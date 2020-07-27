Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmAdjPrename

    Private Sub frmAdjPrename_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With BetterListView1
            .Columns.Add(0).Text = "รหัสเดิม"
            .Columns(0).Width = 100
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ความหมาย"
            .Columns(1).Width = 120
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "รหัสใหม่"
            .Columns(2).Width = 100
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "ความหมาย"
            .Columns(3).Width = 120
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        CboPrenameAction()
        ShowData()

    End Sub
    Private Sub CboPrenameAction()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("PRENAME_DESC,PRENAME_CODE", " l_mypcu_prename ", " WHERE STATUS_AF = '1' ")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboPrename
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "PRENAME_DESC"
                .Properties.ValueMember = "PRENAME_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = "พิมพ์เพื่อค้นหา"
            End With
        End If
    End Sub

    Private Sub CheckBox1_Click(sender As Object, e As EventArgs) Handles chkAll.Click
        chkAll.Checked = True
        chk0.Checked = False
        chk1.Checked = False
        ShowData()
    End Sub

    Private Sub CheckBox2_Click(sender As Object, e As EventArgs) Handles chk0.Click
        chk0.Checked = True
        chkAll.Checked = False
        chk1.Checked = False
        ShowData()
    End Sub

    Private Sub CheckBox3_Click(sender As Object, e As EventArgs) Handles chk1.Click
        chk1.Checked = True
        chk0.Checked = False
        chkAll.Checked = False
        ShowData()
    End Sub

    Private Sub ShowData()
        SplashScreenManager1.ShowWaitForm()
        Dim ds As DataSet
        Dim tmpSQL As String = ""
        If chkAll.Checked = True Then
            tmpSQL = " "
        ElseIf chk0.Checked = True Then
            tmpSQL = " WHERE IFNULL(PRENAME_HOS,'') = '' "
        ElseIf chk1.Checked = True Then
            tmpSQL = " WHERE IFNULL(PRENAME_HOS,'') <> '' "
        End If
        ds = clsdataBus.Lc_Business.SELECT_TABLE(" a.PRENAME,b.PRENAME AS PRENAME_TH,IFNULL(a.PRENAME_HOS,'') AS PRENAME_HOS,c.PRENAME_DESC AS PRENAME_DESC_HOS ", " m_person a JOIN l_prename b ON(a.PRENAME = b.PRENAME_CODE) LEFT JOIN l_mypcu_prename c ON(a.PRENAME_HOS = c.PRENAME_CODE) ", " " & tmpSQL & " GROUP BY a.PRENAME  ")
        If ds.Tables(0).Rows.Count > 0 Then
            Betterdisplay(ds)
            Label5.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
        Else
            BetterListView1.Items.Clear()
            Label5.Text = "จำนวน 0 รายการ"
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub Betterdisplay(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim tmpPrename As String = ""

        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                BetterListView1.Items.Add(dr("PRENAME").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("PRENAME_TH").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("PRENAME_HOS").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("PRENAME_DESC_HOS").ToString).AlignHorizontal = TextAlignmentHorizontal.Left

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If
            Next
            BetterListView1.EndUpdate()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f As New frmLookupPrename
        f.ShowDialog()
        CboPrenameAction()

    End Sub

    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            lblPrenameOld.Text = lvi.SubItems.Item(0).Text
            txtPrenameTh.Text = lvi.SubItems.Item(1).Text
        Next
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If lblPrename.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดคำนำหน้าก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPrenameTh.Select()
            Exit Sub
        End If

        clsbusent.Lc_BusinessEntity.UpdateM_table(" m_person ", "PRENAME_HOS = '" & lblPrename.Text & "'", " PRENAME = '" & lblPrenameOld.Text & "'")
        clsbusent.Lc_BusinessEntity.UpdateM_table(" m_provider ", "PRENAME_HOS = '" & lblPrename.Text & "'", " PRENAME = '" & lblPrenameOld.Text & "'")
        clsbusent.Lc_BusinessEntity.UpdateM_table(" l_user ", "PRENAME_HOS = '" & lblPrename.Text & "'", " PRENAME = '" & lblPrenameOld.Text & "'")

        ClearData()
        ShowData()

    End Sub

    Private Sub cboPrename_EditValueChanged(sender As Object, e As EventArgs) Handles cboPrename.EditValueChanged
        lblPrename.Text = cboPrename.EditValue
    End Sub
    Private Sub ClearData()
        lblPrename.Text = ""
        txtPrenameTh.Text = ""
        lblPrenameOld.Text = ""
        cboPrename.Text = ""
    End Sub
End Class