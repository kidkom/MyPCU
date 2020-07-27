Imports clsdataAcc2 = MyPCU.ClsDataAccess2
Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.Data.OleDb
Public Class ClsBusiness2
    Public Shared Lc_Business2 As New ClsBusiness2
    Public Shared Lc_DataAdp2 As Object
    Public Shared Lc_CommandBuilder2 As Object
    Private Lc_SQL2 As String = Nothing
    Private Lc_sb2 As StringBuilder = Nothing
    Private Lc_Errmsg2 As String = Nothing

    Private Function GetDataAdp2(ByVal SqlStr As String, ByVal TbName As String, Optional ByRef ds As DataSet = Nothing) As DataSet
        ds = New DataSet
        Dim SqlStr2 As String = ""
        If vImport43 = "1" Then
            SqlStr2 = "SET TRANSACTION ISOLATION LEVEL READ COMMITTED;  " & SqlStr
        Else
            SqlStr2 = "SET TRANSACTION ISOLATION LEVEL READ COMMITTED;  SET binlog_format = MIXED;" & SqlStr
        End If

        Try

            If clsdataAcc2.Lc_DataAcc2.getDB_Conn_db2() <> True Then 'เช็คการติดต่อฐานข้อมูลว่าติดต่อได้หรือไม่ True = ติดต่อได้ False = ติดต่อไม่ได้
                ds = Nothing
                Lc_Errmsg2 = "not connected"
            Else

                Dim Adp_My As New MySqlDataAdapter(SqlStr2, clsdataAcc2.G_ConnMDB_MySql2)  'ดึงข้อมูลผ่าน OleDbDataAdapter
                Lc_DataAdp2 = Adp_My
                Adp_My.Fill(ds, TbName) 'กำหนด ค่าให้กับ Dataset และกำหนดชื่อ Table
                Lc_CommandBuilder2 = New MySqlCommandBuilder(Lc_DataAdp2)
                Lc_Errmsg2 = "connected"
            End If '-2147217865 

        Catch ex As OleDbException
            If ex.ErrorCode = -2147217865 Then Throw ex
        Catch ex As MySqlException
            If ex.ErrorCode = -2147467259 Then Throw ex
        Catch ex As Exception
            ds = Nothing
            Lc_Errmsg2 = ex.Message
        End Try
        Return ds
    End Function
    Public Function SELECT_TABLE_db2(ByVal strField As String, ByVal strTable As String, ByVal strWhere As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb2 = New StringBuilder

        Try
            Lc_sb2.Remove(0, Lc_sb2.Length())
            Lc_sb2.Append("SELECT " & strField & " FROM " & strTable & " " & strWhere & "")
            Lc_SQL2 = Lc_sb2.ToString
            ds = GetDataAdp2(Lc_SQL2, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SHOW_TABLE(ByVal strTable As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb2 = New StringBuilder

        Try
            Lc_sb2.Remove(0, Lc_sb2.Length())
            Lc_sb2.Append("SHOW TABLES " & strTable & "")
            Lc_SQL2 = Lc_sb2.ToString
            ds = GetDataAdp2(Lc_SQL2, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SHOW_TABLE_COLUMN(ByVal strTable As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb2 = New StringBuilder

        Try
            Lc_sb2.Remove(0, Lc_sb2.Length())
            Lc_sb2.Append("SHOW COLUMNS FROM " & strTable & "")
            Lc_SQL2 = Lc_sb2.ToString
            ds = GetDataAdp2(Lc_SQL2, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SELECT_SQL(ByVal strField As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb2 = New StringBuilder

        Try
            Lc_sb2.Remove(0, Lc_sb2.Length())
            Lc_sb2.Append(strField)
            Lc_SQL2 = Lc_sb2.ToString
            ds = GetDataAdp2(Lc_SQL2, "Table1", ds)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

        Return ds
    End Function
    Public Function SELECT_TABLE(ByVal strField As String, ByVal strTable As String, ByVal strWhere As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb2 = New StringBuilder

        Try
            Lc_sb2.Remove(0, Lc_sb2.Length())
            Lc_sb2.Append("SELECT " & strField & " FROM " & strTable & " " & strWhere & "")
            Lc_SQL2 = Lc_sb2.ToString
            ds = GetDataAdp2(Lc_SQL2, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
End Class
