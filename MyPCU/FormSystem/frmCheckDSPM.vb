Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Imports Microsoft.Reporting.WinForms
Imports System.Globalization

Public Class frmCheckDSPM
    Dim dsRpt As New DataSet
    Dim dsRpt2 As New DataSet
    Dim dsRpt3 As New DataSet
    Dim CurrentReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
    Private Sub frmCheckDSPM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 30
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "PID"
            .Columns(1).Width = 100
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "HN"
            .Columns(2).Width = 0
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "CID"
            .Columns(3).Width = 120
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "ชื่อ-นามสกุล"
            .Columns(4).Width = 150
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "เพศ"
            .Columns(5).Width = 60
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "วันเดือนปีเกิด"
            .Columns(6).Width = 120
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "อายุ"
            .Columns(7).Width = 150
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "อายุเดือน"
            .Columns(8).Width = 100
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        Timer1.Enabled = True
       
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 100
        Timer1.Enabled = False
        SplashScreenManager1.ShowWaitForm()

        ShowData()


        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub ShowData()
        Dim ds As DataSet

        ds = clsdataBus.Lc_Business.SELECT_TABLE(" * ", " m_person ", " WHERE TYPEAREA IN('1','3') AND DISCHARGE = '9' AND STATUS_AF <> '8' AND TIMESTAMPDIFF( MONTH, BIRTH, NOW()) IN(9,18,30,42,60) " _
                                                 & " AND PID NOT IN(SELECT a.PID FROM m_person a JOIN m_specialpp b ON(a.PID = b.PID) WHERE TIMESTAMPDIFF( MONTH, BIRTH, DATE_SERV) = TIMESTAMPDIFF( MONTH, BIRTH, NOW())  AND (PPSPECIAL LIKE '1B20%' OR PPSPECIAL LIKE '1B21%' OR PPSPECIAL LIKE '1B22%' OR PPSPECIAL LIKE '1B23%' OR PPSPECIAL LIKE '1B24%')) ORDER BY BIRTH DESC ")
        If ds.Tables(0).Rows.Count > 0 Then
            DisplayData2(ds)
            Label3.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0") & " คน"
        Else
            BetterListView1.Items.Clear()
            Label3.Text = "จำนวน 0 คน"
        End If
    End Sub
    Private Sub DisplayData2(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itm As ListViewItem
        Dim NAMEUSER As String = ""
        Dim tmpPrename As String = ""
        Dim tmpMonth As Integer = 0
        Dim tmpROWID As String = ""
        Dim tmpBirth As String = ""
        Dim tmpAGE As String = ""
        Dim tmpNow As DateTime = DateTime.ParseExact(clsdataBus.Lc_Business.MySQL_Sysdate(), "yyyyMMddHHmmss", CultureInfo.CurrentCulture)
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
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dsRpt.Tables.Clear()
                drRpt = dt.NewRow()

                dr = ds.Tables(0).Rows(i)

                If dr("SEX").ToString = "1" Then
                    BetterListView1.Items.Add(ImageList1.Images.Item(0)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                Else
                    BetterListView1.Items.Add(ImageList1.Images.Item(1)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                End If

                BetterListView1.Items(i).SubItems.Add(dr("PID").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("HN").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add((dr("CID").ToString)).AlignHorizontal = TextAlignmentHorizontal.Center
                If Not IsDBNull(dr("PRENAME")) Then
                    tmpPrename = clsdataBus.Lc_Business.SELECT_NAME_PRENAME(dr("PRENAME").ToString)
                End If
                Try
                    BetterListView1.Items(i).SubItems.Add(tmpPrename & ((dr("NAME").ToString)) & " " & ((dr("LNAME").ToString))).AlignHorizontal = TextAlignmentHorizontal.Left
                Catch ex As Exception
                    BetterListView1.Items(i).SubItems.Add("มีข้อผิดพลาด!!!").AlignHorizontal = TextAlignmentHorizontal.Center
                End Try

                If dr("SEX").ToString = "1" Then
                    BetterListView1.Items(i).SubItems.Add("ชาย").AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("หญิง").AlignHorizontal = TextAlignmentHorizontal.Center
                End If
                If IsDBNull(dr("BIRTH")) Then
                    BetterListView1.Items(i).SubItems.Add("ไม่มีข้อมูล")
                    BetterListView1.Items(i).SubItems.Add("")
                Else
                    If dr("BIRTH").ToString <> "" Then
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
                                tmpMonth = (Years * 12) + Month
                                StrAge = ((Years.ToString() & " ปี ") + Month.ToString() & " เดือน ") + Days.ToString() & " วัน "
                                tmpAGE = tmpMonth
                            Else
                                StrAge = "วันเดือนปีเกิดไม่ถูกต้อง"
                            End If
                            BetterListView1.Items(i).SubItems.Add(DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy")).AlignHorizontal = TextAlignmentHorizontal.Center
                            tmpBirth = DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy")
                            BetterListView1.Items(i).SubItems.Add(StrAge).AlignHorizontal = TextAlignmentHorizontal.Center
                            BetterListView1.Items(i).SubItems.Add(tmpMonth.ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                        Else
                            BetterListView1.Items(i).SubItems.Add("")
                            BetterListView1.Items(i).SubItems.Add("")
                            BetterListView1.Items(i).SubItems.Add("")
                        End If
                    Else
                        BetterListView1.Items(i).SubItems.Add("ไม่มีข้อมูล")
                        BetterListView1.Items(i).SubItems.Add("")
                        BetterListView1.Items(i).SubItems.Add("")
                    End If

                End If

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If


                drRpt("FIELD1") = "ตารางแสดงรายชื่อเด็กที่ต้องคัดกรอง DSPM"

                drRpt("FIELD2") = "หน่วยบริการ : " & vHname.Replace("รพ.สต.", "โรงพยาบาลส่งเสริมสุขภาพตำบล")
                drRpt("FIELD3") = dr("PID")
                drRpt("FIELD4") = dr("HN")
                drRpt("FIELD5") = (dr("CID").ToString)
                drRpt("FIELD6") = tmpPrename & (dr("NAME")) & " " & ((dr("LNAME").ToString))
                drRpt("FIELD7") = tmpAGE
                drRpt("FIELD8") = ClsBusiness.Lc_Business.SELECT_NAME_ADDRESS_PID(dr("PID").ToString)
                drRpt("FIELD10") = tmpBirth
                dt.Rows.Add(drRpt)
            Next
            BetterListView1.EndUpdate()

            BetterListView1.AutoResizeColumn(4, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(6, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(7, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)

            dsRpt.Tables.Add(dt)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try


    End Sub

    Private Sub cmdPrintReport1_Click(sender As Object, e As EventArgs) Handles cmdPrintReport1.Click
        Dim fReport As New frmReportView
        Dim params As ReportParameter

        params = New ReportParameter("RateId")

        fReport.ReportViewer1.LocalReport.ReportPath = Application.StartupPath & "\Reports\rptPersonDspmName.rdlc"

        fReport.ReportViewer1.LocalReport.DataSources.Clear()
        CurrentReportDataSource.Name = "DataSet20F"
        CurrentReportDataSource.value = dsRpt.Tables(0)
        fReport.ReportViewer1.LocalReport.DataSources.Add(CurrentReportDataSource)
        fReport.ShowDialog()

    End Sub
End Class