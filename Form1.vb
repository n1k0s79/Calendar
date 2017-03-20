Imports Calendar.Documents
Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim sfd As New SaveFileDialog()
        sfd.FileName = "Calendar_" & nmYear.Value.ToString
        sfd.DefaultExt = "pdf"
        sfd.Filter = "PDF files|*.pdf"
        If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
            IO.File.Delete(sfd.FileName)
            ProduceCalendar(sfd.FileName)
            Process.Start(sfd.FileName)
        End If
    End Sub

    Private Sub ProduceCalendar(Filename$)

        Dim d As New Document("Ημερολόγιο - κρατήσεις", Template.Default_("", ""), , nmYear.Value.ToString, "Κέντρο Κονταρός", , ) ' New TiSoft.DocumentElements.Image(Image.FromFile("c:\temp\_default.jpg"), 25))
        d.IncludeTotalPageInNumbering = True
        Dim Heading0 As New Style("Heading1", Style.StyleType.Heading1, "Arial", 40, Style.HorizontalAlignments.Center)
        d.Styles.Add(Heading0)
        Dim Heading1 As Style = d.GetStyle(Style.StyleType.Heading1)


        Dim Cover As New Cover("Κέντρο Κονταρός")
        For i% = 1 To 5
            Cover.Content.Add(New Paragraph(" ", Heading0, Style.HorizontalAlignments.Center))
        Next
        'Cover.ForceEvenPageCount = True
        Cover.Content.Add(New Paragraph("Κέντρο Κονταρός", Heading0))
        Cover.Content.Add(New Paragraph(" ", Heading0))
        Cover.Content.Add(New Paragraph("Ημερολόγιο " & CInt(nmYear.Value).ToString, Heading0))
        d.Sections.Add(Cover)

        Dim Plain As Style = d.GetStyle(Style.StyleType.Plain)
        For nMonth% = 1 To 12

            Dim MonthDate As New Date(2016, nMonth, 1)
            Dim MonthCover As New Section(MonthName(nMonth))
            MonthCover.ForceEvenPageCount = True
            ' προσθέτω το όνομα του μήνα
            For i% = 1 To 10
                MonthCover.Content.Add(New Paragraph(" ", Heading1))
            Next
            MonthCover.Content.Add(New Paragraph(MonthName(nMonth) & " " & CInt(nmYear.Value).ToString, Heading0, Style.HorizontalAlignments.Center))
            d.Sections.Add(MonthCover)

            Dim monthSection As New Section("MonthDays")
            monthSection.ForceEvenPageCount = True
            ' προσθέτω τις μέρες του μήνα
            Dim n As New Date(CInt(nmYear.Value), nMonth, 1)
            Dim daysInMonth% = 0

            'Dim Counter% = 1
            Do While n.Month = nMonth
                monthSection.Content.Add(New Paragraph(n.ToLongDateString, Heading1))

                Select Case n.DayOfWeek
                    Case DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday
                        For i% = 0 To 2
                            monthSection.Content.Add(New Paragraph(" ", Heading1))
                        Next
                    Case Else
                        monthSection.Content.Add(New PageBreak)
                End Select

                'Dim tomorrow = n.AddDays(1)
                'If Counter Mod 3 = 0 AndAlso n.Month = tomorrow.Month Then
                '    MonthDays.Content.Add(New PageBreak)
                'Else
                '    For i% = 0 To 5
                '        MonthDays.Content.Add(New Paragraph(" ", Heading1))
                '    Next
                'End If
                'Counter += 1
                n = n.AddDays(1)
                daysInMonth += 1
            Loop
            'If daysInMonth Mod 2 = 1 Then monthSection.Content.Add(New PageBreak)

            d.Sections.Add(monthSection)
        Next
        Dim a As New PDFConverter("", "", My.Application.TempFilesCollection)
        a.WriteToFile(d, Filename)
    End Sub

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IO.Directory.Exists(My.Application.TempFilesCollection.TempDir) Then IO.Directory.CreateDirectory(My.Application.TempFilesCollection.TempDir)
        nmYear.Value = Now.Year + 1
    End Sub
End Class
