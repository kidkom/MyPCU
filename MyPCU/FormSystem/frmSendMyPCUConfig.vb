Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports clsDataAcc3 = MyPCU.ClsDataAccess3
Imports DevExpress.XtraEditors
Public Class frmSendMyPCUConfig

    Private Sub frmSendMyPCUConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("*", "l_config_mypcu_pro", " WHERE ROWID = '01' ")
        If ds.Tables(0).Rows.Count > 0 Then
            txtDataSource.Text = ds.Tables(0).Rows(0).Item("HOST")
            txtUserID.Text = ds.Tables(0).Rows(0).Item("USERNAME")
            txtPassword.Text = ds.Tables(0).Rows(0).Item("PASSWORD")
            txtPort.Text = ds.Tables(0).Rows(0).Item("PORT")
            txtDatabasename.Text = ds.Tables(0).Rows(0).Item("DATABASENAME")
        End If

    End Sub

    Private Sub cmdTest_Click(sender As Object, e As EventArgs) Handles cmdTest.Click
        Dim strDbType As String = ""
        Dim strDbTypeValue As String = ""
        Dim strDataSource As String = txtDataSource.Text.ToString().Trim()
        Dim strUserID As String = txtUserID.Text.ToString().Trim()
        Dim strPassword As String = txtPassword.Text.ToString().Trim()
        Dim strPort As String = txtPort.Text.ToString().Trim()
        Dim strDbname As String = txtDatabasename.Text.ToString().Trim()

        clsDataAcc3.G_DBIPServer3 = strDataSource
        clsDataAcc3.G_DBPortServer3 = strPort
        clsDataAcc3.G_DBUserName3 = strUserID
        clsDataAcc3.G_DBPassword3 = strPassword
        clsDataAcc3.G_DBName3 = strDbname
        If clsDataAcc3.Lc_DataAcc3.getDB_Conn_db3() = False Then
            XtraMessageBox.Show("ไม่สามารถทำการเชื่อมต่อ database ได้", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            clsDataAcc3.G_DBIPServer3 = strDataSource
            clsDataAcc3.G_DBPortServer3 = strPort
            clsDataAcc3.G_DBUserName3 = strUserID
            clsDataAcc3.G_DBPassword3 = strPassword
            clsDataAcc3.G_DBName3 = strDbname
            Exit Sub
        Else
            XtraMessageBox.Show("ทำการเชื่อมต่อ database ได้", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If txtDataSource.Text = "" Then
            clsbusent.Lc_BusinessEntity.Delete_table("l_config_mypcu_pro", " WHERE ROWID = '01'")
            Exit Sub
        End If


        Try
            Dim strDbType As String = ""
            Dim strDbTypeValue As String = ""

            Dim strDataSource As String = txtDataSource.Text.ToString().Trim()
            Dim strUserID As String = txtUserID.Text.ToString().Trim()
            Dim strPassword As String = txtPassword.Text.ToString().Trim()
            Dim strPort As String = txtPort.Text.ToString().Trim()
            Dim strDbname As String = txtDatabasename.Text.ToString().Trim()

            clsDataAcc3.G_DBIPServer3 = strDataSource
            clsDataAcc3.G_DBPortServer3 = strPort
            clsDataAcc3.G_DBUserName3 = strUserID
            clsDataAcc3.G_DBPassword3 = strPassword
            clsDataAcc3.G_DBName3 = strDbname



            Dim ds As DataSet
            ds = clsdataBus.Lc_Business.SELECT_TABLE("ROWID", "l_config_mypcu_pro", " WHERE ROWID = '01' ")
            If ds.Tables(0).Rows.Count > 0 Then
                clsbusent.Lc_BusinessEntity.Updatem_table("l_config_mypcu_pro", "HOST = '" & strDataSource & "' ,DATABASENAME = '" & strDbname & "',PORT = '" & strPort & "',USERNAME =  '" & strUserID & "',PASSWORD =  '" & strPassword & "'", " ROWID = '01' ")

            Else
                clsbusent.Lc_BusinessEntity.Insertm_table("l_config_mypcu_pro(ROWID,HOST,DATABASENAME,PORT,USERNAME,PASSWORD)", "'01','" & strDataSource & "','" & strDbname & "','" & strPort & "','" & strUserID & "','" & strPassword & "'")
            End If

            XtraMessageBox.Show("ทำการบันทึกการเชื่อมต่อฐานข้อมูล MyData เรียบร้อยแล้ว", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
            clsDataAcc3.G_DBIPServer3 = txtDataSource.Text
            clsDataAcc3.G_DBPortServer3 = txtPort.Text
            clsDataAcc3.G_DBUserName3 = txtUserID.Text
            clsDataAcc3.G_DBPassword3 = txtPassword.Text
            clsDataAcc3.G_DBName3 = txtDatabasename.Text
            If clsDataAcc3.Lc_DataAcc3.getDB_Conn_db3() = False Then
                MessageBox.Show("ไม่สามารถทำการเชื่อมต่อ database ได้", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                clsDataAcc3.G_DBIPServer3 = strDataSource
                clsDataAcc3.G_DBPortServer3 = strPort
                clsDataAcc3.G_DBUserName3 = strUserID
                clsDataAcc3.G_DBPassword3 = strPassword
                clsDataAcc3.G_DBName3 = strDbname

                Exit Sub
            Else
                XtraMessageBox.Show("ทำการเชื่อมต่อ database ", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message.ToString())
        End Try
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
End Class