Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmLookupEducation
    Dim tmpROWID As String = ""
    Dim tmpCode As String = ""
    Dim tmpName As String = ""

    Private Sub frmLookupEducation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdSave.Enabled = False

        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 0
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "รหัส"
            .Columns(1).Width = 100
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "การศึกษา"
            .Columns(2).Width = 120
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "รหัสมาตรฐาน"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "ความหมาย"
            .Columns(4).Width = 120
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        EducationnAction()
        Timer1.Enabled = True
    End Sub
    Private Sub EducationnAction()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("EDUCATION_DESC,EDUCATION_CODE", " l_education", "")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboEducation
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "EDUCATION_DESC"
                .Properties.ValueMember = "EDUCATION_CODE"
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

    Private Sub cboEducation_EditValueChanged(sender As Object, e As EventArgs) Handles cboEducation.EditValueChanged
        lblEducationCode.Text = cboEducation.EditValue
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
        ds = clsdataBus.Lc_Business.SELECT_TABLE(" a.ROWID,a.EDUCATION_CODE,a.EDUCATION_DESC,a.EDUCATION_STD_CODE,b.EDUCATION_DESC AS EDUCATION_STD__DESC,STATUS_AF ", " l_mypcu_education a LEFT JOIN l_education b ON(a.EDUCATION_STD_CODE  = b.EDUCATION_CODE) ", " " & tmpSQL & " ")
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

                BetterListView1.Items(i).SubItems.Add(dr("EDUCATION_CODE").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("EDUCATION_DESC").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("EDUCATION_STD_CODE").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("EDUCATION_STD__DESC").ToString).AlignHorizontal = TextAlignmentHorizontal.Center


                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                If dr("STATUS_AF") = "0" Then
                    BetterListView1.Items(i).BackColor = Color.LightPink
                End If

            Next
            BetterListView1.AutoResizeColumn(2, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(4, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            'BetterListView1.AutoResizeColumn(6, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.EndUpdate()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub GenCode()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE(" (EDUCATION_CODE + 1) AS EDUCATION_CODE ", " l_mypcu_education a  ", " ORDER BY  EDUCATION_CODE+0 DESC LIMIT 1 ")
        If ds.Tables(0).Rows.Count > 0 Then
            tmpCode = CInt(ds.Tables(0).Rows(0).Item("EDUCATION_CODE")).ToString("0000")
        Else
            tmpCode = "0001"
        End If
    End Sub
    Private Sub ClearData()
        txtEducation.Text = ""
        lblEducationCode.Text = ""
        chkStatus.Checked = False
        cmdAdd.Enabled = True
        cmdSave.Enabled = False
        tmpROWID = ""
        cboEducation.Text = ""
        txtEducation.Select()
    End Sub
    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            tmpROWID = lvi.SubItems.Item(0).Text
        Next

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("EDUCATION_DESC,STATUS_AF,EDUCATION_STD_CODE", " l_mypcu_education ", " WHERE ROWID = '" & tmpROWID & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            txtEducation.Text = ds.Tables(0).Rows(0).Item("EDUCATION_DESC")
            tmpName = txtEducation.Text
            If ds.Tables(0).Rows(0).Item("STATUS_AF") = "0" Then
                chkStatus.Checked = True
            Else
                chkStatus.Checked = False
            End If
            lblEducationCode.Text = ds.Tables(0).Rows(0).Item("EDUCATION_STD_CODE")
            cboEducation.EditValue = lblEducationCode.Text
            cmdAdd.Enabled = False
            cmdSave.Enabled = True
        End If
    End Sub
    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        If txtEducation.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดการศึกษาก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtEducation.Select()
            Exit Sub
        End If

        If lblEducationCode.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดรหัสมาตรฐานก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim tmpEDUCATION As String = txtEducation.Text.Replace(" ", "")


        Dim ds As DataSet
        ds = ClsBusiness.Lc_Business.SELECT_TABLE(" a.ROWID,EDUCATION_CODE ", " l_mypcu_education a  ", " WHERE EDUCATION_DESC = '" & tmpEDUCATION & "' ")
        If ds.Tables(0).Rows.Count > 0 Then
            XtraMessageBox.Show("มีการกำหนดแล้ว ไม่สามารถบันทึกซ้ำได้!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        GenCode()
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)
        clsbusent.Lc_BusinessEntity.Insertm_table("l_mypcu_education (EDUCATION_CODE,EDUCATION_DESC,EDUCATION_STD_CODE,USER_REC,D_UPDATE,STATUS_AF)",
         "'" & tmpCode & "','" & tmpEDUCATION & "','" & lblEducationCode.Text & "','" & vUSERID & "','" & tmpNow & "','1'")

        Timer1.Enabled = True
        ClearData()
    End Sub
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If txtEducation.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดการศึกษาก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtEducation.Select()
            Exit Sub
        End If

        If lblEducationCode.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดรหัสมาตรฐานก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim tmpEDUCATION As String = txtEducation.Text.Replace(" ", "")


        Dim tmpStatus As String = ""
        If chkStatus.Checked = True Then
            tmpStatus = "0"
        Else
            tmpStatus = "1"
        End If

        If txtEducation.Text <> tmpName Then
            Dim ds As DataSet
            ds = ClsBusiness.Lc_Business.SELECT_TABLE(" a.ROWID,EDUCATION_CODE ", " l_mypcu_education a  ", " WHERE EDUCATION_DESC = '" & tmpEDUCATION & "' ")
            If ds.Tables(0).Rows.Count > 0 Then
                XtraMessageBox.Show("มีการกำหนดแล้ว ไม่สามารถบันทึกซ้ำได้!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)
        clsbusent.Lc_BusinessEntity.Updatem_table(" l_mypcu_education ", "STATUS_AF = '" & tmpStatus & "', EDUCATION_DESC = '" & tmpEDUCATION & "',EDUCATION_STD_CODE = '" & lblEducationCode.Text & "',USER_REC = '" & vUSERID & "',D_UPDATE = '" & tmpNow & "'", " ROWID = '" & tmpROWID & "'")
        Timer1.Enabled = True
        ClearData()
    End Sub
End Class