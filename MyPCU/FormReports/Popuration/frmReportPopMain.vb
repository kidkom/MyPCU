Imports DevExpress.XtraBars.Docking
Public Class frmReportPopMain
    Private Sub AccordionControlElement1_Click(sender As Object, e As EventArgs) Handles AccordionControlElement1.Click
        Dim panel1 As DockPanel = DockManager1.AddPanel(DockingStyle.Right)
        panel1.DockedAsTabbedDocument = True
        panel1.Text = "รายงานจำนวนประชากรแยกตามกลุ่มอายุและเพศ"

        Dim f As New frmPopPypamid
        f.TopLevel = False
        f.FormBorderStyle = FormBorderStyle.None
        f.Dock = DockStyle.Fill
        panel1.Controls.Add(f)
        f.Show()

    End Sub

    Private Sub AccordionControlElement2_Click(sender As Object, e As EventArgs) Handles AccordionControlElement2.Click
        Dim panel1 As DockPanel = DockManager1.AddPanel(DockingStyle.Right)
        panel1.DockedAsTabbedDocument = True
        panel1.Text = "รายงานจำนวนประชากรแยกตามวันเกิด"

        Dim f As New frmSearchPersonBirth
        f.TopLevel = False
        f.FormBorderStyle = FormBorderStyle.None
        f.Dock = DockStyle.Fill
        panel1.Controls.Add(f)
        f.Show()
    End Sub

    Private Sub AccordionControlElement4_Click(sender As Object, e As EventArgs) Handles AccordionControlElement4.Click
        Dim panel1 As DockPanel = DockManager1.AddPanel(DockingStyle.Right)
        panel1.DockedAsTabbedDocument = True
        panel1.Text = "รายงานจำนวนประชากรแยกตามสถานะการอยู่อาศัย"

        Dim f As New frmPerson_TypeArea
        f.TopLevel = False
        f.FormBorderStyle = FormBorderStyle.None
        f.Dock = DockStyle.Fill
        panel1.Controls.Add(f)
        f.Show()
    End Sub
End Class
