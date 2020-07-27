Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmAdjRace
    Private Sub frmAdjRace_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        CboNationAction()
        ShowData()
    End Sub
    Private Sub CboNationAction()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("NATION_DESC,NATION_CODE", " l_mypcu_nation ", " WHERE STATUS_AF = '1' ")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboNation
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "NATION_DESC"
                .Properties.ValueMember = "NATION_CODE"
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
            tmpSQL = " WHERE IFNULL(RACE_HOS,'') = '' "
        ElseIf chk1.Checked = True Then
            tmpSQL = " WHERE IFNULL(RACE_HOS,'') <> '' "
        End If
        ds = clsdataBus.Lc_Business.SELECT_TABLE(" a.RACE,b.NATION_DESC AS RACE_DESC,IFNULL(a.RACE_HOS,'') AS RACE_HOS,c.NATION_DESC AS RACE_DESC_HOS ", " m_person a JOIN l_nation b ON(a.RACE = b.NATION_CODE) LEFT JOIN l_mypcu_nation c ON(a.RACE_HOS = c.NATION_CODE) ", " " & tmpSQL & " GROUP BY a.RACE  ")
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
                BetterListView1.Items.Add(dr("RACE").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("RACE_DESC").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("RACE_HOS").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("RACE_DESC_HOS").ToString).AlignHorizontal = TextAlignmentHorizontal.Left

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

    Private Sub btnLookup_Click(sender As Object, e As EventArgs) Handles btnLookup.Click
        Dim f As New frmLookupNation
        f.ShowDialog()
        CboNationAction()
    End Sub
    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            lblNationOld.Text = lvi.SubItems.Item(0).Text
            txtNationOld.Text = lvi.SubItems.Item(1).Text
        Next
    End Sub
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If lblNation.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดเชื้อชาติก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNationOld.Select()
            Exit Sub
        End If

        clsbusent.Lc_BusinessEntity.Updatem_table(" m_person ", "RACE_HOS = '" & lblNation.Text & "'", " RACE = '" & lblNationOld.Text & "'")
        'clsbusent.Lc_BusinessEntity.Updatem_table(" m_provider ", "PRENAME_HOS = '" & lblPrename.Text & "'", " PRENAME = '" & lblPrenameOld.Text & "'")
        'clsbusent.Lc_BusinessEntity.Updatem_table(" l_user ", "PRENAME_HOS = '" & lblPrename.Text & "'", " PRENAME = '" & lblPrenameOld.Text & "'")

        ClearData()
        ShowData()

    End Sub

    Private Sub cboNation_EditValueChanged(sender As Object, e As EventArgs) Handles cboNation.EditValueChanged
        lblNation.Text = cboNation.EditValue
    End Sub
    Private Sub ClearData()
        lblNation.Text = ""
        txtNationOld.Text = ""
        lblNationOld.Text = ""
        cboNation.Text = ""
    End Sub
End Class