Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsdataBus = MyPCU.ClsBusiness
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports DevExpress.XtraEditors
Public Class frmChangPassword

    Private Sub cmdLogin_Click(sender As Object, e As EventArgs) Handles cmdLogin.Click
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("USER_ID", " l_user", " WHERE USER_ID = '" & vUSERID & "' AND PASSWORD = '" & Encode(txtPassword.Text.ToLower) & "' AND STATUS = '1' ")

        If ds.Tables(0).Rows.Count = 0 Then
            XtraMessageBox.Show("รหัสผ่านเดิมไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Select()
            txtPassword.SelectAll()
            Exit Sub
        End If

        If txtPasswordNew.Text = "" Then
            XtraMessageBox.Show("กำหนดรหัสผ่านใหม่ก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPasswordNew.Select()
            Exit Sub
        End If

        If txtPasswordNew.Text <> txtPasswordNew2.Text Then
            XtraMessageBox.Show("กำหนดรหัสผ่านใหม่ให้ตรงกัน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPasswordNew2.Select()
            txtPasswordNew2.SelectAll()
            Exit Sub
        End If


        Dim tmpPassword As String = Encode(txtPasswordNew.Text.ToLower)
        clsbusent.Lc_BusinessEntity.Updatem_table("l_user", "PASSWORD = '" & tmpPassword & "'", " USER_ID = '" & vUSERID & "'")

        XtraMessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Sub cmdCancle_Click(sender As Object, e As EventArgs) Handles cmdCancle.Click
        Me.Close()
    End Sub
    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim ds As DataSet
            ds = clsdataBus.Lc_Business.SELECT_TABLE("USER_ID", " l_user", " WHERE USER_ID = '" & vUSERID & "' AND PASSWORD = '" & Encode(txtPassword.Text.ToLower) & "' AND STATUS = '1' ")

            If ds.Tables(0).Rows.Count = 0 Then
                XtraMessageBox.Show("รหัสผ่านเดิมไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Select()
                txtPassword.SelectAll()
                Exit Sub
            Else
                txtPasswordNew.Select()
            End If
        End If
    End Sub

    Private Sub txtPasswordNew_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPasswordNew.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPasswordNew2.Select()
        End If
    End Sub

    Private Sub txtPasswordNew2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPasswordNew2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPasswordNew.Text <> txtPasswordNew2.Text Then
                XtraMessageBox.Show("กำหนดรหัสผ่านใหม่ให้ตรงกัน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPasswordNew2.Select()
                txtPasswordNew2.SelectAll()
                Exit Sub
                cmdLogin.Focus()
            End If
        End If
    End Sub
End Class