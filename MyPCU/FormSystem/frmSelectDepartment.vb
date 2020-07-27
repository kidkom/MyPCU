Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.IO
Imports DevExpress.XtraEditors
Imports MadMilkman.Ini
Public Class frmSelectDepartment

    Private Sub frmSelectDepartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowClinic()

        Try
            Dim filePath = Application.StartupPath & "\config.ini"
            Dim file As New IniFile()
            file.Load(filePath)

            lblClinic.Text = file.Sections("Clinic").Keys("Department").Value
            cboClinic.EditValue = lblClinic.Text
            If file.Sections("Clinic").Keys("Show").Value = "1" Then
                chkClinicShow.Checked = True
            Else
                chkClinicShow.Checked = False
            End If

        Catch ex As Exception

        End Try


    End Sub
    Private Sub ShowClinic()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE(" CLINIC_CODE,CONCAT('[',CLINIC_CODE,'] ',CLINIC_SUB_DESC) AS CLINIC_SUB_DESC ", "  l_clinic_hosp ", "WHERE STATUS = '1' ")

        If ds.Tables(0).Rows.Count > 0 Then
            With cboClinic
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "CLINIC_SUB_DESC"
                .Properties.ValueMember = "CLINIC_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        If lblClinic.Text = "" Then
            XtraMessageBox.Show("กำหนดแผนกก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim tmpClinicShow As String = ""

        If chkClinicShow.Checked = True Then
            tmpClinicShow = "1"
        Else
            tmpClinicShow = "0"
        End If

        Dim filePath = Application.StartupPath & "\config.ini"
        Dim file2 As New IniFile()
        If File.Exists(filePath) = True Then
            file2.Load(filePath)
        End If

        file2.Sections.Remove("Clinic")
        Dim section As IniSection = file2.Sections.Add("Clinic")

        Dim key As IniKey = file2.Sections("Clinic").Keys.Add("Department", lblClinic.Text)
        Dim key2 As IniKey = file2.Sections("Clinic").Keys.Add("Show", tmpClinicShow)

        file2.Save(filePath)
        vClinic = lblClinic.Text

        Me.Close()
    End Sub

    Private Sub cboClinic_EditValueChanged(sender As Object, e As EventArgs) Handles cboClinic.EditValueChanged
        lblClinic.Text = cboClinic.EditValue
    End Sub
End Class