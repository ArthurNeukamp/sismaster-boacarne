<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompressores
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCompressores))
        PictureBox1 = New PictureBox()
        Panel1 = New Panel()
        lblStatus = New Label()
        Label3 = New Label()
        lblRotacao = New Label()
        Label10 = New Label()
        lblCorrenteMotor = New Label()
        Label9 = New Label()
        lblPressaoOleo = New Label()
        lblPressaoDescarga = New Label()
        lblTemperaturaIntermediario = New Label()
        Label66 = New Label()
        lblPressaoIntermediario = New Label()
        lblTemperaturaSeparador = New Label()
        lblTemperaturaOleo = New Label()
        lblTemperaturaDescarga = New Label()
        lblTemperaturaSuccao = New Label()
        Label55 = New Label()
        Label50 = New Label()
        Label43 = New Label()
        Label25 = New Label()
        Label23 = New Label()
        lblPressaoFiltro = New Label()
        Label1 = New Label()
        Label31 = New Label()
        Label8 = New Label()
        lblPressaoSuccao = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        lblNomeCompressor = New Label()
        Timer1 = New Timer(components)
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(12, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(482, 560)
        PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Silver
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(lblStatus)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(lblRotacao)
        Panel1.Controls.Add(Label10)
        Panel1.Controls.Add(lblCorrenteMotor)
        Panel1.Controls.Add(Label9)
        Panel1.Controls.Add(lblPressaoOleo)
        Panel1.Controls.Add(lblPressaoDescarga)
        Panel1.Controls.Add(lblTemperaturaIntermediario)
        Panel1.Controls.Add(Label66)
        Panel1.Controls.Add(lblPressaoIntermediario)
        Panel1.Controls.Add(lblTemperaturaSeparador)
        Panel1.Controls.Add(lblTemperaturaOleo)
        Panel1.Controls.Add(lblTemperaturaDescarga)
        Panel1.Controls.Add(lblTemperaturaSuccao)
        Panel1.Controls.Add(Label55)
        Panel1.Controls.Add(Label50)
        Panel1.Controls.Add(Label43)
        Panel1.Controls.Add(Label25)
        Panel1.Controls.Add(Label23)
        Panel1.Controls.Add(lblPressaoFiltro)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Label31)
        Panel1.Controls.Add(Label8)
        Panel1.Controls.Add(lblPressaoSuccao)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(lblNomeCompressor)
        Panel1.Location = New Point(499, 11)
        Panel1.Margin = New Padding(2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(300, 314)
        Panel1.TabIndex = 21
        ' 
        ' lblStatus
        ' 
        lblStatus.BackColor = Color.Black
        lblStatus.BorderStyle = BorderStyle.FixedSingle
        lblStatus.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblStatus.ForeColor = Color.Yellow
        lblStatus.Location = New Point(189, 292)
        lblStatus.Margin = New Padding(2, 0, 2, 0)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(106, 17)
        lblStatus.TabIndex = 40
        lblStatus.Text = "999"
        lblStatus.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label3
        ' 
        Label3.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label3.BorderStyle = BorderStyle.FixedSingle
        Label3.Font = New Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(2, 292)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(186, 17)
        Label3.TabIndex = 39
        Label3.Text = "Status do Compressor"
        Label3.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblRotacao
        ' 
        lblRotacao.BackColor = Color.Black
        lblRotacao.BorderStyle = BorderStyle.FixedSingle
        lblRotacao.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblRotacao.ForeColor = Color.Cyan
        lblRotacao.Location = New Point(189, 274)
        lblRotacao.Margin = New Padding(2, 0, 2, 0)
        lblRotacao.Name = "lblRotacao"
        lblRotacao.Size = New Size(106, 17)
        lblRotacao.TabIndex = 38
        lblRotacao.Text = "999"
        lblRotacao.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label10
        ' 
        Label10.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label10.BorderStyle = BorderStyle.FixedSingle
        Label10.Font = New Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point)
        Label10.Location = New Point(2, 274)
        Label10.Margin = New Padding(2, 0, 2, 0)
        Label10.Name = "Label10"
        Label10.Size = New Size(186, 17)
        Label10.TabIndex = 37
        Label10.Text = "Rotação Motor"
        Label10.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblCorrenteMotor
        ' 
        lblCorrenteMotor.BackColor = Color.Black
        lblCorrenteMotor.BorderStyle = BorderStyle.FixedSingle
        lblCorrenteMotor.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblCorrenteMotor.ForeColor = Color.Cyan
        lblCorrenteMotor.Location = New Point(189, 256)
        lblCorrenteMotor.Margin = New Padding(2, 0, 2, 0)
        lblCorrenteMotor.Name = "lblCorrenteMotor"
        lblCorrenteMotor.Size = New Size(106, 17)
        lblCorrenteMotor.TabIndex = 36
        lblCorrenteMotor.Text = "999"
        lblCorrenteMotor.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label9
        ' 
        Label9.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label9.BorderStyle = BorderStyle.FixedSingle
        Label9.Font = New Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point)
        Label9.Location = New Point(2, 256)
        Label9.Margin = New Padding(2, 0, 2, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(186, 17)
        Label9.TabIndex = 35
        Label9.Text = "Corrente Elétrica Motor"
        Label9.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblPressaoOleo
        ' 
        lblPressaoOleo.BackColor = Color.Black
        lblPressaoOleo.BorderStyle = BorderStyle.FixedSingle
        lblPressaoOleo.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblPressaoOleo.ForeColor = Color.Cyan
        lblPressaoOleo.Location = New Point(189, 103)
        lblPressaoOleo.Margin = New Padding(2, 0, 2, 0)
        lblPressaoOleo.Name = "lblPressaoOleo"
        lblPressaoOleo.Size = New Size(106, 26)
        lblPressaoOleo.TabIndex = 34
        lblPressaoOleo.Text = "00,0 bar"
        lblPressaoOleo.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblPressaoDescarga
        ' 
        lblPressaoDescarga.BackColor = Color.Black
        lblPressaoDescarga.BorderStyle = BorderStyle.FixedSingle
        lblPressaoDescarga.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblPressaoDescarga.ForeColor = Color.Cyan
        lblPressaoDescarga.Location = New Point(189, 76)
        lblPressaoDescarga.Margin = New Padding(2, 0, 2, 0)
        lblPressaoDescarga.Name = "lblPressaoDescarga"
        lblPressaoDescarga.Size = New Size(106, 26)
        lblPressaoDescarga.TabIndex = 33
        lblPressaoDescarga.Text = "00,0 bar"
        lblPressaoDescarga.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTemperaturaIntermediario
        ' 
        lblTemperaturaIntermediario.BackColor = Color.Black
        lblTemperaturaIntermediario.BorderStyle = BorderStyle.FixedSingle
        lblTemperaturaIntermediario.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblTemperaturaIntermediario.ForeColor = Color.Cyan
        lblTemperaturaIntermediario.Location = New Point(189, 238)
        lblTemperaturaIntermediario.Margin = New Padding(2, 0, 2, 0)
        lblTemperaturaIntermediario.Name = "lblTemperaturaIntermediario"
        lblTemperaturaIntermediario.Size = New Size(106, 17)
        lblTemperaturaIntermediario.TabIndex = 32
        lblTemperaturaIntermediario.Text = "999"
        lblTemperaturaIntermediario.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label66
        ' 
        Label66.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label66.BorderStyle = BorderStyle.FixedSingle
        Label66.Font = New Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point)
        Label66.Location = New Point(2, 238)
        Label66.Margin = New Padding(2, 0, 2, 0)
        Label66.Name = "Label66"
        Label66.Size = New Size(186, 17)
        Label66.TabIndex = 30
        Label66.Text = "Temperatura Intermediário"
        Label66.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblPressaoIntermediario
        ' 
        lblPressaoIntermediario.BackColor = Color.Black
        lblPressaoIntermediario.BorderStyle = BorderStyle.FixedSingle
        lblPressaoIntermediario.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblPressaoIntermediario.ForeColor = Color.Cyan
        lblPressaoIntermediario.Location = New Point(189, 220)
        lblPressaoIntermediario.Margin = New Padding(2, 0, 2, 0)
        lblPressaoIntermediario.Name = "lblPressaoIntermediario"
        lblPressaoIntermediario.Size = New Size(106, 17)
        lblPressaoIntermediario.TabIndex = 29
        lblPressaoIntermediario.Text = "999"
        lblPressaoIntermediario.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTemperaturaSeparador
        ' 
        lblTemperaturaSeparador.BackColor = Color.Black
        lblTemperaturaSeparador.BorderStyle = BorderStyle.FixedSingle
        lblTemperaturaSeparador.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblTemperaturaSeparador.ForeColor = Color.Cyan
        lblTemperaturaSeparador.Location = New Point(189, 202)
        lblTemperaturaSeparador.Margin = New Padding(2, 0, 2, 0)
        lblTemperaturaSeparador.Name = "lblTemperaturaSeparador"
        lblTemperaturaSeparador.Size = New Size(106, 17)
        lblTemperaturaSeparador.TabIndex = 28
        lblTemperaturaSeparador.Text = "999"
        lblTemperaturaSeparador.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTemperaturaOleo
        ' 
        lblTemperaturaOleo.BackColor = Color.Black
        lblTemperaturaOleo.BorderStyle = BorderStyle.FixedSingle
        lblTemperaturaOleo.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblTemperaturaOleo.ForeColor = Color.Cyan
        lblTemperaturaOleo.Location = New Point(189, 184)
        lblTemperaturaOleo.Margin = New Padding(2, 0, 2, 0)
        lblTemperaturaOleo.Name = "lblTemperaturaOleo"
        lblTemperaturaOleo.Size = New Size(106, 17)
        lblTemperaturaOleo.TabIndex = 27
        lblTemperaturaOleo.Text = "999"
        lblTemperaturaOleo.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTemperaturaDescarga
        ' 
        lblTemperaturaDescarga.BackColor = Color.Black
        lblTemperaturaDescarga.BorderStyle = BorderStyle.FixedSingle
        lblTemperaturaDescarga.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblTemperaturaDescarga.ForeColor = Color.Cyan
        lblTemperaturaDescarga.Location = New Point(189, 166)
        lblTemperaturaDescarga.Margin = New Padding(2, 0, 2, 0)
        lblTemperaturaDescarga.Name = "lblTemperaturaDescarga"
        lblTemperaturaDescarga.Size = New Size(106, 17)
        lblTemperaturaDescarga.TabIndex = 26
        lblTemperaturaDescarga.Text = "999"
        lblTemperaturaDescarga.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTemperaturaSuccao
        ' 
        lblTemperaturaSuccao.BackColor = Color.Black
        lblTemperaturaSuccao.BorderStyle = BorderStyle.FixedSingle
        lblTemperaturaSuccao.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblTemperaturaSuccao.ForeColor = Color.Cyan
        lblTemperaturaSuccao.Location = New Point(189, 148)
        lblTemperaturaSuccao.Margin = New Padding(2, 0, 2, 0)
        lblTemperaturaSuccao.Name = "lblTemperaturaSuccao"
        lblTemperaturaSuccao.Size = New Size(106, 17)
        lblTemperaturaSuccao.TabIndex = 25
        lblTemperaturaSuccao.Text = "999"
        lblTemperaturaSuccao.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label55
        ' 
        Label55.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label55.BorderStyle = BorderStyle.FixedSingle
        Label55.Font = New Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point)
        Label55.Location = New Point(2, 220)
        Label55.Margin = New Padding(2, 0, 2, 0)
        Label55.Name = "Label55"
        Label55.Size = New Size(186, 17)
        Label55.TabIndex = 19
        Label55.Text = "Pressão Intermediário"
        Label55.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label50
        ' 
        Label50.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label50.BorderStyle = BorderStyle.FixedSingle
        Label50.Font = New Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point)
        Label50.Location = New Point(2, 202)
        Label50.Margin = New Padding(2, 0, 2, 0)
        Label50.Name = "Label50"
        Label50.Size = New Size(186, 17)
        Label50.TabIndex = 18
        Label50.Text = "Temperatura Separador"
        Label50.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label43
        ' 
        Label43.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label43.BorderStyle = BorderStyle.FixedSingle
        Label43.Font = New Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point)
        Label43.Location = New Point(2, 184)
        Label43.Margin = New Padding(2, 0, 2, 0)
        Label43.Name = "Label43"
        Label43.Size = New Size(186, 17)
        Label43.TabIndex = 17
        Label43.Text = "Temperatura Óleo"
        Label43.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label25
        ' 
        Label25.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label25.BorderStyle = BorderStyle.FixedSingle
        Label25.Font = New Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point)
        Label25.Location = New Point(2, 166)
        Label25.Margin = New Padding(2, 0, 2, 0)
        Label25.Name = "Label25"
        Label25.Size = New Size(186, 17)
        Label25.TabIndex = 16
        Label25.Text = "Temperatura Descarga"
        Label25.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label23
        ' 
        Label23.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label23.BorderStyle = BorderStyle.FixedSingle
        Label23.Font = New Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point)
        Label23.Location = New Point(2, 148)
        Label23.Margin = New Padding(2, 0, 2, 0)
        Label23.Name = "Label23"
        Label23.Size = New Size(186, 17)
        Label23.TabIndex = 15
        Label23.Text = "Temperatura Sucção"
        Label23.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblPressaoFiltro
        ' 
        lblPressaoFiltro.BackColor = Color.Black
        lblPressaoFiltro.BorderStyle = BorderStyle.FixedSingle
        lblPressaoFiltro.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblPressaoFiltro.ForeColor = Color.Cyan
        lblPressaoFiltro.Location = New Point(189, 130)
        lblPressaoFiltro.Margin = New Padding(2, 0, 2, 0)
        lblPressaoFiltro.Name = "lblPressaoFiltro"
        lblPressaoFiltro.Size = New Size(106, 17)
        lblPressaoFiltro.TabIndex = 14
        lblPressaoFiltro.Text = "999"
        lblPressaoFiltro.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label1
        ' 
        Label1.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label1.BorderStyle = BorderStyle.FixedSingle
        Label1.Font = New Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(2, 130)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(186, 17)
        Label1.TabIndex = 12
        Label1.Text = "Pressão após Filtro"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label31
        ' 
        Label31.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label31.BorderStyle = BorderStyle.FixedSingle
        Label31.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label31.Location = New Point(2, 103)
        Label31.Margin = New Padding(2, 0, 2, 0)
        Label31.Name = "Label31"
        Label31.Size = New Size(186, 26)
        Label31.TabIndex = 10
        Label31.Text = "Pressão de Óleo"
        Label31.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label8
        ' 
        Label8.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label8.BorderStyle = BorderStyle.FixedSingle
        Label8.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label8.Location = New Point(2, 76)
        Label8.Margin = New Padding(2, 0, 2, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(186, 26)
        Label8.TabIndex = 5
        Label8.Text = "Pressão Descarga"
        Label8.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblPressaoSuccao
        ' 
        lblPressaoSuccao.BackColor = Color.Black
        lblPressaoSuccao.BorderStyle = BorderStyle.FixedSingle
        lblPressaoSuccao.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblPressaoSuccao.ForeColor = Color.Cyan
        lblPressaoSuccao.Location = New Point(189, 49)
        lblPressaoSuccao.Margin = New Padding(2, 0, 2, 0)
        lblPressaoSuccao.Name = "lblPressaoSuccao"
        lblPressaoSuccao.Size = New Size(106, 26)
        lblPressaoSuccao.TabIndex = 4
        lblPressaoSuccao.Text = "00,0 bar"
        lblPressaoSuccao.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label6
        ' 
        Label6.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label6.BorderStyle = BorderStyle.FixedSingle
        Label6.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.Location = New Point(2, 49)
        Label6.Margin = New Padding(2, 0, 2, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(186, 26)
        Label6.TabIndex = 3
        Label6.Text = "Pressão Sucção"
        Label6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label5
        ' 
        Label5.BackColor = Color.Teal
        Label5.BorderStyle = BorderStyle.FixedSingle
        Label5.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label5.ForeColor = SystemColors.ControlLightLight
        Label5.Location = New Point(189, 30)
        Label5.Margin = New Padding(2, 0, 2, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(106, 18)
        Label5.TabIndex = 2
        Label5.Text = "Status"
        Label5.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label4
        ' 
        Label4.BackColor = Color.Teal
        Label4.BorderStyle = BorderStyle.FixedSingle
        Label4.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.ForeColor = SystemColors.ControlLightLight
        Label4.Location = New Point(2, 30)
        Label4.Margin = New Padding(2, 0, 2, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(186, 18)
        Label4.TabIndex = 1
        Label4.Text = "Descrição"
        Label4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblNomeCompressor
        ' 
        lblNomeCompressor.BackColor = Color.FromArgb(CByte(234), CByte(193), CByte(55))
        lblNomeCompressor.BorderStyle = BorderStyle.FixedSingle
        lblNomeCompressor.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblNomeCompressor.Location = New Point(2, 3)
        lblNomeCompressor.Margin = New Padding(2, 0, 2, 0)
        lblNomeCompressor.Name = "lblNomeCompressor"
        lblNomeCompressor.Size = New Size(293, 26)
        lblNomeCompressor.TabIndex = 0
        lblNomeCompressor.Text = "Compressor XX"
        lblNomeCompressor.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Timer1
        ' 
        Timer1.Enabled = True
        Timer1.Interval = 500
        ' 
        ' frmCompressores
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Gray
        ClientSize = New Size(1258, 625)
        Controls.Add(Panel1)
        Controls.Add(PictureBox1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmCompressores"
        ShowIcon = False
        Text = "Compressores"
        WindowState = FormWindowState.Maximized
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTemperaturaIntermediario As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents lblPressaoIntermediario As Label
    Friend WithEvents lblTemperaturaSeparador As Label
    Friend WithEvents lblTemperaturaOleo As Label
    Friend WithEvents lblTemperaturaDescarga As Label
    Friend WithEvents lblTemperaturaSuccao As Label
    Friend WithEvents Label55 As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents lblPressaoFiltro As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblPressaoSuccao As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblNomeCompressor As Label
    Friend WithEvents lblPressaoOleo As Label
    Friend WithEvents lblPressaoDescarga As Label
    Friend WithEvents lblCorrenteMotor As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblStatus As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblRotacao As Label
    Friend WithEvents Label10 As Label
End Class
