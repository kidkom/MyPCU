Imports clsdataBus = MyPCU.ClsBusiness
Imports System.DateTime
Imports System.Globalization
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Module ModEnCrypt
    Public Function Encode(ByVal strString As String) As String
        Dim enc As New System.Text.UnicodeEncoding
        Dim buffer As Byte() = enc.GetBytes(strString)
        Encode = Convert.ToBase64String(buffer)

    End Function
    Public Function Decode(ByVal strString As String) As String
        Dim enc As New System.Text.UnicodeEncoding
        Dim buffer As Byte() = Convert.FromBase64String(strString)
        Decode = enc.GetString(buffer)
    End Function
    Public Function Decrypt(ByVal data() As Byte) As Byte()
        Dim decrypt_data As Byte() = New Byte(data.Length - 1) {}
        For j As Integer = 0 To data.Length - 1
            If j = data.Length - 1 Then
                If j Mod 2 = 0 Then
                    decrypt_data((data.Length - 1) - j) = data(j)
                Else
                    decrypt_data((data.Length - 1) - j + 1) = data(j)
                End If
            Else
                If j Mod 2 = 0 Then
                    decrypt_data((data.Length - 1) - j - 1) = data(j)
                Else
                    decrypt_data((data.Length - 1) - j + 1) = data(j)
                End If
            End If
        Next
        Return decrypt_data
    End Function
    Public Function CheckCID(ByVal strString As String) As Boolean
        Dim Sum As Integer = 0
        Sum = 0
        strString = Trim(strString.Replace("_", ""))
        strString = Trim(strString.Replace(" ", ""))
        If strString = "" Then
            CheckCID = True
            Exit Function
        End If
        For Count = 1 To 12
            Sum = Sum + Val(Mid(strString, Count, 1)) * (14 - Count)
        Next
        If Microsoft.VisualBasic.Right(strString, 1) = Microsoft.VisualBasic.Right(Str(11 - (Sum Mod 11)), 1) Then
            CheckCID = True
        Else
            CheckCID = False
        End If
        CheckCID = CheckCID
    End Function
    Public Function CheckDate(ByVal strString As String) As Boolean

        CheckDate = IsDate(strString)
    End Function
    Public Function CheckDateToday(ByVal strString As String) As Boolean
        If strString > clsdataBus.Lc_Business.MySQL_SysdateToday.ToString Then
            CheckDateToday = False
        Else
            CheckDateToday = True
        End If
        CheckDateToday = CheckDateToday
    End Function
    Public Function CheckDateExpire(ByVal strString As String) As Boolean
        If strString <= clsdataBus.Lc_Business.MySQL_SysdateToday.ToString Then
            CheckDateExpire = False
        Else
            CheckDateExpire = True
        End If
        CheckDateExpire = CheckDateExpire
    End Function
    Public Function CheckHOSP(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_hospitals", " WHERE HOSPCODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckHOSP = True
        Else
            CheckHOSP = False
        End If
    End Function
    Public Function CheckOCCUPATION(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_occupation", " WHERE OCCUPATION_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckOCCUPATION = True
        Else
            CheckOCCUPATION = False
        End If

    End Function
    Public Function CheckOCCUPATION_OLD(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_occupation_old", " WHERE OCCUPATION_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckOCCUPATION_OLD = True
        Else
            CheckOCCUPATION_OLD = False
        End If

    End Function
    Public Function CheckUnitDrug(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_unit", " WHERE UNIT_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckUnitDrug = True
        Else
            CheckUnitDrug = False
        End If

    End Function
    Public Function CheckPRENAME(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_mypcu_prename", " WHERE PRENAME_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckPRENAME = True
        Else
            CheckPRENAME = False
        End If

    End Function
    Public Function CheckCILINIC(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("CLINIC_CODE", " WHERE CLINIC_CODE = '" & strString & "' AND STATUS = '1'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckCILINIC = True
        Else
            CheckCILINIC = False
        End If

    End Function
    Public Function CheckNATION(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_nation", " WHERE NATION_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckNATION = True
        Else
            CheckNATION = False
        End If

    End Function
    Public Function CheckRELIGION(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_religion", " WHERE RELIGION_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckRELIGION = True
        Else
            CheckRELIGION = False
        End If
    End Function
    Public Function CheckEDUCATION(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_education", " WHERE EDUCATION_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckEDUCATION = True
        Else
            CheckEDUCATION = False
        End If
    End Function
    Public Function CheckTYPEAREA(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_typearea", " WHERE TYPEAREA_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckTYPEAREA = True
        Else
            CheckTYPEAREA = False
        End If
    End Function
    Public Function CheckLABOR(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_labor", " WHERE LABOR_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckLABOR = True
        Else
            CheckLABOR = False
        End If
    End Function
    Public Function CheckCOUNCIL(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_council", " WHERE COUNCIL_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckCOUNCIL = True
        Else
            CheckCOUNCIL = False
        End If
    End Function
    Public Function CheckPROVIDERTYPE(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_providertype_hosp", " WHERE PROVIDER_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckPROVIDERTYPE = True
        Else
            CheckPROVIDERTYPE = False
        End If
    End Function
    Public Function CheckCHANGWAT(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_area A INNER JOIN l_catm B ON(A.PROVINCE_ID = B.PROVINCE_ID)", " WHERE A.PROVINCE_ID = '" & strString & "' GROUP BY A.PROVINCE_ID")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckCHANGWAT = True
        Else
            CheckCHANGWAT = False
        End If
    End Function
    Public Function CheckAMPUR(ByVal strString As String, ByVal strString2 As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_area A INNER JOIN l_catm B ON(A.PROVINCE_ID = B.PROVINCE_ID AND A.AMPHUR_ID = B.AMPHUR_ID)", " WHERE A.PROVINCE_ID = '" & strString & "' AND B.AMPHUR_ID = '" & strString2 & "' GROUP BY A.AMPHUR_ID")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckAMPUR = True
        Else
            CheckAMPUR = False
        End If
    End Function
    Public Function CheckTAMBON(ByVal strString As String, ByVal strString2 As String, ByVal strString3 As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_area A INNER JOIN l_cat B ON(A.PROVINCE_ID = B.PROVINCE_ID AND A.AMPHUR_ID = B.AMPHUR_ID AND A.TAMBOL_ID = B.TAMBOL_ID)", " WHERE A.PROVINCE_ID = '" & strString & "' AND B.AMPHUR_ID = '" & strString2 & "' AND A.TAMBOL_ID = '" & strString3 & "' GROUP BY A.TAMBOL_ID")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckTAMBON = True
        Else
            CheckTAMBON = False
        End If
    End Function
    Public Function CheckCHANGWat_ALL(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_catm", " WHERE PROVINCE_ID = '" & strString & "' GROUP BY PROVINCE_ID")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckCHANGWat_ALL = True
        Else
            CheckCHANGWat_ALL = False
        End If
    End Function
    Public Function CheckAMPUR_ALL(ByVal strString As String, ByVal strString2 As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_catm", " WHERE PROVINCE_ID = '" & strString & "' AND AMPHUR_ID = '" & strString2 & "' GROUP BY AMPHUR_ID")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckAMPUR_ALL = True
        Else
            CheckAMPUR_ALL = False
        End If
    End Function
    Public Function CheckTAMBON_ALL(ByVal strString As String, ByVal strString2 As String, ByVal strString3 As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_cat", " WHERE PROVINCE_ID = '" & strString & "' AND AMPHUR_ID = '" & strString2 & "' AND TAMBOL_ID = '" & strString3 & "' GROUP BY TAMBOL_ID")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckTAMBON_ALL = True
        Else
            CheckTAMBON_ALL = False
        End If
    End Function
    Public Function CheckINSTYPE_NEW(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_instype_new", " WHERE INSTYPE_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckINSTYPE_NEW = True
        Else
            CheckINSTYPE_NEW = False
        End If
    End Function
    Public Function CheckINSTYPE_OLD(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_instype_old", " WHERE INSTYPE_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckINSTYPE_OLD = True
        Else
            CheckINSTYPE_OLD = False
        End If
    End Function
    Public Function CheckAETYPE(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_aetype", " WHERE AETYPE_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckAETYPE = True
        Else
            CheckAETYPE = False
        End If
    End Function
    Public Function CheckAEPLACE(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_aeplace", " WHERE AEPLACE_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckAEPLACE = True
        Else
            CheckAEPLACE = False
        End If
    End Function
    Public Function CheckTYPEIN_AE(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_typein_ae", " WHERE TYPEIN_AE_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckTYPEIN_AE = True
        Else
            CheckTYPEIN_AE = False
        End If
    End Function
    Public Function CheckVEHICLE(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_vehicle", " WHERE VEHICLE_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckVEHICLE = True
        Else
            CheckVEHICLE = False
        End If
    End Function
    Public Function CheckURGENCY(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_urgency", " WHERE URGENCY_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckURGENCY = True
        Else
            CheckURGENCY = False
        End If
    End Function
    Public Function CheckCOMA_EYE(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_coma_eye", " WHERE COMA_EYE_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckCOMA_EYE = True
        Else
            CheckCOMA_EYE = False
        End If
    End Function
    Public Function CheckCOMA_SPEAK(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_coma_speak", " WHERE COMA_SPEAK_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckCOMA_SPEAK = True
        Else
            CheckCOMA_SPEAK = False
        End If
    End Function
    Public Function CheckCOMA_MOVEMENT(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_coma_movement", " WHERE COMA_MOVEMENT_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckCOMA_MOVEMENT = True
        Else
            CheckCOMA_MOVEMENT = False
        End If
    End Function
    Public Function CheckTYPEIN(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_typein", " WHERE TYPEIN_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckTYPEIN = True
        Else
            CheckTYPEIN = False
        End If
    End Function
    Public Function CheckPROVIDER(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("m_provider", " WHERE PROVIDER = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckPROVIDER = True
        Else
            CheckPROVIDER = False
        End If
    End Function
    Public Function CheckUNIT(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_unit", " WHERE UNIT_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckUNIT = True
        Else
            CheckUNIT = False
        End If
    End Function
    Public Function CheckCHARGEITEM(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_chargeitem", " WHERE CHARGEITEm_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckCHARGEITEM = True
        Else
            CheckCHARGEITEM = False
        End If
    End Function
    Public Function CheckTYPEOUT(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_typeout", " WHERE TYPEOUT_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckTYPEOUT = True
        Else
            CheckTYPEOUT = False
        End If
    End Function
    Public Function CheckCAUSEOUT(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_causeout", " WHERE CAUSEOUT_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckCAUSEOUT = True
        Else
            CheckCAUSEOUT = False
        End If
    End Function
    Public Function CheckVACCINETYPE(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_vaccinetype", " WHERE VACCINE_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckVACCINETYPE = True
        Else
            CheckVACCINETYPE = False
        End If
    End Function
    Public Function CheckFPTYPE(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_fptype", " WHERE FP_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckFPTYPE = True
        Else
            CheckFPTYPE = False
        End If
    End Function
    Public Function CheckANCNO(ByVal strString As String) As String

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_ancno", " WHERE " & strString & " >= WEEK_START AND " & strString & " <= WEEK_END ")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckANCNO = ds.Tables(0).Rows(0).Item("ANCNO")
        Else
            CheckANCNO = ""
        End If

        Return CheckANCNO
    End Function
    Public Function CheckBRESULT(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_bresult", " WHERE BRESULT_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckBRESULT = True
        Else
            CheckBRESULT = False
        End If
    End Function
    Public Function CheckCOMPLICATION(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_surveillance_comp", " WHERE CODE_NEW = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckCOMPLICATION = True
        Else
            CheckCOMPLICATION = False
        End If
    End Function
    Public Function CheckCORANISM(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_surveillance_orga", " WHERE CODE_NEW = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckCORANISM = True
        Else
            CheckCORANISM = False
        End If
    End Function
    Public Function CheckSCHOOLTYPE(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_schooltype", " WHERE SCHOOLTYPE_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckSCHOOLTYPE = True
        Else
            CheckSCHOOLTYPE = False
        End If
    End Function
    Public Function CheckCLASS(ByVal strString As String, ByVal strString2 As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_schooltype_class", " WHERE CLASS_CODE = '" & strString & "' AND SCHOOLTYPE_CODE = '" & strString2 & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckCLASS = True
        Else
            CheckCLASS = False
        End If
    End Function
    Public Function CheckClinic(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_clinic_hosp", " WHERE CLINIC_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckClinic = True
        Else
            CheckClinic = False
        End If
    End Function
    Public Function CheckTYPEDISCH(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_typedisch", " WHERE TYPEDISCH_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckTYPEDISCH = True
        Else
            CheckTYPEDISCH = False
        End If
    End Function
    Public Function CheckDISABTYPE(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_disabtype", " WHERE DISABTYPE_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckDISABTYPE = True
        Else
            CheckDISABTYPE = False
        End If
    End Function
    Public Function CheckLAB(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_labprice", " WHERE LAB_CODE = '" & strString & "' AND RESULT_TYPE = '1'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckLAB = True
        Else
            CheckLAB = False
        End If
    End Function
    Public Function CheckLAB2(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_labprice", " WHERE LAB_CODE = '" & strString & "' AND RESULT_TYPE = '2'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckLAB2 = True
        Else
            CheckLAB2 = False
        End If
    End Function
    Public Function CheckLABCODE(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_labprice", " WHERE LAB_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckLABCODE = True
        Else
            CheckLABCODE = False
        End If
    End Function
    Public Function CheckCOMACTIVITY(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_comactivity", " WHERE COMACTIVITY_CODE = '" & strString & "' AND STATUS = '1'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckCOMACTIVITY = True
        Else
            CheckCOMACTIVITY = False
        End If
    End Function
    Public Function CheckCOMSERVICE(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_comservice", " WHERE COMSERVICE_CODE = '" & strString & "' AND STATUS = '1'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckCOMSERVICE = True
        Else
            CheckCOMSERVICE = False
        End If
    End Function
    Public Function CheckPPSPECIAL(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_ppspecial", " WHERE PPSPECIAL_CODE = '" & strString & "' AND STATUS = '1'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckPPSPECIAL = True
        Else
            CheckPPSPECIAL = False
        End If
    End Function
    Public Function CheckRISKTYPE(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_risktype", " WHERE RISKTYPE_CODE = '" & strString & "' AND STATUS = '1'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckRISKTYPE = True
        Else
            CheckRISKTYPE = False
        End If
    End Function
    Public Function CheckVILLAGE(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_area ", " WHERE VILLAGE = '" & strString & "' ")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckVILLAGE = True
        Else
            CheckVILLAGE = False
        End If
    End Function
    Public Function CheckPERSON(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("m_person", " WHERE PID = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckPERSON = True
        Else
            CheckPERSON = False
        End If
    End Function
    Public Function CheckSURVILLANCE(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_surveillance", " WHERE CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckSURVILLANCE = True
        Else
            CheckSURVILLANCE = False
        End If
    End Function
    Public Function Check506(ByVal strString As String, ByVal strString2 As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_surveillance", " WHERE CODE_506 = '" & strString & "' AND CODE = '" & strString2 & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            Check506 = True
        Else
            Check506 = False
        End If
    End Function
    Public Function CheckREHAB(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_rehabcode", " WHERE REHABCODE_CODE = '" & strString & "' AND STATUS = '1'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckREHAB = True
        Else
            CheckREHAB = False
        End If
    End Function
    Public Function CheckICF(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_icf", " WHERE ICF_CODE = '" & strString & "' AND STATUS = '1' ")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckICF = True
        Else
            CheckICF = False
        End If
    End Function
    Public Function CheckFUNCTIONAL(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_functional_test", " WHERE FUNCTIONAL_CODE = '" & strString & "' AND STATUS = '1' ")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckFUNCTIONAL = True
        Else
            CheckFUNCTIONAL = False
        End If
    End Function
    Public Function CheckSYMPTOM(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_symptom", " WHERE SYMPTOm_CODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckSYMPTOM = True
        Else
            CheckSYMPTOM = False
        End If

    End Function
    Public Function CheckDRUG_DOSE(ByVal strString As String, ByVal strString2 As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("d_drug_dose", " WHERE DRUG_ID = '" & strString & "' AND ROWID = '" & strString2 & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckDRUG_DOSE = True
        Else
            CheckDRUG_DOSE = False
        End If

    End Function
    Public Function CheckPINGPONG1(ByVal strString1 As String, ByVal strString2 As String, ByVal strString3 As String) As Boolean
        Select Case strString3
            Case ">"
                If CDbl(strString1) > CDbl(strString2) Then
                    CheckPINGPONG1 = True
                End If
            Case ">="
                If CDbl(strString1) >= CDbl(strString2) Then
                    CheckPINGPONG1 = True
                End If
            Case "<"
                If CDbl(strString1) > CDbl(strString2) Then
                    CheckPINGPONG1 = True
                End If
            Case "<="
                If CDbl(strString1) <= CDbl(strString2) Then
                    CheckPINGPONG1 = True
                End If
        End Select
        CheckPINGPONG1 = CheckPINGPONG1
    End Function
    Public Function CheckPINGPONG2(ByVal strString1 As String, ByVal strString2 As String, ByVal strString3 As String, ByVal strString4 As String, ByVal strString5 As String, ByVal strString6 As String) As Boolean
        Select Case strString3
            Case ">"
                If CDbl(strString1) > CDbl(strString2) Then
                    CheckPINGPONG2 = True
                End If
            Case ">="
                If CDbl(strString1) >= CDbl(strString2) Then
                    CheckPINGPONG2 = True
                End If
            Case "<"
                If CDbl(strString1) > CDbl(strString2) Then
                    CheckPINGPONG2 = True
                End If
            Case "<="
                If CDbl(strString1) >= CDbl(strString2) Then
                    CheckPINGPONG2 = True
                End If
        End Select
        CheckPINGPONG2 = CheckPINGPONG2
    End Function
    Public Function Eval(ByVal command As String) As Object
        Dim MyProvider As New VBCodeProvider 'Create a new VB Code Compiler
        Dim cp As New CodeDom.Compiler.CompilerParameters     'Create a new Compiler parameter object.

        cp.GenerateExecutable = False        'Don't create an object on disk
        cp.GenerateInMemory = True           'But do create one in memory.

        'If cp.OutputAssembly is used with a VBCodeProvider, it seems to want to read before it is executed. 

        'See C# CodeBank example for explanation of why it was used.



        'the below is an empty VB.NET Project with a function that simply returns the value of our command parameter.

        Dim ClassName As String = "class" & Now.Ticks

        Dim TempModuleSource As String = "Imports System" & Environment.NewLine & _
                                         "Namespace ns " & Environment.NewLine & _
                                         "    Public Class " & ClassName & Environment.NewLine & _
                                         "        Public Shared Function Evaluate()" & Environment.NewLine & _
                                         "            Return (" & command & ")" & Environment.NewLine & _
                                         "        End Function" & Environment.NewLine & _
                                         "    End Class" & Environment.NewLine & _
                                         "End Namespace"

        'Create a compiler output results object and compile the source code.

        Dim cr As CodeDom.Compiler.CompilerResults = MyProvider.CompileAssemblyFromSource(cp, TempModuleSource)

        If cr.Errors.Count > 0 Then

            'If the expression passed is invalid or "", the compiler will generate errors.

            'Throw New ArgumentOutOfRangeException("Invalid Expression - please use something VB could evaluate")
            Return Nothing
        Else

            'Find our Evaluate method.
            Dim methInfo As Reflection.MethodInfo = cr.CompiledAssembly.GetType("ns." & ClassName).GetMethod("Evaluate")

            'Invoke it on nothing, so that we can get the return value
            Return methInfo.Invoke(methInfo, New Object() {})
        End If
    End Function
    Public Function NumberToThaiWord(ByVal InputNumber As Double) As String
        If InputNumber = 0 Then
            NumberToThaiWord = "ศูนย์บาทถ้วน"
            Return NumberToThaiWord
        End If

        Dim NewInputNumber As String
        NewInputNumber = InputNumber.ToString("###0.00")

        If CDbl(NewInputNumber) >= 10000000000000 Then
            NumberToThaiWord = ""
            Return NumberToThaiWord
        End If

        Dim tmpNumber(2) As String
        Dim FirstNumber As String
        Dim LastNumber As String

        tmpNumber = NewInputNumber.Split(CChar("."))
        FirstNumber = tmpNumber(0)
        LastNumber = tmpNumber(1)

        Dim nLength As Integer = 0
        nLength = CInt(FirstNumber.Length)

        Dim i As Integer
        Dim CNumber As Integer = 0
        Dim CNumberBak As Integer = 0
        Dim strNumber As String = ""
        Dim strPosition As String = ""
        Dim FinalWord As String = ""
        Dim CountPos As Integer = 0

        For i = nLength To 1 Step -1
            CNumberBak = CNumber
            CNumber = CInt(FirstNumber.Substring(CountPos, 1))

            If CNumber = 0 AndAlso i = 7 Then
                strPosition = "ล้าน"
            ElseIf CNumber = 0 Then
                strPosition = ""
            Else
                strPosition = PositionToText(i)
            End If

            If CNumber = 2 AndAlso strPosition = "สิบ" Then
                strNumber = "ยี่"
            ElseIf CNumber = 1 AndAlso strPosition = "สิบ" Then
                strNumber = ""
            ElseIf CNumber = 1 AndAlso strPosition = "ล้าน" AndAlso nLength >= 8 Then
                If CNumberBak = 0 Then
                    strNumber = "หนึ่ง"
                Else
                    strNumber = "เอ็ด"
                End If
            ElseIf CNumber = 1 AndAlso strPosition = "" AndAlso nLength > 1 Then
                strNumber = "เอ็ด"
            Else
                strNumber = NumberToText(CNumber)
            End If

            CountPos = CountPos + 1

            FinalWord = FinalWord & strNumber & strPosition
        Next

        CountPos = 0
        CNumberBak = 0
        nLength = CInt(LastNumber.Length)

        Dim Stang As String = ""
        Dim FinalStang As String = ""

        If CDbl(LastNumber) > 0.0 Then
            For i = nLength To 1 Step -1
                CNumberBak = CNumber
                CNumber = CInt(LastNumber.Substring(CountPos, 1))

                If CNumber = 1 AndAlso i = 2 Then
                    strPosition = "สิบ"
                ElseIf CNumber = 0 Then
                    strPosition = ""
                Else
                    strPosition = PositionToText(i)
                End If

                If CNumber = 2 AndAlso strPosition = "สิบ" Then
                    Stang = "ยี่"
                ElseIf CNumber = 1 AndAlso i = 2 Then
                    Stang = ""
                ElseIf CNumber = 1 AndAlso strPosition = "" AndAlso nLength > 1 Then
                    If CNumberBak = 0 Then
                        Stang = "หนึ่ง"
                    Else
                        Stang = "เอ็ด"
                    End If
                Else
                    Stang = NumberToText(CNumber)
                End If

                CountPos = CountPos + 1

                FinalStang = FinalStang & Stang & strPosition
            Next

            FinalStang = FinalStang & "สตางค์"
        Else
            FinalStang = ""
        End If

        Dim SubUnit As String
        If FinalStang = "" Then
            SubUnit = "บาทถ้วน"
        Else
            If CDbl(FirstNumber) <> 0 Then
                SubUnit = "บาท"
            Else
                SubUnit = ""
            End If
        End If

        NumberToThaiWord = FinalWord & SubUnit & FinalStang
    End Function

    Private Function NumberToText(ByVal CurrentNum As Integer) As String
        Dim _nText As String = ""

        Select Case CurrentNum
            Case 0
                _nText = ""
            Case 1
                _nText = "หนึ่ง"
            Case 2
                _nText = "สอง"
            Case 3
                _nText = "สาม"
            Case 4
                _nText = "สี่"
            Case 5
                _nText = "ห้า"
            Case 6
                _nText = "หก"
            Case 7
                _nText = "เจ็ด"
            Case 8
                _nText = "แปด"
            Case 9
                _nText = "เก้า"
        End Select

        NumberToText = _nText
    End Function

    Private Function PositionToText(ByVal CurrentPos As Integer) As String
        Dim _nPos As String = ""

        Select Case CurrentPos
            Case 0
                _nPos = ""
            Case 1
                _nPos = ""
            Case 2
                _nPos = "สิบ"
            Case 3
                _nPos = "ร้อย"
            Case 4
                _nPos = "พัน"
            Case 5
                _nPos = "หมื่น"
            Case 6
                _nPos = "แสน"
            Case 7
                _nPos = "ล้าน"
            Case 8
                _nPos = "สิบ"
            Case 9
                _nPos = "ร้อย"
            Case 10
                _nPos = "พัน"
            Case 11
                _nPos = "หมื่น"
            Case 12
                _nPos = "แสน"
            Case 13
                _nPos = "ล้าน"
        End Select

        PositionToText = _nPos
    End Function
    Public Function Thaidate_D_UPDATE(ByVal strString As String) As String
        Dim result As String = ""
        If strString = "" Then
            result = ""
        Else
            Try
                result = DateTime.ParseExact(strString.ToString.Substring(0, 4) + 543 & strString.ToString.Substring(4, 10), "yyyyMMddHHmmss", CultureInfo.CurrentCulture).ToString("d MMM yyyy HH:mm:ss")
            Catch ex As Exception
                result = ""
            End Try
        End If

        Return result
    End Function
    Public Function Thaidate(ByVal strString As String) As String
        Dim result As String = ""
        If strString = "" Then
            result = ""
        Else
            Try
                result = DateTime.ParseExact(strString.ToString.Substring(0, 4) + 543 & strString.ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy")
            Catch ex As Exception
                result = ""
            End Try
        End If

        Return result
    End Function
    Function hash_generator(ByVal hash_type As String, ByVal file_name As String)

        ' We declare the variable : hash
        Dim hash
        If hash_type.ToLower = "md5" Then
            ' Initializes a md5 hash object
            hash = MD5.Create
        ElseIf hash_type.ToLower = "sha1" Then
            ' Initializes a SHA-1 hash object
            hash = SHA1.Create()
        ElseIf hash_type.ToLower = "sha256" Then
            ' Initializes a SHA-256 hash object
            hash = SHA256.Create()
        Else
            MsgBox("Unknown type of hash : " & hash_type, MsgBoxStyle.Critical)
            Return False
        End If

        ' We declare a variable to be an array of bytes
        Dim hashValue() As Byte

        ' We create a FileStream for the file passed as a parameter
        Dim fileStream As FileStream = File.OpenRead(file_name)
        ' We position the cursor at the beginning of stream
        fileStream.Position = 0
        ' We calculate the hash of the file
        hashValue = hash.ComputeHash(fileStream)
        ' The array of bytes is converted into hexadecimal before it can be read easily
        Dim hash_hex = PrintByteArray(hashValue)

        ' We close the open file
        fileStream.Close()

        ' The hash is returned
        Return hash_hex

    End Function
    Public Function PrintByteArray(ByVal array() As Byte)

        Dim hex_value As String = ""

        ' We traverse the array of bytes
        Dim i As Integer
        For i = 0 To array.Length - 1

            ' We convert each byte in hexadecimal
            hex_value += array(i).ToString("X2")

        Next i

        ' We return the string in lowercase
        Return hex_value.ToLower

    End Function
    Function md5_hash(ByVal file_name As String)
        Return hash_generator("md5", file_name)
    End Function

    Function sha_1(ByVal file_name As String)
        Return hash_generator("sha1", file_name)
    End Function

    Function sha_256(ByVal file_name As String)
        Return hash_generator("sha256", file_name)
    End Function
    Public Function ThaidateEclaim(ByVal strString As String) As String
        Dim result As String = ""
        If strString = "" Then
            result = ""
        Else
            Try
                result = DateTime.ParseExact(strString.ToString.Substring(0, 4) & strString.ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy")
            Catch ex As Exception
                result = ""
            End Try
        End If

        Return result
    End Function
    Public Function CheckLabType(ByVal strString As String) As Boolean
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_labprice", " WHERE LAB_CODE = '" & strString & "' AND LAB_TYPE = '1' ")
        If ds.Tables(0).Rows.Count > 0 Then
            CheckLabType = True
        Else
            CheckLabType = False
        End If

    End Function

End Module

