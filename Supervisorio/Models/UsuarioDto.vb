Public Enum GrupoUsuario
    Operacao = 1
    Manutencao = 2
    Administracao = 3
End Enum

Public Class UsuarioDto
    Public Property Id As Integer
    Public Property Usuario As String
    Public Property SenhaHash As String
    Public Property Salt As String
    Public Property Grupo As GrupoUsuario
    Public Property Email As String
End Class
