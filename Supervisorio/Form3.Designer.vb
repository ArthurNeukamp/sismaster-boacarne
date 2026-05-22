<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSADEMA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSADEMA))
        PictureBox1 = New PictureBox()
        imgCP1 = New PictureBox()
        lblSuccaoCP1 = New Label()
        lblSuccaoCP2 = New Label()
        lblSuccaoCP3 = New Label()
        lblDescargaCP3 = New Label()
        lblDadosCP1 = New Label()
        lblDescargaCP1 = New Label()
        lblDescargaCP2 = New Label()
        lblDadosCP2 = New Label()
        lblDadosCP3 = New Label()
        lblTeste1 = New Label()
        lblTeste3 = New Label()
        imgCP2 = New PictureBox()
        imgCP3 = New PictureBox()
        lblTeste2 = New Label()
        Timer1 = New Timer(components)
        imgCPTipo1ON = New PictureBox()
        imgCPTipo1Falha = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgCP1, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgCP2, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgCP3, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgCPTipo1ON, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgCPTipo1Falha, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(8, 7)
        PictureBox1.Margin = New Padding(2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(1297, 573)
        PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize
        PictureBox1.TabIndex = 18
        PictureBox1.TabStop = False
        ' 
        ' imgCP1
        ' 
        imgCP1.Image = CType(resources.GetObject("imgCP1.Image"), Image)
        imgCP1.Location = New Point(15, 261)
        imgCP1.Name = "imgCP1"
        imgCP1.Size = New Size(191, 77)
        imgCP1.SizeMode = PictureBoxSizeMode.AutoSize
        imgCP1.TabIndex = 19
        imgCP1.TabStop = False
        imgCP1.Visible = False
        ' 
        ' lblSuccaoCP1
        ' 
        lblSuccaoCP1.BackColor = Color.Black
        lblSuccaoCP1.BorderStyle = BorderStyle.FixedSingle
        lblSuccaoCP1.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblSuccaoCP1.ForeColor = Color.Cyan
        lblSuccaoCP1.Location = New Point(8, 220)
        lblSuccaoCP1.Margin = New Padding(2, 0, 2, 0)
        lblSuccaoCP1.Name = "lblSuccaoCP1"
        lblSuccaoCP1.Size = New Size(55, 17)
        lblSuccaoCP1.TabIndex = 58
        lblSuccaoCP1.Text = "-9,99 bar"
        lblSuccaoCP1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblSuccaoCP2
        ' 
        lblSuccaoCP2.BackColor = Color.Black
        lblSuccaoCP2.BorderStyle = BorderStyle.FixedSingle
        lblSuccaoCP2.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblSuccaoCP2.ForeColor = Color.Cyan
        lblSuccaoCP2.Location = New Point(8, 340)
        lblSuccaoCP2.Margin = New Padding(2, 0, 2, 0)
        lblSuccaoCP2.Name = "lblSuccaoCP2"
        lblSuccaoCP2.Size = New Size(55, 17)
        lblSuccaoCP2.TabIndex = 59
        lblSuccaoCP2.Text = "-9,99 bar"
        lblSuccaoCP2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblSuccaoCP3
        ' 
        lblSuccaoCP3.BackColor = Color.Black
        lblSuccaoCP3.BorderStyle = BorderStyle.FixedSingle
        lblSuccaoCP3.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblSuccaoCP3.ForeColor = Color.Cyan
        lblSuccaoCP3.Location = New Point(8, 461)
        lblSuccaoCP3.Margin = New Padding(2, 0, 2, 0)
        lblSuccaoCP3.Name = "lblSuccaoCP3"
        lblSuccaoCP3.Size = New Size(55, 17)
        lblSuccaoCP3.TabIndex = 60
        lblSuccaoCP3.Text = "-9,99 bar"
        lblSuccaoCP3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblDescargaCP3
        ' 
        lblDescargaCP3.BackColor = Color.Black
        lblDescargaCP3.BorderStyle = BorderStyle.FixedSingle
        lblDescargaCP3.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblDescargaCP3.ForeColor = Color.FromArgb(CByte(255), CByte(192), CByte(192))
        lblDescargaCP3.Location = New Point(161, 563)
        lblDescargaCP3.Margin = New Padding(2, 0, 2, 0)
        lblDescargaCP3.Name = "lblDescargaCP3"
        lblDescargaCP3.Size = New Size(50, 17)
        lblDescargaCP3.TabIndex = 61
        lblDescargaCP3.Text = "19,9 bar"
        lblDescargaCP3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblDadosCP1
        ' 
        lblDadosCP1.BackColor = Color.Black
        lblDadosCP1.BorderStyle = BorderStyle.FixedSingle
        lblDadosCP1.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        lblDadosCP1.ForeColor = Color.Lime
        lblDadosCP1.Location = New Point(75, 298)
        lblDadosCP1.Margin = New Padding(2, 0, 2, 0)
        lblDadosCP1.Name = "lblDadosCP1"
        lblDadosCP1.Size = New Size(82, 14)
        lblDadosCP1.TabIndex = 62
        lblDadosCP1.Text = "999 A - 9999 RPM"
        lblDadosCP1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblDescargaCP1
        ' 
        lblDescargaCP1.BackColor = Color.Black
        lblDescargaCP1.BorderStyle = BorderStyle.FixedSingle
        lblDescargaCP1.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblDescargaCP1.ForeColor = Color.FromArgb(CByte(255), CByte(192), CByte(192))
        lblDescargaCP1.Location = New Point(161, 321)
        lblDescargaCP1.Margin = New Padding(2, 0, 2, 0)
        lblDescargaCP1.Name = "lblDescargaCP1"
        lblDescargaCP1.Size = New Size(50, 17)
        lblDescargaCP1.TabIndex = 63
        lblDescargaCP1.Text = "19,9 bar"
        lblDescargaCP1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblDescargaCP2
        ' 
        lblDescargaCP2.BackColor = Color.Black
        lblDescargaCP2.BorderStyle = BorderStyle.FixedSingle
        lblDescargaCP2.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblDescargaCP2.ForeColor = Color.FromArgb(CByte(255), CByte(192), CByte(192))
        lblDescargaCP2.Location = New Point(161, 442)
        lblDescargaCP2.Margin = New Padding(2, 0, 2, 0)
        lblDescargaCP2.Name = "lblDescargaCP2"
        lblDescargaCP2.Size = New Size(50, 17)
        lblDescargaCP2.TabIndex = 64
        lblDescargaCP2.Text = "19,9 bar"
        lblDescargaCP2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblDadosCP2
        ' 
        lblDadosCP2.BackColor = Color.Black
        lblDadosCP2.BorderStyle = BorderStyle.FixedSingle
        lblDadosCP2.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        lblDadosCP2.ForeColor = Color.Lime
        lblDadosCP2.Location = New Point(75, 419)
        lblDadosCP2.Margin = New Padding(2, 0, 2, 0)
        lblDadosCP2.Name = "lblDadosCP2"
        lblDadosCP2.Size = New Size(82, 14)
        lblDadosCP2.TabIndex = 65
        lblDadosCP2.Text = "999 A - 9999 RPM"
        lblDadosCP2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblDadosCP3
        ' 
        lblDadosCP3.BackColor = Color.Black
        lblDadosCP3.BorderStyle = BorderStyle.FixedSingle
        lblDadosCP3.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        lblDadosCP3.ForeColor = Color.Lime
        lblDadosCP3.Location = New Point(75, 540)
        lblDadosCP3.Margin = New Padding(2, 0, 2, 0)
        lblDadosCP3.Name = "lblDadosCP3"
        lblDadosCP3.Size = New Size(82, 14)
        lblDadosCP3.TabIndex = 66
        lblDadosCP3.Text = "999 A - 9999 RPM"
        lblDadosCP3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTeste1
        ' 
        lblTeste1.BackColor = Color.Black
        lblTeste1.BorderStyle = BorderStyle.FixedSingle
        lblTeste1.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblTeste1.ForeColor = Color.Cyan
        lblTeste1.Location = New Point(375, 462)
        lblTeste1.Margin = New Padding(2, 0, 2, 0)
        lblTeste1.Name = "lblTeste1"
        lblTeste1.Size = New Size(82, 22)
        lblTeste1.TabIndex = 67
        lblTeste1.Text = "2999 mm"
        lblTeste1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTeste3
        ' 
        lblTeste3.BackColor = Color.Black
        lblTeste3.BorderStyle = BorderStyle.FixedSingle
        lblTeste3.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblTeste3.ForeColor = Color.Cyan
        lblTeste3.Location = New Point(514, 540)
        lblTeste3.Margin = New Padding(2, 0, 2, 0)
        lblTeste3.Name = "lblTeste3"
        lblTeste3.Size = New Size(72, 26)
        lblTeste3.TabIndex = 68
        lblTeste3.Text = "9,99 bar"
        lblTeste3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' imgCP2
        ' 
        imgCP2.Image = CType(resources.GetObject("imgCP2.Image"), Image)
        imgCP2.Location = New Point(14, 381)
        imgCP2.Name = "imgCP2"
        imgCP2.Size = New Size(191, 77)
        imgCP2.SizeMode = PictureBoxSizeMode.AutoSize
        imgCP2.TabIndex = 69
        imgCP2.TabStop = False
        imgCP2.Visible = False
        ' 
        ' imgCP3
        ' 
        imgCP3.Image = CType(resources.GetObject("imgCP3.Image"), Image)
        imgCP3.Location = New Point(14, 503)
        imgCP3.Name = "imgCP3"
        imgCP3.Size = New Size(191, 77)
        imgCP3.SizeMode = PictureBoxSizeMode.AutoSize
        imgCP3.TabIndex = 70
        imgCP3.TabStop = False
        imgCP3.Visible = False
        ' 
        ' lblTeste2
        ' 
        lblTeste2.BackColor = Color.Black
        lblTeste2.BorderStyle = BorderStyle.FixedSingle
        lblTeste2.Font = New Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point)
        lblTeste2.ForeColor = Color.Cyan
        lblTeste2.Location = New Point(302, 319)
        lblTeste2.Margin = New Padding(2, 0, 2, 0)
        lblTeste2.Name = "lblTeste2"
        lblTeste2.Size = New Size(64, 26)
        lblTeste2.TabIndex = 71
        lblTeste2.Text = "199,9%"
        lblTeste2.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Timer1
        ' 
        Timer1.Enabled = True
        Timer1.Interval = 500
        ' 
        ' imgCPTipo1ON
        ' 
        imgCPTipo1ON.Image = CType(resources.GetObject("imgCPTipo1ON.Image"), Image)
        imgCPTipo1ON.Location = New Point(456, 330)
        imgCPTipo1ON.Name = "imgCPTipo1ON"
        imgCPTipo1ON.Size = New Size(191, 77)
        imgCPTipo1ON.SizeMode = PictureBoxSizeMode.AutoSize
        imgCPTipo1ON.TabIndex = 72
        imgCPTipo1ON.TabStop = False
        imgCPTipo1ON.Visible = False
        ' 
        ' imgCPTipo1Falha
        ' 
        imgCPTipo1Falha.Image = CType(resources.GetObject("imgCPTipo1Falha.Image"), Image)
        imgCPTipo1Falha.Location = New Point(456, 321)
        imgCPTipo1Falha.Name = "imgCPTipo1Falha"
        imgCPTipo1Falha.Size = New Size(191, 77)
        imgCPTipo1Falha.SizeMode = PictureBoxSizeMode.AutoSize
        imgCPTipo1Falha.TabIndex = 73
        imgCPTipo1Falha.TabStop = False
        imgCPTipo1Falha.Visible = False
        ' 
        ' FrmSADEMA
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Gray
        ClientSize = New Size(1364, 603)
        Controls.Add(imgCPTipo1ON)
        Controls.Add(imgCPTipo1Falha)
        Controls.Add(lblTeste2)
        Controls.Add(lblDadosCP3)
        Controls.Add(lblDescargaCP3)
        Controls.Add(imgCP3)
        Controls.Add(lblDescargaCP2)
        Controls.Add(lblDadosCP2)
        Controls.Add(imgCP2)
        Controls.Add(lblTeste3)
        Controls.Add(lblTeste1)
        Controls.Add(lblDescargaCP1)
        Controls.Add(lblDadosCP1)
        Controls.Add(lblSuccaoCP3)
        Controls.Add(lblSuccaoCP2)
        Controls.Add(lblSuccaoCP1)
        Controls.Add(imgCP1)
        Controls.Add(PictureBox1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(2)
        MinimizeBox = False
        Name = "FrmSADEMA"
        ShowIcon = False
        Text = "Sala de Máquinas"
        WindowState = FormWindowState.Maximized
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(imgCP1, ComponentModel.ISupportInitialize).EndInit()
        CType(imgCP2, ComponentModel.ISupportInitialize).EndInit()
        CType(imgCP3, ComponentModel.ISupportInitialize).EndInit()
        CType(imgCPTipo1ON, ComponentModel.ISupportInitialize).EndInit()
        CType(imgCPTipo1Falha, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents imgCP1 As PictureBox
    Friend WithEvents lblSuccaoCP1 As Label
    Friend WithEvents lblSuccaoCP2 As Label
    Friend WithEvents lblSuccaoCP3 As Label
    Friend WithEvents lblDescargaCP3 As Label
    Friend WithEvents lblDadosCP1 As Label
    Friend WithEvents lblDescargaCP1 As Label
    Friend WithEvents lblDescargaCP2 As Label
    Friend WithEvents lblDadosCP2 As Label
    Friend WithEvents lblDadosCP3 As Label
    Friend WithEvents lblTeste1 As Label
    Friend WithEvents lblTeste3 As Label
    Friend WithEvents imgCP2 As PictureBox
    Friend WithEvents imgCP3 As PictureBox
    Friend WithEvents lblTeste2 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents imgCPTipo1ON As PictureBox
    Friend WithEvents imgCPTipo1Falha As PictureBox
End Class
