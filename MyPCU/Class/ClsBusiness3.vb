Imports clsdataAcc3 = MyPCU.ClsDataAccess3
Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.Data.OleDb
Public Class ClsBusiness3
    Public Shared Lc_Business3 As New ClsBusiness3
    Public Shared Lc_DataAdp3 As Object
    Public Shared Lc_CommandBuilder3 As Object
    Private Lc_SQL3 As String = Nothing
    Private Lc_sb3 As StringBuilder = Nothing
    Private Lc_Errmsg3 As String = Nothing

    Private Function GetDataAdp3(ByVal SqlStr As String, ByVal TbName As String, Optional ByRef ds As DataSet = Nothing) As DataSet
        ds = New DataSet
        Dim SqlStr3 As String = ""
        SqlStr3 = "SET TRANSACTION ISOLATION LEVEL READ COMMITTED;  " & SqlStr

        Try

            If clsdataAcc3.Lc_DataAcc3.getDB_Conn_db3() <> True Then 'เช็คการติดต่อฐานข้อมูลว่าติดต่อได้หรือไม่ True = ติดต่อได้ False = ติดต่อไม่ได้
                ds = Nothing
                Lc_Errmsg3 = "not connected"
            Else

                Dim Adp_My As New MySqlDataAdapter(SqlStr3, clsdataAcc3.G_ConnMDB_MySql3)  'ดึงข้อมูลผ่าน OleDbDataAdapter
                Lc_DataAdp3 = Adp_My
                Adp_My.Fill(ds, TbName) 'กำหนด ค่าให้กับ Dataset และกำหนดชื่อ Table
                Lc_CommandBuilder3 = New MySqlCommandBuilder(Lc_DataAdp3)
                Lc_Errmsg3 = "connected"
            End If '-2147217865 

        Catch ex As OleDbException
            If ex.ErrorCode = -2147217865 Then Throw ex
        Catch ex As MySqlException
            If ex.ErrorCode = -2147467259 Then Throw ex
        Catch ex As Exception
            ds = Nothing
            Lc_Errmsg3 = ex.Message
        End Try
        Return ds
    End Function
    Public Function SELECT_TABLE(ByVal strField As String, ByVal strTable As String, ByVal strWhere As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb3 = New StringBuilder

        Try
            Lc_sb3.Remove(0, Lc_sb3.Length())
            Lc_sb3.Append("SELECT " & strField & " FROM " & strTable & " " & strWhere & " ;")
            Lc_SQL3 = Lc_sb3.ToString
            ds = GetDataAdp3(Lc_SQL3, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SHOW_DAY() As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb3 = New StringBuilder

        Try
            Lc_sb3.Remove(0, Lc_sb3.Length())
            Lc_sb3.Append("SELECT DAYOFWEEK(NOW()) AS DOW")
            Lc_SQL3 = Lc_sb3.ToString
            ds = GetDataAdp3(Lc_SQL3, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SHOW_TABLE(ByVal strTable As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb3 = New StringBuilder

        Try
            Lc_sb3.Remove(0, Lc_sb3.Length())
            Lc_sb3.Append("SHOW TABLES " & strTable & "")
            Lc_SQL3 = Lc_sb3.ToString
            ds = GetDataAdp3(Lc_SQL3, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SHOW_TABLE_COLUMN(ByVal strTable As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb3 = New StringBuilder

        Try
            Lc_sb3.Remove(0, Lc_sb3.Length())
            Lc_sb3.Append("SHOW COLUMNS FROM " & strTable & "")
            Lc_SQL3 = Lc_sb3.ToString
            ds = GetDataAdp3(Lc_SQL3, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function countm_upload(ByVal strType As String, ByVal tmpFilename As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb3 = New StringBuilder
        Try
            'สำหรับ MySql
            Lc_sb3.Remove(0, Lc_sb3.Length())
            Lc_sb3.Append("SELECT COUNT(*) AS C_AMOUNT ")
            Lc_sb3.Append(" FROM " & strType & " WHERE FILE_ID = '" & tmpFilename & "'")
            Lc_SQL3 = Lc_sb3.ToString
            ds = GetDataAdp3(Lc_SQL3, "Table1", ds)

        Catch ex As Exception
        Finally
        End Try
        Return ds
    End Function
    Public Function MySQL_Sysdate() As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb3 = New StringBuilder
        Try
            'สำหรับ MySql
            Lc_sb3.Remove(0, Lc_sb3.Length())
            Lc_sb3.Append("SELECT SYSDATE() AS DATENOW ")
            Lc_SQL3 = Lc_sb3.ToString
            ds = GetDataAdp3(Lc_SQL3, "Table1", ds)
            strNAME = CDate(ds.Tables(0).Rows(0).Item("DATENOW")).AddYears(-543).ToString("yyyyMMddHHmmss")
        Catch ex As Exception
        Finally
        End Try
        Return strNAME
    End Function
End Class
