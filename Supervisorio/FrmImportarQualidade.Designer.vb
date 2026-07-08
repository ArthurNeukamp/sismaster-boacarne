<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmImportarQualidade
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

    Friend WithEvents lblArquivo As Label
    Friend WithEvents tcImportacao As TabControl
    Friend WithEvents tpValidos As TabPage
    Friend WithEvents tpAlertas As TabPage
    Friend WithEvents dgvCiclos As DataGridView
    Friend WithEvents txtAlertas As TextBox
    Friend WithEvents pnlBotoes As Panel
    Friend WithEvents btnImportar As Button
    Friend WithEvents btnFechar As Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblArquivo = New Label()
        tcImportacao = New TabControl()
        tpValidos = New TabPage()
        tpAlertas = New TabPage()
        dgvCiclos = New DataGridView()
        txtAlertas = New TextBox()
        pnlBotoes = New Panel()
        btnImportar = New Button()
        btnFechar = New Button()

        CType(dgvCiclos, System.ComponentModel.ISupportInitialize).BeginInit()
        tcImportacao.SuspendLayout()
        tpValidos.SuspendLayout()
        tpAlertas.SuspendLayout()
        pnlBotoes.SuspendLayout()
        SuspendLayout()

        ' lblArquivo
        lblArquivo.Dock = DockStyle.Top
        lblArquivo.Height = 40
        lblArquivo.Padding = New Padding(10)
        lblArquivo.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblArquivo.Text = "Arquivo: "

        ' tcImportacao
        tcImportacao.Dock = DockStyle.Fill
        tcImportacao.Controls.Add(tpValidos)
        tcImportacao.Controls.Add(tpAlertas)

        ' tpValidos
        tpValidos.Text = "Registros Válidos"
        tpValidos.Controls.Add(dgvCiclos)

        ' dgvCiclos
        dgvCiclos.Dock = DockStyle.Fill
        dgvCiclos.AllowUserToAddRows = False
        dgvCiclos.AllowUserToDeleteRows = False
        dgvCiclos.ReadOnly = True
        dgvCiclos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvCiclos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize

        ' tpAlertas
        tpAlertas.Text = "Alertas e Erros"
        tpAlertas.Controls.Add(txtAlertas)

        ' txtAlertas
        txtAlertas.Dock = DockStyle.Fill
        txtAlertas.Multiline = True
        txtAlertas.ReadOnly = True
        txtAlertas.ScrollBars = ScrollBars.Vertical
        txtAlertas.Font = New Font("Consolas", 9.0F)
        txtAlertas.BackColor = Color.White
        txtAlertas.ForeColor = Color.DarkRed

        ' pnlBotoes
        pnlBotoes.Dock = DockStyle.Bottom
        pnlBotoes.Height = 50
        pnlBotoes.Controls.AddRange(New Control() {btnImportar, btnFechar})
        pnlBotoes.Padding = New Padding(10)

        ' btnImportar
        btnImportar.Text = "Gerar Gráficos"
        btnImportar.DialogResult = DialogResult.OK
        btnImportar.Width = 150
        btnImportar.Height = 30
        btnImportar.Location = New Point(10, 10)
        btnImportar.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnImportar.BackColor = Color.FromArgb(16, 124, 65)
        btnImportar.ForeColor = Color.White
        btnImportar.FlatStyle = FlatStyle.Flat

        ' btnFechar
        btnFechar.Text = "Cancelar"
        btnFechar.DialogResult = DialogResult.Cancel
        btnFechar.Width = 100
        btnFechar.Height = 30
        btnFechar.Location = New Point(170, 10)
        btnFechar.FlatStyle = FlatStyle.System

        ' FrmImportarQualidade
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(750, 480)
        Controls.Add(tcImportacao)
        Controls.Add(lblArquivo)
        Controls.Add(pnlBotoes)
        Text = "Importar Períodos de Maturação"
        StartPosition = FormStartPosition.CenterParent
        MinimizeBox = False
        MaximizeBox = False

        CType(dgvCiclos, System.ComponentModel.ISupportInitialize).EndInit()
        tcImportacao.ResumeLayout(False)
        tpValidos.ResumeLayout(False)
        tpAlertas.ResumeLayout(False)
        pnlBotoes.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
End Class
