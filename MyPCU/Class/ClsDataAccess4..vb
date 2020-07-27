Imports System.IO
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Configuration
Imports System.Data.Odbc
Imports MySql.Data.MySqlClient
Public Class ClsDataAccess4
    Public Shared G_DBUserName4 As String = ""
    Public Shared G_DBPassword4 As String = ""
    Public Shared G_DBPathName4 As String
    Public Shared G_DBName4 As String
    Public Shared G_DBIPServer4 As String
    Public Shared G_DBPortServer4 As String = ""
    Public Shared G_DBService_Name4 As String
    Public Shared G_DBSID3 As String


    '---ตัวแปร share class ให้กับ class ที่อื่นเรียกใช้ ----
    Public Shared Lc_DataAcc4 As New ClsDataAccess4

    '--- ตัวแปร Connectori สำหรับ Database ---
    Public Shared G_ConnMDB_MySql4 As MySqlConnection = New MySqlConnection


    Public Function getDB_Conn_db4() As Boolean
        Try
            Dim connStr4 As String = ""
            ' Connection Information
            'ติดต่อ MySQL
            ' G_DBName3 = "mypcu"
            'connStr3 = "Data Source=nhso7kkn.info;user id=kidkom.s;password=Piano@1234;port=3306;charset=tis620;"
            connStr4 = "Data Source=" & G_DBIPServer4 & ";user id=" & G_DBUserName4 & ";password=" & G_DBPassword4 & ";port=" & G_DBPortServer4 & ";charset=tis620;"


            ' Open database connection
            With G_ConnMDB_MySql4           'ตั้งค่า Connection สำหรับ MySql
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = connStr4
                .Open()
                Dim LC_Comm As MySqlCommand
                LC_Comm = New MySqlCommand("Use " & G_DBName4, G_ConnMDB_MySql4)
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
        G_ConnMDB_MySql4.Close()
    End Function
End Class
