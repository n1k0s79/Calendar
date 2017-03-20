Option Strict On
Option Explicit On

Namespace My

    ' Προσθέτει (με Partial) στην κλάση MyApplication λειτουργικότητα για να επιστρέφει τα μονοπάτια συχνά χρησμιοποιούμενων φακέλων
    Partial Class MyApplication

        Public ReadOnly Property Language As String
            Get
                Return String.Empty
            End Get
        End Property

        Private _TempFilesManager As System.CodeDom.Compiler.TempFileCollection

        Public ReadOnly Property Name As String
            Get
                Return "Calendar"
            End Get
        End Property

        Public ReadOnly Property TempFilesCollection As System.CodeDom.Compiler.TempFileCollection
            Get
                If _TempFilesManager Is Nothing Then
                    Dim TmpFolder$ = System.IO.Path.Combine(System.IO.Path.GetTempPath, My.Application.Name)
                    _TempFilesManager = New System.CodeDom.Compiler.TempFileCollection(TmpFolder)
                End If
                Return _TempFilesManager
            End Get
        End Property

    End Class
End Namespace
