Imports System.IO
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Configuration
Imports System.Data.Odbc
Imports MySql.Data.MySqlClient
Public Class ClsDataAccess6
    Public Shared G_DBUserName6 As String = ""
    Public Shared G_DBPassword6 As String = ""
    Public Shared G_DBPathName6 As String
    Public Shared G_DBName6 As String
    Public Shared G_DBIPServer6 As String
    Public Shared G_DBPortServer6 As String = ""
    Public Shared G_DBService_Name6 As String
    Public Shared G_DBSID3 As String


    '---ตัวแปร share class ให้กับ class ที่อื่นเรียกใช้ ----
    Public Shared Lc_DataAcc6 As New ClsDataAccess6

    '--- ตัวแปร Connectori สำหรับ Database ---
    Public Shared G_ConnMDB_MySql6 As MySqlConnection = New MySqlConnection


    Public Function getDB_Conn_db6() As Boolean
        Try
            Dim connStr6 As String = ""
            ' Connection Information
            'ติดต่อ MySQL
            ' G_DBName3 = "mypcu"
            'connStr3 = "Data Source=nhso7kkn.info;user id=kidkom.s;password=Piano@1236;port=3306;charset=tis620;"
            connStr6 = "Data Source=" & G_DBIPServer6 & ";user id=" & G_DBUserName6 & ";password=" & G_DBPassword6 & ";port=" & G_DBPortServer6 & ";charset=tis620;"


            ' Open database connection
            With G_ConnMDB_MySql6           'ตั้งค่า Connection สำหรับ MySql
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = connStr6
                .Open()
                Dim LC_Comm As MySqlCommand
                LC_Comm = New MySqlCommand("Use " & G_DBName6, G_ConnMDB_MySql6)
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
        G_ConnMDB_MySql6.Close()
    End Function
End Class

