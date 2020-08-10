Imports clsdataAcc = MyPCU.ClsDataAccess
Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.Data.OleDb
Imports System.Globalization
Imports DevExpress.XtraEditors
Public Class ClsBusiness
    Public Shared Lc_Business As New ClsBusiness
    Public Shared Lc_DataAdp As Object
    Public Shared Lc_CommandBuilder As Object
    Private Lc_SQL As String = Nothing
    Private Lc_sb As StringBuilder = Nothing
    Private Lc_Errmsg As String = Nothing

    Private Function GetDataAdp(ByVal SqlStr As String, ByVal TbName As String, Optional ByRef ds As DataSet = Nothing) As DataSet
        ds = New DataSet
        Dim SqlStr2 As String = ""
        SqlStr2 = "SET TRANSACTION ISOLATION LEVEL READ COMMITTED;  SET binlog_format = MIXED;" & SqlStr

        Try

            If clsdataAcc.Lc_DataAcc.getDB_Conn() <> True Then 'เช็คการติดต่อฐานข้อมูลว่าติดต่อได้หรือไม่ True = ติดต่อได้ False = ติดต่อไม่ได้
                ds = Nothing
                Lc_Errmsg = "not connected"
            Else

                Dim Adp_My As New MySqlDataAdapter(SqlStr, clsdataAcc.G_ConnMDB_MySql)  'ดึงข้อมูลผ่าน OleDbDataAdapter
                Lc_DataAdp = Adp_My
                Adp_My.Fill(ds, TbName) 'กำหนด ค่าให้กับ Dataset และกำหนดชื่อ Table
                Lc_CommandBuilder = New MySqlCommandBuilder(Lc_DataAdp)
                Lc_Errmsg = "connected"
            End If '-2147217865 

        Catch ex As OleDbException
            If ex.ErrorCode = -2147217865 Then Throw ex
        Catch ex As MySqlException
            If ex.ErrorCode = -2147467259 Then Throw ex
        Catch ex As Exception
            ds = Nothing
            Lc_Errmsg = ex.Message
        End Try
        Return ds
    End Function
    Public Function MySQl_version() As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb = New StringBuilder
        Try
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SHOW VARIABLES LIKE 'VERSION' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)

        Catch ex As Exception
        Finally
        End Try
        Return ds
    End Function
    Public Function MySQL_Sysdate() As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT SYSDATE() AS DATENOW ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("DATENOW")
            strNAME = CDate(strNAME).ToString("yyyyMMddHHmmss", CultureInfo.CreateSpecificCulture("th-TH"))
        Catch ex As Exception
        Finally
        End Try
        Return strNAME
    End Function
    Public Function MySQL_Sysdate_En() As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT SYSDATE() AS DATENOW ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("DATENOW")
            strNAME = CDate(strNAME).ToString("yyyyMMddHHmmss", CultureInfo.CreateSpecificCulture("en-EN"))
        Catch ex As Exception
        Finally
        End Try
        Return strNAME
    End Function
    Public Function MySQL_SysdateToday() As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT SYSDATE() AS DATENOW ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = CDate(ds.Tables(0).Rows(0).Item("DATENOW")).ToString("yyyyMMddHHmmss", CultureInfo.CreateSpecificCulture("en-US"))
        Catch ex As Exception
        Finally
        End Try
        Return strNAME
    End Function
    Public Function SELECT_PRENAME(ByVal strWhere As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT PRENAME_CODE,CONCAT(PRENAME,' [',PRENAME_CODE, ']') AS PRENAME FROM l_prename " & strWhere & "")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SELECT_USER(ByVal strWhere As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT USER_ID,CID,PRENAME,FNAME,LNAME,USERNAME,PASSWORD,STATUS,ADMIN,IFNULL(PROVIDER,'') AS PROVIDER,STATUS_AF,USER_REC,D_UPDATE,IFNULL(DRUG_STORE,'0') AS DRUG_STORE,IFNULL(ACC,'0') AS ACC FROM l_user " & strWhere & "")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SELECT_MAX_USERID() As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT MAX(USER_ID) FROM l_user ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SELECT_NAME_USERID(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim NAMEUSERID As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT CONCAT(FNAME,' ',LNAME) AS NAMEUSERID FROM l_user WHERE USER_ID = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            NAMEUSERID = ds.Tables(0).Rows(0).Item("NAMEUSERID").ToString
        Catch ex As Exception

        End Try

        Return NAMEUSERID
    End Function
    Public Function SELECT_NAME_USER_CID(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim NAMEUSERID As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT CONCAT(PRENAME_DESC,FNAME,' ',LNAME) AS NAMEUSERID FROM l_user A JOIN l_prename B ON(A.PRENAME = B.PRENAME_CODE) WHERE CID = '" & Encode(strString) & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            NAMEUSERID = ds.Tables(0).Rows(0).Item("NAMEUSERID").ToString
        Catch ex As Exception

        End Try

        Return NAMEUSERID
    End Function
    Public Function SELECT_NAME_PERSON(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim NAMEUSERID As String = ""
        Dim tmpNAME As String = ""
        Dim tmpLNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT B.PRENAME,NAME,LNAME FROM m_person A LEFT JOIN l_prename B ON(A.PRENAME = B.PRENAME_CODE) WHERE PID = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                tmpNAME = (ds.Tables(0).Rows(0).Item("NAME"))
                tmpLNAME = (ds.Tables(0).Rows(0).Item("LNAME"))
                NAMEUSERID = ds.Tables(0).Rows(0).Item("PRENAME").ToString & tmpNAME & " " & tmpLNAME
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString, "", MessageBoxButtons.OK)
        End Try

        Return NAMEUSERID
    End Function
    Public Function SELECT_NAME_CID(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim NAMEUSERID As String = ""
        Dim tmpNAME As String = ""
        Dim tmpLNAME As String = ""
        Lc_sb = New StringBuilder
        strString = Trim(strString.Replace(" ", "")).ToString
        strString = Encode(strString)
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT B.PRENAME,NAME,LNAME FROM m_person A LEFT JOIN l_prename B ON(A.PRENAME = B.PRENAME_CODE) WHERE CID = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                tmpNAME = (ds.Tables(0).Rows(0).Item("NAME").ToString)
                tmpLNAME = (ds.Tables(0).Rows(0).Item("LNAME").ToString)
                NAMEUSERID = ds.Tables(0).Rows(0).Item("PRENAME").ToString & tmpNAME & " " & tmpLNAME
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString, "", MessageBoxButtons.OK)
        End Try

        Return NAMEUSERID
    End Function
    Public Function SELECT_NAME_PID_CID(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim NAMEUSERID As String = ""
        Dim tmpNAME As String = ""
        Dim tmpLNAME As String = ""
        Lc_sb = New StringBuilder
        strString = Trim(strString.Replace(" ", "")).ToString
        strString = Encode(strString)
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT PID FROM m_person WHERE CID = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                NAMEUSERID = ds.Tables(0).Rows(0).Item("PID")
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString, "", MessageBoxButtons.OK)
        End Try

        Return NAMEUSERID
    End Function
    Public Function SELECT_PID_CID(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim NAMEUSERID As String = ""
        Dim tmpNAME As String = ""
        Dim tmpLNAME As String = ""
        Lc_sb = New StringBuilder
        strString = Encode(strString)
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT PID FROM m_person WHERE CID = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                NAMEUSERID = ds.Tables(0).Rows(0).Item("PID")
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString, "", MessageBoxButtons.OK)
        End Try

        Return NAMEUSERID
    End Function
    Public Function SELECT_CID_PID(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim NAMEUSERID As String = ""
        Dim tmpNAME As String = ""
        Dim tmpLNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT CID FROM m_person WHERE PID = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                NAMEUSERID = (ds.Tables(0).Rows(0).Item("CID"))
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString, "", MessageBoxButtons.OK)
        End Try

        Return NAMEUSERID
    End Function
    Public Function SELECT_NAME_PID(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim NAMEUSERID As String = ""
        Dim tmpNAME As String = ""
        Dim tmpLNAME As String = ""
        Lc_sb = New StringBuilder
        strString = Trim(strString.Replace(" ", "")).ToString
        'strString = Encode(strString)
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT B.PRENAME,NAME,LNAME FROM m_person A LEFT JOIN l_prename B ON(A.PRENAME = B.PRENAME_CODE) WHERE PID = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                tmpNAME = (ds.Tables(0).Rows(0).Item("NAME").ToString)
                tmpLNAME = (ds.Tables(0).Rows(0).Item("LNAME").ToString)
                NAMEUSERID = ds.Tables(0).Rows(0).Item("PRENAME").ToString & tmpNAME & " " & tmpLNAME
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString, "", MessageBoxButtons.OK)
        End Try

        Return NAMEUSERID
    End Function
    Public Function SELECT_NAME_PROVINCE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT PROVINCE_NAME FROM l_catm WHERE PROVINCE_ID = '" & strString & "' GROUP BY PROVINCE_ID")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("PROVINCE_NAME").ToString
        Catch ex As Exception

        End Try

        Return strNAME
    End Function

    Public Function SELECT_NAME_PRENAME(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT PRENAME_DESC FROM l_mypcu_prename WHERE PRENAME_CODE = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("PRENAME_DESC").ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_PRENAME2(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT PRENAME_CODE FROM l_prename WHERE PRENAME = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("PRENAME_CODE").ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_PRENAME3(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT PRENAME_DESC FROM l_prename WHERE PRENAME_CODE = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("PRENAME_DESC").ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_TYPEDX(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT TYPEDX_DESC FROM l_typedx WHERE TYPEDX_CODE = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("TYPEDX_DESC").ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_ALEVEL(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT ALEVEL_DESC_S FROM l_alevel WHERE ALEVEL_CODE = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("ALEVEL_DESC_S").ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_SEX(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT SEX FROM l_mypcu_prename WHERE PRENAME_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("SEX")) Then
                strNAME = ds.Tables(0).Rows(0).Item("SEX").ToString
            Else
                strNAME = ""
            End If

        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_AMPHUR(ByVal strString As String, ByVal strString2 As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT AMPHUR_NAME FROM l_catm WHERE PROVINCE_ID = '" & strString & "' AND AMPHUR_ID = '" & strString2 & "' GROUP BY PROVINCE_ID,AMPHUR_ID")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("AMPHUR_NAME").ToString
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_PROVIDER(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT PROVIDER,CONCAT(IFNULL(B.PRENAME_DESC,''),NAME,' ',LNAME) AS PROVIDER_NAME FROM m_provider A LEFT JOIN l_mypcu_prename B ON(A.PRENAME_HOS = B.PRENAME_CODE) WHERE PROVIDER= '" & strString & "' AND A.STATUS_AF <> '8' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("PROVIDER_NAME").ToString
            Else
                strNAME = "ไม่พบข้อมูล"
            End If

        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_PROVIDER_NO(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT REGISTERNO FROM m_provider A JOIN m_diagnosis_opd B ON(A.PROVIDER = B.PROVIDER) WHERE SEQ = '" & strString & "' AND A.STATUS_AF <> '8' GROUP BY SEQ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("REGISTERNO").ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_PROVIDER_NO2(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT REGISTERNO,CONCAT(IFNULL(C.PRENAME_DESC,''),NAME,' ',LNAME) AS PROVIDER_NAME FROM m_provider A JOIN m_diagnosis_opd B ON(A.PROVIDER = B.PROVIDER) LEFT JOIN l_mypcu_prename C ON(A.PRENAME_HOS = C.PRENAME_CODE) WHERE SEQ = '" & strString & "' AND A.STATUS_AF <> '8' GROUP BY SEQ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("PROVIDER_NAME").ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_PROVIDER_NO_CHI(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT IF(IFNULL(REGISTERNO,'') <> '',REGISTERNO,CID) AS REGISTERNO,PROVIDERTYPE FROM m_provider A JOIN m_diagnosis_opd B ON(A.PROVIDER = B.PROVIDER) WHERE SEQ = '" & strString & "' AND A.STATUS_AF <> '8' GROUP BY SEQ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("PROVIDERTYPE").ToString = "01" Then
                    strNAME = "ว" & ds.Tables(0).Rows(0).Item("REGISTERNO").ToString.Replace("ว", "").Replace(".", "")
                ElseIf ds.Tables(0).Rows(0).Item("PROVIDERTYPE").ToString = "02" Then
                    strNAME = "ท" & ds.Tables(0).Rows(0).Item("REGISTERNO").ToString.Replace("ท", "").Replace(".", "")
                ElseIf ds.Tables(0).Rows(0).Item("PROVIDERTYPE").ToString = "03" Then
                    strNAME = "พ" & ds.Tables(0).Rows(0).Item("REGISTERNO").ToString.Replace("พ", "").Replace(".", "")
                ElseIf ds.Tables(0).Rows(0).Item("PROVIDERTYPE").ToString = "11" Then
                    strNAME = "ภ" & ds.Tables(0).Rows(0).Item("REGISTERNO").ToString.Replace("ภ", "").Replace(".", "")
                Else
                    strNAME = "-" & ds.Tables(0).Rows(0).Item("REGISTERNO").ToString.Replace(" ", "").Replace(".", "")
                End If
            Else
                strNAME = "-"
            End If

        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_PROVIDER_CID(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT IFNULL(CID,'') AS CID FROM m_provider  WHERE PROVIDER = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("CID").ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_TAMBOL(ByVal strString As String, ByVal strString2 As String, ByVal strString3 As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT TAMBOL_NAME FROM l_cat WHERE PROVINCE_ID = '" & strString & "' AND AMPHUR_ID = '" & strString2 & "' AND TAMBOL_ID = '" & strString3 & "' GROUP BY PROVINCE_ID,AMPHUR_ID,TAMBOL_ID")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("TAMBOL_NAME").ToString
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_ADDRESS(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT * FROM l_cat WHERE CONCAT(PROVINCE_ID,AMPHUR_ID,TAMBOL_ID) = '" & strString & "' GROUP BY PROVINCE_ID,AMPHUR_ID,TAMBOL_ID")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = " ต." & ds.Tables(0).Rows(0).Item("TAMBOL_NAME").ToString & " อ." & ds.Tables(0).Rows(0).Item("AMPHUR_NAME").ToString & " จ." & ds.Tables(0).Rows(0).Item("PROVINCE_NAME").ToString
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_TEL(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = "ไม่มีการบันทึก"
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT TEL FROM n_parent_name WHERE PID = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("TEL").ToString
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_BWEIGHT(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = "ไม่มีการบันทึก"
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT BWEIGHT FROM m_newborn WHERE PID = '" & strString & "' AND STATUS_AF = '1' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = CInt(ds.Tables(0).Rows(0).Item("BWEIGHT")).ToString("#,##0")
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_BASPHYXIA(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = "ไม่มีการบันทึก"
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT ASPHYXIA FROM m_newborn WHERE PID = '" & strString & "' AND STATUS_AF = '1' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If CInt(ds.Tables(0).Rows(0).Item("ASPHYXIA")) < 7 Then
                strNAME = "มี"
            ElseIf CInt(ds.Tables(0).Rows(0).Item("ASPHYXIA")) >= 7 And CInt(ds.Tables(0).Rows(0).Item("ASPHYXIA")) <= 10 Then
                strNAME = "ไม่มี"
            ElseIf ds.Tables(0).Rows(0).Item("ASPHYXIA").ToString = "99" Then
                strNAME = "ไม่ทราบ"
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_ADDRESS_PID(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT B.HOUSE,B.VILLAGE,B.VILLANAME,B.TAMBON,B.AMPUR,B.CHANGWAT,TAMBOL_NAME,AMPHUR_NAME,PROVINCE_NAME FROM m_person A JOIN m_home B ON(A.HID = B.HID) JOIN l_cat C ON(B.TAMBON = C.TAMBOL_ID AND B.AMPUR = C.AMPHUR_ID AND B.CHANGWAT = C.PROVINCE_ID) WHERE PID = '" & strString & "' GROUP BY B.HOUSE,B.VILLAGE,B.TAMBON,B.AMPUR,B.CHANGWAT ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("VILLAGE").ToString = "00" Then
                    strNAME = ds.Tables(0).Rows(0).Item("HOUSE").ToString & " " & ds.Tables(0).Rows(0).Item("VILLANAME").ToString & " ต." & ds.Tables(0).Rows(0).Item("TAMBOL_NAME").ToString & " อ." & ds.Tables(0).Rows(0).Item("AMPHUR_NAME").ToString & " จ." & ds.Tables(0).Rows(0).Item("PROVINCE_NAME").ToString
                Else
                    strNAME = ds.Tables(0).Rows(0).Item("HOUSE").ToString & " ม." & CInt(ds.Tables(0).Rows(0).Item("VILLAGE")).ToString("0") & " ต." & ds.Tables(0).Rows(0).Item("TAMBOL_NAME").ToString & " อ." & ds.Tables(0).Rows(0).Item("AMPHUR_NAME").ToString & " จ." & ds.Tables(0).Rows(0).Item("PROVINCE_NAME").ToString
                End If

            Else
                Lc_sb.Remove(0, Lc_sb.Length())
                Lc_sb.Append("SELECT B.HOUSENO,B.VILLAGE,B.TAMBON,B.AMPUR,B.CHANGWAT,TAMBOL_NAME,AMPHUR_NAME,PROVINCE_NAME FROM m_person A JOIN m_address B ON(A.PID = B.PID) JOIN l_cat C ON(B.TAMBON = C.TAMBOL_ID AND B.AMPUR = C.AMPHUR_ID AND B.CHANGWAT = C.PROVINCE_ID) WHERE A.PID = '" & strString & "' GROUP BY B.HOUSENO,B.VILLAGE,B.TAMBON,B.AMPUR,B.CHANGWAT ")
                Lc_SQL = Lc_sb.ToString
                ds = GetDataAdp(Lc_SQL, "Table1", ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    strNAME = ds.Tables(0).Rows(0).Item("HOUSENO").ToString & " ม." & CInt(ds.Tables(0).Rows(0).Item("VILLAGE")).ToString("0") & " ต." & ds.Tables(0).Rows(0).Item("TAMBOL_NAME").ToString & " อ." & ds.Tables(0).Rows(0).Item("AMPHUR_NAME").ToString & " จ." & ds.Tables(0).Rows(0).Item("PROVINCE_NAME").ToString
                End If
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_ADDRESS_PID_2(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT B.HOUSE,B.VILLAGE,B.TAMBON,B.AMPUR,B.CHANGWAT,TAMBOL_NAME,AMPHUR_NAME,PROVINCE_NAME FROM m_person A JOIN m_home B ON(A.HID = B.HID) JOIN l_cat C ON(B.TAMBON = C.TAMBOL_ID AND B.AMPUR = C.AMPHUR_ID AND B.CHANGWAT = C.PROVINCE_ID) WHERE PID = '" & strString & "' GROUP BY B.HOUSE,B.VILLAGE,B.TAMBON,B.AMPUR,B.CHANGWAT ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("HOUSE").ToString & " ม." & CInt(ds.Tables(0).Rows(0).Item("VILLAGE")).ToString("0") & " ต." & ds.Tables(0).Rows(0).Item("TAMBOL_NAME").ToString
            Else
                Lc_sb.Remove(0, Lc_sb.Length())
                Lc_sb.Append("SELECT B.HOUSENO,B.VILLAGE,B.TAMBON,B.AMPUR,B.CHANGWAT,TAMBOL_NAME,AMPHUR_NAME,PROVINCE_NAME FROM m_person A JOIN m_address B ON(A.PID = B.PID) JOIN l_cat C ON(B.TAMBON = C.TAMBOL_ID AND B.AMPUR = C.AMPHUR_ID AND B.CHANGWAT = C.PROVINCE_ID) WHERE A.PID = '" & strString & "' GROUP BY B.HOUSENO,B.VILLAGE,B.TAMBON,B.AMPUR,B.CHANGWAT ")
                Lc_SQL = Lc_sb.ToString
                ds = GetDataAdp(Lc_SQL, "Table1", ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    strNAME = ds.Tables(0).Rows(0).Item("HOUSENO").ToString & " ม." & CInt(ds.Tables(0).Rows(0).Item("VILLAGE")).ToString("0") & " ต." & ds.Tables(0).Rows(0).Item("TAMBOL_NAME").ToString
                End If
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_ADDRESS_CID(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT B.HOUSE,B.VILLAGE,B.TAMBON,B.AMPUR,B.CHANGWAT,TAMBOL_NAME,AMPHUR_NAME,PROVINCE_NAME FROM m_person A JOIN m_home B ON(A.HID = B.HID) JOIN l_cat C ON(B.TAMBON = C.TAMBOL_ID AND B.AMPUR = C.AMPHUR_ID AND B.CHANGWAT = C.PROVINCE_ID) WHERE CID = '" & strString & "' GROUP BY B.HOUSE,B.VILLAGE,B.TAMBON,B.AMPUR,B.CHANGWAT ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("HOUSE").ToString & " ม." & CInt(ds.Tables(0).Rows(0).Item("VILLAGE")).ToString("0") & " ต." & ds.Tables(0).Rows(0).Item("TAMBOL_NAME").ToString & " อ." & ds.Tables(0).Rows(0).Item("AMPHUR_NAME").ToString & " จ." & ds.Tables(0).Rows(0).Item("PROVINCE_NAME").ToString
            Else
                Lc_sb.Remove(0, Lc_sb.Length())
                Lc_sb.Append("SELECT B.HOUSENO,B.VILLAGE,B.TAMBON,B.AMPUR,B.CHANGWAT,TAMBOL_NAME,AMPHUR_NAME,PROVINCE_NAME FROM m_person A JOIN m_address B ON(A.PID = B.PID) JOIN l_cat C ON(B.TAMBON = C.TAMBOL_ID AND B.AMPUR = C.AMPHUR_ID AND B.CHANGWAT = C.PROVINCE_ID) WHERE A.CID = '" & strString & "' GROUP BY B.HOUSENO,B.VILLAGE,B.TAMBON,B.AMPUR,B.CHANGWAT ")
                Lc_SQL = Lc_sb.ToString
                ds = GetDataAdp(Lc_SQL, "Table1", ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    strNAME = ds.Tables(0).Rows(0).Item("HOUSENO").ToString & " ม." & CInt(ds.Tables(0).Rows(0).Item("VILLAGE")).ToString("0") & " ต." & ds.Tables(0).Rows(0).Item("TAMBOL_NAME").ToString & " อ." & ds.Tables(0).Rows(0).Item("AMPHUR_NAME").ToString & " จ." & ds.Tables(0).Rows(0).Item("PROVINCE_NAME").ToString
                End If
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_ADDRESS_HID(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT B.HOUSE,B.VILLAGE,B.TAMBON,B.AMPUR,B.CHANGWAT,TAMBOL_NAME,AMPHUR_NAME,PROVINCE_NAME FROM m_home B JOIN l_cat C ON(B.TAMBON = C.TAMBOL_ID AND B.AMPUR = C.AMPHUR_ID AND B.CHANGWAT = C.PROVINCE_ID) WHERE HID = '" & strString & "' GROUP BY B.HOUSE,B.VILLAGE,B.TAMBON,B.AMPUR,B.CHANGWAT ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("HOUSE").ToString & " ม." & CInt(ds.Tables(0).Rows(0).Item("VILLAGE")).ToString("0") & " ต." & ds.Tables(0).Rows(0).Item("TAMBOL_NAME").ToString & " อ." & ds.Tables(0).Rows(0).Item("AMPHUR_NAME").ToString & " จ." & ds.Tables(0).Rows(0).Item("PROVINCE_NAME").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_TAMBON_ADDRESS(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT * FROM l_cat WHERE CONCAT(PROVINCE_ID,AMPHUR_ID,TAMBOL_ID) = '" & strString & "' GROUP BY PROVINCE_ID,AMPHUR_ID,TAMBOL_ID")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = " ต." & ds.Tables(0).Rows(0).Item("TAMBOL_NAME").ToString
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_ADDRESS_TAMBON(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT * FROM l_cat WHERE CONCAT(PROVINCE_ID,AMPHUR_ID,TAMBOL_ID) = '" & strString & "' GROUP BY PROVINCE_ID,AMPHUR_ID,TAMBOL_ID")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = " ต." & ds.Tables(0).Rows(0).Item("TAMBOL_NAME").ToString
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_HOSPITAL(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT HOSPNAME FROM l_hospitals WHERE HOSPCODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("HOSPNAME").ToString
            Else
                strNAME = ""
            End If

        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_HOSPITAL_DEPARTMENT(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT CLINIC_NAME FROM l_hospital_department WHERE CLINIC = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("CLINIC_NAME").ToString
            Else
                strNAME = ""
            End If

        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_DEPARTMENT(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT CLINIC_SUB_DESC FROM l_clinic_hosp WHERE CLINIC_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("CLINIC_SUB_DESC").ToString
            Else
                strNAME = ""
            End If

        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_HCODE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT A.HOSPNAME,A.AMPHUR_NAME,A.PROVINCE_NAME,TAMBOL_NAME FROM l_confighcode A JOIN l_hospitals B ON(A.HOSPCODE = B.HOSPCODE) JOIN l_cat C ON(B.AMP = C.AMPHUR_ID AND B.TAM = C.TAMBOL_ID AND B.PROVINCE_ID = C.PROVINCE_ID) WHERE A.HOSPCODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("HOSPNAME").ToString & " ต." & ds.Tables(0).Rows(0).Item("TAMBOL_NAME").ToString & " อ." & ds.Tables(0).Rows(0).Item("AMPHUR_NAME").ToString & " จ." & ds.Tables(0).Rows(0).Item("PROVINCE_NAME").ToString
            Else
                strNAME = ""
            End If

        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_HCODE_ADDRESS(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT A.ADDRESS,A.HOSPNAME,A.AMPHUR_NAME,A.PROVINCE_NAME,TAMBOL_NAME FROM l_confighcode A JOIN l_hospitals B ON(A.HOSPCODE = B.HOSPCODE) JOIN l_cat C ON(B.AMP = C.AMPHUR_ID AND B.TAM = C.TAMBOL_ID AND B.PROVINCE_ID = C.PROVINCE_ID) WHERE A.HOSPCODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("ADDRESS").ToString & " ต." & ds.Tables(0).Rows(0).Item("TAMBOL_NAME").ToString & " อ." & ds.Tables(0).Rows(0).Item("AMPHUR_NAME").ToString & " จ." & ds.Tables(0).Rows(0).Item("PROVINCE_NAME").ToString
            Else
                strNAME = ""
            End If

        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_NATION(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT NATION_DESC FROM l_nation WHERE NATION_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("NATION_DESC").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_PROVIDERTYPE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT PROVIDER_DESC FROM l_providertype WHERE PROVIDER_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("PROVIDER_DESC").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_DISCHARGE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DISCHARGE_DESC FROM l_discharge WHERE DISCHARGE_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("DISCHARGE_DESC").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_VSTATUS(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT VSTATUS_DESC FROM l_vstatus WHERE VSTATUS_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("VSTATUS_DESC").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_RELIGION(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT RELIGION_DESC FROM l_religion WHERE RELIGION_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("RELIGION_DESC").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_EDUCATION(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT EDUCATION_DESC FROM l_education WHERE EDUCATION_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("EDUCATION_DESC").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_LABOR(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT LABOR_DESC FROM l_labor WHERE LABOR_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("LABOR_DESC").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_INSTYPE_OLD(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT INSTYPE_DESC FROM l_instype_old WHERE INSTYPE_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("INSTYPE_DESC").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NHSO_STATUS(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT NHSO_DESC FROM l_nhso_status WHERE NHSO_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("NHSO_DESC").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_INSTYPE_NEW(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT INSTYPE_DESC FROM l_instype_new WHERE INSTYPE_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("INSTYPE_DESC").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_INSTYPE_NEW2(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT INSTYPE_NAME2 FROM l_instype_new WHERE INSTYPE_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("INSTYPE_NAME2").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_INSTYPE_OLD_NEW(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT INSTYPE_NEW FROM l_instype_old WHERE INSTYPE_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("INSTYPE_NEW").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_ICD10(ByVal strString As String, ByVal strTHA As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DESC_ENG,DESC_THAI FROM l_icd10 WHERE CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                If strTHA = "0" Then
                    strNAME = ds.Tables(0).Rows(0).Item("DESC_ENG").ToString
                Else
                    strNAME = ds.Tables(0).Rows(0).Item("DESC_THAI").ToString
                End If
            Else
                strNAME = "xxx"
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function

    Public Function SELECT_NAME_ICD10_DETAIL(ByVal strString As String, ByVal strTHA As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DESC_ENG,DESC_THAI,VALID,SEX,AGEMIN,AGEMAX,AGEDMIN FROM l_icd10 WHERE CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                If strTHA = "0" Then
                    strNAME = ds.Tables(0).Rows(0).Item("DESC_ENG").ToString
                    strNAME = strNAME & ";VALID = " & ds.Tables(0).Rows(0).Item("VALID").ToString
                    strNAME = strNAME & ";SEX = " & ds.Tables(0).Rows(0).Item("SEX").ToString
                    strNAME = strNAME & ";AGEMIN = " & ds.Tables(0).Rows(0).Item("AGEMIN").ToString
                    strNAME = strNAME & ";AGEMAX = " & ds.Tables(0).Rows(0).Item("AGEMAX").ToString
                    strNAME = strNAME & ";AGEdayMIN = " & ds.Tables(0).Rows(0).Item("AGDMIN").ToString
                Else
                    strNAME = ds.Tables(0).Rows(0).Item("DESC_THAI").ToString
                    strNAME = strNAME & ";VALID = " & ds.Tables(0).Rows(0).Item("VALID").ToString
                    strNAME = strNAME & ";เพศ = " & ds.Tables(0).Rows(0).Item("SEX").ToString
                    strNAME = strNAME & ";อายุปีน้อยที่สุด = " & ds.Tables(0).Rows(0).Item("AGEMIN").ToString
                    strNAME = strNAME & ";อายุปีมากที่สุด = " & ds.Tables(0).Rows(0).Item("AGEMAX").ToString
                    strNAME = strNAME & ";อายุวันน้อยที่สุด = " & ds.Tables(0).Rows(0).Item("AGDMIN").ToString
                End If
            Else
                strNAME = "xxx"
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_ICD9(ByVal strString As String, ByVal strTHA As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DESC_ENG,DESC_THA,IFNULL(CSMBS,'') AS CSMBS FROM l_icd9 a LEFT JOIN l_procedprice b ON(a.CODE = b.PROCEDCODE ) WHERE CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                If strTHA = "0" Then
                    If ds.Tables(0).Rows(0).Item("CSMBS").ToString = "" Then
                        strNAME = ds.Tables(0).Rows(0).Item("DESC_ENG").ToString
                    Else
                        strNAME = ds.Tables(0).Rows(0).Item("DESC_ENG").ToString & " (" & ds.Tables(0).Rows(0).Item("CSMBS").ToString & ")"
                    End If
                Else
                    If ds.Tables(0).Rows(0).Item("CSMBS").ToString = "" Then
                        strNAME = ds.Tables(0).Rows(0).Item("DESC_THA").ToString
                    Else
                        strNAME = ds.Tables(0).Rows(0).Item("DESC_THA").ToString & " (" & ds.Tables(0).Rows(0).Item("CSMBS").ToString & ")"
                    End If
                End If
            Else
                strNAME = "xxx"
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_ICD9CM(ByVal strString As String, ByVal strTHA As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DESC_ENG,DESC_THA FROM l_icd9  WHERE CODE = '" & strString & "' AND 9CM = 'Y'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                If strTHA = "0" Then
                    strNAME = ds.Tables(0).Rows(0).Item("DESC_ENG").ToString
                Else
                    strNAME = ds.Tables(0).Rows(0).Item("DESC_THA").ToString
                End If
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_ICD9_ICD10TM(ByVal strString As String, ByVal strTHA As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DESC_ENG,DESC_THA FROM l_icd9 a  WHERE CODE = '" & strString & "' AND 9CM = 'N' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                If strTHA = "0" Then
                    strNAME = ds.Tables(0).Rows(0).Item("DESC_ENG").ToString
                Else
                    strNAME = ds.Tables(0).Rows(0).Item("DESC_THA").ToString
                End If
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_ICD9_PRICE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT SERVICEPRICE FROM l_procedprice WHERE PROCEDCODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then

                strNAME = ds.Tables(0).Rows(0).Item("SERVICEPRICE").ToString
            Else
                strNAME = "0.00"
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_ICD9_COST(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT SERVICECOST FROM l_procedprice WHERE PROCEDCODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then

                strNAME = ds.Tables(0).Rows(0).Item("SERVICECOST").ToString
            Else
                strNAME = "0.00"
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_ICD9_DETAIL(ByVal strString As String, ByVal strTHA As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DESC_ENG,DESC_THA,VALIDCODE FROM l_icd9 WHERE CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                If strTHA = "1" Then
                    strNAME = ds.Tables(0).Rows(0).Item("DESC_ENG").ToString
                    strNAME = strNAME & ";VALID = " & ds.Tables(0).Rows(0).Item("VALIDCODE").ToString
                Else
                    strNAME = ds.Tables(0).Rows(0).Item("DESC_THA").ToString
                    strNAME = strNAME & ";VALID = " & ds.Tables(0).Rows(0).Item("VALIDCODE").ToString
                End If
            Else
                strNAME = "xxx"
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_APTYPE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT APTYPE_DESC_T FROM l_aptype WHERE APTYPE_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("APTYPE_DESC_T").ToString
            Else
                strNAME = "รหัสไม่ถูกต้อง"
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_APTYPE_REMARK(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DATA_TEXT FROM at_ap_remark WHERE ROWID = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("DATA_TEXT").ToString
            Else
                strNAME = "-"
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_DIAGTYPE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DIAGTYPE_DESC_E, DIAGTYPE_DESC_T FROM l_diagtype WHERE DIAGTYPE_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                If vICD10TH = "1" Then
                    strNAME = ds.Tables(0).Rows(0).Item("DIAGTYPE_DESC_T").ToString
                Else
                    strNAME = ds.Tables(0).Rows(0).Item("DIAGTYPE_DESC_E").ToString
                End If

            Else
                strNAME = "รหัสไม่ถูกต้อง"
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_CHARGEITEM(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT CHARGEITEm_DESC FROM l_chargeitem WHERE CHARGEITEm_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then

                strNAME = ds.Tables(0).Rows(0).Item("CHARGEITEm_DESC").ToString
            Else
                strNAME = "รหัสไม่ถูกต้อง"
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_LAB(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT LAB_DESC FROM l_labprice WHERE LAB_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then

                strNAME = ds.Tables(0).Rows(0).Item("LAB_DESC").ToString
            Else
                strNAME = "รหัสไม่ถูกต้อง"
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_LABFU_NAME(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT LAB_DESC FROM l_labprice WHERE LABFU_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then

                strNAME = ds.Tables(0).Rows(0).Item("LAB_DESC").ToString
            Else
                strNAME = "รหัสไม่ถูกต้อง"
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_LABFU(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT LABFU_CODE FROM l_labprice WHERE LAB_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then

                strNAME = ds.Tables(0).Rows(0).Item("LABFU_CODE").ToString
            Else
                strNAME = "รหัสไม่ถูกต้อง"
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_LAB_UNIT(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT UNIT FROM l_labprice WHERE LAB_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then

                strNAME = ds.Tables(0).Rows(0).Item("UNIT").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_LABFU_UNIT(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT UNIT FROM l_labprice WHERE LABFU_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then

                strNAME = ds.Tables(0).Rows(0).Item("UNIT").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_UNIT(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT UNIT_DESC FROM l_unit WHERE UNIT_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("UNIT_DESC").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_DRUGDOSE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DRUG_DOSE FROM d_drug_dose WHERE ROWID = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then

                strNAME = ds.Tables(0).Rows(0).Item("DRUG_DOSE").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_DRUG_Exprie(ByVal strString As String, ByVal strString2 As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DATE_EXPIRED FROM d_drug_in WHERE DRUG_ID = '" & strString & "' AND LOT_NO = '" & strString2 & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then

                strNAME = ds.Tables(0).Rows(0).Item("DATE_EXPIRED").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_SERVICE_OTHER(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT OTHER_DESC FROM l_otherprice WHERE OTHER_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then

                strNAME = ds.Tables(0).Rows(0).Item("OTHER_DESC").ToString
            Else
                strNAME = "รหัสไม่ถูกต้อง"
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_VACCINETYPE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT CONCAT(VACCINE_DESC_T,' (',VACCINE_DESC_E,')') AS VACCINE_DESC,VACCINE_CODE FROM l_vaccinetype WHERE VACCINE_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then

                strNAME = ds.Tables(0).Rows(0).Item("VACCINE_DESC").ToString
            Else
                strNAME = "รหัสไม่ถูกต้อง"
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_FPTYPE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT FP_DESC,FP_CODE FROM l_fptype WHERE FP_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then

                strNAME = ds.Tables(0).Rows(0).Item("FP_DESC").ToString
            Else
                strNAME = "รหัสไม่ถูกต้อง"
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_506(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT CODE_506 FROM l_surveillance WHERE CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then

                strNAME = ds.Tables(0).Rows(0).Item("CODE_506").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_SYNDROME_CODE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT CODE_SYNDROME FROM l_surveillance WHERE CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then

                strNAME = ds.Tables(0).Rows(0).Item("CODE_SYNDROME").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_SYNDROME_NAME(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT SYNDROME_DESC FROM l_syndrome WHERE SYNDROME_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then

                strNAME = ds.Tables(0).Rows(0).Item("SYNDROME_DESC").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_ORGANISM(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT NAMEORG FROM l_surveillance_orga WHERE CODE_NEW = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then

                strNAME = ds.Tables(0).Rows(0).Item("NAMEORG").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_OCCUPATION_NEW(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT OCCUPATION_DESC FROM l_occupation WHERE OCCUPATION_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then

                strNAME = ds.Tables(0).Rows(0).Item("OCCUPATION_DESC").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_OCCUPATION_OLD(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT OCCUPATION_DESC FROM l_occupation_old WHERE OCCUPATION_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then

                strNAME = ds.Tables(0).Rows(0).Item("OCCUPATION_DESC").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_CARD_PID(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT INSTYPE_NAME2 FROM m_card A JOIN l_instype_new B ON(INSTYPE_NEW = INSTYPE_CODE) WHERE PID = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then

                strNAME = ds.Tables(0).Rows(0).Item("INSTYPE_NAME2").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_DRUGALLERGY_PID(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT * FROM m_drugallergy WHERE PID = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = "มี"
            Else
                strNAME = "ไม่มี"
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function

    Public Function SELECT_NAME_COMSERVICE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT COMSERVICE_DESC FROM l_comservice WHERE COMSERVICE_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("COMSERVICE_DESC").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_PPSPECIAL(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT PPSPECIAL_DESC FROM l_ppspecial WHERE PPSPECIAL_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("PPSPECIAL_DESC").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_ERRORCODE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT ERROR_DESC FROM l_configcheck WHERE ERROR_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("ERROR_DESC").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_ERRORCODE_REMARK(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT ERROR_REMARK FROM l_configcheck WHERE ERROR_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("ERROR_REMARK").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_REHAB(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT REHABCODE_DESC_T,REHABCODE_CODE FROM l_rehabcode WHERE REHABCODE_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then

                strNAME = ds.Tables(0).Rows(0).Item("REHABCODE_DESC_T").ToString
            Else
                strNAME = "รหัสไม่ถูกต้อง"
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_at_DEVICE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT at_DEVICE_DESC_T FROM l_at_device WHERE at_DEVICE_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then

                strNAME = ds.Tables(0).Rows(0).Item("at_DEVICE_DESC_T").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_DATA(ByVal strTable As String, ByVal strWhere As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT * FROM " & strTable & " " & strWhere & "")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SELECT_TABLE(ByVal strField As String, ByVal strTable As String, ByVal strWhere As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb = New StringBuilder

        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT " & strField & " FROM " & strTable & " " & strWhere & "")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SELECT_SQL(ByVal strField As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb = New StringBuilder

        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append(strField)
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SHOW_TABLE_COLUMN(ByVal strTable As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb = New StringBuilder

        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SHOW COLUMNS FROM " & strTable & "")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SHOW_TABLE(ByVal strTable As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb = New StringBuilder

        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SHOW TABLES " & strTable & "")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SHOW_TABLE_STATUS(ByVal strTable As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb = New StringBuilder

        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SHOW TABLE " & strTable & "")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function Checkm_upload(ByVal strFilename As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb = New StringBuilder
        Try
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT FILENAME, DATE_SEND, TYPE_DESC, STATUS, ROWID ")
            Lc_sb.Append(" FROM m_files_upload ")
            Lc_sb.Append(" where FILENAME = '" & strFilename & "' OR STATUS = '0' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)

        Catch ex As Exception

        Finally

        End Try

        Return ds
    End Function
    Public Function countm_upload(ByVal strType As String, ByVal tmpFilename As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb = New StringBuilder
        Try
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT COUNT(*) AS C_AMOUNT ")
            Lc_sb.Append(" FROM " & strType & " WHERE STATUS_AF = '2'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)

        Catch ex As Exception
        Finally
        End Try
        Return ds
    End Function
    Public Function SELECT_POP() As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb = New StringBuilder
        '---หน่วยบริการหลัก---
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT HOSPCODE, SUM(CASE WHEN SEX = '1' AND TYPEAREA IN('5','1','3') THEN 1 ELSE 0 END) AS POP_MALE,")
            Lc_sb.Append(" SUM(CASE WHEN SEX = '2' AND TYPEAREA IN('5','1','3') THEN 1 ELSE 0 END) AS POP_FEMALE, ")
            Lc_sb.Append(" SUM(CASE WHEN TYPEAREA IN('5','1','3') THEN 1 ELSE 0 END) AS POP_IN, ")
            Lc_sb.Append(" SUM(CASE WHEN TYPEAREA IN('2','4') THEN 1 ELSE 0 END) AS POP_OUT, COUNT(*) AS POP_ALL, ")
            Lc_sb.Append(" SUM(CASE WHEN  TYPEAREA = '5' THEN 1 ELSE 0 END) AS POP5,")
            Lc_sb.Append(" SUM(CASE WHEN  TYPEAREA = '1' THEN 1 ELSE 0 END) AS POP1, ")
            Lc_sb.Append(" SUM(CASE WHEN  TYPEAREA = '2' THEN 1 ELSE 0 END) AS POP2, ")
            Lc_sb.Append(" SUM(CASE WHEN  TYPEAREA = '3' THEN 1 ELSE 0 END) AS POP3, ")
            Lc_sb.Append(" SUM(CASE WHEN  TYPEAREA = '4' THEN 1 ELSE 0 END) AS POP4 ")
            Lc_sb.Append(" FROM m_person WHERE DISCHARGE = '9' AND STATUS_AF <> '8' ")
            Lc_sb.Append(" GROUP BY HOSPCODE ")

            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SELECT_POP_TYPEAREA() As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb = New StringBuilder
        '---หน่วยบริการหลัก---
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT HOSPCODE, SUM(CASE WHEN  TYPEAREA = '5' THEN 1 ELSE 0 END) AS POP5,")
            Lc_sb.Append(" SUM(CASE WHEN  TYPEAREA = '1' THEN 1 ELSE 0 END) AS POP1, ")
            Lc_sb.Append(" SUM(CASE WHEN  TYPEAREA = '2' THEN 1 ELSE 0 END) AS POP2, ")
            Lc_sb.Append(" SUM(CASE WHEN  TYPEAREA = '3' THEN 1 ELSE 0 END) AS POP3, ")
            Lc_sb.Append(" SUM(CASE WHEN  TYPEAREA = '4' THEN 1 ELSE 0 END) AS POP4 ")
            Lc_sb.Append(" FROM m_person WHERE DISCHARGE = '9' AND STATUS_AF <> '8' GROUP BY HOSPCODE ")

            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SELECT_OP_VISIT_DAY(ByVal strDiagCut As String, ByVal strWhere As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb = New StringBuilder
        '---หน่วยบริการหลัก---
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT HOSPCODE,SUBSTR(DATE_SERV,1,6) AS MONTH_SERV,SUBSTR(DATE_SERV,1,4) AS CYEAR, SUBSTR(DATE_SERV,5,2) AS MYEAR, DATE_SERV,")
            Lc_sb.Append(" COUNT(ROWID) AS VISIT, ")
            Lc_sb.Append(" COUNT(CASE WHEN " & strDiagCut & " THEN ROWID END) OP_VISIT,")
            Lc_sb.Append(" COUNT(DISTINCT(PID)) AS P_VISIT, ")
            Lc_sb.Append(" COUNT(DISTINCT(CASE WHEN " & strDiagCut & " THEN PID END)) P_OP_VISIT,")
            Lc_sb.Append(" COUNT(CASE WHEN (PDX LIKE '%I1%' OR PDX LIKE '%E10%' OR PDX LIKE '%E11%' OR PDX LIKE '%E12%' OR PDX LIKE '%E13%' OR PDX LIKE '%E14%') THEN ROWID END) DMHT_VISIT,")
            Lc_sb.Append(" COUNT(DISTINCT(CASE WHEN (PDX LIKE '%I1%' OR PDX LIKE '%E10%' OR PDX LIKE '%E11%' OR PDX LIKE '%E12%' OR PDX LIKE '%E13%' OR PDX LIKE '%E14%') THEN PID END)) P_DMHT_VISIT")
            Lc_sb.Append(" FROM(m_service) ")
            Lc_sb.Append(" WHERE STATUS_AF <> '8' " & strWhere & " ")
            Lc_sb.Append(" GROUP BY HOSPCODE,SUBSTR(DATE_SERV,1,6), SUBSTR(DATE_SERV,1,4), DATE_SERV")
            Lc_sb.Append(" ORDER BY DATE_SERV ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SELECT_OP_VISIT_MONTH_UR(ByVal strDiagCut As String, ByVal strWhere As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb = New StringBuilder
        '---หน่วยบริการหลัก---
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT A.HOSPCODE,substr(date_serv,1,6) as MONTH_SERV,substr(date_serv,1,4) as GYEAR, substr(date_serv,5,2) as MYEAR, MAX(DATE_SERV) as MAX_DATE,  ")
            Lc_sb.Append(" COUNT(DISTINCT(CASE WHEN (TYPEAREA = '5' OR  TYPEAREA = '1' OR TYPEAREA = '3') THEN CONCAT(A.PID,DATE_SERV) END)) VISIT_IN,")
            Lc_sb.Append(" COUNT(DISTINCT(CASE WHEN (TYPEAREA = '5' OR  TYPEAREA = '1' OR TYPEAREA = '3') AND " & strDiagCut & "  THEN CONCAT(A.PID,DATE_SERV) END)) OP_VISIT_IN,")
            Lc_sb.Append(" COUNT(DISTINCT(CASE WHEN (TYPEAREA = '4' OR  TYPEAREA = '2') THEN CONCAT(A.PID,DATE_SERV) END)) VISIT_OUT,")
            Lc_sb.Append(" COUNT(DISTINCT(CASE WHEN (TYPEAREA = '4' OR  TYPEAREA = '2') AND " & strDiagCut & "  THEN CONCAT(A.PID,DATE_SERV) END)) OP_VISIT_OUT")
            Lc_sb.Append(" FROM m_service A JOIN m_person B ON(A.PID = B.PID) ")
            Lc_sb.Append(" " & strWhere & " ")
            Lc_sb.Append(" GROUP BY A.HOSPCODE, substr(date_serv,1,6), substr(date_serv,1,4)")
            Lc_sb.Append(" ORDER BY DATE_SERV ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
    Public Function SELECT_NAME_CHRONIC(ByVal strString As String, ByVal strTHA As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DESC_E,DESC_T FROM l_chronic WHERE CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                If strTHA = "0" Then
                    strNAME = ds.Tables(0).Rows(0).Item("DESC_E").ToString
                Else
                    strNAME = ds.Tables(0).Rows(0).Item("DESC_T").ToString
                End If
            Else
                strNAME = "xxx"
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_INSCL_NHSO(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT MAIN_INSCL_T FROM l_nhso_right WHERE MAIN_INSCL = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("MAIN_INSCL_T").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_DISABTYPE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DISABTYPE_DESC FROM l_disabtype WHERE DISABTYPE_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("DISABTYPE_DESC").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_COMACTIVITY(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT COMACTIVITY_DESC FROM l_comactivity WHERE COMACTIVITY_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then

                strNAME = ds.Tables(0).Rows(0).Item("COMACTIVITY_DESC").ToString
            Else
                strNAME = "รหัสไม่ถูกต้อง"
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_ICF(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT ICF_DESC FROM l_icf WHERE ICF_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("ICF_DESC").ToString
            Else
                strNAME = ""
            End If

        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_QUALIFIER(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT QUALIFIER FROM l_icf WHERE ICF_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("QUALIFIER").ToString
            Else
                strNAME = ""
            End If

        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_QUALIFIER_DESC(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT QUALIFIER_DESC FROM l_qualifier WHERE QUALIFIER_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("QUALIFIER_DESC").ToString
            Else
                strNAME = ""
            End If

        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_DRUG_DOSE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DRUG_DOSE FROM d_drug_dose WHERE ROWID = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("DRUG_DOSE").ToString
            Else
                strNAME = ""
            End If

        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_DRUG_DOSE_CODE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DOSE_PREFIX FROM d_drug_dose WHERE ROWID = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("DOSE_PREFIX").ToString
            Else
                strNAME = ""
            End If

        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_DRUG_COST(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DRUG_COST FROM d_drug_amount WHERE DRUG_ID = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("DRUG_COST").ToString
            Else
                strNAME = ""
            End If

        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_DRUG_PRICE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DRUG_PRICE FROM d_drug_amount WHERE DRUG_ID = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("DRUG_PRICE").ToString
            Else
                strNAME = ""
            End If

        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_DRUG_LOT_DATE_OUT(ByVal strLot As String, ByVal strWithDraw As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DATE_OUT FROM d_drug_withdraw A JOIN d_withdraw_no B ON(A.WITHDRAW_NO = B.WITHDRAW_NO) WHERE LOT_NO = '" & strLot & "' AND A.WITHDRAW_NO = '" & strWithDraw & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = DateTime.ParseExact(ds.Tables(0).Rows(0).Item("DATE_OUT").ToString.Substring(0, 4) + 543 & ds.Tables(0).Rows(0).Item("DATE_OUT").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy")
            Else
                strNAME = ""
            End If

        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_DRUG_DOSE2(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DOSE_PRINT FROM d_drug_dose WHERE ROWID = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("DOSE_PRINT").ToString
            Else
                strNAME = ""
            End If

        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_POSITION(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT POSITION FROM m_provider WHERE PROVIDER = '" & strString & "'  AND STATUS_AF <> '8'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("POSITION").ToString
            Else
                strNAME = ""
            End If

        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_POSITION_ID(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT REGISTERNO FROM m_provider WHERE PROVIDER = '" & strString & "' AND STATUS_AF <> '8'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("REGISTERNO").ToString
            Else
                strNAME = ""
            End If

        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_SEX_PROVIDER(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT SEX FROM m_provider WHERE PROVIDER = '" & strString & "' AND STATUS_AF <> '8'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("SEX").ToString
            Else
                strNAME = "3"
            End If

        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function Select_EXPORT_TEXT(ByVal strField As String, ByVal strFile As String, ByVal strWhere As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb = New StringBuilder
        Try
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT " & strField & " ")
            Lc_sb.Append(" FROM " & strFile & " " & strWhere & " ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)

        Catch ex As Exception
        Finally
        End Try
        Return ds
    End Function
    Public Function SelectSQL(ByVal strSelect As String) As DataSet
        Dim ds As DataSet = Nothing
        Lc_sb = New StringBuilder
        Try
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("" & strSelect & "")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)

        Catch ex As Exception

        Finally

        End Try

        Return ds
    End Function
    Public Function SelectAll(ByVal tableName As String) As DataSet
        Dim ds As DataSet = Nothing
        Try
            Lc_sb = New StringBuilder
            Lc_sb.Append("Select * From " & tableName)
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, tableName, ds)
        Catch ex As Exception

        End Try
        Return ds
    End Function
    Public Function SELECT_NAME_LABRESULT(ByVal strString As String, ByVal strString2 As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT LAB_DESC FROM l_lab_result WHERE LAB_CODE = '" & strString & "' AND LAB_VALUE = '" & strString2 & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("LAB_DESC").ToString
            Else
                strNAME = ""
            End If

        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_LAB_RESULT_TYPE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT RESULT_TYPE FROM l_labprice WHERE LAB_CODE = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("RESULT_TYPE").ToString
            Else
                strNAME = ""
            End If

        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_LABFURESULT(ByVal strString As String, ByVal strString2 As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT LAB_DESC FROM l_lab_result A JOIN l_labprice B ON(A.LAB_CODE = B.LAB_CODE) WHERE LABFU_CODE = '" & strString & "' AND LAB_VALUE = '" & strString2 & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("LAB_DESC").ToString
            Else
                strNAME = ""
            End If

        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_PAT506(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT NAME FROM m_person WHERE PID = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = (ds.Tables(0).Rows(0).Item("NAME")).ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_OCCU506(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT OCCUPATIOn_506 FROM l_occupation_old WHERE OCCUPATION_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("OCCUPATIOn_506").ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_HCODE506(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT CONCAT(PROVINCE_ID,AMP,TAM,MOO) AS HSERV FROM l_hospitals WHERE HOSPCODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("HSERV").ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_CODE506(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT CODE_DESC FROM l_506 WHERE CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("CODE_DESC")
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_FATHER(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT FATHER_NAME FROM n_parent_name WHERE PID = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("FATHER_NAME").ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_MOTHER(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT MOTHER_NAME FROM n_parent_name WHERE PID = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("MOTHER_NAME").ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_COUPLE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT COUPLE_NAME FROM n_parent_name WHERE PID = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("COUPLE_NAME").ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_PID_TEL(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT IFNULL(TEL,'') AS TEL FROM n_parent_name WHERE PID = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("TEL").ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_STORE_TYPE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT STORE_NAME FROM d_drug_store WHERE ROWID = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("STORE_NAME").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_SCHOOL_TYPE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT SCHOOLTYPE_DESC FROM l_schooltype WHERE SCHOOLTYPE_CODE = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("SCHOOLTYPE_DESC").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_PID_CHRONIC(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT CHRONIC FROM m_chronic WHERE PID = '" & strString & "' AND TYPEDISH = '03' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    If i = 0 Then
                        strNAME = ds.Tables(0).Rows(i).Item("CHRONIC").ToString
                    Else
                        strNAME = strNAME & "," & ds.Tables(0).Rows(i).Item("CHRONIC").ToString
                    End If
                Next
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_PARENT(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT FATHER_NAME,MOTHER_NAME FROM n_parent_name WHERE PID = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("FATHER_NAME").ToString & "," & ds.Tables(0).Rows(0).Item("MOTHER_NAME").ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_SUB_FUNCTIONAL(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT FUNCTIONAL_DESC FROM l_functional_sub WHERE FUNCTIONAL_CODE = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = "-(" & ds.Tables(0).Rows(0).Item("FUNCTIONAL_DESC").ToString & ")"
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_DRUG_ACTION(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT INDICATION FROM l_drugprice WHERE DIDSTD = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("INDICATION").ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_DRUG_WARNING(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT WARNING FROM l_drugprice WHERE DIDSTD = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("WARNING").ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_DRUG_UNIT(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT UNIT_DESC FROM l_drugprice A JOIN l_unit B ON(A.UNIT = B.UNIT_CODE)  WHERE DIDSTD = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("UNIT_DESC").ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_DRUGDOSE_MAP(ByVal strString As String, ByVal strString2 As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT ROWID FROM d_drug_dose WHERE DRUG_ID = '" & strString & "' AND DRUG_DOSE = '" & strString2 & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("ROWID").ToString
            Else
                strNAME = ""
            End If

        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_HBA_RESULT(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT IFNULL(LABRESULT,'') AS LABRESULT FROM m_labfu WHERE LABTEST = '0531601' AND PID = '" & strString & "' ORDER BY DATE_SERV DESC LIMIT 1 ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("LABRESULT").ToString
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_HBA_DATE_SERV(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DATE_SERV FROM m_labfu WHERE LABTEST = '0531601' AND PID = '" & strString & "' ORDER BY DATE_SERV DESC LIMIT 1 ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("DATE_SERV").ToString
        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_NAME_BANK(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT CONCAT(BANK,' (',BANK_NO,')') AS BANK FROM acc_bank WHERE ROWID = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("BANK").ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_CSMBS(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT CSMBS FROM l_procedprice WHERE PROCEDCODE = '" & strString & "'  ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("CSMBS").ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_CSMBS_NHSO(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT NAME FROM l_nhso_sev WHERE CODE = '" & strString & "' AND MAININSCL = 'OFC' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("NAME").ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_LABEl_nation(ByVal strNATION As String, ByVal strTYPE As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DETAIl_nation FROM d_drug_dose2 WHERE NATION = '" & strNATION & "' AND DATACODE =   '" & strTYPE & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("DETAIl_nation").ToString & ": "
            Else
                strNAME = strTYPE & ": "
            End If

        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_LABEl_nation_UNIT(ByVal strNATION As String, ByVal strTYPE As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DETAIl_nation FROM d_drug_dose2 WHERE NATION = '" & strNATION & "' AND DETAIL =   '" & strTYPE & "' AND TYPEDATA =   '4'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("DETAIl_nation").ToString
            Else
                strNAME = strTYPE
            End If

        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_LABEl_nation2(ByVal strNATION As String, ByVal strTYPE As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DETAIl_nation FROM d_drug_dose2 WHERE NATION = '" & strNATION & "' AND DETAIL = '" & strTYPE & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("DETAIl_nation").ToString
            Else
                strNAME = strTYPE
            End If
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_MYPCUCARE(ByVal strHCODE As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT IFNULL(MYPCUCARE,'') AS MYPCUCARE FROM l_confighcode WHERE HOSPCODE = '" & strHCODE & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("MYPCUCARE").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function MySQL_Sysdate_add(ByVal str As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            'สำหรับ MySql
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT DATE_ADD(now(), INTERVAL -" & str & " MINUTE) AS DATENOW ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("DATENOW")
            strNAME = CDate(strNAME).ToString("yyyyMMddHHmmss")
        Catch ex As Exception
        Finally
        End Try
        Return strNAME
    End Function
    Public Function SELECT_TMT_CODE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim NAMEUSERID As String = ""
        Dim tmpNAME As String = ""
        Dim tmpLNAME As String = ""
        Lc_sb = New StringBuilder
        strString = Trim(strString.Replace(" ", "")).ToString
        'strString = Encode(strString)
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT TMTCODE FROM l_drugprice WHERE DIDSTD = '" & strString & "' AND IFNULL(TMTCODE,'') <> '' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                NAMEUSERID = ds.Tables(0).Rows(0).Item("TMTCODE")
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString, "", MessageBoxButtons.OK)
        End Try

        Return NAMEUSERID
    End Function
    Public Function SELECT_DRUG_CAT_CODE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim NAMEUSERID As String = ""
        Dim tmpNAME As String = ""
        Dim tmpLNAME As String = ""
        Lc_sb = New StringBuilder
        strString = Trim(strString.Replace(" ", "")).ToString
        'strString = Encode(strString)
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT IF(IFNULL(HOSPDRUGCODE,'') = '',DIDSTD,HOSPDRUGCODE) AS HOSPDRUGCODE FROM l_drugprice WHERE DIDSTD = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                NAMEUSERID = ds.Tables(0).Rows(0).Item("HOSPDRUGCODE")
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString, "", MessageBoxButtons.OK)
        End Try

        Return NAMEUSERID
    End Function
    Public Function SELECT_CSMBS_CODE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim NAMEUSERID As String = ""
        Dim tmpNAME As String = ""
        Dim tmpLNAME As String = ""
        Lc_sb = New StringBuilder
        strString = Trim(strString.Replace(" ", "")).ToString
        'strString = Encode(strString)
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT CSMBS FROM l_procedprice WHERE PROCEDCODE = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                NAMEUSERID = ds.Tables(0).Rows(0).Item("CSMBS")
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString, "", MessageBoxButtons.OK)
        End Try

        Return NAMEUSERID
    End Function
    Public Function SELECT_PROCED_CHARGEITEM(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim NAMEUSERID As String = ""
        Dim tmpNAME As String = ""
        Dim tmpLNAME As String = ""
        Lc_sb = New StringBuilder
        strString = Trim(strString.Replace(" ", "")).ToString
        'strString = Encode(strString)
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT CHARGEITEM FROM l_procedprice WHERE PROCEDCODE = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                NAMEUSERID = ds.Tables(0).Rows(0).Item("CHARGEITEM")
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString, "", MessageBoxButtons.OK)
        End Try

        Return NAMEUSERID
    End Function
    Public Function SELECT_NAME_SSS_STATION(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT HMAIN FROM l_sso_station WHERE STATION = '" & strString & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("HMAIN").ToString
            Else
                strNAME = ""
            End If

        Catch ex As Exception

        End Try

        Return strNAME
    End Function
    Public Function SELECT_VERCODE(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim NAMEUSERID As String = ""
        Dim tmpNAME As String = ""
        Dim tmpLNAME As String = ""
        Lc_sb = New StringBuilder
        strString = Trim(strString.Replace(" ", "")).ToString
        'strString = Encode(strString)
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT VERCODE FROM m_ofc_vercode WHERE SEQ = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                NAMEUSERID = ds.Tables(0).Rows(0).Item("VERCODE")
            Else
                NAMEUSERID = ""
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString, "", MessageBoxButtons.OK)
        End Try

        Return NAMEUSERID
    End Function
    Public Function SELECT_HID_PID(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim NAMEUSERID As String = ""


        Lc_sb = New StringBuilder

        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT HID FROM m_person WHERE PID = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                NAMEUSERID = ds.Tables(0).Rows(0).Item("HID")
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString, "", MessageBoxButtons.OK)
        End Try

        Return NAMEUSERID
    End Function
    Public Function SELECT_NAME_CLINIC(ByVal strHCODE As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT CLINIC_SUB_DESC FROM l_clinic_hosp WHERE CLINIC_CODE = '" & strHCODE & "'")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            If ds.Tables(0).Rows.Count > 0 Then
                strNAME = ds.Tables(0).Rows(0).Item("CLINIC_SUB_DESC").ToString
            Else
                strNAME = ""
            End If
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_PRENAME_HOS(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT PRENAME_STD_CODE FROM l_mypcu_prename WHERE PRENAME_CODE = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("PRENAME_STD_CODE").ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
    Public Function SELECT_NAME_MSTATUS(ByVal strString As String) As String
        Dim ds As DataSet = Nothing
        Dim strNAME As String = ""
        Lc_sb = New StringBuilder
        Try
            Lc_sb.Remove(0, Lc_sb.Length())
            Lc_sb.Append("SELECT MSTATUS_DESC FROM l_mypcu_mstatus WHERE MSTATUS_CODE = '" & strString & "' ")
            Lc_SQL = Lc_sb.ToString
            ds = GetDataAdp(Lc_SQL, "Table1", ds)
            strNAME = ds.Tables(0).Rows(0).Item("MSTATUS_DESC").ToString
        Catch ex As Exception

        End Try
        Return strNAME
    End Function
End Class

