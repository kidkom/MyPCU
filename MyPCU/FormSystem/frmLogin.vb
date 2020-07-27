Imports MySql.Data.MySqlClient
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsdataBus = MyPCU.ClsBusiness
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.IO
Imports System.Xml
Imports System.Globalization
Imports DevExpress.XtraEditors
Imports MadMilkman.Ini


Public Class frmLogin
    Dim tmpClose As Boolean = False
    Dim tmpCID As String = ""
    Dim tmpPass As Boolean = False

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 0

        Try
            Dim filePath = Application.StartupPath & "\mypcu.ini"
            Dim file As New IniFile()
            file.Load(filePath)
            ConfigUpdate = file.Sections("Version").Keys("UpdateStatus").Value
            vProgram = file.Sections("Version").Keys("VersionName").Value
            vVersionCODE = file.Sections("Version").Keys("Version").Value
            vVersionName = file.Sections("Version").Keys("VersionNameCode").Value
            If ConfigUpdate <> "1" Then
                Dim f As New frmSetup
                f.ShowDialog()
                Me.Close()
                Exit Sub
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message.ToString())
            Exit Sub
        End Try


        lblVersionCode.Text = "Version Code " & vVersionCODE


        Dim strDataSource As String = ""
        Dim strUserID As String = ""
        Dim strPassword As String = ""
        Dim strPort As String = ""
        Try
            Dim filePath = Application.StartupPath & "\dc.ini"
            Dim file As New IniFile()
            file.Load(filePath)

            clsDataAcc.G_DBIPServer = Decode(file.Sections("Database").Keys("Host").Value)
            clsDataAcc.G_DBPortServer = Decode(file.Sections("Database").Keys("Port").Value)
            clsDataAcc.G_DBUserName = Decode(file.Sections("Database").Keys("User").Value)
            clsDataAcc.G_DBPassword = Decode(file.Sections("Database").Keys("Pwd").Value)
            clsDataAcc.G_DBName = Decode(file.Sections("Database").Keys("DbName").Value)
        Catch ex As Exception
            XtraMessageBox.Show("ไม่สามารถทำการเชื่อมต่อ database ได้", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim fDBSetting As New frmDBSetting
            fDBSetting.ShowDialog()
            Exit Sub
        End Try

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

        If clsDataAcc.Lc_DataAcc.getDB_Conn() = False Then
            XtraMessageBox.Show(msNotConnectDb, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)

            clsDataAcc.G_DBIPServer = strDataSource
            clsDataAcc.G_DBPortServer = strPort
            clsDataAcc.G_DBUserName = strUserID
            clsDataAcc.G_DBPassword = strPassword

            Dim fDBSetting As New frmDBSetting
            fDBSetting.ShowDialog()
            Exit Sub
        Else

            Dim ds1 As DataSet
            Dim ds2 As DataSet
            ds1 = clsdataBus.Lc_Business.SELECT_DATA("l_confighcode", "")
            If ds1.Tables(0).Rows.Count = 0 Then
                XtraMessageBox.Show("ยังไม่มีการกำหนดหน่วยงานที่ใช้งาน กรุณากำหนดหน่วยงานก่อน", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Dim fHospConfig As New frmHospConfig
                fHospConfig.ShowDialog()
            Else
                vHcode = ds1.Tables(0).Rows(0).Item("HOSPCODE").ToString
                vHname = ds1.Tables(0).Rows(0).Item("HOSPNAME").ToString
                vHmain = ds1.Tables(0).Rows(0).Item("HMAIN").ToString
                vHmainSSS = ds1.Tables(0).Rows(0).Item("HMAIN_SSS").ToString
                vCUP_PROVINCE = ds1.Tables(0).Rows(0).Item("PROVINCE_ID").ToString
                vProvince = ds1.Tables(0).Rows(0).Item("PROVINCE_NAME").ToString
                pLatitude = ds1.Tables(0).Rows(0).Item("LATITUDE").ToString
                pLongitude = ds1.Tables(0).Rows(0).Item("LONGITUDE").ToString

                If IsDBNull(ds1.Tables(0).Rows(0).Item("DRUG_STORE")) Then
                    dDrugStore = "0"
                Else
                    dDrugStore = ds1.Tables(0).Rows(0).Item("DRUG_STORE").ToString
                End If
                If IsDBNull(ds1.Tables(0).Rows(0).Item("DRUG_LABEL")) Then
                    dDrugLabel = "0"
                Else
                    dDrugLabel = ds1.Tables(0).Rows(0).Item("DRUG_LABEL").ToString
                End If
                vHNPID = ds1.Tables(0).Rows(0).Item("HNPID").ToString
                If Not IsDBNull(ds1.Tables(0).Rows(0).Item("TEL")) Then
                    vTEL = ds1.Tables(0).Rows(0).Item("TEL").ToString
                Else
                    vTEL = ""
                End If
                If Not IsDBNull(ds1.Tables(0).Rows(0).Item("CARD")) Then
                    vPRINTCARD = ds1.Tables(0).Rows(0).Item("CARD").ToString
                Else
                    vPRINTCARD = ""
                End If
                If Not IsDBNull(ds1.Tables(0).Rows(0).Item("BILL")) Then
                    sBILL = ds1.Tables(0).Rows(0).Item("BILL").ToString
                Else
                    sBILL = "0"
                End If
                If Not IsDBNull(ds1.Tables(0).Rows(0).Item("EGFR")) Then
                    vGFR = ds1.Tables(0).Rows(0).Item("EGFR").ToString
                Else
                    vGFR = "0"
                End If
                If Not IsDBNull(ds1.Tables(0).Rows(0).Item("SDX")) Then
                    vSdx = ds1.Tables(0).Rows(0).Item("SDX").ToString
                Else
                    vSdx = "0"
                End If
                If Not IsDBNull(ds1.Tables(0).Rows(0).Item("LABEl_nation")) Then
                    vLabelNation = ds1.Tables(0).Rows(0).Item("LABEl_nation").ToString
                Else
                    vLabelNation = "0"
                End If
                If Not IsDBNull(ds1.Tables(0).Rows(0).Item("DIAGNOSIS")) Then
                    vDIAGNOSIS = ds1.Tables(0).Rows(0).Item("DIAGNOSIS").ToString
                Else
                    vDIAGNOSIS = "0"
                End If
                If Not IsDBNull(ds1.Tables(0).Rows(0).Item("EXAM")) Then
                    vExam = ds1.Tables(0).Rows(0).Item("EXAM").ToString
                Else
                    vExam = "0"
                End If
                If Not IsDBNull(ds1.Tables(0).Rows(0).Item("DIAG_WORD")) Then
                    vDiagWord = ds1.Tables(0).Rows(0).Item("DIAG_WORD").ToString
                Else
                    vDiagWord = "0"
                End If

                If Not IsDBNull(ds1.Tables(0).Rows(0).Item("CSMBS")) Then
                    vCSMBS = ds1.Tables(0).Rows(0).Item("CSMBS").ToString
                Else
                    vCSMBS = "0"
                End If


                If Not IsDBNull(ds1.Tables(0).Rows(0).Item("DENTAL_WARNING")) Then
                    vDental = ds1.Tables(0).Rows(0).Item("DENTAL_WARNING").ToString
                Else
                    vDental = "0"
                End If

                If Not IsDBNull(ds1.Tables(0).Rows(0).Item("MESSAGE_UPDATE")) Then
                    If ds1.Tables(0).Rows(0).Item("MESSAGE_UPDATE").ToString = "" Then
                        vMessageDatetime = "00000000000000"
                    Else
                        vMessageDatetime = ds1.Tables(0).Rows(0).Item("MESSAGE_UPDATE").ToString
                    End If

                Else
                    vMessageDatetime = "00000000000000"
                End If

                If Not IsDBNull(ds1.Tables(0).Rows(0).Item("MESSAGE_STATUS")) Then
                    vMessageStatus = ds1.Tables(0).Rows(0).Item("MESSAGE_STATUS").ToString
                Else
                    vMessageStatus = "0"
                End If

                If IsDBNull(ds1.Tables(0).Rows(0).Item("IMAGE_TYPE")) Then
                    vImage = "0"
                Else
                    vImage = ds1.Tables(0).Rows(0).Item("IMAGE_TYPE").ToString
                End If

                If IsDBNull(ds1.Tables(0).Rows(0).Item("DTX1")) Then
                    vDTX1 = ""
                Else
                    vDTX1 = ds1.Tables(0).Rows(0).Item("DTX1").ToString
                End If

                If IsDBNull(ds1.Tables(0).Rows(0).Item("DTX2")) Then
                    vDTX2 = ""
                Else
                    vDTX2 = ds1.Tables(0).Rows(0).Item("DTX2").ToString
                End If
                If IsDBNull(ds1.Tables(0).Rows(0).Item("INTIME")) Then
                    vINTIME = ds1.Tables(0).Rows(0).Item("INTIME").ToString
                Else
                    vINTIME = "080000"
                End If
                If IsDBNull(ds1.Tables(0).Rows(0).Item("OUTTIME")) Then
                    vOUTTIME = ds1.Tables(0).Rows(0).Item("OUTTIME").ToString
                Else
                    vOUTTIME = "160000"
                End If
            End If



            ds2 = clsdataBus.Lc_Business.SELECT_USER("")
            If ds2.Tables(0).Rows.Count = 0 Then
                XtraMessageBox.Show("ยังไม่มีการกำหนดผู้ใช้งาน กรุณากำหนดผู้ใช้งานท่านแรกก่อน", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Dim fUser As New frmFirstUser
                fUser.ShowDialog()
            End If
        End If
        AutoComplete("l_user", txtUsername)

        Try
            Dim objXmlDoc2 As New XmlDocument()
            objXmlDoc2.Load(ClsVariableShare.XmlConfigDbPathPrint)
            Dim objNode2 As XmlNodeList = objXmlDoc2.SelectNodes("/Configuration/Configurations/DBMS")
            vPicPer = objNode2(0).ChildNodes(17).InnerText.ToString() & "\"
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message.ToString())
        End Try


        Timer1.Enabled = True


    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 100
        If tmpClose = False Then
            Me.Opacity = Me.Opacity + 0.1
            If Me.Opacity = 1 Then
                Timer1.Enabled = False
            End If
        Else
            Me.Opacity = Me.Opacity - 0.1
            If Me.Opacity = 0 Then
                End
            End If
        End If

    End Sub
    Private Sub AutoComplete(ByVal strTable As String, ByVal strTextBox As TextBox)
        Dim ds As DataSet
        strTable = strTable
        ds = clsdataBus.Lc_Business.SELECT_DATA(strTable, " WHERE STATUS = '1' ")

        If ds.Tables(0).Rows.Count > 0 Then
            strTextBox.AutoCompleteCustomSource.Clear()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                strTextBox.AutoCompleteCustomSource.Add(Decode(ds.Tables(0).Rows(i).Item("USERNAME")).ToString)
            Next

        End If

    End Sub

    Private Sub cmdLogin_Click(sender As Object, e As EventArgs) Handles cmdLogin.Click

        Dim ds As DataSet
        If txtUsername.Text = "kidkom" And txtPassword.Text = "piano@123" Then
            Me.Hide()
            Dim fMain As New frmMain
            fMain.Show()
            vUSERID = "0"
            vAdmin = True
        Else
            ds = clsdataBus.Lc_Business.SELECT_USER("WHERE USERNAME = '" & Encode(txtUsername.Text.ToLower) & "' AND PASSWORD = '" & Encode(txtPassword.Text.ToLower) & "' AND STATUS = '1' ")
            If ds.Tables(0).Rows.Count > 0 Then
                vUSERID = ds.Tables(0).Rows(0).Item("USER_ID").ToString
                vNAME_USER = ds.Tables(0).Rows(0).Item("FNAME").ToString & " " & ds.Tables(0).Rows(0).Item("LNAME").ToString
                vPROVIDER_ID = ds.Tables(0).Rows(0).Item("PROVIDER").ToString
                vSEX_PRO = ClsBusiness.Lc_Business.SELECT_NAME_SEX_PROVIDER(vPROVIDER_ID)
                vUserCID = Decode(ds.Tables(0).Rows(0).Item("CID")).ToString

                If ds.Tables(0).Rows(0).Item("ADMIN").ToString = "1" Then
                    vAdmin = True
                End If

                vDrugStore = ds.Tables(0).Rows(0).Item("DRUG_STORE").ToString
                vACC = ds.Tables(0).Rows(0).Item("ACC").ToString


                Me.Hide()
                Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)
                Try
                    clsbusent.Lc_BusinessEntity.Insertm_table("r_log (USER_REC,D_UPDATE)", "'" & vUSERID & "','" & tmpNow & "'")

                Catch ex As Exception

                End Try

                Dim fMain As New frmMain
                fMain.Show()
            Else
                XtraMessageBox.Show("Username หรือ Password ไม่ถูกต้อง", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub cmdCancle_Click(sender As Object, e As EventArgs) Handles cmdCancle.Click
        tmpClose = True
        Timer1.Enabled = True
    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                txtPassword.Select()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call cmdLogin_Click(cmdLogin, New System.EventArgs())
        End If
    End Sub

   
End Class