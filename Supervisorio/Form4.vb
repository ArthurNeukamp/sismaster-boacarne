Imports System.Reflection.Emit

Public Class FrmAlaNova
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        '*******************************************************
        'Tunel 1 - Atualização tela
        '*******************************************************
        lblTempTunel1.Text = MainForm.Ambientes(1).varTemperatura / 10 & " °C"

        If Not edtSetPointTunel1.Focused Then
            edtSetPointTunel1.Text = MainForm.Ambientes(1).varSetPoint & " °C"
        End If

        If Not edtOffsetTunel1.Focused Then
            edtOffsetTunel1.Text = MainForm.Ambientes(1).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(1).bitLDEvap Then
            lblLDEvaporadorTunel1.Text = "Ligado"
            If MainForm.Ambientes(1).bitFalhaEvaporador1 Or MainForm.Ambientes(1).bitFalhaEvaporador2 Or MainForm.Ambientes(1).bitFalhaEvaporador3 Or MainForm.Ambientes(1).bitFalhaEvaporador4 Then
                lblLDEvaporadorTunel1.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorTunel1.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorTunel1.Text = "Desligado"
            lblLDEvaporadorTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(1).bitLDVSSC Then
            lblLDVSSCTunel1.Text = "Ligado"
            lblLDVSSCTunel1.BackColor = Color.DarkBlue
        Else
            lblLDVSSCTunel1.Text = "Desligado"
            lblLDVSSCTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(1).bitLDVSLL Then
            lblLDVSLLTunel1.Text = "Ligado"
            lblLDVSLLTunel1.BackColor = Color.DarkBlue
        Else
            lblLDVSLLTunel1.Text = "Desligado"
            lblLDVSLLTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(1).bitLDVSGQ Then
            lblLDVSGQTunel1.Text = "Ligado"
            lblLDVSGQTunel1.BackColor = Color.DarkRed
        Else
            lblLDVSGQTunel1.Text = "Desligado"
            lblLDVSGQTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(1).bitLDVSAG Then
            lblLDVSAGTunel1.Text = "Ligado"
            lblLDVSAGTunel1.BackColor = Color.DarkGreen
        Else
            lblLDVSAGTunel1.Text = "Desligado"
            lblLDVSAGTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(1).bitDegelo Then
            lblLDDegeloTunel1.Text = "Iniciado"
            lblLDDegeloTunel1.BackColor = Color.DarkRed
        Else
            lblLDDegeloTunel1.Text = "Desligado"
            lblLDDegeloTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(1).bitMAEvap Then
            lblMAEvaporadorTunel1.Text = "Automático"
            lblMAEvaporadorTunel1.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorTunel1.Text = "Manual"
            lblMAEvaporadorTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(1).bitMAVSSC Then
            lblMAVSSCTunel1.Text = "Automático"
            lblMAVSSCTunel1.BackColor = Color.DarkBlue
        Else
            lblMAVSSCTunel1.Text = "Manual"
            lblMAVSSCTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(1).bitMAVSLL Then
            lblMAVSLLTunel1.Text = "Automático"
            lblMAVSLLTunel1.BackColor = Color.DarkBlue
        Else
            lblMAVSLLTunel1.Text = "Manual"
            lblMAVSLLTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(1).bitMAVSGQ Then
            lblMAVSGQTunel1.Text = "Automático"
            lblMAVSGQTunel1.BackColor = Color.DarkBlue
        Else
            lblMAVSGQTunel1.Text = "Manual"
            lblMAVSGQTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(1).bitMAVSAG Then
            lblMAVSAGTunel1.Text = "Automático"
            lblMAVSAGTunel1.BackColor = Color.DarkBlue
        Else
            lblMAVSAGTunel1.Text = "Manual"
            lblMAVSAGTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(1).bitMADegelo Then
            lblMADegeloTunel1.Text = "Automático"
            lblMADegeloTunel1.BackColor = Color.DarkBlue
        Else
            lblMADegeloTunel1.Text = "Manual"
            lblMADegeloTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(1).bitHabAmbiente Then
            lblHabAmbienteTunel1.Text = "Habilitado"
            lblHabAmbienteTunel1.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteTunel1.Text = "Desabilitado"
            lblHabAmbienteTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(1).varStatusAmbiente = 0 Then
            lblStatusAmbienteTunel1.Text = "Refrig."
            lblStatusAmbienteTunel1.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(1).varStatusAmbiente = 1 Then
            lblStatusAmbienteTunel1.Text = "Recolher"
            lblStatusAmbienteTunel1.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(1).varStatusAmbiente = 2 Then
            lblStatusAmbienteTunel1.Text = "Pausa"
            lblStatusAmbienteTunel1.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(1).varStatusAmbiente = 3 Then
            lblStatusAmbienteTunel1.Text = "Gás Quente"
            lblStatusAmbienteTunel1.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(1).varStatusAmbiente = 4 Then
            lblStatusAmbienteTunel1.Text = "Água"
            lblStatusAmbienteTunel1.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(1).varStatusAmbiente = 5 Then
            lblStatusAmbienteTunel1.Text = "Gotejam."
            lblStatusAmbienteTunel1.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(1).varStatusAmbiente = 6 Then
            lblStatusAmbienteTunel1.Text = "Pré-Resf."
            lblStatusAmbienteTunel1.BackColor = Color.Blue
        End If
        'Fim Tunel 1
        '*************************************************

        '*******************************************************
        'Tunel 2 - Atualização tela
        '*******************************************************
        lblTempTunel2.Text = MainForm.Ambientes(2).varTemperatura / 10 & " °C"

        If Not edtSetPointTunel2.Focused Then
            edtSetPointTunel2.Text = MainForm.Ambientes(2).varSetPoint & " °C"
        End If

        If Not edtOffSetTunel2.Focused Then
            edtOffSetTunel2.Text = MainForm.Ambientes(2).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(2).bitLDEvap Then
            lblLDEvaporadorTunel2.Text = "Ligado"
            If MainForm.Ambientes(2).bitFalhaEvaporador1 Or MainForm.Ambientes(2).bitFalhaEvaporador2 Or MainForm.Ambientes(2).bitFalhaEvaporador3 Or MainForm.Ambientes(2).bitFalhaEvaporador4 Then
                lblLDEvaporadorTunel2.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorTunel2.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorTunel2.Text = "Desligado"
            lblLDEvaporadorTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(2).bitLDVSSC Then
            lblLDVSSCTunel2.Text = "Ligado"
            lblLDVSSCTunel2.BackColor = Color.DarkBlue
        Else
            lblLDVSSCTunel2.Text = "Desligado"
            lblLDVSSCTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(2).bitLDVSLL Then
            lblLDVSLLTunel2.Text = "Ligado"
            lblLDVSLLTunel2.BackColor = Color.DarkBlue
        Else
            lblLDVSLLTunel2.Text = "Desligado"
            lblLDVSLLTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(2).bitLDVSGQ Then
            lblLDVSGQTunel2.Text = "Ligado"
            lblLDVSGQTunel2.BackColor = Color.DarkRed
        Else
            lblLDVSGQTunel2.Text = "Desligado"
            lblLDVSGQTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(2).bitLDVSAG Then
            lblLDVSAGTunel2.Text = "Ligado"
            lblLDVSAGTunel2.BackColor = Color.DarkGreen
        Else
            lblLDVSAGTunel2.Text = "Desligado"
            lblLDVSAGTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(2).bitDegelo Then
            lblLDDegeloTunel2.Text = "Iniciado"
            lblLDDegeloTunel2.BackColor = Color.DarkRed
        Else
            lblLDDegeloTunel2.Text = "Desligado"
            lblLDDegeloTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(2).bitMAEvap Then
            lblMAEvaporadorTunel2.Text = "Automático"
            lblMAEvaporadorTunel2.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorTunel2.Text = "Manual"
            lblMAEvaporadorTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(2).bitMAVSSC Then
            lblMAVSSCTunel2.Text = "Automático"
            lblMAVSSCTunel2.BackColor = Color.DarkBlue
        Else
            lblMAVSSCTunel2.Text = "Manual"
            lblMAVSSCTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(2).bitMAVSLL Then
            lblMAVSLLTunel2.Text = "Automático"
            lblMAVSLLTunel2.BackColor = Color.DarkBlue
        Else
            lblMAVSLLTunel2.Text = "Manual"
            lblMAVSLLTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(2).bitMAVSGQ Then
            lblMAVSGQTunel2.Text = "Automático"
            lblMAVSGQTunel2.BackColor = Color.DarkBlue
        Else
            lblMAVSGQTunel2.Text = "Manual"
            lblMAVSGQTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(2).bitMAVSAG Then
            lblMAVSAGTunel2.Text = "Automático"
            lblMAVSAGTunel2.BackColor = Color.DarkBlue
        Else
            lblMAVSAGTunel2.Text = "Manual"
            lblMAVSAGTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(2).bitMADegelo Then
            lblMADegeloTunel2.Text = "Automático"
            lblMADegeloTunel2.BackColor = Color.DarkBlue
        Else
            lblMADegeloTunel2.Text = "Manual"
            lblMADegeloTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(2).bitHabAmbiente Then
            lblHabAmbienteTunel2.Text = "Habilitado"
            lblHabAmbienteTunel2.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteTunel2.Text = "Desabilitado"
            lblHabAmbienteTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(2).varStatusAmbiente = 0 Then
            lblStatusAmbienteTunel2.Text = "Refrig."
            lblStatusAmbienteTunel2.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(2).varStatusAmbiente = 1 Then
            lblStatusAmbienteTunel2.Text = "Recolher"
            lblStatusAmbienteTunel2.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(2).varStatusAmbiente = 2 Then
            lblStatusAmbienteTunel2.Text = "Pausa"
            lblStatusAmbienteTunel2.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(2).varStatusAmbiente = 3 Then
            lblStatusAmbienteTunel2.Text = "Gás Quente"
            lblStatusAmbienteTunel2.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(2).varStatusAmbiente = 4 Then
            lblStatusAmbienteTunel2.Text = "Água"
            lblStatusAmbienteTunel2.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(2).varStatusAmbiente = 5 Then
            lblStatusAmbienteTunel2.Text = "Gotejam."
            lblStatusAmbienteTunel2.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(2).varStatusAmbiente = 6 Then
            lblStatusAmbienteTunel2.Text = "Pré-Resf."
            lblStatusAmbienteTunel2.BackColor = Color.Blue
        End If
        'Fim Tunel 2
        '*************************************************

        '*******************************************************
        'Tunel 3 - Atualização tela
        '*******************************************************
        lblTempTunel3.Text = MainForm.Ambientes(3).varTemperatura / 10 & " °C"

        If Not edtSetPointTunel3.Focused Then
            edtSetPointTunel3.Text = MainForm.Ambientes(3).varSetPoint & " °C"
        End If

        If Not edtOffSetTunel3.Focused Then
            edtOffSetTunel3.Text = MainForm.Ambientes(3).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(3).bitLDEvap Then
            lblLDEvaporadorTunel3.Text = "Ligado"
            If MainForm.Ambientes(3).bitFalhaEvaporador1 Or MainForm.Ambientes(3).bitFalhaEvaporador2 Or MainForm.Ambientes(3).bitFalhaEvaporador3 Or MainForm.Ambientes(3).bitFalhaEvaporador4 Then
                lblLDEvaporadorTunel3.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorTunel3.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorTunel3.Text = "Desligado"
            lblLDEvaporadorTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(3).bitLDVSSC Then
            lblLDVSSCTunel3.Text = "Ligado"
            lblLDVSSCTunel3.BackColor = Color.DarkBlue
        Else
            lblLDVSSCTunel3.Text = "Desligado"
            lblLDVSSCTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(3).bitLDVSLL Then
            lblLDVSLLTunel3.Text = "Ligado"
            lblLDVSLLTunel3.BackColor = Color.DarkBlue
        Else
            lblLDVSLLTunel3.Text = "Desligado"
            lblLDVSLLTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(3).bitLDVSGQ Then
            lblLDVSGQTunel3.Text = "Ligado"
            lblLDVSGQTunel3.BackColor = Color.DarkRed
        Else
            lblLDVSGQTunel3.Text = "Desligado"
            lblLDVSGQTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(3).bitLDVSAG Then
            lblLDVSAGTunel3.Text = "Ligado"
            lblLDVSAGTunel3.BackColor = Color.DarkGreen
        Else
            lblLDVSAGTunel3.Text = "Desligado"
            lblLDVSAGTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(3).bitDegelo Then
            lblLDDegeloTunel3.Text = "Iniciado"
            lblLDDegeloTunel3.BackColor = Color.DarkRed
        Else
            lblLDDegeloTunel3.Text = "Desligado"
            lblLDDegeloTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(3).bitMAEvap Then
            lblMAEvaporadorTunel3.Text = "Automático"
            lblMAEvaporadorTunel3.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorTunel3.Text = "Manual"
            lblMAEvaporadorTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(3).bitMAVSSC Then
            lblMAVSSCTunel3.Text = "Automático"
            lblMAVSSCTunel3.BackColor = Color.DarkBlue
        Else
            lblMAVSSCTunel3.Text = "Manual"
            lblMAVSSCTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(3).bitMAVSLL Then
            lblMAVSLLTunel3.Text = "Automático"
            lblMAVSLLTunel3.BackColor = Color.DarkBlue
        Else
            lblMAVSLLTunel3.Text = "Manual"
            lblMAVSLLTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(3).bitMAVSGQ Then
            lblMAVSGQTunel3.Text = "Automático"
            lblMAVSGQTunel3.BackColor = Color.DarkBlue
        Else
            lblMAVSGQTunel3.Text = "Manual"
            lblMAVSGQTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(3).bitMAVSAG Then
            lblMAVSAGTunel3.Text = "Automático"
            lblMAVSAGTunel3.BackColor = Color.DarkBlue
        Else
            lblMAVSAGTunel3.Text = "Manual"
            lblMAVSAGTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(3).bitMADegelo Then
            lblMADegeloTunel3.Text = "Automático"
            lblMADegeloTunel3.BackColor = Color.DarkBlue
        Else
            lblMADegeloTunel3.Text = "Manual"
            lblMADegeloTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(3).bitHabAmbiente Then
            lblHabAmbienteTunel3.Text = "Habilitado"
            lblHabAmbienteTunel3.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteTunel3.Text = "Desabilitado"
            lblHabAmbienteTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(3).varStatusAmbiente = 0 Then
            lblStatusAmbienteTunel3.Text = "Refrig."
            lblStatusAmbienteTunel3.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(3).varStatusAmbiente = 1 Then
            lblStatusAmbienteTunel3.Text = "Recolher"
            lblStatusAmbienteTunel3.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(3).varStatusAmbiente = 2 Then
            lblStatusAmbienteTunel3.Text = "Pausa"
            lblStatusAmbienteTunel3.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(3).varStatusAmbiente = 3 Then
            lblStatusAmbienteTunel3.Text = "Gás Quente"
            lblStatusAmbienteTunel3.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(3).varStatusAmbiente = 4 Then
            lblStatusAmbienteTunel3.Text = "Água"
            lblStatusAmbienteTunel3.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(3).varStatusAmbiente = 5 Then
            lblStatusAmbienteTunel3.Text = "Gotejam."
            lblStatusAmbienteTunel3.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(3).varStatusAmbiente = 6 Then
            lblStatusAmbienteTunel3.Text = "Pré-Resf."
            lblStatusAmbienteTunel3.BackColor = Color.Blue
        End If
        'Fim Tunel 3
        '*************************************************

        '*******************************************************
        'Tunel 4 - Atualização tela
        '*******************************************************
        lblTempTunel4.Text = MainForm.Ambientes(4).varTemperatura / 10 & " °C"

        If Not edtSetPointTunel4.Focused Then
            edtSetPointTunel4.Text = MainForm.Ambientes(4).varSetPoint & " °C"
        End If

        If Not edtOffSetTunel4.Focused Then
            edtOffSetTunel4.Text = MainForm.Ambientes(4).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(4).bitLDEvap Then
            lblLDEvaporadorTunel4.Text = "Ligado"
            If MainForm.Ambientes(4).bitFalhaEvaporador1 Or MainForm.Ambientes(4).bitFalhaEvaporador2 Or MainForm.Ambientes(4).bitFalhaEvaporador3 Or MainForm.Ambientes(4).bitFalhaEvaporador4 Then
                lblLDEvaporadorTunel4.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorTunel4.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorTunel4.Text = "Desligado"
            lblLDEvaporadorTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(4).bitLDVSSC Then
            lblLDVSSCTunel4.Text = "Ligado"
            lblLDVSSCTunel4.BackColor = Color.DarkBlue
        Else
            lblLDVSSCTunel4.Text = "Desligado"
            lblLDVSSCTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(4).bitLDVSLL Then
            lblLDVSLLTunel4.Text = "Ligado"
            lblLDVSLLTunel4.BackColor = Color.DarkBlue
        Else
            lblLDVSLLTunel4.Text = "Desligado"
            lblLDVSLLTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(4).bitLDVSGQ Then
            lblLDVSGQTunel4.Text = "Ligado"
            lblLDVSGQTunel4.BackColor = Color.DarkRed
        Else
            lblLDVSGQTunel4.Text = "Desligado"
            lblLDVSGQTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(4).bitLDVSAG Then
            lblLDVSAGTunel4.Text = "Ligado"
            lblLDVSAGTunel4.BackColor = Color.DarkGreen
        Else
            lblLDVSAGTunel4.Text = "Desligado"
            lblLDVSAGTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(4).bitDegelo Then
            lblLDDegeloTunel4.Text = "Iniciado"
            lblLDDegeloTunel4.BackColor = Color.DarkRed
        Else
            lblLDDegeloTunel4.Text = "Desligado"
            lblLDDegeloTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(4).bitMAEvap Then
            lblMAEvaporadorTunel4.Text = "Automático"
            lblMAEvaporadorTunel4.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorTunel4.Text = "Manual"
            lblMAEvaporadorTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(4).bitMAVSSC Then
            lblMAVSSCTunel4.Text = "Automático"
            lblMAVSSCTunel4.BackColor = Color.DarkBlue
        Else
            lblMAVSSCTunel4.Text = "Manual"
            lblMAVSSCTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(4).bitMAVSLL Then
            lblMAVSLLTunel4.Text = "Automático"
            lblMAVSLLTunel4.BackColor = Color.DarkBlue
        Else
            lblMAVSLLTunel4.Text = "Manual"
            lblMAVSLLTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(4).bitMAVSGQ Then
            lblMAVSGQTunel4.Text = "Automático"
            lblMAVSGQTunel4.BackColor = Color.DarkBlue
        Else
            lblMAVSGQTunel4.Text = "Manual"
            lblMAVSGQTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(4).bitMAVSAG Then
            lblMAVSAGTunel4.Text = "Automático"
            lblMAVSAGTunel4.BackColor = Color.DarkBlue
        Else
            lblMAVSAGTunel4.Text = "Manual"
            lblMAVSAGTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(4).bitMADegelo Then
            lblMADegeloTunel4.Text = "Automático"
            lblMADegeloTunel4.BackColor = Color.DarkBlue
        Else
            lblMADegeloTunel4.Text = "Manual"
            lblMADegeloTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(4).bitHabAmbiente Then
            lblHabAmbienteTunel4.Text = "Habilitado"
            lblHabAmbienteTunel4.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteTunel4.Text = "Desabilitado"
            lblHabAmbienteTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(4).varStatusAmbiente = 0 Then
            lblStatusAmbienteTunel4.Text = "Refrig."
            lblStatusAmbienteTunel4.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(4).varStatusAmbiente = 1 Then
            lblStatusAmbienteTunel4.Text = "Recolher"
            lblStatusAmbienteTunel4.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(4).varStatusAmbiente = 2 Then
            lblStatusAmbienteTunel4.Text = "Pausa"
            lblStatusAmbienteTunel4.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(4).varStatusAmbiente = 3 Then
            lblStatusAmbienteTunel4.Text = "Gás Quente"
            lblStatusAmbienteTunel4.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(4).varStatusAmbiente = 4 Then
            lblStatusAmbienteTunel4.Text = "Água"
            lblStatusAmbienteTunel4.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(4).varStatusAmbiente = 5 Then
            lblStatusAmbienteTunel4.Text = "Gotejam."
            lblStatusAmbienteTunel4.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(4).varStatusAmbiente = 6 Then
            lblStatusAmbienteTunel4.Text = "Pré-Resf."
            lblStatusAmbienteTunel4.BackColor = Color.Blue
        End If
        'Fim Tunel 4
        '*************************************************

        '*******************************************************
        'Tunel 5 - Atualização tela
        '*******************************************************
        lblTempTunel5.Text = MainForm.Ambientes(5).varTemperatura / 10 & " °C"

        If Not edtSetPointTunel5.Focused Then
            edtSetPointTunel5.Text = MainForm.Ambientes(5).varSetPoint & " °C"
        End If

        If Not edtOffSetTunel5.Focused Then
            edtOffSetTunel5.Text = MainForm.Ambientes(5).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(5).bitLDEvap Then
            lblLDEvaporadorTunel5.Text = "Ligado"
            If MainForm.Ambientes(5).bitFalhaEvaporador1 Or MainForm.Ambientes(5).bitFalhaEvaporador2 Or MainForm.Ambientes(5).bitFalhaEvaporador3 Or MainForm.Ambientes(5).bitFalhaEvaporador4 Then
                lblLDEvaporadorTunel5.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorTunel5.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorTunel5.Text = "Desligado"
            lblLDEvaporadorTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(5).bitLDVSSC Then
            lblLDVSSCTunel5.Text = "Ligado"
            lblLDVSSCTunel5.BackColor = Color.DarkBlue
        Else
            lblLDVSSCTunel5.Text = "Desligado"
            lblLDVSSCTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(5).bitLDVSLL Then
            lblLDVSLLTunel5.Text = "Ligado"
            lblLDVSLLTunel5.BackColor = Color.DarkBlue
        Else
            lblLDVSLLTunel5.Text = "Desligado"
            lblLDVSLLTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(5).bitLDVSGQ Then
            lblLDVSGQTunel5.Text = "Ligado"
            lblLDVSGQTunel5.BackColor = Color.DarkRed
        Else
            lblLDVSGQTunel5.Text = "Desligado"
            lblLDVSGQTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(5).bitLDVSAG Then
            lblLDVSAGTunel5.Text = "Ligado"
            lblLDVSAGTunel5.BackColor = Color.DarkGreen
        Else
            lblLDVSAGTunel5.Text = "Desligado"
            lblLDVSAGTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(5).bitDegelo Then
            lblLDDegeloTunel5.Text = "Iniciado"
            lblLDDegeloTunel5.BackColor = Color.DarkRed
        Else
            lblLDDegeloTunel5.Text = "Desligado"
            lblLDDegeloTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(5).bitMAEvap Then
            lblMAEvaporadorTunel5.Text = "Automático"
            lblMAEvaporadorTunel5.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorTunel5.Text = "Manual"
            lblMAEvaporadorTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(5).bitMAVSSC Then
            lblMAVSSCTunel5.Text = "Automático"
            lblMAVSSCTunel5.BackColor = Color.DarkBlue
        Else
            lblMAVSSCTunel5.Text = "Manual"
            lblMAVSSCTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(5).bitMAVSLL Then
            lblMAVSLLTunel5.Text = "Automático"
            lblMAVSLLTunel5.BackColor = Color.DarkBlue
        Else
            lblMAVSLLTunel5.Text = "Manual"
            lblMAVSLLTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(5).bitMAVSGQ Then
            lblMAVSGQTunel5.Text = "Automático"
            lblMAVSGQTunel5.BackColor = Color.DarkBlue
        Else
            lblMAVSGQTunel5.Text = "Manual"
            lblMAVSGQTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(5).bitMAVSAG Then
            lblMAVSAGTunel5.Text = "Automático"
            lblMAVSAGTunel5.BackColor = Color.DarkBlue
        Else
            lblMAVSAGTunel5.Text = "Manual"
            lblMAVSAGTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(5).bitMADegelo Then
            lblMADegeloTunel5.Text = "Automático"
            lblMADegeloTunel5.BackColor = Color.DarkBlue
        Else
            lblMADegeloTunel5.Text = "Manual"
            lblMADegeloTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(5).bitHabAmbiente Then
            lblHabAmbienteTunel5.Text = "Habilitado"
            lblHabAmbienteTunel5.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteTunel5.Text = "Desabilitado"
            lblHabAmbienteTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(5).varStatusAmbiente = 0 Then
            lblStatusAmbienteTunel5.Text = "Refrig."
            lblStatusAmbienteTunel5.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(5).varStatusAmbiente = 1 Then
            lblStatusAmbienteTunel5.Text = "Recolher"
            lblStatusAmbienteTunel5.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(5).varStatusAmbiente = 2 Then
            lblStatusAmbienteTunel5.Text = "Pausa"
            lblStatusAmbienteTunel5.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(5).varStatusAmbiente = 3 Then
            lblStatusAmbienteTunel5.Text = "Gás Quente"
            lblStatusAmbienteTunel5.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(5).varStatusAmbiente = 4 Then
            lblStatusAmbienteTunel5.Text = "Água"
            lblStatusAmbienteTunel5.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(5).varStatusAmbiente = 5 Then
            lblStatusAmbienteTunel5.Text = "Gotejam."
            lblStatusAmbienteTunel5.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(5).varStatusAmbiente = 6 Then
            lblStatusAmbienteTunel5.Text = "Pré-Resf."
            lblStatusAmbienteTunel5.BackColor = Color.Blue
        End If
        'Fim Tunel 5
        '*************************************************

        '*******************************************************
        'Estocagem - Atualização tela
        '*******************************************************
        lblTempEstocagem1.Text = MainForm.Ambientes(6).varTemperatura / 10 & " °C"

        If Not edtSetPointEstocagem1.Focused Then
            edtSetPointEstocagem1.Text = MainForm.Ambientes(6).varSetPoint & " °C"
        End If

        If Not edtOffSetEstocagem1.Focused Then
            edtOffSetEstocagem1.Text = MainForm.Ambientes(6).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(6).bitLDEvap Then
            lblLDEvaporadorEstocagem.Text = "Ligado"
            If MainForm.Ambientes(6).bitFalhaEvaporador1 Or MainForm.Ambientes(6).bitFalhaEvaporador2 Or MainForm.Ambientes(6).bitFalhaEvaporador3 Or MainForm.Ambientes(6).bitFalhaEvaporador4 Then
                lblLDEvaporadorEstocagem.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorEstocagem.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorEstocagem.Text = "Desligado"
            lblLDEvaporadorEstocagem.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(6).bitLDVSSC Then
            lblLDVSSCEstocagem.Text = "Ligado"
            lblLDVSSCEstocagem.BackColor = Color.DarkBlue
        Else
            lblLDVSSCEstocagem.Text = "Desligado"
            lblLDVSSCEstocagem.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(6).bitLDVSLL Then
            lblLDVSLLEstocagem.Text = "Ligado"
            lblLDVSLLEstocagem.BackColor = Color.DarkBlue
        Else
            lblLDVSLLEstocagem.Text = "Desligado"
            lblLDVSLLEstocagem.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(6).bitLDVSGQ Then
            lblLDVSGQEstocagem.Text = "Ligado"
            lblLDVSGQEstocagem.BackColor = Color.DarkRed
        Else
            lblLDVSGQEstocagem.Text = "Desligado"
            lblLDVSGQEstocagem.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(6).bitLDVSAG Then
            lblLDVSAGEstocagem.Text = "Ligado"
            lblLDVSAGEstocagem.BackColor = Color.DarkGreen
        Else
            lblLDVSAGEstocagem.Text = "Desligado"
            lblLDVSAGEstocagem.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(6).bitDegelo Then
            lblLDDegeloEstocagem.Text = "Iniciado"
            lblLDDegeloEstocagem.BackColor = Color.DarkRed
        Else
            lblLDDegeloEstocagem.Text = "Desligado"
            lblLDDegeloEstocagem.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(6).bitMAEvap Then
            lblMAEvaporadorEstocagem.Text = "Automático"
            lblMAEvaporadorEstocagem.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorEstocagem.Text = "Manual"
            lblMAEvaporadorEstocagem.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(6).bitMAVSSC Then
            lblMAVSSCEstocagem.Text = "Automático"
            lblMAVSSCEstocagem.BackColor = Color.DarkBlue
        Else
            lblMAVSSCEstocagem.Text = "Manual"
            lblMAVSSCEstocagem.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(6).bitMAVSLL Then
            lblMAVSLLEstocagem.Text = "Automático"
            lblMAVSLLEstocagem.BackColor = Color.DarkBlue
        Else
            lblMAVSLLEstocagem.Text = "Manual"
            lblMAVSLLEstocagem.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(6).bitMAVSGQ Then
            lblMAVSGQEstocagem.Text = "Automático"
            lblMAVSGQEstocagem.BackColor = Color.DarkBlue
        Else
            lblMAVSGQEstocagem.Text = "Manual"
            lblMAVSGQEstocagem.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(6).bitMAVSAG Then
            lblMAVSAGEstocagem.Text = "Automático"
            lblMAVSAGEstocagem.BackColor = Color.DarkBlue
        Else
            lblMAVSAGEstocagem.Text = "Manual"
            lblMAVSAGEstocagem.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(6).bitMADegelo Then
            lblMADegeloEstocagem.Text = "Automático"
            lblMADegeloEstocagem.BackColor = Color.DarkBlue
        Else
            lblMADegeloEstocagem.Text = "Manual"
            lblMADegeloEstocagem.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(6).bitHabAmbiente Then
            lblHabAmbienteEstocagem.Text = "Habilitado"
            lblHabAmbienteEstocagem.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteEstocagem.Text = "Desabilitado"
            lblHabAmbienteEstocagem.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(6).varStatusAmbiente = 0 Then
            lblStatusAmbienteEstocagem.Text = "Refrig."
            lblStatusAmbienteEstocagem.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(6).varStatusAmbiente = 1 Then
            lblStatusAmbienteEstocagem.Text = "Recolher"
            lblStatusAmbienteEstocagem.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(6).varStatusAmbiente = 2 Then
            lblStatusAmbienteEstocagem.Text = "Pausa"
            lblStatusAmbienteEstocagem.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(6).varStatusAmbiente = 3 Then
            lblStatusAmbienteEstocagem.Text = "Gás Quente"
            lblStatusAmbienteEstocagem.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(6).varStatusAmbiente = 4 Then
            lblStatusAmbienteEstocagem.Text = "Água"
            lblStatusAmbienteEstocagem.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(6).varStatusAmbiente = 5 Then
            lblStatusAmbienteEstocagem.Text = "Gotejam."
            lblStatusAmbienteEstocagem.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(6).varStatusAmbiente = 6 Then
            lblStatusAmbienteEstocagem.Text = "Pré-Resf."
            lblStatusAmbienteEstocagem.BackColor = Color.Blue
        End If
        'Fim Estocagem
        '*************************************************

        '*******************************************************
        'Corredor dos Túneis - Atualização tela
        '*******************************************************
        lblTempCorredor.Text = MainForm.Ambientes(7).varTemperatura / 10 & " °C"

        If Not edtSetPointCorredor.Focused Then
            edtSetPointCorredor.Text = MainForm.Ambientes(7).varSetPoint & " °C"
        End If

        If Not edtOffsetCorredor.Focused Then
            edtOffsetCorredor.Text = MainForm.Ambientes(7).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(7).bitLDEvap Then
            lblLDEvaporadorCorredor.Text = "Ligado"
            If MainForm.Ambientes(7).bitFalhaEvaporador1 Or MainForm.Ambientes(7).bitFalhaEvaporador2 Or MainForm.Ambientes(7).bitFalhaEvaporador3 Or MainForm.Ambientes(7).bitFalhaEvaporador4 Then
                lblLDEvaporadorCorredor.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorCorredor.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorCorredor.Text = "Desligado"
            lblLDEvaporadorCorredor.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(7).bitLDVSSC Then
            lblLDVSSCCorredor.Text = "Ligado"
            lblLDVSSCCorredor.BackColor = Color.DarkBlue
        Else
            lblLDVSSCCorredor.Text = "Desligado"
            lblLDVSSCCorredor.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(7).bitLDVSLL Then
            lblLDVSLLCorredor.Text = "Ligado"
            lblLDVSLLCorredor.BackColor = Color.DarkBlue
        Else
            lblLDVSLLCorredor.Text = "Desligado"
            lblLDVSLLCorredor.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(7).bitLDVSGQ Then
            lblLDVSGQCorredor.Text = "Ligado"
            lblLDVSGQCorredor.BackColor = Color.DarkRed
        Else
            lblLDVSGQCorredor.Text = "Desligado"
            lblLDVSGQCorredor.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(7).bitDegelo Then
            lblLDDegeloCorredor.Text = "Ligado"
            lblLDDegeloCorredor.BackColor = Color.DarkRed
        Else
            lblLDDegeloCorredor.Text = "Desligado"
            lblLDDegeloCorredor.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(7).bitMAEvap Then
            lblMAEvaporadorCorredor.Text = "Automático"
            lblMAEvaporadorCorredor.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorCorredor.Text = "Manual"
            lblMAEvaporadorCorredor.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(7).bitMAVSSC Then
            lblMAVSSCCorredor.Text = "Automático"
            lblMAVSSCCorredor.BackColor = Color.DarkBlue
        Else
            lblMAVSSCCorredor.Text = "Manual"
            lblMAVSSCCorredor.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(7).bitMAVSLL Then
            lblMAVSLLCorredor.Text = "Automático"
            lblMAVSLLCorredor.BackColor = Color.DarkBlue
        Else
            lblMAVSLLCorredor.Text = "Manual"
            lblMAVSLLCorredor.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(7).bitMAVSGQ Then
            lblMAVSGQCorredor.Text = "Automático"
            lblMAVSGQCorredor.BackColor = Color.DarkBlue
        Else
            lblMAVSGQCorredor.Text = "Manual"
            lblMAVSGQCorredor.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(7).bitMADegelo Then
            lblMADegeloCorredor.Text = "Automático"
            lblMADegeloCorredor.BackColor = Color.DarkBlue
        Else
            lblMADegeloCorredor.Text = "Manual"
            lblMADegeloCorredor.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(7).bitHabAmbiente Then
            lblHabAmbienteCorredor.Text = "Habilitado"
            lblHabAmbienteCorredor.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteCorredor.Text = "Desabilitado"
            lblHabAmbienteCorredor.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(7).varStatusAmbiente = 0 Then
            lblStatusAmbienteCorredor.Text = "Refrig."
            lblStatusAmbienteCorredor.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(7).varStatusAmbiente = 1 Then
            lblStatusAmbienteCorredor.Text = "Recolher"
            lblStatusAmbienteCorredor.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(7).varStatusAmbiente = 2 Then
            lblStatusAmbienteCorredor.Text = "Pausa"
            lblStatusAmbienteCorredor.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(7).varStatusAmbiente = 3 Then
            lblStatusAmbienteCorredor.Text = "Gás Quente"
            lblStatusAmbienteCorredor.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(7).varStatusAmbiente = 4 Then
            lblStatusAmbienteCorredor.Text = "Água"
            lblStatusAmbienteCorredor.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(7).varStatusAmbiente = 5 Then
            lblStatusAmbienteCorredor.Text = "Gotejam."
            lblStatusAmbienteCorredor.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(7).varStatusAmbiente = 6 Then
            lblStatusAmbienteCorredor.Text = "Pré-Resf."
            lblStatusAmbienteCorredor.BackColor = Color.Blue
        End If
        'Fim Corredor dos túneis
        '*************************************************

        '*******************************************************
        'Expedição Docas - Atualização tela
        '*******************************************************
        lblTempDocas.Text = MainForm.Ambientes(8).varTemperatura / 10 & " °C"

        If Not edtSetPointDocas.Focused Then
            edtSetPointDocas.Text = MainForm.Ambientes(8).varSetPoint & " °C"
        End If

        If Not edtOffsetDocas.Focused Then
            edtOffsetDocas.Text = MainForm.Ambientes(8).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(8).bitLDEvap Then
            lblLDEvaporadorDocas.Text = "Ligado"
            If MainForm.Ambientes(8).bitFalhaEvaporador1 Or MainForm.Ambientes(8).bitFalhaEvaporador2 Or MainForm.Ambientes(8).bitFalhaEvaporador3 Or MainForm.Ambientes(8).bitFalhaEvaporador4 Then
                lblLDEvaporadorDocas.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorDocas.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorDocas.Text = "Desligado"
            lblLDEvaporadorDocas.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(8).bitLDVSLL Then
            lblLDVSLLDocas.Text = "Ligado"
            lblLDVSLLDocas.BackColor = Color.DarkBlue
        Else
            lblLDVSLLDocas.Text = "Desligado"
            lblLDVSLLDocas.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(8).bitLDVSGQ Then
            lblLDVSGQDocas.Text = "Ligado"
            lblLDVSGQDocas.BackColor = Color.DarkRed
        Else
            lblLDVSGQDocas.Text = "Desligado"
            lblLDVSGQDocas.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(8).bitDegelo Then
            lblLDDegeloDocas.Text = "Ligado"
            lblLDDegeloDocas.BackColor = Color.DarkRed
        Else
            lblLDDegeloDocas.Text = "Desligado"
            lblLDDegeloDocas.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(8).bitMAEvap Then
            lblMAEvaporadorDocas.Text = "Automático"
            lblMAEvaporadorDocas.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorDocas.Text = "Manual"
            lblMAEvaporadorDocas.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(8).bitMAVSLL Then
            lblMAVSLLDocas.Text = "Automático"
            lblMAVSLLDocas.BackColor = Color.DarkBlue
        Else
            lblMAVSLLDocas.Text = "Manual"
            lblMAVSLLDocas.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(8).bitMAVSGQ Then
            lblMAVSGQDocas.Text = "Automático"
            lblMAVSGQDocas.BackColor = Color.DarkBlue
        Else
            lblMAVSGQDocas.Text = "Manual"
            lblMAVSGQDocas.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(8).bitMADegelo Then
            lblMADegeloDocas.Text = "Automático"
            lblMADegeloDocas.BackColor = Color.DarkBlue
        Else
            lblMADegeloDocas.Text = "Manual"
            lblMADegeloDocas.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(8).bitHabAmbiente Then
            lblHabAmbienteDocas.Text = "Habilitado"
            lblHabAmbienteDocas.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteDocas.Text = "Desabilitado"
            lblHabAmbienteDocas.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(8).varStatusAmbiente = 0 Then
            lblStatusAmbienteDocas.Text = "Refrig."
            lblStatusAmbienteDocas.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(8).varStatusAmbiente = 1 Then
            lblStatusAmbienteDocas.Text = "Recolher"
            lblStatusAmbienteDocas.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(8).varStatusAmbiente = 2 Then
            lblStatusAmbienteDocas.Text = "Pausa"
            lblStatusAmbienteDocas.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(8).varStatusAmbiente = 3 Then
            lblStatusAmbienteDocas.Text = "Gás Quente"
            lblStatusAmbienteDocas.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(8).varStatusAmbiente = 4 Then
            lblStatusAmbienteDocas.Text = "Água"
            lblStatusAmbienteDocas.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(8).varStatusAmbiente = 5 Then
            lblStatusAmbienteDocas.Text = "Gotejam."
            lblStatusAmbienteDocas.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(8).varStatusAmbiente = 6 Then
            lblStatusAmbienteDocas.Text = "Pré-Resf."
            lblStatusAmbienteDocas.BackColor = Color.Blue
        End If
        'Fim expedição docas
        '*************************************************


    End Sub

    Private Sub FrmAlaNova_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Timer1.Interval = 500
        Timer1.Enabled = True
        MainForm.MenuPrincipal.Focus()
    End Sub

    Private Sub edtSetPointTunel1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtSetPointTunel1.KeyPress
        If e.KeyChar = Chr(13) Then
            EscreveSetpoint(1, MainForm.Ambientes(1).varADSetpoint, CShort(edtSetPointTunel1.Text))
        End If
    End Sub

    Private Sub edtSetPointTunel2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtSetPointTunel2.KeyPress
        If e.KeyChar = Chr(13) Then
            EscreveSetpoint(1, MainForm.Ambientes(2).varADSetpoint, CShort(edtSetPointTunel2.Text))
        End If
    End Sub

    Private Sub edtSetPointTunel3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtSetPointTunel3.KeyPress
        If e.KeyChar = Chr(13) Then
            EscreveSetpoint(1, MainForm.Ambientes(3).varADSetpoint, CShort(edtSetPointTunel3.Text))
        End If
    End Sub

    Private Sub edtSetPointTunel4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtSetPointTunel4.KeyPress
        If e.KeyChar = Chr(13) Then
            EscreveSetpoint(1, MainForm.Ambientes(4).varADSetpoint, CShort(edtSetPointTunel4.Text))
        End If
    End Sub

    Private Sub edtSetPointTunel5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtSetPointTunel5.KeyPress
        If e.KeyChar = Chr(13) Then
            EscreveSetpoint(1, MainForm.Ambientes(5).varADSetpoint, CShort(edtSetPointTunel5.Text))
        End If
    End Sub

    Private Sub edtSetPointEstocagem1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtSetPointEstocagem1.KeyPress
        If e.KeyChar = Chr(13) Then
            EscreveSetpoint(1, MainForm.Ambientes(6).varADSetpoint, CShort(edtSetPointEstocagem1.Text))
        End If
    End Sub

    Private Sub edtSetPointDocas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtSetPointDocas.KeyPress
        If e.KeyChar = Chr(13) Then
            EscreveSetpoint(1, MainForm.Ambientes(8).varADSetpoint, CShort(edtSetPointDocas.Text))
        End If
    End Sub

    Private Sub edtSetPointCorredor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtSetPointCorredor.KeyPress
        If e.KeyChar = Chr(13) Then
            'res = MainForm.myProtocol.writeSingleRegister(1, 2424 + 1, CShort(edtSetPointCorredor.Text))
            EscreveSetpoint(1, MainForm.Ambientes(7).varADSetpoint, CShort(edtSetPointCorredor.Text))
        End If
    End Sub

    Private Sub lblAtalhoTunel5_Click(sender As Object, e As EventArgs) Handles lblAtalhoTunel5.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 5
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub

    Private Sub labelxx_Click(sender As Object, e As EventArgs) Handles labelxx.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 6
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub

    Private Sub lblAtalhoTunel4_Click(sender As Object, e As EventArgs) Handles lblAtalhoTunel4.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 4
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub

    Private Sub lblAtalhoTunel3_Click(sender As Object, e As EventArgs) Handles lblAtalhoTunel3.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 3
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub

    Private Sub lblAtalhoTunel2_Click(sender As Object, e As EventArgs) Handles lblAtalhoTunel2.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 2
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub

    Private Sub lblAtalhoTunel1_Click(sender As Object, e As EventArgs) Handles lblAtalhoTunel1.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 1
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub

    Private Sub lblAtalhoCorredor_Click(sender As Object, e As EventArgs) Handles lblAtalhoCorredor.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 7
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub

    Private Sub lblAtalhoDocas_Click(sender As Object, e As EventArgs) Handles lblAtalhoDocas.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 8
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub

    Private Sub edtOffSetTunel5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtOffSetTunel5.KeyPress
        Dim Valor As Short
        If e.KeyChar = Chr(13) Then
            Valor = CShort(edtOffSetTunel5.Text) * 10
            EscreveOffSet(1, MainForm.Ambientes(5).varADOffSet, Valor)
        End If
    End Sub

    Private Sub edtOffSetTunel4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtOffSetTunel4.KeyPress
        Dim Valor As Short
        If e.KeyChar = Chr(13) Then
            Valor = CShort(edtOffSetTunel4.Text) * 10
            EscreveOffSet(1, MainForm.Ambientes(4).varADOffSet, Valor)
        End If
    End Sub

    Private Sub edtOffSetTunel3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtOffSetTunel3.KeyPress
        Dim Valor As Short
        If e.KeyChar = Chr(13) Then
            Valor = CShort(edtOffSetTunel3.Text) * 10
            EscreveOffSet(1, MainForm.Ambientes(3).varADOffSet, Valor)
        End If
    End Sub

    Private Sub edtOffSetTunel2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtOffSetTunel2.KeyPress
        Dim Valor As Short
        If e.KeyChar = Chr(13) Then
            Valor = CShort(edtOffSetTunel2.Text) * 10
            EscreveOffSet(1, MainForm.Ambientes(2).varADOffSet, Valor)
        End If
    End Sub

    Private Sub edtOffsetTunel1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtOffsetTunel1.KeyPress
        Dim Valor As Short
        If e.KeyChar = Chr(13) Then
            Valor = CShort(edtOffsetTunel1.Text) * 10
            EscreveOffSet(1, MainForm.Ambientes(1).varADOffSet, Valor)
        End If
    End Sub

    Private Sub edtOffSetEstocagem1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtOffSetEstocagem1.KeyPress
        Dim Valor As Short
        If e.KeyChar = Chr(13) Then
            Valor = CShort(edtOffSetEstocagem1.Text) * 10
            EscreveOffSet(1, MainForm.Ambientes(6).varADOffSet, Valor)
        End If
    End Sub

    Private Sub edtOffsetCorredor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtOffsetCorredor.KeyPress
        Dim Valor As Short
        If e.KeyChar = Chr(13) Then
            Valor = CShort(edtOffsetCorredor.Text) * 10
            EscreveOffSet(1, MainForm.Ambientes(7).varADOffSet, Valor)
        End If
    End Sub

    Private Sub edtOffsetDocas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtOffsetDocas.KeyPress
        Dim Valor As Short
        If e.KeyChar = Chr(13) Then
            Valor = CShort(edtOffsetDocas.Text) * 10
            EscreveOffSet(1, MainForm.Ambientes(8).varADOffSet, Valor)
        End If
    End Sub

End Class