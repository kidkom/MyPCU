Imports clsDataAcc8 = MyPCU.ClsDataAccess8
Imports clsdataBus8 = MyPCU.ClsBusiness8
Imports clsbusent8 = MyPCU.ClsBusinessEntity8
Imports clsdataBus = MyPCU.ClsBusiness
Imports System.DateTime
Imports System.Globalization
Imports MySql.Data.MySqlClient
Imports System.IO
Imports DevExpress.XtraEditors
Public Class frmAssetDecline
    Dim tmpAssetID As String = ""
    Dim tmpID As String = ""
    Dim tmpROWID As String = ""
    Dim tmpUpdate As Boolean = False
    Private Sub frmAssetDecline_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblASSET_CODE_ID.Text = picCODE
        txtASSET_NAME.Text = PicNAME
        DateEdit1.EditValue = Now
        tmpAssetID = picAssetCODE
        tmpID = PicID
        ShowData()
    End Sub
    Private Sub ShowData()
        Dim ds2 As DataSet
        ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("*", " m_assets_fix ", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "' AND ASSET_STATUS = '0' AND STATUS_AF = '1' ")
        If ds2.Tables(0).Rows.Count > 0 Then
            tmpUpdate = True
            cmdDel.Enabled = True
            tmpROWID = ds2.Tables(0).Rows(0).Item("ROWID")
            DateEdit1.EditValue = DateTime.ParseExact(ds2.Tables(0).Rows(0).Item("DATE_IN").ToString.Substring(0, 4) + 543 & ds2.Tables(0).Rows(0).Item("DATE_IN").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("dd/MM/yyyy")
            txtDETAIL.Text = ds2.Tables(0).Rows(0).Item("DETAIL")

        End If
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If DateEdit1.EditValue = Nothing Then
            XtraMessageBox.Show("กรุณาวันที่บันทึกก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            DateEdit1.Select()
            Exit Sub
        End If

        If txtDETAIL.Text = "" Then
            XtraMessageBox.Show("กรุณาบันทึกรายละเอียดก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDETAIL.Select()
            Exit Sub
        End If


        Dim DATE_IN As String = CDate(DateEdit1.EditValue).ToString("yyyyMMdd")
        DATE_IN = DATE_IN.ToString.Substring(0, 4) - 543 & DATE_IN.ToString.Substring(4, 4)
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate()

        If tmpUpdate = False Then
            clsbusent8.Lc_BusinessEntity8.InsertM_table("m_assets_fix (ASSET_ID,ID,ASSET_STATUS,DATE_IN,DETAIL,BUDGETTYPE,PRICE,USER_REC,D_UPDATE,STATUS_AF,STATUS_SEND,DOC_NO)",
            "'" & tmpAssetID & "','" & tmpID & "','0','" & DATE_IN & "','" & txtDETAIL.Text & "','','0.00','" & vUSERID & "','" & tmpNow & "','1','0',''")
            clsbusent8.Lc_BusinessEntity8.UpdateM_table("m_assets", " STATUS_AF = '4',USER_REC = '" & vUSERID & "',D_UPDATE = '" & tmpNow & "'", "  ASSET_CODE_ID = '" & tmpAssetID & "' AND ASSET_ID  = '" & tmpID & "'")
        Else
            clsbusent8.Lc_BusinessEntity8.UpdateM_table("m_assets_fix", " DATE_IN = '" & DATE_IN & "',DETAIL = '" & txtDETAIL.Text & "',USER_REC = '" & vUSERID & "',D_UPDATE = '" & tmpNow & "',STATUS_SEND = '0'", "  ROWID  = '" & tmpROWID & "'")

        End If
        XtraMessageBox.Show("บันทึกการจำหน่ายเรียบร้อยแล้ว", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Sub cmdDel_Click(sender As Object, e As EventArgs) Handles cmdDel.Click
        If XtraMessageBox.Show("ต้องการยกเลิกการจำหน่ายใช่หรือไม่?", vProgram, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate()
            clsbusent8.Lc_BusinessEntity8.UpdateM_table("m_assets_fix", " STATUS_SEND = '0',STATUS_AF = '0',USER_REC = '" & vUSERID & "',D_UPDATE = '" & tmpNow & "'", "  ROWID  = '" & tmpROWID & "'")
            clsbusent8.Lc_BusinessEntity8.UpdateM_table("m_assets", "STATUS_SEND = '0', STATUS_AF = '1',USER_REC = '" & vUSERID & "',D_UPDATE = '" & tmpNow & "'", "  ASSET_CODE_ID = '" & tmpAssetID & "' AND ASSET_ID  = '" & tmpID & "'")
            Me.Close()
        End If
    End Sub

End Class