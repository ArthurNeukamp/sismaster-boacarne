Public Class frmCamaras
    Private Sub frmCamaras_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Timer1.Interval = 500
        Timer1.Enabled = True
        MainForm.MenuPrincipal.Focus()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        '*******************************************************
        'Camara 1 - Atualização tela
        '*******************************************************
        lblTempCamara1.Text = MainForm.Ambientes(21).varTemperatura / 10 & " °C"

        If Not edtSetPointCamara1.Focused Then
            edtSetPointCamara1.Text = MainForm.Ambientes(21).varSetPoint & " °C"
        End If

        If Not edtOffSetCamara1.Focused Then
            edtOffSetCamara1.Text = MainForm.Ambientes(21).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(21).bitLDEvap Then
            lblLDEvaporadorCamara1.Text = "Ligado"
            If MainForm.Ambientes(21).bitFalhaEvaporador1 Or MainForm.Ambientes(21).bitFalhaEvaporador2 Or MainForm.Ambientes(21).bitFalhaEvaporador3 Or MainForm.Ambientes(21).bitFalhaEvaporador4 Then
                lblLDEvaporadorCamara1.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorCamara1.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorCamara1.Text = "Desligado"
            lblLDEvaporadorCamara1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(21).bitLDVSSC Then
            lblLDVSSCCamara1.Text = "Ligado"
            lblLDVSSCCamara1.BackColor = Color.DarkBlue
        Else
            lblLDVSSCCamara1.Text = "Desligado"
            lblLDVSSCCamara1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(21).bitLDVSLL Then
            lblLDVSLLCamara1.Text = "Ligado"
            lblLDVSLLCamara1.BackColor = Color.DarkBlue
        Else
            lblLDVSLLCamara1.Text = "Desligado"
            lblLDVSLLCamara1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(21).bitLDVSGQ Then
            lblLDVSGQCamara1.Text = "Ligado"
            lblLDVSGQCamara1.BackColor = Color.DarkRed
        Else
            lblLDVSGQCamara1.Text = "Desligado"
            lblLDVSGQCamara1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(21).bitDegelo Then
            lblLDDegeloCamara1.Text = "Iniciado"
            lblLDDegeloCamara1.BackColor = Color.DarkRed
        Else
            lblLDDegeloCamara1.Text = "Desligado"
            lblLDDegeloCamara1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(21).bitMAEvap Then
            lblMAEvaporadorCamara1.Text = "Automático"
            lblMAEvaporadorCamara1.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorCamara1.Text = "Manual"
            lblMAEvaporadorCamara1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(21).bitMAVSSC Then
            lblMAVSSCCamara1.Text = "Automático"
            lblMAVSSCCamara1.BackColor = Color.DarkBlue
        Else
            lblMAVSSCCamara1.Text = "Manual"
            lblMAVSSCCamara1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(21).bitMAVSLL Then
            lblMAVSLLCamara1.Text = "Automático"
            lblMAVSLLCamara1.BackColor = Color.DarkBlue
        Else
            lblMAVSLLCamara1.Text = "Manual"
            lblMAVSLLCamara1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(21).bitMAVSGQ Then
            lblMAVSGQCamara1.Text = "Automático"
            lblMAVSGQCamara1.BackColor = Color.DarkBlue
        Else
            lblMAVSGQCamara1.Text = "Manual"
            lblMAVSGQCamara1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(21).bitMADegelo Then
            lblMADegeloCamara1.Text = "Automático"
            lblMADegeloCamara1.BackColor = Color.DarkBlue
        Else
            lblMADegeloCamara1.Text = "Manual"
            lblMADegeloCamara1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(21).bitHabAmbiente Then
            lblHabAmbienteCamara1.Text = "Habilitado"
            lblHabAmbienteCamara1.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteCamara1.Text = "Desabilitado"
            lblHabAmbienteCamara1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(21).varStatusAmbiente = 0 Then
            lblStatusAmbienteCamara1.Text = "Refrig."
            lblStatusAmbienteCamara1.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(21).varStatusAmbiente = 1 Then
            lblStatusAmbienteCamara1.Text = "Recolher"
            lblStatusAmbienteCamara1.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(21).varStatusAmbiente = 2 Then
            lblStatusAmbienteCamara1.Text = "Pausa"
            lblStatusAmbienteCamara1.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(21).varStatusAmbiente = 3 Then
            lblStatusAmbienteCamara1.Text = "Gás Quente"
            lblStatusAmbienteCamara1.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(21).varStatusAmbiente = 4 Then
            lblStatusAmbienteCamara1.Text = "Água"
            lblStatusAmbienteCamara1.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(21).varStatusAmbiente = 5 Then
            lblStatusAmbienteCamara1.Text = "Gotejam."
            lblStatusAmbienteCamara1.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(21).varStatusAmbiente = 6 Then
            lblStatusAmbienteCamara1.Text = "Pré-Resf."
            lblStatusAmbienteCamara1.BackColor = Color.Blue
        End If
        'Fim Camara 1
        '*******************************************************

        '*******************************************************
        'Camara 2 - Atualização tela
        '*******************************************************
        lblTempCamara2.Text = MainForm.Ambientes(22).varTemperatura / 10 & " °C"

        If Not edtSetPointCamara2.Focused Then
            edtSetPointCamara2.Text = MainForm.Ambientes(22).varSetPoint & " °C"
        End If

        If Not edtOffSetCamara2.Focused Then
            edtOffSetCamara2.Text = MainForm.Ambientes(22).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(22).bitLDEvap Then
            lblLDEvaporadorCamara2.Text = "Ligado"
            If MainForm.Ambientes(22).bitFalhaEvaporador1 Or MainForm.Ambientes(22).bitFalhaEvaporador2 Or MainForm.Ambientes(22).bitFalhaEvaporador3 Or MainForm.Ambientes(22).bitFalhaEvaporador4 Then
                lblLDEvaporadorCamara2.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorCamara2.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorCamara2.Text = "Desligado"
            lblLDEvaporadorCamara2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(22).bitLDVSSC Then
            lblLDVSSCCamara2.Text = "Ligado"
            lblLDVSSCCamara2.BackColor = Color.DarkBlue
        Else
            lblLDVSSCCamara2.Text = "Desligado"
            lblLDVSSCCamara2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(22).bitLDVSLL Then
            lblLDVSLLCamara2.Text = "Ligado"
            lblLDVSLLCamara2.BackColor = Color.DarkBlue
        Else
            lblLDVSLLCamara2.Text = "Desligado"
            lblLDVSLLCamara2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(22).bitLDVSGQ Then
            lblLDVSGQCamara2.Text = "Ligado"
            lblLDVSGQCamara2.BackColor = Color.DarkRed
        Else
            lblLDVSGQCamara2.Text = "Desligado"
            lblLDVSGQCamara2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(22).bitDegelo Then
            lblLDDegeloCamara2.Text = "Iniciado"
            lblLDDegeloCamara2.BackColor = Color.DarkRed
        Else
            lblLDDegeloCamara2.Text = "Desligado"
            lblLDDegeloCamara2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(22).bitMAEvap Then
            lblMAEvaporadorCamara2.Text = "Automático"
            lblMAEvaporadorCamara2.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorCamara2.Text = "Manual"
            lblMAEvaporadorCamara2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(22).bitMAVSSC Then
            lblMAVSSCCamara2.Text = "Automático"
            lblMAVSSCCamara2.BackColor = Color.DarkBlue
        Else
            lblMAVSSCCamara2.Text = "Manual"
            lblMAVSSCCamara2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(22).bitMAVSLL Then
            lblMAVSLLCamara2.Text = "Automático"
            lblMAVSLLCamara2.BackColor = Color.DarkBlue
        Else
            lblMAVSLLCamara2.Text = "Manual"
            lblMAVSLLCamara2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(22).bitMAVSGQ Then
            lblMAVSGQCamara2.Text = "Automático"
            lblMAVSGQCamara2.BackColor = Color.DarkBlue
        Else
            lblMAVSGQCamara2.Text = "Manual"
            lblMAVSGQCamara2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(22).bitMADegelo Then
            lblMADegeloCamara2.Text = "Automático"
            lblMADegeloCamara2.BackColor = Color.DarkBlue
        Else
            lblMADegeloCamara2.Text = "Manual"
            lblMADegeloCamara2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(22).bitHabAmbiente Then
            lblHabAmbienteCamara2.Text = "Habilitado"
            lblHabAmbienteCamara2.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteCamara2.Text = "Desabilitado"
            lblHabAmbienteCamara2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(22).varStatusAmbiente = 0 Then
            lblStatusAmbienteCamara2.Text = "Refrig."
            lblStatusAmbienteCamara2.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(22).varStatusAmbiente = 1 Then
            lblStatusAmbienteCamara2.Text = "Recolher"
            lblStatusAmbienteCamara2.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(22).varStatusAmbiente = 2 Then
            lblStatusAmbienteCamara2.Text = "Pausa"
            lblStatusAmbienteCamara2.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(22).varStatusAmbiente = 3 Then
            lblStatusAmbienteCamara2.Text = "Gás Quente"
            lblStatusAmbienteCamara2.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(22).varStatusAmbiente = 4 Then
            lblStatusAmbienteCamara2.Text = "Água"
            lblStatusAmbienteCamara2.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(22).varStatusAmbiente = 5 Then
            lblStatusAmbienteCamara2.Text = "Gotejam."
            lblStatusAmbienteCamara2.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(22).varStatusAmbiente = 6 Then
            lblStatusAmbienteCamara2.Text = "Pré-Resf."
            lblStatusAmbienteCamara2.BackColor = Color.Blue
        End If
        'Fim Camara 2
        '*******************************************************

        '*******************************************************
        'Camara 3 - Atualização tela
        '*******************************************************
        lblTempCamara3.Text = MainForm.Ambientes(23).varTemperatura / 10 & " °C"

        If Not edtSetPointCamara3.Focused Then
            edtSetPointCamara3.Text = MainForm.Ambientes(23).varSetPoint & " °C"
        End If

        If Not edtOffSetCamara3.Focused Then
            edtOffSetCamara3.Text = MainForm.Ambientes(23).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(23).bitLDEvap Then
            lblLDEvaporadorCamara3.Text = "Ligado"
            If MainForm.Ambientes(23).bitFalhaEvaporador1 Or MainForm.Ambientes(23).bitFalhaEvaporador2 Or MainForm.Ambientes(23).bitFalhaEvaporador3 Or MainForm.Ambientes(23).bitFalhaEvaporador4 Then
                lblLDEvaporadorCamara3.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorCamara3.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorCamara3.Text = "Desligado"
            lblLDEvaporadorCamara3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(23).bitLDVSSC Then
            lblLDVSSCCamara3.Text = "Ligado"
            lblLDVSSCCamara3.BackColor = Color.DarkBlue
        Else
            lblLDVSSCCamara3.Text = "Desligado"
            lblLDVSSCCamara3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(23).bitLDVSLL Then
            lblLDVSLLCamara3.Text = "Ligado"
            lblLDVSLLCamara3.BackColor = Color.DarkBlue
        Else
            lblLDVSLLCamara3.Text = "Desligado"
            lblLDVSLLCamara3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(23).bitLDVSGQ Then
            lblLDVSGQCamara3.Text = "Ligado"
            lblLDVSGQCamara3.BackColor = Color.DarkRed
        Else
            lblLDVSGQCamara3.Text = "Desligado"
            lblLDVSGQCamara3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(23).bitDegelo Then
            lblLDDegeloCamara3.Text = "Iniciado"
            lblLDDegeloCamara3.BackColor = Color.DarkRed
        Else
            lblLDDegeloCamara3.Text = "Desligado"
            lblLDDegeloCamara3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(23).bitMAEvap Then
            lblMAEvaporadorCamara3.Text = "Automático"
            lblMAEvaporadorCamara3.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorCamara3.Text = "Manual"
            lblMAEvaporadorCamara3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(23).bitMAVSSC Then
            lblMAVSSCCamara3.Text = "Automático"
            lblMAVSSCCamara3.BackColor = Color.DarkBlue
        Else
            lblMAVSSCCamara3.Text = "Manual"
            lblMAVSSCCamara3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(23).bitMAVSLL Then
            lblMAVSLLCamara3.Text = "Automático"
            lblMAVSLLCamara3.BackColor = Color.DarkBlue
        Else
            lblMAVSLLCamara3.Text = "Manual"
            lblMAVSLLCamara3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(23).bitMAVSGQ Then
            lblMAVSGQCamara3.Text = "Automático"
            lblMAVSGQCamara3.BackColor = Color.DarkBlue
        Else
            lblMAVSGQCamara3.Text = "Manual"
            lblMAVSGQCamara3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(23).bitMADegelo Then
            lblMADegeloCamara3.Text = "Automático"
            lblMADegeloCamara3.BackColor = Color.DarkBlue
        Else
            lblMADegeloCamara3.Text = "Manual"
            lblMADegeloCamara3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(23).bitHabAmbiente Then
            lblHabAmbienteCamara3.Text = "Habilitado"
            lblHabAmbienteCamara3.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteCamara3.Text = "Desabilitado"
            lblHabAmbienteCamara3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(23).varStatusAmbiente = 0 Then
            lblStatusAmbienteCamara3.Text = "Refrig."
            lblStatusAmbienteCamara3.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(23).varStatusAmbiente = 1 Then
            lblStatusAmbienteCamara3.Text = "Recolher"
            lblStatusAmbienteCamara3.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(23).varStatusAmbiente = 2 Then
            lblStatusAmbienteCamara3.Text = "Pausa"
            lblStatusAmbienteCamara3.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(23).varStatusAmbiente = 3 Then
            lblStatusAmbienteCamara3.Text = "Gás Quente"
            lblStatusAmbienteCamara3.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(23).varStatusAmbiente = 4 Then
            lblStatusAmbienteCamara3.Text = "Água"
            lblStatusAmbienteCamara3.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(23).varStatusAmbiente = 5 Then
            lblStatusAmbienteCamara3.Text = "Gotejam."
            lblStatusAmbienteCamara3.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(23).varStatusAmbiente = 6 Then
            lblStatusAmbienteCamara3.Text = "Pré-Resf."
            lblStatusAmbienteCamara3.BackColor = Color.Blue
        End If
        'Fim Camara 3
        '*******************************************************

        '*******************************************************
        'Camara 4 - Atualização tela
        '*******************************************************
        lblTempCamara4.Text = MainForm.Ambientes(24).varTemperatura / 10 & " °C"

        If Not edtSetPointCamara4.Focused Then
            edtSetPointCamara4.Text = MainForm.Ambientes(24).varSetPoint & " °C"
        End If

        If Not edtOffSetCamara4.Focused Then
            edtOffSetCamara4.Text = MainForm.Ambientes(24).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(24).bitLDEvap Then
            lblLDEvaporadorCamara4.Text = "Ligado"
            If MainForm.Ambientes(24).bitFalhaEvaporador1 Or MainForm.Ambientes(24).bitFalhaEvaporador2 Or MainForm.Ambientes(24).bitFalhaEvaporador3 Or MainForm.Ambientes(24).bitFalhaEvaporador4 Then
                lblLDEvaporadorCamara4.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorCamara4.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorCamara4.Text = "Desligado"
            lblLDEvaporadorCamara4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(24).bitLDVSSC Then
            lblLDVSSCCamara4.Text = "Ligado"
            lblLDVSSCCamara4.BackColor = Color.DarkBlue
        Else
            lblLDVSSCCamara4.Text = "Desligado"
            lblLDVSSCCamara4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(24).bitLDVSLL Then
            lblLDVSLLCamara4.Text = "Ligado"
            lblLDVSLLCamara4.BackColor = Color.DarkBlue
        Else
            lblLDVSLLCamara4.Text = "Desligado"
            lblLDVSLLCamara4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(24).bitLDVSGQ Then
            lblLDVSGQCamara4.Text = "Ligado"
            lblLDVSGQCamara4.BackColor = Color.DarkRed
        Else
            lblLDVSGQCamara4.Text = "Desligado"
            lblLDVSGQCamara4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(24).bitDegelo Then
            lblLDDegeloCamara4.Text = "Iniciado"
            lblLDDegeloCamara4.BackColor = Color.DarkRed
        Else
            lblLDDegeloCamara4.Text = "Desligado"
            lblLDDegeloCamara4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(24).bitMAEvap Then
            lblMAEvaporadorCamara4.Text = "Automático"
            lblMAEvaporadorCamara4.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorCamara4.Text = "Manual"
            lblMAEvaporadorCamara4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(24).bitMAVSSC Then
            lblMAVSSCCamara4.Text = "Automático"
            lblMAVSSCCamara4.BackColor = Color.DarkBlue
        Else
            lblMAVSSCCamara4.Text = "Manual"
            lblMAVSSCCamara4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(24).bitMAVSLL Then
            lblMAVSLLCamara4.Text = "Automático"
            lblMAVSLLCamara4.BackColor = Color.DarkBlue
        Else
            lblMAVSLLCamara4.Text = "Manual"
            lblMAVSLLCamara4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(24).bitMAVSGQ Then
            lblMAVSGQCamara4.Text = "Automático"
            lblMAVSGQCamara4.BackColor = Color.DarkBlue
        Else
            lblMAVSGQCamara4.Text = "Manual"
            lblMAVSGQCamara4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(24).bitMADegelo Then
            lblMADegeloCamara4.Text = "Automático"
            lblMADegeloCamara4.BackColor = Color.DarkBlue
        Else
            lblMADegeloCamara4.Text = "Manual"
            lblMADegeloCamara4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(24).bitHabAmbiente Then
            lblHabAmbienteCamara4.Text = "Habilitado"
            lblHabAmbienteCamara4.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteCamara4.Text = "Desabilitado"
            lblHabAmbienteCamara4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(24).varStatusAmbiente = 0 Then
            lblStatusAmbienteCamara4.Text = "Refrig."
            lblStatusAmbienteCamara4.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(24).varStatusAmbiente = 1 Then
            lblStatusAmbienteCamara4.Text = "Recolher"
            lblStatusAmbienteCamara4.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(24).varStatusAmbiente = 2 Then
            lblStatusAmbienteCamara4.Text = "Pausa"
            lblStatusAmbienteCamara4.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(24).varStatusAmbiente = 3 Then
            lblStatusAmbienteCamara4.Text = "Gás Quente"
            lblStatusAmbienteCamara4.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(24).varStatusAmbiente = 4 Then
            lblStatusAmbienteCamara4.Text = "Água"
            lblStatusAmbienteCamara4.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(24).varStatusAmbiente = 5 Then
            lblStatusAmbienteCamara4.Text = "Gotejam."
            lblStatusAmbienteCamara4.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(24).varStatusAmbiente = 6 Then
            lblStatusAmbienteCamara4.Text = "Pré-Resf."
            lblStatusAmbienteCamara4.BackColor = Color.Blue
        End If
        'Fim Camara 4
        '*******************************************************

        '*******************************************************
        'Camara 5 - Atualização tela
        '*******************************************************
        lblTempCamara5.Text = MainForm.Ambientes(25).varTemperatura / 10 & " °C"

        If Not edtSetPointCamara5.Focused Then
            edtSetPointCamara5.Text = MainForm.Ambientes(25).varSetPoint & " °C"
        End If

        If Not edtOffSetCamara5.Focused Then
            edtOffSetCamara5.Text = MainForm.Ambientes(25).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(25).bitLDEvap Then
            lblLDEvaporadorCamara5.Text = "Ligado"
            If MainForm.Ambientes(25).bitFalhaEvaporador1 Or MainForm.Ambientes(25).bitFalhaEvaporador2 Or MainForm.Ambientes(25).bitFalhaEvaporador3 Or MainForm.Ambientes(25).bitFalhaEvaporador4 Then
                lblLDEvaporadorCamara5.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorCamara5.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorCamara5.Text = "Desligado"
            lblLDEvaporadorCamara5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(25).bitLDVSSC Then
            lblLDVSSCCamara5.Text = "Ligado"
            lblLDVSSCCamara5.BackColor = Color.DarkBlue
        Else
            lblLDVSSCCamara5.Text = "Desligado"
            lblLDVSSCCamara5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(25).bitLDVSLL Then
            lblLDVSLLCamara5.Text = "Ligado"
            lblLDVSLLCamara5.BackColor = Color.DarkBlue
        Else
            lblLDVSLLCamara5.Text = "Desligado"
            lblLDVSLLCamara5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(25).bitLDVSGQ Then
            lblLDVSGQCamara5.Text = "Ligado"
            lblLDVSGQCamara5.BackColor = Color.DarkRed
        Else
            lblLDVSGQCamara5.Text = "Desligado"
            lblLDVSGQCamara5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(25).bitDegelo Then
            lblLDDegeloCamara5.Text = "Iniciado"
            lblLDDegeloCamara5.BackColor = Color.DarkRed
        Else
            lblLDDegeloCamara5.Text = "Desligado"
            lblLDDegeloCamara5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(25).bitMAEvap Then
            lblMAEvaporadorCamara5.Text = "Automático"
            lblMAEvaporadorCamara5.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorCamara5.Text = "Manual"
            lblMAEvaporadorCamara5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(25).bitMAVSSC Then
            lblMAVSSCCamara5.Text = "Automático"
            lblMAVSSCCamara5.BackColor = Color.DarkBlue
        Else
            lblMAVSSCCamara5.Text = "Manual"
            lblMAVSSCCamara5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(25).bitMAVSLL Then
            lblMAVSLLCamara5.Text = "Automático"
            lblMAVSLLCamara5.BackColor = Color.DarkBlue
        Else
            lblMAVSLLCamara5.Text = "Manual"
            lblMAVSLLCamara5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(25).bitMAVSGQ Then
            lblMAVSGQCamara5.Text = "Automático"
            lblMAVSGQCamara5.BackColor = Color.DarkBlue
        Else
            lblMAVSGQCamara5.Text = "Manual"
            lblMAVSGQCamara5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(25).bitMADegelo Then
            lblMADegeloCamara5.Text = "Automático"
            lblMADegeloCamara5.BackColor = Color.DarkBlue
        Else
            lblMADegeloCamara5.Text = "Manual"
            lblMADegeloCamara5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(25).bitHabAmbiente Then
            lblHabAmbienteCamara5.Text = "Habilitado"
            lblHabAmbienteCamara5.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteCamara5.Text = "Desabilitado"
            lblHabAmbienteCamara5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(25).varStatusAmbiente = 0 Then
            lblStatusAmbienteCamara5.Text = "Refrig."
            lblStatusAmbienteCamara5.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(25).varStatusAmbiente = 1 Then
            lblStatusAmbienteCamara5.Text = "Recolher"
            lblStatusAmbienteCamara5.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(25).varStatusAmbiente = 2 Then
            lblStatusAmbienteCamara5.Text = "Pausa"
            lblStatusAmbienteCamara5.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(25).varStatusAmbiente = 3 Then
            lblStatusAmbienteCamara5.Text = "Gás Quente"
            lblStatusAmbienteCamara5.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(25).varStatusAmbiente = 4 Then
            lblStatusAmbienteCamara5.Text = "Água"
            lblStatusAmbienteCamara5.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(25).varStatusAmbiente = 5 Then
            lblStatusAmbienteCamara5.Text = "Gotejam."
            lblStatusAmbienteCamara5.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(25).varStatusAmbiente = 6 Then
            lblStatusAmbienteCamara5.Text = "Pré-Resf."
            lblStatusAmbienteCamara5.BackColor = Color.Blue
        End If
        'Fim Camara 5
        '*******************************************************

        '*******************************************************
        'Camara 6 - Atualização tela
        '*******************************************************
        lblTempCamara6.Text = MainForm.Ambientes(26).varTemperatura / 10 & " °C"

        If Not edtSetPointCamara6.Focused Then
            edtSetPointCamara6.Text = MainForm.Ambientes(26).varSetPoint & " °C"
        End If

        If Not edtOffSetCamara6.Focused Then
            edtOffSetCamara6.Text = MainForm.Ambientes(26).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(26).bitLDEvap Then
            lblLDEvaporadorCamara6.Text = "Ligado"
            If MainForm.Ambientes(26).bitFalhaEvaporador1 Or MainForm.Ambientes(26).bitFalhaEvaporador2 Or MainForm.Ambientes(26).bitFalhaEvaporador3 Or MainForm.Ambientes(26).bitFalhaEvaporador4 Then
                lblLDEvaporadorCamara6.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorCamara6.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorCamara6.Text = "Desligado"
            lblLDEvaporadorCamara6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(26).bitLDVSSC Then
            lblLDVSSCCamara6.Text = "Ligado"
            lblLDVSSCCamara6.BackColor = Color.DarkBlue
        Else
            lblLDVSSCCamara6.Text = "Desligado"
            lblLDVSSCCamara6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(26).bitLDVSLL Then
            lblLDVSLLCamara6.Text = "Ligado"
            lblLDVSLLCamara6.BackColor = Color.DarkBlue
        Else
            lblLDVSLLCamara6.Text = "Desligado"
            lblLDVSLLCamara6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(26).bitLDVSGQ Then
            lblLDVSGQCamara6.Text = "Ligado"
            lblLDVSGQCamara6.BackColor = Color.DarkRed
        Else
            lblLDVSGQCamara6.Text = "Desligado"
            lblLDVSGQCamara6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(26).bitDegelo Then
            lblLDDegeloCamara6.Text = "Iniciado"
            lblLDDegeloCamara6.BackColor = Color.DarkRed
        Else
            lblLDDegeloCamara6.Text = "Desligado"
            lblLDDegeloCamara6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(26).bitMAEvap Then
            lblMAEvaporadorCamara6.Text = "Automático"
            lblMAEvaporadorCamara6.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorCamara6.Text = "Manual"
            lblMAEvaporadorCamara6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(26).bitMAVSSC Then
            lblMAVSSCCamara6.Text = "Automático"
            lblMAVSSCCamara6.BackColor = Color.DarkBlue
        Else
            lblMAVSSCCamara6.Text = "Manual"
            lblMAVSSCCamara6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(26).bitMAVSLL Then
            lblMAVSLLCamara6.Text = "Automático"
            lblMAVSLLCamara6.BackColor = Color.DarkBlue
        Else
            lblMAVSLLCamara6.Text = "Manual"
            lblMAVSLLCamara6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(26).bitMAVSGQ Then
            lblMAVSGQCamara6.Text = "Automático"
            lblMAVSGQCamara6.BackColor = Color.DarkBlue
        Else
            lblMAVSGQCamara6.Text = "Manual"
            lblMAVSGQCamara6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(26).bitMADegelo Then
            lblMADegeloCamara6.Text = "Automático"
            lblMADegeloCamara6.BackColor = Color.DarkBlue
        Else
            lblMADegeloCamara6.Text = "Manual"
            lblMADegeloCamara6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(26).bitHabAmbiente Then
            lblHabAmbienteCamara6.Text = "Habilitado"
            lblHabAmbienteCamara6.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteCamara6.Text = "Desabilitado"
            lblHabAmbienteCamara6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(26).varStatusAmbiente = 0 Then
            lblStatusAmbienteCamara6.Text = "Refrig."
            lblStatusAmbienteCamara6.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(26).varStatusAmbiente = 1 Then
            lblStatusAmbienteCamara6.Text = "Recolher"
            lblStatusAmbienteCamara6.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(26).varStatusAmbiente = 2 Then
            lblStatusAmbienteCamara6.Text = "Pausa"
            lblStatusAmbienteCamara6.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(26).varStatusAmbiente = 3 Then
            lblStatusAmbienteCamara6.Text = "Gás Quente"
            lblStatusAmbienteCamara6.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(26).varStatusAmbiente = 4 Then
            lblStatusAmbienteCamara6.Text = "Água"
            lblStatusAmbienteCamara6.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(26).varStatusAmbiente = 5 Then
            lblStatusAmbienteCamara6.Text = "Gotejam."
            lblStatusAmbienteCamara6.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(26).varStatusAmbiente = 6 Then
            lblStatusAmbienteCamara6.Text = "Pré-Resf."
            lblStatusAmbienteCamara6.BackColor = Color.Blue
        End If
        'Fim Camara 6
        '*******************************************************

        '*******************************************************
        'Camara 7 - Atualização tela
        '*******************************************************
        lblTempCamara7.Text = MainForm.Ambientes(27).varTemperatura / 10 & " °C"

        If Not edtSetPointCamara7.Focused Then
            edtSetPointCamara7.Text = MainForm.Ambientes(27).varSetPoint & " °C"
        End If

        If Not edtOffSetCamara7.Focused Then
            edtOffSetCamara7.Text = MainForm.Ambientes(27).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(27).bitLDEvap Then
            lblLDEvaporadorCamara7.Text = "Ligado"
            If MainForm.Ambientes(27).bitFalhaEvaporador1 Or MainForm.Ambientes(27).bitFalhaEvaporador2 Or MainForm.Ambientes(27).bitFalhaEvaporador3 Or MainForm.Ambientes(27).bitFalhaEvaporador4 Then
                lblLDEvaporadorCamara7.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorCamara7.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorCamara7.Text = "Desligado"
            lblLDEvaporadorCamara7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(27).bitLDVSSC Then
            lblLDVSSCCamara7.Text = "Ligado"
            lblLDVSSCCamara7.BackColor = Color.DarkBlue
        Else
            lblLDVSSCCamara7.Text = "Desligado"
            lblLDVSSCCamara7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(27).bitLDVSLL Then
            lblLDVSLLCamara7.Text = "Ligado"
            lblLDVSLLCamara7.BackColor = Color.DarkBlue
        Else
            lblLDVSLLCamara7.Text = "Desligado"
            lblLDVSLLCamara7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(27).bitLDVSGQ Then
            lblLDVSGQCamara7.Text = "Ligado"
            lblLDVSGQCamara7.BackColor = Color.DarkRed
        Else
            lblLDVSGQCamara7.Text = "Desligado"
            lblLDVSGQCamara7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(27).bitDegelo Then
            lblLDDegeloCamara7.Text = "Iniciado"
            lblLDDegeloCamara7.BackColor = Color.DarkRed
        Else
            lblLDDegeloCamara7.Text = "Desligado"
            lblLDDegeloCamara7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(27).bitMAEvap Then
            lblMAEvaporadorCamara7.Text = "Automático"
            lblMAEvaporadorCamara7.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorCamara7.Text = "Manual"
            lblMAEvaporadorCamara7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(27).bitMAVSSC Then
            lblMAVSSCCamara7.Text = "Automático"
            lblMAVSSCCamara7.BackColor = Color.DarkBlue
        Else
            lblMAVSSCCamara7.Text = "Manual"
            lblMAVSSCCamara7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(27).bitMAVSLL Then
            lblMAVSLLCamara7.Text = "Automático"
            lblMAVSLLCamara7.BackColor = Color.DarkBlue
        Else
            lblMAVSLLCamara7.Text = "Manual"
            lblMAVSLLCamara7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(27).bitMAVSGQ Then
            lblMAVSGQCamara7.Text = "Automático"
            lblMAVSGQCamara7.BackColor = Color.DarkBlue
        Else
            lblMAVSGQCamara7.Text = "Manual"
            lblMAVSGQCamara7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(27).bitMADegelo Then
            lblMADegeloCamara7.Text = "Automático"
            lblMADegeloCamara7.BackColor = Color.DarkBlue
        Else
            lblMADegeloCamara7.Text = "Manual"
            lblMADegeloCamara7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(27).bitHabAmbiente Then
            lblHabAmbienteCamara7.Text = "Habilitado"
            lblHabAmbienteCamara7.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteCamara7.Text = "Desabilitado"
            lblHabAmbienteCamara7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(27).varStatusAmbiente = 0 Then
            lblStatusAmbienteCamara7.Text = "Refrig."
            lblStatusAmbienteCamara7.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(27).varStatusAmbiente = 1 Then
            lblStatusAmbienteCamara7.Text = "Recolher"
            lblStatusAmbienteCamara7.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(27).varStatusAmbiente = 2 Then
            lblStatusAmbienteCamara7.Text = "Pausa"
            lblStatusAmbienteCamara7.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(27).varStatusAmbiente = 3 Then
            lblStatusAmbienteCamara7.Text = "Gás Quente"
            lblStatusAmbienteCamara7.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(27).varStatusAmbiente = 4 Then
            lblStatusAmbienteCamara7.Text = "Água"
            lblStatusAmbienteCamara7.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(27).varStatusAmbiente = 5 Then
            lblStatusAmbienteCamara7.Text = "Gotejam."
            lblStatusAmbienteCamara7.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(27).varStatusAmbiente = 6 Then
            lblStatusAmbienteCamara7.Text = "Pré-Resf."
            lblStatusAmbienteCamara7.BackColor = Color.Blue
        End If
        'Fim Camara 7
        '*******************************************************

        '*******************************************************
        'Camara Pulmao - Atualização tela
        '*******************************************************
        lblTempPulmao.Text = MainForm.Ambientes(28).varTemperatura / 10 & " °C"

        If Not edtSetPointPulmao.Focused Then
            edtSetPointPulmao.Text = MainForm.Ambientes(28).varSetPoint & " °C"
        End If

        If Not edtOffSetPulmao.Focused Then
            edtOffSetPulmao.Text = MainForm.Ambientes(28).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(28).bitLDEvap Then
            lblLDEvaporadorPulmao.Text = "Ligado"
            If MainForm.Ambientes(28).bitFalhaEvaporador1 Or MainForm.Ambientes(28).bitFalhaEvaporador2 Or MainForm.Ambientes(28).bitFalhaEvaporador3 Or MainForm.Ambientes(28).bitFalhaEvaporador4 Then
                lblLDEvaporadorPulmao.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorPulmao.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorPulmao.Text = "Desligado"
            lblLDEvaporadorPulmao.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(28).bitLDVSSC Then
            lblLDVSSCPulmao.Text = "Ligado"
            lblLDVSSCPulmao.BackColor = Color.DarkBlue
        Else
            lblLDVSSCPulmao.Text = "Desligado"
            lblLDVSSCPulmao.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(28).bitLDVSLL Then
            lblLDVSLLPulmao.Text = "Ligado"
            lblLDVSLLPulmao.BackColor = Color.DarkBlue
        Else
            lblLDVSLLPulmao.Text = "Desligado"
            lblLDVSLLPulmao.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(28).bitLDVSGQ Then
            lblLDVSGQPulmao.Text = "Ligado"
            lblLDVSGQPulmao.BackColor = Color.DarkRed
        Else
            lblLDVSGQPulmao.Text = "Desligado"
            lblLDVSGQPulmao.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(28).bitDegelo Then
            lblLDDegeloPulmao.Text = "Iniciado"
            lblLDDegeloPulmao.BackColor = Color.DarkRed
        Else
            lblLDDegeloPulmao.Text = "Desligado"
            lblLDDegeloPulmao.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(28).bitMAEvap Then
            lblMAEvaporadorPulmao.Text = "Automático"
            lblMAEvaporadorPulmao.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorPulmao.Text = "Manual"
            lblMAEvaporadorPulmao.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(28).bitMAVSSC Then
            lblMAVSSCPulmao.Text = "Automático"
            lblMAVSSCPulmao.BackColor = Color.DarkBlue
        Else
            lblMAVSSCPulmao.Text = "Manual"
            lblMAVSSCPulmao.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(28).bitMAVSLL Then
            lblMAVSLLPulmao.Text = "Automático"
            lblMAVSLLPulmao.BackColor = Color.DarkBlue
        Else
            lblMAVSLLPulmao.Text = "Manual"
            lblMAVSLLPulmao.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(28).bitMAVSGQ Then
            lblMAVSGQPulmao.Text = "Automático"
            lblMAVSGQPulmao.BackColor = Color.DarkBlue
        Else
            lblMAVSGQPulmao.Text = "Manual"
            lblMAVSGQPulmao.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(28).bitMADegelo Then
            lblMADegeloPulmao.Text = "Automático"
            lblMADegeloPulmao.BackColor = Color.DarkBlue
        Else
            lblMADegeloPulmao.Text = "Manual"
            lblMADegeloPulmao.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(28).bitHabAmbiente Then
            lblHabAmbientePulmao.Text = "Habilitado"
            lblHabAmbientePulmao.BackColor = Color.DarkBlue
        Else
            lblHabAmbientePulmao.Text = "Desabilitado"
            lblHabAmbientePulmao.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(28).varStatusAmbiente = 0 Then
            lblStatusAmbientePulmao.Text = "Refrig."
            lblStatusAmbientePulmao.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(28).varStatusAmbiente = 1 Then
            lblStatusAmbientePulmao.Text = "Recolher"
            lblStatusAmbientePulmao.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(28).varStatusAmbiente = 2 Then
            lblStatusAmbientePulmao.Text = "Pausa"
            lblStatusAmbientePulmao.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(28).varStatusAmbiente = 3 Then
            lblStatusAmbientePulmao.Text = "Gás Quente"
            lblStatusAmbientePulmao.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(28).varStatusAmbiente = 4 Then
            lblStatusAmbientePulmao.Text = "Água"
            lblStatusAmbientePulmao.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(28).varStatusAmbiente = 5 Then
            lblStatusAmbientePulmao.Text = "Gotejam."
            lblStatusAmbientePulmao.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(28).varStatusAmbiente = 6 Then
            lblStatusAmbientePulmao.Text = "Pré-Resf."
            lblStatusAmbientePulmao.BackColor = Color.Blue
        End If
        'Fim Camara Pulmao
        '*******************************************************

    End Sub

    Private Sub lblAtalhoCamara1_Click(sender As Object, e As EventArgs) Handles lblAtalhoCamara1.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 21
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub

    Private Sub lblAtalhoCamara2_Click(sender As Object, e As EventArgs) Handles lblAtalhoCamara2.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 22
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub

    Private Sub lblAtalhoCamara3_Click(sender As Object, e As EventArgs) Handles lblAtalhoCamara3.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 23
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub

    Private Sub lblAtalhoCamara4_Click(sender As Object, e As EventArgs) Handles lblAtalhoCamara4.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 24
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub

    Private Sub lblAtalhoCamara5_Click(sender As Object, e As EventArgs) Handles lblAtalhoCamara5.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 25
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub

    Private Sub lblAtalhoCamara6_Click(sender As Object, e As EventArgs) Handles lblAtalhoCamara6.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 26
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub

    Private Sub lblAtalhoCamara7_Click(sender As Object, e As EventArgs) Handles lblAtalhoCamara7.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 27
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub

    Private Sub lblAtalhoPulmao_Click(sender As Object, e As EventArgs) Handles lblAtalhoPulmao.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 28
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub
End Class