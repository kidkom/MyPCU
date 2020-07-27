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
Imports MySql.Data.MySqlClient

Public Class frmRestore
    Dim tmpFilename As String = ""
    Dim tmpFilepath As String = ""
    Private Sub frmRestore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdBkup.Enabled = False
        Label3.Text = ""

        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 60
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ชื่อแฟ้ม"
            .Columns(1).Width = 300
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "จำนวนข้อมูล"
            .Columns(2).Width = 100
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

    End Sub

    Private Sub cmdBrowse_Click(sender As Object, e As EventArgs) Handles cmdBrowse.Click

        Dim opf As XtraOpenFileDialog = New XtraOpenFileDialog

        opf.Filter = "zip files (*.zip)|*.*|zip files (*.zip)|*.zip"
        opf.FilterIndex = 0
        opf.RestoreDirectory = True


        If opf.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim stFilePathAndName As String = opf.FileName
            Dim MyFile As IO.FileInfo = New IO.FileInfo(stFilePathAndName)
            txtFilename.Text = MyFile.Name
            tmpFilename = MyFile.Name
            tmpFilepath = opf.FileName
            cmdBkup.Enabled = True
        End If

        SplashScreenManager1.ShowWaitForm()


        If txtFilename.Text <> "" Then
            If Directory.Exists(Application.StartupPath & "\Import") = False Then
                Directory.CreateDirectory(Application.StartupPath & "\Import")
                ClsUnzip.unzip.ExtractArchive(tmpFilepath, Application.StartupPath & "\Import")
            Else
                Directory.Delete(Application.StartupPath & "\Import", True)
                Directory.CreateDirectory(Application.StartupPath & "\Import")
                ClsUnzip.unzip.ExtractArchive(tmpFilepath, Application.StartupPath & "\Import")
            End If
        Else
            XtraMessageBox.Show("โปรดระบุไฟล์ที่ต้องการนำเข้าก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmdBrowse.Focus()
        End If

        iUTF8 = ""
        iHeadField = ""
        clsbusent.Lc_BusinessEntity.Turncate_table("l_mypcu_table")
        Import_DATA(Application.StartupPath & "\Import\l_mypcu_table.txt", "l_mypcu_table")

        Dim ds As DataSet
        'ds = clsdataBus.Lc_Business.SHOW_TABLE_STATUS(" STATUS FROM his43")
        ds = clsdataBus.Lc_Business.SELECT_TABLE("M_TABLE", "l_mypcu_table", " WHERE M_TABLE <> 'l_mypcu_table' AND m_TABLE <> 'l_version' ORDER BY m_TABLE")
        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Dim tmpTable As String = ds.Tables(0).Rows(i).Item("M_TABLE").ToString.Replace(" ", "")

                BetterListView1.Items.Add((i + 1).ToString)
                BetterListView1.Items(i).SubItems.Add(tmpTable.ToString.ToUpper).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add("").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If


                ProgressBarControl1.EditValue = (i + 1) * 100 / ds.Tables(0).Rows.Count
                ProgressBarControl1.Refresh()
                BetterListView1.EnsureVisible(BetterListView1.Items.Count - 1)
            Next
        End If


        SplashScreenManager1.CloseWaitForm()

    End Sub
    Sub Import_DATA(ByVal Path As String, ByVal File As String)
        clsDataAcc.Lc_DataAcc.getDB_Conn()
        Try
            clsbusent.Lc_BusinessEntity.load_table(Path, File, "")

        Catch e As IO.FileNotFoundException
        Catch e As Exception
            XtraMessageBox.Show("(" & e.Message & ")")
            Throw e
        End Try
    End Sub
    Private Sub chkAll_Click(sender As Object, e As EventArgs) Handles chkAll.Click
        If chkAll.Checked = True Then
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            For i = 0 To BetterListView1.Items.Count - 1
                BetterListView1.Items(i).Checked = True
            Next
        Else
            For i = 0 To BetterListView1.Items.Count - 1
                BetterListView1.Items(i).Checked = False
            Next
        End If
    End Sub

    Private Sub CheckBox1_Click(sender As Object, e As EventArgs) Handles CheckBox1.Click
        For i = 0 To BetterListView1.Items.Count - 1
            BetterListView1.Items(i).Checked = False
        Next

        If CheckBox1.Checked = True Then
            chkAll.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            For i = 0 To BetterListView1.Items.Count - 1
                Dim lvi As BetterListViewItem
                lvi = BetterListView1.Items(i)
                Dim tmpData As String = lvi.SubItems.Item(1).Text.Substring(0, 3)
                tmpData = tmpData
                If lvi.SubItems.Item(1).Text.Substring(0, 3) = "ACC" Then
                    BetterListView1.Items(i).Checked = True
                End If
            Next
        Else
            For i = 0 To BetterListView1.Items.Count - 1
                Dim lvi As BetterListViewItem
                lvi = BetterListView1.Items(i)
                If lvi.SubItems.Item(1).Text.Substring(0, 3) = "ACC" Then
                    BetterListView1.Items(i).Checked = False
                End If
            Next
        End If
    End Sub

    Private Sub CheckBox2_Click(sender As Object, e As EventArgs) Handles CheckBox2.Click
        For i = 0 To BetterListView1.Items.Count - 1
            BetterListView1.Items(i).Checked = False
        Next

        If CheckBox2.Checked = True Then
            chkAll.Checked = False
            CheckBox1.Checked = False
            CheckBox3.Checked = False
            For i = 0 To BetterListView1.Items.Count - 1
                Dim lvi As BetterListViewItem
                lvi = BetterListView1.Items(i)
                If lvi.SubItems.Item(1).Text.Length >= 8 Then
                    If lvi.SubItems.Item(1).Text.Substring(0, 8) = "N_SCHOOL" Then
                        BetterListView1.Items(i).Checked = True
                    End If
                End If

            Next
        Else
            For i = 0 To BetterListView1.Items.Count - 1
                Dim lvi As BetterListViewItem
                lvi = BetterListView1.Items(i)
                If lvi.SubItems.Item(1).Text.Length >= 8 Then
                    If lvi.SubItems.Item(1).Text.Substring(0, 8) = "N_SCHOOL" Then
                        BetterListView1.Items(i).Checked = False
                    End If
                End If

            Next
        End If
    End Sub

    Private Sub CheckBox3_Click(sender As Object, e As EventArgs) Handles CheckBox3.Click
        For i = 0 To BetterListView1.Items.Count - 1
            BetterListView1.Items(i).Checked = False
        Next

        If CheckBox3.Checked = True Then
            chkAll.Checked = False
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            For i = 0 To BetterListView1.Items.Count - 1
                Dim lvi As BetterListViewItem
                lvi = BetterListView1.Items(i)
                If lvi.SubItems.Item(1).Text.Substring(0, 1) = "L" Then
                    BetterListView1.Items(i).Checked = True
                End If
            Next
        Else
            For i = 0 To BetterListView1.Items.Count - 1
                Dim lvi As BetterListViewItem
                lvi = BetterListView1.Items(i)
                If lvi.SubItems.Item(1).Text.Substring(0, 1) = "L" Then
                    BetterListView1.Items(i).Checked = False
                End If
            Next
        End If
    End Sub

    Private Sub cmdBkup_Click(sender As Object, e As EventArgs) Handles cmdBkup.Click
        If txtFilename.Text = "" Then
            XtraMessageBox.Show("กรุณาเลือกไฟล์ที่ต้องการนำเข้าก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
            cmdBrowse.Focus()
        End If

        If txtFilename.Text.Substring(0, 3) <> "Bku" Then
            XtraMessageBox.Show("รูปแบบไฟล์ไม่ถูกต้อง กรุณาตรวจสอบไฟล์ที่นำเข้า!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        SplashScreenManager1.ShowWaitForm()
        iUTF8 = ""
        iHeadField = ""
        Dim k As Integer = 0

        Dim tmpItem As String = ""
        Dim tmpItem2 As String = ""

        For Each itm As BetterListViewItem In BetterListView1.Items
            If itm.Checked = True Then
                tmpItem = itm.SubItems.Item(1).Text
                If tmpItem2 = "" Then
                    tmpItem2 = tmpItem
                Else
                    tmpItem2 = tmpItem2 & "," & tmpItem
                End If
                k = k + 1
            End If
        Next

        Dim ds2 As DataSet
        If tmpItem2 <> "" Then
            BetterListView1.Items.Clear()
            Dim i As Integer = 0
            Dim validateCode() As String
            validateCode = tmpItem2.Split(CChar(","))
            For Each code As String In validateCode
                Try
                    Dim tmpTable As String = code
                    clsbusent.Lc_BusinessEntity.Turncate_table(tmpTable.ToLower)
                    Import_DATA(Application.StartupPath & "\Import\" & tmpTable & ".txt", tmpTable.ToLower)
                    ds2 = clsdataBus.Lc_Business.SHOW_TABLE_STATUS(" STATUS FROM his43 WHERE NAME = '" & tmpTable.ToLower & "'")
                    BetterListView1.Items.Add((i + 1).ToString)
                    BetterListView1.Items(i).SubItems.Add(tmpTable.ToString.ToUpper).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
                    BetterListView1.Items(i).SubItems.Add(CInt(ds2.Tables(0).Rows(0).Item("ROWS")).ToString("#,##0")).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right

                    If (i Mod 2) = 0 Then
                        BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                    End If


                    ProgressBarControl1.EditValue = (i + 1) * 100 / k
                    ProgressBarControl1.Refresh()
                    BetterListView1.EnsureVisible(BetterListView1.Items.Count - 1)

                    i = i + 1
                Catch ex As Exception
                    XtraMessageBox.Show(ex.ToString, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try

            Next
        End If

        tmpItem2 = ""

        For i = 0 To BetterListView1.Items.Count - 1
            BetterListView1.Items(i).Checked = True
        Next

        If chkReoder.Checked = True Then
            ReOrder2()
        End If
        If chkPicture.Checked = True Then
            ImportPicture()
            ImportPicture2()
        End If
        If chkFinger.Checked = True Then
            clsbusent6.Lc_BusinessEntity6.Turncate_table("m_fingerprint")
            Import_finger(Application.StartupPath & "\Import\fingerprint\m_fingerprint.txt")
        End If


        SplashScreenManager1.CloseWaitForm()
        XtraMessageBox.Show("นำกลับข้อมูลเรียบร้อยแล้ว", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub ReOrder2()
        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SelectSQL(" SHOW TABLES FROM his43 WHERE (TABLES_IN_his43 LIKE 'm_%' OR  TABLES_IN_his43 LIKE 'n_%') AND TABLES_IN_his43 NOT LIKE 'my_%' AND  TABLES_IN_his43 <> 'm_files_upload' AND TABLES_IN_his43 <> 'm_upload' ")
        If ds2.Tables(0).Rows.Count > 0 Then

            Dim tmptable As String = ""
            Dim tmptable2 As String = ""
            For i As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                tmptable = ds2.Tables(0).Rows(i).Item("TABLES_IN_his43")
                Label3.Text = "ปรับปรุงลำดับข้อมูล " & tmptable
                Label3.Refresh()
                tmptable2 = tmptable & "2"
                clsbusent.Lc_BusinessEntity.drop_table(tmptable2)
                clsbusent.Lc_BusinessEntity.clone_table(tmptable, tmptable2)
                'clsbusent.Lc_BusinessEntity.Turncate_table(tmptable2)
                Try
                    Dim ds3 As DataSet
                    ds3 = clsdataBus.Lc_Business.SelectSQL(" SHOW COLUMNS FROM " & tmptable & " WHERE Field = 'ROWID' ")
                    If ds3.Tables(0).Rows.Count > 0 Then
                        Try
                            Dim ds4 As DataSet
                            ds4 = clsdataBus.Lc_Business.SelectSQL(" SELECT ROWID FROM " & tmptable & " ORDER BY ROWID ")
                            If ds4.Tables(0).Rows.Count > 0 Then
                                For k As Integer = 0 To ds4.Tables(0).Rows.Count - 1
                                    clsbusent.Lc_BusinessEntity.Updatem_table(tmptable, " ROWID = " & k + 1 & "", " ROWID  = " & ds4.Tables(0).Rows(k).Item("ROWID") & " ")

                                    Label3.Text = "ปรับปรุงลำดับข้อมูล " & tmptable & " " & CDbl((k + 1) * 100 / ds4.Tables(0).Rows.Count).ToString("0.00") & "%"
                                    Label3.Refresh()
                                Next

                            End If
                        Catch ex As Exception

                        End Try
                    End If

                Catch ex As Exception

                End Try

                clsbusent.Lc_BusinessEntity.drop_table(tmptable2)
            Next
        End If
        Label3.Text = ""

    End Sub
    Private Sub ImportPicture()
        Dim SQL As String = ""
        Dim connpic As MySqlConnection = New MySqlConnection
        Dim cmd As New MySqlCommand
        Dim FileSize As UInt32
        Dim bytes As Byte()
        Dim ds As DataSet
        Dim tmpFD As String = ""
        Dim tmpCID As String = ""
        clsbusent.Lc_BusinessEntity.Turncate_table("m_image_person")
        ds = clsdataBus.Lc_Business.SELECT_TABLE("CID", " m_person ", " WHERE IFNULL(CID,'') <> ''  ")

        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                tmpCID = Decode(ds.Tables(0).Rows(i).Item("CID"))

                If File.Exists(Application.StartupPath & "\Import\PersonPic\" & tmpCID & ".jpg") Then
                    Dim fs As New FileStream(Application.StartupPath & "\Import\PersonPic\" & tmpCID & ".jpg", FileMode.Open, FileAccess.Read)
                    Dim br As New BinaryReader(fs)

                    bytes = System.IO.File.ReadAllBytes(Application.StartupPath & "\Import\PersonPic\" & tmpCID & ".jpg")
                    FileSize = bytes.Length

                    SQL = "INSERT INTO m_image_person (CID,IMG,FILESIZE) VALUES(@CID" & i & ",@IMG" & i & ",@FILESIZE" & i & ")"
                    If connpic.State = ConnectionState.Open Then
                        connpic.Close()
                    End If
                    connpic.ConnectionString = "Data Source=" & clsDataAcc.G_DBIPServer & ";port=" & clsDataAcc.G_DBPortServer & ";Database= his43;user id=" & clsDataAcc.G_DBUserName & ";password=" & clsDataAcc.G_DBPassword & ""
                    connpic.Open()
                    cmd.Connection = connpic
                    cmd.CommandText = SQL
                    cmd.Parameters.AddWithValue("@CID" & i & "", tmpCID)
                    cmd.Parameters.AddWithValue("@IMG" & i & "", bytes)
                    cmd.Parameters.AddWithValue("@FILESIZE" & i & "", FileSize)
                    cmd.ExecuteNonQuery()
                    connpic.Close()
                End If


            Next
            connpic.Close()
        End If


    End Sub
    Private Sub ImportPicture2()
        Dim SQL As String = ""
        Dim connpic As MySqlConnection = New MySqlConnection
        Dim cmd As New MySqlCommand
        Dim FileSize As UInt32
        Dim bytes As Byte()
        Dim ds As DataSet
        Dim tmpFD As String = ""
        Dim tmpHID As String = ""
        clsbusent.Lc_BusinessEntity.Turncate_table("m_image_home")
        ds = clsdataBus.Lc_Business.SELECT_TABLE("HID", " m_home ", " WHERE IFNULL(HID,'') <> ''  ")

        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                tmpHID = ds.Tables(0).Rows(i).Item("HID")

                If File.Exists(Application.StartupPath & "\Import\HomenPic\" & tmpHID & ".png") Then
                    Dim fs As New FileStream(Application.StartupPath & "\Import\HomenPic\" & tmpHID & ".png", FileMode.Open, FileAccess.Read)
                    Dim br As New BinaryReader(fs)

                    bytes = System.IO.File.ReadAllBytes(Application.StartupPath & "\Import\HomenPic\" & tmpHID & ".png")
                    FileSize = bytes.Length

                    SQL = "INSERT INTO m_image_home (HID,IMG,FILESIZE) VALUES(@HID" & i & ",@IMG" & i & ",@FILESIZE" & i & ")"
                    If connpic.State = ConnectionState.Open Then
                        connpic.Close()
                    End If
                    connpic.ConnectionString = "Data Source=" & clsDataAcc.G_DBIPServer & ";port=" & clsDataAcc.G_DBPortServer & ";Database= his43;user id=" & clsDataAcc.G_DBUserName & ";password=" & clsDataAcc.G_DBPassword & ""
                    connpic.Open()
                    cmd.Connection = connpic
                    cmd.CommandText = SQL
                    cmd.Parameters.AddWithValue("@HID" & i & "", tmpHID)
                    cmd.Parameters.AddWithValue("@IMG" & i & "", bytes)
                    cmd.Parameters.AddWithValue("@FILESIZE" & i & "", FileSize)
                    cmd.ExecuteNonQuery()
                    connpic.Close()
                End If
            Next
            connpic.Close()
        End If


    End Sub
    Private Sub Import_finger(ByVal strFile As String)

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

        Try
            Dim myTable As DataTable = New DataTable("MyTable")
            Dim i As Integer
            Dim myRow As DataRow
            Dim fieldValues As String()
            'Dim f As IO.File
            Dim myReader As IO.StreamReader

            Try
                'Open file and read first line to determine how many fields  there are.
                myReader = File.OpenText(strFile)
                fieldValues = myReader.ReadLine().Split("|")
                'Create data columns accordingly
                For i = 0 To fieldValues.Length() - 1
                    myTable.Columns.Add(New DataColumn("Field" & i))
                Next
                'Adding the first line of data to data table
                myRow = myTable.NewRow
                For i = 0 To fieldValues.Length() - 1
                    myRow.Item(i) = fieldValues(i).ToString
                Next
                myTable.Rows.Add(myRow)
                'Now reading the rest of the data to data table
                While myReader.Peek() <> -1
                    fieldValues = myReader.ReadLine().Split("|")
                    myRow = myTable.NewRow
                    For i = 0 To fieldValues.Length() - 1
                        myRow.Item(i) = fieldValues(i).ToString
                    Next
                    myTable.Rows.Add(myRow)
                End While
            Catch ex As Exception
                MsgBox("Error building datatable: " & ex.Message)

            Finally
                myReader.Close()
            End Try
            Dim dr As DataRow = myTable.NewRow()


            For k As Integer = 0 To myTable.Rows.Count - 1
                dr = myTable.Rows(k)

                clsbusent6.Lc_BusinessEntity6.InsertM_table("m_fingerprint (ROWID,CID,print1,print2,pin)",
             "'" & dr("Field0") & "','" & dr("Field1") & "','" & dr("Field2") & "','" & dr("Field3") & "','" & dr("Field4") & "'")



            Next

        Catch ex As Exception

        End Try

    End Sub
End Class
