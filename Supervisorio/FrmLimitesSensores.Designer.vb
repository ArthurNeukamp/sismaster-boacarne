<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLimitesSensores
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlGridContainer = New System.Windows.Forms.Panel()
        Me.dgvLimites = New System.Windows.Forms.DataGridView()
        Me.pnlHeader.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.pnlGridContainer.SuspendLayout()
        CType(Me.dgvLimites, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        ' pnlHeader
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblTitulo)
        Me.pnlHeader.Controls.Add(Me.btnSalvar)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1200, 60)
        Me.pnlHeader.TabIndex = 0

        ' lblTitulo
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 13.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 64, 115)
        Me.lblTitulo.Location = New System.Drawing.Point(20, 16)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(420, 25)
        Me.lblTitulo.Text = "PARAMETRIZAÇÃO DE LIMITES DE TEMPERATURA"

        ' btnSalvar
        Me.btnSalvar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalvar.BackColor = System.Drawing.Color.FromArgb(30, 64, 115)
        Me.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalvar.FlatAppearance.BorderSize = 0
        Me.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalvar.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnSalvar.ForeColor = System.Drawing.Color.White
        Me.btnSalvar.Location = New System.Drawing.Point(1075, 12)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(100, 35)
        Me.btnSalvar.Text = "Salvar"
        Me.btnSalvar.UseVisualStyleBackColor = False

        ' pnlMain
        Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(248, 249, 252)
        Me.pnlMain.Controls.Add(Me.pnlGridContainer)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 60)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlMain.Size = New System.Drawing.Size(1200, 640)
        Me.pnlMain.TabIndex = 1

        ' pnlGridContainer
        Me.pnlGridContainer.BackColor = System.Drawing.Color.White
        Me.pnlGridContainer.Controls.Add(Me.dgvLimites)
        Me.pnlGridContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGridContainer.Location = New System.Drawing.Point(20, 20)
        Me.pnlGridContainer.Name = "pnlGridContainer"
        Me.pnlGridContainer.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlGridContainer.Size = New System.Drawing.Size(1160, 600)
        Me.pnlGridContainer.TabIndex = 0

        ' dgvLimites
        Me.dgvLimites.AllowUserToAddRows = False
        Me.dgvLimites.AllowUserToDeleteRows = False
        Me.dgvLimites.AllowUserToResizeRows = False
        Me.dgvLimites.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvLimites.BackgroundColor = System.Drawing.Color.White
        Me.dgvLimites.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvLimites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLimites.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLimites.Location = New System.Drawing.Point(10, 10)
        Me.dgvLimites.MultiSelect = False
        Me.dgvLimites.Name = "dgvLimites"
        Me.dgvLimites.RowHeadersVisible = False
        Me.dgvLimites.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvLimites.Size = New System.Drawing.Size(1140, 580)
        Me.dgvLimites.TabIndex = 0

        ' FrmLimitesSensores
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7F, 15F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 700)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "FrmLimitesSensores"
        Me.Text = "Configurações de Limites dos Sensores"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlGridContainer.ResumeLayout(False)
        CType(Me.dgvLimites, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnSalvar As System.Windows.Forms.Button
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents pnlGridContainer As System.Windows.Forms.Panel
    Friend WithEvents dgvLimites As System.Windows.Forms.DataGridView
End Class
