Imports clsdataAcc5 = MyPCU.ClsDataAccess5
Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.Data.OleDb
Public Class ClsBusiness5
    Public Shared Lc_Business5 As New ClsBusiness5
    Public Shared Lc_DataAdp5 As Object
    Public Shared Lc_CommandBuilder5 As Object
    Private Lc_SQL5 As String = Nothing
    Private Lc_sb5 As StringBuilder = Nothing
    Private Lc_Errmsg5 As String = Nothing

    Private Function GetDataAdp5(ByVal SqlStr As String, ByVal TbName As String, Optional ByRef ds As DataSet = Nothing) As DataSet
        ds = New DataSet
        Dim SqlStr5 As String = ""
        SqlStr5 = "SET TRANSACTION ISOLATION LEVEL READ COMMITTED;  SET binlog_format = MIXED;" & SqlStr

        Try

            If clsdataAcc5.Lc_DataAcc5.getDB_Conn_db5() <> True Then 'เช็คการติดต่อฐานข้อมูลว่าติดต่อได้หรือไม่ True = ติดต่อได้ False = ติดต่อไม่ได้
                ds = Nothing
                Lc_Errmsg5 = "not connected"
            Else

                Dim Adp_My As New MySqlDataAdapter(SqlStr5, clsdataAcc5.G_ConnMDB_MySql5)  'ดึงข้อมูลผ่าน OleDbDataAdapter
                Lc_DataAdp5 = Adp_My
                Adp_My.Fill(ds, TbName) 'กำหนด ค่าให้กับ Dataset และกำหนดชื่อ Table
                Lc_CommandBuilder5 = New MySqlCommandBuilder(Lc_DataAdp5)
                Lc_Errmsg5 = "connected"
            End If '-2147217865 

        Catch ex As OleDbException
            If ex.ErrorCode = -2147217865 Then Throw ex
        Catch ex As MySqlException
            If ex.ErrorCode = -2147467259 Then Throw ex
        Catch ex As Exception
            ds = Nothing
            Lc_Errmsg5 = ex.Message
        End Try
        Return ds
    End Function
    Public Function SELECT_TABLE(ByVal strField As String, ByVal strTable As String, ByVal strWhere As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb5 = New StringBuilder

        Try
            Lc_sb5.Remove(0, Lc_sb5.Length())
            Lc_sb5.Append("SELECT " & strField & " FROM " & strTable & " " & strWhere & "")
            Lc_SQL5 = Lc_sb5.ToString
            ds = GetDataAdp5(Lc_SQL5, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SHOW_TABLE(ByVal strTable As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb5 = New StringBuilder

        Try
            Lc_sb5.Remove(0, Lc_sb5.Length())
            Lc_sb5.Append("SHOW TABLES " & strTable & "")
            Lc_SQL5 = Lc_sb5.ToString
            ds = GetDataAdp5(Lc_SQL5, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SHOW_TABLE_COLUMN(ByVal strTable As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb5 = New StringBuilder

        Try
            Lc_sb5.Remove(0, Lc_sb5.Length())
            Lc_sb5.Append("SHOW COLUMNS FROM " & strTable & "")
            Lc_SQL5 = Lc_sb5.ToString
            ds = GetDataAdp5(Lc_SQL5, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function countm_upload(ByVal strType As String, ByVal tmpFilename As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb5 = New StringBuilder
        Try
            'สำหรับ MySql
            Lc_sb5.Remove(0, Lc_sb5.Length())
            Lc_sb5.Append("SELECT COUNT(*) AS C_AMOUNT ")
            Lc_sb5.Append(" FROM " & strType & " WHERE FILE_ID = '" & tmpFilename & "'")
            Lc_SQL5 = Lc_sb5.ToString
            ds = GetDataAdp5(Lc_SQL5, "Table1", ds)

        Catch ex As Exception
        Finally
        End Try
        Return ds
    End Function
    Public Function MySQL_Sysdate() As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb5 = New StringBuilder
        Try
            'สำหรับ MySql
            Lc_sb5.Remove(0, Lc_sb5.Length())
            Lc_sb5.Append("SELECT DATE_FORMAT(SYSDATE(),'%Y%m%d%H%i%s') AS DATENOW ")
            Lc_SQL5 = Lc_sb5.ToString
            ds = GetDataAdp5(Lc_SQL5, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("DATENOW")
        Catch ex As Exception
        Finally
        End Try
        Return strNAME
    End Function
End Class
