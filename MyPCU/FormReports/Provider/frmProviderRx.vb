Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Globalization
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Imports Microsoft.Reporting.WinForms

Public Class frmProviderRx
    Dim dsRpt As New DataSet
    Dim CurrentReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
    Dim tmpProvider As String = ""
    Dim tmpProvierName As String = ""
    Dim tmpProvierNameType As String = ""
    Private Sub frmProviderRx_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cboProviderAction()
        cmdPrintReport1.Enabled = False

        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 30
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ลำดับ"
            .Columns(1).Width = 50
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "วันที่รับบริการ"
            .Columns(2).Width = 100
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "ID"
            .Columns(3).Width = 80
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "CID"
            .Columns(4).Width = 130
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "ชื่อ-นามสกุล"
            .Columns(5).Width = 150
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "เลขบัตร"
            .Columns(6).Width = 150
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "สิทธิ์"
            .Columns(7).Width = 120
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "อายุ"
            .Columns(8).Width = 60
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(9).Text = "การวินิจฉัย"
            .Columns(9).Width = 300
            .Columns(9).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        dtpStart.Select()

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
        SplashScreenManager1.ShowWaitForm()

        clsbusent.Lc_BusinessEntity.Updatem_table("m_service A JOIN m_diagnosis_opd B ON(A.HOSPCODE = B.HOSPCODE AND A.PID = B.PID AND A.SEQ = B.SEQ AND A.DATE_SERV = B.DATE_SERV)", " A.PDX = B.DIAGCODE ", " B.DIAGTYPE = '1' AND IFNULL(A.PDX,'') = '' ")

        Dim tmpSQL As String = ""
        Dim tmpProvider As String = cboProvider.EditValue
        Dim DateStart As String = CDate(dtpStart.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))
        Dim DateEnd As String = CDate(dtpEnd.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))

        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("A.SEQ,A.DATE_SERV,A.PDX,C.DESC_ENG,C.DESC_THAI,B.CID,B.BIRTH,B.SEX,A.STATUS_AF,PRENAME_HOS,NAME,LNAME,B.HN,INSTYPE_DESC,A.INSID,A.PID", "m_service A LEFT JOIN m_person B ON(A.PID = B.PID) LEFT JOIN l_icd10 C ON(A.PDX = C.CODE) JOIN m_diagnosis_opd D ON(A.PID = D.PID AND A.SEQ = D.SEQ) LEFT JOIN l_instype_new E ON(A.INSTYPE = E.INSTYPE_CODE)  ", " WHERE (A.DATE_SERV >= '" & DateStart & "' AND A.DATE_SERV <= '" & DateEnd & "') AND A.STATUS_AF <> '8' AND D.PROVIDER = '" & tmpProvider & "' GROUP BY A.SEQ,A.DATE_SERV,A.PDX,C.DESC_ENG,C.DESC_THAI,B.CID,B.BIRTH,B.SEX ORDER BY A.DATE_SERV,A.SEQ+0 ")

        If ds2.Tables(0).Rows.Count > 0 Then
            DisplayData(ds2)
            Label5.Text = "จำนวน " & ds2.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
            cmdPrintReport1.Enabled = True
        Else
            BetterListView1.Items.Clear()
            Label5.Text = "จำนวน 0 รายการ"
            cmdPrintReport1.Enabled = False
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub DisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        'Dim itm As BetterListViewItem
        Dim tmpPrename As String = ""
        Dim tmpOrder As String = ""
        Dim tmpCID As String = ""
        Dim tmpPID As String = ""
        Dim tmpName As String = ""
        Dim tmpDateServ As String = ""
        Dim tmpInscl As String = ""
        Dim tmpDx As String = ""
        Dim tmpInsclID As String = ""
        Dim tmpAge As String = ""
        Dim tmpProvider As String = ""
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
                tmpOrder = CStr(i + 1)


                If dr("SEX") = "1" Then
                    BetterListView1.Items.Add(ImageList1.Images.Item(0)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                Else
                    BetterListView1.Items.Add(ImageList1.Images.Item(1)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                End If

                BetterListView1.Items(i).SubItems.Add(tmpOrder).AlignHorizontal = TextAlignmentHorizontal.Center

                If dr("DATE_SERV") <> "" Then
                    Try
                        tmpDateServ = Thaidate(dr("DATE_SERV"))
                        BetterListView1.Items(i).SubItems.Add(tmpDateServ).AlignHorizontal = TextAlignmentHorizontal.Center
                    Catch ex As Exception
                        tmpDateServ = ""
                        BetterListView1.Items(i).SubItems.Add("")
                    End Try
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If dr("PID") <> "" Then
                    BetterListView1.Items(i).SubItems.Add(dr("PID"))
                    tmpPID = dr("PID")
                Else
                    BetterListView1.Items(i).SubItems.Add("").AlignHorizontal = TextAlignmentHorizontal.Center
                End If
                If dr("CID") <> "" Then
                    Try
                        tmpCID = dr("CID")
                        BetterListView1.Items(i).SubItems.Add(tmpCID).AlignHorizontal = TextAlignmentHorizontal.Center
                    Catch ex As Exception
                        tmpCID = ""
                        BetterListView1.Items(i).SubItems.Add("มีข้อผิดพลาด!!!")
                    End Try
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If

                If dr("PRENAME_HOS") <> "" Then
                    tmpPrename = clsdataBus.Lc_Business.SELECT_NAME_PRENAME(dr("PRENAME_HOS"))
                End If
                Try
                    tmpName = tmpPrename & (dr("NAME")) & " " & (dr("LNAME"))
                    BetterListView1.Items(i).SubItems.Add(tmpName)
                Catch ex As Exception
                    tmpName = ""
                    BetterListView1.Items(i).SubItems.Add("มีข้อผิดพลาด!!!")
                End Try
                If dr("INSID") <> "" Then
                    tmpInsclID = dr("INSID")
                    BetterListView1.Items(i).SubItems.Add(tmpInsclID).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    tmpInsclID = ""
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If dr("INSTYPE_DESC") <> "" Then
                    tmpInscl = dr("INSTYPE_DESC")
                    BetterListView1.Items(i).SubItems.Add(tmpInscl).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    tmpInscl = ""
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If IsDBNull(dr("BIRTH")) Then
                    BetterListView1.Items(i).SubItems.Add("")
                Else
                    Dim DOB As DateTime = DateTime.ParseExact(dr("BIRTH"), "yyyyMMdd", CultureInfo.CurrentCulture)
                    Dim Years As Integer = 0
                    Dim Month As Integer = 0
                    Dim Days As Integer = 0
                    Dim StrAge As String = Nothing

                    If DOB < DateTime.Now Then
                        Dim dateDiff As TimeSpan = DateTime.Now - DOB
                        Dim age As New DateTime(dateDiff.Ticks)
                        Years = age.Year - 544
                        Month = age.Month - 1
                        Days = age.Day - 1
                        StrAge = (Years.ToString() & " ปี ")
                    Else
                        StrAge = "วันเดือนปีเกิดไม่ถูกต้อง"
                    End If

                    BetterListView1.Items(i).SubItems.Add(StrAge).AlignHorizontal = TextAlignmentHorizontal.Center
                    tmpAge = StrAge
                End If

                If (dr("PDX")) <> "" Then
                    If vICD10TH = "1" Then
                        tmpDx = dr("DESC_THAI") & "(" & dr("PDX") & ")"
                        BetterListView1.Items(i).SubItems.Add(tmpDx)
                    Else
                        tmpDx = dr("DESC_ENG") & "(" & dr("PDX") & ")"
                        BetterListView1.Items(i).SubItems.Add(tmpDx)
                    End If
                Else
                    tmpDx = "ไม่มี Pdx!"
                    BetterListView1.Items(i).SubItems.Add("ไม่มี Pdx!")
                End If

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.MintCream
                End If

                If dr("STATUS_AF") = "0" Then
                    BetterListView1.Items(i).BackColor = Color.Orange
                End If

                dsRpt.Tables.Clear()
                drRpt = dt.NewRow()
                drRpt("FIELD1") = "หน่วยบริการ : " & ClsBusiness.Lc_Business.SELECT_NAME_HCODE(vHcode).Replace("รพ.สต.", "โรงพยาบาลส่งเสริมสุขภาพตำบล")
                drRpt("FIELD2") = "ผู้ให้บริการ : " & tmpProvierName & "  ประเภทผู้ให้บริการ : " & tmpProvierNameType
                drRpt("FIELD3") = tmpOrder
                drRpt("FIELD4") = tmpDateServ
                drRpt("FIELD5") = dr("PID")
                drRpt("FIELD6") = tmpCID
                drRpt("FIELD7") = tmpName
                drRpt("FIELD8") = tmpInscl
                drRpt("FIELD9") = tmpDx
                drRpt("FIELD10") = tmpInsclID

                dt.Rows.Add(drRpt)

            Next
            dsRpt.Tables.Add(dt)
            BetterListView1.AutoResizeColumn(2, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)

            BetterListView1.AutoResizeColumn(4, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(5, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(6, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(7, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(8, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(9, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)

            BetterListView1.ResumeSort(True)
            BetterListView1.EndUpdate()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error002" & tmpPID, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        If cboProvider.EditValue = Nothing Then
            MessageBox.Show("กรุณาเลือกผู้ให้บริการก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If dtpStart.EditValue = Nothing Or dtpEnd.EditValue = Nothing Then
            XtraMessageBox.Show("กรุณากำหนดวันที่ก่อน", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        ShowData()
    End Sub

    Private Sub cmdToday_Click(sender As Object, e As EventArgs) Handles cmdToday.Click
        If cboProvider.EditValue = Nothing Then
            MessageBox.Show("กรุณาเลือกผู้ให้บริการก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If dtpStart.EditValue = Nothing Or dtpEnd.EditValue = Nothing Then
            XtraMessageBox.Show("กรุณากำหนดวันที่ก่อน", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate_En().ToString.Substring(0, 8)
        clsbusent.Lc_BusinessEntity.Updatem_table("m_service A JOIN m_diagnosis_opd B ON(A.HOSPCODE = B.HOSPCODE AND A.PID = B.PID AND A.SEQ = B.SEQ AND A.DATE_SERV = B.DATE_SERV)", " A.PDX = B.DIAGCODE ", " B.DIAGTYPE = '1' AND IFNULL(A.PDX,'') = '' ")

        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("A.SEQ,A.DATE_SERV,A.PDX,C.DESC_ENG,C.DESC_THAI,B.CID,B.BIRTH,B.SEX,A.STATUS_AF,PRENAME,NAME,LNAME,B.HN,INSTYPE_DESC,A.INSID", "m_service A LEFT JOIN m_person B ON(A.PID = B.PID) LEFT JOIN l_icd10 C ON(A.PDX = C.CODE) JOIN m_diagnosis_opd D ON(A.PID = D.PID AND A.SEQ = D.SEQ) LEFT JOIN l_instype_new E ON(A.INSTYPE = E.INSTYPE_CODE)  ", " WHERE (A.DATE_SERV = '" & tmpNow & "') AND A.STATUS_AF <> '8' AND D.PROVIDER = '" & cboProvider.EditValue & "' GROUP BY A.SEQ,A.DATE_SERV,A.PDX,C.DESC_ENG,C.DESC_THAI,B.CID,B.BIRTH,B.SEX ORDER BY A.DATE_SERV,A.SEQ+0 ")
        If ds2.Tables(0).Rows.Count > 0 Then
            DisplayData(ds2)
            'Label5.Text = "จำนวน " & ds2.Tables(0).Rows.Count.ToString("#,##0") & " คน"
        Else
            BetterListView1.Items.Clear()
            Label5.Text = "จำนวน 0 คน"
        End If
    End Sub

    Private Sub cmdPrintReport1_Click(sender As Object, e As EventArgs) Handles cmdPrintReport1.Click
        Dim fReport As New frmReportView
        Dim params As ReportParameter

        params = New ReportParameter("RateId")
        fReport.ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\Reports\rptProviderRx.rdlc"
        fReport.ReportViewer1.LocalReport.DataSources.Clear()
        CurrentReportDataSource.Name = "DataSet20F"
        CurrentReportDataSource.value = dsRpt.Tables(0)
        fReport.ReportViewer1.LocalReport.DataSources.Add(CurrentReportDataSource)
        fReport.ShowDialog()

    End Sub

End Class