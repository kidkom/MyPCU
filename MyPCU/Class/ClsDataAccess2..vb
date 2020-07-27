Imports System.IO
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Configuration
Imports System.Data.Odbc
Imports MySql.Data.MySqlClient
Public Class ClsDataAccess2
    Public Shared G_DBUserName2 As String = ""
    Public Shared G_DBPassword2 As String = ""
    Public Shared G_DBPathName2 As String
    Public Shared G_DBName2 As String
    Public Shared G_DBIPServer2 As String
    Public Shared G_DBPortServer2 As String = ""
    Public Shared G_DBService_Name2 As String
    Public Shared G_DBSID2 As String


    '---ตัวแปร share class ให้กับ class ที่อื่นเรียกใช้ ----
    Public Shared Lc_DataAcc2 As New ClsDataAccess2

    '--- ตัวแปร Connectori สำหรับ Database ---
    Public Shared G_ConnMDB_MySql2 As MySqlConnection = New MySqlConnection


    Public Function getDB_Conn_db2() As Boolean
        Try
            Dim connStr2 As String = ""
            ' Connection Information
            'ติดต่อ MySQL
            'G_DBName2 = "jhcisdb"
            connStr2 = "Data Source=" & G_DBIPServer2 & ";user id=" & G_DBUserName2 & ";password=" & G_DBPassword2 & ";port=" & G_DBPortServer2 & ";charset=tis620;"

            ' Open database connection
            With G_ConnMDB_MySql2            'ตั้งค่า Connection สำหรับ MySql
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = connStr2
                .Open()
                Dim LC_Comm As MySqlCommand
                LC_Comm = New MySqlCommand("Use " & G_DBName2, G_ConnMDB_MySql2)
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
    End Function
End Class
