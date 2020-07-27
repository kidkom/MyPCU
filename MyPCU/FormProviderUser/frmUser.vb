Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmUser

    Private Sub frmUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With BetterListView1
            .Columns.Add(0).Text = "User ID"
            .Columns(0).Width = 80
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ชื่อ-นามสกุล"
            .Columns(1).Width = 100
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "Username"
            .Columns(2).Width = 100
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "Password"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "สถานะภาพ"
            .Columns(4).Width = 100
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "สถานะการใข้งาน"
            .Columns(5).Width = 100
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "ผู้ให้บริการ"
            .Columns(6).Width = 100
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "ผู้บันทึก"
            .Columns(7).Width = 100
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "ปรับปรุงเมื่อ"
            .Columns(8).Width = 100
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
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
        Dim ds As DataSet
        If chk1.Checked = True Then
            ds = clsdataBus.Lc_Business.SELECT_TABLE(" * ", " l_user ", " WHERE STATUS = '1' ORDER BY USER_ID")
        ElseIf chk0.Checked = True Then
            ds = clsdataBus.Lc_Business.SELECT_TABLE(" * ", " l_user ", " WHERE STATUS = '0' ORDER BY USER_ID")
        ElseIf chkAll.Checked = True Then
            ds = clsdataBus.Lc_Business.SELECT_TABLE(" * ", " l_user ", " ORDER BY USER_ID")
        End If

        If ds.Tables(0).Rows.Count > 0 Then
            DisplayData(ds)
            Label1.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
        Else
            BetterListView1.Items.Clear()
            Label1.Text = "จำนวน 0 รายการ"
        End If

    End Sub
    Private Sub DisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itm As ListViewItem
        Dim NAMEUSER As String = ""
        Dim tmpPrename As String = ""
        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                NAMEUSER = clsdataBus.Lc_Business.SELECT_NAME_USERID(dr("USER_REC"))
                If Not IsDBNull(dr("PRENAME")) Then
                    tmpPrename = ClsBusiness.Lc_Business.SELECT_NAME_PRENAME(dr("PRENAME"))
                End If

                BetterListView1.Items.Add(dr("USER_ID").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(tmpPrename & (dr("FNAME") & " " & dr("LNAME")).ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(Decode(dr("USERNAME")).ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(Decode(dr("PASSWORD")).ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center



                If dr("ADMIN") = "1" Then
                    BetterListView1.Items(i).SubItems.Add(ImageList1.Images.Item(1), "Admin").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add(ImageList1.Images.Item(3), "User").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                End If
                If dr("STATUS") = "1" Then
                    BetterListView1.Items(i).SubItems.Add("ใช้งาน").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("ยกเลิก").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                End If
                If dr("PROVIDER") <> "" Then
                    BetterListView1.Items(i).SubItems.Add(ImageList1.Images.Item(2), "ใช่").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add(ImageList1.Images.Item(3), "ไม่ใช่").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                End If
                BetterListView1.Items(i).SubItems.Add(NAMEUSER.ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left

                If Not IsDBNull(dr("D_UPDATE")) Then
                    BetterListView1.Items(i).SubItems.Add(Thaidate_D_UPDATE(dr("D_UPDATE").ToString).ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                If Not IsDBNull(dr("STATUS")) Then
                    If dr("STATUS").ToString = "0" Then
                        BetterListView1.Items(i).BackColor = Color.LightPink
                    End If
                End If
            Next

            BetterListView1.AutoResizeColumn(1, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(7, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(8, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)

            BetterListView1.ResumeSort(True)
            BetterListView1.EndUpdate()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub chkAll_Click(sender As Object, e As EventArgs) Handles chkAll.Click
        chkAll.Checked = True
        chk1.Checked = False
        chk0.Checked = False
        Timer1.Enabled = True

    End Sub
    Private Sub chk1_Click(sender As Object, e As EventArgs) Handles chk1.Click
        chkAll.Checked = False
        chk1.Checked = True
        chk0.Checked = False
        Timer1.Enabled = True

    End Sub
    Private Sub chk0_Click(sender As Object, e As EventArgs) Handles chk0.Click
        chkAll.Checked = False
        chk1.Checked = False
        chk0.Checked = True
        Timer1.Enabled = True
    End Sub

    Private Sub BetterListView1_DoubleClick(sender As Object, e As EventArgs) Handles BetterListView1.DoubleClick
        Dim f As New frmUserEdit
        f.ShowDialog()
        vUserSelectID = ""
        Timer1.Enabled = True
    End Sub

    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            vUserSelectID = lvi.SubItems.Item(0).Text
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If vUserSelectID <> "" Then
            Dim f As New frmUserEdit
            f.ShowDialog()
            vUserSelectID = ""
            Timer1.Enabled = True
        End If
    End Sub
End Class