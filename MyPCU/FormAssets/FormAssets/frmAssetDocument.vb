Imports clsDataAcc8 = MyPCU.ClsDataAccess8
Imports clsdataBus8 = MyPCU.ClsBusiness8
Imports clsbusent8 = MyPCU.ClsBusinessEntity8
Imports clsdataBus = MyPCU.ClsBusiness
Imports System.DateTime
Imports System.Globalization
Imports MySql.Data.MySqlClient
Imports System.IO
Imports TwainLib
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmAssetDocument
    Dim tmpAssetID As String = ""
    Dim tmpID As String = ""
    Dim tmpROWID As String = ""
    Dim tmpUpdate As Boolean = False
    Private Sub frmAssetDocument_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdPDF.Enabled = False
        cmdDel.Enabled = False
        CalendarControl1.Visible = False
        txtDATE_IN.Text = Now.ToString("dd/MM/yyyy")
        lblASSET_CODE_ID.Text = picCODE
        txtASSET_NAME.Text = PicNAME

        tmpAssetID = picAssetCODE
        tmpID = PicID

        With ListView1
            .Columns.Add("ROWID", 0, HorizontalAlignment.Center)
            .Columns.Add("ลำดับ", 80, HorizontalAlignment.Center)
            .Columns.Add("วันที่", 150, HorizontalAlignment.Center)
            .Columns.Add("รายการ", 500, HorizontalAlignment.Left)
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
            .Columns.Add(3).Text = "รายการ"
            .Columns(3).Width = 400
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With
        ShowData()
    End Sub
    Private Sub ShowData()
        Dim ds2 As DataSet
        ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("*", " t_document ", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "' ORDER BY DATE_IN DESC")
        If ds2.Tables(0).Rows.Count > 0 Then
            BetterDisplayData(ds2)
            lblAmount.Text = "จำนวน " & ds2.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
        Else
            BetterListView1.Items.Clear()
            lblAmount.Text = "จำนวน 0 รายการ"
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


                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
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

                If (itm.Index Mod 2) = 0 Then
                    itm.BackColor = Color.WhiteSmoke
                End If

            Next
            ListView1.EndUpdate()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub cmdSearchID_Click(sender As Object, e As EventArgs) Handles cmdSearchID.Click
        Dim opf As XtraOpenFileDialog = New XtraOpenFileDialog
        opf.Filter = "PDF files (*.pdf)|*.pdf"
        opf.FilterIndex = 0
        opf.RestoreDirectory = True

        If opf.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim stFilePathAndName As String = opf.FileName
            Dim MyFile As IO.FileInfo = New IO.FileInfo(stFilePathAndName)
            txtFile.Text = opf.FileName
        End If


    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        If txtDETAIL.Text = "" Then
            XtraMessageBox.Show("กรุณาบันทึกรายละเอียดก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDETAIL.Select()
            Exit Sub
        End If


        Dim SQL As String = ""
        Dim conn As MySqlConnection = New MySqlConnection
        Dim cmd As New MySqlCommand
        Dim FileSize As UInt32
        Dim bytes As Byte()


        If txtFile.Text <> "" Then
            Dim fs As New FileStream(txtFile.Text, FileMode.Open, FileAccess.Read)
            Dim br As New BinaryReader(fs)

            bytes = System.IO.File.ReadAllBytes(txtFile.Text)
            FileSize = bytes.Length
        End If



        Dim DATE_IN As String = CDate(txtDATE_IN.Text).ToString("yyyyMMdd")
        DATE_IN = DATE_IN.ToString.Substring(0, 4) - 543 & DATE_IN.ToString.Substring(4, 4)
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate()


        If tmpUpdate = False Then
            If txtFile.Text = "" Then
                XtraMessageBox.Show("กรุณากำหนดไฟล์เอกสารที่ต้องการบันทึกก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmdSearchID.Focus()
                Exit Sub
            End If

            If Not txtFile.Text.Contains(".pdf") Then
                XtraMessageBox.Show("กรุณากำหนดไฟล์เอกสารเป็น PDF ไฟล์!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmdSearchID.Focus()
                Exit Sub
            End If
            SQL = "INSERT INTO t_document (ASSET_ID,ID,DATE_IN,DOC_NO,DETAIL,IMG,FILESIZE,USER_REC,D_UPDATE) VALUES(@ASSET_ID,@ID,@DATE_IN,@DOC_NO,@DETAIL,@IMG,@FILESIZE,@USER_REC,@D_UPDATE)"
            conn.ConnectionString = "Data Source=" & clsDataAcc8.G_DBIPServer8 & ";port=" & clsDataAcc8.G_DBPortServer8 & ";Database= " & clsDataAcc8.G_DBName8 & ";user id=" & clsDataAcc8.G_DBUserName8 & ";password=" & clsDataAcc8.G_DBPassword8 & ""
            conn.Open()
            cmd.Connection = conn
            cmd.CommandText = SQL
            cmd.Parameters.AddWithValue("@ASSET_ID", tmpAssetID)
            cmd.Parameters.AddWithValue("@ID", tmpID)
            cmd.Parameters.AddWithValue("@DATE_IN", DATE_IN)
            cmd.Parameters.AddWithValue("@DOC_NO", txtDOC_NO.Text)
            cmd.Parameters.AddWithValue("@DETAIL", txtDETAIL.Text)
            cmd.Parameters.AddWithValue("@IMG", bytes)
            cmd.Parameters.AddWithValue("@FILESIZE", FileSize)
            cmd.Parameters.AddWithValue("@USER_REC", vUSERID)
            cmd.Parameters.AddWithValue("@D_UPDATE", tmpNow)
            cmd.ExecuteNonQuery()
            conn.Close()
        Else
            If txtFile.Text = "" Then
                SQL = "UPDATE t_document SET DATE_IN = @DATE_IN,DOC_NO = @DOC_NO,DETAIL= @DETAIL,FILESIZE = @FILESIZE,USER_REC = @USER_REC,D_UPDATE = @D_UPDATE  WHERE ROWID = '" & tmpROWID & "'"
                conn.ConnectionString = "Data Source=" & clsDataAcc8.G_DBIPServer8 & ";port=" & clsDataAcc8.G_DBPortServer8 & ";Database= " & clsDataAcc8.G_DBName8 & ";user id=" & clsDataAcc8.G_DBUserName8 & ";password=" & clsDataAcc8.G_DBPassword8 & ""
                conn.Open()
                cmd.Connection = conn
                cmd.CommandText = SQL
                cmd.Parameters.AddWithValue("@DATE_IN", DATE_IN)
                cmd.Parameters.AddWithValue("@DOC_NO", txtDOC_NO.Text)
                cmd.Parameters.AddWithValue("@DETAIL", txtDETAIL.Text)
                cmd.Parameters.AddWithValue("@FILESIZE", FileSize)
                cmd.Parameters.AddWithValue("@USER_REC", vUSERID)
                cmd.Parameters.AddWithValue("@D_UPDATE", tmpNow)
                cmd.ExecuteNonQuery()
                conn.Close()
            Else
                If Not txtFile.Text.Contains(".pdf") Then
                    XtraMessageBox.Show("กรุณากำหนดไฟล์เอกสารเป็น PDF ไฟล์!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    cmdSearchID.Focus()
                    Exit Sub
                End If
                SQL = "UPDATE t_document SET DATE_IN = @DATE_IN,DOC_NO = @DOC_NO,DETAIL= @DETAIL,IMG = @IMG,FILESIZE = @FILESIZE,USER_REC = @USER_REC,D_UPDATE = @D_UPDATE  WHERE ROWID = '" & tmpROWID & "'"
                conn.ConnectionString = "Data Source=" & clsDataAcc8.G_DBIPServer8 & ";port=" & clsDataAcc8.G_DBPortServer8 & ";Database= " & clsDataAcc8.G_DBName8 & ";user id=" & clsDataAcc8.G_DBUserName8 & ";password=" & clsDataAcc8.G_DBPassword8 & ""
                conn.Open()
                cmd.Connection = conn
                cmd.CommandText = SQL
                cmd.Parameters.AddWithValue("@DATE_IN", DATE_IN)
                cmd.Parameters.AddWithValue("@DOC_NO", txtDOC_NO.Text)
                cmd.Parameters.AddWithValue("@DETAIL", txtDETAIL.Text)
                cmd.Parameters.AddWithValue("@IMG", bytes)
                cmd.Parameters.AddWithValue("@FILESIZE", FileSize)
                cmd.Parameters.AddWithValue("@USER_REC", vUSERID)
                cmd.Parameters.AddWithValue("@D_UPDATE", tmpNow)
                cmd.ExecuteNonQuery()
                conn.Close()

            End If
        End If

        ClearData()
        ShowData()
    End Sub
    Private Sub ListView1Action()
        For i As Integer = 0 To ListView1.SelectedItems.Count - 1
            Dim lvi As ListViewItem
            lvi = ListView1.SelectedItems(i)
            tmpROWID = lvi.SubItems.Item(0).Text
        Next
        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("*", " t_document ", " WHERE ROWID = '" & tmpROWID & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            tmpUpdate = True
            cmdDel.Enabled = True
            cmdPDF.Enabled = True

            txtDATE_IN.Text = DateTime.ParseExact(ds2.Tables(0).Rows(0).Item("DATE_IN").ToString.Substring(0, 4) + 543 & ds2.Tables(0).Rows(0).Item("DATE_IN").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("dd/MM/yyyy")

            txtDETAIL.Text = ds2.Tables(0).Rows(0).Item("DETAIL")
            txtDOC_NO.Text = ds2.Tables(0).Rows(0).Item("DOC_NO")

        End If

    End Sub
    Private Sub ClearData()
        txtDATE_IN.Text = Now.ToString("dd/MM/yyyy")
        txtDETAIL.Text = ""
        txtFile.Text = ""
        cmdDel.Enabled = False
        cmdPDF.Enabled = False
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        ListView1Action()
    End Sub
    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        ListView1Action()

        Dim filePdf As String
        filePdf = Application.StartupPath & "\PDF\document.pdf"
        If System.IO.File.Exists(filePdf) Then
            File.Delete(filePdf)
        End If
        Dim bytesLoad As Byte()
        bytesLoad = Nothing

        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("IMG", " t_document ", " WHERE ROWID = '" & tmpROWID & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            bytesLoad = ds2.Tables(0).Rows(0).Item("IMG")
        End If

        My.Computer.FileSystem.WriteAllBytes(filePdf, bytesLoad, False)
        System.Diagnostics.Process.Start(filePdf)
    End Sub

    Private Sub cmdPDF_Click(sender As Object, e As EventArgs) Handles cmdPDF.Click
        Dim filePdf As String
        filePdf = Application.StartupPath & "\PDF\document.pdf"
        If System.IO.File.Exists(filePdf) Then
            File.Delete(filePdf)
        End If
        Dim bytesLoad As Byte()
        bytesLoad = Nothing

        Dim ds2 As DataSet
        ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("IMG", " t_document ", " WHERE ROWID = '" & tmpROWID & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            bytesLoad = ds2.Tables(0).Rows(0).Item("IMG")
        End If

        Try
            My.Computer.FileSystem.WriteAllBytes(filePdf, bytesLoad, False)
            Dim f As New frmPDFviewer
            f.ShowDialog()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub cmdDel_Click(sender As Object, e As EventArgs) Handles cmdDel.Click
        If XtraMessageBox.Show("ต้องการลบข้อมูลเอกสารนี้ใช่หรือไม่?", vProgram, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            clsbusent8.Lc_BusinessEntity8.Delete_table("t_document", " WHERE ROWID  = '" & tmpROWID & "'")
            ClearData()
            ShowData()
        End If
    End Sub

    Private Sub cmdScan_Click(sender As Object, e As EventArgs) Handles cmdScan.Click


        If txtDATE_IN.Text = "" Then
            XtraMessageBox.Show("กรุณาระบุวันที่บันทึกก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If txtDETAIL.Text = "" Then
            XtraMessageBox.Show("กรุณาบันทึกรายละเอียดก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDETAIL.Select()
            Exit Sub
        End If

        Dim f As New frmDocumentScan
        f.ShowDialog()

        If File.Exists(Application.StartupPath & "\Scan\tmpDoc.pdf") Then
            txtFile.Text = Application.StartupPath & "\Scan\tmpDoc.pdf"
        Else
            txtFile.Text = ""
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ClearData()
    End Sub

    Private Sub BetterListView1_DoubleClick(sender As Object, e As EventArgs) Handles BetterListView1.DoubleClick
        Dim filePdf As String
        filePdf = Application.StartupPath & "\PDF\document.pdf"
        If System.IO.File.Exists(filePdf) Then
            File.Delete(filePdf)
        End If
        Dim bytesLoad As Byte()
        bytesLoad = Nothing

        Dim ds2 As DataSet
        ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("IMG", " t_document ", " WHERE ROWID = '" & tmpROWID & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            bytesLoad = ds2.Tables(0).Rows(0).Item("IMG")
        End If

        Try
            My.Computer.FileSystem.WriteAllBytes(filePdf, bytesLoad, False)
            Dim f As New frmPDFviewer
            f.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            tmpROWID = lvi.SubItems.Item(0).Text
        Next
        Dim ds2 As DataSet
        ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("*", " t_document ", " WHERE ROWID = '" & tmpROWID & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            tmpUpdate = True
            cmdDel.Enabled = True
            cmdPDF.Enabled = True

            txtDATE_IN.Text = DateTime.ParseExact(ds2.Tables(0).Rows(0).Item("DATE_IN").ToString.Substring(0, 4) + 543 & ds2.Tables(0).Rows(0).Item("DATE_IN").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("dd/MM/yyyy")
            CalendarControl1.EditValue = txtDATE_IN.Text
            txtDETAIL.Text = ds2.Tables(0).Rows(0).Item("DETAIL")
            txtDOC_NO.Text = ds2.Tables(0).Rows(0).Item("DOC_NO")

        End If
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

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub CalendarControl1_Click(sender As Object, e As EventArgs) Handles CalendarControl1.Click

    End Sub

    Private Sub txtDATE_IN_Click(sender As Object, e As EventArgs) Handles txtDATE_IN.Click

    End Sub
End Class