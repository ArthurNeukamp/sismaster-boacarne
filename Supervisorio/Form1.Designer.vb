<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Label1 = New Label()
        MenuPrincipal = New MenuStrip()
        ArquivoToolStripMenuItem = New ToolStripMenuItem()
        RelatóriosToolStripMenuItem = New ToolStripMenuItem()
        ConfiguraçõesToolStripMenuItem = New ToolStripMenuItem()
        AjudaToolStripMenuItem = New ToolStripMenuItem()
        BarraFerramentasPrincipal = New ToolStrip()
        ToolStripButton1 = New ToolStripButton()
        btnMenuSADEMA = New ToolStripButton()
        ToolStripSplitButton1 = New ToolStripSplitButton()
        Compressor1ToolStripMenuItem = New ToolStripMenuItem()
        Compressor2ToolStripMenuItem = New ToolStripMenuItem()
        Compressor3ToolStripMenuItem = New ToolStripMenuItem()
        BtnAlaNova = New ToolStripButton()
        ToolStripSeparator4 = New ToolStripSeparator()
        btnTuneis47 = New ToolStripButton()
        ToolStripSeparator1 = New ToolStripSeparator()
        btnCamaras = New ToolStripButton()
        ToolStripSeparator2 = New ToolStripSeparator()
        btnMiudos = New ToolStripButton()
        ToolStripSeparator3 = New ToolStripSeparator()
        ToolStripButton2 = New ToolStripButton()
        ToolStripSeparator5 = New ToolStripSeparator()
        btnRelatorios = New ToolStripButton()
        ToolStripSeparator6 = New ToolStripSeparator()
        btnImportarQualidade = New ToolStripButton()
        lblResult = New Label()
        TimerCLP = New Timer(components)
        StatusStrip1 = New StatusStrip()
        ToolStripStatusLabel1 = New ToolStripStatusLabel()
        BarraStatusLabel2 = New ToolStripStatusLabel()
        BarraStatusLabel3 = New ToolStripStatusLabel()
        BarraStatusLabel4 = New ToolStripStatusLabel()
        BarraStatusLabel5 = New ToolStripStatusLabel()
        BarraStatusLabel6 = New ToolStripStatusLabel()
        BarraStatusM251 = New ToolStripStatusLabel()
        TimerCompressor1 = New Timer(components)
        TimerCompressor2 = New Timer(components)
        TimerCompressor3 = New Timer(components)
        PainelSadema = New Panel()
        lblDadosCP3 = New Label()
        Label18 = New Label()
        lblDadosCP2 = New Label()
        Label16 = New Label()
        lblDadosCP1 = New Label()
        Label173 = New Label()
        lblDescargaCP3 = New Label()
        Label11 = New Label()
        lblSuccaoCP3 = New Label()
        Label14 = New Label()
        lblDescargaCP2 = New Label()
        Label10 = New Label()
        lblSuccaoCP2 = New Label()
        Label12 = New Label()
        lblDescargaCP1 = New Label()
        Label9 = New Label()
        lblSuccaoCP1 = New Label()
        Label8 = New Label()
        imgLedInjecaoSeparadorON = New PictureBox()
        imgLedInjecaoSeparadorOFF = New PictureBox()
        lblTeste2 = New Label()
        Label7 = New Label()
        lblTeste3 = New Label()
        Label3 = New Label()
        lblTeste1 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        lblNomeAmbiente = New Label()
        Timer_CLP2 = New Timer(components)
        Timer_M251 = New Timer(components)
        MenuPrincipal.SuspendLayout()
        BarraFerramentasPrincipal.SuspendLayout()
        StatusStrip1.SuspendLayout()
        PainelSadema.SuspendLayout()
        CType(imgLedInjecaoSeparadorON, ComponentModel.ISupportInitialize).BeginInit()
        CType(imgLedInjecaoSeparadorOFF, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(1147, 126)
        Label1.Name = "Label1"
        Label1.Size = New Size(0, 15)
        Label1.TabIndex = 0
        ' 
        ' MenuPrincipal
        ' 
        MenuPrincipal.BackColor = Color.Silver
        MenuPrincipal.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point)
        MenuPrincipal.ImageScalingSize = New Size(20, 20)
        MenuPrincipal.Items.AddRange(New ToolStripItem() {ArquivoToolStripMenuItem, RelatóriosToolStripMenuItem, ConfiguraçõesToolStripMenuItem, AjudaToolStripMenuItem})
        MenuPrincipal.Location = New Point(0, 0)
        MenuPrincipal.Name = "MenuPrincipal"
        MenuPrincipal.Padding = New Padding(5, 1, 0, 1)
        MenuPrincipal.Size = New Size(1283, 24)
        MenuPrincipal.TabIndex = 1
        MenuPrincipal.Text = "MenuPrincipal"
        ' 
        ' ArquivoToolStripMenuItem
        ' 
        ArquivoToolStripMenuItem.Name = "ArquivoToolStripMenuItem"
        ArquivoToolStripMenuItem.Size = New Size(61, 22)
        ArquivoToolStripMenuItem.Text = "Arquivo"
        ' 
        ' RelatóriosToolStripMenuItem
        ' 
        RelatóriosToolStripMenuItem.Name = "RelatóriosToolStripMenuItem"
        RelatóriosToolStripMenuItem.Size = New Size(71, 22)
        RelatóriosToolStripMenuItem.Text = "Relatórios"
        ' 
        ' ConfiguraçõesToolStripMenuItem
        ' 
        ConfiguraçõesToolStripMenuItem.Name = "ConfiguraçõesToolStripMenuItem"
        ConfiguraçõesToolStripMenuItem.Size = New Size(95, 22)
        ConfiguraçõesToolStripMenuItem.Text = "Configurações"
        ' 
        ' AjudaToolStripMenuItem
        ' 
        AjudaToolStripMenuItem.Name = "AjudaToolStripMenuItem"
        AjudaToolStripMenuItem.Size = New Size(50, 22)
        AjudaToolStripMenuItem.Text = "Ajuda"
        ' 
        ' BarraFerramentasPrincipal
        ' 
        BarraFerramentasPrincipal.BackColor = Color.White
        BarraFerramentasPrincipal.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        BarraFerramentasPrincipal.GripMargin = New Padding(10, 2, 2, 2)
        BarraFerramentasPrincipal.ImageScalingSize = New Size(70, 70)
        BarraFerramentasPrincipal.Items.AddRange(New ToolStripItem() {ToolStripButton1, btnMenuSADEMA, ToolStripSplitButton1, BtnAlaNova, ToolStripSeparator4, btnTuneis47, ToolStripSeparator1, btnCamaras, ToolStripSeparator2, btnMiudos, ToolStripSeparator3, ToolStripButton2, ToolStripSeparator5, btnRelatorios, ToolStripSeparator6, btnImportarQualidade})
        BarraFerramentasPrincipal.Location = New Point(0, 24)
        BarraFerramentasPrincipal.Name = "BarraFerramentasPrincipal"
        BarraFerramentasPrincipal.Padding = New Padding(0, 0, 2, 0)
        BarraFerramentasPrincipal.Size = New Size(1283, 92)
        BarraFerramentasPrincipal.TabIndex = 2
        BarraFerramentasPrincipal.Text = "Barra Atalhos"
        ' 
        ' ToolStripButton1
        ' 
        ToolStripButton1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), Image)
        ToolStripButton1.ImageTransparentColor = Color.Magenta
        ToolStripButton1.Name = "ToolStripButton1"
        ToolStripButton1.Size = New Size(79, 89)
        ToolStripButton1.Text = "Reset Falhas"
        ToolStripButton1.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' btnMenuSADEMA
        ' 
        btnMenuSADEMA.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        btnMenuSADEMA.Image = CType(resources.GetObject("btnMenuSADEMA.Image"), Image)
        btnMenuSADEMA.ImageScaling = ToolStripItemImageScaling.None
        btnMenuSADEMA.ImageTransparentColor = Color.Magenta
        btnMenuSADEMA.Margin = New Padding(3, 1, 3, 2)
        btnMenuSADEMA.Name = "btnMenuSADEMA"
        btnMenuSADEMA.Size = New Size(74, 89)
        btnMenuSADEMA.Text = "Sadema"
        btnMenuSADEMA.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' ToolStripSplitButton1
        ' 
        ToolStripSplitButton1.DropDownItems.AddRange(New ToolStripItem() {Compressor1ToolStripMenuItem, Compressor2ToolStripMenuItem, Compressor3ToolStripMenuItem})
        ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), Image)
        ToolStripSplitButton1.ImageScaling = ToolStripItemImageScaling.None
        ToolStripSplitButton1.ImageTransparentColor = Color.Magenta
        ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        ToolStripSplitButton1.Size = New Size(96, 89)
        ToolStripSplitButton1.Text = "Compressores"
        ToolStripSplitButton1.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' Compressor1ToolStripMenuItem
        ' 
        Compressor1ToolStripMenuItem.Name = "Compressor1ToolStripMenuItem"
        Compressor1ToolStripMenuItem.Size = New Size(145, 22)
        Compressor1ToolStripMenuItem.Text = "Compressor 1"
        ' 
        ' Compressor2ToolStripMenuItem
        ' 
        Compressor2ToolStripMenuItem.Name = "Compressor2ToolStripMenuItem"
        Compressor2ToolStripMenuItem.Size = New Size(145, 22)
        Compressor2ToolStripMenuItem.Text = "Compressor 2"
        ' 
        ' Compressor3ToolStripMenuItem
        ' 
        Compressor3ToolStripMenuItem.Name = "Compressor3ToolStripMenuItem"
        Compressor3ToolStripMenuItem.Size = New Size(145, 22)
        Compressor3ToolStripMenuItem.Text = "Compressor 3"
        ' 
        ' BtnAlaNova
        ' 
        BtnAlaNova.Image = CType(resources.GetObject("BtnAlaNova.Image"), Image)
        BtnAlaNova.ImageScaling = ToolStripItemImageScaling.None
        BtnAlaNova.ImageTransparentColor = Color.Magenta
        BtnAlaNova.Name = "BtnAlaNova"
        BtnAlaNova.Size = New Size(75, 89)
        BtnAlaNova.Text = "Túneis 8 - 12"
        BtnAlaNova.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' ToolStripSeparator4
        ' 
        ToolStripSeparator4.Name = "ToolStripSeparator4"
        ToolStripSeparator4.Size = New Size(6, 92)
        ' 
        ' btnTuneis47
        ' 
        btnTuneis47.Image = CType(resources.GetObject("btnTuneis47.Image"), Image)
        btnTuneis47.ImageScaling = ToolStripItemImageScaling.None
        btnTuneis47.ImageTransparentColor = Color.Magenta
        btnTuneis47.Name = "btnTuneis47"
        btnTuneis47.Size = New Size(74, 89)
        btnTuneis47.Text = "Túneis 4 - 7"
        btnTuneis47.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(6, 92)
        ' 
        ' btnCamaras
        ' 
        btnCamaras.Image = CType(resources.GetObject("btnCamaras.Image"), Image)
        btnCamaras.ImageScaling = ToolStripItemImageScaling.None
        btnCamaras.ImageTransparentColor = Color.Magenta
        btnCamaras.Name = "btnCamaras"
        btnCamaras.Size = New Size(97, 89)
        btnCamaras.Text = "Câmaras Carcaça"
        btnCamaras.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(6, 92)
        ' 
        ' btnMiudos
        ' 
        btnMiudos.Image = CType(resources.GetObject("btnMiudos.Image"), Image)
        btnMiudos.ImageScaling = ToolStripItemImageScaling.None
        btnMiudos.ImageTransparentColor = Color.Magenta
        btnMiudos.Name = "btnMiudos"
        btnMiudos.Size = New Size(87, 89)
        btnMiudos.Text = "Túneis Miúdos"
        btnMiudos.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New Size(6, 92)
        ' 
        ' ToolStripButton2
        ' 
        ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), Image)
        ToolStripButton2.ImageScaling = ToolStripItemImageScaling.None
        ToolStripButton2.ImageTransparentColor = Color.Magenta
        ToolStripButton2.Name = "ToolStripButton2"
        ToolStripButton2.Size = New Size(77, 89)
        ToolStripButton2.Text = "Climatizados"
        ToolStripButton2.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' ToolStripSeparator5
        ' 
        ToolStripSeparator5.Name = "ToolStripSeparator5"
        ToolStripSeparator5.Size = New Size(6, 92)
        ' 
        ' btnRelatorios
        ' 
        btnRelatorios.Image = My.Resources.Resources.relatorio_icon
        btnRelatorios.ImageTransparentColor = Color.White
        btnRelatorios.Name = "btnRelatorios"
        btnRelatorios.Size = New Size(74, 89)
        btnRelatorios.Text = "Relatórios"
        btnRelatorios.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' ToolStripSeparator6
        ' 
        ToolStripSeparator6.Name = "ToolStripSeparator6"
        ToolStripSeparator6.Size = New Size(6, 92)
        ' 
        ' btnImportarQualidade
        ' 
        btnImportarQualidade.Image = My.Resources.Resources.importar_icon
        btnImportarQualidade.ImageTransparentColor = Color.White
        btnImportarQualidade.Name = "btnImportarQualidade"
        btnImportarQualidade.Size = New Size(74, 89)
        btnImportarQualidade.Text = "Importar Planilha"
        btnImportarQualidade.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' lblResult
        ' 
        lblResult.AutoSize = True
        lblResult.Location = New Point(25, 707)
        lblResult.Name = "lblResult"
        lblResult.Size = New Size(41, 15)
        lblResult.TabIndex = 3
        lblResult.Text = "Label2"
        ' 
        ' TimerCLP
        ' 
        TimerCLP.Interval = 500
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.ImageScalingSize = New Size(20, 20)
        StatusStrip1.Items.AddRange(New ToolStripItem() {BarraStatusLabel2, ToolStripStatusLabel1, BarraStatusLabel3, BarraStatusLabel4, BarraStatusLabel5, BarraStatusLabel6, BarraStatusM251})
        StatusStrip1.Location = New Point(0, 685)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Padding = New Padding(1, 0, 12, 0)
        StatusStrip1.Size = New Size(1283, 22)
        StatusStrip1.TabIndex = 5
        StatusStrip1.Text = "CLP: "
        ' 
        ' ToolStripStatusLabel1
        ' 
        ToolStripStatusLabel1.Margin = New Padding(0, 3, 10, 2)
        ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        ToolStripStatusLabel1.Size = New Size(31, 17)
        ToolStripStatusLabel1.Text = "CLP:"
        ' 
        ' BarraStatusLabel2
        ' 
        BarraStatusLabel2.Margin = New Padding(0, 3, 10, 2)
        BarraStatusLabel2.Name = "BarraStatusLabel2"
        BarraStatusLabel2.Size = New Size(68, 17)
        BarraStatusLabel2.Text = "Contadores"
        ' 
        ' BarraStatusLabel3
        ' 
        BarraStatusLabel3.Margin = New Padding(10, 3, 0, 2)
        BarraStatusLabel3.Name = "BarraStatusLabel3"
        BarraStatusLabel3.Size = New Size(80, 17)
        BarraStatusLabel3.Text = "Compressor 1"
        ' 
        ' BarraStatusLabel4
        ' 
        BarraStatusLabel4.Margin = New Padding(10, 3, 0, 2)
        BarraStatusLabel4.Name = "BarraStatusLabel4"
        BarraStatusLabel4.Size = New Size(80, 17)
        BarraStatusLabel4.Text = "Compressor 2"
        ' 
        ' BarraStatusLabel5
        ' 
        BarraStatusLabel5.Margin = New Padding(10, 3, 0, 2)
        BarraStatusLabel5.Name = "BarraStatusLabel5"
        BarraStatusLabel5.Size = New Size(80, 17)
        BarraStatusLabel5.Text = "Compressor 3"
        ' 
        ' BarraStatusLabel6
        ' 
        BarraStatusLabel6.Margin = New Padding(10, 3, 0, 2)
        BarraStatusLabel6.Name = "BarraStatusLabel6"
        BarraStatusLabel6.Size = New Size(37, 17)
        BarraStatusLabel6.Text = "CLP 2"
        ' 
        ' BarraStatusM251
        ' 
        BarraStatusM251.Margin = New Padding(10, 3, 0, 2)
        BarraStatusM251.Name = "BarraStatusM251"
        BarraStatusM251.Size = New Size(42, 17)
        BarraStatusM251.Text = "M251: "
        ' 
        ' TimerCompressor1
        ' 
        TimerCompressor1.Interval = 500
        ' 
        ' TimerCompressor2
        ' 
        TimerCompressor2.Interval = 500
        ' 
        ' TimerCompressor3
        ' 
        TimerCompressor3.Interval = 500
        ' 
        ' PainelSadema
        ' 
        PainelSadema.Controls.Add(lblDadosCP3)
        PainelSadema.Controls.Add(Label18)
        PainelSadema.Controls.Add(lblDadosCP2)
        PainelSadema.Controls.Add(Label16)
        PainelSadema.Controls.Add(lblDadosCP1)
        PainelSadema.Controls.Add(Label173)
        PainelSadema.Controls.Add(lblDescargaCP3)
        PainelSadema.Controls.Add(Label11)
        PainelSadema.Controls.Add(lblSuccaoCP3)
        PainelSadema.Controls.Add(Label14)
        PainelSadema.Controls.Add(lblDescargaCP2)
        PainelSadema.Controls.Add(Label10)
        PainelSadema.Controls.Add(lblSuccaoCP2)
        PainelSadema.Controls.Add(Label12)
        PainelSadema.Controls.Add(lblDescargaCP1)
        PainelSadema.Controls.Add(Label9)
        PainelSadema.Controls.Add(lblSuccaoCP1)
        PainelSadema.Controls.Add(Label8)
        PainelSadema.Controls.Add(imgLedInjecaoSeparadorON)
        PainelSadema.Controls.Add(imgLedInjecaoSeparadorOFF)
        PainelSadema.Controls.Add(lblTeste2)
        PainelSadema.Controls.Add(Label7)
        PainelSadema.Controls.Add(lblTeste3)
        PainelSadema.Controls.Add(Label3)
        PainelSadema.Controls.Add(lblTeste1)
        PainelSadema.Controls.Add(Label6)
        PainelSadema.Controls.Add(Label5)
        PainelSadema.Controls.Add(Label4)
        PainelSadema.Controls.Add(lblNomeAmbiente)
        PainelSadema.Location = New Point(1059, 144)
        PainelSadema.Name = "PainelSadema"
        PainelSadema.Size = New Size(243, 533)
        PainelSadema.TabIndex = 17
        ' 
        ' lblDadosCP3
        ' 
        lblDadosCP3.BackColor = Color.Black
        lblDadosCP3.BorderStyle = BorderStyle.FixedSingle
        lblDadosCP3.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblDadosCP3.ForeColor = Color.Lime
        lblDadosCP3.Location = New Point(134, 275)
        lblDadosCP3.Margin = New Padding(2, 0, 2, 0)
        lblDadosCP3.Name = "lblDadosCP3"
        lblDadosCP3.Size = New Size(106, 17)
        lblDadosCP3.TabIndex = 61
        lblDadosCP3.Text = "999 A - 9999 RPM"
        lblDadosCP3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label18
        ' 
        Label18.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label18.BorderStyle = BorderStyle.FixedSingle
        Label18.Font = New Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point)
        Label18.Location = New Point(3, 275)
        Label18.Margin = New Padding(2, 0, 2, 0)
        Label18.Name = "Label18"
        Label18.Size = New Size(129, 17)
        Label18.TabIndex = 60
        Label18.Text = "Compressor 3"
        Label18.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblDadosCP2
        ' 
        lblDadosCP2.BackColor = Color.Black
        lblDadosCP2.BorderStyle = BorderStyle.FixedSingle
        lblDadosCP2.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblDadosCP2.ForeColor = Color.Lime
        lblDadosCP2.Location = New Point(134, 203)
        lblDadosCP2.Margin = New Padding(2, 0, 2, 0)
        lblDadosCP2.Name = "lblDadosCP2"
        lblDadosCP2.Size = New Size(106, 17)
        lblDadosCP2.TabIndex = 59
        lblDadosCP2.Text = "999 A - 9999 RPM"
        lblDadosCP2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label16
        ' 
        Label16.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label16.BorderStyle = BorderStyle.FixedSingle
        Label16.Font = New Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point)
        Label16.Location = New Point(3, 203)
        Label16.Margin = New Padding(2, 0, 2, 0)
        Label16.Name = "Label16"
        Label16.Size = New Size(129, 17)
        Label16.TabIndex = 58
        Label16.Text = "Compressor 2"
        Label16.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblDadosCP1
        ' 
        lblDadosCP1.BackColor = Color.Black
        lblDadosCP1.BorderStyle = BorderStyle.FixedSingle
        lblDadosCP1.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point)
        lblDadosCP1.ForeColor = Color.Lime
        lblDadosCP1.Location = New Point(134, 131)
        lblDadosCP1.Margin = New Padding(2, 0, 2, 0)
        lblDadosCP1.Name = "lblDadosCP1"
        lblDadosCP1.Size = New Size(106, 17)
        lblDadosCP1.TabIndex = 57
        lblDadosCP1.Text = "999 A - 9999 RPM"
        lblDadosCP1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label173
        ' 
        Label173.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label173.BorderStyle = BorderStyle.FixedSingle
        Label173.Font = New Font("Segoe UI", 7F, FontStyle.Bold, GraphicsUnit.Point)
        Label173.Location = New Point(3, 131)
        Label173.Margin = New Padding(2, 0, 2, 0)
        Label173.Name = "Label173"
        Label173.Size = New Size(129, 17)
        Label173.TabIndex = 56
        Label173.Text = "Compressor 1"
        Label173.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblDescargaCP3
        ' 
        lblDescargaCP3.BackColor = Color.Black
        lblDescargaCP3.BorderStyle = BorderStyle.FixedSingle
        lblDescargaCP3.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblDescargaCP3.ForeColor = Color.Cyan
        lblDescargaCP3.Location = New Point(134, 320)
        lblDescargaCP3.Margin = New Padding(2, 0, 2, 0)
        lblDescargaCP3.Name = "lblDescargaCP3"
        lblDescargaCP3.Size = New Size(106, 26)
        lblDescargaCP3.TabIndex = 32
        lblDescargaCP3.Text = "99999"
        lblDescargaCP3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label11
        ' 
        Label11.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label11.BorderStyle = BorderStyle.FixedSingle
        Label11.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label11.Location = New Point(3, 320)
        Label11.Margin = New Padding(2, 0, 2, 0)
        Label11.Name = "Label11"
        Label11.Size = New Size(129, 26)
        Label11.TabIndex = 31
        Label11.Text = "Descarga CP3"
        Label11.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblSuccaoCP3
        ' 
        lblSuccaoCP3.BackColor = Color.Black
        lblSuccaoCP3.BorderStyle = BorderStyle.FixedSingle
        lblSuccaoCP3.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblSuccaoCP3.ForeColor = Color.Cyan
        lblSuccaoCP3.Location = New Point(134, 293)
        lblSuccaoCP3.Margin = New Padding(2, 0, 2, 0)
        lblSuccaoCP3.Name = "lblSuccaoCP3"
        lblSuccaoCP3.Size = New Size(106, 26)
        lblSuccaoCP3.TabIndex = 30
        lblSuccaoCP3.Text = "99999"
        lblSuccaoCP3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label14
        ' 
        Label14.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label14.BorderStyle = BorderStyle.FixedSingle
        Label14.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label14.Location = New Point(3, 293)
        Label14.Margin = New Padding(2, 0, 2, 0)
        Label14.Name = "Label14"
        Label14.Size = New Size(129, 26)
        Label14.TabIndex = 29
        Label14.Text = "Sucção CP3"
        Label14.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblDescargaCP2
        ' 
        lblDescargaCP2.BackColor = Color.Black
        lblDescargaCP2.BorderStyle = BorderStyle.FixedSingle
        lblDescargaCP2.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblDescargaCP2.ForeColor = Color.Cyan
        lblDescargaCP2.Location = New Point(134, 248)
        lblDescargaCP2.Margin = New Padding(2, 0, 2, 0)
        lblDescargaCP2.Name = "lblDescargaCP2"
        lblDescargaCP2.Size = New Size(106, 26)
        lblDescargaCP2.TabIndex = 28
        lblDescargaCP2.Text = "99999"
        lblDescargaCP2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label10
        ' 
        Label10.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label10.BorderStyle = BorderStyle.FixedSingle
        Label10.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label10.Location = New Point(3, 248)
        Label10.Margin = New Padding(2, 0, 2, 0)
        Label10.Name = "Label10"
        Label10.Size = New Size(129, 26)
        Label10.TabIndex = 27
        Label10.Text = "Descarga CP2"
        Label10.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblSuccaoCP2
        ' 
        lblSuccaoCP2.BackColor = Color.Black
        lblSuccaoCP2.BorderStyle = BorderStyle.FixedSingle
        lblSuccaoCP2.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblSuccaoCP2.ForeColor = Color.Cyan
        lblSuccaoCP2.Location = New Point(134, 221)
        lblSuccaoCP2.Margin = New Padding(2, 0, 2, 0)
        lblSuccaoCP2.Name = "lblSuccaoCP2"
        lblSuccaoCP2.Size = New Size(106, 26)
        lblSuccaoCP2.TabIndex = 26
        lblSuccaoCP2.Text = "99999"
        lblSuccaoCP2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label12
        ' 
        Label12.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label12.BorderStyle = BorderStyle.FixedSingle
        Label12.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label12.Location = New Point(3, 221)
        Label12.Margin = New Padding(2, 0, 2, 0)
        Label12.Name = "Label12"
        Label12.Size = New Size(129, 26)
        Label12.TabIndex = 25
        Label12.Text = "Sucção CP2"
        Label12.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblDescargaCP1
        ' 
        lblDescargaCP1.BackColor = Color.Black
        lblDescargaCP1.BorderStyle = BorderStyle.FixedSingle
        lblDescargaCP1.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblDescargaCP1.ForeColor = Color.Cyan
        lblDescargaCP1.Location = New Point(134, 176)
        lblDescargaCP1.Margin = New Padding(2, 0, 2, 0)
        lblDescargaCP1.Name = "lblDescargaCP1"
        lblDescargaCP1.Size = New Size(106, 26)
        lblDescargaCP1.TabIndex = 24
        lblDescargaCP1.Text = "99999"
        lblDescargaCP1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label9
        ' 
        Label9.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label9.BorderStyle = BorderStyle.FixedSingle
        Label9.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label9.Location = New Point(3, 176)
        Label9.Margin = New Padding(2, 0, 2, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(129, 26)
        Label9.TabIndex = 23
        Label9.Text = "Descarga CP1"
        Label9.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblSuccaoCP1
        ' 
        lblSuccaoCP1.BackColor = Color.Black
        lblSuccaoCP1.BorderStyle = BorderStyle.FixedSingle
        lblSuccaoCP1.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblSuccaoCP1.ForeColor = Color.Cyan
        lblSuccaoCP1.Location = New Point(134, 149)
        lblSuccaoCP1.Margin = New Padding(2, 0, 2, 0)
        lblSuccaoCP1.Name = "lblSuccaoCP1"
        lblSuccaoCP1.Size = New Size(106, 26)
        lblSuccaoCP1.TabIndex = 22
        lblSuccaoCP1.Text = "99999"
        lblSuccaoCP1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label8
        ' 
        Label8.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label8.BorderStyle = BorderStyle.FixedSingle
        Label8.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label8.Location = New Point(3, 149)
        Label8.Margin = New Padding(2, 0, 2, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(129, 26)
        Label8.TabIndex = 21
        Label8.Text = "Sucção CP1"
        Label8.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' imgLedInjecaoSeparadorON
        ' 
        imgLedInjecaoSeparadorON.ErrorImage = Nothing
        imgLedInjecaoSeparadorON.Image = CType(resources.GetObject("imgLedInjecaoSeparadorON.Image"), Image)
        imgLedInjecaoSeparadorON.Location = New Point(137, 108)
        imgLedInjecaoSeparadorON.Name = "imgLedInjecaoSeparadorON"
        imgLedInjecaoSeparadorON.Size = New Size(18, 18)
        imgLedInjecaoSeparadorON.SizeMode = PictureBoxSizeMode.AutoSize
        imgLedInjecaoSeparadorON.TabIndex = 20
        imgLedInjecaoSeparadorON.TabStop = False
        imgLedInjecaoSeparadorON.Visible = False
        ' 
        ' imgLedInjecaoSeparadorOFF
        ' 
        imgLedInjecaoSeparadorOFF.Image = My.Resources.Resources.ledCinza
        imgLedInjecaoSeparadorOFF.Location = New Point(137, 108)
        imgLedInjecaoSeparadorOFF.Name = "imgLedInjecaoSeparadorOFF"
        imgLedInjecaoSeparadorOFF.Size = New Size(18, 18)
        imgLedInjecaoSeparadorOFF.SizeMode = PictureBoxSizeMode.AutoSize
        imgLedInjecaoSeparadorOFF.TabIndex = 19
        imgLedInjecaoSeparadorOFF.TabStop = False
        imgLedInjecaoSeparadorOFF.Visible = False
        ' 
        ' lblTeste2
        ' 
        lblTeste2.BackColor = Color.Black
        lblTeste2.BorderStyle = BorderStyle.FixedSingle
        lblTeste2.Font = New Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point)
        lblTeste2.ForeColor = Color.Cyan
        lblTeste2.Location = New Point(134, 104)
        lblTeste2.Margin = New Padding(2, 0, 2, 0)
        lblTeste2.Name = "lblTeste2"
        lblTeste2.Size = New Size(106, 26)
        lblTeste2.TabIndex = 18
        lblTeste2.Text = "99999"
        lblTeste2.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Label7
        ' 
        Label7.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label7.BorderStyle = BorderStyle.FixedSingle
        Label7.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label7.Location = New Point(3, 104)
        Label7.Margin = New Padding(2, 0, 2, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(129, 26)
        Label7.TabIndex = 17
        Label7.Text = "Abertura ICAD"
        Label7.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTeste3
        ' 
        lblTeste3.BackColor = Color.Black
        lblTeste3.BorderStyle = BorderStyle.FixedSingle
        lblTeste3.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblTeste3.ForeColor = Color.Cyan
        lblTeste3.Location = New Point(134, 77)
        lblTeste3.Margin = New Padding(2, 0, 2, 0)
        lblTeste3.Name = "lblTeste3"
        lblTeste3.Size = New Size(106, 26)
        lblTeste3.TabIndex = 16
        lblTeste3.Text = "99999"
        lblTeste3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label3
        ' 
        Label3.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label3.BorderStyle = BorderStyle.FixedSingle
        Label3.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(3, 77)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(129, 26)
        Label3.TabIndex = 15
        Label3.Text = "Pressão Bomba NH3"
        Label3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTeste1
        ' 
        lblTeste1.BackColor = Color.Black
        lblTeste1.BorderStyle = BorderStyle.FixedSingle
        lblTeste1.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblTeste1.ForeColor = Color.Cyan
        lblTeste1.Location = New Point(134, 50)
        lblTeste1.Margin = New Padding(2, 0, 2, 0)
        lblTeste1.Name = "lblTeste1"
        lblTeste1.Size = New Size(106, 26)
        lblTeste1.TabIndex = 14
        lblTeste1.Text = "99999"
        lblTeste1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label6
        ' 
        Label6.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label6.BorderStyle = BorderStyle.FixedSingle
        Label6.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.Location = New Point(3, 50)
        Label6.Margin = New Padding(2, 0, 2, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(129, 26)
        Label6.TabIndex = 7
        Label6.Text = "Nível Separador"
        Label6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label5
        ' 
        Label5.BackColor = Color.Teal
        Label5.BorderStyle = BorderStyle.FixedSingle
        Label5.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label5.ForeColor = SystemColors.ControlLightLight
        Label5.Location = New Point(134, 31)
        Label5.Margin = New Padding(2, 0, 2, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(106, 18)
        Label5.TabIndex = 6
        Label5.Text = "Status"
        Label5.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label4
        ' 
        Label4.BackColor = Color.Teal
        Label4.BorderStyle = BorderStyle.FixedSingle
        Label4.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.ForeColor = SystemColors.ControlLightLight
        Label4.Location = New Point(3, 31)
        Label4.Margin = New Padding(2, 0, 2, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(129, 18)
        Label4.TabIndex = 5
        Label4.Text = "Descrição"
        Label4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblNomeAmbiente
        ' 
        lblNomeAmbiente.BackColor = Color.FromArgb(CByte(234), CByte(193), CByte(55))
        lblNomeAmbiente.BorderStyle = BorderStyle.FixedSingle
        lblNomeAmbiente.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblNomeAmbiente.Location = New Point(3, 4)
        lblNomeAmbiente.Margin = New Padding(2, 0, 2, 0)
        lblNomeAmbiente.Name = "lblNomeAmbiente"
        lblNomeAmbiente.Size = New Size(237, 26)
        lblNomeAmbiente.TabIndex = 4
        lblNomeAmbiente.Text = "Sala de Máquinas"
        lblNomeAmbiente.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Timer_CLP2
        ' 
        Timer_CLP2.Interval = 500
        ' 
        ' Timer_M251
        ' 
        Timer_M251.Interval = 500
        ' 
        ' MainForm
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        AutoSize = True
        BackColor = Color.LightGray
        ClientSize = New Size(1283, 707)
        Controls.Add(PainelSadema)
        Controls.Add(StatusStrip1)
        Controls.Add(lblResult)
        Controls.Add(BarraFerramentasPrincipal)
        Controls.Add(Label1)
        Controls.Add(MenuPrincipal)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        IsMdiContainer = True
        MainMenuStrip = MenuPrincipal
        Name = "MainForm"
        Text = "SisMaster - Sistema de Supervisão Remoto"
        WindowState = FormWindowState.Maximized
        MenuPrincipal.ResumeLayout(False)
        MenuPrincipal.PerformLayout()
        BarraFerramentasPrincipal.ResumeLayout(False)
        BarraFerramentasPrincipal.PerformLayout()
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        PainelSadema.ResumeLayout(False)
        PainelSadema.PerformLayout()
        CType(imgLedInjecaoSeparadorON, ComponentModel.ISupportInitialize).EndInit()
        CType(imgLedInjecaoSeparadorOFF, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents MenuPrincipal As MenuStrip
    Friend WithEvents ArquivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConfiguraçõesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AjudaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents lblResult As Label
    Friend WithEvents TimerCLP As Timer
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents RelatóriosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnMenuSADEMA As ToolStripButton
    Private WithEvents BarraFerramentasPrincipal As ToolStrip
    Friend WithEvents BtnAlaNova As ToolStripButton
    Friend WithEvents ToolStripSplitButton1 As ToolStripSplitButton
    Friend WithEvents Compressor1ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Compressor2ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Compressor3ToolStripMenuItem As ToolStripMenuItem
    Public WithEvents BarraStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents TimerCompressor1 As Timer
    Friend WithEvents TimerCompressor2 As Timer
    Friend WithEvents TimerCompressor3 As Timer
    Public WithEvents BarraStatusLabel3 As ToolStripStatusLabel
    Public WithEvents BarraStatusLabel4 As ToolStripStatusLabel
    Public WithEvents BarraStatusLabel5 As ToolStripStatusLabel
    Friend WithEvents PainelSadema As Panel
    Friend WithEvents lblTeste2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblTeste3 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTeste1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblNomeAmbiente As Label
    Friend WithEvents imgLedInjecaoSeparadorON As PictureBox
    Friend WithEvents imgLedInjecaoSeparadorOFF As PictureBox
    Friend WithEvents lblDescargaCP1 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblSuccaoCP1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblDescargaCP3 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lblSuccaoCP3 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lblDescargaCP2 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblSuccaoCP2 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblDadosCP1 As Label
    Friend WithEvents Label173 As Label
    Friend WithEvents lblDadosCP3 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lblDadosCP2 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Timer_CLP2 As Timer
    Friend WithEvents btnTuneis47 As ToolStripButton
    Friend WithEvents btnCamaras As ToolStripButton
    Friend WithEvents Timer_M251 As Timer
    Public WithEvents BarraStatusM251 As ToolStripStatusLabel
    Public WithEvents BarraStatusLabel6 As ToolStripStatusLabel
    Friend WithEvents btnMiudos As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btnRelatorios As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents btnImportarQualidade As ToolStripButton
End Class
