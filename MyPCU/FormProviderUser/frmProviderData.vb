Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Imports DevExpress.XtraCharts
Public Class frmProviderData

    Private Sub frmProviderData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label4.Text = ""

        With BetterListView1
            .Columns.Add(0).Text = "รหัสผู้ให้บริการ"
            .Columns(0).Width = 100
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ผู้ให้บริการ"
            .Columns(1).Width = 100
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "จำนวน"
            .Columns(2).Width = 100
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        With BetterListView2
            .Columns.Add(0).Text = "แฟ้ม"
            .Columns(0).Width = 200
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "จำนวน"
            .Columns(1).Width = 100
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With
    End Sub

    Private Sub cmdProcess_Click(sender As Object, e As EventArgs) Handles cmdProcess.Click
        SplashScreenManager1.ShowWaitForm()
        BetterListView2.Items.Clear()
        Label4.Text = ""
        ChartControl2.Series("Series 1").Points.Clear()
        ChartControl2.SeriesDataMember = String.Empty

        Dim ds As DataSet
        Dim ds2 As DataSet
        clsbusent.Lc_BusinessEntity.Turncate_table("r_provider")
        ds = clsdataBus.Lc_Business.SELECT_TABLE("M_TABLE", "l_table43", " WHERE M_TABLE <> 'PROVIDER' ORDER BY m_TABLE")
        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Dim ds3 As DataSet
                ds3 = clsdataBus.Lc_Business.SHOW_TABLE_COLUMN("m_" & ds.Tables(0).Rows(i).Item("M_TABLE").ToString.ToLower & " WHERE FIELD = 'PROVIDER' ")
                Dim tmpMTable = ds.Tables(0).Rows(i).Item("M_TABLE").ToString.ToLower
                If ds3.Tables(0).Rows.Count = 1 Then
                    ds2 = clsdataBus.Lc_Business.SELECT_TABLE("PROVIDER,COUNT(*) AS C_COUNT", "m_" & tmpMTable, " WHERE IFNULL(PROVIDER,'') <> '' GROUP BY PROVIDER")
                    If ds2.Tables(0).Rows.Count > 0 Then
                        For h As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                            clsbusent.Lc_BusinessEntity.Insertm_table("r_provider (M_TABLE,PROVIDER,C_COUNT)", "'" & tmpMTable & "','" & ds2.Tables(0).Rows(h).Item("PROVIDER") & "','" & ds2.Tables(0).Rows(h).Item("C_COUNT") & "'")

                        Next
                    End If
                End If
            Next
        End If
        ShowData()
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub ShowData()


        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("PROVIDER,SUM(C_COUNT) AS C_COUNT ", "r_provider", " GROUP BY PROVIDER ORDER BY C_COUNT DESC")
        If ds.Tables(0).Rows.Count > 0 Then
            DisplayData(ds)
            Label1.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
        Else
            Label1.Text = "จำนวน 0 รายการ"
        End If

    End Sub
    Private Sub DisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itm As ListViewItem
        Dim NAMEUSER As String = ""
        Dim tmpPrename As String = ""
        Dim tmpProvider As String = ""


        Try
            ChartControl1.Series("Series 1").Points.Clear()
            ChartControl1.SeriesDataMember = String.Empty
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                BetterListView1.Items.Add(dr("PROVIDER").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                Dim tmpProviderName As String = ClsBusiness.Lc_Business.SELECT_NAME_PROVIDER(dr("PROVIDER"))

                BetterListView1.Items(i).SubItems.Add(tmpProviderName).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(CInt(dr("C_COUNT")).ToString("#,##0")).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                ChartControl1.Series("Series 1").Points.Add(New SeriesPoint(tmpProviderName, CInt(dr("C_COUNT")).ToString("#,##0")))
                ChartControl1.Series("Series 1").Label.TextPattern = "{A}: {VP:P0}"

            Next
            BetterListView1.AutoResizeColumn(1, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)

            BetterListView1.ResumeSort(True)
            BetterListView1.EndUpdate()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged

        Dim tmpProvider As String = ""
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            tmpProvider = lvi.SubItems.Item(0).Text
        Next
        Label4.Text = ClsBusiness.Lc_Business.SELECT_NAME_PROVIDER(tmpProvider)
        ' SplashScreenManager1.ShowWaitForm()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("M_TABLE,C_COUNT ", "r_provider", " WHERE PROVIDER = '" & tmpProvider & "' ORDER BY C_COUNT+0 DESC ")
        If ds.Tables(0).Rows.Count > 0 Then
            DisplayData2(ds)
            Label18.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
        Else
            BetterListView2.Items.Clear()
            Label18.Text = "จำนวน 0 รายการ"
        End If
        ' SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub DisplayData2(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itm As ListViewItem
        Dim NAMEUSER As String = ""
        Dim tmpPrename As String = ""
        Dim tmpProvider As String = ""
        Try
            ChartControl2.Series("Series 1").Points.Clear()
            ChartControl2.SeriesDataMember = String.Empty
            BetterListView2.Items.Clear()
            BetterListView2.BeginUpdate()
            BetterListView2.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)

                BetterListView2.Items.Add(dr("M_TABLE").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
                BetterListView2.Items(i).SubItems.Add(CInt(dr("C_COUNT")).ToString("#,##0")).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right

                If (i Mod 2) = 0 Then
                    BetterListView2.Items(i).BackColor = Color.WhiteSmoke
                End If

                ChartControl2.Series("Series 1").Points.Add(New SeriesPoint(dr("M_TABLE").ToString, CInt(dr("C_COUNT")).ToString("#,##0")))
                ChartControl2.Series("Series 1").Label.TextPattern = "{A}: {VP:P0}"
            Next
            BetterListView2.ResumeSort(True)
            BetterListView2.EndUpdate()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
End Class