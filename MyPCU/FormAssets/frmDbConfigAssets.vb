Imports clsDataAcc8 = MyPCU.ClsDataAccess8
Imports clsdataBus = MyPCU.ClsBusiness
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports DevExpress.XtraEditors
Public Class frmDbConfigAssets

    Private Sub frmDbConfigAssets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("*", "l_config_mypcu_pro", " WHERE ROWID = '08' ")
        If ds.Tables(0).Rows.Count > 0 Then
            txtDataSource.Text = ds.Tables(0).Rows(0).Item("HOST").ToString
            txtUserID.Text = ds.Tables(0).Rows(0).Item("USERNAME").ToString
            txtPassword.Text = ds.Tables(0).Rows(0).Item("PASSWORD").ToString
            txtPort.Text = ds.Tables(0).Rows(0).Item("PORT").ToString
            txtDatabasename.Text = ds.Tables(0).Rows(0).Item("DATABASENAME").ToString
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

        clsDataAcc8.G_DBIPServer8 = strDataSource
        clsDataAcc8.G_DBPortServer8 = strPort
        clsDataAcc8.G_DBUserName8 = strUserID
        clsDataAcc8.G_DBPassword8 = strPassword
        clsDataAcc8.G_DBName8 = strDbname
        If clsDataAcc8.Lc_DataAcc8.getDB_Conn_db8() = False Then
            XtraMessageBox.Show("ไม่สามารถทำการเชื่อมต่อ database ได้", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            clsDataAcc8.G_DBIPServer8 = strDataSource
            clsDataAcc8.G_DBPortServer8 = strPort
            clsDataAcc8.G_DBUserName8 = strUserID
            clsDataAcc8.G_DBPassword8 = strPassword
            clsDataAcc8.G_DBName8 = strDbname
            Exit Sub
        Else
            XtraMessageBox.Show("ทำการเชื่อมต่อ database ได้", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If txtDataSource.Text = "" Then
            clsbusent.Lc_BusinessEntity.Delete_table("l_config_mypcu_pro", " WHERE ROWID = '08'")
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
            
            clsDataAcc8.G_DBIPServer8 = strDataSource
            clsDataAcc8.G_DBPortServer8 = strPort
            clsDataAcc8.G_DBUserName8 = strUserID
            clsDataAcc8.G_DBPassword8 = strPassword
            clsDataAcc8.G_DBName8 = strDbname



            Dim ds As DataSet
            ds = clsdataBus.Lc_Business.SELECT_TABLE("ROWID", "l_config_mypcu_pro", " WHERE ROWID = '08' ")
            If ds.Tables(0).Rows.Count > 0 Then
                clsbusent.Lc_BusinessEntity.Updatem_table("l_config_mypcu_pro", "HOST = '" & strDataSource & "' ,DATABASENAME = '" & strDbname & "',PORT = '" & strPort & "',USERNAME =  '" & strUserID & "',PASSWORD =  '" & strPassword & "'", " ROWID = '08' ")

            Else
                clsbusent.Lc_BusinessEntity.Insertm_table("l_config_mypcu_pro(ROWID,HOST,DATABASENAME,PORT,USERNAME,PASSWORD)", "'08','" & strDataSource & "','" & strDbname & "','" & strPort & "','" & strUserID & "','" & strPassword & "'")
            End If

            XtraMessageBox.Show("ทำการบันทึกการเชื่อมต่อฐานข้อมูลเรียบร้อยแล้ว", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
            clsDataAcc8.G_DBIPServer8 = txtDataSource.Text
            clsDataAcc8.G_DBPortServer8 = txtPort.Text
            clsDataAcc8.G_DBUserName8 = txtUserID.Text
            clsDataAcc8.G_DBPassword8 = txtPassword.Text
            clsDataAcc8.G_DBName8 = txtDatabasename.Text
            If clsDataAcc8.Lc_DataAcc8.getDB_Conn_db8() = False Then
                XtraMessageBox.Show("ไม่สามารถทำการเชื่อมต่อ database ได้", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                clsDataAcc8.G_DBIPServer8 = strDataSource
                clsDataAcc8.G_DBPortServer8 = strPort
                clsDataAcc8.G_DBUserName8 = strUserID
                clsDataAcc8.G_DBPassword8 = strPassword
                clsDataAcc8.G_DBName8 = strDbname

                Exit Sub
            Else
                XtraMessageBox.Show("ทำการเชื่อมต่อ database ", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message.ToString())
        End Try

    End Sub
End Class