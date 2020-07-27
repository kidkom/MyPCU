Imports clsDataAcc8 = MyPCU.ClsDataAccess8
Imports clsdataBus8 = MyPCU.ClsBusiness8
Imports clsbusent8 = MyPCU.ClsBusinessEntity8
Imports System.DateTime
Imports System.Globalization
Imports MySql.Data.MySqlClient
Imports System.IO
Imports Microsoft.Reporting.WinForms
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmSearchTemp

    Private Sub frmSearchTemp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With BetterListView1
            .Columns.Add(0).Text = "ROWID"
            .Columns(0).Width = 0
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "รหัส"
            .Columns(1).Width = 150
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "รายการ"
            .Columns(2).Width = 80
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "โมเดล"
            .Columns(3).Width = 400
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "ราคา"
            .Columns(4).Width = 150
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "วันที่ได้รับ"
            .Columns(5).Width = 150
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "ซื้อจาก"
            .Columns(6).Width = 150
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With
    End Sub
    Private Sub SearchData()
        SplashScreenManager1.ShowWaitForm()
        Dim ds2 As DataSet
        ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("ROWID,ID,ASSETS_NAME,IFNULL(MODEL,'') AS MODEL,IFNULL(SERIAL,'') AS SERIAL,IFNULL(COMPANY,'') AS COMPANY,PRICE,IFNULL(DATEIN,'') AS DATEIN", " m_tmp_assets ", " WHERE ASSETS_NAME LIKE '%" & txtSearch.Text & "%' OR  MODEL LIKE '%" & txtSearch.Text & "%' ")
        If ds2.Tables(0).Rows.Count > 0 Then
            BetterDisplayData(ds2)
        Else
            BetterListView1.Items.Clear()
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub BetterDisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itms As New BetterListViewItem
        Dim tmpPrename As String = ""
        Dim tmpSum As Double = 0.0
        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                BetterListView1.Items.Add(dr("ROWID").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("ID").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("ASSETS_NAME").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("MODEL").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add((CDbl(dr("PRICE")).ToString("#,##0.00")).ToString).AlignHorizontal = TextAlignmentHorizontal.Right
                If dr("DATEIN") <> "" Then
                    BetterListView1.Items(i).SubItems.Add((DateTime.ParseExact(dr("DATEIN").ToString, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy")).ToString).AlignHorizontal = TextAlignmentHorizontal.Center

                Else
                    BetterListView1.Items(i).SubItems.Add("").AlignHorizontal = TextAlignmentHorizontal.Left

                End If
                BetterListView1.Items(i).SubItems.Add(dr("COMPANY").ToString).AlignHorizontal = TextAlignmentHorizontal.Left


                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

            Next
            BetterListView1.AutoResizeColumn(2, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(3, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(6, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)

            BetterListView1.ResumeSort()
            BetterListView1.EndUpdate()

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SearchData()
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            SearchData()
        End If
    End Sub

    Private Sub BetterListView1_DoubleClick(sender As Object, e As EventArgs) Handles BetterListView1.DoubleClick
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            vTmpID = lvi.SubItems.Item(0).Text
        Next
        Me.Close()
    End Sub

    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            vTmpID = lvi.SubItems.Item(0).Text
        Next
    End Sub
End Class