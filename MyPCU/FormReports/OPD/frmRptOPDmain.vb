Imports DevExpress.XtraBars.Docking
Public Class frmRptOPDMain
    Private Sub AccordionControlElement1_Click(sender As Object, e As EventArgs) Handles AccordionControlElement1.Click


    End Sub

    Private Sub AccordionControlElement3_Click(sender As Object, e As EventArgs) Handles AccordionControlElement3.Click
        Dim panel1 As DockPanel = DockManager1.AddPanel(DockingStyle.Right)
        panel1.DockedAsTabbedDocument = True
        panel1.Text = "รายงานแสดงอันดับการให้รหัส ICD10"

        Dim f As New frmDiseaseOrder
        f.TopLevel = False
        f.FormBorderStyle = FormBorderStyle.None
        f.Dock = DockStyle.Fill
        panel1.Controls.Add(f)
        f.Show()
    End Sub


End Class
