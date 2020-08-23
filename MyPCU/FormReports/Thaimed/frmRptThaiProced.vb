Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Globalization
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Imports Microsoft.Reporting.WinForms
Public Class frmRptThaiProced
    Dim dsRpt As New DataSet
    Dim dsRpt2 As New DataSet
    Dim dsRpt3 As New DataSet
    Dim CurrentReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
    Dim DateStart As String = ""
    Dim DateEnd As String = ""
    Private Sub frmRptThaiProced_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdShow2.Enabled = False
        cmdPrintReport1.Enabled = False
        cmdPrintReport2.Enabled = False

        With BetterListView1
            .Columns.Add(0).Text = "ลำดับ"
            .Columns(0).Width = 80
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ROWID"
            .Columns(1).Width = 0
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "CID"
            .Columns(2).Width = 120
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "ID"
            .Columns(3).Width = 0
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "HN"
            .Columns(4).Width = 0
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "ชื่อ-นามสกุล"
            .Columns(5).Width = 150
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "วันที่รับบริการ"
            .Columns(6).Width = 100
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "สถานที่รับบริการ"
            .Columns(7).Width = 100
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "กิจกรรม"
            .Columns(8).Width = 150
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(9).Text = "ต้นทุน (บาท)"
            .Columns(9).Width = 100
            .Columns(9).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(10).Text = "ค่าบริการ (บาท)"
            .Columns(10).Width = 100
            .Columns(10).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(11).Text = "ผู้ให้บริการ"
            .Columns(11).Width = 120
            .Columns(11).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            '.Columns.Add(12).Text = "วันที่บันทึกข้อมูล"
            '.Columns(12).Width = 100
            '.Columns(12).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center

        End With

        With BetterListView2
            .Columns.Add(0).Text = "รหัส"
            .Columns(0).Width = 80
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "หัตถการ"
            .Columns(1).Width = 300
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "จำนวน (คน)"
            .Columns(2).Width = 100
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "จำนวน (ครั้ง)"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "ต้นทุน (บาท)"
            .Columns(4).Width = 100
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "ค่าบริการ (บาท)"
            .Columns(5).Width = 100
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center

        End With
    End Sub
    Private Sub cmdProcess_Click(sender As Object, e As EventArgs) Handles cmdProcess.Click
        If dtpStart.EditValue = Nothing Or dtpEnd.EditValue = Nothing Then
            XtraMessageBox.Show("กรุณากำหนดวันที่ก่อน", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        SplashScreenManager1.ShowWaitForm()

        DateStart = CDate(dtpStart.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))
        DateEnd = CDate(dtpEnd.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))
        SelectRight()

        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub SelectRight()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("A.INSTYPE,B.INSTYPE_DESC", " m_service A JOIN l_instype_new B ON(A.INSTYPE = B.INSTYPE_CODE) JOIN m_procedure_opd C ON(A.SEQ = C.SEQ) JOIN l_icd9 D ON(C.PROCEDCODE = D.CODE)", " WHERE A.STATUS_AF <> '8' AND (A.DATE_SERV >= " & DateStart & " AND A.DATE_SERV <= " & DateEnd & ") AND D.10TMD = 'Y' GROUP BY A.INSTYPE ")
        CheckBox1.Enabled = False
        cboINSTYPE.Enabled = False
        cmdShow2.Enabled = False

        If ds.Tables(0).Rows.Count > 0 Then
            With cboINSTYPE
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "INSTYPE_DESC"
                .Properties.ValueMember = "INSTYPE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = "พิมพ์เพื่อค้นหา"
            End With
            CheckBox1.Enabled = True
            cboINSTYPE.Enabled = True
            cmdShow2.Enabled = True

        End If

    End Sub

    Private Sub cmdShow2_Click(sender As Object, e As EventArgs) Handles cmdShow2.Click
        SplashScreenManager1.ShowWaitForm()
        Dim ds As DataSet
        Dim ds2 As DataSet
        If CheckBox1.Checked = False Then
            ds = clsdataBus.Lc_Business.SELECT_TABLE("A.PID,A.ROWID,B.HN,CID,PRENAME,NAME,LNAME,A.DATE_SERV,A.SEQ,INSID,PROCEDCODE,DESC_THA,PROVIDER,SUBSTR(A.D_UPDATE,1,8) AS D_UPDATE,C.COST,C.SERVICEPRICE,SERVPLACE", "m_service A JOIN m_person B ON(A.PID = B.PID) JOIN m_procedure_opd C ON(A.SEQ = C.SEQ) LEFT JOIN l_icd9 D ON(PROCEDCODE = CODE)  ", "WHERE (A.STATUS_AF <> '8' AND C.STATUS_AF = '1') AND (A.DATE_SERV >= " & DateStart & " AND A.DATE_SERV <= " & DateEnd & ") AND INSTYPE = '" & cboINSTYPE.EditValue & "' AND D.10TMD = 'Y' GROUP BY A.PID,A.DATE_SERV,PROCEDCODE ORDER BY A.DATE_SERV,CID ")
            ds2 = clsdataBus.Lc_Business.SELECT_TABLE("PROCEDCODE,DESC_THA,COUNT(DISTINCT(A.PID)) AS m_COUNT,COUNT(C.SEQ) AS C_COUNT,SUM(C.COST) AS SUm_COST,SUM(C.SERVICEPRICE) AS SUm_SERVPRICE", "m_service A JOIN m_person B ON(A.PID = B.PID) JOIN m_procedure_opd C ON(A.SEQ = C.SEQ) LEFT JOIN l_icd9 D ON(PROCEDCODE = CODE)  ", "WHERE (A.STATUS_AF <> '8' AND C.STATUS_AF = '1') AND (A.DATE_SERV >= " & DateStart & " AND A.DATE_SERV <= " & DateEnd & ") AND INSTYPE = '" & cboINSTYPE.EditValue & "' AND D.10TMD = 'Y' GROUP BY PROCEDCODE ")
        Else
            ds = clsdataBus.Lc_Business.SELECT_TABLE("A.PID,A.ROWID,B.HN,CID,PRENAME,NAME,LNAME,A.DATE_SERV,A.SEQ,INSID,PROCEDCODE,DESC_THA,PROVIDER,SUBSTR(A.D_UPDATE,1,8) AS D_UPDATE,C.COST,C.SERVICEPRICE,SERVPLACE", "m_service A JOIN m_person B ON(A.PID = B.PID) JOIN m_procedure_opd C ON(A.SEQ = C.SEQ) LEFT JOIN l_icd9 D ON(PROCEDCODE = CODE)  ", "WHERE (A.STATUS_AF <> '8' AND C.STATUS_AF = '1') AND (A.DATE_SERV >= " & DateStart & " AND A.DATE_SERV <= " & DateEnd & ") AND D.10TMD = 'Y' GROUP BY A.PID,A.DATE_SERV,PROCEDCODE ORDER BY A.DATE_SERV,CID ")
            ds2 = clsdataBus.Lc_Business.SELECT_TABLE("PROCEDCODE,DESC_THA,COUNT(DISTINCT(A.PID)) AS m_COUNT,COUNT(C.SEQ) AS C_COUNT,SUM(C.COST) AS SUm_COST,SUM(C.SERVICEPRICE) AS SUm_SERVPRICE", "m_service A JOIN m_person B ON(A.PID = B.PID) JOIN m_procedure_opd C ON(A.SEQ = C.SEQ) LEFT JOIN l_icd9 D ON(PROCEDCODE = CODE)  ", "WHERE (A.STATUS_AF <> '8' AND C.STATUS_AF = '1') AND (A.DATE_SERV >= " & DateStart & " AND A.DATE_SERV <= " & DateEnd & ")  AND D.10TMD = 'Y' GROUP BY PROCEDCODE ")
        End If

        If ds.Tables(0).Rows.Count > 0 Then
            DisplayData(ds)
            Label17.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0").ToString & " รายการ"
            cmdPrintReport2.Enabled = True

        Else
            BetterListView1.Items.Clear()
            Label17.Text = "จำนวน 0 รายการ"
            cmdPrintReport2.Enabled = False
        End If

        If ds2.Tables(0).Rows.Count > 0 Then
            DisplayData2(ds2)
            Label3.Text = "จำนวน " & ds2.Tables(0).Rows.Count.ToString("#,##0").ToString & " รายการ"
            cmdPrintReport1.Enabled = True

        Else
            BetterListView2.Items.Clear()
            Label3.Text = "จำนวน 0 รายการ"
            cmdPrintReport1.Enabled = False
        End If
        SplashScreenManager1.CloseWaitForm()

    End Sub
    Private Sub DisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
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

        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                dsRpt.Tables.Clear()
                drRpt = dt.NewRow()
                tmpOder = (i + 1).ToString

                BetterListView1.Items.Add(tmpOder).AlignHorizontal = TextAlignmentHorizontal.Center

                If Not IsDBNull(dr("ROWID")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("ROWID"))
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("CID")) Then
                    Try
                        BetterListView1.Items(i).SubItems.Add(dr("CID").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                        tmpCID = dr("CID")
                    Catch ex As Exception
                        BetterListView1.Items(i).SubItems.Add("ข้อมูลผิดพลาด")
                        tmpCID = ""
                    End Try
                Else
                    BetterListView1.Items(i).SubItems.Add("-")
                End If
                If Not IsDBNull(dr("PID")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("PID").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("-")
                End If
                If Not IsDBNull(dr("HN")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("HN").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("-")
                End If
                If Not IsDBNull(dr("PRENAME")) Then
                    tmpPrename = clsdataBus.Lc_Business.SELECT_NAME_PRENAME(dr("PRENAME"))
                End If
                Try
                    tmpName = tmpPrename & ((dr("NAME"))) & " " & ((dr("LNAME")))
                    BetterListView1.Items(i).SubItems.Add(tmpName).AlignHorizontal = TextAlignmentHorizontal.Left

                Catch ex As Exception
                    BetterListView1.Items(i).SubItems.Add("ข้อมูลผิดพลาด")
                    tmpName = ""
                End Try
                If Not IsDBNull(dr("DATE_SERV")) Then

                    tmpDateServ = Thaidate(dr("DATE_SERV"))
                    BetterListView1.Items(i).SubItems.Add(tmpDateServ).AlignHorizontal = TextAlignmentHorizontal.Center

                Else

                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("SERVPLACE")) Then
                    If dr("SERVPLACE") = "1" Then
                        BetterListView1.Items(i).SubItems.Add("ในหน่วยฯ").AlignHorizontal = TextAlignmentHorizontal.Center
                    Else
                        BetterListView1.Items(i).SubItems.Add("นอกหน่วยฯ").AlignHorizontal = TextAlignmentHorizontal.Center
                    End If
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If

                If Not IsDBNull(dr("PROCEDCODE")) Then

                    BetterListView1.Items(i).SubItems.Add((dr("DESC_THA") & " [" & dr("PROCEDCODE") & "]").ToString).AlignHorizontal = TextAlignmentHorizontal.Left

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
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("COST")) Then
                    If dr("COST") <> "" Then
                        BetterListView1.Items(i).SubItems.Add(CDbl(dr("COST")).ToString("#,##0.00")).AlignHorizontal = TextAlignmentHorizontal.Right
                    Else
                        BetterListView1.Items(i).SubItems.Add("0.00")
                    End If
                Else
                    BetterListView1.Items.Add("0.00")
                End If
                If Not IsDBNull(dr("SERVICEPRICE")) Then
                    If dr("SERVICEPRICE") <> "" Then
                        BetterListView1.Items(i).SubItems.Add(CDbl(dr("SERVICEPRICE")).ToString("#,##0.00")).AlignHorizontal = TextAlignmentHorizontal.Right
                    Else
                        BetterListView1.Items(i).SubItems.Add("0.00")
                    End If
                Else
                    BetterListView1.Items(i).SubItems.Add("0.00")
                End If
                If Not IsDBNull(dr("PROVIDER")) Then
                    BetterListView1.Items(i).SubItems.Add(ClsBusiness.Lc_Business.SELECT_NAME_PROVIDER(dr("PROVIDER"))).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("D_UPDATE")) Then
                    BetterListView1.Items(i).SubItems.Add(Thaidate_D_UPDATE(dr("D_UPDATE"))).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                drRpt("FIELD1") = "รายงานการให้บริการหัตถการแพทย์แผนไทย"

                drRpt("FIELD2") = "หน่วยบริการ : " & ClsBusiness.Lc_Business.SELECT_NAME_HCODE(vHcode).Replace("รพ.สต.", "โรงพยาบาลส่งเสริมสุขภาพตำบล") & vbCrLf & "วันที่ตัดยอดรายงาน " & DateStart & " ถึงวันที่ " & DateEnd

                'drRpt("FIELD2") = "แสดงข้อมูลการประมวลผล ระหว่างวันที่ " & Label4.Text & " ถึงวันที่ " & Label5.Text
                drRpt("FIELD3") = (i + 1).ToString
                drRpt("FIELD4") = tmpCID
                drRpt("FIELD5") = tmpName
                drRpt("FIELD6") = tmpDateServ
                If Not IsDBNull(dr("SERVPLACE")) Then
                    If dr("SERVPLACE") = "1" Then
                        drRpt("FIELD7") = "ในหน่วยฯ"
                    Else
                        drRpt("FIELD7") = "นอกหน่วยฯ"
                    End If
                Else
                    drRpt("FIELD7") = ""
                End If
                drRpt("FIELD8") = tmpDx
                If Not IsDBNull(dr("PROVIDER")) Then
                    drRpt("FIELD9") = ClsBusiness.Lc_Business.SELECT_NAME_PROVIDER(dr("PROVIDER"))
                Else
                    drRpt("FIELD9") = ""
                End If

                If Not IsDBNull(dr("SERVICEPRICE")) Then
                    drRpt("FIELD10") = dr("SERVICEPRICE")
                Else
                    drRpt("FIELD10") = ""
                End If

                dt.Rows.Add(drRpt)
            Next

            BetterListView1.ResumeSort(True)
            BetterListView1.EndUpdate()
            dsRpt.Tables.Add(dt)

            BetterListView1.AutoResizeColumn(2, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(5, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(8, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub DisplayData2(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow

        Dim sumType1 As Integer = 0
        Dim sumType2 As Integer = 0
        Dim sumType3 As Double = 0.0
        Dim sumType4 As Double = 0.0

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
        Dim k As Integer = 0

        Try
            BetterListView2.Items.Clear()
            BetterListView2.BeginUpdate()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                dsRpt2.Tables.Clear()
                drRpt = dt.NewRow()

                BetterListView2.Items.Add(dr("PROCEDCODE").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                If Not IsDBNull(dr("DESC_THA")) Then
                    BetterListView2.Items(i).SubItems.Add(dr("DESC_THA"))
                Else
                    BetterListView2.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("M_COUNT")) Then
                    BetterListView2.Items(i).SubItems.Add(CInt(dr("M_COUNT")).ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right
                Else
                    BetterListView2.Items(i).SubItems.Add("-")
                End If
                If Not IsDBNull(dr("C_COUNT")) Then
                    BetterListView2.Items(i).SubItems.Add(CInt(dr("C_COUNT")).ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right
                Else
                    BetterListView2.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("SUm_COST")) Then
                    BetterListView2.Items(i).SubItems.Add(CDbl(dr("SUm_COST")).ToString("#,##0.00")).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    BetterListView2.Items(i).SubItems.Add("0.00")
                End If
                If Not IsDBNull(dr("SUm_SERVPRICE")) Then
                    BetterListView2.Items(i).SubItems.Add(CDbl(dr("SUm_SERVPRICE")).ToString("#,##0.00")).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    BetterListView2.Items(i).SubItems.Add("0.00")
                End If

                If (i Mod 2) = 0 Then
                    BetterListView2.BackColor = Color.MintCream
                End If

                sumType1 = sumType1 + CInt(dr("M_COUNT"))
                sumType2 = sumType2 + CInt(dr("C_COUNT"))
                sumType3 = sumType3 + CDbl(dr("SUm_COST"))
                sumType4 = sumType4 + CDbl(dr("SUm_SERVPRICE"))

                drRpt("FIELD1") = "แสดงจำนวนผู้รับบริการแพทย์แผนไทย (หัตถการ)"

                drRpt("FIELD2") = "หน่วยบริการ : " & ClsBusiness.Lc_Business.SELECT_NAME_HCODE(vHcode).Replace("รพ.สต.", "โรงพยาบาลส่งเสริมสุขภาพตำบล") & vbCrLf & "วันที่ตัดยอดรายงาน " & DateStart & " ถึงวันที่ " & DateEnd

                'drRpt("FIELD3") = CInt(dr("ICD_GROUP")).ToString("00")
                drRpt("FIELD4") = dr("PROCEDCODE")
                drRpt("FIELD5") = dr("DESC_THA")
                drRpt("FIELD6") = dr("M_COUNT")
                drRpt("FIELD7") = dr("C_COUNT")
                drRpt("FIELD8") = dr("SUm_COST")
                drRpt("FIELD9") = dr("SUm_SERVPRICE")

                dt.Rows.Add(drRpt)
                k = k + 1
            Next

            BetterListView2.EndUpdate()
            dsRpt2.Tables.Add(dt)

            BetterListView2.AutoResizeColumn(1, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)

            BetterListView2.Items.Add("")
            BetterListView2.Items(k).SubItems.Add(("รวม").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
            BetterListView2.Items(k).SubItems.Add(CInt(sumType1).ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Center
            BetterListView2.Items(k).SubItems.Add(CInt(sumType2).ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Center
            BetterListView2.Items(k).SubItems.Add(CDbl(sumType3).ToString("#,##0.00")).AlignHorizontal = TextAlignmentHorizontal.Center
            BetterListView2.Items(k).SubItems.Add(CDbl(sumType4).ToString("#,##0.00")).AlignHorizontal = TextAlignmentHorizontal.Center

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub CheckBox1_Click(sender As Object, e As EventArgs) Handles CheckBox1.Click
        If CheckBox1.Checked = True Then
            Label1.Enabled = False
            cboINSTYPE.Enabled = False
            cmdShow2.Enabled = True
        Else
            Label1.Enabled = True
            cboINSTYPE.Enabled = True
        End If
    End Sub

    Private Sub cmdPrintReport2_Click(sender As Object, e As EventArgs) Handles cmdPrintReport2.Click
        PersonThai()

        Dim fReport As New frmReportView
        Dim params As ReportParameter

        params = New ReportParameter("RateId")

        fReport.ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\Reports\rptProcedThai2.rdlc"
        fReport.ReportViewer1.LocalReport.DataSources.Clear()
        CurrentReportDataSource.Name = "DataSet20F"
        CurrentReportDataSource.value = dsRpt2.Tables(0)
        fReport.ReportViewer1.LocalReport.DataSources.Add(CurrentReportDataSource)

        fReport.ShowDialog()

    End Sub

    Private Sub cmdPrintReport1_Click(sender As Object, e As EventArgs) Handles cmdPrintReport1.Click
        Dim fReport As New frmReportView
        Dim params As ReportParameter

        params = New ReportParameter("RateId")

        fReport.ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\Reports\rptProcedThai.rdlc"

        fReport.ReportViewer1.LocalReport.DataSources.Clear()
        CurrentReportDataSource.Name = "DataSet20F"
        CurrentReportDataSource.value = dsRpt.Tables(0)
        fReport.ReportViewer1.LocalReport.DataSources.Add(CurrentReportDataSource)

        fReport.ShowDialog()

    End Sub
    Private Sub PersonThai()

        Dim ds As DataSet

        If CheckBox1.Checked = False Then
            ds = clsdataBus.Lc_Business.SELECT_TABLE("A.PID,A.ROWID,B.HN,CID,PRENAME,NAME,LNAME,A.DATE_SERV,A.SEQ,INSID,PROCEDCODE,DESC_THA,PROVIDER,SUBSTR(A.D_UPDATE,1,8) AS D_UPDATE,C.COST,SUM(C.SERVICEPRICE) SUm_PRICE,SERVPLACE", "m_service A JOIN m_person B ON(A.PID = B.PID) JOIN m_procedure_opd C ON(A.SEQ = C.SEQ) LEFT JOIN l_icd9 D ON(PROCEDCODE = CODE)  ", "WHERE (A.STATUS_AF <> '8' AND C.STATUS_AF = '1') AND (A.DATE_SERV >= " & DateStart & " AND A.DATE_SERV <= " & DateEnd & ") AND INSTYPE = '" & cboINSTYPE.EditValue & "' AND D.10TMD = 'Y' GROUP BY A.PID,A.DATE_SERV ORDER BY A.DATE_SERV,CID ")
        Else
            ds = clsdataBus.Lc_Business.SELECT_TABLE("A.PID,A.ROWID,B.HN,CID,PRENAME,NAME,LNAME,A.DATE_SERV,A.SEQ,INSID,PROCEDCODE,DESC_THA,PROVIDER,SUBSTR(A.D_UPDATE,1,8) AS D_UPDATE,C.COST,SUM(C.SERVICEPRICE) SUm_PRICE,SERVPLACE", "m_service A JOIN m_person B ON(A.PID = B.PID) JOIN m_procedure_opd C ON(A.SEQ = C.SEQ) LEFT JOIN l_icd9 D ON(PROCEDCODE = CODE)  ", "WHERE (A.STATUS_AF <> '8' AND C.STATUS_AF = '1') AND (A.DATE_SERV >= " & DateStart & " AND A.DATE_SERV <= " & DateEnd & ") AND D.10TMD = 'Y' GROUP BY A.PID,A.DATE_SERV ORDER BY A.DATE_SERV,CID ")
        End If

        If ds.Tables(0).Rows.Count > 0 Then
            DisplayData3(ds)
        End If


    End Sub
    Private Sub DisplayData3(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
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
        Dim DateStart As String = CDate(dtpStart.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))
        Dim DateEnd As String = CDate(dtpEnd.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))

        Try

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                dsRpt3.Tables.Clear()
                drRpt = dt.NewRow()
                tmpOder = (i + 1).ToString

                If Not IsDBNull(dr("CID")) Then
                    Try
                        tmpCID = Decode(dr("CID"))
                    Catch ex As Exception
                        tmpCID = ""
                    End Try

                End If

                If Not IsDBNull(dr("PRENAME")) Then
                    tmpPrename = clsdataBus.Lc_Business.SELECT_NAME_PRENAME(dr("PRENAME"))
                End If
                Try
                    tmpName = tmpPrename & (Decode(dr("NAME"))) & " " & (Decode(dr("LNAME")))
                Catch ex As Exception
                    tmpName = ""
                End Try
                If Not IsDBNull(dr("DATE_SERV")) Then
                    tmpDateServ = DateTime.ParseExact(dr("DATE_SERV").ToString.Substring(0, 4) + 543 & dr("DATE_SERV").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yy")
                End If

                If Not IsDBNull(dr("PROCEDCODE")) Then

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
                End If

                drRpt("FIELD1") = "รายงานการให้บริการหัตถการแพทย์แผนไทย"

                drRpt("FIELD2") = "หน่วยบริการ : " & ClsBusiness.Lc_Business.SELECT_NAME_HCODE(vHcode).Replace("รพ.สต.", "โรงพยาบาลส่งเสริมสุขภาพตำบล") & vbCrLf & "วันที่ตัดยอดรายงาน " & DateStart & " ถึงวันที่ " & DateEnd
                drRpt("FIELD3") = (i + 1).ToString
                drRpt("FIELD4") = tmpCID
                drRpt("FIELD5") = tmpName
                drRpt("FIELD6") = tmpDateServ
                If Not IsDBNull(dr("SERVPLACE")) Then
                    If dr("SERVPLACE") = "1" Then
                        drRpt("FIELD7") = "ในหน่วยฯ"
                    Else
                        drRpt("FIELD7") = "นอกหน่วยฯ"
                    End If
                Else
                    drRpt("FIELD7") = ""
                End If
                drRpt("FIELD8") = tmpDx
                If Not IsDBNull(dr("PROVIDER")) Then
                    drRpt("FIELD9") = ClsBusiness.Lc_Business.SELECT_NAME_PROVIDER(dr("PROVIDER"))
                Else
                    drRpt("FIELD9") = ""
                End If

                If Not IsDBNull(dr("SUm_PRICE")) Then
                    drRpt("FIELD10") = CDbl(dr("SUm_PRICE")).ToString("0.00")
                Else
                    drRpt("FIELD10") = ""
                End If

                dt.Rows.Add(drRpt)
            Next

            dsRpt3.Tables.Add(dt)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub cboINSTYPE_EditValueChanged(sender As Object, e As EventArgs) Handles cboINSTYPE.EditValueChanged
        cmdShow2.Enabled = True
    End Sub


End Class