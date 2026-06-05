Imports System.IO

Public Class LogService

    Private Shared ReadOnly _lock As New Object()
    Private Shared ReadOnly _diretorioLogs As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs")

    Public Shared Sub GravarInfo(categoria As String, mensagem As String)
        GravarLog("INFO", categoria, mensagem)
    End Sub

    Public Shared Sub GravarAviso(categoria As String, mensagem As String)
        GravarLog("WARN", categoria, mensagem)
    End Sub

    Public Shared Sub GravarErro(categoria As String, mensagem As String)
        GravarLog("ERROR", categoria, mensagem)
    End Sub

    Private Shared Sub GravarLog(nivel As String, categoria As String, mensagem As String)
        Try
            SyncLock _lock
                If Not Directory.Exists(_diretorioLogs) Then
                    Directory.CreateDirectory(_diretorioLogs)
                End If

                Dim nomeArquivo = Path.Combine(_diretorioLogs, DateTime.Today.ToString("yyyy-MM-dd") & ".log")
                Dim linha = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [{nivel}] [{categoria}] {mensagem}"

                Using writer As New StreamWriter(nomeArquivo, True)
                    writer.WriteLine(linha)
                End Using
            End SyncLock
        Catch
            ' Silencia falhas ao gravar log para evitar crashar o sistema por causa do logger.
        End Try
    End Sub

    Public Shared Sub LimparLogsAntigos(diasLimite As Integer)
        Try
            If Not Directory.Exists(_diretorioLogs) Then Return

            Dim dataLimite = DateTime.Today.AddDays(-diasLimite)
            Dim arquivos = Directory.GetFiles(_diretorioLogs, "*.log")

            For Each arq In arquivos
                Dim nomeSemExtensao = Path.GetFileNameWithoutExtension(arq)
                Dim dataLog As DateTime
                If DateTime.TryParseExact(nomeSemExtensao, "yyyy-MM-dd", Nothing, System.Globalization.DateTimeStyles.None, dataLog) Then
                    If dataLog < dataLimite Then
                        File.Delete(arq)
                        GravarInfo("SISTEMA", $"Arquivo de log antigo deletado automaticamente: {Path.GetFileName(arq)}")
                    End If
                End If
            Next
        Catch ex As Exception
            GravarErro("SISTEMA", $"Falha ao limpar logs antigos: {ex.Message}")
        End Try
    End Sub

End Class
