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

        ' Montar lista de pares [data_hora formatada, temperatura] a partir do DataTable, ordenando estritamente por DateTime real
        Dim listaTemp As New List(Of Tuple(Of DateTime, String, String))()
        For Each row As DataRow In dados.Rows
            Dim dtVal As DateTime
            Dim dhStr As String = If(row.Table.Columns.Contains("data_hora") AndAlso row("data_hora") IsNot DBNull.Value, row("data_hora").ToString(), "")
            Dim fmtStr As String = If(row.Table.Columns.Contains("data_hora_fmt") AndAlso row("data_hora_fmt") IsNot DBNull.Value, row("data_hora_fmt").ToString(), "")
            
            If Not DateTime.TryParse(dhStr, dtVal) Then
                DateTime.TryParse(fmtStr, dtVal)
            End If
            
            If String.IsNullOrWhiteSpace(fmtStr) Then
                fmtStr = dtVal.ToString("dd/MM/yyyy HH:mm")
            End If
            
            Dim tempVal As Double = 0.0
            If row.Table.Columns.Contains("temperatura") AndAlso row("temperatura") IsNot DBNull.Value Then
                Double.TryParse(row("temperatura").ToString(), tempVal)
            End If
            
            listaTemp.Add(New Tuple(Of DateTime, String, String)(dtVal, fmtStr, tempVal.ToString("F1")))
        Next

        ' Ordenação cronológica garantida por DateTime real
        listaTemp = listaTemp.OrderBy(Function(x) x.Item1).ToList()

        Dim leituras As New List(Of String())()
        For Each item In listaTemp
            leituras.Add(New String() {item.Item2, item.Item3})
        Next

        ' Calcular nLinha (colunas por página) dinamicamente baseando-se no total de registros.
        ' 38 registros cabem verticalmente em uma página A4 sob o cabeçalho/rodapé.
        Dim nLinha As Integer = 1
        Dim totalRegistros = leituras.Count
        Dim maxRowsPerPage = 42
        
        If totalRegistros <= maxRowsPerPage Then
            nLinha = 1
        ElseIf totalRegistros <= maxRowsPerPage * 2 Then
            nLinha = 2
        ElseIf totalRegistros <= maxRowsPerPage * 3 Then
            nLinha = 3
        Else
            nLinha = 4
        End If

        Dim cfg      = _config
        Dim dadosPdf = leituras
        Dim nSensor  = nomeSensor
        Dim dtIni    = dataInicio
        Dim dtFim2   = dataFim

        Dim total = dadosPdf.Count
        Dim pageSize = nLinha * maxRowsPerPage
        Dim totalPages = Math.Max(1, CInt(Math.Ceiling(total / CDbl(pageSize))))

        Document.Create(Sub(container)
            For p = 0 To totalPages - 1
                Dim pageIdx = p
                Dim startIdx = pageIdx * pageSize
                Dim countOnPage = Math.Min(total - startIdx, pageSize)

                container.Page(Sub(page)
                    page.Size(PageSizes.A4)
                    page.Margin(1.5, Unit.Centimetre)
                    page.DefaultTextStyle(Function(x) x.FontSize(8).FontFamily("Arial"))

                    ' Cabeçalho da Folha
                    page.Header().Column(Sub(col)
                        col.Item().Row(Sub(row)
                            Dim logoBytes = ObterLogoBytes()
                            If logoBytes IsNot Nothing Then
                                row.ConstantItem(2.5, Unit.Centimetre).Image(logoBytes)
                                row.ConstantItem(0.4, Unit.Centimetre)
                            ElseIf File.Exists(cfg.LogoPath) Then
                                row.ConstantItem(2.5, Unit.Centimetre).Image(cfg.LogoPath)
                                row.ConstantItem(0.4, Unit.Centimetre)
                            End If
                            row.RelativeItem().Column(Sub(c)
                                c.Item().Text(cfg.NomeCliente).FontSize(13).Bold().FontColor(Color.FromRGB(30, 64, 115))
                                c.Item().Text(cfg.NomeInstalacao).FontSize(9).FontColor(Colors.Grey.Darken2)
                                c.Item().Text("Sensor: " & nSensor).FontSize(9).Bold()
                            End Sub)
                            row.ConstantItem(4.5, Unit.Centimetre).Column(Sub(c)
                                c.Item().Text("De: " & dtIni.ToString("dd/MM/yyyy HH:mm"))
                                c.Item().Text("Até: " & dtFim2.ToString("dd/MM/yyyy HH:mm"))
                                c.Item().Text("Total: " & dadosPdf.Count.ToString("N0") & " registros")
                            End Sub)
                        End Sub)
                        col.Item().PaddingTop(4).LineHorizontal(1).LineColor(Color.FromRGB(30, 64, 115))
                    End Sub)

                    ' Conteúdo da Tabela da Folha
                    page.Content().PaddingVertical(6).Table(Sub(tbl)
                        Dim azul   = Color.FromRGB(30, 64, 115)
                        Dim corSep = Color.FromRGB(120, 145, 185)
                        Dim sepHdr = Color.FromRGB(180, 200, 230)

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

                        Dim alterno = False

                        ' Preenche estritamente as linhas desta folha específica (Coluna 0 -> Coluna 1 -> Coluna 2 -> Coluna 3)
                        For r = 0 To maxRowsPerPage - 1
                            Dim temItemNaLinha As Boolean = False
                            For col = 0 To nLinha - 1
                                Dim posNaPag = col * maxRowsPerPage + r
                                If posNaPag < countOnPage Then
                                    temItemNaLinha = True
                                    Exit For
                                End If
                            Next
                            If Not temItemNaLinha Then Exit For

                            Dim bg = If(alterno, Color.FromRGB(240, 245, 255), Colors.White)
                            alterno = Not alterno

                            For col = 0 To nLinha - 1
                                Dim itemIdx = startIdx + col * maxRowsPerPage + r
                                Dim posNaPag = col * maxRowsPerPage + r

                                If itemIdx < total AndAlso posNaPag < countOnPage Then
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
                    End Sub)

                    ' Rodapé da Folha
                    page.Footer().Column(Sub(col)
                        col.Item().LineHorizontal(0.5).LineColor(Colors.Grey.Medium)
                        col.Item().Row(Sub(row)
                             Dim textoFooter = cfg.FooterTexto
                             textoFooter = textoFooter.Replace(" | Gerado em {DATA} | {HORA}", "")
                             textoFooter = textoFooter.Replace(" | {DATA} | {HORA}", "")
                             textoFooter = textoFooter.Replace("{DATA}", "")
                             textoFooter = textoFooter.Replace("{HORA}", "")
                             row.RelativeItem().Text(textoFooter).FontSize(7).FontColor(Colors.Grey.Darken1)
                            row.ConstantItem(2.5, Unit.Centimetre).Text(Sub(x)
                                x.Span("Pág. ").FontSize(7)
                                x.Span((pageIdx + 1).ToString()).FontSize(7)
                                x.Span(" / ").FontSize(7)
                                x.Span(totalPages.ToString()).FontSize(7)
                            End Sub)
                        End Sub)
                    End Sub)
                End Sub)
            Next
        End Sub).GeneratePdf(destino)
    End Sub

End Class
