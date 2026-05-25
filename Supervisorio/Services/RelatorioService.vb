Imports System.IO
Imports System.Linq
Imports QuestPDF.Fluent
Imports QuestPDF.Helpers
Imports QuestPDF.Infrastructure

Public Class RelatorioService

    Private ReadOnly _config As ConfiguracaoApp

    Public Sub New(config As ConfiguracaoApp)
        _config = config
        QuestPDF.Settings.License = LicenseType.Community
    End Sub

    ' Recupera resilientemente o logotipo do cliente embutido como EmbeddedResource do Assembly.
    Private Function ObterLogoBytes() As Byte()
        Try
            Dim asm = GetType(RelatorioService).Assembly
            Dim nomes = asm.GetManifestResourceNames()
            Dim nomeRecurso = nomes.FirstOrDefault(Function(n) n.EndsWith("logo-boa-carne.jpg", StringComparison.OrdinalIgnoreCase))
            
            If String.IsNullOrEmpty(nomeRecurso) Then Return Nothing
            
            Using ms As New MemoryStream()
                Using stream = asm.GetManifestResourceStream(nomeRecurso)
                    If stream Is Nothing Then Return Nothing
                    stream.CopyTo(ms)
                End Using
                Return ms.ToArray()
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub ExportarPDF(dados      As DataTable,
                            destino    As String,
                            nomeSensor As String,
                            dataInicio As DateTime,
                            dataFim    As DateTime)

        Directory.CreateDirectory(Path.GetDirectoryName(destino))

        ' Montar lista de pares [data_hora formatada, temperatura] a partir do DataTable
        Dim leituras As New List(Of String())
        For Each row As DataRow In dados.Rows
            leituras.Add(New String() {
                If(row("data_hora_fmt")?.ToString(), ""),
                CDbl(row("temperatura")).ToString("F1")
            })
        Next

        ' Calcular nLinha (colunas por página) dinamicamente baseando-se no total de registros.
        ' 38 registros cabem verticalmente em uma página A4 sob o cabeçalho/rodapé.
        Dim nLinha As Integer = 1
        Dim totalRegistros = leituras.Count
        Dim maxRowsPerPage = 38
        
        If totalRegistros <= maxRowsPerPage Then
            nLinha = 1
        ElseIf totalRegistros <= maxRowsPerPage * 2 Then
            nLinha = 2
        ElseIf totalRegistros <= maxRowsPerPage * 3 Then
            nLinha = 3
        Else
            nLinha = 4
        End If

        ' Capturar variáveis de escopo para uso dentro dos lambdas
        Dim cfg      = _config
        Dim dadosPdf = leituras
        Dim nSensor  = nomeSensor
        Dim dtIni    = dataInicio
        Dim dtFim2   = dataFim

        Document.Create(Sub(container)
            container.Page(Sub(page)

                page.Size(PageSizes.A4)
                page.Margin(1.5, Unit.Centimetre)
                page.DefaultTextStyle(Function(x) x.FontSize(8).FontFamily("Arial"))

                ' page.Header() retorna IContainer; encadeamos Column para múltiplas linhas
                page.Header().Column(Sub(col)
                    col.Item().Row(Sub(row)
                        Dim logoBytes = ObterLogoBytes()
                        If logoBytes IsNot Nothing Then
                            row.ConstantItem(2.5, Unit.Centimetre) _
                               .Image(logoBytes)
                            row.ConstantItem(0.4, Unit.Centimetre) ' Espaço elegante após o logo
                        ElseIf File.Exists(cfg.LogoPath) Then
                            row.ConstantItem(2.5, Unit.Centimetre) _
                               .Image(cfg.LogoPath)
                            row.ConstantItem(0.4, Unit.Centimetre) ' Espaço elegante após o logo
                        End If
                        row.RelativeItem().Column(Sub(c)
                            c.Item().Text(cfg.NomeCliente) _
                             .FontSize(13).Bold().FontColor(Color.FromRGB(30, 64, 115))
                            c.Item().Text(cfg.NomeInstalacao) _
                             .FontSize(9).FontColor(Colors.Grey.Darken2)
                            c.Item().Text("Sensor: " & nSensor).FontSize(9).Bold()
                        End Sub)
                        row.ConstantItem(4.5, Unit.Centimetre).Column(Sub(c)
                            c.Item().Text("De: " & dtIni.ToString("dd/MM/yyyy HH:mm"))
                            c.Item().Text("Até: " & dtFim2.ToString("dd/MM/yyyy HH:mm"))
                            c.Item().Text("Gerado: " & DateTime.Now.ToString("dd/MM/yyyy HH:mm"))
                            c.Item().Text("Total: " & dadosPdf.Count.ToString("N0") & " registros")
                        End Sub)
                    End Sub)
                    col.Item().PaddingTop(4).LineHorizontal(1) _
                       .LineColor(Color.FromRGB(30, 64, 115))
                End Sub)

                ' page.Content() retorna IContainer; encadeamos Table diretamente
                page.Content().PaddingVertical(6).Table(Sub(tbl)

                    Dim azul    = Color.FromRGB(30, 64, 115)
                    Dim corSep  = Color.FromRGB(120, 145, 185)  ' divisor entre grupos
                    Dim sepHdr  = Color.FromRGB(180, 200, 230)  ' divisor no cabeçalho

                    tbl.ColumnsDefinition(Sub(cols)
                        For i = 1 To nLinha
                            cols.RelativeColumn(3)
                            cols.RelativeColumn(1.3)
                        Next
                    End Sub)

                    tbl.Header(Sub(h)
                        For i = 1 To nLinha
                            If i > 1 Then
                                h.Cell().Background(azul).BorderLeft(1.5).BorderColor(sepHdr) _
                                 .Padding(3).AlignCenter().Text("Data / Hora") _
                                 .FontColor(Colors.White).Bold().FontSize(7.5)
                            Else
                                h.Cell().Background(azul) _
                                 .Padding(3).AlignCenter().Text("Data / Hora") _
                                 .FontColor(Colors.White).Bold().FontSize(7.5)
                            End If
                            h.Cell().Background(azul) _
                             .Padding(3).AlignCenter().Text("Temp (°C)") _
                             .FontColor(Colors.White).Bold().FontSize(7.5)
                        Next
                    End Sub)

                    Dim total   = dadosPdf.Count
                    Dim pageSize = nLinha * maxRowsPerPage
                    Dim totalPages = CInt(Math.Ceiling(total / pageSize))
                    Dim alterno = False

                    For p = 0 To totalPages - 1
                        Dim startIdx = p * pageSize
                        Dim S = Math.Min(total - startIdx, pageSize)
                        If S <= 0 Then Exit For

                        Dim R_actual = CInt(Math.Ceiling(S / nLinha))

                        For r = 0 To R_actual - 1
                            Dim bg = If(alterno,
                                        Color.FromRGB(240, 245, 255),
                                        Colors.White)
                            alterno = Not alterno

                            For col = 0 To nLinha - 1
                                Dim itemIdx = startIdx + col * R_actual + r

                                If itemIdx < total AndAlso col * R_actual + r < S Then
                                    Dim l = dadosPdf(itemIdx)
                                    If col > 0 Then
                                        tbl.Cell().Background(bg).BorderLeft(1.5).BorderColor(corSep) _
                                           .Padding(3).AlignCenter().Text(l(0)).FontSize(7.5)
                                    Else
                                        tbl.Cell().Background(bg) _
                                           .Padding(3).AlignCenter().Text(l(0)).FontSize(7.5)
                                    End If
                                    tbl.Cell().Background(bg).Padding(3) _
                                       .AlignCenter().Text(l(1)).FontSize(7.5)
                                Else
                                    If col > 0 Then
                                        tbl.Cell().Background(bg).BorderLeft(1.5).BorderColor(corSep).Text("")
                                    Else
                                        tbl.Cell().Background(bg).Text("")
                                    End If
                                    tbl.Cell().Background(bg).Text("")
                                End If
                            Next
                        Next
                    Next

                End Sub)

                ' page.Footer() retorna IContainer; encadeamos Column para linha horizontal + texto
                page.Footer().Column(Sub(col)
                    col.Item().LineHorizontal(0.5).LineColor(Colors.Grey.Medium)
                    col.Item().Row(Sub(row)
                        Dim textoFooter = cfg.FooterTexto _
                            .Replace("{DATA}", DateTime.Now.ToString("dd/MM/yyyy")) _
                            .Replace("{HORA}", DateTime.Now.ToString("HH:mm"))
                        row.RelativeItem().Text(textoFooter) _
                           .FontSize(7).FontColor(Colors.Grey.Darken1)
                        row.ConstantItem(2.5, Unit.Centimetre).Text(Sub(x)
                            x.Span("Pág. ").FontSize(7)
                            x.CurrentPageNumber().FontSize(7)
                            x.Span(" / ").FontSize(7)
                            x.TotalPages().FontSize(7)
                        End Sub)
                    End Sub)
                End Sub)

            End Sub)
        End Sub).GeneratePdf(destino)
    End Sub

End Class
