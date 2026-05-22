Public Class FrmSADEMA
    Private Sub FrmSADEMA_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        MainForm.PainelSadema.Visible = False
    End Sub

    Private Sub FrmSADEMA_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        MainForm.PainelSadema.Visible = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblTeste1.Text = MainForm.varNivelSeparador & " mm"
        lblTeste2.Text = FormatPercent(MainForm.varPosicaoICAD / 27648, 2)
        lblTeste3.Text = MainForm.varPressaoBombaNH3 / 10 & " bar"
        lblDadosCP1.Text = MainForm.Compressores(1).varCorrenteEletrica & " A - " & MainForm.Compressores(1).varRotacao & " RPM"
        lblSuccaoCP1.Text = MainForm.Compressores(1).varPressaoSuccao / 100 & " bar"
        lblDescargaCP1.Text = MainForm.Compressores(1).varPressaoDescarga / 10 & " bar"
        lblDadosCP2.Text = MainForm.Compressores(2).varCorrenteEletrica & " A - " & MainForm.Compressores(2).varRotacao & " RPM"
        lblSuccaoCP2.Text = MainForm.Compressores(2).varPressaoSuccao / 100 & " bar"
        lblDescargaCP2.Text = MainForm.Compressores(2).varPressaoDescarga / 10 & " bar"
        lblDadosCP3.Text = MainForm.Compressores(3).varCorrenteEletrica & " A - " & MainForm.Compressores(3).varRotacao & " RPM"
        lblSuccaoCP3.Text = MainForm.Compressores(3).varPressaoSuccao / 100 & " bar"
        lblDescargaCP3.Text = MainForm.Compressores(3).varPressaoDescarga / 10 & " bar"
        If MainForm.Compressores(1).varStatus > 0 Then
            imgCP1.Image = imgCPTipo1ON.Image
            imgCP1.Visible = True
        End If
        If MainForm.Compressores(2).varStatus > 0 Then
            imgCP2.Image = imgCPTipo1ON.Image
            imgCP2.Visible = True
        End If
        If MainForm.Compressores(3).varStatus > 0 Then
            imgCP3.Image = imgCPTipo1ON.Image
            imgCP3.Visible = True
        End If
    End Sub
End Class