Imports FieldTalk.Modbus.Master

Module Module2
    ' Variáveis globais para controle de sessão de usuário logado
    Public UsuarioLogado As String = ""
    Public GrupoLogado As GrupoUsuario = GrupoUsuario.Operacao
    Public EmailLogado As String = ""

    ' Variáveis globais para rastrear o estado da última tentativa de conexão (0=Inicial, 1=Conectado, 2=Desconectado)
    ' Evita repetições e poluição nos arquivos diários de logs.
    Public ConnectionState_Sadema As Integer = 0
    Public ConnectionState_CLP2 As Integer = 0
    Public ConnectionState_M251 As Integer = 0
    Public ConnectionState_MBComp1 As Integer = 0
    Public ConnectionState_MBComp2 As Integer = 0
    Public ConnectionState_MBComp3 As Integer = 0

    'função para explorar bit a bit (retorna se determinado bit é true ou false.
    Function DesfragmentaBit(Valor As Int16, NumBit As Int16) As Boolean
        If (Valor >> NumBit And 1) <> 0 Then
            DesfragmentaBit = True
        Else
            DesfragmentaBit = False
        End If
    End Function

    'função para escrever o setpoint CLP=1 siemens sadema CLP=2 schneider tuneis 4a7
    Function EscreveSetpoint(CLP As Short, Address As Short, Valor As Short) As Boolean
        Dim res As Integer
        If CLP = 1 Then
            res = MainForm.myProtocol.writeSingleRegister(1, Address + 1, Valor)
        ElseIf CLP = 2 Then
            res = MainForm.CLP_2.writeSingleRegister(1, Address + 1, Valor)
        ElseIf CLP = 3 Then
            res = MainForm.M251.writeSingleRegister(1, Address + 1, Valor)
        End If
        EscreveSetpoint = True
    End Function

    Function EscreveVarControle(CLP As Short, Address As Short, Valor As Short) As Boolean
        Dim res As Integer
        If CLP = 1 Then
            res = MainForm.myProtocol.writeSingleRegister(1, Address + 1, Valor)
        ElseIf CLP = 2 Then
            res = MainForm.CLP_2.writeSingleRegister(1, Address + 1, Valor)
        ElseIf CLP = 3 Then
            res = MainForm.M251.writeSingleRegister(1, Address + 1, Valor)
        End If
        EscreveVarControle = True
    End Function

    'função para escrever o offset
    Function EscreveOffSet(CLP As Short, Address As Short, Valor As Short) As Boolean
        Dim res As Integer
        If CLP = 1 Then
            res = MainForm.myProtocol.writeSingleRegister(1, Address + 1, Valor)
        ElseIf CLP = 2 Then
            res = MainForm.CLP_2.writeSingleRegister(2, Address + 1, Valor)
        ElseIf CLP = 3 Then
            res = MainForm.M251.writeSingleRegister(2, Address + 1, Valor)
        End If
        EscreveOffSet = True
    End Function

    Function EscreveHorarioDegelo(CLP As Short, Address As Short, Hora As Short, Min As Short) As Boolean
        Dim res As Integer
        Dim auxValor1, auxValor2 As Short
        Dim auxCalculo As Long
        If CLP = 1 Then
            'Precisa separar em 2 words o tempo de variavel tipo TIME do clp siemens para escrever nas 2 words
            auxCalculo = Hora * 60 * 60 * 1000
            auxCalculo = auxCalculo + (Min * 60 * 1000)

            auxValor1 = auxCalculo \ 65536
            If auxCalculo Mod 65536 > 32768 Then
                auxValor2 = ((auxCalculo Mod 65536) - 32768) - 32768
            Else
                auxValor2 = auxCalculo Mod 65536
            End If
            res = MainForm.myProtocol.writeSingleRegister(1, Address + 1, auxValor1)
            res = MainForm.myProtocol.writeSingleRegister(1, Address + 2, auxValor2)
        ElseIf CLP = 2 Then
            auxValor1 = (Hora * 100) + Min
            res = MainForm.CLP_2.writeSingleRegister(1, Address + 1, auxValor1)
        ElseIf CLP = 3 Then
            auxValor1 = (Hora * 100) + Min
            res = MainForm.M251.writeSingleRegister(1, Address + 1, auxValor1)
        End If
        EscreveHorarioDegelo = True
    End Function

    Function EscreveTemposDegelo(CLP As Short, Address As Short, Valor As Short) As Boolean
        Dim res As Integer
        Dim auxValor1, auxValor2 As Short
        Dim auxCalculo As Long
        If CLP = 1 Then
            'Precisa separar em 2 words o tempo de variavel tipo TIME do clp siemens para escrever nas 2 words
            auxCalculo = Valor * 60 * 1000
            auxValor1 = auxCalculo \ 65536
            If auxCalculo Mod 65536 > 32768 Then
                auxValor2 = ((auxCalculo Mod 65536) - 32768) - 32768
            Else
                auxValor2 = auxCalculo Mod 65536
            End If
            res = MainForm.myProtocol.writeSingleRegister(1, Address + 1, auxValor1)
            res = MainForm.myProtocol.writeSingleRegister(1, Address + 2, auxValor2)
        ElseIf CLP = 2 Then
            auxValor1 = Valor * 60
            res = MainForm.CLP_2.writeSingleRegister(1, Address + 1, auxValor1)
        ElseIf CLP = 3 Then
            auxValor1 = Valor * 60
            res = MainForm.M251.writeSingleRegister(1, Address + 1, auxValor1)
        End If
        EscreveTemposDegelo = True
    End Function

    Function vlrSemSinal(valor1 As Short, valor2 As Short) As Int32
        'retorna a word menos significativa da variavel tipo TIME do clp Siemens em um valor positivo
        Dim aux1 As Int32
        If valor2 < 0 Then
            aux1 = 32768 + (32768 + valor2)
        Else
            aux1 = valor2
        End If
        vlrSemSinal = (valor1 * 65536) + aux1
    End Function

    Function LigaBit(Valor As Short, NumBit As Short) As Short
        'Função que torna valor 1 (true) um determinado bit de uma word
        Dim auxValor As Int32
        auxValor = Valor Or (1 << NumBit)
        If auxValor > 32767 Then
            LigaBit = auxValor - 65536
        Else
            LigaBit = auxValor
        End If
    End Function

    Function DesligaBit(Valor As Short, NumBit As Short) As Short
        Dim auxValor As Int32
        auxValor = Valor And (65535 - (1 << NumBit))
        If auxValor > 32767 Then
            DesligaBit = auxValor - 65536
        Else
            DesligaBit = auxValor
        End If
    End Function

    Function ConectarCLPSadema() As Boolean
        If MainForm.myProtocol Is Nothing Then
            Try
                MainForm.myProtocol = New MbusTcpMasterProtocol()
            Catch ex As Exception
                MainForm.lblResult.Text = "Could not instantiate ethernet protocol class! Error was " & ex.Message
                LogService.GravarErro("COMUNICACAO", "Erro ao criar instancia do myProtocol (CLP Sadema): " & ex.Message)
                Return False
            End Try
        End If

        MainForm.myProtocol.closeProtocol()

        Dim retryCnt, pollDelay, timeOut, tcpPort, res As Int32
        retryCnt = 0
        pollDelay = 0
        timeOut = 200
        tcpPort = 502

        MainForm.myProtocol.timeout = timeOut
        MainForm.myProtocol.retryCnt = retryCnt
        MainForm.myProtocol.pollDelay = pollDelay
        CType(MainForm.myProtocol, MbusIpClientBase).port = CShort(tcpPort)
        res = CType(MainForm.myProtocol, MbusIpClientBase).openProtocol("10.15.16.162")
        If res = BusProtocolErrors.FTALK_SUCCESS Then
            MainForm.lblResult.Text = "Modbus/TCP port opened successfully with parameters: 10.15.16.162 TCP port " & tcpPort
            If ConnectionState_Sadema <> 1 Then
                LogService.GravarInfo("COMUNICACAO", "Conexão aberta com sucesso no CLP Sadema (10.15.16.162)")
                ConnectionState_Sadema = 1
            End If
        Else
            MainForm.lblResult.Text = "Could not open protocol, error was: " & BusProtocolErrors.getBusProtocolErrorText(res)
            If ConnectionState_Sadema <> 2 Then
                LogService.GravarErro("COMUNICACAO", "Falha ao conectar no CLP Sadema (10.15.16.162): " & BusProtocolErrors.getBusProtocolErrorText(res))
                ConnectionState_Sadema = 2
            End If
            MainForm.myProtocol.closeProtocol()
        End If

        If MainForm.myProtocol.isOpen Then
            MainForm.TimerCLP.Interval = 500
            ConectarCLPSadema = True
        Else
            MainForm.TimerCLP.Interval = 5000
            ConectarCLPSadema = False
        End If
    End Function

    Function ConectarMBComp1() As Boolean
        If MainForm.MBComp1 Is Nothing Then
            Try
                MainForm.MBComp1 = New MbusTcpMasterProtocol()
            Catch ex As Exception
                MainForm.BarraStatusLabel3.Text = "Could not instantiate ethernet protocol class! Error was " & ex.Message
                LogService.GravarErro("COMUNICACAO", "Erro ao criar instancia do MBComp1 (Compressor 1): " & ex.Message)
                Return False
            End Try
        End If

        MainForm.MBComp1.closeProtocol()

        Dim retryCnt, pollDelay, timeOut, tcpPort, res As Int32
        retryCnt = 0
        pollDelay = 0
        timeOut = 200
        tcpPort = 502

        MainForm.MBComp1.timeout = timeOut
        MainForm.MBComp1.retryCnt = retryCnt
        MainForm.MBComp1.pollDelay = pollDelay
        CType(MainForm.MBComp1, MbusIpClientBase).port = CShort(tcpPort)
        res = CType(MainForm.MBComp1, MbusIpClientBase).openProtocol("10.15.16.150")
        If res = BusProtocolErrors.FTALK_SUCCESS Then
            If ConnectionState_MBComp1 <> 1 Then
                LogService.GravarInfo("COMUNICACAO", "Conexão aberta com sucesso no Compressor 1 (10.15.16.150)")
                ConnectionState_MBComp1 = 1
            End If
        Else
            If ConnectionState_MBComp1 <> 2 Then
                LogService.GravarErro("COMUNICACAO", "Falha ao conectar no Compressor 1 (10.15.16.150): " & BusProtocolErrors.getBusProtocolErrorText(res))
                ConnectionState_MBComp1 = 2
            End If
            MainForm.MBComp1.closeProtocol()
        End If

        If MainForm.MBComp1.isOpen Then
            MainForm.TimerCompressor1.Interval = 1000
            ConectarMBComp1 = True
        Else
            MainForm.TimerCompressor1.Interval = 10000
            ConectarMBComp1 = False
        End If
    End Function

    Function ConectarMBComp2() As Boolean
        If MainForm.MBComp2 Is Nothing Then
            Try
                MainForm.MBComp2 = New MbusTcpMasterProtocol()
            Catch ex As Exception
                MainForm.BarraStatusLabel4.Text = "Could not instantiate ethernet protocol class! Error was " & ex.Message
                LogService.GravarErro("COMUNICACAO", "Erro ao criar instancia do MBComp2 (Compressor 2): " & ex.Message)
                Return False
            End Try
        End If

        MainForm.MBComp2.closeProtocol()

        Dim retryCnt, pollDelay, timeOut, tcpPort, res As Int32
        retryCnt = 0
        pollDelay = 0
        timeOut = 200
        tcpPort = 502

        MainForm.MBComp2.timeout = timeOut
        MainForm.MBComp2.retryCnt = retryCnt
        MainForm.MBComp2.pollDelay = pollDelay
        CType(MainForm.MBComp2, MbusIpClientBase).port = CShort(tcpPort)
        res = CType(MainForm.MBComp2, MbusIpClientBase).openProtocol("10.15.16.151")
        If res = BusProtocolErrors.FTALK_SUCCESS Then
            If ConnectionState_MBComp2 <> 1 Then
                LogService.GravarInfo("COMUNICACAO", "Conexão aberta com sucesso no Compressor 2 (10.15.16.151)")
                ConnectionState_MBComp2 = 1
            End If
        Else
            If ConnectionState_MBComp2 <> 2 Then
                LogService.GravarErro("COMUNICACAO", "Falha ao conectar no Compressor 2 (10.15.16.151): " & BusProtocolErrors.getBusProtocolErrorText(res))
                ConnectionState_MBComp2 = 2
            End If
            MainForm.MBComp2.closeProtocol()
        End If

        If MainForm.MBComp2.isOpen Then
            MainForm.TimerCompressor2.Interval = 1000
            ConectarMBComp2 = True
        Else
            MainForm.TimerCompressor2.Interval = 10000
            ConectarMBComp2 = False
        End If
    End Function
    Function ConectarMBComp3() As Boolean
        If MainForm.MBComp3 Is Nothing Then
            Try
                MainForm.MBComp3 = New MbusTcpMasterProtocol()
            Catch ex As Exception
                MainForm.BarraStatusLabel5.Text = "Could not instantiate ethernet protocol class! Error was " & ex.Message
                LogService.GravarErro("COMUNICACAO", "Erro ao criar instancia do MBComp3 (Compressor 3): " & ex.Message)
                Return False
            End Try
        End If

        MainForm.MBComp3.closeProtocol()

        Dim retryCnt, pollDelay, timeOut, tcpPort, res As Int32
        retryCnt = 0
        pollDelay = 0
        timeOut = 200
        tcpPort = 502

        MainForm.MBComp3.timeout = timeOut
        MainForm.MBComp3.retryCnt = retryCnt
        MainForm.MBComp3.pollDelay = pollDelay
        CType(MainForm.MBComp3, MbusIpClientBase).port = CShort(tcpPort)
        res = CType(MainForm.MBComp3, MbusIpClientBase).openProtocol("10.15.16.152")
        If res = BusProtocolErrors.FTALK_SUCCESS Then
            If ConnectionState_MBComp3 <> 1 Then
                LogService.GravarInfo("COMUNICACAO", "Conexão aberta com sucesso no Compressor 3 (10.15.16.152)")
                ConnectionState_MBComp3 = 1
            End If
        Else
            If ConnectionState_MBComp3 <> 2 Then
                LogService.GravarErro("COMUNICACAO", "Falha ao conectar no Compressor 3 (10.15.16.152): " & BusProtocolErrors.getBusProtocolErrorText(res))
                ConnectionState_MBComp3 = 2
            End If
            MainForm.MBComp3.closeProtocol()
        End If

        If MainForm.MBComp3.isOpen Then
            MainForm.TimerCompressor3.Interval = 1000
            ConectarMBComp3 = True
        Else
            MainForm.TimerCompressor3.Interval = 10000
            ConectarMBComp3 = False
        End If
    End Function

    Function ConectarCLP2() As Boolean
        If MainForm.CLP_2 Is Nothing Then
            Try
                MainForm.CLP_2 = New MbusTcpMasterProtocol()
            Catch ex As Exception
                MainForm.BarraStatusLabel6.Text = "Could not instantiate ethernet protocol class! Error was " & ex.Message
                LogService.GravarErro("COMUNICACAO", "Erro ao criar instancia do CLP_2 (CLP 2): " & ex.Message)
                Return False
            End Try
        End If

        MainForm.CLP_2.closeProtocol()

        Dim retryCnt, pollDelay, timeOut, tcpPort, res As Int32
        retryCnt = 0
        pollDelay = 0
        timeOut = 200
        tcpPort = 502

        MainForm.CLP_2.timeout = timeOut
        MainForm.CLP_2.retryCnt = retryCnt
        MainForm.CLP_2.pollDelay = pollDelay
        CType(MainForm.CLP_2, MbusIpClientBase).port = CShort(tcpPort)
        res = CType(MainForm.CLP_2, MbusIpClientBase).openProtocol("10.15.16.164")
        If res = BusProtocolErrors.FTALK_SUCCESS Then
            If ConnectionState_CLP2 <> 1 Then
                LogService.GravarInfo("COMUNICACAO", "Conexão aberta com sucesso no CLP 2 (10.15.16.164)")
                ConnectionState_CLP2 = 1
            End If
        Else
            If ConnectionState_CLP2 <> 2 Then
                LogService.GravarErro("COMUNICACAO", "Falha ao conectar no CLP 2 (10.15.16.164): " & BusProtocolErrors.getBusProtocolErrorText(res))
                ConnectionState_CLP2 = 2
            End If
            MainForm.CLP_2.closeProtocol()
        End If

        If MainForm.CLP_2.isOpen Then
            MainForm.Timer_CLP2.Interval = 500
            ConectarCLP2 = True
        Else
            MainForm.Timer_CLP2.Interval = 5000
            ConectarCLP2 = False
        End If
    End Function

    Function ConectarM251() As Boolean
        MainForm.BarraStatusM251.Text = "Conectar"
        If MainForm.M251 Is Nothing Then
            Try
                MainForm.M251 = New MbusTcpMasterProtocol()
            Catch ex As Exception
                MainForm.BarraStatusM251.Text = "Could not instantiate ethernet protocol class! Error was " & ex.Message
                LogService.GravarErro("COMUNICACAO", "Erro ao criar instancia do M251 (CLP M251): " & ex.Message)
                Return False
            End Try
        End If

        MainForm.M251.closeProtocol()

        Dim retryCnt, pollDelay, timeOut, tcpPort, res As Int32
        retryCnt = 0
        pollDelay = 0
        timeOut = 200
        tcpPort = 502

        MainForm.M251.timeout = timeOut
        MainForm.M251.retryCnt = retryCnt
        MainForm.M251.pollDelay = pollDelay
        CType(MainForm.M251, MbusIpClientBase).port = CShort(tcpPort)
        res = CType(MainForm.M251, MbusIpClientBase).openProtocol("10.15.16.166")
        If res = BusProtocolErrors.FTALK_SUCCESS Then
            If ConnectionState_M251 <> 1 Then
                LogService.GravarInfo("COMUNICACAO", "Conexão aberta com sucesso no CLP M251 (10.15.16.166)")
                ConnectionState_M251 = 1
            End If
        Else
            If ConnectionState_M251 <> 2 Then
                LogService.GravarErro("COMUNICACAO", "Falha ao conectar no CLP M251 (10.15.16.166): " & BusProtocolErrors.getBusProtocolErrorText(res))
                ConnectionState_M251 = 2
            End If
            MainForm.M251.closeProtocol()
        End If

        If MainForm.M251.isOpen Then
            MainForm.Timer_M251.Interval = 500
            ConectarM251 = True
        Else
            MainForm.Timer_M251.Interval = 5000
            ConectarM251 = False
        End If
    End Function

End Module
