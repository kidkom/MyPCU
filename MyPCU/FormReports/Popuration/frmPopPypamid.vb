Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Globalization
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Imports DevExpress.XtraCharts
Imports Microsoft.Reporting.WinForms

Public Class frmPopPypamid
    Dim dsRpt As New DataSet
    Dim dsRpt2 As New DataSet
    Dim tmpUpdate As String = ""
    Dim CurrentReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
    Private Sub frmPopPypamid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpDate1.EditValue = Now

        With BetterListView1
            .Columns.Add(0).Text = "ช่วงอายุ"
            .Columns(0).Width = 100
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ร้อยละ(ชาย)"
            .Columns(1).Width = 100
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "ร้อยละ(หญิง)"
            .Columns(2).Width = 100
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "ร้อยละ(รวม)"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "จำนวน(ชาย)"
            .Columns(4).Width = 100
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "จำนวน(หญิง)"
            .Columns(5).Width = 100
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "รวม"
            .Columns(6).Width = 100
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        cboVillge()
        Timer1.Enabled = True

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 100

        Timer1.Enabled = False
        SplashScreenManager1.ShowWaitForm()

        ShowUpdate()
        Showdata()

        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub cboVillge()
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
    Private Sub ShowUpdate()
        Dim ds As DataSet

        ds = clsdataBus.Lc_Business.SELECT_TABLE("IFNULL(D_UPDATE,'') AS D_UPDATE", "l_reports", " WHERE ROWID = '3' ")
        If ds.Tables(0).Rows.Count > 0 Then
            If ds.Tables(0).Rows(0).Item("D_UPDATE") <> "" Then
                Dim tmpDUD As String = ds.Tables(0).Rows(0).Item("D_UPDATE")
                Label3.Text = " ประมวลผลครั้งล่าสุดเมือ " & Thaidate_D_UPDATE(tmpDUD) & ""
            Else
                Label3.Text = "ยังไม่มีการประมวลผลข้อมูล"
            End If
        End If

    End Sub
    Private Sub Showdata()
        Dim ds As New DataSet
        Dim tmpAll As String = ""

        If chkAll.Checked = True Then
            ds = clsdataBus.Lc_Business.SELECT_TABLE(" AGE_GROUP, SUM(MALE) AS MALE,SUM(FEMALE) AS FEMALE, SUM(POP_ALL) AS POP_ALL ", "r_pop_age", " GROUP BY AGE_GROUP ORDER BY AGE_MIN+0")
        Else
            ds = clsdataBus.Lc_Business.SELECT_TABLE(" AGE_GROUP, SUM(MALE) AS MALE,SUM(FEMALE) AS FEMALE, SUM(POP_ALL) AS POP_ALL ", "r_pop_age", " WHERE ADDRESS = '" & cboVillage.EditValue & "' GROUP BY AGE_GROUP ORDER BY AGE_MIN+0")
        End If
        If ds.Tables(0).Rows.Count > 0 Then

            ChartControl1.Series("MALE").Points.Clear()
            ChartControl1.Series("FEMALE").Points.Clear()


            Try
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim P_MALE = CInt(ds.Tables(0).Rows(i).Item("MALE")) * -100 / CInt(ds.Tables(0).Rows(i).Item("POP_ALL"))
                    Dim P_FEMALE = CInt(ds.Tables(0).Rows(i).Item("FEMALE")) * 100 / CInt(ds.Tables(0).Rows(i).Item("POP_ALL"))

                    ChartControl1.Series("MALE").Points.Add(New SeriesPoint(ds.Tables(0).Rows(i).Item("AGE_GROUP"), CDbl(P_MALE).ToString("0.00")))
                    ChartControl1.Series("MALE").Label.TextPattern = "{A}: {VP:P0}"
                    ChartControl1.Series("FEMALE").Points.Add(New SeriesPoint(ds.Tables(0).Rows(i).Item("AGE_GROUP"), CDbl(P_FEMALE).ToString("0.00")))
                    ChartControl1.Series("FEMALE").Label.TextPattern = "{A}: {VP:P0}"
                Next
            Catch ex As Exception

            End Try


            DisplayData(ds)
        Else
            ChartControl1.Series("MALE").Points.Clear()
            ChartControl1.Series("FEMALE").Points.Clear()
            BetterListView1.Items.Clear()
        End If

    End Sub
    Private Sub DisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim tmpAge As String = ""
        Dim tmpMale As String = ""
        Dim tmpFemale As String = ""
        Dim tmpP_ALL As String = ""
        Dim tmpPALL As String = ""
        Dim tmpALL As String = ""
        Dim tmpP_Male As String = ""
        Dim tmpP_Female As String = ""
        Dim itm As ListViewItem
        Dim tmpSumMale As Integer = 0
        Dim tmpSumFeMale As Integer = 0
        Dim tmpSumALL As Integer = 0
        Dim tmpSumP As Double = 0.0
        Dim tmpSumP_MALE As Double = 0.0
        Dim tmpSumP_FEMALE As Double = 0.0
        Dim k As Integer = 0

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

        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                tmpAge = dr("AGE_GROUP").ToString
                tmpMale = CInt(dr("MALE"))
                tmpFemale = CInt(dr("FEMALE"))
                tmpPALL = (CInt(dr("MALE")) + CInt(dr("FEMALE"))).ToString("#,##0")
                tmpALL = CInt(dr("POP_ALL"))
                tmpP_Male = CDbl(CInt(dr("MALE")) * 100 / tmpALL).ToString("0.00")
                tmpP_Female = CDbl(CInt(dr("FEMALE")) * 100 / tmpALL).ToString("0.00")
                tmpP_ALL = CDbl(CInt(tmpPALL) * 100 / tmpALL).ToString("0.00")

                BetterListView1.Items.Add(tmpAge).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(tmpP_Male).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(tmpP_Female).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(tmpP_ALL).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(CInt(tmpMale).ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right
                BetterListView1.Items(i).SubItems.Add(CInt(tmpFemale).ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right
                BetterListView1.Items(i).SubItems.Add(CInt(tmpPALL).ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                tmpSumMale = tmpSumMale + tmpMale
                tmpSumFeMale = tmpSumFeMale + tmpFemale
                tmpSumP = tmpSumP + tmpP_ALL
                tmpSumP_MALE = tmpSumP_MALE + tmpP_Male
                tmpSumP_FEMALE = tmpSumP_FEMALE + tmpP_Female
                tmpSumALL = tmpSumALL + tmpPALL

                dsRpt.Tables.Clear()
                drRpt = dt.NewRow()
                drRpt("FIELD1") = "หน่วยบริการ " & vHname
                drRpt("FIELD2") = Label1.Text
                drRpt("FIELD3") = Label12.Text
                drRpt("FIELD4") = "ปรับปรุงข้อมูลเมื่อ " & tmpUpdate
                drRpt("FIELD5") = tmpAge
                drRpt("FIELD6") = tmpMale
                drRpt("FIELD7") = tmpFemale
                drRpt("FIELD8") = CInt(tmpMale) + CInt(tmpFemale)
                drRpt("FIELD9") = tmpP_Male
                drRpt("FIELD10") = tmpP_Female
                drRpt("FIELD11") = tmpP_ALL
                dt.Rows.Add(drRpt)

                k = i
            Next

            dsRpt.Tables.Add(dt)

            BetterListView1.ResumeSort(True)
            BetterListView1.EndUpdate()
            k = k + 1
            BetterListView1.Items.Add("รวม").AlignHorizontal = TextAlignmentHorizontal.Right
            BetterListView1.Items(k).SubItems.Add(CDbl(tmpSumMale * 100 / tmpSumALL).ToString("0.00")).AlignHorizontal = TextAlignmentHorizontal.Center
            BetterListView1.Items(k).SubItems.Add(CDbl(tmpSumFeMale * 100 / tmpSumALL).ToString("0.00")).AlignHorizontal = TextAlignmentHorizontal.Center
            BetterListView1.Items(k).SubItems.Add(CDbl(tmpSumALL * 100 / tmpSumALL).ToString("0.00")).AlignHorizontal = TextAlignmentHorizontal.Center
            BetterListView1.Items(k).SubItems.Add(CInt(tmpSumMale).ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right
            BetterListView1.Items(k).SubItems.Add(CInt(tmpSumFeMale).ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right
            BetterListView1.Items(k).SubItems.Add(CInt(tmpSumALL).ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right
            BetterListView1.Items(k).BackColor = Color.LightBlue
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub cmdNewProcess_Click(sender As Object, e As EventArgs) Handles cmdNewProcess.Click
        Dim ds As DataSet
        Dim ds2 As DataSet
        Dim ds3 As DataSet
        Dim POP_ALL As Integer = 0
        SplashScreenManager1.ShowWaitForm()
        Dim tmpDate1 = CDate(dtpDate1.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))
        clsbusent.Lc_BusinessEntity.Turncate_table("r_pop_age")
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_pop_age_lookup", " ORDER BY AGE_MIN+0")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim AGE_MIN As String = ""
            Dim AGE_MAX As String = ""
            Dim AGE_GROUP As String = ""
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                AGE_GROUP = ds.Tables(0).Rows(i).Item("AGE_GROUP")
                AGE_MIN = ds.Tables(0).Rows(i).Item("AGE_MIN")
                AGE_MAX = ds.Tables(0).Rows(i).Item("AGE_MAX")
                ds2 = clsdataBus.Lc_Business.SELECT_TABLE("A.HOSPCODE,CONCAT(B.CHANGWAT,B.AMPUR,B.TAMBON,B.VILLAGE,B.VILLANAME) AS ADDRESS, COUNT(DISTINCT(CASE WHEN SEX = '1' THEN PID END)) AS m_COUNT,COUNT(DISTINCT(CASE WHEN SEX = '2' THEN PID END)) AS F_COUNT,COUNT(DISTINCT(PID)) AS C_COUNT ", "m_person A JOIN m_home B ON(A.HID = B.HID)", " WHERE DISCHARGE = '9' AND (TYPEAREA <> '4' AND TYPEAREA <> '2') AND A.STATUS_AF <> '8' AND ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y')) - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d') < DATE_FORMAT(BIRTH,'00-%m-%d')) >= '" & AGE_MIN & "' AND (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y')) - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d') < DATE_FORMAT(BIRTH,'00-%m-%d')) <= '" & AGE_MAX & "' )  GROUP BY A.HOSPCODE,CONCAT(B.CHANGWAT,B.AMPUR,B.TAMBON,B.VILLAGE,B.VILLANAME)  ")
                If ds2.Tables(0).Rows.Count > 0 Then
                    For h As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                        Dim HOSPCODE As String = ds2.Tables(0).Rows(h).Item("HOSPCODE")
                        Dim ADDRESS As String = ds2.Tables(0).Rows(h).Item("ADDRESS")
                        Dim MALE As String = ds2.Tables(0).Rows(h).Item("M_COUNT")
                        Dim FEMALE As String = ds2.Tables(0).Rows(h).Item("F_COUNT")
                        ds3 = clsdataBus.Lc_Business.SELECT_TABLE("CONCAT(B.CHANGWAT,B.AMPUR,B.TAMBON,B.VILLAGE,B.VILLANAME) AS ADDRESS, COUNT(DISTINCT(PID)) AS C_COUNT", "m_person A JOIN m_home B ON(A.HID = B.HID)", " WHERE DISCHARGE = '9' AND (TYPEAREA <> '4' AND TYPEAREA <> '2') AND A.STATUS_AF <> '8' AND CONCAT(B.CHANGWAT,B.AMPUR,B.TAMBON,B.VILLAGE,B.VILLANAME) = '" & ADDRESS & "' AND ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y')) - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d') < DATE_FORMAT(BIRTH,'00-%m-%d')) >= '0' AND (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y')) - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d') < DATE_FORMAT(BIRTH,'00-%m-%d')) <= '999' ) ")
                        If ds3.Tables(0).Rows.Count > 0 Then
                            POP_ALL = ds3.Tables(0).Rows(0).Item("C_COUNT")
                        End If

                        clsbusent.Lc_BusinessEntity.Insertm_table("r_pop_age (AGE_GROUP,AGE_MIN,AGE_MAX,ADDRESS,MALE,FEMALE,POP_ALL)",
                              "'" & AGE_GROUP & "','" & AGE_MIN & "','" & AGE_MAX & "','" & ADDRESS & "','" & MALE & "','" & FEMALE & "','" & POP_ALL & "'")

                    Next
                End If

            Next
        End If
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate_En()
        clsbusent.Lc_BusinessEntity.Updatem_table("l_reports", "D_UPDATE = '" & tmpNow & "',USER_REC = '" & vUSERID & "'", "ROWID = '3'")
        ShowUpdate()
        Showdata()
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub chkAll_Click(sender As Object, e As EventArgs) Handles chkAll.Click
        chkAll.Checked = True
        chkArea.Checked = False
        Timer1.Enabled = True

    End Sub

    Private Sub cboVillage_EditValueChanged(sender As Object, e As EventArgs) Handles cboVillage.EditValueChanged
        Timer1.Enabled = True
    End Sub

    Private Sub chkArea_Click(sender As Object, e As EventArgs) Handles chkArea.Click
        chkAll.Checked = False
        chkArea.Checked = True
    End Sub

    Private Sub cmdPrint2_Click(sender As Object, e As EventArgs) Handles cmdPrint2.Click

        Dim fReport As New frmReportView

        fReport.ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\Reports\rptPopAge.rdlc"
        fReport.ReportViewer1.LocalReport.DataSources.Clear()
        CurrentReportDataSource.Name = "DataSet20F"
        CurrentReportDataSource.value = dsRpt.Tables(0)
        fReport.ReportViewer1.LocalReport.DataSources.Add(CurrentReportDataSource)
        fReport.ShowDialog()

    End Sub

    Private Sub cmdPrintVillage_Click(sender As Object, e As EventArgs) Handles cmdPrintVillage.Click
        SplashScreenManager1.ShowWaitForm()
        Dim tmpDate1 = CDate(dtpDate1.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("A.HOSPCODE,C.VILLAGE,VILLANAME,CONCAT(C.CHANGWAT,C.AMPUR,C.TAMBON) AS TAMBON,COUNT(DISTINCT(PID)) AS m_COUNT," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 0 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 4) AND SEX = '1' THEN PID END)) AS AGE1M," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 0 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 4) AND SEX = '2' THEN PID END)) AS AGE1F," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 5 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 9) AND SEX = '1' THEN PID END)) AS AGE2M," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 5 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 9) AND SEX = '2' THEN PID END)) AS AGE2F," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 10 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 14) AND SEX = '1' THEN PID END)) AS AGE3M," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 10 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 14) AND SEX = '2' THEN PID END)) AS AGE3F," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 15 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 19) AND SEX = '1' THEN PID END)) AS AGE4M," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 15 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 19) AND SEX = '2' THEN PID END)) AS AGE4F," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 20 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 24) AND SEX = '1' THEN PID END)) AS AGE5M," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 20 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 24) AND SEX = '2' THEN PID END)) AS AGE5F," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 25 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 29) AND SEX = '1' THEN PID END)) AS AGE6M," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 25 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 29) AND SEX = '2' THEN PID END)) AS AGE6F," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 30 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 34) AND SEX = '1' THEN PID END)) AS AGE7M," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 30 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 34) AND SEX = '2' THEN PID END)) AS AGE7F," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 35 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 39) AND SEX = '1' THEN PID END)) AS AGE8M," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 35 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 39) AND SEX = '2' THEN PID END)) AS AGE8F," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 40 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 44) AND SEX = '1' THEN PID END)) AS AGE9M," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 40 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 44) AND SEX = '2' THEN PID END)) AS AGE9F," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 45 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 49) AND SEX = '1' THEN PID END)) AS AGE10M," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 45 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 49) AND SEX = '2' THEN PID END)) AS AGE10F," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 50 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 54) AND SEX = '1' THEN PID END)) AS AGE11M," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 50 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 54) AND SEX = '2' THEN PID END)) AS AGE11F," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 55 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 59) AND SEX = '1' THEN PID END)) AS AGE12M," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 55 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 59) AND SEX = '2' THEN PID END)) AS AGE12F," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 60 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 64) AND SEX = '1' THEN PID END)) AS AGE13M," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 60 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 64) AND SEX = '2' THEN PID END)) AS AGE13F," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 65 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 69) AND SEX = '1' THEN PID END)) AS AGE14M," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 65 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 69) AND SEX = '2' THEN PID END)) AS AGE14F," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 70 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 74) AND SEX = '1' THEN PID END)) AS AGE15M," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 70 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 74) AND SEX = '2' THEN PID END)) AS AGE15F," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 75 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 79) AND SEX = '1' THEN PID END)) AS AGE16M," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 75 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 79) AND SEX = '2' THEN PID END)) AS AGE16F," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 80 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 84) AND SEX = '1' THEN PID END)) AS AGE17M," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 80 AND  (DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= 84) AND SEX = '2' THEN PID END)) AS AGE17F," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 85 ) AND SEX = '1' THEN PID END)) AS AGE18M," _
                                                 & "COUNT(DISTINCT(CASE WHEN ((DATE_FORMAT(" & tmpDate1 & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & tmpDate1 & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= 85 ) AND SEX = '2' THEN PID END)) AS AGE18F," _
                                                 & "COUNT(DISTINCT(CASE WHEN SEX = '1' THEN PID END)) AS MALE," _
                                                 & "COUNT(DISTINCT(CASE WHEN SEX = '2' THEN PID END)) AS FEMALE",
                                                 "m_person A JOIN m_home C ON(A.HOSPCODE = C.HOSPCODE AND A.HID = C.HID)",
                                                 "WHERE DISCHARGE = '9' AND A.STATUS_AF <> '8' AND TYPEAREA IN('1','3','5') GROUP BY A.HOSPCODE,C.TAMBON,C.VILLAGE,C.VILLANAME ORDER BY C.TAMBON,C.VILLAGE,C.VILLANAME ")
        If ds.Tables(0).Rows.Count > 0 Then

            Dim anyData() As String = Nothing
            Dim dr As DataRow

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
            Dim Coulumn17 = New DataColumn("FIELD17", Type.GetType("System.String"))
            Dim Coulumn18 = New DataColumn("FIELD18", Type.GetType("System.String"))
            Dim Coulumn19 = New DataColumn("FIELD19", Type.GetType("System.String"))
            Dim Coulumn20 = New DataColumn("FIELD20", Type.GetType("System.String"))
            Dim Coulumn21 = New DataColumn("FIELD21", Type.GetType("System.String"))
            Dim Coulumn22 = New DataColumn("FIELD22", Type.GetType("System.String"))
            Dim Coulumn23 = New DataColumn("FIELD23", Type.GetType("System.String"))
            Dim Coulumn24 = New DataColumn("FIELD24", Type.GetType("System.String"))
            Dim Coulumn25 = New DataColumn("FIELD25", Type.GetType("System.String"))
            Dim Coulumn26 = New DataColumn("FIELD26", Type.GetType("System.String"))
            Dim Coulumn27 = New DataColumn("FIELD27", Type.GetType("System.String"))
            Dim Coulumn28 = New DataColumn("FIELD28", Type.GetType("System.String"))
            Dim Coulumn29 = New DataColumn("FIELD29", Type.GetType("System.String"))
            Dim Coulumn30 = New DataColumn("FIELD30", Type.GetType("System.String"))
            Dim Coulumn31 = New DataColumn("FIELD31", Type.GetType("System.String"))
            Dim Coulumn32 = New DataColumn("FIELD32", Type.GetType("System.String"))
            Dim Coulumn33 = New DataColumn("FIELD33", Type.GetType("System.String"))
            Dim Coulumn34 = New DataColumn("FIELD34", Type.GetType("System.String"))
            Dim Coulumn35 = New DataColumn("FIELD35", Type.GetType("System.String"))
            Dim Coulumn36 = New DataColumn("FIELD36", Type.GetType("System.String"))
            Dim Coulumn37 = New DataColumn("FIELD37", Type.GetType("System.String"))
            Dim Coulumn38 = New DataColumn("FIELD38", Type.GetType("System.String"))
            Dim Coulumn39 = New DataColumn("FIELD39", Type.GetType("System.String"))
            Dim Coulumn40 = New DataColumn("FIELD40", Type.GetType("System.String"))
            Dim Coulumn41 = New DataColumn("FIELD41", Type.GetType("System.String"))
            Dim Coulumn42 = New DataColumn("FIELD42", Type.GetType("System.String"))
            Dim Coulumn43 = New DataColumn("FIELD43", Type.GetType("System.String"))
            Dim Coulumn44 = New DataColumn("FIELD44", Type.GetType("System.String"))
            Dim Coulumn45 = New DataColumn("FIELD45", Type.GetType("System.String"))
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
            dt.Columns.Add(Coulumn28)
            dt.Columns.Add(Coulumn29)
            dt.Columns.Add(Coulumn30)
            dt.Columns.Add(Coulumn31)
            dt.Columns.Add(Coulumn32)
            dt.Columns.Add(Coulumn33)
            dt.Columns.Add(Coulumn34)
            dt.Columns.Add(Coulumn35)
            dt.Columns.Add(Coulumn36)
            dt.Columns.Add(Coulumn37)
            dt.Columns.Add(Coulumn38)
            dt.Columns.Add(Coulumn39)
            dt.Columns.Add(Coulumn40)
            dt.Columns.Add(Coulumn41)
            dt.Columns.Add(Coulumn42)

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1

                dr = ds.Tables(0).Rows(i)
                dsRpt2.Tables.Clear()
                drRpt = dt.NewRow()
                drRpt("FIELD1") = "หน่วยบริการ : " & vHname.Replace("รพ.สต.", "โรงพยาบาลส่งเสริมสุขภาพตำบล") & vbCrLf & "ประมวลผลถึงวันที่ " & CDate(dtpDate1.EditValue).ToString("d MMM yyyy")
                drRpt("FIELD2") = CStr(i + 1)
                If dr("VILLAGE") = "00" Then
                    drRpt("FIELD3") = ClsBusiness.Lc_Business.SELECT_NAME_ADDRESS_TAMBON(dr("TAMBON")) & " " & dr("VILLANAME")
                Else
                    drRpt("FIELD3") = ClsBusiness.Lc_Business.SELECT_NAME_ADDRESS_TAMBON(dr("TAMBON")) & " หมู่ " & CInt(dr("VILLAGE")).ToString("0")
                End If

                drRpt("FIELD4") = CInt(dr("M_COUNT"))
                drRpt("FIELD5") = CInt(dr("MALE"))
                drRpt("FIELD6") = CInt(dr("FEMALE"))

                drRpt("FIELD7") = CInt(dr("AGE1M"))
                drRpt("FIELD8") = CInt(dr("AGE1F"))
                drRpt("FIELD9") = CInt(dr("AGE2M"))
                drRpt("FIELD10") = CInt(dr("AGE2F"))
                drRpt("FIELD11") = CInt(dr("AGE3M"))
                drRpt("FIELD12") = CInt(dr("AGE3F"))
                drRpt("FIELD13") = CInt(dr("AGE4M"))
                drRpt("FIELD14") = CInt(dr("AGE4F"))
                drRpt("FIELD15") = CInt(dr("AGE5M"))
                drRpt("FIELD16") = CInt(dr("AGE5F"))
                drRpt("FIELD17") = CInt(dr("AGE6M"))
                drRpt("FIELD18") = CInt(dr("AGE6F"))
                drRpt("FIELD19") = CInt(dr("AGE7M"))
                drRpt("FIELD20") = CInt(dr("AGE7F"))
                drRpt("FIELD21") = CInt(dr("AGE8M"))
                drRpt("FIELD22") = CInt(dr("AGE8F"))
                drRpt("FIELD23") = CInt(dr("AGE9M"))
                drRpt("FIELD24") = CInt(dr("AGE9F"))
                drRpt("FIELD25") = CInt(dr("AGE10M"))
                drRpt("FIELD26") = CInt(dr("AGE10F"))
                drRpt("FIELD27") = CInt(dr("AGE11M"))
                drRpt("FIELD28") = CInt(dr("AGE11F"))
                drRpt("FIELD29") = CInt(dr("AGE12M"))
                drRpt("FIELD30") = CInt(dr("AGE12F"))
                drRpt("FIELD31") = CInt(dr("AGE13M"))
                drRpt("FIELD32") = CInt(dr("AGE13F"))
                drRpt("FIELD33") = CInt(dr("AGE14M"))
                drRpt("FIELD34") = CInt(dr("AGE14F"))
                drRpt("FIELD35") = CInt(dr("AGE15M"))
                drRpt("FIELD36") = CInt(dr("AGE15F"))
                drRpt("FIELD37") = CInt(dr("AGE16M"))
                drRpt("FIELD38") = CInt(dr("AGE16F"))
                drRpt("FIELD39") = CInt(dr("AGE17M"))
                drRpt("FIELD40") = CInt(dr("AGE17F"))
                drRpt("FIELD41") = CInt(dr("AGE18M"))
                drRpt("FIELD42") = CInt(dr("AGE18F"))
                dt.Rows.Add(drRpt)

            Next
            dsRpt2.Tables.Add(dt)


            Dim fReport As New frmReportView
            Dim params As ReportParameter

            params = New ReportParameter("RateId")

            fReport.ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\Reports\rptHome2.rdlc"

            fReport.ReportViewer1.LocalReport.DataSources.Clear()
            CurrentReportDataSource.Name = "DataSet20F"
            CurrentReportDataSource.value = dsRpt2.Tables(0)
            fReport.ReportViewer1.LocalReport.DataSources.Add(CurrentReportDataSource)
            fReport.ShowDialog()


        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub
End Class