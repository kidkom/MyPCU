Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Globalization
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Imports DevExpress.XtraCharts
Imports Microsoft.Reporting.WinForms
Public Class frmSearchPersonBirth
    Dim dsRpt As New DataSet
    Dim dsRpt2 As New DataSet
    Dim dsRpt3 As New DataSet
    Dim CurrentReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()

    Private Sub frmSearchPersonBirth_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpDate1.EditValue = Now
        dtpDate2.EditValue = Now
        cmdPrintReport1.Enabled = False

        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 100
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
            .Columns.Add(7).Text = "สถานะสมรส"
            .Columns(7).Width = 100
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "เชื้อชาติ"
            .Columns(8).Width = 100
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(9).Text = "สัญชาติ"
            .Columns(9).Width = 100
            .Columns(9).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(10).Text = "ศาสนา"
            .Columns(10).Width = 100
            .Columns(10).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(11).Text = "สถานะ"
            .Columns(11).Width = 100
            .Columns(11).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(12).Text = "สถานะบุคคล"
            .Columns(12).Width = 100
            .Columns(12).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(13).Text = "สถานะในบ้าน"
            .Columns(13).Width = 100
            .Columns(13).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        cboVillge()
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

    Private Sub cmdNewProcess_Click(sender As Object, e As EventArgs) Handles cmdNewProcess.Click
        SplashScreenManager1.ShowWaitForm()
        Process()
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub Process()
        Dim ds As DataSet
        Dim ta1 As String = ""
        Dim ta2 As String = ""
        Dim ta3 As String = ""
        Dim ta4 As String = ""
        Dim ta5 As String = ""
        Dim tmpShow4 As String = ""
        Dim tmpSEX As String = ""

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


        Dim tmpVill2 As String = ""


        If chkVill.Checked = True Then
            tmpVill2 = " AND CONCAT(C.PROVINCE_ID,C.AMPHUR_ID,C.TAMBOL_ID,C.VILLAGE,C.VILLANAME) = '" & cboVillage.EditValue & "'"
        Else
            tmpVill2 = ""
        End If

        If chkAll.Checked = True Then
            tmpSEX = ""
        ElseIf chkMale.Checked = True Then
            tmpSEX = " AND SEX = '1'"
        ElseIf chkFemale.Checked = True Then
            tmpSEX = " AND SEX = '2'"
        End If

        Dim tmpDate1 = CDate(dtpDate1.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))
        Dim tmpDate2 = CDate(dtpDate2.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))

        ds = clsdataBus.Lc_Business.SELECT_DATA("m_person A LEFT JOIN m_home C ON(A.HID = C.HID)", "WHERE (BIRTH >= '" & tmpDate1 & "' AND BIRTH <= '" & tmpDate2 & "') " & tmpShow4 & tmpVill2 & tmpSEX & " AND A.STATUS_AF <> '8' AND DISCHARGE = '9' ORDER BY BIRTH DESC,NAME,LNAME ")
        If ds.Tables(0).Rows.Count > 0 Then
            DisplayData2(ds)
            Label3.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0") & " คน"
            cmdPrintReport1.Enabled = True
        Else
            BetterListView1.Items.Clear()
            Label3.Text = "จำนวน 0 คน"
            cmdPrintReport1.Enabled = False
        End If
    End Sub
    Private Sub DisplayData2(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itm As ListViewItem
        Dim NAMEUSER As String = ""
        Dim tmpPrename As String = ""
        Dim tmpROWID As String = ""
        Dim tmpProvider As String = ""
        Dim tmpNow As DateTime = DateTime.ParseExact(clsdataBus.Lc_Business.MySQL_Sysdate(), "yyyyMMddHHmmss", CultureInfo.CurrentCulture)
        Dim tmpName As String = ""
        Dim StrAge2 As String = ""
        Dim tmpHouse As String = ""
        Dim tmpCID As String = ""
        Dim tmpNation As String = ""
        Dim tmpBirth As String = ""
        Dim tmpMstatus As String = ""

        Dim tmpAGE As String = ""
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



        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                dsRpt.Tables.Clear()
                drRpt = dt.NewRow()


                If Not IsDBNull(dr("USER_REC")) Then
                    NAMEUSER = clsdataBus.Lc_Business.SELECT_NAME_USERID(dr("USER_REC"))
                End If

                If dr("SEX") = "1" Then
                    BetterListView1.Items.Add(ImageList1.Images.Item(0)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                Else
                    BetterListView1.Items.Add(ImageList1.Images.Item(1)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                End If

                If Not IsDBNull(dr("PID")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("PID"))
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("HN")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("HN"))
                Else
                    BetterListView1.Items(i).SubItems.Add("")
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
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("PRENAME_HOS")) Then
                    tmpPrename = clsdataBus.Lc_Business.SELECT_NAME_PRENAME(dr("PRENAME_HOS"))
                End If
                Try
                    BetterListView1.Items(i).SubItems.Add(tmpPrename & ((dr("NAME"))) & " " & ((dr("LNAME"))))
                    tmpName = tmpPrename & ((dr("NAME"))) & " " & ((dr("LNAME")))
                Catch ex As Exception
                    BetterListView1.Items(i).SubItems.Add("ข้อมูลผิดพลาด")
                    tmpName = ""
                End Try

                If dr("SEX") = "1" Then
                    BetterListView1.Items(i).SubItems.Add("ชาย")
                Else
                    BetterListView1.Items(i).SubItems.Add("หญิง")
                End If
                If IsDBNull(dr("BIRTH")) Then
                    BetterListView1.Items(i).SubItems.Add("")
                Else
                    Dim tmpDOB = dr("BIRTH").ToString.Substring(0, 4) + 543 & dr("BIRTH").ToString.Substring(4, 4)
                    If CheckDate(DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("dd/MM/yyyy")) = True Then

                        Dim DOB As DateTime = DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture)
                        Dim Years As Integer = 0
                        Dim Month As Integer = 0
                        Dim Days As Integer = 0
                        Dim StrAge As String = Nothing
                        ' Check if the DOB is less than current date
                        If DOB < DateTime.Now Then
                            ' Calculate Difference between current date and DOB
                            Dim dateDiff As TimeSpan = DateTime.Now - DOB
                            Dim age As New DateTime(dateDiff.Ticks)
                            Years = age.Year - 1
                            Month = age.Month - 1
                            Days = age.Day - 1
                            StrAge = ((Years.ToString() & " ปี ") + Month.ToString() & " เดือน ") + Days.ToString() & " วัน "
                            StrAge2 = Years.ToString
                        Else
                            StrAge = "วันเดือนปีเกิดไม่ถูกต้อง"
                            StrAge2 = "วันเดือนปีเกิดไม่ถูกต้อง"
                        End If
                        BetterListView1.Items(i).SubItems.Add(DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy"))
                        tmpBirth = DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy")
                        BetterListView1.Items(i).SubItems.Add(StrAge)
                        tmpAGE = ((Years.ToString() & "/") + Month.ToString() & "/") + Days.ToString()
                    Else
                        BetterListView1.Items(i).SubItems.Add("")
                        BetterListView1.Items(i).SubItems.Add("")
                        tmpAGE = ""
                        tmpBirth = ""
                    End If
                End If


                If Not IsDBNull(dr("MSTATUS_HOS")) Then
                    tmpMstatus = clsdataBus.Lc_Business.SELECT_NAME_MSTATUS(dr("MSTATUS_HOS"))
                    BetterListView1.Items(i).SubItems.Add(tmpMstatus)
                Else
                    BetterListView1.Items(i).SubItems.Add("-")
                End If
                If Not IsDBNull(dr("RACE")) Then
                    BetterListView1.Items(i).SubItems.Add(clsdataBus.Lc_Business.SELECT_NAME_NATION(dr("RACE")))
                Else
                    BetterListView1.Items(i).SubItems.Add("-")
                End If
                If Not IsDBNull(dr("NATION")) Then
                    BetterListView1.Items(i).SubItems.Add(clsdataBus.Lc_Business.SELECT_NAME_NATION(dr("NATION")))
                Else
                    BetterListView1.Items(i).SubItems.Add("-")
                End If
                If Not IsDBNull(dr("RELIGION")) Then
                    BetterListView1.Items(i).SubItems.Add(clsdataBus.Lc_Business.SELECT_NAME_RELIGION(dr("RELIGION")))
                Else
                    BetterListView1.Items(i).SubItems.Add("-")
                End If
                If Not IsDBNull(dr("DISCHARGE")) Then
                    BetterListView1.Items(i).SubItems.Add(clsdataBus.Lc_Business.SELECT_NAME_DISCHARGE(dr("DISCHARGE")))
                Else
                    BetterListView1.Items(i).SubItems.Add("-")
                End If
                If Not IsDBNull(dr("TYPEAREA")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("TYPEAREA"))
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("FSTATUS")) Then
                    If dr("FSTATUS") = "1" Then
                        BetterListView1.Items(i).SubItems.Add("เจ้าบ้าน")
                    ElseIf dr("FSTATUS") = "2" Then
                        BetterListView1.Items(i).SubItems.Add("ผู้อาศัย")
                    Else
                        BetterListView1.Items(i).SubItems.Add("")
                    End If
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                If dr("STATUS_AF").ToString = "0" Then
                    BetterListView1.Items(i).BackColor = Color.LightPink
                End If

                tmpROWID = dr("ROWID")

                drRpt("FIELD1") = "ตารางแสดงรายชื่อประชากรที่เกิดระหว่างวันที่ " & CDate(dtpDate1.EditValue).ToString("d MMM yyyy") & " ถึง " & CDate(dtpDate2.EditValue).ToString("d MMM yyyy")

                drRpt("FIELD2") = "หน่วยบริการ : " & vHname.Replace("รพ.สต.", "โรงพยาบาลส่งเสริมสุขภาพตำบล")
                drRpt("FIELD3") = dr("PID")
                drRpt("FIELD4") = dr("HN")
                drRpt("FIELD5") = tmpCID
                drRpt("FIELD6") = tmpName
                drRpt("FIELD7") = tmpAGE
                drRpt("FIELD8") = ClsBusiness.Lc_Business.SELECT_NAME_ADDRESS_PID(dr("PID"))
                drRpt("FIELD9") = clsdataBus.Lc_Business.SELECT_NAME_NATION(dr("NATION"))
                drRpt("FIELD10") = tmpBirth
                dt.Rows.Add(drRpt)
            Next

            dsRpt.Tables.Add(dt)
            BetterListView1.AutoResizeColumn(1, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(2, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(3, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(4, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(6, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)

            BetterListView1.ResumeSort(True)
            BetterListView1.EndUpdate()


        Catch ex As Exception
            MessageBox.Show(ex.Message & " " & tmpROWID, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
End Class