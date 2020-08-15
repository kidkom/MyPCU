Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Globalization
Imports System.IO
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmPtStatus
    Dim tmpROWID As String = ""
    Dim tmpCode As String = ""
    Dim tmpName As String = ""
    Private Sub frmPtStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdSave.Enabled = False

        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 0
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "รหัส"
            .Columns(1).Width = 100
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "รายการ"
            .Columns(2).Width = 120
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "ระดับความเร่งด่วน"
            .Columns(3).Width = 200
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "URGENT"
            .Columns(4).Width = 0
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With
        ShowData()
    End Sub

    Private Sub ShowData()
        Dim ds As DataSet
        Dim tmpSQL As String = ""
        If CheckBox1.Checked = True Then
            tmpSQL = " "
        ElseIf CheckBox2.Checked = True Then
            tmpSQL = " WHERE STATUS_AF = '1' "
        ElseIf CheckBox3.Checked = True Then
            tmpSQL = " WHERE STATUS_AF = '0' "
        End If
        ds = ClsBusiness.Lc_Business.SELECT_TABLE(" * ", " l_pt_status a JOIN l_urgent b ON(a.URGENT = b.URGENT_CODE) ", " " & tmpSQL & " ")
        If ds.Tables(0).Rows.Count > 0 Then
            Betterdisplay(ds)
            Label5.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
        Else
            BetterListView1.Items.Clear()
            Label5.Text = "จำนวน 0 รายการ"
        End If

    End Sub
    Private Sub Betterdisplay(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim tmpPrename As String = ""

        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                BetterListView1.Items.Add(dr("ROWID").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("PT_STATUS_CODE").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("PT_STATUS").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                If dr("URGENT") = "1" Then
                    BetterListView1.Items(i).SubItems.Add(ImageList1.Images.Item(0), dr("URGENT_TH")).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.BeforeTextLeft
                ElseIf dr("URGENT") = "2" Then
                    BetterListView1.Items(i).SubItems.Add(ImageList1.Images.Item(1), dr("URGENT_TH")).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.BeforeTextLeft
                ElseIf dr("URGENT") = "3" Then
                    BetterListView1.Items(i).SubItems.Add(ImageList1.Images.Item(2), dr("URGENT_TH")).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.BeforeTextLeft
                ElseIf dr("URGENT") = "4" Then
                    BetterListView1.Items(i).SubItems.Add(ImageList1.Images.Item(3), dr("URGENT_TH")).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.BeforeTextLeft
                ElseIf dr("URGENT") = "5" Then
                    BetterListView1.Items(i).SubItems.Add(ImageList1.Images.Item(4), dr("URGENT_TH")).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.BeforeTextLeft
                End If
                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                BetterListView1.Items(i).SubItems.Add(dr("URGENT").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
            Next

            BetterListView1.AutoResizeColumn(2, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.EndUpdate()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub CheckBox1_Click(sender As Object, e As EventArgs) Handles CheckBox1.Click
        CheckBox1.Checked = True
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        ShowData()
    End Sub

    Private Sub CheckBox2_Click(sender As Object, e As EventArgs) Handles CheckBox2.Click
        CheckBox1.Checked = False
        CheckBox2.Checked = True
        CheckBox3.Checked = False
        ShowData()
    End Sub

    Private Sub CheckBox3_Click(sender As Object, e As EventArgs) Handles CheckBox3.Click
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = True
        ShowData()
    End Sub
    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        If txtPrenameTh.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดรายการก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPrenameTh.Select()
            Exit Sub
        End If


        Dim tmpPRENAME As String = txtPrenameTh.Text.Replace(" ", "")

        Dim ds As DataSet
        ds = ClsBusiness.Lc_Business.SELECT_TABLE(" ROWID,PT_STATUS_CODE ", " l_pt_status  ", " WHERE PT_STATUS = '" & tmpPRENAME & "' ")
        If ds.Tables(0).Rows.Count > 0 Then
            XtraMessageBox.Show("มีการกำหนดแล้ว ไม่สามารถบันทึกซ็ำได้!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        GenCode()
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)
        clsbusent.Lc_BusinessEntity.Insertm_table("l_pt_status (PT_STATUS_CODE,PT_STATUS,USER_REC,D_UPDATE,STATUS_AF,URGENT)",
         "'" & tmpCode & "','" & tmpPRENAME & "','" & vUSERID & "','" & tmpNow & "','1','" & ImageComboBoxEdit1.EditValue & "'")


        ShowData()
        ClearData()

    End Sub
    Private Sub GenCode()
        Dim ds As DataSet
        ds = ClsBusiness.Lc_Business.SELECT_TABLE(" (PT_STATUS_CODE + 1) AS PT_STATUS_CODE ", " l_pt_status  ", " ORDER BY  PT_STATUS_CODE+0 DESC LIMIT 1 ")
        If ds.Tables(0).Rows.Count > 0 Then
            tmpCode = CInt(ds.Tables(0).Rows(0).Item("PT_STATUS_CODE")).ToString("000")
        Else
            tmpCode = "001"
        End If

    End Sub
    Private Sub ClearData()
        txtPrenameTh.Text = ""
        chkStatus.Checked = False
        cmdAdd.Enabled = True
        cmdSave.Enabled = False
    End Sub

    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            tmpROWID = lvi.SubItems.Item(0).Text
            ImageComboBoxEdit1.EditValue = lvi.SubItems.Item(4).Text
        Next

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE(" * ", " l_pt_status ", " WHERE ROWID = '" & tmpROWID & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            txtPrenameTh.Text = ds.Tables(0).Rows(0).Item("PT_STATUS")
            tmpName = txtPrenameTh.Text
            If ds.Tables(0).Rows(0).Item("STATUS_AF") = "0" Then
                chkStatus.Checked = True
            Else
                chkStatus.Checked = False
            End If
            cmdAdd.Enabled = False
            cmdSave.Enabled = True
        End If

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If txtPrenameTh.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดรายการก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPrenameTh.Select()
            Exit Sub
        End If

        Dim tmpPRENAME As String = txtPrenameTh.Text.Replace(" ", "")

        Dim tmpStatus As String = ""
        If chkStatus.Checked = True Then
            tmpStatus = "0"
        Else
            tmpStatus = "1"
        End If

        If txtPrenameTh.Text <> tmpName Then
            Dim ds As DataSet
            ds = ClsBusiness.Lc_Business.SELECT_TABLE(" ROWID ", "  l_pt_status ", " WHERE PT_STATUS = '" & tmpPRENAME & "' ")
            If ds.Tables(0).Rows.Count > 0 Then
                XtraMessageBox.Show("มีการกำหนดแล้ว ไม่สามารถบันทึกซ็ำได้!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)
        clsbusent.Lc_BusinessEntity.Updatem_table(" l_pt_status ", "STATUS_AF = '" & tmpStatus & "', PT_STATUS  = '" & tmpPRENAME & "',USER_REC = '" & vUSERID & "',D_UPDATE = '" & tmpNow & "',URGENT = '" & ImageComboBoxEdit1.EditValue & "'", " ROWID = '" & tmpROWID & "'")

        ShowData()
        ClearData()
    End Sub
End Class