Imports System.IO
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Configuration
Imports System.Data.Odbc
Imports MySql.Data.MySqlClient
Public Class ClsDataAccess5
    Public Shared G_DBUserName5 As String = "mypcu"
    Public Shared G_DBPassword5 As String = "mypcu11234"
    Public Shared G_DBPathName5 As String
    Public Shared G_DBName5 As String = "mypcupro"
    Public Shared G_DBIPServer5 As String = "203.157.111.6"
    Public Shared G_DBPortServer5 As String = "3306"
    Public Shared G_DBService_Name5 As String
    Public Shared G_DBSID5 As String


    '---ตัวแปร share class ให้กับ class ที่อื่นเรียกใช้ ----
    Public Shared Lc_DataAcc5 As New ClsDataAccess5

    '--- ตัวแปร Connectori สำหรับ Database ---
    Public Shared G_ConnMDB_MySql5 As MySqlConnection = New MySqlConnection


    Public Function getDB_Conn_db5() As Boolean
        Try
            Dim connStr5 As String = ""
            ' Connection Information
            'ติดต่อ MySQL
            ' G_DBName3 = "mypcu"
            'connStr3 = "Data Source=nhso7kkn.info;user id=kidkom.s;password=Piano@1234;port=3306;charset=tis620;"
            connStr5 = "Data Source=" & G_DBIPServer5 & ";user id=" & G_DBUserName5 & ";password=" & G_DBPassword5 & ";port=" & G_DBPortServer5 & ";charset=tis620;"


            ' Open database connection
            With G_ConnMDB_MySql5           'ตั้งค่า Connection สำหรับ MySql
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = connStr5
                .Open()
                Dim LC_Comm As MySqlCommand
                LC_Comm = New MySqlCommand("Use " & G_DBName5, G_ConnMDB_MySql5)
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
        G_ConnMDB_MySql5.Close()
    End Function
End Class
