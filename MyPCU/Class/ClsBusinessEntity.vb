﻿Imports System.Data.OleDb
Imports clsdataAcc = MyPCU.ClsDataAccess
Imports clsdataBus = MyPCU.ClsBusiness
Imports MySql.Data.MySqlClient
Imports System.Text
Public Class ClsBusinessEntity
    Public Shared Lc_BusinessEntity As New ClsBusinessEntity

    Private Lc_myComm_MySql As New MySqlCommand
    Private Lc_myTr As OleDbTransaction
    Private Lc_myTr_MySql As MySqlTransaction
    Private Lc_sb As StringBuilder = Nothing
    Private Lc_SQL As String = ""
    Private Function CommExecuteTrans(ByVal SqlStr As String) As Boolean
        Dim v_Resulte As Boolean = False
        Try
            If clsdataAcc.Lc_DataAcc.getDB_Conn() <> True Then        'เช็คการติดต่อฐานข้อมูลว่าติดต่อได้หรือไม่ True = ติดต่อได้ False = ติดต่อไม่ได้
                v_Resulte = False
            Else
                'สำหรับ MySql
                Lc_myTr_MySql = clsdataAcc.G_ConnMDB_MySql.BeginTransaction()
                Lc_myComm_MySql = New MySqlCommand
                Lc_myComm_MySql.Transaction = Lc_myTr_MySql
                With Lc_myComm_MySql
                    .CommandText = SqlStr
                    .CommandType = CommandType.Text
                    .Connection = clsdataAcc.G_ConnMDB_MySql
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
    Public Function Insertm_table(ByVal strTable As String, ByVal strValues As String) As Boolean
        Dim v_Resulte As Boolean = False
        Try
            Lc_sb = New StringBuilder
            'สำหรับ MySql
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
    Public Function Insertm_Picture(ByVal strTable As String, ByVal strValues As String, ByVal strPicture As Byte) As Boolean
        Dim v_Resulte As Boolean = False
        Try
            Lc_sb = New StringBuilder
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("INSERT INTO " & strTable & " VALUES (" & strValues & "," & strPicture & ")")
            Lc_SQL = Lc_sb.ToString()

            If CommExecuteTrans(Lc_SQL) = False Then
                Exit Try
            Else
                v_Resulte = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)
        'InsertLog_table("'" & vUSERID & "','" & Lc_SQL.Replace(",", "-").Replace("'", "/") & "','" & tmpNow & "'")
        Return v_Resulte
    End Function
    Public Function InsertLog_table(ByVal strValues As String) As Boolean
        Dim v_Resulte As Boolean = False
        Try
            Lc_sb = New StringBuilder
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("INSERT INTO r_log(USER_REC,SQL_DATA,D_UPDATE) VALUES (" & strValues & ")")
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
    Public Function Updatem_table(ByVal strTable As String, ByVal strSET As String, ByVal strWhere As String) As Boolean
        Dim v_Resulte As Boolean = False
        Try
            Lc_sb = New StringBuilder
            'สำหรับ MySql
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
        ' Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)
        'InsertLog_table("'" & vUSERID & "','" & Lc_SQL.Replace(",", "-").Replace("'", "/") & "','" & tmpNow & "'")
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
    Public Function UpdateSQL(ByVal strSQL As String) As Boolean
        Dim v_Resulte As Boolean = False
        Try
            Lc_sb = New StringBuilder
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("" & strSQL & " ;")
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
    Public Function UpdateSQL2(ByVal strSQL As String, ByVal strSQL2 As String) As Boolean
        Dim v_Resulte As Boolean = False
        Try
            Lc_sb = New StringBuilder
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("" & strSQL.Replace(";", "") & strSQL2 & " ;")
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
    Public Function Turncate_table(ByVal strTable As String) As Boolean
        Dim v_Resulte As Boolean = False

        Try
            Lc_sb = New StringBuilder
            'สำหรับ MySql
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
    Private Function AppendSql(ByVal val As String) As String
        If val.Trim = "" Then
            AppendSql = "null,"
        Else
            AppendSql = "'" & val & "',"
        End If
    End Function
    Private Function AppendLastSql(ByVal val As String) As String
        If val.Trim = "" Then
            AppendLastSql = "null)"
        Else
            AppendLastSql = "'" & val & "')"
        End If
    End Function
    Public Function InstTables_m_FILE_UPLOAD(ByVal ROWID As String, ByVal FILENAME As String, ByVal TYPE As String, ByVal TYPE_DESC As String, ByVal DATE_SEND As String, ByVal FILE_AMOUNT As String, ByVal AMOUNT As String, ByVal USER As String) As Boolean
        Dim v_Resulte As Boolean = False
        Try
            Lc_sb = New StringBuilder
            Lc_sb.Append("Insert Into m_files_upload (ROWID, FILENAME, STATUS, TYPE_DESC,FILE_AMOUNT,AMOUNT,USER_REC,DATE_SEND) VALUES(")
            Lc_sb.Append(AppendSql(ROWID))
            Lc_sb.Append(AppendSql(FILENAME))
            Lc_sb.Append(AppendSql(TYPE))
            Lc_sb.Append(AppendSql(TYPE_DESC))
            Lc_sb.Append(AppendSql(FILE_AMOUNT))
            Lc_sb.Append(AppendSql(AMOUNT))
            Lc_sb.Append(AppendSql(USER))
            Lc_sb.Append(AppendLastSql(DATE_SEND))
            Lc_SQL = Lc_sb.ToString()
            If CommExecuteTrans(Lc_SQL) = False Then
                Exit Try
            Else
                v_Resulte = True
            End If
        Catch ex As Exception

        End Try
        Return v_Resulte
    End Function
    Public Function load_table(ByVal strFile As String, ByVal strTable As String, ByVal strColunm As String) As Boolean
        Dim v_Resulte As Boolean = False
        Dim tmpCHAR As String = ""
        Dim tmpHF As String = ""
        If DetectEncoding(strFile) = "Unicode" Then
            tmpCHAR = " CHARACTER SET utf8 "
        End If
        If iUTF8 = "1" Then
            tmpCHAR = " CHARACTER SET utf8 "
        End If
        If iHeadField = "1" Then
            tmpHF = " IGNORE 1 LINES "
        End If
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
    Public Function load_table2(ByVal strFile As String, ByVal strTable As String, ByVal strColunm As String) As Boolean
        Dim v_Resulte As Boolean = False
        Dim tmpCHAR As String = ""
        Dim tmpHF As String = ""
        If DetectEncoding(strFile) = "Unicode" Then
            tmpCHAR = " CHARACTER SET utf8 "
        End If
        If iUTF8 = "1" Then
            tmpCHAR = " CHARACTER SET utf8 "
        End If
        If iHeadField = "1" Then
            tmpHF = " IGNORE 1 LINES "
        End If

        If iUTF8 = "1" Then
            tmpCHAR = " CHARACTER SET utf8 "
        End If
        Try
            Lc_sb = New StringBuilder
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("LOAD DATA LOCAL INFILE '" & strFile.ToString.Replace("\", "/") & "' INTO TABLE " & strTable & tmpCHAR & "")
            Lc_sb.Append(" FIELDS TERMINATED BY '|' ")
            Lc_sb.Append(" LINES TERMINATED BY '\n' " & tmpHF & "  ")
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
    Private Function DetectEncoding(ByVal filename As String) As String
        'Returns "ASCII" if no identifiable byte order mark4.        
        'Returns "Unicode" if an identifiable unicode byte order mark is found5.        
        'Returns "" if file does not exist or no random access6. 7.
        Dim enc As String = ""
        If System.IO.File.Exists(filename) Then
            Dim filein As New System.IO.FileStream(filename, IO.FileMode.Open, IO.FileAccess.Read)
            If (filein.CanSeek) Then
                Dim bom(4) As Byte
                filein.Read(bom, 0, 4)
                If (((bom(0) = &HEF) And (bom(1) = &HBB) And (bom(2) = &HBF)) Or _
                    ((bom(0) = &HFF) And (bom(1) = &HFE)) Or _
                    ((bom(0) = &HFE) And (bom(1) = &HFF)) Or _
                    ((bom(0) = &H0) And (bom(1) = &H0) And (bom(2) = &HFE) And (bom(3) = &HFF))) Then
                    enc = "Unicode"
                Else
                    enc = "ASCII"
                End If
                filein.Seek(0, System.IO.SeekOrigin.Begin)
            End If
            filein.Close()
        End If
        Return enc
    End Function
    Public Function load_table3(ByVal strFile As String, ByVal strTable As String, ByVal strColunm As String) As Boolean
        Dim v_Resulte As Boolean = False

        Try
            Lc_sb = New StringBuilder
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("LOAD DATA LOCAL INFILE '" & strFile.ToString.Replace("\", "/") & "' INTO TABLE " & strTable.ToString.ToLower & "")
            Lc_sb.Append(" FIELDS TERMINATED BY '|' ")
            Lc_sb.Append(" LINES TERMINATED BY '\n' IGNORE 1 LINES  ")
            Lc_sb.Append(" " & strColunm & " ;  ")
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
    Public Function load_table4(ByVal strFile As String, ByVal strTable As String, ByVal strColunm As String) As Boolean
        Dim v_Resulte As Boolean = False

        Try
            Lc_sb = New StringBuilder
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("LOAD DATA LOCAL INFILE '" & strFile.ToString.Replace("\", "/") & "' INTO TABLE " & strTable.ToString.ToLower & "")
            Lc_sb.Append(" FIELDS TERMINATED BY '|' ")
            Lc_sb.Append(" LINES TERMINATED BY '\r\n' ")
            Lc_sb.Append(" " & strColunm & " ;  ")
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
    Public Function update_table_null(ByVal strTable As String, ByVal tmpFilename As String) As Boolean
        Dim v_Resulte As Boolean = False
        Try
            Lc_sb = New StringBuilder
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("DELETE FROM " & strTable.ToString.ToLower & " WHERE HOSPCODE = 'HOSPCODE' ; COMMIT;")
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
    Public Function InstTables_m_upload(ByVal FILENAME As String, ByVal AMOUNT As String, ByVal TYPE As String, ByVal TYPE_DESC As String, ByVal UPLOAD_ID As String, ByVal FILENAME_SEND As String, ByVal DATE_SEND As String) As Boolean
        Dim v_Resulte As Boolean = False
        Try
            Lc_sb = New StringBuilder
            Lc_sb.Append("Insert Into m_upload (FILENAME,AMOUNT,TYPE, TYPE_DESC, UPLOAD_ID, FILENAME_SEND, DATE_SEND) VALUES(")
            Lc_sb.Append(AppendSql(FILENAME))
            Lc_sb.Append(AppendSql(AMOUNT))
            Lc_sb.Append(AppendSql(TYPE))
            Lc_sb.Append(AppendSql(TYPE_DESC))
            Lc_sb.Append(AppendSql(UPLOAD_ID))
            Lc_sb.Append(AppendSql(FILENAME_SEND))
            Lc_sb.Append(AppendLastSql(DATE_SEND))
            Lc_SQL = Lc_sb.ToString()
            If CommExecuteTrans(Lc_SQL) = False Then
                Exit Try
            Else
                v_Resulte = True
            End If
        Catch ex As Exception

        End Try
        Return v_Resulte
    End Function
    Public Function Insert_from_tmp(ByVal strTable As String, ByVal strTable2 As String, ByVal strWhere As String) As Boolean
        Dim v_Resulte As Boolean = False
        Try
            Lc_sb = New StringBuilder
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("INSERT INTO " & strTable.ToString.ToLower & " SELECT * FROM " & strTable2.ToString.ToLower & "  " & strWhere & " ;")
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
    Public Function Insert_from_tmp2(ByVal strTable As String, ByVal strTable2 As String, ByVal strWhere As String) As Boolean
        Dim v_Resulte As Boolean = False
        Try
            Lc_sb = New StringBuilder
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("INSERT INTO " & strTable & " SELECT " & strTable2.ToString.ToLower & "  " & strWhere & "")
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
    Public Function update_ur1(ByVal strTable As String, ByVal strValue As String, ByVal strValue2 As String, ByVal strWhere1 As String) As Boolean
        Dim v_Resulte As Boolean = False
        Try
            Lc_sb = New StringBuilder
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("UPDATE " & strTable.ToString.ToLower & " SET UR_IN = (visit_in/" & strValue & " ) * (366/daymonth),OP_UR_IN = (op_visit_in/" & strValue & " ) * (366/daymonth), UR_ALL = (visit_in/" & strValue2 & " ) * (366/daymonth),OP_UR_ALL = (op_visit_in/" & strValue2 & " ) * (366/daymonth)  WHERE MOD(" & strWhere1 & " -543,4) = 0 ")
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
    Public Function update_ur2(ByVal strTable As String, ByVal strValue As String, ByVal strValue2 As String, ByVal strWhere1 As String) As Boolean
        Dim v_Resulte As Boolean = False
        Try
            Lc_sb = New StringBuilder
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("UPDATE " & strTable.ToString.ToLower & " SET UR_IN = (visit_in/" & strValue & " ) * (365/daymonth),OP_UR_IN = (op_visit_in/" & strValue & " ) * (365/daymonth), UR_ALL = (visit_in/" & strValue2 & " ) * (365/daymonth),OP_UR_ALL = (op_visit_in/" & strValue2 & " ) * (365/daymonth) WHERE MOD(" & strWhere1 & " -543,4) <> 0 ")
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
    Public Function ChangeToThaibathWord(ByVal mondyValue As String) As String
        Dim digit() As String = {"เอ็ด", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน", "สิบล้าน", "ร้อยล้าน", "พันล้าน"}
        Dim tmp() As String = mondyValue.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
        Dim intNumber = tmp(0).Replace(",", "")
        Dim decNumber As String
        If (tmp.Length > 1) Then
            decNumber = tmp(1)
        Else
            decNumber = ""
        End If

        Dim result As String = ""
        Dim testChar As String = ""
        Dim splitChar As String = ""

        Dim wordLength As Integer = intNumber.Length - 1
        For intPosition As Integer = 0 To wordLength
            splitChar = intNumber.Substring(intPosition, 1)
            Select Case splitChar
                Case "0" : testChar = ""
                Case "1" : testChar = "หนึ่ง"
                Case "2" : testChar = "สอง"
                Case "3" : testChar = "สาม"
                Case "4" : testChar = "สี่"
                Case "5" : testChar = "ห้า"
                Case "6" : testChar = "หก"
                Case "7" : testChar = "เจ็ด"
                Case "8" : testChar = "แปด"
                Case "9" : testChar = "เก้า"
            End Select

            Select Case (wordLength - intPosition)
                Case 0
                    If (splitChar = "1") Then
                        If (wordLength = 0) Then
                            result = result & testChar
                        Else
                            result = result & digit(wordLength - intPosition)
                        End If
                    Else
                        result = result & testChar
                    End If
                Case 1
                    Select Case splitChar
                        Case "0"
                        Case "1"
                            result = result & digit(wordLength - intPosition)
                        Case "2"
                            testChar = "ยี่"
                            result = result & testChar & digit(wordLength - intPosition)
                        Case Else
                            result = result & testChar & digit(wordLength - intPosition)
                    End Select
                Case Else
                    Select Case splitChar
                        Case "0"
                        Case Else
                            result = result & testChar & digit(wordLength - intPosition)
                    End Select
            End Select

        Next
        result = result & "บาท"

        Dim stang As String = ""
        If (decNumber.Length > 0) Then
            wordLength = decNumber.Length - 1
            For intPosition As Integer = 0 To wordLength
                splitChar = decNumber.Substring(intPosition, 1)
                Select Case splitChar
                    Case "0" : testChar = ""
                    Case "1" : testChar = "หนึ่ง"
                    Case "2" : testChar = "สอง"
                    Case "3" : testChar = "สาม"
                    Case "4" : testChar = "สี่"
                    Case "5" : testChar = "ห้า"
                    Case "6" : testChar = "หก"
                    Case "7" : testChar = "เจ็ด"
                    Case "8" : testChar = "แปด"
                    Case "9" : testChar = "เก้า"
                End Select

                Select Case (wordLength - intPosition)
                    Case 0
                        If (splitChar = "1") Then
                            If (wordLength = 0) Then
                                stang = stang & testChar
                            Else
                                stang = stang & digit(wordLength - intPosition)
                            End If
                        Else
                            stang = stang & testChar
                        End If
                    Case 1
                        Select Case splitChar
                            Case "0"
                            Case "1"
                                stang = stang & digit(wordLength - intPosition)
                            Case "2"
                                testChar = "ยี่"
                                stang = stang & testChar & digit(wordLength - intPosition)
                            Case Else
                                stang = stang & testChar & digit(wordLength - intPosition)
                        End Select
                    Case Else
                        Select Case splitChar
                            Case "0"
                            Case Else
                                stang = stang & testChar & digit(wordLength - intPosition)
                        End Select
                End Select

            Next
        End If

        If (stang.Trim().Length > 0) Then
            stang = stang & "สตางค์"
        Else
            stang = "ถ้วน"
        End If

        result = result & stang

        Return result
    End Function
    Public Function clone_table(ByVal strTable As String, ByVal strTable2 As String) As Boolean
        Dim v_Resulte As Boolean = False

        Try
            Lc_sb = New StringBuilder
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("CREATE TABLE " & strTable2 & " LIKE " & strTable)
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

    Public Function drop_table(ByVal strTable As String) As Boolean
        Dim v_Resulte As Boolean = False

        Try
            Lc_sb = New StringBuilder
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("DROP TABLE IF EXISTS " & strTable)
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
    Public Function SetGlobal() As Boolean
        Dim v_Resulte As Boolean = False
        Try
            Lc_sb = New StringBuilder
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SET GLOBAL max_allowed_packet=1073741824;")
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

