Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Globalization
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Imports Microsoft.Reporting.WinForms

Public Class frmRptDentUC
    Dim ds As DataSet
    Dim dsRpt As New DataSet
    Dim dsRpt2 As New DataSet
    Dim CurrentReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
    Private Sub frmDentalUC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdPrint.Enabled = False
        cmdPrint2.Enabled = False
        cboProviderAction()

        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 30
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "เดือน"
            .Columns(1).Width = 80
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "ทั้งหมด (ครั้ง)"
            .Columns(2).Width = 120
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "บัตรทอง (ครั้ง)"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "ถอนฟัน(ครั้ง)"
            .Columns(4).Width = 100
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "ถอนฟัน(ซี่)"
            .Columns(5).Width = 100
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "ถอนฟัน UC(ครั้ง)"
            .Columns(6).Width = 100
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "ถอนฟัน UC(ซี่)"
            .Columns(7).Width = 100
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "อุดฟัน(ครั้ง)"
            .Columns(8).Width = 100
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(9).Text = "อุดฟัน(ซี่)"
            .Columns(9).Width = 100
            .Columns(9).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(10).Text = "อุดฟัน UC(ครั้ง)"
            .Columns(10).Width = 100
            .Columns(10).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(11).Text = "อุดฟัน UC(ซี่)"
            .Columns(11).Width = 100
            .Columns(11).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(12).Text = "ขูดหินปูน(ครั้ง)"
            .Columns(12).Width = 100
            .Columns(12).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(13).Text = "ขูดหินปูน(ส่วน)"
            .Columns(13).Width = 100
            .Columns(13).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(14).Text = "ขูดหินปูน UC(ครั้ง)"
            .Columns(14).Width = 100
            .Columns(14).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(15).Text = "ขูดหินปูน UC(ส่วน)"
            .Columns(15).Width = 100
            .Columns(15).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(16).Text = "เคลือบหลุมร่องฟัน(ครั้ง)"
            .Columns(16).Width = 100
            .Columns(16).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(17).Text = "เคลือบหลุมร่องฟัน(ซี่)"
            .Columns(17).Width = 100
            .Columns(17).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(18).Text = "เคลือบหลุมร่องฟัน UC(ครั้ง)"
            .Columns(18).Width = 100
            .Columns(18).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(19).Text = "เคลือบหลุมร่องฟัน UC(ซี่)"
            .Columns(19).Width = 100
            .Columns(19).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(20).Text = "เคลือบฟลูออไรด์(ครั้ง)"
            .Columns(20).Width = 100
            .Columns(20).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(21).Text = "เคลือบฟลูออไรด์ UC(ครั้ง)"
            .Columns(21).Width = 100
            .Columns(21).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(22).Text = "ขัดฟัน(ครั้ง)"
            .Columns(22).Width = 100
            .Columns(22).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(23).Text = "ขัดฟัน UC(ครั้ง)"
            .Columns(23).Width = 100
            .Columns(23).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(24).Text = "อื่นๆ ทั้งหทด (ครั้ง)"
            .Columns(24).Width = 100
            .Columns(24).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(25).Text = "อื่นๆ UC (ครั้ง)"
            .Columns(25).Width = 100
            .Columns(25).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center

        End With

        With BetterListView2
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 30
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ลำดับ"
            .Columns(1).Width = 80
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "ROWID"
            .Columns(2).Width = 0
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "CID"
            .Columns(3).Width = 120
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "ID"
            .Columns(4).Width = 100
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "HN"
            .Columns(5).Width = 0
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "ชื่อ-นามสกุล"
            .Columns(6).Width = 150
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "อายุ"
            .Columns(7).Width = 120
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "DATE_SERV"
            .Columns(8).Width = 0
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(9).Text = "วันที่รับบริการ"
            .Columns(9).Width = 100
            .Columns(9).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(10).Text = "สถานที่รับบริการ"
            .Columns(10).Width = 100
            .Columns(10).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(11).Text = "กิจกรรม"
            .Columns(11).Width = 100
            .Columns(11).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(12).Text = "ผู้ให้บริการ"
            .Columns(12).Width = 100
            .Columns(12).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(13).Text = "วันที่บันทึกข้อมูล"
            .Columns(13).Width = 100
            .Columns(13).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center

        End With

        'ds = clsdataBus.Lc_Business.SELECT_TABLE("PROVIDER,CONCAT(B.PRENAME,NAME,' ',LNAME) AS PROVIDER_NAME", "m_provider A LEFT JOIN l_prename B ON(A.PRENAME = B.PRENAME_CODE)", " WHERE A.STATUS = '1' AND STATUS_AF <> '8' AND PROVIDERTYPE IN('02','06') ORDER BY NAME")
        'If ds.Tables(0).Rows.Count > 0 Then
        '    With cboProvider
        '        .DataSource = ds.Tables(0)
        '        .DisplayMember = "PROVIDER_NAME"
        '        .ValueMember = "PROVIDER"
        '        .SelectedValue = 0
        '    End With
        'End If
    End Sub
    Private Sub cboProviderAction()
        Dim ds As DataSet

        ds = clsdataBus.Lc_Business.SELECT_TABLE("PROVIDER,CONCAT(b.PRENAME_DESC,' ',a.NAME,' ',a.LNAME) AS PROVIDER_NAME", " m_provider a JOIN l_mypcu_prename b ON(a.PRENAME_HOS = b.PRENAME_CODE)  ", " WHERE a.STATUS_AF <> '8' AND IFNULL(SERVICE,'') = '1'  ORDER BY PROVIDER ")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboProvider
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "PROVIDER_NAME"
                .Properties.ValueMember = "PROVIDER"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = "พิมพ์เพื่อค้นหา"
            End With
        End If
    End Sub
    Private Sub ShowData()
        Dim tmpSQL As String = ""

        'If CheckBox1.Checked = True Then
        tmpSQL = " AND B.PROVIDER = '" & cboProvider.EditValue & "'"
        'Else
        '    tmpSQL = ""
        'End If

        Dim DateStart As String = CDate(dtpStart.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))
        Dim DateEnd As String = CDate(dtpEnd.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("SUBSTR(A.DATE_SERV,1,6) AS MONTH_SERV,SUBSTR(A.DATE_SERV,1,4)+543 AS YEAR_SERV,SUBSTR(A.DATE_SERV,5,2) AS MONTH_SERV2,COUNT(DISTINCT(B.SEQ)) AS COUNT_ALL," _
                                                 & "COUNT(DISTINCT(CASE WHEN INSTYPE = '0100' THEN B.SEQ END)) AS COUNT_UC," _
                                                 & "COUNT(DISTINCT(CASE WHEN PROCEDCODE IN('2372700','2382770') THEN B.SEQ END)) AS P_EX," _
                                                 & "COUNT(CASE WHEN PROCEDCODE IN('2372700','2382770') THEN B.SEQ END) AS C_EX," _
                                                 & "COUNT(DISTINCT(CASE WHEN PROCEDCODE IN('2372700','2382770') AND INSTYPE = '0100' THEN B.SEQ END)) AS P_EX2," _
                                                 & "COUNT(CASE WHEN PROCEDCODE IN('2372700','2382770') AND INSTYPE = '0100' THEN B.SEQ END) AS C_EX2," _
                                                 & "COUNT(DISTINCT(CASE WHEN SUBSTR(PROCEDCODE,1,5) IN('23771','23871') THEN B.SEQ END)) AS P_EX3," _
                                                 & "COUNT(CASE WHEN SUBSTR(PROCEDCODE,1,5) IN('23771','23871') THEN B.SEQ END) AS C_EX3," _
                                                 & "COUNT(DISTINCT(CASE WHEN SUBSTR(PROCEDCODE,1,5) IN('23771','23871') AND INSTYPE = '0100'  THEN B.SEQ END)) AS P_EX4," _
                                                 & "COUNT(CASE WHEN SUBSTR(PROCEDCODE,1,5) IN('23771','23871') AND INSTYPE = '0100' THEN B.SEQ END) AS C_EX4," _
                                                 & "COUNT(DISTINCT(CASE WHEN SUBSTR(PROCEDCODE,1,5) IN('22773','22873') THEN B.SEQ END)) AS P_EX5," _
                                                 & "COUNT(CASE WHEN SUBSTR(PROCEDCODE,1,5) IN('22773','22873') THEN B.SEQ END) AS C_EX5," _
                                                 & "COUNT(DISTINCT(CASE WHEN SUBSTR(PROCEDCODE,1,5) IN('22773','22873') AND INSTYPE = '0100' THEN B.SEQ END)) AS P_EX5_2," _
                                                 & "COUNT(CASE WHEN SUBSTR(PROCEDCODE,1,5) IN('22773','22873') AND INSTYPE = '0100' THEN B.SEQ END) AS C_EX5_2," _
                                                 & "COUNT(DISTINCT(CASE WHEN PROCEDCODE IN('2377030','2387030') THEN B.SEQ END)) AS P_EX6," _
                                                 & "COUNT(CASE WHEN PROCEDCODE IN('2377030','2387030') THEN B.SEQ END) AS C_EX6," _
                                                 & "COUNT(DISTINCT(CASE WHEN PROCEDCODE IN('2377030','2387030') AND INSTYPE = '0100' THEN B.SEQ END)) AS P_EX7," _
                                                 & "COUNT(CASE WHEN PROCEDCODE IN('2377030','2387030') AND INSTYPE = '0100' THEN B.SEQ END) AS C_EX7," _
                                                 & "COUNT(DISTINCT(CASE WHEN PROCEDCODE IN('2377020','2377021','2387020','2387021') THEN B.SEQ END)) AS P_EX8," _
                                                 & "COUNT(DISTINCT(CASE WHEN PROCEDCODE IN('2377020','2377021','2387020','2387021')  AND INSTYPE = '0100' THEN B.SEQ END)) AS C_EX8," _
                                                 & "COUNT(DISTINCT(CASE WHEN PROCEDCODE IN('2377010','2377021','2387010','2387021') THEN B.SEQ END)) AS P_EX9," _
                                                 & "COUNT(DISTINCT(CASE WHEN PROCEDCODE IN('2377010','2377021','2387010','2387021')  AND INSTYPE = '0100' THEN B.SEQ END)) AS C_EX9," _
                                                 & "COUNT(DISTINCT(CASE WHEN PROCEDCODE NOT IN('2372700','2382770') AND SUBSTR(PROCEDCODE,1,5) NOT IN('23771','23871') AND SUBSTR(PROCEDCODE,1,5) NOT IN('22773','22873') AND  SUBSTR(PROCEDCODE,1,5) NOT IN('22772') AND SUBSTR(PROCEDCODE,1,6) NOT IN('228742') AND SUBSTR(PROCEDCODE,1,6) NOT IN('228741')  AND SUBSTR(PROCEDCODE,1,5) NOT IN('23826') AND PROCEDCODE NOT IN('2377010','2377020','2377021','2387010','2387020','2387021') AND PROCEDCODE NOT IN('2377030','2387030') THEN B.SEQ END)) AS P_EX10," _
                                                 & "COUNT(DISTINCT(CASE WHEN (PROCEDCODE NOT IN('2372700','2382770') AND SUBSTR(PROCEDCODE,1,5) NOT IN('23771','23871') AND SUBSTR(PROCEDCODE,1,5) NOT IN('22773','22873') AND  SUBSTR(PROCEDCODE,1,5) NOT IN('22772') AND SUBSTR(PROCEDCODE,1,6) NOT IN('228742') AND SUBSTR(PROCEDCODE,1,6) NOT IN('228741')  AND SUBSTR(PROCEDCODE,1,5) NOT IN('23826') AND PROCEDCODE NOT IN('2377010','2377020','2377021','2387010','2387020','2387021') AND PROCEDCODE NOT IN('2377030','2387030')) AND INSTYPE = '0100' THEN B.SEQ END)) AS C_EX10" _
                                                 , "m_service A JOIN m_procedure_opd B ON(A.SEQ = B.SEQ) JOIN l_icd9 C ON(B.PROCEDCODE = C.CODE) ", " WHERE (A.DATE_SERV >= " & DateStart & " AND A.DATE_SERV <= " & DateEnd & ") AND C.DENTAL = 'Y' " & tmpSQL & " AND PROVIDER IN(SELECT PROVIDER FROM m_provider WHERE PROVIDERTYPE IN('02','06')) GROUP BY SUBSTR(A.DATE_SERV,1,6) ")
        If ds.Tables(0).Rows.Count > 0 Then
            DisplayData(ds)
            cmdPrint.Enabled = True
        Else
            BetterListView1.Items.Clear()
            cmdPrint.Enabled = False
        End If
    End Sub
    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        Dim fReport As New frmReportView
        Dim params As ReportParameter
        params = New ReportParameter("RateId")
        fReport.ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\Reports\rptDental2.rdlc"

        fReport.ReportViewer1.LocalReport.DataSources.Clear()
        CurrentReportDataSource.Name = "DataSet1"
        CurrentReportDataSource.value = dsRpt.Tables(0)
        fReport.ReportViewer1.LocalReport.DataSources.Add(CurrentReportDataSource)

        fReport.ShowDialog()

    End Sub
    Private Sub DisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim itm As BetterListViewItem

        Dim dr As DataRow
        Dim sum1 As Integer = 0
        Dim sum2 As Integer = 0
        Dim sum3 As Integer = 0
        Dim sum4 As Integer = 0
        Dim sum5 As Integer = 0
        Dim sum6 As Integer = 0
        Dim sum7 As Integer = 0
        Dim sum8 As Integer = 0
        Dim sum9 As Integer = 0
        Dim sum10 As Integer = 0
        Dim sum11 As Integer = 0
        Dim sum12 As Integer = 0
        Dim sum13 As Integer = 0
        Dim sum14 As Integer = 0
        Dim sum15 As Integer = 0
        Dim sum16 As Integer = 0
        Dim sum17 As Integer = 0
        Dim sum18 As Integer = 0
        Dim sum19 As Integer = 0
        Dim sum20 As Integer = 0
        Dim sum21 As Integer = 0
        Dim sum22 As Integer = 0
        Dim sum23 As Integer = 0
        Dim sum24 As Integer = 0
        Dim sum25 As Integer = 0
        Dim k As Integer = 0

        Dim dt As DataTable
        dt = New DataTable()
        dt.Clear()
        Dim drRpt As DataRow
        Dim Coulumn1 = New DataColumn("F1", Type.GetType("System.String"))
        Dim Coulumn2 = New DataColumn("F2", Type.GetType("System.String"))
        Dim Coulumn3 = New DataColumn("F3", Type.GetType("System.String"))
        Dim Coulumn4 = New DataColumn("F4", Type.GetType("System.String"))
        Dim Coulumn5 = New DataColumn("F5", Type.GetType("System.String"))
        Dim Coulumn6 = New DataColumn("F6", Type.GetType("System.String"))
        Dim Coulumn7 = New DataColumn("F7", Type.GetType("System.String"))
        Dim Coulumn8 = New DataColumn("F8", Type.GetType("System.String"))
        Dim Coulumn9 = New DataColumn("F9", Type.GetType("System.String"))
        Dim Coulumn10 = New DataColumn("F10", Type.GetType("System.String"))
        Dim Coulumn11 = New DataColumn("F11", Type.GetType("System.String"))
        Dim Coulumn12 = New DataColumn("F12", Type.GetType("System.String"))
        Dim Coulumn13 = New DataColumn("F13", Type.GetType("System.String"))
        Dim Coulumn14 = New DataColumn("F14", Type.GetType("System.String"))
        Dim Coulumn15 = New DataColumn("F15", Type.GetType("System.String"))
        Dim Coulumn16 = New DataColumn("F16", Type.GetType("System.String"))
        Dim Coulumn17 = New DataColumn("F17", Type.GetType("System.String"))
        Dim Coulumn18 = New DataColumn("F18", Type.GetType("System.String"))
        Dim Coulumn19 = New DataColumn("F19", Type.GetType("System.String"))
        Dim Coulumn20 = New DataColumn("F20", Type.GetType("System.String"))
        Dim Coulumn21 = New DataColumn("F21", Type.GetType("System.String"))
        Dim Coulumn22 = New DataColumn("F22", Type.GetType("System.String"))
        Dim Coulumn23 = New DataColumn("F23", Type.GetType("System.String"))
        Dim Coulumn24 = New DataColumn("F24", Type.GetType("System.String"))
        Dim Coulumn25 = New DataColumn("F25", Type.GetType("System.String"))
        Dim Coulumn26 = New DataColumn("F26", Type.GetType("System.String"))
        Dim Coulumn27 = New DataColumn("F27", Type.GetType("System.String"))
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
        dt.Columns.Add(Coulumn14)
        dt.Columns.Add(Coulumn15)
        dt.Columns.Add(Coulumn16)
        dt.Columns.Add(Coulumn17)
        dt.Columns.Add(Coulumn18)
        dt.Columns.Add(Coulumn19)
        dt.Columns.Add(Coulumn20)
        dt.Columns.Add(Coulumn21)
        dt.Columns.Add(Coulumn22)
        dt.Columns.Add(Coulumn23)
        dt.Columns.Add(Coulumn24)
        dt.Columns.Add(Coulumn25)
        dt.Columns.Add(Coulumn26)
        dt.Columns.Add(Coulumn27)
        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                Dim tmpMonthName As String = "'"
                If dr("MONTH_SERV").ToString.Substring(4, 2) = "10" Then
                    tmpMonthName = "ต.ค. " & CStr(CInt(dr("MONTH_SERV").ToString.Substring(0, 4)) + 543).Substring(2, 2)
                ElseIf dr("MONTH_SERV").ToString.Substring(4, 2) = "11" Then
                    tmpMonthName = "พ.ย. " & CStr(CInt(dr("MONTH_SERV").ToString.Substring(0, 4)) + 543).Substring(2, 2)
                ElseIf dr("MONTH_SERV").ToString.Substring(4, 2) = "12" Then
                    tmpMonthName = "ธ.ค. " & CStr(CInt(dr("MONTH_SERV").ToString.Substring(0, 4)) + 543).Substring(2, 2)
                ElseIf dr("MONTH_SERV").ToString.Substring(4, 2) = "01" Then
                    tmpMonthName = "ม.ค. " & CStr(CInt(dr("MONTH_SERV").ToString.Substring(0, 4)) + 543).Substring(2, 2)
                ElseIf dr("MONTH_SERV").ToString.Substring(4, 2) = "02" Then
                    tmpMonthName = "ก.พ. " & CStr(CInt(dr("MONTH_SERV").ToString.Substring(0, 4)) + 543).Substring(2, 2)
                ElseIf dr("MONTH_SERV").ToString.Substring(4, 2) = "03" Then
                    tmpMonthName = "มี.ค. " & CStr(CInt(dr("MONTH_SERV").ToString.Substring(0, 4)) + 543).Substring(2, 2)
                ElseIf dr("MONTH_SERV").ToString.Substring(4, 2) = "04" Then
                    tmpMonthName = "เม.ย. " & CStr(CInt(dr("MONTH_SERV").ToString.Substring(0, 4)) + 543).Substring(2, 2)
                ElseIf dr("MONTH_SERV").ToString.Substring(4, 2) = "05" Then
                    tmpMonthName = "พ.ค. " & CStr(CInt(dr("MONTH_SERV").ToString.Substring(0, 4)) + 543).Substring(2, 2)
                ElseIf dr("MONTH_SERV").ToString.Substring(4, 2) = "06" Then
                    tmpMonthName = "มิ.ย. " & CStr(CInt(dr("MONTH_SERV").ToString.Substring(0, 4)) + 543).Substring(2, 2)
                ElseIf dr("MONTH_SERV").ToString.Substring(4, 2) = "07" Then
                    tmpMonthName = "ก.ค. " & CStr(CInt(dr("MONTH_SERV").ToString.Substring(0, 4)) + 543).Substring(2, 2)
                ElseIf dr("MONTH_SERV").ToString.Substring(4, 2) = "08" Then
                    tmpMonthName = "ส.ค. " & CStr(CInt(dr("MONTH_SERV").ToString.Substring(0, 4)) + 543).Substring(2, 2)
                ElseIf dr("MONTH_SERV").ToString.Substring(4, 2) = "09" Then
                    tmpMonthName = "ก.ย. " & CStr(CInt(dr("MONTH_SERV").ToString.Substring(0, 4)) + 543).Substring(2, 2)
                End If

                BetterListView1.Items.Add(tmpMonthName).AlignHorizontal = TextAlignmentHorizontal.Center
                If Not IsDBNull(dr("COUNT_ALL")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("COUNT_ALL")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("COUNT_UC")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("COUNT_UC")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("P_EX")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("P_EX")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("C_EX")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("C_EX")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("P_EX2")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("P_EX2")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("C_EX2")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("C_EX2")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("P_EX3")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("P_EX3")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("C_EX3")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("C_EX3")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("P_EX4")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("P_EX4")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("C_EX4")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("C_EX4")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("P_EX5")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("P_EX5")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("C_EX5")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("C_EX5")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("P_EX5_2")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("P_EX5")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("C_EX5_2")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("C_EX5")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("P_EX6")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("P_EX6")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("C_EX6")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("C_EX6")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("P_EX7")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("P_EX7")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("C_EX7")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("C_EX7")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If

                If Not IsDBNull(dr("P_EX8")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("P_EX8")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("C_EX8")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("C_EX8")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("P_EX9")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("P_EX9")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("C_EX9")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("C_EX9")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("P_EX10")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("P_EX10")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("C_EX10")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("C_EX10")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.MintCream
                End If

                sum1 = CInt(dr("COUNT_ALL")) + sum1
                sum2 = CInt(dr("COUNT_UC")) + sum2
                sum3 = CInt(dr("P_EX")) + sum3
                sum4 = CInt(dr("C_EX")) + sum4
                sum5 = CInt(dr("P_EX2")) + sum5
                sum6 = CInt(dr("C_EX2")) + sum6
                sum7 = CInt(dr("P_EX3")) + sum7
                sum8 = CInt(dr("C_EX3")) + sum8
                sum9 = CInt(dr("P_EX4")) + sum9
                sum10 = CInt(dr("C_EX4")) + sum10
                sum11 = CInt(dr("P_EX5")) + sum11
                sum12 = CInt(dr("C_EX5")) + sum12
                sum13 = CInt(dr("P_EX5_2")) + sum13
                sum14 = CInt(dr("C_EX5_2")) + sum14
                sum15 = CInt(dr("P_EX6")) + sum15
                sum16 = CInt(dr("C_EX6")) + sum16
                sum17 = CInt(dr("P_EX7")) + sum17
                sum18 = CInt(dr("C_EX7")) + sum18
                sum19 = CInt(dr("P_EX8")) + sum19
                sum20 = CInt(dr("C_EX8")) + sum20
                sum21 = CInt(dr("P_EX9")) + sum21
                sum22 = CInt(dr("C_EX9")) + sum22
                sum23 = CInt(dr("P_EX10")) + sum23
                sum24 = CInt(dr("C_EX10")) + sum24


                dsRpt.Tables.Clear()
                drRpt = dt.NewRow()
                drRpt("F1") = "สถานบริการ " & ClsBusiness.Lc_Business.SELECT_NAME_HCODE(vHcode).Replace("รพ.สต.", "โรงพยาบาลส่งเสริมสุขภาพตำบล")

                drRpt("F2") = "ประมวลผลตั้งแต่วันที่ " & CDate(dtpStart.EditValue).ToString("d MMMM yyyy") & " ถึงวันที่ " & CDate(dtpEnd.EditValue).ToString("d MMMM yyyy")

                drRpt("F2") = "ผู้ให้บริการ " & ClsBusiness.Lc_Business.SELECT_NAME_PROVIDER(cboProvider.EditValue) & "   ประมวลผลตั้งแต่วันที่ " & CDate(dtpStart.EditValue).ToString("d MMMM yyyy") & " ถึงวันที่ " & CDate(dtpEnd.EditValue).ToString("d MMMM yyyy")


                drRpt("F3") = tmpMonthName
                drRpt("F4") = dr("COUNT_ALL")
                drRpt("F5") = dr("COUNT_UC")
                drRpt("F6") = dr("P_EX")
                drRpt("F7") = dr("C_EX")
                drRpt("F8") = dr("P_EX2")
                drRpt("F9") = dr("C_EX2")
                drRpt("F10") = dr("P_EX3")
                drRpt("F11") = dr("C_EX3")
                drRpt("F12") = dr("P_EX4")
                drRpt("F13") = dr("C_EX4")
                drRpt("F14") = dr("P_EX5")
                drRpt("F15") = dr("C_EX5")
                drRpt("F16") = dr("P_EX5_2")
                drRpt("F17") = dr("C_EX5_2")
                drRpt("F18") = dr("P_EX6")
                drRpt("F19") = dr("C_EX6")
                drRpt("F20") = dr("P_EX7")
                drRpt("F21") = dr("C_EX7")
                drRpt("F22") = dr("P_EX8")
                drRpt("F23") = dr("C_EX8")
                drRpt("F24") = dr("P_EX9")
                drRpt("F25") = dr("C_EX9")
                drRpt("F26") = dr("P_EX10")
                drRpt("F27") = dr("C_EX10")

                dt.Rows.Add(drRpt)
                k = k + 1
            Next

            dsRpt.Tables.Add(dt)
            BetterListView1.Items.Add("รวม")

            BetterListView1.Items(k).SubItems.Add(CInt(sum1).ToString("#,##0"))
            BetterListView1.Items(k).SubItems.Add(CInt(sum2).ToString("#,##0"))
            BetterListView1.Items(k).SubItems.Add(CInt(sum3).ToString("#,##0"))
            BetterListView1.Items(k).SubItems.Add(CInt(sum4).ToString("#,##0"))
            BetterListView1.Items(k).SubItems.Add(CInt(sum5).ToString("#,##0"))

            BetterListView1.Items(k).SubItems.Add(CInt(sum6).ToString("#,##0"))
            BetterListView1.Items(k).SubItems.Add(CInt(sum7).ToString("#,##0"))
            BetterListView1.Items(k).SubItems.Add(CInt(sum8).ToString("#,##0"))
            BetterListView1.Items(k).SubItems.Add(CInt(sum9).ToString("#,##0"))
            BetterListView1.Items(k).SubItems.Add(CInt(sum10).ToString("#,##0"))

            BetterListView1.Items(k).SubItems.Add(CInt(sum11).ToString("#,##0"))
            BetterListView1.Items(k).SubItems.Add(CInt(sum12).ToString("#,##0"))
            BetterListView1.Items(k).SubItems.Add(CInt(sum13).ToString("#,##0"))
            BetterListView1.Items(k).SubItems.Add(CInt(sum14).ToString("#,##0"))
            BetterListView1.Items(k).SubItems.Add(CInt(sum15).ToString("#,##0"))

            BetterListView1.Items(k).SubItems.Add(CInt(sum16).ToString("#,##0"))
            BetterListView1.Items(k).SubItems.Add(CInt(sum17).ToString("#,##0"))
            BetterListView1.Items(k).SubItems.Add(CInt(sum18).ToString("#,##0"))
            BetterListView1.Items(k).SubItems.Add(CInt(sum19).ToString("#,##0"))
            BetterListView1.Items(k).SubItems.Add(CInt(sum20).ToString("#,##0"))

            BetterListView1.Items(k).SubItems.Add(CInt(sum21).ToString("#,##0"))
            BetterListView1.Items(k).SubItems.Add(CInt(sum22).ToString("#,##0"))
            BetterListView1.Items(k).SubItems.Add(CInt(sum23).ToString("#,##0"))
            BetterListView1.Items(k).SubItems.Add(CInt(sum24).ToString("#,##0"))


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub DisplayData2(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itm As ListViewItem
        Dim tmpPrename As String = ""
        Dim tmpDNAME As String = ""
        Dim tmpAmount As String = ""
        Dim tmpPrice As String = ""
        Dim tmpDose As String = ""
        Dim tmpOder As String = ""
        Dim tmpDx As String = ""
        Dim dt As DataTable
        dt = New DataTable()
        dt.Clear()
        Dim drRpt As DataRow
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
        Dim Coulumn14 = New DataColumn("FIELD14", Type.GetType("System.String"))
        Dim Coulumn15 = New DataColumn("FIELD15", Type.GetType("System.String"))
        Dim Coulumn16 = New DataColumn("FIELD16", Type.GetType("System.String"))
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
        dt.Columns.Add(Coulumn14)
        dt.Columns.Add(Coulumn15)
        dt.Columns.Add(Coulumn16)
        Dim tmpName As String = ""
        Dim StrAge2 As String = ""
        Dim tmpHouse As String = ""
        Dim tmpCID As String = ""
        Dim tmpDateServ As String = ""
        Dim tmpBP As String = ""
        Dim tmpBMI As String = ""
        Dim tmpAge As String = ""
        Dim tmpRx As String = ""
        Dim tmpPx As String = ""
        Dim tmpProvider As String = ""
        Dim tmpPID As String = ""
        Dim tmpOrder As String = ""

        Try
            BetterListView2.Items.Clear()
            BetterListView2.BeginUpdate()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                dsRpt.Tables.Clear()
                drRpt = dt.NewRow()
                tmpOrder = (i + 1).ToString
                BetterListView2.Items.Add(tmpOrder)
                If Not IsDBNull(dr("ROWID")) Then
                    BetterListView2.Items(i).SubItems.Add(dr("ROWID"))
                Else
                    BetterListView2.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("CID")) Then
                    Try
                        BetterListView2.Items(i).SubItems.Add(Decode(dr("CID")))
                        tmpCID = Decode(dr("CID"))
                    Catch ex As Exception
                        BetterListView2.Items(i).SubItems.Add("ข้อมูลผิดพลาด")
                        tmpCID = ""
                    End Try
                Else
                    BetterListView2.Items(i).SubItems.Add("-")
                End If
                If Not IsDBNull(dr("PID")) Then
                    BetterListView2.Items(i).SubItems.Add(dr("PID"))
                Else
                    BetterListView2.Items(i).SubItems.Add("-")
                End If
                If Not IsDBNull(dr("HN")) Then
                    BetterListView2.Items(i).SubItems.Add(dr("HN"))
                Else
                    BetterListView2.Items(i).SubItems.Add("-")
                End If
                If Not IsDBNull(dr("PRENAME")) Then
                    tmpPrename = clsdataBus.Lc_Business.SELECT_NAME_PRENAME(dr("PRENAME"))
                End If
                Try
                    BetterListView2.Items(i).SubItems.Add(tmpPrename & (Decode(dr("NAME"))) & " " & (Decode(dr("LNAME"))))
                    tmpName = tmpPrename & (Decode(dr("NAME"))) & " " & (Decode(dr("LNAME")))
                Catch ex As Exception
                    BetterListView2.Items(i).SubItems.Add("ข้อมูลผิดพลาด")
                    tmpName = ""
                End Try
                If IsDBNull(dr("BIRTH")) Then
                    BetterListView2.Items(i).SubItems.Add("ไม่มีข้อมูล")

                Else
                    If dr("BIRTH") <> "" Then
                        Dim tmpDOB = dr("BIRTH").ToString.Substring(0, 4) + 543 & dr("BIRTH").ToString.Substring(4, 4)
                        If CheckDate(DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("dd/MM/yyyy")) = True Then
                            Dim tmpDOS As String = dr("DATE_SERV").ToString.Substring(0, 4) + 543 & dr("DATE_SERV").ToString.Substring(4, 4)
                            Dim tmpDOS2 As DateTime = DateTime.ParseExact(tmpDOS, "yyyyMMdd", CultureInfo.CurrentCulture)
                            Dim DOB As DateTime = DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture)
                            Dim Years As Integer = 0
                            Dim Month As Integer = 0
                            Dim Days As Integer = 0
                            Dim StrAge As String = Nothing
                            ' Check if the DOB is less than current date
                            If DOB < tmpDOS2 Then
                                ' Calculate Difference between current date and DOB
                                Dim dateDiff As TimeSpan = tmpDOS2 - DOB
                                Dim age As New DateTime(dateDiff.Ticks)
                                Years = age.Year - 1
                                Month = age.Month - 1
                                Days = age.Day - 1
                                BetterListView2.Items(i).SubItems.Add(Years.ToString() & "/" & Month.ToString() & "/" & Days.ToString())
                            Else
                                BetterListView2.Items(i).SubItems.Add("วันเดือนปีเกิดไม่ถูกต้อง")
                            End If
                            'itm.SubItems.Add(DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy"))
                        Else

                            BetterListView2.Items(i).SubItems.Add("")
                        End If
                    Else
                        BetterListView2.Items(i).SubItems.Add("ไม่มีข้อมูล")

                    End If

                End If

                If Not IsDBNull(dr("DATE_SERV")) Then
                    BetterListView2.Items(i).SubItems.Add(dr("DATE_SERV"))
                    BetterListView2.Items(i).SubItems.Add(DateTime.ParseExact(dr("DATE_SERV").ToString.Substring(0, 4) + 543 & dr("DATE_SERV").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy"))
                    tmpDateServ = DateTime.ParseExact(dr("DATE_SERV").ToString.Substring(0, 4) + 543 & dr("DATE_SERV").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yy")
                Else
                    BetterListView2.Items(i).SubItems.Add("")
                    BetterListView2.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("SERVPLACE")) Then
                    If dr("SERVPLACE") = "1" Then
                        BetterListView2.Items(i).SubItems.Add("ในหน่วยฯ")
                    Else
                        BetterListView2.Items(i).SubItems.Add("นอกหน่วยฯ")
                    End If
                Else
                    BetterListView2.Items(i).SubItems.Add("")
                End If

                If Not IsDBNull(dr("PROCEDCODE")) Then

                    BetterListView2.Items(i).SubItems.Add(dr("DESC_THA") & " (" & dr("PROCEDCODE") & ")")

                    Dim ds3 As DataSet
                    ds3 = clsdataBus.Lc_Business.SELECT_TABLE("PROCEDCODE,DESC_THA", "m_procedure_opd A JOIN l_icd9 B ON(A.PROCEDCODE = B.CODE) ", "WHERE 10TMD = 'Y' AND STATUS_AF <> '8' AND SEQ = '" & dr("SEQ") & "'")
                    If ds3.Tables(0).Rows.Count > 0 Then
                        For h As Integer = 0 To ds3.Tables(0).Rows.Count - 1
                            If h = 0 Then
                                tmpDx = (h + 1).ToString & ". " & ds3.Tables(0).Rows(h).Item("DESC_THA") & " (" & ds3.Tables(0).Rows(h).Item("PROCEDCODE") & ")"
                            Else
                                tmpDx = tmpDx & vbCrLf & (h + 1).ToString & ". " & ds3.Tables(0).Rows(h).Item("DESC_THA") & " (" & ds3.Tables(0).Rows(h).Item("PROCEDCODE") & ")"
                            End If
                        Next
                    Else
                        tmpDx = "1. " & dr("DESC_THA")
                    End If

                Else
                    itm.SubItems.Add("")
                End If

                If Not IsDBNull(dr("PROVIDER")) Then
                    itm.SubItems.Add(ClsBusiness.Lc_Business.SELECT_NAME_PROVIDER(dr("PROVIDER")))
                Else
                    itm.SubItems.Add("")
                End If
                If Not IsDBNull(dr("D_UPDATE")) Then
                    itm.SubItems.Add(DateTime.ParseExact(dr("D_UPDATE").ToString.Substring(0, 4) + 543 & dr("D_UPDATE").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy"))
                Else
                    itm.SubItems.Add("")
                End If

                If (itm.Index Mod 2) = 0 Then
                    itm.BackColor = Color.FromArgb(255, 255, 128)
                End If

                drRpt("FIELD1") = ClsBusiness.Lc_Business.SELECT_NAME_HCODE(vHcode).ToString.Replace("รพ.สต.", "โรงพยาบาลส่งเสริมสุขภาพตำบล") & vbCrLf & "ข้อมูลการให้บริการตั้งแต่วันที่ " & CDate(dtpStart.EditValue).ToString("d MMMM yyyy") & " ถึงวันที่ " & CDate(dtpEnd.EditValue).ToString("d MMMM yyyy")
                drRpt("FIELD2") = tmpOrder
                drRpt("FIELD3") = DateTime.ParseExact(dr("DATE_SERV").ToString.Substring(0, 4) + 543 & dr("DATE_SERV").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy")
                drRpt("FIELD4") = dr("HN")
                tmpPID = dr("HN")
                If IsDBNull(dr("BIRTH")) Then
                    tmpAge = "ไม่มีข้อมูล"
                    'itm.SubItems.Add("")
                Else
                    If dr("BIRTH") <> "" Then
                        Dim tmpDOB = dr("BIRTH").ToString.Substring(0, 4) + 543 & dr("BIRTH").ToString.Substring(4, 4)
                        If CheckDate(DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("dd/MM/yyyy")) = True Then
                            Dim tmpDOS As String = dr("DATE_SERV").ToString.Substring(0, 4) + 543 & dr("DATE_SERV").ToString.Substring(4, 4)
                            Dim tmpDOS2 As DateTime = DateTime.ParseExact(tmpDOS, "yyyyMMdd", CultureInfo.CurrentCulture)
                            Dim DOB As DateTime = DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture)
                            Dim Years As Integer = 0
                            Dim Month As Integer = 0
                            Dim Days As Integer = 0
                            Dim StrAge As String = Nothing
                            ' Check if the DOB is less than current date
                            If DOB < tmpDOS2 Then
                                ' Calculate Difference between current date and DOB
                                Dim dateDiff As TimeSpan = tmpDOS2 - DOB
                                Dim age As New DateTime(dateDiff.Ticks)
                                Years = age.Year - 1
                                Month = age.Month - 1
                                Days = age.Day - 1
                                tmpAge = ((Years.ToString() & "/") + Month.ToString() & "/") + Days.ToString()
                            Else
                                tmpAge = "วันเดือนปีเกิดไม่ถูกต้อง"
                            End If
                            'itm.SubItems.Add(DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy"))
                        Else
                            'itm.SubItems.Add("")
                            tmpAge = ""
                        End If
                    Else
                        tmpAge = "ไม่มีข้อมูล"
                        'itm.SubItems.Add("")
                    End If

                End If

                If Not IsDBNull(dr("PRENAME")) Then
                    tmpPrename = clsdataBus.Lc_Business.SELECT_NAME_PRENAME(dr("PRENAME"))
                End If
                Try
                    drRpt("FIELD5") = tmpPrename & (Decode(dr("NAME"))) & " " & (Decode(dr("LNAME"))) _
                                      & vbCrLf & "เลขประชาชน : " & Decode(dr("CID")) _
                                      & vbCrLf & "อายุ : " & tmpAge _
                                      & vbCrLf & "ที่อยู่ : " & ClsBusiness.Lc_Business.SELECT_NAME_ADDRESS_PID(dr("PID"))
                Catch ex As Exception
                    drRpt("FIELD5") = "มีข้อผิดพลาด!!!"
                End Try

                drRpt("FIELD6") = "สิทธิ : " & ClsBusiness.Lc_Business.SELECT_NAME_INSTYPE_NEW(dr("INSTYPE")) _
                                 & vbCrLf & "เลขบัตร : " & dr("INSID") _
                                 & vbCrLf & "หน่วยบริการหลัก : " & ClsBusiness.Lc_Business.SELECT_NAME_HOSPITAL(dr("MAIN"))



                Dim ds6 As DataSet
                ds6 = clsdataBus.Lc_Business.SELECT_TABLE("DIAGCODE,DESC_THAI,PROVIDER", "m_diagnosis_opd A JOIN l_icd10 B ON(A.DIAGCODE = B.CODE) ", "WHERE STATUS_AF <> '8' AND SEQ = '" & dr("SEQ") & "' ORDER BY DIAGTYPE")
                If ds6.Tables(0).Rows.Count > 0 Then
                    For h As Integer = 0 To ds6.Tables(0).Rows.Count - 1
                        If h = 0 Then
                            tmpDx = "PDx : " & ds6.Tables(0).Rows(h).Item("DIAGCODE") & " " & ds6.Tables(0).Rows(h).Item("DESC_THAI")
                            tmpProvider = ClsBusiness.Lc_Business.SELECT_NAME_PROVIDER(ds6.Tables(0).Rows(h).Item("PROVIDER"))
                        Else
                            tmpDx = tmpDx & vbCrLf & "SDx : " & (h).ToString & ". " & ds6.Tables(0).Rows(h).Item("DIAGCODE") & " " & ds6.Tables(0).Rows(h).Item("DESC_THAI")
                        End If
                    Next
                Else
                    tmpDx = "'"
                End If
                drRpt("FIELD7") = "อาการสำคัญ : " & dr("CHIEFCOMP") _
                                    & vbCrLf & tmpDx _
                                    & vbCrLf & "ผู้วินิจฉัย/รักษา : " & tmpProvider

                Dim ds4 As DataSet
                ds4 = clsdataBus.Lc_Business.SELECT_TABLE("DNAME,AMOUNT", "m_drug_opd", "WHERE STATUS_AF <> '8' AND SEQ = '" & dr("SEQ") & "'")
                If ds4.Tables(0).Rows.Count > 0 Then
                    For k As Integer = 0 To ds4.Tables(0).Rows.Count - 1
                        If k = 0 Then
                            tmpRx = (k + 1).ToString & ". " & ds4.Tables(0).Rows(k).Item("DNAME") & " (" & ds4.Tables(0).Rows(k).Item("AMOUNT") & ")"
                        Else
                            tmpRx = tmpRx & vbCrLf & (k + 1).ToString & ". " & ds4.Tables(0).Rows(k).Item("DNAME") & " (" & ds4.Tables(0).Rows(k).Item("AMOUNT") & ")"
                        End If
                    Next
                Else
                    tmpRx = ""
                End If

                Dim ds5 As DataSet
                ds5 = clsdataBus.Lc_Business.SELECT_TABLE("PROCEDCODE,DESC_THA", "m_procedure_opd A JOIN l_icd9 B ON(A.PROCEDCODE = B.CODE) ", "WHERE STATUS_AF <> '8' AND SEQ = '" & dr("SEQ") & "'")
                If ds5.Tables(0).Rows.Count > 0 Then
                    For h As Integer = 0 To ds5.Tables(0).Rows.Count - 1
                        If h = 0 Then
                            tmpPx = (h + 1).ToString & ". " & ds5.Tables(0).Rows(h).Item("PROCEDCODE") & " " & ds5.Tables(0).Rows(h).Item("DESC_THA")
                        Else
                            tmpPx = tmpPx & vbCrLf & (h + 1).ToString & ". " & ds5.Tables(0).Rows(h).Item("PROCEDCODE") & " " & ds5.Tables(0).Rows(h).Item("DESC_THA")
                        End If
                    Next
                Else
                    tmpPx = ""
                End If


                drRpt("FIELD8") = "ยา : " & vbCrLf & tmpRx & vbCrLf & "หัตถการ : " & vbCrLf & tmpPx
                drRpt("FIELD9") = "ต้นทุน : " & dr("COST") & vbCrLf & "ค่าบริการ : " & dr("PRICE") & vbCrLf & "จ่ายจริง : " & dr("PAYPRICE")



                dt.Rows.Add(drRpt)
            Next

            BetterListView2.EndUpdate()
            dsRpt.Tables.Add(dt)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub cmdPrint2_Click(sender As Object, e As EventArgs) Handles cmdPrint2.Click
        Dim fReport As New frmReportView
        Dim params As ReportParameter
        params = New ReportParameter("RateId")
        fReport.ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\Reports\rptServiceReport.rdlc"

        fReport.ReportViewer1.LocalReport.DataSources.Clear()
        CurrentReportDataSource.Name = "DataSet20F"
        CurrentReportDataSource.value = dsRpt.Tables(0)
        fReport.ReportViewer1.LocalReport.DataSources.Add(CurrentReportDataSource)

        fReport.ShowDialog()

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        SplashScreenManager1.ShowWaitForm()
        cmdPrint.Enabled = False
        BetterListView1.Items.Clear()
        ShowData()
        SplashScreenManager1.CloseWaitForm()
    End Sub
End Class