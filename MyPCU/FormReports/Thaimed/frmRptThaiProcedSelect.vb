Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Text
Imports Microsoft.Reporting.WinForms
Imports DevExpress.XtraEditors
Imports ComponentOwl.BetterListView
Imports System.Globalization
Imports System.DateTime
Imports MySql.Data.MySqlClient

Public Class frmRptThaiProcedSelect
    Dim dsx As DataSet
    Dim tmpProcedCode As String = ""
    Dim tmpProcedCode2 As String = ""
    Dim tmpICD As String = ""
    Dim dsRpt As New DataSet
    Dim dsRpt2 As New DataSet
    Dim CurrentReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
    Dim DateStart As String = ""
    Dim DateEnd As String = ""

    Private Sub frmRptThaiProcedSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdPrint.Enabled = False
        cmdPrintReport2.Enabled = False


        If vProcedSelect = "15" Then
            Me.Text = "รายงานหัตถการแพทย์แผนไทย(กำหนดเงื่อนไขเอง)"
        ElseIf vProcedSelect = "11" Then
            Me.Text = "รายงานหัตถการทั่วไป(กำหนดเงื่อนไขเอง)"
        ElseIf vProcedSelect = "14" Then
            Me.Text = "รายงานหัตถการกายภาพบำบัด(กำหนดเงื่อนไขเอง)"
        End If

        With BetterListView1
            .Columns.Add(0).Text = "รหัส"
            .Columns(0).Width = 80
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "กิจกรรม"
            .Columns(1).Width = 200
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "คน"
            .Columns(2).Width = 100
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "ครั้ง"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "งาน"
            .Columns(4).Width = 100
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "ค่าบริการ"
            .Columns(5).Width = 100
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "ต้นทุน"
            .Columns(5).Width = 120
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center

        End With

        With BetterListView2
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
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "HN"
            .Columns(4).Width = 0
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "ชื่อ-นามสกุล"
            .Columns(5).Width = 150
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "อายุ"
            .Columns(6).Width = 120
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "DATE_SERV"
            .Columns(7).Width = 0
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "วันที่รับบริการ"
            .Columns(8).Width = 100
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(9).Text = "สถานที่รับบริการ"
            .Columns(9).Width = 100
            .Columns(9).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(10).Text = "กิจกรรม"
            .Columns(10).Width = 150
            .Columns(10).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(11).Text = "ผู้ให้บริการ"
            .Columns(11).Width = 100
            .Columns(11).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(12).Text = "สิทธิ"
            .Columns(12).Width = 100
            .Columns(12).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(13).Text = "หน่วยบริการหลัก"
            .Columns(13).Width = 150
            .Columns(13).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(14).Text = "วันที่บันทึกข้อมูล"
            .Columns(14).Width = 100
            .Columns(14).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center

        End With

        With BetterListView3
            .Columns.Add(0).Text = "รหัส"
            .Columns(0).Width = 80
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "กิจกรรม"
            .Columns(1).Width = 250
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center

        End With

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("PROVIDER,CONCAT(B.PRENAME,NAME,' ',LNAME) AS PROVIDER_NAME", "m_provider A LEFT JOIN l_prename B ON(A.PRENAME = B.PRENAME_CODE)", " WHERE A.STATUS = '1' AND STATUS_AF <> '8' ORDER BY NAME")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboProvider
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "PROVIDER_NAME"
                .Properties.ValueMember = "PROVIDER"
                .Properties.TextEditStyle = 0
            End With
        End If
        ShowDataProced()
        cboSelect.EditValue = 0
    End Sub
    Private Sub ShowDataProced()
        Dim ds2 As DataSet
        Dim tmpSQL As String = ""

        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("PROCEDCODE,DESC_THA,A.STATUS", " l_procedprice A JOIN l_icd9 B ON(A.PROCEDCODE = B.CODE) ", " WHERE CHARGEITEM = '" & "vProcedSelect" & "' AND A.STATUS = '1' ORDER BY PROCEDCODE ")
        If ds2.Tables(0).Rows.Count > 0 Then
            DisplayData3(ds2)

        Else
            BetterListView3.Items.Clear()

        End If
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
    Private Sub DisplayData3(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim tmpPrename As String = ""

        Try
            BetterListView3.Items.Clear()
            BetterListView3.BeginUpdate()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                If dr("PROCEDCODE") <> "" Then
                    BetterListView3.Items.Add(dr("PROCEDCODE"))
                Else
                    BetterListView3.Items(i).SubItems.Add("")
                End If

                If dr("DESC_THA") <> "" Then
                    BetterListView3.Items(i).SubItems.Add(dr("DESC_THA"))
                Else
                    BetterListView3.Items(i).SubItems.Add("")
                End If

                If (i Mod 2) = 0 Then
                    BetterListView3.Items(i).BackColor = Color.MintCream
                End If

                If dr("STATUS") = "0" Then
                    BetterListView3.Items(i).BackColor = Color.LightPink
                End If
            Next
            BetterListView3.EndUpdate()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub Chk2_Click(sender As Object, e As EventArgs) Handles chk2.Click
        If chk2.Checked = True Then
            For i = 0 To BetterListView3.Items.Count - 1
                BetterListView3.Items(i).Checked = True
            Next
        Else
            For i = 0 To BetterListView3.Items.Count - 1
                BetterListView3.Items(i).Checked = False
            Next
        End If
    End Sub
    Private Sub cmdProcess_Click(sender As Object, e As EventArgs) Handles cmdProcess.Click

        If dtpStart.EditValue = Nothing Or dtpEnd.EditValue = Nothing Then
            XtraMessageBox.Show("กรุณากำหนดวันที่ก่อน", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        For Each itm As BetterListViewItem In BetterListView3.Items
            If itm.Checked = True Then
                tmpICD = itm.SubItems.Item(0).Text
                If tmpProcedCode = "" Then
                    tmpProcedCode = tmpICD
                Else
                    tmpProcedCode = tmpProcedCode & "','" & tmpICD
                End If
            End If
        Next
        BetterListView2.Items.Clear()
        SplashScreenManager1.ShowWaitForm()

        DateStart = CDate(dtpStart.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))
        DateEnd = CDate(dtpEnd.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))
        cmdPrintReport2.Enabled = False
        BetterListView2.Items.Clear()
        ShowData()

        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub ShowData()
        Dim tmpSQL As String = ""
        Dim tmpSQL2 As String = ""
        Dim tmpSQL3 As String = ""
        Dim tmpSQL4 As String = ""
        Dim tmpSQL5 As String = ""

        If tmpProcedCode = "" Then
            tmpSQL3 = " AND PROCEDCODE = '' "
        Else
            tmpSQL3 = " AND PROCEDCODE IN('" & tmpProcedCode & "')  "
        End If

        If CheckBox1.Checked = True Then
            tmpSQL = " AND B.PROVIDER = '" & cboProvider.EditValue & "'"
        Else
            tmpSQL = ""
        End If

        If chk1.Checked = True Then
            tmpSQL2 = ""
        ElseIf chk2.Checked = True Then
            tmpSQL2 = " AND LOCATION = '1' "
        ElseIf chk3.Checked = True Then
            tmpSQL2 = " AND LOCATION = '2' "
        End If

        If chk4.Checked = True Then
            tmpSQL5 = ""
        ElseIf chk5.Checked = True Then
            tmpSQL5 = " AND INTIME = '1' "
        ElseIf chk6.Checked = True Then
            tmpSQL5 = " AND INTIME = '2' "
        End If

        If cboSelect.EditValue = 0 Then
            tmpSQL4 = ""
        ElseIf cboSelect.EditValue = 1 Then
            tmpSQL4 = " AND (INSTYPE LIKE '1%' OR INSTYPE LIKE '2%' OR INSTYPE LIKE '3%' OR INSTYPE LIKE '7%' ) "
        ElseIf cboSelect.EditValue = 2 Then
            tmpSQL4 = " AND (INSTYPE LIKE '4%' ) "
        ElseIf cboSelect.EditValue = 3 Then
            tmpSQL4 = " AND (INSTYPE LIKE '0%' AND SUBINSTYPE <> '89' AND MAIN = '" & vHmain & "') "
        ElseIf cboSelect.EditValue = 4 Then
            tmpSQL4 = " AND (INSTYPE LIKE '0%' AND SUBINSTYPE <> '89' AND MAIN <> '" & vHmain & "') "
        ElseIf cboSelect.EditValue = 5 Then
            tmpSQL4 = " AND (INSTYPE LIKE '0%' AND SUBINSTYPE = '89' AND MAIN = '" & vHmain & "') "
        ElseIf cboSelect.EditValue = 6 Then
            tmpSQL4 = " AND (INSTYPE LIKE '0%' AND SUBINSTYPE = '89' AND MAIN <> '" & vHmain & "') "
        ElseIf cboSelect.EditValue = 7 Then
            tmpSQL4 = " AND (INSTYPE LIKE '84%') "
        ElseIf cboSelect.EditValue = 8 Then
            tmpSQL4 = " AND (INSTYPE LIKE '5%' OR INSTYPE LIKE '6%' OR INSTYPE LIKE '81%' OR INSTYPE LIKE '82%' OR INSTYPE LIKE '83%' OR INSTYPE LIKE '91%' ) "
        End If

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("PROCEDCODE,DESC_THA," _
                                                 & "COUNT(DISTINCT(A.PID)) AS P_COUNT1," _
                                                 & "COUNT(DISTINCT(A.SEQ)) AS C_COUNT1," _
                                                 & "COUNT(B.PROCEDCODE) AS m_COUNT1," _
                                                 & "SUM(SERVICEPRICE) AS SUm_PRICE," _
                                                 & "SUM(B.COST) AS SUm_COST" _
                                                 , "m_service A JOIN m_procedure_opd B ON(A.SEQ = B.SEQ) JOIN l_icd9 C ON(B.PROCEDCODE = C.CODE) JOIN m_person D ON(A.PID = D.PID) ", " WHERE (A.DATE_SERV >= " & DateStart & " AND A.DATE_SERV <= " & DateEnd & ") " & tmpSQL & tmpSQL2 & tmpSQL3 & tmpSQL4 & tmpSQL5 & " GROUP BY PROCEDCODE ")
        If ds.Tables(0).Rows.Count > 0 Then
            ShowData2()
            DisplayData(ds)
            cmdPrint.Enabled = True
        Else
            BetterListView1.Items.Clear()
            cmdPrint.Enabled = False
        End If
    End Sub
    Private Sub ShowData2()
        Dim tmpSQL As String = ""
        Dim tmpSQL2 As String = ""
        Dim tmpSQL3 As String = ""
        Dim tmpSQL4 As String = ""
        Dim tmpSQL5 As String = ""

        If tmpProcedCode = "" Then
            tmpSQL3 = " AND PROCEDCODE = '' "
        Else
            tmpSQL3 = " AND PROCEDCODE IN('" & tmpProcedCode & "')  "
        End If

        If chk1.Checked = True Then
            tmpSQL = " AND B.PROVIDER = '" & cboProvider.EditValue & "'"
        Else
            tmpSQL = ""
        End If

        If chk1.Checked = True Then
            tmpSQL2 = ""
        ElseIf chk2.Checked = True Then
            tmpSQL2 = " AND LOCATION = '1' "
        ElseIf chk3.Checked = True Then
            tmpSQL2 = " AND LOCATION = '2' "
        End If

        If chk4.Checked = True Then
            tmpSQL5 = ""
        ElseIf chk5.Checked = True Then
            tmpSQL5 = " AND INTIME = '1' "
        ElseIf chk6.Checked = True Then
            tmpSQL5 = " AND INTIME = '2' "
        End If

        If cboSelect.EditValue = 0 Then
            tmpSQL4 = ""
        ElseIf cboSelect.EditValue = 1 Then
            tmpSQL4 = " AND (INSTYPE LIKE '1%' OR INSTYPE LIKE '2%' OR INSTYPE LIKE '3%' OR INSTYPE LIKE '7%' ) "
        ElseIf cboSelect.EditValue = 2 Then
            tmpSQL4 = " AND (INSTYPE LIKE '4%' ) "
        ElseIf cboSelect.EditValue = 3 Then
            tmpSQL4 = " AND (INSTYPE LIKE '0%' AND SUBINSTYPE <> '89' AND MAIN = '" & vHmain & "') "
        ElseIf cboSelect.EditValue = 4 Then
            tmpSQL4 = " AND (INSTYPE LIKE '0%' AND SUBINSTYPE <> '89' AND MAIN <> '" & vHmain & "') "
        ElseIf cboSelect.EditValue = 5 Then
            tmpSQL4 = " AND (INSTYPE LIKE '0%' AND SUBINSTYPE = '89' AND MAIN = '" & vHmain & "') "
        ElseIf cboSelect.EditValue = 6 Then
            tmpSQL4 = " AND (INSTYPE LIKE '0%' AND SUBINSTYPE = '89' AND MAIN <> '" & vHmain & "') "
        ElseIf cboSelect.EditValue = 7 Then
            tmpSQL4 = " AND (INSTYPE LIKE '84%') "
        ElseIf cboSelect.EditValue = 8 Then
            tmpSQL4 = " AND (INSTYPE LIKE '5%' OR INSTYPE LIKE '6%' OR INSTYPE LIKE '81%' OR INSTYPE LIKE '82%' OR INSTYPE LIKE '83%' OR INSTYPE LIKE '91%' ) "
        End If


        dsx = clsdataBus.Lc_Business.SELECT_TABLE("" _
                                                 & "COUNT(DISTINCT(A.PID)) AS P_COUNT1," _
                                                 & "COUNT(DISTINCT(A.SEQ)) AS C_COUNT1," _
                                                 & "COUNT(B.PROCEDCODE) AS m_COUNT1," _
                                                 & "SUM(SERVICEPRICE) AS SUm_PRICE" _
                                                 , "m_service A JOIN m_procedure_opd B ON(A.SEQ = B.SEQ) JOIN l_icd9 C ON(B.PROCEDCODE = C.CODE) JOIN m_person D ON(A.PID = D.PID) ", " WHERE (A.DATE_SERV >= " & DateStart & " AND A.DATE_SERV <= " & DateEnd & ") " & tmpSQL & tmpSQL2 & tmpSQL3 & tmpSQL4 & tmpSQL5 & "  GROUP BY A.HOSPCODE ")

    End Sub
    Private Sub DisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing

        Dim dr As DataRow
        Dim sum1 As Integer = 0
        Dim sum2 As Integer = 0
        Dim sum3 As Integer = 0
        Dim sum4 As Double = 0.0
        Dim sum5 As Double = 0.0
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

        Try
            BetterListView1.Items.Clear()


            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)

                BetterListView1.Items.Add(dr("PROCEDCODE"))
                BetterListView1.Items(i).SubItems.Add(dr("DESC_THA"))
                If Not IsDBNull(dr("P_COUNT1")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("P_COUNT1")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("C_COUNT1")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("C_COUNT1")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("M_COUNT1")) Then
                    BetterListView1.Items(i).SubItems.Add(CInt(dr("M_COUNT1")).ToString("#,##0"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0")
                End If
                If Not IsDBNull(dr("SUm_PRICE")) Then
                    BetterListView1.Items(i).SubItems.Add(CDbl(dr("SUm_PRICE")).ToString("#,##0.00"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0.00")
                End If
                If Not IsDBNull(dr("SUm_COST")) Then
                    BetterListView1.Items(i).SubItems.Add(CDbl(dr("SUm_COST")).ToString("#,##0.00"))
                Else
                    BetterListView1.Items(i).SubItems.Add("0.00")
                End If

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.MintCream
                End If
                k = k + 1
                sum1 = CInt(dr("P_COUNT1")) + sum1
                sum2 = CInt(dr("C_COUNT1")) + sum2
                sum3 = CInt(dr("M_COUNT1")) + sum3
                sum4 = CDbl(dr("SUm_PRICE")) + sum4
                sum5 = CDbl(dr("SUm_COST")) + sum5

                dsRpt.Tables.Clear()
                drRpt = dt.NewRow()
                Dim tmpHeadRpt As String = ""
                'If vProcedSelect = "15" Then
                '    tmpHeadRpt = "รายงานหัตถการแพทย์แผนไทย"
                'ElseIf vProcedSelect = "11" Then
                '    tmpHeadRpt = "รายงานหัตถการทั่วไป"
                'ElseIf vProcedSelect = "14" Then
                '    tmpHeadRpt = "รายงานหัตถการกายภาพบำบัด"
                'End If

                drRpt("FIELD1") = tmpHeadRpt & vbCrLf & "สถานบริการ " & ClsBusiness.Lc_Business.SELECT_NAME_HCODE(vHcode).Replace("รพ.สต.", "โรงพยาบาลส่งเสริมสุขภาพตำบล")
                If CheckBox1.Checked = False Then
                    drRpt("FIELD2") = "ประมวลผลตั้งแต่วันที่ " & DateStart & " ถึงวันที่ " & DateEnd
                Else
                    drRpt("FIELD2") = "ผู้ให้บริการ " & ClsBusiness.Lc_Business.SELECT_NAME_PROVIDER(cboProvider.EditValue) & "   ประมวลผลตั้งแต่วันที่ " & DateStart & " ถึงวันที่ " & DateEnd
                End If


                drRpt("FIELD3") = dr("PROCEDCODE")
                drRpt("FIELD4") = dr("DESC_THA")
                drRpt("FIELD5") = dr("P_COUNT1")
                drRpt("FIELD6") = dr("C_COUNT1")
                drRpt("FIELD7") = dr("M_COUNT1")
                drRpt("FIELD8") = dr("SUm_PRICE")
                drRpt("FIELD9") = dsx.Tables(0).Rows(0).Item("P_COUNT1")
                drRpt("FIELD10") = dr("SUm_COST")

                dt.Rows.Add(drRpt)

            Next

            dsRpt.Tables.Add(dt)
            BetterListView1.Items.Add("")
            BetterListView1.Items(k).SubItems.Add("รวม")
            BetterListView1.Items(k).SubItems.Add(CInt(dsx.Tables(0).Rows(0).Item("P_COUNT1")).ToString("#,##0"))
            BetterListView1.Items(k).SubItems.Add(CInt(sum2).ToString("#,##0"))
            BetterListView1.Items(k).SubItems.Add(CInt(sum3).ToString("#,##0"))
            BetterListView1.Items(k).SubItems.Add(CDbl(sum4).ToString("#,##0.00"))
            BetterListView1.Items(k).SubItems.Add(CDbl(sum5).ToString("#,##0.00"))

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub betterListView1_Click(sender As Object, e As EventArgs) Handles BetterListView1.Click
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            tmpProcedCode2 = lvi.SubItems.Item(0).Text
        Next
        ShowData3()
    End Sub

    Private Sub ShowData3()
        Dim tmpSQL As String = ""
        Dim tmpSQL2 As String = ""
        Dim tmpSQL3 As String = ""
        Dim tmpSQL4 As String = ""
        Dim tmpSQL5 As String = ""

        If cboSelect.EditValue = 0 Then
            tmpSQL = ""
        ElseIf cboSelect.EditValue = 1 Then
            tmpSQL = " AND (INSTYPE LIKE '1%' OR INSTYPE LIKE '2%' OR INSTYPE LIKE '3%' OR INSTYPE LIKE '7%' ) "
        ElseIf cboSelect.EditValue = 2 Then
            tmpSQL = " AND (INSTYPE LIKE '4%' ) "
        ElseIf cboSelect.EditValue = 3 Then
            tmpSQL = " AND (INSTYPE LIKE '0%' AND SUBINSTYPE <> '89' AND MAIN = '" & vHmain & "') "
        ElseIf cboSelect.EditValue = 4 Then
            tmpSQL = " AND (INSTYPE LIKE '0%' AND SUBINSTYPE <> '89' AND MAIN <> '" & vHmain & "') "
        ElseIf cboSelect.EditValue = 5 Then
            tmpSQL = " AND (INSTYPE LIKE '0%' AND SUBINSTYPE = '89' AND MAIN = '" & vHmain & "') "
        ElseIf cboSelect.EditValue = 6 Then
            tmpSQL = " AND (INSTYPE LIKE '0%' AND SUBINSTYPE = '89' AND MAIN <> '" & vHmain & "') "
        ElseIf cboSelect.EditValue = 7 Then
            tmpSQL = " AND (INSTYPE LIKE '84%') "
        ElseIf cboSelect.EditValue = 8 Then
            tmpSQL = " AND (INSTYPE LIKE '5%' OR INSTYPE LIKE '6%' OR INSTYPE LIKE '81%' OR INSTYPE LIKE '82%' OR INSTYPE LIKE '83%' OR INSTYPE LIKE '91%' ) "
        End If

        If chk1.Checked = True Then
            tmpSQL2 = ""
        ElseIf chk2.Checked = True Then
            tmpSQL2 = " AND LOCATION = '1' "
        ElseIf chk3.Checked = True Then
            tmpSQL2 = " AND LOCATION = '2' "
        End If

        If chk4.Checked = True Then
            tmpSQL5 = ""
        ElseIf chk5.Checked = True Then
            tmpSQL5 = " AND INTIME = '1' "
        ElseIf chk6.Checked = True Then
            tmpSQL5 = " AND INTIME = '2' "
        End If

        If CheckBox1.Checked = True Then
            tmpSQL3 = " AND C.PROVIDER = '" & cboProvider.EditValue & "'"
        Else
            tmpSQL3 = ""
        End If


        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("A.PID,A.ROWID,B.HN,CID,PRENAME,NAME,LNAME,BIRTH,A.DATE_SERV,A.SEQ,CHIEFCOMP,A.COST,A.PRICE,A.PAYPRICE,INSID,INSTYPE,SUBINSTYPE,MAIN,PROCEDCODE,DESC_THA,PROVIDER,SUBSTR(A.D_UPDATE,1,8) AS D_UPDATE,SERVPLACE", "m_service A JOIN m_person B ON(A.PID = B.PID) JOIN m_procedure_opd C ON(A.SEQ = C.SEQ) LEFT JOIN l_icd9 D ON(PROCEDCODE = CODE)  ", "WHERE PROCEDCODE = '" & tmpProcedCode2 & "' AND (A.STATUS_AF <> '8' AND C.STATUS_AF <> '8') AND (A.DATE_SERV >= " & DateStart & " AND A.DATE_SERV <= " & DateEnd & ")  " & tmpSQL & tmpSQL2 & tmpSQL3 & tmpSQL4 & tmpSQL5 & "  ORDER BY A.DATE_SERV,CID ")
        If ds.Tables(0).Rows.Count > 0 Then
            DisplayData2(ds)
            Label17.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0").ToString & " รายการ"
            cmdPrintReport2.Enabled = True
        Else
            BetterListView2.Items.Clear()
            Label17.Text = "จำนวน 0 รายการ"
            cmdPrintReport2.Enabled = False
        End If
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
                dsRpt2.Tables.Clear()
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
                        BetterListView2.Items(i).SubItems.Add((dr("CID")))
                        tmpCID = (dr("CID"))
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
                    BetterListView2.Items(i).SubItems.Add(tmpPrename & (dr("NAME")) & " " & (dr("LNAME")))
                    tmpName = tmpPrename & (dr("NAME")) & " " & (dr("LNAME"))
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
                    ds3 = clsdataBus.Lc_Business.SELECT_TABLE("PROCEDCODE,DESC_THA", "m_procedure_opd A JOIN l_icd9 B ON(A.PROCEDCODE = B.CODE) ", "WHERE STATUS_AF <> '8' AND SEQ = '" & dr("SEQ") & "'")
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
                    BetterListView2.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("PROVIDER")) Then
                    BetterListView2.Items(i).SubItems.Add(ClsBusiness.Lc_Business.SELECT_NAME_PROVIDER(dr("PROVIDER")))
                Else
                    BetterListView2.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("INSTYPE")) Then
                    BetterListView2.Items(i).SubItems.Add(ClsBusiness.Lc_Business.SELECT_NAME_INSTYPE_NEW(dr("INSTYPE")))
                Else
                    BetterListView2.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("MAIN")) Then
                    BetterListView2.Items(i).SubItems.Add(ClsBusiness.Lc_Business.SELECT_NAME_HOSPITAL(dr("MAIN")))
                Else
                    BetterListView2.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("D_UPDATE")) Then
                    BetterListView2.Items(i).SubItems.Add(DateTime.ParseExact(dr("D_UPDATE").ToString.Substring(0, 4) + 543 & dr("D_UPDATE").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy"))
                Else
                    BetterListView2.Items(i).SubItems.Add("")
                End If

                If (i Mod 2) = 0 Then
                    BetterListView2.Items(i).BackColor = Color.WhiteSmoke
                End If

                drRpt("FIELD1") = ClsBusiness.Lc_Business.SELECT_NAME_HCODE(vHcode).ToString.Replace("รพ.สต.", "โรงพยาบาลส่งเสริมสุขภาพตำบล") & vbCrLf & "ข้อมูลการให้บริการตั้งแต่วันที่ " & DateStart & " ถึงวันที่ " & DateEnd
                drRpt("FIELD2") = tmpOrder
                drRpt("FIELD3") = DateTime.ParseExact(dr("DATE_SERV").ToString.Substring(0, 4) + 543 & dr("DATE_SERV").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy")
                drRpt("FIELD4") = dr("HN")
                tmpPID = dr("HN")
                If IsDBNull(dr("BIRTH")) Then
                    tmpAge = "ไม่มีข้อมูล"

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

                        Else

                            tmpAge = ""
                        End If
                    Else
                        tmpAge = "ไม่มีข้อมูล"

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
            dsRpt2.Tables.Add(dt)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error003", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub cmdPrintReport2_Click(sender As Object, e As EventArgs) Handles cmdPrintReport2.Click
        Dim fReport As New frmReportView
        Dim params As ReportParameter
        params = New ReportParameter("RateId")
        fReport.ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\Reports\rptServiceReport.rdlc"
        fReport.ReportViewer1.LocalReport.DataSources.Clear()
        CurrentReportDataSource.Name = "DataSet20F"
        CurrentReportDataSource.value = dsRpt2.Tables(0)
        fReport.ReportViewer1.LocalReport.DataSources.Add(CurrentReportDataSource)

        fReport.ShowDialog()

    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        Dim fReport As New frmReportView
        Dim params As ReportParameter
        params = New ReportParameter("RateId")
        fReport.ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\Reports\rptThaimedSelect.rdlc"
        fReport.ReportViewer1.LocalReport.DataSources.Clear()
        CurrentReportDataSource.Name = "DataSet1"
        CurrentReportDataSource.value = dsRpt.Tables(0)
        fReport.ReportViewer1.LocalReport.DataSources.Add(CurrentReportDataSource)

        fReport.ShowDialog()

    End Sub


End Class