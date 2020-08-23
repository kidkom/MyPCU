Imports DevExpress.XtraBars.Docking

Public Class frmRptThaimedMain
    Private Sub AccordionControlElement2_Click(sender As Object, e As EventArgs) Handles AccordionControlElement2.Click
        Dim panel1 As DockPanel = DockManager1.AddPanel(DockingStyle.Right)
        panel1.DockedAsTabbedDocument = True
        panel1.Text = "รายงานมูลค่าการใช้ยาแพทย์แผนไทย"

        Dim f As New frmThaiDrugCost
        f.TopLevel = False
        f.FormBorderStyle = FormBorderStyle.None
        f.Dock = DockStyle.Fill
        panel1.Controls.Add(f)
        f.Show()
    End Sub

    Private Sub AccordionControlElement3_Click(sender As Object, e As EventArgs) Handles AccordionControlElement3.Click

        Dim panel1 As DockPanel = DockManager1.AddPanel(DockingStyle.Right)
        panel1.DockedAsTabbedDocument = True
        panel1.Text = "รายงานการให้บริการแพทย์แผนไทย (หัตถการ)"

        Dim f As New frmRptThaiProced
        f.TopLevel = False
        f.FormBorderStyle = FormBorderStyle.None
        f.Dock = DockStyle.Fill
        panel1.Controls.Add(f)
        f.Show()
    End Sub

    Private Sub AccordionControlElement1_Click(sender As Object, e As EventArgs) Handles AccordionControlElement1.Click
        Dim panel1 As DockPanel = DockManager1.AddPanel(DockingStyle.Right)
        panel1.DockedAsTabbedDocument = True
        panel1.Text = "รายงานการใช้ยาแผนไทยในการให้บริการ"

        Dim f As New frmRptDrugHerb
        f.TopLevel = False
        f.FormBorderStyle = FormBorderStyle.None
        f.Dock = DockStyle.Fill
        panel1.Controls.Add(f)
        f.Show()
    End Sub

    Private Sub AccordionControlElement4_Click(sender As Object, e As EventArgs) Handles AccordionControlElement4.Click
        vProcedSelect = "15"
        Dim panel1 As DockPanel = DockManager1.AddPanel(DockingStyle.Right)
        panel1.DockedAsTabbedDocument = True
        panel1.Text = "รายงานหัตถการแพทย์แผนไทย (กำหนดเงื่อนไขเอง)"

        Dim f As New frmRptThaiProcedSelect
        f.TopLevel = False
        f.FormBorderStyle = FormBorderStyle.None
        f.Dock = DockStyle.Fill
        panel1.Controls.Add(f)
        f.Show()
    End Sub
End Class
