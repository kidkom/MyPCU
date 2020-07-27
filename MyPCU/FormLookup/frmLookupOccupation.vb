
Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmLookupOccupation
    Dim tmpROWID As String = ""
    Dim tmpCode As String = ""
    Dim tmpName As String = ""
    Private Sub FrmLookupOccupation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdSave.Enabled = False

        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 0
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "รหัส"
            .Columns(1).Width = 100
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "อาชีพ"
            .Columns(2).Width = 150
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "รหัสมาตรฐาน(เดิม)"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "ความหมาย"
            .Columns(4).Width = 150
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "รหัสมาตรฐาน(ใหม่)"
            .Columns(5).Width = 100
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "ความหมาย"
            .Columns(6).Width = 150
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        OldOccupationAction()
        NewOccupationAction()
        Timer1.Enabled = True
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 100
        Timer1.Enabled = False
        SplashScreenManager1.ShowWaitForm()

        ShowData()

        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub OldOccupationAction()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("OCCUPATION_DESC,OCCUPATION_CODE", " l_occupation_old", " ORDER BY OCCUPATION_DESC ")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboOccupationDescOld
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "OCCUPATION_DESC"
                .Properties.ValueMember = "OCCUPATION_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = "พิมพ์เพื่อค้นหา"
            End With
        End If
    End Sub
    Private Sub NewOccupationAction()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("OCCUPATION_DESC,OCCUPATION_CODE", " l_occupation", "ORDER BY OCCUPATION_DESC")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboOccupationDescNew
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "OCCUPATION_DESC"
                .Properties.ValueMember = "OCCUPATION_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = "พิมพ์เพื่อค้นหา"
            End With
        End If
    End Sub


    Private Sub chkUseOnly_Click(sender As Object, e As EventArgs) Handles chkUseOnly.Click
        chkUseOnly.Checked = True
        chkCancel.Checked = False
        chkAll.Checked = False
        Timer1.Enabled = True
    End Sub

    Private Sub chkCancel_Click(sender As Object, e As EventArgs) Handles chkCancel.Click
        chkUseOnly.Checked = False
        chkCancel.Checked = True
        chkAll.Checked = False
        Timer1.Enabled = True
    End Sub

    Private Sub chkAll_Click(sender As Object, e As EventArgs) Handles chkAll.Click
        chkUseOnly.Checked = False
        chkCancel.Checked = False
        chkAll.Checked = True
        Timer1.Enabled = True
    End Sub

    Private Sub cboOccupationDescOld_EditValueChanged(sender As Object, e As EventArgs) Handles cboOccupationDescOld.EditValueChanged
        lblOccupationCodeOld.Text = cboOccupationDescOld.EditValue
    End Sub

    Private Sub cboOccupationDescNew_EditValueChanged(sender As Object, e As EventArgs) Handles cboOccupationDescNew.EditValueChanged
        lblOccupationCodeNew.Text = cboOccupationDescNew.EditValue
    End Sub
    Private Sub ShowData()
        Dim ds As DataSet
        Dim tmpSQL As String = ""
        If chkAll.Checked = True Then
            tmpSQL = " "
        ElseIf chkUseOnly.Checked = True Then
            tmpSQL = " WHERE a.STATUS_AF = '1' "
        ElseIf chkCancel.Checked = True Then
            tmpSQL = " WHERE a.STATUS_AF = '0' "
        End If
        ds = clsdataBus.Lc_Business.SELECT_TABLE(" a.ROWID,a.OCCUPATION_CODE,a.OCCUPATION_DESC,b.OCCUPATION_DESC AS OLD_OCCU,GROUP_CONCAT(c.OCCUPATION_DESC) AS NEW_OCCU,OCCUPATION_STD_CODE_OLD,OCCUPATION_STD_CODE_NEW " _
                                                 , " l_mypcu_occupation a LEFT JOIN l_occupation_old b ON(a.OCCUPATION_STD_CODE_OLD  = b.OCCUPATION_CODE) " _
                                                  & " LEFT JOIN l_occupation c ON(a.OCCUPATION_STD_CODE_NEW = c.OCCUPATION_CODE)   " _
                                                 , " " & tmpSQL & " GROUP BY OCCUPATION_CODE,OCCUPATION_STD_CODE_NEW ")
        If ds.Tables(0).Rows.Count > 0 Then
            Betterdisplay(ds)
            lblTotalRow.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
        Else
            BetterListView1.Items.Clear()
            lblTotalRow.Text = "จำนวน 0 รายการ"
        End If
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
                BetterListView1.Items.Add(dr("ROWID").ToString).AlignHorizontal = TextAlignmentHorizontal.Center

                BetterListView1.Items(i).SubItems.Add(dr("OCCUPATION_CODE").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("OCCUPATION_DESC").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("OCCUPATION_STD_CODE_OLD").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("OLD_OCCU").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("OCCUPATION_STD_CODE_NEW").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("NEW_OCCU").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If
            Next
            BetterListView1.AutoResizeColumn(4, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(6, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            'BetterListView1.AutoResizeColumn(6, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.EndUpdate()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        If txtOccupation.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดอาชีพก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtOccupation.Select()
            Exit Sub
        End If

        If lblOccupationCodeOld.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดรหัสอาชีพเดิมก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If lblOccupationCodeNew.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดรหัสอาชีพใหม่ก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim tmpOccupation As String = txtOccupation.Text
        Dim OldOccupation As String = lblOccupationCodeOld.Text
        Dim NewOcuupation As String = lblOccupationCodeNew.Text

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE(" ROWID ", " l_mypcu_occupation ", " WHERE OCCUPATION_DESC = '" & tmpOccupation & "' ")
        If ds.Tables(0).Rows.Count > 1 Then
            XtraMessageBox.Show("มีการกำหนดแล้ว ไม่สามารถบันทึกซ้ำได้!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        GenCode()
        'Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate_En()

        clsbusent.Lc_BusinessEntity.Insertm_table("l_mypcu_occupation (OCCUPATION_CODE,OCCUPATION_DESC,OCCUPATION_STD_CODE_OLD,OCCUPATION_STD_CODE_NEW,USER_REC,D_UPDATE,STATUS_AF)",
         "'" & tmpCode & "','" & tmpOccupation & "','" & OldOccupation & "','" & NewOcuupation & "','" & vUSERID & "','" & tmpNow & "','1' ")

        ClearData()
        Timer1.Enabled = True

    End Sub
    Private Sub ClearData()
        txtOccupation.Text = ""
        lblOccupationCodeOld.Text = ""
        lblOccupationCodeNew.Text = ""
        cmdAdd.Enabled = True
        cmdSave.Enabled = False
        tmpROWID = ""
        cboOccupationDescNew.Text = ""
        cboOccupationDescOld.Text = ""
    End Sub
    Private Sub GenCode()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE(" (OCCUPATION_CODE + 1) AS OCCUPATION_CODE ", " l_mypcu_occupation a  ", " ORDER BY  OCCUPATION_CODE+0 DESC LIMIT 1 ")
        If ds.Tables(0).Rows.Count > 0 Then
            tmpCode = CInt(ds.Tables(0).Rows(0).Item("OCCUPATION_CODE")).ToString("0000")
        Else
            tmpCode = "0001"
        End If

    End Sub
    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            tmpROWID = lvi.SubItems.Item(0).Text
        Next

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("OCCUPATION_DESC,STATUS_AF,OCCUPATION_STD_CODE_OLD,OCCUPATION_STD_CODE_NEW", " l_mypcu_occupation ", " WHERE ROWID = '" & tmpROWID & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            txtOccupation.Text = ds.Tables(0).Rows(0).Item("OCCUPATION_DESC")
            tmpName = txtOccupation.Text
            If ds.Tables(0).Rows(0).Item("STATUS_AF") = "0" Then
                chkStatus.Checked = True
            Else
                chkStatus.Checked = False
            End If
            lblOccupationCodeOld.Text = ds.Tables(0).Rows(0).Item("OCCUPATION_STD_CODE_OLD")
            cboOccupationDescOld.EditValue = lblOccupationCodeOld.Text
            lblOccupationCodeNew.Text = ds.Tables(0).Rows(0).Item("OCCUPATION_STD_CODE_NEW")
            cboOccupationDescNew.EditValue = lblOccupationCodeNew.Text
            cmdAdd.Enabled = False
            cmdSave.Enabled = True
        End If
    End Sub
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If txtOccupation.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดอาชีพก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtOccupation.Select()
            Exit Sub
        End If

        If lblOccupationCodeOld.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดรหัสมาตรฐานก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If lblOccupationCodeNew.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดรหัสมาตรฐานก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        Dim tmpOCCUPATION As String = txtOccupation.Text.Replace(" ", "")


        Dim tmpStatus As String = ""
        If chkStatus.Checked = True Then
            tmpStatus = "0"
        Else
            tmpStatus = "1"
        End If

        If txtOccupation.Text <> tmpName Then
            Dim ds As DataSet
            ds = ClsBusiness.Lc_Business.SELECT_TABLE(" a.ROWID,OCCUPATION_CODE ", " l_mypcu_occupation a  ", " WHERE OCCUPATION_DESC = '" & tmpOCCUPATION & "' ")
            If ds.Tables(0).Rows.Count > 0 Then
                XtraMessageBox.Show("มีการกำหนดแล้ว ไม่สามารถบันทึกซ้ำได้!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)
        clsbusent.Lc_BusinessEntity.Updatem_table(" l_mypcu_occupation ", " STATUS_AF = '" & tmpStatus & "',OCCUPATION_DESC = '" & tmpOCCUPATION & "',OCCUPATION_STD_CODE_OLD = '" & lblOccupationCodeOld.Text & "',OCCUPATION_STD_CODE_NEW = '" & lblOccupationCodeNew.Text & "',USER_REC = '" & vUSERID & "',D_UPDATE = '" & tmpNow & "'", " ROWID = '" & tmpROWID & "'")
        ClearData()

        Timer1.Enabled = True

    End Sub
End Class