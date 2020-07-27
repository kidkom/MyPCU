Imports MySql.Data.MySqlClient
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsDataAcc3 = MyPCU.ClsDataAccess3
Imports clsdataBus = MyPCU.ClsBusiness
Imports clsdataBus3 = MyPCU.ClsBusiness3
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports clsbusent3 = MyPCU.ClsBusinessEntity3
Imports clsDataAcc4 = MyPCU.ClsDataAccess4
Imports clsdataBus4 = MyPCU.ClsBusiness4
Imports clsbusent4 = MyPCU.ClsBusinessEntity4
Imports clsDataAcc8 = MyPCU.ClsDataAccess8
Imports System.IO
Imports System.Xml
Imports System.Net.Mail
Imports System.Net.NetworkInformation
Imports System.DateTime
Imports System.Globalization
Imports System.Text
Imports DevExpress.XtraEditors
Imports MadMilkman.Ini
Public Class frmMain
    Dim tmpProvider As String = ""
    Dim pageready As Boolean = False
    Dim ComStatus As Boolean = False
    Dim tmpAutotime As String = ""
    Dim tmpServer As String = ""
    Dim tmpNHSO As Boolean = False
    Dim tmpVERSION1 As String = "0"
    Dim tmpVERSION1_NAME As String = ""
    Dim tmpShowDSPM As String = ""
    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim tmpClose As Boolean = True
        Dim result = XtraMessageBox.Show("คุณต้องการออกจากโปรแกรมใช่หรือไม่?", vProgram, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = System.Windows.Forms.DialogResult.Yes Then
            Dim x As Integer = 0
            Dim ds As DataSet
            ds = clsdataBus.Lc_Business.SELECT_TABLE("M_TABLE", "l_configcheck", " GROUP BY M_TABLE ORDER BY M_TABLE  ")
            Dim tmpTable As String = ""
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                tmpTable = "m_" & ds.Tables(0).Rows(i).Item("M_TABLE").ToString
                Dim ds2 As DataSet
                ds2 = clsdataBus.Lc_Business.SELECT_TABLE("*", tmpTable.ToLower, " WHERE STATUS_AF = '2' ")
                If ds2.Tables(0).Rows.Count > 0 Then
                    x = 1
                    If XtraMessageBox.Show("มีการบันทึกข้อมูลใหม่ที่ยังไม่ได้ตรวจสอบ คุณต้องการตรวจสอบข้อมูลหรือไม่?", vProgram, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = System.Windows.Forms.DialogResult.Yes Then
                        e.Cancel = True
                        ckType2 = "1"
                        Dim CurrentForm As Form
                        For Each CurrentForm In Me.MdiChildren
                            If TypeOf CurrentForm Is frmCheckData Then
                                CurrentForm.MdiParent = Me
                                Exit Sub
                            End If
                        Next
                        Dim f As New frmCheckData
                        f.MdiParent = Me
                        f.Dock = DockStyle.Fill
                        f.Show()
                        pPID = ""
                        hHID = ""
                        ckType2 = ""
                        tmpClose = False
                        Exit For

                    Else
                        x = 0
                        Exit For
                    End If
                End If
            Next
            If x = 0 Then
                CheckSurveil()

            End If
            If tmpClose = True Then
                frmLogin.Close()
            End If

        ElseIf result = System.Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If


       
    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = vProgram & "-" & vVersionCODE
        Dim strDataSource As String = ""
        Dim strUserID As String = ""
        Dim strPassword As String = ""
        Dim strPort As String = ""
        Dim strDbName As String = ""
        Dim tmpProvider As String = ""


        BarStaticItem3.Caption = ""
        BarStaticItem4.Caption = ""
        BarStaticItem6.Caption = ""
        BarStaticItem5.Caption = ""
        BarStaticItem7.Caption = ""

        If vColor = "1" Then
            Me.Ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Red
            chkRed.Checked = True
        ElseIf vColor = "2" Then
            Me.Ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue
            chkBlue.Checked = True
        ElseIf vColor = "3" Then
            Me.Ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.DarkBlue
            chkDarkBlue.Checked = True
        ElseIf vColor = "4" Then
            Me.Ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Green
            chkGreen.Checked = True
        ElseIf vColor = "5" Then
            Me.Ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Orange
            chkOrange.Checked = True
        ElseIf vColor = "6" Then
            Me.Ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Purple
            chkPurple.Checked = True
        ElseIf vColor = "7" Then
            Me.Ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Teal
            chkTeal.Checked = True
        Else
            Me.Ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue
            chkBlue.Checked = True
        End If

        Try
            Dim filePath = Application.StartupPath & "\dc.ini"
            Dim file As New IniFile()
            file.Load(filePath)

            strDataSource = Decode(file.Sections("Database").Keys("Host").Value)
            strPort = Decode(file.Sections("Database").Keys("Port").Value)
            strUserID = Decode(file.Sections("Database").Keys("User").Value)
            strPassword = Decode(file.Sections("Database").Keys("Pwd").Value)
            strDbName = Decode(file.Sections("Database").Keys("DbName").Value)
        Catch ex As Exception
            XtraMessageBox.Show("ไม่สามารถทำการเชื่อมต่อ database ได้", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim fDBSetting As New frmDBSetting
            fDBSetting.ShowDialog()
            Exit Sub
        End Try

        If clsDataAcc.Lc_DataAcc.getDB_Conn() = False Then
            XtraMessageBox.Show("ไม่สามารถทำการเชื่อมต่อ database ได้", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)

            clsDataAcc.G_DBIPServer = strDbName
            clsDataAcc.G_DBPortServer = strPort
            clsDataAcc.G_DBUserName = strUserID
            clsDataAcc.G_DBPassword = strPassword
            clsDataAcc.G_DBName = strDbName
            Dim fDBSetting As New frmDBSetting
            fDBSetting.ShowDialog()
            Exit Sub
            BarStaticItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Else
            BarStaticItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If


        CheckUserRole()
        CheckConfig()



        Dim tmpSERVER As String = ""
        If strDataSource = "localhost" Then
            tmpSERVER = "-[MyPCU SERVER]"
        Else
            tmpSERVER = "-[MyPCU CLIENT]"
        End If

        Me.Text = Me.Text & tmpSERVER

        Dim ds As New DataSet
        ds = clsdataBus.Lc_Business.MySQl_version()
        If vPROVIDER_ID <> "" Then
            tmpProvider = " [ผู้ให้บริการ]"
        End If
        Dim tmpClinicName As String = ClsBusiness.Lc_Business.SELECT_NAME_DEPARTMENT(vClinic)
        BarStaticItem3.Caption = "| MySQL Version : " & ds.Tables(0).Rows(0).Item("Value").ToString
        BarStaticItem4.Caption = "| หน่วยบริการ : " & vHname & "  [" & vHcode & "] | ชื่อผู้ใช้งาน : คุณ" & vNAME_USER & tmpProvider & " | แผนก : " & tmpClinicName

        CheckHoliday()

        Dim ds9 As DataSet
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 4)


        Try
            WebBrowser1.Navigate("http://mypcu.in.th/mypcu3.html")
        Catch ex As Exception

        End Try


        Dim ds3 As DataSet
        Dim tmpVERSION2 As String = ""
        Try
            ds3 = clsdataBus.Lc_Business.SELECT_TABLE("VERSION", "l_version", "")
            If ds3.Tables(0).Rows.Count > 0 Then
                tmpVERSION2 = ds3.Tables(0).Rows(0).Item("VERSION").ToString
            End If
        Catch ex As Exception
            tmpVERSION2 = 0
        End Try
        If txtVERSION.Text <> "" Then
            tmpVERSION1 = txtVERSION.Text
            tmpVERSION1_NAME = txtVERSION2.Text


            If CInt(tmpVERSION2) < CInt(tmpVERSION1) Then
                If XtraMessageBox.Show("มีการ Update โปรแกรม เป็น Version " & tmpVERSION1_NAME & vbCrLf & "ต้องการ Download เพื่อ Update เลยหรือไม่? ", vProgram, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = System.Windows.Forms.DialogResult.Yes Then
                    Dim f As New frmMypPCU_News
                    f.ShowDialog()
                Else
                    'Exit Sub
                End If
            End If
        End If
        If vVersionCODE <> tmpVERSION2 Then
            If XtraMessageBox.Show("มีการปรับปรุงเวอร์ชั่นในเครื่องแม่ข่าย โปรดตรวจสอบว่าเวอร์ชั่นตรงกันหรือไม่? ", vProgram, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = System.Windows.Forms.DialogResult.Yes Then
                Dim f As New frmMypPCU_News
                f.ShowDialog()
            Else
                'Exit Sub
            End If
        End If


        ds9 = clsdataBus.Lc_Business.SELECT_TABLE("*", "r_log", "WHERE SUBSTR(D_UPDATE,1,8) = '" & tmpNow & "' AND USER_REC = '" & vUSERID & "' ")
        If ds9.Tables(0).Rows.Count = 1 Then
            ' Timer2.Enabled = True

            If dDrugStore = "1" Then
                'FixDRUGAMOUNT()
            End If

            Dim CurrentForm As Form
            For Each CurrentForm In Me.MdiChildren
                If TypeOf CurrentForm Is frmMypPCU_News Then
                    CurrentForm.MdiParent = Me
                    Exit Sub
                End If
            Next
            Dim f As New frmMypPCU_News
            f.MdiParent = Me
            f.Dock = DockStyle.Fill
            f.Show()

            tmpNHSO = True
            Dim tmpUPDATE1 As String = ""
            Dim tmpUPDATE2 As String = ""
        End If

        Dim ds10 As DataSet
        ds10 = clsdataBus.Lc_Business.SELECT_TABLE("*", "r_log", "WHERE SUBSTR(D_UPDATE,1,8) = '" & tmpNow & "'")
        If ds10.Tables(0).Rows.Count = 1 Then
            ClsBusinessEntity.Lc_BusinessEntity.Updatem_table(" n_user_nhso ", " PASSWORD = '' ", " IFNULL(PASSWORD,'') <> '' ")
            Dim f2 As New frmSystemCheck
            f2.ShowDialog()
        End If
        If vUserCID <> "" Then
            If tmpNHSO = True Then
                Dim f As New frmNHSOlogin
                f.ShowDialog()
            End If
        End If

        GetVersion()

        If tmpShowDSPM = "1" Then
            CheckDSPM()
        End If

        ConnectDBAsset()

        Timer1.Enabled = True

    End Sub

    Private Sub CheckUserRole()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("IFNULL(ADMIN,'0') AS ADMIN,IFNULL(POP,'0') AS POP,IFNULL(CHRONIC,'0') AS CHRONIC,IFNULL(SERVICE,'0') AS SERVICE,IFNULL(ASSET,'0') AS ASSET,IFNULL(MET_ADMIN,'0') AS MET_ADMIN,IFNULL(MET_USER,'0') AS MET_USER,IFNULL(DRUG_STORE,'0') AS DRUG_STORE,IFNULL(ACC,'0') AS ACC,IFNULL(DATA,'0') AS DATA", " l_user ", "WHERE USER_ID = '" & vUSERID & "'")

        If ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows(0).Item("ADMIN").ToString = "0" Then
                RibbonPageGroup1.Enabled = False
                RibbonPageGroup10.Enabled = False
            Else
                RibbonPageGroup1.Enabled = True
                RibbonPageGroup10.Enabled = True
            End If
            If ds.Tables(0).Rows(0).Item("POP").ToString = "0" Then

            End If
            If ds.Tables(0).Rows(0).Item("CHRONIC").ToString = "1" Then

            End If

            If ds.Tables(0).Rows(0).Item("SERVICE").ToString = "1" Then

            End If

            If ds.Tables(0).Rows(0).Item("ASSET").ToString = "1" Then

            End If
            If ds.Tables(0).Rows(0).Item("MET_ADMIN").ToString = "1" Then

            End If

            If ds.Tables(0).Rows(0).Item("MET_USER").ToString = "1" Then

            End If

            If ds.Tables(0).Rows(0).Item("DRUG_STORE").ToString = "1" Then

            End If

            If ds.Tables(0).Rows(0).Item("ACC").ToString = "0" Then
                RibbonPage10.Visible = False
            Else
                RibbonPage10.Visible = True
            End If

            If ds.Tables(0).Rows(0).Item("DATA").ToString = "1" Then

            End If
        End If

    End Sub
    Private Sub CheckConfig()
        Try
            Dim filePath = Application.StartupPath & "\config.ini"
            Dim file As New IniFile()
            file.Load(filePath)

            vClinic = file.Sections("Clinic").Keys("Department").Value
            If file.Sections("Clinic").Keys("Show").Value = "0" Then
                Dim f As New frmSelectDepartment
                f.ShowDialog()
            End If
            tmpShowDSPM = file.Sections("DSPM").Keys("Show").Value

        Catch ex As Exception

        End Try


        Try
            Dim filePath = Application.StartupPath & "\config.ini"
            Dim file As New IniFile()
            file.Load(filePath)

            vICD10TH = file.Sections("ICD").Keys("vICD10TH").Value
            vICD10 = file.Sections("ICD").Keys("vICD10").Value
            vICD10TM = file.Sections("ICD").Keys("vICD10").Value
            vICD10TMD = file.Sections("ICD").Keys("vICD10").Value
            vICD9 = file.Sections("ICD").Keys("vICD9").Value
            vICD9TM = file.Sections("ICD").Keys("vICD9TM").Value
            vICD9TMD = file.Sections("ICD").Keys("vICD9TMD").Value
            vICD9DENT = file.Sections("ICD").Keys("vICD9DENT").Value
            vICD9CHINA = file.Sections("ICD").Keys("vICD9CHINA").Value

            ICD10_1 = file.Sections("ICD").Keys("ICD10_1").Value
            ICD10_2 = file.Sections("ICD").Keys("ICD10_2").Value
            ICD10_3 = file.Sections("ICD").Keys("ICD10_3").Value
            ICD10_4 = file.Sections("ICD").Keys("ICD10_4").Value
            ICD10_5 = file.Sections("ICD").Keys("ICD10_5").Value
        Catch ex As Exception

        End Try



        If ICD10_1 = "1" Then
            vICD10_1 = ClsICD.strOP_1
            vICD10PP_1 = ClsICD.strPP_1
        Else
            vICD10_1 = ""
            vICD10PP_1 = ""
        End If
        If ICD10_2 = "1" Then
            vICD10_2 = ClsICD.strOP_2
            vICD10PP_2 = ClsICD.strPP_2
        Else
            vICD10_2 = ""
            vICD10PP_2 = ""
        End If
        If ICD10_3 = "1" Then
            vICD10_3 = ClsICD.strOP_3
            vICD10PP_3 = ClsICD.strPP_3
        Else
            vICD10_3 = ""
            vICD10PP_3 = ""
        End If
        If ICD10_4 = "1" Then
            vICD10_4 = ClsICD.strOP_4
            vICD10PP_4 = ClsICD.strPP_4
        Else
            vICD10_4 = ""
            vICD10PP_4 = ""
        End If
        If ICD10_5 = "1" Then
            vICD10_5 = ClsICD.strOP_5
            vICD10PP_5 = ClsICD.strPP_5
        Else
            vICD10_5 = ""
            vICD10PP_5 = ""
        End If
        vICD10OP = vICD10_1 & vICD10_2 & vICD10_3 & vICD10_4 & vICD10_5 & ClsICD.strICD10_End
        vICD10PP = vICD10PP_1 & vICD10PP_2 & vICD10PP_3 & vICD10PP_4 & vICD10PP_5 & ClsICD.strICD10_End

        CheckPrinter()
        CheckImage()
    End Sub
    Private Sub GetVersion()
        Dim strHostName As String

        strHostName = System.Net.Dns.GetHostName()

        Dim dsx As DataSet
        dsx = clsdataBus.Lc_Business.SELECT_TABLE("*", "r_system_update ", " WHERE COMPUTER_NAME = '" & My.Computer.Name & "'  ")

        If dsx.Tables(0).Rows.Count > 0 Then
            clsbusent.Lc_BusinessEntity.Updatem_table("r_system_update", "VERSION = '" & vVersion & "',VERSION_CODE = '" & vVersionCODE & "'", "  COMPUTER_NAME = '" & My.Computer.Name & "' ")
        Else
            clsbusent.Lc_BusinessEntity.Insertm_table("r_system_update (COMPUTER_NAME,VERSION_CODE,VERSION)",
                            "'" & My.Computer.Name & "','" & vVersionCODE & "','" & vVersion & "'")
        End If
    End Sub
    Private Sub ConnectDBAsset()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("*", "l_config_mypcu_pro", " WHERE ROWID = '08' ")
        If ds.Tables(0).Rows.Count > 0 Then
            clsDataAcc8.G_DBIPServer8 = ds.Tables(0).Rows(0).Item("HOST").ToString
            clsDataAcc8.G_DBUserName8 = ds.Tables(0).Rows(0).Item("USERNAME").ToString
            clsDataAcc8.G_DBPassword8 = ds.Tables(0).Rows(0).Item("PASSWORD").ToString
            clsDataAcc8.G_DBPortServer8 = ds.Tables(0).Rows(0).Item("PORT").ToString
            clsDataAcc8.G_DBName8 = ds.Tables(0).Rows(0).Item("DATABASENAME").ToString

            If clsDataAcc8.Lc_DataAcc8.getDB_Conn_db8 = False Then
                RibbonPage14.Visible = False
            End If
        Else
            RibbonPage14.Visible = False
        End If
    End Sub
    Private Sub CheckDSPM()
        Dim ds As DataSet
        'Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 4)

        ds = clsdataBus.Lc_Business.SELECT_TABLE(" PID ", " m_person ", " WHERE TYPEAREA IN('1','3') AND DISCHARGE = '9' AND STATUS_AF <> '8' AND TIMESTAMPDIFF( MONTH, BIRTH, NOW()) IN(9,18,30,42,60) " _
                                                 & " AND PID NOT IN(SELECT a.PID FROM m_person a JOIN m_specialpp b ON(a.PID = b.PID) WHERE TIMESTAMPDIFF( MONTH, BIRTH, DATE_SERV) = TIMESTAMPDIFF( MONTH, BIRTH, NOW())  AND (PPSPECIAL LIKE '1B20%' OR PPSPECIAL LIKE '1B21%' OR PPSPECIAL LIKE '1B22%' OR PPSPECIAL LIKE '1B23%' OR PPSPECIAL LIKE '1B24%')) ORDER BY BIRTH DESC ")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim CurrentForm As Form
            For Each CurrentForm In Me.MdiChildren
                If TypeOf CurrentForm Is frmCheckDSPM Then
                    CurrentForm.MdiParent = Me
                    Exit Sub
                End If
            Next
            Dim f As New frmCheckDSPM
            f.MdiParent = Me
            f.Dock = DockStyle.Fill
            f.Show()
        End If
    End Sub
    Private Sub CheckSurveil()
        Dim ds As DataSet
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 4)

        ds = clsdataBus.Lc_Business.SELECT_TABLE("*", "m_surveillance ", " WHERE DATE_SERV = '" & tmpNow & "' AND IFNULL(SEND_DBF,'') <> '1' ")
        If ds.Tables(0).Rows.Count > 0 Then
            If XtraMessageBox.Show("วันนี้มีผู้ป่วยโรคที่ต้องเฝ้าระวังจำนวน " & ds.Tables(0).Rows.Count & " ราย คุณต้องการส่งข้อมูลหรือไม่?", vProgram, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = System.Windows.Forms.DialogResult.Yes Then
                Dim f As New frmSend506
                f.ShowDialog()
            End If
        End If


    End Sub
    Private Sub CheckPrinter()
        Try
            Dim filePath = Application.StartupPath & "\config.ini"
            Dim file As New IniFile()
            file.Load(filePath)

            Print1 = file.Sections("Print1").Keys("Printername").Value
            Width1 = file.Sections("Print1").Keys("Width").Value
            Height1 = file.Sections("Print1").Keys("Height").Value
            MarginTop1 = file.Sections("Print1").Keys("MarginTop").Value
            MarginBottom1 = file.Sections("Print1").Keys("MarginBottom").Value
            MarginLeft1 = file.Sections("Print1").Keys("MarginLeft").Value
            MarginRight1 = file.Sections("Print1").Keys("MarginRight").Value
            PrintView1 = file.Sections("Print1").Keys("PrintView").Value
        Catch ex As Exception
        End Try


        Try
            Dim filePath = Application.StartupPath & "\config.ini"
            Dim file As New IniFile()
            file.Load(filePath)

            Print2 = file.Sections("Print2").Keys("Printername").Value
            Width2 = file.Sections("Print2").Keys("Width").Value
            Height2 = file.Sections("Print2").Keys("Height").Value
            MarginTop2 = file.Sections("Print2").Keys("MarginTop").Value
            MarginBottom2 = file.Sections("Print2").Keys("MarginBottom").Value
            MarginLeft2 = file.Sections("Print2").Keys("MarginLeft").Value
            MarginRight2 = file.Sections("Print2").Keys("MarginRight").Value
            PrintView2 = file.Sections("Print2").Keys("PrintView").Value
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CheckImage()
        Try
            Dim filePath = Application.StartupPath & "\config.ini"
            Dim file As New IniFile()
            file.Load(filePath)
            vImage = file.Sections("Pictures").Keys("Type").Value
            PicPer = file.Sections("Pictures").Keys("Folder").Value

        Catch ex As Exception
            vImage = "1"
        End Try
    End Sub
    Private Sub CheckHoliday()
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 4)

        Dim dsh As DataSet
        dsh = clsdataBus.Lc_Business.SELECT_TABLE("FLAG_HOLIDAY", " l_holidays ", " WHERE DATE_HOLIDAY = '" & tmpNow & "'")
        If dsh.Tables(0).Rows.Count = 0 Then
            Dim f As New frmHolidays
            f.ShowDialog()
        Else
            vHoliday = dsh.Tables(0).Rows(0).Item("FLAG_HOLIDAY").ToString
            If vHoliday = "0" Then
                If XtraMessageBox.Show("วันนี้เป็นวันทำการปกติใช่่หรือไม่?", vProgram, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.No Then
                    Dim f As New frmHolidays
                    f.ShowDialog()
                End If
            Else
                If XtraMessageBox.Show("วันนี้เป็นวันหยุดราชการใช่่หรือไม่?", vProgram, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = System.Windows.Forms.DialogResult.No Then
                    Dim f As New frmHolidays
                    f.ShowDialog()
                End If
            End If
        End If




        If vHoliday = "1" Then
            BarStaticItem5.Caption = "| นอกเวลาทำการ"
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 1000
        Try

            Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate()
            Dim tmpNow2 As String = DateTime.ParseExact(tmpNow, "yyyyMMddHHmmss", CultureInfo.CurrentCulture).ToString("HHmmss")

            tmpNow = " SERVER Date Time : " & DateTime.ParseExact(tmpNow, "yyyyMMddHHmmss", CultureInfo.CurrentCulture).ToString("d MMM yyyy HH:mm:ss")
            BarStaticItem7.Caption = tmpNow

            If tmpNow2 > vOUTTIME Then
                BarStaticItem5.Caption = "| นอกเวลาทำการ"
            End If
            If tmpNow2 < 60000 Then
                BarStaticItem5.Caption = "| นอกเวลาทำการ"
            End If

        Catch ex As Exception


        End Try

    End Sub
    Private Sub mnuConnectDB_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuConnectDB.ItemClick
        Dim fDBSetting As New frmDBSetting
        fDBSetting.ShowDialog()
    End Sub


    Private Sub mnuHosConfig_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuHosConfig.ItemClick
        Dim fHospConfig As New frmHospConfig
        fHospConfig.ShowDialog()
    End Sub

    Private Sub mnuAreaSetting_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuAreaSetting.ItemClick
        Dim fHospConfig As New frmAreaSetting
        fHospConfig.ShowDialog()
    End Sub

    Private Sub mnuDbConfigAssets_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuDbConfigAssets.ItemClick
        Dim fHospConfig As New frmDbConfigAssets
        fHospConfig.ShowDialog()
    End Sub

    Private Sub BarButtonItem23_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem23.ItemClick
        Dim CurrentForm As Form
        For Each CurrentForm In Me.MdiChildren
            If TypeOf CurrentForm Is frmMypPCU_News Then
                CurrentForm.MdiParent = Me
                Exit Sub
            End If
        Next
        Dim f As New frmMypPCU_News
        f.MdiParent = Me
        f.Dock = DockStyle.Fill
        f.Show()
    End Sub
    Private Sub SaveColor(ByVal Str As String)
        Dim filePath = Application.StartupPath & "\dc.ini"
        Dim file2 As New IniFile()
        If File.Exists(Application.StartupPath & "\dc.ini") Then
            file2.Load(filePath)
        End If
        file2.Sections.Remove("Color")
        Dim section As IniSection = file2.Sections.Add("Color")


        file2.Sections("Color").Keys.Clear()
        Dim key As IniKey = file2.Sections("Color").Keys.Add("Color", Str)
        file2.Save(filePath)

    End Sub
    Private Sub chkRed_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles chkRed.ItemClick
        If chkRed.Checked = True Then
            chkDarkblue.Checked = False
            chkGreen.Checked = False
            chkBlue.Checked = False
            chkOrange.Checked = False
            chkPurple.Checked = False
            chkTeal.Checked = False
            SaveColor("1")
            Me.Ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Red
            Me.Ribbon.Refresh()
            vColor = "1"
        End If
    End Sub
    Private Sub chkBlue_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles chkBlue.ItemClick
        If chkBlue.Checked = True Then
            chkDarkblue.Checked = False
            chkGreen.Checked = False
            chkRed.Checked = False
            chkOrange.Checked = False
            chkPurple.Checked = False
            chkTeal.Checked = False
            vColor = "2"
            SaveColor("2")
            Me.Ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Blue
            Me.Ribbon.Refresh()
        End If
    End Sub

    Private Sub chkDarkblue_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles chkDarkBlue.ItemClick
        If chkDarkblue.Checked = True Then
            chkBlue.Checked = False
            chkGreen.Checked = False
            chkRed.Checked = False
            chkOrange.Checked = False
            chkPurple.Checked = False
            chkTeal.Checked = False
            vColor = "3"
            SaveColor("3")

            Me.Ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.DarkBlue
            Me.Ribbon.Refresh()
        End If
    End Sub
    Private Sub chkGreen_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles chkGreen.ItemClick
        If chkGreen.Checked = True Then
            chkBlue.Checked = False
            chkDarkblue.Checked = False
            chkRed.Checked = False
            chkOrange.Checked = False
            chkPurple.Checked = False
            chkTeal.Checked = False
            vColor = "4"
            SaveColor("4")

            Me.Ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Green
            Me.Ribbon.Refresh()
        End If
    End Sub
    Private Sub chkOrange_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles chkOrange.ItemClick
        If chkOrange.Checked = True Then
            chkBlue.Checked = False
            chkDarkblue.Checked = False
            chkRed.Checked = False
            chkGreen.Checked = False
            chkPurple.Checked = False
            chkTeal.Checked = False
            vColor = "5"
            SaveColor("5")

            Me.Ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Orange
            Me.Ribbon.Refresh()
        End If
    End Sub
    Private Sub chkPurple_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles chkPurple.ItemClick
        If chkPurple.Checked = True Then
            chkBlue.Checked = False
            chkDarkblue.Checked = False
            chkRed.Checked = False
            chkGreen.Checked = False
            chkOrange.Checked = False
            chkTeal.Checked = False
            vColor = "6"
            SaveColor("6")

            Me.Ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Purple
            Me.Ribbon.Refresh()
        End If
    End Sub
    Private Sub chkTeal_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles chkTeal.ItemClick
        If chkTeal.Checked = True Then
            chkBlue.Checked = False
            chkDarkblue.Checked = False
            chkRed.Checked = False
            chkGreen.Checked = False
            chkPurple.Checked = False
            chkOrange.Checked = False
            vColor = "7"
            SaveColor("7")
            Me.Ribbon.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Teal
            Me.Ribbon.Refresh()
        End If
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        Dim CurrentForm As Form
        For Each CurrentForm In Me.MdiChildren
            If TypeOf CurrentForm Is frmProvider Then
                CurrentForm.MdiParent = Me
                Exit Sub
            End If
        Next
        Dim f As New frmProvider
        f.MdiParent = Me
        f.Dock = DockStyle.Fill
        f.Show()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Dim f As New frmComfigSystem
        f.ShowDialog()
        CheckConfig()
    End Sub

    Private Sub BarButtonItem24_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem24.ItemClick
        Dim CurrentForm As Form
        For Each CurrentForm In Me.MdiChildren
            If TypeOf CurrentForm Is frmHome Then
                CurrentForm.MdiParent = Me
                Exit Sub
            End If
        Next
        Dim f As New frmHome
        f.MdiParent = Me
        f.Dock = DockStyle.Fill
        f.Show()
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Dim f As New frmConfigPicture
        f.ShowDialog()
    End Sub
    Private Sub BarButtonItem69_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem69.ItemClick
        Me.Close()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        vConfigOnline = "1"
        Dim f As New frmSystemCheck
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem72_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem72.ItemClick
        Dim CurrentForm As Form
        For Each CurrentForm In Me.MdiChildren
            If TypeOf CurrentForm Is frmCheckData Then
                CurrentForm.MdiParent = Me
                Exit Sub
            End If
        Next
        Dim f As New frmCheckData
        f.MdiParent = Me
        f.Dock = DockStyle.Fill
        f.Show()
    End Sub

    Private Sub BarButtonItem75_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem75.ItemClick
        Dim CurrentForm As Form
        For Each CurrentForm In Me.MdiChildren
            If TypeOf CurrentForm Is frmMedicineList Then
                CurrentForm.MdiParent = Me
                Exit Sub
            End If
        Next
        Dim f As New frmMedicineList
        f.MdiParent = Me
        f.Dock = DockStyle.Fill
        f.Show()
    End Sub

    Private Sub BarButtonItem78_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem78.ItemClick
        Dim f As New frmBkupData
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Dim f As New frmSendMyPCUConfig
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Dim f As New frmFingerPrintDatabase
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem79_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem79.ItemClick
        Dim f As New frmRestore
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        Dim f As New frmDepartmentEdit
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem22_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem22.ItemClick
        Dim f As New frmSelectDepartment
        f.ShowDialog()
        Dim tmpClinicName As String = ClsBusiness.Lc_Business.SELECT_NAME_DEPARTMENT(vClinic)
        BarStaticItem4.Caption = "| หน่วยบริการ : " & vHname & "  [" & vHcode & "] | ชื่อผู้ใช้งาน : คุณ" & vNAME_USER & tmpProvider & " | แผนก : " & tmpClinicName
        BarStaticItem4.Refresh()

    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        Dim CurrentForm As Form
        For Each CurrentForm In Me.MdiChildren
            If TypeOf CurrentForm Is frmUser Then
                CurrentForm.MdiParent = Me
                Exit Sub
            End If
        Next
        Dim f As New frmUser
        f.MdiParent = Me
        f.Dock = DockStyle.Fill
        f.Show()
    End Sub

    Private Sub BarButtonItem19_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem19.ItemClick
        Dim f As New frmChangeUser
        f.ShowDialog()
        If vPROVIDER_ID <> "" Then
            tmpProvider = " [ผู้ให้บริการ]"
        Else
            tmpProvider = ""
        End If
        Dim tmpClinicName As String = ClsBusiness.Lc_Business.SELECT_NAME_DEPARTMENT(vClinic)
        BarStaticItem4.Caption = "| หน่วยบริการ : " & vHname & "  [" & vHcode & "] | ชื่อผู้ใช้งาน : คุณ" & vNAME_USER & tmpProvider & " | แผนก : " & tmpClinicName
        BarStaticItem4.Refresh()
        CheckUserRole()
    End Sub

    Private Sub BarButtonItem20_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem20.ItemClick
        Dim f As New frmChangPassword
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        Dim CurrentForm As Form
        For Each CurrentForm In Me.MdiChildren
            If TypeOf CurrentForm Is frmProcedPrice Then
                CurrentForm.MdiParent = Me
                Exit Sub
            End If
        Next
        Dim f As New frmProcedPrice
        f.MdiParent = Me
        f.Dock = DockStyle.Fill
        f.Show()
    End Sub

    Private Sub BarButtonItem96_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem96.ItemClick
        Dim f As New frmIcd10Search
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem97_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem97.ItemClick
        Dim f As New frmIcd9Search
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem99_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem99.ItemClick
        Dim f As New frmImportTMT
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem27_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem27.ItemClick
        Dim f As New frmPerson
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem102_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem102.ItemClick
        Dim f As New frmLookupPrename
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem88_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem88.ItemClick
        Dim CurrentForm As Form
        For Each CurrentForm In Me.MdiChildren
            If TypeOf CurrentForm Is frmVaccineMain Then
                CurrentForm.MdiParent = Me
                Exit Sub
            End If
        Next
        Dim f As New frmVaccineMain
        f.MdiParent = Me
        f.Dock = DockStyle.Fill
        f.Show()
    End Sub

    Private Sub BarButtonItem120_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem120.ItemClick
        Dim f As New frmMyPCUupdate
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem117_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem117.ItemClick
        Dim f As New frmTableAssetType
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem103_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem103.ItemClick
        Dim f As New frmLookupOccupation
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem105_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem105.ItemClick
        Dim f As New frmLookupReligion
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem121_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem121.ItemClick
        Dim f As New frmAdjPrename
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem118_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem118.ItemClick
        Dim f As New frmTableAssetsGroup
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem119_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem119.ItemClick
        Dim f As New frmTableGroupType
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem128_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem128.ItemClick
        Dim f As New frmTableAssets
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem129_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem129.ItemClick
        Dim f As New frmTableLocationOffice
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem131_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem131.ItemClick
        Dim f As New frmTableBtype
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem132_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem132.ItemClick
        Dim f As New frmTableBudget
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem133_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem133.ItemClick
        Dim f As New frmTableStatus
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem134_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem134.ItemClick
        Dim f As New frmCompanySearch
        f.ShowDialog()
    End Sub

    Private Sub mnuAssetsManage_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuAssetsManage.ItemClick
        Dim CurrentForm As Form
        For Each CurrentForm In Me.MdiChildren
            If TypeOf CurrentForm Is frmManageAsset Then
                CurrentForm.MdiParent = Me
                Exit Sub
            End If
        Next
        Dim f As New frmManageAsset
        f.MdiParent = Me
        f.Dock = DockStyle.Fill
        f.Show()
    End Sub

    Private Sub BarButtonItem122_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem122.ItemClick
        Dim f As New frmAdjustOccupation
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem106_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem106.ItemClick
        Dim f As New frmLookupEducation
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem104_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem104.ItemClick
        Dim f As New frmLookupNation
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem107_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem107.ItemClick
        Dim f As New frmLookupLabor
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem123_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem123.ItemClick
        Dim f As New frmAdjRace
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem124_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem124.ItemClick
        Dim f As New frmAdjNation
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem126_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem126.ItemClick
        Dim f As New frmAdjEducation
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem125_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem125.ItemClick
        Dim f As New frmAdjReligion
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem127_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem127.ItemClick
        Dim f As New frmAdjLabor
        f.ShowDialog()
    End Sub


    Private Sub BarButtonItem138_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem138.ItemClick
        Dim f As New frmLookupMstatus
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem139_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem139.ItemClick
        Dim f As New frmAdjMstatus
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem155_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem155.ItemClick
        Dim f As New frmLookupMstatus
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem156_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem156.ItemClick
        Dim f As New frmAdjMstatus
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem157_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem157.ItemClick
        Dim f As New frmLookupPersonContact
        f.ShowDialog()
    End Sub

    Private Sub BarButtonItem159_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem159.ItemClick
        Dim CurrentForm As Form
        For Each CurrentForm In Me.MdiChildren
            If TypeOf CurrentForm Is frmReportPopMain Then
                CurrentForm.MdiParent = Me
                Exit Sub
            End If
        Next
        Dim f As New frmReportPopMain
        f.MdiParent = Me
        f.Dock = DockStyle.Fill
        f.Show()

    End Sub
End Class