Public Class AquisicaoService

    Private ReadOnly _db     As DatabaseService
    Private ReadOnly _config As ConfiguracaoApp
    Private ReadOnly _form   As MainForm
    Private _timer           As System.Timers.Timer
    
    ' Controla a limpeza diária de registros antigos.
    Private _ultimaLimpeza   As Date = Date.MinValue
    
    ' Controla a prevenção absoluta de registros duplicados por minuto redondo.
    Private _ultimaDataColetada As DateTime = DateTime.MinValue

    ' Índices fixos dos 38 sensores monitorados, conforme Form1.vb.
    Private Shared ReadOnly _sensorIds As Integer() = {
        1, 2, 3, 4, 5, 6, 7, 8,
        11, 12, 13, 14, 15, 16,
        21, 22, 23, 24, 25, 26, 27, 28,
        29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44
    }

    Public Sub New(db As DatabaseService, config As ConfiguracaoApp, form As MainForm)
        _db = db
        _config = config
        _form = form
    End Sub

    ' Inicia o temporizador agendando o primeiro disparo cravado no próximo minuto compatível com o intervalo.
    ' Garante que o atraso mínimo inicial de segurança (30 segundos) seja respeitado para conexão dos CLPs.
    Public Sub Iniciar()
        Dim agora = DateTime.Now
        Dim proximoHorario = ObterProximoHorarioCompativel(agora, _config.IntervaloColetaMinutos, 30)
        
        Dim diffMs = CDbl((proximoHorario - agora).TotalMilliseconds)
        
        ' Configura o timer para o primeiro disparo de calibração
        _timer = New System.Timers.Timer(diffMs)
        AddHandler _timer.Elapsed, AddressOf OnPrimeiroTick
        _timer.AutoReset = False ' Dispara apenas uma vez para calibração
        _timer.Start()
    End Sub

    ' Disparado no primeiro minuto compatível. Configura o timer para rodar a cada 60 segundos exatos.
    Private Sub OnPrimeiroTick(sender As Object, e As System.Timers.ElapsedEventArgs)
        Try
            _timer.Stop()
            RemoveHandler _timer.Elapsed, AddressOf OnPrimeiroTick
            
            ' Executa a primeira amostragem (que ocorre exatamente na hora cheia)
            OnTick(Nothing, Nothing)
            
            ' Configura o temporizador para ticks fixos e contínuos de 1 minuto
            _timer.Interval = 60000
            AddHandler _timer.Elapsed, AddressOf OnTick
            _timer.AutoReset = True
            _timer.Start()
        Catch
        End Try
    End Sub

    ' Método obsoleto mantido por compatibilidade com a chamada do MainForm.
    Public Sub NotificarCLPConectado()
        ' Não faz nada, pois a coleta agora é contínua e auto-gerenciada.
    End Sub

    Private Sub OnTick(sender As Object, e As System.Timers.ElapsedEventArgs)
        ' Captura instantânea do horário redondo na thread de background para total imunidade a congelamentos de UI.
        Dim agoraRaw = DateTime.Now
        Dim minuto = agoraRaw.Minute

        ' 1. Verifica se o minuto atual é compatível com o intervalo configurado (módulo zero)
        If minuto Mod _config.IntervaloColetaMinutos = 0 Then
            
            ' 2. Alinha a data-hora cravada no minuto redondo correspondente, com segundos em :00
            Dim dataAlinhada = New DateTime(agoraRaw.Year, agoraRaw.Month, agoraRaw.Day, agoraRaw.Hour, minuto, 0)

            ' 3. Prevenção absoluta de duplicidades: grava apenas uma única vez para este minuto redondo
            If dataAlinhada <> _ultimaDataColetada Then
                _ultimaDataColetada = dataAlinhada

                Try
                    ' Coleta na UI thread para evitar leitura concorrente de variáveis de CLP.
                    Dim snapshot As List(Of LeituraDto) = Nothing
                    _form.Invoke(Sub() snapshot = ColetarSnapshot(dataAlinhada))

                    If snapshot IsNot Nothing Then
                        _db.InserirLote(snapshot)
                    End If

                    ' Limpeza de registros antigos uma vez por dia.
                    If _ultimaLimpeza.Date < DateTime.Today Then
                        _db.LimparRegistrosAntigos(_config.RetencaoMeses)
                        LogService.LimparLogsAntigos(60)
                        _ultimaLimpeza = DateTime.Today
                    End If

                Catch
                    ' Falhas silenciosas para resiliência operacional máxima.
                End Try
            End If
        End If
    End Sub

    ' Retorna a próxima data de minuto redondo que atenda ao intervalo e possua o atraso mínimo de segurança.
    Private Function ObterProximoHorarioCompativel(agora As DateTime, intervaloMinutos As Integer, atrasoMinimoSegundos As Integer) As DateTime
        If intervaloMinutos <= 0 Then intervaloMinutos = 1

        ' Começa a procurar a partir do minuto corrente com segundos e ms zerados
        Dim dataFoco = New DateTime(agora.Year, agora.Month, agora.Day, agora.Hour, agora.Minute, 0)

        Do
            dataFoco = dataFoco.AddMinutes(1)
            If dataFoco.Minute Mod intervaloMinutos = 0 Then
                Dim diffSegundos = (dataFoco - agora).TotalSeconds
                If diffSegundos >= atrasoMinimoSegundos Then
                    Return dataFoco
                End If
            End If
        Loop
    End Function

    Private Function ColetarSnapshot(dataColeta As DateTime) As List(Of LeituraDto)
        Dim leituras = New List(Of LeituraDto)(_sensorIds.Length)

        For Each sid In _sensorIds
            Dim nomeConfigurado As String = $"Sensor {sid}"
            _config.Sensores.TryGetValue(sid, nomeConfigurado)

            ' Mapeia o status real de comunicação específico do CLP responsável por cada sensor
            Dim sensorClpOk As Boolean = False
            If sid >= 1 AndAlso sid <= 8 Then
                sensorClpOk = (ConnectionState_Sadema = 1)
            ElseIf sid >= 11 AndAlso sid <= 16 Then
                sensorClpOk = (ConnectionState_CLP2 = 1)
            ElseIf sid >= 21 AndAlso sid <= 44 Then
                sensorClpOk = (ConnectionState_M251 = 1)
            End If

            leituras.Add(New LeituraDto With {
                .DataHora = dataColeta,
                .SensorId = sid,
                .Nome = nomeConfigurado,
                .Temperatura = _form.Ambientes(sid).varTemperatura / 10.0,
                .ClpOk = sensorClpOk
            })
        Next
        Return leituras
    End Function

End Class
