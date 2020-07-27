
Imports MySql.Data.MySqlClient
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsdataBus = MyPCU.ClsBusiness
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.IO
Imports System.Text
Imports System.Globalization
Imports DevExpress.XtraEditors
Imports MadMilkman.Ini
Public Class frmSetup
    Dim tmpServer As Boolean = True
    Private Sub frmSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = ""
        Label2.Text = ""
        Label4.Text = ""
        Label5.Text = ""
        Try
            Dim filePath = Application.StartupPath & "\dc.ini"
            Dim file As New IniFile()
            file.Load(filePath)

            vColor = file.Sections("Color").Keys("Color").Value
        Catch ex As Exception
            vColor = "2"
        End Try

        If vColor = "1" Then
            Me.BackColor = Color.DarkRed
        ElseIf vColor = "2" Then
            Me.BackColor = Color.Blue
        ElseIf vColor = "3" Then
            Me.BackColor = Color.DarkBlue
        ElseIf vColor = "4" Then
            Me.BackColor = Color.Green
        ElseIf vColor = "5" Then
            Me.BackColor = Color.Orange
        ElseIf vColor = "6" Then
            Me.BackColor = Color.Purple
        ElseIf vColor = "7" Then
            Me.BackColor = Color.Teal
        End If


        Try
            Dim filePath = Application.StartupPath & "\mypcu.ini"
            Dim file As New IniFile()
            file.Load(filePath)
            ConfigUpdate = file.Sections("Version").Keys("UpdateStatus").Value
            vProgram = file.Sections("Version").Keys("VersionName").Value
            vVersionCODE = file.Sections("Version").Keys("Version").Value

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message.ToString())
            Exit Sub
        End Try

        If ConfigUpdate = "0" Then
            Label1.Text = "MyPCU 2020 Update to version : " & vVersionCODE
        ElseIf ConfigUpdate = "2" Then
            Label1.Text = "MyPCU 2020 Setup"
        ElseIf ConfigUpdate = "3" Then
            Label1.Text = "MyPCU 2020 Update from MyPCU old"
        End If


        Try
            Dim filePath = Application.StartupPath & "\dc.ini"
            Dim file As New IniFile()
            file.Load(filePath)

            clsDataAcc.G_DBIPServer = Decode(file.Sections("Database").Keys("Host").Value)
            clsDataAcc.G_DBPortServer = Decode(file.Sections("Database").Keys("Port").Value)
            clsDataAcc.G_DBUserName = Decode(file.Sections("Database").Keys("User").Value)
            clsDataAcc.G_DBPassword = Decode(file.Sections("Database").Keys("Pwd").Value)
            clsDataAcc.G_DBName = Decode(file.Sections("Database").Keys("DbName").Value)

            If clsDataAcc.G_DBIPServer = "localhost" Then
                Label2.Text = "เครื่องนี้ถูกกำหนดเป็นเครื่อง Server"
            Else
                Label2.Text = "เครื่องนี้ถูกกำหนดเป็นเครื่อง Client"
                tmpServer = False
            End If

        Catch ex As Exception
            Dim fDBSetting As New frmDBSetting
            fDBSetting.ShowDialog()
        End Try

        If clsDataAcc.Lc_DataAcc.getDB_Conn() = False Then
            XtraMessageBox.Show("ไม่สามารถทำการเชื่อมต่อ database ได้", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim fDBSetting As New frmDBSetting
            fDBSetting.ShowDialog()
        Else
            Label4.Text = "เชื่อมต่อฐานข้อมูลได้ กดปุ่มดำเนินการ"
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fDBSetting As New frmDBSetting
        fDBSetting.ShowDialog()
    End Sub

    Private Sub cmdRun_Click(sender As Object, e As EventArgs) Handles cmdRun.Click
        If tmpServer = False Then
            UpdateIni()
        Else
            If ConfigUpdate = "1" Then
                Update1()
            ElseIf ConfigUpdate = "2" Then
                Update2()
            ElseIf ConfigUpdate = "3" Then
                Update3()
            End If

        End If
        XtraMessageBox.Show("ปรับปรุงเป็น MyPCU2020 Version : " & vVersionCODE & " เรียบร้อยแล้ว", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        frmLogin.Close()
    End Sub
    Private Sub Update1()
        SplashScreenManager1.ShowWaitForm()

        UpdateIni()
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub Update2()
        SplashScreenManager1.ShowWaitForm()

        UpdateIni()
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub Update3()
        SplashScreenManager1.ShowWaitForm()
        Label5.Text = "ปรับปรุงตาราง l_confighcode"

        Exp_Data(Application.StartupPath & "\Script\l_confighcode.txt", "l_confighcode")
        ImportData2("l_confighcode")

        Label5.Text = "ปรับปรุงตาราง l_clinic_hosp"
        Exp_Data(Application.StartupPath & "\Script\l_clinic_hosp.txt", "l_clinic_hosp")
        ImportData2("l_clinic_hosp")


        Label5.Text = "ปรับปรุงตาราง l_user"
        Exp_Data(Application.StartupPath & "\Script\l_user.txt", "l_user")
        ImportData2("l_user")

        Label5.Text = "ปรับปรุงตาราง m_provider"
        Exp_Data(Application.StartupPath & "\Script\m_provider.txt", "m_provider")
        ImportData2("m_provider")

        Label5.Text = "ปรับปรุงตาราง l_providertype_hosp"
        Exp_Data(Application.StartupPath & "\Script\l_providertype_hosp.txt", "l_providertype_hosp")
        ImportData2("l_providertype_hosp")

        'ใช้จริงต้องแก้ เป็น Import_field_add
        Label5.Text = "ปรับปรุงตาราง l_procedprice"
        Exp_Data_UTF8(Application.StartupPath & "\Script\l_procedprice.txt", "l_procedprice")
        clsbusent.Lc_BusinessEntity.Turncate_table("l_procedprice")
        Import_field_add_rowid(Application.StartupPath & "\Script\l_procedprice.txt", "l_procedprice", "CHARGEITEM,CHARGELIST,PROCEDCODE,SERVICEPRICE,SERVICECOST,DENTAL,USER_REC,D_UPDATE,STATUS,CLAIM,CSMBS,ICD,ICD9CM,PROCEDNAME", 14)
        clsbusent.Lc_BusinessEntity.Updatem_table(" l_procedprice a JOIN l_icd9 b ON(a.PROCEDCODE = b.CODE) ", " PROCEDNAME = DESC_THA ", " b.STATUS = '1' ")
        clsbusent.Lc_BusinessEntity.Updatem_table(" l_procedprice a JOIN l_icd9 b ON(a.PROCEDCODE = b.CODE) ", " ICD = CODE,ICD9CM = '' ", " b.STATUS = '1' AND (10TM = 'Y' OR 10TMD = 'Y') ")
        clsbusent.Lc_BusinessEntity.Updatem_table(" l_procedprice a JOIN l_icd9 b ON(a.PROCEDCODE = b.CODE) ", " ICD9CM = CODE", " b.STATUS = '1' AND 9CM = 'Y' ")

        Label5.Text = "l_nhso_sev"
        clsbusent.Lc_BusinessEntity.Turncate_table("l_nhso_sev")
        Exp_Data_UTF8(Application.StartupPath & "\Script\l_nhso_sev6.txt", "l_nhso_sev6")
        Import_field_add(Application.StartupPath & "\Script\l_nhso_sev6.txt", "l_nhso_sev", "CODE,NAME,UNIT,COST,GYEAR,EXPDATE,STARTDATE,MAININSCL,FLAG", 9)
        clsbusent.Lc_BusinessEntity.Updatem_table(" l_nhso_sev6 a JOIN l_nhso_sev b ON(a.CODE = b.CODE) ", " b.ITEM = '6' ", " a.CODE = b.CODE ")
        Exp_Data_UTF8(Application.StartupPath & "\Script\l_nhso_sev7.txt", "l_nhso_sev7")
        Import_field_add(Application.StartupPath & "\Script\l_nhso_sev7.txt", "l_nhso_sev", "CODE,NAME,UNIT,COST,GYEAR,EXPDATE,STARTDATE,MAININSCL,FLAG", 9)
        clsbusent.Lc_BusinessEntity.Updatem_table(" l_nhso_sev7 a JOIN l_nhso_sev b ON(a.CODE = b.CODE) ", " b.ITEM = '7' ", " a.CODE = b.CODE ")
        Exp_Data_UTF8(Application.StartupPath & "\Script\l_nhso_sev13.txt", "l_nhso_sev13")
        Import_field_add(Application.StartupPath & "\Script\l_nhso_sev13.txt", "l_nhso_sev", "CODE,NAME,UNIT,COST,GYEAR,EXPDATE,STARTDATE,MAININSCL", 8)
        clsbusent.Lc_BusinessEntity.Updatem_table(" l_nhso_sev13 a JOIN l_nhso_sev b ON(a.CODE = b.CODE) ", " b.ITEM = '13' ", " a.CODE = b.CODE ")
        Exp_Data_UTF8(Application.StartupPath & "\Script\l_nhso_sev15.txt", "l_nhso_sev15")
        Import_field_add(Application.StartupPath & "\Script\l_nhso_sev15.txt", "l_nhso_sev", "CODE,NAME,UNIT,COST,GYEAR,EXPDATE,STARTDATE,MAININSCL", 8)
        clsbusent.Lc_BusinessEntity.Updatem_table(" l_nhso_sev15 a JOIN l_nhso_sev b ON(a.CODE = b.CODE) ", " b.ITEM = '15' ", " a.CODE = b.CODE ")

        clsbusent.Lc_BusinessEntity.Updatem_table(" m_person ", " CID2 = CID,NAME2 = NAME,LNAME2 = LNAME ", " WHERE LENGTH(CID) > 13 ")
        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE(" CID,NAME,LNAME ", " m_person", " WHERE LENGTH(CID) > 13 ")
        If ds2.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                Dim cid As String = Decode(ds2.Tables(0).Rows(i).Item("CID"))
                Dim name As String = Decode(ds2.Tables(0).Rows(i).Item("NAME"))
                Dim lname As String = Decode(ds2.Tables(0).Rows(i).Item("LNAME"))
                clsbusent.Lc_BusinessEntity.Updatem_table(" m_person ", " CID = '" & cid & "',NAME = '" & name & "',LNAME = '" & lname & "' ", " CID = '" & ds2.Tables(0).Rows(i).Item("CID") & "' ")
            Next
        End If


        Label5.Text = ""
        UpdateIni()
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub UpdateIni()
        Dim filePath = Application.StartupPath & "\mypcu.ini"
        Dim file2 As New IniFile()
        If File.Exists(filePath) = True Then
            file2.Load(filePath)
        End If

        file2.Sections.Remove("Version")
        Dim section As IniSection = file2.Sections.Add("Version")

        Dim key As IniKey = file2.Sections("Version").Keys.Add("VersionName", vProgram)
        Dim key2 As IniKey = file2.Sections("Version").Keys.Add("Version", vVersionCODE)
        Dim key3 As IniKey = file2.Sections("Version").Keys.Add("UpdateStatus", "1")


        file2.Save(filePath)
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
    Private Sub Exp_Data_UTF8(ByVal Path As String, ByVal File As String)
        Dim delim As String = ""
        Dim sw As New StreamWriter(Path, False, UnicodeEncoding.UTF8)
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
    Private Sub ImportData2(ByVal strData As String)
        'Dim Con
        Dim Sql As String = ""
        Dim cmd As New MySqlCommand
        Dim pItem As ListViewItem
        Dim pItem2 As ListViewItem
        pItem = New ListViewItem
        pItem2 = New ListViewItem
        clsbusent.Lc_BusinessEntity.Turncate_table(strData)

        If File.Exists(Application.StartupPath & "\Script\" & strData & ".txt") Then
            clsDataAcc.Lc_DataAcc.getDB_Conn()
            Try
                clsbusent.Lc_BusinessEntity.load_table(Application.StartupPath & "\Script\" & strData & ".txt", strData, "")
            Catch e As IO.FileNotFoundException
            Catch e As Exception
                MessageBox.Show("(" & e.Message & ")")
                Throw e
            End Try
        End If

    End Sub
    Private Sub Import_field_add_rowid(ByVal strFile As String, ByVal strTable As String, ByVal strfield As String, ByVal strFieldNum As Integer)
        Try
            Dim myTable As DataTable = New DataTable("MyTable")
            Dim i As Integer
            Dim myRow As DataRow
            Dim fieldValues As String()
            Dim myReader As IO.StreamReader

            Try
                myReader = File.OpenText(strFile)
                fieldValues = myReader.ReadLine().Split("|")
                For i = 0 To fieldValues.Length() - 1
                    myTable.Columns.Add(New DataColumn("Field" & i))
                Next
                myRow = myTable.NewRow
                For i = 0 To fieldValues.Length() - 1
                    myRow.Item(i) = fieldValues(i).ToString
                Next
                myTable.Rows.Add(myRow)
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
                Dim tmpValue As String = ""
                For x As Integer = 1 To CInt(strFieldNum)
                    Dim tmpFileds As String = "Field" & x
                    If x = CInt(strFieldNum) Then
                        tmpValue = tmpValue & "'" & dr(tmpFileds) & "'"
                    Else
                        tmpValue = tmpValue & "'" & dr(tmpFileds) & "',"
                    End If

                Next
                clsbusent.Lc_BusinessEntity.Insertm_table("" & strTable & " (" & strfield & ")",
                         "" & tmpValue & "")
            Next

        Catch ex As Exception

        End Try

    End Sub
    Private Sub Import_field_add(ByVal strFile As String, ByVal strTable As String, ByVal strfield As String, ByVal strFieldNum As Integer)
        Try
            Dim myTable As DataTable = New DataTable("MyTable")
            Dim i As Integer
            Dim myRow As DataRow
            Dim fieldValues As String()
            Dim myReader As IO.StreamReader

            Try
                myReader = File.OpenText(strFile)
                fieldValues = myReader.ReadLine().Split("|")
                For i = 0 To fieldValues.Length() - 1
                    myTable.Columns.Add(New DataColumn("Field" & i))
                Next
                myRow = myTable.NewRow
                For i = 0 To fieldValues.Length() - 1
                    myRow.Item(i) = fieldValues(i).ToString
                Next
                myTable.Rows.Add(myRow)
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
                Dim tmpValue As String = ""
                For x As Integer = 0 To CInt(strFieldNum) - 1
                    Dim tmpFileds As String = "Field" & x
                    If x = CInt(strFieldNum) - 1 Then
                        tmpValue = tmpValue & "'" & dr(tmpFileds) & "'"
                    Else
                        tmpValue = tmpValue & "'" & dr(tmpFileds) & "',"
                    End If

                Next
                clsbusent.Lc_BusinessEntity.Insertm_table("" & strTable & " (" & strfield & ")",
                         "" & tmpValue & "")
            Next

        Catch ex As Exception

        End Try

    End Sub
End Class