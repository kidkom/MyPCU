Imports MySql.Data.MySqlClient
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsDataAcc3 = MyPCU.ClsDataAccess3
Imports clsdataBus = MyPCU.ClsBusiness
Imports clsdataBus3 = MyPCU.ClsBusiness3
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports clsbusent3 = MyPCU.ClsBusinessEntity3
Imports clsDataAcc4 = MyPCU.ClsDataAccess4
Imports clsdataBus4 = MyPCU.ClsBusiness4
Imports clsbusent4 = MyPCU.ClsBusinessEntity4
Imports System.IO
Imports System.Xml
Imports System.Net.Mail
Imports System.Net.NetworkInformation
Imports System.DateTime
Imports System.Globalization
Imports System.Text
Public Class frmSystemCheck
    Dim tmpDate1 As String = ""
    Dim tmpDate2 As String = ""
    Private Sub frmSystemCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tmpDate1 As String = ""
        Dim tmpDate2 As String = ""


        With ListView1
            .Columns.Add("การดำเนินการ", 405, HorizontalAlignment.Center)
        End With
        ListView1.View = View.Details
        ListView1.GridLines = False


        If vConfigOnline = "1" Then
            Conntest()
        Else
            Timer1.Enabled = True
        End If

        Conntest5()


    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Timer1.Interval = 100
        Timer1.Enabled = False
        SplashScreenManager1.ShowWaitForm()

        Dim ds As DataSet
        Dim tmpNowSex As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)
        Try
            ds = clsdataBus.Lc_Business.SELECT_TABLE("PID", " m_person ", "WHERE (DATE_FORMAT(SYSDATE(),'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(SYSDATE(),'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 15 AND (PRENAME = '001' OR PRENAME = '002') ")
            If ds.Tables(0).Rows.Count > 0 Then
                Try
                    clsbusent.Lc_BusinessEntity.Updatem_table("m_person", " PRENAME = '003',D_UPDATE = '" & tmpNowSex & "',USER_REC = '" & vUSERID & "'", " (DATE_FORMAT(SYSDATE(),'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(SYSDATE(),'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 15 AND PRENAME = '001' AND STATUS_AF = '1' ")
                    clsbusent.Lc_BusinessEntity.Updatem_table("m_person", " PRENAME = '004',D_UPDATE = '" & tmpNowSex & "',USER_REC = '" & vUSERID & "'", " (DATE_FORMAT(SYSDATE(),'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(SYSDATE(),'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 15 AND PRENAME = '002' AND STATUS_AF = '1' ")
                    clsbusent.Lc_BusinessEntity.Updatem_table("m_home", " VILLANAME = '' ", " VILLAGE <> '00' ")

                    CheckBox1.Checked = True
                    CheckBox1.Text = "ปรับปรุงคำนำหน้าเด็กที่อายุ 15 ปีบริบูรณ์ จำนวน " & ds.Tables(0).Rows.Count & " ราย"
                    CheckBox1.ForeColor = Color.Green
                Catch ex As Exception
                    MessageBox.Show("ไม่สามารถดำเนินการปรับปรุงคำนำหน้าได้ เนื่องจากมีข้อมูลวันเดือนปีเกิดไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try

            Else
                CheckBox1.Checked = True
                CheckBox1.Text = "ปรับปรุงคำนำหน้าเด็กที่อายุ 15 ปีบริบูรณ์ จำนวน 0 ราย"
                CheckBox1.ForeColor = Color.Green
            End If

        Catch ex As Exception
            MessageBox.Show("ไม่สามารถดำเนินการปรับปรุงคำนำหน้าได้ เนื่องจากมีข้อมูลวันเดือนปีเกิดไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        clsbusent.Lc_BusinessEntity.Updatem_table("m_person", " HID = '' ,D_UPDATE = '" & tmpNowSex & "',USER_REC = '" & vUSERID & "'", " TYPEAREA = '4' AND IFNULL(HID,'') <> '' ")
        clsbusent.Lc_BusinessEntity.Updatem_table("m_person", " MSTATUS = '6' ,D_UPDATE = '" & tmpNowSex & "',USER_REC = '" & vUSERID & "'", " PRENAME LIKE '8%' OR PRENAME LIKE '9%' ")
        clsbusent.Lc_BusinessEntity.Delete_table("n_service_remark", " WHERE IFNULL(PID,'') = '' ")
        clsbusent.Lc_BusinessEntity.Delete_table("n_service_remark", " WHERE IFNULL(SEQ,'') = '' ")

        clsbusent.Lc_BusinessEntity.Delete_table("m_card", " WHERE IFNULL(PID,'') = ''   ")
        clsbusent.Lc_BusinessEntity.Delete_table("m_prenatal", " WHERE IFNULL(PID,'') = ''   ")
        clsbusent.Lc_BusinessEntity.Delete_table("m_person", " WHERE IFNULL(CID,'') = ''   ")
        clsbusent.Lc_BusinessEntity.Delete_table("m_women", " WHERE IFNULL(PID,'') = ''   ")
        clsbusent.Lc_BusinessEntity.Delete_table("m_anc", " WHERE IFNULL(PID,'') = ''   ")



        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("*", " l_table_lookup ", " WHERE L_TABLE = 'l_table_lookup' ")
        If ds2.Tables(0).Rows.Count = 0 Then
            clsbusent.Lc_BusinessEntity.Insertm_table("l_table_lookup (L_TABLE,STATUS,D_UPDATE)", "'l_table_lookup','','20141001'")

        End If

        EPI1()
        EPI2()
        EPI3()
        EPI4()
        Conntest()
        CheckBox2.Checked = True
        CheckBox2.ForeColor = Color.Green
        Conntest4()
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub EPI1()
        Dim ds As New DataSet
        Dim ds2 As New DataSet

        tmpDate2 = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 4)

        Dim tmpShow2 As String = ""
        tmpShow2 = " AND ((DATE_FORMAT(" & tmpDate2 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate2 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 1) "

        ds = clsdataBus.Lc_Business.SELECT_TABLE("A.HOSPCODE,A.PID," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '010' THEN DATE_SERV END),'') AS BCG," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '081' THEN DATE_SERV END),'') AS OPV1," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '041' THEN DATE_SERV END),'') AS HB," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '082' THEN DATE_SERV END),'') AS OPV2," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '083' THEN DATE_SERV END),'') AS OPV3," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '031' OR VACCINETYPE = '091' THEN DATE_SERV END),'') AS DTP1," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '032' OR VACCINETYPE = '092' THEN DATE_SERV END),'') AS DTP2," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '033' OR VACCINETYPE = '093' THEN DATE_SERV END),'') AS DTP3," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '091' THEN DATE_SERV END),'') AS HBV1," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '042' OR VACCINETYPE = '092' THEN DATE_SERV END),'') AS HBV2," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '043' OR VACCINETYPE = '093' THEN DATE_SERV END),'') AS HBV3," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '061' THEN DATE_SERV END),'') AS MMR," _
                                                 & "MAX(IFNULL(B.D_UPDATE,'0')) D_UPDATE" _
                                                 & "", " m_person A LEFT JOIN m_epi B ON(A.PID = B.PID) JOIN m_home C ON(A.HID = C.HID) ", _
                                                 " WHERE (A.STATUS_AF <> '8' AND IFNULL(B.STATUS_AF,'') = '1') AND IFNULL(C.VILLAGE,'') <> '' AND DISCHARGE = '9' AND TYPEAREA IN('1','3','5')  " _
                                                 & "" & tmpShow2 & " GROUP BY A.PID ORDER BY A.PID ")


        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Dim HCODE As String = ds.Tables(0).Rows(i).Item("HOSPCODE")
                Dim PID As String = ds.Tables(0).Rows(i).Item("PID")
                Dim BCG As String = ds.Tables(0).Rows(i).Item("BCG")
                Dim HB As String = ds.Tables(0).Rows(i).Item("HB")
                Dim OPV1 As String = ds.Tables(0).Rows(i).Item("OPV1")
                Dim OPV2 As String = ds.Tables(0).Rows(i).Item("OPV2")
                Dim OPV3 As String = ds.Tables(0).Rows(i).Item("OPV3")
                Dim DTP1 As String = ds.Tables(0).Rows(i).Item("DTP1")
                Dim DTP2 As String = ds.Tables(0).Rows(i).Item("DTP2")
                Dim DTP3 As String = ds.Tables(0).Rows(i).Item("DTP3")
                Dim HBV1 As String = ds.Tables(0).Rows(i).Item("HBV1")
                Dim HBV2 As String = ds.Tables(0).Rows(i).Item("HBV2")
                Dim HBV3 As String = ds.Tables(0).Rows(i).Item("HBV3")
                Dim MMR As String = ds.Tables(0).Rows(i).Item("MMR")
                Dim D_UPDATE As String = ds.Tables(0).Rows(i).Item("D_UPDATE")


                ds2 = clsdataBus.Lc_Business.SELECT_TABLE("PID", "r_epi_1", " WHERE PID  = '" & PID & "'")
                If ds2.Tables(0).Rows.Count > 0 Then
                    clsbusent.Lc_BusinessEntity.Updatem_table("r_epi_1", "BCG = '" & BCG & "',HB = '" & HB & "',OPV1 = '" & OPV1 & "',OPV2 = '" & OPV2 & "',OPV3 = '" & OPV3 & "',DTP1 = '" & DTP1 & "',DTP2 = '" & DTP2 & "',DTP3 = '" & DTP3 & "',HBV1 = '" & HBV1 & "',HBV2 = '" & HBV2 & "',HBV3 = '" & HBV3 & "',MMR = '" & MMR & "',D_UPDATE = '" & D_UPDATE & "'", " PID  = '" & PID & "'")
                Else
                    clsbusent.Lc_BusinessEntity.Insertm_table("r_epi_1 (HCODE,PID,BCG,HB,OPV1,OPV2,OPV3,DTP1,DTP2,DTP3,HBV1,HBV2,HBV3,MMR,D_UPDATE)", "'" & HCODE & "','" & PID & "','" & HB & "','" & BCG & "','" & OPV1 & "','" & OPV2 & "','" & OPV3 & "','" & DTP1 & "','" & DTP2 & "','" & DTP3 & "','" & HBV1 & "','" & HBV2 & "','" & HBV3 & "','" & MMR & "','" & D_UPDATE & "'")

                End If

            Next
        End If
        clsbusent.Lc_BusinessEntity.Updatem_table("r_epi_1 A JOIN m_person B ON(A.PID = B.PID)", "STATUS = '0'", " ((DATE_FORMAT(" & tmpDate2 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate2 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 1) ")
        clsbusent.Lc_BusinessEntity.Updatem_table("r_epi_1 A JOIN m_person B ON(A.PID = B.PID)", "STATUS = '1'", " (BCG <> '' AND HB <> ''  AND OPV1 <> '' AND OPV2 <> '' AND OPV3 <> '' AND DTP1 <> '' AND DTP2 <> '' AND DTP3 <> '' AND HBV1 <> '' AND HBV2 <> '' AND HBV3 <> '' AND MMR <> '') AND ((DATE_FORMAT(" & tmpDate2 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate2 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 1) ")


    End Sub
    Private Sub EPI2()
        Dim ds As New DataSet
        Dim ds2 As New DataSet

        tmpDate2 = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 4)


        ds = clsdataBus.Lc_Business.SELECT_TABLE("A.HOSPCODE,A.PID," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '010' THEN DATE_SERV END),'') AS BCG," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '041' THEN DATE_SERV END),'') AS HB," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '081' THEN DATE_SERV END),'') AS OPV1," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '082' THEN DATE_SERV END),'') AS OPV2," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '083' THEN DATE_SERV END),'') AS OPV3," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '031' OR VACCINETYPE = '091' THEN DATE_SERV END),'') AS DTP1," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '032' OR VACCINETYPE = '092' THEN DATE_SERV END),'') AS DTP2," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '033' OR VACCINETYPE = '093' THEN DATE_SERV END),'') AS DTP3," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '091' THEN DATE_SERV END),'') AS HBV1," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '042' OR VACCINETYPE = '092' THEN DATE_SERV END),'') AS HBV2," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '043' OR VACCINETYPE = '093' THEN DATE_SERV END),'') AS HBV3," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '051' THEN DATE_SERV END),'') AS JE1," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '052' THEN DATE_SERV END),'') AS JE2," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '061' THEN DATE_SERV END),'') AS MMR," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = 'J11' THEN DATE_SERV END),'') AS J11," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '034' THEN DATE_SERV END),'') AS DTP4," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '084' THEN DATE_SERV END),'') AS OPV4," _
                                                 & "MAX(IFNULL(B.D_UPDATE,'0')) D_UPDATE" _
                                                 & "", " m_person A LEFT JOIN m_epi B ON(A.PID = B.PID) JOIN m_home C ON(A.HID = C.HID)", _
                                                 " WHERE (A.STATUS_AF <> '8' AND IFNULL(B.STATUS_AF,'') = '1') AND IFNULL(C.VILLAGE,'') <> '' AND DISCHARGE = '9' AND TYPEAREA IN('1','3','5') AND " _
                                                 & "((DATE_FORMAT(" & tmpDate2 & ",'%Y')-DATE_FORMAT(A.BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate2 & ",'00-%m-%d')<DATE_FORMAT(A.BIRTH,'00-%m-%d'))) <= 3 ) AND A.PID NOT IN(SELECT PID FROM r_epi_1 )  GROUP BY PID ORDER BY PID ")


        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Dim HCODE As String = ds.Tables(0).Rows(i).Item("HOSPCODE")
                Dim PID As String = ds.Tables(0).Rows(i).Item("PID")
                Dim BCG As String = ds.Tables(0).Rows(i).Item("BCG")
                Dim HB As String = ds.Tables(0).Rows(i).Item("HB")
                Dim OPV1 As String = ds.Tables(0).Rows(i).Item("OPV1")
                Dim OPV2 As String = ds.Tables(0).Rows(i).Item("OPV2")
                Dim OPV3 As String = ds.Tables(0).Rows(i).Item("OPV3")
                Dim DTP1 As String = ds.Tables(0).Rows(i).Item("DTP1")
                Dim DTP2 As String = ds.Tables(0).Rows(i).Item("DTP2")
                Dim DTP3 As String = ds.Tables(0).Rows(i).Item("DTP3")
                Dim HBV1 As String = ds.Tables(0).Rows(i).Item("HBV1")
                Dim HBV2 As String = ds.Tables(0).Rows(i).Item("HBV2")
                Dim HBV3 As String = ds.Tables(0).Rows(i).Item("HBV3")
                Dim JE1 As String = ds.Tables(0).Rows(i).Item("JE1")
                Dim JE2 As String = ds.Tables(0).Rows(i).Item("JE2")
                Dim MMR As String = ds.Tables(0).Rows(i).Item("MMR")
                Dim J11 As String = ds.Tables(0).Rows(i).Item("J11")
                Dim OPV4 As String = ds.Tables(0).Rows(i).Item("OPV4")
                Dim DTP4 As String = ds.Tables(0).Rows(i).Item("DTP4")
                Dim D_UPDATE As String = ds.Tables(0).Rows(i).Item("D_UPDATE")

                ds2 = clsdataBus.Lc_Business.SELECT_TABLE("PID", "r_epi_1", " WHERE PID  = '" & PID & "'")

                If ds2.Tables(0).Rows.Count > 0 Then
                    clsbusent.Lc_BusinessEntity.Updatem_table("r_epi_1", "BCG = '" & BCG & "',HB = '" & HB & "',OPV1 = '" & OPV1 & "',OPV2 = '" & OPV2 & "',OPV3 = '" & OPV3 & "',DTP1 = '" & DTP1 & "',DTP2 = '" & DTP2 & "',DTP3 = '" & DTP3 & "',HBV1 = '" & HBV1 & "',HBV2 = '" & HBV2 & "',HBV3 = '" & HBV3 & "',JE1 = '" & JE1 & "',JE2 = '" & JE2 & "',J12 = '" & J11 & "',MMR = '" & MMR & "',OPV4 = '" & OPV4 & "',DTP4 = '" & DTP4 & "',D_UPDATE = '" & D_UPDATE & "'", " PID  = '" & PID & "'")
                Else
                    clsbusent.Lc_BusinessEntity.Insertm_table("r_epi_1 (HCODE,PID,BCG,HB,OPV1,OPV2,OPV3,DTP1,DTP2,DTP3,HBV1,HBV2,HBV3,JE1,JE2,MMR,J11,OPV4,DTP4,D_UPDATE)", "'" & HCODE & "','" & PID & "','" & BCG & "','" & HB & "','" & OPV1 & "','" & OPV2 & "','" & OPV3 & "','" & DTP1 & "','" & DTP2 & "','" & DTP3 & "','" & HBV1 & "','" & HBV2 & "','" & HBV3 & "','" & JE1 & "','" & JE2 & "','" & MMR & "','" & J11 & "','" & OPV4 & "','" & DTP4 & "','" & D_UPDATE & "'")

                End If


            Next
        End If
        clsbusent.Lc_BusinessEntity.Updatem_table("r_epi_1 A JOIN m_person B ON(A.PID = B.PID)", "STATUS = '0'", " ((DATE_FORMAT(" & tmpDate2 & ",'%Y')-DATE_FORMAT(B.BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate2 & ",'00-%m-%d')<DATE_FORMAT(B.BIRTH,'00-%m-%d'))) >= 2  )")
        clsbusent.Lc_BusinessEntity.Updatem_table("r_epi_1 A JOIN m_person B ON(A.PID = B.PID)", "STATUS = '1'", " (BCG <> '' AND HB <> '' AND OPV1 <> '' AND OPV2 <> '' AND OPV3 <> '' AND DTP1 <> '' AND DTP2 <> '' AND DTP3 <> '' AND HBV1 <> '' AND HBV2 <> '' AND HBV3 <> '' AND ((JE1 <> '' AND JE2 <> '') OR (J11 <> ''))  AND MMR <> '' AND OPV4 <> '' AND DTP4 <> '') AND ((DATE_FORMAT(" & tmpDate2 & ",'%Y')-DATE_FORMAT(B.BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate2 & ",'00-%m-%d')<DATE_FORMAT(B.BIRTH,'00-%m-%d'))) >= 2 )")

    End Sub
    Private Sub EPI3()

        tmpDate2 = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 4)

        Dim ds As New DataSet
        Dim ds2 As New DataSet

        ds = clsdataBus.Lc_Business.SELECT_TABLE("A.HOSPCODE,A.PID," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '010' THEN DATE_SERV END),'') AS BCG," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '041' THEN DATE_SERV END),'') AS HB," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '081' THEN DATE_SERV END),'') AS OPV1," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '082' THEN DATE_SERV END),'') AS OPV2," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '083' THEN DATE_SERV END),'') AS OPV3," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '031' OR VACCINETYPE = '091' THEN DATE_SERV END),'') AS DTP1," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '032' OR VACCINETYPE = '092' THEN DATE_SERV END),'') AS DTP2," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '033' OR VACCINETYPE = '093' THEN DATE_SERV END),'') AS DTP3," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '041' OR VACCINETYPE = '091' THEN DATE_SERV END),'') AS HBV1," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '042' OR VACCINETYPE = '092' THEN DATE_SERV END),'') AS HBV2," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '043' OR VACCINETYPE = '093' THEN DATE_SERV END),'') AS HBV3," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '051' THEN DATE_SERV END),'') AS JE1," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '052' THEN DATE_SERV END),'') AS JE2," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '053' THEN DATE_SERV END),'') AS JE3," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '061' THEN DATE_SERV END),'') AS MMR," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '072' OR VACCINETYPE = '073'  THEN DATE_SERV END),'') AS MMR2," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '084' THEN DATE_SERV END),'') AS OPV4," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '085' THEN DATE_SERV END),'') AS OPV5," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '034' THEN DATE_SERV END),'') AS DTP4," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '035' THEN DATE_SERV END),'') AS DTP5," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = 'J11' THEN DATE_SERV END),'') AS J11," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = 'J12' THEN DATE_SERV END),'') AS J12," _
                                                 & "MAX(IFNULL(B.D_UPDATE,'0')) D_UPDATE" _
                                                 & "", " m_person A LEFT JOIN m_epi B ON(A.PID = B.PID) JOIN m_home C ON(A.HID = C.HID) ", _
                                                 " WHERE (A.STATUS_AF <> '8' AND IFNULL(B.STATUS_AF,'') = '1') AND IFNULL(C.VILLAGE,'') <> '' AND DISCHARGE = '9' AND TYPEAREA IN('1','3','5') AND " _
                                                 & "((DATE_FORMAT(" & tmpDate2 & ",'%Y')-DATE_FORMAT(A.BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate2 & ",'00-%m-%d')<DATE_FORMAT(A.BIRTH,'00-%m-%d'))) <= 4  ) AND A.PID NOT IN(SELECT PID FROM r_epi_1 )  GROUP BY PID ORDER BY PID ")


        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Dim HCODE As String = ds.Tables(0).Rows(i).Item("HOSPCODE")
                Dim PID As String = ds.Tables(0).Rows(i).Item("PID")
                Dim BCG As String = ds.Tables(0).Rows(i).Item("BCG")
                Dim HB As String = ds.Tables(0).Rows(i).Item("HB")
                Dim OPV1 As String = ds.Tables(0).Rows(i).Item("OPV1")
                Dim OPV2 As String = ds.Tables(0).Rows(i).Item("OPV2")
                Dim OPV3 As String = ds.Tables(0).Rows(i).Item("OPV3")
                Dim DTP1 As String = ds.Tables(0).Rows(i).Item("DTP1")
                Dim DTP2 As String = ds.Tables(0).Rows(i).Item("DTP2")
                Dim DTP3 As String = ds.Tables(0).Rows(i).Item("DTP3")
                Dim HBV1 As String = ds.Tables(0).Rows(i).Item("HBV1")
                Dim HBV2 As String = ds.Tables(0).Rows(i).Item("HBV2")
                Dim HBV3 As String = ds.Tables(0).Rows(i).Item("HBV3")
                Dim JE1 As String = ds.Tables(0).Rows(i).Item("JE1")
                Dim JE2 As String = ds.Tables(0).Rows(i).Item("JE2")
                Dim MMR As String = ds.Tables(0).Rows(i).Item("MMR")
                Dim MMR2 As String = ds.Tables(0).Rows(i).Item("MMR2")
                Dim OPV4 As String = ds.Tables(0).Rows(i).Item("OPV4")
                Dim OPV5 As String = ds.Tables(0).Rows(i).Item("OPV5")
                Dim DTP4 As String = ds.Tables(0).Rows(i).Item("DTP4")
                Dim DTP5 As String = ds.Tables(0).Rows(i).Item("DTP5")
                Dim JE3 As String = ds.Tables(0).Rows(i).Item("JE3")
                Dim J11 As String = ds.Tables(0).Rows(i).Item("J11")
                Dim J12 As String = ds.Tables(0).Rows(i).Item("J12")
                Dim D_UPDATE As String = ds.Tables(0).Rows(i).Item("D_UPDATE")

                ds2 = clsdataBus.Lc_Business.SELECT_TABLE("PID", "r_epi_1", " WHERE PID  = '" & PID & "'")

                If ds2.Tables(0).Rows.Count > 0 Then
                    clsbusent.Lc_BusinessEntity.Updatem_table("r_epi_1", "BCG = '" & BCG & "',HB = '" & HB & "',OPV1 = '" & OPV1 & "',OPV2 = '" & OPV2 & "',OPV3 = '" & OPV3 & "',DTP1 = '" & DTP1 & "',DTP2 = '" & DTP2 & "',DTP3 = '" & DTP3 & "',HBV1 = '" & HBV1 & "',HBV2 = '" & HBV2 & "',HBV3 = '" & HBV3 & "',JE1 = '" & JE1 & "',JE2 = '" & JE2 & "',JE3 = '" & JE3 & "',J11 = '" & J11 & "',J12 = '" & J12 & "',MMR = '" & MMR & "',MMR2 = '" & MMR2 & "',OPV4 = '" & OPV4 & "',DTP4 = '" & DTP4 & "',OPV5 = '" & OPV5 & "',DTP5 = '" & DTP5 & "',D_UPDATE = '" & D_UPDATE & "'", " PID  = '" & PID & "'")
                Else
                    clsbusent.Lc_BusinessEntity.Insertm_table("r_epi_1 (HCODE,PID,BCG,HB,OPV1,OPV2,OPV3,DTP1,DTP2,DTP3,HBV1,HBV2,HBV3,JE1,JE2,JE3,MMR,J11,OPV4,DTP4,MMR2,J12,OPV5,DTP5,D_UPDATE)", "'" & HCODE & "','" & PID & "','" & BCG & "','" & HB & "','" & OPV1 & "','" & OPV2 & "','" & OPV3 & "','" & DTP1 & "','" & DTP2 & "','" & DTP3 & "','" & HBV1 & "','" & HBV2 & "','" & HBV3 & "','" & JE1 & "','" & JE2 & "','" & JE3 & "','" & MMR & "','" & J11 & "','" & OPV4 & "','" & DTP4 & "','" & MMR2 & "','" & J12 & "','" & OPV5 & "','" & DTP5 & "','" & D_UPDATE & "'")

                End If
            Next
        End If
        clsbusent.Lc_BusinessEntity.Updatem_table("r_epi_1 A JOIN m_person B ON(A.PID = B.PID) ", "STATUS = '0' ", "((DATE_FORMAT(" & tmpDate2 & ",'%Y')-DATE_FORMAT(B.BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate2 & ",'00-%m-%d')<DATE_FORMAT(B.BIRTH,'00-%m-%d'))) >= 3 )")
        clsbusent.Lc_BusinessEntity.Updatem_table("r_epi_1 A JOIN m_person B ON(A.PID = B.PID) ", "STATUS = '1'", " (BCG <> '' AND HB <> '' AND OPV1 <> '' AND OPV2 <> '' AND OPV3 <> '' AND DTP1 <> '' AND DTP2 <> '' AND DTP3 <> '' AND HBV1 <> '' AND HBV2 <> '' AND HBV3 <> '' AND ((JE1 <> '' AND JE2 <> '' AND JE3 <> '') OR (J11 <> '' AND J12 <> '') OR (JE1 <> '' AND JE2 <> '' AND J11 <> '')) AND MMR <> '' AND MMR2 <> ''  AND  OPV4 <> ''  AND DTP4 <> '' ) AND ((DATE_FORMAT(" & tmpDate2 & ",'%Y')-DATE_FORMAT(B.BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate2 & ",'00-%m-%d')<DATE_FORMAT(B.BIRTH,'00-%m-%d'))) >= 3 )")

    End Sub
    Private Sub EPI4()
        tmpDate2 = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 4)

        Dim ds As New DataSet
        Dim ds2 As New DataSet


        ds = clsdataBus.Lc_Business.SELECT_TABLE("A.HOSPCODE,A.PID," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '010' THEN DATE_SERV END),'') AS BCG," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '041' THEN DATE_SERV END),'') AS HB," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '081' THEN DATE_SERV END),'') AS OPV1," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '082' THEN DATE_SERV END),'') AS OPV2," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '083' THEN DATE_SERV END),'') AS OPV3," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '031' OR VACCINETYPE = '091' THEN DATE_SERV END),'') AS DTP1," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '032' OR VACCINETYPE = '092' THEN DATE_SERV END),'') AS DTP2," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '033' OR VACCINETYPE = '093' THEN DATE_SERV END),'') AS DTP3," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '041' OR VACCINETYPE = '091' THEN DATE_SERV END),'') AS HBV1," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '042' OR VACCINETYPE = '092' THEN DATE_SERV END),'') AS HBV2," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '043' OR VACCINETYPE = '093' THEN DATE_SERV END),'') AS HBV3," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '051' THEN DATE_SERV END),'') AS JE1," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '052' THEN DATE_SERV END),'') AS JE2," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '053' THEN DATE_SERV END),'') AS JE3," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '061' THEN DATE_SERV END),'') AS MMR," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '072' OR VACCINETYPE = '073'  THEN DATE_SERV END),'') AS MMR2," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '084' THEN DATE_SERV END),'') AS OPV4," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '085' THEN DATE_SERV END),'') AS OPV5," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '034' THEN DATE_SERV END),'') AS DTP4," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = '035' THEN DATE_SERV END),'') AS DTP5," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = 'J11' THEN DATE_SERV END),'') AS J11," _
                                                 & "IFNULL(MAX(CASE WHEN VACCINETYPE = 'J12' THEN DATE_SERV END),'') AS J12," _
                                                 & "MAX(IFNULL(B.D_UPDATE,'0')) D_UPDATE" _
                                                 & "", " m_person A LEFT JOIN m_epi B ON(A.PID = B.PID) JOIN m_home C ON(A.HID = C.HID) ", _
                                                 " WHERE (A.STATUS_AF <> '8' AND IFNULL(B.STATUS_AF,'') = '1') AND IFNULL(C.VILLAGE,'') <> '' AND DISCHARGE = '9' AND TYPEAREA IN('1','3','5') AND " _
                                                 & "((DATE_FORMAT(" & tmpDate2 & ",'%Y')-DATE_FORMAT(A.BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate2 & ",'00-%m-%d')<DATE_FORMAT(A.BIRTH,'00-%m-%d'))) <= 7  ) AND A.PID NOT IN(SELECT PID FROM r_epi_1 ) GROUP BY PID ORDER BY PID ")


        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Dim HCODE As String = ds.Tables(0).Rows(i).Item("HOSPCODE")
                Dim PID As String = ds.Tables(0).Rows(i).Item("PID")
                Dim BCG As String = ds.Tables(0).Rows(i).Item("BCG")
                Dim HB As String = ds.Tables(0).Rows(i).Item("HB")
                Dim OPV1 As String = ds.Tables(0).Rows(i).Item("OPV1")
                Dim OPV2 As String = ds.Tables(0).Rows(i).Item("OPV2")
                Dim OPV3 As String = ds.Tables(0).Rows(i).Item("OPV3")
                Dim DTP1 As String = ds.Tables(0).Rows(i).Item("DTP1")
                Dim DTP2 As String = ds.Tables(0).Rows(i).Item("DTP2")
                Dim DTP3 As String = ds.Tables(0).Rows(i).Item("DTP3")
                Dim HBV1 As String = ds.Tables(0).Rows(i).Item("HBV1")
                Dim HBV2 As String = ds.Tables(0).Rows(i).Item("HBV2")
                Dim HBV3 As String = ds.Tables(0).Rows(i).Item("HBV3")
                Dim JE1 As String = ds.Tables(0).Rows(i).Item("JE1")
                Dim JE2 As String = ds.Tables(0).Rows(i).Item("JE2")
                Dim MMR As String = ds.Tables(0).Rows(i).Item("MMR")
                Dim MMR2 As String = ds.Tables(0).Rows(i).Item("MMR2")
                Dim OPV4 As String = ds.Tables(0).Rows(i).Item("OPV4")
                Dim OPV5 As String = ds.Tables(0).Rows(i).Item("OPV5")
                Dim DTP4 As String = ds.Tables(0).Rows(i).Item("DTP4")
                Dim DTP5 As String = ds.Tables(0).Rows(i).Item("DTP5")
                Dim JE3 As String = ds.Tables(0).Rows(i).Item("JE3")
                Dim J11 As String = ds.Tables(0).Rows(i).Item("J11")
                Dim J12 As String = ds.Tables(0).Rows(i).Item("J12")
                Dim D_UPDATE As String = ds.Tables(0).Rows(i).Item("D_UPDATE")

                ds2 = clsdataBus.Lc_Business.SELECT_TABLE("PID", "r_epi_1", " WHERE PID  = '" & PID & "'")

                If ds2.Tables(0).Rows.Count > 0 Then
                    clsbusent.Lc_BusinessEntity.Updatem_table("r_epi_1", "BCG = '" & BCG & "',HB = '" & HB & "',OPV1 = '" & OPV1 & "',OPV2 = '" & OPV2 & "',OPV3 = '" & OPV3 & "',DTP1 = '" & DTP1 & "',DTP2 = '" & DTP2 & "',DTP3 = '" & DTP3 & "',HBV1 = '" & HBV1 & "',HBV2 = '" & HBV2 & "',HBV3 = '" & HBV3 & "',JE1 = '" & JE1 & "',JE2 = '" & JE2 & "',JE3 = '" & JE3 & "',J11 = '" & J11 & "',J12 = '" & J12 & "',MMR = '" & MMR & "',MMR2 = '" & MMR2 & "',OPV4 = '" & OPV4 & "',DTP4 = '" & DTP4 & "',OPV5 = '" & OPV5 & "',DTP5 = '" & DTP5 & "',D_UPDATE = '" & D_UPDATE & "'", " PID  = '" & PID & "'")
                Else
                    clsbusent.Lc_BusinessEntity.Insertm_table("r_epi_1 (HCODE,PID,BCG,HB,OPV1,OPV2,OPV3,DTP1,DTP2,DTP3,HBV1,HBV2,HBV3,JE1,JE2,JE3,MMR,J11,OPV4,DTP4,MMR2,J12,OPV5,DTP5,D_UPDATE)", "'" & HCODE & "','" & PID & "','" & BCG & "','" & HB & "','" & OPV1 & "','" & OPV2 & "','" & OPV3 & "','" & DTP1 & "','" & DTP2 & "','" & DTP3 & "','" & HBV1 & "','" & HBV2 & "','" & HBV3 & "','" & JE1 & "','" & JE2 & "','" & JE3 & "','" & MMR & "','" & J11 & "','" & OPV4 & "','" & DTP4 & "','" & MMR2 & "','" & J12 & "','" & OPV5 & "','" & DTP5 & "','" & D_UPDATE & "'")

                End If
            Next
        End If
        clsbusent.Lc_BusinessEntity.Updatem_table("r_epi_1 A JOIN m_person B ON(A.PID = B.PID) ", "STATUS = '0' ", "((DATE_FORMAT(" & tmpDate2 & ",'%Y')-DATE_FORMAT(B.BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate2 & ",'00-%m-%d')<DATE_FORMAT(B.BIRTH,'00-%m-%d'))) >= 4 )")
        clsbusent.Lc_BusinessEntity.Updatem_table("r_epi_1 A JOIN m_person B ON(A.PID = B.PID) ", "STATUS = '1'", " (BCG <> '' AND HB <> '' AND OPV1 <> '' AND OPV2 <> '' AND OPV3 <> '' AND DTP1 <> '' AND DTP2 <> '' AND DTP3 <> '' AND HBV1 <> '' AND HBV2 <> '' AND HBV3 <> '' AND  ((JE1 <> '' AND JE2 <> '' AND JE3 <> '') OR (J11 <> '' AND J12 <> '') OR (JE1 <> '' AND JE2 <> '' AND J11 <> '')) AND MMR <> '' AND MMR2 <> ''  AND  OPV4 <> '' AND OPV5 <> '' AND DTP4 <> '' AND DTP5 <> '' ) AND ((DATE_FORMAT(" & tmpDate2 & ",'%Y')-DATE_FORMAT(B.BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate2 & ",'00-%m-%d')<DATE_FORMAT(B.BIRTH,'00-%m-%d'))) >= 4 )")

    End Sub
    Private Sub Conntest()

        Try
            If My.Computer.Network.Ping("www.google.com") = True Then
                Dim strDataSource4 As String = ""
                Dim strUserID4 As String = ""
                Dim strPassword4 As String = ""
                Dim strPort4 As String = ""
                Dim strDatabasename4 As String = ""
                Try


                    clsDataAcc4.G_DBIPServer4 = "203.157.111.7"
                    clsDataAcc4.G_DBPortServer4 = "3306"
                    clsDataAcc4.G_DBUserName4 = "kidkom"
                    clsDataAcc4.G_DBPassword4 = "Mc00963"
                    clsDataAcc4.G_DBName4 = "mypcupro"
                Catch ex As Exception
                    'MessageBox.Show(ex.Message.ToString())
                End Try

                Try
                    If clsDataAcc4.Lc_DataAcc4.getDB_Conn_db4() = True Then
                        CheckBox4.Checked = True
                        CheckBox4.ForeColor = Color.Green

                        If vConfigOnline <> "1" Then
                            Conntest4()
                        End If


                        Dim dsCk As DataSet
                        dsCk = clsdataBus4.Lc_Business4.SELECT_TABLE(" HOSPCODE,IFNULL(MYPCUCARE,'') AS MYPCUCARE", " m_confighcode_mypcu", " WHERE HOSPCODE = '" & vHcode & "'")
                        If dsCk.Tables(0).Rows.Count = 0 Then
                            Dim dsx As DataSet
                            dsx = clsdataBus.Lc_Business.SELECT_TABLE("*", "l_confighcode", "")
                            If dsx.Tables(0).Rows.Count > 0 Then
                                Dim tmpHospcode As String = dsx.Tables(0).Rows(0).Item("HOSPCODE").ToString
                                Dim tmpHosname As String = dsx.Tables(0).Rows(0).Item("HOSPNAME").ToString
                                Dim tmpProvinceID As String = dsx.Tables(0).Rows(0).Item("PROVINCE_ID").ToString
                                Dim tmpProvinceName As String = dsx.Tables(0).Rows(0).Item("PROVINCE_NAME").ToString
                                Dim tmpAmphurID As String = dsx.Tables(0).Rows(0).Item("AMPHUR_ID").ToString
                                Dim tmpAmphurName As String = dsx.Tables(0).Rows(0).Item("AMPHUR_NAME").ToString

                                ClsBusinessEntity4.Lc_BusinessEntity4.Insertm_table("m_confighcode_mypcu (HOSPCODE,HOSPNAME,PROVINCE_ID,PROVINCE_NAME,AMPHUR_ID,AMPHUR_NAME,D_UPDATE,VERSION)",
                            "'" & tmpHospcode & "','" & tmpHosname & "','" & tmpProvinceID & "','" & tmpProvinceName & "','" & tmpAmphurID & "','" & tmpAmphurName & "',DATE_FORMAT(NOW(),'%Y%m%d%h%i%s'),'" & vVersion & "'")
                            End If
                        Else
                            ClsBusinessEntity4.Lc_BusinessEntity4.Updatem_table("m_confighcode_mypcu ", "D_UPDATE = DATE_FORMAT(NOW(),'%Y%m%d%h%i%s'),VERSION = '" & vVersion & "'", " HOSPCODE = '" & vHcode & "'")
                            ClsBusinessEntity.Lc_BusinessEntity.Updatem_table("l_confighcode ", "MYPCUCARE = '" & dsCk.Tables(0).Rows(0).Item("MYPCUCARE") & "'", " HOSPCODE = '" & vHcode & "'")

                        End If
                    Else
                        CheckBox4.Checked = False
                        CheckBox4.Text = "ไม่สามารถเชื่อมต่อ SERVER ได้"
                        CheckBox4.ForeColor = Color.Crimson

                    End If
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception
            CheckBox4.Checked = False
            CheckBox4.Text = "ไม่สามารถเชื่อมต่อ SERVER ได้"
            CheckBox4.ForeColor = Color.Crimson
        End Try



    End Sub
    Private Sub Conntest4()
        Try
            If My.Computer.Network.Ping("www.google.com") = True Then
                Dim strDataSource4 As String = ""
                Dim strUserID4 As String = ""
                Dim strPassword4 As String = ""
                Dim strPort4 As String = ""
                Dim strDatabasename4 As String = ""
                Try


                    clsDataAcc4.G_DBIPServer4 = "203.157.111.7"
                    clsDataAcc4.G_DBPortServer4 = "3306"
                    clsDataAcc4.G_DBUserName4 = "kidkom"
                    clsDataAcc4.G_DBPassword4 = "Mc00963"
                    clsDataAcc4.G_DBName4 = "mypcupro"
                Catch ex As Exception
                    'MessageBox.Show(ex.Message.ToString())
                End Try

                Try
                    If clsDataAcc4.Lc_DataAcc4.getDB_Conn_db4() = True Then
                        CheckBox1.Checked = True
                        Dim dscheck1 As DataSet
                        Dim check1 As Integer = 0

                        Dim dscheck2 As DataSet
                        Dim check2 As Integer = 0

                        dscheck1 = clsdataBus.Lc_Business.SELECT_TABLE("COUNT(*) AS C_COUNT", " l_hospitals ", "")
                        If dscheck1.Tables(0).Rows.Count > 0 Then
                            check1 = CInt(dscheck1.Tables(0).Rows(0).Item("C_COUNT"))
                            Label1.Text = "ในฐานข้อมูลมี " & check1.ToString("#,##0") & " รายการ"
                        End If

                        dscheck2 = clsdataBus4.Lc_Business4.SELECT_TABLE("COUNT(*) AS C_COUNT", " l_hospitals ", "")
                        If dscheck2.Tables(0).Rows.Count > 0 Then
                            check2 = CInt(dscheck2.Tables(0).Rows(0).Item("C_COUNT"))
                            Label2.Text = "ใน SERVER มี " & check1.ToString("#,##0") & " รายการ"
                        End If

                        If check1 <> check2 Then
                            Dim ds As DataSet
                            clsbusent.Lc_BusinessEntity.Turncate_table("tmp_hospitals")
                            ds = clsdataBus4.Lc_Business4.SELECT_TABLE("*", "l_hospitals", "")
                            Dim Path = Application.StartupPath & "\Script\l_hospitals.txt"
                            Exp_Data(Path, ds)
                            Import_DATA(Path, "tmp_hospitals")

                            Dim ds2 As DataSet
                            ds2 = clsdataBus.Lc_Business.SELECT_TABLE("*", " tmp_hospitals ", "WHERE HOSPCODE NOT IN(SELECT HOSPCODE FROM l_hospitals)")
                            If ds2.Tables(0).Rows.Count > 0 Then
                                For i As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                                    Try
                                        clsbusent.Lc_BusinessEntity.Insertm_table("l_hospitals (HOSPCODE,HOSPNAME,PROVINCE_ID,AMP,TAM,MOO,STATUS)",
                                         "'" & ds2.Tables(0).Rows(i).Item("HOSPCODE") & "','" & ds2.Tables(0).Rows(i).Item("HOSPNAME") & "','" & ds2.Tables(0).Rows(i).Item("PROVINCE_ID") & "','" & ds2.Tables(0).Rows(i).Item("AMP") & "','" & ds2.Tables(0).Rows(i).Item("TAM") & "','" & ds2.Tables(0).Rows(i).Item("MOO") & "','" & ds2.Tables(0).Rows(i).Item("STATUS") & "'")

                                    Catch ex As Exception

                                    End Try
                                Next
                            End If

                            Dim ds3 As DataSet
                            ds3 = clsdataBus.Lc_Business.SELECT_TABLE("*", " l_hospitals ", "WHERE HOSPCODE NOT IN(SELECT HOSPCODE FROM tmp_hospitals)")
                            If ds3.Tables(0).Rows.Count > 0 Then
                                For i As Integer = 0 To ds3.Tables(0).Rows.Count - 1
                                    Try
                                        clsbusent4.Lc_BusinessEntity4.Insertm_table("l_hospitals (HOSPCODE,HOSPNAME,PROVINCE_ID,AMP,TAM,MOO,STATUS,HOSPSEND)",
                                         "'" & ds3.Tables(0).Rows(i).Item("HOSPCODE") & "','" & ds3.Tables(0).Rows(i).Item("HOSPNAME") & "','" & ds3.Tables(0).Rows(i).Item("PROVINCE_ID") & "','" & ds3.Tables(0).Rows(i).Item("AMP") & "','" & ds3.Tables(0).Rows(i).Item("TAM") & "','" & ds3.Tables(0).Rows(i).Item("MOO") & "','" & ds3.Tables(0).Rows(i).Item("STATUS") & "','" & vHcode & "'")

                                    Catch ex As Exception

                                    End Try
                                Next
                            End If

                            clsbusent.Lc_BusinessEntity.Delete_table("l_hospitals", " WHERE HOSPCODE NOT IN(SELECT HOSPCODE FROM tmp_hospitals )")

                        End If
                        CheckBox3.Checked = True
                        CheckBox3.ForeColor = Color.Green

                        Try
                            Dim ds As DataSet
                            Dim tmpUPDATE1 As String = "0"
                            Dim tmpUPDATE2 As String = "0"
                            Dim dsChk1 As DataSet
                            Dim dsChk2 As DataSet
                            Dim dsChk3 As DataSet
                            Dim dsChk5 As DataSet
                            dsChk1 = clsdataBus4.Lc_Business4.SELECT_TABLE(" MAX(D_UPDATE) AS D_UPDATE", " l_table_lookup", "")
                            If dsChk1.Tables(0).Rows.Count > 0 Then
                                tmpUPDATE1 = dsChk1.Tables(0).Rows(0).Item("D_UPDATE")
                            End If
                            dsChk2 = clsdataBus.Lc_Business.SELECT_TABLE("MAX(D_UPDATE) AS D_UPDATE", "l_table_lookup", "")
                            If dsChk2.Tables(0).Rows.Count > 0 Then
                                tmpUPDATE2 = dsChk2.Tables(0).Rows(0).Item("D_UPDATE")
                            End If
                            If CInt(tmpUPDATE2) < CInt(tmpUPDATE1) Then
                                dsChk3 = clsdataBus4.Lc_Business4.SELECT_TABLE(" L_TABLE,D_UPDATE", " l_table_lookup", "")
                                For i As Integer = 0 To dsChk3.Tables(0).Rows.Count - 1
                                    dsChk5 = clsdataBus.Lc_Business.SELECT_TABLE("*", "l_table_lookup", " WHERE L_TABLE = '" & dsChk3.Tables(0).Rows(i).Item("L_TABLE") & "' AND D_UPDATE <> '" & dsChk3.Tables(0).Rows(i).Item("D_UPDATE") & "' ")
                                    If dsChk5.Tables(0).Rows.Count > 0 Then
                                        clsbusent.Lc_BusinessEntity.Turncate_table(dsChk3.Tables(0).Rows(i).Item("L_TABLE").ToString.ToLower)
                                        ds = clsdataBus4.Lc_Business4.SELECT_TABLE("*", dsChk3.Tables(0).Rows(i).Item("L_TABLE").ToString.ToLower, "")
                                        Dim Path2 = Application.StartupPath & "\Script\" & dsChk3.Tables(0).Rows(i).Item("L_TABLE").ToString.ToLower & ".txt"
                                        Exp_Data(Path2, ds)
                                        Import_DATA(Path2, dsChk3.Tables(0).Rows(i).Item("L_TABLE"))
                                        clsbusent.Lc_BusinessEntity.Updatem_table("l_table_lookup", " D_UPDATE = '" & dsChk3.Tables(0).Rows(i).Item("D_UPDATE") & "'", " L_TABLE = '" & dsChk3.Tables(0).Rows(i).Item("L_TABLE") & "' ")
                                        Dim pItem As ListViewItem
                                        pItem = New ListViewItem
                                        pItem.UseItemStyleForSubItems = False
                                        pItem.Text = "ปรับปรุงตาราง " & dsChk3.Tables(0).Rows(i).Item("L_TABLE")
                                        ListView1.Items.Add(pItem)
                                        ListView1.Refresh()
                                    End If

                                Next
                                CheckBox5.Checked = True
                                CheckBox5.ForeColor = Color.Green
                            Else
                                Dim pItem As ListViewItem
                                pItem = New ListViewItem
                                pItem.UseItemStyleForSubItems = False
                                pItem.Text = "ไม่มีตารางรหัสมาตรฐานที่ต้อง Update"
                                ListView1.Items.Add(pItem)
                                CheckBox5.Checked = True
                                CheckBox5.ForeColor = Color.Green
                            End If

                        Catch ex As Exception

                        End Try
                    End If



                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try


        Conntest5()

    End Sub
    Private Sub Conntest5()
        Try
            If My.Computer.Network.Ping("www.google.com") = True Then
                Dim strDataSource3 As String = ""
                Dim strUserID3 As String = ""
                Dim strPassword3 As String = ""
                Dim strPort3 As String = ""
                Dim strDatabasename3 As String = ""
                Dim dsc As DataSet
                dsc = clsdataBus.Lc_Business.SELECT_TABLE("*", "l_config_mypcu_pro", " WHERE ROWID = '01' ")
                If dsc.Tables(0).Rows.Count > 0 Then
                    strDataSource3 = dsc.Tables(0).Rows(0).Item("HOST")
                    strUserID3 = dsc.Tables(0).Rows(0).Item("USERNAME")
                    strPassword3 = dsc.Tables(0).Rows(0).Item("PASSWORD")
                    strPort3 = dsc.Tables(0).Rows(0).Item("PORT")
                    strDatabasename3 = dsc.Tables(0).Rows(0).Item("DATABASENAME")
                    clsDataAcc3.G_DBIPServer3 = strDataSource3
                    clsDataAcc3.G_DBPortServer3 = strPort3
                    clsDataAcc3.G_DBUserName3 = strUserID3
                    clsDataAcc3.G_DBPassword3 = strPassword3
                    clsDataAcc3.G_DBName3 = strDatabasename3
                    Try
                        If clsDataAcc3.Lc_DataAcc3.getDB_Conn_db3() = True Then

                            Try
                                If clsDataAcc3.Lc_DataAcc3.getDB_Conn_db3() = True Then

                                    Dim dsSMS1 As DataSet
                                    dsSMS1 = ClsBusiness3.Lc_Business3.SELECT_TABLE("*", " l_hospital_department ", "  ")
                                    If dsSMS1.Tables(0).Rows.Count > 0 Then
                                        For i As Integer = 0 To dsSMS1.Tables(0).Rows.Count - 1

                                            Dim dsSMS2 As DataSet
                                            dsSMS2 = ClsBusiness.Lc_Business.SELECT_TABLE("*", " l_hospital_department ", " WHERE  HOSPCODE = '" & dsSMS1.Tables(0).Rows(i).Item("HOSPCODE") & "' AND CLINIC = '" & dsSMS1.Tables(0).Rows(i).Item("CLINIC") & "' ")
                                            If dsSMS2.Tables(0).Rows.Count = 0 Then
                                                clsbusent.Lc_BusinessEntity.Insertm_table("l_hospital_department (HOSPTYPE,HOSPCODE,HOSPNAME,CLINIC,CLINIC_NAME,STATUS_AF)",
                                                  "" & dsSMS1.Tables(0).Rows(i).Item("HOSPTYPE") & ",'" & dsSMS1.Tables(0).Rows(i).Item("HOSPCODE") & "','" & dsSMS1.Tables(0).Rows(i).Item("HOSPNAME") & "','" & dsSMS1.Tables(0).Rows(i).Item("CLINIC") & "','" & dsSMS1.Tables(0).Rows(i).Item("CLINIC_NAME") & "','" & dsSMS1.Tables(0).Rows(i).Item("STATUS_AF") & "'")
                                            End If
                                        Next
                                    End If
                                End If
                            Catch ex As Exception

                            End Try

                        Else
                        End If
                    Catch ex As Exception
                    End Try
                End If
            Else
            End If
        Catch ex As Exception
        End Try






    End Sub
    Private Sub Exp_Data(ByVal Path As String, ByVal ds As DataSet)
        Dim delim As String = ""
        Dim sw As New StreamWriter(Path, False, UnicodeEncoding.Default)
        Dim tmpPCUCODE As String = ""
        Dim dt As New DataTable()

        clsDataAcc.Lc_DataAcc.getDB_Conn()
        Try
            delim = ""
            dt = ds.Tables(0)
            For Each row As DataRow In dt.Rows
                For Each value As Object In row.ItemArray
                    sw.Write(delim)
                    delim = "|"
                    sw.Write(value)
                Next
                delim = ""
                sw.WriteLine()

            Next


        Catch ex As Exception
            Console.Write("ERROR: " & ex.Message)
        Finally

        End Try
        sw.Close()
        sw.Dispose()
        dt.Dispose()
    End Sub
    Sub Import_DATA(ByVal Path As String, ByVal File As String)
        clsDataAcc.Lc_DataAcc.getDB_Conn()

        Try
            clsbusent.Lc_BusinessEntity.load_table4(Path, File, "")

        Catch e As IO.FileNotFoundException
        Catch e As Exception
            MessageBox.Show("(" & e.Message & ")")
            Throw e
        End Try


    End Sub
    Sub Import_DATA2(ByVal Path As String, ByVal File As String)

        Try
            clsbusent4.Lc_BusinessEntity4.load_table4(Path, File, "")

        Catch e As IO.FileNotFoundException
        Catch e As Exception
            MessageBox.Show("(" & e.Message & ")")
            Throw e
        End Try


    End Sub
    Private Sub cmdApply_Click(sender As Object, e As EventArgs) Handles cmdApply.Click
        Timer1.Enabled = True
    End Sub
End Class