Public Class frmTuneisMiudos
    Private Sub frmTuneisMiudos_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Timer1.Interval = 500
        Timer1.Enabled = True
        MainForm.MenuPrincipal.Focus()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        '*******************************************************
        'Tunel 1 - Atualização tela
        '*******************************************************
        lblTempTunel1.Text = MainForm.Ambientes(29).varTemperatura / 10 & " °C"

        If Not edtSetPointTunel1.Focused Then
            edtSetPointTunel1.Text = MainForm.Ambientes(29).varSetPoint & " °C"
        End If

        If Not edtOffSetTunel1.Focused Then
            edtOffSetTunel1.Text = MainForm.Ambientes(29).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(29).bitLDEvap Then
            lblLDEvaporadorTunel1.Text = "Ligado"
            If MainForm.Ambientes(29).bitFalhaEvaporador1 Or MainForm.Ambientes(29).bitFalhaEvaporador2 Or MainForm.Ambientes(29).bitFalhaEvaporador3 Or MainForm.Ambientes(29).bitFalhaEvaporador4 Then
                lblLDEvaporadorTunel1.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorTunel1.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorTunel1.Text = "Desligado"
            lblLDEvaporadorTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(29).bitLDVSSC Then
            lblLDVSSCTunel1.Text = "Ligado"
            lblLDVSSCTunel1.BackColor = Color.DarkBlue
        Else
            lblLDVSSCTunel1.Text = "Desligado"
            lblLDVSSCTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(29).bitLDVSLL Then
            lblLDVSLLTunel1.Text = "Ligado"
            lblLDVSLLTunel1.BackColor = Color.DarkBlue
        Else
            lblLDVSLLTunel1.Text = "Desligado"
            lblLDVSLLTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(29).bitLDVSGQ Then
            lblLDVSGQTunel1.Text = "Ligado"
            lblLDVSGQTunel1.BackColor = Color.DarkRed
        Else
            lblLDVSGQTunel1.Text = "Desligado"
            lblLDVSGQTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(29).bitLDVSAG Then
            lblLDVSAGTunel1.Text = "Ligado"
            lblLDVSAGTunel1.BackColor = Color.DarkGreen
        Else
            lblLDVSAGTunel1.Text = "Desligado"
            lblLDVSAGTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(29).bitDegelo Then
            lblLDDegeloTunel1.Text = "Iniciado"
            lblLDDegeloTunel1.BackColor = Color.DarkRed
        Else
            lblLDDegeloTunel1.Text = "Desligado"
            lblLDDegeloTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(29).bitMAEvap Then
            lblMAEvaporadorTunel1.Text = "Automático"
            lblMAEvaporadorTunel1.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorTunel1.Text = "Manual"
            lblMAEvaporadorTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(29).bitMAVSSC Then
            lblMAVSSCTunel1.Text = "Automático"
            lblMAVSSCTunel1.BackColor = Color.DarkBlue
        Else
            lblMAVSSCTunel1.Text = "Manual"
            lblMAVSSCTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(29).bitMAVSLL Then
            lblMAVSLLTunel1.Text = "Automático"
            lblMAVSLLTunel1.BackColor = Color.DarkBlue
        Else
            lblMAVSLLTunel1.Text = "Manual"
            lblMAVSLLTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(29).bitMAVSGQ Then
            lblMAVSGQTunel1.Text = "Automático"
            lblMAVSGQTunel1.BackColor = Color.DarkBlue
        Else
            lblMAVSGQTunel1.Text = "Manual"
            lblMAVSGQTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(29).bitMAVSAG Then
            lblMAVSAGTunel1.Text = "Automático"
            lblMAVSAGTunel1.BackColor = Color.DarkBlue
        Else
            lblMAVSAGTunel1.Text = "Manual"
            lblMAVSAGTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(29).bitMADegelo Then
            lblMADegeloTunel1.Text = "Automático"
            lblMADegeloTunel1.BackColor = Color.DarkBlue
        Else
            lblMADegeloTunel1.Text = "Manual"
            lblMADegeloTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(29).bitHabAmbiente Then
            lblHabAmbienteTunel1.Text = "Habilitado"
            lblHabAmbienteTunel1.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteTunel1.Text = "Desabilitado"
            lblHabAmbienteTunel1.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(29).varStatusAmbiente = 0 Then
            lblStatusAmbienteTunel1.Text = "Refrig."
            lblStatusAmbienteTunel1.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(29).varStatusAmbiente = 1 Then
            lblStatusAmbienteTunel1.Text = "Recolher"
            lblStatusAmbienteTunel1.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(29).varStatusAmbiente = 2 Then
            lblStatusAmbienteTunel1.Text = "Pausa"
            lblStatusAmbienteTunel1.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(29).varStatusAmbiente = 3 Then
            lblStatusAmbienteTunel1.Text = "Gás Quente"
            lblStatusAmbienteTunel1.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(29).varStatusAmbiente = 4 Then
            lblStatusAmbienteTunel1.Text = "Água"
            lblStatusAmbienteTunel1.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(29).varStatusAmbiente = 5 Then
            lblStatusAmbienteTunel1.Text = "Gotejam."
            lblStatusAmbienteTunel1.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(29).varStatusAmbiente = 6 Then
            lblStatusAmbienteTunel1.Text = "Pré-Resf."
            lblStatusAmbienteTunel1.BackColor = Color.Blue
        End If
        'Fim Tunel 1
        '*******************************************************

        '*******************************************************
        'Tunel 2 - Atualização tela
        '*******************************************************
        lblTempTunel2.Text = MainForm.Ambientes(30).varTemperatura / 10 & " °C"

        If Not edtSetPointTunel2.Focused Then
            edtSetPointTunel2.Text = MainForm.Ambientes(30).varSetPoint & " °C"
        End If

        If Not edtOffSetTunel2.Focused Then
            edtOffSetTunel2.Text = MainForm.Ambientes(30).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(30).bitLDEvap Then
            lblLDEvaporadorTunel2.Text = "Ligado"
            If MainForm.Ambientes(30).bitFalhaEvaporador1 Or MainForm.Ambientes(30).bitFalhaEvaporador2 Or MainForm.Ambientes(30).bitFalhaEvaporador3 Or MainForm.Ambientes(30).bitFalhaEvaporador4 Then
                lblLDEvaporadorTunel2.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorTunel2.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorTunel2.Text = "Desligado"
            lblLDEvaporadorTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(30).bitLDVSSC Then
            lblLDVSSCTunel2.Text = "Ligado"
            lblLDVSSCTunel2.BackColor = Color.DarkBlue
        Else
            lblLDVSSCTunel2.Text = "Desligado"
            lblLDVSSCTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(30).bitLDVSLL Then
            lblLDVSLLTunel2.Text = "Ligado"
            lblLDVSLLTunel2.BackColor = Color.DarkBlue
        Else
            lblLDVSLLTunel2.Text = "Desligado"
            lblLDVSLLTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(30).bitLDVSGQ Then
            lblLDVSGQTunel2.Text = "Ligado"
            lblLDVSGQTunel2.BackColor = Color.DarkRed
        Else
            lblLDVSGQTunel2.Text = "Desligado"
            lblLDVSGQTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(30).bitLDVSAG Then
            lblLDVSAGTunel2.Text = "Ligado"
            lblLDVSAGTunel2.BackColor = Color.DarkGreen
        Else
            lblLDVSAGTunel2.Text = "Desligado"
            lblLDVSAGTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(30).bitDegelo Then
            lblLDDegeloTunel2.Text = "Iniciado"
            lblLDDegeloTunel2.BackColor = Color.DarkRed
        Else
            lblLDDegeloTunel2.Text = "Desligado"
            lblLDDegeloTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(30).bitMAEvap Then
            lblMAEvaporadorTunel2.Text = "Automático"
            lblMAEvaporadorTunel2.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorTunel2.Text = "Manual"
            lblMAEvaporadorTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(30).bitMAVSSC Then
            lblMAVSSCTunel2.Text = "Automático"
            lblMAVSSCTunel2.BackColor = Color.DarkBlue
        Else
            lblMAVSSCTunel2.Text = "Manual"
            lblMAVSSCTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(30).bitMAVSLL Then
            lblMAVSLLTunel2.Text = "Automático"
            lblMAVSLLTunel2.BackColor = Color.DarkBlue
        Else
            lblMAVSLLTunel2.Text = "Manual"
            lblMAVSLLTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(30).bitMAVSGQ Then
            lblMAVSGQTunel2.Text = "Automático"
            lblMAVSGQTunel2.BackColor = Color.DarkBlue
        Else
            lblMAVSGQTunel2.Text = "Manual"
            lblMAVSGQTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(30).bitMAVSAG Then
            lblMAVSAGTunel2.Text = "Automático"
            lblMAVSAGTunel2.BackColor = Color.DarkBlue
        Else
            lblMAVSAGTunel2.Text = "Manual"
            lblMAVSAGTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(30).bitMADegelo Then
            lblMADegeloTunel2.Text = "Automático"
            lblMADegeloTunel2.BackColor = Color.DarkBlue
        Else
            lblMADegeloTunel2.Text = "Manual"
            lblMADegeloTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(30).bitHabAmbiente Then
            lblHabAmbienteTunel2.Text = "Habilitado"
            lblHabAmbienteTunel2.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteTunel2.Text = "Desabilitado"
            lblHabAmbienteTunel2.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(30).varStatusAmbiente = 0 Then
            lblStatusAmbienteTunel2.Text = "Refrig."
            lblStatusAmbienteTunel2.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(30).varStatusAmbiente = 1 Then
            lblStatusAmbienteTunel2.Text = "Recolher"
            lblStatusAmbienteTunel2.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(30).varStatusAmbiente = 2 Then
            lblStatusAmbienteTunel2.Text = "Pausa"
            lblStatusAmbienteTunel2.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(30).varStatusAmbiente = 3 Then
            lblStatusAmbienteTunel2.Text = "Gás Quente"
            lblStatusAmbienteTunel2.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(30).varStatusAmbiente = 4 Then
            lblStatusAmbienteTunel2.Text = "Água"
            lblStatusAmbienteTunel2.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(30).varStatusAmbiente = 5 Then
            lblStatusAmbienteTunel2.Text = "Gotejam."
            lblStatusAmbienteTunel2.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(30).varStatusAmbiente = 6 Then
            lblStatusAmbienteTunel2.Text = "Pré-Resf."
            lblStatusAmbienteTunel2.BackColor = Color.Blue
        End If
        'Fim Tunel 2
        '*******************************************************

        '*******************************************************
        'Tunel 3 - Atualização tela
        '*******************************************************
        lblTempTunel3.Text = MainForm.Ambientes(31).varTemperatura / 10 & " °C"

        If Not edtSetPointTunel3.Focused Then
            edtSetPointTunel3.Text = MainForm.Ambientes(31).varSetPoint & " °C"
        End If

        If Not edtOffSetTunel3.Focused Then
            edtOffSetTunel3.Text = MainForm.Ambientes(31).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(31).bitLDEvap Then
            lblLDEvaporadorTunel3.Text = "Ligado"
            If MainForm.Ambientes(31).bitFalhaEvaporador1 Or MainForm.Ambientes(31).bitFalhaEvaporador2 Or MainForm.Ambientes(31).bitFalhaEvaporador3 Or MainForm.Ambientes(31).bitFalhaEvaporador4 Then
                lblLDEvaporadorTunel3.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorTunel3.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorTunel3.Text = "Desligado"
            lblLDEvaporadorTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(31).bitLDVSSC Then
            lblLDVSSCTunel3.Text = "Ligado"
            lblLDVSSCTunel3.BackColor = Color.DarkBlue
        Else
            lblLDVSSCTunel3.Text = "Desligado"
            lblLDVSSCTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(31).bitLDVSLL Then
            lblLDVSLLTunel3.Text = "Ligado"
            lblLDVSLLTunel3.BackColor = Color.DarkBlue
        Else
            lblLDVSLLTunel3.Text = "Desligado"
            lblLDVSLLTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(31).bitLDVSGQ Then
            lblLDVSGQTunel3.Text = "Ligado"
            lblLDVSGQTunel3.BackColor = Color.DarkRed
        Else
            lblLDVSGQTunel3.Text = "Desligado"
            lblLDVSGQTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(31).bitLDVSAG Then
            lblLDVSAGTunel3.Text = "Ligado"
            lblLDVSAGTunel3.BackColor = Color.DarkGreen
        Else
            lblLDVSAGTunel3.Text = "Desligado"
            lblLDVSAGTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(31).bitDegelo Then
            lblLDDegeloTunel3.Text = "Iniciado"
            lblLDDegeloTunel3.BackColor = Color.DarkRed
        Else
            lblLDDegeloTunel3.Text = "Desligado"
            lblLDDegeloTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(31).bitMAEvap Then
            lblMAEvaporadorTunel3.Text = "Automático"
            lblMAEvaporadorTunel3.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorTunel3.Text = "Manual"
            lblMAEvaporadorTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(31).bitMAVSSC Then
            lblMAVSSCTunel3.Text = "Automático"
            lblMAVSSCTunel3.BackColor = Color.DarkBlue
        Else
            lblMAVSSCTunel3.Text = "Manual"
            lblMAVSSCTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(31).bitMAVSLL Then
            lblMAVSLLTunel3.Text = "Automático"
            lblMAVSLLTunel3.BackColor = Color.DarkBlue
        Else
            lblMAVSLLTunel3.Text = "Manual"
            lblMAVSLLTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(31).bitMAVSGQ Then
            lblMAVSGQTunel3.Text = "Automático"
            lblMAVSGQTunel3.BackColor = Color.DarkBlue
        Else
            lblMAVSGQTunel3.Text = "Manual"
            lblMAVSGQTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(31).bitMAVSAG Then
            lblMAVSAGTunel3.Text = "Automático"
            lblMAVSAGTunel3.BackColor = Color.DarkBlue
        Else
            lblMAVSAGTunel3.Text = "Manual"
            lblMAVSAGTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(31).bitMADegelo Then
            lblMADegeloTunel3.Text = "Automático"
            lblMADegeloTunel3.BackColor = Color.DarkBlue
        Else
            lblMADegeloTunel3.Text = "Manual"
            lblMADegeloTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(31).bitHabAmbiente Then
            lblHabAmbienteTunel3.Text = "Habilitado"
            lblHabAmbienteTunel3.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteTunel3.Text = "Desabilitado"
            lblHabAmbienteTunel3.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(31).varStatusAmbiente = 0 Then
            lblStatusAmbienteTunel3.Text = "Refrig."
            lblStatusAmbienteTunel3.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(31).varStatusAmbiente = 1 Then
            lblStatusAmbienteTunel3.Text = "Recolher"
            lblStatusAmbienteTunel3.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(31).varStatusAmbiente = 2 Then
            lblStatusAmbienteTunel3.Text = "Pausa"
            lblStatusAmbienteTunel3.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(31).varStatusAmbiente = 3 Then
            lblStatusAmbienteTunel3.Text = "Gás Quente"
            lblStatusAmbienteTunel3.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(31).varStatusAmbiente = 4 Then
            lblStatusAmbienteTunel3.Text = "Água"
            lblStatusAmbienteTunel3.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(31).varStatusAmbiente = 5 Then
            lblStatusAmbienteTunel3.Text = "Gotejam."
            lblStatusAmbienteTunel3.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(31).varStatusAmbiente = 6 Then
            lblStatusAmbienteTunel3.Text = "Pré-Resf."
            lblStatusAmbienteTunel3.BackColor = Color.Blue
        End If
        'Fim Tunel 3
        '*******************************************************

        '*******************************************************
        'Estocagem Miudos - Atualização tela
        '*******************************************************
        lblTempEstMiudos.Text = MainForm.Ambientes(32).varTemperatura / 10 & " °C"

        If Not edtSetPointEstMiudos.Focused Then
            edtSetPointEstMiudos.Text = MainForm.Ambientes(32).varSetPoint & " °C"
        End If

        If Not edtOffSetEstMiudos.Focused Then
            edtOffSetEstMiudos.Text = MainForm.Ambientes(32).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(32).bitLDEvap Then
            lblLDEvaporadorEstMiudos.Text = "Ligado"
            If MainForm.Ambientes(32).bitFalhaEvaporador1 Or MainForm.Ambientes(32).bitFalhaEvaporador2 Or MainForm.Ambientes(32).bitFalhaEvaporador3 Or MainForm.Ambientes(32).bitFalhaEvaporador4 Then
                lblLDEvaporadorEstMiudos.BackColor = Color.DarkRed
            Else
                lblLDEvaporadorEstMiudos.BackColor = Color.DarkBlue
            End If
        Else
            lblLDEvaporadorEstMiudos.Text = "Desligado"
            lblLDEvaporadorEstMiudos.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(32).bitLDVSSC Then
            lblLDVSSCEstMiudos.Text = "Ligado"
            lblLDVSSCEstMiudos.BackColor = Color.DarkBlue
        Else
            lblLDVSSCEstMiudos.Text = "Desligado"
            lblLDVSSCEstMiudos.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(32).bitLDVSLL Then
            lblLDVSLLEstMiudos.Text = "Ligado"
            lblLDVSLLEstMiudos.BackColor = Color.DarkBlue
        Else
            lblLDVSLLEstMiudos.Text = "Desligado"
            lblLDVSLLEstMiudos.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(32).bitLDVSGQ Then
            lblLDVSGQEstMiudos.Text = "Ligado"
            lblLDVSGQEstMiudos.BackColor = Color.DarkRed
        Else
            lblLDVSGQEstMiudos.Text = "Desligado"
            lblLDVSGQEstMiudos.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(32).bitLDVSAG Then
            lblLDVSAGEstMiudos.Text = "Ligado"
            lblLDVSAGEstMiudos.BackColor = Color.DarkGreen
        Else
            lblLDVSAGEstMiudos.Text = "Desligado"
            lblLDVSAGEstMiudos.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(32).bitDegelo Then
            lblLDDegeloEstMiudos.Text = "Iniciado"
            lblLDDegeloEstMiudos.BackColor = Color.DarkRed
        Else
            lblLDDegeloEstMiudos.Text = "Desligado"
            lblLDDegeloEstMiudos.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(32).bitMAEvap Then
            lblMAEvaporadorEstMiudos.Text = "Automático"
            lblMAEvaporadorEstMiudos.BackColor = Color.DarkBlue
        Else
            lblMAEvaporadorEstMiudos.Text = "Manual"
            lblMAEvaporadorEstMiudos.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(32).bitMAVSSC Then
            lblMAVSSCEstMiudos.Text = "Automático"
            lblMAVSSCEstMiudos.BackColor = Color.DarkBlue
        Else
            lblMAVSSCEstMiudos.Text = "Manual"
            lblMAVSSCEstMiudos.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(32).bitMAVSLL Then
            lblMAVSLLEstMiudos.Text = "Automático"
            lblMAVSLLEstMiudos.BackColor = Color.DarkBlue
        Else
            lblMAVSLLEstMiudos.Text = "Manual"
            lblMAVSLLEstMiudos.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(32).bitMAVSGQ Then
            lblMAVSGQEstMiudos.Text = "Automático"
            lblMAVSGQEstMiudos.BackColor = Color.DarkBlue
        Else
            lblMAVSGQEstMiudos.Text = "Manual"
            lblMAVSGQEstMiudos.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(32).bitMAVSAG Then
            lblMAVSAGEstMiudos.Text = "Automático"
            lblMAVSAGEstMiudos.BackColor = Color.DarkBlue
        Else
            lblMAVSAGEstMiudos.Text = "Manual"
            lblMAVSAGEstMiudos.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(32).bitMADegelo Then
            lblMADegeloEstMiudos.Text = "Automático"
            lblMADegeloEstMiudos.BackColor = Color.DarkBlue
        Else
            lblMADegeloEstMiudos.Text = "Manual"
            lblMADegeloEstMiudos.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(32).bitHabAmbiente Then
            lblHabAmbienteEstMiudos.Text = "Habilitado"
            lblHabAmbienteEstMiudos.BackColor = Color.DarkBlue
        Else
            lblHabAmbienteEstMiudos.Text = "Desabilitado"
            lblHabAmbienteEstMiudos.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(32).varStatusAmbiente = 0 Then
            lblStatusAmbienteEstMiudos.Text = "Refrig."
            lblStatusAmbienteEstMiudos.BackColor = Color.DarkBlue
        ElseIf MainForm.Ambientes(32).varStatusAmbiente = 1 Then
            lblStatusAmbienteEstMiudos.Text = "Recolher"
            lblStatusAmbienteEstMiudos.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(32).varStatusAmbiente = 2 Then
            lblStatusAmbienteEstMiudos.Text = "Pausa"
            lblStatusAmbienteEstMiudos.BackColor = Color.Blue
        ElseIf MainForm.Ambientes(32).varStatusAmbiente = 3 Then
            lblStatusAmbienteEstMiudos.Text = "Gás Quente"
            lblStatusAmbienteEstMiudos.BackColor = Color.DarkRed
        ElseIf MainForm.Ambientes(32).varStatusAmbiente = 4 Then
            lblStatusAmbienteEstMiudos.Text = "Água"
            lblStatusAmbienteEstMiudos.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(32).varStatusAmbiente = 5 Then
            lblStatusAmbienteEstMiudos.Text = "Gotejam."
            lblStatusAmbienteEstMiudos.BackColor = Color.DarkGreen
        ElseIf MainForm.Ambientes(32).varStatusAmbiente = 6 Then
            lblStatusAmbienteEstMiudos.Text = "Pré-Resf."
            lblStatusAmbienteEstMiudos.BackColor = Color.Blue
        End If
        'Fim Estocagem Miudos
        '*******************************************************
    End Sub

    Private Sub lblAtalhoTunel1_Click(sender As Object, e As EventArgs) Handles lblAtalhoTunel1.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 29
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub

    Private Sub lblAtalhoTunel2_Click(sender As Object, e As EventArgs) Handles lblAtalhoTunel2.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 30
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub

    Private Sub lblAtalhoTunel3_Click(sender As Object, e As EventArgs) Handles lblAtalhoTunel3.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 31
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub

    Private Sub lblAtalhoEstMiudos_Click(sender As Object, e As EventArgs) Handles lblAtalhoEstMiudos.Click
        FrmAmbientes.MdiParent = MainForm
        MainForm.varAmbienteAtivo = 32
        MainForm.Label1.Text = MainForm.varAmbienteAtivo
        FrmAmbientes.Show()
        Me.Close()
    End Sub
End Class