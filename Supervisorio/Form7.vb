Imports System.Data.Common

Public Class frmCompressores
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim auxCA As Integer
        auxCA = MainForm.varCompressorAtivo
        lblPressaoSuccao.Text = MainForm.Compressores(auxCA).varPressaoSuccao / 100 & " bar"
        lblPressaoDescarga.Text = MainForm.Compressores(auxCA).varPressaoDescarga / 10 & " bar"
        lblPressaoOleo.Text = MainForm.Compressores(auxCA).varPressaoOleo / 10 & " bar"
        lblPressaoFiltro.Text = MainForm.Compressores(auxCA).varPressaoFiltroOleo / 10 & " bar"
        lblTemperaturaSuccao.Text = MainForm.Compressores(auxCA).varTemperaturaSuccao / 10 & " °C"
        lblTemperaturaDescarga.Text = MainForm.Compressores(auxCA).varTemperaturaDescarga / 10 & " °C"
        lblTemperaturaOleo.Text = MainForm.Compressores(auxCA).varTemperaturaOleo / 10 & " °C"
        lblTemperaturaSeparador.Text = MainForm.Compressores(auxCA).varTemperaturaSeparador / 10 & " °C"
        lblPressaoIntermediario.Text = MainForm.Compressores(auxCA).varPressaoIntermediario / 100 & " bar"
        lblTemperaturaIntermediario.Text = MainForm.Compressores(auxCA).varTemperaturaIntermediario / 10 & " °C"
        lblCorrenteMotor.Text = MainForm.Compressores(auxCA).varCorrenteEletrica & " A"
        lblRotacao.Text = MainForm.Compressores(auxCA).varRotacao & " RPM"
        If MainForm.Compressores(auxCA).varStatus = 0 Then
            lblStatus.Text = "STOP"
        ElseIf MainForm.Compressores(auxCA).varStatus = 1 Then
            lblStatus.Text = "ANTI-CYCLE"
        ElseIf MainForm.Compressores(auxCA).varStatus = 2 Then
            lblStatus.Text = "AUTO STOP"
        ElseIf MainForm.Compressores(auxCA).varStatus = 3 Then
            lblStatus.Text = "CUT IN"
        ElseIf MainForm.Compressores(auxCA).varStatus = 4 Then
            lblStatus.Text = "SYSTEM START"
        ElseIf MainForm.Compressores(auxCA).varStatus = 5 Then
            lblStatus.Text = "OIL PUMP START"
        ElseIf MainForm.Compressores(auxCA).varStatus = 6 Then
            lblStatus.Text = "PRE-START"
        ElseIf MainForm.Compressores(auxCA).varStatus = 7 Then
            lblStatus.Text = "START"
        ElseIf MainForm.Compressores(auxCA).varStatus = 8 Then
            lblStatus.Text = "RUN"
        ElseIf MainForm.Compressores(auxCA).varStatus = 9 Then
            lblStatus.Text = "CUT OUT"
        ElseIf MainForm.Compressores(auxCA).varStatus = 10 Then
            lblStatus.Text = "PUMP OUT"
        End If
    End Sub


    Private Sub frmCompressores_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        If MainForm.varCompressorAtivo = 1 Then
            lblNomeCompressor.Text = "Compressor 1"
            Me.Text = "Compressor 1"
        ElseIf MainForm.varCompressorAtivo = 2 Then
            lblNomeCompressor.Text = "Compressor 2"
            Me.Text = "Compressor 2"
        ElseIf MainForm.varCompressorAtivo = 3 Then
            lblNomeCompressor.Text = "Compressor 3"
            Me.Text = "Compressor 3"
        End If
    End Sub

End Class