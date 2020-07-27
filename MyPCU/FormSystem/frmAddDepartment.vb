Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.IO
Imports DevExpress.XtraEditors
Imports ComponentOwl.BetterListView
Public Class frmAddDepartment
    Dim tmpID As String = ""
    Private Sub frmAddDepartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowClinic()

        If vClinicSelect <> "" Then
            Dim ds As DataSet
            ds = clsdataBus.Lc_Business.SELECT_TABLE(" CLINIC_CODE,CLINIC_SUB_DESC,IFNULL(MAIN_CODE ,'') AS MAIN_CODE", "  l_clinic_hosp ", " WHERE CLINIC_CODE = '" & vClinicSelect & "' ")
            If ds.Tables(0).Rows.Count > 0 Then
                lblClinic.Text = ds.Tables(0).Rows(0).Item("MAIN_CODE")
                cboClinic.EditValue = lblClinic.Text
                txtSubClinic.Text = ds.Tables(0).Rows(0).Item("CLINIC_SUB_DESC")
            End If
        End If
    End Sub

    Private Sub ShowClinic()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE(" CLINIC_CODE,CLINIC_DESC ", "  l_clinic ", "WHERE STATUS = '1' ")

        If ds.Tables(0).Rows.Count > 0 Then
            With cboClinic
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "CLINIC_DESC"
                .Properties.ValueMember = "CLINIC_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
    End Sub

    Private Sub cboClinic_EditValueChanged(sender As Object, e As EventArgs) Handles cboClinic.EditValueChanged
        lblClinic.Text = cboClinic.EditValue
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        If lblClinic.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดแผนกก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If txtSubClinic.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดแผนกย่อยก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim tmpStatus As String = ""
        If chkStatus.Checked = True Then
            tmpStatus = "0"
        Else
            tmpStatus = "1"
        End If
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)

        If vClinicSelect <> "" Then
            clsbusent.Lc_BusinessEntity.Updatem_table("l_clinic_hosp", "MAIN_CODE = '" & lblClinic.Text & "',CLINIC_DESC = '" & cboClinic.Text & "', CLINIC_SUB_DESC = '" & txtSubClinic.Text & "',STATUS = '" & tmpStatus & "',D_UPDATE = '" & tmpNow & "',USER_REC = '" & vUSERID & "'", " CLINIC_CODE  = '" & vClinicSelect & "'")
        Else
            GenID()
            clsbusent.Lc_BusinessEntity.Insertm_table("l_clinic_hosp (CLINIC_CODE,CLINIC_DESC,CLINIC_SUB_DESC,STATUS,USER_REC,D_UPDATE,MAIN_CODE)",
        "'" & tmpID & "','" & cboClinic.Text & "','" & txtSubClinic.Text & "','" & tmpStatus & "','" & vUSERID & "','" & tmpNow & "','" & lblClinic.Text & "'")

        End If

        XtraMessageBox.Show(msSave, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub
    Private Sub GenID()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE(" CLINIC_CODE", "  l_clinic_hosp ", "WHERE MAIN_CODE = '" & lblClinic.Text & "' ")
        If ds.Tables(0).Rows.Count > 0 Then
            tmpID = lblClinic.Text & CInt(ds.Tables(0).Rows.Count).ToString("00")
        Else
            tmpID = lblClinic.Text & "00"
        End If
    End Sub
End Class