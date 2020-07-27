Imports System.IO
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Configuration
Imports System.Data.Odbc
Imports MySql.Data.MySqlClient
Public Class ClsDataAccess
    Public Shared G_DBUserName As String = ""
    Public Shared G_DBPassword As String = ""
    Public Shared G_DBPathName As String
    Public Shared G_DBName As String
    Public Shared G_DBIPServer As String
    Public Shared G_DBPortServer As String = ""
    Public Shared G_DBService_Name As String
    Public Shared G_DBSID As String


    '---ตัวแปร share class ให้กับ class ที่อื่นเรียกใช้ ----
    Public Shared Lc_DataAcc As New ClsDataAccess

    '--- ตัวแปร Connectori สำหรับ Database ---
    Public Shared G_ConnMDB_MySql As MySqlConnection = New MySqlConnection


    Public Function getDB_Conn() As Boolean
        Try
            Dim connStr As String = ""
            ' Connection Information
            'ติดต่อ MySQL
            'G_DBName = "his43"
            connStr = "Data Source=" & G_DBIPServer & ";user id=" & G_DBUserName & ";password=" & G_DBPassword & ";port=" & G_DBPortServer & ";"

            ' Open database connection
            With G_ConnMDB_MySql            'ตั้งค่า Connection สำหรับ MySql
                If .State = ConnectionState.Open Then .Close()
                .ConnectionString = connStr
                .Open()
                Dim LC_Comm As MySqlCommand
                LC_Comm = New MySqlCommand("Use " & G_DBName, G_ConnMDB_MySql)
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

