Public Class FrmTuneis47
    Private Sub Form8_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Timer1.Interval = 500
        Timer1.Enabled = True
        MainForm.MenuPrincipal.Focus()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        '*******************************************************
        'Tunel 4 - Atualização tela
        '*******************************************************
        lblTempTunel4.Text = MainForm.Ambientes(11).varTemperatura / 10 & " °C"

        If Not edtSetPointTunel4.Focused Then
            edtSetPointTunel4.Text = MainForm.Ambientes(11).varSetPoint & " °C"
        End If

        If Not edtOffSetTunel4.Focused Then
            edtOffSetTunel4.Text = MainForm.Ambientes(11).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(11).bitLDEvap Then
            lblLDEvaporadorTunel4.Text = "Ligado"
            If MainForm.Ambientes(11).bitFalhaEvaporador1 Or MainForm.Ambientes(11).bitFalhaEvaporador2 Or MainForm.Ambientes(11).bitFalhaEvaporador3 Or MainForm.Ambientes(11).bitFalhaEvaporador4 Then
                lblLDEvaporadorTunel4.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorTunel4.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorTunel4.Text = "Desligado"
            lblLDEvaporadorTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(11).bitLDVSSC Then
            lblLDVSSCTunel4.Text = "Ligado"
            lblLDVSSCTunel4.BackColor = Color.DarkBlue
        Else
            lblLDVSSCTunel4.Text = "Desligado"
            lblLDVSSCTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(11).bitLDVSLL Then
            lblLDVSLLTunel4.Text = "Ligado"
            lblLDVSLLTunel4.BackColor = Color.DarkBlue
        Else
            lblLDVSLLTunel4.Text = "Desligado"
            lblLDVSLLTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(11).bitLDVSGQ Then
            lblLDVSGQTunel4.Text = "Ligado"
            lblLDVSGQTunel4.BackColor = Color.DarkRed
        Else
            lblLDVSGQTunel4.Text = "Desligado"
            lblLDVSGQTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(11).bitLDVSAG Then
            lblLDVSAGTunel4.Text = "Ligado"
            lblLDVSAGTunel4.BackColor = Color.DarkGreen
        Else
            lblLDVSAGTunel4.Text = "Desligado"
            lblLDVSAGTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(11).bitDegelo Then
            lblLDDegeloTunel4.Text = "Iniciado"
            lblLDDegeloTunel4.BackColor = Color.DarkRed
        Else
            lblLDDegeloTunel4.Text = "Desligado"
            lblLDDegeloTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(11).bitMAEvap Then
            lblMAEvaporadorTunel4.Text = "Automático"
            lblMAEvaporadorTunel4.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorTunel4.Text = "Manual"
            lblMAEvaporadorTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(11).bitMAVSSC Then
            lblMAVSSCTunel4.Text = "Automático"
            lblMAVSSCTunel4.BackColor = Color.DarkBlue
        Else
            lblMAVSSCTunel4.Text = "Manual"
            lblMAVSSCTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(11).bitMAVSLL Then
            lblMAVSLLTunel4.Text = "Automático"
            lblMAVSLLTunel4.BackColor = Color.DarkBlue
        Else
            lblMAVSLLTunel4.Text = "Manual"
            lblMAVSLLTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(11).bitMAVSGQ Then
            lblMAVSGQTunel4.Text = "Automático"
            lblMAVSGQTunel4.BackColor = Color.DarkBlue
        Else
            lblMAVSGQTunel4.Text = "Manual"
            lblMAVSGQTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(11).bitMAVSAG Then
            lblMAVSAGTunel4.Text = "Automático"
            lblMAVSAGTunel4.BackColor = Color.DarkBlue
        Else
            lblMAVSAGTunel4.Text = "Manual"
            lblMAVSAGTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(11).bitMADegelo Then
            lblMADegeloTunel4.Text = "Automático"
            lblMADegeloTunel4.BackColor = Color.DarkBlue
        Else
            lblMADegeloTunel4.Text = "Manual"
            lblMADegeloTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(11).bitHabAmbiente Then
            lblHabAmbienteTunel4.Text = "Habilitado"
            lblHabAmbienteTunel4.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteTunel4.Text = "Desabilitado"
            lblHabAmbienteTunel4.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(11).varStatusAmbiente = 0 Then
            lblStatusAmbienteTunel4.Text = "Refrig."
            lblStatusAmbienteTunel4.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(11).varStatusAmbiente = 1 Then
            lblStatusAmbienteTunel4.Text = "Recolher"
            lblStatusAmbienteTunel4.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(11).varStatusAmbiente = 2 Then
            lblStatusAmbienteTunel4.Text = "Pausa"
            lblStatusAmbienteTunel4.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(11).varStatusAmbiente = 3 Then
            lblStatusAmbienteTunel4.Text = "Gás Quente"
            lblStatusAmbienteTunel4.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(11).varStatusAmbiente = 4 Then
            lblStatusAmbienteTunel4.Text = "Água"
            lblStatusAmbienteTunel4.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(11).varStatusAmbiente = 5 Then
            lblStatusAmbienteTunel4.Text = "Gotejam."
            lblStatusAmbienteTunel4.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(11).varStatusAmbiente = 6 Then
            lblStatusAmbienteTunel4.Text = "Pré-Resf."
            lblStatusAmbienteTunel4.BackColor = Color.Blue
        End If
        'Fim Tunel 4
        '*******************************************************

        '*******************************************************
        'Tunel 5 - Atualização tela
        '*******************************************************
        lblTempTunel5.Text = MainForm.Ambientes(12).varTemperatura / 10 & " °C"

        If Not edtSetPointTunel5.Focused Then
            edtSetPointTunel5.Text = MainForm.Ambientes(12).varSetPoint & " °C"
        End If

        If Not edtOffSetTunel5.Focused Then
            edtOffSetTunel5.Text = MainForm.Ambientes(12).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(12).bitLDEvap Then
            lblLDEvaporadorTunel5.Text = "Ligado"
            If MainForm.Ambientes(12).bitFalhaEvaporador1 Or MainForm.Ambientes(12).bitFalhaEvaporador2 Or MainForm.Ambientes(12).bitFalhaEvaporador3 Or MainForm.Ambientes(12).bitFalhaEvaporador4 Then
                lblLDEvaporadorTunel5.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorTunel5.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorTunel5.Text = "Desligado"
            lblLDEvaporadorTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(12).bitLDVSSC Then
            lblLDVSSCTunel5.Text = "Ligado"
            lblLDVSSCTunel5.BackColor = Color.DarkBlue
        Else
            lblLDVSSCTunel5.Text = "Desligado"
            lblLDVSSCTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(12).bitLDVSLL Then
            lblLDVSLLTunel5.Text = "Ligado"
            lblLDVSLLTunel5.BackColor = Color.DarkBlue
        Else
            lblLDVSLLTunel5.Text = "Desligado"
            lblLDVSLLTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(12).bitLDVSGQ Then
            lblLDVSGQTunel5.Text = "Ligado"
            lblLDVSGQTunel5.BackColor = Color.DarkRed
        Else
            lblLDVSGQTunel5.Text = "Desligado"
            lblLDVSGQTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(12).bitLDVSAG Then
            lblLDVSAGTunel5.Text = "Ligado"
            lblLDVSAGTunel5.BackColor = Color.DarkGreen
        Else
            lblLDVSAGTunel5.Text = "Desligado"
            lblLDVSAGTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(12).bitDegelo Then
            lblLDDegeloTunel5.Text = "Iniciado"
            lblLDDegeloTunel5.BackColor = Color.DarkRed
        Else
            lblLDDegeloTunel5.Text = "Desligado"
            lblLDDegeloTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(12).bitMAEvap Then
            lblMAEvaporadorTunel5.Text = "Automático"
            lblMAEvaporadorTunel5.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorTunel5.Text = "Manual"
            lblMAEvaporadorTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(12).bitMAVSSC Then
            lblMAVSSCTunel5.Text = "Automático"
            lblMAVSSCTunel5.BackColor = Color.DarkBlue
        Else
            lblMAVSSCTunel5.Text = "Manual"
            lblMAVSSCTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(12).bitMAVSLL Then
            lblMAVSLLTunel5.Text = "Automático"
            lblMAVSLLTunel5.BackColor = Color.DarkBlue
        Else
            lblMAVSLLTunel5.Text = "Manual"
            lblMAVSLLTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(12).bitMAVSGQ Then
            lblMAVSGQTunel5.Text = "Automático"
            lblMAVSGQTunel5.BackColor = Color.DarkBlue
        Else
            lblMAVSGQTunel5.Text = "Manual"
            lblMAVSGQTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(12).bitMAVSAG Then
            lblMAVSAGTunel5.Text = "Automático"
            lblMAVSAGTunel5.BackColor = Color.DarkBlue
        Else
            lblMAVSAGTunel5.Text = "Manual"
            lblMAVSAGTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(12).bitMADegelo Then
            lblMADegeloTunel5.Text = "Automático"
            lblMADegeloTunel5.BackColor = Color.DarkBlue
        Else
            lblMADegeloTunel5.Text = "Manual"
            lblMADegeloTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(12).bitHabAmbiente Then
            lblHabAmbienteTunel5.Text = "Habilitado"
            lblHabAmbienteTunel5.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteTunel5.Text = "Desabilitado"
            lblHabAmbienteTunel5.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(12).varStatusAmbiente = 0 Then
            lblStatusAmbienteTunel5.Text = "Refrig."
            lblStatusAmbienteTunel5.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(12).varStatusAmbiente = 1 Then
            lblStatusAmbienteTunel5.Text = "Recolher"
            lblStatusAmbienteTunel5.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(12).varStatusAmbiente = 2 Then
            lblStatusAmbienteTunel5.Text = "Pausa"
            lblStatusAmbienteTunel5.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(12).varStatusAmbiente = 3 Then
            lblStatusAmbienteTunel5.Text = "Gás Quente"
            lblStatusAmbienteTunel5.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(12).varStatusAmbiente = 4 Then
            lblStatusAmbienteTunel5.Text = "Água"
            lblStatusAmbienteTunel5.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(12).varStatusAmbiente = 5 Then
            lblStatusAmbienteTunel5.Text = "Gotejam."
            lblStatusAmbienteTunel5.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(12).varStatusAmbiente = 6 Then
            lblStatusAmbienteTunel5.Text = "Pré-Resf."
            lblStatusAmbienteTunel5.BackColor = Color.Blue
        End If
        'Fim Tunel 5
        '*******************************************************

        '*******************************************************
        'Tunel 6 - Atualização tela
        '*******************************************************
        lblTempTunel6.Text = MainForm.Ambientes(13).varTemperatura / 10 & " °C"

        If Not edtSetPointTunel6.Focused Then
            edtSetPointTunel6.Text = MainForm.Ambientes(13).varSetPoint & " °C"
        End If

        If Not edtOffSetTunel6.Focused Then
            edtOffSetTunel6.Text = MainForm.Ambientes(13).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(13).bitLDEvap Then
            lblLDEvaporadorTunel6.Text = "Ligado"
            If MainForm.Ambientes(13).bitFalhaEvaporador1 Or MainForm.Ambientes(13).bitFalhaEvaporador2 Or MainForm.Ambientes(13).bitFalhaEvaporador3 Or MainForm.Ambientes(13).bitFalhaEvaporador4 Then
                lblLDEvaporadorTunel6.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorTunel6.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorTunel6.Text = "Desligado"
            lblLDEvaporadorTunel6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(13).bitLDVSSC Then
            lblLDVSSCTunel6.Text = "Ligado"
            lblLDVSSCTunel6.BackColor = Color.DarkBlue
        Else
            lblLDVSSCTunel6.Text = "Desligado"
            lblLDVSSCTunel6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(13).bitLDVSLL Then
            lblLDVSLLTunel6.Text = "Ligado"
            lblLDVSLLTunel6.BackColor = Color.DarkBlue
        Else
            lblLDVSLLTunel6.Text = "Desligado"
            lblLDVSLLTunel6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(13).bitLDVSGQ Then
            lblLDVSGQTunel6.Text = "Ligado"
            lblLDVSGQTunel6.BackColor = Color.DarkRed
        Else
            lblLDVSGQTunel6.Text = "Desligado"
            lblLDVSGQTunel6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(13).bitLDVSAG Then
            lblLDVSAGTunel6.Text = "Ligado"
            lblLDVSAGTunel6.BackColor = Color.DarkGreen
        Else
            lblLDVSAGTunel6.Text = "Desligado"
            lblLDVSAGTunel6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(13).bitDegelo Then
            lblLDDegeloTunel6.Text = "Iniciado"
            lblLDDegeloTunel6.BackColor = Color.DarkRed
        Else
            lblLDDegeloTunel6.Text = "Desligado"
            lblLDDegeloTunel6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(13).bitMAEvap Then
            lblMAEvaporadorTunel6.Text = "Automático"
            lblMAEvaporadorTunel6.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorTunel6.Text = "Manual"
            lblMAEvaporadorTunel6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(13).bitMAVSSC Then
            lblMAVSSCTunel6.Text = "Automático"
            lblMAVSSCTunel6.BackColor = Color.DarkBlue
        Else
            lblMAVSSCTunel6.Text = "Manual"
            lblMAVSSCTunel6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(13).bitMAVSLL Then
            lblMAVSLLTunel6.Text = "Automático"
            lblMAVSLLTunel6.BackColor = Color.DarkBlue
        Else
            lblMAVSLLTunel6.Text = "Manual"
            lblMAVSLLTunel6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(13).bitMAVSGQ Then
            lblMAVSGQTunel6.Text = "Automático"
            lblMAVSGQTunel6.BackColor = Color.DarkBlue
        Else
            lblMAVSGQTunel6.Text = "Manual"
            lblMAVSGQTunel6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(13).bitMAVSAG Then
            lblMAVSAGTunel6.Text = "Automático"
            lblMAVSAGTunel6.BackColor = Color.DarkBlue
        Else
            lblMAVSAGTunel6.Text = "Manual"
            lblMAVSAGTunel6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(13).bitMADegelo Then
            lblMADegeloTunel6.Text = "Automático"
            lblMADegeloTunel6.BackColor = Color.DarkBlue
        Else
            lblMADegeloTunel6.Text = "Manual"
            lblMADegeloTunel6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(13).bitHabAmbiente Then
            lblHabAmbienteTunel6.Text = "Habilitado"
            lblHabAmbienteTunel6.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteTunel6.Text = "Desabilitado"
            lblHabAmbienteTunel6.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(13).varStatusAmbiente = 0 Then
            lblStatusAmbienteTunel6.Text = "Refrig."
            lblStatusAmbienteTunel6.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(13).varStatusAmbiente = 1 Then
            lblStatusAmbienteTunel6.Text = "Recolher"
            lblStatusAmbienteTunel6.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(13).varStatusAmbiente = 2 Then
            lblStatusAmbienteTunel6.Text = "Pausa"
            lblStatusAmbienteTunel6.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(13).varStatusAmbiente = 3 Then
            lblStatusAmbienteTunel6.Text = "Gás Quente"
            lblStatusAmbienteTunel6.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(13).varStatusAmbiente = 4 Then
            lblStatusAmbienteTunel6.Text = "Água"
            lblStatusAmbienteTunel6.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(13).varStatusAmbiente = 5 Then
            lblStatusAmbienteTunel6.Text = "Gotejam."
            lblStatusAmbienteTunel6.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(13).varStatusAmbiente = 6 Then
            lblStatusAmbienteTunel6.Text = "Pré-Resf."
            lblStatusAmbienteTunel6.BackColor = Color.Blue
        End If
        'Fim Tunel 5
        '*******************************************************

        '*******************************************************
        'Tunel 7 - Atualização tela
        '*******************************************************
        lblTempTunel7.Text = MainForm.Ambientes(14).varTemperatura / 10 & " °C"

        If Not edtSetPointTunel7.Focused Then
            edtSetPointTunel7.Text = MainForm.Ambientes(14).varSetPoint & " °C"
        End If

        If Not edtOffSetTunel7.Focused Then
            edtOffSetTunel7.Text = MainForm.Ambientes(14).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(14).bitLDEvap Then
            lblLDEvaporadorTunel7.Text = "Ligado"
            If MainForm.Ambientes(14).bitFalhaEvaporador1 Or MainForm.Ambientes(14).bitFalhaEvaporador2 Or MainForm.Ambientes(14).bitFalhaEvaporador3 Or MainForm.Ambientes(14).bitFalhaEvaporador4 Then
                lblLDEvaporadorTunel7.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorTunel7.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorTunel7.Text = "Desligado"
            lblLDEvaporadorTunel7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(14).bitLDVSSC Then
            lblLDVSSCTunel7.Text = "Ligado"
            lblLDVSSCTunel7.BackColor = Color.DarkBlue
        Else
            lblLDVSSCTunel7.Text = "Desligado"
            lblLDVSSCTunel7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(14).bitLDVSLL Then
            lblLDVSLLTunel7.Text = "Ligado"
            lblLDVSLLTunel7.BackColor = Color.DarkBlue
        Else
            lblLDVSLLTunel7.Text = "Desligado"
            lblLDVSLLTunel7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(14).bitLDVSGQ Then
            lblLDVSGQTunel7.Text = "Ligado"
            lblLDVSGQTunel7.BackColor = Color.DarkRed
        Else
            lblLDVSGQTunel7.Text = "Desligado"
            lblLDVSGQTunel7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(14).bitLDVSAG Then
            lblLDVSAGTunel7.Text = "Ligado"
            lblLDVSAGTunel7.BackColor = Color.DarkGreen
        Else
            lblLDVSAGTunel7.Text = "Desligado"
            lblLDVSAGTunel7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(14).bitDegelo Then
            lblLDDegeloTunel7.Text = "Iniciado"
            lblLDDegeloTunel7.BackColor = Color.DarkRed
        Else
            lblLDDegeloTunel7.Text = "Desligado"
            lblLDDegeloTunel7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(14).bitMAEvap Then
            lblMAEvaporadorTunel7.Text = "Automático"
            lblMAEvaporadorTunel7.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorTunel7.Text = "Manual"
            lblMAEvaporadorTunel7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(14).bitMAVSSC Then
            lblMAVSSCTunel7.Text = "Automático"
            lblMAVSSCTunel7.BackColor = Color.DarkBlue
        Else
            lblMAVSSCTunel7.Text = "Manual"
            lblMAVSSCTunel7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(14).bitMAVSLL Then
            lblMAVSLLTunel7.Text = "Automático"
            lblMAVSLLTunel7.BackColor = Color.DarkBlue
        Else
            lblMAVSLLTunel7.Text = "Manual"
            lblMAVSLLTunel7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(14).bitMAVSGQ Then
            lblMAVSGQTunel7.Text = "Automático"
            lblMAVSGQTunel7.BackColor = Color.DarkBlue
        Else
            lblMAVSGQTunel7.Text = "Manual"
            lblMAVSGQTunel7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(14).bitMAVSAG Then
            lblMAVSAGTunel7.Text = "Automático"
            lblMAVSAGTunel7.BackColor = Color.DarkBlue
        Else
            lblMAVSAGTunel7.Text = "Manual"
            lblMAVSAGTunel7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(14).bitMADegelo Then
            lblMADegeloTunel7.Text = "Automático"
            lblMADegeloTunel7.BackColor = Color.DarkBlue
        Else
            lblMADegeloTunel7.Text = "Manual"
            lblMADegeloTunel7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(14).bitHabAmbiente Then
            lblHabAmbienteTunel7.Text = "Habilitado"
            lblHabAmbienteTunel7.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteTunel7.Text = "Desabilitado"
            lblHabAmbienteTunel7.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(14).varStatusAmbiente = 0 Then
            lblStatusAmbienteTunel7.Text = "Refrig."
            lblStatusAmbienteTunel7.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(14).varStatusAmbiente = 1 Then
            lblStatusAmbienteTunel7.Text = "Recolher"
            lblStatusAmbienteTunel7.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(14).varStatusAmbiente = 2 Then
            lblStatusAmbienteTunel7.Text = "Pausa"
            lblStatusAmbienteTunel7.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(14).varStatusAmbiente = 3 Then
            lblStatusAmbienteTunel7.Text = "Gás Quente"
            lblStatusAmbienteTunel7.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(14).varStatusAmbiente = 4 Then
            lblStatusAmbienteTunel7.Text = "Água"
            lblStatusAmbienteTunel7.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(14).varStatusAmbiente = 5 Then
            lblStatusAmbienteTunel7.Text = "Gotejam."
            lblStatusAmbienteTunel7.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(14).varStatusAmbiente = 6 Then
            lblStatusAmbienteTunel7.Text = "Pré-Resf."
            lblStatusAmbienteTunel7.BackColor = Color.Blue
        End If
        'Fim Tunel 7
        '*******************************************************

        '*******************************************************
        'Estocagem 1 - Atualização tela
        '*******************************************************
        lblTempEstocagem1.Text = MainForm.Ambientes(15).varTemperatura / 10 & " °C"

        If Not edtSetPointEstocagem1.Focused Then
            edtSetPointEstocagem1.Text = MainForm.Ambientes(15).varSetPoint & " °C"
        End If

        If Not edtOffsetEstocagem1.Focused Then
            edtOffsetEstocagem1.Text = MainForm.Ambientes(15).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(15).bitLDEvap Then
            lblLDEvaporadorEstocagem1.Text = "Ligado"
            If MainForm.Ambientes(15).bitFalhaEvaporador1 Or MainForm.Ambientes(15).bitFalhaEvaporador2 Or MainForm.Ambientes(15).bitFalhaEvaporador3 Or MainForm.Ambientes(15).bitFalhaEvaporador4 Then
                lblLDEvaporadorEstocagem1.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorEstocagem1.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorEstocagem1.Text = "Desligado"
            lblLDEvaporadorEstocagem1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(15).bitLDVSSC Then
            lblLDVSSCEstocagem1.Text = "Ligado"
            lblLDVSSCEstocagem1.BackColor = Color.DarkBlue
        Else
            lblLDVSSCEstocagem1.Text = "Desligado"
            lblLDVSSCEstocagem1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(15).bitLDVSLL Then
            lblLDVSLLEstocagem1.Text = "Ligado"
            lblLDVSLLEstocagem1.BackColor = Color.DarkBlue
        Else
            lblLDVSLLEstocagem1.Text = "Desligado"
            lblLDVSLLEstocagem1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(15).bitLDVSGQ Then
            lblLDVSGQEstocagem1.Text = "Ligado"
            lblLDVSGQEstocagem1.BackColor = Color.DarkRed
        Else
            lblLDVSGQEstocagem1.Text = "Desligado"
            lblLDVSGQEstocagem1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(15).bitLDVSAG Then
            lblLDVSAGEstocagem1.Text = "Ligado"
            lblLDVSAGEstocagem1.BackColor = Color.DarkGreen
        Else
            lblLDVSAGEstocagem1.Text = "Desligado"
            lblLDVSAGEstocagem1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(15).bitDegelo Then
            lblLDDegeloEstocagem1.Text = "Iniciado"
            lblLDDegeloEstocagem1.BackColor = Color.DarkRed
        Else
            lblLDDegeloEstocagem1.Text = "Desligado"
            lblLDDegeloEstocagem1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(15).bitMAEvap Then
            lblMAEvaporadorEstocagem1.Text = "Automático"
            lblMAEvaporadorEstocagem1.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorEstocagem1.Text = "Manual"
            lblMAEvaporadorEstocagem1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(15).bitMAVSSC Then
            lblMAVSSCEstocagem1.Text = "Automático"
            lblMAVSSCEstocagem1.BackColor = Color.DarkBlue
        Else
            lblMAVSSCEstocagem1.Text = "Manual"
            lblMAVSSCEstocagem1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(15).bitMAVSLL Then
            lblMAVSLLEstocagem1.Text = "Automático"
            lblMAVSLLEstocagem1.BackColor = Color.DarkBlue
        Else
            lblMAVSLLEstocagem1.Text = "Manual"
            lblMAVSLLEstocagem1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(15).bitMAVSGQ Then
            lblMAVSGQEstocagem1.Text = "Automático"
            lblMAVSGQEstocagem1.BackColor = Color.DarkBlue
        Else
            lblMAVSGQEstocagem1.Text = "Manual"
            lblMAVSGQEstocagem1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(15).bitMAVSAG Then
            lblMAVSAGEstocagem1.Text = "Automático"
            lblMAVSAGEstocagem1.BackColor = Color.DarkBlue
        Else
            lblMAVSAGEstocagem1.Text = "Manual"
            lblMAVSAGEstocagem1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(15).bitMADegelo Then
            lblMADegeloEstocagem1.Text = "Automático"
            lblMADegeloEstocagem1.BackColor = Color.DarkBlue
        Else
            lblMADegeloEstocagem1.Text = "Manual"
            lblMADegeloEstocagem1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(15).bitHabAmbiente Then
            lblHabAmbienteEstocagem1.Text = "Habilitado"
            lblHabAmbienteEstocagem1.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteEstocagem1.Text = "Desabilitado"
            lblHabAmbienteEstocagem1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(15).varStatusAmbiente = 0 Then
            lblStatusAmbienteEstocagem1.Text = "Refrig."
            lblStatusAmbienteEstocagem1.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(15).varStatusAmbiente = 1 Then
            lblStatusAmbienteEstocagem1.Text = "Recolher"
            lblStatusAmbienteEstocagem1.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(15).varStatusAmbiente = 2 Then
            lblStatusAmbienteEstocagem1.Text = "Pausa"
            lblStatusAmbienteEstocagem1.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(15).varStatusAmbiente = 3 Then
            lblStatusAmbienteEstocagem1.Text = "Gás Quente"
            lblStatusAmbienteEstocagem1.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(15).varStatusAmbiente = 4 Then
            lblStatusAmbienteEstocagem1.Text = "Água"
            lblStatusAmbienteEstocagem1.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(15).varStatusAmbiente = 5 Then
            lblStatusAmbienteEstocagem1.Text = "Gotejam."
            lblStatusAmbienteEstocagem1.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(15).varStatusAmbiente = 6 Then
            lblStatusAmbienteEstocagem1.Text = "Pré-Resf."
            lblStatusAmbienteEstocagem1.BackColor = Color.Blue
        End If
        'Fim estocagem 1
        '*******************************************************

        '*******************************************************
        'Estocagem 2 - Atualização tela
        '*******************************************************
        lblTempEstocagem2.Text = MainForm.Ambientes(16).varTemperatura / 10 & " °C"

        If Not edtSetPointEstocagem2.Focused Then
            edtSetPointEstocagem2.Text = MainForm.Ambientes(16).varSetPoint & " °C"
        End If

        If Not edtOffSetEstocagem2.Focused Then
            edtOffSetEstocagem2.Text = MainForm.Ambientes(16).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(16).bitLDEvap Then
            lblLDEvaporadorEstocagem2.Text = "Ligado"
            If MainForm.Ambientes(16).bitFalhaEvaporador1 Or MainForm.Ambientes(16).bitFalhaEvaporador2 Or MainForm.Ambientes(16).bitFalhaEvaporador3 Or MainForm.Ambientes(16).bitFalhaEvaporador4 Then
                lblLDEvaporadorEstocagem2.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorEstocagem2.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorEstocagem2.Text = "Desligado"
            lblLDEvaporadorEstocagem2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(16).bitLDVSSC Then
            lblLDVSSCEstocagem2.Text = "Ligado"
            lblLDVSSCEstocagem2.BackColor = Color.DarkBlue
        Else
            lblLDVSSCEstocagem2.Text = "Desligado"
            lblLDVSSCEstocagem2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(16).bitLDVSLL Then
            lblLDVSLLEstocagem2.Text = "Ligado"
            lblLDVSLLEstocagem2.BackColor = Color.DarkBlue
        Else
            lblLDVSLLEstocagem2.Text = "Desligado"
            lblLDVSLLEstocagem2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(16).bitLDVSGQ Then
            lblLDVSGQEstocagem2.Text = "Ligado"
            lblLDVSGQEstocagem2.BackColor = Color.DarkRed
        Else
            lblLDVSGQEstocagem2.Text = "Desligado"
            lblLDVSGQEstocagem2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(16).bitLDVSAG Then
            lblLDVSAGEstocagem2.Text = "Ligado"
            lblLDVSAGEstocagem2.BackColor = Color.DarkGreen
        Else
            lblLDVSAGEstocagem2.Text = "Desligado"
            lblLDVSAGEstocagem2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(16).bitDegelo Then
            lblLDDegeloEstocagem2.Text = "Iniciado"
            lblLDDegeloEstocagem2.BackColor = Color.DarkRed
        Else
            lblLDDegeloEstocagem2.Text = "Desligado"
            lblLDDegeloEstocagem2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(16).bitMAEvap Then
            lblMAEvaporadorEstocagem2.Text = "Automático"
            lblMAEvaporadorEstocagem2.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorEstocagem2.Text = "Manual"
            lblMAEvaporadorEstocagem2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(16).bitMAVSSC Then
            lblMAVSSCEstocagem2.Text = "Automático"
            lblMAVSSCEstocagem2.BackColor = Color.DarkBlue
        Else
            lblMAVSSCEstocagem2.Text = "Manual"
            lblMAVSSCEstocagem2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(16).bitMAVSLL Then
            lblMAVSLLEstocagem2.Text = "Automático"
            lblMAVSLLEstocagem2.BackColor = Color.DarkBlue
        Else
            lblMAVSLLEstocagem2.Text = "Manual"
            lblMAVSLLEstocagem2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(16).bitMAVSGQ Then
            lblMAVSGQEstocagem2.Text = "Automático"
            lblMAVSGQEstocagem2.BackColor = Color.DarkBlue
        Else
            lblMAVSGQEstocagem2.Text = "Manual"
            lblMAVSGQEstocagem2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(16).bitMAVSAG Then
            lblMAVSAGEstocagem2.Text = "Automático"
            lblMAVSAGEstocagem2.BackColor = Color.DarkBlue
        Else
            lblMAVSAGEstocagem2.Text = "Manual"
            lblMAVSAGEstocagem2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(16).bitMADegelo Then
            lblMADegeloEstocagem2.Text = "Automático"
            lblMADegeloEstocagem2.BackColor = Color.DarkBlue
        Else
            lblMADegeloEstocagem2.Text = "Manual"
            lblMADegeloEstocagem2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(16).bitHabAmbiente Then
            lblHabAmbienteEstocagem2.Text = "Habilitado"
            lblHabAmbienteEstocagem2.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteEstocagem2.Text = "Desabilitado"
            lblHabAmbienteEstocagem2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(16).varStatusAmbiente = 0 Then
            lblStatusAmbienteEstocagem2.Text = "Refrig."
            lblStatusAmbienteEstocagem2.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(16).varStatusAmbiente = 1 Then
            lblStatusAmbienteEstocagem2.Text = "Recolher"
            lblStatusAmbienteEstocagem2.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(16).varStatusAmbiente = 2 Then
            lblStatusAmbienteEstocagem2.Text = "Pausa"
            lblStatusAmbienteEstocagem2.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(16).varStatusAmbiente = 3 Then
            lblStatusAmbienteEstocagem2.Text = "Gás Quente"
            lblStatusAmbienteEstocagem2.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(16).varStatusAmbiente = 4 Then
            lblStatusAmbienteEstocagem2.Text = "Água"
            lblStatusAmbienteEstocagem2.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(16).varStatusAmbiente = 5 Then
            lblStatusAmbienteEstocagem2.Text = "Gotejam."
            lblStatusAmbienteEstocagem2.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(16).varStatusAmbiente = 6 Then
            lblStatusAmbienteEstocagem2.Text = "Pré-Resf."
            lblStatusAmbienteEstocagem2.BackColor = Color.Blue
        End If
        'Fim estocagem 2
        '*******************************************************

    End Sub

    Private Sub edtSetPointTunel4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtSetPointTunel4.KeyPress
        If e.KeyChar = Chr(13) Then
            EscreveSetpoint(2, MainForm.Ambientes(11).varADSetpoint, CShort(edtSetPointTunel4.Text))
        End If
    End Sub

    Private Sub edtSetPointTunel5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtSetPointTunel5.KeyPress
        If e.KeyChar = Chr(13) Then
            EscreveSetpoint(2, MainForm.Ambientes(12).varADSetpoint, CShort(edtSetPointTunel5.Text))
        End If
    End Sub

    Private Sub edtSetPointTunel6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtSetPointTunel6.KeyPress
        If e.KeyChar = Chr(13) Then
            EscreveSetpoint(2, MainForm.Ambientes(13).varADSetpoint, CShort(edtSetPointTunel6.Text))
        End If
    End Sub

    Private Sub edtSetPointTunel7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtSetPointTunel7.KeyPress
        If e.KeyChar = Chr(13) Then
            EscreveSetpoint(2, MainForm.Ambientes(14).varADSetpoint, CShort(edtSetPointTunel7.Text))
        End If
    End Sub

    Private Sub edtSetPointEstocagem1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtSetPointEstocagem1.KeyPress
        If e.KeyChar = Chr(13) Then
            EscreveSetpoint(2, MainForm.Ambientes(15).varADSetpoint, CShort(edtSetPointEstocagem1.Text))
        End If
    End Sub

    Private Sub edtSetPointEstocagem2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtSetPointEstocagem2.KeyPress
        If e.KeyChar = Chr(13) Then
            EscreveSetpoint(2, MainForm.Ambientes(16).varADSetpoint, CShort(edtSetPointEstocagem2.Text))
        End If
    End Sub

    Private Sub edtOffSetTunel4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtOffSetTunel4.KeyPress
        Dim Valor As Short
        If e.KeyChar = Chr(13) Then
            Valor = CShort(edtOffSetTunel4.Text) * 10
            EscreveOffSet(2, MainForm.Ambientes(11).varADOffSet, Valor)
        End If
    End Sub

    Private Sub edtOffSetTunel5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtOffSetTunel5.KeyPress
        Dim Valor As Short
        If e.KeyChar = Chr(13) Then
            Valor = CShort(edtOffSetTunel5.Text) * 10
            EscreveOffSet(2, MainForm.Ambientes(12).varADOffSet, Valor)
        End If
    End Sub

    Private Sub edtOffSetTunel6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtOffSetTunel6.KeyPress
        Dim Valor As Short
        If e.KeyChar = Chr(13) Then
            Valor = CShort(edtOffSetTunel6.Text) * 10
            EscreveOffSet(2, MainForm.Ambientes(13).varADOffSet, Valor)
        End If
    End Sub

    Private Sub edtOffSetTunel7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtOffSetTunel7.KeyPress
        Dim Valor As Short
        If e.KeyChar = Chr(13) Then
            Valor = CShort(edtOffSetTunel7.Text) * 10
            EscreveOffSet(2, MainForm.Ambientes(14).varADOffSet, Valor)
        End If
    End Sub

    Private Sub edtOffsetEstocagem1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtOffsetEstocagem1.KeyPress
        Dim Valor As Short
        If e.KeyChar = Chr(13) Then
            Valor = CShort(edtOffsetEstocagem1.Text) * 10
            EscreveOffSet(2, MainForm.Ambientes(15).varADOffSet, Valor)
        End If
    End Sub

    Private Sub edtOffSetEstocagem2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtOffSetEstocagem2.KeyPress
        Dim Valor As Short
        If e.KeyChar = Chr(13) Then
            Valor = CShort(edtOffSetEstocagem2.Text) * 10
            EscreveOffSet(2, MainForm.Ambientes(16).varADOffSet, Valor)
        End If
    End Sub

    Private Sub lblAtalhoTunel4_Click(sender As Object, e As EventArgs) Handles lblAtalhoTunel4.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 11
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub

    Private Sub lblAtalhoTunel5_Click(sender As Object, e As EventArgs) Handles lblAtalhoTunel5.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 12
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub

    Private Sub lblAtalhoTunel6_Click(sender As Object, e As EventArgs) Handles lblAtalhoTunel6.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 13
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub

    Private Sub lblAtalhoTunel7_Click(sender As Object, e As EventArgs) Handles lblAtalhoTunel7.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 14
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub
End Class