Imports clsDataAcc8 = MyPCU.ClsDataAccess8
Imports clsdataBus8 = MyPCU.ClsBusiness8
Imports clsbusent8 = MyPCU.ClsBusinessEntity8
Imports clsdataBus = MyPCU.ClsBusiness
Imports System.DateTime
Imports System.Globalization
Imports MySql.Data.MySqlClient
Imports System.IO
Imports Microsoft.Reporting.WinForms
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmAssetFix
    Dim tmpAssetID As String = ""
    Dim tmpID As String = ""
    Dim tmpROWID As String = ""
    Dim tmpUpdate As Boolean = False
    Dim dsRpt As New DataSet
    Dim dsRpt2 As New DataSet
    Dim CurrentReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
    Private Sub frmAssetFix_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdDel.Enabled = False
        lblASSET_CODE_ID.Text = picCODE
        txtASSET_NAME.Text = PicNAME

        CalendarControl1.Visible = False
        txtDATE_IN.Text = Now.ToString("dd/MM/yyyy")


        tmpAssetID = picAssetCODE
        tmpID = PicID
        cmdPrint.Enabled = False
        With ListView1
            .Columns.Add("ROWID", 0, HorizontalAlignment.Center)
            .Columns.Add("ลำดับ", 80, HorizontalAlignment.Center)
            .Columns.Add("วันที่", 150, HorizontalAlignment.Center)
            .Columns.Add("รายละเอียด", 400, HorizontalAlignment.Left)
            .Columns.Add("จำนวนเงิน", 150, HorizontalAlignment.Right)
            .Columns.Add("งบประมาณ", 150, HorizontalAlignment.Center)
            .Columns.Add("เอกสารที่เกี่ยวข้อง", 200, HorizontalAlignment.Left)
        End With
        ListView1.View = View.Details
        ListView1.GridLines = True

        With BetterListView1
            .Columns.Add(0).Text = "ROWID"
            .Columns(0).Width = 0
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ลำดับ"
            .Columns(1).Width = 80
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "วันที่"
            .Columns(2).Width = 80
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "รายละเอียด"
            .Columns(3).Width = 400
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "จำนวนเงิน"
            .Columns(4).Width = 150
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "งบประมาณ"
            .Columns(5).Width = 150
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "เอกสารที่เกี่ยวข้อง"
            .Columns(6).Width = 200
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        Dim ds2 As DataSet
        ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("RECIEVECODE,RECIEVENAME", "l_recieve ", " WHERE STATUS_AF = '1' ORDER BY RECIEVECODE+0 ")
        If ds2.Tables(0).Rows.Count > 0 Then
            With cboBUDGET
                .Properties.DataSource = ds2.Tables(0)
                .Properties.DisplayMember = "RECIEVENAME"
                .Properties.ValueMember = "RECIEVECODE"
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If

        If fixNumID <> "" Then
            cmdFixMat.Enabled = True
            txtDOC_NO.Text = "เลขที่ใบแจ้งซ่อม " & fixNumID
            txtDETAIL.Text = "เลขที่ใบแจ้งซ่อม " & fixNumID
        Else
            cmdFixMat.Enabled = False
        End If
        ShowData()
    End Sub
    Private Sub ShowData()
        Dim ds2 As DataSet
        ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("*", " m_assets_fix ", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "' AND ASSET_STATUS = '1' AND STATUS_AF = '1' ORDER BY DATE_IN ")
        If ds2.Tables(0).Rows.Count > 0 Then
            BetterDisplayData(ds2)
            lblAmount.Text = "จำนวน " & ds2.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
            cmdPrint.Enabled = True
        Else
            BetterListView1.Items.Clear()
            lblAmount.Text = "จำนวน 0 รายการ"
            cmdPrint.Enabled = False
        End If

    End Sub
    Private Sub BetterDisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itms As New BetterListViewItem
        Dim tmpPrename As String = ""
        Dim tmpSum As Double = 0.0
        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                BetterListView1.Items.Add(dr("ROWID").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add((i + 1).ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add((DateTime.ParseExact(dr("DATE_IN").ToString.Substring(0, 4) + 543 & dr("DATE_IN").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy")).ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("DETAIL").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add((CDbl(dr("PRICE")).ToString("#,##0.00")).ToString).AlignHorizontal = TextAlignmentHorizontal.Right
                If Not IsDBNull(dr("BUDGETTYPE")) Then
                    BetterListView1.Items(i).SubItems.Add(ClsBusiness8.Lc_Business8.SELECT_NAME_BUDGET(dr("BUDGETTYPE")).ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                BetterListView1.Items(i).SubItems.Add(dr("DOC_NO").ToString).AlignHorizontal = TextAlignmentHorizontal.Left

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                If dr("ASSET_STATUS") = "0" Then
                    BetterListView1.Items(i).BackColor = Color.LightPink
                End If
            Next
            BetterListView1.AutoResizeColumn(2, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(3, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.ResumeSort()
            BetterListView1.EndUpdate()

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub DisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itm As ListViewItem
        Dim NAMEUSER As String = ""
        Dim tmpPrename As String = ""
        Dim tmpProvider As String = ""
        Try
            ListView1.Items.Clear()
            ListView1.BeginUpdate()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                itm = ListView1.Items.Add(dr("ROWID"))
                itm.SubItems.Add(i + 1)
                itm.SubItems.Add(DateTime.ParseExact(dr("DATE_IN").ToString.Substring(0, 4) + 543 & dr("DATE_IN").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy"))
                itm.SubItems.Add(dr("DETAIL"))
                itm.SubItems.Add(CDbl(dr("PRICE")).ToString("#,##0.00"))
                If Not IsDBNull(dr("BUDGETTYPE")) Then
                    itm.SubItems.Add(ClsBusiness8.Lc_Business8.SELECT_NAME_BUDGET(dr("BUDGETTYPE")))
                Else
                    itm.SubItems.Add("")
                End If
                itm.SubItems.Add(dr("DOC_NO"))

                If (itm.Index Mod 2) = 0 Then
                    itm.BackColor = Color.Thistle
                End If

            Next
            ListView1.EndUpdate()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub txtPRICE_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPRICE.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Try

                    txtPRICE.Text = CDbl(txtPRICE.Text).ToString("#,##0.00")
                Catch ex As Exception
                    XtraMessageBox.Show("บันทึกตัวเลขไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtPRICE.SelectAll()

                    Exit Sub
                End Try
                cboBUDGET.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPRICE_Leave(sender As Object, e As EventArgs) Handles txtPRICE.Leave
        Try

            txtPRICE.Text = CDbl(txtPRICE.Text).ToString("#,##0.00")
        Catch ex As Exception
            XtraMessageBox.Show("บันทึกตัวเลขไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPRICE.SelectAll()

            Exit Sub
        End Try
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If txtDATE_IN.Text = "" Then
            XtraMessageBox.Show("กรุณาวันที่บันทึกก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If txtDETAIL.Text = "" Then
            XtraMessageBox.Show("กรุณาบันทึกรายละเอียดก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDETAIL.Select()
            Exit Sub
        End If

        If CInt(txtPRICE.Text) < 0 Then
            XtraMessageBox.Show("กรุณาบันทึกจำนวนเงินก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPRICE.Select()
            txtPRICE.SelectAll()
            Exit Sub
        End If

        Dim DATE_IN As String = CDate(txtDATE_IN.Text).ToString("yyyyMMdd")
        DATE_IN = DATE_IN.ToString.Substring(0, 4) - 543 & DATE_IN.ToString.Substring(4, 4)
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate()


        If tmpUpdate = False Then
            clsbusent8.Lc_BusinessEntity8.InsertM_table("m_assets_fix (ASSET_ID,ID,ASSET_STATUS,DATE_IN,DOC_NO,DETAIL,BUDGETTYPE,PRICE,USER_REC,D_UPDATE,STATUS_AF,STATUS_SEND)",
            "'" & tmpAssetID & "','" & tmpID & "','1','" & DATE_IN & "','" & txtDOC_NO.Text & "','" & txtDETAIL.Text & "','" & cboBUDGET.EditValue & "','" & CDbl(txtPRICE.Text).ToString("0.00") & "','" & vUSERID & "','" & tmpNow & "','1','0'")
            ClearData()
            ShowData()
        Else
            clsbusent8.Lc_BusinessEntity8.UpdateM_table("m_assets_fix", " DATE_IN = '" & DATE_IN & "',DOC_NO = '" & txtDOC_NO.Text & "',DETAIL = '" & txtDETAIL.Text & "',BUDGETTYPE = '" & cboBUDGET.EditValue & "',PRICE = '" & CDbl(txtPRICE.Text).ToString("0.00") & "',USER_REC = '" & vUSERID & "',D_UPDATE = '" & tmpNow & "',STATUS_SEND = '0'", "  ROWID  = '" & tmpROWID & "'")
            ClearData()
            ShowData()
        End If
    End Sub
    Private Sub ClearData()
        txtDATE_IN.Text = Now.ToString("dd/MM/yyyy")
        txtPRICE.Text = "0.00"
        txtDETAIL.Text = ""
        cmdDel.Enabled = False
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        For i As Integer = 0 To ListView1.SelectedItems.Count - 1
            Dim lvi As ListViewItem
            lvi = ListView1.SelectedItems(i)
            tmpROWID = lvi.SubItems.Item(0).Text
        Next
        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("*", " m_assets_fix ", " WHERE ROWID = '" & tmpROWID & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            tmpUpdate = True
            cmdDel.Enabled = True

            txtDATE_IN.Text = DateTime.ParseExact(ds2.Tables(0).Rows(0).Item("DATE_IN").ToString.Substring(0, 4) + 543 & ds2.Tables(0).Rows(0).Item("DATE_IN").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("dd/MM/yyyy")
            txtDETAIL.Text = ds2.Tables(0).Rows(0).Item("DETAIL")
            cboBUDGET.EditValue = ds2.Tables(0).Rows(0).Item("BUDGETTYPE")
            txtPRICE.Text = CDbl(ds2.Tables(0).Rows(0).Item("PRICE")).ToString("#,##0.00")
            txtDOC_NO.Text = ds2.Tables(0).Rows(0).Item("DOC_NO")
        End If
    End Sub

    Private Sub cmdDel_Click(sender As Object, e As EventArgs) Handles cmdDel.Click
        If XtraMessageBox.Show("ต้องการลบข้อมูลนี้ใช่หรือไม่?", vProgram, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)
            clsbusent8.Lc_BusinessEntity8.UpdateM_table("m_assets_fix", " STATUS_AF = '0',STATUS_SEND = '0',USER_REC = '" & vUSERID & "',D_UPDATE = '" & tmpNow & "'", "  ROWID  = '" & tmpROWID & "'")
            ClearData()
            ShowData()
        End If
    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        Dim dt As DataTable
        dt = New DataTable()
        dt.Clear()
        Dim drRpt As DataRow
        Dim Coulumn1 = New DataColumn("FIELD1", Type.GetType("System.String"))
        Dim Coulumn2 = New DataColumn("FIELD2", Type.GetType("System.String"))
        Dim Coulumn3 = New DataColumn("FIELD3", Type.GetType("System.String"))
        Dim Coulumn4 = New DataColumn("FIELD4", Type.GetType("System.String"))
        Dim Coulumn5 = New DataColumn("FIELD5", Type.GetType("System.String"))
        Dim Coulumn6 = New DataColumn("FIELD6", Type.GetType("System.String"))
        Dim Coulumn7 = New DataColumn("FIELD7", Type.GetType("System.String"))
        Dim Coulumn8 = New DataColumn("FIELD8", Type.GetType("System.String"))
        Dim Coulumn9 = New DataColumn("FIELD9", Type.GetType("System.String"))
        Dim Coulumn10 = New DataColumn("FIELD10", Type.GetType("System.String"))
        Dim Coulumn11 = New DataColumn("FIELD11", Type.GetType("System.String"))
        Dim Coulumn12 = New DataColumn("FIELD12", Type.GetType("System.String"))
        dt.Columns.Add(Coulumn1)
        dt.Columns.Add(Coulumn2)
        dt.Columns.Add(Coulumn3)
        dt.Columns.Add(Coulumn4)
        dt.Columns.Add(Coulumn5)
        dt.Columns.Add(Coulumn6)
        dt.Columns.Add(Coulumn7)
        dt.Columns.Add(Coulumn8)
        dt.Columns.Add(Coulumn9)
        dt.Columns.Add(Coulumn10)
        dt.Columns.Add(Coulumn11)
        dt.Columns.Add(Coulumn12)

        For i = 0 To BetterListView1.Items.Count - 1
            dsRpt.Tables.Clear()
            drRpt = dt.NewRow()

            drRpt("FIELD1") = "รายงานการซ่อมบำรุง ปรับปรุง ทรัพย์สิน "
            drRpt("FIELD2") = "ส่วนราชการ : " & ClsBusiness.Lc_Business.SELECT_NAME_HCODE(vHcode).Replace("รพ.สต.", "โรงพยาบาลส่งเสริมสุขภาพตำบล")
            drRpt("FIELD3") = "รายการทรัพย์สิน : " & txtASSET_NAME.Text & vbCrLf & "เลขที่ทรัพย์สิน : " & lblASSET_CODE_ID.Text
            'drRpt("FIELD4") = "เลขที่ทรัพย์สิน : " & lblASSET_CODE_ID.Text
            drRpt("FIELD5") = BetterListView1.Items(i).SubItems(1).Text
            drRpt("FIELD6") = BetterListView1.Items(i).SubItems(2).Text
            drRpt("FIELD7") = BetterListView1.Items(i).SubItems(3).Text
            drRpt("FIELD8") = BetterListView1.Items(i).SubItems(4).Text
            drRpt("FIELD9") = BetterListView1.Items(i).SubItems(5).Text
            drRpt("FIELD10") = BetterListView1.Items(i).SubItems(6).Text
            dt.Rows.Add(drRpt)
        Next

        dsRpt.Tables.Add(dt)



        Dim fReport As New frmReportView
        Dim params As ReportParameter

        params = New ReportParameter("RateId")

        fReport.ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\Reports\RptAssetFixe.rdlc"

        fReport.ReportViewer1.LocalReport.DataSources.Clear()
        CurrentReportDataSource.Name = "DataSet20F"
        CurrentReportDataSource.value = dsRpt.Tables(0)
        fReport.ReportViewer1.LocalReport.DataSources.Add(CurrentReportDataSource)
        fReport.ShowDialog()
    End Sub

    Private Sub cmdCalenda_Click(sender As Object, e As EventArgs) Handles cmdCalenda.Click
        If CalendarControl1.Visible = False Then
            CalendarControl1.Visible = True
            CalendarControl1.EditValue = txtDATE_IN.Text
        Else
            CalendarControl1.Visible = False
        End If

    End Sub
    Private Sub CalendarControl1_DoubleClick(sender As Object, e As EventArgs) Handles CalendarControl1.DoubleClick
        txtDATE_IN.Text = CalendarControl1.EditValue
        CalendarControl1.Visible = False
        If CheckDateToday(CDate(txtDATE_IN.Text).ToString("yyyyMMdd")) = False Then
            XtraMessageBox.Show("บันทึกวันที่มากกว่าวันปัจจุบัน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDATE_IN.Text = Now.ToString("dd/MM/yyyy")
            Exit Sub
        End If

    End Sub

    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            tmpROWID = lvi.SubItems.Item(0).Text
        Next
        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("*", " m_assets_fix ", " WHERE ROWID = '" & tmpROWID & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            tmpUpdate = True
            cmdDel.Enabled = True

            txtDATE_IN.Text = DateTime.ParseExact(ds2.Tables(0).Rows(0).Item("DATE_IN").ToString.Substring(0, 4) + 543 & ds2.Tables(0).Rows(0).Item("DATE_IN").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("dd/MM/yyyy")
            CalendarControl1.EditValue = txtDATE_IN.Text
            txtDETAIL.Text = ds2.Tables(0).Rows(0).Item("DETAIL")
            cboBUDGET.EditValue = ds2.Tables(0).Rows(0).Item("BUDGETTYPE")
            txtPRICE.Text = CDbl(ds2.Tables(0).Rows(0).Item("PRICE")).ToString("#,##0.00")
            txtDOC_NO.Text = ds2.Tables(0).Rows(0).Item("DOC_NO")
        End If
    End Sub

    Private Sub cmdFixMat_Click(sender As Object, e As EventArgs) Handles cmdFixMat.Click
        Dim f As New frmAssetMatFix
        f.ShowDialog()
        Dim ds As DataSet
        ds = clsdataBus8.Lc_Business8.SELECT_TABLE(" SUM(TOTAL) AS S_TOTAL ", "  m_fix_mat ", " WHERE  FIX_ID = '" & fixNumID & "' AND STATUS_AF <> '8' GROUP BY FIX_ID  ")
        If ds.Tables(0).Rows.Count > 0 Then
            txtPRICE.Text = ds.Tables(0).Rows(0).Item("S_TOTAL")
        End If

    End Sub

    Private Sub CalendarControl1_Click(sender As Object, e As EventArgs) Handles CalendarControl1.Click

    End Sub

    Private Sub txtDATE_IN_Click(sender As Object, e As EventArgs) Handles txtDATE_IN.Click

    End Sub
End Class