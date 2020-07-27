Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports clsDataAcc6 = MyPCU.ClsDataAccess6
Imports clsdataBus6 = MyPCU.ClsBusiness6
Imports clsbusent6 = MyPCU.ClsBusinessEntity6
Imports System.Text
Imports System.DateTime
Imports System.Globalization
Imports System.IO
Imports System.Globalization.DateTimeFormatInfo
Imports ComponentAce.Compression.ZipForge
Imports ComponentAce.Compression.Archiver
Imports System.Xml
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Imports MadMilkman.Ini
Public Class frmBkupData
    Dim tmpFolder As String = ""
    Dim tmpFolder1 As String = ""
    Dim tmpFileName As String = ""
    Dim Path As String = ""
    Dim tmpRowID As String = ""
    Dim tmpAmountFile As String = ""
    Dim tmpAmount As String = ""
    Dim tmpPath As String = ""
    Private Sub frmBkupData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If vImage = "1" Then
            CheckBox1.Checked = True
        End If
        cmdBkup.Enabled = False

        With BetterListView1
            .Columns.Add(0).Text = "ID"
            .Columns(0).Width = 0
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ชื่อแฟ้ม"
            .Columns(1).Width = 400
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "จำนวนข้อมูล"
            .Columns(2).Width = 100
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        Try
            Dim filePath = Application.StartupPath & "\config.ini"
            Dim file As New IniFile()
            file.Load(filePath)

            TextBox1.Text = file.Sections("Backup").Keys("Path").Value

        Catch ex As Exception

        End Try
      

        If TextBox1.Text <> "" Then
            cmdBkup.Enabled = True
        End If


       
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If XtraFolderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            TextBox1.Text = XtraFolderBrowserDialog1.SelectedPath
        End If

        If TextBox1.Text <> "" Then
            cmdBkup.Enabled = True
        Else
            cmdBkup.Enabled = False
        End If
    End Sub
    Private Sub cmdBkup_Click(sender As Object, e As EventArgs) Handles cmdBkup.Click


        If TextBox1.Text = "" Then
            XtraMessageBox.Show("กำหนดตำแหน่งที่เก็บไฟล์ก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        SplashScreenManager1.ShowWaitForm()

        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SHOW_TABLE_STATUS(" STATUS FROM " & clsDataAcc.G_DBName & "")
        If ds2.Tables(0).Rows.Count > 0 Then
            clsbusent.Lc_BusinessEntity.Turncate_table("l_mypcu_table")
            For i As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                If ds2.Tables(0).Rows(i).Item("NAME") <> "m_image_person" And ds2.Tables(0).Rows(i).Item("NAME") <> "m_fingerprint" Then
                    clsbusent.Lc_BusinessEntity.Insertm_table("l_mypcu_table (M_TABLE)", "'" & ds2.Tables(0).Rows(i).Item("NAME") & "'")
                End If

            Next
        End If

        tmpFolder1 = Date.Now.ToString("yyyyMMddHHmmss")
        tmpFileName = "Bkup_" & vHcode & "_" & tmpFolder1

        Directory.CreateDirectory(TextBox1.Text & "\" & tmpFileName)

        If CheckBox1.Checked = True Then
            Directory.CreateDirectory(TextBox1.Text & "\" & tmpFileName & "\PersonPic")
            Directory.CreateDirectory(TextBox1.Text & "\" & tmpFileName & "\HomePic")
            Exp_DataPicture1(Path)
            Exp_DataPicture2(Path)
        End If

        If CheckBox2.Checked = True Then
            Directory.CreateDirectory(TextBox1.Text & "\" & tmpFileName & "\fingerprint")
            Exp_Data6(TextBox1.Text & "\" & tmpFileName & "\fingerprint\m_fingerprint.txt", "m_fingerprint")
        End If

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SHOW_TABLE_STATUS(" STATUS FROM his43")
        If ds.Tables(0).Rows.Count > 0 Then
            BetterListView1.Items.Clear()
            ProgressBarControl1.EditValue = 0
            ProgressBarControl1.Properties.Maximum = 100
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Dim tmpTable As String = ds.Tables(0).Rows(i).Item("NAME").ToString
                Path = TextBox1.Text & "\" & tmpFileName & "\" & tmpTable.ToString.ToUpper & ".txt"
                Exp_Data(Path, tmpTable)

                BetterListView1.Items.Add((i + 1).ToString)
                BetterListView1.Items(i).SubItems.Add(tmpTable.ToString.ToUpper).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(CInt(ds.Tables(0).Rows(i).Item("ROWS")).ToString("#,##0")).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If


                ProgressBarControl1.EditValue = (i + 1) * 100 / ds.Tables(0).Rows.Count
                ProgressBarControl1.Refresh()
                BetterListView1.EnsureVisible(BetterListView1.Items.Count - 1)
            Next
        End If
        Dim archiver As New ZipForge()
        If Directory.Exists(TextBox1.Text & "\" & tmpFileName) Then
            Try
                ' Set the name of the archive file we want to create
                archiver.FileName = TextBox1.Text & "\" & tmpFileName & ".zip"
                ' Because we create a new archive, 
                ' we set fileMode to System.IO.FileMode.Create
                archiver.OpenArchive(System.IO.FileMode.Create)
                ' Set base (default) directory for all archive operations
                archiver.BaseDir = TextBox1.Text & "\" & tmpFileName & "\"
                ' Add the c:\Test folder to the archive with all subfolders
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim tmpTable As String = ds.Tables(0).Rows(i).Item("NAME").ToString
                    archiver.AddFiles(tmpTable & ".txt")
                    File.Delete(TextBox1.Text & "\" & tmpFileName & "\" & tmpTable & ".txt")
                Next
                archiver.AddFiles(TextBox1.Text & "\" & tmpFileName)
                archiver.CloseArchive()
                ' Catch all exceptions of the ArchiverException type        
            Catch ae As ArchiverException
                Console.WriteLine("Message: {0} Error code: {1}", ae.Message, ae.ErrorCode)
                ' Wait for the  key to be pressed
                Console.ReadLine()
            End Try


        End If

        Dim filePath = Application.StartupPath & "\config.ini"
        Dim file2 As New IniFile()
        If File.Exists(filePath) = True Then
            file2.Load(filePath)
        End If
        file2.Sections.Remove("Backup")
        file2.Sections.Add("Backup")
        file2.Sections("Backup").Keys.Add("Path", TextBox1.Text)
        file2.Save(filePath)

        Directory.Delete(TextBox1.Text & "\" & tmpFileName, True)

        SplashScreenManager1.CloseWaitForm()
        XtraMessageBox.Show("สำรองข้อมูลเรียบร้อยแล้ว", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)


    End Sub
    Private Sub Exp_DataPicture1(ByVal Path As String)
        Dim delim As String = ""
        Dim ds As New DataSet
        Dim ds2 As New DataSet
        Dim tmpPCUCODE As String = ""
        Dim dt As New DataTable()
        Dim tmpFD As String = ""


        Try
            ds2 = clsdataBus.Lc_Business.SELECT_TABLE("ROWID,CID", " m_image_person ", "")
            If ds2.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                    Dim filePdf As String
                    filePdf = TextBox1.Text & "\" & tmpFileName & "\PersonPic\" & ds2.Tables(0).Rows(i).Item("CID") & ".jpg"
                    Dim bytesLoad As Byte()
                    bytesLoad = Nothing

                    Dim ds3 As DataSet
                    ds3 = clsdataBus.Lc_Business.SELECT_TABLE("IMG", "m_image_person", " WHERE ROWID = '" & ds2.Tables(0).Rows(i).Item("ROWID") & "'")
                    If ds3.Tables(0).Rows.Count > 0 Then
                        bytesLoad = ds3.Tables(0).Rows(0).Item("IMG")
                        My.Computer.FileSystem.WriteAllBytes(filePdf, bytesLoad, False)
                    End If

                Next

            End If

        Catch ex As Exception
            Console.Write("ERROR: " & ex.Message)
        Finally

        End Try

    End Sub
    Private Sub Exp_DataPicture2(ByVal Path As String)
        Dim delim As String = ""
        Dim ds As New DataSet
        Dim ds2 As New DataSet
        Dim tmpPCUCODE As String = ""
        Dim dt As New DataTable()
        Dim tmpFD As String = ""


        Try
            ds2 = clsdataBus.Lc_Business.SELECT_TABLE("ROWID,HID", " m_image_home ", "")
            If ds2.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                    Dim filePdf As String
                    filePdf = TextBox1.Text & "\" & tmpFileName & "\HomePic\" & ds2.Tables(0).Rows(i).Item("HID") & ".jpg"
                    Dim bytesLoad As Byte()
                    bytesLoad = Nothing

                    Dim ds3 As DataSet
                    ds3 = clsdataBus.Lc_Business.SELECT_TABLE("IMG", "m_image_home", " WHERE ROWID = '" & ds2.Tables(0).Rows(i).Item("ROWID") & "'")
                    If ds3.Tables(0).Rows.Count > 0 Then
                        bytesLoad = ds3.Tables(0).Rows(0).Item("IMG")
                        My.Computer.FileSystem.WriteAllBytes(filePdf, bytesLoad, False)
                    End If

                Next

            End If

        Catch ex As Exception
            Console.Write("ERROR: " & ex.Message)
        Finally

        End Try

    End Sub
    Private Sub Exp_Data(ByVal Path As String, ByVal File As String)
        Dim delim As String = ""
        Dim sw As New StreamWriter(Path, False, UnicodeEncoding.Default)
        Dim ds As New DataSet
        Dim ds2 As New DataSet
        Dim tmpPCUCODE As String = ""
        Dim dt As New DataTable()

        clsDataAcc.Lc_DataAcc.getDB_Conn()
        Try
            delim = ""
            clsDataAcc.Lc_DataAcc.getDB_Conn()
            ds2 = clsdataBus.Lc_Business.SelectAll(File)
            dt = ds2.Tables(0)
            For Each row As DataRow In dt.Rows
                For Each value As Object In row.ItemArray
                    sw.Write(delim)
                    delim = "|"
                    sw.Write(value)
                Next
                delim = ""
                sw.WriteLine()

            Next


        Catch ex As Exception
            Console.Write("ERROR: " & ex.Message)
        Finally

        End Try
        sw.Close()
        sw.Dispose()
        dt.Dispose()
    End Sub
    Private Sub Exp_Data6(ByVal Path As String, ByVal File As String)
        Dim delim As String = ""
        Dim sw As New StreamWriter(Path, False, UnicodeEncoding.Default)
        Dim ds As New DataSet
        Dim ds2 As New DataSet
        Dim tmpPCUCODE As String = ""
        Dim dt As New DataTable()

        Dim strDataSource6 As String = ""
        Dim strUserID6 As String = ""
        Dim strPassword6 As String = ""
        Dim strPort6 As String = ""
        Dim strDatabasename6 As String = ""


        Dim strDataSource5 As String = ""
        Dim strUserID5 As String = ""
        Dim strPassword5 As String = ""
        Dim strPort5 As String = ""
        Dim strDatabasename5 As String = ""
        Dim dsc As DataSet
        dsc = clsdataBus.Lc_Business.SELECT_TABLE("*", "l_config_mypcu_pro", " WHERE ROWID = '09' ")
        If dsc.Tables(0).Rows.Count > 0 Then
            strDataSource6 = dsc.Tables(0).Rows(0).Item("HOST")
            strUserID6 = dsc.Tables(0).Rows(0).Item("USERNAME")
            strPassword6 = dsc.Tables(0).Rows(0).Item("PASSWORD")
            strPort6 = dsc.Tables(0).Rows(0).Item("PORT")
            strDatabasename6 = dsc.Tables(0).Rows(0).Item("DATABASENAME")
            clsDataAcc6.G_DBIPServer6 = strDataSource6
            clsDataAcc6.G_DBPortServer6 = strPort6
            clsDataAcc6.G_DBUserName6 = strUserID6
            clsDataAcc6.G_DBPassword6 = strPassword6
            clsDataAcc6.G_DBName6 = strDatabasename6

        End If

        clsDataAcc6.Lc_DataAcc6.getDB_Conn_db6()
        Try
            delim = ""
            clsDataAcc6.Lc_DataAcc6.getDB_Conn_db6()
            ds2 = clsdataBus6.Lc_Business6.SelectAll(File)
            dt = ds2.Tables(0)
            For Each row As DataRow In dt.Rows
                For Each value As Object In row.ItemArray
                    sw.Write(delim)
                    delim = "|"
                    sw.Write(value)
                Next
                delim = ""
                sw.WriteLine()

            Next


        Catch ex As Exception
            Console.Write("ERROR: " & ex.Message)
        Finally

        End Try
        sw.Close()
        sw.Dispose()
        dt.Dispose()
    End Sub
End Class