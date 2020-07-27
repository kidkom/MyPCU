Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Globalization
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Imports DevExpress.XtraCharts
Imports Microsoft.Reporting.WinForms
Public Class frmPerson_TypeArea
    Dim tmpPROVINCE As String = ""
    Dim tmpAMPUR As String = ""
    Dim tmpTAMBON As String = ""
    Dim tmpMOO As String = ""
    Dim dsRpt As New DataSet
    Dim dsRpt2 As New DataSet
    Dim tmpAll As Integer = 0
    Dim CurrentReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
    Private Sub frmPerson_TypeArea_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkAddress.Enabled = False

        With BetterListView1
            .Columns.Add(0).Text = "ประเภท"
            .Columns(0).Width = 80
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "สถานะการอยู่อาศัย"
            .Columns(1).Width = 100
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "จำนวน"
            .Columns(2).Width = 80
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "ร้อยละ"
            .Columns(3).Width = 80
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        With BetterListView2
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 30
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "PID"
            .Columns(1).Width = 100
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "HN"
            .Columns(2).Width = 100
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "CID"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "ชื่อ-นามสกุล"
            .Columns(4).Width = 100
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "เพศ"
            .Columns(5).Width = 100
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "วันเดือนปีเกิด"
            .Columns(6).Width = 100
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "อายุ"
            .Columns(7).Width = 100
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "ที่อยู่"
            .Columns(8).Width = 100
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(9).Text = "สถานะสมรส"
            .Columns(9).Width = 100
            .Columns(9).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(10).Text = "เชื้อชาติ"
            .Columns(10).Width = 100
            .Columns(10).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(11).Text = "สัญชาติ"
            .Columns(11).Width = 100
            .Columns(11).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(12).Text = "ศาสนา"
            .Columns(12).Width = 100
            .Columns(12).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(13).Text = "สถานะ"
            .Columns(13).Width = 100
            .Columns(13).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(14).Text = "สถานะบุคคล"
            .Columns(14).Width = 100
            .Columns(14).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(15).Text = "สถานะในบ้าน"
            .Columns(15).Width = 100
            .Columns(15).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub
    Private Sub TypeAreaCbo()
        Dim ds As DataSet
        ds = ClsBusiness.Lc_Business.SELECT_TABLE("TYPEAREA_CODE", " l_typearea", "")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboTypeArea
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "TYPEAREA_CODE"
                .Properties.ValueMember = "TYPEAREA_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Width = 79
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
    End Sub
    Private Sub SexAction()
        Dim ds As DataSet
        ds = ClsBusiness.Lc_Business.SELECT_TABLE("SEX, SEX_CODE", " l_sex", " WHERE STATUS_AF = '1' ")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboSex
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "SEX"
                .Properties.ValueMember = "SEX_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
    End Sub
    Private Sub DischargeAction()
        Dim ds As DataSet
        ds = ClsBusiness.Lc_Business.SELECT_TABLE("DISCHARGE_DESC, DISCHARGE_CODE", " l_discharge", "  ")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboDischarge
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "DISCHARGE_DESC"
                .Properties.ValueMember = "DISCHARGE_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
    End Sub
    Private Sub ProcessTyparea()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("a.TYPEAREA,b.TYPEAREA_DESC,COUNT(*) AS C_COUNT,(COUNT(*)/(SELECT COUNT(*) FROM m_person WHERE STATUS_AF <> '8'))*100 AS C_PERCENT" _
                                                 , " m_person a JOIN l_typearea b ON(a.TYPEAREA = b.TYPEAREA_CODE) ", " WHERE STATUS_AF <> '8' GROUP BY a.TYPEAREA ")
        If ds.Tables(0).Rows.Count > 0 Then
            DisplayData(ds)
        Else
            BetterListView1.Items.Clear()
        End If
    End Sub
    Private Sub DisplayData(ByVal ds As DataSet)
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
        dt.Columns.Add(Coulumn1)
        dt.Columns.Add(Coulumn2)
        dt.Columns.Add(Coulumn3)
        dt.Columns.Add(Coulumn4)
        dt.Columns.Add(Coulumn5)

        Try
            ChartControl1.Series("Series 1").Points.Clear()
            ChartControl1.SeriesDataMember = String.Empty
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                BetterListView1.Items.Add(dr("TYPEAREA").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("TYPEAREA_DESC").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left

                BetterListView1.Items(i).SubItems.Add(CDbl(dr("C_COUNT")).ToString("#,##0")).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right
                BetterListView1.Items(i).SubItems.Add(CDbl(dr("C_PERCENT")).ToString("#,##0.00")).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                ChartControl1.Series("Series 1").Points.Add(New SeriesPoint("TYPEAREA " & dr("TYPEAREA"), CInt(dr("C_COUNT")).ToString("#,##0")))
                ChartControl1.Series("Series 1").Label.TextPattern = "{A}: {VP:P0}"


                dsRpt2.Tables.Clear()
                drRpt = dt.NewRow()


                drRpt("FIELD1") = "รายกงานประชากรจำแนกตามประเภทการอยู่อาศัย"
                drRpt("FIELD2") = "หน่วยบริการ : " & ClsBusiness.Lc_Business.SELECT_NAME_HCODE(vHcode).Replace("รพ.สต.", "โรงพยาบาลส่งเสริมสุขภาพตำบล")
                drRpt("FIELD3") = dr("TYPEAREA")
                drRpt("FIELD4") = dr("C_COUNT")
                drRpt("FIELD5") = dr("C_PERCENT")
                dt.Rows.Add(drRpt)

            Next
            dsRpt2.Tables.Add(dt)
            BetterListView1.AutoResizeColumn(1, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)

            BetterListView1.ResumeSort(True)
            BetterListView1.EndUpdate()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub cmdPrint1_Click(sender As Object, e As EventArgs) Handles cmdPrint1.Click

        Dim fReport As New frmReportView
        Dim params As ReportParameter

        params = New ReportParameter("RateId")

        fReport.ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\Reports\rptPopTypeArea.rdlc"

        fReport.ReportViewer1.LocalReport.DataSources.Clear()
        CurrentReportDataSource.Name = "DataSet20F"
        CurrentReportDataSource.value = dsRpt2.Tables(0)
        fReport.ReportViewer1.LocalReport.DataSources.Add(CurrentReportDataSource)

        fReport.ShowDialog()
    End Sub

    Private Sub cmdProcess_Click(sender As Object, e As EventArgs) Handles cmdProcess.Click
        Dim ds As DataSet
        Dim tmpTypeArea As String = ""
        Dim tmpSEX As String = ""
        Dim tmpDischarge As String = ""
        Dim tmpAddress As String = ""
        Select Case cboTypeArea.EditValue
            Case 1
                tmpTypeArea = " WHERE TYPEAREA = '1' "
            Case 2
                tmpTypeArea = " WHERE TYPEAREA = '2' "
            Case 3
                tmpTypeArea = " WHERE TYPEAREA = '3' "
            Case 4
                tmpTypeArea = " WHERE TYPEAREA = '4' "
            Case 5
                tmpTypeArea = " WHERE TYPEAREA = '5' "
            Case Else
                tmpTypeArea = ""
        End Select
        Select Case cboSex.EditValue
            Case 1
                tmpSEX = " AND A.SEX = '1' "
            Case 2
                tmpSEX = " AND A.SEX = '2' "
            Case Else
                tmpSEX = ""
        End Select
        Select Case cboDischarge.EditValue
            Case 1
                tmpDischarge = " AND DISCHARGE = '1' "
            Case 2
                tmpDischarge = " AND DISCHARGE = '2' "
            Case 3
                tmpDischarge = " AND DISCHARGE = '3' "
            Case 4
                tmpDischarge = " AND DISCHARGE = '9' "
            Case Else
                tmpDischarge = " "
        End Select
        If chkAddress.Checked = True Then
            If tmpPROVINCE <> "" Then
                tmpAddress = " AND C.CHANGWAT = '" & cboCHANGWAT.EditValue & "'"
            End If
            If tmpAMPUR <> "" Then
                tmpAddress = tmpAddress & " AND C.AMPUR = '" & cboAMPHUR.EditValue & "'"
            End If
            If tmpTAMBON <> "" Then
                tmpAddress = tmpAddress & " AND C.TAMBON = '" & cboTambon.EditValue & "'"
            End If
            If tmpMOO <> "" Then
                tmpAddress = tmpAddress & " AND C.VILLAGE = '" & cboMoo.EditValue & "'"
            End If
        Else
            tmpAddress = ""
        End If
        SplashScreenManager1.ShowWaitForm()

        'If chkAddress.Checked = True Then
        ds = clsdataBus.Lc_Business.SELECT_TABLE("A.PID,B.ROWID,HN,CID,IFNULL(PRENAME_DESC,'') AS PRENAME_DESC,NAME,LNAME,BIRTH,A.SEX,IFNULL(MSTATUS_DESC,'') AS MSTATUS_DESC," _
                    & "IFNULL(na.NATION_DESC,'') AS NATION_DESC,IFNULL(ra.NATION_DESC,'') AS RACE_DESC,IFNULL(RELIGION_DESC,'') AS RELIGION_DESC,DISCHARGE_DESC," _
                    & "TYPEAREA,B.HOUSE,B.VILLAGE,B.CHANGWAT,B.AMPUR,B.TAMBON,FSTATUS,C.HOUSENO,C.VILLAGE,C.CHANGWAT,C.AMPUR,C.TAMBON,A.USER_REC,A.STATUS_AF, " _
                    & "IFNULL(D.PROVINCE_NAME,'') AS PROVINCE_NAME,IFNULL(D.AMPHUR_NAME,'') AS AMPHUR_NAME,IFNULL(D.TAMBOL_NAME,'') AS TAMBOL_NAME," _
                    & "IFNULL(h.PROVINCE_NAME,'') AS PROVINCE_NAME1,IFNULL(h.AMPHUR_NAME,'') AS AMPHUR_NAME1,IFNULL(h.TAMBOL_NAME,'') AS TAMBOL_NAME1" _
                    , "m_person A LEFT JOIN m_home B ON(A.HID = B.HID) LEFT JOIN m_address C ON(A.PID = C.PID) " _
                    & "LEFT JOIN l_cat D ON(C.CHANGWAT = D.PROVINCE_ID  AND C.AMPUR = D.AMPHUR_ID And C.TAMBON = D.TAMBOL_ID) " _
                    & "LEFT JOIN l_cat h ON(B.CHANGWAT = h.PROVINCE_ID  AND B.AMPUR = h.AMPHUR_ID  AND B.TAMBON = h.TAMBOL_ID) " _
                    & "LEFT JOIN l_mypcu_prename pn ON(A.PRENAME_HOS = pn.PRENAME_CODE) " _
                    & "LEFT JOIN l_mypcu_mstatus ms On(A.MSTATUS_HOS = ms.MSTATUS_CODE) " _
                    & "LEFT JOIN l_mypcu_nation na ON(A.NATION_HOS = na.NATION_CODE) " _
                    & "LEFT JOIN l_mypcu_nation ra On(A.RACE_HOS = ra.NATION_CODE) " _
                    & "LEFT JOIN l_mypcu_religion rg ON(A.RELIGION_HOS = rg.RELIGION_CODE) " _
                    & "LEFT JOIN l_discharge dc On(A.DISCHARGE = dc.DISCHARGE_CODE) " _
                    , "" & tmpTypeArea & tmpSEX & tmpDischarge & tmpAddress & " AND A.STATUS_AF <> '8' GROUP BY A.PID ORDER BY TYPEAREA,B.CHANGWAT,B.AMPUR,B.TAMBON,B.VILLAGE,B.HOUSE+0,C.CHANGWAT,C.AMPUR,C.TAMBON,C.VILLAGE,C.HOUSENO+0 ")

        'Else
        'ds = clsdataBus.Lc_Business.SELECT_TABLE("A.PID,B.ROWID,HN,CID,PRENAME,NAME,LNAME,BIRTH,SEX,MSTATUS,NATION,RACE,RELIGION,DISCHARGE,TYPEAREA,B.HOUSE,B.VILLAGE,B.CHANGWAT,B.AMPUR,B.TAMBON,FSTATUS,C.HOUSENO,C.VILLAGE,C.CHANGWAT,C.AMPUR,C.TAMBON,A.USER_REC,A.STATUS_AF", "m_person A LEFT JOIN m_home B ON(A.HID = B.HID) LEFT JOIN m_address C ON(A.PID = C.PID) ", "" & tmpTypeArea & tmpSEX & tmpDischarge & tmpAddress & " AND A.STATUS_AF <> '8' GROUP BY A.PID ORDER BY TYPEAREA,B.CHANGWAT,B.AMPUR,B.TAMBON,B.VILLAGE,B.HOUSE+0,C.CHANGWAT,C.AMPUR,C.TAMBON,C.VILLAGE,C.HOUSENO+0 ")

        'End If

        If ds.Tables(0).Rows.Count > 0 Then
            DisplayData2(ds)
            Label17.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0").ToString & " รายการ"
            cmdPrintReport2.Enabled = True
        Else
            BetterListView2.Items.Clear()
            Label17.Text = "จำนวน 0 รายการ"
            cmdPrintReport2.Enabled = False
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub DisplayData2(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itm As ListViewItem
        Dim NAMEUSER As String = ""
        Dim tmpPrename As String = ""
        Dim tmpProvider As String = ""
        Dim tmpNow As DateTime = DateTime.ParseExact(clsdataBus.Lc_Business.MySQL_Sysdate(), "yyyyMMddHHmmss", CultureInfo.CurrentCulture)
        Dim tmpBirth As String = ""
        Dim tmpPID As String = ""
        Dim tmpCID As String = ""
        Dim tmpHouse As String = ""
        Dim tmpAGE As String = ""
        Dim tmpName As String = ""

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


        Try
            BetterListView2.Items.Clear()
            BetterListView2.BeginUpdate()
            BetterListView2.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                dsRpt.Tables.Clear()
                drRpt = dt.NewRow()

                If dr("SEX") = "1" Then
                    BetterListView2.Items.Add(ImageList1.Images.Item(0)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                Else
                    BetterListView2.Items.Add(ImageList1.Images.Item(1)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                End If

                If Not IsDBNull(dr("PID")) Then
                    BetterListView2.Items(i).SubItems.Add(dr("PID").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    BetterListView2.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("HN")) Then
                    BetterListView2.Items(i).SubItems.Add(dr("HN").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    BetterListView2.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("CID")) Then
                    Try
                        BetterListView2.Items(i).SubItems.Add(dr("CID").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                        tmpCID = (dr("CID"))
                    Catch ex As Exception
                        BetterListView2.Items(i).SubItems.Add("ข้อมูลผิดพลาด")
                        tmpCID = ""
                    End Try
                Else
                    BetterListView2.Items(i).SubItems.Add("")
                End If

                tmpPrename = dr("PRENAME_DESC")

                Try
                    tmpName = tmpPrename & ((dr("NAME"))) & " " & ((dr("LNAME")))
                    BetterListView2.Items(i).SubItems.Add(tmpName).AlignHorizontal = TextAlignmentHorizontal.Left

                Catch ex As Exception
                    BetterListView2.Items(i).SubItems.Add("ข้อมูลผิดพลาด")
                    tmpName = ""
                End Try

                If dr("SEX") = "1" Then
                    BetterListView2.Items(i).SubItems.Add("ชาย").AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    BetterListView2.Items(i).SubItems.Add("หญิง").AlignHorizontal = TextAlignmentHorizontal.Center
                End If

                If IsDBNull(dr("BIRTH")) Then
                    BetterListView2.Items(i).SubItems.Add("")
                Else
                    Dim tmpDOB = dr("BIRTH").ToString.Substring(0, 4) + 543 & dr("BIRTH").ToString.Substring(4, 4)
                    If CheckDate(DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("dd/MM/yyyy")) = True Then

                        Dim DOB As DateTime = DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture)
                        Dim Years As Integer = 0
                        Dim Month As Integer = 0
                        Dim Days As Integer = 0
                        Dim StrAge As String = Nothing
                        If DOB < DateTime.Now Then
                            Dim dateDiff As TimeSpan = DateTime.Now - DOB
                            Dim age As New DateTime(dateDiff.Ticks)
                            Years = age.Year - 1
                            Month = age.Month - 1
                            Days = age.Day - 1
                            StrAge = ((Years.ToString() & " ปี ") + Month.ToString() & " เดือน ") + Days.ToString() & " วัน "
                        Else
                            StrAge = "วันเดือนปีเกิดไม่ถูกต้อง"

                        End If
                        BetterListView2.Items(i).SubItems.Add(DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy")).AlignHorizontal = TextAlignmentHorizontal.Center
                        tmpBirth = DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy")
                        BetterListView2.Items(i).SubItems.Add(StrAge).AlignHorizontal = TextAlignmentHorizontal.Center
                        tmpAGE = ((Years.ToString() & "/") + Month.ToString() & "/") + Days.ToString()
                    Else
                        BetterListView2.Items(i).SubItems.Add("")
                        BetterListView2.Items(i).SubItems.Add("")
                        tmpAGE = ""
                        tmpBirth = ""
                    End If
                End If

                If chkAddress.Checked = True Then
                    If dr("TYPEAREA") = "4" Then
                        Dim tmpHouseNo As String = ""
                        Dim tmpVillage As String = ""
                        Dim tmpAddress As String = ""
                        If Not IsDBNull(dr("HOUSENO")) Then
                            tmpHouseNo = dr("HOUSENO")
                        Else
                            tmpHouseNo = ""
                        End If
                        If Not IsDBNull(dr("VILLAGE1")) Then
                            tmpVillage = " หมู่ " & CInt(dr("VILLAGE1")).ToString("0")
                        Else
                            tmpVillage = ""
                        End If
                        If Not IsDBNull(dr("TAMBON1")) And Not IsDBNull(dr("AMPUR1")) And Not IsDBNull(dr("CHANGWAT1")) Then
                            tmpAddress = " ต. " & dr("TAMBOL_NAME") & " อ. " & dr("AMPHUR_NAME") & " จ. " & dr("PROVINCE_NAME")
                        End If
                        tmpHouse = tmpHouseNo & tmpVillage & tmpAddress
                        BetterListView2.Items(i).SubItems.Add(tmpHouse).AlignHorizontal = TextAlignmentHorizontal.Left
                    End If
                Else
                    If Not IsDBNull(dr("HOUSE")) Then
                        tmpHouse = dr("HOUSE") & " หมู่ " & CInt(dr("VILLAGE")).ToString("0") & " ต. " & dr("TAMBOL_NAME1")
                        BetterListView2.Items(i).SubItems.Add(tmpHouse).AlignHorizontal = TextAlignmentHorizontal.Left
                    Else
                        tmpHouse = ""
                        BetterListView2.Items(i).SubItems.Add(tmpHouse).AlignHorizontal = TextAlignmentHorizontal.Left
                    End If
                End If


                If Not IsDBNull(dr("MSTATUS_DESC")) Then

                    BetterListView2.Items(i).SubItems.Add(dr("MSTATUS_DESC").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    BetterListView2.Items(i).SubItems.Add("-")
                End If
                If Not IsDBNull(dr("RACE_DESC")) Then
                    BetterListView2.Items(i).SubItems.Add(dr("RACE_DESC").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    BetterListView2.Items(i).SubItems.Add("-")
                End If
                If Not IsDBNull(dr("NATION_DESC")) Then
                    BetterListView2.Items(i).SubItems.Add(dr("NATION_DESC").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    BetterListView2.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("RELIGION_DESC")) Then
                    BetterListView2.Items(i).SubItems.Add(dr("RELIGION_DESC").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    BetterListView2.Items(i).SubItems.Add("-")
                End If
                If Not IsDBNull(dr("DISCHARGE_DESC")) Then
                    BetterListView2.Items(i).SubItems.Add(dr("DISCHARGE_DESC").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    BetterListView2.Items(i).SubItems.Add("-")
                End If
                If Not IsDBNull(dr("TYPEAREA")) Then
                    BetterListView2.Items(i).SubItems.Add(dr("TYPEAREA").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    BetterListView2.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("FSTATUS")) Then
                    If dr("FSTATUS") = "1" Then
                        BetterListView2.Items(i).SubItems.Add("เจ้าบ้าน").AlignHorizontal = TextAlignmentHorizontal.Center
                    ElseIf dr("FSTATUS") = "2" Then
                        BetterListView2.Items(i).SubItems.Add("ผู้อาศัย").AlignHorizontal = TextAlignmentHorizontal.Center
                    Else
                        BetterListView2.Items(i).SubItems.Add("")
                    End If
                Else
                    BetterListView2.Items(i).SubItems.Add("")
                End If

                If (i Mod 2) = 0 Then
                    BetterListView2.Items(i).BackColor = Color.WhiteSmoke
                End If

                If dr("STATUS_AF").ToString = "0" Then
                    BetterListView2.Items(i).BackColor = Color.LightPink
                End If


                drRpt("FIELD1") = "ตารางแสดงรายชื่อประชากร"
                drRpt("FIELD2") = "หน่วยบริการ : " & vHname.Replace("รพ.สต.", "โรงพยาบาลส่งเสริมสุขภาพตำบล")
                drRpt("FIELD3") = tmpPID
                drRpt("FIELD4") = dr("HN")
                drRpt("FIELD5") = tmpCID
                drRpt("FIELD6") = tmpName
                drRpt("FIELD7") = tmpAGE
                drRpt("FIELD8") = tmpHouse
                drRpt("FIELD9") = dr("NATION_DESC")
                drRpt("FIELD10") = tmpBirth
                dt.Rows.Add(drRpt)
            Next

            dsRpt.Tables.Add(dt)
            BetterListView2.AutoResizeColumn(1, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView2.AutoResizeColumn(2, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView2.AutoResizeColumn(3, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView2.AutoResizeColumn(4, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView2.AutoResizeColumn(6, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView2.AutoResizeColumn(7, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView2.AutoResizeColumn(8, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)

            BetterListView2.ResumeSort(True)
            BetterListView2.EndUpdate()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub cboTypeArea_EditValueChanged(sender As Object, e As EventArgs) Handles cboTypeArea.EditValueChanged
        If cboTypeArea.EditValue = 4 Then
            chkAddress.Enabled = True
        Else
            chkAddress.Checked = False
            chkAddress.Enabled = False
            cboCHANGWAT.Enabled = False
            cboAMPHUR.Enabled = False
            cboTambon.Enabled = False
            cboMoo.Enabled = False
            tmpPROVINCE = ""
            tmpAMPUR = ""
            tmpTAMBON = ""
            tmpMOO = ""
        End If
    End Sub
    Private Sub chkAddress_Click(sender As Object, e As EventArgs) Handles chkAddress.Click

        If chkAddress.Checked = True Then
            chkAddress.Checked = True
            chkAddress.Enabled = True
            cboCHANGWAT.Enabled = True
            SplashScreenManager1.ShowWaitForm()
            Dim ds As DataSet
            ds = clsdataBus.Lc_Business.SELECT_TABLE("PROVINCE_ID,PROVINCE_NAME ", "m_address A JOIN l_catm B ON(A.CHANGWAT = B.PROVINCE_ID)", "GROUP BY PROVINCE_NAME ")
            If ds.Tables(0).Rows.Count > 0 Then
                With cboCHANGWAT
                    .Properties.DataSource = ds.Tables(0)
                    .Properties.DisplayMember = "PROVINCE_NAME"
                    .Properties.ValueMember = "PROVINCE_ID"
                    .Properties.ForceInitialize()
                    .Properties.PopulateColumns()
                    .Properties.Columns(0).Visible = False
                    .Properties.ShowHeader = False
                    .Properties.NullText = ""
                End With
            End If
            SplashScreenManager1.CloseWaitForm()
        End If
    End Sub

    Private Sub cboCHANGWAT_EditValueChanged(sender As Object, e As EventArgs) Handles cboCHANGWAT.EditValueChanged
        cboAMPHUR.Enabled = True
        tmpAMPUR = ""
        tmpTAMBON = ""
        tmpMOO = ""
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("AMPHUR_ID,AMPHUR_NAME ", " m_address A JOIN l_catm B ON(A.CHANGWAT = B.PROVINCE_ID AND A.AMPUR = B.AMPHUR_ID)", "WHERE PROVINCE_ID = '" & cboCHANGWAT.EditValue & "'  GROUP BY AMPHUR_ID ")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboAMPHUR
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "AMPHUR_NAME"
                .Properties.ValueMember = "AMPHUR_ID"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        Else
            cboAMPHUR.Properties.DataSource = Nothing
        End If
        tmpPROVINCE = cboCHANGWAT.EditValue
    End Sub
    Private Sub cboAMPHUR_EditValueChanged(sender As Object, e As EventArgs) Handles cboAMPHUR.EditValueChanged
        cboTambon.Enabled = True
        tmpTAMBON = ""
        tmpMOO = ""
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("TAMBOL_ID,TAMBOL_NAME ", "m_address A JOIN l_cat B ON(A.CHANGWAT = B.PROVINCE_ID AND A.AMPUR = B.AMPHUR_ID AND A.TAMBON = B.TAMBOL_ID)", "WHERE PROVINCE_ID = '" & cboCHANGWAT.EditValue & "'  AND AMPHUR_ID = '" & cboAMPHUR.EditValue & "' GROUP BY TAMBOL_ID ")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboTambon
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "TAMBOL_NAME"
                .Properties.ValueMember = "TAMBOL_ID"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With

        Else
            cboTambon.Properties.DataSource = Nothing

        End If
        tmpAMPUR = cboAMPHUR.EditValue
    End Sub
    Private Sub cboTambon_EditValueChanged(sender As Object, e As EventArgs) Handles cboTambon.EditValueChanged
        cboMoo.Enabled = True
        tmpMOO = ""
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("VILLAGE", "m_address A JOIN l_cat B ON(A.CHANGWAT = B.PROVINCE_ID AND A.AMPUR = B.AMPHUR_ID AND A.TAMBON = B.TAMBOL_ID)", "WHERE PROVINCE_ID = '" & cboCHANGWAT.EditValue & "'  AND AMPHUR_ID = '" & cboAMPHUR.EditValue & "' AND TAMBON = '" & cboTambon.EditValue & "' GROUP BY VILLAGE ")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboMoo
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "VILLAGE"
                .Properties.ValueMember = "VILLAGE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With

        Else
            cboMoo.Properties.DataSource = Nothing
        End If
        tmpTAMBON = cboTambon.EditValue
    End Sub

    Private Sub cboMoo_EditValueChanged(sender As Object, e As EventArgs) Handles cboMoo.EditValueChanged
        tmpMOO = cboMoo.EditValue
    End Sub

    Private Sub cmdPrintReport2_Click(sender As Object, e As EventArgs) Handles cmdPrintReport2.Click
        Dim fReport As New frmReportView
        Dim params As ReportParameter

        params = New ReportParameter("RateId")

        fReport.ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\Reports\rptPersonTypeName.rdlc"
        fReport.ReportViewer1.LocalReport.DataSources.Clear()
        CurrentReportDataSource.Name = "DataSet20F"
        CurrentReportDataSource.value = dsRpt.Tables(0)
        fReport.ReportViewer1.LocalReport.DataSources.Add(CurrentReportDataSource)
        fReport.ShowDialog()

    End Sub
End Class