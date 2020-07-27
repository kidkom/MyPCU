Imports System.IO
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Configuration
Imports System.Data.Odbc
Imports MySql.Data.MySqlClient
Public Class ClsDataAccess7
    Public Shared G_DBUserName7 As String = "dpexadmin"
    Public Shared G_DBPassword7 As String = "fi$hg@pherd3p3x"
    Public Shared G_DBPathName7 As String
    Public Shared G_DBName7 As String = "dpex_star"
    Public Shared G_DBIPServer7 As String = "164.115.74.159"
    Public Shared G_DBPortServer7 As String = "3306"
    Public Shared G_DBService_Name7 As String
    Public Shared G_DBSID3 As String


    '---ตัวแปร share class ให้กับ class ที่อื่นเรียกใช้ ----
    Public Shared Lc_DataAcc7 As New ClsDataAccess7

    '--- ตัวแปร Connectori สำหรับ Database ---
    Public Shared G_ConnMDB_MySql7 As MySqlConnection = New MySqlConnection


    Public Function getDB_Conn_db7() As Boolean
        Try
            Dim connStr7 As String = ""
            ' Connection Information
            'ติดต่อ MySQL
            ' G_DBName3 = "mypcu"
            'connStr3 = "Data Source=nhso7kkn.info;user id=kidkom.s;password=Piano@1237;port=3307;charset=tis720;"
            connStr7 = "Data Source=" & G_DBIPServer7 & ";user id=" & G_DBUserName7 & ";password=" & G_DBPassword7 & ";port=" & G_DBPortServer7 & ";"


            ' Open database connection
            With G_ConnMDB_MySql7           'ตั้งค่า Connection สำหรับ MySql
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = connStr7
                .Open()
                Dim LC_Comm As MySqlCommand
                LC_Comm = New MySqlCommand("Use " & G_DBName7, G_ConnMDB_MySql7)
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
        G_ConnMDB_MySql7.Close()
    End Function
End Class

