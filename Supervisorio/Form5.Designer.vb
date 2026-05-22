<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAmbientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAmbientes))
        Panel1 = New Panel()
        lblStatusAmbiente = New Label()
        lblHabAmbiente = New Label()
        Label66 = New Label()
        lblLDDegelo = New Label()
        lblLDVSAG = New Label()
        lblLDVSGQ = New Label()
        lblLDVSLL = New Label()
        lblLDVSSC = New Label()
        lblMADegelo = New Label()
        lblMAVSAG = New Label()
        lblMAVSGQ = New Label()
        lblMAVSLL = New Label()
        lblMAVSSC = New Label()
        Label55 = New Label()
        lblAgua = New Label()
        Label43 = New Label()
        Label25 = New Label()
        lblSuccao = New Label()
        lblLDEvaporador = New Label()
        lblMAEvaporador = New Label()
        Label1 = New Label()
        edtOffset = New TextBox()
        Label31 = New Label()
        edtSetPoint = New TextBox()
        Label8 = New Label()
        lblTemp = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        lblNomeAmbiente = New Label()
        Timer1 = New Timer(components)
        Panel2 = New Panel()
        Label34 = New Label()
        edtSPTempoPreResfriamento = New TextBox()
        Label35 = New Label()
        Label32 = New Label()
        edtSPTempoGotejamento = New TextBox()
        Label33 = New Label()
        Label28 = New Label()
        edtSPTempoAgua = New TextBox()
        Label30 = New Label()
        Label20 = New Label()
        edtSPTempoGasQuente = New TextBox()
        Label26 = New Label()
        Label15 = New Label()
        edtSPTempoRecolhimento = New TextBox()
        Label22 = New Label()
        edtHoraDegelo3 = New TextBox()
        edtMinutoDegelo3 = New TextBox()
        CheckBoxDegelo3 = New CheckBox()
        edtHoraDegelo2 = New TextBox()
        edtMinutoDegelo2 = New TextBox()
        CheckBoxDegelo2 = New CheckBox()
        edtHoraDegelo1 = New TextBox()
        edtMinutoDegelo1 = New TextBox()
        Label3 = New Label()
        Label12 = New Label()
        Label11 = New Label()
        Label10 = New Label()
        CheckBoxDegelo1 = New CheckBox()
        Label9 = New Label()
        Label7 = New Label()
        Label2 = New Label()
        Label13 = New Label()
        Label14 = New Label()
        Panel3 = New Panel()
        lblTempoPreResfriamento = New Label()
        Label29 = New Label()
        lblTempoGotejamento = New Label()
        Label27 = New Label()
        lblTempoAgua = New Label()
        Label24 = New Label()
        lblTempoGasQuente = New Label()
        Label21 = New Label()
        lblTempoRecolhimento = New Label()
        Label16 = New Label()
        Label17 = New Label()
        Label18 = New Label()
        Label19 = New Label()
        imgRepouso = New PictureBox()
        imgResfrigerando = New PictureBox()
        imgGasQuente = New PictureBox()
        imgGotejando = New PictureBox()
        imgRecolhendo = New PictureBox()
        imgAgua = New PictureBox()
        imgMotor1 = New PictureBox()
        imgMotor2 = New PictureBox()
        imgMotor3 = New PictureBox()
        imgMotor4 = New PictureBox()
        imgMAEvap = New PictureBox()
        Label36 = New Label()
        Label37 = New Label()
        Label38 = New Label()
        Label39 = New Label()
        imgLDEvap = New PictureBox()
        Label41 = New Label()
        Label40 = New Label()
        imgMAVSSC = New PictureBox()
        Label47 = New Label()
        Label46 = New Label()
        Label45 = New Label()
        imgLDVSSC = New PictureBox()
        Label44 = New Label()
        Label42 = New Label()
        imgMAVSLL = New PictureBox()
        Label53 = New Label()
        Label52 = New Label()
        Label51 = New Label()
        imgLDVSLL = New PictureBox()
        Label49 = New Label()
        Label48 = New Label()
        imgMAVSGQ = New PictureBox()
        Label59 = New Label()
        Label58 = New Label()
        Label57 = New Label()
        imgLDVSGQ = New PictureBox()
        Label56 = New Label()
        Label54 = New Label()
        Panel4 = New Panel()
        Label60 = New Label()
        Label61 = New Label()
        imgLDVSAG = New PictureBox()
        Label62 = New Label()
        Label63 = New Label()
        Label64 = New Label()
        imgMAVSAG = New PictureBox()
        imgBotao90 = New PictureBox()
        imgBotao0 = New PictureBox()
        Label65 = New Label()
        Label67 = New Label()
        Label68 = New Label()
        imgHabAmbiente = New PictureBox()
        imgForcaDegelo = New PictureBox()
        Label69 = New Label()
        Label70 = New Label()
        Label71 = New Label()
        Label72 = New Label()
        imgMADegelo = New PictureBox()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        CType(imgRepouso, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgResfrigerando, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgGasQuente, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgGotejando, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgRecolhendo, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgAgua, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgMotor1, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgMotor2, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgMotor3, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgMotor4, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgMAEvap, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgLDEvap, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgMAVSSC, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgLDVSSC, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgMAVSLL, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgLDVSLL, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgMAVSGQ, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgLDVSGQ, ComponentModel.ISupportInitialize).BeginInit()
        Panel4.SuspendLayout()
        CType(imgLDVSAG, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgMAVSAG, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgBotao90, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgBotao0, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgHabAmbiente, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgForcaDegelo, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgMADegelo, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Silver
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(lblStatusAmbiente)
        Panel1.Controls.Add(lblHabAmbiente)
        Panel1.Controls.Add(Label66)
        Panel1.Controls.Add(lblLDDegelo)
        Panel1.Controls.Add(lblLDVSAG)
        Panel1.Controls.Add(lblLDVSGQ)
        Panel1.Controls.Add(lblLDVSLL)
        Panel1.Controls.Add(lblLDVSSC)
        Panel1.Controls.Add(lblMADegelo)
        Panel1.Controls.Add(lblMAVSAG)
        Panel1.Controls.Add(lblMAVSGQ)
        Panel1.Controls.Add(lblMAVSLL)
        Panel1.Controls.Add(lblMAVSSC)
        Panel1.Controls.Add(Label55)
        Panel1.Controls.Add(lblAgua)
        Panel1.Controls.Add(Label43)
        Panel1.Controls.Add(Label25)
        Panel1.Controls.Add(lblSuccao)
        Panel1.Controls.Add(lblLDEvaporador)
        Panel1.Controls.Add(lblMAEvaporador)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(edtOffset)
        Panel1.Controls.Add(Label31)
        Panel1.Controls.Add(edtSetPoint)
        Panel1.Controls.Add(Label8)
        Panel1.Controls.Add(lblTemp)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(lblNomeAmbiente)
        Panel1.Location = New Point(793, 18)
        Panel1.Margin = New Padding(2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(243, 260)
        Panel1.TabIndex = 20
        ' 
        ' lblStatusAmbiente
        ' 
        lblStatusAmbiente.BackColor = Color.DimGray
        lblStatusAmbiente.BorderStyle = BorderStyle.FixedSingle
        lblStatusAmbiente.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblStatusAmbiente.ForeColor = Color.White
        lblStatusAmbiente.Location = New Point(170, 238)
        lblStatusAmbiente.Margin = New Padding(2, 0, 2, 0)
        lblStatusAmbiente.Name = "lblStatusAmbiente"
        lblStatusAmbiente.Size = New Size(69, 17)
        lblStatusAmbiente.TabIndex = 32
        lblStatusAmbiente.Text = "Desligado"
        lblStatusAmbiente.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblHabAmbiente
        ' 
        lblHabAmbiente.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        lblHabAmbiente.BorderStyle = BorderStyle.FixedSingle
        lblHabAmbiente.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblHabAmbiente.ForeColor = Color.White
        lblHabAmbiente.Location = New Point(92, 238)
        lblHabAmbiente.Margin = New Padding(2, 0, 2, 0)
        lblHabAmbiente.Name = "lblHabAmbiente"
        lblHabAmbiente.Size = New Size(77, 17)
        lblHabAmbiente.TabIndex = 31
        lblHabAmbiente.Text = "Habilitado"
        lblHabAmbiente.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label66
        ' 
        Label66.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label66.BorderStyle = BorderStyle.FixedSingle
        Label66.Font = New Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point)
        Label66.Location = New Point(2, 238)
        Label66.Margin = New Padding(2, 0, 2, 0)
        Label66.Name = "Label66"
        Label66.Size = New Size(89, 17)
        Label66.TabIndex = 30
        Label66.Text = "Ambiente"
        Label66.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblLDDegelo
        ' 
        lblLDDegelo.BackColor = Color.DimGray
        lblLDDegelo.BorderStyle = BorderStyle.FixedSingle
        lblLDDegelo.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblLDDegelo.ForeColor = Color.White
        lblLDDegelo.Location = New Point(170, 220)
        lblLDDegelo.Margin = New Padding(2, 0, 2, 0)
        lblLDDegelo.Name = "lblLDDegelo"
        lblLDDegelo.Size = New Size(69, 17)
        lblLDDegelo.TabIndex = 29
        lblLDDegelo.Text = "Desligado"
        lblLDDegelo.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblLDVSAG
        ' 
        lblLDVSAG.BackColor = Color.DimGray
        lblLDVSAG.BorderStyle = BorderStyle.FixedSingle
        lblLDVSAG.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblLDVSAG.ForeColor = Color.White
        lblLDVSAG.Location = New Point(170, 202)
        lblLDVSAG.Margin = New Padding(2, 0, 2, 0)
        lblLDVSAG.Name = "lblLDVSAG"
        lblLDVSAG.Size = New Size(69, 17)
        lblLDVSAG.TabIndex = 28
        lblLDVSAG.Text = "Desligado"
        lblLDVSAG.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblLDVSGQ
        ' 
        lblLDVSGQ.BackColor = Color.DimGray
        lblLDVSGQ.BorderStyle = BorderStyle.FixedSingle
        lblLDVSGQ.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblLDVSGQ.ForeColor = Color.White
        lblLDVSGQ.Location = New Point(170, 184)
        lblLDVSGQ.Margin = New Padding(2, 0, 2, 0)
        lblLDVSGQ.Name = "lblLDVSGQ"
        lblLDVSGQ.Size = New Size(69, 17)
        lblLDVSGQ.TabIndex = 27
        lblLDVSGQ.Text = "Desligado"
        lblLDVSGQ.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblLDVSLL
        ' 
        lblLDVSLL.BackColor = Color.DimGray
        lblLDVSLL.BorderStyle = BorderStyle.FixedSingle
        lblLDVSLL.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblLDVSLL.ForeColor = Color.White
        lblLDVSLL.Location = New Point(170, 166)
        lblLDVSLL.Margin = New Padding(2, 0, 2, 0)
        lblLDVSLL.Name = "lblLDVSLL"
        lblLDVSLL.Size = New Size(69, 17)
        lblLDVSLL.TabIndex = 26
        lblLDVSLL.Text = "Desligado"
        lblLDVSLL.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblLDVSSC
        ' 
        lblLDVSSC.BackColor = Color.DimGray
        lblLDVSSC.BorderStyle = BorderStyle.FixedSingle
        lblLDVSSC.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblLDVSSC.ForeColor = Color.White
        lblLDVSSC.Location = New Point(170, 148)
        lblLDVSSC.Margin = New Padding(2, 0, 2, 0)
        lblLDVSSC.Name = "lblLDVSSC"
        lblLDVSSC.Size = New Size(69, 17)
        lblLDVSSC.TabIndex = 25
        lblLDVSSC.Text = "Desligado"
        lblLDVSSC.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblMADegelo
        ' 
        lblMADegelo.BackColor = Color.DarkBlue
        lblMADegelo.BorderStyle = BorderStyle.FixedSingle
        lblMADegelo.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblMADegelo.ForeColor = Color.White
        lblMADegelo.Location = New Point(92, 220)
        lblMADegelo.Margin = New Padding(2, 0, 2, 0)
        lblMADegelo.Name = "lblMADegelo"
        lblMADegelo.Size = New Size(77, 17)
        lblMADegelo.TabIndex = 24
        lblMADegelo.Text = "Automático"
        lblMADegelo.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblMAVSAG
        ' 
        lblMAVSAG.BackColor = Color.DarkBlue
        lblMAVSAG.BorderStyle = BorderStyle.FixedSingle
        lblMAVSAG.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblMAVSAG.ForeColor = Color.White
        lblMAVSAG.Location = New Point(92, 202)
        lblMAVSAG.Margin = New Padding(2, 0, 2, 0)
        lblMAVSAG.Name = "lblMAVSAG"
        lblMAVSAG.Size = New Size(77, 17)
        lblMAVSAG.TabIndex = 23
        lblMAVSAG.Text = "Automático"
        lblMAVSAG.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblMAVSGQ
        ' 
        lblMAVSGQ.BackColor = Color.DarkBlue
        lblMAVSGQ.BorderStyle = BorderStyle.FixedSingle
        lblMAVSGQ.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblMAVSGQ.ForeColor = Color.White
        lblMAVSGQ.Location = New Point(92, 184)
        lblMAVSGQ.Margin = New Padding(2, 0, 2, 0)
        lblMAVSGQ.Name = "lblMAVSGQ"
        lblMAVSGQ.Size = New Size(77, 17)
        lblMAVSGQ.TabIndex = 22
        lblMAVSGQ.Text = "Automático"
        lblMAVSGQ.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblMAVSLL
        ' 
        lblMAVSLL.BackColor = Color.DarkBlue
        lblMAVSLL.BorderStyle = BorderStyle.FixedSingle
        lblMAVSLL.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblMAVSLL.ForeColor = Color.White
        lblMAVSLL.Location = New Point(92, 166)
        lblMAVSLL.Margin = New Padding(2, 0, 2, 0)
        lblMAVSLL.Name = "lblMAVSLL"
        lblMAVSLL.Size = New Size(77, 17)
        lblMAVSLL.TabIndex = 21
        lblMAVSLL.Text = "Automático"
        lblMAVSLL.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblMAVSSC
        ' 
        lblMAVSSC.BackColor = Color.DarkBlue
        lblMAVSSC.BorderStyle = BorderStyle.FixedSingle
        lblMAVSSC.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblMAVSSC.ForeColor = Color.White
        lblMAVSSC.Location = New Point(92, 148)
        lblMAVSSC.Margin = New Padding(2, 0, 2, 0)
        lblMAVSSC.Name = "lblMAVSSC"
        lblMAVSSC.Size = New Size(77, 17)
        lblMAVSSC.TabIndex = 20
        lblMAVSSC.Text = "Automático"
        lblMAVSSC.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label55
        ' 
        Label55.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label55.BorderStyle = BorderStyle.FixedSingle
        Label55.Font = New Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point)
        Label55.Location = New Point(2, 220)
        Label55.Margin = New Padding(2, 0, 2, 0)
        Label55.Name = "Label55"
        Label55.Size = New Size(89, 17)
        Label55.TabIndex = 19
        Label55.Text = "Degelo"
        Label55.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblAgua
        ' 
        lblAgua.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        lblAgua.BorderStyle = BorderStyle.FixedSingle
        lblAgua.Font = New Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point)
        lblAgua.Location = New Point(2, 202)
        lblAgua.Margin = New Padding(2, 0, 2, 0)
        lblAgua.Name = "lblAgua"
        lblAgua.Size = New Size(89, 17)
        lblAgua.TabIndex = 18
        lblAgua.Text = "VS Agua"
        lblAgua.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label43
        ' 
        Label43.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label43.BorderStyle = BorderStyle.FixedSingle
        Label43.Font = New Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point)
        Label43.Location = New Point(2, 184)
        Label43.Margin = New Padding(2, 0, 2, 0)
        Label43.Name = "Label43"
        Label43.Size = New Size(89, 17)
        Label43.TabIndex = 17
        Label43.Text = "VS Gás Quente"
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
        Label25.Size = New Size(89, 17)
        Label25.TabIndex = 16
        Label25.Text = "VS Líquido"
        Label25.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblSuccao
        ' 
        lblSuccao.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        lblSuccao.BorderStyle = BorderStyle.FixedSingle
        lblSuccao.Font = New Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point)
        lblSuccao.Location = New Point(2, 148)
        lblSuccao.Margin = New Padding(2, 0, 2, 0)
        lblSuccao.Name = "lblSuccao"
        lblSuccao.Size = New Size(89, 17)
        lblSuccao.TabIndex = 15
        lblSuccao.Text = "VS Sucção"
        lblSuccao.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblLDEvaporador
        ' 
        lblLDEvaporador.BackColor = Color.DimGray
        lblLDEvaporador.BorderStyle = BorderStyle.FixedSingle
        lblLDEvaporador.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblLDEvaporador.ForeColor = Color.White
        lblLDEvaporador.Location = New Point(170, 130)
        lblLDEvaporador.Margin = New Padding(2, 0, 2, 0)
        lblLDEvaporador.Name = "lblLDEvaporador"
        lblLDEvaporador.Size = New Size(69, 17)
        lblLDEvaporador.TabIndex = 14
        lblLDEvaporador.Text = "Desligado"
        lblLDEvaporador.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblMAEvaporador
        ' 
        lblMAEvaporador.BackColor = Color.DarkBlue
        lblMAEvaporador.BorderStyle = BorderStyle.FixedSingle
        lblMAEvaporador.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblMAEvaporador.ForeColor = Color.White
        lblMAEvaporador.Location = New Point(92, 130)
        lblMAEvaporador.Margin = New Padding(2, 0, 2, 0)
        lblMAEvaporador.Name = "lblMAEvaporador"
        lblMAEvaporador.Size = New Size(77, 17)
        lblMAEvaporador.TabIndex = 13
        lblMAEvaporador.Text = "Automático"
        lblMAEvaporador.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label1
        ' 
        Label1.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label1.BorderStyle = BorderStyle.FixedSingle
        Label1.Font = New Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(2, 130)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(89, 17)
        Label1.TabIndex = 12
        Label1.Text = "Evaporadores"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' edtOffset
        ' 
        edtOffset.BorderStyle = BorderStyle.None
        edtOffset.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        edtOffset.Location = New Point(135, 104)
        edtOffset.Margin = New Padding(2)
        edtOffset.Name = "edtOffset"
        edtOffset.Size = New Size(102, 22)
        edtOffset.TabIndex = 11
        edtOffset.Text = "00,0 °C"
        edtOffset.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label31
        ' 
        Label31.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label31.BorderStyle = BorderStyle.FixedSingle
        Label31.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label31.Location = New Point(2, 103)
        Label31.Margin = New Padding(2, 0, 2, 0)
        Label31.Name = "Label31"
        Label31.Size = New Size(129, 26)
        Label31.TabIndex = 10
        Label31.Text = "OffSet"
        Label31.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' edtSetPoint
        ' 
        edtSetPoint.BorderStyle = BorderStyle.None
        edtSetPoint.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        edtSetPoint.Location = New Point(135, 77)
        edtSetPoint.Margin = New Padding(2)
        edtSetPoint.Name = "edtSetPoint"
        edtSetPoint.Size = New Size(102, 22)
        edtSetPoint.TabIndex = 6
        edtSetPoint.Text = "00,0 °C"
        edtSetPoint.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label8
        ' 
        Label8.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label8.BorderStyle = BorderStyle.FixedSingle
        Label8.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label8.Location = New Point(2, 76)
        Label8.Margin = New Padding(2, 0, 2, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(129, 26)
        Label8.TabIndex = 5
        Label8.Text = "SetPoint"
        Label8.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTemp
        ' 
        lblTemp.BackColor = Color.Black
        lblTemp.BorderStyle = BorderStyle.FixedSingle
        lblTemp.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblTemp.ForeColor = Color.Cyan
        lblTemp.Location = New Point(133, 49)
        lblTemp.Margin = New Padding(2, 0, 2, 0)
        lblTemp.Name = "lblTemp"
        lblTemp.Size = New Size(106, 26)
        lblTemp.TabIndex = 4
        lblTemp.Text = "00,0 °C"
        lblTemp.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label6
        ' 
        Label6.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label6.BorderStyle = BorderStyle.FixedSingle
        Label6.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.Location = New Point(2, 49)
        Label6.Margin = New Padding(2, 0, 2, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(129, 26)
        Label6.TabIndex = 3
        Label6.Text = "Temperatura"
        Label6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label5
        ' 
        Label5.BackColor = Color.Teal
        Label5.BorderStyle = BorderStyle.FixedSingle
        Label5.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label5.ForeColor = SystemColors.ControlLightLight
        Label5.Location = New Point(133, 30)
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
        Label4.Size = New Size(129, 18)
        Label4.TabIndex = 1
        Label4.Text = "Descrição"
        Label4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblNomeAmbiente
        ' 
        lblNomeAmbiente.BackColor = Color.FromArgb(CByte(234), CByte(193), CByte(55))
        lblNomeAmbiente.BorderStyle = BorderStyle.FixedSingle
        lblNomeAmbiente.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblNomeAmbiente.Location = New Point(2, 3)
        lblNomeAmbiente.Margin = New Padding(2, 0, 2, 0)
        lblNomeAmbiente.Name = "lblNomeAmbiente"
        lblNomeAmbiente.Size = New Size(237, 26)
        lblNomeAmbiente.TabIndex = 0
        lblNomeAmbiente.Text = "Túnel XX"
        lblNomeAmbiente.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Timer1
        ' 
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Silver
        Panel2.Controls.Add(Label34)
        Panel2.Controls.Add(edtSPTempoPreResfriamento)
        Panel2.Controls.Add(Label35)
        Panel2.Controls.Add(Label32)
        Panel2.Controls.Add(edtSPTempoGotejamento)
        Panel2.Controls.Add(Label33)
        Panel2.Controls.Add(Label28)
        Panel2.Controls.Add(edtSPTempoAgua)
        Panel2.Controls.Add(Label30)
        Panel2.Controls.Add(Label20)
        Panel2.Controls.Add(edtSPTempoGasQuente)
        Panel2.Controls.Add(Label26)
        Panel2.Controls.Add(Label15)
        Panel2.Controls.Add(edtSPTempoRecolhimento)
        Panel2.Controls.Add(Label22)
        Panel2.Controls.Add(edtHoraDegelo3)
        Panel2.Controls.Add(edtMinutoDegelo3)
        Panel2.Controls.Add(CheckBoxDegelo3)
        Panel2.Controls.Add(edtHoraDegelo2)
        Panel2.Controls.Add(edtMinutoDegelo2)
        Panel2.Controls.Add(CheckBoxDegelo2)
        Panel2.Controls.Add(edtHoraDegelo1)
        Panel2.Controls.Add(edtMinutoDegelo1)
        Panel2.Controls.Add(Label3)
        Panel2.Controls.Add(Label12)
        Panel2.Controls.Add(Label11)
        Panel2.Controls.Add(Label10)
        Panel2.Controls.Add(CheckBoxDegelo1)
        Panel2.Controls.Add(Label9)
        Panel2.Controls.Add(Label7)
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(Label13)
        Panel2.Controls.Add(Label14)
        Panel2.Location = New Point(790, 281)
        Panel2.Margin = New Padding(2)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(253, 292)
        Panel2.TabIndex = 21
        ' 
        ' Label34
        ' 
        Label34.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label34.BorderStyle = BorderStyle.FixedSingle
        Label34.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label34.Location = New Point(203, 238)
        Label34.Margin = New Padding(2, 0, 2, 0)
        Label34.Name = "Label34"
        Label34.Size = New Size(46, 26)
        Label34.TabIndex = 64
        Label34.Text = "Min."
        Label34.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' edtSPTempoPreResfriamento
        ' 
        edtSPTempoPreResfriamento.BorderStyle = BorderStyle.None
        edtSPTempoPreResfriamento.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        edtSPTempoPreResfriamento.Location = New Point(139, 240)
        edtSPTempoPreResfriamento.Margin = New Padding(2)
        edtSPTempoPreResfriamento.Name = "edtSPTempoPreResfriamento"
        edtSPTempoPreResfriamento.Size = New Size(58, 22)
        edtSPTempoPreResfriamento.TabIndex = 63
        edtSPTempoPreResfriamento.Text = "99"
        edtSPTempoPreResfriamento.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label35
        ' 
        Label35.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label35.BorderStyle = BorderStyle.FixedSingle
        Label35.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label35.Location = New Point(3, 238)
        Label35.Margin = New Padding(2, 0, 2, 0)
        Label35.Name = "Label35"
        Label35.Size = New Size(129, 26)
        Label35.TabIndex = 62
        Label35.Text = "Pré-Resfriam."
        Label35.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label32
        ' 
        Label32.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label32.BorderStyle = BorderStyle.FixedSingle
        Label32.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label32.Location = New Point(203, 211)
        Label32.Margin = New Padding(2, 0, 2, 0)
        Label32.Name = "Label32"
        Label32.Size = New Size(46, 26)
        Label32.TabIndex = 61
        Label32.Text = "Min."
        Label32.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' edtSPTempoGotejamento
        ' 
        edtSPTempoGotejamento.BorderStyle = BorderStyle.None
        edtSPTempoGotejamento.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        edtSPTempoGotejamento.Location = New Point(139, 213)
        edtSPTempoGotejamento.Margin = New Padding(2)
        edtSPTempoGotejamento.Name = "edtSPTempoGotejamento"
        edtSPTempoGotejamento.Size = New Size(58, 22)
        edtSPTempoGotejamento.TabIndex = 60
        edtSPTempoGotejamento.Text = "99"
        edtSPTempoGotejamento.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label33
        ' 
        Label33.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label33.BorderStyle = BorderStyle.FixedSingle
        Label33.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label33.Location = New Point(3, 211)
        Label33.Margin = New Padding(2, 0, 2, 0)
        Label33.Name = "Label33"
        Label33.Size = New Size(129, 26)
        Label33.TabIndex = 59
        Label33.Text = "Gotejamento"
        Label33.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label28
        ' 
        Label28.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label28.BorderStyle = BorderStyle.FixedSingle
        Label28.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label28.Location = New Point(203, 184)
        Label28.Margin = New Padding(2, 0, 2, 0)
        Label28.Name = "Label28"
        Label28.Size = New Size(46, 26)
        Label28.TabIndex = 58
        Label28.Text = "Min."
        Label28.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' edtSPTempoAgua
        ' 
        edtSPTempoAgua.BorderStyle = BorderStyle.None
        edtSPTempoAgua.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        edtSPTempoAgua.Location = New Point(139, 186)
        edtSPTempoAgua.Margin = New Padding(2)
        edtSPTempoAgua.Name = "edtSPTempoAgua"
        edtSPTempoAgua.Size = New Size(58, 22)
        edtSPTempoAgua.TabIndex = 57
        edtSPTempoAgua.Text = "99"
        edtSPTempoAgua.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label30
        ' 
        Label30.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label30.BorderStyle = BorderStyle.FixedSingle
        Label30.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label30.Location = New Point(3, 184)
        Label30.Margin = New Padding(2, 0, 2, 0)
        Label30.Name = "Label30"
        Label30.Size = New Size(129, 26)
        Label30.TabIndex = 56
        Label30.Text = "Água"
        Label30.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label20
        ' 
        Label20.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label20.BorderStyle = BorderStyle.FixedSingle
        Label20.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label20.Location = New Point(203, 157)
        Label20.Margin = New Padding(2, 0, 2, 0)
        Label20.Name = "Label20"
        Label20.Size = New Size(46, 26)
        Label20.TabIndex = 55
        Label20.Text = "Min."
        Label20.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' edtSPTempoGasQuente
        ' 
        edtSPTempoGasQuente.BorderStyle = BorderStyle.None
        edtSPTempoGasQuente.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        edtSPTempoGasQuente.Location = New Point(139, 159)
        edtSPTempoGasQuente.Margin = New Padding(2)
        edtSPTempoGasQuente.Name = "edtSPTempoGasQuente"
        edtSPTempoGasQuente.Size = New Size(58, 22)
        edtSPTempoGasQuente.TabIndex = 54
        edtSPTempoGasQuente.Text = "99"
        edtSPTempoGasQuente.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label26
        ' 
        Label26.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label26.BorderStyle = BorderStyle.FixedSingle
        Label26.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label26.Location = New Point(3, 157)
        Label26.Margin = New Padding(2, 0, 2, 0)
        Label26.Name = "Label26"
        Label26.Size = New Size(129, 26)
        Label26.TabIndex = 53
        Label26.Text = "Gás Quente"
        Label26.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label15
        ' 
        Label15.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label15.BorderStyle = BorderStyle.FixedSingle
        Label15.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label15.Location = New Point(203, 130)
        Label15.Margin = New Padding(2, 0, 2, 0)
        Label15.Name = "Label15"
        Label15.Size = New Size(46, 26)
        Label15.TabIndex = 52
        Label15.Text = "Min."
        Label15.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' edtSPTempoRecolhimento
        ' 
        edtSPTempoRecolhimento.BorderStyle = BorderStyle.None
        edtSPTempoRecolhimento.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        edtSPTempoRecolhimento.Location = New Point(139, 132)
        edtSPTempoRecolhimento.Margin = New Padding(2)
        edtSPTempoRecolhimento.Name = "edtSPTempoRecolhimento"
        edtSPTempoRecolhimento.Size = New Size(58, 22)
        edtSPTempoRecolhimento.TabIndex = 51
        edtSPTempoRecolhimento.Text = "99"
        edtSPTempoRecolhimento.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label22
        ' 
        Label22.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label22.BorderStyle = BorderStyle.FixedSingle
        Label22.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label22.Location = New Point(3, 130)
        Label22.Margin = New Padding(2, 0, 2, 0)
        Label22.Name = "Label22"
        Label22.Size = New Size(129, 26)
        Label22.TabIndex = 50
        Label22.Text = "Recolhimento"
        Label22.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' edtHoraDegelo3
        ' 
        edtHoraDegelo3.BorderStyle = BorderStyle.None
        edtHoraDegelo3.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        edtHoraDegelo3.Location = New Point(166, 101)
        edtHoraDegelo3.Margin = New Padding(2)
        edtHoraDegelo3.Name = "edtHoraDegelo3"
        edtHoraDegelo3.Size = New Size(35, 22)
        edtHoraDegelo3.TabIndex = 45
        edtHoraDegelo3.Text = "99"
        edtHoraDegelo3.TextAlign = HorizontalAlignment.Center
        ' 
        ' edtMinutoDegelo3
        ' 
        edtMinutoDegelo3.BorderStyle = BorderStyle.None
        edtMinutoDegelo3.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        edtMinutoDegelo3.Location = New Point(213, 101)
        edtMinutoDegelo3.Margin = New Padding(2)
        edtMinutoDegelo3.Name = "edtMinutoDegelo3"
        edtMinutoDegelo3.Size = New Size(35, 22)
        edtMinutoDegelo3.TabIndex = 46
        edtMinutoDegelo3.Text = "99"
        edtMinutoDegelo3.TextAlign = HorizontalAlignment.Center
        ' 
        ' CheckBoxDegelo3
        ' 
        CheckBoxDegelo3.AutoSize = True
        CheckBoxDegelo3.CheckAlign = ContentAlignment.MiddleCenter
        CheckBoxDegelo3.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        CheckBoxDegelo3.Location = New Point(141, 107)
        CheckBoxDegelo3.Margin = New Padding(2)
        CheckBoxDegelo3.Name = "CheckBoxDegelo3"
        CheckBoxDegelo3.Size = New Size(15, 14)
        CheckBoxDegelo3.TabIndex = 44
        CheckBoxDegelo3.UseVisualStyleBackColor = True
        ' 
        ' edtHoraDegelo2
        ' 
        edtHoraDegelo2.BorderStyle = BorderStyle.None
        edtHoraDegelo2.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        edtHoraDegelo2.Location = New Point(166, 76)
        edtHoraDegelo2.Margin = New Padding(2)
        edtHoraDegelo2.Name = "edtHoraDegelo2"
        edtHoraDegelo2.Size = New Size(35, 22)
        edtHoraDegelo2.TabIndex = 41
        edtHoraDegelo2.Text = "99"
        edtHoraDegelo2.TextAlign = HorizontalAlignment.Center
        ' 
        ' edtMinutoDegelo2
        ' 
        edtMinutoDegelo2.BorderStyle = BorderStyle.None
        edtMinutoDegelo2.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        edtMinutoDegelo2.Location = New Point(213, 76)
        edtMinutoDegelo2.Margin = New Padding(2)
        edtMinutoDegelo2.Name = "edtMinutoDegelo2"
        edtMinutoDegelo2.Size = New Size(35, 22)
        edtMinutoDegelo2.TabIndex = 42
        edtMinutoDegelo2.Text = "99"
        edtMinutoDegelo2.TextAlign = HorizontalAlignment.Center
        ' 
        ' CheckBoxDegelo2
        ' 
        CheckBoxDegelo2.AutoSize = True
        CheckBoxDegelo2.CheckAlign = ContentAlignment.MiddleCenter
        CheckBoxDegelo2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        CheckBoxDegelo2.Location = New Point(141, 81)
        CheckBoxDegelo2.Margin = New Padding(2)
        CheckBoxDegelo2.Name = "CheckBoxDegelo2"
        CheckBoxDegelo2.Size = New Size(15, 14)
        CheckBoxDegelo2.TabIndex = 40
        CheckBoxDegelo2.UseVisualStyleBackColor = True
        ' 
        ' edtHoraDegelo1
        ' 
        edtHoraDegelo1.BorderStyle = BorderStyle.None
        edtHoraDegelo1.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        edtHoraDegelo1.Location = New Point(166, 51)
        edtHoraDegelo1.Margin = New Padding(2)
        edtHoraDegelo1.Name = "edtHoraDegelo1"
        edtHoraDegelo1.Size = New Size(35, 22)
        edtHoraDegelo1.TabIndex = 37
        edtHoraDegelo1.Text = "99"
        edtHoraDegelo1.TextAlign = HorizontalAlignment.Center
        ' 
        ' edtMinutoDegelo1
        ' 
        edtMinutoDegelo1.BorderStyle = BorderStyle.None
        edtMinutoDegelo1.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        edtMinutoDegelo1.Location = New Point(213, 51)
        edtMinutoDegelo1.Margin = New Padding(2)
        edtMinutoDegelo1.Name = "edtMinutoDegelo1"
        edtMinutoDegelo1.Size = New Size(35, 22)
        edtMinutoDegelo1.TabIndex = 38
        edtMinutoDegelo1.Text = "99"
        edtMinutoDegelo1.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label3
        ' 
        Label3.BackColor = Color.Teal
        Label3.BorderStyle = BorderStyle.FixedSingle
        Label3.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.ForeColor = SystemColors.ControlLightLight
        Label3.Location = New Point(133, 30)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(116, 18)
        Label3.TabIndex = 4
        Label3.Text = "Programado"
        Label3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point)
        Label12.Location = New Point(199, 43)
        Label12.Margin = New Padding(2, 0, 2, 0)
        Label12.Name = "Label12"
        Label12.Size = New Size(19, 30)
        Label12.TabIndex = 39
        Label12.Text = ":"
        Label12.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label11
        ' 
        Label11.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label11.BorderStyle = BorderStyle.FixedSingle
        Label11.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label11.Location = New Point(3, 103)
        Label11.Margin = New Padding(2, 0, 2, 0)
        Label11.Name = "Label11"
        Label11.Size = New Size(129, 26)
        Label11.TabIndex = 36
        Label11.Text = "Degelo 3"
        Label11.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label10
        ' 
        Label10.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label10.BorderStyle = BorderStyle.FixedSingle
        Label10.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label10.Location = New Point(3, 76)
        Label10.Margin = New Padding(2, 0, 2, 0)
        Label10.Name = "Label10"
        Label10.Size = New Size(129, 26)
        Label10.TabIndex = 35
        Label10.Text = "Degelo 2"
        Label10.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' CheckBoxDegelo1
        ' 
        CheckBoxDegelo1.AutoSize = True
        CheckBoxDegelo1.CheckAlign = ContentAlignment.MiddleCenter
        CheckBoxDegelo1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        CheckBoxDegelo1.Location = New Point(141, 56)
        CheckBoxDegelo1.Margin = New Padding(2)
        CheckBoxDegelo1.Name = "CheckBoxDegelo1"
        CheckBoxDegelo1.Size = New Size(15, 14)
        CheckBoxDegelo1.TabIndex = 34
        CheckBoxDegelo1.UseVisualStyleBackColor = True
        ' 
        ' Label9
        ' 
        Label9.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label9.BorderStyle = BorderStyle.FixedSingle
        Label9.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label9.Location = New Point(3, 49)
        Label9.Margin = New Padding(2, 0, 2, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(129, 26)
        Label9.TabIndex = 33
        Label9.Text = "Degelo 1"
        Label9.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label7
        ' 
        Label7.BackColor = Color.Teal
        Label7.BorderStyle = BorderStyle.FixedSingle
        Label7.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label7.ForeColor = SystemColors.ControlLightLight
        Label7.Location = New Point(3, 30)
        Label7.Margin = New Padding(2, 0, 2, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(129, 18)
        Label7.TabIndex = 3
        Label7.Text = "Descrição"
        Label7.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label2
        ' 
        Label2.BackColor = Color.FromArgb(CByte(234), CByte(193), CByte(55))
        Label2.BorderStyle = BorderStyle.FixedSingle
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.Location = New Point(2, 3)
        Label2.Margin = New Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(247, 26)
        Label2.TabIndex = 1
        Label2.Text = "Parametros de Degelo"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point)
        Label13.Location = New Point(199, 69)
        Label13.Margin = New Padding(2, 0, 2, 0)
        Label13.Name = "Label13"
        Label13.Size = New Size(19, 30)
        Label13.TabIndex = 43
        Label13.Text = ":"
        Label13.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point)
        Label14.Location = New Point(199, 94)
        Label14.Margin = New Padding(2, 0, 2, 0)
        Label14.Name = "Label14"
        Label14.Size = New Size(19, 30)
        Label14.TabIndex = 47
        Label14.Text = ":"
        Label14.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.Silver
        Panel3.Controls.Add(lblTempoPreResfriamento)
        Panel3.Controls.Add(Label29)
        Panel3.Controls.Add(lblTempoGotejamento)
        Panel3.Controls.Add(Label27)
        Panel3.Controls.Add(lblTempoAgua)
        Panel3.Controls.Add(Label24)
        Panel3.Controls.Add(lblTempoGasQuente)
        Panel3.Controls.Add(Label21)
        Panel3.Controls.Add(lblTempoRecolhimento)
        Panel3.Controls.Add(Label16)
        Panel3.Controls.Add(Label17)
        Panel3.Controls.Add(Label18)
        Panel3.Controls.Add(Label19)
        Panel3.Location = New Point(566, 380)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(217, 193)
        Panel3.TabIndex = 22
        ' 
        ' lblTempoPreResfriamento
        ' 
        lblTempoPreResfriamento.BackColor = Color.Black
        lblTempoPreResfriamento.BorderStyle = BorderStyle.FixedSingle
        lblTempoPreResfriamento.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblTempoPreResfriamento.ForeColor = Color.Cyan
        lblTempoPreResfriamento.Location = New Point(132, 159)
        lblTempoPreResfriamento.Margin = New Padding(2, 0, 2, 0)
        lblTempoPreResfriamento.Name = "lblTempoPreResfriamento"
        lblTempoPreResfriamento.Size = New Size(81, 26)
        lblTempoPreResfriamento.TabIndex = 17
        lblTempoPreResfriamento.Text = "99m 99s"
        lblTempoPreResfriamento.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label29
        ' 
        Label29.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label29.BorderStyle = BorderStyle.FixedSingle
        Label29.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label29.Location = New Point(4, 159)
        Label29.Margin = New Padding(2, 0, 2, 0)
        Label29.Name = "Label29"
        Label29.Size = New Size(127, 26)
        Label29.TabIndex = 16
        Label29.Text = "Pré-Resfriam."
        Label29.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTempoGotejamento
        ' 
        lblTempoGotejamento.BackColor = Color.Black
        lblTempoGotejamento.BorderStyle = BorderStyle.FixedSingle
        lblTempoGotejamento.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblTempoGotejamento.ForeColor = Color.Cyan
        lblTempoGotejamento.Location = New Point(132, 132)
        lblTempoGotejamento.Margin = New Padding(2, 0, 2, 0)
        lblTempoGotejamento.Name = "lblTempoGotejamento"
        lblTempoGotejamento.Size = New Size(81, 26)
        lblTempoGotejamento.TabIndex = 15
        lblTempoGotejamento.Text = "99m 99s"
        lblTempoGotejamento.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label27
        ' 
        Label27.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label27.BorderStyle = BorderStyle.FixedSingle
        Label27.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label27.Location = New Point(4, 132)
        Label27.Margin = New Padding(2, 0, 2, 0)
        Label27.Name = "Label27"
        Label27.Size = New Size(127, 26)
        Label27.TabIndex = 14
        Label27.Text = "Gotejamento"
        Label27.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTempoAgua
        ' 
        lblTempoAgua.BackColor = Color.Black
        lblTempoAgua.BorderStyle = BorderStyle.FixedSingle
        lblTempoAgua.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblTempoAgua.ForeColor = Color.Cyan
        lblTempoAgua.Location = New Point(132, 105)
        lblTempoAgua.Margin = New Padding(2, 0, 2, 0)
        lblTempoAgua.Name = "lblTempoAgua"
        lblTempoAgua.Size = New Size(81, 26)
        lblTempoAgua.TabIndex = 13
        lblTempoAgua.Text = "99m 99s"
        lblTempoAgua.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label24
        ' 
        Label24.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label24.BorderStyle = BorderStyle.FixedSingle
        Label24.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label24.Location = New Point(4, 105)
        Label24.Margin = New Padding(2, 0, 2, 0)
        Label24.Name = "Label24"
        Label24.Size = New Size(127, 26)
        Label24.TabIndex = 12
        Label24.Text = "Água"
        Label24.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTempoGasQuente
        ' 
        lblTempoGasQuente.BackColor = Color.Black
        lblTempoGasQuente.BorderStyle = BorderStyle.FixedSingle
        lblTempoGasQuente.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblTempoGasQuente.ForeColor = Color.Cyan
        lblTempoGasQuente.Location = New Point(132, 78)
        lblTempoGasQuente.Margin = New Padding(2, 0, 2, 0)
        lblTempoGasQuente.Name = "lblTempoGasQuente"
        lblTempoGasQuente.Size = New Size(81, 26)
        lblTempoGasQuente.TabIndex = 11
        lblTempoGasQuente.Text = "99m 99s"
        lblTempoGasQuente.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label21
        ' 
        Label21.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label21.BorderStyle = BorderStyle.FixedSingle
        Label21.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label21.Location = New Point(4, 78)
        Label21.Margin = New Padding(2, 0, 2, 0)
        Label21.Name = "Label21"
        Label21.Size = New Size(127, 26)
        Label21.TabIndex = 10
        Label21.Text = "Gás Quente"
        Label21.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTempoRecolhimento
        ' 
        lblTempoRecolhimento.BackColor = Color.Black
        lblTempoRecolhimento.BorderStyle = BorderStyle.FixedSingle
        lblTempoRecolhimento.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblTempoRecolhimento.ForeColor = Color.Cyan
        lblTempoRecolhimento.Location = New Point(132, 51)
        lblTempoRecolhimento.Margin = New Padding(2, 0, 2, 0)
        lblTempoRecolhimento.Name = "lblTempoRecolhimento"
        lblTempoRecolhimento.Size = New Size(81, 26)
        lblTempoRecolhimento.TabIndex = 9
        lblTempoRecolhimento.Text = "99m 99s"
        lblTempoRecolhimento.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label16
        ' 
        Label16.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label16.BorderStyle = BorderStyle.FixedSingle
        Label16.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label16.Location = New Point(4, 51)
        Label16.Margin = New Padding(2, 0, 2, 0)
        Label16.Name = "Label16"
        Label16.Size = New Size(127, 26)
        Label16.TabIndex = 8
        Label16.Text = "Recolhimento"
        Label16.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label17
        ' 
        Label17.BackColor = Color.Teal
        Label17.BorderStyle = BorderStyle.FixedSingle
        Label17.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label17.ForeColor = SystemColors.ControlLightLight
        Label17.Location = New Point(132, 32)
        Label17.Margin = New Padding(2, 0, 2, 0)
        Label17.Name = "Label17"
        Label17.Size = New Size(81, 18)
        Label17.TabIndex = 7
        Label17.Text = "Status"
        Label17.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label18
        ' 
        Label18.BackColor = Color.Teal
        Label18.BorderStyle = BorderStyle.FixedSingle
        Label18.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label18.ForeColor = SystemColors.ControlLightLight
        Label18.Location = New Point(4, 32)
        Label18.Margin = New Padding(2, 0, 2, 0)
        Label18.Name = "Label18"
        Label18.Size = New Size(127, 18)
        Label18.TabIndex = 6
        Label18.Text = "Descrição"
        Label18.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label19
        ' 
        Label19.BackColor = Color.FromArgb(CByte(234), CByte(193), CByte(55))
        Label19.BorderStyle = BorderStyle.FixedSingle
        Label19.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label19.Location = New Point(4, 5)
        Label19.Margin = New Padding(2, 0, 2, 0)
        Label19.Name = "Label19"
        Label19.Size = New Size(209, 26)
        Label19.TabIndex = 5
        Label19.Text = "Degelo"
        Label19.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' imgRepouso
        ' 
        imgRepouso.Image = CType(resources.GetObject("imgRepouso.Image"), Image)
        imgRepouso.Location = New Point(4, 18)
        imgRepouso.Margin = New Padding(2)
        imgRepouso.Name = "imgRepouso"
        imgRepouso.Size = New Size(779, 357)
        imgRepouso.SizeMode = PictureBoxSizeMode.AutoSize
        imgRepouso.TabIndex = 19
        imgRepouso.TabStop = False
        ' 
        ' imgResfrigerando
        ' 
        imgResfrigerando.Image = CType(resources.GetObject("imgResfrigerando.Image"), Image)
        imgResfrigerando.Location = New Point(4, 18)
        imgResfrigerando.Margin = New Padding(2)
        imgResfrigerando.Name = "imgResfrigerando"
        imgResfrigerando.Size = New Size(779, 357)
        imgResfrigerando.SizeMode = PictureBoxSizeMode.AutoSize
        imgResfrigerando.TabIndex = 23
        imgResfrigerando.TabStop = False
        ' 
        ' imgGasQuente
        ' 
        imgGasQuente.Image = CType(resources.GetObject("imgGasQuente.Image"), Image)
        imgGasQuente.Location = New Point(4, 18)
        imgGasQuente.Margin = New Padding(2)
        imgGasQuente.Name = "imgGasQuente"
        imgGasQuente.Size = New Size(779, 357)
        imgGasQuente.SizeMode = PictureBoxSizeMode.AutoSize
        imgGasQuente.TabIndex = 24
        imgGasQuente.TabStop = False
        ' 
        ' imgGotejando
        ' 
        imgGotejando.Image = CType(resources.GetObject("imgGotejando.Image"), Image)
        imgGotejando.Location = New Point(4, 18)
        imgGotejando.Margin = New Padding(2)
        imgGotejando.Name = "imgGotejando"
        imgGotejando.Size = New Size(779, 357)
        imgGotejando.SizeMode = PictureBoxSizeMode.AutoSize
        imgGotejando.TabIndex = 25
        imgGotejando.TabStop = False
        ' 
        ' imgRecolhendo
        ' 
        imgRecolhendo.Image = CType(resources.GetObject("imgRecolhendo.Image"), Image)
        imgRecolhendo.Location = New Point(4, 18)
        imgRecolhendo.Margin = New Padding(2)
        imgRecolhendo.Name = "imgRecolhendo"
        imgRecolhendo.Size = New Size(779, 357)
        imgRecolhendo.SizeMode = PictureBoxSizeMode.AutoSize
        imgRecolhendo.TabIndex = 26
        imgRecolhendo.TabStop = False
        ' 
        ' imgAgua
        ' 
        imgAgua.Image = CType(resources.GetObject("imgAgua.Image"), Image)
        imgAgua.Location = New Point(4, 18)
        imgAgua.Margin = New Padding(2)
        imgAgua.Name = "imgAgua"
        imgAgua.Size = New Size(779, 357)
        imgAgua.SizeMode = PictureBoxSizeMode.AutoSize
        imgAgua.TabIndex = 27
        imgAgua.TabStop = False
        ' 
        ' imgMotor1
        ' 
        imgMotor1.Image = CType(resources.GetObject("imgMotor1.Image"), Image)
        imgMotor1.Location = New Point(77, 211)
        imgMotor1.Name = "imgMotor1"
        imgMotor1.Size = New Size(101, 83)
        imgMotor1.TabIndex = 28
        imgMotor1.TabStop = False
        ' 
        ' imgMotor2
        ' 
        imgMotor2.Image = CType(resources.GetObject("imgMotor2.Image"), Image)
        imgMotor2.Location = New Point(213, 211)
        imgMotor2.Name = "imgMotor2"
        imgMotor2.Size = New Size(101, 83)
        imgMotor2.TabIndex = 29
        imgMotor2.TabStop = False
        ' 
        ' imgMotor3
        ' 
        imgMotor3.Image = CType(resources.GetObject("imgMotor3.Image"), Image)
        imgMotor3.Location = New Point(436, 211)
        imgMotor3.Name = "imgMotor3"
        imgMotor3.Size = New Size(101, 83)
        imgMotor3.TabIndex = 30
        imgMotor3.TabStop = False
        ' 
        ' imgMotor4
        ' 
        imgMotor4.Image = CType(resources.GetObject("imgMotor4.Image"), Image)
        imgMotor4.Location = New Point(572, 211)
        imgMotor4.Name = "imgMotor4"
        imgMotor4.Size = New Size(101, 83)
        imgMotor4.TabIndex = 31
        imgMotor4.TabStop = False
        ' 
        ' imgMAEvap
        ' 
        imgMAEvap.Image = CType(resources.GetObject("imgMAEvap.Image"), Image)
        imgMAEvap.Location = New Point(11, 65)
        imgMAEvap.Name = "imgMAEvap"
        imgMAEvap.Size = New Size(46, 46)
        imgMAEvap.SizeMode = PictureBoxSizeMode.AutoSize
        imgMAEvap.TabIndex = 33
        imgMAEvap.TabStop = False
        ' 
        ' Label36
        ' 
        Label36.BackColor = Color.FromArgb(CByte(234), CByte(193), CByte(55))
        Label36.BorderStyle = BorderStyle.FixedSingle
        Label36.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label36.Location = New Point(3, 4)
        Label36.Margin = New Padding(2, 0, 2, 0)
        Label36.Name = "Label36"
        Label36.Size = New Size(528, 26)
        Label36.TabIndex = 34
        Label36.Text = "Painel de Operação"
        Label36.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label37
        ' 
        Label37.BackColor = Color.Teal
        Label37.BorderStyle = BorderStyle.FixedSingle
        Label37.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label37.ForeColor = SystemColors.ControlLightLight
        Label37.Location = New Point(3, 32)
        Label37.Margin = New Padding(2, 0, 2, 0)
        Label37.Name = "Label37"
        Label37.Size = New Size(103, 18)
        Label37.TabIndex = 35
        Label37.Text = "Evaporadores"
        Label37.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label38
        ' 
        Label38.BackColor = Color.Navy
        Label38.BorderStyle = BorderStyle.FixedSingle
        Label38.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label38.ForeColor = SystemColors.ControlLightLight
        Label38.Location = New Point(11, 51)
        Label38.Margin = New Padding(2, 0, 2, 0)
        Label38.Name = "Label38"
        Label38.Size = New Size(47, 14)
        Label38.TabIndex = 36
        Label38.Text = "Auto"
        Label38.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label39
        ' 
        Label39.BackColor = Color.Navy
        Label39.BorderStyle = BorderStyle.FixedSingle
        Label39.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label39.ForeColor = SystemColors.ControlLightLight
        Label39.Location = New Point(58, 81)
        Label39.Margin = New Padding(2, 0, 2, 0)
        Label39.Name = "Label39"
        Label39.Size = New Size(42, 14)
        Label39.TabIndex = 37
        Label39.Text = "Manual"
        Label39.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' imgLDEvap
        ' 
        imgLDEvap.Image = CType(resources.GetObject("imgLDEvap.Image"), Image)
        imgLDEvap.Location = New Point(12, 135)
        imgLDEvap.Name = "imgLDEvap"
        imgLDEvap.Size = New Size(46, 46)
        imgLDEvap.SizeMode = PictureBoxSizeMode.AutoSize
        imgLDEvap.TabIndex = 38
        imgLDEvap.TabStop = False
        ' 
        ' Label41
        ' 
        Label41.BackColor = Color.Navy
        Label41.BorderStyle = BorderStyle.FixedSingle
        Label41.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label41.ForeColor = SystemColors.ControlLightLight
        Label41.Location = New Point(12, 121)
        Label41.Margin = New Padding(2, 0, 2, 0)
        Label41.Name = "Label41"
        Label41.Size = New Size(47, 14)
        Label41.TabIndex = 39
        Label41.Text = "Liga"
        Label41.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label40
        ' 
        Label40.BackColor = Color.Navy
        Label40.BorderStyle = BorderStyle.FixedSingle
        Label40.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label40.ForeColor = SystemColors.ControlLightLight
        Label40.Location = New Point(59, 151)
        Label40.Margin = New Padding(2, 0, 2, 0)
        Label40.Name = "Label40"
        Label40.Size = New Size(42, 14)
        Label40.TabIndex = 40
        Label40.Text = "Desliga"
        Label40.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' imgMAVSSC
        ' 
        imgMAVSSC.Image = CType(resources.GetObject("imgMAVSSC.Image"), Image)
        imgMAVSSC.Location = New Point(116, 65)
        imgMAVSSC.Name = "imgMAVSSC"
        imgMAVSSC.Size = New Size(46, 46)
        imgMAVSSC.SizeMode = PictureBoxSizeMode.AutoSize
        imgMAVSSC.TabIndex = 41
        imgMAVSSC.TabStop = False
        ' 
        ' Label47
        ' 
        Label47.BackColor = Color.Teal
        Label47.BorderStyle = BorderStyle.FixedSingle
        Label47.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label47.ForeColor = SystemColors.ControlLightLight
        Label47.Location = New Point(108, 32)
        Label47.Margin = New Padding(2, 0, 2, 0)
        Label47.Name = "Label47"
        Label47.Size = New Size(103, 18)
        Label47.TabIndex = 42
        Label47.Text = "VS Sucção"
        Label47.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label46
        ' 
        Label46.BackColor = Color.Navy
        Label46.BorderStyle = BorderStyle.FixedSingle
        Label46.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label46.ForeColor = SystemColors.ControlLightLight
        Label46.Location = New Point(116, 51)
        Label46.Margin = New Padding(2, 0, 2, 0)
        Label46.Name = "Label46"
        Label46.Size = New Size(47, 14)
        Label46.TabIndex = 43
        Label46.Text = "Auto"
        Label46.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label45
        ' 
        Label45.BackColor = Color.Navy
        Label45.BorderStyle = BorderStyle.FixedSingle
        Label45.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label45.ForeColor = SystemColors.ControlLightLight
        Label45.Location = New Point(163, 81)
        Label45.Margin = New Padding(2, 0, 2, 0)
        Label45.Name = "Label45"
        Label45.Size = New Size(42, 14)
        Label45.TabIndex = 44
        Label45.Text = "Manual"
        Label45.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' imgLDVSSC
        ' 
        imgLDVSSC.Image = CType(resources.GetObject("imgLDVSSC.Image"), Image)
        imgLDVSSC.Location = New Point(117, 135)
        imgLDVSSC.Name = "imgLDVSSC"
        imgLDVSSC.Size = New Size(46, 46)
        imgLDVSSC.SizeMode = PictureBoxSizeMode.AutoSize
        imgLDVSSC.TabIndex = 45
        imgLDVSSC.TabStop = False
        ' 
        ' Label44
        ' 
        Label44.BackColor = Color.Navy
        Label44.BorderStyle = BorderStyle.FixedSingle
        Label44.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label44.ForeColor = SystemColors.ControlLightLight
        Label44.Location = New Point(117, 121)
        Label44.Margin = New Padding(2, 0, 2, 0)
        Label44.Name = "Label44"
        Label44.Size = New Size(47, 14)
        Label44.TabIndex = 46
        Label44.Text = "Liga"
        Label44.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label42
        ' 
        Label42.BackColor = Color.Navy
        Label42.BorderStyle = BorderStyle.FixedSingle
        Label42.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label42.ForeColor = SystemColors.ControlLightLight
        Label42.Location = New Point(164, 151)
        Label42.Margin = New Padding(2, 0, 2, 0)
        Label42.Name = "Label42"
        Label42.Size = New Size(42, 14)
        Label42.TabIndex = 47
        Label42.Text = "Desliga"
        Label42.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' imgMAVSLL
        ' 
        imgMAVSLL.Image = CType(resources.GetObject("imgMAVSLL.Image"), Image)
        imgMAVSLL.Location = New Point(221, 65)
        imgMAVSLL.Name = "imgMAVSLL"
        imgMAVSLL.Size = New Size(46, 46)
        imgMAVSLL.SizeMode = PictureBoxSizeMode.AutoSize
        imgMAVSLL.TabIndex = 48
        imgMAVSLL.TabStop = False
        ' 
        ' Label53
        ' 
        Label53.BackColor = Color.Teal
        Label53.BorderStyle = BorderStyle.FixedSingle
        Label53.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label53.ForeColor = SystemColors.ControlLightLight
        Label53.Location = New Point(213, 32)
        Label53.Margin = New Padding(2, 0, 2, 0)
        Label53.Name = "Label53"
        Label53.Size = New Size(103, 18)
        Label53.TabIndex = 49
        Label53.Text = "VS Liquido"
        Label53.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label52
        ' 
        Label52.BackColor = Color.Navy
        Label52.BorderStyle = BorderStyle.FixedSingle
        Label52.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label52.ForeColor = SystemColors.ControlLightLight
        Label52.Location = New Point(221, 51)
        Label52.Margin = New Padding(2, 0, 2, 0)
        Label52.Name = "Label52"
        Label52.Size = New Size(47, 14)
        Label52.TabIndex = 50
        Label52.Text = "Auto"
        Label52.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label51
        ' 
        Label51.BackColor = Color.Navy
        Label51.BorderStyle = BorderStyle.FixedSingle
        Label51.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label51.ForeColor = SystemColors.ControlLightLight
        Label51.Location = New Point(268, 81)
        Label51.Margin = New Padding(2, 0, 2, 0)
        Label51.Name = "Label51"
        Label51.Size = New Size(42, 14)
        Label51.TabIndex = 51
        Label51.Text = "Manual"
        Label51.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' imgLDVSLL
        ' 
        imgLDVSLL.Image = CType(resources.GetObject("imgLDVSLL.Image"), Image)
        imgLDVSLL.Location = New Point(222, 135)
        imgLDVSLL.Name = "imgLDVSLL"
        imgLDVSLL.Size = New Size(46, 46)
        imgLDVSLL.SizeMode = PictureBoxSizeMode.AutoSize
        imgLDVSLL.TabIndex = 52
        imgLDVSLL.TabStop = False
        ' 
        ' Label49
        ' 
        Label49.BackColor = Color.Navy
        Label49.BorderStyle = BorderStyle.FixedSingle
        Label49.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label49.ForeColor = SystemColors.ControlLightLight
        Label49.Location = New Point(222, 121)
        Label49.Margin = New Padding(2, 0, 2, 0)
        Label49.Name = "Label49"
        Label49.Size = New Size(47, 14)
        Label49.TabIndex = 53
        Label49.Text = "Liga"
        Label49.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label48
        ' 
        Label48.BackColor = Color.Navy
        Label48.BorderStyle = BorderStyle.FixedSingle
        Label48.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label48.ForeColor = SystemColors.ControlLightLight
        Label48.Location = New Point(269, 151)
        Label48.Margin = New Padding(2, 0, 2, 0)
        Label48.Name = "Label48"
        Label48.Size = New Size(42, 14)
        Label48.TabIndex = 54
        Label48.Text = "Desliga"
        Label48.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' imgMAVSGQ
        ' 
        imgMAVSGQ.Image = CType(resources.GetObject("imgMAVSGQ.Image"), Image)
        imgMAVSGQ.Location = New Point(326, 65)
        imgMAVSGQ.Name = "imgMAVSGQ"
        imgMAVSGQ.Size = New Size(46, 46)
        imgMAVSGQ.SizeMode = PictureBoxSizeMode.AutoSize
        imgMAVSGQ.TabIndex = 55
        imgMAVSGQ.TabStop = False
        ' 
        ' Label59
        ' 
        Label59.BackColor = Color.Teal
        Label59.BorderStyle = BorderStyle.FixedSingle
        Label59.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label59.ForeColor = SystemColors.ControlLightLight
        Label59.Location = New Point(318, 32)
        Label59.Margin = New Padding(2, 0, 2, 0)
        Label59.Name = "Label59"
        Label59.Size = New Size(103, 18)
        Label59.TabIndex = 56
        Label59.Text = "VS Gás Quente"
        Label59.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label58
        ' 
        Label58.BackColor = Color.Navy
        Label58.BorderStyle = BorderStyle.FixedSingle
        Label58.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label58.ForeColor = SystemColors.ControlLightLight
        Label58.Location = New Point(326, 51)
        Label58.Margin = New Padding(2, 0, 2, 0)
        Label58.Name = "Label58"
        Label58.Size = New Size(47, 14)
        Label58.TabIndex = 57
        Label58.Text = "Auto"
        Label58.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label57
        ' 
        Label57.BackColor = Color.Navy
        Label57.BorderStyle = BorderStyle.FixedSingle
        Label57.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label57.ForeColor = SystemColors.ControlLightLight
        Label57.Location = New Point(373, 81)
        Label57.Margin = New Padding(2, 0, 2, 0)
        Label57.Name = "Label57"
        Label57.Size = New Size(42, 14)
        Label57.TabIndex = 58
        Label57.Text = "Manual"
        Label57.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' imgLDVSGQ
        ' 
        imgLDVSGQ.Image = CType(resources.GetObject("imgLDVSGQ.Image"), Image)
        imgLDVSGQ.Location = New Point(327, 135)
        imgLDVSGQ.Name = "imgLDVSGQ"
        imgLDVSGQ.Size = New Size(46, 46)
        imgLDVSGQ.SizeMode = PictureBoxSizeMode.AutoSize
        imgLDVSGQ.TabIndex = 59
        imgLDVSGQ.TabStop = False
        ' 
        ' Label56
        ' 
        Label56.BackColor = Color.Navy
        Label56.BorderStyle = BorderStyle.FixedSingle
        Label56.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label56.ForeColor = SystemColors.ControlLightLight
        Label56.Location = New Point(327, 121)
        Label56.Margin = New Padding(2, 0, 2, 0)
        Label56.Name = "Label56"
        Label56.Size = New Size(47, 14)
        Label56.TabIndex = 60
        Label56.Text = "Liga"
        Label56.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label54
        ' 
        Label54.BackColor = Color.Navy
        Label54.BorderStyle = BorderStyle.FixedSingle
        Label54.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label54.ForeColor = SystemColors.ControlLightLight
        Label54.Location = New Point(374, 151)
        Label54.Margin = New Padding(2, 0, 2, 0)
        Label54.Name = "Label54"
        Label54.Size = New Size(42, 14)
        Label54.TabIndex = 61
        Label54.Text = "Desliga"
        Label54.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.LemonChiffon
        Panel4.Controls.Add(Label60)
        Panel4.Controls.Add(Label61)
        Panel4.Controls.Add(imgLDVSAG)
        Panel4.Controls.Add(Label62)
        Panel4.Controls.Add(Label63)
        Panel4.Controls.Add(Label64)
        Panel4.Controls.Add(imgMAVSAG)
        Panel4.Controls.Add(Label54)
        Panel4.Controls.Add(Label56)
        Panel4.Controls.Add(imgLDVSGQ)
        Panel4.Controls.Add(Label57)
        Panel4.Controls.Add(Label58)
        Panel4.Controls.Add(Label59)
        Panel4.Controls.Add(imgMAVSGQ)
        Panel4.Controls.Add(Label48)
        Panel4.Controls.Add(Label49)
        Panel4.Controls.Add(imgLDVSLL)
        Panel4.Controls.Add(Label51)
        Panel4.Controls.Add(Label52)
        Panel4.Controls.Add(Label53)
        Panel4.Controls.Add(imgMAVSLL)
        Panel4.Controls.Add(Label42)
        Panel4.Controls.Add(Label44)
        Panel4.Controls.Add(imgLDVSSC)
        Panel4.Controls.Add(Label45)
        Panel4.Controls.Add(Label46)
        Panel4.Controls.Add(Label47)
        Panel4.Controls.Add(imgMAVSSC)
        Panel4.Controls.Add(Label40)
        Panel4.Controls.Add(Label41)
        Panel4.Controls.Add(imgLDEvap)
        Panel4.Controls.Add(Label39)
        Panel4.Controls.Add(Label38)
        Panel4.Controls.Add(Label37)
        Panel4.Controls.Add(Label36)
        Panel4.Controls.Add(imgMAEvap)
        Panel4.Location = New Point(5, 380)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(535, 193)
        Panel4.TabIndex = 33
        ' 
        ' Label60
        ' 
        Label60.BackColor = Color.Navy
        Label60.BorderStyle = BorderStyle.FixedSingle
        Label60.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label60.ForeColor = SystemColors.ControlLightLight
        Label60.Location = New Point(479, 151)
        Label60.Margin = New Padding(2, 0, 2, 0)
        Label60.Name = "Label60"
        Label60.Size = New Size(47, 14)
        Label60.TabIndex = 75
        Label60.Text = "Desliga"
        Label60.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label61
        ' 
        Label61.BackColor = Color.Navy
        Label61.BorderStyle = BorderStyle.FixedSingle
        Label61.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label61.ForeColor = SystemColors.ControlLightLight
        Label61.Location = New Point(432, 121)
        Label61.Margin = New Padding(2, 0, 2, 0)
        Label61.Name = "Label61"
        Label61.Size = New Size(47, 14)
        Label61.TabIndex = 74
        Label61.Text = "Liga"
        Label61.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' imgLDVSAG
        ' 
        imgLDVSAG.Image = CType(resources.GetObject("imgLDVSAG.Image"), Image)
        imgLDVSAG.Location = New Point(432, 135)
        imgLDVSAG.Name = "imgLDVSAG"
        imgLDVSAG.Size = New Size(46, 46)
        imgLDVSAG.SizeMode = PictureBoxSizeMode.AutoSize
        imgLDVSAG.TabIndex = 73
        imgLDVSAG.TabStop = False
        ' 
        ' Label62
        ' 
        Label62.BackColor = Color.Navy
        Label62.BorderStyle = BorderStyle.FixedSingle
        Label62.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label62.ForeColor = SystemColors.ControlLightLight
        Label62.Location = New Point(478, 81)
        Label62.Margin = New Padding(2, 0, 2, 0)
        Label62.Name = "Label62"
        Label62.Size = New Size(47, 14)
        Label62.TabIndex = 72
        Label62.Text = "Manual"
        Label62.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label63
        ' 
        Label63.BackColor = Color.Navy
        Label63.BorderStyle = BorderStyle.FixedSingle
        Label63.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label63.ForeColor = SystemColors.ControlLightLight
        Label63.Location = New Point(431, 51)
        Label63.Margin = New Padding(2, 0, 2, 0)
        Label63.Name = "Label63"
        Label63.Size = New Size(47, 14)
        Label63.TabIndex = 71
        Label63.Text = "Auto"
        Label63.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label64
        ' 
        Label64.BackColor = Color.Teal
        Label64.BorderStyle = BorderStyle.FixedSingle
        Label64.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label64.ForeColor = SystemColors.ControlLightLight
        Label64.Location = New Point(423, 32)
        Label64.Margin = New Padding(2, 0, 2, 0)
        Label64.Name = "Label64"
        Label64.Size = New Size(108, 18)
        Label64.TabIndex = 70
        Label64.Text = "VS Água"
        Label64.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' imgMAVSAG
        ' 
        imgMAVSAG.Image = CType(resources.GetObject("imgMAVSAG.Image"), Image)
        imgMAVSAG.Location = New Point(431, 65)
        imgMAVSAG.Name = "imgMAVSAG"
        imgMAVSAG.Size = New Size(46, 46)
        imgMAVSAG.SizeMode = PictureBoxSizeMode.AutoSize
        imgMAVSAG.TabIndex = 69
        imgMAVSAG.TabStop = False
        ' 
        ' imgBotao90
        ' 
        imgBotao90.Image = CType(resources.GetObject("imgBotao90.Image"), Image)
        imgBotao90.Location = New Point(1028, 527)
        imgBotao90.Name = "imgBotao90"
        imgBotao90.Size = New Size(46, 46)
        imgBotao90.SizeMode = PictureBoxSizeMode.AutoSize
        imgBotao90.TabIndex = 34
        imgBotao90.TabStop = False
        imgBotao90.Visible = False
        ' 
        ' imgBotao0
        ' 
        imgBotao0.Image = CType(resources.GetObject("imgBotao0.Image"), Image)
        imgBotao0.Location = New Point(1028, 485)
        imgBotao0.Name = "imgBotao0"
        imgBotao0.Size = New Size(46, 46)
        imgBotao0.SizeMode = PictureBoxSizeMode.AutoSize
        imgBotao0.TabIndex = 35
        imgBotao0.TabStop = False
        imgBotao0.Visible = False
        ' 
        ' Label65
        ' 
        Label65.BackColor = Color.Navy
        Label65.BorderStyle = BorderStyle.FixedSingle
        Label65.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label65.ForeColor = SystemColors.ControlLightLight
        Label65.Location = New Point(742, 71)
        Label65.Margin = New Padding(2, 0, 2, 0)
        Label65.Name = "Label65"
        Label65.Size = New Size(39, 14)
        Label65.TabIndex = 41
        Label65.Text = "Desab."
        Label65.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label67
        ' 
        Label67.BackColor = Color.Navy
        Label67.BorderStyle = BorderStyle.FixedSingle
        Label67.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label67.ForeColor = SystemColors.ControlLightLight
        Label67.Location = New Point(695, 41)
        Label67.Margin = New Padding(2, 0, 2, 0)
        Label67.Name = "Label67"
        Label67.Size = New Size(47, 14)
        Label67.TabIndex = 40
        Label67.Text = "Habilita"
        Label67.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label68
        ' 
        Label68.BackColor = Color.Teal
        Label68.BorderStyle = BorderStyle.FixedSingle
        Label68.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label68.ForeColor = SystemColors.ControlLightLight
        Label68.Location = New Point(695, 22)
        Label68.Margin = New Padding(2, 0, 2, 0)
        Label68.Name = "Label68"
        Label68.Size = New Size(86, 18)
        Label68.TabIndex = 39
        Label68.Text = "Ambiente"
        Label68.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' imgHabAmbiente
        ' 
        imgHabAmbiente.Image = CType(resources.GetObject("imgHabAmbiente.Image"), Image)
        imgHabAmbiente.Location = New Point(695, 55)
        imgHabAmbiente.Name = "imgHabAmbiente"
        imgHabAmbiente.Size = New Size(46, 46)
        imgHabAmbiente.SizeMode = PictureBoxSizeMode.AutoSize
        imgHabAmbiente.TabIndex = 38
        imgHabAmbiente.TabStop = False
        ' 
        ' imgForcaDegelo
        ' 
        imgForcaDegelo.Image = CType(resources.GetObject("imgForcaDegelo.Image"), Image)
        imgForcaDegelo.Location = New Point(630, 55)
        imgForcaDegelo.Name = "imgForcaDegelo"
        imgForcaDegelo.Size = New Size(46, 46)
        imgForcaDegelo.SizeMode = PictureBoxSizeMode.AutoSize
        imgForcaDegelo.TabIndex = 42
        imgForcaDegelo.TabStop = False
        ' 
        ' Label69
        ' 
        Label69.BackColor = Color.Teal
        Label69.BorderStyle = BorderStyle.FixedSingle
        Label69.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label69.ForeColor = SystemColors.ControlLightLight
        Label69.Location = New Point(611, 22)
        Label69.Margin = New Padding(2, 0, 2, 0)
        Label69.Name = "Label69"
        Label69.Size = New Size(82, 18)
        Label69.TabIndex = 43
        Label69.Text = "Força Degelo"
        Label69.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label70
        ' 
        Label70.BackColor = Color.Navy
        Label70.BorderStyle = BorderStyle.FixedSingle
        Label70.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label70.ForeColor = SystemColors.ControlLightLight
        Label70.Location = New Point(742, 153)
        Label70.Margin = New Padding(2, 0, 2, 0)
        Label70.Name = "Label70"
        Label70.Size = New Size(39, 14)
        Label70.TabIndex = 47
        Label70.Text = "Manual"
        Label70.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label71
        ' 
        Label71.BackColor = Color.Navy
        Label71.BorderStyle = BorderStyle.FixedSingle
        Label71.Font = New Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label71.ForeColor = SystemColors.ControlLightLight
        Label71.Location = New Point(695, 123)
        Label71.Margin = New Padding(2, 0, 2, 0)
        Label71.Name = "Label71"
        Label71.Size = New Size(47, 14)
        Label71.TabIndex = 46
        Label71.Text = "Auto"
        Label71.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label72
        ' 
        Label72.BackColor = Color.Teal
        Label72.BorderStyle = BorderStyle.FixedSingle
        Label72.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label72.ForeColor = SystemColors.ControlLightLight
        Label72.Location = New Point(695, 104)
        Label72.Margin = New Padding(2, 0, 2, 0)
        Label72.Name = "Label72"
        Label72.Size = New Size(86, 18)
        Label72.TabIndex = 45
        Label72.Text = "Degelo"
        Label72.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' imgMADegelo
        ' 
        imgMADegelo.Image = CType(resources.GetObject("imgMADegelo.Image"), Image)
        imgMADegelo.Location = New Point(695, 137)
        imgMADegelo.Name = "imgMADegelo"
        imgMADegelo.Size = New Size(46, 46)
        imgMADegelo.SizeMode = PictureBoxSizeMode.AutoSize
        imgMADegelo.TabIndex = 44
        imgMADegelo.TabStop = False
        ' 
        ' FrmAmbientes
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.Gray
        ClientSize = New Size(1349, 618)
        Controls.Add(Label70)
        Controls.Add(Label71)
        Controls.Add(Label72)
        Controls.Add(imgMADegelo)
        Controls.Add(Label69)
        Controls.Add(imgForcaDegelo)
        Controls.Add(Label65)
        Controls.Add(Label67)
        Controls.Add(Label68)
        Controls.Add(imgHabAmbiente)
        Controls.Add(imgBotao0)
        Controls.Add(imgBotao90)
        Controls.Add(Panel4)
        Controls.Add(imgMotor4)
        Controls.Add(imgMotor3)
        Controls.Add(imgMotor2)
        Controls.Add(imgMotor1)
        Controls.Add(imgAgua)
        Controls.Add(imgRecolhendo)
        Controls.Add(imgGotejando)
        Controls.Add(imgGasQuente)
        Controls.Add(imgResfrigerando)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(imgRepouso)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(2)
        Name = "FrmAmbientes"
        ShowIcon = False
        Text = "Tunel XX"
        WindowState = FormWindowState.Maximized
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        CType(imgRepouso, ComponentModel.ISupportInitialize).EndInit()
        CType(imgResfrigerando, ComponentModel.ISupportInitialize).EndInit()
        CType(imgGasQuente, ComponentModel.ISupportInitialize).EndInit()
        CType(imgGotejando, ComponentModel.ISupportInitialize).EndInit()
        CType(imgRecolhendo, ComponentModel.ISupportInitialize).EndInit()
        CType(imgAgua, ComponentModel.ISupportInitialize).EndInit()
        CType(imgMotor1, ComponentModel.ISupportInitialize).EndInit()
        CType(imgMotor2, ComponentModel.ISupportInitialize).EndInit()
        CType(imgMotor3, ComponentModel.ISupportInitialize).EndInit()
        CType(imgMotor4, ComponentModel.ISupportInitialize).EndInit()
        CType(imgMAEvap, ComponentModel.ISupportInitialize).EndInit()
        CType(imgLDEvap, ComponentModel.ISupportInitialize).EndInit()
        CType(imgMAVSSC, ComponentModel.ISupportInitialize).EndInit()
        CType(imgLDVSSC, ComponentModel.ISupportInitialize).EndInit()
        CType(imgMAVSLL, ComponentModel.ISupportInitialize).EndInit()
        CType(imgLDVSLL, ComponentModel.ISupportInitialize).EndInit()
        CType(imgMAVSGQ, ComponentModel.ISupportInitialize).EndInit()
        CType(imgLDVSGQ, ComponentModel.ISupportInitialize).EndInit()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        CType(imgLDVSAG, ComponentModel.ISupportInitialize).EndInit()
        CType(imgMAVSAG, ComponentModel.ISupportInitialize).EndInit()
        CType(imgBotao90, ComponentModel.ISupportInitialize).EndInit()
        CType(imgBotao0, ComponentModel.ISupportInitialize).EndInit()
        CType(imgHabAmbiente, ComponentModel.ISupportInitialize).EndInit()
        CType(imgForcaDegelo, ComponentModel.ISupportInitialize).EndInit()
        CType(imgMADegelo, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblStatusAmbiente As Label
    Friend WithEvents lblHabAmbiente As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents lblLDDegelo As Label
    Friend WithEvents lblLDVSAG As Label
    Friend WithEvents lblLDVSGQ As Label
    Friend WithEvents lblLDVSLL As Label
    Friend WithEvents lblLDVSSC As Label
    Friend WithEvents lblMADegelo As Label
    Friend WithEvents lblMAVSAG As Label
    Friend WithEvents lblMAVSGQ As Label
    Friend WithEvents lblMAVSLL As Label
    Friend WithEvents lblMAVSSC As Label
    Friend WithEvents Label55 As Label
    Friend WithEvents lblAgua As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents lblSuccao As Label
    Friend WithEvents lblLDEvaporador As Label
    Friend WithEvents lblMAEvaporador As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents edtOffset As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents edtSetPoint As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents lblTemp As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblNomeAmbiente As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CheckBoxDegelo1 As CheckBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents edtHoraDegelo1 As TextBox
    Friend WithEvents edtMinutoDegelo1 As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents edtHoraDegelo3 As TextBox
    Friend WithEvents edtMinutoDegelo3 As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents CheckBoxDegelo3 As CheckBox
    Friend WithEvents edtHoraDegelo2 As TextBox
    Friend WithEvents edtMinutoDegelo2 As TextBox
    Friend WithEvents CheckBoxDegelo2 As CheckBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblTempoRecolhimento As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents lblTempoGotejamento As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents lblTempoAgua As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents lblTempoGasQuente As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents lblTempoPreResfriamento As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents imgRepouso As PictureBox
    Friend WithEvents imgResfrigerando As PictureBox
    Friend WithEvents imgGasQuente As PictureBox
    Friend WithEvents imgGotejando As PictureBox
    Friend WithEvents imgRecolhendo As PictureBox
    Friend WithEvents imgAgua As PictureBox
    Friend WithEvents edtSPTempoRecolhimento As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents edtSPTempoPreResfriamento As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents edtSPTempoGotejamento As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents edtSPTempoAgua As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents edtSPTempoGasQuente As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents imgMotor1 As PictureBox
    Friend WithEvents imgMotor2 As PictureBox
    Friend WithEvents imgMotor3 As PictureBox
    Friend WithEvents imgMotor4 As PictureBox
    Friend WithEvents imgMAEvap As PictureBox
    Friend WithEvents Label36 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents imgLDEvap As PictureBox
    Friend WithEvents Label41 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents imgMAVSSC As PictureBox
    Friend WithEvents Label47 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents imgLDVSSC As PictureBox
    Friend WithEvents Label44 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents imgMAVSLL As PictureBox
    Friend WithEvents Label53 As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents imgLDVSLL As PictureBox
    Friend WithEvents Label49 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents imgMAVSGQ As PictureBox
    Friend WithEvents Label59 As Label
    Friend WithEvents Label58 As Label
    Friend WithEvents Label57 As Label
    Friend WithEvents imgLDVSGQ As PictureBox
    Friend WithEvents Label56 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label60 As Label
    Friend WithEvents Label61 As Label
    Friend WithEvents imgLDVSAG As PictureBox
    Friend WithEvents Label62 As Label
    Friend WithEvents Label63 As Label
    Friend WithEvents Label64 As Label
    Friend WithEvents imgMAVSAG As PictureBox
    Friend WithEvents imgBotao90 As PictureBox
    Friend WithEvents imgBotao0 As PictureBox
    Friend WithEvents Label65 As Label
    Friend WithEvents Label67 As Label
    Friend WithEvents Label68 As Label
    Friend WithEvents imgHabAmbiente As PictureBox
    Friend WithEvents imgForcaDegelo As PictureBox
    Friend WithEvents Label69 As Label
    Friend WithEvents Label70 As Label
    Friend WithEvents Label71 As Label
    Friend WithEvents Label72 As Label
    Friend WithEvents imgMADegelo As PictureBox
End Class
