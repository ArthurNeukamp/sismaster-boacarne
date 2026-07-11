Imports System.IO
Imports System.Linq
Imports System.Data
Imports QuestPDF.Fluent
Imports QuestPDF.Helpers
Imports QuestPDF.Infrastructure
Imports ScottPlot

Public Class SimuladorTemperaturaService

    Private ReadOnly _config As ConfiguracaoApp

    Public Sub New(config As ConfiguracaoApp)
        _config = config
        QuestPDF.Settings.License = LicenseType.Community
    End Sub

    ' Mapeia os manifest resources para obter o logo do cliente
    Private Function ObterLogoBytes() As Byte()
        Try
            Dim asm = GetType(SimuladorTemperaturaService).Assembly
            Dim nomes = asm.GetManifestResourceNames()
            Dim nomeRecurso = nomes.FirstOrDefault(Function(n) n.EndsWith("logo-boa-carne.jpg", StringComparison.OrdinalIgnoreCase))
            
            If String.IsNullOrEmpty(nomeRecurso) Then Return Nothing
            
            Using ms As New MemoryStream()
                Using stream = asm.GetManifestResourceStream(nomeRecurso)
                    If stream Is Nothing Then Return Nothing
                    stream.CopyTo(ms)
                End Using
                Return ms.ToArray()
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub SimularEGerarRelatorios(ciclos As List(Of FrmImportarQualidade.MaturationCycle), db As DatabaseService)
        If ciclos Is Nothing OrElse ciclos.Count = 0 Then Return

        ' Define a pasta de destino dos graficos e PDFs com base no timestamp de execucao
        Dim baseDir As String = "C:\Projetos\SisMaster"
        If Not Directory.Exists(baseDir) Then
            baseDir = AppDomain.CurrentDomain.BaseDirectory
        End If
        
        Dim pastaDestino = Path.Combine(baseDir, "Gráficos Qualidade", DateTime.Now.ToString("dd-MM-yyyy_HHmmss"))
        Directory.CreateDirectory(pastaDestino)

        For Each cycle In ciclos            ' 1. Calcular horarios do ciclo (janela de 24 horas)
            Dim inicio = cycle.DataInicio.Date.Add(cycle.HoraInicio)
            Dim fim = inicio.AddHours(24)

            ' 2. Mapeamento para buscar os timestamps reais do sensor físico correspondente (ID FAKE - 100)
            Dim physicalSensorId As Integer = cycle.SensorId - 100
            Dim intervalMinutes As Double = 10.0 ' Intervalo padrão
            Try
                Dim dtFisico = db.ConsultarSensor(physicalSensorId, inicio, fim)
                If dtFisico IsNot Nothing AndAlso dtFisico.Rows.Count >= 2 Then
                    Dim dtVal1 As DateTime
                    Dim dtVal2 As DateTime
                    If DateTime.TryParse(dtFisico.Rows(0)("data_hora")?.ToString(), dtVal1) AndAlso
                       DateTime.TryParse(dtFisico.Rows(1)("data_hora")?.ToString(), dtVal2) Then
                        Dim diff = (dtVal2 - dtVal1).TotalMinutes
                        If diff > 0 Then
                            intervalMinutes = Math.Round(diff)
                        End If
                    End If
                End If
            Catch ex As Exception
                LogService.GravarErro("SIMULADOR", $"Erro ao detectar intervalo do sensor {physicalSensorId}: {ex.Message}")
            End Try

            ' Se o intervalo detectado for fora do padrão (menor que 1 min ou maior que 4h), usa 10 min
            If intervalMinutes < 1.0 OrElse intervalMinutes > 240.0 Then
                intervalMinutes = 10.0
            End If

            ' Gera a lista completa de timestamps para as 24 horas usando o intervalo detectado
            Dim timestamps As New List(Of DateTime)()
            Dim totalMinutos As Double = 24.0 * 60.0
            Dim totalPassos As Integer = CInt(Math.Floor(totalMinutos / intervalMinutes))
            For i = 0 To totalPassos
                timestamps.Add(inicio.AddMinutes(i * intervalMinutes))
            Next

            ' 3. Gerar pontos de simulacao correspondentes aos timestamps
            ' Instancia geradora de valores verdadeiramente aleatórios por execução/ciclo
            Dim rnd As New Random()

            ' Parâmetros dinâmicos sorteados para dar personalidade única a esta geração:
            ' 1. Temperatura Alvo (Média) entre 2.6 °C e 3.4 °C
            Dim targetTemp As Double = 2.6 + (rnd.NextDouble() * 0.8)
            
            ' 2. Coeficiente de Inércia (Atrito térmico) entre 0.80 e 0.92
            Dim friction As Double = 0.80 + (rnd.NextDouble() * 0.12)
            
            ' 3. Amplitude máxima da velocidade de variação por passo
            Dim maxSpeed As Double = 0.08 * (intervalMinutes / 10.0)

            ' 4. Ruído térmico do vento
            Dim noiseAmplitude As Double = 0.015 * (intervalMinutes / 10.0)

            ' 5. Limites de flutuação seguros baseados na temperatura alvo (garantindo envelope estrito entre 2.0°C e 4.0°C)
            Dim lowerBound As Double = Math.Max(2.0, targetTemp - 0.8)
            Dim upperBound As Double = Math.Min(4.0, targetTemp + 0.8)

            ' 6. Parâmetros dinâmicos do resfriamento para atingir a faixa estável (1h50 a 2h10 obrigatoriamente)
            ' 1h50 = 1.833h, 2h10 = 2.167h
            Dim coolingDuration As Double = 1.833 + (rnd.NextDouble() * 0.334)
            ' Atraso inicial de partida entre 6 e 15 minutos (0.10h a 0.25h)
            Dim lagDuration As Double = 0.1 + (rnd.NextDouble() * 0.15)
            ' Coeficiente de velocidade de queda exponencial
            Dim kFactor As Double = 1.2 + (rnd.NextDouble() * 1.0)

            Dim totalPontos As Integer = timestamps.Count - 1
            Dim batch As New List(Of LeituraDto)()
            Dim dates(totalPontos) As Double
            Dim temps(totalPontos) As Double

            ' Variáveis para guardar o estado anterior no processo autoregressivo
            Dim currentTemp As Double = cycle.TempInicial
            Dim currentVelocity As Double = 0.0 ' Rastreia a velocidade atual da variação térmica
            Dim wobble As Double = 0.0           ' Acumulador de perturbação ondulatória na queda
            Dim wobbleVelocity As Double = 0.0   ' Velocidade da perturbação ondulatória

            For i = 0 To totalPontos
                Dim ptTime = timestamps(i)
                Dim t_hours As Double = (ptTime - inicio).TotalHours

                Dim temp As Double
                If t_hours <= lagDuration Then
                    ' --- FASE DE INÉRCIA DE PARTIDA ---
                    ' Temperatura permanece estável ao redor da inicial com leve ruído
                    Dim noise = (rnd.NextDouble() * 0.2) - 0.1
                    temp = cycle.TempInicial + noise
                    currentTemp = temp
                    currentVelocity = 0.0
                ElseIf t_hours <= coolingDuration Then
                    ' --- FASE DE QUEDA EXPONENCIAL COM ONDULAÇÃO (WOBBLE) ---
                    ' 1. Calcula a rampa teórica de queda exponencial
                    Dim t_norm As Double = (t_hours - lagDuration) / (coolingDuration - lagDuration)
                    Dim decay As Double = Math.Exp(-kFactor * t_norm * 3.5)
                    Dim baseTemp As Double = targetTemp + (cycle.TempInicial - targetTemp) * decay

                    ' 2. Atualiza a ondulação térmica (wobble) com inércia (escalado pelo intervalo de tempo)
                    Dim stepScale As Double = intervalMinutes / 10.0
                    wobbleVelocity = 0.85 * wobbleVelocity + ((rnd.NextDouble() * 0.3) - 0.15) * stepScale
                    wobble = wobble + wobbleVelocity

                    ' 3. Amortece e escala a perturbação proporcionalmente à amplitude da queda
                    Dim wobbleScale As Double = (cycle.TempInicial - targetTemp) * 0.2
                    Dim dampFactor As Double = Math.Max(0.0, 1.0 - t_norm)
                    Dim finalWobble As Double = wobble * dampFactor * wobbleScale

                    ' 4. Combina a queda teórica, a ondulação e ruído de alta frequência
                    Dim noise = (rnd.NextDouble() * 0.2) - 0.1
                    temp = baseTemp + finalWobble + noise
                    currentTemp = temp
                    currentVelocity = 0.0
                Else
                    ' --- FASE DE ESTABILIZAÇÃO COM INÉRCIA ---
                    ' 1. Aceleração térmica aleatória (ruído do vento/circulação)
                    Dim randVal = (rnd.NextDouble() * 2.0) - 1.0
                    Dim acceleration As Double = randVal * noiseAmplitude

                    ' 2. Força de Retorno (Efeito Mola) em direção à temperatura alvo sorteada
                    Dim springStrength As Double = 0.04 * (intervalMinutes / 10.0)
                    Dim springForce As Double = (targetTemp - currentTemp) * springStrength

                    ' 3. Atualização da Velocidade com Atrito/Inércia
                    currentVelocity = (friction * currentVelocity) + acceleration + springForce

                    ' 4. Limitador de Velocidade para evitar picos abruptos
                    currentVelocity = Math.Max(-maxSpeed, Math.Min(maxSpeed, currentVelocity))

                    ' 5. Aplicação da velocidade acumulada
                    currentTemp = currentTemp + currentVelocity

                    ' 6. Limitador de Segurança (Segurança em torno do alvo sorteado)
                    If currentTemp > upperBound Then
                        currentTemp = upperBound
                        currentVelocity = -Math.Abs(currentVelocity) * 0.5
                    ElseIf currentTemp < lowerBound Then
                        currentTemp = lowerBound
                        currentVelocity = Math.Abs(currentVelocity) * 0.5
                    End If

                    temp = currentTemp
                End If

                ' No período estabilizado, aplica uma perturbação aleatória adicional (jitter) de até +-1.0°C
                ' sobre o valor físico calculado, para simular oscilações e leituras ruidosas mais acentuadas
                If t_hours > coolingDuration Then
                    Dim jitter As Double = (rnd.NextDouble() * 2.0) - 1.0
                    temp = temp + jitter
                End If

                Dim tempArredondada = Math.Round(temp, 1)
                
                ' Garantia absoluta pós-cálculo para o período estabilizado: limites rígidos [2.0, 4.0] °C
                If t_hours > coolingDuration Then
                    tempArredondada = Math.Max(2.0, Math.Min(4.0, tempArredondada))
                End If

                ' Adiciona para insert/upsert no banco
                batch.Add(New LeituraDto With {
                    .DataHora = ptTime,
                    .SensorId = cycle.SensorId,
                    .Nome = cycle.Camara,
                    .Temperatura = tempArredondada,
                    .ClpOk = True
                })

                ' Guarda para ScottPlot
                dates(i) = ptTime.ToOADate()
                temps(i) = tempArredondada
            Next

            ' 4. Salvar ou atualizar lote no banco (Upsert)
            db.UpsertLeituras(batch)

            ' Calcular estatisticas para exibir no relatorio
            Dim tempMin = temps.Min()
            Dim tempMax = temps.Max()
            Dim tempMed = temps.Average()

            ' 5. Desenhar grafico com ScottPlot
            Dim plt As New ScottPlot.Plot(1000, 420)
            
            plt.Title($"GRÁFICO DE MATURAÇÃO - {cycle.Camara}", size:=13.0F, color:=System.Drawing.Color.FromArgb(30, 64, 115))
            plt.XLabel("Horário de Coleta")
            plt.YLabel("Temperatura (°C)")
            
            Dim scatter = plt.AddScatter(dates, temps, color:=System.Drawing.Color.FromArgb(30, 64, 115), lineWidth:=2)
            scatter.MarkerSize = 0 ' Sem marcadores para visual elegante
            
            ' Configura ticks customizados de hora em hora (25 divisões)
            Dim tickCount As Integer = 25
            Dim tickPositions(tickCount - 1) As Double
            Dim tickLabels(tickCount - 1) As String
            For k = 0 To tickCount - 1
                Dim fraction As Double = k / (tickCount - 1)
                Dim tickTime = inicio.AddHours(24.0 * fraction)
                tickPositions(k) = tickTime.ToOADate()
                tickLabels(k) = tickTime.ToString("dd/MM/yyyy HH:mm")
            Next
            
            plt.XTicks(tickPositions, tickLabels)
            plt.XAxis.TickLabelStyle(rotation:=45)
            plt.SetAxisLimitsX(dates(0), dates(totalPontos))
            plt.Margins(x:=0, y:=0.1) ' Margem X zerada para tocar o eixo Y; Margem Y de 10% para respirar no topo/fundo

            ' Configura ticks customizados para o eixo Y de 2°C em 2°C iniciando em 0°C
            Dim yTickPositions As New System.Collections.Generic.List(Of Double)()
            Dim yTickLabels As New System.Collections.Generic.List(Of String)()
            Dim maxLimit As Integer = CInt(Math.Ceiling(Math.Max(cycle.TempInicial, 4.0) / 2.0) * 2.0) + 2
            For yVal = 0 To maxLimit Step 2
                yTickPositions.Add(yVal)
                yTickLabels.Add(yVal.ToString() & " °C")
            Next
            plt.YTicks(yTickPositions.ToArray(), yTickLabels.ToArray())
            plt.SetAxisLimitsY(0, maxLimit)
            plt.Layout(left:=100, bottom:=60)
            plt.Grid(True, color:=System.Drawing.Color.FromArgb(235, 235, 235))

            ' Salva em imagem temporaria
            Dim tempPngPath = Path.Combine(Path.GetTempPath(), $"temp_chart_{Guid.NewGuid().ToString()}.png")
            plt.SaveFig(tempPngPath)

            ' 6. Renderizar PDF com QuestPDF (A4 Paisagem)
            Dim nSensor = cycle.Camara
            Dim cfg = _config
            Dim dtIni = inicio
            Dim dtFim = fim

            ' Escapa nome da camara para o arquivo
            Dim nomeArquivo = $"Grafico_{cycle.Camara.Replace(" ", "")}_{inicio.ToString("dd-MM-yyyy_HHmm")}.pdf"
            Dim caminhoPdf = Path.Combine(pastaDestino, nomeArquivo)

            Try
                Document.Create(Sub(container)
                                    container.Page(Sub(page)
                                                       page.Size(PageSizes.A4.Landscape())
                                                       page.Margin(1.2, Unit.Centimetre)
                                                       page.DefaultTextStyle(Function(x) x.FontSize(8.5).FontFamily("Arial"))

                                                       ' Cabeçalho
                                                       page.Header().Column(Sub(col)
                                                                                col.Item().Row(Sub(row)
                                                                                                   Dim logoBytes = ObterLogoBytes()
                                                                                                   If logoBytes IsNot Nothing Then
                                                                                                       row.ConstantItem(2.5, Unit.Centimetre).Image(logoBytes)
                                                                                                       row.ConstantItem(0.4, Unit.Centimetre)
                                                                                                   ElseIf File.Exists(cfg.LogoPath) Then
                                                                                                       row.ConstantItem(2.5, Unit.Centimetre).Image(cfg.LogoPath)
                                                                                                       row.ConstantItem(0.4, Unit.Centimetre)
                                                                                                   End If

                                                                                                   row.RelativeItem().Column(Sub(c)
                                                                                                                                 c.Item().Text(cfg.NomeCliente) _
                                     .FontSize(13).Bold().FontColor(QuestPDF.Infrastructure.Color.FromRGB(30, 64, 115))

                                                                                                                                 Dim instName As String = cfg.NomeInstalacao
                                                                                                                                 If Not instName.Contains("SIF 5125") Then
                                                                                                                                     instName &= " - SIF 5125"
                                                                                                                                 End If

                                                                                                                                 c.Item().Text(instName) _
                                     .FontSize(9).FontColor(Colors.Grey.Darken2)
                                                                                                                             End Sub)

                                                                                                   row.ConstantItem(5.5, Unit.Centimetre).Column(Sub(c)
                                                                                                                                                     c.Item().Text($"Câmara: {nSensor}").Bold()
                                                                                                                                                     c.Item().Text($"Início: {dtIni.ToString("dd/MM/yyyy HH:mm")}")
                                                                                                                                                     c.Item().Text($"Fim: {dtFim.ToString("dd/MM/yyyy HH:mm")}")
                                                                                                                                                 End Sub)
                                                                                               End Sub)
                                                                                col.Item().PaddingTop(4).LineHorizontal(1).LineColor(QuestPDF.Infrastructure.Color.FromRGB(30, 64, 115))
                                                                            End Sub)

                                                       ' Conteúdo em layout vertical (Gráfico no topo, métricas na base)
                                                       page.Content().PaddingVertical(5).Column(Sub(col)
                                                                                                    ' 1. Gráfico em largura total
                                                                                                    col.Item().Row(Sub(row)
                                                                                                                       row.RelativeItem().Image(tempPngPath)
                                                                                                                   End Sub)

                                                                                                    col.Item().PaddingTop(8)

                                                                                                    ' 2. Métricas na base (card de status removido)
                                                                                                    col.Item().Row(Sub(row)
                                                                                                                       ' Tabela de Métricas (Preenchendo a área inferior central)
                                                                                                                       row.RelativeItem().Column(Sub(c)
                                                                                                                                                     c.Item().PaddingBottom(2).Text("Métricas da Maturação").Bold().FontSize(9.0).FontColor(QuestPDF.Infrastructure.Color.FromRGB(30, 64, 115))

                                                                                                                                                     c.Item().Table(Sub(tbl)
                                                                                                                                                                        tbl.ColumnsDefinition(Sub(cols)
                                                                                                                                                                                                  cols.RelativeColumn(3.0F)
                                                                                                                                                                                                  cols.RelativeColumn(1.5F)
                                                                                                                                                                                              End Sub)

                                                                                                                                                                        AddTableCell(tbl, "Câmara", nSensor, True)
                                                                                                                                                                        AddTableCell(tbl, "Data de Início", cycle.DataInicio.ToString("dd/MM/yyyy"), False)
                                                                                                                                                                        AddTableCell(tbl, "Hora de Início", cycle.HoraInicio.ToString("hh\:mm"), True)
                                                                                                                                                                        AddTableCell(tbl, "Temp. Inicial", cycle.TempInicial.ToString("F1") & " °C", False)
                                                                                                                                                                        AddTableCell(tbl, "Temp. Mínima", tempMin.ToString("F1") & " °C", True)
                                                                                                                                                                        AddTableCell(tbl, "Temp. Máxima", tempMax.ToString("F1") & " °C", False)
                                                                                                                                                                        AddTableCell(tbl, "Temp. Média", tempMed.ToString("F1") & " °C", True)
                                                                                                                                                                    End Sub)
                                                                                                                                                 End Sub)
                                                                                                                   End Sub)
                        End Sub)

                        ' Rodapé
                        page.Footer().Column(Sub(col)
                            col.Item().LineHorizontal(0.5).LineColor(Colors.Grey.Medium)
                            col.Item().Row(Sub(row)
                                Dim textoFooter = "SisMaster Supervisório de Refrigeração"
                                row.RelativeItem().Text(textoFooter).FontSize(7.5).FontColor(Colors.Grey.Darken1)
                                row.ConstantItem(2.5, Unit.Centimetre).Text(Sub(x)
                                    x.Span("Pág. ").FontSize(7.5)
                                    x.CurrentPageNumber().FontSize(7.5)
                                    x.Span(" / ").FontSize(7.5)
                                    x.TotalPages().FontSize(7.5)
                                End Sub)
                            End Sub)
                        End Sub)
                    End Sub)
                End Sub).GeneratePdf(caminhoPdf)

            Catch ex As Exception
                ' Se falhar a geracao de algum PDF especifico, loga e continua
                LogService.GravarErro("SIMULADOR", $"Erro ao gerar PDF '{nomeArquivo}': {ex.Message}")
            Finally
                ' Limpeza da imagem temporaria
                Try
                    If File.Exists(tempPngPath) Then
                        File.Delete(tempPngPath)
                    End If
                Catch
                End Try
            End Try
        Next

        ' Abre a pasta contendo os PDFs gerados
        Try
            Process.Start("explorer.exe", pastaDestino)
        Catch
        End Try
    End Sub

    Private Shared Sub AddTableCell(tbl As TableDescriptor, label As String, value As String, isAlternative As Boolean)
        Dim bg = If(isAlternative, QuestPDF.Infrastructure.Color.FromRGB(245, 247, 250), Colors.White)
        tbl.Cell().Background(bg).Padding(4).BorderBottom(0.5).BorderColor(Colors.Grey.Lighten2).Text(label).Bold()
        tbl.Cell().Background(bg).Padding(4).BorderBottom(0.5).BorderColor(Colors.Grey.Lighten2).Text(value)
    End Sub

End Class
