Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmIcd10Search

    Private Sub frmIcd10Search_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 30
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "รหัส"
            .Columns(1).Width = 100
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "VALID"
            .Columns(2).Width = 60
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "ความหมาย"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "ความหมาย (ENG)"
            .Columns(4).Width = 100
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "เพศ"
            .Columns(5).Width = 100
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "AGEMIN"
            .Columns(6).Width = 100
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "AGEMAX"
            .Columns(7).Width = 100
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "AGEDMIN"
            .Columns(8).Width = 100
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

       
    End Sub
    Private Sub chkAll_Click(sender As Object, e As EventArgs) Handles chkAll.Click
        chkAll.Checked = True
        chk10.Checked = False
        chk10TM.Checked = False
        chk10TMD.Checked = False
    End Sub

    Private Sub chk10_Click(sender As Object, e As EventArgs) Handles chk10.Click
        chkAll.Checked = False
        chk10.Checked = True
        chk10TM.Checked = False
        chk10TMD.Checked = False
    End Sub

    Private Sub chk10TM_Click(sender As Object, e As EventArgs) Handles chk10TM.Click
        chkAll.Checked = False
        chk10.Checked = False
        chk10TM.Checked = True
        chk10TMD.Checked = False
    End Sub

    Private Sub chk10TMD_Click(sender As Object, e As EventArgs) Handles chk10TMD.Click
        chkAll.Checked = False
        chk10.Checked = False
        chk10TM.Checked = False
        chk10TMD.Checked = True
    End Sub
    Private Sub SearchData()
        SplashScreenManager1.ShowWaitForm()
        Dim tmpSQL As String = ""
        If chkAll.Checked = True Then
            tmpSQL = " "
        ElseIf chk10.Checked = True Then
            tmpSQL = " AND 9CM = 'Y' "
        ElseIf chk10TM.Checked = True Then
            tmpSQL = " AND 10TM = 'Y' "
        ElseIf chk10TMD.Checked = True Then
            tmpSQL = " AND 10TMD = 'Y' "
        End If
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_icd10", "WHERE (CODE LIKE '" & txtSearch.Text & "%' OR DESC_ENG LIKE '%" & txtSearch.Text & "%' OR DESC_THAI LIKE '%" & txtSearch.Text & "%') " & tmpSQL & " ")
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

                If Not IsDBNull(dr("10TM")) Then
                    If dr("10TM") = "Y" Then
                        BetterListView1.Items.Add(ImageList1.Images.Item(0)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                    Else
                        BetterListView1.Items.Add("")
                    End If
                Else
                    BetterListView1.Items.Add("")
                End If

                BetterListView1.Items(i).SubItems.Add(dr("CODE").ToString).AlignHorizontal = TextAlignmentHorizontal.Center

                If Not IsDBNull(dr("VALID")) Then
                    If dr("VALID") = "F" Then
                        BetterListView1.Items(i).SubItems.Add(ImageList1.Images.Item(1), dr("VALID").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                    Else
                        BetterListView1.Items(i).SubItems.Add(ImageList1.Images.Item(2), dr("VALID").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                    End If
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("DESC_THAI")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("DESC_THAI").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("DESC_ENG")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("DESC_ENG").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If

                If Not IsDBNull(dr("SEX")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("SEX").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    itm.SubItems.Add("-")
                End If
                If Not IsDBNull(dr("AGEMIN")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("AGEMIN").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    itm.SubItems.Add("-")
                End If
                If Not IsDBNull(dr("AGEMAX")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("AGEMAX").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    itm.SubItems.Add("-")
                End If
                If Not IsDBNull(dr("AGEDMIN")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("AGEDMIN").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    itm.SubItems.Add("-")
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
            BetterListView1.AutoResizeColumn(3, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(4, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SearchData()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        SearchData()
    End Sub

    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged

    End Sub
End Class