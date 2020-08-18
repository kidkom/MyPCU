Imports DevExpress.XtraBars.Docking
Public Class frmRptDenMain
    Private Sub frmRptDenMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub AccordionControlElement2_Click(sender As Object, e As EventArgs) Handles AccordionControlElement2.Click

        Dim panel1 As DockPanel = DockManager1.AddPanel(DockingStyle.Right)
        panel1.DockedAsTabbedDocument = True
        panel1.Text = "รายงานสรุปข้อมูลทันตกรรม (ประกันสุขภาพถ้วนหน้า)"

        Dim f As New frmRptDentUC
        f.TopLevel = False
        f.FormBorderStyle = FormBorderStyle.None
        f.Dock = DockStyle.Fill
        panel1.Controls.Add(f)
        f.Show()
    End Sub


End Class

