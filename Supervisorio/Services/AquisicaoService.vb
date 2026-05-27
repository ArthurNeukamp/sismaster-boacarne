Public Class AquisicaoService

    Private ReadOnly _db     As DatabaseService
    Private ReadOnly _config As ConfiguracaoApp
    Private ReadOnly _form   As MainForm
    Private _timer           As System.Timers.Timer
    Private _ultimaLimpeza   As Date = Date.MinValue

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

    ' Inicia o timer com sincronismo de horário cravado e atraso de segurança inicial.
    Public Sub Iniciar()
        Dim agora = DateTime.Now
        Dim msAteProximo = ObterMilisegundosAteProximoIntervalo(agora, _config.IntervaloColetaMinutos)
        
        ' Se o próximo intervalo estiver a menos de 30 segundos do início do software,
        ' pula para o próximo intervalo subsequente para garantir que os CLPs conectem primeiro.
        If msAteProximo < 30000 Then
            msAteProximo += (_config.IntervaloColetaMinutos * 60 * 1000)
        End If
        
        _timer = New System.Timers.Timer(msAteProximo)
        AddHandler _timer.Elapsed, AddressOf OnTick
        _timer.AutoReset = True
        _timer.Start()
    End Sub

    ' Método obsoleto mantido apenas por compatibilidade com a chamada existente do MainForm.
    Public Sub NotificarCLPConectado()
        ' Não faz nada, pois a coleta agora é contínua desde a inicialização.
    End Sub

    Private Sub OnTick(sender As Object, e As System.Timers.ElapsedEventArgs)
        ' Captura o horário exato IMEDIATAMENTE na thread de background do Timer,
        ' ficando totalmente imune a qualquer congelamento ou lentidão da UI Thread.
        Dim agoraRaw = DateTime.Now
        
        Try
            Dim clpAtivo As Boolean = _form.myProtocol?.isOpen() OrElse
                                      _form.CLP_2?.isOpen() OrElse
                                      _form.M251?.isOpen()

            Dim dataColeta = ObterDataHoraAlinhada(agoraRaw, _config.IntervaloColetaMinutos)

            ' Coleta na UI thread para evitar conflito concorrente de leitura de variáveis.
            Dim snapshot As List(Of LeituraDto) = Nothing
            _form.Invoke(Sub() snapshot = ColetarSnapshot(clpAtivo, dataColeta))

            If snapshot IsNot Nothing Then
                _db.InserirLote(snapshot)
            End If

            ' Limpeza de registros antigos uma vez por dia.
            If _ultimaLimpeza.Date < DateTime.Today Then
                _db.LimparRegistrosAntigos(_config.RetencaoMeses)
                _ultimaLimpeza = DateTime.Today
            End If

        Catch
            ' Falhas silenciosas
        Finally
            ' Recalcula o próximo intervalo cravado e auto-corrige o Timer para o próximo ciclo
            Try
                Dim proxIntervaloMs = ObterMilisegundosAteProximoIntervalo(DateTime.Now, _config.IntervaloColetaMinutos)
                _timer.Interval = proxIntervaloMs
            Catch
            End Try
        End Try
    End Sub

    Private Function ColetarSnapshot(clpAtivo As Boolean, dataColeta As DateTime) As List(Of LeituraDto)
        Dim leituras = New List(Of LeituraDto)(_sensorIds.Length)

        For Each sid In _sensorIds
            Dim nomeConfigurado As String = $"Sensor {sid}"
            _config.Sensores.TryGetValue(sid, nomeConfigurado)

            leituras.Add(New LeituraDto With {
                .DataHora    = dataColeta,
                .SensorId    = sid,
                .Nome        = nomeConfigurado,
                .Temperatura = _form.Ambientes(sid).varTemperatura / 10.0,
                .ClpOk       = clpAtivo
            })
        Next
        Return leituras
    End Function

    ' Calcula matematicamente os milissegundos restantes até a próxima borda cheia do relógio.
    Private Function ObterMilisegundosAteProximoIntervalo(agora As DateTime, intervaloMinutos As Integer) As Double
        If intervaloMinutos <= 0 Then intervaloMinutos = 1
        Dim minutosAtuais = agora.Minute
        Dim minutosProximo = ((minutosAtuais \ intervaloMinutos) + 1) * intervaloMinutos
        Dim proximaData = agora.Date.AddHours(agora.Hour).AddMinutes(minutosProximo)
        Dim diff = proximaData - agora
        Return diff.TotalMilliseconds
    End Function

    ' Arredonda o DateTime para o limite do relógio mais próximo com segundos fixados em :00.
    Private Function ObterDataHoraAlinhada(agora As DateTime, intervaloMinutos As Integer) As DateTime
        If intervaloMinutos <= 0 Then intervaloMinutos = 1
        Dim minutosTotais = agora.Hour * 60 + agora.Minute
        Dim segundosTotais = agora.Second
        Dim fracaoMinuto = minutosTotais + (segundosTotais / 60.0)
        Dim intervaloArredondado = Math.Round(fracaoMinuto / intervaloMinutos) * intervaloMinutos
        Return agora.Date.AddMinutes(CInt(intervaloArredondado))
    End Function

End Class
