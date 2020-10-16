Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports clsDataAcc4 = MyPCU.ClsDataAccess4
Imports System.IO
Imports System.Drawing.Printing
Imports DevExpress.XtraEditors
Imports MadMilkman.Ini
Imports MySql.Data.MySqlClient
Public Class frmConfigThaiRefer
    Private Sub frmConfigThaiRefer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("*", "l_config_mypcu_pro", " WHERE ROWID = '04' ")
        If ds.Tables(0).Rows.Count > 0 Then
            txtDataSource.Text = ds.Tables(0).Rows(0).Item("HOST")
            txtUserID.Text = ds.Tables(0).Rows(0).Item("USERNAME")
            txtPassword.Text = ds.Tables(0).Rows(0).Item("PASSWORD")
            txtPort.Text = ds.Tables(0).Rows(0).Item("PORT")
            txtDatabasename.Text = ds.Tables(0).Rows(0).Item("DATABASENAME")
        End If
    End Sub

    Private Sub cmdTest_Click(sender As Object, e As EventArgs) Handles cmdTest.Click

        Dim strDataSource As String = txtDataSource.Text.ToString().Trim()
        Dim strUserID As String = txtUserID.Text.ToString().Trim()
        Dim strPassword As String = txtPassword.Text.ToString().Trim()
        Dim strPort As String = txtPort.Text.ToString().Trim()
        Dim strDbname As String = txtDatabasename.Text.ToString().Trim()

        clsDataAcc4.G_DBIPServer4 = strDataSource
        clsDataAcc4.G_DBPortServer4 = strPort
        clsDataAcc4.G_DBUserName4 = strUserID
        clsDataAcc4.G_DBPassword4 = strPassword
        clsDataAcc4.G_DBName4 = strDbname
        If clsDataAcc4.Lc_DataAcc4.getDB_Conn_db4() = False Then
            XtraMessageBox.Show("ไม่สามารถทำการเชื่อมต่อ database ได้", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            clsDataAcc4.G_DBIPServer4 = strDataSource
            clsDataAcc4.G_DBPortServer4 = strPort
            clsDataAcc4.G_DBUserName4 = strUserID
            clsDataAcc4.G_DBPassword4 = strPassword
            clsDataAcc4.G_DBName4 = strDbname
            Exit Sub
        Else
            XtraMessageBox.Show("ทำการเชื่อมต่อ database ได้", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Try
            Dim strDataSource As String = txtDataSource.Text.ToString().Trim()
            Dim strUserID As String = txtUserID.Text.ToString().Trim()
            Dim strPassword As String = txtPassword.Text.ToString().Trim()
            Dim strPort As String = txtPort.Text.ToString().Trim()
            Dim strDbname As String = txtDatabasename.Text.ToString().Trim()

            Dim ds As DataSet
            ds = clsdataBus.Lc_Business.SELECT_TABLE(" ROWID ", "l_config_mypcu_pro", " WHERE ROWID = '04' ")
            If ds.Tables(0).Rows.Count > 0 Then
                clsbusent.Lc_BusinessEntity.Updatem_table(" l_config_mypcu_pro ", " HOST = '" & strDataSource & "' ,DATABASENAME = '" & strDbname & "',PORT = '" & strPort & "',USERNAME =  '" & strUserID & "',PASSWORD =  '" & strPassword & "'", " ROWID = '04' ")
            Else
                clsbusent.Lc_BusinessEntity.Insertm_table(" l_config_mypcu_pro(ROWID,HOST,DATABASENAME,PORT,USERNAME,PASSWORD)", "'04','" & strDataSource & "','" & strDbname & "','" & strPort & "','" & strUserID & "','" & strPassword & "'")
            End If

            XtraMessageBox.Show("ทำการบันทึกการเชื่อมต่อฐานข้อมูล MyData เรียบร้อยแล้ว", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
            clsDataAcc4.G_DBIPServer4 = txtDataSource.Text
            clsDataAcc4.G_DBPortServer4 = txtPort.Text
            clsDataAcc4.G_DBUserName4 = txtUserID.Text
            clsDataAcc4.G_DBPassword4 = txtPassword.Text
            clsDataAcc4.G_DBName4 = txtDatabasename.Text

            If clsDataAcc4.Lc_DataAcc4.getDB_Conn_db4() = False Then
                XtraMessageBox.Show("ไม่สามารถทำการเชื่อมต่อ database ได้", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                clsDataAcc4.G_DBIPServer4 = strDataSource
                clsDataAcc4.G_DBPortServer4 = strPort
                clsDataAcc4.G_DBUserName4 = strUserID
                clsDataAcc4.G_DBPassword4 = strPassword
                clsDataAcc4.G_DBName4 = strDbname

                Exit Sub
            Else
                XtraMessageBox.Show("ทำการเชื่อมต่อ database ", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
End Class