Public Class FrmRelatorios

    Private ReadOnly _db     As DatabaseService
    Private ReadOnly _config As ConfiguracaoApp

    ' Cores usadas em AplicarEstilo e no controle visual do botao PDF
    Private ReadOnly _azulPrincipal As Color = Color.FromArgb(30, 64, 115)
    Private ReadOnly _cinzaBotao    As Color = Color.FromArgb(200, 205, 215)
    Private ReadOnly _cinzaTexto    As Color = Color.FromArgb(140, 148, 160)

    Public Sub New(db As DatabaseService, config As ConfiguracaoApp)
        InitializeComponent()
        _db     = db
        _config = config
    End Sub

    Private Sub FrmRelatorios_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim atraso = _config.PeriodoPadraoAtrasoDias
        dtpInicio.Value = DateTime.Now.AddDays(-atraso).Date
        dtpFim.Value    = DateTime.Now.Date.AddDays(1).AddSeconds(-1)

        cbSensor.Items.Clear()
        For Each kvp In _config.Sensores.OrderBy(Function(x) x.Value)
            cbSensor.Items.Add(New SensorItem(kvp.Key, kvp.Value))
        Next
        If cbSensor.Items.Count > 0 Then cbSensor.SelectedIndex = 0

        ConfigurarColunasDGV()
        AplicarEstilo()
    End Sub

    Private Sub ConfigurarColunasDGV()
        dgvLeituras.Columns.Clear()

        Dim colData As New DataGridViewTextBoxColumn With {
            .Name             = "colDataHora",
            .HeaderText       = "Data / Hora",
            .DataPropertyName = "data_hora_fmt",
            .Width            = 160,
            .DefaultCellStyle = New DataGridViewCellStyle With {
                .Alignment = DataGridViewContentAlignment.MiddleCenter
            }
        }
        Dim colTemp As New DataGridViewTextBoxColumn With {
            .Name             = "colTemperatura",
            .HeaderText       = "Temperatura (°C)",
            .DataPropertyName = "temperatura",
            .DefaultCellStyle = New DataGridViewCellStyle With {
                .Format    = "F1",
                .Alignment = DataGridViewContentAlignment.MiddleCenter
            }
        }
        dgvLeituras.AutoGenerateColumns = False
        dgvLeituras.Columns.AddRange(colData, colTemp)
        dgvLeituras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub btnAtualizar_Click(sender As Object, e As EventArgs) Handles btnAtualizar.Click
        ExecutarConsulta()
    End Sub

    Private Sub ExecutarConsulta()
        If cbSensor.SelectedItem Is Nothing Then
            MessageBox.Show("Selecione um sensor.", "Atenção",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If dtpFim.Value < dtpInicio.Value Then
            MessageBox.Show("A data final deve ser maior que a inicial.", "Atenção",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Cursor = Cursors.WaitCursor
        Try
            Dim sensor = CType(cbSensor.SelectedItem, SensorItem)
            Dim dados  = _db.ConsultarSensor(sensor.Id, dtpInicio.Value, dtpFim.Value)
            AdicionarColunaFormatada(dados)
            dgvLeituras.DataSource = dados

            Dim temDados = dados.Rows.Count > 0
            AtualizarEstadoBotaoPDF(temDados)

            If temDados Then
                lblTotal.Text = dados.Rows.Count.ToString("N0") & " registros  -  " & sensor.Nome
            Else
                lblTotal.Text = "Nenhum registro encontrado para o periodo selecionado."
            End If
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    ' Controla visual do botao Exportar PDF manualmente porque FlatStyle.Flat
    ' nao muda aparencia automaticamente ao desabilitar.
    Private Sub AtualizarEstadoBotaoPDF(habilitado As Boolean)
        btnExportarPDF.Enabled = habilitado
        If habilitado Then
            btnExportarPDF.BackColor                     = _azulPrincipal
            btnExportarPDF.ForeColor                     = Color.White
            btnExportarPDF.FlatAppearance.BorderColor    = _azulPrincipal
            btnExportarPDF.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 90, 145)
        Else
            btnExportarPDF.BackColor                     = _cinzaBotao
            btnExportarPDF.ForeColor                     = _cinzaTexto
            btnExportarPDF.FlatAppearance.BorderColor    = _cinzaBotao
            btnExportarPDF.FlatAppearance.MouseOverBackColor = _cinzaBotao
        End If
    End Sub

    ' Adiciona coluna data_hora_fmt com a data ja formatada para exibicao no grid.
    Private Sub AdicionarColunaFormatada(dt As DataTable)
        If Not dt.Columns.Contains("data_hora") Then Return
        If dt.Columns.Contains("data_hora_fmt") Then dt.Columns.Remove("data_hora_fmt")

        dt.Columns.Add("data_hora_fmt", GetType(String))
        For Each row As DataRow In dt.Rows
            Dim dh As DateTime
            If DateTime.TryParse(row("data_hora").ToString(), dh) Then
                row("data_hora_fmt") = dh.ToString("dd/MM/yyyy HH:mm:ss")
            Else
                row("data_hora_fmt") = row("data_hora").ToString()
            End If
        Next
    End Sub

    Private Sub btnExportarPDF_Click(sender As Object, e As EventArgs) Handles btnExportarPDF.Click
        If dgvLeituras.RowCount = 0 Then Return

        Dim sensor = CType(cbSensor.SelectedItem, SensorItem)
        
        Dim pasta As String = _config.PastaExportacao
        Dim nomeArquivo As String = "Leituras_" & sensor.Nome & "_" & DateTime.Now.ToString("dd-MM-yyyy_HHmm") & ".pdf"
        Dim caminhoCompleto As String = System.IO.Path.Combine(pasta, nomeArquivo)

        Cursor = Cursors.WaitCursor
        Try
            Dim dados = CType(dgvLeituras.DataSource, DataTable)
            Dim svc   = New RelatorioService(_config)
            svc.ExportarPDF(dados, caminhoCompleto, sensor.Nome, dtpInicio.Value, dtpFim.Value)
            Process.Start(New ProcessStartInfo(caminhoCompleto) With {.UseShellExecute = True})
        Catch ex As Exception
            MessageBox.Show("Erro ao gerar PDF: " & ex.Message, "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub AplicarEstilo()
        Dim azulClaro   = Color.FromArgb(240, 245, 255)
        Dim azulSelecao = Color.FromArgb(180, 210, 240)
        Dim fundoForm   = Color.FromArgb(248, 249, 252)
        Dim fundoPainel = Color.FromArgb(235, 241, 250)
        Dim cinzaRodape = Color.FromArgb(100, 110, 130)
        Dim fonteNormal = New Font("Segoe UI", 9F)
        Dim fonteBold   = New Font("Segoe UI", 9F, FontStyle.Bold)

        Me.BackColor     = fundoForm
        pnlFiltros.BackColor = fundoPainel

        For Each ctrl As Control In pnlFiltros.Controls
            If TypeOf ctrl Is Label Then
                ctrl.Font      = fonteNormal
                ctrl.ForeColor = _azulPrincipal
            End If
        Next

        cbSensor.Font  = fonteNormal
        dtpInicio.Font = fonteNormal
        dtpFim.Font    = fonteNormal

        ' Botao Atualizar
        btnAtualizar.FlatStyle                     = FlatStyle.Flat
        btnAtualizar.BackColor                     = _azulPrincipal
        btnAtualizar.ForeColor                     = Color.White
        btnAtualizar.Font                          = fonteBold
        btnAtualizar.FlatAppearance.BorderSize     = 0
        btnAtualizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 90, 145)

        ' Botao Exportar PDF — visual inicial desabilitado
        btnExportarPDF.FlatStyle               = FlatStyle.Flat
        btnExportarPDF.Font                    = fonteBold
        btnExportarPDF.FlatAppearance.BorderSize = 0
        AtualizarEstadoBotaoPDF(False)

        ' DataGridView
        dgvLeituras.EnableHeadersVisualStyles  = False
        dgvLeituras.BorderStyle                = BorderStyle.None
        dgvLeituras.BackgroundColor            = Color.White
        dgvLeituras.GridColor                  = Color.FromArgb(210, 220, 235)
        dgvLeituras.Font                       = fonteNormal

        dgvLeituras.ColumnHeadersDefaultCellStyle.BackColor          = _azulPrincipal
        dgvLeituras.ColumnHeadersDefaultCellStyle.ForeColor          = Color.White
        dgvLeituras.ColumnHeadersDefaultCellStyle.Font               = fonteBold
        dgvLeituras.ColumnHeadersDefaultCellStyle.SelectionBackColor = _azulPrincipal
        dgvLeituras.ColumnHeadersDefaultCellStyle.Padding            = New Padding(4, 0, 0, 0)
        dgvLeituras.ColumnHeadersHeight                              = 30
        dgvLeituras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

        dgvLeituras.DefaultCellStyle.BackColor          = Color.White
        dgvLeituras.DefaultCellStyle.ForeColor          = Color.FromArgb(40, 50, 65)
        dgvLeituras.DefaultCellStyle.SelectionBackColor = azulSelecao
        dgvLeituras.DefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 40, 70)
        dgvLeituras.DefaultCellStyle.Padding            = New Padding(4, 0, 4, 0)
        dgvLeituras.RowTemplate.Height                  = 26

        dgvLeituras.AlternatingRowsDefaultCellStyle.BackColor          = azulClaro
        dgvLeituras.AlternatingRowsDefaultCellStyle.SelectionBackColor = azulSelecao
        dgvLeituras.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 40, 70)

        lblTotal.Font      = fonteNormal
        lblTotal.ForeColor = cinzaRodape
        lblTotal.BackColor = fundoForm
    End Sub

End Class

Public Class SensorItem
    Public ReadOnly Property Id   As Integer
    Public ReadOnly Property Nome As String

    Public Sub New(id As Integer, nome As String)
        Me.Id   = id
        Me.Nome = nome
    End Sub

    Public Overrides Function ToString() As String
        Return Nome
    End Function
End Class
