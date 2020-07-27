Imports clsDataAcc8 = MyPCU.ClsDataAccess8
Imports clsdataBus8 = MyPCU.ClsBusiness8
Imports clsbusent8 = MyPCU.ClsBusinessEntity8
Imports System.DateTime
Imports System.Globalization
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmSearchAssetCode
    Dim tmpLevel1 As Boolean = False
    Dim tmpLevel2 As Boolean = False
    Dim tmpLevel3 As Boolean = False
    Dim tmpGroupCode As String = ""
    Dim tmpTypeCode As String = ""
    Private Sub frmSearchAssetCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With ListView1
            .Columns.Add("รหัส", 80, HorizontalAlignment.Center)
            .Columns.Add("รายการ", 600, HorizontalAlignment.Left)
            .Columns.Add("STATUS", 0, HorizontalAlignment.Left)
        End With
        ListView1.View = View.Details
        ListView1.GridLines = True


        With BetterListView1
            .Columns.Add(0).Text = "รหัส"
            .Columns(0).Width = 80
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "รายการ"
            .Columns(1).Width = 600
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "STATUS"
            .Columns(2).Width = 0
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "จำนวนที่มี"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With
        searchData()
    End Sub
    Private Sub searchData()
        Dim ds As DataSet
        ds = clsdataBus8.Lc_Business8.SELECT_TABLE("GroupCode,GroupName,a.STATUS_AF,COUNT(b.ROWID) AS C_COUNT", " l_group a LEFT JOIN m_assets b ON(a.GROUPCODE = b.GROUP_CODE) ", " WHERE a.STATUS_AF = '1'  GROUP BY GroupCode ORDER BY GroupCODE ")
        If ds.Tables(0).Rows.Count > 0 Then
            tmpLevel1 = True
            BetterDisplayData(ds)
        Else
            BetterListView1.Items.Clear()
        End If
    End Sub
    Private Sub BetterDisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itms As New BetterListViewItem
        Dim tmpAmount As Integer = 0.0
        Dim s As Integer = 0

        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                BetterListView1.Items.Add(dr("GroupCode").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("GroupName").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("STATUS_AF").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("C_COUNT").ToString).AlignHorizontal = TextAlignmentHorizontal.Right

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                If dr("STATUS_AF") = "0" Then
                    BetterListView1.Items(i).BackColor = Color.LightPink
                End If

                If BetterListView1.Items(i).SubItems(3).Text = "0" Then
                    BetterListView1.Items(i).BackColor = Color.Beige
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

    Private Sub BetterListView1_DoubleClick(sender As Object, e As EventArgs) Handles BetterListView1.DoubleClick
        If tmpLevel1 = True Then
            searchData2()
            Exit Sub
        End If
        If tmpLevel2 = True Then
            searchData3()
            Exit Sub
        End If
    End Sub
    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            If tmpLevel1 = True Then
                lblCode.Text = lvi.SubItems.Item(0).Text
                tmpGroupCode = lvi.SubItems.Item(0).Text
            ElseIf tmpLevel2 = True Then
                lblCode.Text = tmpGroupCode & "-" & lvi.SubItems.Item(0).Text
                tmpTypeCode = lvi.SubItems.Item(0).Text
            ElseIf tmpLevel3 = True Then
                lblCode.Text = tmpGroupCode & "-" & tmpTypeCode & "-" & lvi.SubItems.Item(0).Text
            End If
        Next


    End Sub
    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        For i As Integer = 0 To ListView1.SelectedItems.Count - 1
            Dim lvi As ListViewItem
            lvi = ListView1.SelectedItems(i)
            If tmpLevel1 = True Then
                lblCode.Text = lvi.SubItems.Item(0).Text
                tmpGroupCode = lvi.SubItems.Item(0).Text
            ElseIf tmpLevel2 = True Then
                lblCode.Text = tmpGroupCode & "-" & lvi.SubItems.Item(0).Text
                tmpTypeCode = lvi.SubItems.Item(0).Text
            ElseIf tmpLevel3 = True Then
                lblCode.Text = tmpGroupCode & "-" & tmpTypeCode & "-" & lvi.SubItems.Item(0).Text
            End If
        Next
        

    End Sub
    Private Sub searchData2()
        Dim ds As DataSet
        ds = clsdataBus8.Lc_Business8.SELECT_TABLE(" TypeCode,TypeName,a.STATUS_AF,COUNT(b.ROWID) AS C_COUNT  ", " l_group_type a LEFT JOIN m_assets b ON(a.GROUPCODE = b.GROUP_CODE AND a.TYPECODE = b.GROUP_TYPE_CODE) ", " WHERE GroupCode = '" & tmpGroupCode & "' AND a.STATUS_AF = '1' GROUP BY TypeCODE ORDER BY TypeCODE ")

        If ds.Tables(0).Rows.Count > 0 Then
            tmpLevel1 = False
            tmpLevel2 = True
            BetterDisplayData3(ds)
        Else
            BetterListView1.Items.Clear()
        End If
    End Sub
    Private Sub BetterDisplayData3(ByVal ds As DataSet)
        BetterListView1.Items.Clear()
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itms As New BetterListViewItem
        Dim tmpAmount As Integer = 0.0
        Dim s As Integer = 0

        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                BetterListView1.Items.Add(dr("TypeCode").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("TypeName").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("STATUS_AF").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("C_COUNT").ToString).AlignHorizontal = TextAlignmentHorizontal.Right

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                If dr("STATUS_AF") = "0" Then
                    BetterListView1.Items(i).BackColor = Color.LightPink
                End If

                If BetterListView1.Items(i).SubItems(3).Text = "0" Then
                    BetterListView1.Items(i).BackColor = Color.Beige
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
        searchData()
    End Sub

    Private Sub cmdCancle_Click(sender As Object, e As EventArgs) Handles cmdCancle.Click
        assetCode = lblCode.Text
        Me.Close()
    End Sub
    Private Sub searchData3()
        BetterListView1.Items.Clear()
        Dim ds As DataSet
        ds = clsdataBus8.Lc_Business8.SELECT_TABLE("ASSETSCODE,ASSETSNAME,a.STATUS_AF,COUNT(b.ROWID) AS C_COUNT ", "l_assets a LEFT JOIN m_assets b ON(a.GROUPCODE = b.GROUP_CODE AND a.TYPECODE = b.GROUP_TYPE_CODE AND a.ASSETSCODE = b.ASSET_CODE)", " WHERE GroupCode = '" & tmpGroupCode & "' AND TYPECODE = '" & tmpTypeCode & "' AND a.STATUS_AF = '1' GROUP BY ASSETSCODE ORDER BY ASSETSCODE ")

        If ds.Tables(0).Rows.Count > 0 Then
            BetterDisplayData1(ds)
            tmpLevel1 = False
            tmpLevel2 = False
            tmpLevel3 = True
        Else
            BetterListView1.Items.Clear()
        End If
    End Sub
    Private Sub BetterDisplayData1(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itms As New BetterListViewItem
        Dim tmpAmount As Integer = 0.0
        Dim s As Integer = 0

        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                BetterListView1.Items.Add(dr("ASSETSCODE").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("ASSETSNAME").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("STATUS_AF").ToString).AlignHorizontal = TextAlignmentHorizontal.Center

                BetterListView1.Items(i).SubItems.Add(dr("C_COUNT").ToString).AlignHorizontal = TextAlignmentHorizontal.Right

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                If dr("STATUS_AF") = "0" Then
                    BetterListView1.Items(i).BackColor = Color.LightPink
                End If

                If BetterListView1.Items(i).SubItems(3).Text = "0" Then
                    BetterListView1.Items(i).BackColor = Color.Beige
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

                itm.SubItems.Add(dr("ASSETSNAME"))
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

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs)

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

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs)

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


End Class