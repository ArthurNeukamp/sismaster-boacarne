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
                ' 1. Cria a tabela de leituras
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

                ' 2. Cria a tabela de usuários
                cmd.CommandText =
                    "CREATE TABLE IF NOT EXISTS usuarios (
                         id          INTEGER PRIMARY KEY AUTOINCREMENT,
                         usuario     TEXT    UNIQUE NOT NULL,
                         senha_hash  TEXT    NOT NULL,
                         salt        TEXT    NOT NULL,
                         grupo       TEXT    NOT NULL,
                         email       TEXT
                     );"
                cmd.ExecuteNonQuery()

                ' 2.1. Cria a tabela de limites dos sensores
                cmd.CommandText =
                    "CREATE TABLE IF NOT EXISTS limites_sensores (
                         sensor_id   INTEGER PRIMARY KEY,
                         habilitado  INTEGER NOT NULL DEFAULT 0,
                         temp_min    REAL NOT NULL DEFAULT 0.0,
                         temp_max    REAL NOT NULL DEFAULT 0.0
                     );"
                cmd.ExecuteNonQuery()

                ' 3. Cria o usuário administrador padrão 'adm' com senha '1111' se a tabela estiver vazia
                cmd.CommandText = "SELECT COUNT(*) FROM usuarios"
                Dim count = Convert.ToInt32(cmd.ExecuteScalar())
                If count = 0 Then
                    Dim saltVal As String = GerarSalt()
                    Dim hashVal As String = CalcularHash("1111", saltVal)
                    cmd.CommandText = "INSERT INTO usuarios (usuario, senha_hash, salt, grupo, email) " &
                                      "VALUES ('adm', @hash, @salt, 'Administracao', 'admin@sismaster.com')"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@hash", hashVal)
                    cmd.Parameters.AddWithValue("@salt", saltVal)
                    cmd.ExecuteNonQuery()
                End If
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

    ' Insere ou atualiza (Upsert) uma lista de leituras em lote.
    ' Se o registro (sensor_id + data_hora) ja existir, atualiza a temperatura/nome/clp_ok.
    ' Caso contrario, insere um novo registro.
    Public Sub UpsertLeituras(leituras As List(Of LeituraDto))
        If leituras Is Nothing OrElse leituras.Count = 0 Then Return

        Using conn = CriarConexao()
            conn.Open()
            Using trans = conn.BeginTransaction()
                Using cmdUpdate = conn.CreateCommand()
                    cmdUpdate.CommandText =
                        "UPDATE leituras SET temperatura = @temp, clp_ok = @ok, nome = @nome
                         WHERE sensor_id = @sid AND data_hora = @dt"
                    
                    Dim pTempU = cmdUpdate.Parameters.Add("@temp", SqliteType.Real)
                    Dim pOkU   = cmdUpdate.Parameters.Add("@ok",   SqliteType.Integer)
                    Dim pNomeU = cmdUpdate.Parameters.Add("@nome", SqliteType.Text)
                    Dim pSidU  = cmdUpdate.Parameters.Add("@sid",  SqliteType.Integer)
                    Dim pDtU   = cmdUpdate.Parameters.Add("@dt",   SqliteType.Text)

                    Using cmdInsert = conn.CreateCommand()
                        cmdInsert.CommandText =
                            "INSERT INTO leituras (data_hora, sensor_id, nome, temperatura, clp_ok)
                             VALUES (@dt, @sid, @nome, @temp, @ok)"
                        
                        Dim pDtI   = cmdInsert.Parameters.Add("@dt",   SqliteType.Text)
                        Dim pSidI  = cmdInsert.Parameters.Add("@sid",  SqliteType.Integer)
                        Dim pNomeI = cmdInsert.Parameters.Add("@nome", SqliteType.Text)
                        Dim pTempI = cmdInsert.Parameters.Add("@temp", SqliteType.Real)
                        Dim pOkI   = cmdInsert.Parameters.Add("@ok",   SqliteType.Integer)

                        For Each l In leituras
                            Dim dtStr As String = l.DataHora.ToString("yyyy-MM-dd HH:mm:ss")
                            
                            ' Tenta o UPDATE primeiro
                            pTempU.Value = l.Temperatura
                            pOkU.Value   = If(l.ClpOk, 1, 0)
                            pNomeU.Value = l.Nome
                            pSidU.Value  = l.SensorId
                            pDtU.Value   = dtStr
                            
                            Dim rowsAffected = cmdUpdate.ExecuteNonQuery()
                            If rowsAffected = 0 Then
                                ' Nao encontrou registro, faz o INSERT
                                pDtI.Value   = dtStr
                                pSidI.Value  = l.SensorId
                                pNomeI.Value = l.Nome
                                pTempI.Value = l.Temperatura
                                pOkI.Value   = If(l.ClpOk, 1, 0)
                                cmdInsert.ExecuteNonQuery()
                            End If
                        Next
                    End Using
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

    ' Remove registros de um sensor especifico em um determinado intervalo.
    ' Usado para limpar dados FAKE anteriores antes de gravar a nova simulacao.
    Public Sub LimparPeriodoSensor(sensorId As Integer, inicio As DateTime, fim As DateTime)
        Using conn = CriarConexao()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "DELETE FROM leituras WHERE sensor_id = @sid AND data_hora BETWEEN @ini AND @fim"
                cmd.Parameters.AddWithValue("@sid", sensorId)
                cmd.Parameters.AddWithValue("@ini", inicio.ToString("yyyy-MM-dd HH:mm:ss"))
                cmd.Parameters.AddWithValue("@fim", fim.ToString("yyyy-MM-dd HH:mm:ss"))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

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

    ' Verifica se ja existe leitura gravada para o sensorId e dataHora especificados.
    Public Function ExisteLeitura(sensorId As Integer, dataHora As DateTime) As Boolean
        Using conn = CriarConexao()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "SELECT COUNT(1) FROM leituras WHERE sensor_id = @sid AND data_hora = @dt"
                cmd.Parameters.AddWithValue("@sid", sensorId)
                cmd.Parameters.AddWithValue("@dt", dataHora.ToString("yyyy-MM-dd HH:mm:ss"))
                Dim count = Convert.ToInt32(cmd.ExecuteScalar())
                Return count > 0
            End Using
        End Using
    End Function

    ' --- MÉTODOS DE SEGURANÇA E AUXILIARES ---
    Public Shared Function GerarSalt() As String
        Dim bytes(15) As Byte
        Using rng = System.Security.Cryptography.RandomNumberGenerator.Create()
            rng.GetBytes(bytes)
        End Using
        Return Convert.ToHexString(bytes)
    End Function

    Public Shared Function CalcularHash(senha As String, salt As String) As String
        Dim bytesSenha = System.Text.Encoding.UTF8.GetBytes(senha & salt)
        Using sha = System.Security.Cryptography.SHA256.Create()
            Dim hashBytes = sha.ComputeHash(bytesSenha)
            Return Convert.ToHexString(hashBytes)
        End Using
    End Function

    ' --- OPERAÇÕES DE BANCO PARA USUÁRIOS ---
    Public Function BuscarUsuario(usuario As String) As UsuarioDto
        Using conn = CriarConexao()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "SELECT id, usuario, senha_hash, salt, grupo, email FROM usuarios WHERE usuario = @user"
                cmd.Parameters.AddWithValue("@user", usuario)
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim u As New UsuarioDto With {
                            .Id = reader.GetInt32(0),
                            .Usuario = reader.GetString(1),
                            .SenhaHash = reader.GetString(2),
                            .Salt = reader.GetString(3),
                            .Email = If(reader.IsDBNull(5), "", reader.GetString(5))
                        }
                        Dim grupoStr = reader.GetString(4)
                        Dim grupoEnum As GrupoUsuario
                        If [Enum].TryParse(Of GrupoUsuario)(grupoStr, True, grupoEnum) Then
                            u.Grupo = grupoEnum
                        Else
                            u.Grupo = GrupoUsuario.Operacao
                        End If
                        Return u
                    End If
                End Using
            End Using
        End Using
        Return Nothing
    End Function

    Public Function ListarUsuarios() As List(Of UsuarioDto)
        Dim lista As New List(Of UsuarioDto)()
        Using conn = CriarConexao()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "SELECT id, usuario, senha_hash, salt, grupo, email FROM usuarios ORDER BY usuario"
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim u As New UsuarioDto With {
                            .Id = reader.GetInt32(0),
                            .Usuario = reader.GetString(1),
                            .SenhaHash = reader.GetString(2),
                            .Salt = reader.GetString(3),
                            .Email = If(reader.IsDBNull(5), "", reader.GetString(5))
                        }
                        Dim grupoStr = reader.GetString(4)
                        Dim grupoEnum As GrupoUsuario
                        If [Enum].TryParse(Of GrupoUsuario)(grupoStr, True, grupoEnum) Then
                            u.Grupo = grupoEnum
                        Else
                            u.Grupo = GrupoUsuario.Operacao
                        End If
                        lista.Add(u)
                    End While
                End Using
            End Using
        End Using
        Return lista
    End Function

    Public Sub InserirUsuario(user As UsuarioDto)
        Using conn = CriarConexao()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "INSERT INTO usuarios (usuario, senha_hash, salt, grupo, email) VALUES (@user, @hash, @salt, @grupo, @email)"
                cmd.Parameters.AddWithValue("@user", user.Usuario)
                cmd.Parameters.AddWithValue("@hash", user.SenhaHash)
                cmd.Parameters.AddWithValue("@salt", user.Salt)
                cmd.Parameters.AddWithValue("@grupo", user.Grupo.ToString())
                cmd.Parameters.AddWithValue("@email", If(String.IsNullOrEmpty(user.Email), DBNull.Value, user.Email))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub AtualizarUsuarioDados(user As UsuarioDto)
        Using conn = CriarConexao()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "UPDATE usuarios SET grupo = @grupo, email = @email WHERE id = @id"
                cmd.Parameters.AddWithValue("@grupo", user.Grupo.ToString())
                cmd.Parameters.AddWithValue("@email", If(String.IsNullOrEmpty(user.Email), DBNull.Value, user.Email))
                cmd.Parameters.AddWithValue("@id", user.Id)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub AtualizarUsuarioCompleto(user As UsuarioDto)
        Using conn = CriarConexao()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "UPDATE usuarios SET senha_hash = @hash, salt = @salt, grupo = @grupo, email = @email WHERE id = @id"
                cmd.Parameters.AddWithValue("@hash", user.SenhaHash)
                cmd.Parameters.AddWithValue("@salt", user.Salt)
                cmd.Parameters.AddWithValue("@grupo", user.Grupo.ToString())
                cmd.Parameters.AddWithValue("@email", If(String.IsNullOrEmpty(user.Email), DBNull.Value, user.Email))
                cmd.Parameters.AddWithValue("@id", user.Id)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub ExcluirUsuario(id As Integer)
        Using conn = CriarConexao()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "DELETE FROM usuarios WHERE id = @id"
                cmd.Parameters.AddWithValue("@id", id)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function ContarAdministradores() As Integer
        Using conn = CriarConexao()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "SELECT COUNT(*) FROM usuarios WHERE grupo = 'Administracao'"
                Return Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        End Using
    End Function

    Public Function ObterLimitesSensores() As List(Of LimiteSensorDto)
        Dim lista As New List(Of LimiteSensorDto)()
        Using conn = CriarConexao()
            conn.Open()
            Using cmd = conn.CreateCommand()
                cmd.CommandText = "SELECT sensor_id, habilitado, temp_min, temp_max FROM limites_sensores"
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        lista.Add(New LimiteSensorDto With {
                            .SensorId = reader.GetInt32(0),
                            .Habilitado = reader.GetInt32(1) = 1,
                            .TempMin = reader.GetDouble(2),
                            .TempMax = reader.GetDouble(3)
                        })
                    End While
                End Using
            End Using
        End Using
        Return lista
    End Function

    Public Sub SalvarLimitesSensores(limites As List(Of LimiteSensorDto))
        If limites Is Nothing OrElse limites.Count = 0 Then Return
        Using conn = CriarConexao()
            conn.Open()
            Using trans = conn.BeginTransaction()
                Using cmd = conn.CreateCommand()
                    cmd.CommandText = "INSERT INTO limites_sensores (sensor_id, habilitado, temp_min, temp_max)
                                       VALUES (@sid, @hab, @min, @max)
                                       ON CONFLICT(sensor_id) DO UPDATE SET
                                       habilitado = @hab, temp_min = @min, temp_max = @max"
                    Dim pSid = cmd.Parameters.Add("@sid", SqliteType.Integer)
                    Dim pHab = cmd.Parameters.Add("@hab", SqliteType.Integer)
                    Dim pMin = cmd.Parameters.Add("@min", SqliteType.Real)
                    Dim pMax = cmd.Parameters.Add("@max", SqliteType.Real)

                    For Each lim In limites
                        pSid.Value = lim.SensorId
                        pHab.Value = If(lim.Habilitado, 1, 0)
                        pMin.Value = lim.TempMin
                        pMax.Value = lim.TempMax
                        cmd.ExecuteNonQuery()
                    Next
                End Using
                trans.Commit()
            End Using
        End Using
    End Sub

    Private Function CriarConexao() As SqliteConnection
        Return New SqliteConnection($"Data Source={_caminhoDb}")
    End Function

End Class
