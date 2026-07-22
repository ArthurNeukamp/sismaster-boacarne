Imports System.IO
Imports System.Windows.Forms

Public Class FrmImportarQualidade

    Private _caminhoArquivo As String
    Private _db As DatabaseService
    Private _ciclos As List(Of MaturationCycle)

    Public Class MaturationCycle
        Public Property RowIndex As Integer
        Public Property Camara As String
        Public Property SensorId As Integer
        Public Property DataCarregamento As DateTime
        Public Property HoraCarregamento As TimeSpan
        Public Property TempCarregamento As Double
        Public Property DataInicio As DateTime?
        Public Property HoraInicio As TimeSpan?
        Public Property TempInicial As Double?
        Public Property DataFim As DateTime
        Public Property HoraFim As TimeSpan

        Public ReadOnly Property TemInicio As Boolean
            Get
                Return DataInicio.HasValue AndAlso HoraInicio.HasValue AndAlso TempInicial.HasValue
            End Get
        End Property

        Public Property Degelo1_Data As DateTime?
        Public Property Degelo1_Hora As TimeSpan?
        Public Property Degelo1_Duracao As Integer
        Public Property Degelo1_TempMax As Double

        Public Property Degelo2_Data As DateTime?
        Public Property Degelo2_Hora As TimeSpan?
        Public Property Degelo2_Duracao As Integer
        Public Property Degelo2_TempMax As Double

        Public Property Degelo3_Data As DateTime?
        Public Property Degelo3_Hora As TimeSpan?
        Public Property Degelo3_Duracao As Integer
        Public Property Degelo3_TempMax As Double
    End Class

    Public Sub New(caminhoArquivo As String, db As DatabaseService)
        ' Chamada necessária para o designer.
        InitializeComponent()

        _caminhoArquivo = caminhoArquivo
        _db = db
    End Sub

    Private Sub FrmImportarQualidade_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblArquivo.Text = "Arquivo selecionado: " & Path.GetFileName(_caminhoArquivo)
        
        ' Inicia a leitura da planilha ao carregar o formulário
        CarregarPlanilha(_caminhoArquivo)
    End Sub

    Private Function ObterSensorId(nomeCamara As String) As Integer
        If String.IsNullOrWhiteSpace(nomeCamara) Then Return -1
        
        Dim nomeNorm As String = nomeCamara.Trim().ToLower()
        
        ' Normalização básica para tolerar pequenas variações de acento e espaços
        nomeNorm = nomeNorm.Replace("â", "a").Replace("á", "a").Replace("ã", "a")
        nomeNorm = nomeNorm.Replace(" ", "")
        
        Select Case nomeNorm
            Case "camara1", "camaracarcaca1", "camara_carcaca_1"
                Return 121
            Case "camara2", "camaracarcaca2", "camara_carcaca_2"
                Return 122
            Case "camara3", "camaracarcaca3", "camara_carcaca_3"
                Return 123
            Case "camara4", "camaracarcaca4", "camara_carcaca_4"
                Return 124
            Case "camara5", "camaracarcaca5", "camara_carcaca_5"
                Return 125
            Case "camara6", "camaracarcaca6", "camara_carcaca_6"
                Return 126
            Case "camara7", "camaracarcaca7", "camara_carcaca_7"
                Return 127
            Case Else
                Return -1
        End Select
    End Function

    Private Function ParseDateTimeCell(cell As ClosedXML.Excel.IXLCell, culture As System.Globalization.CultureInfo) As DateTime?
        If cell.IsEmpty() Then Return Nothing
        Try
            If cell.DataType = ClosedXML.Excel.XLDataType.DateTime Then
                Return cell.GetDateTime()
            Else
                Dim dblVal As Double
                If Double.TryParse(cell.GetString(), System.Globalization.NumberStyles.Any, culture, dblVal) Then
                    Return DateTime.FromOADate(dblVal)
                Else
                    Dim dt As DateTime
                    If DateTime.TryParse(cell.GetString(), culture, System.Globalization.DateTimeStyles.None, dt) Then
                        Return dt
                    End If
                End If
            End If
        Catch
        End Try
        Return Nothing
    End Function

    Private Function ParseTimeSpanCell(cell As ClosedXML.Excel.IXLCell, culture As System.Globalization.CultureInfo) As TimeSpan?
        If cell.IsEmpty() Then Return Nothing
        Try
            If cell.DataType = ClosedXML.Excel.XLDataType.TimeSpan Then
                Return cell.GetTimeSpan()
            ElseIf cell.DataType = ClosedXML.Excel.XLDataType.DateTime Then
                Return cell.GetDateTime().TimeOfDay
            Else
                Dim dblVal As Double
                If Double.TryParse(cell.GetString(), System.Globalization.NumberStyles.Any, culture, dblVal) Then
                    If dblVal >= 0 AndAlso dblVal < 1.0 Then
                        Return TimeSpan.FromDays(dblVal)
                    End If
                Else
                    Dim ts As TimeSpan
                    If TimeSpan.TryParse(cell.GetString(), ts) Then
                        Return ts
                    End If
                End If
            End If
        Catch
        End Try
        Return Nothing
    End Function

    Private Function ParseDoubleCell(cell As ClosedXML.Excel.IXLCell, culture As System.Globalization.CultureInfo) As Double?
        If cell.IsEmpty() Then Return Nothing
        Try
            If cell.DataType = ClosedXML.Excel.XLDataType.Number Then
                Return cell.GetDouble()
            Else
                Dim strVal As String = cell.GetString().Replace(".", ",").Trim()
                Dim dblVal As Double
                If Double.TryParse(strVal, System.Globalization.NumberStyles.Any, culture, dblVal) Then
                    Return dblVal
                End If
            End If
        Catch
        End Try
        Return Nothing
    End Function

    Private Function ParseIntCell(cell As ClosedXML.Excel.IXLCell, culture As System.Globalization.CultureInfo) As Integer?
        Dim dbl = ParseDoubleCell(cell, culture)
        If dbl.HasValue Then Return CInt(dbl.Value)
        Return Nothing
    End Function

    Private Sub CarregarPlanilha(caminhoArquivo As String)
        Dim ciclos As New List(Of MaturationCycle)()
        Dim alertas As New List(Of String)()
        Dim ciclosAceitos As New Dictionary(Of Integer, List(Of Tuple(Of DateTime, DateTime)))()
        Dim cultureInfo As New System.Globalization.CultureInfo("pt-BR")

        Try
            Using workbook As New ClosedXML.Excel.XLWorkbook(caminhoArquivo)
                ' Busca a planilha Qualidade
                Dim worksheet As ClosedXML.Excel.IXLWorksheet = Nothing
                For Each ws In workbook.Worksheets
                    If ws.Name.Trim().Equals("Qualidade", StringComparison.OrdinalIgnoreCase) Then
                        worksheet = ws
                        Exit For
                    End If
                Next

                If worksheet Is Nothing Then
                    Throw New Exception("Não foi possível encontrar a aba chamada 'Qualidade' no arquivo Excel.")
                End If

                ' O cabeçalho está na linha 3, os dados começam na linha 4
                Dim linhaAtual As Integer = 4

                While True
                    Dim row = worksheet.Row(linhaAtual)

                    ' Critério de parada: se todas as células da linha nas primeiras 4 colunas estiverem vazias
                    If row.Cell(1).IsEmpty() AndAlso row.Cell(2).IsEmpty() AndAlso row.Cell(3).IsEmpty() AndAlso row.Cell(4).IsEmpty() Then
                        Exit While
                    End If

                    Dim erroLinha As String = ""
                    Dim câmara As String = row.Cell(1).GetString().Trim()
                    Dim sensorId As Integer = ObterSensorId(câmara)

                    If sensorId = -1 Then
                        erroLinha &= "Câmara não reconhecida ('" & câmara & "'). "
                    End If

                    ' Ler Data, Hora e Temp Carregamento
                    Dim dCarregOpt = ParseDateTimeCell(row.Cell(2), cultureInfo)
                    Dim hCarregOpt = ParseTimeSpanCell(row.Cell(3), cultureInfo)
                    Dim tCarregOpt = ParseDoubleCell(row.Cell(4), cultureInfo)

                    Dim dataCarregamento As DateTime
                    Dim horaCarregamento As TimeSpan
                    Dim tempCarregamento As Double

                    If dCarregOpt.HasValue Then
                        dataCarregamento = dCarregOpt.Value
                        If dataCarregamento.Year < 2000 Then
                            erroLinha &= "Data de carregamento muito antiga. "
                        End If
                    Else
                        erroLinha &= "Data de carregamento vazia ou inválida. "
                    End If

                    If hCarregOpt.HasValue Then
                        horaCarregamento = hCarregOpt.Value
                    Else
                        erroLinha &= "Hora de carregamento vazia ou inválida. "
                    End If

                    If tCarregOpt.HasValue Then
                        tempCarregamento = tCarregOpt.Value
                    Else
                        erroLinha &= "Temperatura de carregamento vazia ou inválida. "
                    End If

                    ' Ler Data e Hora Início (opcionais)
                    Dim dIniOpt = ParseDateTimeCell(row.Cell(5), cultureInfo)
                    Dim hIniOpt = ParseTimeSpanCell(row.Cell(6), cultureInfo)
                    Dim tIniOpt = ParseDoubleCell(row.Cell(7), cultureInfo)

                    Dim dataInicio As DateTime? = Nothing
                    Dim horaInicio As TimeSpan? = Nothing
                    Dim tempInicial As Double? = Nothing

                    Dim temAlgumInicio As Boolean = dIniOpt.HasValue OrElse hIniOpt.HasValue OrElse tIniOpt.HasValue
                    Dim temTodoInicio As Boolean = dIniOpt.HasValue AndAlso hIniOpt.HasValue AndAlso tIniOpt.HasValue

                    If temAlgumInicio AndAlso Not temTodoInicio Then
                        erroLinha &= "Se informados, os campos de início (data, hora e temperatura) devem estar todos preenchidos. "
                    ElseIf temTodoInicio Then
                        dataInicio = dIniOpt.Value
                        If dataInicio.Value.Year < 2000 Then
                            erroLinha &= "Data de início muito antiga (deve ser posterior ao ano 2000). "
                        End If
                        horaInicio = hIniOpt.Value
                        tempInicial = tIniOpt.Value
                    End If

                    ' Ler Data e Hora Fim
                    Dim dFimOpt = ParseDateTimeCell(row.Cell(8), cultureInfo)
                    Dim hFimOpt = ParseTimeSpanCell(row.Cell(9), cultureInfo)

                    Dim dataFim As DateTime
                    Dim horaFim As TimeSpan

                    If dFimOpt.HasValue Then
                        dataFim = dFimOpt.Value
                    Else
                        erroLinha &= "Data de término vazia ou inválida. "
                    End If

                    If hFimOpt.HasValue Then
                        horaFim = hFimOpt.Value
                    Else
                        erroLinha &= "Hora de término vazia ou inválida. "
                    End If

                    Dim inicioCarregamento As DateTime
                    Dim fimCiclo As DateTime

                    If String.IsNullOrEmpty(erroLinha) Then
                        inicioCarregamento = dataCarregamento.Date.Add(horaCarregamento)
                        fimCiclo = dataFim.Date.Add(horaFim)

                        If temTodoInicio Then
                            Dim inicioCiclo = dataInicio.Value.Date.Add(horaInicio.Value)
                            If inicioCiclo <= inicioCarregamento Then
                                erroLinha &= "A data/hora de início deve ser maior que a data/hora de carregamento. "
                            End If
                            If fimCiclo <= inicioCiclo Then
                                erroLinha &= "A data/hora de término deve ser maior que a data/hora de início. "
                            End If
                        Else
                            If fimCiclo <= inicioCarregamento Then
                                erroLinha &= "A data/hora de término deve ser maior que a data/hora de carregamento. "
                            End If
                        End If
                    End If

                    ' Criar ciclo temporário para carregar os degelos
                    Dim ciclo As New MaturationCycle()
                    ciclo.RowIndex = linhaAtual
                    ciclo.Camara = câmara
                    ciclo.SensorId = sensorId
                    ciclo.DataCarregamento = dataCarregamento
                    ciclo.HoraCarregamento = horaCarregamento
                    ciclo.TempCarregamento = tempCarregamento
                    ciclo.DataInicio = dataInicio
                    ciclo.HoraInicio = horaInicio
                    ciclo.TempInicial = tempInicial
                    If String.IsNullOrEmpty(erroLinha) Then
                        ciclo.DataFim = dataFim
                        ciclo.HoraFim = horaFim
                    End If

                    Dim inicioReferencia As DateTime = If(ciclo.TemInicio, ciclo.DataInicio.Value.Date.Add(ciclo.HoraInicio.Value), inicioCarregamento)

                    ' --- LER E VALIDAR DEGELOS ---
                    ' Degelo 1 (Col J=10 a M=13)
                    Dim deg1_D = ParseDateTimeCell(row.Cell(10), cultureInfo)
                    Dim deg1_H = ParseTimeSpanCell(row.Cell(11), cultureInfo)
                    Dim deg1_Dur = ParseIntCell(row.Cell(12), cultureInfo)
                    Dim deg1_Max = ParseDoubleCell(row.Cell(13), cultureInfo)

                    If deg1_D.HasValue OrElse deg1_H.HasValue OrElse deg1_Dur.HasValue OrElse deg1_Max.HasValue Then
                        If Not (deg1_D.HasValue AndAlso deg1_H.HasValue AndAlso deg1_Dur.HasValue AndAlso deg1_Max.HasValue) Then
                            erroLinha &= "Degelo 1 possui campos incompletos. "
                        Else
                            Dim dtDeg = deg1_D.Value.Date.Add(deg1_H.Value)
                            If dtDeg < inicioReferencia Then
                                erroLinha &= $"Degelo 1 inicia em {dtDeg.ToString("dd/MM/yyyy HH:mm")}, que é anterior ao início do ciclo. "
                            End If
                            ciclo.Degelo1_Data = deg1_D
                            ciclo.Degelo1_Hora = deg1_H
                            ciclo.Degelo1_Duracao = deg1_Dur.Value
                            ciclo.Degelo1_TempMax = deg1_Max.Value
                        End If
                    End If

                    ' Degelo 2 (Col N=14 a Q=17)
                    Dim deg2_D = ParseDateTimeCell(row.Cell(14), cultureInfo)
                    Dim deg2_H = ParseTimeSpanCell(row.Cell(15), cultureInfo)
                    Dim deg2_Dur = ParseIntCell(row.Cell(16), cultureInfo)
                    Dim deg2_Max = ParseDoubleCell(row.Cell(17), cultureInfo)

                    If deg2_D.HasValue OrElse deg2_H.HasValue OrElse deg2_Dur.HasValue OrElse deg2_Max.HasValue Then
                        If Not (deg2_D.HasValue AndAlso deg2_H.HasValue AndAlso deg2_Dur.HasValue AndAlso deg2_Max.HasValue) Then
                            erroLinha &= "Degelo 2 possui campos incompletos. "
                        Else
                            Dim dtDeg = deg2_D.Value.Date.Add(deg2_H.Value)
                            If dtDeg < inicioReferencia Then
                                erroLinha &= $"Degelo 2 inicia em {dtDeg.ToString("dd/MM/yyyy HH:mm")}, que é anterior ao início do ciclo. "
                            End If
                            ciclo.Degelo2_Data = deg2_D
                            ciclo.Degelo2_Hora = deg2_H
                            ciclo.Degelo2_Duracao = deg2_Dur.Value
                            ciclo.Degelo2_TempMax = deg2_Max.Value
                        End If
                    End If

                    ' Degelo 3 (Col R=18 a U=21)
                    Dim deg3_D = ParseDateTimeCell(row.Cell(18), cultureInfo)
                    Dim deg3_H = ParseTimeSpanCell(row.Cell(19), cultureInfo)
                    Dim deg3_Dur = ParseIntCell(row.Cell(20), cultureInfo)
                    Dim deg3_Max = ParseDoubleCell(row.Cell(21), cultureInfo)

                    If deg3_D.HasValue OrElse deg3_H.HasValue OrElse deg3_Dur.HasValue OrElse deg3_Max.HasValue Then
                        If Not (deg3_D.HasValue AndAlso deg3_H.HasValue AndAlso deg3_Dur.HasValue AndAlso deg3_Max.HasValue) Then
                            erroLinha &= "Degelo 3 possui campos incompletos. "
                        Else
                            Dim dtDeg = deg3_D.Value.Date.Add(deg3_H.Value)
                            If dtDeg < inicioReferencia Then
                                erroLinha &= $"Degelo 3 inicia em {dtDeg.ToString("dd/MM/yyyy HH:mm")}, que é anterior ao início do ciclo. "
                            End If
                            ciclo.Degelo3_Data = deg3_D
                            ciclo.Degelo3_Hora = deg3_H
                            ciclo.Degelo3_Duracao = deg3_Dur.Value
                            ciclo.Degelo3_TempMax = deg3_Max.Value
                        End If
                    End If

                    ' Validar sobreposição de intervalos para a mesma câmara nesta planilha
                    If String.IsNullOrEmpty(erroLinha) Then
                        Dim conflito As Boolean = False
                        Dim intConflito As Tuple(Of DateTime, DateTime) = Nothing

                        If ciclosAceitos.ContainsKey(sensorId) Then
                            For Each interval In ciclosAceitos(sensorId)
                                If inicioCarregamento < interval.Item2 AndAlso fimCiclo > interval.Item1 Then
                                    conflito = True
                                    intConflito = interval
                                    Exit For
                                end If
                            Next
                        End If

                        If conflito Then
                            erroLinha &= $"Conflito de sobreposição. A câmara já possui um ciclo ativo entre {intConflito.Item1.ToString("dd/MM/yyyy HH:mm")} e {intConflito.Item2.ToString("dd/MM/yyyy HH:mm")}. "
                        Else
                            If Not ciclosAceitos.ContainsKey(sensorId) Then
                                ciclosAceitos(sensorId) = New List(Of Tuple(Of DateTime, DateTime))()
                            End If
                            ciclosAceitos(sensorId).Add(Tuple.Create(inicioCarregamento, fimCiclo))
                        End If
                    End If

                    ' Se houver qualquer erro na linha, descarta o registro e acumula o log de erro
                    If Not String.IsNullOrEmpty(erroLinha) Then
                        alertas.Add("Linha " & linhaAtual & ": " & erroLinha)
                    Else
                        ciclos.Add(ciclo)
                    End If

                    linhaAtual += 1
                End While
            End Using
            
            ' Preencher o grid com os ciclos válidos
            dgvCiclos.DataSource = (From c In ciclos
                                   Select New With {
                                       .Linha = c.RowIndex,
                                       .Câmara = c.Camara,
                                       .Carregamento = c.DataCarregamento.ToString("dd/MM/yyyy") & " " & c.HoraCarregamento.ToString("hh\:mm"),
                                       .Início = If(c.TemInicio, c.DataInicio.Value.ToString("dd/MM/yyyy") & " " & c.HoraInicio.Value.ToString("hh\:mm"), "N/I"),
                                       .Fim = c.DataFim.ToString("dd/MM/yyyy") & " " & c.HoraFim.ToString("hh\:mm")
                                   }).ToList()
            
            ' Preencher o painel de alertas
            If alertas.Count > 0 Then
                txtAlertas.Text = String.Join(Environment.NewLine, alertas)
                tcImportacao.SelectedTab = tpAlertas
                
                ' Exibe a MessageBox consolidada de alertas
                Dim msg As String = "A importação foi concluída com os seguintes alertas:" & Environment.NewLine &
                                    String.Join(Environment.NewLine, alertas.Take(10))
                If alertas.Count > 10 Then
                    msg &= Environment.NewLine & "... e mais " & (alertas.Count - 10) & " linhas com problemas."
                End If
                msg &= Environment.NewLine & "As demais linhas válidas foram listadas com sucesso."
                
                MessageBox.Show(msg, "Importação de Planilha", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                txtAlertas.Text = "Nenhum erro ou alerta encontrado na planilha!"
                tcImportacao.SelectedTab = tpValidos
                MessageBox.Show("Planilha importada com sucesso! Todos os registros estão válidos.", "Importação de Planilha", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            
            _ciclos = ciclos
            ' Chama o método de processamento (onde o usuário colocará o breakpoint para inspecionar os ciclos)
            ProcessarCiclos(ciclos)
            
            ' Ativa o botão de simular se houver registros válidos
            btnImportar.Enabled = (ciclos.Count > 0)
            
        Catch ex As Exception
            MessageBox.Show("Erro crítico ao abrir ou ler o arquivo Excel: " & ex.Message, "Erro de Importação", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub

    Private Sub ProcessarCiclos(ciclos As List(Of MaturationCycle))
        ' =====================================================================================
        ' BREAKPOINT AQUI: Insira o breakpoint nesta linha para verificar a lista de ciclos
        ' gerada a partir do Excel carregado. Você pode inspecionar a variável 'ciclos'.
        ' =====================================================================================
        Dim count As Integer = ciclos.Count
        ' (Na FASE 4, esta lista de ciclos será enviada para o simulador gerar os dados FAKE)
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        If _ciclos Is Nothing OrElse _ciclos.Count = 0 Then
            MessageBox.Show("Nenhum registro válido para simulação.", "Simulador de Temperatura", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Cursor = Cursors.WaitCursor
            btnImportar.Enabled = False
            btnFechar.Enabled = False

            Dim simService As New SimuladorTemperaturaService(ConfiguracaoApp.Carregar())
            simService.SimularEGerarRelatorios(_ciclos, _db)

            MessageBox.Show("Simulação e geração de gráficos concluídos com sucesso!", "Simulador de Temperatura", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()
        Catch ex As Exception
            MessageBox.Show("Erro ao executar simulação: " & ex.Message, "Erro do Simulador", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
            btnImportar.Enabled = True
            btnFechar.Enabled = True
        End Try
    End Sub

    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        Close()
    End Sub

End Class
