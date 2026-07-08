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
        Public Property DataInicio As DateTime
        Public Property HoraInicio As TimeSpan
        Public Property TempInicial As Double
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

    Private Sub CarregarPlanilha(caminhoArquivo As String)
        Dim ciclos As New List(Of MaturationCycle)()
        Dim alertas As New List(Of String)()
        Dim ciclosAceitos As New Dictionary(Of Integer, List(Of DateTime))()
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

                    Dim dataInicio As DateTime
                    Dim horaInicio As TimeSpan
                    Dim tempInicial As Double

                    ' 1. Validar Câmara
                    If sensorId = -1 Then
                        erroLinha &= "Câmara não reconhecida ('" & câmara & "'). "
                    End If

                    ' 2. Validar Data
                    Dim cellDate = row.Cell(2)
                    Dim dataValida As Boolean = False
                    If Not cellDate.IsEmpty() Then
                        Try
                            If cellDate.DataType = ClosedXML.Excel.XLDataType.DateTime Then
                                dataInicio = cellDate.GetDateTime()
                                dataValida = True
                            Else
                                ' Tenta ler como número (serial do Excel)
                                Dim dblVal As Double
                                If Double.TryParse(cellDate.GetString(), System.Globalization.NumberStyles.Any, cultureInfo, dblVal) Then
                                    dataInicio = DateTime.FromOADate(dblVal)
                                    dataValida = True
                                Else
                                    ' Tenta parsing normal de string
                                    If DateTime.TryParse(cellDate.GetString(), cultureInfo, System.Globalization.DateTimeStyles.None, dataInicio) Then
                                        dataValida = True
                                    End If
                                End If
                            End If

                            If dataValida AndAlso dataInicio.Year < 2000 Then
                                erroLinha &= "Data muito antiga (deve ser posterior ao ano 2000). "
                                dataValida = False
                            End If
                        Catch ex As Exception
                            erroLinha &= "Formato de data inválido. "
                        End Try
                    Else
                        erroLinha &= "Data de início vazia. "
                    End If

                    ' 3. Validar Hora
                    Dim cellTime = row.Cell(3)
                    Dim horaValida As Boolean = False
                    If Not cellTime.IsEmpty() Then
                        Try
                            If cellTime.DataType = ClosedXML.Excel.XLDataType.TimeSpan Then
                                horaInicio = cellTime.GetTimeSpan()
                                horaValida = True
                            ElseIf cellTime.DataType = ClosedXML.Excel.XLDataType.DateTime Then
                                horaInicio = cellTime.GetDateTime().TimeOfDay
                                horaValida = True
                            Else
                                ' Tenta ler como número decimal (fração do dia)
                                Dim dblVal As Double
                                If Double.TryParse(cellTime.GetString(), System.Globalization.NumberStyles.Any, cultureInfo, dblVal) Then
                                    If dblVal >= 0 AndAlso dblVal < 1.0 Then
                                        horaInicio = TimeSpan.FromDays(dblVal)
                                        horaValida = True
                                    Else
                                        erroLinha &= "Hora fora do limite (deve ser entre 00:00 e 23:59). "
                                    End If
                                Else
                                    ' Tenta parsing de string
                                    If TimeSpan.TryParse(cellTime.GetString(), horaInicio) Then
                                        horaValida = True
                                    End If
                                End If
                            End If
                        Catch ex As Exception
                            erroLinha &= "Formato de hora inválido. "
                        End Try
                    Else
                        erroLinha &= "Hora de início vazia. "
                    End If

                    ' 4. Validar Temperatura
                    Dim cellTemp = row.Cell(4)
                    Dim tempValida As Boolean = False
                    If Not cellTemp.IsEmpty() Then
                        Try
                            If cellTemp.DataType = ClosedXML.Excel.XLDataType.Number Then
                                tempInicial = cellTemp.GetDouble()
                                tempValida = True
                            Else
                                ' Trata decimal localizado (vírgula vs ponto)
                                Dim strTemp As String = cellTemp.GetString().Replace(".", ",")
                                If Double.TryParse(strTemp, System.Globalization.NumberStyles.Any, cultureInfo, tempInicial) Then
                                    tempValida = True
                                End If
                            End If
                        Catch ex As Exception
                            erroLinha &= "Formato de temperatura inválido. "
                        End Try
                    Else
                        erroLinha &= "Temperatura inicial vazia. "
                    End If

                    ' 5. Validar sobreposição de ciclos de 24h para a mesma câmara nesta planilha
                    If String.IsNullOrEmpty(erroLinha) Then
                        Dim inicioCiclo = dataInicio.Date.Add(horaInicio)
                        Dim conflito As Boolean = False
                        Dim dtConflito As DateTime = DateTime.MinValue

                        If ciclosAceitos.ContainsKey(sensorId) Then
                            For Each dt In ciclosAceitos(sensorId)
                                If Math.Abs((inicioCiclo - dt).TotalHours) < 24.0 Then
                                    conflito = True
                                    dtConflito = dt
                                    Exit For
                                End If
                            Next
                        End If

                        If conflito Then
                            erroLinha &= $"Conflito de sobreposição. A câmara já possui um ciclo ativo que inicia em {dtConflito.ToString("dd/MM/yyyy HH:mm")} (menos de 24h de intervalo). "
                        Else
                            ' Adiciona na lista de aceitos para esta câmara
                            If Not ciclosAceitos.ContainsKey(sensorId) Then
                                ciclosAceitos(sensorId) = New List(Of DateTime)()
                            End If
                            ciclosAceitos(sensorId).Add(inicioCiclo)
                        End If
                    End If

                    ' Se houver qualquer erro na linha, descarta o registro e acumula o log de erro
                    If Not String.IsNullOrEmpty(erroLinha) Then
                        alertas.Add("Linha " & linhaAtual & ": " & erroLinha)
                    Else
                        ' Registro válido!
                        Dim ciclo As New MaturationCycle() With {
                            .RowIndex = linhaAtual,
                            .Camara = câmara,
                            .SensorId = sensorId,
                            .DataInicio = dataInicio,
                            .HoraInicio = horaInicio,
                            .TempInicial = tempInicial
                        }
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
                                       .Data = c.DataInicio.ToString("dd/MM/yyyy"),
                                       .Hora = c.HoraInicio.ToString("hh\:mm"),
                                       .TempInicial = c.TempInicial.ToString("0.0") & " °C"
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
