Imports System.Windows.Forms
Imports System.Drawing

Public Class FrmLimitesSensores
    Private ReadOnly _db As DatabaseService
    Private ReadOnly _config As ConfiguracaoApp

    ' Índices dos 38 sensores monitorados
    Private Shared ReadOnly _sensorIds As Integer() = {
        1, 2, 3, 4, 5, 6, 7, 8,
        11, 12, 13, 14, 15, 16,
        21, 22, 23, 24, 25, 26, 27, 28,
        29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44
    }

    Public Sub New(db As DatabaseService, config As ConfiguracaoApp)
        InitializeComponent()
        _db = db
        _config = config
    End Sub

    Private Sub FrmLimitesSensores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Oculta os painéis sobrepostos no MainForm
        If MainForm.PainelSadema IsNot Nothing Then MainForm.PainelSadema.Visible = False
        If MainForm.lblResult IsNot Nothing Then MainForm.lblResult.Visible = False

        AplicarEstilo()
        ConfigurarColunasGrid()
        CarregarDados()
    End Sub

    Private Sub AplicarEstilo()
        ' Customiza cabeçalho e linhas do DataGridView
        dgvLimites.EnableHeadersVisualStyles = False
        dgvLimites.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 64, 115)
        dgvLimites.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvLimites.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        dgvLimites.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvLimites.ColumnHeadersHeight = 35

        dgvLimites.DefaultCellStyle.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
        dgvLimites.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 250)
        dgvLimites.DefaultCellStyle.SelectionForeColor = Color.Black
        dgvLimites.GridColor = Color.FromArgb(210, 220, 235)
        dgvLimites.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 253)
    End Sub

    Private Sub ConfigurarColunasGrid()
        dgvLimites.Columns.Clear()

        ' Column 0: ID
        Dim colId As New DataGridViewTextBoxColumn()
        colId.Name = "Id"
        colId.HeaderText = "ID"
        colId.ReadOnly = True
        colId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        colId.FillWeight = 40
        dgvLimites.Columns.Add(colId)

        ' Column 1: Nome do Ambiente
        Dim colNome As New DataGridViewTextBoxColumn()
        colNome.Name = "Ambiente"
        colNome.HeaderText = "Ambiente / Sensor"
        colNome.ReadOnly = True
        colNome.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        colNome.FillWeight = 180
        dgvLimites.Columns.Add(colNome)

        ' Column 2: Habilitado (Checkbox)
        Dim colHabilitado As New DataGridViewCheckBoxColumn()
        colHabilitado.Name = "Habilitado"
        colHabilitado.HeaderText = "Ativar Limites"
        colHabilitado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        colHabilitado.FillWeight = 60
        dgvLimites.Columns.Add(colHabilitado)

        ' Column 3: Mínima
        Dim colMin As New DataGridViewTextBoxColumn()
        colMin.Name = "TempMin"
        colMin.HeaderText = "Temp. Mínima (°C)"
        colMin.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        colMin.FillWeight = 70
        dgvLimites.Columns.Add(colMin)

        ' Column 4: Máxima
        Dim colMax As New DataGridViewTextBoxColumn()
        colMax.Name = "TempMax"
        colMax.HeaderText = "Temp. Máxima (°C)"
        colMax.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        colMax.FillWeight = 70
        dgvLimites.Columns.Add(colMax)
    End Sub

    Private Sub CarregarDados()
        Try
            ' Carrega limites salvos no banco
            Dim limites = _db.ObterLimitesSensores().ToDictionary(Function(x) x.SensorId)

            dgvLimites.Rows.Clear()
            For Each sid In _sensorIds
                Dim nome As String = $"Sensor {sid}"
                _config.Sensores.TryGetValue(sid, nome)

                Dim habilitado As Boolean = False
                Dim tempMin As Double = 0.0
                Dim tempMax As Double = 0.0

                Dim lim As LimiteSensorDto = Nothing
                If limites.TryGetValue(sid, lim) Then
                    habilitado = lim.Habilitado
                    tempMin = lim.TempMin
                    tempMax = lim.TempMax
                End If

                Dim rowIdx = dgvLimites.Rows.Add()
                Dim r = dgvLimites.Rows(rowIdx)
                r.Cells("Id").Value = sid
                r.Cells("Ambiente").Value = nome
                r.Cells("Habilitado").Value = habilitado
                r.Cells("TempMin").Value = tempMin.ToString("F1")
                r.Cells("TempMax").Value = tempMax.ToString("F1")
            Next
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar configurações de limites: " & ex.Message,
                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        ' Finaliza edição pendente na célula
        dgvLimites.EndEdit()

        Dim listaLimites As New List(Of LimiteSensorDto)()
        Dim decSep = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator

        ' Validação dos dados
        For Each r As DataGridViewRow In dgvLimites.Rows
            Dim sid As Integer = Convert.ToInt32(r.Cells("Id").Value)
            Dim nome As String = Convert.ToString(r.Cells("Ambiente").Value)
            Dim habilitado As Boolean = Convert.ToBoolean(r.Cells("Habilitado").Value)

            Dim valMinStr = Convert.ToString(r.Cells("TempMin").Value)
            Dim valMaxStr = Convert.ToString(r.Cells("TempMax").Value)

            ' Uniformiza separadores de ponto/vírgula conforme a cultura do sistema
            Dim cleanMinStr = valMinStr.Replace(".", decSep).Replace(",", decSep)
            Dim cleanMaxStr = valMaxStr.Replace(".", decSep).Replace(",", decSep)

            Dim tempMin As Double = 0.0
            Dim tempMax As Double = 0.0

            If Not Double.TryParse(cleanMinStr, tempMin) Then
                MessageBox.Show($"Temperatura Mínima inválida para o ambiente '{nome}'.",
                                "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If Not Double.TryParse(cleanMaxStr, tempMax) Then
                MessageBox.Show($"Temperatura Máxima inválida para o ambiente '{nome}'.",
                                "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If tempMin > tempMax Then
                MessageBox.Show($"A Temperatura Mínima não pode ser maior que a Temperatura Máxima no ambiente '{nome}'.",
                                "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            listaLimites.Add(New LimiteSensorDto With {
                .SensorId = sid,
                .Habilitado = habilitado,
                .TempMin = tempMin,
                .TempMax = tempMax
            })
        Next

        ' Gravação no banco
        Try
            _db.SalvarLimitesSensores(listaLimites)
            MessageBox.Show("Limites de temperatura salvos com sucesso!",
                            "Limites Sensores", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CarregarDados()
        Catch ex As Exception
            MessageBox.Show("Erro ao salvar limites: " & ex.Message,
                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmLimitesSensores_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' Reexibe os painéis sobrepostos no MainForm
        If MainForm.PainelSadema IsNot Nothing Then MainForm.PainelSadema.Visible = True
        If MainForm.lblResult IsNot Nothing Then MainForm.lblResult.Visible = True
    End Sub
End Class
