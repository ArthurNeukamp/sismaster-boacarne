Public Class frmClimatizacao
    Private Sub frmClimatizacao_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Timer1.Interval = 500
        Timer1.Enabled = True
        MainForm.MenuPrincipal.Focus()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        '*******************************************************
        'Climatizados - Atualização tela
        '*******************************************************
        lblTempEmbSec.Text = MainForm.Ambientes(34).varTemperatura / 10 & " °C"
        lblTempDesossa.Text = MainForm.Ambientes(35).varTemperatura / 10 & " °C"
        lblTempOsso.Text = MainForm.Ambientes(36).varTemperatura / 10 & " °C"
        lblTempPaletizacao.Text = MainForm.Ambientes(37).varTemperatura / 10 & " °C"
        lblTempExpCaixaria.Text = MainForm.Ambientes(38).varTemperatura / 10 & " °C"
        lblTempEmbMiudos.Text = MainForm.Ambientes(39).varTemperatura / 10 & " °C"
        lblTempBuchariaLimpa.Text = MainForm.Ambientes(40).varTemperatura / 10 & " °C"
        lblTempBuchariaSuja.Text = MainForm.Ambientes(41).varTemperatura / 10 & " °C"
        lblTempSalaMiudos.Text = MainForm.Ambientes(42).varTemperatura / 10 & " °C"
        lblTempCamaraMiudos.Text = MainForm.Ambientes(43).varTemperatura / 10 & " °C"
        lblTempCamaraEstomago.Text = MainForm.Ambientes(44).varTemperatura / 10 & " °C"
    End Sub
End Class