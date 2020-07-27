Imports clsdataAcc6 = MyPCU.ClsDataAccess6
Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.Data.OleDb
Imports System.DateTime
Imports System.Globalization
Public Class ClsBusiness6
    Public Shared Lc_Business6 As New ClsBusiness6
    Public Shared Lc_DataAdp6 As Object
    Public Shared Lc_CommandBuilder6 As Object
    Private Lc_SQL6 As String = Nothing
    Private Lc_sb6 As StringBuilder = Nothing
    Private Lc_Errmsg6 As String = Nothing
    Private Function GetDataAdp6(ByVal SqlStr As String, ByVal TbName As String, Optional ByRef ds As DataSet = Nothing) As DataSet
        ds = New DataSet
        Dim SqlStr3 As String = ""
        SqlStr3 = "SET TRANSACTION ISOLATION LEVEL READ COMMITTED;  SET binlog_format = MIXED;" & SqlStr

        Try

            If clsdataAcc6.Lc_DataAcc6.getDB_Conn_db6() <> True Then 'เช็คการติดต่อฐานข้อมูลว่าติดต่อได้หรือไม่ True = ติดต่อได้ False = ติดต่อไม่ได้
                ds = Nothing
                Lc_Errmsg6 = "not connected"
            Else

                Dim Adp_My As New MySqlDataAdapter(SqlStr, clsdataAcc6.G_ConnMDB_MySql6)  'ดึงข้อมูลผ่าน OleDbDataAdapter
                Lc_DataAdp6 = Adp_My
                Adp_My.Fill(ds, TbName) 'กำหนด ค่าให้กับ Dataset และกำหนดชื่อ Table
                Lc_CommandBuilder6 = New MySqlCommandBuilder(Lc_DataAdp6)
                Lc_Errmsg6 = "connected"
            End If '-2147217866 

        Catch ex As OleDbException
            If ex.ErrorCode = -2147217866 Then Throw ex
        Catch ex As MySqlException
            If ex.ErrorCode = -2147467269 Then Throw ex
        Catch ex As Exception
            ds = Nothing
            Lc_Errmsg6 = ex.Message
        End Try
        Return ds
    End Function
    Public Function SELECT_TABLE(ByVal strField As String, ByVal strTable As String, ByVal strWhere As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb6 = New StringBuilder

        Try
            Lc_sb6.Remove(0, Lc_sb6.Length())
            Lc_sb6.Append("SELECT " & strField & " FROM " & strTable & " " & strWhere & " ;")
            Lc_SQL6 = Lc_sb6.ToString
            ds = GetDataAdp6(Lc_SQL6, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SelectAll(ByVal tableName As String) As DataSet
        Dim ds As DataSet = Nothing
        Try
            Lc_sb6 = New StringBuilder
            Lc_sb6.Append("Select * From " & tableName)
            Lc_SQL6 = Lc_sb6.ToString
            ds = GetDataAdp6(Lc_SQL6, tableName, ds)
        Catch ex As Exception

        End Try
        Return ds
    End Function
    Public Function SELECT_NAME_USERID(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim NAMEUSERID As String = ""
        Lc_sb6 = New StringBuilder
        Try
            Lc_sb6.Remove(0, Lc_sb6.Length())
            Lc_sb6.Append("SELECT CONCAT(PRENAME_DESC,FNAME,' ',LNAME) AS NAMEUSERID FROM l_user A JOIN l_prename B ON(A.PRENAME = B.PRENAME_CODE) WHERE USER_ID = '" & strString & "' ")
            Lc_SQL6 = Lc_sb6.ToString
            ds = GetDataAdp6(Lc_SQL6, "Table1", ds)
            NAMEUSERID = ds.Tables(0).Rows(0).Item("NAMEUSERID").ToString
        Catch ex As Exception

        End Try

        Return NAMEUSERID
    End Function
End Class

