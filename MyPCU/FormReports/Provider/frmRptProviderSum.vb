Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports DevExpress.XtraEditors
Imports ComponentOwl.BetterListView
Imports System.Globalization
Imports System.DateTime
Imports Microsoft.Reporting.WinForms
Imports MySql.Data.MySqlClient
Public Class frmRptProviderSum
    Dim dsRpt As New DataSet
    Dim dsRpt2 As New DataSet
    Dim CurrentReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
    Dim tmpProvider As String = ""
    Dim tmpProvierName As String = ""
    Dim tmpProvierNameType As String = ""
    Private Sub frmRptProviderSum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdPrintReport1.Enabled = False
        cmdPrintReport2.Enabled = False
        With BetterListView1
            .Columns.Add(0).Text = "ลำดับ"
            .Columns(0).Width = 60
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "PROVIDER"
            .Columns(1).Width = 0
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "ชื่อ-นามสกุล"
            .Columns(2).Width = 150
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "ประเภทบุคลากร"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "เลขที่ใบประกอบวิชาชีพ"
            .Columns(4).Width = 150
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "จำนวนคน(OP)"
            .Columns(5).Width = 100
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "จำนวนครั้ง(OP)"
            .Columns(6).Width = 100
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "จำนวนคน(PP)"
            .Columns(7).Width = 100
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "จำนวนครั้ง(PP)"
            .Columns(8).Width = 100
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(9).Text = "จำนวนคน(รวม)"
            .Columns(9).Width = 100
            .Columns(9).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(10).Text = "จำนวนครั้ง(รวม)"
            .Columns(10).Width = 100
            .Columns(10).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center

        End With

        With BetterListView2
            .Columns.Add(0).Text = "ลำดับ"
            .Columns(0).Width = 60
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "วันที่รับบริการ"
            .Columns(1).Width = 0
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "HN"
            .Columns(2).Width = 0
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "CID"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "ชื่อ-นามสกุล"
            .Columns(4).Width = 100
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "สิทธิ"
            .Columns(5).Width = 100
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "เลขบัตร"
            .Columns(6).Width = 100
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "อายุ"
            .Columns(7).Width = 100
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "การวินิจฉัย"
            .Columns(8).Width = 300
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center

        End With

        dtpStart.Select()


    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If dtpStart.EditValue = Nothing Or dtpEnd.EditValue = Nothing Then
            XtraMessageBox.Show("กรุณากำหนดวันที่ก่อน", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim DateStart As String = CDate(dtpStart.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))
        Dim DateEnd As String = CDate(dtpEnd.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))
        SplashScreenManager1.ShowWaitForm()
        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("IFNULL(PN.PRENAME_DESC,'') AS PRENAME,C.NAME,C.LNAME,IFNULL(P.PROVIDER_DESC,'') AS PROVIDER_DESC,REGISTERNO,B.PROVIDER," _
         & "COUNT(DISTINCT(CASE WHEN A.STATUS_AF <> '8'  AND " & vICD10OP & "  THEN A.PID END)) AS OP_COUNT1," _
         & "COUNT(DISTINCT(CASE WHEN A.STATUS_AF <> '8'  AND " & vICD10OP & "  THEN A.SEQ END)) AS OP_COUNT2," _
         & "COUNT(DISTINCT(CASE WHEN A.STATUS_AF <> '8'  THEN A.PID END)) AS COUNT1," _
         & "COUNT(DISTINCT(CASE WHEN A.STATUS_AF <> '8'  THEN A.SEQ END)) AS COUNT2" _
         , " m_service A JOIN m_diagnosis_opd B ON(A.SEQ = B.SEQ) JOIN m_provider C ON(B.PROVIDER = C.PROVIDER) LEFT JOIN l_providertype_hosp P ON(C.PROVIDER_TYPE_HOSP = P.PROVIDER_CODE) LEFT JOIN l_mypcu_prename PN ON(C.PRENAME_HOS = PN.PRENAME_CODE)" _
         , "WHERE (A.DATE_SERV >= '" & DateStart & "' AND A.DATE_SERV <= '" & DateEnd & "') AND C.STATUS_AF <> '8' GROUP BY B.PROVIDER ORDER BY C.PROVIDERTYPE")

        If ds2.Tables(0).Rows.Count > 0 Then
            DisplayData(ds2)
            Label4.Text = "จำนวน " & ds2.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
            cmdPrintReport1.Enabled = True
        Else
            BetterListView1.Items.Clear()
            Label4.Text = "จำนวน 0 รายการ"
            cmdPrintReport1.Enabled = False
        End If

        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub DisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow

        Dim tmpOrder As String = ""
        Dim tmpPrename As String = ""
        Dim tmpProviderType As String = ""
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

        Dim sumType1 As Integer = 0
        Dim sumType2 As Integer = 0
        Dim sumType3 As Integer = 0
        Dim sumType4 As Integer = 0
        Dim sumType5 As Integer = 0
        Dim sumType6 As Integer = 0
        Dim k As Integer = 0
        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                tmpOrder = CStr(i + 1)
                BetterListView1.Items.Add(tmpOrder)

                If Not IsDBNull(dr("PROVIDER")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("PROVIDER").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("PRENAME")) Then
                    tmpPrename = dr("PRENAME")
                End If
                BetterListView1.Items(i).SubItems.Add((tmpPrename & (dr("NAME")) & " " & (dr("LNAME"))).ToString).AlignHorizontal = TextAlignmentHorizontal.Left

                If Not IsDBNull(dr("PROVIDER_DESC")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("PROVIDER_DESC").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("-")
                End If
                If Not IsDBNull(dr("REGISTERNO")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("REGISTERNO").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("-")
                End If
                BetterListView1.Items(i).SubItems.Add(CInt(dr("OP_COUNT1")).ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right
                BetterListView1.Items(i).SubItems.Add(CInt(dr("OP_COUNT2")).ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right
                BetterListView1.Items(i).SubItems.Add(CInt(dr("COUNT1") - dr("OP_COUNT1")).ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right
                BetterListView1.Items(i).SubItems.Add(CInt(dr("COUNT2") - dr("OP_COUNT2")).ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right
                BetterListView1.Items(i).SubItems.Add(CInt(dr("COUNT1")).ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right
                BetterListView1.Items(i).SubItems.Add(CInt(dr("COUNT2")).ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right


                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                sumType1 = sumType1 + CInt(dr("OP_COUNT1"))
                sumType2 = sumType2 + CInt(dr("OP_COUNT2"))
                sumType3 = sumType3 + CInt(dr("COUNT1") - dr("OP_COUNT1"))
                sumType4 = sumType4 + CInt(dr("COUNT2") - dr("OP_COUNT2"))
                sumType5 = sumType5 + CInt(dr("COUNT1"))
                sumType6 = sumType6 + CInt(dr("COUNT2"))
                k = k + 1



                dsRpt.Tables.Clear()
                drRpt = dt.NewRow()
                drRpt("FIELD1") = "หน่วยบริการ : " & ClsBusiness.Lc_Business.SELECT_NAME_HCODE(vHcode).Replace("รพ.สต.", "โรงพยาบาลส่งเสริมสุขภาพตำบล")
                drRpt("FIELD2") = "รายงานจำนวนการให้บริการจำแนกตามผู้ให้บริการ"

                drRpt("FIELD3") = tmpOrder
                drRpt("FIELD4") = tmpPrename & (dr("NAME")) & " " & (dr("LNAME"))
                drRpt("FIELD5") = dr("PROVIDER_DESC")
                drRpt("FIELD6") = dr("REGISTERNO")

                drRpt("FIELD7") = dr("OP_COUNT1")
                drRpt("FIELD8") = dr("OP_COUNT2")
                drRpt("FIELD9") = CInt(dr("COUNT1") - dr("OP_COUNT1"))
                drRpt("FIELD10") = CInt(dr("COUNT2") - dr("OP_COUNT2"))
                drRpt("FIELD11") = dr("COUNT1")
                drRpt("FIELD12") = dr("COUNT2")
                drRpt("FIELD13") = "ข้อมูลการให้บริการ ตั้งแต่วันที่ " & CDate(dtpStart.EditValue).ToString("d MMMM yyyy") & " ถึงวันที่ " & CDate(dtpEnd.EditValue).ToString("d MMMM yyyy")
                dt.Rows.Add(drRpt)

            Next
            dsRpt.Tables.Add(dt)

            BetterListView1.AutoResizeColumn(2, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(3, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(4, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.EndUpdate()
            BetterListView1.ResumeSort(True)


            BetterListView1.Items.Add("")
            BetterListView1.Items(k).SubItems.Add("")
            BetterListView1.Items(k).SubItems.Add("")
            BetterListView1.Items(k).SubItems.Add("")
            BetterListView1.Items(k).SubItems.Add("รวม").AlignHorizontal = TextAlignmentHorizontal.Right
            BetterListView1.Items(k).SubItems.Add(sumType1.ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right
            BetterListView1.Items(k).SubItems.Add(sumType2.ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right
            BetterListView1.Items(k).SubItems.Add(sumType3.ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right
            BetterListView1.Items(k).SubItems.Add(sumType4.ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right
            BetterListView1.Items(k).SubItems.Add(sumType5.ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right
            BetterListView1.Items(k).SubItems.Add(sumType6.ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right
            BetterListView1.Items(k).BackColor = Color.LightBlue

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub cmdPrintReport1_Click(sender As Object, e As EventArgs) Handles cmdPrintReport1.Click
        Dim fReport As New frmReportView
        Dim params As ReportParameter

        params = New ReportParameter("RateId")
        fReport.ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\Reports\rptProviderSum.rdlc"
        fReport.ReportViewer1.LocalReport.DataSources.Clear()
        CurrentReportDataSource.Name = "DataSet20F"
        CurrentReportDataSource.value = dsRpt.Tables(0)
        fReport.ReportViewer1.LocalReport.DataSources.Add(CurrentReportDataSource)
        fReport.ShowDialog()

    End Sub

    Private Sub BetterListView1_ItemSelectionChanged(sender As Object, eventArgs As BetterListViewItemSelectionChangedEventArgs) Handles BetterListView1.ItemSelectionChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            tmpProvider = lvi.SubItems(1).Text
            tmpProvierName = lvi.SubItems.Item(2).Text
            tmpProvierNameType = lvi.SubItems.Item(3).Text
        Next
    End Sub

    Private Sub BetterListView1_Click(sender As Object, e As EventArgs) Handles BetterListView1.Click
        ShowData()
    End Sub
    Private Sub ShowData()
        SplashScreenManager1.ShowWaitForm()
        clsbusent.Lc_BusinessEntity.Updatem_table("m_service A JOIN m_diagnosis_opd B ON(A.HOSPCODE = B.HOSPCODE AND A.PID = B.PID AND A.SEQ = B.SEQ AND A.DATE_SERV = B.DATE_SERV)", " A.PDX = B.DIAGCODE ", " B.DIAGTYPE = '1' AND IFNULL(A.PDX,'') = '' ")
        Dim tmpSQL As String = ""
        If chkAll.Checked = True Then
            tmpSQL = ""
        ElseIf chkOP.Checked = True Then
            tmpSQL = " AND " & vICD10OP & " "
        ElseIf chkPP.Checked = True Then
            tmpSQL = " AND " & vICD10PP & ""
        End If

        Dim DateStart As String = CDate(dtpStart.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))
        Dim DateEnd As String = CDate(dtpEnd.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))


        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("A.SEQ,A.DATE_SERV,A.PDX,C.DESC_ENG,C.DESC_THAI,B.CID,B.BIRTH,B.SEX,A.STATUS_AF,PRENAME,NAME,LNAME,B.HN,INSTYPE_DESC,A.INSID", "m_service A LEFT JOIN m_person B ON(A.PID = B.PID) LEFT JOIN l_icd10 C ON(A.PDX = C.CODE) JOIN m_diagnosis_opd D ON(A.PID = D.PID AND A.SEQ = D.SEQ) LEFT JOIN l_instype_new E ON(A.INSTYPE = E.INSTYPE_CODE)  ", " WHERE (A.DATE_SERV >= '" & DateStart & "' AND A.DATE_SERV <= '" & DateEnd & "') AND A.STATUS_AF <> '8' AND D.PROVIDER = '" & tmpProvider & "' " & tmpSQL & " GROUP BY A.SEQ,A.DATE_SERV,A.PDX,C.DESC_ENG,C.DESC_THAI,B.CID,B.BIRTH,B.SEX ORDER BY A.DATE_SERV,A.SEQ+0 ")

        If ds2.Tables(0).Rows.Count > 0 Then
            DisplayData2(ds2)
            Label5.Text = "จำนวน " & ds2.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
            cmdPrintReport2.Enabled = True
        Else
            BetterListView2.Items.Clear()
            Label5.Text = "จำนวน 0 รายการ"
            cmdPrintReport2.Enabled = False
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub DisplayData2(ByVal ds As DataSet)

    End Sub
End Class
