Imports FieldTalk.Modbus.Master

Module Module2
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
        ' Make sure we close rather than leaving closing to the garbage collector
        If Not MainForm.myProtocol Is Nothing Then
            MainForm.myProtocol.closeProtocol()
        End If
        '
        ' Create and open protocol
        '
        Try
            MainForm.myProtocol = New MbusTcpMasterProtocol
        Catch ex As OutOfMemoryException
            MainForm.lblResult.Text = "Could not instantiate ethernet protocol class! Error was " & ex.Message
        End Try
        '
        ' Here we configure the protocol
        '
        Dim retryCnt, pollDelay, timeOut, tcpPort, res As Int32
        retryCnt = 0
        pollDelay = 0
        timeOut = 200
        tcpPort = 502

        MainForm.myProtocol.timeout = timeOut
        MainForm.myProtocol.retryCnt = retryCnt
        MainForm.myProtocol.pollDelay = pollDelay
        ' Note: The following CType() cast is required as the myProtocol object is declared
        ' as the superclass of MbusTcpMasterProtocol. That way myProtocol can
        ' represent different protocol types.
        CType(MainForm.myProtocol, MbusIpClientBase).port = CShort(tcpPort)
        res = CType(MainForm.myProtocol, MbusIpClientBase).openProtocol("10.15.16.162")
        If res = BusProtocolErrors.FTALK_SUCCESS Then
            MainForm.lblResult.Text = "Modbus/TCP port opened successfully with parameters: 10.15.16.162 TCP port " & tcpPort
        Else
            MainForm.lblResult.Text = "Could not open protocol, error was: " & BusProtocolErrors.getBusProtocolErrorText(res)
            MainForm.myProtocol.closeProtocol()
        End If

        If MainForm.myProtocol.isOpen Then
            MainForm.ToolStripStatusLabel1.Text = "CLP: Conectado"
            MainForm.TimerCLP.Interval = 500
            ConectarCLPSadema = True
        Else
            MainForm.ToolStripStatusLabel1.Text = "CLP: Desconectado"
            MainForm.TimerCLP.Interval = 5000
            MainForm.varContadorCommFault += 1
            MainForm.BarraStatusLabel2.Text = "Contadores: " & MainForm.varContadorCommOK & " OK - " & MainForm.varContadorCommFault & " Fault"
            ConectarCLPSadema = False
        End If
    End Function

    Function ConectarMBComp1() As Boolean
        ' Make sure we close rather than leaving closing to the garbage collector
        If Not MainForm.MBComp1 Is Nothing Then
            MainForm.MBComp1.closeProtocol()
        End If
        '
        ' Create and open protocol
        '
        Try
            MainForm.MBComp1 = New MbusTcpMasterProtocol
        Catch ex As OutOfMemoryException
            MainForm.BarraStatusLabel3.Text = "Could not instantiate ethernet protocol class! Error was " & ex.Message
        End Try
        '
        ' Here we configure the protocol
        '
        Dim retryCnt, pollDelay, timeOut, tcpPort, res As Int32
        retryCnt = 0
        pollDelay = 0
        timeOut = 200
        tcpPort = 502

        MainForm.MBComp1.timeout = timeOut
        MainForm.MBComp1.retryCnt = retryCnt
        MainForm.MBComp1.pollDelay = pollDelay
        ' Note: The following CType() cast is required as the myProtocol object is declared
        ' as the superclass of MbusTcpMasterProtocol. That way myProtocol can
        ' represent different protocol types.
        CType(MainForm.MBComp1, MbusIpClientBase).port = CShort(tcpPort)
        res = CType(MainForm.MBComp1, MbusIpClientBase).openProtocol("10.15.16.150")
        If res = BusProtocolErrors.FTALK_SUCCESS Then
            MainForm.BarraStatusLabel3.Text = "Compressor 1: Conectado"
        Else
            MainForm.BarraStatusLabel3.Text = "Comp 1 - Não Conectado" & BusProtocolErrors.getBusProtocolErrorText(res)
            MainForm.MBComp1.closeProtocol()
        End If

        If MainForm.MBComp1.isOpen Then
            MainForm.BarraStatusLabel3.Text = "Compressor 1: Conectado"
            MainForm.TimerCompressor1.Interval = 1000
            ConectarMBComp1 = True
        Else
            MainForm.BarraStatusLabel3.Text = "Compressor 1: Desconectado"
            MainForm.TimerCompressor1.Interval = 10000
            ConectarMBComp1 = False
        End If
    End Function

    Function ConectarMBComp2() As Boolean
        ' Make sure we close rather than leaving closing to the garbage collector
        If Not MainForm.MBComp2 Is Nothing Then
            MainForm.MBComp2.closeProtocol()
        End If
        '
        ' Create and open protocol
        '
        Try
            MainForm.MBComp2 = New MbusTcpMasterProtocol
        Catch ex As OutOfMemoryException
            MainForm.BarraStatusLabel4.Text = "Could not instantiate ethernet protocol class! Error was " & ex.Message
        End Try
        '
        ' Here we configure the protocol
        '
        Dim retryCnt, pollDelay, timeOut, tcpPort, res As Int32
        retryCnt = 0
        pollDelay = 0
        timeOut = 200
        tcpPort = 502

        MainForm.MBComp2.timeout = timeOut
        MainForm.MBComp2.retryCnt = retryCnt
        MainForm.MBComp2.pollDelay = pollDelay
        ' Note: The following CType() cast is required as the myProtocol object is declared
        ' as the superclass of MbusTcpMasterProtocol. That way myProtocol can
        ' represent different protocol types.
        CType(MainForm.MBComp2, MbusIpClientBase).port = CShort(tcpPort)
        res = CType(MainForm.MBComp2, MbusIpClientBase).openProtocol("10.15.16.151")
        If res = BusProtocolErrors.FTALK_SUCCESS Then
            MainForm.BarraStatusLabel4.Text = "Compressor 2: Conectado"
        Else
            MainForm.BarraStatusLabel4.Text = "Comp 2 - Não Conectado" & BusProtocolErrors.getBusProtocolErrorText(res)
            MainForm.MBComp2.closeProtocol()
        End If

        If MainForm.MBComp2.isOpen Then
            MainForm.BarraStatusLabel4.Text = "Compressor 2: Conectado"
            MainForm.TimerCompressor2.Interval = 1000
            ConectarMBComp2 = True
        Else
            MainForm.BarraStatusLabel4.Text = "Compressor 2: Desconectado"
            MainForm.TimerCompressor2.Interval = 10000
            ConectarMBComp2 = False
        End If
    End Function
    Function ConectarMBComp3() As Boolean
        ' Make sure we close rather than leaving closing to the garbage collector
        If Not MainForm.MBComp3 Is Nothing Then
            MainForm.MBComp3.closeProtocol()
        End If
        '
        ' Create and open protocol
        '
        Try
            MainForm.MBComp3 = New MbusTcpMasterProtocol
        Catch ex As OutOfMemoryException
            MainForm.BarraStatusLabel5.Text = "Could not instantiate ethernet protocol class! Error was " & ex.Message
        End Try
        '
        ' Here we configure the protocol
        '
        Dim retryCnt, pollDelay, timeOut, tcpPort, res As Int32
        retryCnt = 0
        pollDelay = 0
        timeOut = 200
        tcpPort = 502

        MainForm.MBComp3.timeout = timeOut
        MainForm.MBComp3.retryCnt = retryCnt
        MainForm.MBComp3.pollDelay = pollDelay
        ' Note: The following CType() cast is required as the myProtocol object is declared
        ' as the superclass of MbusTcpMasterProtocol. That way myProtocol can
        ' represent different protocol types.
        CType(MainForm.MBComp3, MbusIpClientBase).port = CShort(tcpPort)
        res = CType(MainForm.MBComp3, MbusIpClientBase).openProtocol("10.15.16.152")
        If res = BusProtocolErrors.FTALK_SUCCESS Then
            MainForm.BarraStatusLabel5.Text = "Compressor 3: Conectado"
        Else
            MainForm.BarraStatusLabel5.Text = "Comp 3 - Não Conectado" & BusProtocolErrors.getBusProtocolErrorText(res)
            MainForm.MBComp3.closeProtocol()
        End If

        If MainForm.MBComp3.isOpen Then
            MainForm.BarraStatusLabel5.Text = "Compressor 3: Conectado"
            MainForm.TimerCompressor3.Interval = 1000
            ConectarMBComp3 = True
        Else
            MainForm.BarraStatusLabel5.Text = "Compressor 3: Desconectado"
            MainForm.TimerCompressor3.Interval = 10000
            ConectarMBComp3 = False
        End If
    End Function

    Function ConectarCLP2() As Boolean
        ' Make sure we close rather than leaving closing to the garbage collector
        If Not MainForm.CLP_2 Is Nothing Then
            MainForm.CLP_2.closeProtocol()
        End If
        '
        ' Create and open protocol
        '
        Try
            MainForm.CLP_2 = New MbusTcpMasterProtocol
        Catch ex As OutOfMemoryException
            MainForm.BarraStatusLabel6.Text = "Could not instantiate ethernet protocol class! Error was " & ex.Message
        End Try
        '
        ' Here we configure the protocol
        '
        Dim retryCnt, pollDelay, timeOut, tcpPort, res As Int32
        retryCnt = 0
        pollDelay = 0
        timeOut = 200
        tcpPort = 502

        MainForm.CLP_2.timeout = timeOut
        MainForm.CLP_2.retryCnt = retryCnt
        MainForm.CLP_2.pollDelay = pollDelay
        ' Note: The following CType() cast is required as the myProtocol object is declared
        ' as the superclass of MbusTcpMasterProtocol. That way myProtocol can
        ' represent different protocol types.
        CType(MainForm.CLP_2, MbusIpClientBase).port = CShort(tcpPort)
        res = CType(MainForm.CLP_2, MbusIpClientBase).openProtocol("10.15.16.164")
        If res = BusProtocolErrors.FTALK_SUCCESS Then
            MainForm.BarraStatusLabel6.Text = "CLP 2: Conectado"
        Else
            MainForm.BarraStatusLabel6.Text = "CLP 2 - Não Conectado" & BusProtocolErrors.getBusProtocolErrorText(res)
            MainForm.CLP_2.closeProtocol()
        End If

        If MainForm.CLP_2.isOpen Then
            MainForm.BarraStatusLabel6.Text = "CLP 2: Conectado"
            MainForm.Timer_CLP2.Interval = 500
            ConectarCLP2 = True
        Else
            MainForm.BarraStatusLabel6.Text = "CLP 2: Desconectado"
            MainForm.Timer_CLP2.Interval = 5000
            ConectarCLP2 = False
        End If
    End Function

    Function ConectarM251() As Boolean
        MainForm.BarraStatusM251.Text = "Conectar"
        ' Make sure we close rather than leaving closing to the garbage collector
        If Not MainForm.M251 Is Nothing Then
            MainForm.M251.closeProtocol()
        End If
        '
        ' Create and open protocol
        '
        Try
            MainForm.M251 = New MbusTcpMasterProtocol
        Catch ex As OutOfMemoryException
            MainForm.BarraStatusM251.Text = "Could not instantiate ethernet protocol class! Error was " & ex.Message
        End Try
        '
        ' Here we configure the protocol
        '
        Dim retryCnt, pollDelay, timeOut, tcpPort, res As Int32
        retryCnt = 0
        pollDelay = 0
        timeOut = 200
        tcpPort = 502

        MainForm.M251.timeout = timeOut
        MainForm.M251.retryCnt = retryCnt
        MainForm.M251.pollDelay = pollDelay
        ' Note: The following CType() cast is required as the myProtocol object is declared
        ' as the superclass of MbusTcpMasterProtocol. That way myProtocol can
        ' represent different protocol types.
        CType(MainForm.M251, MbusIpClientBase).port = CShort(tcpPort)
        res = CType(MainForm.M251, MbusIpClientBase).openProtocol("10.15.16.166")
        If res = BusProtocolErrors.FTALK_SUCCESS Then
            MainForm.BarraStatusM251.Text = "M251: Conectado"
        Else
            MainForm.BarraStatusM251.Text = "M251 - Não Conectado" & BusProtocolErrors.getBusProtocolErrorText(res)
            MainForm.M251.closeProtocol()
        End If

        If MainForm.M251.isOpen Then
            MainForm.BarraStatusM251.Text = "M251: Conectado"
            MainForm.Timer_M251.Interval = 500
            ConectarM251 = True
        Else
            MainForm.BarraStatusM251.Text = "M251: Desconectado"
            MainForm.Timer_M251.Interval = 5000
            ConectarM251 = False
        End If
    End Function

End Module
