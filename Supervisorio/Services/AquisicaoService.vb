Public Class AquisicaoService

    Private ReadOnly _db     As DatabaseService
    Private ReadOnly _config As ConfiguracaoApp
    Private ReadOnly _form   As MainForm
    Private _timer           As System.Timers.Timer

    ' Fica True apos o primeiro sucesso de leitura de qualquer CLP.
    ' Nao volta a False — coleta continua mesmo com queda posterior.
    Private _clpConectou As Boolean = False

    ' Controla a limpeza diaria de registros antigos.
    ' Inicializado com MinValue para garantir execucao na primeira coleta do dia.
    Private _ultimaLimpeza As Date = Date.MinValue

    ' Indices fixos dos 38 sensores monitorados, conforme Form1.vb.
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

    ' Inicia o timer de coleta em background thread.
    ' Chamado em MainForm_Shown apos InicializarBanco().
    Public Sub Iniciar()
        _timer = New System.Timers.Timer(_config.IntervaloColetaMinutos * 60 * 1000)
        AddHandler _timer.Elapsed, AddressOf OnTick
        _timer.AutoReset = True
        _timer.Start()
    End Sub

    ' Chamado pelos timers de CLP em Form1.vb apos leitura bem-sucedida.
    ' Habilita a coleta a partir do primeiro CLP que comunicar.
    Public Sub NotificarCLPConectado()
        _clpConectou = True
    End Sub

    ' Executado na background thread a cada intervalo configurado.
    Private Sub OnTick(sender As Object, e As System.Timers.ElapsedEventArgs)
        If Not _clpConectou Then Return

        Try
            Dim clpAtivo As Boolean = _form.myProtocol?.isOpen() OrElse
                                      _form.CLP_2?.isOpen() OrElse
                                      _form.M251?.isOpen()

            If Not clpAtivo AndAlso Not _config.ColetarSemConexao Then Return

            ' Captura os valores na UI thread para evitar leitura concorrente.
            Dim snapshot As List(Of LeituraDto) = Nothing
            _form.Invoke(Sub() snapshot = ColetarSnapshot(clpAtivo))

            If snapshot IsNot Nothing Then
                _db.InserirLote(snapshot)
            End If

            ' Limpeza de registros antigos uma vez por dia.
            If _ultimaLimpeza.Date < DateTime.Today Then
                _db.LimparRegistrosAntigos(_config.RetencaoMeses)
                _ultimaLimpeza = DateTime.Today
            End If

        Catch
            ' Falhas silenciosas para nao interferir no funcionamento do supervisorio.
        End Try
    End Sub

    ' Executado na UI thread (dentro do Invoke).
    ' Le varTemperatura de cada ambiente e monta a lista de leituras.
    Private Function ColetarSnapshot(clpAtivo As Boolean) As List(Of LeituraDto)
        Dim agora    = DateTime.Now
        Dim leituras = New List(Of LeituraDto)(_sensorIds.Length)

        For Each sid In _sensorIds
            Dim nomeConfigurado As String = $"Sensor {sid}"
            _config.Sensores.TryGetValue(sid, nomeConfigurado)

            leituras.Add(New LeituraDto With {
                .DataHora    = agora,
                .SensorId    = sid,
                .Nome        = nomeConfigurado,
                .Temperatura = _form.Ambientes(sid).varTemperatura / 10.0,
                .ClpOk       = clpAtivo
            })
        Next
        Return leituras
    End Function

End Class
