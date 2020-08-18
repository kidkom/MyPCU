Module ModVariable
    ' สำหรับ Massage ต่าง


    ' สำหรับ Login
    Public vColor As String = ""
    Public vClinic As String = ""
    Public ConfigUpdate As String = ""
    Public vProgram As String = ""
    Public vVersionName As String = ""
    Public vVersionCODE As String = ""
    Public vHcode As String = ""
    Public vHname As String = ""
    Public vHmain As String = ""
    Public vHmainSSS As String = ""
    Public vCUP_PROVINCE As String = ""
    Public vProvince As String = ""
    Public pLatitude As String = ""
    Public pLongitude As String = ""
    Public dDrugStore As String = ""
    Public dDrugLabel As String = ""
    Public vTEL As String = ""
    Public vPRINTCARD As String = ""
    Public vHNPID As String = ""
    Public sBILL As String = ""
    Public vGFR As String = ""
    Public vSdx As String = ""
    Public vDIAGNOSIS As String = ""
    Public vLabelNation As String = ""
    Public vExam As String = ""
    Public vDiagWord As String = ""
    Public vCSMBS As String = ""
    Public vDental As String = ""
    Public vMessageDatetime As String = ""
    Public vMessageStatus As String = ""
    Public vImage As String = ""
    Public vDTX1 As String = ""
    Public vDTX2 As String = ""
    Public vAutoBkuptime As String = ""
    Public vLang As String = ""
    Public vPicPer As String = ""
    Public vUSERID As String = ""
    Public vAdmin As Boolean = False
    Public vPROVIDER_ID As String = ""
    Public vNAME_USER As String = ""
    Public vSEX_PRO As String = ""
    Public vUserCID As String = ""
    Public vDrugStore As String = ""
    Public vACC As String = ""
    Public vICD10TH As String = ""
    Public vImport43 As String = ""
    Public vICD10 As String = ""
    Public vICD10TM As String = ""
    Public vICD10TMD As String = ""
    Public vPSEARCH As String = ""
    Public vICD9TH As String = ""
    Public vICD9 As String = ""
    Public vICD9TM As String = ""
    Public vICD9TMD As String = ""
    Public vICD9DENT As String = ""
    Public vICD9CHINA As String = ""

    Public vINTIME As String = ""
    Public vOUTTIME As String = ""
    Public ICD10_1 As String = ""
    Public ICD10_2 As String = ""
    Public ICD10_3 As String = ""
    Public ICD10_4 As String = ""
    Public ICD10_5 As String = ""
    Public vICD10_1 As String = ""
    Public vICD10_2 As String = ""
    Public vICD10_3 As String = ""
    Public vICD10_4 As String = ""
    Public vICD10_5 As String = ""
    Public vICD10OP As String = ""
    Public vICD10PP_1 As String = ""
    Public vICD10PP_2 As String = ""
    Public vICD10PP_3 As String = ""
    Public vICD10PP_4 As String = ""
    Public vICD10PP_5 As String = ""
    Public vICD10PP As String = ""
    Public vFolder As String = ""
    Public vTmpHcode As String = ""
    Public vVersion As String = ""
    Public vHoliday As String = ""
    Public vfgCID As String = ""
    Public ckType2 As String = ""
    Public pPID As String = ""
    Public hHID As String = ""

    'เกี่ยวกับการ import data 
    Public iUTF8 As String = ""
    Public iHeadField As String = ""

    '********************************Print

    Public Print1 As String = ""
    Public Width1 As String = ""
    Public Height1 As String = ""
    Public MarginTop1 As String = ""
    Public MarginBottom1 As String = ""
    Public MarginLeft1 As String = ""
    Public MarginRight1 As String = ""
    Public PrintView1 As String = ""

    Public Print2 As String = ""
    Public Width2 As String = ""
    Public Height2 As String = ""
    Public MarginTop2 As String = ""
    Public MarginBottom2 As String = ""
    Public MarginLeft2 As String = ""
    Public MarginRight2 As String = ""
    Public PrintView2 As String = ""
    Public PicHome As String = ""
    Public PicPer As String = ""
    Public PicProvider As String = ""
    Public vProviderPic As String = ""
    Public vPIDHN As String = ""
    Public vSERVER As String = ""
    Public vConfigOnline As String = ""
    Public vCidImage As String = ""
    '********************************ตัวแปร Clinic
    Public vClinicSelect As String = ""


    '********************************ตัวแปร smart card
    Public iCardConnect As Boolean = False
    Public smTitle As String = ""
    Public smFname As String = ""
    Public smLname As String = ""
    Public smSex As String = ""
    Public smDOB As String = ""


    '*******PROVIDER
    Public vPvdROWID As String = ""
    Public vUserSelectID As String = ""
    Public vUserSelectCID As String = ""

    '*******HOME
    Public vHomeHID As String = ""
    Public hLatitude As String = ""
    Public hLongitude As String = ""
    Public hHouseName As String = ""
    Public hHOUSE As String = ""
    Public hVILLAGE As String = ""
    Public hVILLAGE_NAME As String = ""
    Public hTAMBON As String = ""
    Public hAMPUR As String = ""
    Public hCHANGWAT As String = ""
    Public vLatitude As String = ""
    Public vLongitude As String = ""

    Public hTOILET As String = ""
    Public hWATER As String = ""
    Public hWATERTYPE As String = ""
    Public hGARBAGE As String = ""
    Public hHOUSING As String = ""
    Public hDURABILITY As String = ""
    Public hCLEANLINESS As String = ""
    Public hVENTILATION As String = ""
    Public hLIGHT As String = ""
    Public hWATERTM As String = ""
    Public hMFOOD As String = ""
    Public hBCONTROL As String = ""
    Public hACONTROL As String = ""
    Public hCHEMICAL As String = ""

    '*******PROCED
    Public vProcedROWID As String = ""
    Public vProcedAdd As String = ""
    Public vProcedCode As String = ""


    '*******PERSON SEARCH
    Public vSearchPID As String = ""
    Public vSearchCID As String = ""
    Public vSearchName As String = ""

    '*******CHRONIC 

    Public vChonicPID As String = ""
    Public vChronicCode As String = ""
    Public vChronicRowID As String = ""

    '********VACCINE*****
    Public vEpiPID As String = ""
    Public vVaccineRowID As String = ""

    '********NUTRITION*****
    Public vNutritionPID As String = ""
    Public vNutritionRowID As String = ""


    '********SERVICE********
    Public vQueueSEQ As String = ""

    '********REFERIN********
    Public vReferinType As String = ""
    Public vReferinHosp As String = ""
    Public vReferinCause As String = ""
    Public vReferinNo As String = ""
    Public vReferinDateExpire As String = ""

    '********สิทธิ********
    Public vQinscl As String = ""

End Module
