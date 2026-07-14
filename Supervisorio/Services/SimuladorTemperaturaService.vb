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
            ' 1. Calcular horarios do ciclo (dinâmico com base no DataFim/HoraFim do Excel)
            Dim inicio = cycle.DataInicio.Date.Add(cycle.HoraInicio)
            Dim fim = cycle.DataFim.Date.Add(cycle.HoraFim)
            Dim duracaoHoras As Double = (fim - inicio).TotalHours

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

            ' Gera a lista completa de timestamps para o período usando o intervalo detectado
            Dim timestamps As New List(Of DateTime)()
            Dim totalMinutos As Double = duracaoHoras * 60.0
            Dim totalPassos As Integer = CInt(Math.Floor(totalMinutos / intervalMinutes))
            For i = 0 To totalPassos
                timestamps.Add(inicio.AddMinutes(i * intervalMinutes))
            Next

            ' 3. Gerar pontos de simulacao correspondentes aos timestamps
            Dim rnd As New Random()
            Dim targetTemp As Double = 2.6 + (rnd.NextDouble() * 0.8)
            Dim friction As Double = 0.80 + (rnd.NextDouble() * 0.12)
            Dim maxSpeed As Double = 0.08 * (intervalMinutes / 10.0)
            Dim noiseAmplitude As Double = 0.015 * (intervalMinutes / 10.0)
            Dim lowerBound As Double = Math.Max(2.0, targetTemp - 0.8)
            Dim upperBound As Double = Math.Min(4.0, targetTemp + 0.8)
            Dim coolingDuration As Double = 1.833 + (rnd.NextDouble() * 0.334)
            Dim lagDuration As Double = 0.1 + (rnd.NextDouble() * 0.15)
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

            Dim currentTemp As Double = cycle.TempInicial
            Dim currentVelocity As Double = 0.0
            Dim wobble As Double = 0.0
            Dim wobbleVelocity As Double = 0.0

            For i = 0 To totalPontos
                Dim ptTime = timestamps(i)
                Dim t_hours As Double = (ptTime - inicio).TotalHours

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

                        If progress < 0.3 Then
                            Dim startTempOfDefrost = 3.0
                            If i > 0 Then startTempOfDefrost = temps(i - 1)
                            temp = startTempOfDefrost + (peakTemp - startTempOfDefrost) * (progress / 0.3)
                        Else
                            temp = peakTemp
                        End If

                        Dim jitter = (rnd.NextDouble() * 1.0) - 0.5
                        temp = temp + jitter
                        temp = Math.Max(currentDefrost.TempMin, Math.Min(currentDefrost.TempMax, temp))
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
                    If t_hours <= lagDuration Then
                        Dim noise = (rnd.NextDouble() * 1.6) - 0.8
                        temp = cycle.TempInicial + noise
                        currentTemp = temp
                        currentVelocity = 0.0
                    ElseIf t_hours <= coolingDuration Then
                        Dim t_norm As Double = (t_hours - lagDuration) / (coolingDuration - lagDuration)
                        Dim decay As Double = Math.Exp(-kFactor * t_norm * 3.5)
                        Dim baseTemp As Double = targetTemp + (cycle.TempInicial - targetTemp) * decay

                        Dim stepScale As Double = intervalMinutes / 10.0
                        wobbleVelocity = 0.85 * wobbleVelocity + ((rnd.NextDouble() * 0.3) - 0.15) * stepScale
                        wobble = wobble + wobbleVelocity

                        Dim wobbleScale As Double = (cycle.TempInicial - targetTemp) * 0.2
                        Dim dampFactor As Double = Math.Max(0.0, 1.0 - t_norm)
                        Dim finalWobble As Double = wobble * dampFactor * wobbleScale

                        Dim noise = (rnd.NextDouble() * 2.0) - 1.0
                        temp = baseTemp + finalWobble + noise
                        currentTemp = temp
                        currentVelocity = 0.0
                    Else
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
                    End If

                    If t_hours > coolingDuration Then
                        Dim jitter As Double = (rnd.NextDouble() * 2.0) - 1.0
                        temp = temp + jitter
                    End If

                    If t_hours > coolingDuration Then
                        temp = Math.Max(2.0, Math.Min(4.0, temp))
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

            db.LimparPeriodoSensor(cycle.SensorId, inicio, fim)
            db.UpsertLeituras(batch)

            Dim dadosSalvos = db.ConsultarSensor(cycle.SensorId, inicio, fim)
            Dim totalPontosSalvos = dadosSalvos.Rows.Count
            
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

            Dim plt As New ScottPlot.Plot(2500, 1050)
            
            Dim nSensor = cycle.Camara.Trim()
            plt.Title($"GRÁFICO DE MATURAÇÃO - {nSensor.ToUpper()}", size:=30, color:=System.Drawing.Color.FromArgb(30, 64, 115), bold:=True)
            
            plt.AddScatter(datesSalvas, tempsSalvas, color:=System.Drawing.Color.FromArgb(30, 64, 115), lineWidth:=5, markerSize:=0)
            
            Dim stepHours As Double = 1.0
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
            plt.SetAxisLimitsX(datesSalvas(0), datesSalvas(totalPontosSalvos - 1))
            plt.Margins(x:=0, y:=0.1)

            Dim yTickPositions As New System.Collections.Generic.List(Of Double)()
            Dim yTickLabels As New System.Collections.Generic.List(Of String)()
            Dim maxLimit As Integer = CInt(Math.Ceiling(Math.Max(tempsSalvas.Max(), 4.0) / 2.0) * 2.0) + 2
            For yVal = 0 To maxLimit Step 2
                yTickPositions.Add(yVal)
                yTickLabels.Add(yVal.ToString() & " °C")
            Next
            plt.YTicks(yTickPositions.ToArray(), yTickLabels.ToArray())
            plt.YAxis.TickLabelStyle(fontSize:=16.0F)
            plt.SetAxisLimitsY(0, maxLimit)
            plt.Layout(left:=220, bottom:=160)
            plt.Grid(True, color:=System.Drawing.Color.FromArgb(235, 235, 235))
            
            Dim tempPngPath = Path.Combine(Path.GetTempPath(), $"temp_chart_{Guid.NewGuid().ToString()}.png")
            plt.SaveFig(tempPngPath)

            Dim nomeArquivo = $"Grafico_{cycle.Camara.Replace(" ", "")}_{inicio.ToString("dd-MM-yyyy_HHmm")}.pdf"
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
                        page.Margin(1.2, Unit.Centimetre)
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

                                row.ConstantItem(5.5, Unit.Centimetre).Column(Sub(c)
                                    c.Item().Text($"Câmara: {nSensor}").Bold()
                                    c.Item().Text($"Início: {inicio.ToString("dd/MM/yyyy HH:mm")}")
                                    c.Item().Text($"Fim: {fim.ToString("dd/MM/yyyy HH:mm")}")
                                End Sub)
                            End Sub)
                            colHeader.Item().PaddingTop(4).LineHorizontal(1).LineColor(QuestPDF.Infrastructure.Color.FromRGB(30, 64, 115))
                        End Sub)

                        ' Conteúdo vertical
                        page.Content().PaddingVertical(5).Column(Sub(col)
                            col.Item().Row(Sub(row)
                                row.RelativeItem().Image(tempPngPath)
                            End Sub)

                            col.Item().PaddingTop(8)

                            col.Item().Row(Sub(row)
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
                    Dim nomeArquivoList = $"Relatorio_{cycle.Camara.Replace(" ", "")}_{inicio.ToString("dd-MM-yyyy_HHmm")}.pdf"
                    Dim caminhoListPdf = Path.Combine(pastaDestino, nomeArquivoList)
                    relService.ExportarPDF(dadosRelatorio, caminhoListPdf, cycle.Camara, inicio, fim)
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
        tbl.Cell().Background(bg).Padding(4).BorderBottom(0.5).BorderColor(Colors.Grey.Lighten2).Text(label).Bold()
        tbl.Cell().Background(bg).Padding(4).BorderBottom(0.5).BorderColor(Colors.Grey.Lighten2).Text(value)
    End Sub

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

        Dim plt As New ScottPlot.Plot(2500, 1050)
        
        Dim nSensor = camaraNome.Trim()
        plt.Title($"GRÁFICO DE MATURAÇÃO - {nSensor.ToUpper()}", size:=30, color:=System.Drawing.Color.FromArgb(30, 64, 115), bold:=True)
        
        plt.AddScatter(datesSalvas, tempsSalvas, color:=System.Drawing.Color.FromArgb(30, 64, 115), lineWidth:=5, markerSize:=0)
        
        Dim duracaoHoras As Double = (fim - inicio).TotalHours
        Dim stepHours As Double = 1.0
        If duracaoHoras > 24.0 Then
            stepHours = Math.Ceiling(duracaoHoras / 24.0)
            If stepHours > 1.0 AndAlso stepHours <= 2.0 Then
                stepHours = 2.0
            ElseIf stepHours > 2.0 AndAlso stepHours <= 3.0 Then
                stepHours = 3.0
            ElseIf stepHours > 3.0 AndAlso stepHours <= 4.0 Then
                stepHours = 4.0
            ElseIf stepHours > 4.0 AndAlso stepHours <= 6.0 Then
                stepHours = 6.0
            ElseIf stepHours > 6.0 AndAlso stepHours <= 12.0 Then
                stepHours = 12.0
            ElseIf stepHours > 12.0 AndAlso stepHours <= 24.0 Then
                stepHours = 24.0
            ElseIf stepHours > 24.0 AndAlso stepHours <= 48.0 Then
                stepHours = 48.0
            ElseIf stepHours > 48.0 Then
                stepHours = Math.Ceiling(stepHours / 24.0) * 24.0
            End If
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
        plt.SetAxisLimitsX(datesSalvas(0), datesSalvas(totalPontosSalvos - 1))
        plt.Margins(x:=0, y:=0.1)

        Dim yTickPositions As New System.Collections.Generic.List(Of Double)()
        Dim yTickLabels As New System.Collections.Generic.List(Of String)()
        Dim maxLimit As Integer = CInt(Math.Ceiling(Math.Max(tempsSalvas.Max(), 4.0) / 2.0) * 2.0) + 2
        For yVal = 0 To maxLimit Step 2
            yTickPositions.Add(yVal)
            yTickLabels.Add(yVal.ToString() & " °C")
        Next
        plt.YTicks(yTickPositions.ToArray(), yTickLabels.ToArray())
        plt.YAxis.TickLabelStyle(fontSize:=16.0F)
        plt.SetAxisLimitsY(0, maxLimit)
        plt.Layout(left:=220, bottom:=160)
        plt.Grid(True, color:=System.Drawing.Color.FromArgb(235, 235, 235))
        
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
                    page.Margin(1.2, Unit.Centimetre)
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

                            row.ConstantItem(5.5, Unit.Centimetre).Column(Sub(c)
                                c.Item().Text($"Câmara: {nSensor}").Bold()
                                c.Item().Text($"Início: {inicio.ToString("dd/MM/yyyy HH:mm")}")
                                c.Item().Text($"Fim: {fim.ToString("dd/MM/yyyy HH:mm")}")
                            End Sub)
                        End Sub)
                        colHeader.Item().PaddingTop(4).LineHorizontal(1).LineColor(QuestPDF.Infrastructure.Color.FromRGB(30, 64, 115))
                    End Sub)

                    ' Conteúdo vertical
                    page.Content().PaddingVertical(5).Column(Sub(col)
                        col.Item().Row(Sub(row)
                            row.RelativeItem().Image(tempPngPath)
                        End Sub)

                        col.Item().PaddingTop(8)

                        col.Item().Row(Sub(row)
                            row.RelativeItem().Column(Sub(c)
                                c.Item().PaddingBottom(2).Text("Métricas da Maturação").Bold().FontSize(9.0).FontColor(QuestPDF.Infrastructure.Color.FromRGB(30, 64, 115))
                                
                                c.Item().Table(Sub(tbl)
                                    tbl.ColumnsDefinition(Sub(cols)
                                        cols.RelativeColumn(3.0F)
                                        cols.RelativeColumn(1.5F)
                                    End Sub)

                                    AddTableCell(tbl, "Câmara", nSensor, True)
                                    AddTableCell(tbl, "Data de Início", inicio.ToString("dd/MM/yyyy"), False)
                                    AddTableCell(tbl, "Hora de Início", inicio.ToString("HH\:mm"), True)
                                    AddTableCell(tbl, "Temp. Inicial", tempsSalvas(0).ToString("F1") & " °C", False)
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

End Class
