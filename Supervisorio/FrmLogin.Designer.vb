<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLogin
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
        Me.pnlCardLogin = New System.Windows.Forms.Panel()
        Me.picAvatar = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.lblSenha = New System.Windows.Forms.Label()
        Me.txtSenha = New System.Windows.Forms.TextBox()
        Me.lblError = New System.Windows.Forms.Label()
        Me.btnEntrar = New System.Windows.Forms.Button()
        Me.btnSair = New System.Windows.Forms.Button()
        Me.pnlCardLogin.SuspendLayout()
        CType(Me.picAvatar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        ' pnlCardLogin
        Me.pnlCardLogin.BackColor = System.Drawing.Color.White
        Me.pnlCardLogin.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.pnlCardLogin.Controls.Add(Me.picAvatar)
        Me.pnlCardLogin.Controls.Add(Me.lblTitle)
        Me.pnlCardLogin.Controls.Add(Me.lblUsuario)
        Me.pnlCardLogin.Controls.Add(Me.txtUsuario)
        Me.pnlCardLogin.Controls.Add(Me.lblSenha)
        Me.pnlCardLogin.Controls.Add(Me.txtSenha)
        Me.pnlCardLogin.Controls.Add(Me.lblError)
        Me.pnlCardLogin.Controls.Add(Me.btnEntrar)
        Me.pnlCardLogin.Controls.Add(Me.btnSair)
        Me.pnlCardLogin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCardLogin.Location = New System.Drawing.Point(0, 0)
        Me.pnlCardLogin.Name = "pnlCardLogin"
        Me.pnlCardLogin.Size = New System.Drawing.Size(380, 320)
        Me.pnlCardLogin.TabIndex = 0

        ' picAvatar
        Me.picAvatar.Image = My.Resources.Resources.usuarios_icon
        Me.picAvatar.Location = New System.Drawing.Point(160, 20)
        Me.picAvatar.Name = "picAvatar"
        Me.picAvatar.Size = New System.Drawing.Size(60, 60)
        Me.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picAvatar.TabIndex = 0
        Me.picAvatar.TabStop = False

        ' lblTitle
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 12.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 64, 115)
        Me.lblTitle.Location = New System.Drawing.Point(0, 90)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(380, 25)
        Me.lblTitle.Text = "Login"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        ' lblUsuario
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(80, 90, 100)
        Me.lblUsuario.Location = New System.Drawing.Point(35, 125)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(51, 15)
        Me.lblUsuario.Text = "Usuário:"

        ' txtUsuario
        Me.txtUsuario.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtUsuario.Location = New System.Drawing.Point(35, 143)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(310, 25)
        Me.txtUsuario.TabIndex = 1

        ' lblSenha
        Me.lblSenha.AutoSize = True
        Me.lblSenha.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblSenha.ForeColor = System.Drawing.Color.FromArgb(80, 90, 100)
        Me.lblSenha.Location = New System.Drawing.Point(35, 175)
        Me.lblSenha.Name = "lblSenha"
        Me.lblSenha.Size = New System.Drawing.Size(43, 15)
        Me.lblSenha.Text = "Senha:"

        ' txtSenha
        Me.txtSenha.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtSenha.Location = New System.Drawing.Point(35, 193)
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSenha.Size = New System.Drawing.Size(310, 25)
        Me.txtSenha.TabIndex = 2

        ' lblError
        Me.lblError.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblError.ForeColor = System.Drawing.Color.Firebrick
        Me.lblError.Location = New System.Drawing.Point(35, 222)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(310, 20)
        Me.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        ' btnEntrar
        Me.btnEntrar.BackColor = System.Drawing.Color.FromArgb(30, 64, 115)
        Me.btnEntrar.FlatAppearance.BorderSize = 0
        Me.btnEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEntrar.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnEntrar.ForeColor = System.Drawing.Color.White
        Me.btnEntrar.Location = New System.Drawing.Point(35, 248)
        Me.btnEntrar.Name = "btnEntrar"
        Me.btnEntrar.Size = New System.Drawing.Size(145, 32)
        Me.btnEntrar.TabIndex = 3
        Me.btnEntrar.Text = "Entrar"
        Me.btnEntrar.UseVisualStyleBackColor = False

        ' btnSair
        Me.btnSair.BackColor = System.Drawing.Color.FromArgb(230, 233, 240)
        Me.btnSair.FlatAppearance.BorderSize = 0
        Me.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSair.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnSair.ForeColor = System.Drawing.Color.FromArgb(80, 90, 100)
        Me.btnSair.Location = New System.Drawing.Point(200, 248)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(145, 32)
        Me.btnSair.TabIndex = 4
        Me.btnSair.Text = "Cancelar"
        Me.btnSair.UseVisualStyleBackColor = True

        ' FrmLogin
        Me.AcceptButton = Me.btnEntrar
        Me.CancelButton = Me.btnSair
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(380, 320)
        Me.Controls.Add(Me.pnlCardLogin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLogin"
        Me.ShowIcon = True
        Me.ShowInTaskbar = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SisMaster - Identificação"
        Me.pnlCardLogin.ResumeLayout(False)
        Me.pnlCardLogin.PerformLayout()
        CType(Me.picAvatar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents pnlCardLogin As System.Windows.Forms.Panel
    Friend WithEvents picAvatar As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents lblSenha As System.Windows.Forms.Label
    Friend WithEvents txtSenha As System.Windows.Forms.TextBox
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents btnEntrar As System.Windows.Forms.Button
    Friend WithEvents btnSair As System.Windows.Forms.Button
End Class
