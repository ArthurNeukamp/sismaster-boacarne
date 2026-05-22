Public Class FrmAmbientes
    Public AmbienteAtivo As Integer
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim varTempoDecorridoMin, varTempoDecorridoSeg As Integer
        AmbienteAtivo = MainForm.varAmbienteAtivo
        '*******************************************************
        '            Atualização tela
        '*******************************************************
        lblTemp.Text = MainForm.Ambientes(AmbienteAtivo).varTemperatura / 10 & " °C"

        If Not edtSetPoint.Focused Then
            edtSetPoint.Text = MainForm.Ambientes(AmbienteAtivo).varSetPoint & " °C"
        End If

        If Not edtOffset.Focused Then
            edtOffset.Text = MainForm.Ambientes(AmbienteAtivo).varOffSet / 10 & " °C"
        End If

        If MainForm.Ambientes(AmbienteAtivo).bitLDEvap Then
            lblLDEvaporador.Text = "Ligado"
            If MainForm.Ambientes(AmbienteAtivo).bitFalhaEvaporador1 Or MainForm.Ambientes(AmbienteAtivo).bitFalhaEvaporador2 Or MainForm.Ambientes(AmbienteAtivo).bitFalhaEvaporador3 Or MainForm.Ambientes(AmbienteAtivo).bitFalhaEvaporador4 Then
                lblLDEvaporador.BackColor = Color.DarkRed
            Else
                lblLDEvaporador.BackColor = Color.DarkBlue
            End If
            imgMotor1.Image = My.Resources.motor_ligado
            imgMotor2.Image = imgMotor1.Image
            imgMotor3.Image = imgMotor1.Image
            imgMotor4.Image = imgMotor1.Image
        Else
            lblLDEvaporador.Text = "Desligado"
            lblLDEvaporador.BackColor = Color.DimGray
            imgMotor1.Image = My.Resources.motor_desligado
            imgMotor2.Image = imgMotor1.Image
            imgMotor3.Image = imgMotor1.Image
            imgMotor4.Image = imgMotor1.Image
        End If

        If MainForm.Ambientes(AmbienteAtivo).bitLDVSSC Then
            lblLDVSSC.Text = "Ligado"
            lblLDVSSC.BackColor = Color.DarkBlue
        Else
            lblLDVSSC.Text = "Desligado"
            lblLDVSSC.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(AmbienteAtivo).bitLDVSLL Then
            lblLDVSLL.Text = "Ligado"
            lblLDVSLL.BackColor = Color.DarkBlue
        Else
            lblLDVSLL.Text = "Desligado"
            lblLDVSLL.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(AmbienteAtivo).bitLDVSGQ Then
            lblLDVSGQ.Text = "Ligado"
            lblLDVSGQ.BackColor = Color.DarkRed
        Else
            lblLDVSGQ.Text = "Desligado"
            lblLDVSGQ.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(AmbienteAtivo).bitLDVSAG Then
            lblLDVSAG.Text = "Ligado"
            lblLDVSAG.BackColor = Color.DarkGreen
        Else
            lblLDVSAG.Text = "Desligado"
            lblLDVSAG.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(AmbienteAtivo).bitDegelo Then
            lblLDDegelo.Text = "Iniciado"
            lblLDDegelo.BackColor = Color.DarkRed
        Else
            lblLDDegelo.Text = "Desligado"
            lblLDDegelo.BackColor = Color.DimGray
        End If

        If MainForm.Ambientes(AmbienteAtivo).bitMAEvap Then
            lblMAEvaporador.Text = "Automático"
            lblMAEvaporador.BackColor = Color.DarkBlue
            imgMAEvap.Image = imgBotao90.Image
        Else
            lblMAEvaporador.Text = "Manual"
            lblMAEvaporador.BackColor = Color.DimGray
            imgMAEvap.Image = imgBotao0.Image
        End If

        If MainForm.Ambientes(AmbienteAtivo).bitMAVSSC Then
            lblMAVSSC.Text = "Automático"
            lblMAVSSC.BackColor = Color.DarkBlue
            imgMAVSSC.Image = imgBotao90.Image
        Else
            lblMAVSSC.Text = "Manual"
            lblMAVSSC.BackColor = Color.DimGray
            imgMAVSSC.Image = imgBotao0.Image
        End If

        If MainForm.Ambientes(AmbienteAtivo).bitMAVSLL Then
            lblMAVSLL.Text = "Automático"
            lblMAVSLL.BackColor = Color.DarkBlue
            imgMAVSLL.Image = imgBotao90.Image
        Else
            lblMAVSLL.Text = "Manual"
            lblMAVSLL.BackColor = Color.DimGray
            imgMAVSLL.Image = imgBotao0.Image
        End If

        If MainForm.Ambientes(AmbienteAtivo).bitMAVSGQ Then
            lblMAVSGQ.Text = "Automático"
            lblMAVSGQ.BackColor = Color.DarkBlue
            imgMAVSGQ.Image = imgBotao90.Image
        Else
            lblMAVSGQ.Text = "Manual"
            lblMAVSGQ.BackColor = Color.DimGray
            imgMAVSGQ.Image = imgBotao0.Image
        End If

        If MainForm.Ambientes(AmbienteAtivo).bitMAVSAG Then
            lblMAVSAG.Text = "Automático"
            lblMAVSAG.BackColor = Color.DarkBlue
            imgMAVSAG.Image = imgBotao90.Image
        Else
            lblMAVSAG.Text = "Manual"
            lblMAVSAG.BackColor = Color.DimGray
            imgMAVSAG.Image = imgBotao0.Image
        End If

        If MainForm.Ambientes(AmbienteAtivo).bitMADegelo Then
            lblMADegelo.Text = "Automático"
            lblMADegelo.BackColor = Color.DarkBlue
            imgMADegelo.Image = imgBotao90.Image
        Else
            lblMADegelo.Text = "Manual"
            lblMADegelo.BackColor = Color.DimGray
            imgMADegelo.Image = imgBotao0.Image
        End If

        If MainForm.Ambientes(AmbienteAtivo).bitHabAmbiente Then
            lblHabAmbiente.Text = "Habilitado"
            lblHabAmbiente.BackColor = Color.DarkBlue
            imgHabAmbiente.Image = imgBotao90.Image
        Else
            lblHabAmbiente.Text = "Desabilitado"
            lblHabAmbiente.BackColor = Color.DimGray
            imgHabAmbiente.Image = imgBotao0.Image
        End If

        If MainForm.Ambientes(AmbienteAtivo).bitLigaEvap Then
            imgLDEvap.Image = imgBotao90.Image
        Else
            imgLDEvap.Image = imgBotao0.Image
        End If

        If MainForm.Ambientes(AmbienteAtivo).bitLigaVSSC Then
            imgLDVSSC.Image = imgBotao90.Image
        Else
            imgLDVSSC.Image = imgBotao0.Image
        End If

        If MainForm.Ambientes(AmbienteAtivo).bitLigaVSLL Then
            imgLDVSLL.Image = imgBotao90.Image
        Else
            imgLDVSLL.Image = imgBotao0.Image
        End If

        If MainForm.Ambientes(AmbienteAtivo).bitLigaVSGQ Then
            imgLDVSGQ.Image = imgBotao90.Image
        Else
            imgLDVSGQ.Image = imgBotao0.Image
        End If

        If MainForm.Ambientes(AmbienteAtivo).bitLigaVSAG Then
            imgLDVSAG.Image = imgBotao90.Image
        Else
            imgLDVSAG.Image = imgBotao0.Image
        End If

        If Not MainForm.Ambientes(AmbienteAtivo).bitHabAmbiente Then
            lblStatusAmbiente.Text = "Desligado"
            lblStatusAmbiente.BackColor = Color.DarkBlue
            imgGasQuente.Visible = False
            imgGotejando.Visible = False
            imgRecolhendo.Visible = False
            imgResfrigerando.Visible = False
            imgAgua.Visible = False
            imgRepouso.Visible = True
        ElseIf MainForm.Ambientes(AmbienteAtivo).varStatusAmbiente = 0 Then
            lblStatusAmbiente.Text = "Refrig."
            lblStatusAmbiente.BackColor = Color.DarkBlue
            imgGasQuente.Visible = False
            imgGotejando.Visible = False
            imgRecolhendo.Visible = False
            imgResfrigerando.Visible = True
            imgAgua.Visible = False
            imgRepouso.Visible = False
        ElseIf MainForm.Ambientes(AmbienteAtivo).varStatusAmbiente = 1 Then
            lblStatusAmbiente.Text = "Recolher"
            lblStatusAmbiente.BackColor = Color.Blue
            imgGasQuente.Visible = False
            imgGotejando.Visible = False
            imgRecolhendo.Visible = True
            imgResfrigerando.Visible = False
            imgAgua.Visible = False
            imgRepouso.Visible = False
        ElseIf MainForm.Ambientes(AmbienteAtivo).varStatusAmbiente = 2 Then
            lblStatusAmbiente.Text = "Pausa"
            lblStatusAmbiente.BackColor = Color.Blue
            imgGasQuente.Visible = False
            imgGotejando.Visible = False
            imgRecolhendo.Visible = False
            imgResfrigerando.Visible = False
            imgAgua.Visible = False
            imgRepouso.Visible = True
        ElseIf MainForm.Ambientes(AmbienteAtivo).varStatusAmbiente = 3 Then
            lblStatusAmbiente.Text = "Gás Quente"
            lblStatusAmbiente.BackColor = Color.DarkRed
            imgGasQuente.Visible = True
            imgGotejando.Visible = False
            imgRecolhendo.Visible = False
            imgResfrigerando.Visible = False
            imgAgua.Visible = False
            imgRepouso.Visible = False
        ElseIf MainForm.Ambientes(AmbienteAtivo).varStatusAmbiente = 4 Then
            lblStatusAmbiente.Text = "Água"
            lblStatusAmbiente.BackColor = Color.DarkGreen
            imgGasQuente.Visible = False
            imgGotejando.Visible = False
            imgRecolhendo.Visible = False
            imgResfrigerando.Visible = False
            imgAgua.Visible = True
            imgRepouso.Visible = False
        ElseIf MainForm.Ambientes(AmbienteAtivo).varStatusAmbiente = 5 Then
            lblStatusAmbiente.Text = "Gotejam."
            lblStatusAmbiente.BackColor = Color.DarkGreen
            imgGasQuente.Visible = False
            imgGotejando.Visible = True
            imgRecolhendo.Visible = False
            imgResfrigerando.Visible = False
            imgAgua.Visible = False
            imgRepouso.Visible = False
        ElseIf MainForm.Ambientes(AmbienteAtivo).varStatusAmbiente = 6 Then
            lblStatusAmbiente.Text = "Pré-Resf."
            lblStatusAmbiente.BackColor = Color.Blue
            imgGasQuente.Visible = False
            imgGotejando.Visible = False
            imgRecolhendo.Visible = False
            imgResfrigerando.Visible = True
            imgAgua.Visible = False
            imgRepouso.Visible = False
        End If

        varTempoDecorridoMin = MainForm.Ambientes(AmbienteAtivo).varTempoRecolhimento \ 60
        varTempoDecorridoSeg = MainForm.Ambientes(AmbienteAtivo).varTempoRecolhimento Mod 60
        lblTempoRecolhimento.Text = varTempoDecorridoMin & "m " & varTempoDecorridoSeg & "s"

        varTempoDecorridoMin = MainForm.Ambientes(AmbienteAtivo).varTempoGasQuente \ 60
        varTempoDecorridoSeg = MainForm.Ambientes(AmbienteAtivo).varTempoGasQuente Mod 60
        lblTempoGasQuente.Text = varTempoDecorridoMin & "m " & varTempoDecorridoSeg & "s"

        varTempoDecorridoMin = MainForm.Ambientes(AmbienteAtivo).varTempoAgua \ 60
        varTempoDecorridoSeg = MainForm.Ambientes(AmbienteAtivo).varTempoAgua Mod 60
        lblTempoAgua.Text = varTempoDecorridoMin & "m " & varTempoDecorridoSeg & "s"

        varTempoDecorridoMin = MainForm.Ambientes(AmbienteAtivo).varTempoGotejamento \ 60
        varTempoDecorridoSeg = MainForm.Ambientes(AmbienteAtivo).varTempoGotejamento Mod 60
        lblTempoGotejamento.Text = varTempoDecorridoMin & "m " & varTempoDecorridoSeg & "s"

        varTempoDecorridoMin = MainForm.Ambientes(AmbienteAtivo).varTempoPreResfriamento \ 60
        varTempoDecorridoSeg = MainForm.Ambientes(AmbienteAtivo).varTempoPreResfriamento Mod 60
        lblTempoPreResfriamento.Text = varTempoDecorridoMin & "m " & varTempoDecorridoSeg & "s"

        varTempoDecorridoMin = MainForm.Ambientes(AmbienteAtivo).varTempoPreResfriamento \ 60
        varTempoDecorridoSeg = MainForm.Ambientes(AmbienteAtivo).varTempoPreResfriamento Mod 60
        lblTempoPreResfriamento.Text = varTempoDecorridoMin & "m " & varTempoDecorridoSeg & "s"

        If Not edtSPTempoRecolhimento.Focused Then
            edtSPTempoRecolhimento.Text = MainForm.Ambientes(AmbienteAtivo).varSPRecolhimento / 60
        End If

        If Not edtSPTempoGasQuente.Focused Then
            edtSPTempoGasQuente.Text = MainForm.Ambientes(AmbienteAtivo).varSPGasQuente / 60
        End If

        If Not edtSPTempoAgua.Focused Then
            edtSPTempoAgua.Text = MainForm.Ambientes(AmbienteAtivo).varSPAgua / 60
        End If

        If Not edtSPTempoGotejamento.Focused Then
            edtSPTempoGotejamento.Text = MainForm.Ambientes(AmbienteAtivo).varSPGotejamento / 60
        End If

        If Not edtSPTempoPreResfriamento.Focused Then
            edtSPTempoPreResfriamento.Text = MainForm.Ambientes(AmbienteAtivo).varSPPreResfriamento / 60
        End If

        If Not edtHoraDegelo1.Focused Then
            edtHoraDegelo1.Text = MainForm.Ambientes(AmbienteAtivo).varHoraDegelo1
        End If

        If Not edtMinutoDegelo1.Focused Then
            edtMinutoDegelo1.Text = MainForm.Ambientes(AmbienteAtivo).varMinutoDegelo1
        End If

        If Not edtHoraDegelo2.Focused Then
            edtHoraDegelo2.Text = MainForm.Ambientes(AmbienteAtivo).varHoraDegelo2
        End If

        If Not edtMinutoDegelo2.Focused Then
            edtMinutoDegelo2.Text = MainForm.Ambientes(AmbienteAtivo).varMinutoDegelo2
        End If

        If Not edtHoraDegelo3.Focused Then
            edtHoraDegelo3.Text = MainForm.Ambientes(AmbienteAtivo).varHoraDegelo3
        End If

        If Not edtMinutoDegelo3.Focused Then
            edtMinutoDegelo3.Text = MainForm.Ambientes(AmbienteAtivo).varMinutoDegelo3
        End If

        If Not CheckBoxDegelo1.Focused Then
            CheckBoxDegelo1.Checked = MainForm.Ambientes(AmbienteAtivo).bitHabDegelo1
        End If

        If Not CheckBoxDegelo2.Focused Then
            CheckBoxDegelo2.Checked = MainForm.Ambientes(AmbienteAtivo).bitHabDegelo2
        End If

        If Not CheckBoxDegelo3.Focused Then
            CheckBoxDegelo3.Checked = MainForm.Ambientes(AmbienteAtivo).bitHabDegelo3
        End If

        'Fim Atualização tela
        '*************************************************


    End Sub

    Private Sub FrmAmbientes_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        MainForm.varAmbienteAtivo = 0
        MainForm.Label1.Text = "0"
    End Sub

    Private Sub edtSPTempoRecolhimento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtSPTempoRecolhimento.KeyPress
        Dim auxValor, auxAddress As Short
        If e.KeyChar = Chr(13) Then
            If CShort(edtSPTempoRecolhimento.Text) > 60 Then
                MessageBox.Show("O Tempo de Recolhimento deve ser menor que 60min.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            'Precisa separar em 2 words o tempo de variavel tipo TIME do clp siemens para escrever nas 2 words
            auxValor = CShort(edtSPTempoRecolhimento.Text)
            auxAddress = MainForm.Ambientes(AmbienteAtivo).varADTRecolhimento
            MainForm.Label1.Text = AmbienteAtivo & " " & MainForm.Ambientes(AmbienteAtivo).varCLP & " " & auxAddress & " " & auxValor
            EscreveTemposDegelo(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAddress, auxValor)
        End If
    End Sub

    Private Sub edtSPTempoGasQuente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtSPTempoGasQuente.KeyPress
        Dim auxValor, auxAddress As Short
        If e.KeyChar = Chr(13) Then
            If CShort(edtSPTempoGasQuente.Text) > 60 Then
                MessageBox.Show("O Tempo de Gás Quente deve ser menor que 60min.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            'Precisa separar em 2 words o tempo de variavel tipo TIME do clp siemens para escrever nas 2 words
            auxValor = CShort(edtSPTempoGasQuente.Text)
            auxAddress = MainForm.Ambientes(AmbienteAtivo).varADTGasQuente
            MainForm.Label1.Text = AmbienteAtivo & " " & MainForm.Ambientes(AmbienteAtivo).varCLP & " " & auxAddress & " " & auxValor
            EscreveTemposDegelo(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAddress, auxValor)
        End If
    End Sub

    Private Sub edtSPTempoAgua_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtSPTempoAgua.KeyPress
        Dim auxValor, auxAddress As Short
        If e.KeyChar = Chr(13) Then
            If CShort(edtSPTempoAgua.Text) > 15 Then
                MessageBox.Show("O Tempo de Água deve ser menor que 15min.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            'Precisa separar em 2 words o tempo de variavel tipo TIME do clp siemens para escrever nas 2 words
            auxValor = CShort(edtSPTempoAgua.Text)
            auxAddress = MainForm.Ambientes(AmbienteAtivo).varADTAgua
            MainForm.Label1.Text = AmbienteAtivo & " " & MainForm.Ambientes(AmbienteAtivo).varCLP & " " & auxAddress & " " & auxValor
            EscreveTemposDegelo(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAddress, auxValor)
        End If
    End Sub

    Private Sub edtSPTempoGotejamento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtSPTempoGotejamento.KeyPress
        Dim auxValor, auxAddress As Short
        If e.KeyChar = Chr(13) Then
            If CShort(edtSPTempoGotejamento.Text) > 15 Then
                MessageBox.Show("O Tempo de Gotejamento deve ser menor que 15min.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            'Precisa separar em 2 words o tempo de variavel tipo TIME do clp siemens para escrever nas 2 words
            auxValor = CShort(edtSPTempoGotejamento.Text)
            auxAddress = MainForm.Ambientes(AmbienteAtivo).varADTGotejamento
            MainForm.Label1.Text = AmbienteAtivo & " " & MainForm.Ambientes(AmbienteAtivo).varCLP & " " & auxAddress & " " & auxValor
            EscreveTemposDegelo(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAddress, auxValor)
        End If
    End Sub

    Private Sub edtSPTempoPreResfriamento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtSPTempoPreResfriamento.KeyPress
        Dim auxValor, auxAddress As Short
        If e.KeyChar = Chr(13) Then
            If CShort(edtSPTempoPreResfriamento.Text) > 15 Then
                MessageBox.Show("O Tempo de Pré-resfriamento deve ser menor que 15min.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            'Precisa separar em 2 words o tempo de variavel tipo TIME do clp siemens para escrever nas 2 words
            auxValor = CShort(edtSPTempoPreResfriamento.Text)
            auxAddress = MainForm.Ambientes(AmbienteAtivo).varADTPreResfriamento
            MainForm.Label1.Text = AmbienteAtivo & " " & MainForm.Ambientes(AmbienteAtivo).varCLP & " " & auxAddress & " " & auxValor
            EscreveTemposDegelo(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAddress, auxValor)
        End If
    End Sub

    Private Sub edtHoraDegelo1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtHoraDegelo1.KeyPress
        Dim auxValor1, auxValor2, auxAddress As Short
        If e.KeyChar = Chr(13) Then
            If CShort(edtHoraDegelo1.Text) > 23 Then
                MessageBox.Show("Hora do degelo deve ser menor que 24.?", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            auxAddress = MainForm.Ambientes(AmbienteAtivo).varADHora1
            auxValor1 = CShort(edtHoraDegelo1.Text)
            auxValor2 = CShort(edtMinutoDegelo1.Text)
            EscreveHorarioDegelo(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAddress, auxValor1, auxValor2)
        End If
    End Sub

    Private Sub edtMinutoDegelo1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtMinutoDegelo1.KeyPress
        Dim auxValor1, auxValor2, auxAddress As Short
        If e.KeyChar = Chr(13) Then
            If CShort(edtMinutoDegelo1.Text) > 59 Then
                MessageBox.Show("Minuto do degelo deve ser menor que 60!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            auxAddress = MainForm.Ambientes(AmbienteAtivo).varADHora1
            auxValor1 = CShort(edtHoraDegelo1.Text)
            auxValor2 = CShort(edtMinutoDegelo1.Text)
            EscreveHorarioDegelo(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAddress, auxValor1, auxValor2)
        End If
    End Sub

    Private Sub edtHoraDegelo2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtHoraDegelo2.KeyPress
        Dim auxValor1, auxValor2, auxAddress As Short
        If e.KeyChar = Chr(13) Then
            If CShort(edtHoraDegelo2.Text) > 23 Then
                MessageBox.Show("Hora do degelo deve ser menor que 24!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            auxAddress = MainForm.Ambientes(AmbienteAtivo).varADHora2
            auxValor1 = CShort(edtHoraDegelo2.Text)
            auxValor2 = CShort(edtMinutoDegelo2.Text)
            EscreveHorarioDegelo(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAddress, auxValor1, auxValor2)
        End If
    End Sub

    Private Sub edtMinutoDegelo2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtMinutoDegelo2.KeyPress
        Dim auxValor1, auxValor2, auxAddress As Short
        If e.KeyChar = Chr(13) Then
            If CShort(edtMinutoDegelo2.Text) > 59 Then
                MessageBox.Show("Minuto do degelo deve ser menor que 60!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            auxAddress = MainForm.Ambientes(AmbienteAtivo).varADHora2
            auxValor1 = CShort(edtHoraDegelo2.Text)
            auxValor2 = CShort(edtMinutoDegelo2.Text)
            EscreveHorarioDegelo(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAddress, auxValor1, auxValor2)
        End If
    End Sub

    Private Sub edtHoraDegelo3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtHoraDegelo3.KeyPress
        Dim auxValor1, auxValor2, auxAddress As Short
        If e.KeyChar = Chr(13) Then
            If CShort(edtHoraDegelo3.Text) > 23 Then
                MessageBox.Show("Hora do degelo deve ser menor que 24.?", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            auxAddress = MainForm.Ambientes(AmbienteAtivo).varADHora3
            auxValor1 = CShort(edtHoraDegelo3.Text)
            auxValor2 = CShort(edtMinutoDegelo3.Text)
            EscreveHorarioDegelo(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAddress, auxValor1, auxValor2)
        End If
    End Sub

    Private Sub edtMinutoDegelo3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtMinutoDegelo3.KeyPress
        Dim auxValor1, auxValor2, auxAddress As Short
        If e.KeyChar = Chr(13) Then
            If CShort(edtMinutoDegelo3.Text) > 59 Then
                MessageBox.Show("Minuto do degelo deve ser menor que 60!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            auxAddress = MainForm.Ambientes(AmbienteAtivo).varADHora3
            auxValor1 = CShort(edtHoraDegelo3.Text)
            auxValor2 = CShort(edtMinutoDegelo3.Text)
            EscreveHorarioDegelo(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAddress, auxValor1, auxValor2)
        End If
    End Sub

    Private Sub imgLDEvap_Click(sender As Object, e As EventArgs) Handles imgLDEvap.Click
        Dim auxAdress, auxValor As Short
        auxAdress = MainForm.Ambientes(AmbienteAtivo).varADControle
        If MainForm.Ambientes(AmbienteAtivo).bitLigaEvap Then
            auxValor = DesligaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 14)
        Else
            auxValor = LigaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 14)
        End If
        EscreveVarControle(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAdress, auxValor)
    End Sub

    Private Sub imgLDVSSC_Click(sender As Object, e As EventArgs) Handles imgLDVSSC.Click
        Dim auxAdress, auxValor As Short
        auxAdress = MainForm.Ambientes(AmbienteAtivo).varADControle
        If MainForm.Ambientes(AmbienteAtivo).bitLigaVSSC Then
            auxValor = DesligaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 15)
        Else
            auxValor = LigaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 15)
        End If
        EscreveVarControle(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAdress, auxValor)
    End Sub

    Private Sub imgLDVSLL_Click(sender As Object, e As EventArgs) Handles imgLDVSLL.Click
        Dim auxAdress, auxValor As Short
        auxAdress = MainForm.Ambientes(AmbienteAtivo).varADControle
        If MainForm.Ambientes(AmbienteAtivo).bitLigaVSLL Then
            auxValor = DesligaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 0)
        Else
            auxValor = LigaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 0)
        End If
        EscreveVarControle(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAdress, auxValor)
    End Sub

    Private Sub imgLDVSGQ_Click(sender As Object, e As EventArgs) Handles imgLDVSGQ.Click
        Dim auxAdress, auxValor As Short
        auxAdress = MainForm.Ambientes(AmbienteAtivo).varADControle
        If MainForm.Ambientes(AmbienteAtivo).bitLigaVSGQ Then
            auxValor = DesligaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 1)
        Else
            auxValor = LigaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 1)
        End If
        EscreveVarControle(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAdress, auxValor)
    End Sub

    Private Sub imgLDVSAG_Click(sender As Object, e As EventArgs) Handles imgLDVSAG.Click
        Dim auxAdress, auxValor As Short
        auxAdress = MainForm.Ambientes(AmbienteAtivo).varADControle
        If MainForm.Ambientes(AmbienteAtivo).bitLigaVSAG Then
            auxValor = DesligaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 2)
        Else
            auxValor = LigaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 2)
        End If
        EscreveVarControle(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAdress, auxValor)
    End Sub

    Private Sub imgMAEvap_Click(sender As Object, e As EventArgs) Handles imgMAEvap.Click
        Dim auxAdress, auxValor As Short
        If MessageBox.Show("Deseja mudar o modo de operação do Evaporador?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            auxAdress = MainForm.Ambientes(AmbienteAtivo).varADControle
            If MainForm.Ambientes(AmbienteAtivo).bitMAEvap Then
                auxValor = DesligaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 9)
            Else
                auxValor = LigaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 9)
            End If
            EscreveVarControle(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAdress, auxValor)
        End If
    End Sub

    Private Sub imgMAVSSC_Click(sender As Object, e As EventArgs) Handles imgMAVSSC.Click
        Dim auxAdress, auxValor As Short
        If MessageBox.Show("Deseja mudar o modo de operação da VS Sucção?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            auxAdress = MainForm.Ambientes(AmbienteAtivo).varADControle
            If MainForm.Ambientes(AmbienteAtivo).bitMAVSSC Then
                auxValor = DesligaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 10)
            Else
                auxValor = LigaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 10)
            End If
            EscreveVarControle(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAdress, auxValor)
        End If
    End Sub

    Private Sub imgMAVSLL_Click(sender As Object, e As EventArgs) Handles imgMAVSLL.Click
        Dim auxAdress, auxValor As Short
        If MessageBox.Show("Deseja mudar o modo de operação da VS Líquido?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            auxAdress = MainForm.Ambientes(AmbienteAtivo).varADControle
            If MainForm.Ambientes(AmbienteAtivo).bitMAVSLL Then
                auxValor = DesligaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 11)
            Else
                auxValor = LigaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 11)
            End If
            EscreveVarControle(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAdress, auxValor)
        End If
    End Sub

    Private Sub imgMAVSGQ_Click(sender As Object, e As EventArgs) Handles imgMAVSGQ.Click
        Dim auxAdress, auxValor As Short
        If MessageBox.Show("Deseja mudar o modo de operação da VS Gás Quente?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            auxAdress = MainForm.Ambientes(AmbienteAtivo).varADControle
            If MainForm.Ambientes(AmbienteAtivo).bitMAVSGQ Then
                auxValor = DesligaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 12)
            Else
                auxValor = LigaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 12)
            End If
            EscreveVarControle(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAdress, auxValor)
        End If
    End Sub

    Private Sub imgMAVSAG_Click(sender As Object, e As EventArgs) Handles imgMAVSAG.Click
        Dim auxAdress, auxValor As Short
        If MessageBox.Show("Deseja mudar o modo de operação da VS Água?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            auxAdress = MainForm.Ambientes(AmbienteAtivo).varADControle
            If MainForm.Ambientes(AmbienteAtivo).bitMAVSAG Then
                auxValor = DesligaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 13)
            Else
                auxValor = LigaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 13)
            End If
            EscreveVarControle(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAdress, auxValor)
        End If
    End Sub

    Private Sub imgHabAmbiente_Click(sender As Object, e As EventArgs) Handles imgHabAmbiente.Click
        Dim auxAdress, auxValor As Short
        If MessageBox.Show("Deseja mudar o Status do Ambiente?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            auxAdress = MainForm.Ambientes(AmbienteAtivo).varADControle
            If MainForm.Ambientes(AmbienteAtivo).bitHabAmbiente Then
                auxValor = DesligaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 8)
            Else
                auxValor = LigaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 8)
            End If
            EscreveVarControle(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAdress, auxValor)
        End If
    End Sub

    Private Sub imgMADegelo_Click(sender As Object, e As EventArgs) Handles imgMADegelo.Click
        Dim auxAdress, auxValor As Short
        auxAdress = MainForm.Ambientes(AmbienteAtivo).varADControle
        If MainForm.Ambientes(AmbienteAtivo).bitMADegelo Then
            auxValor = DesligaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 3)
        Else
            auxValor = LigaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 3)
        End If
        EscreveVarControle(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAdress, auxValor)
    End Sub

    Private Sub imgForcaDegelo_Click(sender As Object, e As EventArgs) Handles imgForcaDegelo.Click
        Dim auxAdress, auxValor As Short
        If MainForm.Ambientes(AmbienteAtivo).bitMADegelo Then
            MessageBox.Show("O Degelo deve estar no manual.", "informação", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If MessageBox.Show("Deseja fazer degelo manual?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            auxAdress = MainForm.Ambientes(AmbienteAtivo).varADControle
            auxValor = LigaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 7)
            EscreveVarControle(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAdress, auxValor)
        End If
    End Sub

    Private Sub CheckBoxDegelo1_Click(sender As Object, e As EventArgs) Handles CheckBoxDegelo1.Click
        Dim auxAdress, auxValor As Short
        auxAdress = MainForm.Ambientes(AmbienteAtivo).varADControle
        If MainForm.Ambientes(AmbienteAtivo).bitHabDegelo1 Then
            auxValor = DesligaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 4)
        Else
            auxValor = LigaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 4)
        End If
        EscreveVarControle(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAdress, auxValor)
    End Sub

    Private Sub CheckBoxDegelo2_Click(sender As Object, e As EventArgs) Handles CheckBoxDegelo2.Click
        Dim auxAdress, auxValor As Short
        auxAdress = MainForm.Ambientes(AmbienteAtivo).varADControle
        If MainForm.Ambientes(AmbienteAtivo).bitHabDegelo2 Then
            auxValor = DesligaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 5)
        Else
            auxValor = LigaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 5)
        End If
        EscreveVarControle(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAdress, auxValor)
    End Sub

    Private Sub CheckBoxDegelo3_Click(sender As Object, e As EventArgs) Handles CheckBoxDegelo3.Click
        Dim auxAdress, auxValor As Short
        auxAdress = MainForm.Ambientes(AmbienteAtivo).varADControle
        If MainForm.Ambientes(AmbienteAtivo).bitHabDegelo3 Then
            auxValor = DesligaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 6)
        Else
            auxValor = LigaBit(MainForm.Ambientes(AmbienteAtivo).varControle, 6)
        End If
        EscreveVarControle(MainForm.Ambientes(AmbienteAtivo).varCLP, auxAdress, auxValor)
    End Sub

    Private Sub FrmAmbientes_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If MainForm.varAmbienteAtivo = 1 Then
            lblNomeAmbiente.Text = "Tunel 12"
            Me.Text = "Tunel 12"
        ElseIf MainForm.varAmbienteAtivo = 2 Then
            lblNomeAmbiente.Text = "Tunel 11"
            Me.Text = "Tunel 11"
        ElseIf MainForm.varAmbienteAtivo = 3 Then
            lblNomeAmbiente.Text = "Tunel 10"
            Me.Text = "Tunel 10"
        ElseIf MainForm.varAmbienteAtivo = 4 Then
            lblNomeAmbiente.Text = "Tunel 9"
            Me.Text = "Tunel 9"
        ElseIf MainForm.varAmbienteAtivo = 5 Then
            lblNomeAmbiente.Text = "Tunel 8"
            Me.Text = "Tunel 8"
        ElseIf MainForm.varAmbienteAtivo = 6 Then
            lblNomeAmbiente.Text = "Estocagem Congelados 3"
            Me.Text = "Estocagem Congelados 3"
        ElseIf MainForm.varAmbienteAtivo = 7 Then
            lblNomeAmbiente.Text = "Corredor Tuneis"
            Me.Text = "Corredor Tuneis"
            lblAgua.Visible = False
            lblMAVSAG.Visible = False
            lblLDVSAG.Visible = False
            edtSPTempoAgua.Visible = False
            imgMAVSAG.Visible = False
            imgLDVSAG.Visible = False
        ElseIf MainForm.varAmbienteAtivo = 8 Then
            lblNomeAmbiente.Text = "Docas Expedição"
            Me.Text = "Docas Expedição"
            lblSuccao.Visible = False
            lblMAVSSC.Visible = False
            lblLDVSSC.Visible = False
            lblAgua.Visible = False
            lblMAVSAG.Visible = False
            lblLDVSAG.Visible = False
            edtSPTempoAgua.Visible = False
            edtSPTempoGasQuente.Visible = False
            imgMAVSSC.Visible = False
            imgMAVSAG.Visible = False
            imgLDVSSC.Visible = False
            imgLDVSAG.Visible = False
        ElseIf MainForm.varAmbienteAtivo = 11 Then
            lblNomeAmbiente.Text = "Tunel 4"
            Me.Text = "Tunel 4"
        ElseIf MainForm.varAmbienteAtivo = 12 Then
            lblNomeAmbiente.Text = "Tunel 5"
            Me.Text = "Tunel 5"
        ElseIf MainForm.varAmbienteAtivo = 13 Then
            lblNomeAmbiente.Text = "Tunel 6"
            Me.Text = "Tunel 6"
        ElseIf MainForm.varAmbienteAtivo = 14 Then
            lblNomeAmbiente.Text = "Tunel 7"
            Me.Text = "Tunel 7"
        ElseIf MainForm.varAmbienteAtivo = 15 Then
            lblNomeAmbiente.Text = "Estocagem 1"
            Me.Text = "Estocagem 1"
        ElseIf MainForm.varAmbienteAtivo = 16 Then
            lblNomeAmbiente.Text = "Estocagem 2"
            Me.Text = "Estocagem 2"
        ElseIf MainForm.varAmbienteAtivo = 21 Then
            lblNomeAmbiente.Text = "Câmara Carcaça 1"
            Me.Text = "Câmara Carcaça 1"
            lblAgua.Visible = False
            lblMAVSAG.Visible = False
            lblLDVSAG.Visible = False
            edtSPTempoAgua.Visible = False
            imgMAVSAG.Visible = False
            imgLDVSAG.Visible = False
        ElseIf MainForm.varAmbienteAtivo = 22 Then
            lblNomeAmbiente.Text = "Câmara Carcaça 2"
            Me.Text = "Câmara Carcaça 2"
            lblAgua.Visible = False
            lblMAVSAG.Visible = False
            lblLDVSAG.Visible = False
            edtSPTempoAgua.Visible = False
            imgMAVSAG.Visible = False
            imgLDVSAG.Visible = False
        ElseIf MainForm.varAmbienteAtivo = 23 Then
            lblNomeAmbiente.Text = "Câmara Carcaça 3"
            Me.Text = "Câmara Carcaça 3"
            lblAgua.Visible = False
            lblMAVSAG.Visible = False
            lblLDVSAG.Visible = False
            edtSPTempoAgua.Visible = False
            imgMAVSAG.Visible = False
            imgLDVSAG.Visible = False
        ElseIf MainForm.varAmbienteAtivo = 24 Then
            lblNomeAmbiente.Text = "Câmara Carcaça 4"
            Me.Text = "Câmara Carcaça 4"
            lblAgua.Visible = False
            lblMAVSAG.Visible = False
            lblLDVSAG.Visible = False
            edtSPTempoAgua.Visible = False
            imgMAVSAG.Visible = False
            imgLDVSAG.Visible = False
        ElseIf MainForm.varAmbienteAtivo = 25 Then
            lblNomeAmbiente.Text = "Câmara Carcaça 5"
            Me.Text = "Câmara Carcaça 5"
            lblAgua.Visible = False
            lblMAVSAG.Visible = False
            lblLDVSAG.Visible = False
            edtSPTempoAgua.Visible = False
            imgMAVSAG.Visible = False
            imgLDVSAG.Visible = False
        ElseIf MainForm.varAmbienteAtivo = 26 Then
            lblNomeAmbiente.Text = "Câmara Carcaça 6"
            Me.Text = "Câmara Carcaça 6"
            lblAgua.Visible = False
            lblMAVSAG.Visible = False
            lblLDVSAG.Visible = False
            edtSPTempoAgua.Visible = False
            imgMAVSAG.Visible = False
            imgLDVSAG.Visible = False
        ElseIf MainForm.varAmbienteAtivo = 27 Then
            lblNomeAmbiente.Text = "Câmara Carcaça 7"
            Me.Text = "Câmara Carcaça 7"
            lblAgua.Visible = False
            lblMAVSAG.Visible = False
            lblLDVSAG.Visible = False
            edtSPTempoAgua.Visible = False
            imgMAVSAG.Visible = False
            imgLDVSAG.Visible = False
        ElseIf MainForm.varAmbienteAtivo = 28 Then
            lblNomeAmbiente.Text = "Câmara Pulmão"
            Me.Text = "Câmara Pulmão"
            lblAgua.Visible = False
            lblMAVSAG.Visible = False
            lblLDVSAG.Visible = False
            edtSPTempoAgua.Visible = False
            imgMAVSAG.Visible = False
            imgLDVSAG.Visible = False
        ElseIf MainForm.varAmbienteAtivo = 29 Then
            lblNomeAmbiente.Text = "Tunel 1"
            Me.Text = "Tunel 1"
        ElseIf MainForm.varAmbienteAtivo = 30 Then
            lblNomeAmbiente.Text = "Tunel 2"
            Me.Text = "Tunel 2"
        ElseIf MainForm.varAmbienteAtivo = 31 Then
            lblNomeAmbiente.Text = "Tunel 3"
            Me.Text = "Tunel 3"
        ElseIf MainForm.varAmbienteAtivo = 32 Then
            lblNomeAmbiente.Text = "Estocagem"
            Me.Text = "Estocagem"
        End If

        Timer1.Interval = 500
        Timer1.Enabled = True

        MainForm.MenuPrincipal.Focus()

        imgGasQuente.Visible = False
        imgGotejando.Visible = False
        imgRecolhendo.Visible = False
        imgResfrigerando.Visible = False
        imgRepouso.Visible = True
    End Sub

    Private Sub edtOffset_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtOffset.KeyPress
        Dim Valor As Short
        If e.KeyChar = Chr(13) Then
            Valor = CShort(edtOffset.Text) * 10
            EscreveOffSet(MainForm.Ambientes(AmbienteAtivo).varCLP, MainForm.Ambientes(AmbienteAtivo).varADOffSet, Valor)
        End If
    End Sub

    Private Sub edtSetPoint_KeyPress(sender As Object, e As KeyPressEventArgs) Handles edtSetPoint.KeyPress
        Dim Valor As Short
        If e.KeyChar = Chr(13) Then
            Valor = CShort(edtSetPoint.Text)
            EscreveSetpoint(MainForm.Ambientes(AmbienteAtivo).varCLP, MainForm.Ambientes(AmbienteAtivo).varADSetpoint, Valor)
        End If
    End Sub
End Class