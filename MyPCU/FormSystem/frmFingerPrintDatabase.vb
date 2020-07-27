Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports clsDataAcc6 = MyPCU.ClsDataAccess6
Imports DevExpress.XtraEditors
Public Class frmFingerPrintDatabase

    Private Sub frmFingerPrintDatabase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("*", "l_config_mypcu_pro", " WHERE ROWID = '09' ")
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

        clsDataAcc6.G_DBIPServer6 = strDataSource
        clsDataAcc6.G_DBPortServer6 = strPort
        clsDataAcc6.G_DBUserName6 = strUserID
        clsDataAcc6.G_DBPassword6 = strPassword
        clsDataAcc6.G_DBName6 = strDbname
        If clsDataAcc6.Lc_DataAcc6.getDB_Conn_db6() = False Then
            XtraMessageBox.Show("ไม่สามารถทำการเชื่อมต่อ database ได้", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            clsDataAcc6.G_DBIPServer6 = strDataSource
            clsDataAcc6.G_DBPortServer6 = strPort
            clsDataAcc6.G_DBUserName6 = strUserID
            clsDataAcc6.G_DBPassword6 = strPassword
            clsDataAcc6.G_DBName6 = strDbname
            Exit Sub
        Else
            XtraMessageBox.Show("ทำการเชื่อมต่อ database ได้", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Try
            Dim strDbType As String = ""
            Dim strDbTypeValue As String = ""

            Dim strDataSource As String = txtDataSource.Text.ToString().Trim()
            Dim strUserID As String = txtUserID.Text.ToString().Trim()
            Dim strPassword As String = txtPassword.Text.ToString().Trim()
            Dim strPort As String = txtPort.Text.ToString().Trim()
            Dim strDbname As String = txtDatabasename.Text.ToString().Trim()

            clsDataAcc6.G_DBIPServer6 = strDataSource
            clsDataAcc6.G_DBPortServer6 = strPort
            clsDataAcc6.G_DBUserName6 = strUserID
            clsDataAcc6.G_DBPassword6 = strPassword
            clsDataAcc6.G_DBName6 = strDbname

            Dim ds As DataSet
            ds = clsdataBus.Lc_Business.SELECT_TABLE("ROWID", "l_config_mypcu_pro", " WHERE ROWID = '09' ")
            If ds.Tables(0).Rows.Count > 0 Then
                clsbusent.Lc_BusinessEntity.Updatem_table("l_config_mypcu_pro", "HOST = '" & strDataSource & "' ,DATABASENAME = '" & strDbname & "',PORT = '" & strPort & "',USERNAME =  '" & strUserID & "',PASSWORD =  '" & strPassword & "'", " ROWID = '09' ")

            Else
                clsbusent.Lc_BusinessEntity.Insertm_table("l_config_mypcu_pro(ROWID,HOST,DATABASENAME,PORT,USERNAME,PASSWORD)", "'09','" & strDataSource & "','" & strDbname & "','" & strPort & "','" & strUserID & "','" & strPassword & "'")
            End If

            XtraMessageBox.Show("ทำการบันทึกการเชื่อมต่อฐานข้อมูลลายนิ้วมือ เรียบร้อยแล้ว", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
            clsDataAcc6.G_DBIPServer6 = txtDataSource.Text
            clsDataAcc6.G_DBPortServer6 = txtPort.Text
            clsDataAcc6.G_DBUserName6 = txtUserID.Text
            clsDataAcc6.G_DBPassword6 = txtPassword.Text
            clsDataAcc6.G_DBName6 = txtDatabasename.Text
            If clsDataAcc6.Lc_DataAcc6.getDB_Conn_db6() = False Then
                MessageBox.Show("ไม่สามารถทำการเชื่อมต่อ database ได้", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                clsDataAcc6.G_DBIPServer6 = strDataSource
                clsDataAcc6.G_DBPortServer6 = strPort
                clsDataAcc6.G_DBUserName6 = strUserID
                clsDataAcc6.G_DBPassword6 = strPassword
                clsDataAcc6.G_DBName6 = strDbname

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