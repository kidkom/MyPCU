Public Class frmVaccineMain



    Private Sub frmVaccineMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub AccordionControlElement4_Click(sender As Object, e As EventArgs) Handles AccordionControlElement4.Click
        Dim f As New frmVaccineCode
        f.ShowDialog()
    End Sub
End Class
