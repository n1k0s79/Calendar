'Imports Calendar.Documents

'Public Class CalendarMonth
'    Inherits Documents.Document

'    Private _Year%
'    Private _Month%

'    Public Overrides Function Content() As System.Collections.Generic.List(Of Documents.Element)
'        Dim ret As New List(Of Element)

'        Dim HeadingStyle As Style = _Theme.TextStyleByName("Heading1")
'        HeadingStyle.HorizontalAlignment = TiSoft.DocumentElements.HorizontalAlignment.Center
'        HeadingStyle.Font.Size = 28
'        HeadingStyle.Font.Bold = True
'        HeadingStyle.SpacingBefore = 0.4
'        HeadingStyle.SpacingAfter = 0.4

'        'ret.Add(New TiSoft.DocumentElements.Paragraph(_Title, HeadingStyle))



'        Dim p As New TiSoft.DocumentElements.Paragraph(TiSoft.Calendar.GetMonthNameGreek2(_Month) & " " & _Year, HeadingStyle)
'        p.Style.HorizontalAlignment = TiSoft.DocumentElements.HorizontalAlignment.Center
'        ret.Add(p)
'        ret.Add(New TiSoft.DocumentElements.PageBreak)
'        Dim n As New Date(_Year, _Month, 1)
'        Do While n.Month = _Month
'            'ret.Add(New TiSoft.DocumentElements.Image("c:\temp\month.jpg", 80))
'            ret.Add(New TiSoft.DocumentElements.Paragraph(n.ToLongDateString, TiSoft.DocumentElements.TextStyle.Heading1))
'            ret.Add(New TiSoft.DocumentElements.PageBreak)
'            n = n.AddDays(1)
'        Loop



'        Return ret
'    End Function

'    Public Overrides Sub InitializeSection()
'        OddPageHeaderFooter = TiSoft.DocumentElements.HeaderFooter.ReportOddPageHeaderFooter(Me.Document.Theme, , , "Ημερολόγιο - κρατήσεις", , , TiSoft.Calendar.GetMonthNameGreek2(_Month) & " " & _Year)
'        EvenPageHeaderFooter = TiSoft.DocumentElements.HeaderFooter.ReportOddPageHeaderFooter(Me.Document.Theme, , , "Κέντρο Κονταρός ", , , TiSoft.Calendar.GetMonthNameGreek2(_Month) & " " & _Year)
'    End Sub

'    Public Overrides ReadOnly Property Title As String
'        Get
'            Return "Calendar"
'        End Get
'    End Property

'    Public Sub New(Year%, Month%)
'        _Year = Year
'        _Month = Month
'    End Sub
'End Class
