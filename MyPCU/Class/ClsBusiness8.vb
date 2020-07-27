Imports clsdataAcc8 = MyPCU.ClsDataAccess8
Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.Data.OleDb
Imports System.DateTime
Imports System.Globalization
Public Class ClsBusiness8
    Public Shared Lc_Business8 As New ClsBusiness8
    Public Shared Lc_DataAdp8 As Object
    Public Shared Lc_CommandBuilder8 As Object
    Private Lc_SQL8 As String = Nothing
    Private Lc_sb8 As StringBuilder = Nothing
    Private Lc_Errmsg8 As String = Nothing
    Private Function GetDataAdp8(ByVal SqlStr As String, ByVal TbName As String, Optional ByRef ds As DataSet = Nothing) As DataSet
        ds = New DataSet
        Dim SqlStr3 As String = ""
        SqlStr3 = "SET TRANSACTION ISOLATION LEVEL READ COMMITTED;  SET binlog_format = MIXED;" & SqlStr

        Try

            If clsdataAcc8.Lc_DataAcc8.getDB_Conn_db8() <> True Then 'เช็คการติดต่อฐานข้อมูลว่าติดต่อได้หรือไม่ True = ติดต่อได้ False = ติดต่อไม่ได้
                ds = Nothing
                Lc_Errmsg8 = "not connected"
            Else

                Dim Adp_My As New MySqlDataAdapter(SqlStr, clsdataAcc8.G_ConnMDB_MySql8)  'ดึงข้อมูลผ่าน OleDbDataAdapter
                Lc_DataAdp8 = Adp_My
                Adp_My.Fill(ds, TbName) 'กำหนด ค่าให้กับ Dataset และกำหนดชื่อ Table
                Lc_CommandBuilder8 = New MySqlCommandBuilder(Lc_DataAdp8)
                Lc_Errmsg8 = "connected"
            End If '-2147217877 

        Catch ex As OleDbException
            If ex.ErrorCode = -2147217877 Then Throw ex
        Catch ex As MySqlException
            If ex.ErrorCode = -2147477279 Then Throw ex
        Catch ex As Exception
            ds = Nothing
            Lc_Errmsg8 = ex.Message
        End Try
        Return ds
    End Function
    Public Function SELECT_TABLE(ByVal strField As String, ByVal strTable As String, ByVal strWhere As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb8 = New StringBuilder

        Try
            Lc_sb8.Remove(0, Lc_sb8.Length())
            Lc_sb8.Append("SELECT " & strField & " FROM " & strTable & " " & strWhere & " ;")
            Lc_SQL8 = Lc_sb8.ToString
            ds = GetDataAdp8(Lc_SQL8, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SelectAll(ByVal tableName As String) As DataSet
        Dim ds As DataSet = Nothing
        Try
            Lc_sb8 = New StringBuilder
            Lc_sb8.Append("Select * From " & tableName)
            Lc_SQL8 = Lc_sb8.ToString
            ds = GetDataAdp8(Lc_SQL8, tableName, ds)
        Catch ex As Exception

        End Try
        Return ds
    End Function
    Public Function SELECT_NAME_USERID(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim NAMEUSERID As String = ""
        Lc_sb8 = New StringBuilder
        Try
            Lc_sb8.Remove(0, Lc_sb8.Length())
            Lc_sb8.Append("SELECT CONCAT(PRENAME_DESC,FNAME,' ',LNAME) AS NAMEUSERID FROM l_user A JOIN l_prename B ON(A.PRENAME = B.PRENAME_CODE) WHERE USER_ID = '" & strString & "' ")
            Lc_SQL8 = Lc_sb8.ToString
            ds = GetDataAdp8(Lc_SQL8, "Table1", ds)
            NAMEUSERID = ds.Tables(0).Rows(0).Item("NAMEUSERID").ToString
        Catch ex As Exception

        End Try

        Return NAMEUSERID
    End Function
    Public Function SELECT_AGEUSED(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb8 = New StringBuilder
        Try
            Lc_sb8.Remove(0, Lc_sb8.Length())
            Lc_sb8.Append("SELECT AGEUSED FROM l_assets_type WHERE ASSETCODE = '" & strString & "' ")
            Lc_SQL8 = Lc_sb8.ToString
            ds = GetDataAdp8(Lc_SQL8, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("AGEUSED").ToString
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_BUDGET(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb8 = New StringBuilder
        Try
            Lc_sb8.Remove(0, Lc_sb8.Length())
            Lc_sb8.Append("SELECT RECIEVENAME FROM l_recieve WHERE RECIEVECODE = '" & strString & "'   ")
            Lc_SQL8 = Lc_sb8.ToString
            ds = GetDataAdp8(Lc_SQL8, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("RECIEVENAME").ToString
        Catch ex As Exception

        End Try

        Return strNAME

    End Function
End Class

