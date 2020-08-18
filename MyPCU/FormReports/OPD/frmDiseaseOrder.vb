Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Globalization
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Imports Microsoft.Reporting.WinForms

Public Class frmDiseaseOrder
    Dim tmpAge1 As String = ""
    Dim tmpAge2 As String = ""
    Dim ds As DataSet
    Dim dsRpt As New DataSet
    Dim dsRpt2 As New DataSet
    Dim dsRpt3 As New DataSet
    Dim CurrentReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
    Dim tmpUpdate As String = ""
    Dim tmpDiagCODE As String = ""
    Dim tmpOPDCode As String = ""
    Dim tmpPPCode As String = ""
    Private Sub frmDiseaseOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdPrintReport1.Enabled = False

        With BetterListView1
            .Columns.Add(0).Text = "ลำดับ"
            .Columns(0).Width = 50
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "รหัส"
            .Columns(1).Width = 80
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "ความหมาย (ไทย)"
            .Columns(2).Width = 100
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "ความหมาย (Eng)"
            .Columns(3).Width = 80
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "จำนวน (คน)"
            .Columns(4).Width = 130
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "จำนวน (ครั้ง)"
            .Columns(5).Width = 150
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center

        End With

        cboVillgeAction()

        tmpOPDCode = ClsICD.strOP_1 & ClsICD.strOP_End
        tmpPPCode = ClsICD.strPP_1 & ClsICD.strPP_End
    End Sub
    Private Sub cboVillgeAction()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_SQL("(SELECT CONCAT(A.PROVINCE_ID,A.AMPHUR_ID,A.TAMBOL_ID,VILLAGE,VILLANAME) AS TV,CONCAT('หมู่ ',VILLAGE+0,' ต.',TAMBOL_NAME) AS VILLNAME,A.TAMBOL_ID,VILLAGE,VILLANAME FROM l_area A JOIN l_cat B ON(A.PROVINCE_ID = B.PROVINCE_ID AND A.AMPHUR_ID = B.AMPHUR_ID AND A.TAMBOL_ID = B.TAMBOL_ID) WHERE VILLAGE <> '00') " _
                                                & "UNION (SELECT CONCAT(A.PROVINCE_ID,A.AMPHUR_ID,A.TAMBOL_ID,VILLAGE,VILLANAME) AS TV,CONCAT(VILLANAME,' ต.',TAMBOL_NAME) AS VILLNAME,A.TAMBOL_ID,VILLAGE,VILLANAME FROM l_area A JOIN l_cat B ON(A.PROVINCE_ID = B.PROVINCE_ID AND A.AMPHUR_ID = B.AMPHUR_ID AND A.TAMBOL_ID = B.TAMBOL_ID) WHERE VILLAGE = '00') " _
                                                & "ORDER BY TAMBOL_ID,VILLAGE,VILLANAME+0")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboVillage
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "VILLNAME"
                .Properties.ValueMember = "TV"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.Columns(2).Visible = False
                .Properties.Columns(3).Visible = False
                .Properties.Columns(4).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If

    End Sub
    Private Sub ShowDataName()
        SplashScreenManager1.ShowWaitForm()

        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 4)
        Dim tmpVill As String = ""
        Dim tmpVill2 As String = ""
        Dim tmpAGE As String = ""
        Dim tmpShow As String = ""
        Dim tmpShow2 As String = ""
        Dim tmpShow3 As String = ""
        Dim tmpShow4 As String = ""
        Dim tmpShow5 As String = ""
        Dim tmpShowSex As String = ""
        Dim tmpShowIns As String = ""
        tmpAge1 = txtAge1.Value.ToString
        tmpAge2 = txtAge2.Value.ToString

        Dim t1 As String = ""
        Dim t2 As String = ""
        Dim t3 As String = ""
        Dim t4 As String = ""
        Dim t5 As String = ""
        Dim t6 As String = ""
        Dim t7 As String = ""
        Dim d1 As String = ""
        Dim d2 As String = ""
        Dim d3 As String = ""
        Dim d4 As String = ""
        Dim ta1 As String = ""
        Dim ta2 As String = ""
        Dim ta3 As String = ""
        Dim ta4 As String = ""
        Dim ta5 As String = ""

        If chkMstatus1.Checked = True Then
            t1 = "1"
        Else
            t1 = "0"
        End If
        If chkMstatus2.Checked = True Then
            t2 = "2"
        Else
            t2 = "0"
        End If
        If chkMstatus3.Checked = True Then
            t3 = "3"
        Else
            t3 = "0"
        End If
        If chkMstatus4.Checked = True Then
            t4 = "4"
        Else
            t4 = "0"
        End If
        If chkMstatus5.Checked = True Then
            t5 = "5"
        Else
            t5 = "0"
        End If
        If chkMstatus6.Checked = True Then
            t6 = "6"
        Else
            t6 = "0"
        End If
        If chkMstatus9.Checked = True Then
            t7 = "9"
        Else
            t7 = "0"
        End If
        tmpShow = "AND MSTATUS IN('" & t1 & "','" & t2 & "','" & t3 & "','" & t4 & "','" & t5 & "','" & t6 & "','" & t7 & "')"

        If chkDischarge1.Checked = True Then
            d1 = "1"
        Else
            d1 = "0"
        End If
        If chkDischarge2.Checked = True Then
            d2 = "2"
        Else
            d2 = "0"
        End If
        If chkDischarge3.Checked = True Then
            d3 = "3"
        Else
            d3 = "0"
        End If
        If chkDischarge9.Checked = True Then
            d4 = "9"
        Else
            d4 = "0"
        End If
        tmpShow3 = "AND DISCHARGE IN ('" & d1 & "','" & d2 & "','" & d3 & "','" & d4 & "')"

        If chkTypeArea1.Checked = True Then
            ta1 = "1"
        Else
            ta1 = "0"
        End If
        If chkTypeArea2.Checked = True Then
            ta2 = "2"
        Else
            ta2 = "0"
        End If
        If chkTypeArea3.Checked = True Then
            ta3 = "3"
        Else
            ta3 = "0"
        End If
        If chkTypeArea4.Checked = True Then
            ta4 = "4"
        Else
            ta4 = "0"
        End If
        If chkTypeArea5.Checked = True Then
            ta5 = "5"
        Else
            ta5 = "0"
        End If

        tmpShow4 = "AND TYPEAREA IN ('" & ta1 & "','" & ta2 & "','" & ta3 & "','" & ta4 & "','" & ta5 & "')"

        If chkVill.Checked = True Then
            tmpVill = " AND CONCAT(B.CHANGWAT,B.AMPUR,B.TAMBON,B.VILLAGE,B.VILLANAME) = '" & cboVillage.EditValue & "'"
            tmpVill2 = " WHERE CONCAT(B.CHANGWAT,B.AMPUR,B.TAMBON,B.VILLAGE,B.VILLANAME) = '" & cboVillage.EditValue & "'"
        Else
            tmpVill = ""
        End If

        Dim DateStart As String = CDate(dtpStart.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))
        Dim DateEnd As String = CDate(dtpEnd.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))


        If chkAge.Checked = True Then
            tmpShow2 = " "
        Else
            If chkYear.Checked = True Then
                tmpShow2 = " AND ((DATE_FORMAT(" & DateEnd & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & DateEnd & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= " & tmpAge1 & " AND  (DATE_FORMAT(" & DateEnd & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & DateEnd & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) < " & tmpAge2 & ")  "
            Else
                tmpShow2 = " AND (TIMESTAMPDIFF(MONTH, DATE_FORMAT(BIRTH,'%Y-%m-%d'),DATE_FORMAT(" & DateEnd & ",'%Y-%m-%d')) >= " & tmpAge1 & " AND  TIMESTAMPDIFF(MONTH, DATE_FORMAT(BIRTH,'%Y-%m-%d'),DATE_FORMAT(" & DateEnd & ",'%Y-%m-%d')) <= " & tmpAge2 & ")  "

            End If
        End If

        If chkOP.Checked = True Then
            tmpShow5 = " AND " & tmpOPDCode
        ElseIf chkPP.Checked = True Then
            tmpShow5 = " AND " & tmpPPCode
        ElseIf chkOPPP.Checked = True Then
            tmpShow5 = ""
        End If


        If chkSexAll.Checked = True Then
            tmpShowSex = ""
        ElseIf chkmale.Checked = True Then
            tmpShowSex = " AND A.SEX = '1'"
        ElseIf chkmale.Checked = True Then
            tmpShowSex = " AND A.SEX = '2'"
        End If


        Dim tOFC As String = ""
        Dim tUC As String = ""
        Dim tSSS As String = ""
        If chkInsUC.Checked = True Then
            tUC = "03"
        Else
            tUC = "00"
        End If
        If chkInsOFC.Checked = True Then
            tOFC = "01"
        Else
            tOFC = "00"
        End If
        If chkInsSSS.Checked = True Then
            tSSS = "02"
        Else
            tSSS = "00"
        End If
        If chkInsAll.Checked = True Then
            tmpShowIns = ""
        ElseIf chkInsOFC.Checked = True Then
            tmpShowIns = " AND INSTYPE_TYPE IN('" & tUC & "','" & tOFC & "','" & tSSS & "')"
        End If


        Dim ds As DataSet

        ds = clsdataBus.Lc_Business.SELECT_TABLE("PDX,DESC_THAI,DESC_ENG,COUNT(DISTINCT(SEQ)) AS M_COUNT,COUNT(DISTINCT(A.PID)) AS P_COUNT" _
                                                 , "m_person A JOIN m_service B ON(A.PID = B.PID) LEFT JOIN m_home C ON(A.HID = C.HID) JOIN l_icd10 D ON(B.PDX = D.CODE) JOIN l_instype_new ins ON(B.INSTYPE = ins.INSTYPE_CODE) " _
                                                   , "WHERE B.STATUS_AF <> '8'   " & tmpShow2 & tmpShow & tmpShow3 & tmpShow4 & tmpShow5 & tmpShowSex & tmpVill & tmpShowIns & " AND (DATE_SERV >= " & DateStart & " AND DATE_SERV <= " & DateEnd & ") GROUP BY PDX ORDER BY COUNT(DISTINCT(A.PID)) DESC ")

        If ds.Tables(0).Rows.Count > 0 Then

            Displaydata(ds)
            Label17.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0").ToString & " รายการ"
            cmdPrintReport1.Enabled = True
        Else
            BetterListView1.Items.Clear()
            Label17.Text = "จำนวน 0 รายการ"
            cmdPrintReport1.Enabled = False
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub Displaydata(ByVal ds As DataSet)

        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim tmpPrename As String = ""
        Dim tmpOrder As String = ""
        Dim tmpCID As String = ""
        Dim tmpPID As String = ""

        Dim tmpName As String = ""
        Dim tmpDateServ As String = ""
        Dim tmpInscl As String = ""
        Dim tmpDx As String = ""
        Dim tmpInsclID As String = ""
        Dim drRpt As DataRow
        Dim dt As DataTable
        dt = New DataTable()

        dt.Clear()
        Dim Coulumn1 = New DataColumn("FIELD1", Type.GetType("System.String"))
        Dim Coulumn2 = New DataColumn("FIELD2", Type.GetType("System.String"))
        Dim Coulumn3 = New DataColumn("FIELD3", Type.GetType("System.String"))
        Dim Coulumn4 = New DataColumn("FIELD4", Type.GetType("System.String"))
        Dim Coulumn5 = New DataColumn("FIELD5", Type.GetType("System.String"))
        Dim Coulumn6 = New DataColumn("FIELD6", Type.GetType("System.String"))
        Dim Coulumn7 = New DataColumn("FIELD7", Type.GetType("System.String"))
        Dim Coulumn8 = New DataColumn("FIELD8", Type.GetType("System.String"))
        Dim Coulumn9 = New DataColumn("FIELD9", Type.GetType("System.String"))
        Dim Coulumn10 = New DataColumn("FIELD10", Type.GetType("System.String"))
        Dim Coulumn11 = New DataColumn("FIELD11", Type.GetType("System.String"))
        Dim Coulumn12 = New DataColumn("FIELD12", Type.GetType("System.String"))
        Dim Coulumn13 = New DataColumn("FIELD13", Type.GetType("System.String"))
        dt.Columns.Add(Coulumn1)
        dt.Columns.Add(Coulumn2)
        dt.Columns.Add(Coulumn3)
        dt.Columns.Add(Coulumn4)
        dt.Columns.Add(Coulumn5)
        dt.Columns.Add(Coulumn6)
        dt.Columns.Add(Coulumn7)
        dt.Columns.Add(Coulumn8)
        dt.Columns.Add(Coulumn9)
        dt.Columns.Add(Coulumn10)
        dt.Columns.Add(Coulumn11)
        dt.Columns.Add(Coulumn12)
        dt.Columns.Add(Coulumn13)


        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                tmpOrder = CStr(i + 1)

                BetterListView1.Items.Add(tmpOrder).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("PDX"))

                If IsDBNull(dr("DESC_THAI")) Then
                    BetterListView1.Items(i).SubItems.Add("****ไม่มีรหัสนี้ใน icd9cm หรือ icd10tm****")
                Else
                    BetterListView1.Items(i).SubItems.Add(dr("DESC_THAI").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                End If
                If IsDBNull(dr("DESC_ENG")) Then
                    BetterListView1.Items(i).SubItems.Add("****ไม่มีรหัสนี้ใน icd10 หรือ icd10tm****")
                Else
                    BetterListView1.Items(i).SubItems.Add(dr("DESC_ENG").ToString).AlignHorizontal = TextAlignmentHorizontal.Left

                End If
                BetterListView1.Items(i).SubItems.Add(CInt(dr("P_COUNT")).ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right
                BetterListView1.Items(i).SubItems.Add(CInt(dr("M_COUNT")).ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right


                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.MintCream
                End If

                dsRpt.Tables.Clear()
                drRpt = dt.NewRow()
                drRpt("FIELD1") = "รายงานการให้รหัสวินิจฉัยปัญหาสุขภาพในพื้นที่"
                drRpt("FIELD2") = "หน่วยบริการ : " & vHname.Replace("รพ.สต.", "โรงพยาบาลส่งเสริมสุขภาพตำบล") & vbCrLf & "แสดงข้อมูลประมวลผล ระหว่างวันที่ " & CDate(dtpStart.EditValue).ToString("d MMMM yyyy") & " ถึงวันที่ " & CDate(dtpEnd.EditValue).ToString("d MMMM yyyy")
                drRpt("FIELD3") = i + 1
                drRpt("FIELD4") = dr("PDX")
                drRpt("FIELD5") = dr("DESC_THAI") & vbCrLf & dr("DESC_ENG")
                drRpt("FIELD6") = dr("P_COUNT")
                drRpt("FIELD7") = dr("M_COUNT")
                dt.Rows.Add(drRpt)
            Next
            dsRpt.Tables.Add(dt)
            BetterListView1.AutoResizeColumn(2, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(3, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)

            BetterListView1.ResumeSort(True)
            BetterListView1.EndUpdate()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error002" & tmpPID, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub


    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If dtpStart.EditValue = Nothing Or dtpEnd.EditValue = Nothing Then
            XtraMessageBox.Show("กรุณากำหนดวันที่ก่อน", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ShowDataName()

    End Sub

    Private Sub cmdPrintReport1_Click(sender As Object, e As EventArgs) Handles cmdPrintReport1.Click
        Dim fReport As New frmReportView
        Dim params As ReportParameter

        params = New ReportParameter("RateId")

        fReport.ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\Reports\rptDiseaseOrder.rdlc"

        fReport.ReportViewer1.LocalReport.DataSources.Clear()
        CurrentReportDataSource.Name = "DataSet20F"
        CurrentReportDataSource.value = dsRpt.Tables(0)
        fReport.ReportViewer1.LocalReport.DataSources.Add(CurrentReportDataSource)

        fReport.ShowDialog()

    End Sub

    Private Sub chkAge_Click(sender As Object, e As EventArgs) Handles chkAge.Click
        chkAge.Checked = True
        chkYear.Checked = False
        chkMonth.Checked = False
    End Sub

    Private Sub chkYear_Click(sender As Object, e As EventArgs) Handles chkYear.Click
        chkAge.Checked = False
        chkYear.Checked = True
        chkMonth.Checked = False
    End Sub

    Private Sub chkMonth_Click(sender As Object, e As EventArgs) Handles chkMonth.Click
        chkAge.Checked = False
        chkYear.Checked = False
        chkMonth.Checked = True
    End Sub

    Private Sub chkSexAll_click(sender As Object, e As EventArgs) Handles chkSexAll.Click
        chkSexAll.Checked = True
        chkmale.Checked = False
        chkfemale.Checked = False
    End Sub

    Private Sub chkmale_Click(sender As Object, e As EventArgs) Handles chkmale.Click
        chkSexAll.Checked = False
        chkmale.Checked = True
        chkfemale.Checked = False
    End Sub

    Private Sub chkfemale_Click(sender As Object, e As EventArgs) Handles chkfemale.Click
        chkSexAll.Checked = False
        chkmale.Checked = False
        chkfemale.Checked = True
    End Sub

    Private Sub chkOPPP_Click(sender As Object, e As EventArgs) Handles chkOPPP.Click
        chkOPPP.Checked = True
        chkOP.Checked = False
        chkPP.Checked = False
    End Sub

    Private Sub chkPP_Click(sender As Object, e As EventArgs) Handles chkPP.Click
        chkOPPP.Checked = False
        chkOP.Checked = False
        chkPP.Checked = True
    End Sub

    Private Sub chkOP_Click(sender As Object, e As EventArgs) Handles chkOP.Click
        chkOPPP.Checked = False
        chkOP.Checked = True
        chkPP.Checked = False
    End Sub

    Private Sub ChecktypeAll_Click(sender As Object, e As EventArgs) Handles ChecktypeAll.Click
        ChecktypeAll.Checked = True
        chkTypeArea1.Checked = True
        chkTypeArea2.Checked = True
        chkTypeArea3.Checked = True
        chkTypeArea4.Checked = True
        chkTypeArea5.Checked = True

    End Sub

    Private Sub chkTypeArea1_Click(sender As Object, e As EventArgs) Handles chkTypeArea1.Click
        If chkTypeArea1.Checked = False Then
            ChecktypeAll.Checked = False
        End If
    End Sub

    Private Sub chkTypeArea2_Click(sender As Object, e As EventArgs) Handles chkTypeArea2.Click
        If chkTypeArea2.Checked = False Then
            ChecktypeAll.Checked = False
        End If
    End Sub
    Private Sub chkTypeArea3_Click(sender As Object, e As EventArgs) Handles chkTypeArea3.Click
        If chkTypeArea3.Checked = False Then
            ChecktypeAll.Checked = False
        End If
    End Sub
    Private Sub chkTypeArea4_Click(sender As Object, e As EventArgs) Handles chkTypeArea4.Click
        If chkTypeArea4.Checked = False Then
            ChecktypeAll.Checked = False
        End If
    End Sub
    Private Sub chkTypeArea5_Click(sender As Object, e As EventArgs) Handles chkTypeArea5.Click
        If chkTypeArea5.Checked = False Then
            ChecktypeAll.Checked = False
        End If
    End Sub

    Private Sub chkMstatusAll_Click(sender As Object, e As EventArgs) Handles chkMstatusAll.Click
        chkMstatusAll.Checked = True
        chkMstatus1.Checked = True
        chkMstatus2.Checked = True
        chkMstatus3.Checked = True
        chkMstatus4.Checked = True
        chkMstatus5.Checked = True
        chkMstatus6.Checked = True
        chkMstatus9.Checked = True
    End Sub
    Private Sub chkMstatus1_Click(sender As Object, e As EventArgs) Handles chkMstatus1.Click
        If chkMstatus1.Checked = False Then
            chkMstatusAll.Checked = False
        End If
    End Sub
    Private Sub chkMstatus2_Click(sender As Object, e As EventArgs) Handles chkMstatus2.Click
        If chkMstatus2.Checked = False Then
            chkMstatusAll.Checked = False
        End If
    End Sub
    Private Sub chkMstatus3_Click(sender As Object, e As EventArgs) Handles chkMstatus3.Click
        If chkMstatus3.Checked = False Then
            chkMstatusAll.Checked = False
        End If
    End Sub
    Private Sub chkMstatus4_Click(sender As Object, e As EventArgs) Handles chkMstatus4.Click
        If chkMstatus4.Checked = False Then
            chkMstatusAll.Checked = False
        End If
    End Sub
    Private Sub chkMstatus5_Click(sender As Object, e As EventArgs) Handles chkMstatus5.Click
        If chkMstatus5.Checked = False Then
            chkMstatusAll.Checked = False
        End If
    End Sub
    Private Sub chkMstatus6_Click(sender As Object, e As EventArgs) Handles chkMstatus6.Click
        If chkMstatus6.Checked = False Then
            chkMstatusAll.Checked = False
        End If
    End Sub
    Private Sub chkMstatus9_Click(sender As Object, e As EventArgs) Handles chkMstatus9.Click
        If chkMstatus9.Checked = False Then
            chkMstatusAll.Checked = False
        End If
    End Sub

    Private Sub chkInsAll_Click(sender As Object, e As EventArgs) Handles chkInsAll.Click
        chkInsAll.Checked = True
        chkInsOFC.Checked = True
        chkInsSSS.Checked = True
        chkInsUC.Checked = True
    End Sub

    Private Sub chkInsOFC_Click(sender As Object, e As EventArgs) Handles chkInsOFC.Click
        If chkInsOFC.Checked = False Then
            chkInsAll.Checked = False
        End If
    End Sub
    Private Sub chkInsSSS_Click(sender As Object, e As EventArgs) Handles chkInsSSS.Click
        If chkInsSSS.Checked = False Then
            chkInsAll.Checked = False
        End If
    End Sub
    Private Sub chkInsuc_Click(sender As Object, e As EventArgs) Handles chkInsUC.Click
        If chkInsUC.Checked = False Then
            chkInsAll.Checked = False
        End If
    End Sub
End Class