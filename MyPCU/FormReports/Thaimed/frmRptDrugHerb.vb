Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports DevExpress.XtraEditors
Imports ComponentOwl.BetterListView
Imports System.Globalization
Imports System.DateTime
Imports Microsoft.Reporting.WinForms

Public Class frmRptDrugHerb
    Dim dsRpt As New DataSet
    Dim dsRpt2 As New DataSet
    Dim CurrentReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
    Dim DateStart As String = ""
    Dim DateEnd As String = ""

    Private Sub frmRptDrugHerb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdShow2.Enabled = False
        cmdPrintReport2.Enabled = False
        cmdPrintReport1.Enabled = False

        With BetterListView1
            .Columns.Add(0).Text = "ROWID"
            .Columns(0).Width = 0
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ID"
            .Columns(1).Width = 60
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "HN"
            .Columns(2).Width = 0
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "CID"
            .Columns(3).Width = 150
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "ชื่อ-นามสกุล"
            .Columns(4).Width = 120
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "วันที่รับบริการ"
            .Columns(5).Width = 100
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "การวินิจฉัย"
            .Columns(6).Width = 300
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "รหัสยา"
            .Columns(7).Width = 150
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "ชื่อยา"
            .Columns(8).Width = 200
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center

        End With
        With BetterListView2
            .Columns.Add(0).Text = "รหัส"
            .Columns(0).Width = 150
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ยาแพทย์แผนไทย"
            .Columns(1).Width = 300
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "จำนวน (คน)"
            .Columns(2).Width = 0
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "จำนวน (ครั้ง)"
            .Columns(3).Width = 150
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "ค่าบริการ"
            .Columns(4).Width = 120
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
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
        CheckBox2.Enabled = False
        CheckBox3.Enabled = False
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
            CheckBox2.Enabled = True
            CheckBox3.Enabled = True
            cboINSTYPE.Enabled = True
            cmdShow2.Enabled = True

        End If

    End Sub

    Private Sub cmdShow2_Click(sender As Object, e As EventArgs) Handles cmdShow2.Click

        Dim ds As DataSet
        Dim ds2 As DataSet
        If CheckBox2.Checked = True Then
            If CheckBox1.Checked = False Then
                ds = clsdataBus.Lc_Business.SELECT_TABLE("A.PID,A.ROWID,B.HN,CID,PRENAME,NAME,LNAME,A.DATE_SERV,A.SEQ,INSID,PDX,DESC_THAI,DESC_ENG,DIDSTD,DNAME", "m_service A JOIN m_person B ON(A.PID = B.PID) JOIN m_drug_opd C ON(A.SEQ = C.SEQ) LEFT JOIN l_icd10 ON(PDX = CODE) ", "WHERE (A.STATUS_AF <> '8' AND C.STATUS_AF = '1') AND (A.DATE_SERV >= " & DateStart & " AND A.DATE_SERV <= " & DateEnd & ") AND INSTYPE = '" & cboINSTYPE.EditValue & "' AND DIDSTD LIKE '4%'  ORDER BY DATE_SERV,CID ")
            Else
                ds = clsdataBus.Lc_Business.SELECT_TABLE("A.PID,A.ROWID,B.HN,CID,PRENAME,NAME,LNAME,A.DATE_SERV,A.SEQ,INSID,PDX,DESC_THAI,DESC_ENG,DIDSTD,DNAME", "m_service A JOIN m_person B ON(A.PID = B.PID) JOIN m_drug_opd C ON(A.SEQ = C.SEQ) LEFT JOIN l_icd10 ON(PDX = CODE) ", "WHERE (A.STATUS_AF <> '8' AND C.STATUS_AF = '1') AND (A.DATE_SERV >= " & DateStart & " AND A.DATE_SERV <= " & DateEnd & ") AND DIDSTD LIKE '4%'  ORDER BY DATE_SERV,CID ")
            End If

        Else
            If CheckBox1.Checked = False Then
                ds = clsdataBus.Lc_Business.SELECT_TABLE("A.PID,A.ROWID,B.HN,CID,PRENAME,NAME,LNAME,A.DATE_SERV,A.SEQ,INSID,PDX,DESC_THAI,DESC_ENG,IFNULL(INSTYPE,'') AS INSTYPE", "m_service A JOIN m_person B ON(A.PID = B.PID) JOIN m_drug_opd C ON(A.SEQ = C.SEQ) LEFT JOIN l_icd10 ON(PDX = CODE) ", "WHERE (A.STATUS_AF <> '8' AND C.STATUS_AF = '1') AND (A.DATE_SERV >= " & DateStart & " AND A.DATE_SERV <= " & DateEnd & ") AND INSTYPE = '" & cboINSTYPE.EditValue & "' AND DIDSTD LIKE '4%'  GROUP BY A.PID,A.SEQ ORDER BY DATE_SERV,CID ")
            Else
                ds = clsdataBus.Lc_Business.SELECT_TABLE("A.PID,A.ROWID,B.HN,CID,PRENAME,NAME,LNAME,A.DATE_SERV,A.SEQ,INSID,PDX,DESC_THAI,DESC_ENG,IFNULL(INSTYPE,'') AS INSTYPE", "m_service A JOIN m_person B ON(A.PID = B.PID) JOIN m_drug_opd C ON(A.SEQ = C.SEQ) LEFT JOIN l_icd10 ON(PDX = CODE) ", "WHERE (A.STATUS_AF <> '8' AND C.STATUS_AF = '1') AND (A.DATE_SERV >= " & DateStart & " AND A.DATE_SERV <= " & DateEnd & ") AND DIDSTD LIKE '4%'  GROUP BY A.PID,A.SEQ ORDER BY DATE_SERV,CID ")
            End If

        End If
        If CheckBox1.Checked = True Then
            ds2 = clsdataBus.Lc_Business.SELECT_TABLE("C.DIDSTD,C.DNAME,COUNT(DISTINCT(A.PID)) AS m_COUNT,COUNT(C.SEQ) AS C_COUNT,SUM(C.AMOUNT*C.DRUGPRICE) AS SUm_PRICE", "m_service A JOIN m_person B ON(A.PID = B.PID) JOIN m_drug_opd C ON(A.SEQ = C.SEQ) LEFT JOIN l_drugprice D ON(C.DIDSTD = D.DIDSTD)  ", "WHERE (A.STATUS_AF <> '8' AND C.STATUS_AF = '1') AND (A.DATE_SERV >= " & DateStart & " AND A.DATE_SERV <= " & DateEnd & ") AND C.DIDSTD LIKE '4%'  GROUP BY C.DIDSTD ")
        Else
            ds2 = clsdataBus.Lc_Business.SELECT_TABLE("C.DIDSTD,C.DNAME,COUNT(DISTINCT(A.PID)) AS m_COUNT,COUNT(C.SEQ) AS C_COUNT,SUM(C.AMOUNT*C.DRUGPRICE) AS SUm_PRICE", "m_service A JOIN m_person B ON(A.PID = B.PID) JOIN m_drug_opd C ON(A.SEQ = C.SEQ) LEFT JOIN l_drugprice D ON(C.DIDSTD = D.DIDSTD)  ", "WHERE (A.STATUS_AF <> '8' AND C.STATUS_AF = '1') AND (A.DATE_SERV >= " & DateStart & " AND A.DATE_SERV <= " & DateEnd & ") AND INSTYPE = '" & cboINSTYPE.EditValue & "' AND C.DIDSTD LIKE '4%'  GROUP BY C.DIDSTD ")
        End If
        SplashScreenManager1.ShowWaitForm()
        If ds.Tables(0).Rows.Count > 0 Then
            If CheckBox2.Checked = True Then
                DisplayData(ds)
            Else
                DisplayData2(ds)
            End If

            Label4.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0").ToString & " รายการ"
            cmdPrintReport1.Enabled = True
        Else
            BetterListView1.Items.Clear()
            Label4.Text = "จำนวน 0 รายการ"
            cmdPrintReport1.Enabled = False

        End If

        If ds2.Tables(0).Rows.Count > 0 Then
            DisplayData3(ds2)
            Label5.Text = "จำนวน " & ds2.Tables(0).Rows.Count.ToString("#,##0").ToString & " รายการ"
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
        Dim tmpPrename As String = ""
        Dim tmpWeight As String = ""
        Dim tmpHeight As String = ""
        Dim tmpHead As String = ""
        Dim tmpNLEVEL As String = ""
        Dim tmpDx As String = ""
        Dim tmpOder As String = ""
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


                If Not IsDBNull(dr("ROWID")) Then
                    BetterListView1.Items.Add(dr("ROWID"))
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("PID")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("PID"))
                Else
                    BetterListView1.Items(i).SubItems.Add("-")
                End If
                If Not IsDBNull(dr("HN")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("HN"))
                Else
                    BetterListView1.Items(i).SubItems.Add("-")
                End If
                If Not IsDBNull(dr("CID")) Then
                    Try
                        BetterListView1.Items(i).SubItems.Add((dr("CID")))
                        tmpCID = (dr("CID"))
                    Catch ex As Exception
                        BetterListView1.Items(i).SubItems.Add("ข้อมูลผิดพลาด")
                        tmpCID = ""
                    End Try
                Else
                    BetterListView1.Items(i).SubItems.Add("-")
                End If
                If Not IsDBNull(dr("PRENAME")) Then
                    tmpPrename = clsdataBus.Lc_Business.SELECT_NAME_PRENAME(dr("PRENAME"))
                End If
                Try
                    BetterListView1.Items(i).SubItems.Add(tmpPrename & (dr("NAME")) & " " & (dr("LNAME")))
                    tmpName = tmpPrename & (dr("NAME")) & " " & (dr("LNAME"))
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

                If Not IsDBNull(dr("PDX")) Then
                    If vICD10TH = "1" Then
                        BetterListView1.Items(i).SubItems.Add(dr("PDX") & " " & dr("DESC_THAI"))
                    Else
                        BetterListView1.Items(i).SubItems.Add(dr("PDX") & " " & dr("DESC_ENG"))
                    End If
                    Dim ds3 As DataSet
                    ds3 = clsdataBus.Lc_Business.SELECT_TABLE("DIAGCODE,DESC_THAI", "m_diagnosis_opd A JOIN l_icd10 B ON(A.DIAGCODE = B.CODE) ", "WHERE STATUS_AF <> '8' AND SEQ = '" & dr("SEQ") & "'")
                    If ds3.Tables(0).Rows.Count > 0 Then
                        For h As Integer = 0 To ds3.Tables(0).Rows.Count - 1
                            If h = 0 Then
                                tmpDx = (h + 1).ToString & ". " & ds3.Tables(0).Rows(h).Item("DIAGCODE") & " " & ds3.Tables(0).Rows(h).Item("DESC_THAI")
                            Else
                                tmpDx = tmpDx & vbCrLf & (h + 1).ToString & ". " & ds3.Tables(0).Rows(h).Item("DIAGCODE") & " " & ds3.Tables(0).Rows(h).Item("DESC_THAI")
                            End If
                        Next
                    Else
                        tmpDx = "1. " & dr("PDX") & " " & dr("DESC_THAI")
                    End If
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If

                If Not IsDBNull(dr("DIDSTD")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("DIDSTD"))
                Else
                    BetterListView1.Items(i).SubItems.Add("-")
                End If
                If Not IsDBNull(dr("DNAME")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("DNAME"))
                Else
                    BetterListView1.Items(i).SubItems.Add("-")
                End If

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If


                drRpt("FIELD1") = "ตารางผลการให้บริการ การสั่งจ่ายยาแผนไทย (สมุนไพร) ตามบัญชียาหลักแห่งชาติ"

                drRpt("FIELD2") = "หน่วยบริการ : " & ClsBusiness.Lc_Business.SELECT_NAME_HCODE(vHcode).Replace("รพ.สต.", "โรงพยาบาลส่งเสริมสุขภาพตำบล") & vbCrLf & "วันที่ตัดยอดรายงาน " & DateStart & " ถึงวันที่ " & DateEnd

                drRpt("FIELD3") = (i + 1).ToString
                drRpt("FIELD5") = tmpCID
                drRpt("FIELD4") = tmpName
                drRpt("FIELD9") = tmpDx
                drRpt("FIELD8") = tmpDateServ
                drRpt("FIELD10") = dr("DIDSTD")
                drRpt("FIELD11") = dr("DNAME")
                drRpt("FIELD13") = dr("HN")

                dt.Rows.Add(drRpt)
            Next

            BetterListView1.EndUpdate()
            dsRpt.Tables.Add(dt)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub DisplayData3(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim sumType1 As Integer = 0
        Dim sumType2 As Integer = 0
        Dim sumType3 As Double = 0
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
            BetterListView2.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                dsRpt2.Tables.Clear()
                drRpt = dt.NewRow()

                BetterListView2.Items.Add(dr("DIDSTD"))
                If Not IsDBNull(dr("DNAME")) Then
                    BetterListView2.Items(i).SubItems.Add(dr("DNAME"))
                Else
                    BetterListView2.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(CInt(dr("M_COUNT")).ToString("#,##0")) Then
                    BetterListView2.Items(i).SubItems.Add(CInt(dr("M_COUNT")).ToString("#,##0"))
                Else
                    BetterListView2.Items(i).SubItems.Add("-")
                End If
                If Not IsDBNull(CInt(dr("C_COUNT")).ToString("#,##0")) Then
                    BetterListView2.Items(i).SubItems.Add(CInt(dr("C_COUNT")).ToString("#,##0"))
                Else
                    BetterListView2.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(CDbl(dr("SUm_PRICE")).ToString("#,##0.00")) Then
                    BetterListView2.Items(i).SubItems.Add(CDbl(dr("SUm_PRICE")).ToString("#,##0.00"))
                Else
                    BetterListView2.Items(i).SubItems.Add("0.00")
                End If

                If (i Mod 2) = 0 Then
                    BetterListView2.Items(i).BackColor = Color.WhiteSmoke
                End If
                k = k + 1
                sumType1 = sumType1 + CInt(dr("M_COUNT"))
                sumType2 = sumType2 + CInt(dr("C_COUNT"))
                sumType3 = sumType3 + CDbl(dr("SUm_PRICE"))

                drRpt("FIELD1") = "แสดงจำนวนผู้รับบริการแพทย์แผนไทย (ยาแพทย์แผนไทย)"

                drRpt("FIELD2") = "หน่วยบริการ : " & ClsBusiness.Lc_Business.SELECT_NAME_HCODE(vHcode).Replace("รพ.สต.", "โรงพยาบาลส่งเสริมสุขภาพตำบล") & vbCrLf & "วันที่ตัดยอดรายงาน " & DateStart & " ถึงวันที่ " & DateEnd

                'drRpt("FIELD3") = CInt(dr("ICD_GROUP")).ToString("00")
                drRpt("FIELD4") = dr("DIDSTD")
                drRpt("FIELD5") = dr("DNAME")
                drRpt("FIELD6") = dr("M_COUNT")
                drRpt("FIELD7") = dr("C_COUNT")
                drRpt("FIELD8") = dr("SUm_PRICE")

                dt.Rows.Add(drRpt)
            Next

            BetterListView2.EndUpdate()
            dsRpt2.Tables.Add(dt)

            BetterListView2.Items.Add("")
            BetterListView2.Items(k).SubItems.Add("รวม")
            BetterListView2.Items(k).SubItems.Add(CInt(sumType1).ToString("#,##0"))
            BetterListView2.Items(k).SubItems.Add(CInt(sumType2).ToString("#,##0"))
            BetterListView2.Items(k).SubItems.Add(CDbl(sumType3).ToString("#,##0.00"))

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub DisplayData2(ByVal ds As DataSet)
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

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                dsRpt.Tables.Clear()
                drRpt = dt.NewRow()
                tmpOder = (i + 1).ToString

                If Not IsDBNull(dr("ROWID")) Then
                    BetterListView1.Items.Add(dr("ROWID"))
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If

                BetterListView1.Items(i).SubItems.Add(tmpOder).AlignHorizontal = TextAlignmentHorizontal.Center


                If Not IsDBNull(dr("DATE_SERV")) Then
                    tmpDateServ = Thaidate(dr("DATE_SERV"))
                    BetterListView1.Items(i).SubItems.Add(tmpDateServ).AlignHorizontal = TextAlignmentHorizontal.Center

                Else
                    BetterListView1.Items(i).SubItems.Add("")

                End If
                If Not IsDBNull(dr("PRENAME")) Then
                    tmpPrename = clsdataBus.Lc_Business.SELECT_NAME_PRENAME(dr("PRENAME"))
                End If
                Try
                    BetterListView1.Items(i).SubItems.Add(tmpPrename & (Decode(dr("NAME"))) & " " & (Decode(dr("LNAME"))))
                    tmpName = tmpPrename & (Decode(dr("NAME"))) & " " & (Decode(dr("LNAME")))
                Catch ex As Exception
                    BetterListView1.Items(i).SubItems.Add("ข้อมูลผิดพลาด")
                    tmpName = ""
                End Try
                If Not IsDBNull(dr("HN")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("HN"))
                Else
                    BetterListView1.Items(i).SubItems.Add("-")
                End If
                BetterListView1.Items(i).SubItems.Add(ClsBusiness.Lc_Business.SELECT_NAME_ADDRESS_PID(dr("PID")))
                BetterListView1.Items(i).SubItems.Add(ClsBusiness.Lc_Business.SELECT_NAME_INSTYPE_NEW(dr("INSTYPE")))


                If Not IsDBNull(dr("PDX")) Then
                    If vICD10TH = "1" Then
                        BetterListView1.Items(i).SubItems.Add(dr("PDX") & " " & dr("DESC_THAI"))
                    Else
                        BetterListView1.Items(i).SubItems.Add(dr("PDX") & " " & dr("DESC_ENG"))
                    End If
                    Dim ds3 As DataSet
                    ds3 = clsdataBus.Lc_Business.SELECT_TABLE("DIAGCODE,DESC_THAI", "m_diagnosis_opd A JOIN l_icd10 B ON(A.DIAGCODE = B.CODE) ", "WHERE STATUS_AF <> '8' AND SEQ = '" & dr("SEQ") & "'")
                    If ds3.Tables(0).Rows.Count > 0 Then
                        For h As Integer = 0 To ds3.Tables(0).Rows.Count - 1
                            If h = 0 Then
                                tmpDx = (h + 1).ToString & ". " & ds3.Tables(0).Rows(h).Item("DIAGCODE") & " " & ds3.Tables(0).Rows(h).Item("DESC_THAI")
                            Else
                                tmpDx = tmpDx & vbCrLf & (h + 1).ToString & ". " & ds3.Tables(0).Rows(h).Item("DIAGCODE") & " " & ds3.Tables(0).Rows(h).Item("DESC_THAI")
                            End If
                        Next
                    Else
                        tmpDx = "1. " & dr("PDX") & " " & dr("DESC_THAI")
                    End If

                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                Dim ds2 As DataSet
                ds2 = clsdataBus.Lc_Business.SELECT_TABLE("DNAME,AMOUNT,DRUGPRICE,DRUG_DOSE", "m_drug_opd", "WHERE STATUS_AF <> '8' AND DIDSTD LIKE '4%' AND SEQ = '" & dr("SEQ") & "'")
                If ds2.Tables(0).Rows.Count > 0 Then
                    BetterListView1.Items(i).SubItems.Add(ds2.Tables(0).Rows(0).Item("DNAME"))
                    BetterListView1.Items(i).SubItems.Add(ds2.Tables(0).Rows(0).Item("AMOUNT"))
                    BetterListView1.Items(i).SubItems.Add(CDbl(ds2.Tables(0).Rows(0).Item("DRUGPRICE") * ds2.Tables(0).Rows(0).Item("AMOUNT")).ToString("0.00"))
                    BetterListView1.Items(i).SubItems.Add(ClsBusiness.Lc_Business.SELECT_NAME_DRUG_DOSE(ds2.Tables(0).Rows(0).Item("DRUG_DOSE")))
                    For k As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                        tmpDNAME = ds2.Tables(0).Rows(k).Item("DNAME")
                        tmpAmount = ds2.Tables(0).Rows(k).Item("AMOUNT")
                        tmpPrice = CDbl(ds2.Tables(0).Rows(k).Item("DRUGPRICE") * ds2.Tables(0).Rows(k).Item("AMOUNT")).ToString("0.00")
                        tmpDose = ClsBusiness.Lc_Business.SELECT_NAME_DRUG_DOSE(ds2.Tables(0).Rows(k).Item("DRUG_DOSE"))
                        If k > 0 Then
                            tmpDNAME = tmpDNAME & vbCrLf & ds2.Tables(0).Rows(k).Item("DNAME")
                            tmpAmount = tmpAmount & vbCrLf & ds2.Tables(0).Rows(k).Item("AMOUNT")
                            tmpPrice = tmpPrice & vbCrLf & ds2.Tables(0).Rows(k).Item("DRUGPRICE")
                            If Not IsDBNull(ds2.Tables(0).Rows(k).Item("DRUG_DOSE")) Then
                                tmpDose = tmpDose & vbCrLf & ClsBusiness.Lc_Business.SELECT_NAME_DRUG_DOSE(ds2.Tables(0).Rows(k).Item("DRUG_DOSE"))
                            Else
                                tmpDose = ""
                            End If
                        End If
                    Next

                Else
                    BetterListView1.Items(i).SubItems.Add("")
                    BetterListView1.Items(i).SubItems.Add("")
                    BetterListView1.Items(i).SubItems.Add("")
                    BetterListView1.Items(i).SubItems.Add("")
                End If


                drRpt("FIELD1") = "ตารางผลการให้บริการ การสั่งจ่ายยาแผนไทย (สมุนไพร) ตามบัญชียาหลักแห่งชาติ"

                drRpt("FIELD2") = "หน่วยบริการ : " & ClsBusiness.Lc_Business.SELECT_NAME_HCODE(vHcode).Replace("รพ.สต.", "โรงพยาบาลส่งเสริมสุขภาพตำบล") & vbCrLf & "วันที่ตัดยอดรายงาน " & DateStart & " ถึงวันที่ " & DateEnd

                'drRpt("FIELD2") = "แสดงข้อมูลการประมวลผล ระหว่างวันที่ " & Label4.Text & " ถึงวันที่ " & Label5.Text
                drRpt("FIELD3") = (i + 1).ToString
                drRpt("FIELD5") = tmpCID
                drRpt("FIELD4") = tmpName
                drRpt("FIELD9") = tmpDx
                drRpt("FIELD8") = tmpDateServ
                drRpt("FIELD13") = dr("HN")
                drRpt("FIELD10") = tmpDNAME
                drRpt("FIELD11") = tmpAmount
                drRpt("FIELD12") = ClsBusiness.Lc_Business.SELECT_NAME_ADDRESS_PID(dr("PID"))
                drRpt("FIELD14") = ClsBusiness.Lc_Business.SELECT_NAME_INSTYPE_NEW(dr("INSTYPE"))
                drRpt("FIELD15") = tmpPrice
                drRpt("FIELD16") = tmpDose
                dt.Rows.Add(drRpt)
            Next

            BetterListView1.EndUpdate()
            dsRpt.Tables.Add(dt)

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

    Private Sub CheckBox3_Click(sender As Object, e As EventArgs) Handles CheckBox3.Click
        CheckBox3.Checked = True
        CheckBox2.Checked = False
        BetterListView1.Items.Clear()
        BetterListView1.Columns.Clear()
        With BetterListView1
            .Columns.Add(0).Text = "ROWID"
            .Columns(0).Width = 0
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ลำดับ"
            .Columns(1).Width = 60
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "DATE_SERV"
            .Columns(2).Width = 0
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "วันที่รับบริการ"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "ชื่อ-นามสกุล"
            .Columns(4).Width = 150
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "HN"
            .Columns(5).Width = 80
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(66).Text = "ที่อยู่"
            .Columns(6).Width = 150
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "สิทธิ"
            .Columns(7).Width = 120
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "การวินิจฉัย"
            .Columns(8).Width = 300
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(9).Text = "ชื่อยา"
            .Columns(9).Width = 200
            .Columns(9).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(10).Text = "จำนวน"
            .Columns(10).Width = 100
            .Columns(10).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(11).Text = "ราคา"
            .Columns(11).Width = 100
            .Columns(11).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(12).Text = "คำแนะนำ"
            .Columns(12).Width = 150
            .Columns(12).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center

        End With

    End Sub

    Private Sub CheckBox2_Click(sender As Object, e As EventArgs) Handles CheckBox2.Click
        CheckBox2.Checked = True
        CheckBox3.Checked = False

        BetterListView1.Items.Clear()
        BetterListView1.Columns.Clear()
        With BetterListView1
            .Columns.Add(0).Text = "ROWID"
            .Columns(0).Width = 0
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ID"
            .Columns(1).Width = 60
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "HN"
            .Columns(2).Width = 0
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "CID"
            .Columns(3).Width = 150
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "ชื่อ-นามสกุล"
            .Columns(4).Width = 120
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "วันที่รับบริการ"
            .Columns(5).Width = 100
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "การวินิจฉัย"
            .Columns(6).Width = 300
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "รหัสยา"
            .Columns(7).Width = 150
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "ชื่อยา"
            .Columns(8).Width = 200
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center

        End With
    End Sub
    Private Sub cmdPrintReport1_Click(sender As Object, e As EventArgs) Handles cmdPrintReport1.Click
        Dim fReport As New frmReportView
        Dim params As ReportParameter

        params = New ReportParameter("RateId")

        fReport.ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "rptDrugHerb3.rdlc"

        fReport.ReportViewer1.LocalReport.DataSources.Clear()
        CurrentReportDataSource.Name = "DataSet20F"
        CurrentReportDataSource.value = dsRpt.Tables(0)
        fReport.ReportViewer1.LocalReport.DataSources.Add(CurrentReportDataSource)

        fReport.ShowDialog()
    End Sub
    Private Sub cmdPrintReport2_Click(sender As Object, e As EventArgs) Handles cmdPrintReport2.Click
        Dim fReport As New frmReportView
        Dim params As ReportParameter

        params = New ReportParameter("RateId")
        If CheckBox2.Checked = True Then
            fReport.ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\Reports\rptDrugHerb.rdlc"
        Else
            fReport.ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\Reports\rptDrugHerb2.rdlc"
        End If

        fReport.ReportViewer1.LocalReport.DataSources.Clear()
        CurrentReportDataSource.Name = "DataSet20F"
        CurrentReportDataSource.value = dsRpt.Tables(0)
        fReport.ReportViewer1.LocalReport.DataSources.Add(CurrentReportDataSource)

        fReport.ShowDialog()
    End Sub
End Class