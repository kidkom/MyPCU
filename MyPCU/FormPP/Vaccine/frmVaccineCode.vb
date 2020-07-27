Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Imports DevExpress.XtraCharts
Public Class frmVaccineCode

    Private Sub frmVaccineCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With BetterListView1
            .Columns.Add(0).Text = "รหัสวัคซีน"
            .Columns(0).Width = 100
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "รายการ"
            .Columns(1).Width = 200
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = ""
            .Columns(2).Width = 30
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "FHIR"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "Display"
            .Columns(4).Width = 200
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With
        Timer1.Enabled = True

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 100
        Timer1.Enabled = False
        SplashScreenManager1.ShowWaitForm()
        ShowData()
        SplashScreenManager1.CloseWaitForm()

    End Sub
    Private Sub ShowData()
        Dim tmpSearch As String
        tmpSearch = txtSearch.Text
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("VACCINE_CODE,VACCINE_DESC_E,IFNULL(FHIR_CODE,'') AS FHIR_CODE", "l_vaccinetype", "WHERE VACCINE_CODE LIKE '%" & tmpSearch & "%' OR VACCINE_DESC_E LIKE '%" & tmpSearch & "%' OR VACCINE_DESC_T LIKE '%" & tmpSearch & "%' ORDER BY VACCINE_CODE")
        If ds.Tables(0).Rows.Count > 0 Then
            DisplayData(ds)
            Label5.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
        Else
            Label5.Text = "จำนวน 0 รายการ"
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
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                BetterListView1.Items.Add(dr("VACCINE_CODE").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("VACCINE_DESC_E").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
                If dr("FHIR_CODE") <> "" Then
                    BetterListView1.Items(i).SubItems.Add(ImageList1.Images.Item(0)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                Else
                    BetterListView1.Items(i).SubItems.Add("").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                End If
                BetterListView1.Items(i).SubItems.Add(dr("FHIR_CODE").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

            Next
            ' BetterListView1.AutoResizeColumn(1, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)

            BetterListView1.ResumeSort(True)
            BetterListView1.EndUpdate()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        Timer1.Enabled = True
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Timer1.Enabled = True
        End If
    End Sub
End Class