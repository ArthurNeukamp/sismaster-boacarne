Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox
Imports FieldTalk.Modbus.Master


Public Class MainForm

    Public myProtocol, MBComp1, MBComp2, MBComp3, CLP_2, M251 As MbusMasterFunctions
    Public Structure STRCamaras
        Dim varStatus, varControle As Integer
        Dim varTemperatura, varSetPoint, varOffSet, varStatusAmbiente As Integer
        Dim bitLigaEvap, bitLigaVSSC, bitLigaVSGQ, bitLigaVSLL, bitLigaVSAG, bitDegelo As Boolean
        Dim bitMAEvap, bitMAVSSC, bitMAVSGQ, bitMAVSLL, bitMAVSAG As Boolean
        Dim bitLDEvap, bitLDVSSC, bitLDVSGQ, bitLDVSLL, bitLDVSAG As Boolean
        Dim bitHabAmbiente As Boolean
        Dim bitMADegelo, bitForceDegelo, bitHabDegelo1, bitHabDegelo2, bitHabDegelo3, bitHabDegelo4 As Boolean
        Dim varSPRecolhimento, varSPGasQuente, varSPAgua, varSPGotejamento, varSPPreResfriamento As Integer
        Dim varHoraDegelo1, varMinutoDegelo1, varHoraDegelo2, varMinutoDegelo2 As Integer
        Dim varHoraDegelo3, varMinutoDegelo3, varHoraDegelo4, varMinutoDegelo4 As Integer
        Dim varTempoRecolhimento, varTempoGasQuente, varTempoAgua, varTempoGotejamento, varTempoPreResfriamento As Int16
        Dim bitFalhaEvaporador1, bitFalhaEvaporador2, bitFalhaEvaporador3, bitFalhaEvaporador4 As Boolean
        'Endereços e tipo de ambiente e CLP=1 siemens sala maquinas CLP=2 tuneis 4a7 CLP=3 SADEMA M251
        Dim varStartAdress, varTipoAmbiente, varADTRecolhimento, varADTGasQuente, varADTAgua, varADTGotejamento, varADTPreResfriamento As Integer
        Dim varADSetpoint, varADOffSet, varADControle, varCLP, varADHora1, varADHora2, varADHora3 As Short
    End Structure

    Public Structure STRCompressores
        Dim varPressaoSuccao, varPressaoDescarga, varPressaoOleo, varPressaoFiltroOleo, varTemperaturaSuccao, varTemperaturaDescarga As Integer
        Dim varTemperaturaOleo, varTemperaturaSeparador, varPressaoIntermediario, varTemperaturaIntermediario, varCorrenteEletrica As Integer
        Dim varStatus, varRotacao As Integer
    End Structure

    Public blcGeral(3000), blcGeral2(500), blcGeral3(600) As Integer
    Public varContadorCommOK, varContadorCommFault, varAlarmes1, varAlarmes2, varAlarmes3, varAlarmes4 As Int32

    Public Ambientes(50) As STRCamaras
    Public Compressores(3) As STRCompressores

    Public varPosicaoICAD, varNivelSeparador, varPressaoBombaNH3, varAmbienteAtivo, varCompressorAtivo As Integer
    Public varStatusSadema1 As Integer
    Public bitValvulaLiquidoSeparador As Boolean

    Private Sub TimerCLP_Tick(sender As Object, e As EventArgs) Handles TimerCLP.Tick
        Dim readVals(100), i, j As Int16
        Dim slave, startRdReg, numRdRegs, varST As Int16
        Dim res As Int32
        Dim varTempoDecorrido As Int32 'auxiliar para calculos de variaveis do CLP tipo Time e TOD

        If Not myProtocol.isOpen() Then
            If Not ConectarCLPSadema() Then
                Exit Sub
            End If
        Else
            varContadorCommOK += 1
            BarraStatusLabel2.Text = "Contadores: " & varContadorCommOK & " OK - " & varContadorCommFault & " Fault"
        End If

        slave = 1
        startRdReg = 2407
        numRdRegs = 75
        res = myProtocol.readMultipleRegisters(slave, startRdReg, readVals, numRdRegs)
        If res = BusProtocolErrors.FTALK_SUCCESS Then
            For i = 1 To 100
                blcGeral(startRdReg - 1 + i) = readVals(i)
            Next
            Ambientes(1).varTemperatura = blcGeral(2408)
            Ambientes(2).varTemperatura = readVals(3)
            Ambientes(3).varTemperatura = readVals(4)
            Ambientes(4).varTemperatura = readVals(5)
            Ambientes(5).varTemperatura = readVals(6)
            Ambientes(6).varTemperatura = readVals(7)
            Ambientes(7).varTemperatura = readVals(8)
            Ambientes(8).varTemperatura = readVals(9)
            Ambientes(1).varSetPoint = blcGeral(2418)
            Ambientes(2).varSetPoint = readVals(13)
            Ambientes(3).varSetPoint = readVals(14)
            Ambientes(4).varSetPoint = readVals(15)
            Ambientes(5).varSetPoint = readVals(16)
            Ambientes(6).varSetPoint = readVals(17)
            Ambientes(7).varSetPoint = readVals(18)
            Ambientes(8).varSetPoint = readVals(19)
            varPressaoBombaNH3 = blcGeral(2429)
            varNivelSeparador = blcGeral(2430)
            varPosicaoICAD = blcGeral(2431)

            Ambientes(1).varOffSet = blcGeral(2433)
            Ambientes(2).varOffSet = blcGeral(2434)
            Ambientes(3).varOffSet = blcGeral(2435)
            Ambientes(4).varOffSet = blcGeral(2436)
            Ambientes(5).varOffSet = blcGeral(2437)
            Ambientes(6).varOffSet = blcGeral(2438)
            Ambientes(7).varOffSet = blcGeral(2439)
            Ambientes(8).varOffSet = blcGeral(2440)

            Ambientes(1).varStatus = blcGeral(2443)
            Ambientes(2).varStatus = blcGeral(2444)
            Ambientes(3).varStatus = blcGeral(2445)
            Ambientes(4).varStatus = blcGeral(2446)
            Ambientes(5).varStatus = blcGeral(2447)
            Ambientes(6).varStatus = blcGeral(2448)
            Ambientes(7).varStatus = blcGeral(2449)
            Ambientes(8).varStatus = blcGeral(2450)

            Ambientes(1).varControle = blcGeral(2456)
            Ambientes(2).varControle = blcGeral(2457)
            Ambientes(3).varControle = blcGeral(2458)
            Ambientes(4).varControle = blcGeral(2459)
            Ambientes(5).varControle = blcGeral(2460)
            Ambientes(6).varControle = blcGeral(2461)
            Ambientes(7).varControle = blcGeral(2462)
            Ambientes(8).varControle = blcGeral(2463)

            Ambientes(1).varStatusAmbiente = blcGeral(2469)
            Ambientes(2).varStatusAmbiente = blcGeral(2470)
            Ambientes(3).varStatusAmbiente = blcGeral(2471)
            Ambientes(4).varStatusAmbiente = blcGeral(2472)
            Ambientes(5).varStatusAmbiente = blcGeral(2473)
            Ambientes(6).varStatusAmbiente = blcGeral(2474)
            Ambientes(7).varStatusAmbiente = blcGeral(2475)
            Ambientes(8).varStatusAmbiente = blcGeral(2476)

            'Label1.Text = Ambientes(1).varControle >> 2

            'desfragmenta bits tunel 1 (Atual Tunel 12)
            Ambientes(1).bitLigaEvap = DesfragmentaBit(Ambientes(1).varControle, 14)
            Ambientes(1).bitLigaVSSC = DesfragmentaBit(Ambientes(1).varControle, 15)
            Ambientes(1).bitLigaVSLL = DesfragmentaBit(Ambientes(1).varControle, 0)
            Ambientes(1).bitLigaVSGQ = DesfragmentaBit(Ambientes(1).varControle, 1)
            Ambientes(1).bitLigaVSAG = DesfragmentaBit(Ambientes(1).varControle, 2)
            Ambientes(1).bitMADegelo = DesfragmentaBit(Ambientes(1).varControle, 3)
            Ambientes(1).bitHabDegelo1 = DesfragmentaBit(Ambientes(1).varControle, 4)
            Ambientes(1).bitHabDegelo2 = DesfragmentaBit(Ambientes(1).varControle, 5)
            Ambientes(1).bitHabDegelo3 = DesfragmentaBit(Ambientes(1).varControle, 6)
            Ambientes(1).bitForceDegelo = DesfragmentaBit(Ambientes(1).varControle, 7)
            Ambientes(1).bitHabAmbiente = DesfragmentaBit(Ambientes(1).varControle, 8)
            Ambientes(1).bitMAEvap = DesfragmentaBit(Ambientes(1).varControle, 9)
            Ambientes(1).bitMAVSSC = DesfragmentaBit(Ambientes(1).varControle, 10)
            Ambientes(1).bitMAVSLL = DesfragmentaBit(Ambientes(1).varControle, 11)
            Ambientes(1).bitMAVSGQ = DesfragmentaBit(Ambientes(1).varControle, 12)
            Ambientes(1).bitMAVSAG = DesfragmentaBit(Ambientes(1).varControle, 13)
            Ambientes(1).bitDegelo = DesfragmentaBit(Ambientes(1).varStatus, 8)
            Ambientes(1).bitLDEvap = DesfragmentaBit(Ambientes(1).varStatus, 9)
            Ambientes(1).bitLDVSSC = DesfragmentaBit(Ambientes(1).varStatus, 10)
            Ambientes(1).bitLDVSLL = DesfragmentaBit(Ambientes(1).varStatus, 11)
            Ambientes(1).bitLDVSGQ = DesfragmentaBit(Ambientes(1).varStatus, 12)
            Ambientes(1).bitLDVSAG = DesfragmentaBit(Ambientes(1).varStatus, 13)
            Ambientes(1).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 0)
            Ambientes(1).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 1)

            'desfragmenta bits tunel 2 (Atual Tunel 11)
            Ambientes(2).bitLigaEvap = DesfragmentaBit(Ambientes(2).varControle, 14)
            Ambientes(2).bitLigaVSSC = DesfragmentaBit(Ambientes(2).varControle, 15)
            Ambientes(2).bitLigaVSLL = DesfragmentaBit(Ambientes(2).varControle, 0)
            Ambientes(2).bitLigaVSGQ = DesfragmentaBit(Ambientes(2).varControle, 1)
            Ambientes(2).bitLigaVSAG = DesfragmentaBit(Ambientes(2).varControle, 2)
            Ambientes(2).bitMADegelo = DesfragmentaBit(Ambientes(2).varControle, 3)
            Ambientes(2).bitHabDegelo1 = DesfragmentaBit(Ambientes(2).varControle, 4)
            Ambientes(2).bitHabDegelo2 = DesfragmentaBit(Ambientes(2).varControle, 5)
            Ambientes(2).bitHabDegelo3 = DesfragmentaBit(Ambientes(2).varControle, 6)
            Ambientes(2).bitForceDegelo = DesfragmentaBit(Ambientes(2).varControle, 7)
            Ambientes(2).bitHabAmbiente = DesfragmentaBit(Ambientes(2).varControle, 8)
            Ambientes(2).bitMAEvap = DesfragmentaBit(Ambientes(2).varControle, 9)
            Ambientes(2).bitMAVSSC = DesfragmentaBit(Ambientes(2).varControle, 10)
            Ambientes(2).bitMAVSLL = DesfragmentaBit(Ambientes(2).varControle, 11)
            Ambientes(2).bitMAVSGQ = DesfragmentaBit(Ambientes(2).varControle, 12)
            Ambientes(2).bitMAVSAG = DesfragmentaBit(Ambientes(2).varControle, 13)
            Ambientes(2).bitDegelo = DesfragmentaBit(Ambientes(2).varStatus, 8)
            Ambientes(2).bitLDEvap = DesfragmentaBit(Ambientes(2).varStatus, 9)
            Ambientes(2).bitLDVSSC = DesfragmentaBit(Ambientes(2).varStatus, 10)
            Ambientes(2).bitLDVSLL = DesfragmentaBit(Ambientes(2).varStatus, 11)
            Ambientes(2).bitLDVSGQ = DesfragmentaBit(Ambientes(2).varStatus, 12)
            Ambientes(2).bitLDVSAG = DesfragmentaBit(Ambientes(2).varStatus, 13)
            Ambientes(2).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 2)
            Ambientes(2).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 3)

            'desfragmenta bits tunel 3 (Atual tunel 10)
            Ambientes(3).bitLigaEvap = DesfragmentaBit(Ambientes(3).varControle, 14)
            Ambientes(3).bitLigaVSSC = DesfragmentaBit(Ambientes(3).varControle, 15)
            Ambientes(3).bitLigaVSLL = DesfragmentaBit(Ambientes(3).varControle, 0)
            Ambientes(3).bitLigaVSGQ = DesfragmentaBit(Ambientes(3).varControle, 1)
            Ambientes(3).bitLigaVSAG = DesfragmentaBit(Ambientes(3).varControle, 2)
            Ambientes(3).bitMADegelo = DesfragmentaBit(Ambientes(3).varControle, 3)
            Ambientes(3).bitHabDegelo1 = DesfragmentaBit(Ambientes(3).varControle, 4)
            Ambientes(3).bitHabDegelo2 = DesfragmentaBit(Ambientes(3).varControle, 5)
            Ambientes(3).bitHabDegelo3 = DesfragmentaBit(Ambientes(3).varControle, 6)
            Ambientes(3).bitForceDegelo = DesfragmentaBit(Ambientes(3).varControle, 7)
            Ambientes(3).bitHabAmbiente = DesfragmentaBit(Ambientes(3).varControle, 8)
            Ambientes(3).bitMAEvap = DesfragmentaBit(Ambientes(3).varControle, 9)
            Ambientes(3).bitMAVSSC = DesfragmentaBit(Ambientes(3).varControle, 10)
            Ambientes(3).bitMAVSLL = DesfragmentaBit(Ambientes(3).varControle, 11)
            Ambientes(3).bitMAVSGQ = DesfragmentaBit(Ambientes(3).varControle, 12)
            Ambientes(3).bitMAVSAG = DesfragmentaBit(Ambientes(3).varControle, 13)
            Ambientes(3).bitDegelo = DesfragmentaBit(Ambientes(3).varStatus, 8)
            Ambientes(3).bitLDEvap = DesfragmentaBit(Ambientes(3).varStatus, 9)
            Ambientes(3).bitLDVSSC = DesfragmentaBit(Ambientes(3).varStatus, 10)
            Ambientes(3).bitLDVSLL = DesfragmentaBit(Ambientes(3).varStatus, 11)
            Ambientes(3).bitLDVSGQ = DesfragmentaBit(Ambientes(3).varStatus, 12)
            Ambientes(3).bitLDVSAG = DesfragmentaBit(Ambientes(3).varStatus, 13)
            Ambientes(3).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 4)
            Ambientes(3).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 5)

            'desfragmenta bits tunel 4 (Atual tunel 9)
            Ambientes(4).bitLigaEvap = DesfragmentaBit(Ambientes(4).varControle, 14)
            Ambientes(4).bitLigaVSSC = DesfragmentaBit(Ambientes(4).varControle, 15)
            Ambientes(4).bitLigaVSLL = DesfragmentaBit(Ambientes(4).varControle, 0)
            Ambientes(4).bitLigaVSGQ = DesfragmentaBit(Ambientes(4).varControle, 1)
            Ambientes(4).bitLigaVSAG = DesfragmentaBit(Ambientes(4).varControle, 2)
            Ambientes(4).bitMADegelo = DesfragmentaBit(Ambientes(4).varControle, 3)
            Ambientes(4).bitHabDegelo1 = DesfragmentaBit(Ambientes(4).varControle, 4)
            Ambientes(4).bitHabDegelo2 = DesfragmentaBit(Ambientes(4).varControle, 5)
            Ambientes(4).bitHabDegelo3 = DesfragmentaBit(Ambientes(4).varControle, 6)
            Ambientes(4).bitForceDegelo = DesfragmentaBit(Ambientes(4).varControle, 7)
            Ambientes(4).bitHabAmbiente = DesfragmentaBit(Ambientes(4).varControle, 8)
            Ambientes(4).bitMAEvap = DesfragmentaBit(Ambientes(4).varControle, 9)
            Ambientes(4).bitMAVSSC = DesfragmentaBit(Ambientes(4).varControle, 10)
            Ambientes(4).bitMAVSLL = DesfragmentaBit(Ambientes(4).varControle, 11)
            Ambientes(4).bitMAVSGQ = DesfragmentaBit(Ambientes(4).varControle, 12)
            Ambientes(4).bitMAVSAG = DesfragmentaBit(Ambientes(4).varControle, 13)
            Ambientes(4).bitDegelo = DesfragmentaBit(Ambientes(4).varStatus, 8)
            Ambientes(4).bitLDEvap = DesfragmentaBit(Ambientes(4).varStatus, 9)
            Ambientes(4).bitLDVSSC = DesfragmentaBit(Ambientes(4).varStatus, 10)
            Ambientes(4).bitLDVSLL = DesfragmentaBit(Ambientes(4).varStatus, 11)
            Ambientes(4).bitLDVSGQ = DesfragmentaBit(Ambientes(4).varStatus, 12)
            Ambientes(4).bitLDVSAG = DesfragmentaBit(Ambientes(4).varStatus, 13)
            Ambientes(4).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 6)
            Ambientes(4).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 7)

            'desfragmenta bits tunel 5 (Atual tunel 8)
            Ambientes(5).bitLigaEvap = DesfragmentaBit(Ambientes(5).varControle, 14)
            Ambientes(5).bitLigaVSSC = DesfragmentaBit(Ambientes(5).varControle, 15)
            Ambientes(5).bitLigaVSLL = DesfragmentaBit(Ambientes(5).varControle, 0)
            Ambientes(5).bitLigaVSGQ = DesfragmentaBit(Ambientes(5).varControle, 1)
            Ambientes(5).bitLigaVSAG = DesfragmentaBit(Ambientes(5).varControle, 2)
            Ambientes(5).bitMADegelo = DesfragmentaBit(Ambientes(5).varControle, 3)
            Ambientes(5).bitHabDegelo1 = DesfragmentaBit(Ambientes(5).varControle, 4)
            Ambientes(5).bitHabDegelo2 = DesfragmentaBit(Ambientes(5).varControle, 5)
            Ambientes(5).bitHabDegelo3 = DesfragmentaBit(Ambientes(5).varControle, 6)
            Ambientes(5).bitForceDegelo = DesfragmentaBit(Ambientes(5).varControle, 7)
            Ambientes(5).bitHabAmbiente = DesfragmentaBit(Ambientes(5).varControle, 8)
            Ambientes(5).bitMAEvap = DesfragmentaBit(Ambientes(5).varControle, 9)
            Ambientes(5).bitMAVSSC = DesfragmentaBit(Ambientes(5).varControle, 10)
            Ambientes(5).bitMAVSLL = DesfragmentaBit(Ambientes(5).varControle, 11)
            Ambientes(5).bitMAVSGQ = DesfragmentaBit(Ambientes(5).varControle, 12)
            Ambientes(5).bitMAVSAG = DesfragmentaBit(Ambientes(5).varControle, 13)
            Ambientes(5).bitDegelo = DesfragmentaBit(Ambientes(5).varStatus, 8)
            Ambientes(5).bitLDEvap = DesfragmentaBit(Ambientes(5).varStatus, 9)
            Ambientes(5).bitLDVSSC = DesfragmentaBit(Ambientes(5).varStatus, 10)
            Ambientes(5).bitLDVSLL = DesfragmentaBit(Ambientes(5).varStatus, 11)
            Ambientes(5).bitLDVSGQ = DesfragmentaBit(Ambientes(5).varStatus, 12)
            Ambientes(5).bitLDVSAG = DesfragmentaBit(Ambientes(5).varStatus, 13)
            Ambientes(5).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 8)
            Ambientes(5).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 9)

            'desfragmenta bits Estocagem 3
            Ambientes(6).bitLigaEvap = DesfragmentaBit(Ambientes(6).varControle, 14)
            Ambientes(6).bitLigaVSSC = DesfragmentaBit(Ambientes(6).varControle, 15)
            Ambientes(6).bitLigaVSLL = DesfragmentaBit(Ambientes(6).varControle, 0)
            Ambientes(6).bitLigaVSGQ = DesfragmentaBit(Ambientes(6).varControle, 1)
            Ambientes(6).bitLigaVSAG = DesfragmentaBit(Ambientes(6).varControle, 2)
            Ambientes(6).bitMADegelo = DesfragmentaBit(Ambientes(6).varControle, 3)
            Ambientes(6).bitHabDegelo1 = DesfragmentaBit(Ambientes(6).varControle, 4)
            Ambientes(6).bitHabDegelo2 = DesfragmentaBit(Ambientes(6).varControle, 5)
            Ambientes(6).bitHabDegelo3 = DesfragmentaBit(Ambientes(6).varControle, 6)
            Ambientes(6).bitForceDegelo = DesfragmentaBit(Ambientes(6).varControle, 7)
            Ambientes(6).bitHabAmbiente = DesfragmentaBit(Ambientes(6).varControle, 8)
            Ambientes(6).bitMAEvap = DesfragmentaBit(Ambientes(6).varControle, 9)
            Ambientes(6).bitMAVSSC = DesfragmentaBit(Ambientes(6).varControle, 10)
            Ambientes(6).bitMAVSLL = DesfragmentaBit(Ambientes(6).varControle, 11)
            Ambientes(6).bitMAVSGQ = DesfragmentaBit(Ambientes(6).varControle, 12)
            Ambientes(6).bitMAVSAG = DesfragmentaBit(Ambientes(6).varControle, 13)
            Ambientes(6).bitDegelo = DesfragmentaBit(Ambientes(6).varStatus, 8)
            Ambientes(6).bitLDEvap = DesfragmentaBit(Ambientes(6).varStatus, 9)
            Ambientes(6).bitLDVSSC = DesfragmentaBit(Ambientes(6).varStatus, 10)
            Ambientes(6).bitLDVSLL = DesfragmentaBit(Ambientes(6).varStatus, 11)
            Ambientes(6).bitLDVSGQ = DesfragmentaBit(Ambientes(6).varStatus, 12)
            Ambientes(6).bitLDVSAG = DesfragmentaBit(Ambientes(6).varStatus, 13)
            Ambientes(6).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 10)
            Ambientes(6).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 11)
            Ambientes(6).bitFalhaEvaporador3 = DesfragmentaBit(varAlarmes1, 12)

            'desfragmenta bits Corredor Túneis
            Ambientes(7).bitLigaEvap = DesfragmentaBit(Ambientes(7).varControle, 14)
            Ambientes(7).bitLigaVSSC = DesfragmentaBit(Ambientes(7).varControle, 15)
            Ambientes(7).bitLigaVSLL = DesfragmentaBit(Ambientes(7).varControle, 0)
            Ambientes(7).bitLigaVSGQ = DesfragmentaBit(Ambientes(7).varControle, 1)
            Ambientes(7).bitLigaVSAG = DesfragmentaBit(Ambientes(7).varControle, 2)
            Ambientes(7).bitMADegelo = DesfragmentaBit(Ambientes(7).varControle, 3)
            Ambientes(7).bitHabDegelo1 = DesfragmentaBit(Ambientes(7).varControle, 4)
            Ambientes(7).bitHabDegelo2 = DesfragmentaBit(Ambientes(7).varControle, 5)
            Ambientes(7).bitHabDegelo3 = DesfragmentaBit(Ambientes(7).varControle, 6)
            Ambientes(7).bitForceDegelo = DesfragmentaBit(Ambientes(7).varControle, 7)
            Ambientes(7).bitHabAmbiente = DesfragmentaBit(Ambientes(7).varControle, 8)
            Ambientes(7).bitMAEvap = DesfragmentaBit(Ambientes(7).varControle, 9)
            Ambientes(7).bitMAVSSC = DesfragmentaBit(Ambientes(7).varControle, 10)
            Ambientes(7).bitMAVSLL = DesfragmentaBit(Ambientes(7).varControle, 11)
            Ambientes(7).bitMAVSGQ = DesfragmentaBit(Ambientes(7).varControle, 12)
            Ambientes(7).bitMAVSAG = DesfragmentaBit(Ambientes(7).varControle, 13)
            Ambientes(7).bitDegelo = DesfragmentaBit(Ambientes(7).varStatus, 8)
            Ambientes(7).bitLDEvap = DesfragmentaBit(Ambientes(7).varStatus, 9)
            Ambientes(7).bitLDVSSC = DesfragmentaBit(Ambientes(7).varStatus, 10)
            Ambientes(7).bitLDVSLL = DesfragmentaBit(Ambientes(7).varStatus, 11)
            Ambientes(7).bitLDVSGQ = DesfragmentaBit(Ambientes(7).varStatus, 12)
            Ambientes(7).bitLDVSAG = DesfragmentaBit(Ambientes(7).varStatus, 13)
            Ambientes(7).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 13)
            Ambientes(7).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 14)
            Ambientes(7).bitFalhaEvaporador3 = DesfragmentaBit(varAlarmes1, 15)
            Ambientes(7).bitFalhaEvaporador4 = DesfragmentaBit(varAlarmes2, 0)

            'desfragmenta bits Docas Expedição
            Ambientes(8).bitLigaEvap = DesfragmentaBit(Ambientes(8).varControle, 14)
            Ambientes(8).bitLigaVSSC = DesfragmentaBit(Ambientes(8).varControle, 15)
            Ambientes(8).bitLigaVSLL = DesfragmentaBit(Ambientes(8).varControle, 0)
            Ambientes(8).bitLigaVSGQ = DesfragmentaBit(Ambientes(8).varControle, 1)
            Ambientes(8).bitLigaVSAG = DesfragmentaBit(Ambientes(8).varControle, 2)
            Ambientes(8).bitMADegelo = DesfragmentaBit(Ambientes(8).varControle, 3)
            Ambientes(8).bitHabDegelo1 = DesfragmentaBit(Ambientes(8).varControle, 4)
            Ambientes(8).bitHabDegelo2 = DesfragmentaBit(Ambientes(8).varControle, 5)
            Ambientes(8).bitHabDegelo3 = DesfragmentaBit(Ambientes(8).varControle, 6)
            Ambientes(8).bitForceDegelo = DesfragmentaBit(Ambientes(8).varControle, 7)
            Ambientes(8).bitHabAmbiente = DesfragmentaBit(Ambientes(8).varControle, 8)
            Ambientes(8).bitMAEvap = DesfragmentaBit(Ambientes(8).varControle, 9)
            Ambientes(8).bitMAVSSC = DesfragmentaBit(Ambientes(8).varControle, 10)
            Ambientes(8).bitMAVSLL = DesfragmentaBit(Ambientes(8).varControle, 11)
            Ambientes(8).bitMAVSGQ = DesfragmentaBit(Ambientes(8).varControle, 12)
            Ambientes(8).bitMAVSAG = DesfragmentaBit(Ambientes(8).varControle, 13)
            Ambientes(8).bitDegelo = DesfragmentaBit(Ambientes(8).varStatus, 8)
            Ambientes(8).bitLDEvap = DesfragmentaBit(Ambientes(8).varStatus, 9)
            Ambientes(8).bitLDVSSC = DesfragmentaBit(Ambientes(8).varStatus, 10)
            Ambientes(8).bitLDVSLL = DesfragmentaBit(Ambientes(8).varStatus, 11)
            Ambientes(8).bitLDVSGQ = DesfragmentaBit(Ambientes(8).varStatus, 12)
            Ambientes(8).bitLDVSAG = DesfragmentaBit(Ambientes(8).varStatus, 13)
            'Ambientes(8).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 13)
            'Ambientes(8).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 14)
            'Ambientes(8).bitFalhaEvaporador3 = DesfragmentaBit(varAlarmes1, 15)
            'Ambientes(8).bitFalhaEvaporador4 = DesfragmentaBit(varAlarmes2, 0)

            varStatusSadema1 = blcGeral(2451)
            varAlarmes1 = blcGeral(2479)
            varAlarmes2 = blcGeral(2480)
            varAlarmes3 = blcGeral(2481)
            varAlarmes4 = blcGeral(2482)
            bitValvulaLiquidoSeparador = DesfragmentaBit(varStatusSadema1, 0)

            lblTeste1.Text = varNivelSeparador & " mm"
            lblTeste2.Text = FormatPercent(varPosicaoICAD / 27648, 2)
            lblTeste3.Text = varPressaoBombaNH3 / 10 & " bar"
            lblDadosCP1.Text = Compressores(1).varCorrenteEletrica & " A - " & Compressores(1).varRotacao & " RPM"
            lblSuccaoCP1.Text = Compressores(1).varPressaoSuccao / 100 & " bar"
            lblDescargaCP1.Text = Compressores(1).varPressaoDescarga / 10 & " bar"
            lblDadosCP2.Text = Compressores(2).varCorrenteEletrica & " A - " & Compressores(2).varRotacao & " RPM"
            lblSuccaoCP2.Text = Compressores(2).varPressaoSuccao / 100 & " bar"
            lblDescargaCP2.Text = Compressores(2).varPressaoDescarga / 10 & " bar"
            lblDadosCP3.Text = Compressores(3).varCorrenteEletrica & " A - " & Compressores(3).varRotacao & " RPM"
            lblSuccaoCP3.Text = Compressores(3).varPressaoSuccao / 100 & " bar"
            lblDescargaCP3.Text = Compressores(3).varPressaoDescarga / 10 & " bar"

            If bitValvulaLiquidoSeparador Then
                imgLedInjecaoSeparadorON.Visible = True
                imgLedInjecaoSeparadorOFF.Visible = False
            Else
                imgLedInjecaoSeparadorON.Visible = False
                imgLedInjecaoSeparadorOFF.Visible = True
            End If
        End If

        If varAmbienteAtivo <> 0 And Ambientes(varAmbienteAtivo).varCLP = 1 Then
            slave = 1
            startRdReg = Ambientes(varAmbienteAtivo).varStartAdress
            numRdRegs = 71
            res = myProtocol.readMultipleRegisters(slave, startRdReg, readVals, numRdRegs)
            If res = BusProtocolErrors.FTALK_SUCCESS Then
                For j = 1 To numRdRegs
                    blcGeral(startRdReg - 1 + j) = readVals(j)
                Next
            End If

            'carrega os valores dos tempos decorridos de degelo indexadinho em Segundos
            varST = Ambientes(varAmbienteAtivo).varStartAdress

            Ambientes(varAmbienteAtivo).bitHabDegelo1 = DesfragmentaBit(blcGeral(varST), 1)
            Ambientes(varAmbienteAtivo).bitHabDegelo2 = DesfragmentaBit(blcGeral(varST), 2)
            Ambientes(varAmbienteAtivo).bitHabDegelo3 = DesfragmentaBit(blcGeral(varST), 3)

            varTempoDecorrido = vlrSemSinal(blcGeral(varST + 17), blcGeral(varST + 18))
            varTempoDecorrido = varTempoDecorrido \ 1000
            Ambientes(varAmbienteAtivo).varTempoRecolhimento = varTempoDecorrido

            varTempoDecorrido = vlrSemSinal(blcGeral(varST + 21), blcGeral(varST + 22))
            varTempoDecorrido = varTempoDecorrido \ 1000
            Ambientes(varAmbienteAtivo).varTempoGasQuente = varTempoDecorrido

            varTempoDecorrido = vlrSemSinal(blcGeral(varST + 23), blcGeral(varST + 24))
            varTempoDecorrido = varTempoDecorrido \ 1000
            Ambientes(varAmbienteAtivo).varTempoAgua = varTempoDecorrido

            varTempoDecorrido = vlrSemSinal(blcGeral(varST + 25), blcGeral(varST + 26))
            varTempoDecorrido = varTempoDecorrido \ 1000
            Ambientes(varAmbienteAtivo).varTempoGotejamento = varTempoDecorrido

            varTempoDecorrido = vlrSemSinal(blcGeral(varST + 27), blcGeral(varST + 28))
            varTempoDecorrido = varTempoDecorrido \ 1000
            Ambientes(varAmbienteAtivo).varTempoPreResfriamento = varTempoDecorrido

            varTempoDecorrido = vlrSemSinal(blcGeral(varST + 5), blcGeral(varST + 6))
            varTempoDecorrido = varTempoDecorrido \ 1000
            Ambientes(varAmbienteAtivo).varSPRecolhimento = varTempoDecorrido

            varTempoDecorrido = vlrSemSinal(blcGeral(varST + 9), blcGeral(varST + 10))
            varTempoDecorrido = varTempoDecorrido \ 1000
            Ambientes(varAmbienteAtivo).varSPGasQuente = varTempoDecorrido

            varTempoDecorrido = vlrSemSinal(blcGeral(varST + 11), blcGeral(varST + 12))
            varTempoDecorrido = varTempoDecorrido \ 1000
            Ambientes(varAmbienteAtivo).varSPAgua = varTempoDecorrido

            varTempoDecorrido = vlrSemSinal(blcGeral(varST + 13), blcGeral(varST + 14))
            varTempoDecorrido = varTempoDecorrido \ 1000
            Ambientes(varAmbienteAtivo).varSPGotejamento = varTempoDecorrido

            varTempoDecorrido = vlrSemSinal(blcGeral(varST + 15), blcGeral(varST + 16))
            varTempoDecorrido = varTempoDecorrido \ 1000
            Ambientes(varAmbienteAtivo).varSPPreResfriamento = varTempoDecorrido

            varTempoDecorrido = vlrSemSinal(blcGeral(varST + 29), blcGeral(varST + 30))
            varTempoDecorrido = varTempoDecorrido \ 1000
            Ambientes(varAmbienteAtivo).varHoraDegelo1 = varTempoDecorrido \ 60 \ 60
            Ambientes(varAmbienteAtivo).varMinutoDegelo1 = (varTempoDecorrido \ 60) Mod 60

            varTempoDecorrido = vlrSemSinal(blcGeral(varST + 31), blcGeral(varST + 32))
            varTempoDecorrido = varTempoDecorrido \ 1000
            Ambientes(varAmbienteAtivo).varHoraDegelo2 = varTempoDecorrido \ 60 \ 60
            Ambientes(varAmbienteAtivo).varMinutoDegelo2 = (varTempoDecorrido \ 60) Mod 60

            varTempoDecorrido = vlrSemSinal(blcGeral(varST + 33), blcGeral(varST + 34))
            varTempoDecorrido = varTempoDecorrido \ 1000
            Ambientes(varAmbienteAtivo).varHoraDegelo3 = varTempoDecorrido \ 60 \ 60
            Ambientes(varAmbienteAtivo).varMinutoDegelo3 = (varTempoDecorrido \ 60) Mod 60

        End If
    End Sub

    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        varContadorCommFault = 0
        varContadorCommOK = 0
        TimerCLP.Enabled = True
        Timer_CLP2.Enabled = True
        Timer_M251.Enabled = True
        TimerCompressor1.Enabled = True
        TimerCompressor2.Enabled = True
        TimerCompressor3.Enabled = True
        ConectarCLPSadema()
        ConectarMBComp1()
        ConectarMBComp2()
        ConectarMBComp3()
        ConectarCLP2()
        ConectarM251()

        Ambientes(1).varCLP = 1     'Tunel 12
        Ambientes(2).varCLP = 1     'Tunel 11
        Ambientes(3).varCLP = 1     'Tunel 10
        Ambientes(4).varCLP = 1     'Tunel 9
        Ambientes(5).varCLP = 1     'Tunel 8
        Ambientes(6).varCLP = 1     'Estocagem Congelados 3
        Ambientes(7).varCLP = 1     'Corredor Túneis
        Ambientes(8).varCLP = 1     'Expedição Docas
        Ambientes(11).varCLP = 2    'Tunel 4
        Ambientes(12).varCLP = 2    'Tunel 5
        Ambientes(13).varCLP = 2    'Tunel 6
        Ambientes(14).varCLP = 2    'Tunel 7
        Ambientes(15).varCLP = 2    'Estocagem 1
        Ambientes(16).varCLP = 2    'Estocagem 2
        Ambientes(21).varCLP = 3    'Camara Resfriamento Carcaças 1
        Ambientes(22).varCLP = 3    'Camara Resfriamento Carcaças 2
        Ambientes(23).varCLP = 3    'Camara Resfriamento Carcaças 3
        Ambientes(24).varCLP = 3    'Camara Resfriamento Carcaças 4
        Ambientes(25).varCLP = 3    'Camara Resfriamento Carcaças 5
        Ambientes(26).varCLP = 3    'Camara Resfriamento Carcaças 6
        Ambientes(27).varCLP = 3    'Camara Resfriamento Carcaças 7
        Ambientes(28).varCLP = 3    'Camara Pulmao
        Ambientes(29).varCLP = 3    'Tunel Miudos 1
        Ambientes(30).varCLP = 3    'Tunel Miudos 2
        Ambientes(31).varCLP = 3    'Tunel Miudos 3
        Ambientes(32).varCLP = 3    'Estocagem Congalados Miudos
        Ambientes(33).varCLP = 3    'Estocagem Resfriados
        Ambientes(34).varCLP = 3    'Embalagem Secundária
        Ambientes(35).varCLP = 3    'Desossa
        Ambientes(36).varCLP = 3    'Expedição Carne com Osso
        Ambientes(37).varCLP = 3    'Paletização
        Ambientes(38).varCLP = 3    'Expedição Caixaria


        'Para verificar os endereçamentos, vide programa dos respectivos CLPs
        Ambientes(1).varStartAdress = 305
        Ambientes(2).varStartAdress = 471
        Ambientes(3).varStartAdress = 637
        Ambientes(4).varStartAdress = 803
        Ambientes(5).varStartAdress = 969
        Ambientes(6).varStartAdress = 1136
        Ambientes(7).varStartAdress = 1373
        Ambientes(8).varStartAdress = 1662
        Ambientes(11).varStartAdress = 1
        Ambientes(12).varStartAdress = 21
        Ambientes(13).varStartAdress = 41
        Ambientes(14).varStartAdress = 61
        Ambientes(15).varStartAdress = 81
        Ambientes(16).varStartAdress = 101
        Ambientes(21).varStartAdress = 81
        Ambientes(22).varStartAdress = 101
        Ambientes(23).varStartAdress = 121
        Ambientes(24).varStartAdress = 141
        Ambientes(25).varStartAdress = 161
        Ambientes(26).varStartAdress = 181
        Ambientes(27).varStartAdress = 201
        Ambientes(28).varStartAdress = 221
        Ambientes(29).varStartAdress = 1
        Ambientes(30).varStartAdress = 21
        Ambientes(31).varStartAdress = 41
        Ambientes(32).varStartAdress = 61

        Ambientes(1).varADControle = 2456
        Ambientes(2).varADControle = 2457
        Ambientes(3).varADControle = 2458
        Ambientes(4).varADControle = 2459
        Ambientes(5).varADControle = 2460
        Ambientes(6).varADControle = 2461
        Ambientes(7).varADControle = 2462
        Ambientes(8).varADControle = 2463
        Ambientes(11).varADControle = 220
        Ambientes(12).varADControle = 221
        Ambientes(13).varADControle = 222
        Ambientes(14).varADControle = 223
        Ambientes(15).varADControle = 224
        Ambientes(16).varADControle = 225
        Ambientes(21).varADControle = 550
        Ambientes(22).varADControle = 551
        Ambientes(23).varADControle = 552
        Ambientes(24).varADControle = 553
        Ambientes(25).varADControle = 554
        Ambientes(26).varADControle = 555
        Ambientes(27).varADControle = 556
        Ambientes(28).varADControle = 558
        Ambientes(29).varADControle = 559
        Ambientes(30).varADControle = 560
        Ambientes(31).varADControle = 561
        Ambientes(32).varADControle = 562

        Ambientes(1).varADSetpoint = 2418
        Ambientes(2).varADSetpoint = 2419
        Ambientes(3).varADSetpoint = 2420
        Ambientes(4).varADSetpoint = 2421
        Ambientes(5).varADSetpoint = 2422
        Ambientes(6).varADSetpoint = 2423
        Ambientes(7).varADSetpoint = 2424
        Ambientes(8).varADSetpoint = 2425
        Ambientes(11).varADSetpoint = 140
        Ambientes(12).varADSetpoint = 141
        Ambientes(13).varADSetpoint = 142
        Ambientes(14).varADSetpoint = 143
        Ambientes(15).varADSetpoint = 144
        Ambientes(16).varADSetpoint = 145
        Ambientes(21).varADSetpoint = 350
        Ambientes(22).varADSetpoint = 351
        Ambientes(23).varADSetpoint = 352
        Ambientes(24).varADSetpoint = 353
        Ambientes(25).varADSetpoint = 354
        Ambientes(26).varADSetpoint = 355
        Ambientes(27).varADSetpoint = 356
        Ambientes(28).varADSetpoint = 358
        Ambientes(29).varADSetpoint = 359
        Ambientes(30).varADSetpoint = 360
        Ambientes(31).varADSetpoint = 361
        Ambientes(32).varADSetpoint = 362

        Ambientes(1).varADOffSet = 2433
        Ambientes(2).varADOffSet = 2434
        Ambientes(3).varADOffSet = 2435
        Ambientes(4).varADOffSet = 2436
        Ambientes(5).varADOffSet = 2437
        Ambientes(6).varADOffSet = 2438
        Ambientes(7).varADOffSet = 2439
        Ambientes(8).varADOffSet = 2440
        Ambientes(11).varADOffSet = 160
        Ambientes(12).varADOffSet = 161
        Ambientes(13).varADOffSet = 162
        Ambientes(14).varADOffSet = 163
        Ambientes(15).varADOffSet = 164
        Ambientes(16).varADOffSet = 165
        Ambientes(21).varADOffSet = 400
        Ambientes(22).varADOffSet = 401
        Ambientes(23).varADOffSet = 402
        Ambientes(24).varADOffSet = 403
        Ambientes(25).varADOffSet = 404
        Ambientes(26).varADOffSet = 405
        Ambientes(27).varADOffSet = 406
        Ambientes(28).varADOffSet = 408
        Ambientes(29).varADOffSet = 409
        Ambientes(30).varADOffSet = 410
        Ambientes(31).varADOffSet = 411
        Ambientes(32).varADOffSet = 412

        Ambientes(1).varADHora1 = Ambientes(1).varStartAdress + 29
        Ambientes(2).varADHora1 = Ambientes(2).varStartAdress + 29
        Ambientes(3).varADHora1 = Ambientes(3).varStartAdress + 29
        Ambientes(4).varADHora1 = Ambientes(4).varStartAdress + 29
        Ambientes(5).varADHora1 = Ambientes(5).varStartAdress + 29
        Ambientes(6).varADHora1 = Ambientes(6).varStartAdress + 29
        Ambientes(7).varADHora1 = Ambientes(7).varStartAdress + 29
        Ambientes(8).varADHora1 = Ambientes(8).varStartAdress + 29
        Ambientes(11).varADHora1 = Ambientes(11).varStartAdress + 10
        Ambientes(12).varADHora1 = Ambientes(12).varStartAdress + 10
        Ambientes(13).varADHora1 = Ambientes(13).varStartAdress + 10
        Ambientes(14).varADHora1 = Ambientes(14).varStartAdress + 10
        Ambientes(15).varADHora1 = Ambientes(15).varStartAdress + 10
        Ambientes(16).varADHora1 = Ambientes(16).varStartAdress + 10
        Ambientes(21).varADHora1 = Ambientes(21).varStartAdress + 10
        Ambientes(22).varADHora1 = Ambientes(22).varStartAdress + 10
        Ambientes(23).varADHora1 = Ambientes(23).varStartAdress + 10
        Ambientes(24).varADHora1 = Ambientes(24).varStartAdress + 10
        Ambientes(25).varADHora1 = Ambientes(25).varStartAdress + 10
        Ambientes(26).varADHora1 = Ambientes(26).varStartAdress + 10
        Ambientes(27).varADHora1 = Ambientes(27).varStartAdress + 10
        Ambientes(28).varADHora1 = Ambientes(28).varStartAdress + 10
        Ambientes(29).varADHora1 = Ambientes(29).varStartAdress + 10
        Ambientes(30).varADHora1 = Ambientes(30).varStartAdress + 10
        Ambientes(31).varADHora1 = Ambientes(31).varStartAdress + 10
        Ambientes(32).varADHora1 = Ambientes(32).varStartAdress + 10

        Ambientes(1).varADHora2 = Ambientes(1).varStartAdress + 31
        Ambientes(2).varADHora2 = Ambientes(2).varStartAdress + 31
        Ambientes(3).varADHora2 = Ambientes(3).varStartAdress + 31
        Ambientes(4).varADHora2 = Ambientes(4).varStartAdress + 31
        Ambientes(5).varADHora2 = Ambientes(5).varStartAdress + 31
        Ambientes(6).varADHora2 = Ambientes(6).varStartAdress + 31
        Ambientes(7).varADHora2 = Ambientes(7).varStartAdress + 31
        Ambientes(8).varADHora2 = Ambientes(8).varStartAdress + 31
        Ambientes(11).varADHora2 = Ambientes(11).varStartAdress + 11
        Ambientes(12).varADHora2 = Ambientes(12).varStartAdress + 11
        Ambientes(13).varADHora2 = Ambientes(13).varStartAdress + 11
        Ambientes(14).varADHora2 = Ambientes(14).varStartAdress + 11
        Ambientes(15).varADHora2 = Ambientes(15).varStartAdress + 11
        Ambientes(16).varADHora2 = Ambientes(16).varStartAdress + 11
        Ambientes(21).varADHora2 = Ambientes(21).varStartAdress + 11
        Ambientes(22).varADHora2 = Ambientes(22).varStartAdress + 11
        Ambientes(23).varADHora2 = Ambientes(23).varStartAdress + 11
        Ambientes(24).varADHora2 = Ambientes(24).varStartAdress + 11
        Ambientes(25).varADHora2 = Ambientes(25).varStartAdress + 11
        Ambientes(26).varADHora2 = Ambientes(26).varStartAdress + 11
        Ambientes(27).varADHora2 = Ambientes(27).varStartAdress + 11
        Ambientes(28).varADHora2 = Ambientes(28).varStartAdress + 11
        Ambientes(29).varADHora2 = Ambientes(29).varStartAdress + 11
        Ambientes(30).varADHora2 = Ambientes(30).varStartAdress + 11
        Ambientes(31).varADHora2 = Ambientes(31).varStartAdress + 11
        Ambientes(32).varADHora2 = Ambientes(32).varStartAdress + 11

        Ambientes(1).varADHora3 = Ambientes(1).varStartAdress + 33
        Ambientes(2).varADHora3 = Ambientes(2).varStartAdress + 33
        Ambientes(3).varADHora3 = Ambientes(3).varStartAdress + 33
        Ambientes(4).varADHora3 = Ambientes(4).varStartAdress + 33
        Ambientes(5).varADHora3 = Ambientes(5).varStartAdress + 33
        Ambientes(6).varADHora3 = Ambientes(6).varStartAdress + 33
        Ambientes(7).varADHora3 = Ambientes(7).varStartAdress + 33
        Ambientes(8).varADHora3 = Ambientes(8).varStartAdress + 33
        Ambientes(11).varADHora3 = Ambientes(11).varStartAdress + 12
        Ambientes(12).varADHora3 = Ambientes(12).varStartAdress + 12
        Ambientes(13).varADHora3 = Ambientes(13).varStartAdress + 12
        Ambientes(14).varADHora3 = Ambientes(14).varStartAdress + 12
        Ambientes(15).varADHora3 = Ambientes(15).varStartAdress + 12
        Ambientes(16).varADHora3 = Ambientes(16).varStartAdress + 12
        Ambientes(21).varADHora3 = Ambientes(21).varStartAdress + 12
        Ambientes(22).varADHora3 = Ambientes(22).varStartAdress + 12
        Ambientes(23).varADHora3 = Ambientes(23).varStartAdress + 12
        Ambientes(24).varADHora3 = Ambientes(24).varStartAdress + 12
        Ambientes(25).varADHora3 = Ambientes(25).varStartAdress + 12
        Ambientes(26).varADHora3 = Ambientes(26).varStartAdress + 12
        Ambientes(27).varADHora3 = Ambientes(27).varStartAdress + 12
        Ambientes(28).varADHora3 = Ambientes(28).varStartAdress + 12
        Ambientes(29).varADHora3 = Ambientes(29).varStartAdress + 12
        Ambientes(30).varADHora3 = Ambientes(30).varStartAdress + 12
        Ambientes(31).varADHora3 = Ambientes(31).varStartAdress + 12
        Ambientes(32).varADHora3 = Ambientes(32).varStartAdress + 12

        Ambientes(1).varADTRecolhimento = Ambientes(1).varStartAdress + 5
        Ambientes(2).varADTRecolhimento = Ambientes(2).varStartAdress + 5
        Ambientes(3).varADTRecolhimento = Ambientes(3).varStartAdress + 5
        Ambientes(4).varADTRecolhimento = Ambientes(4).varStartAdress + 5
        Ambientes(5).varADTRecolhimento = Ambientes(5).varStartAdress + 5
        Ambientes(6).varADTRecolhimento = Ambientes(6).varStartAdress + 5
        Ambientes(7).varADTRecolhimento = Ambientes(7).varStartAdress + 5
        Ambientes(8).varADTRecolhimento = Ambientes(8).varStartAdress + 5
        Ambientes(11).varADTRecolhimento = Ambientes(11).varStartAdress + 0
        Ambientes(12).varADTRecolhimento = Ambientes(12).varStartAdress + 0
        Ambientes(13).varADTRecolhimento = Ambientes(13).varStartAdress + 0
        Ambientes(14).varADTRecolhimento = Ambientes(14).varStartAdress + 0
        Ambientes(15).varADTRecolhimento = Ambientes(15).varStartAdress + 0
        Ambientes(16).varADTRecolhimento = Ambientes(16).varStartAdress + 0
        Ambientes(21).varADTRecolhimento = Ambientes(21).varStartAdress + 0
        Ambientes(22).varADTRecolhimento = Ambientes(22).varStartAdress + 0
        Ambientes(23).varADTRecolhimento = Ambientes(23).varStartAdress + 0
        Ambientes(24).varADTRecolhimento = Ambientes(24).varStartAdress + 0
        Ambientes(25).varADTRecolhimento = Ambientes(25).varStartAdress + 0
        Ambientes(26).varADTRecolhimento = Ambientes(26).varStartAdress + 0
        Ambientes(27).varADTRecolhimento = Ambientes(27).varStartAdress + 0
        Ambientes(28).varADTRecolhimento = Ambientes(28).varStartAdress + 0
        Ambientes(29).varADTRecolhimento = Ambientes(29).varStartAdress + 0
        Ambientes(30).varADTRecolhimento = Ambientes(30).varStartAdress + 0
        Ambientes(31).varADTRecolhimento = Ambientes(31).varStartAdress + 0
        Ambientes(32).varADTRecolhimento = Ambientes(32).varStartAdress + 0

        Ambientes(1).varADTGasQuente = Ambientes(1).varStartAdress + 9
        Ambientes(2).varADTGasQuente = Ambientes(2).varStartAdress + 9
        Ambientes(3).varADTGasQuente = Ambientes(3).varStartAdress + 9
        Ambientes(4).varADTGasQuente = Ambientes(4).varStartAdress + 9
        Ambientes(5).varADTGasQuente = Ambientes(5).varStartAdress + 9
        Ambientes(6).varADTGasQuente = Ambientes(6).varStartAdress + 9
        Ambientes(7).varADTGasQuente = Ambientes(7).varStartAdress + 9
        Ambientes(8).varADTGasQuente = Ambientes(8).varStartAdress + 9
        Ambientes(11).varADTGasQuente = Ambientes(11).varStartAdress + 1
        Ambientes(12).varADTGasQuente = Ambientes(12).varStartAdress + 1
        Ambientes(13).varADTGasQuente = Ambientes(13).varStartAdress + 1
        Ambientes(14).varADTGasQuente = Ambientes(14).varStartAdress + 1
        Ambientes(15).varADTGasQuente = Ambientes(15).varStartAdress + 1
        Ambientes(16).varADTGasQuente = Ambientes(16).varStartAdress + 1
        Ambientes(21).varADTGasQuente = Ambientes(21).varStartAdress + 1
        Ambientes(22).varADTGasQuente = Ambientes(22).varStartAdress + 1
        Ambientes(23).varADTGasQuente = Ambientes(23).varStartAdress + 1
        Ambientes(24).varADTGasQuente = Ambientes(24).varStartAdress + 1
        Ambientes(25).varADTGasQuente = Ambientes(25).varStartAdress + 1
        Ambientes(26).varADTGasQuente = Ambientes(26).varStartAdress + 1
        Ambientes(27).varADTGasQuente = Ambientes(27).varStartAdress + 1
        Ambientes(28).varADTGasQuente = Ambientes(28).varStartAdress + 1
        Ambientes(29).varADTGasQuente = Ambientes(29).varStartAdress + 1
        Ambientes(30).varADTGasQuente = Ambientes(30).varStartAdress + 1
        Ambientes(31).varADTGasQuente = Ambientes(31).varStartAdress + 1
        Ambientes(32).varADTGasQuente = Ambientes(32).varStartAdress + 1

        Ambientes(1).varADTAgua = Ambientes(1).varStartAdress + 11
        Ambientes(2).varADTAgua = Ambientes(2).varStartAdress + 11
        Ambientes(3).varADTAgua = Ambientes(3).varStartAdress + 11
        Ambientes(4).varADTAgua = Ambientes(4).varStartAdress + 11
        Ambientes(5).varADTAgua = Ambientes(5).varStartAdress + 11
        Ambientes(6).varADTAgua = Ambientes(6).varStartAdress + 11
        Ambientes(7).varADTAgua = Ambientes(7).varStartAdress + 11
        Ambientes(8).varADTAgua = Ambientes(8).varStartAdress + 11
        Ambientes(11).varADTAgua = Ambientes(11).varStartAdress + 2
        Ambientes(12).varADTAgua = Ambientes(12).varStartAdress + 2
        Ambientes(13).varADTAgua = Ambientes(13).varStartAdress + 2
        Ambientes(14).varADTAgua = Ambientes(14).varStartAdress + 2
        Ambientes(15).varADTAgua = Ambientes(15).varStartAdress + 2
        Ambientes(16).varADTAgua = Ambientes(16).varStartAdress + 2
        Ambientes(21).varADTAgua = Ambientes(21).varStartAdress + 2
        Ambientes(22).varADTAgua = Ambientes(22).varStartAdress + 2
        Ambientes(23).varADTAgua = Ambientes(23).varStartAdress + 2
        Ambientes(24).varADTAgua = Ambientes(24).varStartAdress + 2
        Ambientes(25).varADTAgua = Ambientes(25).varStartAdress + 2
        Ambientes(26).varADTAgua = Ambientes(26).varStartAdress + 2
        Ambientes(27).varADTAgua = Ambientes(27).varStartAdress + 2
        Ambientes(28).varADTAgua = Ambientes(28).varStartAdress + 2
        Ambientes(29).varADTAgua = Ambientes(29).varStartAdress + 2
        Ambientes(30).varADTAgua = Ambientes(30).varStartAdress + 2
        Ambientes(31).varADTAgua = Ambientes(31).varStartAdress + 2
        Ambientes(32).varADTAgua = Ambientes(32).varStartAdress + 2

        Ambientes(1).varADTGotejamento = Ambientes(1).varStartAdress + 13
        Ambientes(2).varADTGotejamento = Ambientes(2).varStartAdress + 13
        Ambientes(3).varADTGotejamento = Ambientes(3).varStartAdress + 13
        Ambientes(4).varADTGotejamento = Ambientes(4).varStartAdress + 13
        Ambientes(5).varADTGotejamento = Ambientes(5).varStartAdress + 13
        Ambientes(6).varADTGotejamento = Ambientes(6).varStartAdress + 13
        Ambientes(7).varADTGotejamento = Ambientes(7).varStartAdress + 13
        Ambientes(8).varADTGotejamento = Ambientes(8).varStartAdress + 13
        Ambientes(11).varADTGotejamento = Ambientes(11).varStartAdress + 3
        Ambientes(12).varADTGotejamento = Ambientes(12).varStartAdress + 3
        Ambientes(13).varADTGotejamento = Ambientes(13).varStartAdress + 3
        Ambientes(14).varADTGotejamento = Ambientes(14).varStartAdress + 3
        Ambientes(15).varADTGotejamento = Ambientes(15).varStartAdress + 3
        Ambientes(16).varADTGotejamento = Ambientes(16).varStartAdress + 3
        Ambientes(21).varADTGotejamento = Ambientes(21).varStartAdress + 3
        Ambientes(22).varADTGotejamento = Ambientes(22).varStartAdress + 3
        Ambientes(23).varADTGotejamento = Ambientes(23).varStartAdress + 3
        Ambientes(24).varADTGotejamento = Ambientes(24).varStartAdress + 3
        Ambientes(25).varADTGotejamento = Ambientes(25).varStartAdress + 3
        Ambientes(26).varADTGotejamento = Ambientes(26).varStartAdress + 3
        Ambientes(27).varADTGotejamento = Ambientes(27).varStartAdress + 3
        Ambientes(28).varADTGotejamento = Ambientes(28).varStartAdress + 3
        Ambientes(29).varADTGotejamento = Ambientes(29).varStartAdress + 3
        Ambientes(30).varADTGotejamento = Ambientes(30).varStartAdress + 3
        Ambientes(31).varADTGotejamento = Ambientes(31).varStartAdress + 3
        Ambientes(32).varADTGotejamento = Ambientes(32).varStartAdress + 3

        Ambientes(1).varADTPreResfriamento = Ambientes(1).varStartAdress + 15
        Ambientes(2).varADTPreResfriamento = Ambientes(2).varStartAdress + 15
        Ambientes(3).varADTPreResfriamento = Ambientes(3).varStartAdress + 15
        Ambientes(4).varADTPreResfriamento = Ambientes(4).varStartAdress + 15
        Ambientes(5).varADTPreResfriamento = Ambientes(5).varStartAdress + 15
        Ambientes(6).varADTPreResfriamento = Ambientes(6).varStartAdress + 15
        Ambientes(7).varADTPreResfriamento = Ambientes(7).varStartAdress + 15
        Ambientes(8).varADTPreResfriamento = Ambientes(8).varStartAdress + 15
        Ambientes(11).varADTPreResfriamento = Ambientes(11).varStartAdress + 4
        Ambientes(12).varADTPreResfriamento = Ambientes(12).varStartAdress + 4
        Ambientes(13).varADTPreResfriamento = Ambientes(13).varStartAdress + 4
        Ambientes(14).varADTPreResfriamento = Ambientes(14).varStartAdress + 4
        Ambientes(15).varADTPreResfriamento = Ambientes(15).varStartAdress + 4
        Ambientes(16).varADTPreResfriamento = Ambientes(16).varStartAdress + 4
        Ambientes(21).varADTPreResfriamento = Ambientes(21).varStartAdress + 4
        Ambientes(22).varADTPreResfriamento = Ambientes(22).varStartAdress + 4
        Ambientes(23).varADTPreResfriamento = Ambientes(23).varStartAdress + 4
        Ambientes(24).varADTPreResfriamento = Ambientes(24).varStartAdress + 4
        Ambientes(25).varADTPreResfriamento = Ambientes(25).varStartAdress + 4
        Ambientes(26).varADTPreResfriamento = Ambientes(26).varStartAdress + 4
        Ambientes(27).varADTPreResfriamento = Ambientes(27).varStartAdress + 4
        Ambientes(28).varADTPreResfriamento = Ambientes(28).varStartAdress + 4
        Ambientes(29).varADTPreResfriamento = Ambientes(29).varStartAdress + 4
        Ambientes(30).varADTPreResfriamento = Ambientes(30).varStartAdress + 4
        Ambientes(31).varADTPreResfriamento = Ambientes(31).varStartAdress + 4
        Ambientes(32).varADTPreResfriamento = Ambientes(32).varStartAdress + 4

        'Tipo 1 = Tunel 2xEvap com 2xMotores cada
        'Tipo 2 = Estocagem congelados com degelo agua 3xEvap com 3xMotores cada
        'Tipo 3 = Corredor Tuneis degelo sem agua 4xEvap 2xMotor cada
        Ambientes(1).varTipoAmbiente = 1
        Ambientes(2).varTipoAmbiente = 1
        Ambientes(3).varTipoAmbiente = 1
        Ambientes(4).varTipoAmbiente = 1
        Ambientes(5).varTipoAmbiente = 1
        Ambientes(6).varTipoAmbiente = 1
        Ambientes(7).varTipoAmbiente = 1
        Ambientes(8).varTipoAmbiente = 1
        Ambientes(11).varTipoAmbiente = 1
        Ambientes(12).varTipoAmbiente = 1
        Ambientes(13).varTipoAmbiente = 1
        Ambientes(14).varTipoAmbiente = 1
        Ambientes(15).varTipoAmbiente = 1
        Ambientes(16).varTipoAmbiente = 1
        Ambientes(21).varTipoAmbiente = 1
        Ambientes(22).varTipoAmbiente = 1
        Ambientes(23).varTipoAmbiente = 1
        Ambientes(24).varTipoAmbiente = 1
        Ambientes(25).varTipoAmbiente = 1
        Ambientes(26).varTipoAmbiente = 1
        Ambientes(27).varTipoAmbiente = 1
        Ambientes(28).varTipoAmbiente = 1
        Ambientes(29).varTipoAmbiente = 1
        Ambientes(30).varTipoAmbiente = 1
        Ambientes(31).varTipoAmbiente = 1
        Ambientes(32).varTipoAmbiente = 1

        MenuPrincipal.Focus()
    End Sub

    Private Sub TimerCompressor1_Tick(sender As Object, e As EventArgs) Handles TimerCompressor1.Tick
        Dim readVals(100) As Int16
        Dim slave, startRdReg, numRdRegs As Int16
        Dim res As Int32

        If Not MBComp1.isOpen() Then
            If Not ConectarMBComp1() Then
                Exit Sub
            End If
        End If

        slave = 1
        startRdReg = 3018
        numRdRegs = 30
        res = MBComp1.readMultipleRegisters(slave, startRdReg, readVals, numRdRegs)
        If res = BusProtocolErrors.FTALK_SUCCESS Then
            Compressores(1).varPressaoSuccao = readVals(1)
            Compressores(1).varPressaoDescarga = readVals(2)
            Compressores(1).varPressaoOleo = readVals(3)
            Compressores(1).varPressaoFiltroOleo = readVals(4)
            Compressores(1).varTemperaturaSuccao = readVals(5)
            Compressores(1).varTemperaturaDescarga = readVals(6)
            Compressores(1).varTemperaturaOleo = readVals(7)
            Compressores(1).varTemperaturaSeparador = readVals(8)
            Compressores(1).varPressaoIntermediario = readVals(9)
            Compressores(1).varTemperaturaIntermediario = readVals(10)
            Compressores(1).varCorrenteEletrica = readVals(12)
        End If

        slave = 1
        startRdReg = 3262
        numRdRegs = 4
        res = MBComp1.readMultipleRegisters(slave, startRdReg, readVals, numRdRegs)
        If res = BusProtocolErrors.FTALK_SUCCESS Then
            Compressores(1).varStatus = readVals(1)
            Compressores(1).varRotacao = readVals(3)
        End If
    End Sub

    Private Sub TimerCompressor2_Tick(sender As Object, e As EventArgs) Handles TimerCompressor2.Tick
        Dim readVals(100) As Int16
        Dim slave, startRdReg, numRdRegs As Int16
        Dim res As Int32

        If Not MBComp2.isOpen() Then
            If Not ConectarMBComp2() Then
                Exit Sub
            End If
        End If

        slave = 1
        startRdReg = 3018
        numRdRegs = 30
        res = MBComp2.readMultipleRegisters(slave, startRdReg, readVals, numRdRegs)
        If res = BusProtocolErrors.FTALK_SUCCESS Then
            Compressores(2).varPressaoSuccao = readVals(1)
            Compressores(2).varPressaoDescarga = readVals(2)
            Compressores(2).varPressaoOleo = readVals(3)
            Compressores(2).varPressaoFiltroOleo = readVals(4)
            Compressores(2).varTemperaturaSuccao = readVals(5)
            Compressores(2).varTemperaturaDescarga = readVals(6)
            Compressores(2).varTemperaturaOleo = readVals(7)
            Compressores(2).varTemperaturaSeparador = readVals(8)
            Compressores(2).varPressaoIntermediario = readVals(9)
            Compressores(2).varTemperaturaIntermediario = readVals(10)
            Compressores(2).varCorrenteEletrica = readVals(12)
        End If

        slave = 1
        startRdReg = 3262
        numRdRegs = 4
        res = MBComp2.readMultipleRegisters(slave, startRdReg, readVals, numRdRegs)
        If res = BusProtocolErrors.FTALK_SUCCESS Then
            Compressores(2).varStatus = readVals(1)
            Compressores(2).varRotacao = readVals(3)
        End If
    End Sub

    Private Sub TimerCompressor3_Tick(sender As Object, e As EventArgs) Handles TimerCompressor3.Tick
        Dim readVals(100) As Int16
        Dim slave, startRdReg, numRdRegs As Int16
        Dim res As Int32

        If Not MBComp3.isOpen() Then
            If Not ConectarMBComp3() Then
                Exit Sub
            End If
        End If

        slave = 1
        startRdReg = 3018
        numRdRegs = 30
        res = MBComp3.readMultipleRegisters(slave, startRdReg, readVals, numRdRegs)
        If res = BusProtocolErrors.FTALK_SUCCESS Then
            Compressores(3).varPressaoSuccao = readVals(1)
            Compressores(3).varPressaoDescarga = readVals(2)
            Compressores(3).varPressaoOleo = readVals(3)
            Compressores(3).varPressaoFiltroOleo = readVals(4)
            Compressores(3).varTemperaturaSuccao = readVals(5)
            Compressores(3).varTemperaturaDescarga = readVals(6)
            Compressores(3).varTemperaturaOleo = readVals(7)
            Compressores(3).varTemperaturaSeparador = readVals(8)
            Compressores(3).varPressaoIntermediario = readVals(9)
            Compressores(3).varTemperaturaIntermediario = readVals(10)
            Compressores(3).varCorrenteEletrica = readVals(12)
        End If

        slave = 1
        startRdReg = 3262
        numRdRegs = 4
        res = MBComp3.readMultipleRegisters(slave, startRdReg, readVals, numRdRegs)
        If res = BusProtocolErrors.FTALK_SUCCESS Then
            Compressores(3).varStatus = readVals(1)
            Compressores(3).varRotacao = readVals(3)
        End If
    End Sub

    Private Sub Timer_CLP2_Tick(sender As Object, e As EventArgs) Handles Timer_CLP2.Tick
        Dim readVals(150), i, j As Int16
        Dim slave, startRdReg, numRdRegs, varST As Int16
        Dim res As Int32

        If Not CLP_2.isOpen() Then
            If Not ConectarCLP2() Then
                Exit Sub
            End If
        End If

        slave = 1
        startRdReg = 120
        numRdRegs = 120
        res = CLP_2.readMultipleRegisters(slave, startRdReg, readVals, numRdRegs)
        If res = BusProtocolErrors.FTALK_SUCCESS Then
            For i = 1 To numRdRegs
                blcGeral2(startRdReg - 1 + i) = readVals(i)
            Next

            Ambientes(11).varTemperatura = blcGeral2(120)
            Ambientes(12).varTemperatura = blcGeral2(121)
            Ambientes(13).varTemperatura = blcGeral2(122)
            Ambientes(14).varTemperatura = blcGeral2(123)
            Ambientes(15).varTemperatura = blcGeral2(124)
            Ambientes(16).varTemperatura = blcGeral2(125)

            Ambientes(11).varSetPoint = blcGeral2(140)
            Ambientes(12).varSetPoint = blcGeral2(141)
            Ambientes(13).varSetPoint = blcGeral2(142)
            Ambientes(14).varSetPoint = blcGeral2(143)
            Ambientes(15).varSetPoint = blcGeral2(144)
            Ambientes(16).varSetPoint = blcGeral2(145)

            Ambientes(11).varOffSet = blcGeral2(160)
            Ambientes(12).varOffSet = blcGeral2(161)
            Ambientes(13).varOffSet = blcGeral2(162)
            Ambientes(14).varOffSet = blcGeral2(163)
            Ambientes(15).varOffSet = blcGeral2(164)
            Ambientes(16).varOffSet = blcGeral2(165)

            Ambientes(11).varStatusAmbiente = blcGeral2(180)
            Ambientes(12).varStatusAmbiente = blcGeral2(181)
            Ambientes(13).varStatusAmbiente = blcGeral2(182)
            Ambientes(14).varStatusAmbiente = blcGeral2(183)
            Ambientes(15).varStatusAmbiente = blcGeral2(184)
            Ambientes(16).varStatusAmbiente = blcGeral2(185)

            Ambientes(11).varStatus = blcGeral2(200)
            Ambientes(12).varStatus = blcGeral2(201)
            Ambientes(13).varStatus = blcGeral2(202)
            Ambientes(14).varStatus = blcGeral2(203)
            Ambientes(15).varStatus = blcGeral2(204)
            Ambientes(16).varStatus = blcGeral2(205)

            Ambientes(11).varControle = blcGeral2(220)
            Ambientes(12).varControle = blcGeral2(221)
            Ambientes(13).varControle = blcGeral2(222)
            Ambientes(14).varControle = blcGeral2(223)
            Ambientes(15).varControle = blcGeral2(224)
            Ambientes(16).varControle = blcGeral2(225)

            'desfragmenta bits tunel 4
            Ambientes(11).bitLigaEvap = DesfragmentaBit(Ambientes(11).varControle, 14)
            Ambientes(11).bitLigaVSSC = DesfragmentaBit(Ambientes(11).varControle, 15)
            Ambientes(11).bitLigaVSLL = DesfragmentaBit(Ambientes(11).varControle, 0)
            Ambientes(11).bitLigaVSGQ = DesfragmentaBit(Ambientes(11).varControle, 1)
            Ambientes(11).bitLigaVSAG = DesfragmentaBit(Ambientes(11).varControle, 2)
            Ambientes(11).bitMADegelo = DesfragmentaBit(Ambientes(11).varControle, 3)
            Ambientes(11).bitHabDegelo1 = DesfragmentaBit(Ambientes(11).varControle, 4)
            Ambientes(11).bitHabDegelo2 = DesfragmentaBit(Ambientes(11).varControle, 5)
            Ambientes(11).bitHabDegelo3 = DesfragmentaBit(Ambientes(11).varControle, 6)
            Ambientes(11).bitForceDegelo = DesfragmentaBit(Ambientes(11).varControle, 7)
            Ambientes(11).bitHabAmbiente = DesfragmentaBit(Ambientes(11).varControle, 8)
            Ambientes(11).bitMAEvap = DesfragmentaBit(Ambientes(11).varControle, 9)
            Ambientes(11).bitMAVSSC = DesfragmentaBit(Ambientes(11).varControle, 10)
            Ambientes(11).bitMAVSLL = DesfragmentaBit(Ambientes(11).varControle, 11)
            Ambientes(11).bitMAVSGQ = DesfragmentaBit(Ambientes(11).varControle, 12)
            Ambientes(11).bitMAVSAG = DesfragmentaBit(Ambientes(11).varControle, 13)
            Ambientes(11).bitDegelo = DesfragmentaBit(Ambientes(11).varStatus, 8)
            Ambientes(11).bitLDEvap = DesfragmentaBit(Ambientes(11).varStatus, 9)
            Ambientes(11).bitLDVSSC = DesfragmentaBit(Ambientes(11).varStatus, 10)
            Ambientes(11).bitLDVSLL = DesfragmentaBit(Ambientes(11).varStatus, 11)
            Ambientes(11).bitLDVSGQ = DesfragmentaBit(Ambientes(11).varStatus, 12)
            Ambientes(11).bitLDVSAG = DesfragmentaBit(Ambientes(11).varStatus, 13)
            'Ambientes(11).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 0)
            'Ambientes(11).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 1)

            'desfragmenta bits tunel 5
            Ambientes(12).bitLigaEvap = DesfragmentaBit(Ambientes(12).varControle, 14)
            Ambientes(12).bitLigaVSSC = DesfragmentaBit(Ambientes(12).varControle, 15)
            Ambientes(12).bitLigaVSLL = DesfragmentaBit(Ambientes(12).varControle, 0)
            Ambientes(12).bitLigaVSGQ = DesfragmentaBit(Ambientes(12).varControle, 1)
            Ambientes(12).bitLigaVSAG = DesfragmentaBit(Ambientes(12).varControle, 2)
            Ambientes(12).bitMADegelo = DesfragmentaBit(Ambientes(12).varControle, 3)
            Ambientes(12).bitHabDegelo1 = DesfragmentaBit(Ambientes(12).varControle, 4)
            Ambientes(12).bitHabDegelo2 = DesfragmentaBit(Ambientes(12).varControle, 5)
            Ambientes(12).bitHabDegelo3 = DesfragmentaBit(Ambientes(12).varControle, 6)
            Ambientes(12).bitForceDegelo = DesfragmentaBit(Ambientes(12).varControle, 7)
            Ambientes(12).bitHabAmbiente = DesfragmentaBit(Ambientes(12).varControle, 8)
            Ambientes(12).bitMAEvap = DesfragmentaBit(Ambientes(12).varControle, 9)
            Ambientes(12).bitMAVSSC = DesfragmentaBit(Ambientes(12).varControle, 10)
            Ambientes(12).bitMAVSLL = DesfragmentaBit(Ambientes(12).varControle, 11)
            Ambientes(12).bitMAVSGQ = DesfragmentaBit(Ambientes(12).varControle, 12)
            Ambientes(12).bitMAVSAG = DesfragmentaBit(Ambientes(12).varControle, 13)
            Ambientes(12).bitDegelo = DesfragmentaBit(Ambientes(12).varStatus, 8)
            Ambientes(12).bitLDEvap = DesfragmentaBit(Ambientes(12).varStatus, 9)
            Ambientes(12).bitLDVSSC = DesfragmentaBit(Ambientes(12).varStatus, 10)
            Ambientes(12).bitLDVSLL = DesfragmentaBit(Ambientes(12).varStatus, 11)
            Ambientes(12).bitLDVSGQ = DesfragmentaBit(Ambientes(12).varStatus, 12)
            Ambientes(12).bitLDVSAG = DesfragmentaBit(Ambientes(12).varStatus, 13)
            'Ambientes(11).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 0)
            'Ambientes(11).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 1)

            'desfragmenta bits tunel 6
            Ambientes(13).bitLigaEvap = DesfragmentaBit(Ambientes(13).varControle, 14)
            Ambientes(13).bitLigaVSSC = DesfragmentaBit(Ambientes(13).varControle, 15)
            Ambientes(13).bitLigaVSLL = DesfragmentaBit(Ambientes(13).varControle, 0)
            Ambientes(13).bitLigaVSGQ = DesfragmentaBit(Ambientes(13).varControle, 1)
            Ambientes(13).bitLigaVSAG = DesfragmentaBit(Ambientes(13).varControle, 2)
            Ambientes(13).bitMADegelo = DesfragmentaBit(Ambientes(13).varControle, 3)
            Ambientes(13).bitHabDegelo1 = DesfragmentaBit(Ambientes(13).varControle, 4)
            Ambientes(13).bitHabDegelo2 = DesfragmentaBit(Ambientes(13).varControle, 5)
            Ambientes(13).bitHabDegelo3 = DesfragmentaBit(Ambientes(13).varControle, 6)
            Ambientes(13).bitForceDegelo = DesfragmentaBit(Ambientes(13).varControle, 7)
            Ambientes(13).bitHabAmbiente = DesfragmentaBit(Ambientes(13).varControle, 8)
            Ambientes(13).bitMAEvap = DesfragmentaBit(Ambientes(13).varControle, 9)
            Ambientes(13).bitMAVSSC = DesfragmentaBit(Ambientes(13).varControle, 10)
            Ambientes(13).bitMAVSLL = DesfragmentaBit(Ambientes(13).varControle, 11)
            Ambientes(13).bitMAVSGQ = DesfragmentaBit(Ambientes(13).varControle, 12)
            Ambientes(13).bitMAVSAG = DesfragmentaBit(Ambientes(13).varControle, 13)
            Ambientes(13).bitDegelo = DesfragmentaBit(Ambientes(13).varStatus, 8)
            Ambientes(13).bitLDEvap = DesfragmentaBit(Ambientes(13).varStatus, 9)
            Ambientes(13).bitLDVSSC = DesfragmentaBit(Ambientes(13).varStatus, 10)
            Ambientes(13).bitLDVSLL = DesfragmentaBit(Ambientes(13).varStatus, 11)
            Ambientes(13).bitLDVSGQ = DesfragmentaBit(Ambientes(13).varStatus, 12)
            Ambientes(13).bitLDVSAG = DesfragmentaBit(Ambientes(13).varStatus, 13)
            'Ambientes(11).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 0)
            'Ambientes(11).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 1)

            'desfragmenta bits tunel 7
            Ambientes(14).bitLigaEvap = DesfragmentaBit(Ambientes(14).varControle, 14)
            Ambientes(14).bitLigaVSSC = DesfragmentaBit(Ambientes(14).varControle, 15)
            Ambientes(14).bitLigaVSLL = DesfragmentaBit(Ambientes(14).varControle, 0)
            Ambientes(14).bitLigaVSGQ = DesfragmentaBit(Ambientes(14).varControle, 1)
            Ambientes(14).bitLigaVSAG = DesfragmentaBit(Ambientes(14).varControle, 2)
            Ambientes(14).bitMADegelo = DesfragmentaBit(Ambientes(14).varControle, 3)
            Ambientes(14).bitHabDegelo1 = DesfragmentaBit(Ambientes(14).varControle, 4)
            Ambientes(14).bitHabDegelo2 = DesfragmentaBit(Ambientes(14).varControle, 5)
            Ambientes(14).bitHabDegelo3 = DesfragmentaBit(Ambientes(14).varControle, 6)
            Ambientes(14).bitForceDegelo = DesfragmentaBit(Ambientes(14).varControle, 7)
            Ambientes(14).bitHabAmbiente = DesfragmentaBit(Ambientes(14).varControle, 8)
            Ambientes(14).bitMAEvap = DesfragmentaBit(Ambientes(14).varControle, 9)
            Ambientes(14).bitMAVSSC = DesfragmentaBit(Ambientes(14).varControle, 10)
            Ambientes(14).bitMAVSLL = DesfragmentaBit(Ambientes(14).varControle, 11)
            Ambientes(14).bitMAVSGQ = DesfragmentaBit(Ambientes(14).varControle, 12)
            Ambientes(14).bitMAVSAG = DesfragmentaBit(Ambientes(14).varControle, 13)
            Ambientes(14).bitDegelo = DesfragmentaBit(Ambientes(14).varStatus, 8)
            Ambientes(14).bitLDEvap = DesfragmentaBit(Ambientes(14).varStatus, 9)
            Ambientes(14).bitLDVSSC = DesfragmentaBit(Ambientes(14).varStatus, 10)
            Ambientes(14).bitLDVSLL = DesfragmentaBit(Ambientes(14).varStatus, 11)
            Ambientes(14).bitLDVSGQ = DesfragmentaBit(Ambientes(14).varStatus, 12)
            Ambientes(14).bitLDVSAG = DesfragmentaBit(Ambientes(14).varStatus, 13)
            'Ambientes(11).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 0)
            'Ambientes(11).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 1)

            'desfragmenta bits estocagem 1
            Ambientes(15).bitLigaEvap = DesfragmentaBit(Ambientes(15).varControle, 14)
            Ambientes(15).bitLigaVSSC = DesfragmentaBit(Ambientes(15).varControle, 15)
            Ambientes(15).bitLigaVSLL = DesfragmentaBit(Ambientes(15).varControle, 0)
            Ambientes(15).bitLigaVSGQ = DesfragmentaBit(Ambientes(15).varControle, 1)
            Ambientes(15).bitLigaVSAG = DesfragmentaBit(Ambientes(15).varControle, 2)
            Ambientes(15).bitMADegelo = DesfragmentaBit(Ambientes(15).varControle, 3)
            Ambientes(15).bitHabDegelo1 = DesfragmentaBit(Ambientes(15).varControle, 4)
            Ambientes(15).bitHabDegelo2 = DesfragmentaBit(Ambientes(15).varControle, 5)
            Ambientes(15).bitHabDegelo3 = DesfragmentaBit(Ambientes(15).varControle, 6)
            Ambientes(15).bitForceDegelo = DesfragmentaBit(Ambientes(15).varControle, 7)
            Ambientes(15).bitHabAmbiente = DesfragmentaBit(Ambientes(15).varControle, 8)
            Ambientes(15).bitMAEvap = DesfragmentaBit(Ambientes(15).varControle, 9)
            Ambientes(15).bitMAVSSC = DesfragmentaBit(Ambientes(15).varControle, 10)
            Ambientes(15).bitMAVSLL = DesfragmentaBit(Ambientes(15).varControle, 11)
            Ambientes(15).bitMAVSGQ = DesfragmentaBit(Ambientes(15).varControle, 12)
            Ambientes(15).bitMAVSAG = DesfragmentaBit(Ambientes(15).varControle, 13)
            Ambientes(15).bitDegelo = DesfragmentaBit(Ambientes(15).varStatus, 8)
            Ambientes(15).bitLDEvap = DesfragmentaBit(Ambientes(15).varStatus, 9)
            Ambientes(15).bitLDVSSC = DesfragmentaBit(Ambientes(15).varStatus, 10)
            Ambientes(15).bitLDVSLL = DesfragmentaBit(Ambientes(15).varStatus, 11)
            Ambientes(15).bitLDVSGQ = DesfragmentaBit(Ambientes(15).varStatus, 12)
            Ambientes(15).bitLDVSAG = DesfragmentaBit(Ambientes(15).varStatus, 13)
            'Ambientes(11).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 0)
            'Ambientes(11).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 1)

            'desfragmenta bits estocagem 2
            Ambientes(16).bitLigaEvap = DesfragmentaBit(Ambientes(16).varControle, 14)
            Ambientes(16).bitLigaVSSC = DesfragmentaBit(Ambientes(16).varControle, 15)
            Ambientes(16).bitLigaVSLL = DesfragmentaBit(Ambientes(16).varControle, 0)
            Ambientes(16).bitLigaVSGQ = DesfragmentaBit(Ambientes(16).varControle, 1)
            Ambientes(16).bitLigaVSAG = DesfragmentaBit(Ambientes(16).varControle, 2)
            Ambientes(16).bitMADegelo = DesfragmentaBit(Ambientes(16).varControle, 3)
            Ambientes(16).bitHabDegelo1 = DesfragmentaBit(Ambientes(16).varControle, 4)
            Ambientes(16).bitHabDegelo2 = DesfragmentaBit(Ambientes(16).varControle, 5)
            Ambientes(16).bitHabDegelo3 = DesfragmentaBit(Ambientes(16).varControle, 6)
            Ambientes(16).bitForceDegelo = DesfragmentaBit(Ambientes(16).varControle, 7)
            Ambientes(16).bitHabAmbiente = DesfragmentaBit(Ambientes(16).varControle, 8)
            Ambientes(16).bitMAEvap = DesfragmentaBit(Ambientes(16).varControle, 9)
            Ambientes(16).bitMAVSSC = DesfragmentaBit(Ambientes(16).varControle, 10)
            Ambientes(16).bitMAVSLL = DesfragmentaBit(Ambientes(16).varControle, 11)
            Ambientes(16).bitMAVSGQ = DesfragmentaBit(Ambientes(16).varControle, 12)
            Ambientes(16).bitMAVSAG = DesfragmentaBit(Ambientes(16).varControle, 13)
            Ambientes(16).bitDegelo = DesfragmentaBit(Ambientes(16).varStatus, 8)
            Ambientes(16).bitLDEvap = DesfragmentaBit(Ambientes(16).varStatus, 9)
            Ambientes(16).bitLDVSSC = DesfragmentaBit(Ambientes(16).varStatus, 10)
            Ambientes(16).bitLDVSLL = DesfragmentaBit(Ambientes(16).varStatus, 11)
            Ambientes(16).bitLDVSGQ = DesfragmentaBit(Ambientes(16).varStatus, 12)
            Ambientes(16).bitLDVSAG = DesfragmentaBit(Ambientes(16).varStatus, 13)
            'Ambientes(11).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 0)
            'Ambientes(11).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 1)
        End If

        If varAmbienteAtivo <> 0 And Ambientes(varAmbienteAtivo).varCLP = 2 Then
            slave = 1
            startRdReg = Ambientes(varAmbienteAtivo).varStartAdress
            numRdRegs = 19
            res = CLP_2.readMultipleRegisters(slave, startRdReg, readVals, numRdRegs)
            If res = BusProtocolErrors.FTALK_SUCCESS Then
                For j = 1 To numRdRegs
                    blcGeral2(startRdReg - 1 + j) = readVals(j)
                Next
            End If

            'bits de habilita degelo
            varST = Ambientes(varAmbienteAtivo).varADControle
            Ambientes(varAmbienteAtivo).bitHabDegelo1 = DesfragmentaBit(blcGeral2(varST), 4)
            Ambientes(varAmbienteAtivo).bitHabDegelo2 = DesfragmentaBit(blcGeral2(varST), 5)
            Ambientes(varAmbienteAtivo).bitHabDegelo3 = DesfragmentaBit(blcGeral2(varST), 6)

            'carrega os valores dos tempos decorridos de degelo indexadinho em Segundos
            varST = Ambientes(varAmbienteAtivo).varStartAdress
            Ambientes(varAmbienteAtivo).varSPRecolhimento = blcGeral2(varST + 0)
            Ambientes(varAmbienteAtivo).varSPGasQuente = blcGeral2(varST + 1)
            Ambientes(varAmbienteAtivo).varSPAgua = blcGeral2(varST + 2)
            Ambientes(varAmbienteAtivo).varSPGotejamento = blcGeral2(varST + 3)
            Ambientes(varAmbienteAtivo).varSPPreResfriamento = blcGeral2(varST + 4)

            Ambientes(varAmbienteAtivo).varTempoRecolhimento = blcGeral2(varST + 5)
            Ambientes(varAmbienteAtivo).varTempoGasQuente = blcGeral2(varST + 6)
            Ambientes(varAmbienteAtivo).varTempoAgua = blcGeral2(varST + 7)
            Ambientes(varAmbienteAtivo).varTempoGotejamento = blcGeral2(varST + 8)
            Ambientes(varAmbienteAtivo).varTempoPreResfriamento = blcGeral2(varST + 9)

            Ambientes(varAmbienteAtivo).varHoraDegelo1 = blcGeral2(varST + 10) \ 100
            Ambientes(varAmbienteAtivo).varMinutoDegelo1 = blcGeral2(varST + 10) Mod 100

            Ambientes(varAmbienteAtivo).varHoraDegelo2 = blcGeral2(varST + 11) \ 100
            Ambientes(varAmbienteAtivo).varMinutoDegelo2 = blcGeral2(varST + 11) Mod 100

            Ambientes(varAmbienteAtivo).varHoraDegelo3 = blcGeral2(varST + 12) \ 100
            Ambientes(varAmbienteAtivo).varMinutoDegelo3 = blcGeral2(varST + 12) Mod 100
        End If
    End Sub

    Private Sub Timer_M251_Tick(sender As Object, e As EventArgs) Handles Timer_M251.Tick
        Dim readVals(150), i, j As Int16
        Dim slave, startRdReg, numRdRegs, varST As Int16
        Dim res As Int32

        If Not M251.isOpen() Then
            If Not ConectarM251() Then
                Exit Sub
            End If
        End If

        slave = 1
        startRdReg = 300
        numRdRegs = 100
        res = M251.readMultipleRegisters(slave, startRdReg, readVals, numRdRegs)
        If res = BusProtocolErrors.FTALK_SUCCESS Then
            For i = 1 To numRdRegs
                blcGeral3(startRdReg - 1 + i) = readVals(i)
            Next

            Ambientes(21).varTemperatura = blcGeral3(300)   'Camara1
            Ambientes(22).varTemperatura = blcGeral3(301)   'Camara2
            Ambientes(23).varTemperatura = blcGeral3(302)   'Camara3
            Ambientes(24).varTemperatura = blcGeral3(303)   'Camara4
            Ambientes(25).varTemperatura = blcGeral3(304)   'Camara5
            Ambientes(26).varTemperatura = blcGeral3(305)   'Camara6
            Ambientes(27).varTemperatura = blcGeral3(306)   'Camara7
            Ambientes(28).varTemperatura = blcGeral3(308)   'Pulmao
            Ambientes(29).varTemperatura = blcGeral3(309)   'Tunel1
            Ambientes(30).varTemperatura = blcGeral3(310)   'Tunel2
            Ambientes(31).varTemperatura = blcGeral3(311)   'Tunel3
            Ambientes(32).varTemperatura = blcGeral3(307)   'Estocagem Miudos
            Ambientes(33).varTemperatura = blcGeral3(312)   'Estocagem Resfriados
            Ambientes(34).varTemperatura = blcGeral3(313)   'Embalagem Secundaria
            Ambientes(35).varTemperatura = blcGeral3(314)   'Desossa
            Ambientes(36).varTemperatura = blcGeral3(315)   'Expedição Carne com Osso
            Ambientes(37).varTemperatura = blcGeral3(316)   'Paletização
            Ambientes(38).varTemperatura = blcGeral3(317)   'Expedição Caixaria
            Ambientes(39).varTemperatura = blcGeral3(318)   'Embalagem Miúdos
            Ambientes(40).varTemperatura = blcGeral3(319)   'Bucharia Limpa
            Ambientes(41).varTemperatura = blcGeral3(320)   'Bucharia Suja
            Ambientes(42).varTemperatura = blcGeral3(321)   'Sala Miúdos
            Ambientes(43).varTemperatura = blcGeral3(322)   'Camara Resfriamento Miúdos
            Ambientes(44).varTemperatura = blcGeral3(323)   'Camara Resfriamento Estomago

            Ambientes(21).varSetPoint = blcGeral3(350)
            Ambientes(22).varSetPoint = blcGeral3(351)
            Ambientes(23).varSetPoint = blcGeral3(352)
            Ambientes(24).varSetPoint = blcGeral3(353)
            Ambientes(25).varSetPoint = blcGeral3(354)
            Ambientes(26).varSetPoint = blcGeral3(355)
            Ambientes(27).varSetPoint = blcGeral3(356)
            Ambientes(28).varSetPoint = blcGeral3(358)
            Ambientes(29).varSetPoint = blcGeral3(359)
            Ambientes(30).varSetPoint = blcGeral3(360)
            Ambientes(31).varSetPoint = blcGeral3(361)
            Ambientes(32).varSetPoint = blcGeral3(357)
        End If

        slave = 1
        startRdReg = 400
        numRdRegs = 100
        res = M251.readMultipleRegisters(slave, startRdReg, readVals, numRdRegs)
        If res = BusProtocolErrors.FTALK_SUCCESS Then
            For i = 1 To numRdRegs
                blcGeral3(startRdReg - 1 + i) = readVals(i)
            Next

            Ambientes(21).varOffSet = blcGeral3(400)
            Ambientes(22).varOffSet = blcGeral3(401)
            Ambientes(23).varOffSet = blcGeral3(402)
            Ambientes(24).varOffSet = blcGeral3(403)
            Ambientes(25).varOffSet = blcGeral3(404)
            Ambientes(26).varOffSet = blcGeral3(405)
            Ambientes(27).varOffSet = blcGeral3(406)
            Ambientes(28).varOffSet = blcGeral3(408)
            Ambientes(29).varOffSet = blcGeral3(409)
            Ambientes(30).varOffSet = blcGeral3(410)
            Ambientes(31).varOffSet = blcGeral3(411)
            Ambientes(32).varOffSet = blcGeral3(407)

            Ambientes(21).varStatusAmbiente = blcGeral3(450)
            Ambientes(22).varStatusAmbiente = blcGeral3(451)
            Ambientes(23).varStatusAmbiente = blcGeral3(452)
            Ambientes(24).varStatusAmbiente = blcGeral3(453)
            Ambientes(25).varStatusAmbiente = blcGeral3(454)
            Ambientes(26).varStatusAmbiente = blcGeral3(455)
            Ambientes(27).varStatusAmbiente = blcGeral3(456)
            Ambientes(28).varStatusAmbiente = blcGeral3(458)
            Ambientes(29).varStatusAmbiente = blcGeral3(459)
            Ambientes(30).varStatusAmbiente = blcGeral3(460)
            Ambientes(31).varStatusAmbiente = blcGeral3(461)
            Ambientes(32).varStatusAmbiente = blcGeral3(457)
        End If

        slave = 1
        startRdReg = 500
        numRdRegs = 100
        res = M251.readMultipleRegisters(slave, startRdReg, readVals, numRdRegs)
        If res = BusProtocolErrors.FTALK_SUCCESS Then
            For i = 1 To numRdRegs
                blcGeral3(startRdReg - 1 + i) = readVals(i)
            Next

            Ambientes(21).varStatus = blcGeral3(500)
            Ambientes(22).varStatus = blcGeral3(501)
            Ambientes(23).varStatus = blcGeral3(502)
            Ambientes(24).varStatus = blcGeral3(503)
            Ambientes(25).varStatus = blcGeral3(504)
            Ambientes(26).varStatus = blcGeral3(505)
            Ambientes(27).varStatus = blcGeral3(506)
            Ambientes(28).varStatus = blcGeral3(508)
            Ambientes(29).varStatus = blcGeral3(509)
            Ambientes(30).varStatus = blcGeral3(510)
            Ambientes(31).varStatus = blcGeral3(511)
            Ambientes(32).varStatus = blcGeral3(507)

            Ambientes(21).varControle = blcGeral3(550)
            Ambientes(22).varControle = blcGeral3(551)
            Ambientes(23).varControle = blcGeral3(552)
            Ambientes(24).varControle = blcGeral3(553)
            Ambientes(25).varControle = blcGeral3(554)
            Ambientes(26).varControle = blcGeral3(555)
            Ambientes(27).varControle = blcGeral3(556)
            Ambientes(28).varControle = blcGeral3(558)
            Ambientes(29).varControle = blcGeral3(559)
            Ambientes(30).varControle = blcGeral3(560)
            Ambientes(31).varControle = blcGeral3(561)
            Ambientes(32).varControle = blcGeral3(557)

            'desfragmenta bits camara resfriamento carcaça 1
            Ambientes(21).bitLigaEvap = DesfragmentaBit(Ambientes(21).varControle, 14)
            Ambientes(21).bitLigaVSSC = DesfragmentaBit(Ambientes(21).varControle, 15)
            Ambientes(21).bitLigaVSLL = DesfragmentaBit(Ambientes(21).varControle, 0)
            Ambientes(21).bitLigaVSGQ = DesfragmentaBit(Ambientes(21).varControle, 1)
            Ambientes(21).bitLigaVSAG = DesfragmentaBit(Ambientes(21).varControle, 2)
            Ambientes(21).bitMADegelo = DesfragmentaBit(Ambientes(21).varControle, 3)
            Ambientes(21).bitHabDegelo1 = DesfragmentaBit(Ambientes(21).varControle, 4)
            Ambientes(21).bitHabDegelo2 = DesfragmentaBit(Ambientes(21).varControle, 5)
            Ambientes(21).bitHabDegelo3 = DesfragmentaBit(Ambientes(21).varControle, 6)
            Ambientes(21).bitForceDegelo = DesfragmentaBit(Ambientes(21).varControle, 7)
            Ambientes(21).bitHabAmbiente = DesfragmentaBit(Ambientes(21).varControle, 8)
            Ambientes(21).bitMAEvap = DesfragmentaBit(Ambientes(21).varControle, 9)
            Ambientes(21).bitMAVSSC = DesfragmentaBit(Ambientes(21).varControle, 10)
            Ambientes(21).bitMAVSLL = DesfragmentaBit(Ambientes(21).varControle, 11)
            Ambientes(21).bitMAVSGQ = DesfragmentaBit(Ambientes(21).varControle, 12)
            Ambientes(21).bitMAVSAG = DesfragmentaBit(Ambientes(21).varControle, 13)
            Ambientes(21).bitDegelo = DesfragmentaBit(Ambientes(21).varStatus, 8)
            Ambientes(21).bitLDEvap = DesfragmentaBit(Ambientes(21).varStatus, 9)
            Ambientes(21).bitLDVSSC = DesfragmentaBit(Ambientes(21).varStatus, 10)
            Ambientes(21).bitLDVSLL = DesfragmentaBit(Ambientes(21).varStatus, 11)
            Ambientes(21).bitLDVSGQ = DesfragmentaBit(Ambientes(21).varStatus, 12)
            Ambientes(21).bitLDVSAG = DesfragmentaBit(Ambientes(21).varStatus, 13)
            'Ambientes(21).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 0)
            'Ambientes(21).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 1)

            'desfragmenta bits camara resfriamento carcaca 2
            Ambientes(22).bitLigaEvap = DesfragmentaBit(Ambientes(22).varControle, 14)
            Ambientes(22).bitLigaVSSC = DesfragmentaBit(Ambientes(22).varControle, 15)
            Ambientes(22).bitLigaVSLL = DesfragmentaBit(Ambientes(22).varControle, 0)
            Ambientes(22).bitLigaVSGQ = DesfragmentaBit(Ambientes(22).varControle, 1)
            Ambientes(22).bitLigaVSAG = DesfragmentaBit(Ambientes(22).varControle, 2)
            Ambientes(22).bitMADegelo = DesfragmentaBit(Ambientes(22).varControle, 3)
            Ambientes(22).bitHabDegelo1 = DesfragmentaBit(Ambientes(22).varControle, 4)
            Ambientes(22).bitHabDegelo2 = DesfragmentaBit(Ambientes(22).varControle, 5)
            Ambientes(22).bitHabDegelo3 = DesfragmentaBit(Ambientes(22).varControle, 6)
            Ambientes(22).bitForceDegelo = DesfragmentaBit(Ambientes(22).varControle, 7)
            Ambientes(22).bitHabAmbiente = DesfragmentaBit(Ambientes(22).varControle, 8)
            Ambientes(22).bitMAEvap = DesfragmentaBit(Ambientes(22).varControle, 9)
            Ambientes(22).bitMAVSSC = DesfragmentaBit(Ambientes(22).varControle, 10)
            Ambientes(22).bitMAVSLL = DesfragmentaBit(Ambientes(22).varControle, 11)
            Ambientes(22).bitMAVSGQ = DesfragmentaBit(Ambientes(22).varControle, 12)
            Ambientes(22).bitMAVSAG = DesfragmentaBit(Ambientes(22).varControle, 13)
            Ambientes(22).bitDegelo = DesfragmentaBit(Ambientes(22).varStatus, 8)
            Ambientes(22).bitLDEvap = DesfragmentaBit(Ambientes(22).varStatus, 9)
            Ambientes(22).bitLDVSSC = DesfragmentaBit(Ambientes(22).varStatus, 10)
            Ambientes(22).bitLDVSLL = DesfragmentaBit(Ambientes(22).varStatus, 11)
            Ambientes(22).bitLDVSGQ = DesfragmentaBit(Ambientes(22).varStatus, 12)
            Ambientes(22).bitLDVSAG = DesfragmentaBit(Ambientes(22).varStatus, 13)
            'Ambientes(22).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 0)
            'Ambientes(22).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 1)

            'desfragmenta bits camara resfriamento de carcaca 3
            Ambientes(23).bitLigaEvap = DesfragmentaBit(Ambientes(23).varControle, 14)
            Ambientes(23).bitLigaVSSC = DesfragmentaBit(Ambientes(23).varControle, 15)
            Ambientes(23).bitLigaVSLL = DesfragmentaBit(Ambientes(23).varControle, 0)
            Ambientes(23).bitLigaVSGQ = DesfragmentaBit(Ambientes(23).varControle, 1)
            Ambientes(23).bitLigaVSAG = DesfragmentaBit(Ambientes(23).varControle, 2)
            Ambientes(23).bitMADegelo = DesfragmentaBit(Ambientes(23).varControle, 3)
            Ambientes(23).bitHabDegelo1 = DesfragmentaBit(Ambientes(23).varControle, 4)
            Ambientes(23).bitHabDegelo2 = DesfragmentaBit(Ambientes(23).varControle, 5)
            Ambientes(23).bitHabDegelo3 = DesfragmentaBit(Ambientes(23).varControle, 6)
            Ambientes(23).bitForceDegelo = DesfragmentaBit(Ambientes(23).varControle, 7)
            Ambientes(23).bitHabAmbiente = DesfragmentaBit(Ambientes(23).varControle, 8)
            Ambientes(23).bitMAEvap = DesfragmentaBit(Ambientes(23).varControle, 9)
            Ambientes(23).bitMAVSSC = DesfragmentaBit(Ambientes(23).varControle, 10)
            Ambientes(23).bitMAVSLL = DesfragmentaBit(Ambientes(23).varControle, 11)
            Ambientes(23).bitMAVSGQ = DesfragmentaBit(Ambientes(23).varControle, 12)
            Ambientes(23).bitMAVSAG = DesfragmentaBit(Ambientes(23).varControle, 13)
            Ambientes(23).bitDegelo = DesfragmentaBit(Ambientes(23).varStatus, 8)
            Ambientes(23).bitLDEvap = DesfragmentaBit(Ambientes(23).varStatus, 9)
            Ambientes(23).bitLDVSSC = DesfragmentaBit(Ambientes(23).varStatus, 10)
            Ambientes(23).bitLDVSLL = DesfragmentaBit(Ambientes(23).varStatus, 11)
            Ambientes(23).bitLDVSGQ = DesfragmentaBit(Ambientes(23).varStatus, 12)
            Ambientes(23).bitLDVSAG = DesfragmentaBit(Ambientes(23).varStatus, 13)
            'Ambientes(23).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 0)
            'Ambientes(23).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 1)

            'desfragmenta bits camara resfriamento carcaca 4
            Ambientes(24).bitLigaEvap = DesfragmentaBit(Ambientes(24).varControle, 14)
            Ambientes(24).bitLigaVSSC = DesfragmentaBit(Ambientes(24).varControle, 15)
            Ambientes(24).bitLigaVSLL = DesfragmentaBit(Ambientes(24).varControle, 0)
            Ambientes(24).bitLigaVSGQ = DesfragmentaBit(Ambientes(24).varControle, 1)
            Ambientes(24).bitLigaVSAG = DesfragmentaBit(Ambientes(24).varControle, 2)
            Ambientes(24).bitMADegelo = DesfragmentaBit(Ambientes(24).varControle, 3)
            Ambientes(24).bitHabDegelo1 = DesfragmentaBit(Ambientes(24).varControle, 4)
            Ambientes(24).bitHabDegelo2 = DesfragmentaBit(Ambientes(24).varControle, 5)
            Ambientes(24).bitHabDegelo3 = DesfragmentaBit(Ambientes(24).varControle, 6)
            Ambientes(24).bitForceDegelo = DesfragmentaBit(Ambientes(24).varControle, 7)
            Ambientes(24).bitHabAmbiente = DesfragmentaBit(Ambientes(24).varControle, 8)
            Ambientes(24).bitMAEvap = DesfragmentaBit(Ambientes(24).varControle, 9)
            Ambientes(24).bitMAVSSC = DesfragmentaBit(Ambientes(24).varControle, 10)
            Ambientes(24).bitMAVSLL = DesfragmentaBit(Ambientes(24).varControle, 11)
            Ambientes(24).bitMAVSGQ = DesfragmentaBit(Ambientes(24).varControle, 12)
            Ambientes(24).bitMAVSAG = DesfragmentaBit(Ambientes(24).varControle, 13)
            Ambientes(24).bitDegelo = DesfragmentaBit(Ambientes(24).varStatus, 8)
            Ambientes(24).bitLDEvap = DesfragmentaBit(Ambientes(24).varStatus, 9)
            Ambientes(24).bitLDVSSC = DesfragmentaBit(Ambientes(24).varStatus, 10)
            Ambientes(24).bitLDVSLL = DesfragmentaBit(Ambientes(24).varStatus, 11)
            Ambientes(24).bitLDVSGQ = DesfragmentaBit(Ambientes(24).varStatus, 12)
            Ambientes(24).bitLDVSAG = DesfragmentaBit(Ambientes(24).varStatus, 13)
            'Ambientes(24).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 0)
            'Ambientes(24).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 1)

            'desfragmenta bits camara resfriamento carcaca 5
            Ambientes(25).bitLigaEvap = DesfragmentaBit(Ambientes(25).varControle, 14)
            Ambientes(25).bitLigaVSSC = DesfragmentaBit(Ambientes(25).varControle, 15)
            Ambientes(25).bitLigaVSLL = DesfragmentaBit(Ambientes(25).varControle, 0)
            Ambientes(25).bitLigaVSGQ = DesfragmentaBit(Ambientes(25).varControle, 1)
            Ambientes(25).bitLigaVSAG = DesfragmentaBit(Ambientes(25).varControle, 2)
            Ambientes(25).bitMADegelo = DesfragmentaBit(Ambientes(25).varControle, 3)
            Ambientes(25).bitHabDegelo1 = DesfragmentaBit(Ambientes(25).varControle, 4)
            Ambientes(25).bitHabDegelo2 = DesfragmentaBit(Ambientes(25).varControle, 5)
            Ambientes(25).bitHabDegelo3 = DesfragmentaBit(Ambientes(25).varControle, 6)
            Ambientes(25).bitForceDegelo = DesfragmentaBit(Ambientes(25).varControle, 7)
            Ambientes(25).bitHabAmbiente = DesfragmentaBit(Ambientes(25).varControle, 8)
            Ambientes(25).bitMAEvap = DesfragmentaBit(Ambientes(25).varControle, 9)
            Ambientes(25).bitMAVSSC = DesfragmentaBit(Ambientes(25).varControle, 10)
            Ambientes(25).bitMAVSLL = DesfragmentaBit(Ambientes(25).varControle, 11)
            Ambientes(25).bitMAVSGQ = DesfragmentaBit(Ambientes(25).varControle, 12)
            Ambientes(25).bitMAVSAG = DesfragmentaBit(Ambientes(25).varControle, 13)
            Ambientes(25).bitDegelo = DesfragmentaBit(Ambientes(25).varStatus, 8)
            Ambientes(25).bitLDEvap = DesfragmentaBit(Ambientes(25).varStatus, 9)
            Ambientes(25).bitLDVSSC = DesfragmentaBit(Ambientes(25).varStatus, 10)
            Ambientes(25).bitLDVSLL = DesfragmentaBit(Ambientes(25).varStatus, 11)
            Ambientes(25).bitLDVSGQ = DesfragmentaBit(Ambientes(25).varStatus, 12)
            Ambientes(25).bitLDVSAG = DesfragmentaBit(Ambientes(25).varStatus, 13)
            'Ambientes(25).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 0)
            'Ambientes(25).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 1)

            'desfragmenta bits camara resfriamento carcaca 6
            Ambientes(26).bitLigaEvap = DesfragmentaBit(Ambientes(26).varControle, 14)
            Ambientes(26).bitLigaVSSC = DesfragmentaBit(Ambientes(26).varControle, 15)
            Ambientes(26).bitLigaVSLL = DesfragmentaBit(Ambientes(26).varControle, 0)
            Ambientes(26).bitLigaVSGQ = DesfragmentaBit(Ambientes(26).varControle, 1)
            Ambientes(26).bitLigaVSAG = DesfragmentaBit(Ambientes(26).varControle, 2)
            Ambientes(26).bitMADegelo = DesfragmentaBit(Ambientes(26).varControle, 3)
            Ambientes(26).bitHabDegelo1 = DesfragmentaBit(Ambientes(26).varControle, 4)
            Ambientes(26).bitHabDegelo2 = DesfragmentaBit(Ambientes(26).varControle, 5)
            Ambientes(26).bitHabDegelo3 = DesfragmentaBit(Ambientes(26).varControle, 6)
            Ambientes(26).bitForceDegelo = DesfragmentaBit(Ambientes(26).varControle, 7)
            Ambientes(26).bitHabAmbiente = DesfragmentaBit(Ambientes(26).varControle, 8)
            Ambientes(26).bitMAEvap = DesfragmentaBit(Ambientes(26).varControle, 9)
            Ambientes(26).bitMAVSSC = DesfragmentaBit(Ambientes(26).varControle, 10)
            Ambientes(26).bitMAVSLL = DesfragmentaBit(Ambientes(26).varControle, 11)
            Ambientes(26).bitMAVSGQ = DesfragmentaBit(Ambientes(26).varControle, 12)
            Ambientes(26).bitMAVSAG = DesfragmentaBit(Ambientes(26).varControle, 13)
            Ambientes(26).bitDegelo = DesfragmentaBit(Ambientes(26).varStatus, 8)
            Ambientes(26).bitLDEvap = DesfragmentaBit(Ambientes(26).varStatus, 9)
            Ambientes(26).bitLDVSSC = DesfragmentaBit(Ambientes(26).varStatus, 10)
            Ambientes(26).bitLDVSLL = DesfragmentaBit(Ambientes(26).varStatus, 11)
            Ambientes(26).bitLDVSGQ = DesfragmentaBit(Ambientes(26).varStatus, 12)
            Ambientes(26).bitLDVSAG = DesfragmentaBit(Ambientes(26).varStatus, 13)
            'Ambientes(26).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 0)
            'Ambientes(26).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 1)

            'desfragmenta bits camara resfriamento carcaca 7
            Ambientes(27).bitLigaEvap = DesfragmentaBit(Ambientes(27).varControle, 14)
            Ambientes(27).bitLigaVSSC = DesfragmentaBit(Ambientes(27).varControle, 15)
            Ambientes(27).bitLigaVSLL = DesfragmentaBit(Ambientes(27).varControle, 0)
            Ambientes(27).bitLigaVSGQ = DesfragmentaBit(Ambientes(27).varControle, 1)
            Ambientes(27).bitLigaVSAG = DesfragmentaBit(Ambientes(27).varControle, 2)
            Ambientes(27).bitMADegelo = DesfragmentaBit(Ambientes(27).varControle, 3)
            Ambientes(27).bitHabDegelo1 = DesfragmentaBit(Ambientes(27).varControle, 4)
            Ambientes(27).bitHabDegelo2 = DesfragmentaBit(Ambientes(27).varControle, 5)
            Ambientes(27).bitHabDegelo3 = DesfragmentaBit(Ambientes(27).varControle, 6)
            Ambientes(27).bitForceDegelo = DesfragmentaBit(Ambientes(27).varControle, 7)
            Ambientes(27).bitHabAmbiente = DesfragmentaBit(Ambientes(27).varControle, 8)
            Ambientes(27).bitMAEvap = DesfragmentaBit(Ambientes(27).varControle, 9)
            Ambientes(27).bitMAVSSC = DesfragmentaBit(Ambientes(27).varControle, 10)
            Ambientes(27).bitMAVSLL = DesfragmentaBit(Ambientes(27).varControle, 11)
            Ambientes(27).bitMAVSGQ = DesfragmentaBit(Ambientes(27).varControle, 12)
            Ambientes(27).bitMAVSAG = DesfragmentaBit(Ambientes(27).varControle, 13)
            Ambientes(27).bitDegelo = DesfragmentaBit(Ambientes(27).varStatus, 8)
            Ambientes(27).bitLDEvap = DesfragmentaBit(Ambientes(27).varStatus, 9)
            Ambientes(27).bitLDVSSC = DesfragmentaBit(Ambientes(27).varStatus, 10)
            Ambientes(27).bitLDVSLL = DesfragmentaBit(Ambientes(27).varStatus, 11)
            Ambientes(27).bitLDVSGQ = DesfragmentaBit(Ambientes(27).varStatus, 12)
            Ambientes(27).bitLDVSAG = DesfragmentaBit(Ambientes(27).varStatus, 13)
            'Ambientes(27).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 0)
            'Ambientes(27).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 1)

            'desfragmenta bits camara pulmao
            Ambientes(28).bitLigaEvap = DesfragmentaBit(Ambientes(28).varControle, 14)
            Ambientes(28).bitLigaVSSC = DesfragmentaBit(Ambientes(28).varControle, 15)
            Ambientes(28).bitLigaVSLL = DesfragmentaBit(Ambientes(28).varControle, 0)
            Ambientes(28).bitLigaVSGQ = DesfragmentaBit(Ambientes(28).varControle, 1)
            Ambientes(28).bitLigaVSAG = DesfragmentaBit(Ambientes(28).varControle, 2)
            Ambientes(28).bitMADegelo = DesfragmentaBit(Ambientes(28).varControle, 3)
            Ambientes(28).bitHabDegelo1 = DesfragmentaBit(Ambientes(28).varControle, 4)
            Ambientes(28).bitHabDegelo2 = DesfragmentaBit(Ambientes(28).varControle, 5)
            Ambientes(28).bitHabDegelo3 = DesfragmentaBit(Ambientes(28).varControle, 6)
            Ambientes(28).bitForceDegelo = DesfragmentaBit(Ambientes(28).varControle, 7)
            Ambientes(28).bitHabAmbiente = DesfragmentaBit(Ambientes(28).varControle, 8)
            Ambientes(28).bitMAEvap = DesfragmentaBit(Ambientes(28).varControle, 9)
            Ambientes(28).bitMAVSSC = DesfragmentaBit(Ambientes(28).varControle, 10)
            Ambientes(28).bitMAVSLL = DesfragmentaBit(Ambientes(28).varControle, 11)
            Ambientes(28).bitMAVSGQ = DesfragmentaBit(Ambientes(28).varControle, 12)
            Ambientes(28).bitMAVSAG = DesfragmentaBit(Ambientes(28).varControle, 13)
            Ambientes(28).bitDegelo = DesfragmentaBit(Ambientes(28).varStatus, 8)
            Ambientes(28).bitLDEvap = DesfragmentaBit(Ambientes(28).varStatus, 9)
            Ambientes(28).bitLDVSSC = DesfragmentaBit(Ambientes(28).varStatus, 10)
            Ambientes(28).bitLDVSLL = DesfragmentaBit(Ambientes(28).varStatus, 11)
            Ambientes(28).bitLDVSGQ = DesfragmentaBit(Ambientes(28).varStatus, 12)
            Ambientes(28).bitLDVSAG = DesfragmentaBit(Ambientes(28).varStatus, 13)
            'Ambientes(28).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 0)
            'Ambientes(28).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 1)

            'desfragmenta bits Tunel 1 Miudos
            Ambientes(29).bitLigaEvap = DesfragmentaBit(Ambientes(29).varControle, 14)
            Ambientes(29).bitLigaVSSC = DesfragmentaBit(Ambientes(29).varControle, 15)
            Ambientes(29).bitLigaVSLL = DesfragmentaBit(Ambientes(29).varControle, 0)
            Ambientes(29).bitLigaVSGQ = DesfragmentaBit(Ambientes(29).varControle, 1)
            Ambientes(29).bitLigaVSAG = DesfragmentaBit(Ambientes(29).varControle, 2)
            Ambientes(29).bitMADegelo = DesfragmentaBit(Ambientes(29).varControle, 3)
            Ambientes(29).bitHabDegelo1 = DesfragmentaBit(Ambientes(29).varControle, 4)
            Ambientes(29).bitHabDegelo2 = DesfragmentaBit(Ambientes(29).varControle, 5)
            Ambientes(29).bitHabDegelo3 = DesfragmentaBit(Ambientes(29).varControle, 6)
            Ambientes(29).bitForceDegelo = DesfragmentaBit(Ambientes(29).varControle, 7)
            Ambientes(29).bitHabAmbiente = DesfragmentaBit(Ambientes(29).varControle, 8)
            Ambientes(29).bitMAEvap = DesfragmentaBit(Ambientes(29).varControle, 9)
            Ambientes(29).bitMAVSSC = DesfragmentaBit(Ambientes(29).varControle, 10)
            Ambientes(29).bitMAVSLL = DesfragmentaBit(Ambientes(29).varControle, 11)
            Ambientes(29).bitMAVSGQ = DesfragmentaBit(Ambientes(29).varControle, 12)
            Ambientes(29).bitMAVSAG = DesfragmentaBit(Ambientes(29).varControle, 13)
            Ambientes(29).bitDegelo = DesfragmentaBit(Ambientes(29).varStatus, 8)
            Ambientes(29).bitLDEvap = DesfragmentaBit(Ambientes(29).varStatus, 9)
            Ambientes(29).bitLDVSSC = DesfragmentaBit(Ambientes(29).varStatus, 10)
            Ambientes(29).bitLDVSLL = DesfragmentaBit(Ambientes(29).varStatus, 11)
            Ambientes(29).bitLDVSGQ = DesfragmentaBit(Ambientes(29).varStatus, 12)
            Ambientes(29).bitLDVSAG = DesfragmentaBit(Ambientes(29).varStatus, 13)
            'Ambientes(29).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 0)
            'Ambientes(29).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 1)

            'desfragmenta bits Tunel 2 Miudos
            Ambientes(30).bitLigaEvap = DesfragmentaBit(Ambientes(30).varControle, 14)
            Ambientes(30).bitLigaVSSC = DesfragmentaBit(Ambientes(30).varControle, 15)
            Ambientes(30).bitLigaVSLL = DesfragmentaBit(Ambientes(30).varControle, 0)
            Ambientes(30).bitLigaVSGQ = DesfragmentaBit(Ambientes(30).varControle, 1)
            Ambientes(30).bitLigaVSAG = DesfragmentaBit(Ambientes(30).varControle, 2)
            Ambientes(30).bitMADegelo = DesfragmentaBit(Ambientes(30).varControle, 3)
            Ambientes(30).bitHabDegelo1 = DesfragmentaBit(Ambientes(30).varControle, 4)
            Ambientes(30).bitHabDegelo2 = DesfragmentaBit(Ambientes(30).varControle, 5)
            Ambientes(30).bitHabDegelo3 = DesfragmentaBit(Ambientes(30).varControle, 6)
            Ambientes(30).bitForceDegelo = DesfragmentaBit(Ambientes(30).varControle, 7)
            Ambientes(30).bitHabAmbiente = DesfragmentaBit(Ambientes(30).varControle, 8)
            Ambientes(30).bitMAEvap = DesfragmentaBit(Ambientes(30).varControle, 9)
            Ambientes(30).bitMAVSSC = DesfragmentaBit(Ambientes(30).varControle, 10)
            Ambientes(30).bitMAVSLL = DesfragmentaBit(Ambientes(30).varControle, 11)
            Ambientes(30).bitMAVSGQ = DesfragmentaBit(Ambientes(30).varControle, 12)
            Ambientes(30).bitMAVSAG = DesfragmentaBit(Ambientes(30).varControle, 13)
            Ambientes(30).bitDegelo = DesfragmentaBit(Ambientes(30).varStatus, 8)
            Ambientes(30).bitLDEvap = DesfragmentaBit(Ambientes(30).varStatus, 9)
            Ambientes(30).bitLDVSSC = DesfragmentaBit(Ambientes(30).varStatus, 10)
            Ambientes(30).bitLDVSLL = DesfragmentaBit(Ambientes(30).varStatus, 11)
            Ambientes(30).bitLDVSGQ = DesfragmentaBit(Ambientes(30).varStatus, 12)
            Ambientes(30).bitLDVSAG = DesfragmentaBit(Ambientes(30).varStatus, 13)
            'Ambientes(30).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 0)
            'Ambientes(30).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 1)

            'desfragmenta bits Tunel 3 Miudos
            Ambientes(31).bitLigaEvap = DesfragmentaBit(Ambientes(31).varControle, 14)
            Ambientes(31).bitLigaVSSC = DesfragmentaBit(Ambientes(31).varControle, 15)
            Ambientes(31).bitLigaVSLL = DesfragmentaBit(Ambientes(31).varControle, 0)
            Ambientes(31).bitLigaVSGQ = DesfragmentaBit(Ambientes(31).varControle, 1)
            Ambientes(31).bitLigaVSAG = DesfragmentaBit(Ambientes(31).varControle, 2)
            Ambientes(31).bitMADegelo = DesfragmentaBit(Ambientes(31).varControle, 3)
            Ambientes(31).bitHabDegelo1 = DesfragmentaBit(Ambientes(31).varControle, 4)
            Ambientes(31).bitHabDegelo2 = DesfragmentaBit(Ambientes(31).varControle, 5)
            Ambientes(31).bitHabDegelo3 = DesfragmentaBit(Ambientes(31).varControle, 6)
            Ambientes(31).bitForceDegelo = DesfragmentaBit(Ambientes(31).varControle, 7)
            Ambientes(31).bitHabAmbiente = DesfragmentaBit(Ambientes(31).varControle, 8)
            Ambientes(31).bitMAEvap = DesfragmentaBit(Ambientes(31).varControle, 9)
            Ambientes(31).bitMAVSSC = DesfragmentaBit(Ambientes(31).varControle, 10)
            Ambientes(31).bitMAVSLL = DesfragmentaBit(Ambientes(31).varControle, 11)
            Ambientes(31).bitMAVSGQ = DesfragmentaBit(Ambientes(31).varControle, 12)
            Ambientes(31).bitMAVSAG = DesfragmentaBit(Ambientes(31).varControle, 13)
            Ambientes(31).bitDegelo = DesfragmentaBit(Ambientes(31).varStatus, 8)
            Ambientes(31).bitLDEvap = DesfragmentaBit(Ambientes(31).varStatus, 9)
            Ambientes(31).bitLDVSSC = DesfragmentaBit(Ambientes(31).varStatus, 10)
            Ambientes(31).bitLDVSLL = DesfragmentaBit(Ambientes(31).varStatus, 11)
            Ambientes(31).bitLDVSGQ = DesfragmentaBit(Ambientes(31).varStatus, 12)
            Ambientes(31).bitLDVSAG = DesfragmentaBit(Ambientes(31).varStatus, 13)
            'Ambientes(31).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 0)
            'Ambientes(31).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 1)

            'desfragmenta bits Estocagem Congelados Miudos
            Ambientes(32).bitLigaEvap = DesfragmentaBit(Ambientes(32).varControle, 14)
            Ambientes(32).bitLigaVSSC = DesfragmentaBit(Ambientes(32).varControle, 15)
            Ambientes(32).bitLigaVSLL = DesfragmentaBit(Ambientes(32).varControle, 0)
            Ambientes(32).bitLigaVSGQ = DesfragmentaBit(Ambientes(32).varControle, 1)
            Ambientes(32).bitLigaVSAG = DesfragmentaBit(Ambientes(32).varControle, 2)
            Ambientes(32).bitMADegelo = DesfragmentaBit(Ambientes(32).varControle, 3)
            Ambientes(32).bitHabDegelo1 = DesfragmentaBit(Ambientes(32).varControle, 4)
            Ambientes(32).bitHabDegelo2 = DesfragmentaBit(Ambientes(32).varControle, 5)
            Ambientes(32).bitHabDegelo3 = DesfragmentaBit(Ambientes(32).varControle, 6)
            Ambientes(32).bitForceDegelo = DesfragmentaBit(Ambientes(32).varControle, 7)
            Ambientes(32).bitHabAmbiente = DesfragmentaBit(Ambientes(32).varControle, 8)
            Ambientes(32).bitMAEvap = DesfragmentaBit(Ambientes(32).varControle, 9)
            Ambientes(32).bitMAVSSC = DesfragmentaBit(Ambientes(32).varControle, 10)
            Ambientes(32).bitMAVSLL = DesfragmentaBit(Ambientes(32).varControle, 11)
            Ambientes(32).bitMAVSGQ = DesfragmentaBit(Ambientes(32).varControle, 12)
            Ambientes(32).bitMAVSAG = DesfragmentaBit(Ambientes(32).varControle, 13)
            Ambientes(32).bitDegelo = DesfragmentaBit(Ambientes(32).varStatus, 8)
            Ambientes(32).bitLDEvap = DesfragmentaBit(Ambientes(32).varStatus, 9)
            Ambientes(32).bitLDVSSC = DesfragmentaBit(Ambientes(32).varStatus, 10)
            Ambientes(32).bitLDVSLL = DesfragmentaBit(Ambientes(32).varStatus, 11)
            Ambientes(32).bitLDVSGQ = DesfragmentaBit(Ambientes(32).varStatus, 12)
            Ambientes(32).bitLDVSAG = DesfragmentaBit(Ambientes(32).varStatus, 13)
            'Ambientes(32).bitFalhaEvaporador1 = DesfragmentaBit(varAlarmes1, 0)
            'Ambientes(32).bitFalhaEvaporador2 = DesfragmentaBit(varAlarmes1, 1)

        End If

        If varAmbienteAtivo <> 0 And Ambientes(varAmbienteAtivo).varCLP = 3 Then
            slave = 1
            startRdReg = Ambientes(varAmbienteAtivo).varStartAdress
            numRdRegs = 19
            res = M251.readMultipleRegisters(slave, startRdReg, readVals, numRdRegs)
            If res = BusProtocolErrors.FTALK_SUCCESS Then
                For j = 1 To numRdRegs
                    blcGeral3(startRdReg - 1 + j) = readVals(j)
                Next
            End If

            'bits de habilita degelo
            varST = Ambientes(varAmbienteAtivo).varADControle
            Ambientes(varAmbienteAtivo).bitHabDegelo1 = DesfragmentaBit(blcGeral3(varST), 4)
            Ambientes(varAmbienteAtivo).bitHabDegelo2 = DesfragmentaBit(blcGeral3(varST), 5)
            Ambientes(varAmbienteAtivo).bitHabDegelo3 = DesfragmentaBit(blcGeral3(varST), 6)

            'carrega os valores dos tempos decorridos de degelo indexadinho em Segundos
            varST = Ambientes(varAmbienteAtivo).varStartAdress
            Ambientes(varAmbienteAtivo).varSPRecolhimento = blcGeral3(varST + 0)
            Ambientes(varAmbienteAtivo).varSPGasQuente = blcGeral3(varST + 1)
            Ambientes(varAmbienteAtivo).varSPAgua = blcGeral3(varST + 2)
            Ambientes(varAmbienteAtivo).varSPGotejamento = blcGeral3(varST + 3)
            Ambientes(varAmbienteAtivo).varSPPreResfriamento = blcGeral3(varST + 4)

            Ambientes(varAmbienteAtivo).varTempoRecolhimento = blcGeral3(varST + 5)
            Ambientes(varAmbienteAtivo).varTempoGasQuente = blcGeral3(varST + 6)
            Ambientes(varAmbienteAtivo).varTempoAgua = blcGeral3(varST + 7)
            Ambientes(varAmbienteAtivo).varTempoGotejamento = blcGeral3(varST + 8)
            Ambientes(varAmbienteAtivo).varTempoPreResfriamento = blcGeral3(varST + 9)

            Ambientes(varAmbienteAtivo).varHoraDegelo1 = blcGeral3(varST + 10) \ 100
            Ambientes(varAmbienteAtivo).varMinutoDegelo1 = blcGeral3(varST + 10) Mod 100

            Ambientes(varAmbienteAtivo).varHoraDegelo2 = blcGeral3(varST + 11) \ 100
            Ambientes(varAmbienteAtivo).varMinutoDegelo2 = blcGeral3(varST + 11) Mod 100

            Ambientes(varAmbienteAtivo).varHoraDegelo3 = blcGeral3(varST + 12) \ 100
            Ambientes(varAmbienteAtivo).varMinutoDegelo3 = blcGeral3(varST + 12) Mod 100
        End If

    End Sub


    Private Sub btnMenuSADEMA_Click(sender As Object, e As EventArgs) Handles btnMenuSADEMA.Click
        FrmAlaNova.Close()
        FrmAmbientes.Close()
        frmCamaras.Close()
        frmCompressores.Close()
        frmTuneisMiudos.Close()
        FrmTuneis47.Close()
        frmClimatizacao.Close()

        FrmSADEMA.MdiParent = Me
        FrmSADEMA.Show()
    End Sub

    Private Sub BtnAlaNova_Click(sender As Object, e As EventArgs) Handles BtnAlaNova.Click
        FrmSADEMA.Close()
        FrmAmbientes.Close()
        frmCompressores.Close()
        frmCamaras.Close()
        FrmTuneis47.Close()
        FrmAlaNova.Close()
        frmTuneisMiudos.Close()
        frmClimatizacao.Close()

        FrmAlaNova.MdiParent = Me
        FrmAlaNova.Show()
    End Sub

    Private Sub Compressor1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Compressor1ToolStripMenuItem.Click
        FrmSADEMA.Close()
        FrmAmbientes.Close()
        FrmAlaNova.Close()
        frmCamaras.Close()
        frmCompressores.Close()
        frmTuneisMiudos.Close()
        frmClimatizacao.Close()

        frmCompressores.MdiParent = Me
        varCompressorAtivo = 1
        frmCompressores.Show()
    End Sub

    Private Sub Compressor2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Compressor2ToolStripMenuItem.Click
        FrmSADEMA.Close()
        FrmAmbientes.Close()
        FrmAlaNova.Close()
        frmCompressores.Close()
        frmCamaras.Close()
        FrmTuneis47.Close()
        frmTuneisMiudos.Close()
        frmClimatizacao.Close()

        frmCompressores.MdiParent = Me
        varCompressorAtivo = 2
        frmCompressores.Show()
    End Sub

    Private Sub Compressor3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Compressor3ToolStripMenuItem.Click
        FrmSADEMA.Close()
        FrmAmbientes.Close()
        FrmAlaNova.Close()
        frmCompressores.Close()
        FrmTuneis47.Close()
        frmCamaras.Close()
        frmTuneisMiudos.Close()
        frmClimatizacao.Close()

        frmCompressores.MdiParent = Me
        varCompressorAtivo = 3
        frmCompressores.Show()
    End Sub
    Private Sub btnTuneis47_Click(sender As Object, e As EventArgs) Handles btnTuneis47.Click
        FrmSADEMA.Close()
        FrmAmbientes.Close()
        frmCompressores.Close()
        frmCamaras.Close()
        FrmAlaNova.Close()
        frmTuneisMiudos.Close()
        frmClimatizacao.Close()

        FrmTuneis47.MdiParent = Me
        FrmTuneis47.Show()
    End Sub

    Private Sub btnCamaras_Click(sender As Object, e As EventArgs) Handles btnCamaras.Click
        FrmSADEMA.Close()
        FrmAmbientes.Close()
        frmCompressores.Close()
        FrmTuneis47.Close()
        FrmAlaNova.Close()
        frmTuneisMiudos.Close()
        frmClimatizacao.Close()

        frmCamaras.MdiParent = Me
        frmCamaras.Show()
    End Sub

    Private Sub btnMiudos_Click(sender As Object, e As EventArgs) Handles btnMiudos.Click
        FrmSADEMA.Close()
        FrmAmbientes.Close()
        frmCompressores.Close()
        frmCamaras.Close()
        FrmAlaNova.Close()
        FrmTuneis47.Close()
        frmClimatizacao.Close()

        frmTuneisMiudos.MdiParent = Me
        frmTuneisMiudos.Show()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        FrmSADEMA.Close()
        FrmAmbientes.Close()
        frmCompressores.Close()
        frmCamaras.Close()
        FrmAlaNova.Close()
        FrmTuneis47.Close()
        frmTuneisMiudos.Close()

        frmClimatizacao.MdiParent = Me
        frmClimatizacao.Show()

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim res As Integer
        Dim Valor As Short
        Valor = 2
        'Reset da comunicação serial modbus RTU no clp da Siemens sala de máquinas
        res = myProtocol.writeSingleRegister(1, 2407 + 1, Valor)
    End Sub

End Class
