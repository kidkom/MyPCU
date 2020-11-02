Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Text
Imports System.DateTime
Imports System.Globalization
Imports DevExpress.XtraEditors
Imports ComponentOwl.BetterListView

Public Class frmBank
    Dim tmpROWID As String = ""
    Private Sub frmBank_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdSave.Enabled = False
        cmdDel.Enabled = False
        dtpDate.EditValue = Now.ToString("dd/MM/yyyy")

        With BetterListView1
            .Columns.Add(0).Text = "ROWID"
            .Columns(0).Width = 0
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ลำดับ"
            .Columns(1).Width = 60
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "ธนาคาร"
            .Columns(2).Width = 250
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "เลขที่บัญชี"
            .Columns(3).Width = 200
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "วันที่เริ่มบันทึก"
            .Columns(4).Width = 120
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "จำนวนเงินเริ่มต้น"
            .Columns(5).Width = 120
        End With

        Dim ds3 As DataSet
        ds3 = clsdataBus.Lc_Business.SELECT_TABLE("TOTAL", "acc_cash", " WHERE ROWID = '1' ")
        If ds3.Tables(0).Rows.Count > 0 Then
            txtCash.Text = CDbl(ds3.Tables(0).Rows(0).Item("TOTAL")).ToString("#,##0.00")
        End If

        cboProviderAction()
        Showdata()
    End Sub
    Private Sub cboProviderAction()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("PROVIDER,CONCAT(PROVIDER,' : ',IFNULL(B.PRENAME,''),NAME,' ',LNAME) AS PROVIDER_NAME", "m_provider A LEFT JOIN l_prename B ON(A.PRENAME = B.PRENAME_CODE)", " WHERE A.STATUS = '1' ORDER BY NAME")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboPROVIDER
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "PROVIDER_NAME"
                .Properties.ValueMember = "PROVIDER"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
    End Sub
    Private Sub Showdata()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("acc_bank", " WHERE STATUS_AF <> '8'")
        If ds.Tables(0).Rows.Count > 0 Then
            DisplayData(ds)
            Label18.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
        Else
            BetterListView1.Items.Clear()
            Label18.Text = "จำนวน 0 รายการ"
        End If

    End Sub
    Private Sub DisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itm As ListViewItem
        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                BetterListView1.Items.Add(dr("ROWID"))
                BetterListView1.Items(i).SubItems.Add((i + 1).ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("BANK").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
                If Not IsDBNull(dr("BANK_NO")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("BANK_NO").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If

                If CheckDate(DateTime.ParseExact(dr("DATE_START").ToString.Substring(0, 4) + 543 & dr("DATE_START").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("dd/MM/yyyy")) = False Then
                    BetterListView1.Items(i).SubItems.Add("")
                Else
                    BetterListView1.Items(i).SubItems.Add(Thaidate(dr("DATE_START"))).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                End If
                If Not IsDBNull(dr("AMOUNT")) Then
                    BetterListView1.Items(i).SubItems.Add(CDbl(dr("AMOUNT")).ToString("#,##0.00")).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right
                Else
                    BetterListView1.Items(i).SubItems.Add("0.00").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right
                End If

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If


                If Not IsDBNull(dr("STATUS_AF")) Then
                    If dr("STATUS_AF") = "0" Then
                        BetterListView1.Items(i).BackColor = Color.LightPink
                    End If
                End If

            Next
            BetterListView1.AutoResizeColumn(2, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(3, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)

            BetterListView1.ResumeSort(True)
            BetterListView1.EndUpdate()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub cmdAddPerson2_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        If dtpDate.EditValue = Nothing Then
            XtraMessageBox.Show("กรุณากำหนดวันที่เริ่มต้นก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtpDate.Select()
            Exit Sub
        End If
        If CDate(dtpDate.EditValue).ToString("MMdd") <> "0930" Then
            XtraMessageBox.Show("กรุณากำหนดวันที่เริ่มต้นเป็นวันที่ 30 ก.ย. เท่านั้น!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dtpDate.Select()
            Exit Sub
        End If
        If txtBank.Text.Trim = "" Then
            XtraMessageBox.Show("กรุณากำหนดธนาคารก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtBank.Select()
            Exit Sub
        End If
        If txtBankNo.Text.Trim = "" Then
            XtraMessageBox.Show("กรุณากำหนดเลขบัญชีธนาคารก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtBankNo.Select()
            Exit Sub
        End If
        If txtProvider.Text.Trim = "" Then
            XtraMessageBox.Show("กรุณากำหนดผู้บันทึกก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtProvider.Select()
            Exit Sub
        End If

        If CInt(txtCash.Text) <= 0 Then
            XtraMessageBox.Show("กรุณากำหนดยอดเงินสดคงเหลือยกมาก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCash.Select()
            Exit Sub
        End If

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("*", "acc_bank", " WHERE BANK_NO = '" & txtBankNo.Text & "'")

        If ds.Tables(0).Rows.Count > 0 Then
            XtraMessageBox.Show("ไม่สามารถบันทึกได้เนื่องจากมีการบันทึกเลขบัญชีนี้แล้ว!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If XtraMessageBox.Show("กรุณาตรจสอบจำนวนเงิน และข้อมูลต่างๆอีกครั้งก่อนบันทึก เพราะจะไม่สามารถแก้ไขข้อมูลได้อีก หากต้องการบันทึกกด Yes หากไม่ต้องการกด No", vProgram, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = System.Windows.Forms.DialogResult.No Then
            Exit Sub
        Else

            Dim tmpDate As String = ""
            tmpDate = CDate(dtpDate.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))

            Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate_En

            clsbusent.Lc_BusinessEntity.Insertm_table("acc_bank (DATE_START,BANK,BANK_NO,AMOUNT,PROVIDER,USER_REC,D_UPDATE,STATUS_AF)",
        "'" & tmpDate & "','" & txtBank.Text & "','" & txtBankNo.Text & "','" & CDbl(txtAmount.Text).ToString("0.00") & "','" & txtProvider.Text & "','" & vUSERID & "','" & tmpNow & "','1'")

            Dim ds2 As DataSet
            ds2 = clsdataBus.Lc_Business.SELECT_TABLE("ROWID", "acc_bank", " WHERE BANK_NO = '" & txtBankNo.Text & "'")
            If ds2.Tables(0).Rows.Count > 0 Then
                Dim tmpRowid As String = ds2.Tables(0).Rows(0).Item("ROWID")
                clsbusent.Lc_BusinessEntity.Insertm_table("acc_bank_data (DATE_SERV,MTYPE,BANK_ID,AMOUNT,PROVIDER,USER_REC,D_UPDATE,STATUS_AF)",
            "'" & tmpDate & "','0','" & tmpRowid & "','" & CDbl(txtAmount.Text).ToString("0.00") & "','" & txtProvider.Text & "','" & vUSERID & "','" & tmpNow & "','1'")
            End If
            Dim ds3 As DataSet
            ds3 = clsdataBus.Lc_Business.SELECT_TABLE("*", "acc_cash", " WHERE ROWID = '1' ")
            If ds3.Tables(0).Rows.Count = 0 Then
                clsbusent.Lc_BusinessEntity.Insertm_table("acc_cash (DATE_SERV,CASH_TYPE,ITEM,PAPER,MONEY_IN,MONEY_OUT,MONEY_BANK,TOTAL,PROVIDER,USER_REC,D_UPDATE,STATUS_AF)",
  "'" & tmpDate & "','00','','ยอดยกมา','','','','" & CDbl(txtCash.Text).ToString("0.00") & "','" & txtProvider.Text & "','" & vUSERID & "','" & tmpNow & "','1'")
            End If

        End If

        txtBank.Text = ""
        txtBankNo.Text = ""
        txtAmount.Text = "0.00"

        Showdata()
    End Sub


    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            tmpROWID = lvi.SubItems.Item(0).Text
            txtBank.Text = lvi.SubItems.Item(2).Text
            txtBankNo.Text = lvi.SubItems.Item(3).Text
            txtAmount.Text = lvi.SubItems.Item(5).Text
        Next
        cmdDel.Enabled = True
        cmdSave.Enabled = True
        cmdAdd.Enabled = False

    End Sub

    Private Sub cmdDel_Click(sender As Object, e As EventArgs) Handles cmdDel.Click
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("*", "acc_bank_data", " WHERE BANK_ID = '" & tmpROWID & "'")
        If ds.Tables(0).Rows.Count > 1 Then
            XtraMessageBox.Show("ไม่สามารถลบได้ เนื่องจากมีการบันทึกแล้ว!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            cmdDel.Enabled = False
            cmdDel.Enabled = False
            cmdAdd.Enabled = True
            Exit Sub
        Else
            Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)
            If XtraMessageBox.Show("ยืนยันการลบข้อมูล!!!", vProgram, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = System.Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                clsbusent.Lc_BusinessEntity.Delete_table("acc_bank", " WHERE ROWID = '" & tmpROWID & "'")
                cmdDel.Enabled = False
                cmdSave.Enabled = False
                cmdAdd.Enabled = True
            End If

        End If
        txtBank.Text = ""
        txtBankNo.Text = ""
        txtAmount.Text = "0.00"
        Showdata()
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate_En

        clsbusent.Lc_BusinessEntity.Updatem_table("acc_bank", "BANK_NO = '" & txtBankNo.Text & "',BANK = '" & txtBank.Text & "',USER_REC = '" & vUSERID & "',D_UPDATE = '" & tmpNow & "'", "ROWID = '" & tmpROWID & "'")

        cmdDel.Enabled = False
        cmdSave.Enabled = False
        cmdAdd.Enabled = True
        txtBank.Text = ""
        txtBankNo.Text = ""
        txtAmount.Text = "0.00"
        Showdata()
    End Sub
    Private Sub txtBank_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBank.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                txtBankNo.Select()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtBankNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBankNo.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                txtAmount.Select()
                txtAmount.SelectAll()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAmount.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If IsNumeric(txtAmount.Text) = False Then
                    XtraMessageBox.Show("บันทึกตัวเลขไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtAmount.SelectAll()
                Else
                    txtAmount.Text = CDbl(txtAmount.Text).ToString("#,##0.00")
                End If
                txtProvider.Select()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtAmount_Leave(sender As Object, e As EventArgs) Handles txtAmount.Leave
        If IsNumeric(txtAmount.Text) = False Then
            XtraMessageBox.Show("บันทึกตัวเลขไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAmount.SelectAll()
        Else
            txtAmount.Text = CDbl(txtAmount.Text).ToString("#,##0.00")
        End If
    End Sub
    Private Sub txtProvider_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProvider.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                cboPROVIDER.EditValue = txtProvider.Text
                cmdSave.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cboPROVIDER_EditValueChanged(sender As Object, e As EventArgs) Handles cboPROVIDER.EditValueChanged
        txtProvider.Text = cboPROVIDER.EditValue
    End Sub

    Private Sub txtCash_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCash.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If IsNumeric(txtCash.Text) = False Then
                    XtraMessageBox.Show("บันทึกตัวเลขไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCash.SelectAll()
                Else
                    txtCash.Text = CDbl(txtAmount.Text).ToString("#,##0.00")
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCash_Leave(sender As Object, e As EventArgs) Handles txtCash.Leave
        If IsNumeric(txtCash.Text) = False Then
            XtraMessageBox.Show("บันทึกตัวเลขไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCash.SelectAll()
        Else
            txtCash.Text = CDbl(txtAmount.Text).ToString("#,##0.00")
        End If
    End Sub
End Class