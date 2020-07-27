Imports System.IO
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Configuration
Imports System.Data.Odbc
Imports MySql.Data.MySqlClient
Public Class ClsDataAccess3
    Public Shared G_DBUserName3 As String = ""
    Public Shared G_DBPassword3 As String = ""
    Public Shared G_DBPathName3 As String
    Public Shared G_DBName3 As String
    Public Shared G_DBIPServer3 As String
    Public Shared G_DBPortServer3 As String = ""
    Public Shared G_DBService_Name3 As String
    Public Shared G_DBSID3 As String


    '---ตัวแปร share class ให้กับ class ที่อื่นเรียกใช้ ----
    Public Shared Lc_DataAcc3 As New ClsDataAccess3

    '--- ตัวแปร Connectori สำหรับ Database ---
    Public Shared G_ConnMDB_MySql3 As MySqlConnection = New MySqlConnection


    Public Function getDB_Conn_db3() As Boolean
        Try
            Dim connStr3 As String = ""
            ' Connection Information
            'ติดต่อ MySQL
            ' G_DBName3 = "mypcu"
            'connStr3 = "Data Source=nhso7kkn.info;user id=kidkom.s;password=Piano@1234;port=3306;charset=tis620;"
            connStr3 = "Data Source=" & G_DBIPServer3 & ";user id=" & G_DBUserName3 & ";password=" & G_DBPassword3 & ";port=" & G_DBPortServer3 & ";charset=tis620;"


            ' Open database connection
            With G_ConnMDB_MySql3           'ตั้งค่า Connection สำหรับ MySql
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = connStr3
                .Open()
                Dim LC_Comm As MySqlCommand
                LC_Comm = New MySqlCommand("Use " & G_DBName3, G_ConnMDB_MySql3)
                LC_Comm.ExecuteNonQuery()
            End With
            'ElseIf TypeDBValue = "2" Then
            Return True
            ' Catch exceptions while connecting to the database 
        Catch ex As MySqlException
            'MsgBox("ไม่สามารถเชื่อมต่อ MySql Host ที่ระบุได้" & vbCrLf & ex.Message)
            MsgBox(ex.Message)
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        G_ConnMDB_MySql3.Close()
    End Function
End Class
