Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmSearchChronic
    Private Sub frmSearchChronic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With BetterListView1
            .Columns.Add(0).Text = "รหัส"
            .Columns(0).Width = 100
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ความหมาย"
            .Columns(1).Width = 100
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "ความหมาย (ENG)"
            .Columns(2).Width = 100
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "วันที่ยกเลิก"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        txtSearch.Select()
    End Sub
    Private Sub SearchAction()
        Dim tmpSearch As String
        tmpSearch = txtSearch.Text

        Dim ds As DataSet
        SplashScreenManager1.ShowWaitForm()
        ds = clsdataBus.Lc_Business.SELECT_TABLE("*", "l_chronic", "WHERE CODE LIKE '%" & tmpSearch & "%' OR DESC_E LIKE '%" & tmpSearch & "%' OR DESC_T LIKE '%" & tmpSearch & "%' ORDER BY CODE")
        If ds.Tables(0).Rows.Count > 0 Then
            DisplayData(ds)
            lblAmount.Text = "ผลการค้นหาจำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
        Else
            BetterListView1.Items.Clear()
            lblAmount.Text = "ผลการค้นหาจำนวน 0 รายการ"
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub DisplayData(ByVal ds As DataSet)

        Dim dr As DataRow
        Dim itm As ListViewItem

        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)

                BetterListView1.Items.Add(dr("CODE").ToString).AlignHorizontal = TextAlignmentHorizontal.Center


                If Not IsDBNull(dr("DESC_T")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("DESC_T").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("DESC_E")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("DESC_E").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If


                If dr("STATUS") = "0" Then
                    If dr("DATEEXPIRE") <> "" Then
                        BetterListView1.Items(i).SubItems.Add(Thaidate(dr("DATEEXPIRE"))).AlignHorizontal = TextAlignmentHorizontal.Center
                    Else
                        BetterListView1.Items(i).SubItems.Add("")
                    End If
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If


                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                If dr("STATUS") = "0" Then
                    BetterListView1.Items(i).BackColor = Color.LightPink
                End If


            Next
            BetterListView1.ResumeSort(True)
            BetterListView1.EndUpdate()
            BetterListView1.AutoResizeColumn(1, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(2, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(3, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SearchAction()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        SearchAction()
    End Sub
    Private Sub BetterListView1_DoubleClick(sender As Object, e As EventArgs) Handles BetterListView1.DoubleClick
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            vChronicCode = lvi.SubItems.Item(0).Text
        Next
        Me.Close()
    End Sub

    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            vChronicCode = lvi.SubItems.Item(0).Text
        Next
    End Sub
End Class