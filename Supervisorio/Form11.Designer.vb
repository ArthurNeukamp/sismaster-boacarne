<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClimatizacao
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClimatizacao))
        Panel5 = New Panel()
        edtOffSetTunel1 = New TextBox()
        Label39 = New Label()
        lblTempEmbSec = New Label()
        Label26 = New Label()
        Label27 = New Label()
        Label28 = New Label()
        lblAtalhoTunel1 = New Label()
        Panel1 = New Panel()
        TextBox1 = New TextBox()
        Label1 = New Label()
        lblTempDesossa = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Panel2 = New Panel()
        TextBox2 = New TextBox()
        Label7 = New Label()
        lblTempOsso = New Label()
        Label9 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        Label12 = New Label()
        Panel3 = New Panel()
        TextBox3 = New TextBox()
        Label13 = New Label()
        lblTempPaletizacao = New Label()
        Label15 = New Label()
        Label16 = New Label()
        Label17 = New Label()
        Label18 = New Label()
        Panel4 = New Panel()
        TextBox4 = New TextBox()
        Label19 = New Label()
        lblTempExpCaixaria = New Label()
        Label21 = New Label()
        Label22 = New Label()
        Label23 = New Label()
        Label24 = New Label()
        Timer1 = New Timer(components)
        Panel6 = New Panel()
        TextBox5 = New TextBox()
        Label2 = New Label()
        lblTempEmbMiudos = New Label()
        Label14 = New Label()
        Label20 = New Label()
        Label25 = New Label()
        Label29 = New Label()
        Panel7 = New Panel()
        TextBox6 = New TextBox()
        Label30 = New Label()
        lblTempBuchariaLimpa = New Label()
        Label32 = New Label()
        Label33 = New Label()
        Label34 = New Label()
        Label35 = New Label()
        Panel8 = New Panel()
        TextBox7 = New TextBox()
        Label36 = New Label()
        lblTempBuchariaSuja = New Label()
        Label38 = New Label()
        Label40 = New Label()
        Label41 = New Label()
        Label42 = New Label()
        Panel9 = New Panel()
        TextBox8 = New TextBox()
        Label43 = New Label()
        lblTempSalaMiudos = New Label()
        Label45 = New Label()
        Label46 = New Label()
        Label47 = New Label()
        Label48 = New Label()
        Panel10 = New Panel()
        TextBox9 = New TextBox()
        Label49 = New Label()
        lblTempCamaraMiudos = New Label()
        Label51 = New Label()
        Label52 = New Label()
        Label53 = New Label()
        Label54 = New Label()
        Panel11 = New Panel()
        TextBox10 = New TextBox()
        Label55 = New Label()
        lblTempCamaraEstomago = New Label()
        Label57 = New Label()
        Label58 = New Label()
        Label59 = New Label()
        Label60 = New Label()
        Panel5.SuspendLayout()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        Panel6.SuspendLayout()
        Panel7.SuspendLayout()
        Panel8.SuspendLayout()
        Panel9.SuspendLayout()
        Panel10.SuspendLayout()
        Panel11.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.Silver
        Panel5.BorderStyle = BorderStyle.FixedSingle
        Panel5.Controls.Add(edtOffSetTunel1)
        Panel5.Controls.Add(Label39)
        Panel5.Controls.Add(lblTempEmbSec)
        Panel5.Controls.Add(Label26)
        Panel5.Controls.Add(Label27)
        Panel5.Controls.Add(Label28)
        Panel5.Controls.Add(lblAtalhoTunel1)
        Panel5.Location = New Point(29, 38)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(346, 172)
        Panel5.TabIndex = 24
        ' 
        ' edtOffSetTunel1
        ' 
        edtOffSetTunel1.BorderStyle = BorderStyle.None
        edtOffSetTunel1.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        edtOffSetTunel1.Location = New Point(193, 124)
        edtOffSetTunel1.Name = "edtOffSetTunel1"
        edtOffSetTunel1.Size = New Size(146, 32)
        edtOffSetTunel1.TabIndex = 8
        edtOffSetTunel1.Text = "00,0 °C"
        edtOffSetTunel1.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label39
        ' 
        Label39.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label39.BorderStyle = BorderStyle.FixedSingle
        Label39.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label39.Location = New Point(3, 122)
        Label39.Name = "Label39"
        Label39.Size = New Size(183, 42)
        Label39.TabIndex = 7
        Label39.Text = "OffSet"
        Label39.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTempEmbSec
        ' 
        lblTempEmbSec.BackColor = Color.Black
        lblTempEmbSec.BorderStyle = BorderStyle.FixedSingle
        lblTempEmbSec.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblTempEmbSec.ForeColor = Color.Cyan
        lblTempEmbSec.Location = New Point(190, 78)
        lblTempEmbSec.Name = "lblTempEmbSec"
        lblTempEmbSec.Size = New Size(151, 42)
        lblTempEmbSec.TabIndex = 4
        lblTempEmbSec.Text = "00,0 °C"
        lblTempEmbSec.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label26
        ' 
        Label26.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label26.BorderStyle = BorderStyle.FixedSingle
        Label26.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label26.Location = New Point(3, 78)
        Label26.Name = "Label26"
        Label26.Size = New Size(183, 42)
        Label26.TabIndex = 3
        Label26.Text = "Temperatura"
        Label26.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label27
        ' 
        Label27.BackColor = Color.Teal
        Label27.BorderStyle = BorderStyle.FixedSingle
        Label27.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label27.ForeColor = SystemColors.ControlLightLight
        Label27.Location = New Point(190, 48)
        Label27.Name = "Label27"
        Label27.Size = New Size(151, 29)
        Label27.TabIndex = 2
        Label27.Text = "Status"
        Label27.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label28
        ' 
        Label28.BackColor = Color.Teal
        Label28.BorderStyle = BorderStyle.FixedSingle
        Label28.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label28.ForeColor = SystemColors.ControlLightLight
        Label28.Location = New Point(3, 48)
        Label28.Name = "Label28"
        Label28.Size = New Size(183, 29)
        Label28.TabIndex = 1
        Label28.Text = "Descrição"
        Label28.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblAtalhoTunel1
        ' 
        lblAtalhoTunel1.BackColor = Color.FromArgb(CByte(255), CByte(224), CByte(192))
        lblAtalhoTunel1.BorderStyle = BorderStyle.FixedSingle
        lblAtalhoTunel1.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblAtalhoTunel1.Location = New Point(3, 5)
        lblAtalhoTunel1.Name = "lblAtalhoTunel1"
        lblAtalhoTunel1.Size = New Size(338, 42)
        lblAtalhoTunel1.TabIndex = 0
        lblAtalhoTunel1.Text = "Embalagem Secundária"
        lblAtalhoTunel1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Silver
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(TextBox1)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(lblTempDesossa)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label6)
        Panel1.Location = New Point(381, 38)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(346, 172)
        Panel1.TabIndex = 25
        ' 
        ' TextBox1
        ' 
        TextBox1.BorderStyle = BorderStyle.None
        TextBox1.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox1.Location = New Point(193, 124)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(146, 32)
        TextBox1.TabIndex = 8
        TextBox1.Text = "00,0 °C"
        TextBox1.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label1
        ' 
        Label1.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label1.BorderStyle = BorderStyle.FixedSingle
        Label1.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(3, 122)
        Label1.Name = "Label1"
        Label1.Size = New Size(183, 42)
        Label1.TabIndex = 7
        Label1.Text = "OffSet"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTempDesossa
        ' 
        lblTempDesossa.BackColor = Color.Black
        lblTempDesossa.BorderStyle = BorderStyle.FixedSingle
        lblTempDesossa.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblTempDesossa.ForeColor = Color.Cyan
        lblTempDesossa.Location = New Point(190, 78)
        lblTempDesossa.Name = "lblTempDesossa"
        lblTempDesossa.Size = New Size(151, 42)
        lblTempDesossa.TabIndex = 4
        lblTempDesossa.Text = "00,0 °C"
        lblTempDesossa.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label3
        ' 
        Label3.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label3.BorderStyle = BorderStyle.FixedSingle
        Label3.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(3, 78)
        Label3.Name = "Label3"
        Label3.Size = New Size(183, 42)
        Label3.TabIndex = 3
        Label3.Text = "Temperatura"
        Label3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label4
        ' 
        Label4.BackColor = Color.Teal
        Label4.BorderStyle = BorderStyle.FixedSingle
        Label4.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.ForeColor = SystemColors.ControlLightLight
        Label4.Location = New Point(190, 48)
        Label4.Name = "Label4"
        Label4.Size = New Size(151, 29)
        Label4.TabIndex = 2
        Label4.Text = "Status"
        Label4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label5
        ' 
        Label5.BackColor = Color.Teal
        Label5.BorderStyle = BorderStyle.FixedSingle
        Label5.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label5.ForeColor = SystemColors.ControlLightLight
        Label5.Location = New Point(3, 48)
        Label5.Name = "Label5"
        Label5.Size = New Size(183, 29)
        Label5.TabIndex = 1
        Label5.Text = "Descrição"
        Label5.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label6
        ' 
        Label6.BackColor = Color.FromArgb(CByte(255), CByte(224), CByte(192))
        Label6.BorderStyle = BorderStyle.FixedSingle
        Label6.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.Location = New Point(3, 5)
        Label6.Name = "Label6"
        Label6.Size = New Size(338, 42)
        Label6.TabIndex = 0
        Label6.Text = "Desossa"
        Label6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Silver
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Controls.Add(TextBox2)
        Panel2.Controls.Add(Label7)
        Panel2.Controls.Add(lblTempOsso)
        Panel2.Controls.Add(Label9)
        Panel2.Controls.Add(Label10)
        Panel2.Controls.Add(Label11)
        Panel2.Controls.Add(Label12)
        Panel2.Location = New Point(733, 38)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(346, 172)
        Panel2.TabIndex = 26
        ' 
        ' TextBox2
        ' 
        TextBox2.BorderStyle = BorderStyle.None
        TextBox2.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox2.Location = New Point(193, 124)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(146, 32)
        TextBox2.TabIndex = 8
        TextBox2.Text = "00,0 °C"
        TextBox2.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label7
        ' 
        Label7.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label7.BorderStyle = BorderStyle.FixedSingle
        Label7.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label7.Location = New Point(3, 122)
        Label7.Name = "Label7"
        Label7.Size = New Size(183, 42)
        Label7.TabIndex = 7
        Label7.Text = "OffSet"
        Label7.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTempOsso
        ' 
        lblTempOsso.BackColor = Color.Black
        lblTempOsso.BorderStyle = BorderStyle.FixedSingle
        lblTempOsso.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblTempOsso.ForeColor = Color.Cyan
        lblTempOsso.Location = New Point(190, 78)
        lblTempOsso.Name = "lblTempOsso"
        lblTempOsso.Size = New Size(151, 42)
        lblTempOsso.TabIndex = 4
        lblTempOsso.Text = "00,0 °C"
        lblTempOsso.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label9
        ' 
        Label9.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label9.BorderStyle = BorderStyle.FixedSingle
        Label9.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label9.Location = New Point(3, 78)
        Label9.Name = "Label9"
        Label9.Size = New Size(183, 42)
        Label9.TabIndex = 3
        Label9.Text = "Temperatura"
        Label9.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label10
        ' 
        Label10.BackColor = Color.Teal
        Label10.BorderStyle = BorderStyle.FixedSingle
        Label10.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label10.ForeColor = SystemColors.ControlLightLight
        Label10.Location = New Point(190, 48)
        Label10.Name = "Label10"
        Label10.Size = New Size(151, 29)
        Label10.TabIndex = 2
        Label10.Text = "Status"
        Label10.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label11
        ' 
        Label11.BackColor = Color.Teal
        Label11.BorderStyle = BorderStyle.FixedSingle
        Label11.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label11.ForeColor = SystemColors.ControlLightLight
        Label11.Location = New Point(3, 48)
        Label11.Name = "Label11"
        Label11.Size = New Size(183, 29)
        Label11.TabIndex = 1
        Label11.Text = "Descrição"
        Label11.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label12
        ' 
        Label12.BackColor = Color.FromArgb(CByte(255), CByte(224), CByte(192))
        Label12.BorderStyle = BorderStyle.FixedSingle
        Label12.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label12.Location = New Point(3, 5)
        Label12.Name = "Label12"
        Label12.Size = New Size(338, 42)
        Label12.TabIndex = 0
        Label12.Text = "Exp. Carne com Osso"
        Label12.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.Silver
        Panel3.BorderStyle = BorderStyle.FixedSingle
        Panel3.Controls.Add(TextBox3)
        Panel3.Controls.Add(Label13)
        Panel3.Controls.Add(lblTempPaletizacao)
        Panel3.Controls.Add(Label15)
        Panel3.Controls.Add(Label16)
        Panel3.Controls.Add(Label17)
        Panel3.Controls.Add(Label18)
        Panel3.Location = New Point(1086, 38)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(346, 172)
        Panel3.TabIndex = 27
        ' 
        ' TextBox3
        ' 
        TextBox3.BorderStyle = BorderStyle.None
        TextBox3.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox3.Location = New Point(193, 124)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(146, 32)
        TextBox3.TabIndex = 8
        TextBox3.Text = "00,0 °C"
        TextBox3.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label13
        ' 
        Label13.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label13.BorderStyle = BorderStyle.FixedSingle
        Label13.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label13.Location = New Point(3, 122)
        Label13.Name = "Label13"
        Label13.Size = New Size(183, 42)
        Label13.TabIndex = 7
        Label13.Text = "OffSet"
        Label13.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTempPaletizacao
        ' 
        lblTempPaletizacao.BackColor = Color.Black
        lblTempPaletizacao.BorderStyle = BorderStyle.FixedSingle
        lblTempPaletizacao.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblTempPaletizacao.ForeColor = Color.Cyan
        lblTempPaletizacao.Location = New Point(190, 78)
        lblTempPaletizacao.Name = "lblTempPaletizacao"
        lblTempPaletizacao.Size = New Size(151, 42)
        lblTempPaletizacao.TabIndex = 4
        lblTempPaletizacao.Text = "00,0 °C"
        lblTempPaletizacao.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label15
        ' 
        Label15.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label15.BorderStyle = BorderStyle.FixedSingle
        Label15.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label15.Location = New Point(3, 78)
        Label15.Name = "Label15"
        Label15.Size = New Size(183, 42)
        Label15.TabIndex = 3
        Label15.Text = "Temperatura"
        Label15.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label16
        ' 
        Label16.BackColor = Color.Teal
        Label16.BorderStyle = BorderStyle.FixedSingle
        Label16.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label16.ForeColor = SystemColors.ControlLightLight
        Label16.Location = New Point(190, 48)
        Label16.Name = "Label16"
        Label16.Size = New Size(151, 29)
        Label16.TabIndex = 2
        Label16.Text = "Status"
        Label16.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label17
        ' 
        Label17.BackColor = Color.Teal
        Label17.BorderStyle = BorderStyle.FixedSingle
        Label17.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label17.ForeColor = SystemColors.ControlLightLight
        Label17.Location = New Point(3, 48)
        Label17.Name = "Label17"
        Label17.Size = New Size(183, 29)
        Label17.TabIndex = 1
        Label17.Text = "Descrição"
        Label17.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label18
        ' 
        Label18.BackColor = Color.FromArgb(CByte(255), CByte(224), CByte(192))
        Label18.BorderStyle = BorderStyle.FixedSingle
        Label18.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label18.Location = New Point(3, 5)
        Label18.Name = "Label18"
        Label18.Size = New Size(338, 42)
        Label18.TabIndex = 0
        Label18.Text = "Paletização"
        Label18.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.Silver
        Panel4.BorderStyle = BorderStyle.FixedSingle
        Panel4.Controls.Add(TextBox4)
        Panel4.Controls.Add(Label19)
        Panel4.Controls.Add(lblTempExpCaixaria)
        Panel4.Controls.Add(Label21)
        Panel4.Controls.Add(Label22)
        Panel4.Controls.Add(Label23)
        Panel4.Controls.Add(Label24)
        Panel4.Location = New Point(29, 229)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(346, 172)
        Panel4.TabIndex = 28
        ' 
        ' TextBox4
        ' 
        TextBox4.BorderStyle = BorderStyle.None
        TextBox4.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox4.Location = New Point(193, 124)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(146, 32)
        TextBox4.TabIndex = 8
        TextBox4.Text = "00,0 °C"
        TextBox4.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label19
        ' 
        Label19.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label19.BorderStyle = BorderStyle.FixedSingle
        Label19.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label19.Location = New Point(3, 122)
        Label19.Name = "Label19"
        Label19.Size = New Size(183, 42)
        Label19.TabIndex = 7
        Label19.Text = "OffSet"
        Label19.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTempExpCaixaria
        ' 
        lblTempExpCaixaria.BackColor = Color.Black
        lblTempExpCaixaria.BorderStyle = BorderStyle.FixedSingle
        lblTempExpCaixaria.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblTempExpCaixaria.ForeColor = Color.Cyan
        lblTempExpCaixaria.Location = New Point(190, 78)
        lblTempExpCaixaria.Name = "lblTempExpCaixaria"
        lblTempExpCaixaria.Size = New Size(151, 42)
        lblTempExpCaixaria.TabIndex = 4
        lblTempExpCaixaria.Text = "00,0 °C"
        lblTempExpCaixaria.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label21
        ' 
        Label21.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label21.BorderStyle = BorderStyle.FixedSingle
        Label21.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label21.Location = New Point(3, 78)
        Label21.Name = "Label21"
        Label21.Size = New Size(183, 42)
        Label21.TabIndex = 3
        Label21.Text = "Temperatura"
        Label21.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label22
        ' 
        Label22.BackColor = Color.Teal
        Label22.BorderStyle = BorderStyle.FixedSingle
        Label22.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label22.ForeColor = SystemColors.ControlLightLight
        Label22.Location = New Point(190, 48)
        Label22.Name = "Label22"
        Label22.Size = New Size(151, 29)
        Label22.TabIndex = 2
        Label22.Text = "Status"
        Label22.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label23
        ' 
        Label23.BackColor = Color.Teal
        Label23.BorderStyle = BorderStyle.FixedSingle
        Label23.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label23.ForeColor = SystemColors.ControlLightLight
        Label23.Location = New Point(3, 48)
        Label23.Name = "Label23"
        Label23.Size = New Size(183, 29)
        Label23.TabIndex = 1
        Label23.Text = "Descrição"
        Label23.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label24
        ' 
        Label24.BackColor = Color.FromArgb(CByte(255), CByte(224), CByte(192))
        Label24.BorderStyle = BorderStyle.FixedSingle
        Label24.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label24.Location = New Point(3, 5)
        Label24.Name = "Label24"
        Label24.Size = New Size(338, 42)
        Label24.TabIndex = 0
        Label24.Text = "Expedição Caixaria"
        Label24.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Timer1
        ' 
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = Color.Silver
        Panel6.BorderStyle = BorderStyle.FixedSingle
        Panel6.Controls.Add(TextBox5)
        Panel6.Controls.Add(Label2)
        Panel6.Controls.Add(lblTempEmbMiudos)
        Panel6.Controls.Add(Label14)
        Panel6.Controls.Add(Label20)
        Panel6.Controls.Add(Label25)
        Panel6.Controls.Add(Label29)
        Panel6.Location = New Point(381, 229)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(346, 172)
        Panel6.TabIndex = 29
        ' 
        ' TextBox5
        ' 
        TextBox5.BorderStyle = BorderStyle.None
        TextBox5.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox5.Location = New Point(193, 124)
        TextBox5.Name = "TextBox5"
        TextBox5.Size = New Size(146, 32)
        TextBox5.TabIndex = 8
        TextBox5.Text = "00,0 °C"
        TextBox5.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label2
        ' 
        Label2.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label2.BorderStyle = BorderStyle.FixedSingle
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.Location = New Point(3, 122)
        Label2.Name = "Label2"
        Label2.Size = New Size(183, 42)
        Label2.TabIndex = 7
        Label2.Text = "OffSet"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTempEmbMiudos
        ' 
        lblTempEmbMiudos.BackColor = Color.Black
        lblTempEmbMiudos.BorderStyle = BorderStyle.FixedSingle
        lblTempEmbMiudos.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblTempEmbMiudos.ForeColor = Color.Cyan
        lblTempEmbMiudos.Location = New Point(190, 78)
        lblTempEmbMiudos.Name = "lblTempEmbMiudos"
        lblTempEmbMiudos.Size = New Size(151, 42)
        lblTempEmbMiudos.TabIndex = 4
        lblTempEmbMiudos.Text = "00,0 °C"
        lblTempEmbMiudos.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label14
        ' 
        Label14.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label14.BorderStyle = BorderStyle.FixedSingle
        Label14.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label14.Location = New Point(3, 78)
        Label14.Name = "Label14"
        Label14.Size = New Size(183, 42)
        Label14.TabIndex = 3
        Label14.Text = "Temperatura"
        Label14.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label20
        ' 
        Label20.BackColor = Color.Teal
        Label20.BorderStyle = BorderStyle.FixedSingle
        Label20.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label20.ForeColor = SystemColors.ControlLightLight
        Label20.Location = New Point(190, 48)
        Label20.Name = "Label20"
        Label20.Size = New Size(151, 29)
        Label20.TabIndex = 2
        Label20.Text = "Status"
        Label20.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label25
        ' 
        Label25.BackColor = Color.Teal
        Label25.BorderStyle = BorderStyle.FixedSingle
        Label25.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label25.ForeColor = SystemColors.ControlLightLight
        Label25.Location = New Point(3, 48)
        Label25.Name = "Label25"
        Label25.Size = New Size(183, 29)
        Label25.TabIndex = 1
        Label25.Text = "Descrição"
        Label25.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label29
        ' 
        Label29.BackColor = Color.FromArgb(CByte(255), CByte(224), CByte(192))
        Label29.BorderStyle = BorderStyle.FixedSingle
        Label29.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label29.Location = New Point(3, 5)
        Label29.Name = "Label29"
        Label29.Size = New Size(338, 42)
        Label29.TabIndex = 0
        Label29.Text = "Embalagem Miúdos"
        Label29.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel7
        ' 
        Panel7.BackColor = Color.Silver
        Panel7.BorderStyle = BorderStyle.FixedSingle
        Panel7.Controls.Add(TextBox6)
        Panel7.Controls.Add(Label30)
        Panel7.Controls.Add(lblTempBuchariaLimpa)
        Panel7.Controls.Add(Label32)
        Panel7.Controls.Add(Label33)
        Panel7.Controls.Add(Label34)
        Panel7.Controls.Add(Label35)
        Panel7.Location = New Point(733, 229)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(346, 172)
        Panel7.TabIndex = 30
        ' 
        ' TextBox6
        ' 
        TextBox6.BorderStyle = BorderStyle.None
        TextBox6.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox6.Location = New Point(193, 124)
        TextBox6.Name = "TextBox6"
        TextBox6.Size = New Size(146, 32)
        TextBox6.TabIndex = 8
        TextBox6.Text = "00,0 °C"
        TextBox6.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label30
        ' 
        Label30.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label30.BorderStyle = BorderStyle.FixedSingle
        Label30.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label30.Location = New Point(3, 122)
        Label30.Name = "Label30"
        Label30.Size = New Size(183, 42)
        Label30.TabIndex = 7
        Label30.Text = "OffSet"
        Label30.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTempBuchariaLimpa
        ' 
        lblTempBuchariaLimpa.BackColor = Color.Black
        lblTempBuchariaLimpa.BorderStyle = BorderStyle.FixedSingle
        lblTempBuchariaLimpa.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblTempBuchariaLimpa.ForeColor = Color.Cyan
        lblTempBuchariaLimpa.Location = New Point(190, 78)
        lblTempBuchariaLimpa.Name = "lblTempBuchariaLimpa"
        lblTempBuchariaLimpa.Size = New Size(151, 42)
        lblTempBuchariaLimpa.TabIndex = 4
        lblTempBuchariaLimpa.Text = "00,0 °C"
        lblTempBuchariaLimpa.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label32
        ' 
        Label32.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label32.BorderStyle = BorderStyle.FixedSingle
        Label32.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label32.Location = New Point(3, 78)
        Label32.Name = "Label32"
        Label32.Size = New Size(183, 42)
        Label32.TabIndex = 3
        Label32.Text = "Temperatura"
        Label32.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label33
        ' 
        Label33.BackColor = Color.Teal
        Label33.BorderStyle = BorderStyle.FixedSingle
        Label33.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label33.ForeColor = SystemColors.ControlLightLight
        Label33.Location = New Point(190, 48)
        Label33.Name = "Label33"
        Label33.Size = New Size(151, 29)
        Label33.TabIndex = 2
        Label33.Text = "Status"
        Label33.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label34
        ' 
        Label34.BackColor = Color.Teal
        Label34.BorderStyle = BorderStyle.FixedSingle
        Label34.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label34.ForeColor = SystemColors.ControlLightLight
        Label34.Location = New Point(3, 48)
        Label34.Name = "Label34"
        Label34.Size = New Size(183, 29)
        Label34.TabIndex = 1
        Label34.Text = "Descrição"
        Label34.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label35
        ' 
        Label35.BackColor = Color.FromArgb(CByte(255), CByte(224), CByte(192))
        Label35.BorderStyle = BorderStyle.FixedSingle
        Label35.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label35.Location = New Point(3, 5)
        Label35.Name = "Label35"
        Label35.Size = New Size(338, 42)
        Label35.TabIndex = 0
        Label35.Text = "Bucharia Limpa"
        Label35.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = Color.Silver
        Panel8.BorderStyle = BorderStyle.FixedSingle
        Panel8.Controls.Add(TextBox7)
        Panel8.Controls.Add(Label36)
        Panel8.Controls.Add(lblTempBuchariaSuja)
        Panel8.Controls.Add(Label38)
        Panel8.Controls.Add(Label40)
        Panel8.Controls.Add(Label41)
        Panel8.Controls.Add(Label42)
        Panel8.Location = New Point(1086, 229)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(346, 172)
        Panel8.TabIndex = 31
        ' 
        ' TextBox7
        ' 
        TextBox7.BorderStyle = BorderStyle.None
        TextBox7.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox7.Location = New Point(193, 124)
        TextBox7.Name = "TextBox7"
        TextBox7.Size = New Size(146, 32)
        TextBox7.TabIndex = 8
        TextBox7.Text = "00,0 °C"
        TextBox7.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label36
        ' 
        Label36.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label36.BorderStyle = BorderStyle.FixedSingle
        Label36.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label36.Location = New Point(3, 122)
        Label36.Name = "Label36"
        Label36.Size = New Size(183, 42)
        Label36.TabIndex = 7
        Label36.Text = "OffSet"
        Label36.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTempBuchariaSuja
        ' 
        lblTempBuchariaSuja.BackColor = Color.Black
        lblTempBuchariaSuja.BorderStyle = BorderStyle.FixedSingle
        lblTempBuchariaSuja.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblTempBuchariaSuja.ForeColor = Color.Cyan
        lblTempBuchariaSuja.Location = New Point(190, 78)
        lblTempBuchariaSuja.Name = "lblTempBuchariaSuja"
        lblTempBuchariaSuja.Size = New Size(151, 42)
        lblTempBuchariaSuja.TabIndex = 4
        lblTempBuchariaSuja.Text = "00,0 °C"
        lblTempBuchariaSuja.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label38
        ' 
        Label38.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label38.BorderStyle = BorderStyle.FixedSingle
        Label38.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label38.Location = New Point(3, 78)
        Label38.Name = "Label38"
        Label38.Size = New Size(183, 42)
        Label38.TabIndex = 3
        Label38.Text = "Temperatura"
        Label38.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label40
        ' 
        Label40.BackColor = Color.Teal
        Label40.BorderStyle = BorderStyle.FixedSingle
        Label40.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label40.ForeColor = SystemColors.ControlLightLight
        Label40.Location = New Point(190, 48)
        Label40.Name = "Label40"
        Label40.Size = New Size(151, 29)
        Label40.TabIndex = 2
        Label40.Text = "Status"
        Label40.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label41
        ' 
        Label41.BackColor = Color.Teal
        Label41.BorderStyle = BorderStyle.FixedSingle
        Label41.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label41.ForeColor = SystemColors.ControlLightLight
        Label41.Location = New Point(3, 48)
        Label41.Name = "Label41"
        Label41.Size = New Size(183, 29)
        Label41.TabIndex = 1
        Label41.Text = "Descrição"
        Label41.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label42
        ' 
        Label42.BackColor = Color.FromArgb(CByte(255), CByte(224), CByte(192))
        Label42.BorderStyle = BorderStyle.FixedSingle
        Label42.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label42.Location = New Point(3, 5)
        Label42.Name = "Label42"
        Label42.Size = New Size(338, 42)
        Label42.TabIndex = 0
        Label42.Text = "Bucharia Suja"
        Label42.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel9
        ' 
        Panel9.BackColor = Color.Silver
        Panel9.BorderStyle = BorderStyle.FixedSingle
        Panel9.Controls.Add(TextBox8)
        Panel9.Controls.Add(Label43)
        Panel9.Controls.Add(lblTempSalaMiudos)
        Panel9.Controls.Add(Label45)
        Panel9.Controls.Add(Label46)
        Panel9.Controls.Add(Label47)
        Panel9.Controls.Add(Label48)
        Panel9.Location = New Point(29, 422)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(346, 172)
        Panel9.TabIndex = 32
        ' 
        ' TextBox8
        ' 
        TextBox8.BorderStyle = BorderStyle.None
        TextBox8.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox8.Location = New Point(193, 124)
        TextBox8.Name = "TextBox8"
        TextBox8.Size = New Size(146, 32)
        TextBox8.TabIndex = 8
        TextBox8.Text = "00,0 °C"
        TextBox8.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label43
        ' 
        Label43.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label43.BorderStyle = BorderStyle.FixedSingle
        Label43.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label43.Location = New Point(3, 122)
        Label43.Name = "Label43"
        Label43.Size = New Size(183, 42)
        Label43.TabIndex = 7
        Label43.Text = "OffSet"
        Label43.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTempSalaMiudos
        ' 
        lblTempSalaMiudos.BackColor = Color.Black
        lblTempSalaMiudos.BorderStyle = BorderStyle.FixedSingle
        lblTempSalaMiudos.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblTempSalaMiudos.ForeColor = Color.Cyan
        lblTempSalaMiudos.Location = New Point(190, 78)
        lblTempSalaMiudos.Name = "lblTempSalaMiudos"
        lblTempSalaMiudos.Size = New Size(151, 42)
        lblTempSalaMiudos.TabIndex = 4
        lblTempSalaMiudos.Text = "00,0 °C"
        lblTempSalaMiudos.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label45
        ' 
        Label45.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label45.BorderStyle = BorderStyle.FixedSingle
        Label45.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label45.Location = New Point(3, 78)
        Label45.Name = "Label45"
        Label45.Size = New Size(183, 42)
        Label45.TabIndex = 3
        Label45.Text = "Temperatura"
        Label45.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label46
        ' 
        Label46.BackColor = Color.Teal
        Label46.BorderStyle = BorderStyle.FixedSingle
        Label46.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label46.ForeColor = SystemColors.ControlLightLight
        Label46.Location = New Point(190, 48)
        Label46.Name = "Label46"
        Label46.Size = New Size(151, 29)
        Label46.TabIndex = 2
        Label46.Text = "Status"
        Label46.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label47
        ' 
        Label47.BackColor = Color.Teal
        Label47.BorderStyle = BorderStyle.FixedSingle
        Label47.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label47.ForeColor = SystemColors.ControlLightLight
        Label47.Location = New Point(3, 48)
        Label47.Name = "Label47"
        Label47.Size = New Size(183, 29)
        Label47.TabIndex = 1
        Label47.Text = "Descrição"
        Label47.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label48
        ' 
        Label48.BackColor = Color.FromArgb(CByte(255), CByte(224), CByte(192))
        Label48.BorderStyle = BorderStyle.FixedSingle
        Label48.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label48.Location = New Point(3, 5)
        Label48.Name = "Label48"
        Label48.Size = New Size(338, 42)
        Label48.TabIndex = 0
        Label48.Text = "Sala de Miúdos"
        Label48.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel10
        ' 
        Panel10.BackColor = Color.Silver
        Panel10.BorderStyle = BorderStyle.FixedSingle
        Panel10.Controls.Add(TextBox9)
        Panel10.Controls.Add(Label49)
        Panel10.Controls.Add(lblTempCamaraMiudos)
        Panel10.Controls.Add(Label51)
        Panel10.Controls.Add(Label52)
        Panel10.Controls.Add(Label53)
        Panel10.Controls.Add(Label54)
        Panel10.Location = New Point(381, 422)
        Panel10.Name = "Panel10"
        Panel10.Size = New Size(346, 172)
        Panel10.TabIndex = 33
        ' 
        ' TextBox9
        ' 
        TextBox9.BorderStyle = BorderStyle.None
        TextBox9.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox9.Location = New Point(193, 124)
        TextBox9.Name = "TextBox9"
        TextBox9.Size = New Size(146, 32)
        TextBox9.TabIndex = 8
        TextBox9.Text = "00,0 °C"
        TextBox9.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label49
        ' 
        Label49.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label49.BorderStyle = BorderStyle.FixedSingle
        Label49.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label49.Location = New Point(3, 122)
        Label49.Name = "Label49"
        Label49.Size = New Size(183, 42)
        Label49.TabIndex = 7
        Label49.Text = "OffSet"
        Label49.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTempCamaraMiudos
        ' 
        lblTempCamaraMiudos.BackColor = Color.Black
        lblTempCamaraMiudos.BorderStyle = BorderStyle.FixedSingle
        lblTempCamaraMiudos.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblTempCamaraMiudos.ForeColor = Color.Cyan
        lblTempCamaraMiudos.Location = New Point(190, 78)
        lblTempCamaraMiudos.Name = "lblTempCamaraMiudos"
        lblTempCamaraMiudos.Size = New Size(151, 42)
        lblTempCamaraMiudos.TabIndex = 4
        lblTempCamaraMiudos.Text = "00,0 °C"
        lblTempCamaraMiudos.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label51
        ' 
        Label51.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label51.BorderStyle = BorderStyle.FixedSingle
        Label51.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label51.Location = New Point(3, 78)
        Label51.Name = "Label51"
        Label51.Size = New Size(183, 42)
        Label51.TabIndex = 3
        Label51.Text = "Temperatura"
        Label51.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label52
        ' 
        Label52.BackColor = Color.Teal
        Label52.BorderStyle = BorderStyle.FixedSingle
        Label52.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label52.ForeColor = SystemColors.ControlLightLight
        Label52.Location = New Point(190, 48)
        Label52.Name = "Label52"
        Label52.Size = New Size(151, 29)
        Label52.TabIndex = 2
        Label52.Text = "Status"
        Label52.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label53
        ' 
        Label53.BackColor = Color.Teal
        Label53.BorderStyle = BorderStyle.FixedSingle
        Label53.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label53.ForeColor = SystemColors.ControlLightLight
        Label53.Location = New Point(3, 48)
        Label53.Name = "Label53"
        Label53.Size = New Size(183, 29)
        Label53.TabIndex = 1
        Label53.Text = "Descrição"
        Label53.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label54
        ' 
        Label54.BackColor = Color.FromArgb(CByte(255), CByte(224), CByte(192))
        Label54.BorderStyle = BorderStyle.FixedSingle
        Label54.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label54.Location = New Point(3, 5)
        Label54.Name = "Label54"
        Label54.Size = New Size(338, 42)
        Label54.TabIndex = 0
        Label54.Text = "Câmara Resf. Miúdos"
        Label54.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel11
        ' 
        Panel11.BackColor = Color.Silver
        Panel11.BorderStyle = BorderStyle.FixedSingle
        Panel11.Controls.Add(TextBox10)
        Panel11.Controls.Add(Label55)
        Panel11.Controls.Add(lblTempCamaraEstomago)
        Panel11.Controls.Add(Label57)
        Panel11.Controls.Add(Label58)
        Panel11.Controls.Add(Label59)
        Panel11.Controls.Add(Label60)
        Panel11.Location = New Point(733, 422)
        Panel11.Name = "Panel11"
        Panel11.Size = New Size(346, 172)
        Panel11.TabIndex = 34
        ' 
        ' TextBox10
        ' 
        TextBox10.BorderStyle = BorderStyle.None
        TextBox10.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox10.Location = New Point(193, 124)
        TextBox10.Name = "TextBox10"
        TextBox10.Size = New Size(146, 32)
        TextBox10.TabIndex = 8
        TextBox10.Text = "00,0 °C"
        TextBox10.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label55
        ' 
        Label55.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label55.BorderStyle = BorderStyle.FixedSingle
        Label55.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label55.Location = New Point(3, 122)
        Label55.Name = "Label55"
        Label55.Size = New Size(183, 42)
        Label55.TabIndex = 7
        Label55.Text = "OffSet"
        Label55.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTempCamaraEstomago
        ' 
        lblTempCamaraEstomago.BackColor = Color.Black
        lblTempCamaraEstomago.BorderStyle = BorderStyle.FixedSingle
        lblTempCamaraEstomago.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        lblTempCamaraEstomago.ForeColor = Color.Cyan
        lblTempCamaraEstomago.Location = New Point(190, 78)
        lblTempCamaraEstomago.Name = "lblTempCamaraEstomago"
        lblTempCamaraEstomago.Size = New Size(151, 42)
        lblTempCamaraEstomago.TabIndex = 4
        lblTempCamaraEstomago.Text = "00,0 °C"
        lblTempCamaraEstomago.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label57
        ' 
        Label57.BackColor = Color.FromArgb(CByte(192), CByte(255), CByte(192))
        Label57.BorderStyle = BorderStyle.FixedSingle
        Label57.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label57.Location = New Point(3, 78)
        Label57.Name = "Label57"
        Label57.Size = New Size(183, 42)
        Label57.TabIndex = 3
        Label57.Text = "Temperatura"
        Label57.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label58
        ' 
        Label58.BackColor = Color.Teal
        Label58.BorderStyle = BorderStyle.FixedSingle
        Label58.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label58.ForeColor = SystemColors.ControlLightLight
        Label58.Location = New Point(190, 48)
        Label58.Name = "Label58"
        Label58.Size = New Size(151, 29)
        Label58.TabIndex = 2
        Label58.Text = "Status"
        Label58.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label59
        ' 
        Label59.BackColor = Color.Teal
        Label59.BorderStyle = BorderStyle.FixedSingle
        Label59.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label59.ForeColor = SystemColors.ControlLightLight
        Label59.Location = New Point(3, 48)
        Label59.Name = "Label59"
        Label59.Size = New Size(183, 29)
        Label59.TabIndex = 1
        Label59.Text = "Descrição"
        Label59.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label60
        ' 
        Label60.BackColor = Color.FromArgb(CByte(255), CByte(224), CByte(192))
        Label60.BorderStyle = BorderStyle.FixedSingle
        Label60.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label60.Location = New Point(3, 5)
        Label60.Name = "Label60"
        Label60.Size = New Size(338, 42)
        Label60.TabIndex = 0
        Label60.Text = "Câmara Resf. Estômago"
        Label60.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' frmClimatizacao
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.Gray
        ClientSize = New Size(1599, 932)
        Controls.Add(Panel11)
        Controls.Add(Panel10)
        Controls.Add(Panel9)
        Controls.Add(Panel8)
        Controls.Add(Panel7)
        Controls.Add(Panel6)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(Panel5)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimizeBox = False
        Name = "frmClimatizacao"
        ShowIcon = False
        Text = "Ambientes Climatizados"
        WindowState = FormWindowState.Maximized
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        Panel7.ResumeLayout(False)
        Panel7.PerformLayout()
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        Panel9.ResumeLayout(False)
        Panel9.PerformLayout()
        Panel10.ResumeLayout(False)
        Panel10.PerformLayout()
        Panel11.ResumeLayout(False)
        Panel11.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel5 As Panel
    Friend WithEvents edtOffSetTunel1 As TextBox
    Friend WithEvents Label39 As Label
    Friend WithEvents lblTempEmbSec As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents lblAtalhoTunel1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTempDesossa As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents lblTempOsso As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents lblTempPaletizacao As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents lblTempExpCaixaria As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel6 As Panel
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblTempEmbMiudos As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents lblTempBuchariaLimpa As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents lblTempBuchariaSuja As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents Label43 As Label
    Friend WithEvents lblTempSalaMiudos As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents Label49 As Label
    Friend WithEvents lblTempCamaraMiudos As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents Label55 As Label
    Friend WithEvents lblTempCamaraEstomago As Label
    Friend WithEvents Label57 As Label
    Friend WithEvents Label58 As Label
    Friend WithEvents Label59 As Label
    Friend WithEvents Label60 As Label
End Class
