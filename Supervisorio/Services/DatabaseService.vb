Imports System.IO
Imports Microsoft.Data.Sqlite

Public Class DatabaseService

    Private ReadOnly _caminhoDb As String

    Public Sub New(caminhoDb As String)
        _caminhoDb = caminhoDb
    End Sub

    ' Cria o diretorio, o arquivo .db e a tabela se ainda nao existirem.
    ' Deve ser chamado uma unica vez em MainForm_Shown.
    Public Sub InicializarBanco()
        Directory.CreateDirectory(Path.GetDirectoryName(_caminhoDb))
        Using conn = CriarConexao()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText =
                    "CREATE TABLE IF NOT EXISTS leituras (
                         id          INTEGER PRIMARY KEY AUTOINCREMENT,
                         data_hora   TEXT    NOT NULL,
                         sensor_id   INTEGER NOT NULL,
                         nome        TEXT    NOT NULL,
                         temperatura REAL    NOT NULL,
                         clp_ok      INTEGER NOT NULL DEFAULT 1
                     );
                     CREATE INDEX IF NOT EXISTS idx_data
                         ON leituras(data_hora);
                     CREATE INDEX IF NOT EXISTS idx_sensor
                         ON leituras(sensor_id, data_hora);"
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' Insere uma lista de leituras em uma unica transacao.
    ' Chamado pelo AquisicaoService a cada ciclo de coleta.
    Public Sub InserirLote(leituras As List(Of LeituraDto))
        If leituras Is Nothing OrElse leituras.Count = 0 Then Return

        Using conn = CriarConexao()
            conn.Open()
            Using trans = conn.BeginTransaction()
                Using cmd = conn.CreateCommand()
                    cmd.CommandText =
                        "INSERT INTO leituras (data_hora, sensor_id, nome, temperatura, clp_ok)
                         VALUES (@dt, @sid, @nome, @temp, @ok)"

                    Dim pDt   = cmd.Parameters.Add("@dt",   SqliteType.Text)
                    Dim pSid  = cmd.Parameters.Add("@sid",  SqliteType.Integer)
                    Dim pNome = cmd.Parameters.Add("@nome", SqliteType.Text)
                    Dim pTemp = cmd.Parameters.Add("@temp", SqliteType.Real)
                    Dim pOk   = cmd.Parameters.Add("@ok",   SqliteType.Integer)

                    For Each l In leituras
                        pDt.Value   = l.DataHora.ToString("yyyy-MM-dd HH:mm:ss")
                        pSid.Value  = l.SensorId
                        pNome.Value = l.Nome
                        pTemp.Value = l.Temperatura
                        pOk.Value   = If(l.ClpOk, 1, 0)
                        cmd.ExecuteNonQuery()
                    Next
                End Using
                trans.Commit()
            End Using
        End Using
    End Sub

    ' Remove registros com data_hora anterior ao limite de retencao.
    ' Retorna o numero de linhas deletadas.
    Public Function LimparRegistrosAntigos(meses As Integer) As Integer
        If meses <= 0 Then Return 0
        Dim limite = DateTime.Now.AddMonths(-meses).ToString("yyyy-MM-dd HH:mm:ss")
        Using conn = CriarConexao()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "DELETE FROM leituras WHERE data_hora < @limite"
                cmd.Parameters.AddWithValue("@limite", limite)
                Return cmd.ExecuteNonQuery()
            End Using
        End Using
    End Function

    ' Consulta leituras de um unico sensor em um periodo.
    ' Retorna DataTable com colunas data_hora e temperatura.
    ' Usado pelo FrmRelatorios para popular o grid.
    Public Function ConsultarSensor(sensorId As Integer,
                                     inicio   As DateTime,
                                     fim      As DateTime) As DataTable
        Dim tabela As New DataTable()
        Using conn = CriarConexao()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText =
                    "SELECT data_hora, temperatura
                     FROM   leituras
                     WHERE  sensor_id = @sid
                       AND  data_hora BETWEEN @ini AND @fim
                     ORDER  BY data_hora ASC"
                cmd.Parameters.AddWithValue("@sid", sensorId)
                cmd.Parameters.AddWithValue("@ini", inicio.ToString("yyyy-MM-dd HH:mm:ss"))
                cmd.Parameters.AddWithValue("@fim", fim.ToString("yyyy-MM-dd HH:mm:ss"))
                Using reader = cmd.ExecuteReader()
                    tabela.Load(reader)
                End Using
            End Using
        End Using
        Return tabela
    End Function

    Private Function CriarConexao() As SqliteConnection
        Return New SqliteConnection($"Data Source={_caminhoDb}")
    End Function

End Class
