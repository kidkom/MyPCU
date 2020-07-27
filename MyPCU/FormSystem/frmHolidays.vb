Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.IO
Imports DevExpress.XtraEditors
Public Class frmHolidays
    Dim tmpUpdate As Boolean = False
    Private Sub frmHolidays_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 4)

        Dim dsh As DataSet
        dsh = clsdataBus.Lc_Business.SELECT_TABLE("FLAG_HOLIDAY,REMARK", " l_holidays ", " WHERE DATE_HOLIDAY = '" & tmpNow & "'")
        If dsh.Tables(0).Rows.Count > 0 Then
            If dsh.Tables(0).Rows(0).Item("FLAG_HOLIDAY").ToString = "0" Then
                chk0.Checked = True
            Else
                chk1.Checked = True
            End If
            txtRemark.Text = dsh.Tables(0).Rows(0).Item("REMARK").ToString
            tmpUpdate = True
        End If

    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Dim tmpToday As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 4)
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)
        Dim tmpFlag As String = ""
        If chk0.Checked = True Then
            tmpFlag = "0"
        Else
            tmpFlag = "1"
        End If
        vHoliday = tmpFlag
        If tmpUpdate = False Then
            clsbusent.Lc_BusinessEntity.Insertm_table("l_holidays (DATE_HOLIDAY,FLAG_HOLIDAY,REMARK,USER_REC,D_UPDATE)", "'" & tmpToday & "','" & tmpFlag & "','" & txtRemark.Text & "','" & vUSERID & "','" & tmpNow & "'")
            tmpUpdate = True
            XtraMessageBox.Show(msSave, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            clsbusent.Lc_BusinessEntity.Updatem_table("l_holidays", "FLAG_HOLIDAY = '" & tmpFlag & "',REMARK = '" & txtRemark.Text & "',USER_REC = '" & vUSERID & "',D_UPDATE = '" & tmpNow & "'", " DATE_HOLIDAY = '" & tmpToday & "'")
            XtraMessageBox.Show(msSave, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If

    End Sub

    Private Sub chk0_Click(sender As Object, e As EventArgs) Handles chk0.Click
        chk0.Checked = True
        chk1.Checked = False
    End Sub

    Private Sub chk1_Click(sender As Object, e As EventArgs) Handles chk1.Click
        chk0.Checked = False
        chk1.Checked = True
    End Sub
End Class