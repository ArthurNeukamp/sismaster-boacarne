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

    Private Class DefrostRange
        Public StartTime As DateTime
        Public DurationMinutes As Integer
        Public EndTime As DateTime
        Public CooldownEndTime As DateTime
        Public TempMin As Double
        Public TempMax As Double
        Public PeakTemp As Double

        Public Sub New(start As DateTime, dur As Integer, tMax As Double, rnd As Random)
            StartTime = start
            DurationMinutes = dur
            EndTime = start.AddMinutes(dur)
            CooldownEndTime = EndTime.AddMinutes(45)
            TempMin = tMax - 4.0
            TempMax = tMax
            ' Temperatura de pico sorteada entre [TempMax - 4.0, TempMax]
            PeakTemp = tMax - (rnd.NextDouble() * 4.0)
        End Sub
    End Class

    Public Sub SimularEGerarRelatorios(ciclos As List(Of FrmImportarQualidade.MaturationCycle), db As DatabaseService)
        If ciclos Is Nothing OrElse ciclos.Count = 0 Then Return

        ' Define a pasta de destino dos graficos e PDFs com base no timestamp de execucao
        Dim baseDir As String = "C:\Projetos\SisMaster"
        If Not Directory.Exists(baseDir) Then
            baseDir = AppDomain.CurrentDomain.BaseDirectory
        End If
        
        Dim pastaDestino = Path.Combine(baseDir, "Gráficos Qualidade", DateTime.Now.ToString("dd-MM-yyyy_HHmmss"))
        Directory.CreateDirectory(pastaDestino)

        For Each cycle In ciclos
            Dim temCarregamento As Boolean = cycle.TemCarregamento
            Dim carregamento As DateTime = If(temCarregamento, cycle.DataCarregamento.Value.Date.Add(cycle.HoraCarregamento.Value), cycle.DataInicio.Date.Add(cycle.HoraInicio))
            Dim tempCarregamento As Double = If(temCarregamento, cycle.TempCarregamento.Value, cycle.TempInicial)
            Dim inicio As DateTime = cycle.DataInicio.Date.Add(cycle.HoraInicio)
            Dim tempInicialRef As Double = cycle.TempInicial
            Dim fim = cycle.DataFim.Date.Add(cycle.HoraFim)
            Dim duracaoHoras As Double = (fim - carregamento).TotalHours

            ' 2. Mapeamento para buscar os timestamps reais do sensor físico correspondente (ID FAKE - 100)
            Dim physicalSensorId As Integer = cycle.SensorId - 100
            Dim intervalMinutes As Double = 10.0 ' Intervalo padrão
            Dim timestamps As New List(Of DateTime)()

            Try
                Dim dtFisico = db.ConsultarSensor(physicalSensorId, carregamento, fim)
                If dtFisico IsNot Nothing AndAlso dtFisico.Rows.Count > 0 Then
                    ' Extrai as datas/horas exatas gravadas no banco pelo sensor físico real
                    Dim setHorarios As New HashSet(Of DateTime)()
                    For Each row As DataRow In dtFisico.Rows
                        Dim dtParsed As DateTime
                        If DateTime.TryParse(row("data_hora")?.ToString(), dtParsed) Then
                            Dim dtRedonda As New DateTime(dtParsed.Year, dtParsed.Month, dtParsed.Day, dtParsed.Hour, dtParsed.Minute, 0)
                            If Not setHorarios.Contains(dtRedonda) Then
                                setHorarios.Add(dtRedonda)
                                timestamps.Add(dtRedonda)
                            End If
                        End If
                    Next

                    ' Detectar o intervalo médio entre as coletas reais para prosseguir se o ciclo avançar além do último dado real
                    If dtFisico.Rows.Count >= 2 Then
                        Dim dtVal1, dtVal2 As DateTime
                        If DateTime.TryParse(dtFisico.Rows(0)("data_hora")?.ToString(), dtVal1) AndAlso
                           DateTime.TryParse(dtFisico.Rows(1)("data_hora")?.ToString(), dtVal2) Then
                            Dim diff = (dtVal2 - dtVal1).TotalMinutes
                            If diff > 0 Then intervalMinutes = Math.Round(diff)
                        End If
                    End If
                End If
            Catch ex As Exception
                LogService.GravarErro("SIMULADOR", $"Erro ao carregar timestamps reais do sensor {physicalSensorId}: {ex.Message}")
            End Try

            If intervalMinutes < 1.0 OrElse intervalMinutes > 240.0 Then intervalMinutes = 10.0

            ' Se não havia dados reais no banco para o período (ou para estender até o Fim do ciclo), completa a lista de timestamps
            If timestamps.Count = 0 Then
                Dim carregamentoRedondo As New DateTime(carregamento.Year, carregamento.Month, carregamento.Day, carregamento.Hour, carregamento.Minute, 0)
                Dim currTime = carregamentoRedondo
                While currTime <= fim
                    timestamps.Add(currTime)
                    currTime = currTime.AddMinutes(intervalMinutes)
                End While
            Else
                Dim ultimoHorarioReal = timestamps.Last()
                Dim currTime = ultimoHorarioReal.AddMinutes(intervalMinutes)
                While currTime <= fim
                    timestamps.Add(currTime)
                    currTime = currTime.AddMinutes(intervalMinutes)
                End While
            End If

            ' 3. Gerar pontos de simulacao correspondentes aos timestamps
            Dim rnd As New Random()
            Dim targetTemp As Double = 2.6 + (rnd.NextDouble() * 0.8)
            Dim friction As Double = 0.80 + (rnd.NextDouble() * 0.12)
            Dim maxSpeed As Double = 0.08 * (intervalMinutes / 10.0)
            Dim noiseAmplitude As Double = 0.015 * (intervalMinutes / 10.0)
            Dim lowerBound As Double = Math.Max(2.2, targetTemp - 0.8)
            Dim upperBound As Double = Math.Min(3.8, targetTemp + 0.8)

            ' Seleção randômica do perfil de descida da câmara (0: Exponencial, 1: Sigmoidal/Curva S, 2: Inércia Térmica, 3: Duplo Estágio)
            Dim profileType As Integer = rnd.Next(0, 4)
            Dim coolingDuration As Double
            Dim lagDuration As Double

            Select Case profileType
                Case 0 ' Exponencial Padrão
                    coolingDuration = 1.8 + (rnd.NextDouble() * 0.7)
                    lagDuration = 0.1 + (rnd.NextDouble() * 0.15)
                Case 1 ' Sigmoidal / Curva S
                    coolingDuration = 2.2 + (rnd.NextDouble() * 0.8)
                    lagDuration = 0.15 + (rnd.NextDouble() * 0.2)
                Case 2 ' Inércia Térmica / Lag Prolongado (Retém de 20 a 45 min)
                    coolingDuration = 2.5 + (rnd.NextDouble() * 0.8)
                    lagDuration = 0.35 + (rnd.NextDouble() * 0.4)
                Case Else ' Duplo Estágio com Ciclagem
                    coolingDuration = 2.4 + (rnd.NextDouble() * 0.6)
                    lagDuration = 0.15 + (rnd.NextDouble() * 0.2)
            End Select

            Dim kFactor As Double = 1.2 + (rnd.NextDouble() * 1.0)

            ' Preparar dados dos degelos para busca rápida no loop de pontos
            Dim activeDegelos As New List(Of DefrostRange)()
            If cycle.Degelo1_Data.HasValue AndAlso cycle.Degelo1_Hora.HasValue Then
                Dim dStart = cycle.Degelo1_Data.Value.Date.Add(cycle.Degelo1_Hora.Value)
                activeDegelos.Add(New DefrostRange(dStart, cycle.Degelo1_Duracao, cycle.Degelo1_TempMax, rnd))
            End If
            If cycle.Degelo2_Data.HasValue AndAlso cycle.Degelo2_Hora.HasValue Then
                Dim dStart = cycle.Degelo2_Data.Value.Date.Add(cycle.Degelo2_Hora.Value)
                activeDegelos.Add(New DefrostRange(dStart, cycle.Degelo2_Duracao, cycle.Degelo2_TempMax, rnd))
            End If
            If cycle.Degelo3_Data.HasValue AndAlso cycle.Degelo3_Hora.HasValue Then
                Dim dStart = cycle.Degelo3_Data.Value.Date.Add(cycle.Degelo3_Hora.Value)
                activeDegelos.Add(New DefrostRange(dStart, cycle.Degelo3_Duracao, cycle.Degelo3_TempMax, rnd))
            End If

            Dim totalPontos As Integer = timestamps.Count - 1
            Dim batch As New List(Of LeituraDto)()
            Dim dates(totalPontos) As Double
            Dim temps(totalPontos) As Double

            Dim currentTemp As Double = tempCarregamento
            Dim currentVelocity As Double = 0.0
            Dim wobble As Double = 0.0
            Dim wobbleVelocity As Double = 0.0

            For i = 0 To totalPontos
                Dim ptTime = timestamps(i)

                Dim temp As Double
                
                ' Verifica se o timestamp está dentro de um degelo ou do período de cooldown de 45 minutos
                Dim currentDefrost As DefrostRange = Nothing
                Dim isCooldown As Boolean = False

                For Each d In activeDegelos
                    If ptTime >= d.StartTime AndAlso ptTime <= d.EndTime Then
                        currentDefrost = d
                        isCooldown = False
                        Exit For
                    ElseIf ptTime > d.EndTime AndAlso ptTime <= d.CooldownEndTime Then
                        currentDefrost = d
                        isCooldown = True
                        Exit For
                    End If
                Next

                If currentDefrost IsNot Nothing Then
                    If Not isCooldown Then
                        Dim elapsedMinutes = (ptTime - currentDefrost.StartTime).TotalMinutes
                        Dim progress = elapsedMinutes / currentDefrost.DurationMinutes
                        Dim peakTemp = currentDefrost.PeakTemp

                        If progress < 0.5 Then
                            Dim startTempOfDefrost As Double = cycle.TempInicial
                            temp = startTempOfDefrost + (peakTemp - startTempOfDefrost) * (progress / 0.5)
                            
                            Dim jitter = (rnd.NextDouble() * 1.0) - 0.5
                            temp = temp + jitter
                            temp = Math.Min(currentDefrost.TempMax, temp)
                        Else
                            temp = peakTemp
                            
                            Dim jitter = (rnd.NextDouble() * 1.0) - 0.5
                            temp = temp + jitter
                            temp = Math.Max(currentDefrost.TempMin, Math.Min(currentDefrost.TempMax, temp))
                        End If
                        currentTemp = temp
                        currentVelocity = 0.0
                    Else
                        Dim elapsedCooldown = (ptTime - currentDefrost.EndTime).TotalMinutes
                        Dim progressCooldown = elapsedCooldown / 45.0
                        Dim decay = Math.Exp(-3.0 * progressCooldown)

                        Dim peakTemp = currentDefrost.PeakTemp
                        temp = targetTemp + (peakTemp - targetTemp) * decay

                        Dim noise = (rnd.NextDouble() * 0.2) - 0.1
                        temp = temp + noise
                        currentTemp = temp
                        currentVelocity = 0.0
                    End If
                Else
                    If temCarregamento AndAlso ptTime < inicio Then
                        ' Descida da TempCarregamento para TempInicial no carregamento (Fase 1)
                        Dim t_hours_carreg As Double = (ptTime - carregamento).TotalHours
                        Dim loadingDuration As Double = (inicio - carregamento).TotalHours
                        Dim t_norm As Double = t_hours_carreg / loadingDuration
                        Dim exponent As Double = 1.3 + (rnd.NextDouble() * 0.6)
                        Dim decay As Double = Math.Pow(Math.Max(0.0, 1.0 - t_norm), exponent)
                        Dim baseTemp As Double = tempInicialRef + (tempCarregamento - tempInicialRef) * decay

                        Dim stepScale As Double = intervalMinutes / 10.0
                        wobbleVelocity = 0.85 * wobbleVelocity + ((rnd.NextDouble() * 0.3) - 0.15) * stepScale
                        wobble = wobble + wobbleVelocity

                        Dim wobbleScale As Double = (cycle.TempCarregamento - tempInicialRef) * 0.2
                        Dim dampFactor As Double = Math.Max(0.0, 1.0 - t_norm)
                        Dim finalWobble As Double = wobble * dampFactor * wobbleScale

                        ' Ruído com amortecimento para que varie apenas de 0 a -1°C no momento exato do início
                        Dim noise As Double = ((rnd.NextDouble() * 2.0) - 1.0) * dampFactor + (1.0 - dampFactor) * (rnd.NextDouble() * -1.0)
                        temp = baseTemp + finalWobble + noise
                        currentTemp = temp
                        currentVelocity = 0.0
                    Else
                        ' Bypass ou Fase 2: Transição de descida suave (1h50 a 2h50) partindo de tempInicialRef (TempInicial ou TempCarregamento)
                        Dim t_hours As Double = (ptTime - inicio).TotalHours
                        
                        If t_hours <= lagDuration Then
                            ' Período de lag logo após o início: oscilação suave em torno da temperatura inicial
                            Dim noise = (rnd.NextDouble() * 0.6) - 0.3
                            temp = tempInicialRef + noise
                            currentTemp = temp
                            currentVelocity = 0.0
                        ElseIf t_hours <= coolingDuration Then
                            ' Período de descida contínua pós-início rumo à estabilização
                            Dim t_norm As Double = (t_hours - lagDuration) / (coolingDuration - lagDuration)
                            Dim decay As Double

                            Select Case profileType
                                Case 0 ' Exponencial Padrão
                                    decay = Math.Exp(-kFactor * t_norm * 3.5)
                                Case 1 ' Curva S (Sigmoidal)
                                    Dim s_factor As Double = t_norm * t_norm * (3.0 - 2.0 * t_norm)
                                    decay = 1.0 - s_factor
                                Case 2 ' Inércia / Convexa
                                    decay = Math.Pow(Math.Max(0.0, 1.0 - t_norm), 1.8)
                                Case Else ' Duplo Estágio com Ciclagem
                                    Dim base_decay As Double = Math.Exp(-kFactor * t_norm * 3.0)
                                    Dim bump As Double = 0.18 * Math.Sin(t_norm * Math.PI * 2.0)
                                    decay = Math.Min(1.0, Math.Max(0.0, base_decay + bump))
                            End Select

                            Dim baseTemp As Double = targetTemp + (tempInicialRef - targetTemp) * decay

                            Dim noise = (rnd.NextDouble() * 0.8) - 0.4
                            temp = baseTemp + noise
                            temp = Math.Max(2.2, temp)
                            currentTemp = temp
                            currentVelocity = 0.0
                        Else
                            ' Fase de maturação estabilizada e ruidosa normal
                            Dim randVal = (rnd.NextDouble() * 2.0) - 1.0
                            Dim acceleration As Double = randVal * noiseAmplitude

                            Dim springStrength As Double = 0.04 * (intervalMinutes / 10.0)
                            Dim springForce As Double = (targetTemp - currentTemp) * springStrength

                            currentVelocity = (friction * currentVelocity) + acceleration + springForce
                            currentVelocity = Math.Max(-maxSpeed, Math.Min(maxSpeed, currentVelocity))

                            currentTemp = currentTemp + currentVelocity

                            If currentTemp > upperBound Then
                                currentTemp = upperBound
                                currentVelocity = -Math.Abs(currentVelocity) * 0.5
                            ElseIf currentTemp < lowerBound Then
                                currentTemp = lowerBound
                                currentVelocity = Math.Abs(currentVelocity) * 0.5
                            End If

                            temp = currentTemp

                            ' Restaurando o jitter e o clamping originais que garantem a aleatoriedade
                            Dim jitter As Double = (rnd.NextDouble() * 2.0) - 1.0
                            temp = temp + jitter
                            temp = Math.Max(2.2, Math.Min(3.8, temp))
                        End If
                    End If
                End If

                Dim tempArredondada = Math.Round(temp, 1)

                batch.Add(New LeituraDto With {
                    .DataHora = ptTime,
                    .SensorId = cycle.SensorId,
                    .Nome = cycle.Camara,
                    .Temperatura = tempArredondada,
                    .ClpOk = True
                })

                dates(i) = ptTime.ToOADate()
                temps(i) = tempArredondada
            Next

            db.LimparPeriodoSensor(cycle.SensorId, carregamento, fim)
            db.UpsertLeituras(batch)

            Dim dadosSalvos = db.ConsultarSensor(cycle.SensorId, carregamento, fim)
            Dim totalPontosSalvos = dadosSalvos.Rows.Count
            
            Dim datesSalvas(totalPontosSalvos - 1) As Double
            Dim tempsSalvas(totalPontosSalvos - 1) As Double
            For idx = 0 To totalPontosSalvos - 1
                Dim row = dadosSalvos.Rows(idx)
                Dim dh As DateTime = Convert.ToDateTime(row("data_hora"))
                datesSalvas(idx) = dh.ToOADate()
                tempsSalvas(idx) = Convert.ToDouble(row("temperatura"))
            Next

            Dim isMaturacao = IsSensorMaturacao(cycle.SensorId)

            ' Filtrar dados térmicos especificamente a partir do Início da Maturação para os cálculos de métricas
            Dim tempsMaturacao As New List(Of Double)()
            For idx = 0 To totalPontosSalvos - 1
                Dim row = dadosSalvos.Rows(idx)
                Dim dh As DateTime = Convert.ToDateTime(row("data_hora"))
                If Not isMaturacao OrElse dh >= inicio Then
                    tempsMaturacao.Add(Convert.ToDouble(row("temperatura")))
                End If
            Next
            If tempsMaturacao.Count = 0 Then
                tempsMaturacao.AddRange(tempsSalvas)
            End If

            Dim tempMin = tempsMaturacao.Min()
            Dim tempMax = tempsMaturacao.Max()
            Dim tempMed = tempsMaturacao.Average()
            Dim tempFinalRef = tempsSalvas(tempsSalvas.Length - 1)

            Dim plt As New ScottPlot.Plot(2500, 1050)

            Dim nSensor = cycle.Camara.Trim()
            Dim tituloGrafico = If(isMaturacao, $"GRÁFICO DE MATURAÇÃO - {nSensor.ToUpper()}", $"GRÁFICO - {nSensor.ToUpper()}")
            plt.Title(tituloGrafico, size:=30, color:=System.Drawing.Color.FromArgb(30, 64, 115), bold:=True)

            plt.AddScatter(datesSalvas, tempsSalvas, color:=System.Drawing.Color.FromArgb(30, 64, 115), lineWidth:=5, markerSize:=0)

            ConfigurarEixosGrafico(plt, carregamento, fim, datesSalvas, tempsSalvas)

            Dim tempPngPath = Path.Combine(Path.GetTempPath(), $"temp_chart_{Guid.NewGuid().ToString()}.png")
            plt.SaveFig(tempPngPath)

            Dim nomeArquivo = $"Grafico_{cycle.Camara.Replace(" ", "")}_{carregamento.ToString("dd-MM-yyyy_HHmm")}.pdf"
            Dim caminhoPdf = Path.Combine(pastaDestino, nomeArquivo)

            Try
                Dim nomeCliente = If(String.IsNullOrWhiteSpace(_config.NomeCliente), "FRIGORÍFICO BOA CARNE", _config.NomeCliente.ToUpper())
                Dim subCabecalho = _config.NomeInstalacao
                If Not String.IsNullOrEmpty(subCabecalho) AndAlso Not subCabecalho.Contains("SIF 5125") Then
                    subCabecalho &= " - SIF 5125"
                ElseIf String.IsNullOrEmpty(subCabecalho) Then
                    subCabecalho = "FRIGORÍFICO BOA CARNE - SIF 5125"
                End If
                Dim logoBytes = ObterLogoBytes()

                Document.Create(Sub(container)
                                    container.Page(Sub(page)
                                                       page.Size(PageSizes.A4.Landscape())
                                                       page.Margin(1.0, Unit.Centimetre)
                                                       page.PageColor(Colors.White)
                                                       page.DefaultTextStyle(Function(x) x.FontSize(8.5).FontFamily("Arial"))

                                                       ' Cabeçalho
                                                       page.Header().Column(Sub(colHeader)
                                                                                colHeader.Item().Row(Sub(row)
                                                                                                         If logoBytes IsNot Nothing Then
                                                                                                             row.ConstantItem(2.5, Unit.Centimetre).Image(logoBytes)
                                                                                                             row.ConstantItem(0.4, Unit.Centimetre)
                                                                                                         ElseIf File.Exists(_config.LogoPath) Then
                                                                                                             row.ConstantItem(2.5, Unit.Centimetre).Image(_config.LogoPath)
                                                                                                             row.ConstantItem(0.4, Unit.Centimetre)
                                                                                                         End If

                                                                                                         row.RelativeItem().Column(Sub(c)
                                                                                                                                       c.Item().Text(nomeCliente).FontSize(13).Bold().FontColor(QuestPDF.Infrastructure.Color.FromRGB(30, 64, 115))
                                                                                                                                       c.Item().Text(subCabecalho).FontSize(9).FontColor(Colors.Grey.Darken2)
                                                                                                                                   End Sub)

                                                                                                         row.ConstantItem(7.5, Unit.Centimetre).Column(Sub(c)
                                                                                                                                                           Dim rotuloAmbiente = If(isMaturacao, "Câmara", "Ambiente")
                                                                                                                                                           c.Item().Text($"{rotuloAmbiente}: {nSensor}").Bold()
                                                                                                                                                           c.Item().Text($"Início: {carregamento.ToString("dd/MM/yyyy HH:mm")}")
                                                                                                                                                           c.Item().Text($"Fim: {fim.ToString("dd/MM/yyyy HH:mm")}")
                                                                                                                                                       End Sub)
                                                                                                     End Sub)
                                                                                colHeader.Item().PaddingTop(4).LineHorizontal(1).LineColor(QuestPDF.Infrastructure.Color.FromRGB(30, 64, 115))
                                                                            End Sub)

                                                       ' Conteúdo vertical
                                                       page.Content().PaddingVertical(2).Column(Sub(col)
                                                                                                    col.Item().Row(Sub(row)
                                                                                                                       row.RelativeItem().Image(tempPngPath)
                                                                                                                   End Sub)

                                                                                                    col.Item().PaddingTop(4)

                                                                                                    col.Item().Row(Sub(row)
                                                                                                                       row.RelativeItem().Column(Sub(c)
                                                                                                                                                     Dim tituloMetricas = If(isMaturacao, "Métricas da Maturação", "Métricas de Temperatura")
                                                                                                                                                     c.Item().PaddingBottom(2).Text(tituloMetricas).Bold().FontSize(9.0).FontColor(QuestPDF.Infrastructure.Color.FromRGB(30, 64, 115))

                                                                                                                                                     c.Item().Table(Sub(tbl)
                                                                                                                                                                        tbl.ColumnsDefinition(Sub(cols)
                                                                                                                                                                                                  cols.RelativeColumn(3.0F)
                                                                                                                                                                                                  cols.RelativeColumn(1.5F)
                                                                                                                                                                                              End Sub)

                                                                                                                                                                        Dim rotuloAmbiente = If(isMaturacao, "Câmara", "Ambiente")
                                                                                                                                                                        AddTableCell(tbl, rotuloAmbiente, nSensor, True)
                                                                                                                                                                        If isMaturacao Then
                                                                                                                                                                            AddTableCell(tbl, "Data/Hora de Início de Maturação", cycle.DataInicio.ToString("dd/MM/yyyy") & " " & cycle.HoraInicio.ToString("hh\:mm"), False)
                                                                                                                                                                            AddTableCell(tbl, "Data/Hora de Fim de Maturação", cycle.DataFim.ToString("dd/MM/yyyy") & " " & cycle.HoraFim.ToString("hh\:mm"), True)
                                                                                                                                                                            AddTableCell(tbl, "Temp. Inicial de Maturação", cycle.TempInicial.ToString("F1") & " °C", False)
                                                                                                                                                                            AddTableCell(tbl, "Temp. Final de Maturação", tempFinalRef.ToString("F1") & " °C", True)
                                                                                                                                                                            AddTableCell(tbl, "Temp. Mínima Durante Maturação", tempMin.ToString("F1") & " °C", False)
                                                                                                                                                                            AddTableCell(tbl, "Temp. Máxima Durante Maturação", tempMax.ToString("F1") & " °C", True)
                                                                                                                                                                            AddTableCell(tbl, "Temp. Média Durante Maturação", tempMed.ToString("F1") & " °C", False)
                                                                                                                                                                        Else
                                                                                                                                                                            AddTableCell(tbl, "Data/Hora de Início", cycle.DataInicio.ToString("dd/MM/yyyy") & " " & cycle.HoraInicio.ToString("hh\:mm"), False)
                                                                                                                                                                            AddTableCell(tbl, "Data/Hora de Fim", cycle.DataFim.ToString("dd/MM/yyyy") & " " & cycle.HoraFim.ToString("hh\:mm"), True)
                                                                                                                                                                            AddTableCell(tbl, "Temp. Inicial", cycle.TempInicial.ToString("F1") & " °C", False)
                                                                                                                                                                            AddTableCell(tbl, "Temp. Final", tempFinalRef.ToString("F1") & " °C", True)
                                                                                                                                                                            AddTableCell(tbl, "Temp. Mínima", tempMin.ToString("F1") & " °C", False)
                                                                                                                                                                            AddTableCell(tbl, "Temp. Máxima", tempMax.ToString("F1") & " °C", True)
                                                                                                                                                                            AddTableCell(tbl, "Temp. Média", tempMed.ToString("F1") & " °C", False)
                                                                                                                                                                        End If
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

                ' --- 6.1. GERAR RELATÓRIO PADRÃO POR LISTA NA MESMA PASTA ---
                Try
                    Dim dadosRelatorio As New DataTable()
                    dadosRelatorio.Columns.Add("data_hora_fmt", GetType(String))
                    dadosRelatorio.Columns.Add("temperatura", GetType(Double))

                    For Each row As DataRow In dadosSalvos.Rows
                        Dim dr = dadosRelatorio.NewRow()
                        Dim dh As DateTime = Convert.ToDateTime(row("data_hora"))
                        dr("data_hora_fmt") = dh.ToString("dd/MM/yyyy HH:mm:ss")
                        dr("temperatura") = Convert.ToDouble(row("temperatura"))
                        dadosRelatorio.Rows.Add(dr)
                    Next

                    Dim relService As New RelatorioService(_config)
                    Dim nomeArquivoList = $"Relatorio_{cycle.Camara.Replace(" ", "")}_{carregamento.ToString("dd-MM-yyyy_HHmm")}.pdf"
                    Dim caminhoListPdf = Path.Combine(pastaDestino, nomeArquivoList)
                    relService.ExportarPDF(dadosRelatorio, caminhoListPdf, cycle.Camara, carregamento, fim)
                Catch ex As Exception
                    LogService.GravarErro("SIMULADOR", $"Erro ao exportar relatório por lista para câmara {cycle.Camara}: {ex.Message}")
                End Try

            Catch ex As Exception
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
        tbl.Cell().Background(bg).Padding(2.5).BorderBottom(0.5).BorderColor(Colors.Grey.Lighten2).Text(label).Bold()
        tbl.Cell().Background(bg).Padding(2.5).BorderBottom(0.5).BorderColor(Colors.Grey.Lighten2).Text(value)
    End Sub

    Private Shared Function IsSensorMaturacao(sensorId As Integer) As Boolean
        Return (sensorId >= 21 AndAlso sensorId <= 27) OrElse (sensorId >= 121 AndAlso sensorId <= 127)
    End Function

    Public Sub GerarGraficoPDFExclusivo(sensorId As Integer, camaraNome As String, inicio As DateTime, fim As DateTime, db As DatabaseService, caminhoPdf As String)
        Dim dadosSalvos = db.ConsultarSensor(sensorId, inicio, fim)
        Dim totalPontosSalvos = dadosSalvos.Rows.Count
        If totalPontosSalvos = 0 Then
            Throw New Exception("Nenhum registro encontrado no banco de dados para o sensor selecionado no período informado.")
        End If

        Dim datesSalvas(totalPontosSalvos - 1) As Double
        Dim tempsSalvas(totalPontosSalvos - 1) As Double
        For idx = 0 To totalPontosSalvos - 1
            Dim row = dadosSalvos.Rows(idx)
            Dim dh As DateTime = Convert.ToDateTime(row("data_hora"))
            datesSalvas(idx) = dh.ToOADate()
            tempsSalvas(idx) = Convert.ToDouble(row("temperatura"))
        Next

        Dim tempMin = tempsSalvas.Min()
        Dim tempMax = tempsSalvas.Max()
        Dim tempMed = tempsSalvas.Average()
        Dim tempFinalRef = tempsSalvas(tempsSalvas.Length - 1)

        Dim plt As New ScottPlot.Plot(2500, 1050)

        Dim isMaturacao = IsSensorMaturacao(sensorId)
        Dim nSensor = camaraNome.Trim()
        Dim tituloGrafico = If(isMaturacao, $"GRÁFICO DE MATURAÇÃO - {nSensor.ToUpper()}", $"GRÁFICO - {nSensor.ToUpper()}")
        plt.Title(tituloGrafico, size:=30, color:=System.Drawing.Color.FromArgb(30, 64, 115), bold:=True)

        plt.AddScatter(datesSalvas, tempsSalvas, color:=System.Drawing.Color.FromArgb(30, 64, 115), lineWidth:=5, markerSize:=0)

        ConfigurarEixosGrafico(plt, inicio, fim, datesSalvas, tempsSalvas)

        Dim tempPngPath = Path.Combine(Path.GetTempPath(), $"temp_chart_{Guid.NewGuid().ToString()}.png")
        plt.SaveFig(tempPngPath)

        Try
            Dim nomeCliente = If(String.IsNullOrWhiteSpace(_config.NomeCliente), "FRIGORÍFICO BOA CARNE", _config.NomeCliente.ToUpper())
            Dim subCabecalho = _config.NomeInstalacao
            If Not String.IsNullOrEmpty(subCabecalho) AndAlso Not subCabecalho.Contains("SIF 5125") Then
                subCabecalho &= " - SIF 5125"
            ElseIf String.IsNullOrEmpty(subCabecalho) Then
                subCabecalho = "FRIGORÍFICO BOA CARNE - SIF 5125"
            End If

            Dim logoBytes = ObterLogoBytes()

            Document.Create(Sub(container)
                                container.Page(Sub(page)
                                                   page.Size(PageSizes.A4.Landscape())
                                                   page.Margin(1.0, Unit.Centimetre)
                                                   page.PageColor(Colors.White)
                                                   page.DefaultTextStyle(Function(x) x.FontSize(8.5).FontFamily("Arial"))

                                                   ' Cabeçalho
                                                   page.Header().Column(Sub(colHeader)
                                                                            colHeader.Item().Row(Sub(row)
                                                                                                     If logoBytes IsNot Nothing Then
                                                                                                         row.ConstantItem(2.5, Unit.Centimetre).Image(logoBytes)
                                                                                                         row.ConstantItem(0.4, Unit.Centimetre)
                                                                                                     ElseIf File.Exists(_config.LogoPath) Then
                                                                                                         row.ConstantItem(2.5, Unit.Centimetre).Image(_config.LogoPath)
                                                                                                         row.ConstantItem(0.4, Unit.Centimetre)
                                                                                                     End If

                                                                                                     row.RelativeItem().Column(Sub(c)
                                                                                                                                   c.Item().Text(nomeCliente).FontSize(13).Bold().FontColor(QuestPDF.Infrastructure.Color.FromRGB(30, 64, 115))
                                                                                                                                   c.Item().Text(subCabecalho).FontSize(9).FontColor(Colors.Grey.Darken2)
                                                                                                                               End Sub)

                                                                                                     row.ConstantItem(7.5, Unit.Centimetre).Column(Sub(c)
                                                                                                                                                       Dim rotuloAmbiente = If(isMaturacao, "Câmara", "Ambiente")
                                                                                                                                                       c.Item().Text($"{rotuloAmbiente}: {nSensor}").Bold()
                                                                                                                                                       c.Item().Text($"Início: {inicio.ToString("dd/MM/yyyy HH:mm")}")
                                                                                                                                                       c.Item().Text($"Fim: {fim.ToString("dd/MM/yyyy HH:mm")}")
                                                                                                                                                   End Sub)
                                                                                                 End Sub)
                                                                            colHeader.Item().PaddingTop(4).LineHorizontal(1).LineColor(QuestPDF.Infrastructure.Color.FromRGB(30, 64, 115))
                                                                        End Sub)

                                                   ' Conteúdo vertical
                                                   page.Content().PaddingVertical(2).Column(Sub(col)
                                                                                                col.Item().Row(Sub(row)
                                                                                                                   row.RelativeItem().Image(tempPngPath)
                                                                                                               End Sub)

                                                                                                col.Item().PaddingTop(4)

                                                                                                col.Item().Row(Sub(row)
                                                                                                                   row.RelativeItem().Column(Sub(c)
                                                                                                                                                 Dim tituloMetricas = If(isMaturacao, "Métricas da Maturação", "Métricas de Temperatura")
                                                                                                                                                 c.Item().PaddingBottom(2).Text(tituloMetricas).Bold().FontSize(9.0).FontColor(QuestPDF.Infrastructure.Color.FromRGB(30, 64, 115))

                                                                                                                                                 c.Item().Table(Sub(tbl)
                                                                                                                                                                    tbl.ColumnsDefinition(Sub(cols)
                                                                                                                                                                                              cols.RelativeColumn(3.0F)
                                                                                                                                                                                              cols.RelativeColumn(1.5F)
                                                                                                                                                                                          End Sub)

                                                                                                                                                                    Dim rotuloAmbiente = If(isMaturacao, "Câmara", "Ambiente")
                                                                                                                                                                    AddTableCell(tbl, rotuloAmbiente, nSensor, True)
                                                                                                                                                                    If isMaturacao Then
                                                                                                                                                                        AddTableCell(tbl, "Data/Hora de Início de Maturação", inicio.ToString("dd/MM/yyyy HH:mm"), False)
                                                                                                                                                                        AddTableCell(tbl, "Data/Hora de Fim de Maturação", fim.ToString("dd/MM/yyyy HH:mm"), True)
                                                                                                                                                                        AddTableCell(tbl, "Temp. Inicial de Maturação", tempsSalvas(0).ToString("F1") & " °C", False)
                                                                                                                                                                        AddTableCell(tbl, "Temp. Final de Maturação", tempFinalRef.ToString("F1") & " °C", True)
                                                                                                                                                                        AddTableCell(tbl, "Temp. Mínima Durante Maturação", tempMin.ToString("F1") & " °C", False)
                                                                                                                                                                        AddTableCell(tbl, "Temp. Máxima Durante Maturação", tempMax.ToString("F1") & " °C", True)
                                                                                                                                                                        AddTableCell(tbl, "Temp. Média Durante Maturação", tempMed.ToString("F1") & " °C", False)
                                                                                                                                                                    Else
                                                                                                                                                                        AddTableCell(tbl, "Data/Hora de Início", inicio.ToString("dd/MM/yyyy HH:mm"), False)
                                                                                                                                                                        AddTableCell(tbl, "Data/Hora de Fim", fim.ToString("dd/MM/yyyy HH:mm"), True)
                                                                                                                                                                        AddTableCell(tbl, "Temp. Inicial", tempsSalvas(0).ToString("F1") & " °C", False)
                                                                                                                                                                        AddTableCell(tbl, "Temp. Final", tempFinalRef.ToString("F1") & " °C", True)
                                                                                                                                                                        AddTableCell(tbl, "Temp. Mínima", tempMin.ToString("F1") & " °C", False)
                                                                                                                                                                        AddTableCell(tbl, "Temp. Máxima", tempMax.ToString("F1") & " °C", True)
                                                                                                                                                                        AddTableCell(tbl, "Temp. Média", tempMed.ToString("F1") & " °C", False)
                                                                                                                                                                    End If
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

        Finally
            ' Limpeza da imagem temporaria
            Try
                If File.Exists(tempPngPath) Then
                    File.Delete(tempPngPath)
                End If
            Catch
            End Try
        End Try
    End Sub

    Private Shared Sub ConfigurarEixosGrafico(plt As ScottPlot.Plot, inicio As DateTime, fim As DateTime, datesSalvas() As Double, tempsSalvas() As Double)
        Dim duracaoHoras As Double = (fim - inicio).TotalHours
        Dim stepHours As Double = 1.0

        If duracaoHoras > 96.0 Then
            ' Para períodos longos (superiores a 4 dias / 96h), escala proporcionalmente
            Dim diasTotal = duracaoHoras / 24.0
            If diasTotal <= 7.0 Then
                stepHours = 2.0
            ElseIf diasTotal <= 15.0 Then
                stepHours = 6.0
            ElseIf diasTotal <= 30.0 Then
                stepHours = 12.0
            Else
                stepHours = Math.Ceiling(diasTotal / 25.0) * 24.0
            End If
        Else
            ' Para períodos normais de maturação (até 4 dias / 96h): sempre de 1h em 1h
            stepHours = 1.0
        End If

        Dim tickCount As Integer = CInt(Math.Floor(duracaoHoras / stepHours)) + 1
        Dim tickPositions(tickCount - 1) As Double
        Dim tickLabels(tickCount - 1) As String
        For k = 0 To tickCount - 1
            Dim tickTime = inicio.AddHours(k * stepHours)
            tickPositions(k) = tickTime.ToOADate()
            tickLabels(k) = tickTime.ToString("dd/MM/yyyy HH:mm")
        Next

        plt.XTicks(tickPositions, tickLabels)
        plt.XAxis.TickLabelStyle(rotation:=45, fontSize:=15.0F)
        plt.SetAxisLimitsX(datesSalvas(0), datesSalvas(datesSalvas.Length - 1))
        plt.Margins(x:=0, y:=0.1)

        ' Configurar Eixo Y (sempre de 1 °C em 1 °C, dinâmico para mínimo e máximo)
        Dim yTickPositions As New System.Collections.Generic.List(Of Double)()
        Dim yTickLabels As New System.Collections.Generic.List(Of String)()
        
        Dim minTemp = tempsSalvas.Min()
        Dim maxTemp = tempsSalvas.Max()
        
        Dim minLimit As Integer = CInt(Math.Floor(minTemp)) - 1
        If minLimit > 0 Then minLimit = 0
        
        Dim maxLimit As Integer = CInt(Math.Ceiling(Math.Max(maxTemp, 4.0))) + 1
        
        For yVal = minLimit To maxLimit Step 1
            yTickPositions.Add(yVal)
            yTickLabels.Add(yVal.ToString() & " °C")
        Next
        plt.YTicks(yTickPositions.ToArray(), yTickLabels.ToArray())
        plt.YAxis.TickLabelStyle(fontSize:=16.0F)
        plt.SetAxisLimitsY(minLimit, maxLimit)
        plt.Layout(left:=220, bottom:=160)
        plt.XAxis.MajorGrid(True, color:=System.Drawing.Color.FromArgb(170, 170, 170), lineWidth:=1.0F)
        plt.YAxis.MajorGrid(True, color:=System.Drawing.Color.FromArgb(80, 80, 80), lineWidth:=3.0F)
    End Sub

End Class
