Public Class frmPDFviewer 

    Private Sub frmPdfViewer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.PdfViewer1.Dispose()
    End Sub

    Private Sub frmPdfViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If vPDFform <> "1" And vPDFform <> "2" Then
            Me.PdfViewer1.LoadDocument(Application.StartupPath & "\PDF\document.pdf")
        ElseIf vPDFform = "2" Then
            Me.PdfViewer1.LoadDocument(Application.StartupPath & "\Doc\manualnumber1.pdf")
        End If

    End Sub
End Class