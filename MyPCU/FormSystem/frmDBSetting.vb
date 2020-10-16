Imports System.Xml
Imports System.IO
Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports DevExpress.XtraEditors
Imports MadMilkman.Ini
Public Class frmDBSetting

    Private Sub frmDBSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim filePath = Application.StartupPath & "\dc.ini"
            Dim file As New IniFile()
            file.Load(filePath)

            txtDataSource.Text = Decode(file.Sections("Database").Keys("Host").Value)
            txtPort.Text = Decode(file.Sections("Database").Keys("Port").Value)
            txtUserID.Text = Decode(file.Sections("Database").Keys("User").Value)
            txtPassword.Text = Decode(file.Sections("Database").Keys("Pwd").Value)
            txtDatabase.Text = Decode(file.Sections("Database").Keys("DbName").Value)
        Catch ex As Exception
            XtraMessageBox.Show("ไม่สามารถทำการเชื่อมต่อ database ได้", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub cmdTest_Click(sender As Object, e As EventArgs) Handles cmdTest.Click
        Dim strDbType As String = ""
        Dim strDbTypeValue As String = ""
        Dim strDataSource As String = txtDataSource.Text.ToString().Trim()
        Dim strUserID As String = txtUserID.Text.ToString().Trim()
        Dim strPassword As String = txtPassword.Text.ToString().Trim()
        Dim strPort As String = txtPort.Text.ToString().Trim()
        Dim strDbName As String = txtDatabase.Text.ToString().Trim()
        Dim tmpDataSource As String = clsDataAcc.G_DBIPServer
        Dim tmpUserID As String = clsDataAcc.G_DBUserName
        Dim tmpPassword As String = clsDataAcc.G_DBPassword
        Dim tmpPort As String = clsDataAcc.G_DBPortServer
        Dim tmpDbName As String = clsDataAcc.G_DBName

        clsDataAcc.G_DBIPServer = strDataSource
        clsDataAcc.G_DBPortServer = strPort
        clsDataAcc.G_DBUserName = strUserID
        clsDataAcc.G_DBPassword = strPassword
        clsDataAcc.G_DBName = strDbName

        If clsDataAcc.Lc_DataAcc.getDB_Conn() = False Then
            XtraMessageBox.Show(msNotConnectDb, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            clsDataAcc.G_DBIPServer = tmpDataSource
            clsDataAcc.G_DBPortServer = tmpPort
            clsDataAcc.G_DBUserName = tmpUserID
            clsDataAcc.G_DBPassword = tmpPassword
            clsDataAcc.G_DBName = tmpDbName
            Exit Sub
        Else
            XtraMessageBox.Show(msConnectDb, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim filePath = Application.StartupPath & "\dc.ini"
        Dim file2 As New IniFile()
        If File.Exists(filePath) = True Then
            file2.Load(filePath)
        End If

        file2.Sections.Remove("Database")
        Dim section As IniSection = file2.Sections.Add("Database")

        Dim key As IniKey = file2.Sections("Database").Keys.Add("Host", Encode(txtDataSource.Text))
        Dim key2 As IniKey = file2.Sections("Database").Keys.Add("Port", Encode(txtPort.Text))
        Dim key3 As IniKey = file2.Sections("Database").Keys.Add("User", Encode(txtUserID.Text))
        Dim key4 As IniKey = file2.Sections("Database").Keys.Add("Pwd", Encode(txtPassword.Text))
        Dim key5 As IniKey = file2.Sections("Database").Keys.Add("DbName", Encode(txtDatabase.Text))

        file2.Save(filePath)


        Try
            Dim strDbType As String = ""
            Dim strDbTypeValue As String = ""

            Dim strDataSource As String = txtDataSource.Text.ToString().Trim()
            Dim strUserID As String = txtUserID.Text.ToString().Trim()
            Dim strPassword As String = txtPassword.Text.ToString().Trim()
            Dim strPort As String = txtPort.Text.ToString().Trim()
            Dim strDbName As String = txtDatabase.Text.ToString().Trim()
            Dim tmpDataSource As String = clsDataAcc.G_DBIPServer
            Dim tmpUserID As String = clsDataAcc.G_DBUserName
            Dim tmpPassword As String = clsDataAcc.G_DBPassword
            Dim tmpPort As String = clsDataAcc.G_DBPortServer
            Dim tmpDbName As String = clsDataAcc.G_DBName
            clsDataAcc.G_DBIPServer = strDataSource
            clsDataAcc.G_DBPortServer = strPort
            clsDataAcc.G_DBUserName = strUserID
            clsDataAcc.G_DBPassword = strPassword
            clsDataAcc.G_DBName = strDbName

            XtraMessageBox.Show("ทำการบันทึกการเชื่อมต่อฐานข้อมูล MySQL เรียบร้อยแล้ว", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)

            If clsDataAcc.Lc_DataAcc.getDB_Conn() = False Then
                XtraMessageBox.Show("ไม่สามารถทำการเชื่อมต่อ database ได้", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                clsDataAcc.G_DBIPServer = tmpDataSource
                clsDataAcc.G_DBPortServer = tmpPort
                clsDataAcc.G_DBUserName = tmpUserID
                clsDataAcc.G_DBPassword = tmpPassword
                clsDataAcc.G_DBName = tmpDataSource
                Exit Sub
            Else
                XtraMessageBox.Show("ทำการเชื่อมต่อ database ได้ ระบบจะทำการปิดโปรแกรมหลังจากนี้", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
                frmLogin.Close()
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message.ToString())
        End Try

    End Sub

End Class