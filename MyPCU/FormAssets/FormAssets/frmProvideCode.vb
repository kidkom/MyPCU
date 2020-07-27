Imports clsDataAcc8 = MyPCU.ClsDataAccess8
Imports clsdataBus8 = MyPCU.ClsBusiness8
Imports clsbusent8 = MyPCU.ClsBusinessEntity8
Imports System.DateTime
Imports System.Globalization
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmProvideCode
    Dim tmpLevel1 As Boolean = False
    Dim tmpLevel2 As Boolean = False
    Dim tmpLevel3 As Boolean = False
    Dim tmpGroupCode As String = ""
    Dim tmpTypeCode As String = ""
    Dim tmpUNIT As String = ""
    Private Sub frmProvideCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        genCode = ""
        NumericUpDown1.Enabled = False
        cmdAdd.Visible = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        With ListView1
            .Columns.Add("รหัส", 80, HorizontalAlignment.Center)
            .Columns.Add("รายการ", 650, HorizontalAlignment.Left)
            .Columns.Add("STATUS", 0, HorizontalAlignment.Left)
            .Columns.Add("UNIT", 0, HorizontalAlignment.Left)
        End With
        ListView1.View = View.Details
        ListView1.GridLines = True

        With BetterListView1
            .Columns.Add(0).Text = "รหัส"
            .Columns(0).Width = 80
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "รายการ"
            .Columns(1).Width = 650
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "STATUS"
            .Columns(2).Width = 0
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "UNIT"
            .Columns(3).Width = 0
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        With ListView2
            .Columns.Add("ลำดับ", 80, HorizontalAlignment.Center)
            .Columns.Add("รหัส", 150, HorizontalAlignment.Center)
            .Columns.Add("รายการ", 500, HorizontalAlignment.Left)
        End With
        ListView2.View = View.Details
        ListView2.GridLines = True

        With BetterListView2
            .Columns.Add(0).Text = "ลำดับ"
            .Columns(0).Width = 80
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "รหัส"
            .Columns(1).Width = 150
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "รายการ"
            .Columns(2).Width = 500
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With
        searchData()
        TextBox1.Select()
    End Sub
    Private Sub searchData()
        Dim ds As DataSet
        ds = clsdataBus8.Lc_Business8.SELECT_TABLE("*", "l_group ", " WHERE STATUS_AF = '1' ORDER BY GroupCODE ")
        If ds.Tables(0).Rows.Count > 0 Then
            tmpLevel1 = True
            BetterDisplayData2(ds)
        Else
            BetterListView1.Items.Clear()
        End If
    End Sub
    Private Sub BetterDisplayData2(ByVal ds As DataSet)
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

                BetterListView1.Items(i).SubItems.Add(dr("GroupName").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("STATUS_AF").ToString).AlignHorizontal = TextAlignmentHorizontal.Left

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

            Next
            BetterListView1.AutoResizeColumn(1, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.ResumeSort()
            BetterListView1.EndUpdate()

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub DisplayData2(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itm As ListViewItem
        Dim NAMEUSER As String = ""
        Dim tmpPrename As String = ""
        Dim tmpProvider As String = ""
        Try
            ListView1.Items.Clear()
            ListView1.BeginUpdate()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                itm = ListView1.Items.Add(dr("GroupCode"))

                itm.SubItems.Add(dr("GroupName"))
                itm.SubItems.Add(dr("STATUS_AF"))

                If (itm.Index Mod 2) = 0 Then
                    itm.BackColor = Color.WhiteSmoke
                End If
                If dr("STATUS_AF") = "0" Then
                    itm.BackColor = Color.Red
                End If

            Next
            ListView1.EndUpdate()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            If tmpLevel1 = True Then
                TextBox1.Text = lvi.SubItems.Item(0).Text
                tmpGroupCode = lvi.SubItems.Item(0).Text
                TextBox2.Enabled = True
                TextBox2.Select()
            ElseIf tmpLevel2 = True Then
                TextBox2.Text = lvi.SubItems.Item(0).Text
                tmpTypeCode = lvi.SubItems.Item(0).Text
                TextBox3.Enabled = True
                TextBox3.Select()
            ElseIf tmpLevel3 = True Then
                TextBox3.Text = lvi.SubItems.Item(0).Text
                tmpUNIT = lvi.SubItems.Item(3).Text
                searchDataAsset()
            End If
        Next
        If tmpLevel1 = True Then
            searchData2()
            Exit Sub
        End If
        If tmpLevel2 = True Then
            searchData3()
            Exit Sub
        End If
    End Sub
    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        For i As Integer = 0 To ListView1.SelectedItems.Count - 1
            Dim lvi As ListViewItem
            lvi = ListView1.SelectedItems(i)
            If tmpLevel1 = True Then
                TextBox1.Text = lvi.SubItems.Item(0).Text
                tmpGroupCode = lvi.SubItems.Item(0).Text
                TextBox2.Enabled = True
                TextBox2.Select()
            ElseIf tmpLevel2 = True Then
                TextBox2.Text = lvi.SubItems.Item(0).Text
                tmpTypeCode = lvi.SubItems.Item(0).Text
                TextBox3.Enabled = True
                TextBox3.Select()
            ElseIf tmpLevel3 = True Then
                TextBox3.Text = lvi.SubItems.Item(0).Text
                tmpUNIT = lvi.SubItems.Item(3).Text
                searchDataAsset()
            End If
        Next
        If tmpLevel1 = True Then
            searchData2()
            Exit Sub
        End If
        If tmpLevel2 = True Then
            searchData3()
            Exit Sub
        End If

    End Sub
    Private Sub searchData2()
        BetterListView1.Items.Clear()
        Dim ds As DataSet
        ds = clsdataBus8.Lc_Business8.SELECT_TABLE("*", "l_group_type ", " WHERE GroupCode = '" & tmpGroupCode & "' AND STATUS_AF = '1' ORDER BY TypeCODE ")
        If ds.Tables(0).Rows.Count > 0 Then
            tmpLevel1 = False
            tmpLevel2 = True
            BetterDisplayData3(ds)
        Else
            BetterListView1.Items.Clear()
        End If
    End Sub
    Private Sub BetterDisplayData3(ByVal ds As DataSet)
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
                BetterListView1.Items.Add(dr("TypeCode").ToString).AlignHorizontal = TextAlignmentHorizontal.Center

                BetterListView1.Items(i).SubItems.Add(dr("TypeName").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("STATUS_AF").ToString).AlignHorizontal = TextAlignmentHorizontal.Left

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

            Next
            BetterListView1.AutoResizeColumn(1, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.ResumeSort()
            BetterListView1.EndUpdate()

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub DisplayData3(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itm As ListViewItem
        Dim NAMEUSER As String = ""
        Dim tmpPrename As String = ""
        Dim tmpProvider As String = ""
        Try
            ListView1.Items.Clear()
            ListView1.BeginUpdate()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                itm = ListView1.Items.Add(dr("TypeCode"))

                itm.SubItems.Add(dr("TypeName"))
                itm.SubItems.Add(dr("STATUS_AF"))
                If (itm.Index Mod 2) = 0 Then
                    itm.BackColor = Color.WhiteSmoke
                End If
                If dr("STATUS_AF") = "0" Then
                    itm.BackColor = Color.Red
                End If

            Next
            ListView1.EndUpdate()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub cmdSearch2_Click(sender As Object, e As EventArgs) Handles cmdSearch2.Click
        lblCode.Text = ""
        tmpLevel1 = False
        tmpLevel2 = False
        tmpLevel3 = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        cmdAdd.Visible = False
        NumericUpDown1.Value = 1
        NumericUpDown1.Enabled = False
        BetterListView2.Items.Clear()
        searchData()
        TextBox1.Select()
    End Sub

    Private Sub cmdCancle_Click(sender As Object, e As EventArgs) Handles cmdCancle.Click
        If TextBox3.Text = "" Or TextBox3.Text.Length < 4 Then
            XtraMessageBox.Show("กำหนดรหัสให้ครบถ้วนก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If NumericUpDown1.Enabled = False Then
            XtraMessageBox.Show("กำหนดรหัสให้ครบถ้วนก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        genCode = TextBox1.Text
        genCode2 = TextBox2.Text
        genCode3 = TextBox3.Text
        genCode4 = NumericUpDown1.Value.ToString
        genUnit = tmpUNIT
        tAmount = NumericUpDown2.Value
        Dim ds As DataSet
        ds = clsdataBus8.Lc_Business8.SELECT_TABLE(" ASSET_NAME", "m_assets ", " WHERE ASSET_CODE_ID = '" & lblCode.Text & "' AND ASSET_ID = '" & NumericUpDown1.Value.ToString & "'  ")
        If ds.Tables(0).Rows.Count > 0 Then
            XtraMessageBox.Show("มีรหัสทรัพย์สินนี้แล้วคือ " & ds.Tables(0).Rows(0).Item("ASSET_NAME") & " ไม่สามารถกำหนดซ้ำได้!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If XtraMessageBox.Show("รหัสทรัพย์สินคือ " & genCode & "-" & genCode2 & "-" & genCode3 & "/" & genCode4 & " คุณต้องการที่จะบันทึกตามรหัสนี้ใช่หรือไม่?", vProgram, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then

            Me.Close()
        Else
            genCode = ""
            genUnit = ""
            Exit Sub
        End If

    End Sub
    Private Sub searchData3()
        BetterListView1.Items.Clear()
        Dim ds As DataSet
        ds = clsdataBus8.Lc_Business8.SELECT_TABLE("*", "l_assets ", " WHERE GroupCode = '" & tmpGroupCode & "' AND TYPECODE = '" & tmpTypeCode & "'  ORDER BY ASSETSCODE ")

        If ds.Tables(0).Rows.Count > 0 Then
            BetterDisplayData(ds)
            tmpLevel1 = False
            tmpLevel2 = False
            tmpLevel3 = True
            cmdAdd.Visible = True
        Else
            cmdAdd.Visible = True
            BetterListView1.Items.Clear()
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
                BetterListView1.Items.Add(dr("ASSETSCODE").ToString).AlignHorizontal = TextAlignmentHorizontal.Center

                BetterListView1.Items(i).SubItems.Add((dr("ASSETSNAME") & "/" & dr("UNIT")).ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("STATUS_AF").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("UNIT").ToString).AlignHorizontal = TextAlignmentHorizontal.Left

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

            Next
            BetterListView1.AutoResizeColumn(1, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.ResumeSort()
            BetterListView1.EndUpdate()

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub DisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itm As ListViewItem
        Dim NAMEUSER As String = ""
        Dim tmpPrename As String = ""
        Dim tmpProvider As String = ""
        Try
            ListView1.Items.Clear()
            ListView1.BeginUpdate()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                itm = ListView1.Items.Add(dr("ASSETSCODE"))

                itm.SubItems.Add(dr("ASSETSNAME") & "/" & dr("UNIT"))
                itm.SubItems.Add(dr("STATUS_AF"))
                itm.SubItems.Add(dr("UNIT"))

                If (itm.Index Mod 2) = 0 Then
                    itm.BackColor = Color.WhiteSmoke
                End If
                If dr("STATUS_AF") = "0" Then
                    itm.BackColor = Color.Red
                End If

            Next
            ListView1.EndUpdate()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click

        If tmpLevel1 = True Then
            searchData()
            Exit Sub
        End If
        If tmpLevel2 = True Then
            searchData2()
            Exit Sub
        End If
        If tmpLevel3 = True Then
            searchData3()
            Exit Sub
        End If
    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs) Handles RadioButton2.Click

        If tmpLevel1 = True Then
            searchData()
            Exit Sub
        End If
        If tmpLevel2 = True Then
            searchData2()
            Exit Sub
        End If
        If tmpLevel3 = True Then
            searchData3()
            Exit Sub
        End If
    End Sub
    Private Sub searchDataAsset()
        Dim tmpCode As String = TextBox1.Text & "-" & TextBox2.Text & "-" & TextBox3.Text
        Dim ds As DataSet
        ds = clsdataBus8.Lc_Business8.SELECT_TABLE("*", " m_assets ", " WHERE ASSET_CODE_ID = '" & tmpCode & "' ORDER BY ASSET_ID+0 DESC ")

        If ds.Tables(0).Rows.Count > 0 Then
            BetterDisplayDataAsset(ds)
            NumericUpDown1.Enabled = True
        Else
            NumericUpDown1.Enabled = True
            BetterListView2.Items.Clear()
            NumericUpDown1.Value = 1
        End If
    End Sub
    Private Sub BetterDisplayDataAsset(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itms As New BetterListViewItem
        Dim tmpPrename As String = ""

        Try
            BetterListView2.Items.Clear()
            BetterListView2.BeginUpdate()
            BetterListView2.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                BetterListView1.Items.Add((i + 1).ToString).AlignHorizontal = TextAlignmentHorizontal.Center

                BetterListView2.Items(i).SubItems.Add((dr("ASSET_CODE_ID") & "/" & dr("ASSET_ID")).ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView2.Items(i).SubItems.Add(dr("ASSET_NAME").ToString).AlignHorizontal = TextAlignmentHorizontal.Left

                If (i Mod 2) = 0 Then
                    BetterListView2.Items(i).BackColor = Color.WhiteSmoke
                End If

                If i = 0 Then
                    NumericUpDown1.Value = CInt(dr("ASSET_ID")) + 1
                End If

            Next
            BetterListView2.AutoResizeColumn(2, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView2.ResumeSort()
            BetterListView2.EndUpdate()

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub DisplayDataAsse(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itm As ListViewItem
        Dim NAMEUSER As String = ""
        Dim tmpPrename As String = ""
        Dim tmpProvider As String = ""
        Try
            ListView2.Items.Clear()
            ListView2.BeginUpdate()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                itm = ListView2.Items.Add(i + 1)

                itm.SubItems.Add(dr("ASSET_CODE_ID") & "/" & dr("ASSET_ID"))
                itm.SubItems.Add(dr("ASSET_NAME"))

                If (itm.Index Mod 2) = 0 Then
                    itm.BackColor = Color.WhiteSmoke
                End If
                If dr("STATUS_AF") = "4" Then
                    itm.BackColor = Color.LightCoral
                End If
                If i = 0 Then
                    NumericUpDown1.Value = CInt(dr("ASSET_ID")) + 1
                End If
            Next
            ListView2.EndUpdate()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        tCODE1 = TextBox1.Text
        tCODE2 = TextBox2.Text
        Dim f As New frmTableAssets
        f.ShowDialog()
        searchData3()

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        

    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        If TextBox1.Text.Length > 0 Then
            Dim ds As DataSet
            If RadioButton1.Checked = True Then
                ds = clsdataBus8.Lc_Business8.SELECT_TABLE("*", "l_group ", " WHERE GROUPCODE LIKE '" & TextBox1.Text & "%' AND STATUS_AF = '1' ORDER BY GroupName ")
            Else
                ds = clsdataBus8.Lc_Business8.SELECT_TABLE("*", "l_group ", " WHERE GROUPCODE LIKE '" & TextBox1.Text & "%' AND STATUS_AF = '1' ORDER BY GroupCODE ")
            End If
            If ds.Tables(0).Rows.Count > 0 Then
                tmpLevel1 = True
                DisplayData2(ds)
            Else
                ListView1.Items.Clear()
            End If
        End If
        If TextBox1.Text.Length = 4 Then
            Dim ds2 As DataSet
            ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("*", "l_group ", " WHERE GROUPCODE = '" & TextBox1.Text & "' AND STATUS_AF = '1' ORDER BY GroupName ")
            If ds2.Tables(0).Rows.Count > 0 Then
                TextBox2.Enabled = True
                TextBox2.Select()
                tmpGroupCode = TextBox1.Text
                searchData2()
            Else
                TextBox2.Enabled = False
                TextBox2.Text = ""
            End If
        Else
            TextBox2.Enabled = False
            TextBox2.Text = ""
        End If
    End Sub

    Private Sub TextBox2_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyUp
        If TextBox2.Text.Length > 0 Then
            Dim ds As DataSet
            If RadioButton1.Checked = True Then
                ds = clsdataBus8.Lc_Business8.SELECT_TABLE("*", "l_group_type ", " WHERE GroupCode = '" & tmpGroupCode & "' AND TYPECODE LIKE  '" & TextBox2.Text & "%' AND STATUS_AF = '1' ORDER BY TypeName ")
            Else
                ds = clsdataBus8.Lc_Business8.SELECT_TABLE("*", "l_group_type ", " WHERE GroupCode = '" & tmpGroupCode & "' AND TYPECODE LIKE  '" & TextBox2.Text & "%' AND STATUS_AF = '1' ORDER BY TypeCODE ")
            End If
            If ds.Tables(0).Rows.Count > 0 Then
                tmpLevel1 = False
                tmpLevel2 = True
                DisplayData3(ds)
            Else
                ListView1.Items.Clear()
            End If
        End If
        If TextBox2.Text.Length = 3 Then
            Dim ds2 As DataSet
            ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("*", "l_group_type ", " WHERE GROUPCODE = '" & tmpGroupCode & "' AND TYPECODE  = '" & TextBox2.Text & "' AND STATUS_AF = '1' ")
            If ds2.Tables(0).Rows.Count > 0 Then
                TextBox3.Enabled = True
                TextBox3.Select()
                tmpTypeCode = TextBox2.Text
                searchData3()
            Else
                TextBox3.Enabled = False
                TextBox3.Text = ""
            End If
        Else
            TextBox3.Enabled = False
            TextBox3.Text = ""
        End If
    End Sub

    Private Sub TextBox3_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyUp
        If TextBox3.Text.Length > 0 Then
            Dim ds As DataSet
            If RadioButton1.Checked = True Then
                ds = clsdataBus8.Lc_Business8.SELECT_TABLE("*", "l_assets ", " WHERE GroupCode = '" & tmpGroupCode & "' AND TYPECODE = '" & tmpTypeCode & "' AND ASSETSCODE LIKE '" & TextBox3.Text & "%'  ORDER BY ASSETSNAME ")
            Else
                ds = clsdataBus8.Lc_Business8.SELECT_TABLE("*", "l_assets ", " WHERE GroupCode = '" & tmpGroupCode & "' AND TYPECODE = '" & tmpTypeCode & "' AND ASSETSCODE LIKE '" & TextBox3.Text & "%'  ORDER BY ASSETSCODE ")
            End If
            If ds.Tables(0).Rows.Count > 0 Then
                DisplayData(ds)
                tmpLevel1 = False
                tmpLevel2 = False
                tmpLevel3 = True
                cmdAdd.Visible = True
            Else
                ListView1.Items.Clear()
            End If
        End If
        If TextBox1.Text.Length = 4 Then
            Dim ds2 As DataSet
            ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("*", "l_assets ", " WHERE GroupCode = '" & tmpGroupCode & "' AND TYPECODE = '" & tmpTypeCode & "' AND ASSETSCODE = '" & TextBox3.Text & "'  ")
            If ds2.Tables(0).Rows.Count > 0 Then
                tmpUNIT = ds2.Tables(0).Rows(0).Item("UNIT")
                searchDataAsset()
            Else
                NumericUpDown1.Enabled = False
            End If
        Else
            NumericUpDown1.Enabled = False
        End If
    End Sub


End Class