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
            .Columns.Add(5).Text = "จำนวน (คน)"
            .Columns(5).Width = 150
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "จำนวน (ครั้ง)"
            .Columns(6).Width = 150
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center

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
            If optYear.Checked = True Then
                tmpShow2 = " AND ((DATE_FORMAT(" & DateEnd & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & DateEnd & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= " & tmpAge1 & " AND  (DATE_FORMAT(" & DateEnd & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & DateEnd & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) < " & tmpAge2 & ")  "
            Else
                tmpShow2 = " AND (TIMESTAMPDIFF(MONTH, DATE_FORMAT(BIRTH,'%Y-%m-%d'),DATE_FORMAT(" & DateEnd & ",'%Y-%m-%d')) >= " & tmpAge1 & " AND  TIMESTAMPDIFF(MONTH, DATE_FORMAT(BIRTH,'%Y-%m-%d'),DATE_FORMAT(" & DateEnd & ",'%Y-%m-%d')) <= " & tmpAge2 & ")  "

            End If
        End If

        If optOP.Checked = True Then
            tmpShow5 = " AND " & tmpOPDCode
        ElseIf optPP.Checked = True Then
            tmpShow5 = " AND " & tmpPPCode
        ElseIf optOPPP.Checked = True Then
            tmpShow5 = ""
        End If


        If optSexAll.Checked = True Then
            tmpShowSex = ""
        ElseIf optSexFemale.Checked = True Then
            tmpShowSex = " AND A.SEX = '1'"
        ElseIf optSexFemale.Checked = True Then
            tmpShowSex = " AND A.SEX = '2'"
        End If
        'tmpShow2 = " AND ((DATE_FORMAT(" & (DateTimePicker2.Value.ToString("yyyyMMdd").Substring(0, 4) -543) & DateTimePicker2.Value.ToString("yyyyMMdd").Substring(4, 4) & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & (DateTimePicker2.Value.ToString("yyyyMMdd").Substring(0, 4) -543) & DateTimePicker2.Value.ToString("yyyyMMdd").Substring(4, 4) & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) >= " & tmpAge1 & " AND  (DATE_FORMAT(" & (DateTimePicker2.Value.ToString("yyyyMMdd").Substring(0, 4) -543) & DateTimePicker2.Value.ToString("yyyyMMdd").Substring(4, 4) & ",'%Y')-DATE_FORMAT(BIRTH,'%Y') - (DATE_FORMAT(" & (DateTimePicker2.Value.ToString("yyyyMMdd").Substring(0, 4) -543) & DateTimePicker2.Value.ToString("yyyyMMdd").Substring(4, 4) & ",'00-%m-%d')<DATE_FORMAT(BIRTH,'00-%m-%d'))) <= " & tmpAge2 & ") AND (DATE_SERV >= " & (DateTimePicker1.Value.ToString("yyyyMMdd").Substring(0, 4) -543) & DateTimePicker1.Value.ToString("yyyyMMdd").Substring(4, 4) & " AND DATE_SERV <= " & (DateTimePicker2.Value.ToString("yyyyMMdd").Substring(0, 4) -543) & DateTimePicker2.Value.ToString("yyyyMMdd").Substring(4, 4) & ")  AND DIAGCODE IN('" & tmpDiagCODE.Replace(",", "','") & "') "



        Dim ds As DataSet

        ds = clsdataBus.Lc_Business.SELECT_TABLE("PDX,DESC_THAI,DESC_ENG,COUNT(DISTINCT(SEQ)) AS M_COUNT,COUNT(DISTINCT(A.PID)) AS P_COUNT", "m_person A JOIN m_service B ON(A.PID = B.PID) LEFT JOIN m_home C ON(A.HID = C.HID) JOIN l_icd10 D ON(B.PDX = D.CODE)", "WHERE B.STATUS_AF <> '8'   " & tmpShow2 & tmpShow & tmpShow3 & tmpShow4 & tmpShow5 & tmpShowSex & tmpVill & " AND (DATE_SERV >= " & DateEnd & " AND DATE_SERV <= " & DateStart & ") GROUP BY PDX ORDER BY COUNT(DISTINCT(A.PID)) DESC ")

        If ds.Tables(0).Rows.Count > 0 Then

            DisplayData2(ds)
            Label17.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0").ToString & " รายการ"
            cmdPrintReport1.Enabled = True
        Else
            BetterListView1.Items.Clear()
            Label17.Text = "จำนวน 0 รายการ"
            cmdPrintReport1.Enabled = False
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub Displaydata2(ByVal ds As DataSet)

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If dtpStart.EditValue = Nothing Or dtpEnd.EditValue = Nothing Then
            XtraMessageBox.Show("กรุณากำหนดวันที่ก่อน", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ShowDataName()

    End Sub
End Class