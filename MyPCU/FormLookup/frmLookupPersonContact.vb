Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmLookupPersonContact
    Dim tmpROWID As String = ""
    Dim tmpCode As String = ""
    Dim tmpName As String = ""

    Private Sub frmLookupPersonContact_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdSave.Enabled = False

        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 0
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "รหัส"
            .Columns(1).Width = 100
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "ลักษณะความสัมพันธ์"
            .Columns(2).Width = 120
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "รหัสมาตรฐาน"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "ความหมาย"
            .Columns(4).Width = 120
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        PersonContactAction()
        Timer1.Enabled = True
    End Sub
    Private Sub PersonContactAction()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("PERSON_CONTACT_DESC,PERSON_CONTACT_CODE", " l_person_contact", "")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboPersonContact
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "PERSON_CONTACT_DESC"
                .Properties.ValueMember = "PERSON_CONTACT_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = "พิมพ์เพื่อค้นหา"
            End With
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 100
        Timer1.Enabled = False
        SplashScreenManager1.ShowWaitForm()

        ShowData()

        SplashScreenManager1.CloseWaitForm()
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

    Private Sub cboPersonContact_EditValueChanged(sender As Object, e As EventArgs) Handles cboPersonContact.EditValueChanged
        lblPersonContactCode.Text = cboPersonContact.EditValue
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
        ds = clsdataBus.Lc_Business.SELECT_TABLE(" a.ROWID,a.PERSON_CONTACT_CODE,a.PERSON_CONTACT_DESC,a.PERSON_CONTACT_STD_CODE,b.PERSON_CONTACT_DESC AS PERSON_CONTACT_STD__DESC,a.STATUS_AF ", " l_mypcu_person_contact a LEFT JOIN l_person_contact b ON(a.PERSON_CONTACT_STD_CODE  = b.PERSON_CONTACT_CODE) ", " " & tmpSQL & " ")
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

                BetterListView1.Items(i).SubItems.Add(dr("PERSON_CONTACT_CODE").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("PERSON_CONTACT_DESC").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("PERSON_CONTACT_STD_CODE").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("PERSON_CONTACT_STD__DESC").ToString).AlignHorizontal = TextAlignmentHorizontal.Left


                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                If dr("STATUS_AF") = "0" Then
                    BetterListView1.Items(i).BackColor = Color.LightPink
                End If

            Next
            'BetterListView1.AutoResizeColumn(2, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            'BetterListView1.AutoResizeColumn(4, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            'BetterListView1.AutoResizeColumn(6, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.EndUpdate()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub GenCode()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE(" (PERSON_CONTACT_CODE + 1) AS PERSON_CONTACT_CODE ", " l_mypcu_person_contact a  ", " ORDER BY  PERSON_CONTACT_CODE+0 DESC LIMIT 1 ")
        If ds.Tables(0).Rows.Count > 0 Then
            tmpCode = CInt(ds.Tables(0).Rows(0).Item("PERSON_CONTACT_CODE")).ToString("0000")
        Else
            tmpCode = "0001"
        End If
    End Sub
    Private Sub ClearData()
        txtPersonContact.Text = ""
        lblPersonContactCode.Text = ""
        chkStatus.Checked = False
        cmdAdd.Enabled = True
        cmdSave.Enabled = False
        tmpROWID = ""
        cboPersonContact.Text = ""
    End Sub
    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            tmpROWID = lvi.SubItems.Item(0).Text
        Next

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("PERSON_CONTACT_DESC,STATUS_AF,PERSON_CONTACT_STD_CODE", " l_mypcu_person_contact ", " WHERE ROWID = '" & tmpROWID & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            txtPersonContact.Text = ds.Tables(0).Rows(0).Item("PERSON_CONTACT_DESC")
            tmpName = txtPersonContact.Text
            If ds.Tables(0).Rows(0).Item("STATUS_AF") = "0" Then
                chkStatus.Checked = True
            Else
                chkStatus.Checked = False
            End If
            lblPersonContactCode.Text = ds.Tables(0).Rows(0).Item("PERSON_CONTACT_STD_CODE")
            cboPersonContact.EditValue = lblPersonContactCode.Text
            cmdAdd.Enabled = False
            cmdSave.Enabled = True
        End If
    End Sub
    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        If txtPersonContact.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดลักษณะความสัมพันธ์ก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPersonContact.Select()
            Exit Sub
        End If

        If lblPersonContactCode.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดรหัสมาตรฐานก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim tmpPERSONCONTACT As String = txtPersonContact.Text.Replace(" ", "")


        Dim ds As DataSet
        ds = ClsBusiness.Lc_Business.SELECT_TABLE(" a.ROWID,PERSON_CONTACT_CODE ", " l_mypcu_person_contact a  ", " WHERE PERSON_CONTACT_DESC = '" & tmpPERSONCONTACT & "' ")
        If ds.Tables(0).Rows.Count > 0 Then
            XtraMessageBox.Show("มีการกำหนดแล้ว ไม่สามารถบันทึกซ้ำได้!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        GenCode()
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)
        clsbusent.Lc_BusinessEntity.Insertm_table("l_mypcu_person_contact (PERSON_CONTACT_CODE,PERSON_CONTACT_DESC,PERSON_CONTACT_STD_CODE,USER_REC,D_UPDATE,STATUS_AF)",
         "'" & tmpCode & "','" & tmpPERSONCONTACT & "','" & lblPersonContactCode.Text & "','" & vUSERID & "','" & tmpNow & "','1'")

        Timer1.Enabled = True
        ClearData()
    End Sub
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If txtPersonContact.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดลักษณะความสัมพันธ์ก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPersonContact.Select()
            Exit Sub
        End If

        If lblPersonContactCode.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดรหัสมาตรฐานก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim tmpPERSONCONTACT As String = txtPersonContact.Text.Replace(" ", "")


        Dim tmpStatus As String = ""
        If chkStatus.Checked = True Then
            tmpStatus = "0"
        Else
            tmpStatus = "1"
        End If

        If txtPersonContact.Text <> tmpName Then
            Dim ds As DataSet
            ds = ClsBusiness.Lc_Business.SELECT_TABLE(" a.ROWID,PERSON_CONTACT_CODE ", " l_mypcu_person_contact a  ", " WHERE PERSON_CONTACT_DESC = '" & tmpPERSONCONTACT & "' ")
            If ds.Tables(0).Rows.Count > 0 Then
                XtraMessageBox.Show("มีการกำหนดแล้ว ไม่สามารถบันทึกซ้ำได้!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)
        clsbusent.Lc_BusinessEntity.Updatem_table(" l_mypcu_person_contact ", "STATUS_AF = '" & tmpStatus & "', PERSON_CONTACT_DESC = '" & tmpPERSONCONTACT & "',PERSON_CONTACT_STD_CODE = '" & lblPersonContactCode.Text & "',USER_REC = '" & vUSERID & "',D_UPDATE = '" & tmpNow & "'", " ROWID = '" & tmpROWID & "'")

        Timer1.Enabled = True
        ClearData()
    End Sub
End Class