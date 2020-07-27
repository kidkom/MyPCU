Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmHospSearch

    Private Sub frmHospSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblAmount.Text = ""

        With BetterListView1
            .Columns.Add(0).Text = "รหัส"
            .Columns(0).Width = 100
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ชื่อหน่วยบริการ"
            .Columns(1).Width = 300
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "รหัสจังหวัด"
            .Columns(2).Width = 100
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "จังหวัด"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "รหัสอำเภอ"
            .Columns(4).Width = 100
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "อำเภอ"
            .Columns(5).Width = 100
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

    End Sub
    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SearchData()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SearchData()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE(" HOSPCODE,HOSPNAME,a.PROVINCE_ID,PROVINCE_NAME,AMP,AMPHUR_NAME ", "  l_hospitals a JOIN l_cat b ON(a.PROVINCE_ID = b.PROVINCE_ID AND a.AMP = b.AMPHUR_ID AND a.TAM = b.TAMBOL_ID) ", "WHERE HOSPCODE LIKE '" & txtSearch.Text & "%' OR HOSPNAME LIKE '%" & txtSearch.Text & "%' ORDER BY a.PROVINCE_ID,AMP,TAM,HOSPCODE")
        If ds.Tables(0).Rows.Count > 0 Then
            SplashScreenManager1.ShowWaitForm()
            DisplayData(ds)
            lblAmount.Text = "ผลการค้นหาจำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
            SplashScreenManager1.CloseWaitForm()
        Else
            BetterListView1.Items.Clear()
            lblAmount.Text = "ผลการค้นหาจำนวน 0 รายการ"
        End If
    End Sub
    Private Sub DisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itm As ListViewItem
        Dim tmpProvinceName As String = ""
        Dim tmpAmphurName As String = ""

        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                BetterListView1.Items.Add(dr("HOSPCODE").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("HOSPNAME").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("PROVINCE_ID").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("PROVINCE_NAME").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("AMP").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("AMPHUR_NAME").ToString).AlignHorizontal = TextAlignmentHorizontal.Center

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If
               
            Next
            BetterListView1.EndUpdate()
            BetterListView1.AutoResizeColumn(1, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(3, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(5, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub cmdSearch2_Click(sender As Object, e As EventArgs) Handles cmdSearch2.Click
        SearchData()
    End Sub

    Private Sub BetterListView1_DoubleClick(sender As Object, e As EventArgs) Handles BetterListView1.DoubleClick
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            vTmpHcode = lvi.SubItems.Item(0).Text
        Next
        Me.Close()
    End Sub
End Class