Imports System.Windows.Forms

Public Class FrmControleUsuarios
    Private ReadOnly _db As DatabaseService
    Private _selectedUser As UsuarioDto = Nothing
    Private _listaOriginal As List(Of UsuarioDto) = Nothing

    Public Sub New(db As DatabaseService)
        InitializeComponent()
        _db = db
    End Sub

    Private Sub FrmControleUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Inicializar ComboBox de Grupos
        cbGrupo.Items.Clear()
        cbGrupo.Items.AddRange(New Object() {"Operação", "Manutenção", "Administração"})
        cbGrupo.SelectedIndex = 0

        ' Configurações iniciais do grid
        dgvUsuarios.AutoGenerateColumns = False
        dgvUsuarios.Columns.Clear()
        dgvUsuarios.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Usuario", .HeaderText = "Usuário", .Name = "ColUsuario"})
        dgvUsuarios.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "GrupoExibicao", .HeaderText = "Grupo", .Name = "ColGrupo"})
        dgvUsuarios.Columns.Add(New DataGridViewTextBoxColumn With {.DataPropertyName = "Email", .HeaderText = "E-mail", .Name = "ColEmail"})

        ' Estilização Premium do Grid
        dgvUsuarios.BackgroundColor = Color.White
        dgvUsuarios.BorderStyle = BorderStyle.None
        dgvUsuarios.GridColor = Color.FromArgb(230, 233, 240)
        dgvUsuarios.EnableHeadersVisualStyles = False
        dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 64, 115)
        dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250)
        dgvUsuarios.RowTemplate.Height = 28

        CarregarUsuarios()
        LimparFormulario()
    End Sub

    Private Sub CarregarUsuarios()
        _listaOriginal = _db.ListarUsuarios()

        ' Mapear para exibição amigável no Grid
        Dim viewList = (From u In _listaOriginal
                        Select New With {
                            .Id = u.Id,
                            .Usuario = u.Usuario,
                            .Grupo = u.Grupo,
                            .GrupoExibicao = ObterNomeExibicaoGrupo(u.Grupo),
                            .Email = u.Email
                        }).ToList()

        dgvUsuarios.DataSource = viewList
    End Sub

    Private Function ObterNomeExibicaoGrupo(grupo As GrupoUsuario) As String
        Select Case grupo
            Case GrupoUsuario.Administracao
                Return "Administração"
            Case GrupoUsuario.Manutencao
                Return "Manutenção"
            Case Else
                Return "Operação"
        End Select
    End Function

    Private Function ObterEnumGrupo(exibicao As String) As GrupoUsuario
        Select Case exibicao
            Case "Administração"
                Return GrupoUsuario.Administracao
            Case "Manutenção"
                Return GrupoUsuario.Manutencao
            Case Else
                Return GrupoUsuario.Operacao
        End Select
    End Function

    Private Sub dgvUsuarios_SelectionChanged(sender As Object, e As EventArgs) Handles dgvUsuarios.SelectionChanged
        If dgvUsuarios.SelectedRows.Count > 0 Then
            Dim idSel As Integer = Convert.ToInt32(dgvUsuarios.SelectedRows(0).Cells(0).OwningRow.DataBoundItem.Id)
            _selectedUser = _listaOriginal.FirstOrDefault(Function(u) u.Id = idSel)

            If _selectedUser IsNot Nothing Then
                txtUsuario.Text = _selectedUser.Usuario
                txtUsuario.ReadOnly = True
                txtSenha.Text = ""
                txtConfirmarSenha.Text = ""
                txtEmail.Text = _selectedUser.Email
                cbGrupo.SelectedItem = ObterNomeExibicaoGrupo(_selectedUser.Grupo)
                
                lblAvisoSenha.Visible = True
                btnExcluir.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Dim username As String = txtUsuario.Text.Trim()
        Dim senha As String = txtSenha.Text
        Dim confirmar As String = txtConfirmarSenha.Text
        Dim email As String = txtEmail.Text.Trim()
        Dim grupo As GrupoUsuario = ObterEnumGrupo(cbGrupo.SelectedItem.ToString())

        ' Validações básicas comuns
        If String.IsNullOrWhiteSpace(username) Then
            MessageBox.Show("O nome de usuário não pode estar em branco.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsuario.Focus()
            Return
        End If

        ' Validação de E-mail (Opcional, mas se preenchido deve ser válido)
        If Not String.IsNullOrWhiteSpace(email) Then
            Dim emailRegex As New System.Text.RegularExpressions.Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
            If Not emailRegex.IsMatch(email) Then
                MessageBox.Show("Por favor, digite um e-mail válido (exemplo: usuario@dominio.com).", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtEmail.Focus()
                Return
            End If
        End If

        If _selectedUser Is Nothing Then
            ' --- CADASTRAR NOVO USUÁRIO ---
            
            ' Validar se já existe
            If _db.BuscarUsuario(username) IsNot Nothing Then
                MessageBox.Show("Este nome de usuário já está cadastrado no sistema.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUsuario.Focus()
                Return
            End If

            ' Validar senha
            If String.IsNullOrEmpty(senha) Then
                MessageBox.Show("Por favor, digite uma senha para o novo usuário.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSenha.Focus()
                Return
            End If

            If senha.Length < 4 Then
                MessageBox.Show("A senha deve conter no mínimo 4 caracteres.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSenha.Focus()
                Return
            End If

            If senha <> confirmar Then
                MessageBox.Show("A confirmação de senha não coincide.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtConfirmarSenha.Focus()
                Return
            End If

            ' Cria novo usuário no banco
            Dim saltVal As String = DatabaseService.GerarSalt()
            Dim hashVal As String = DatabaseService.CalcularHash(senha, saltVal)

            Dim uNew As New UsuarioDto With {
                .Usuario = username,
                .SenhaHash = hashVal,
                .Salt = saltVal,
                .Grupo = grupo,
                .Email = email
            }
            _db.InserirUsuario(uNew)
            MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            ' --- EDITAR USUÁRIO EXISTENTE ---
            
            ' Validar senha se preenchida
            If Not String.IsNullOrEmpty(senha) Then
                If senha.Length < 4 Then
                    MessageBox.Show("A senha deve conter no mínimo 4 caracteres.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtSenha.Focus()
                    Return
                End If

                If senha <> confirmar Then
                    MessageBox.Show("A confirmação de senha não coincide.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtConfirmarSenha.Focus()
                    Return
                End If

                ' Gera novo salt e hash
                Dim saltVal As String = DatabaseService.GerarSalt()
                Dim hashVal As String = DatabaseService.CalcularHash(senha, saltVal)

                _selectedUser.SenhaHash = hashVal
                _selectedUser.Salt = saltVal
                _selectedUser.Grupo = grupo
                _selectedUser.Email = email
                _db.AtualizarUsuarioCompleto(_selectedUser)
            Else
                ' Sem alteração de senha
                _selectedUser.Grupo = grupo
                _selectedUser.Email = email
                _db.AtualizarUsuarioDados(_selectedUser)
            End If

            MessageBox.Show("Usuário atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        CarregarUsuarios()
        LimparFormulario()
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If _selectedUser Is Nothing Then Return

        ' Impedir de excluir a si mesmo
        If _selectedUser.Usuario.ToLower() = UsuarioLogado.ToLower() Then
            MessageBox.Show("Você não pode excluir o seu próprio usuário logado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Impedir de excluir o último administrador
        If _selectedUser.Grupo = GrupoUsuario.Administracao AndAlso _db.ContarAdministradores() <= 1 Then
            MessageBox.Show("Você não pode excluir o último usuário Administrador do sistema.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirmResult = MessageBox.Show($"Deseja realmente excluir o usuário '{_selectedUser.Usuario}'?",
                                             "Confirmar Exclusão",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question)
        If confirmResult = DialogResult.Yes Then
            _db.ExcluirUsuario(_selectedUser.Id)
            MessageBox.Show("Usuário excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CarregarUsuarios()
            LimparFormulario()
        End If
    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        LimparFormulario()
    End Sub

    Private Sub LimparFormulario()
        _selectedUser = Nothing
        txtUsuario.Text = ""
        txtUsuario.ReadOnly = False
        txtSenha.Text = ""
        txtConfirmarSenha.Text = ""
        txtEmail.Text = ""
        cbGrupo.SelectedIndex = 0
        
        lblAvisoSenha.Visible = False
        btnExcluir.Enabled = False
        dgvUsuarios.ClearSelection()
    End Sub
End Class
