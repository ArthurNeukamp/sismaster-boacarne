<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmControleUsuarios
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
        Me.pnlEsquerdo = New System.Windows.Forms.Panel()
        Me.grpLista = New System.Windows.Forms.GroupBox()
        Me.dgvUsuarios = New System.Windows.Forms.DataGridView()
        Me.grpCadastro = New System.Windows.Forms.GroupBox()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.lblSenha = New System.Windows.Forms.Label()
        Me.txtSenha = New System.Windows.Forms.TextBox()
        Me.lblAvisoSenha = New System.Windows.Forms.Label()
        Me.lblConfirmarSenha = New System.Windows.Forms.Label()
        Me.txtConfirmarSenha = New System.Windows.Forms.TextBox()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.cbGrupo = New System.Windows.Forms.ComboBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.btnLimpar = New System.Windows.Forms.Button()
        Me.pnlEsquerdo.SuspendLayout()
        Me.grpLista.SuspendLayout()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCadastro.SuspendLayout()
        Me.SuspendLayout()

        ' pnlEsquerdo
        Me.pnlEsquerdo.Controls.Add(Me.grpLista)
        Me.pnlEsquerdo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEsquerdo.Location = New System.Drawing.Point(0, 0)
        Me.pnlEsquerdo.Name = "pnlEsquerdo"
        Me.pnlEsquerdo.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlEsquerdo.Size = New System.Drawing.Size(500, 500)
        Me.pnlEsquerdo.TabIndex = 0

        ' grpLista
        Me.grpLista.Controls.Add(Me.dgvUsuarios)
        Me.grpLista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpLista.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.grpLista.Location = New System.Drawing.Point(10, 10)
        Me.grpLista.Name = "grpLista"
        Me.grpLista.Padding = New System.Windows.Forms.Padding(10)
        Me.grpLista.Size = New System.Drawing.Size(480, 480)
        Me.grpLista.TabIndex = 0
        Me.grpLista.TabStop = False
        Me.grpLista.Text = "Usuários Cadastrados"
        Me.grpLista.BackColor = System.Drawing.Color.White

        ' dgvUsuarios
        Me.dgvUsuarios.AllowUserToAddRows = False
        Me.dgvUsuarios.AllowUserToDeleteRows = False
        Me.dgvUsuarios.AllowUserToResizeRows = False
        Me.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUsuarios.Location = New System.Drawing.Point(10, 27)
        Me.dgvUsuarios.MultiSelect = False
        Me.dgvUsuarios.Name = "dgvUsuarios"
        Me.dgvUsuarios.ReadOnly = True
        Me.dgvUsuarios.RowHeadersVisible = False
        Me.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUsuarios.Size = New System.Drawing.Size(460, 443)
        Me.dgvUsuarios.TabIndex = 0

        ' grpCadastro
        Me.grpCadastro.Controls.Add(Me.lblUsuario)
        Me.grpCadastro.Controls.Add(Me.txtUsuario)
        Me.grpCadastro.Controls.Add(Me.lblSenha)
        Me.grpCadastro.Controls.Add(Me.txtSenha)
        Me.grpCadastro.Controls.Add(Me.lblAvisoSenha)
        Me.grpCadastro.Controls.Add(Me.lblConfirmarSenha)
        Me.grpCadastro.Controls.Add(Me.txtConfirmarSenha)
        Me.grpCadastro.Controls.Add(Me.lblGrupo)
        Me.grpCadastro.Controls.Add(Me.cbGrupo)
        Me.grpCadastro.Controls.Add(Me.lblEmail)
        Me.grpCadastro.Controls.Add(Me.txtEmail)
        Me.grpCadastro.Controls.Add(Me.btnSalvar)
        Me.grpCadastro.Controls.Add(Me.btnExcluir)
        Me.grpCadastro.Controls.Add(Me.btnLimpar)
        Me.grpCadastro.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.grpCadastro.Location = New System.Drawing.Point(515, 10)
        Me.grpCadastro.Name = "grpCadastro"
        Me.grpCadastro.Size = New System.Drawing.Size(360, 480)
        Me.grpCadastro.TabIndex = 1
        Me.grpCadastro.TabStop = False
        Me.grpCadastro.Text = "Cadastro / Edição de Usuário"
        Me.grpCadastro.BackColor = System.Drawing.Color.White

        ' lblUsuario
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblUsuario.Location = New System.Drawing.Point(20, 35)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(52, 15)
        Me.lblUsuario.Text = "Usuário:"

        ' txtUsuario
        Me.txtUsuario.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtUsuario.Location = New System.Drawing.Point(20, 53)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(320, 24)
        Me.txtUsuario.TabIndex = 1

        ' lblSenha
        Me.lblSenha.AutoSize = True
        Me.lblSenha.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblSenha.Location = New System.Drawing.Point(20, 95)
        Me.lblSenha.Name = "lblSenha"
        Me.lblSenha.Size = New System.Drawing.Size(44, 15)
        Me.lblSenha.Text = "Senha:"

        ' txtSenha
        Me.txtSenha.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtSenha.Location = New System.Drawing.Point(20, 113)
        Me.txtSenha.Name = "txtSenha"
        Me.txtSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtSenha.Size = New System.Drawing.Size(320, 24)
        Me.txtSenha.TabIndex = 2

        ' lblAvisoSenha
        Me.lblAvisoSenha.AutoSize = True
        Me.lblAvisoSenha.Font = New System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblAvisoSenha.ForeColor = System.Drawing.Color.DimGray
        Me.lblAvisoSenha.Location = New System.Drawing.Point(20, 140)
        Me.lblAvisoSenha.Name = "lblAvisoSenha"
        Me.lblAvisoSenha.Size = New System.Drawing.Size(262, 12)
        Me.lblAvisoSenha.Text = "* Deixe em branco para manter a senha atual ao editar."

        ' lblConfirmarSenha
        Me.lblConfirmarSenha.AutoSize = True
        Me.lblConfirmarSenha.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblConfirmarSenha.Location = New System.Drawing.Point(20, 165)
        Me.lblConfirmarSenha.Name = "lblConfirmarSenha"
        Me.lblConfirmarSenha.Size = New System.Drawing.Size(102, 15)
        Me.lblConfirmarSenha.Text = "Confirmar Senha:"

        ' txtConfirmarSenha
        Me.txtConfirmarSenha.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtConfirmarSenha.Location = New System.Drawing.Point(20, 183)
        Me.txtConfirmarSenha.Name = "txtConfirmarSenha"
        Me.txtConfirmarSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmarSenha.Size = New System.Drawing.Size(320, 24)
        Me.txtConfirmarSenha.TabIndex = 3

        ' lblGrupo
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblGrupo.Location = New System.Drawing.Point(20, 225)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(46, 15)
        Me.lblGrupo.Text = "Grupo:"

        ' cbGrupo
        Me.cbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGrupo.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.cbGrupo.FormattingEnabled = True
        Me.cbGrupo.Location = New System.Drawing.Point(20, 243)
        Me.cbGrupo.Name = "cbGrupo"
        Me.cbGrupo.Size = New System.Drawing.Size(320, 25)
        Me.cbGrupo.TabIndex = 4

        ' lblEmail
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblEmail.Location = New System.Drawing.Point(20, 285)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(102, 15)
        Me.lblEmail.Text = "E-mail (opcional):"

        ' txtEmail
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtEmail.Location = New System.Drawing.Point(20, 303)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(320, 24)
        Me.txtEmail.TabIndex = 5

        ' btnSalvar
        Me.btnSalvar.BackColor = System.Drawing.Color.FromArgb(30, 64, 115)
        Me.btnSalvar.FlatAppearance.BorderSize = 0
        Me.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalvar.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnSalvar.ForeColor = System.Drawing.Color.White
        Me.btnSalvar.Location = New System.Drawing.Point(20, 355)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(320, 32)
        Me.btnSalvar.TabIndex = 6
        Me.btnSalvar.Text = "Salvar Usuário"
        Me.btnSalvar.UseVisualStyleBackColor = False

        ' btnExcluir
        Me.btnExcluir.BackColor = System.Drawing.Color.Firebrick
        Me.btnExcluir.FlatAppearance.BorderSize = 0
        Me.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcluir.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnExcluir.ForeColor = System.Drawing.Color.White
        Me.btnExcluir.Location = New System.Drawing.Point(20, 395)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Size = New System.Drawing.Size(150, 32)
        Me.btnExcluir.TabIndex = 7
        Me.btnExcluir.Text = "Excluir"
        Me.btnExcluir.UseVisualStyleBackColor = False

        ' btnLimpar
        Me.btnLimpar.BackColor = System.Drawing.Color.FromArgb(230, 233, 240)
        Me.btnLimpar.FlatAppearance.BorderSize = 0
        Me.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnLimpar.ForeColor = System.Drawing.Color.FromArgb(80, 90, 100)
        Me.btnLimpar.Location = New System.Drawing.Point(190, 395)
        Me.btnLimpar.Name = "btnLimpar"
        Me.btnLimpar.Size = New System.Drawing.Size(150, 32)
        Me.btnLimpar.TabIndex = 8
        Me.btnLimpar.Text = "Limpar / Novo"
        Me.btnLimpar.UseVisualStyleBackColor = True

        ' FrmControleUsuarios
        Me.BackColor = System.Drawing.Color.FromArgb(245, 247, 250)
        Me.ClientSize = New System.Drawing.Size(890, 500)
        Me.Controls.Add(Me.grpCadastro)
        Me.Controls.Add(Me.pnlEsquerdo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmControleUsuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gerenciamento de Usuários"
        Me.pnlEsquerdo.ResumeLayout(False)
        Me.grpLista.ResumeLayout(False)
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCadastro.ResumeLayout(False)
        Me.grpCadastro.PerformLayout()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents pnlEsquerdo As System.Windows.Forms.Panel
    Friend WithEvents grpLista As System.Windows.Forms.GroupBox
    Friend WithEvents dgvUsuarios As System.Windows.Forms.DataGridView
    Friend WithEvents grpCadastro As System.Windows.Forms.GroupBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents lblSenha As System.Windows.Forms.Label
    Friend WithEvents txtSenha As System.Windows.Forms.TextBox
    Friend WithEvents lblAvisoSenha As System.Windows.Forms.Label
    Friend WithEvents lblConfirmarSenha As System.Windows.Forms.Label
    Friend WithEvents txtConfirmarSenha As System.Windows.Forms.TextBox
    Friend WithEvents lblGrupo As System.Windows.Forms.Label
    Friend WithEvents cbGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents btnSalvar As System.Windows.Forms.Button
    Friend WithEvents btnExcluir As System.Windows.Forms.Button
    Friend WithEvents btnLimpar As System.Windows.Forms.Button
End Class
