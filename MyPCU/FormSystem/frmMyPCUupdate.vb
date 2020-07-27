Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.IO
Imports DevExpress.XtraEditors
Imports ComponentOwl.BetterListView
Public Class frmMyPCUupdate
    Private Sub FrmMyPCUupdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 0
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ชื่อเครื่อง"
            .Columns(1).Width = 300
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "เวอร์ชั่นในเครื่อง"
            .Columns(2).Width = 100
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "เวอร์ชั่นปัจจุบัน"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        Timer1.Enabled = True
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 100
        Timer1.Enabled = False
        SplashScreenManager1.ShowWaitForm()
        SearchData()
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub SearchData()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE(" A.ROWID,A.COMPUTER_NAME,A.VERSION_CODE,IFNULL(B.VERSION,'000000') AS VERSION_NOW  ", " r_system_update A , l_version B   ", " ORDER BY A.COMPUTER_NAME")
        If ds.Tables(0).Rows.Count > 0 Then
            DisplayData(ds)
            Label1.Text = "จำนวน " & CInt(ds.Tables(0).Rows.Count).ToString("#,##0") & " รายการ"
        Else
            BetterListView1.Items.Clear()
            Label1.Text = "จำนวน 0 รายการ"
        End If
    End Sub
    Private Sub DisplayData(ByVal ds As DataSet)
        Dim dr As DataRow

        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                BetterListView1.Items.Add(dr("ROWID").ToString)
                BetterListView1.Items(i).SubItems.Add(dr("COMPUTER_NAME").ToString)
                BetterListView1.Items(i).SubItems.Add(dr("VERSION_CODE").ToString)
                BetterListView1.Items(i).SubItems.Add(dr("VERSION_NOW").ToString)

                If i Mod 2 = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                If dr("VERSION_CODE") <> dr("VERSION_NOW") Then
                    BetterListView1.Items(i).BackColor = Color.LightPink
                End If

            Next

            BetterListView1.AutoResizeColumn(1, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.ResumeSort(True)
            BetterListView1.EndUpdate()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try


    End Sub


End Class