Imports clsDataAcc = MyPCU.ClsDataAccess8
Imports clsdataBus = MyPCU.ClsBusiness8
Imports clsbusent = MyPCU.ClsBusinessEntity8
Imports System.DateTime
Imports System.Globalization
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmTableAssets

    Private Sub frmTableAssets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdEdit.Enabled = False
        With BetterListView1
            .Columns.Add(0).Text = "รหัสกลุ่ม"
            .Columns(0).Width = 80
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "รหัสประเภท"
            .Columns(1).Width = 80
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "รหัส"
            .Columns(2).Width = 80
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "รายการ"
            .Columns(3).Width = 400
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "หน่วย"
            .Columns(4).Width = 100
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "STATUS"
            .Columns(5).Width = 0
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business8.SELECT_TABLE("GroupName,GroupCode", "l_group ", " WHERE STATUS_AF = '1' ORDER BY GroupName ")
        With cboGroup
            .Properties.DataSource = ds.Tables(0)
            .Properties.DisplayMember = "GroupName"
            .Properties.ValueMember = "GroupCode"
            .Properties.PopulateColumns()
            '.Properties.Columns(0).Visible = False
            .Properties.ShowHeader = False
            .Properties.NullText = ""
        End With

        If tCODE1 <> "" Then
            txtGroupCode.Text = tCODE1
            cboGroup.EditValue = tCODE1
            txtTypeCode.Text = tCODE2
            Dim ds2 As DataSet
            ds2 = clsdataBus.Lc_Business8.SELECT_TABLE("TYPENAME,TYPECODE", "l_group_type ", " WHERE GROUPCODE = '" & txtGroupCode.Text & "' AND  STATUS_AF = '1'  ORDER BY TYPENAME ")
            With cboType
                .Properties.DataSource = ds2.Tables(0)
                .Properties.DisplayMember = "TYPENAME"
                .Properties.ValueMember = "TYPECODE"
                .Properties.PopulateColumns()
                '.Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
            searchData()
        End If
    End Sub

    Private Sub cboGroup_EditValueChanged(sender As Object, e As EventArgs) Handles cboGroup.EditValueChanged
        txtGroupCode.Text = cboGroup.EditValue
        BetterListView1.Items.Clear()
        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business8.SELECT_TABLE("TYPENAME,TYPECODE", "l_group_type ", " WHERE GROUPCODE = '" & txtGroupCode.Text & "' AND  STATUS_AF = '1'  ORDER BY TYPENAME ")
        With cboType
            .Properties.DataSource = ds2.Tables(0)
            .Properties.DisplayMember = "TYPENAME"
            .Properties.ValueMember = "TYPECODE"
            .Properties.PopulateColumns()
            '.Properties.Columns(0).Visible = False
            .Properties.ShowHeader = False
            .Properties.NullText = ""
        End With
    End Sub
    Private Sub cboType_EditValueChanged(sender As Object, e As EventArgs) Handles cboType.EditValueChanged
        txtTypeCode.Text = cboType.EditValue
        searchData()
    End Sub
    Private Sub searchData()
        Dim ds As DataSet
        If chkActive.Checked = True Then
            ds = clsdataBus.Lc_Business8.SELECT_TABLE("*", "l_assets ", " WHERE GroupCode = '" & txtGroupCode.Text & "' AND TYPECODE = '" & txtTypeCode.Text & "' AND  STATUS_AF = '1'  ORDER BY ASSETSCODE ")
        ElseIf chkNonActive.Checked = True Then
            ds = clsdataBus.Lc_Business8.SELECT_TABLE("*", "l_assets ", " WHERE GroupCode = '" & txtGroupCode.Text & "' AND TYPECODE = '" & txtTypeCode.Text & "' AND  STATUS_AF = '0'  ORDER BY ASSETSCODE ")
        Else
            ds = clsdataBus.Lc_Business8.SELECT_TABLE("*", "l_assets ", " WHERE GroupCode = '" & txtGroupCode.Text & "' AND TYPECODE = '" & txtTypeCode.Text & "'  ORDER BY ASSETSCODE ")
        End If

        If ds.Tables(0).Rows.Count > 0 Then
            BetterDisplayData(ds)
            lblAmount.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
        Else
            BetterListView1.Items.Clear()
            lblAmount.Text = "จำนวน 0 รายการ"
        End If
    End Sub
    Private Sub BetterDisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itms As New BetterListViewItem
        Dim tmpPrename As String = ""

        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                BetterListView1.Items.Add(dr("GroupCode").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("TYPECODE").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("ASSETSCODE").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("ASSETSNAME").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("UNIT").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("STATUS_AF").ToString).AlignHorizontal = TextAlignmentHorizontal.Left

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                If dr("STATUS_AF") = "0" Then
                    BetterListView1.Items(i).BackColor = Color.LightPink
                End If

            Next
            BetterListView1.AutoResizeColumn(3, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.ResumeSort()
            BetterListView1.EndUpdate()

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub


    Private Sub txtGroupCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGroupCode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                cboGroup.EditValue = txtGroupCode.Text
                BetterListView1.Items.Clear()

                Dim ds2 As DataSet
                ds2 = clsdataBus.Lc_Business8.SELECT_TABLE("TYPENAME,TYPECODE", "l_group_type ", " WHERE GROUPCODE = '" & txtGroupCode.Text & "' AND  STATUS_AF = '1'  ORDER BY TYPENAME ")
                With cboType
                    .Properties.DataSource = ds2.Tables(0)
                    .Properties.DisplayMember = "TYPENAME"
                    .Properties.ValueMember = "TYPECODE"
                    .Properties.PopulateColumns()
                    '.Properties.Columns(0).Visible = False
                    .Properties.ShowHeader = False
                    .Properties.NullText = ""
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtTypeCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTypeCode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                cboType.EditValue = txtTypeCode.Text
                searchData()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ClearData()
        txtCode.Text = ""
        txtDesc.Text = ""
        CheckBox1.Checked = False
        txtCode.Enabled = True
        cmdAdd.Enabled = True
        cmdEdit.Enabled = False
    End Sub
    Private Sub cmdEdit_Click(sender As Object, e As EventArgs) Handles cmdEdit.Click
        If txtDesc.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดรายการที่ต้องการบันทึกก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDesc.Select()
            Exit Sub
        End If
        Dim tmpStatus As String = "1"

        If CheckBox1.Checked = True Then
            tmpStatus = "0"
        End If
        clsbusent.Lc_BusinessEntity8.UpdateM_table("l_assets", "ASSETSNAME = '" & txtDesc.Text & "',UNIT = '" & txtUNIT.Text & "',STATUS_AF = '" & tmpStatus & "'", "GroupCode = '" & txtGroupCode.Text & "' AND TypeCode = '" & txtTypeCode.Text & "' AND ASSETSCODE = '" & txtCode.Text & "'")
        ClearData()
        searchData()
    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        If txtGroupCode.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดกลุ่มที่ต้องการบันทึกก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCode.Select()
            Exit Sub
        End If
        If txtCode.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดรหัสรายการที่ต้องการบันทึกก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCode.Select()
            Exit Sub
        End If
        If txtCode.Text.Length < 4 Then
            XtraMessageBox.Show("กรุณากำหนดรหัสรายการให้ครบ 4 หลักก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCode.Select()
            Exit Sub
        End If
        If txtDesc.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดรายการที่ต้องการบันทึกก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDesc.Select()
            Exit Sub
        End If

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business8.SELECT_TABLE("*", "l_assets ", " WHERE  GroupCode = '" & txtGroupCode.Text & "' AND TypeCode = '" & txtCode.Text & "' AND ASSETSCODE = '" & txtCode.Text & "' ")
        If ds.Tables(0).Rows.Count > 0 Then
            XtraMessageBox.Show("ไม่สามารถบันทึกได้เนื่องจากมีรหัสนี้แล้ว!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Try
            clsbusent.Lc_BusinessEntity8.InsertM_table("l_assets (GroupCode,TypeCode,ASSETSCODE,ASSETSNAME,UNIT,STATUS_AF)",
        "'" & txtGroupCode.Text & "','" & txtTypeCode.Text & "','" & txtCode.Text & "','" & txtDesc.Text & "','" & txtUNIT.Text & "','1'")
            ClearData()
            searchData()
        Catch ex As Exception
            XtraMessageBox.Show("ไม่สามารถบันทึกได้เนื่องจากมีรหัสนี้แล้ว!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub
    Private Sub chkActive_Click(sender As Object, e As EventArgs) Handles chkActive.Click
        chkActive.Checked = True
        chkNonActive.Checked = False
        chkAll.Checked = False
        searchData()
    End Sub

    Private Sub chkNonActive_Click(sender As Object, e As EventArgs) Handles chkNonActive.Click
        chkActive.Checked = False
        chkNonActive.Checked = True
        chkAll.Checked = False
        searchData()
    End Sub

    Private Sub chkAll_Click(sender As Object, e As EventArgs) Handles chkAll.Click
        chkActive.Checked = False
        chkNonActive.Checked = False
        chkAll.Checked = True
        searchData()
    End Sub

   
    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            txtCode.Text = lvi.SubItems.Item(2).Text
            txtDesc.Text = lvi.SubItems.Item(3).Text
            If lvi.SubItems.Item(5).Text = "0" Then
                CheckBox1.Checked = True
            End If
            txtUNIT.Text = lvi.SubItems.Item(4).Text
        Next
        txtCode.Enabled = False
        cmdEdit.Enabled = True
        cmdAdd.Enabled = False
    End Sub
  

End Class