Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports DevExpress.XtraEditors
Imports ComponentOwl.BetterListView
Imports System.Globalization
Imports System.DateTime
Imports Microsoft.Reporting.WinForms
Imports MySql.Data.MySqlClient

Public Class frmRptProviderOppp
    Dim dsRpt As New DataSet
    Dim dsRpt2 As New DataSet
    Dim CurrentReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()

    Private Sub frmRptProviderSum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdPrintReport1.Enabled = False
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("PROVIDER,CONCAT(B.PRENAME,NAME,' ',LNAME) AS PROVIDER_NAME", "m_provider A LEFT JOIN l_prename B ON(A.PRENAME = B.PRENAME_CODE)", " WHERE A.STATUS = '1' AND STATUS_AF <> '8'  ORDER BY NAME")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboProvider
                '.DataSource = ds.Tables(0)
                '.DisplayMember = "PROVIDER_NAME"
                '.ValueMember = "PROVIDER"
                '.SelectedValue = 0
            End With
        End If
        With BetterListView1
            .Columns.Add(0).Text = "ลำดับ"
            .Columns(0).Width = 60
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "วันที่รับบริการ"
            .Columns(1).Width = 100
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "HN"
            .Columns(2).Width = 100
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "Cid"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "ชื่อ-นามสกุล"
            .Columns(4).Width = 150
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "สิทธิ์"
            .Columns(5).Width = 100
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "เลขบัตร"
            .Columns(6).Width = 100
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "ค่าใช้จ่าย"
            .Columns(7).Width = 150
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "การวินิจฉัย"
            .Columns(8).Width = 220
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With
        BetterListView1.View = View.Details

    End Sub
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If dtpStart.EditValue = Nothing Or dtpEnd.EditValue = Nothing Then
            XtraMessageBox.Show("กรุณากำหนดวันที่ก่อน", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim DateStart As String = CDate(dtpStart.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))
        Dim DateEnd As String = CDate(dtpEnd.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))

        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("IFNULL(PN.PRENAME_DESC,'') AS PRENAME,C.NAME,C.LNAME,IFNULL(P.PROVIDER_DESC,'') AS PROVIDER_DESC,REGISTERNO,B.PROVIDER," _
         & "COUNT(DISTINCT(CASE WHEN A.STATUS_AF <> '8'  AND " & vICD10OP & "  THEN A.PID END)) AS OP_COUNT1," _
         & "COUNT(DISTINCT(CASE WHEN A.STATUS_AF <> '8'  AND " & vICD10OP & "  THEN A.SEQ END)) AS OP_COUNT2," _
         & "COUNT(DISTINCT(CASE WHEN A.STATUS_AF <> '8'  THEN A.PID END)) AS COUNT1," _
         & "COUNT(DISTINCT(CASE WHEN A.STATUS_AF <> '8'  THEN A.SEQ END)) AS COUNT2" _
         , " m_service A JOIN m_diagnosis_opd B ON(A.SEQ = B.SEQ) JOIN m_provider C ON(B.PROVIDER = C.PROVIDER) LEFT JOIN l_providertype_hosp P ON(C.PROVIDER_TYPE_HOSP = P.PROVIDER_CODE) LEFT JOIN l_mypcu_prename PN ON(C.PRENAME_HOS = PN.PRENAME_CODE)" _
         , "WHERE (A.DATE_SERV >= '" & DateStart & "' AND A.DATE_SERV <= '" & DateEnd & "') AND C.STATUS_AF <> '8' GROUP BY B.PROVIDER ORDER BY C.PROVIDERTYPE")

        If ds2.Tables(0).Rows.Count > 0 Then
            ' DisplayData(ds2)
            Label4.Text = "จำนวน " & ds2.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
            cmdPrintReport1.Enabled = True
        Else
            BetterListView1.Items.Clear()
            Label4.Text = "จำนวน 0 รายการ"
            cmdPrintReport1.Enabled = False
        End If

    End Sub
    Private Sub BetterListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BetterListView1.SelectedIndexChanged

    End Sub
End Class