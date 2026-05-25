<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRelatorios
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblSensor      = New Label()
        cbSensor       = New ComboBox()
        lblInicio      = New Label()
        dtpInicio      = New DateTimePicker()
        lblFim         = New Label()
        dtpFim         = New DateTimePicker()
        btnAtualizar   = New Button()
        btnExportarPDF = New Button()
        dgvLeituras    = New DataGridView()
        lblTotal       = New Label()
        pnlFiltros     = New Panel()
        CType(dgvLeituras, System.ComponentModel.ISupportInitialize).BeginInit()
        pnlFiltros.SuspendLayout()
        SuspendLayout()

        ' pnlFiltros
        pnlFiltros.Controls.AddRange(New Control() {
            lblSensor, cbSensor, lblInicio, dtpInicio,
            lblFim, dtpFim, btnAtualizar, btnExportarPDF})
        pnlFiltros.Dock    = DockStyle.Top
        pnlFiltros.Height  = 50
        pnlFiltros.Padding = New Padding(6, 8, 6, 0)

        ' lblSensor
        lblSensor.AutoSize = True
        lblSensor.Location = New Point(8, 14)
        lblSensor.Text     = "Sensor:"

        ' cbSensor
        cbSensor.DropDownStyle = ComboBoxStyle.DropDownList
        cbSensor.Location      = New Point(60, 11)
        cbSensor.Width         = 220

        ' lblInicio
        lblInicio.AutoSize = True
        lblInicio.Location = New Point(295, 14)
        lblInicio.Text     = "De:"

        ' dtpInicio
        dtpInicio.Format       = DateTimePickerFormat.Custom
        dtpInicio.CustomFormat = "dd/MM/yyyy HH:mm"
        dtpInicio.Location     = New Point(320, 11)
        dtpInicio.Width        = 145

        ' lblFim
        lblFim.AutoSize = True
        lblFim.Location = New Point(475, 14)
        lblFim.Text     = "Até:"

        ' dtpFim
        dtpFim.Format       = DateTimePickerFormat.Custom
        dtpFim.CustomFormat = "dd/MM/yyyy HH:mm"
        dtpFim.Location     = New Point(502, 11)
        dtpFim.Width        = 145

        ' btnAtualizar — consulta o banco com os filtros atuais e popula o grid
        btnAtualizar.Location = New Point(660, 9)
        btnAtualizar.Size     = New Size(90, 26)
        btnAtualizar.Text     = "Atualizar"

        ' btnExportarPDF — habilitado somente apos grid ter dados
        btnExportarPDF.Location = New Point(758, 9)
        btnExportarPDF.Size     = New Size(110, 26)
        btnExportarPDF.Text     = "Exportar PDF"
        btnExportarPDF.Enabled  = False

        ' dgvLeituras
        dgvLeituras.AllowUserToAddRows    = False
        dgvLeituras.AllowUserToDeleteRows = False
        dgvLeituras.AllowUserToResizeRows = False
        dgvLeituras.ReadOnly              = True
        dgvLeituras.SelectionMode         = DataGridViewSelectionMode.FullRowSelect
        dgvLeituras.Dock                  = DockStyle.Fill
        dgvLeituras.RowHeadersVisible     = False
        dgvLeituras.AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill

        ' lblTotal
        lblTotal.Dock      = DockStyle.Bottom
        lblTotal.Height    = 22
        lblTotal.TextAlign = ContentAlignment.MiddleLeft
        lblTotal.Padding   = New Padding(6, 0, 0, 0)
        lblTotal.Text      = ""

        ' FrmRelatorios
        ClientSize    = New Size(1000, 600)
        Text          = "Relatórios de Temperatura"
        StartPosition = FormStartPosition.CenterParent
        MinimizeBox   = False
        Controls.AddRange(New Control() {dgvLeituras, pnlFiltros, lblTotal})

        CType(dgvLeituras, System.ComponentModel.ISupportInitialize).EndInit()
        pnlFiltros.ResumeLayout(False)
        pnlFiltros.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblSensor      As Label
    Friend WithEvents cbSensor       As ComboBox
    Friend WithEvents lblInicio      As Label
    Friend WithEvents dtpInicio      As DateTimePicker
    Friend WithEvents lblFim         As Label
    Friend WithEvents dtpFim         As DateTimePicker
    Friend WithEvents btnAtualizar   As Button
    Friend WithEvents btnExportarPDF As Button
    Friend WithEvents dgvLeituras    As DataGridView
    Friend WithEvents lblTotal       As Label
    Friend WithEvents pnlFiltros     As Panel

End Class
