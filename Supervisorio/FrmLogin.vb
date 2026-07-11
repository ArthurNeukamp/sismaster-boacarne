Imports System.Windows.Forms

Public Class FrmLogin
    Private ReadOnly _db As DatabaseService

    Public Sub New(db As DatabaseService)
        InitializeComponent()
        _db = db
    End Sub

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsuario.Select()
    End Sub

    Private Sub btnEntrar_Click(sender As Object, e As EventArgs) Handles btnEntrar.Click
        lblError.Text = ""
        Dim username As String = txtUsuario.Text.Trim()
        Dim password As String = txtSenha.Text

        If String.IsNullOrWhiteSpace(username) Then
            lblError.Text = "Digite o nome de usuário!"
            txtUsuario.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(password) Then
            lblError.Text = "Digite a senha!"
            txtSenha.Focus()
            Return
        End If

        Try
            Dim user = _db.BuscarUsuario(username)
            If user IsNot Nothing Then
                Dim computedHash = DatabaseService.CalcularHash(password, user.Salt)
                If computedHash = user.SenhaHash Then
                    ' Define as credenciais na sessão global
                    UsuarioLogado = user.Usuario
                    GrupoLogado = user.Grupo
                    EmailLogado = If(user.Email, "")

                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                    Return
                End If
            End If
        Catch ex As Exception
            lblError.Text = "Erro: " & ex.Message
            Return
        End Try

        lblError.Text = "Usuário ou senha incorretos!"
        txtSenha.Clear()
        txtSenha.Focus()
    End Sub

    Private Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
