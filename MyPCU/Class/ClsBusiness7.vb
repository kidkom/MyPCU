Imports clsdataAcc7 = MyPCU.ClsDataAccess7
Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.Data.OleDb
Imports System.DateTime
Imports System.Globalization
Public Class ClsBusiness7
    Public Shared Lc_Business7 As New ClsBusiness7
    Public Shared Lc_DataAdp7 As Object
    Public Shared Lc_CommandBuilder7 As Object
    Private Lc_SQL7 As String = Nothing
    Private Lc_sb7 As StringBuilder = Nothing
    Private Lc_Errmsg7 As String = Nothing
    Private Function GetDataAdp7(ByVal SqlStr As String, ByVal TbName As String, Optional ByRef ds As DataSet = Nothing) As DataSet
        ds = New DataSet
        Dim SqlStr3 As String = ""
        SqlStr3 = "SET TRANSACTION ISOLATION LEVEL READ COMMITTED;  SET binlog_format = MIXED;" & SqlStr

        Try

            If clsdataAcc7.Lc_DataAcc7.getDB_Conn_db7() <> True Then 'เช็คการติดต่อฐานข้อมูลว่าติดต่อได้หรือไม่ True = ติดต่อได้ False = ติดต่อไม่ได้
                ds = Nothing
                Lc_Errmsg7 = "not connected"
            Else

                Dim Adp_My As New MySqlDataAdapter(SqlStr, clsdataAcc7.G_ConnMDB_MySql7)  'ดึงข้อมูลผ่าน OleDbDataAdapter
                Lc_DataAdp7 = Adp_My
                Adp_My.Fill(ds, TbName) 'กำหนด ค่าให้กับ Dataset และกำหนดชื่อ Table
                Lc_CommandBuilder7 = New MySqlCommandBuilder(Lc_DataAdp7)
                Lc_Errmsg7 = "connected"
            End If '-2147217877 

        Catch ex As OleDbException
            If ex.ErrorCode = -2147217877 Then Throw ex
        Catch ex As MySqlException
            If ex.ErrorCode = -2147477279 Then Throw ex
        Catch ex As Exception
            ds = Nothing
            Lc_Errmsg7 = ex.Message
        End Try
        Return ds
    End Function
    Public Function SELECT_TABLE(ByVal strField As String, ByVal strTable As String, ByVal strWhere As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb7 = New StringBuilder

        Try
            Lc_sb7.Remove(0, Lc_sb7.Length())
            Lc_sb7.Append("SELECT " & strField & " FROM " & strTable & " " & strWhere & " ;")
            Lc_SQL7 = Lc_sb7.ToString
            ds = GetDataAdp7(Lc_SQL7, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SelectAll(ByVal tableName As String) As DataSet
        Dim ds As DataSet = Nothing
        Try
            Lc_sb7 = New StringBuilder
            Lc_sb7.Append("Select * From " & tableName)
            Lc_SQL7 = Lc_sb7.ToString
            ds = GetDataAdp7(Lc_SQL7, tableName, ds)
        Catch ex As Exception

        End Try
        Return ds
    End Function
    Public Function SELECT_NAME_USERID(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim NAMEUSERID As String = ""
        Lc_sb7 = New StringBuilder
        Try
            Lc_sb7.Remove(0, Lc_sb7.Length())
            Lc_sb7.Append("SELECT CONCAT(PRENAME_DESC,FNAME,' ',LNAME) AS NAMEUSERID FROM l_user A JOIN l_prename B ON(A.PRENAME = B.PRENAME_CODE) WHERE USER_ID = '" & strString & "' ")
            Lc_SQL7 = Lc_sb7.ToString
            ds = GetDataAdp7(Lc_SQL7, "Table1", ds)
            NAMEUSERID = ds.Tables(0).Rows(0).Item("NAMEUSERID").ToString
        Catch ex As Exception

        End Try

        Return NAMEUSERID
    End Function
End Class

