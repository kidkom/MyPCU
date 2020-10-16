Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors

Public Class frmDrugArea
    Dim tmpROWID As String = ""
    Dim tmpCode As String = ""
    Dim tmpName As String = ""
    Private Sub frmDrugArea_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 0
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "รหัส"
            .Columns(1).Width = 100
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "ตำแหน่งที่ให้วัคซีน"
            .Columns(2).Width = 120
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "รหัสมาตรฐาน"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "ความหมาย"
            .Columns(4).Width = 120
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
    Private Sub ShowData()
        Dim ds As DataSet
        Dim tmpSQL As String = ""
        If chkAll.Checked = True Then
            tmpSQL = " WHERE VACCINE = '1'"
        ElseIf chkUseOnly.Checked = True Then
            tmpSQL = " WHERE STATUS_AF = '1' AND VACCINE = '1' "
        ElseIf chkCancel.Checked = True Then
            tmpSQL = " WHERE STATUS_AF = '0' AND VACCINE = '1' "
        End If
        ds = clsdataBus.Lc_Business.SELECT_TABLE(" ROWID,AREA_CODE,AREA,STD_CODE,STD_DESC,STATUS_AF ", " l_drug_area", " " & tmpSQL & " ")
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

                BetterListView1.Items(i).SubItems.Add(dr("AREA_CODE").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("AREA").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("STD_CODE").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("STD_DESC").ToString).AlignHorizontal = TextAlignmentHorizontal.Left


                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                If dr("STATUS_AF") = "0" Then
                    BetterListView1.Items(i).BackColor = Color.LightPink
                End If

            Next
            BetterListView1.AutoResizeColumn(2, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(4, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)

            BetterListView1.EndUpdate()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub GenCode()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE(" (AREA_CODE + 1) AS AREA_CODE ", " l_drug_area  ", " ORDER BY  AREA_CODE+0 DESC LIMIT 1 ")
        If ds.Tables(0).Rows.Count > 0 Then
            tmpCode = CInt(ds.Tables(0).Rows(0).Item("AREA_CODE")).ToString("0000")
        Else
            tmpCode = "0001"
        End If
    End Sub
    Private Sub ClearData()
        txtMarialStatus.Text = ""
        lblMarialStatusCode.Text = ""
        chkStatus.Checked = False
        cmdAdd.Enabled = True
        cmdSave.Enabled = False
        tmpROWID = ""

    End Sub
    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            tmpROWID = lvi.SubItems.Item(0).Text
        Next

    End Sub
    Private Sub BetterListView1_Click(sender As Object, e As EventArgs) Handles BetterListView1.Click
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("STD_DESC,STATUS_AF,STD_CODE", " l_drug_area", " WHERE ROWID = '" & tmpROWID & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            txtMarialStatus.Text = ds.Tables(0).Rows(0).Item("STD_DESC")
            tmpName = txtMarialStatus.Text
            If ds.Tables(0).Rows(0).Item("STATUS_AF") = "0" Then
                chkStatus.Checked = True
            Else
                chkStatus.Checked = False
            End If
            lblMarialStatusCode.Text = ds.Tables(0).Rows(0).Item("STD_CODE")
            cboMarialStatus.EditValue = lblMarialStatusCode.Text
            cmdAdd.Enabled = False
            cmdSave.Enabled = True
        End If
    End Sub
    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        If txtMarialStatus.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดสถานะการให้วัคซีนก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMarialStatus.Select()
            Exit Sub
        End If

        'If lblMarialStatusCode.Text = "" Then
        '    XtraMessageBox.Show("กรุณากำหนดรหัสมาตรฐานก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If

        Dim tmpMSTATUS As String = txtMarialStatus.Text.Replace(" ", "")


        Dim ds As DataSet
        ds = ClsBusiness.Lc_Business.SELECT_TABLE(" ROWID,STD_CODE ", " l_drug_area  ", " WHERE STD_DESC = '" & tmpMSTATUS & "' ")
        If ds.Tables(0).Rows.Count > 0 Then
            XtraMessageBox.Show("มีการกำหนดแล้ว ไม่สามารถบันทึกซ้ำได้!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        GenCode()
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate_En()

        clsbusent.Lc_BusinessEntity.Insertm_table("l_drug_area(AREA_CODE,AREA,STD_CODE,STD_DESC,USER_REC,D_UPDATE,STATUS_AF,VACCINE)",
         "'" & tmpCode & "','" & tmpMSTATUS & "','','','" & vUSERID & "','" & tmpNow & "','1','1'")

        Timer1.Enabled = True
        ClearData()
    End Sub
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If txtMarialStatus.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดสถานะการให้วัคซีนก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMarialStatus.Select()
            Exit Sub
        End If

        'If lblMarialStatusCode.Text = "" Then
        '    XtraMessageBox.Show("กรุณากำหนดรหัสมาตรฐานก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If

        Dim tmpMSTATUS As String = txtMarialStatus.Text.Replace(" ", "")


        Dim tmpStatus As String = ""
        If chkStatus.Checked = True Then
            tmpStatus = "0"
        Else
            tmpStatus = "1"
        End If

        If txtMarialStatus.Text <> tmpName Then
            Dim ds As DataSet
            ds = ClsBusiness.Lc_Business.SELECT_TABLE(" ROWID,STD_CODE ", " l_drug_area  ", " WHERE STD_DESC = '" & tmpMSTATUS & "' ")
            If ds.Tables(0).Rows.Count > 0 Then
                XtraMessageBox.Show("มีการกำหนดแล้ว ไม่สามารถบันทึกซ้ำได้!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)
        clsbusent.Lc_BusinessEntity.Updatem_table(" l_drug_area ", "STATUS_AF = '" & tmpStatus & "', STD_DESC = '" & tmpMSTATUS & "',TD_CODE = '" & lblMarialStatusCode.Text & "',USER_REC = '" & vUSERID & "',D_UPDATE = '" & tmpNow & "'", " ROWID = '" & tmpROWID & "'")

        Timer1.Enabled = True
        ClearData()
    End Sub



End Class