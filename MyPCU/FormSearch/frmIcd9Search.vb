Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmIcd9Search

    Private Sub frmIcd9Search_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With BetterListView1
            .Columns.Add(0).Text = "รหัส"
            .Columns(0).Width = 100
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "VALID"
            .Columns(1).Width = 60
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "ความหมาย"
            .Columns(2).Width = 100
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "ความหมาย (ENG)"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "ICD 9 CM"
            .Columns(4).Width = 100
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "ICD 10 TM"
            .Columns(5).Width = 100
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "แพทย์แผนไทย"
            .Columns(6).Width = 100
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "ทันตกรรม"
            .Columns(7).Width = 100
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        If vProcedAdd = "10" Then
            chkAll.Checked = False
            chk10TM.Checked = True
        Else : vProcedAdd = "9"
            chkAll.Checked = False
            chk9CM.Checked = True
        End If
    End Sub

    Private Sub chkAll_Click(sender As Object, e As EventArgs) Handles chkAll.Click
        chkAll.Checked = True
        chk9CM.Checked = False
        chk10TM.Checked = False
        chk10TMD.Checked = False
        chk10Dental.Checked = False
    End Sub

    Private Sub chk9CM_Click(sender As Object, e As EventArgs) Handles chk9CM.Click
        chkAll.Checked = False
        chk9CM.Checked = True
        chk10TM.Checked = False
        chk10TMD.Checked = False
        chk10Dental.Checked = False
    End Sub

    Private Sub chk10TM_Click(sender As Object, e As EventArgs) Handles chk10TM.Click
        chkAll.Checked = False
        chk9CM.Checked = False
        chk10TM.Checked = True
        chk10TMD.Checked = False
        chk10Dental.Checked = False
    End Sub

    Private Sub chk10TMD_Click(sender As Object, e As EventArgs) Handles chk10TMD.Click
        chkAll.Checked = False
        chk9CM.Checked = False
        chk10TM.Checked = False
        chk10TMD.Checked = True
        chk10Dental.Checked = False
    End Sub

    Private Sub chk10Dental_Click(sender As Object, e As EventArgs) Handles chk10Dental.Click
        chkAll.Checked = False
        chk9CM.Checked = False
        chk10TM.Checked = False
        chk10TMD.Checked = False
        chk10Dental.Checked = True
    End Sub
    Private Sub SearchData()
        SplashScreenManager1.ShowWaitForm()
        Dim tmpSQL As String = ""
        If chkAll.Checked = True Then
            tmpSQL = " "
        ElseIf chk9CM.Checked = True Then
            tmpSQL = " AND 9CM = 'Y' "
        ElseIf chk10TM.Checked = True Then
            tmpSQL = " AND 10TM = 'Y' "
        ElseIf chk10TMD.Checked = True Then
            tmpSQL = " AND 10TMD = 'Y' "
        ElseIf chk10Dental.Checked = True Then
            tmpSQL = " AND DENTAL = 'Y' "
        End If
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_icd9", "WHERE (CODE LIKE '" & txtSearch.Text & "%' OR DESC_ENG LIKE '%" & txtSearch.Text & "%' OR DESC_THA LIKE '%" & txtSearch.Text & "%') " & tmpSQL & "")
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


        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itm As ListViewItem
        Dim tmpProvinceName As String = ""
        Dim tmpAmphurName As String = ""

        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                BetterListView1.Items.Add(dr("CODE").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                If Not IsDBNull(dr("VALIDCODE")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("VALIDCODE").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("DESC_THA")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("DESC_THA").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("DESC_ENG")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("DESC_ENG").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If

                If dr("9CM") = "Y" Then
                    BetterListView1.Items(i).SubItems.Add(ImageList1.Images.Item(0)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If dr("10TM") = "Y" Then
                    BetterListView1.Items(i).SubItems.Add(ImageList1.Images.Item(0)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If

                If dr("10TMD") = "Y" Then
                    BetterListView1.Items(i).SubItems.Add(ImageList1.Images.Item(0)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If dr("DENTAL") = "Y" Then
                    BetterListView1.Items(i).SubItems.Add(ImageList1.Images.Item(0)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
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
                SearchData()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        SearchData()
    End Sub

    Private Sub BetterListView1_DoubleClick(sender As Object, e As EventArgs) Handles BetterListView1.DoubleClick
        Me.Close()
    End Sub

    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            vProcedCode = lvi.SubItems.Item(0).Text
        Next
    End Sub
End Class