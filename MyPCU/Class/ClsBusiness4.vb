Imports clsdataAcc4 = MyPCU.ClsDataAccess4
Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.Data.OleDb
Public Class ClsBusiness4
    Public Shared Lc_Business4 As New ClsBusiness4
    Public Shared Lc_DataAdp4 As Object
    Public Shared Lc_CommandBuilder4 As Object
    Private Lc_SQL4 As String = Nothing
    Private Lc_sb4 As StringBuilder = Nothing
    Private Lc_Errmsg4 As String = Nothing

    Private Function GetDataAdp4(ByVal SqlStr As String, ByVal TbName As String, Optional ByRef ds As DataSet = Nothing) As DataSet
        ds = New DataSet
        Dim SqlStr4 As String = ""
        SqlStr4 = "SET TRANSACTION ISOLATION LEVEL READ COMMITTED;  SET binlog_format = MIXED;" & SqlStr

        Try

            If clsdataAcc4.Lc_DataAcc4.getDB_Conn_db4() <> True Then 'เช็คการติดต่อฐานข้อมูลว่าติดต่อได้หรือไม่ True = ติดต่อได้ False = ติดต่อไม่ได้
                ds = Nothing
                Lc_Errmsg4 = "not connected"
            Else

                Dim Adp_My As New MySqlDataAdapter(SqlStr4, clsdataAcc4.G_ConnMDB_MySql4)  'ดึงข้อมูลผ่าน OleDbDataAdapter
                Lc_DataAdp4 = Adp_My
                Adp_My.Fill(ds, TbName) 'กำหนด ค่าให้กับ Dataset และกำหนดชื่อ Table
                Lc_CommandBuilder4 = New MySqlCommandBuilder(Lc_DataAdp4)
                Lc_Errmsg4 = "connected"
            End If '-2147217865 

        Catch ex As OleDbException
            If ex.ErrorCode = -2147217865 Then Throw ex
        Catch ex As MySqlException
            If ex.ErrorCode = -2147467259 Then Throw ex
        Catch ex As Exception
            ds = Nothing
            Lc_Errmsg4 = ex.Message
        End Try
        Return ds
    End Function
    Public Function SELECT_TABLE(ByVal strField As String, ByVal strTable As String, ByVal strWhere As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb4 = New StringBuilder

        Try
            Lc_sb4.Remove(0, Lc_sb4.Length())
            Lc_sb4.Append("SELECT " & strField & " FROM " & strTable & " " & strWhere & "")
            Lc_SQL4 = Lc_sb4.ToString
            ds = GetDataAdp4(Lc_SQL4, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SHOW_TABLE(ByVal strTable As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb4 = New StringBuilder

        Try
            Lc_sb4.Remove(0, Lc_sb4.Length())
            Lc_sb4.Append("SHOW TABLES " & strTable & "")
            Lc_SQL4 = Lc_sb4.ToString
            ds = GetDataAdp4(Lc_SQL4, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SHOW_TABLE_COLUMN(ByVal strTable As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb4 = New StringBuilder

        Try
            Lc_sb4.Remove(0, Lc_sb4.Length())
            Lc_sb4.Append("SHOW COLUMNS FROM " & strTable & "")
            Lc_SQL4 = Lc_sb4.ToString
            ds = GetDataAdp4(Lc_SQL4, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function countm_upload(ByVal strType As String, ByVal tmpFilename As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb4 = New StringBuilder
        Try
            'สำหรับ MySql
            Lc_sb4.Remove(0, Lc_sb4.Length())
            Lc_sb4.Append("SELECT COUNT(*) AS C_AMOUNT ")
            Lc_sb4.Append(" FROM " & strType & " WHERE FILE_ID = '" & tmpFilename & "'")
            Lc_SQL4 = Lc_sb4.ToString
            ds = GetDataAdp4(Lc_SQL4, "Table1", ds)

        Catch ex As Exception
        Finally
        End Try
        Return ds
    End Function
End Class
