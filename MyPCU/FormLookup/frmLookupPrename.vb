Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmLookupPrename
    Dim tmpROWID As String = ""
    Dim tmpCode As String = ""
    Dim tmpName As String = ""
    Private Sub frmLookupPrename_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdSave.Enabled = False

        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 0
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = ""
            .Columns(1).Width = 30
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "รหัส"
            .Columns(2).Width = 100
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "คำนำหน้า"
            .Columns(3).Width = 120
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "คำนำหน้า (En)"
            .Columns(4).Width = 0
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "รหัสมาตรฐาน"
            .Columns(5).Width = 100
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "ความหมาย"
            .Columns(6).Width = 120
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("PRENAME,PRENAME_CODE", " l_prename", "")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboPrename
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "PRENAME"
                .Properties.ValueMember = "PRENAME_CODE"
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = "พิมพ์เพื่อค้นหา"
            End With
        End If
        ShowData()

    End Sub

    Private Sub cboPrename_EditValueChanged(sender As Object, e As EventArgs) Handles cboPrename.EditValueChanged
        lblPrename.Text = cboPrename.EditValue
    End Sub
    Private Sub ShowData()
        Dim ds As DataSet
        Dim tmpSQL As String = ""
        If CheckBox1.Checked = True Then
            tmpSQL = " "
        ElseIf CheckBox2.Checked = True Then
            tmpSQL = " WHERE a.STATUS_AF = '1' "
        ElseIf CheckBox3.Checked = True Then
            tmpSQL = " WHERE a.STATUS_AF = '0' "
        End If
        ds = clsdataBus.Lc_Business.SELECT_TABLE(" a.ROWID,a.PRENAME_CODE,a.PRENAME_DESC,a.PRENAME_DESC_ENG,a.PRENAME_STD_CODE,b.PRENAME,IFNULL(a.SEX,'') SEX ", " l_mypcu_prename a LEFT JOIN l_prename b ON(a.PRENAME_STD_CODE  = b.PRENAME_CODE) ", " " & tmpSQL & " ")
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
                If dr("SEX") = "1" Then
                    BetterListView1.Items(i).SubItems.Add(ImageList1.Images.Item(0)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                ElseIf dr("SEX") = "2" Then
                    BetterListView1.Items(i).SubItems.Add(ImageList1.Images.Item(1)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                Else
                    BetterListView1.Items(i).SubItems.Add("".ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                End If
                BetterListView1.Items(i).SubItems.Add(dr("PRENAME_CODE").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("PRENAME_DESC").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("PRENAME_DESC_ENG").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("PRENAME_STD_CODE").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("PRENAME").ToString).AlignHorizontal = TextAlignmentHorizontal.Left

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If
            Next
            'BetterListView1.AutoResizeColumn(3, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            'BetterListView1.AutoResizeColumn(4, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            'BetterListView1.AutoResizeColumn(6, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
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

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub GenCode()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE(" (PRENAME_CODE + 1) AS PRENAME_CODE ", " l_mypcu_prename a  ", " ORDER BY  PRENAME_CODE+0 DESC LIMIT 1 ")
        If ds.Tables(0).Rows.Count > 0 Then
            tmpCode = CInt(ds.Tables(0).Rows(0).Item("PRENAME_CODE")).ToString("0000")
        Else
            tmpCode = "0001"
        End If

    End Sub
    Private Sub ClearData()
        txtPrenameEn.Text = ""
        txtPrenameTh.Text = ""
        optSex1.Checked = True
        lblPrename.Text = ""
        chkStatus.Checked = False
        cmdAdd.Enabled = True
        cmdSave.Enabled = False
    End Sub

    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            tmpROWID = lvi.SubItems.Item(0).Text
        Next

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("PRENAME_DESC,IFNULL(PRENAME_DESC_ENG,'') PRENAME_DESC_ENG,IFNULL(SEX,'') SEX,STATUS_AF,PRENAME_STD_CODE", " l_mypcu_prename ", " WHERE ROWID = '" & tmpROWID & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            txtPrenameTh.Text = ds.Tables(0).Rows(0).Item("PRENAME_DESC")
            tmpName = txtPrenameTh.Text
            txtPrenameEn.Text = ds.Tables(0).Rows(0).Item("PRENAME_DESC_ENG")
            If ds.Tables(0).Rows(0).Item("SEX") = "1" Then
                optSex1.Checked = True
                optSex2.Checked = False
            Else
                optSex2.Checked = True
                optSex1.Checked = False
            End If
            If ds.Tables(0).Rows(0).Item("STATUS_AF") = "0" Then
                chkStatus.Checked = True
            Else
                chkStatus.Checked = False
            End If
            lblPrename.Text = ds.Tables(0).Rows(0).Item("PRENAME_STD_CODE")
            cboPrename.EditValue = lblPrename.Text
            cmdAdd.Enabled = False
            cmdSave.Enabled = True
        End If

    End Sub

    Private Sub cmdSearchCouple_Click(sender As Object, e As EventArgs) Handles cmdSearchCouple.Click
        Dim f As New frmAdjPrename
        f.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        If txtPrenameTh.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดคำนำหน้าก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPrenameTh.Select()
            Exit Sub
        End If

        If lblPrename.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดรหัสมาตรฐานก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim tmpPRENAME As String = txtPrenameTh.Text.Replace(" ", "")
        Dim tmpPRENAME_EN As String = txtPrenameEn.Text.Replace(" ", "")
        Dim tmpSEX As String = ""
        If optSex1.Checked = True Then
            tmpSEX = "1"
        Else
            tmpSEX = "2"
        End If

        Dim ds As DataSet
        ds = ClsBusiness.Lc_Business.SELECT_TABLE(" a.ROWID,PRENAME_CODE ", " l_mypcu_prename a  ", " WHERE PRENAME_DESC = '" & tmpPRENAME & "' ")
        If ds.Tables(0).Rows.Count > 0 Then
            XtraMessageBox.Show("มีการกำหนดแล้ว ไม่สามารถบันทึกซ็ำได้!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        GenCode()
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)
        clsbusent.Lc_BusinessEntity.Insertm_table("l_mypcu_prename (PRENAME_CODE,PRENAME_DESC,PRENAME_DESC_ENG,SEX,PRENAME_STD_CODE,USER_REC,D_UPDATE,STATUS_AF)",
         "'" & tmpCode & "','" & tmpPRENAME & "','" & tmpPRENAME_EN & "','" & tmpSEX & "','" & lblPrename.Text & "','" & vUSERID & "','" & tmpNow & "','1'")


        ShowData()
        ClearData()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If txtPrenameTh.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดคำนำหน้าก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPrenameTh.Select()
            Exit Sub
        End If

        If lblPrename.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดรหัสมาตรฐานก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim tmpPRENAME As String = txtPrenameTh.Text.Replace(" ", "")
        Dim tmpPRENAME_EN As String = txtPrenameEn.Text.Replace(" ", "")
        Dim tmpSEX As String = ""
        If optSex1.Checked = True Then
            tmpSEX = "1"
        Else
            tmpSEX = "2"
        End If
        Dim tmpStatus As String = ""
        If chkStatus.Checked = True Then
            tmpStatus = "0"
        Else
            tmpStatus = "1"
        End If

        If txtPrenameTh.Text <> tmpName Then
            Dim ds As DataSet
            ds = ClsBusiness.Lc_Business.SELECT_TABLE(" a.ROWID,PRENAME_CODE ", " l_mypcu_prename a  ", " WHERE PRENAME_DESC = '" & tmpPRENAME & "' ")
            If ds.Tables(0).Rows.Count > 0 Then
                XtraMessageBox.Show("มีการกำหนดแล้ว ไม่สามารถบันทึกซ็ำได้!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)
        clsbusent.Lc_BusinessEntity.Updatem_table(" l_mypcu_prename ", "STATUS_AF = '" & tmpStatus & "', PRENAME_DESC = '" & tmpPRENAME & "',PRENAME_DESC_ENG = '" & tmpPRENAME_EN & "',SEX = '" & tmpSEX & "',PRENAME_STD_CODE = '" & lblPrename.Text & "',USER_REC = '" & vUSERID & "',D_UPDATE = '" & tmpNow & "'", " ROWID = '" & tmpROWID & "'")

        ShowData()
        ClearData()
    End Sub

    Private Sub optSex1_Click(sender As Object, e As EventArgs) Handles optSex1.Click
        optSex1.Checked = True
        optSex2.Checked = False
    End Sub

    Private Sub optSex2_Click(sender As Object, e As EventArgs) Handles optSex2.Click
        optSex1.Checked = False
        optSex2.Checked = True
    End Sub
End Class