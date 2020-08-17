Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Globalization
Imports System.IO
Imports DevExpress.XtraEditors
Public Class frmReferInEdit
    Private Sub frmReferInEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CauseIn()
        txtHospin.Select()
    End Sub

    Private Sub bntHospName_Click(sender As Object, e As EventArgs) Handles bntHospName.Click
        Dim f As New frmHospSearch
        f.ShowDialog()
        If vTmpHcode <> "" Then
            txtHospin.Text = vTmpHcode
            bntHospName.Text = ClsBusiness.Lc_Business.SELECT_NAME_HOSPITAL(txtHospin.Text)
        End If
        vTmpHcode = ""
        txtREFER_NO.Select()
    End Sub
    Private Sub CauseIn()
        Dim ds6 As DataSet
        ds6 = ClsBusiness.Lc_Business.SELECT_TABLE("CAUSEIN_DESC,CAUSEIN_CODE", "l_causein", "")
        If ds6.Tables(0).Rows.Count > 0 Then
            With cboCauseIn
                .Properties.DataSource = ds6.Tables(0)
                .Properties.DisplayMember = "CAUSEIN_DESC"
                .Properties.ValueMember = "CAUSEIN_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
    End Sub
    Private Sub txtHospin_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHospin.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                txtCauseIn.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtHospin_Leave(sender As Object, e As EventArgs) Handles txtHospin.Leave
        If txtHospin.Text <> "" Then
            bntHospName.Text = ClsBusiness.Lc_Business.SELECT_NAME_HOSPITAL(txtHospin.Text)
            If bntHospName.Text = "" And txtHospin.Text <> "" Then
                XtraMessageBox.Show(mDataMiss, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtHospin.Select()
                txtHospin.SelectAll()
            Else
                txtCauseIn.Select()
            End If
        End If

    End Sub

    Private Sub txtCauseIn_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCauseIn.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboCauseIn.EditValue = txtCauseIn.Text
            txtREFER_NO.Select()
        End If
    End Sub

    Private Sub cboCauseIn_EditValueChanged(sender As Object, e As EventArgs) Handles cboCauseIn.EditValueChanged
        txtCauseIn.Text = cboCauseIn.EditValue
    End Sub

    Private Sub txtCauseIn_Leave(sender As Object, e As EventArgs) Handles txtCauseIn.Leave
        If txtCauseIn.Text <> "" Then
            cboCauseIn.EditValue = txtCauseIn.Text
            If cboCauseIn.Text = "" Then
                XtraMessageBox.Show(mDataMiss, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtCauseIn.Select()
                txtCauseIn.SelectAll()
            End If

        End If
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        If chkCancel.Checked = False Then
            If chkReferInType3.Checked = True Then
                vReferinType = "3"
            Else
                vReferinType = "4"
            End If

            vReferinCause = txtCauseIn.Text

            If txtHospin.Text <> "" Then
                vReferinHosp = txtHospin.Text
            Else
                vReferinHosp = ""
            End If

            vReferinNo = txtREFER_NO.Text

            If DateEdit1.EditValue IsNot Nothing Then
                vReferinDateExpire = CDate(DateEdit1.EditValue).ToString("yyyyMMdd", System.Globalization.CultureInfo.GetCultureInfo("en-US"))
            Else
                vReferinDateExpire = ""
            End If

        Else
            vReferinType = ""
            vReferinHosp = ""
            vReferinCause = ""
            vReferinNo = ""
            vReferinDateExpire = ""

        End If

        Me.Close()
    End Sub

    Private Sub chkReferInType3_Click(sender As Object, e As EventArgs) Handles chkReferInType3.Click
        chkReferInType3.Checked = True
        chkReferInType4.Checked = False
        txtHospin.Enabled = True
        bntHospName.Enabled = True
    End Sub
    Private Sub chkReferInType4_Click(sender As Object, e As EventArgs) Handles chkReferInType4.Click
        chkReferInType3.Checked = False
        chkReferInType4.Checked = True
        txtHospin.Enabled = False
        bntHospName.Enabled = False
        txtHospin.Text = ""
        bntHospName.Text = ""
    End Sub
End Class