Imports System.IO
Imports System.Xml.Linq

Public Class ConfiguracaoApp

    Public Property CaminhoDb               As String  = ""
    Public Property IntervaloColetaMinutos  As Integer = 5
    Public Property ColetarSemConexao       As Boolean = True
    Public Property RetencaoMeses           As Integer = 12

    Public Property LogoPath                As String  = ""
    Public Property NomeCliente             As String  = "Cliente"
    Public Property NomeInstalacao          As String  = "Frigorifico"
    Public Property FooterTexto             As String  = "SisMaster | {DATA} | {HORA}"
    Public Property PastaExportacao         As String  = ""
    Public Property PeriodoPadraoAtrasoDias As Integer = 2

    ' Mapa id -> nome configurado para cada sensor de temperatura
    Public Property Sensores As New Dictionary(Of Integer, String)

    Private Shared _instancia As ConfiguracaoApp

    ' Retorna a instancia carregada. Carrega do XML na primeira chamada.
    Public Shared Function Carregar() As ConfiguracaoApp
        If _instancia Is Nothing Then
            _instancia = New ConfiguracaoApp()
            _instancia.CarregarXml()
        End If
        Return _instancia
    End Function

    ' Forca recarga do XML na proxima chamada a Carregar().
    ' Util para testes ou se o XML for alterado em tempo de execucao.
    Public Shared Sub Recarregar()
        _instancia = Nothing
    End Sub

    ' Caminho absoluto: retorna como esta.
    ' Caminho relativo ou vazio: resolve a partir do diretorio do executavel.
    Private Shared Function ResolvePathXml(valor As String, padraoRelativo As String) As String
        Dim base = AppDomain.CurrentDomain.BaseDirectory
        If String.IsNullOrWhiteSpace(valor) Then
            Return If(String.IsNullOrWhiteSpace(padraoRelativo), "", Path.Combine(base, padraoRelativo))
        End If
        Return If(Path.IsPathRooted(valor), valor, Path.Combine(base, valor))
    End Function

    Private Sub CarregarXml()
        Dim caminho = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Config", "sismaster.config.xml")

        If Not File.Exists(caminho) Then
            CarregarPadroes()
            Return
        End If

        Try
            Dim doc = XDocument.Load(caminho)

            Dim db = doc.Root.Element("BancoDados")
            If db IsNot Nothing Then
                CaminhoDb              = ResolvePathXml(db.Element("CaminhoDb")?.Value, Path.Combine("dados", "sensores.db"))
                IntervaloColetaMinutos = CInt(If(db.Element("IntervaloColetaMinutos")?.Value, "5"))
                ColetarSemConexao      = (db.Element("ColetarSemConexao")?.Value?.ToLower() = "true")
                RetencaoMeses          = CInt(If(db.Element("RetencaoMeses")?.Value, "12"))
            End If

            Dim rel = doc.Root.Element("Relatorios")
            If rel IsNot Nothing Then
                LogoPath                = ResolvePathXml(rel.Element("LogoPath")?.Value,                "")
                NomeCliente             = If(rel.Element("NomeCliente")?.Value,             NomeCliente)
                NomeInstalacao          = If(rel.Element("NomeInstalacao")?.Value,          NomeInstalacao)
                FooterTexto             = If(rel.Element("FooterTexto")?.Value,             FooterTexto)
                PastaExportacao         = ResolvePathXml(rel.Element("PastaExportacao")?.Value,         "relatorios")
                PeriodoPadraoAtrasoDias = CInt(If(rel.Element("PeriodoPadraoAtrasoDias")?.Value, "2"))
            End If

            For Each s In doc.Root.Descendants("Sensor")
                Dim id   = CInt(s.Attribute("id").Value)
                Dim nome = s.Attribute("nome").Value
                Sensores(id) = nome
            Next

        Catch
            CarregarPadroes()
        End Try
    End Sub

    ' Nomes padrao caso o XML nao exista ou nao possa ser lido.
    ' Espelham os comentarios presentes em Form1.vb.
    Private Sub CarregarPadroes()
        Dim base = AppDomain.CurrentDomain.BaseDirectory
        CaminhoDb       = Path.Combine(base, "dados", "sensores.db")
        PastaExportacao = Path.Combine(base, "relatorios")

        Sensores = New Dictionary(Of Integer, String) From {
            {1,  "Tunel 12"},         {2,  "Tunel 11"},        {3,  "Tunel 10"},
            {4,  "Tunel 09"},         {5,  "Tunel 08"},        {6,  "Estocagem 3"},
            {7,  "Corredor Tuneis"},  {8,  "Docas Expedicao"},
            {11, "Tunel 04"},         {12, "Tunel 05"},        {13, "Tunel 06"},
            {14, "Tunel 07"},         {15, "Estocagem 01"},    {16, "Estocagem 02"},
            {21, "Camara1"},          {22, "Camara2"},         {23, "Camara3"},
            {24, "Camara4"},          {25, "Camara5"},         {26, "Camara6"},
            {27, "Camara7"},          {28, "Pulmao"},
            {29, "Tunel1"},           {30, "Tunel2"},          {31, "Tunel3"},
            {32, "Estocagem Miudos"}, {33, "Estocagem Resfriados"},
            {34, "Embalagem Secundaria"}, {35, "Desossa"},
            {36, "Expedicao Carne com Osso"}, {37, "Paletizacao"},
            {38, "Expedicao Caixaria"},   {39, "Embalagem Miudos"},
            {40, "Bucharia Limpa"},   {41, "Bucharia Suja"},   {42, "Sala Miudos"},
            {43, "Camara Resfriamento Miudos"}, {44, "Camara Resfriamento Estomago"}
        }
    End Sub

End Class
