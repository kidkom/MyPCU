Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Globalization
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Imports Microsoft.Reporting.WinForms

Public Class frmThaiDrugCost
    Dim dsRpt As New DataSet
    Dim dsRpt2 As New DataSet
    Dim CurrentReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()

    Private Sub frmRptDrugHerb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdPrintReport1.Enabled = False

        With BetterListView1
            .Columns.Add(0).Text = "เดือน/ปี"
            .Columns(0).Width = 150
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "แผนปัจจุบัน (ครั้ง)"
            .Columns(1).Width = 120
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "แผนไทย (ครั้ง)"
            .Columns(2).Width = 120
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "ร้อยละ"
            .Columns(3).Width = 80
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "แผนปัจจุบัน (บาท)"
            .Columns(4).Width = 120
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "แผนไทย (บาท)"
            .Columns(5).Width = 120
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "ร้อยละ"
            .Columns(6).Width = 120
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center

        End With

    End Sub
    Private Sub ShowData()
        Dim ds As New DataSet
        Dim DateStart As String = CDate(dtpStart.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))
        Dim DateEnd As String = CDate(dtpEnd.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))
        ds = clsdataBus.Lc_Business.SELECT_TABLE("CONCAT(MONTH_NAME,SUBSTR(DATE_SERV,1,4)+543) AS LABEL," _
                                                    & "COUNT(DISTINCT(SEQ)) - COUNT(DISTINCT(CASE WHEN DIDSTD LIKE '4%' THEN SEQ END)) AS VALUE1," _
                                                    & "COUNT(DISTINCT(CASE WHEN DIDSTD LIKE '4%' THEN SEQ END)) AS VALUE2," _
                                                    & " FORMAT((COUNT(DISTINCT(CASE WHEN DIDSTD LIKE '4%' THEN SEQ END)) *100)/COUNT(DISTINCT(SEQ)),2) AS VALUE3," _
                                                    & " IFNULL(REPLACE(FORMAT(SUM(AMOUNT*DRUGCOST) - SUM(CASE WHEN DIDSTD LIKE '4%' THEN AMOUNT*DRUGCOST END),2),',',''),0.00) AS VALUE4," _
                                                    & " IFNULL(REPLACE(FORMAT(SUM(CASE WHEN DIDSTD LIKE '4%' THEN AMOUNT*DRUGCOST END),2),',',''),0.00) AS VALUE5," _
                                                    & " IFNULL(FORMAT((SUM(CASE WHEN DIDSTD LIKE '4%' THEN AMOUNT*DRUGCOST END) *100)/SUM(AMOUNT*DRUGCOST),2),0.00) AS VALUE6",
                                                 "m_drug_opd A JOIN l_month B ON(B.MONTH_ID = SUBSTR(DATE_SERV,5,2))",
                                                 " WHERE (DATE_SERV >= " & DateStart & " AND DATE_SERV <= " & DateEnd & " ) AND STATUS_AF = '1'  GROUP BY SUBSTR(DATE_SERV,1,6) ORDER BY DATE_SERV ")

        If ds.Tables(0).Rows.Count > 0 Then
            DisplayData(ds)
            Label3.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0").ToString & " รายการ"
            cmdPrintReport1.Enabled = True
        Else
            BetterListView1.Items.Clear()
            Label3.Text = "จำนวน 0 รายการ"
            cmdPrintReport1.Enabled = False
        End If
    End Sub
    Private Sub DisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow

        Dim sumType1 As Integer = 0
        Dim sumType2 As Integer = 0
        Dim sumType3 As Double = 0
        Dim sumType4 As Integer = 0
        Dim sumType5 As Double = 0

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


        BetterListView1.Items.Clear()
        BetterListView1.BeginUpdate()
        BetterListView1.SuspendSort()


        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            dr = ds.Tables(0).Rows(i)
            dsRpt2.Tables.Clear()
            drRpt = dt.NewRow()


            BetterListView1.Items.Add(dr("LABEL").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
            If Not IsDBNull(CInt(dr("VALUE1")).ToString("#,##0")) Then
                BetterListView1.Items(i).SubItems.Add(CInt(dr("VALUE1")).ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right
            Else
                BetterListView1.Items(i).SubItems.Add("0")
            End If
            If Not IsDBNull(CInt(dr("VALUE2")).ToString("#,##0")) Then
                BetterListView1.Items(i).SubItems.Add(CInt(dr("VALUE2")).ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right
            Else
                BetterListView1.Items(i).SubItems.Add("0")
            End If
            If Not IsDBNull(CDbl(dr("VALUE3")).ToString("#,##0.00")) Then
                BetterListView1.Items(i).SubItems.Add(CDbl(dr("VALUE3")).ToString("#,##0.00")).AlignHorizontal = TextAlignmentHorizontal.Center
            Else
                BetterListView1.Items(i).SubItems.Add("0.00")
            End If

            If Not IsDBNull(CDbl(dr("VALUE4")).ToString("#,##0")) Then
                BetterListView1.Items(i).SubItems.Add(CInt(dr("VALUE4")).ToString("#,##0.00")).AlignHorizontal = TextAlignmentHorizontal.Right
            Else
                BetterListView1.Items(i).SubItems.Add("0")
            End If
            If Not IsDBNull(CDbl(dr("VALUE5")).ToString("#,##0")) Then
                BetterListView1.Items(i).SubItems.Add(CInt(dr("VALUE5")).ToString("#,##0.00")).AlignHorizontal = TextAlignmentHorizontal.Right
            Else
                BetterListView1.Items(i).SubItems.Add("0")
            End If
            If Not IsDBNull(CDbl(dr("VALUE6")).ToString("#,##0.00")) Then
                BetterListView1.Items(i).SubItems.Add(CDbl(dr("VALUE6")).ToString("#,##0.00")).AlignHorizontal = TextAlignmentHorizontal.Center
            Else
                BetterListView1.Items(i).SubItems.Add("0.00")
            End If

            If (i Mod 2 = 0) Then
                BetterListView1.Items(i).BackColor = Color.WhiteSmoke
            End If


            sumType1 = sumType1 + CInt(dr("VALUE1"))
            sumType2 = sumType2 + CInt(dr("VALUE2"))
            sumType3 = sumType3 + CInt(dr("VALUE3"))
            sumType4 = sumType4 + CInt(dr("VALUE4"))
            sumType5 = sumType5 + CInt(dr("VALUE5"))

            drRpt("FIELD1") = "แสดงจำนวนผู้รับบริการและมูลค่าแพทย์แผนไทย (ยาแพทย์แผนไทย)"

            drRpt("FIELD2") = "หน่วยบริการ : " & ClsBusiness.Lc_Business.SELECT_NAME_HCODE(vHcode).Replace("รพ.สต.", "โรงพยาบาลส่งเสริมสุขภาพตำบล") & vbCrLf & "วันที่ตัดยอดรายงาน " & CDate(dtpStart.EditValue).ToString("d MMMM yyyy") & " ถึงวันที่ " & CDate(dtpEnd.EditValue).ToString("d MMMM yyyy")
            drRpt("FIELD3") = dr("LABEL")
            drRpt("FIELD4") = dr("VALUE1")
            drRpt("FIELD5") = dr("VALUE2")
            drRpt("FIELD6") = dr("VALUE4")
            drRpt("FIELD7") = dr("VALUE5")

            dt.Rows.Add(drRpt)
        Next

        BetterListView1.EndUpdate()
        BetterListView1.ResumeSort(True)
        dsRpt2.Tables.Add(dt)

        Exit Sub


    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        SplashScreenManager1.ShowWaitForm()
        ShowData()
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub cmdPrintReport1_Click(sender As Object, e As EventArgs) Handles cmdPrintReport1.Click
        Dim fReport As New frmReportView
        Dim params As ReportParameter

        params = New ReportParameter("RateId")

        fReport.ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\Reports\rptDrugHerb4.rdlc"


        fReport.ReportViewer1.LocalReport.DataSources.Clear()
        CurrentReportDataSource.Name = "DataSet20F"
        CurrentReportDataSource.value = dsRpt2.Tables(0)
        fReport.ReportViewer1.LocalReport.DataSources.Add(CurrentReportDataSource)

        fReport.ShowDialog()

    End Sub

    Private Sub BetterListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BetterListView1.SelectedIndexChanged

    End Sub
End Class