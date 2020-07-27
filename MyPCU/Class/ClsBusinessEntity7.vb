Imports System.Data.OleDb
Imports clsdataAcc7 = MyPCU.ClsDataAccess7
Imports clsdataBus7 = MyPCU.ClsBusiness7
Imports MySql.Data.MySqlClient
Imports System.Text
Public Class ClsBusinessEntity7
    Public Shared Lc_BusinessEntity7 As New ClsBusinessEntity7

    Private Lc_myComm_MySql As New MySqlCommand
    Private Lc_myTr As OleDbTransaction
    Private Lc_myTr_MySql As MySqlTransaction
    Private Lc_sb As StringBuilder = Nothing
    Private Lc_SQL As String = ""
    Private Function CommExecuteTrans(ByVal SqlStr As String) As Boolean
        Dim v_Resulte As Boolean = False
        Try
            If clsdataAcc7.Lc_DataAcc7.getDB_Conn_db7 <> True Then        'เช็คการติดต่อฐานข้อมูลว่าติดต่อได้หรือไม่ True = ติดต่อได้ False = ติดต่อไม่ได้
                v_Resulte = False
            Else
                'สำหรับ MySql
                Lc_myTr_MySql = clsdataAcc7.G_ConnMDB_MySql7.BeginTransaction()
                Lc_myComm_MySql = New MySqlCommand
                Lc_myComm_MySql.Transaction = Lc_myTr_MySql
                With Lc_myComm_MySql
                    .CommandText = SqlStr
                    .CommandType = CommandType.Text
                    .Connection = clsdataAcc7.G_ConnMDB_MySql7
                    .ExecuteNonQuery()
                End With
                Lc_myTr_MySql.Commit()

                v_Resulte = True
            End If
        Catch ex As Exception

            Lc_myTr_MySql.Rollback()
            MsgBox(ex.Message & vbCrLf & SqlStr)
        Finally
            Lc_myComm_MySql.Parameters.Clear()
            Lc_myComm_MySql.Dispose()
            Lc_myComm_MySql = Nothing

        End Try

        Return v_Resulte
    End Function
    Public Function ExecuteSql(ByVal strSQL As String) As Boolean

        ExecuteSql = CommExecuteTrans(strSQL)

    End Function
    Public Function load_table(ByVal strFile As String, ByVal strTable As String, ByVal strColunm As String) As Boolean
        Dim v_Resulte As Boolean = False
        Dim tmpCHAR As String = ""
        Dim tmpHF As String = ""
        Try
            Lc_sb = New StringBuilder
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("set foreign_key_checks=0; set unique_checks=0; LOAD DATA LOCAL INFILE '" & strFile.ToString.Replace("\", "/") & "' INTO TABLE " & strTable & tmpCHAR & "  ")
            Lc_sb.Append(" FIELDS TERMINATED BY '|' ")
            Lc_sb.Append(" LINES TERMINATED BY '\r\n' " & tmpHF & "")
            Lc_sb.Append(" " & strColunm & "; ")
            Lc_SQL = Lc_sb.ToString()

            If CommExecuteTrans(Lc_SQL) = False Then
                Exit Try
            Else
                v_Resulte = True
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

        Return v_Resulte

    End Function
    Public Function InsertM_table(ByVal strTable As String, ByVal strValues As String) As Boolean
        Dim v_Resulte As Boolean = False
        Try
            Lc_sb = New StringBuilder
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("INSERT INTO " & strTable & " VALUES (" & strValues & ")")
            Lc_SQL = Lc_sb.ToString()

            If CommExecuteTrans(Lc_SQL) = False Then
                Exit Try
            Else
                v_Resulte = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return v_Resulte
    End Function
    Public Function Insert_Picture(ByVal strTable As String, ByVal strValues As String) As Boolean
        Dim v_Resulte As Boolean = False
        Try
            Lc_sb = New StringBuilder
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("INSERT INTO " & strTable & " VALUES (" & strValues & ")")
            Lc_SQL = Lc_sb.ToString()

            If CommExecuteTrans(Lc_SQL) = False Then
                Exit Try
            Else
                v_Resulte = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return v_Resulte
    End Function
    Public Function Turncate_table(ByVal strTable As String) As Boolean
        Dim v_Resulte As Boolean = False
        Try
            Lc_sb = New StringBuilder
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("TRUNCATE " & strTable)
            Lc_SQL = Lc_sb.ToString()

            If CommExecuteTrans(Lc_SQL) = False Then
                Exit Try
            Else
                v_Resulte = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return v_Resulte
    End Function
    Public Function UpdateM_table(ByVal strTable As String, ByVal strSET As String, ByVal strWhere As String) As Boolean
        Dim v_Resulte As Boolean = False
        Try
            Lc_sb = New StringBuilder
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("UPDATE " & strTable & " SET " & strSET & " WHERE " & strWhere & " ;")
            Lc_SQL = Lc_sb.ToString()

            If CommExecuteTrans(Lc_SQL) = False Then
                Exit Try
            Else
                v_Resulte = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return v_Resulte

    End Function
    Public Function Delete_table(ByVal strTable As String, ByVal strWhere As String) As Boolean
        Dim v_Resulte As Boolean = False

        Try
            Lc_sb = New StringBuilder
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("DELETE FROM " & strTable & "" & strWhere & "")
            Lc_SQL = Lc_sb.ToString()

            If CommExecuteTrans(Lc_SQL) = False Then
                Exit Try
            Else
                v_Resulte = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return v_Resulte

    End Function
    Public Function UpdateALL(ByVal strTable As String, ByVal strSET As String) As Boolean
        Dim v_Resulte As Boolean = False
        Try
            Lc_sb = New StringBuilder
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("UPDATE " & strTable & " SET " & strSET & " ")
            Lc_SQL = Lc_sb.ToString()

            If CommExecuteTrans(Lc_SQL) = False Then
                Exit Try
            Else
                v_Resulte = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return v_Resulte
    End Function
End Class
