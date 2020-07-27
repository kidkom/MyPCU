Imports clsDataAcc8 = MyPCU.ClsDataAccess8
Imports clsdataBus8 = MyPCU.ClsBusiness8
Imports clsbusent8 = MyPCU.ClsBusinessEntity8
Imports clsdataBus = MyPCU.ClsBusiness
Imports System.DateTime
Imports System.Globalization
Imports MySql.Data.MySqlClient
Imports System.IO
Imports DevExpress.XtraEditors
Public Class frmDelAssets
    Dim tmpAssetID As String = ""
    Dim tmpID As String = ""
    Dim tmpPicture1 As Boolean = False
    Dim tmpPicture2 As Boolean = False
    Dim tmpPicture3 As Boolean = False
    Dim tmpPicture4 As Boolean = False
    Dim tmpDateIn As String = ""
    Dim tmpDaysUsed As Integer = 0
    Dim tmpDaysExpire As Integer = 0
    Dim tmpUpdate As Boolean = False
    Dim rs As New Resizer
    Private Sub frmDelAssets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If aseetROWID <> "" Then
            ShowData()
            txtASSET_NAME.SelectionStart = txtASSET_NAME.TextLength
        End If
    End Sub
    Private Sub ShowData()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("*", "m_assets ", "  WHERE ROWID = '" & aseetROWID & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            tmpUpdate = True

            lblASSET_CODE_ID1.Text = ds.Tables(0).Rows(0).Item("GROUP_CODE")
            lblASSET_CODE_ID2.Text = ds.Tables(0).Rows(0).Item("GROUP_TYPE_CODE")
            lblASSET_CODE_ID3.Text = ds.Tables(0).Rows(0).Item("ASSET_CODE")
            lblASSET_CODE_ID4.Text = ds.Tables(0).Rows(0).Item("ASSET_ID")
            tmpAssetID = ds.Tables(0).Rows(0).Item("ASSET_CODE_ID")
            tmpID = ds.Tables(0).Rows(0).Item("ASSET_ID")
            txtASSET_NAME.Text = ds.Tables(0).Rows(0).Item("ASSET_NAME")

            ShowImages1()
            ShowImages2()
            ShowImages3()
            ShowImages4()


        End If
    End Sub
    Private Sub ShowImages1()
        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("IMG", " t_picture1 ", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            Dim lb() As Byte = ds2.Tables(0).Rows(0).Item("IMG")
            Dim ms As MemoryStream = New MemoryStream(lb)
            Dim img As Image = Image.FromStream(ms)
            PictureBox1.Image = img
            ms.Close()
        End If
    End Sub
    Private Sub ShowImages2()
        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("IMG", " t_picture2 ", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            Dim lb() As Byte = ds2.Tables(0).Rows(0).Item("IMG")
            Dim ms As MemoryStream = New MemoryStream(lb)
            Dim img As Image = Image.FromStream(ms)
            PictureBox2.Image = img
            ms.Close()
        End If
    End Sub
    Private Sub ShowImages3()
        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("IMG", " t_picture3 ", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            Dim lb() As Byte = ds2.Tables(0).Rows(0).Item("IMG")
            Dim ms As MemoryStream = New MemoryStream(lb)
            Dim img As Image = Image.FromStream(ms)
            PictureBox3.Image = img
            ms.Close()
        End If
    End Sub
    Private Sub ShowImages4()
        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("IMG", " t_picture4 ", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            Dim lb() As Byte = ds2.Tables(0).Rows(0).Item("IMG")
            Dim ms As MemoryStream = New MemoryStream(lb)
            Dim img As Image = Image.FromStream(ms)
            PictureBox4.Image = img
            ms.Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If XtraMessageBox.Show("คุณต้องการลบข้อมูลทรัพย์สินนี้ใช่หรือไม่!!!", vProgram, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = System.Windows.Forms.DialogResult.Yes Then
            If XtraMessageBox.Show("ยืนยันการลบข้อมูลทรัพย์สินนี้ใช่หรือไม่!!!", vProgram, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = System.Windows.Forms.DialogResult.Yes Then
                ClsBusinessEntity.Lc_BusinessEntity.Delete_table("m_assets", " WHERE ROWID = '" & aseetROWID & "'")
                ClsBusinessEntity.Lc_BusinessEntity.Delete_table("m_assets_fix", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID = '" & tmpID & "'")
                ClsBusinessEntity.Lc_BusinessEntity.Delete_table("t_document", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID = '" & tmpID & "'")
                ClsBusinessEntity.Lc_BusinessEntity.Delete_table("t_picture1", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID = '" & tmpID & "'")
                ClsBusinessEntity.Lc_BusinessEntity.Delete_table("t_picture2", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID = '" & tmpID & "'")
                ClsBusinessEntity.Lc_BusinessEntity.Delete_table("t_picture3", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID = '" & tmpID & "'")
                ClsBusinessEntity.Lc_BusinessEntity.Delete_table("t_picture4", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID = '" & tmpID & "'")

                Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate_En

                clsbusent8.Lc_BusinessEntity8.InsertM_table("m_assets_delete (ROWID,ASSETS_CODE,ASSETS_ID,ASSETS_NAME,USER_REC,D_UPDATE)",
                            "'" & aseetROWID & "','" & tmpAssetID & "'" _
                            & ",'" & tmpID & "'" _
                            & ",'" & txtASSET_NAME.Text.Replace("'", "\'") & "'" _
                            & ",'" & vUSERID & "'" _
                            & ",'" & tmpNow & "'")
                XtraMessageBox.Show("ดำเนินการเรียบร้อยแล้ว", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                Exit Sub
            End If
        Else
            Exit Sub
        End If
    End Sub
End Class