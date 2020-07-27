Imports System.IO
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Configuration
Imports System.Data.Odbc
Imports MySql.Data.MySqlClient
Public Class ClsDataAccess8
    Public Shared G_DBUserName8 As String = ""
    Public Shared G_DBPassword8 As String = ""
    Public Shared G_DBPathName8 As String
    Public Shared G_DBName8 As String = ""
    Public Shared G_DBIPServer8 As String = ""
    Public Shared G_DBPortServer8 As String = ""
    Public Shared G_DBService_Name8 As String
    Public Shared G_DBSID3 As String


    '---ตัวแปร share class ให้กับ class ที่อื่นเรียกใช้ ----
    Public Shared Lc_DataAcc8 As New ClsDataAccess8

    '--- ตัวแปร Connectori สำหรับ Database ---
    Public Shared G_ConnMDB_MySql8 As MySqlConnection = New MySqlConnection


    Public Function getDB_Conn_db8() As Boolean
        Try
            Dim connStr8 As String = ""
            ' Connection Information
            'ติดต่อ MySQL
            'connStr3 = "Data Source=nhso8kkn.info;user id=kidkom.s;password=Piano@1238;port=3308;charset=tis820;"
            connStr8 = "Data Source=" & G_DBIPServer8 & ";user id=" & G_DBUserName8 & ";password=" & G_DBPassword8 & ";port=" & G_DBPortServer8 & ";"


            ' Open database connection
            With G_ConnMDB_MySql8           'ตั้งค่า Connection สำหรับ MySql
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = connStr8
                .Open()
                Dim LC_Comm As MySqlCommand
                LC_Comm = New MySqlCommand("Use " & G_DBName8, G_ConnMDB_MySql8)
                LC_Comm.ExecuteNonQuery()
            End With
            'ElseIf TypeDBValue = "2" Then
            Return True
            ' Catch exceptions while connecting to the database 
        Catch ex As MySqlException
            'MsgBox("ไม่สามารถเชื่อมต่อ MySql Host ที่ระบุได้" & vbCrLf & ex.Message)
            'MsgBox(ex.Message)
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        G_ConnMDB_MySql8.Close()
    End Function
End Class

