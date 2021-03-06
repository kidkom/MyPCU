﻿Imports clsDataAcc = MyPCU.ClsDataAccess8
Imports clsdataBus = MyPCU.ClsBusiness8
Imports clsbusent = MyPCU.ClsBusinessEntity8
Imports System.DateTime
Imports System.Globalization
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmTableGroupType

    Private Sub frmTableGroupType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdEdit.Enabled = False

        With BetterListView1
            .Columns.Add(0).Text = "รหัสกลุ่ม"
            .Columns(0).Width = 80
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "รหัส"
            .Columns(1).Width = 80
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "รายการ"
            .Columns(2).Width = 400
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "STATUS"
            .Columns(3).Width = 0
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
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


    End Sub

    Private Sub cboGroup_SelectionChangeCommitted(sender As Object, e As EventArgs)
        txtGroupCode.Text = cboGroup.EditValue
        searchData()
    End Sub
    Private Sub searchData()
        Dim ds As DataSet
        If chkActive.Checked = True Then
            ds = clsdataBus.Lc_Business8.SELECT_TABLE("*", "l_group_type ", " WHERE GroupCode = '" & txtGroupCode.Text & "' AND  STATUS_AF = '1' ORDER BY TypeCode ")
        ElseIf chkNonActive.Checked = True Then
            ds = clsdataBus.Lc_Business8.SELECT_TABLE("*", "l_group_type ", " WHERE GroupCode = '" & txtGroupCode.Text & "' AND  STATUS_AF = '0' ORDER BY TypeCode ")
        Else
            ds = clsdataBus.Lc_Business8.SELECT_TABLE("*", "l_group_type ", " WHERE GroupCode = '" & txtGroupCode.Text & "'  ORDER BY TypeCode ")
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
                BetterListView1.Items(i).SubItems.Add(dr("TypeCode").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("TypeName").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("STATUS_AF").ToString).AlignHorizontal = TextAlignmentHorizontal.Left

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                If dr("STATUS_AF") = "0" Then
                    BetterListView1.Items(i).BackColor = Color.LightPink
                End If

            Next
            ' BetterListView1.AutoResizeColumn(1, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
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
        clsbusent.Lc_BusinessEntity8.UpdateM_table("l_group_type", "TypeName = '" & txtDesc.Text & "',STATUS_AF = '" & tmpStatus & "'", "GroupCode = '" & txtGroupCode.Text & "' AND TypeCode = '" & txtCode.Text & "'")
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
        If txtDesc.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดรายการที่ต้องการบันทึกก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDesc.Select()
            Exit Sub
        End If

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business8.SELECT_TABLE("*", "l_group_type ", " WHERE  GroupCode = '" & txtGroupCode.Text & "' AND TypeCode = '" & txtCode.Text & "' ")
        If ds.Tables(0).Rows.Count > 0 Then
            XtraMessageBox.Show("ไม่สามารถบันทึกได้เนื่องจากมีรหัสนี้แล้ว!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Try
            clsbusent.Lc_BusinessEntity8.InsertM_table("l_group_type (GroupCode,TypeCode,TypeName,STATUS_AF)",
        "'" & txtGroupCode.Text & "','" & txtCode.Text & "','" & txtDesc.Text & "','1'")
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
            txtCode.Text = lvi.SubItems.Item(1).Text
            txtDesc.Text = lvi.SubItems.Item(2).Text
            If lvi.SubItems.Item(3).Text = "0" Then
                CheckBox1.Checked = True
            End If
        Next
        txtCode.Enabled = False
        cmdEdit.Enabled = True
        cmdAdd.Enabled = False
    End Sub

    Private Sub cboGroup_EditValueChanged(sender As Object, e As EventArgs) Handles cboGroup.EditValueChanged
        txtGroupCode.Text = cboGroup.EditValue
        searchData()
    End Sub
End Class