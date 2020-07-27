Imports clsDataAcc = MyPCU.ClsDataAccess8
Imports clsdataBus = MyPCU.ClsBusiness8
Imports clsbusent = MyPCU.ClsBusinessEntity8
Imports System.DateTime
Imports System.Globalization
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmManageAsset

    Private Sub frmManageAsset_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With ListView1
            .Columns.Add("ROWID", 0, HorizontalAlignment.Center)
            .Columns.Add("ลำดับ", 80, HorizontalAlignment.Center)
            .Columns.Add("เลขที่ทรัพย์สิน", 150, HorizontalAlignment.Center)
            .Columns.Add("รายการ", 400, HorizontalAlignment.Left)
            .Columns.Add("วันที่ได้รับ", 120, HorizontalAlignment.Center)
            .Columns.Add("มูลค่า", 100, HorizontalAlignment.Right)
            .Columns.Add("อายุการใช้งาน (ปี)", 120, HorizontalAlignment.Center)
            .Columns.Add("ใช้มาแล้ว", 150, HorizontalAlignment.Center)
            .Columns.Add("มูลค่าปัจจุบัน(หักค่าเสื่อม)", 150, HorizontalAlignment.Right)
        End With
        ListView1.View = View.Details
        ListView1.GridLines = True


        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 30
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ROWID"
            .Columns(1).Width = 0
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "ลำดับ"
            .Columns(2).Width = 80
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "เลขที่ทรัพย์สิน"
            .Columns(3).Width = 150
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "รายการ"
            .Columns(4).Width = 400
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "วันที่ได้รับ"
            .Columns(5).Width = 120
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "มูลค่า"
            .Columns(6).Width = 100
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "อายุการใช้งาน (ปี)"
            .Columns(7).Width = 150
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "ใช้มาแล้ว"
            .Columns(8).Width = 150
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(9).Text = "มูลค่าปัจจุบัน(หักค่าเสื่อม)"
            .Columns(9).Width = 150
            .Columns(9).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With


        Dim ds As DataSet
        ds = clsdataBus.Lc_Business8.SELECT_TABLE("BTYPECODE,BTYPENAME", "l_btype ", " WHERE STATUS_AF = '1' ORDER BY BTYPECODE+0 ")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboBTYPE
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "BTYPENAME"
                .Properties.ValueMember = "BTYPECODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With

        End If

        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business8.SELECT_TABLE("RECIEVECODE,RECIEVENAME", "l_recieve ", " WHERE STATUS_AF = '1' ORDER BY RECIEVECODE+0 ")
        If ds2.Tables(0).Rows.Count > 0 Then
            With cboBUDGET
                .Properties.DataSource = ds2.Tables(0)
                .Properties.DisplayMember = "RECIEVENAME"
                .Properties.ValueMember = "RECIEVECODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If

        Dim ds3 As DataSet
        ds3 = clsdataBus.Lc_Business8.SELECT_TABLE("LOCATECODE,LOCATENAME", "l_location_office ", " WHERE STATUS_AF = '1'  ORDER BY LOCATECODE+0 ")
        If ds3.Tables(0).Rows.Count > 0 Then
            With cboLOCATE_OFFICE
                .Properties.DataSource = ds3.Tables(0)
                .Properties.DisplayMember = "LOCATENAME"
                .Properties.ValueMember = "LOCATECODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If

        Dim ds4 As DataSet
        ds4 = clsdataBus.Lc_Business8.SELECT_TABLE("LOCATECODE,LOCATENAME", "l_location ", "  WHERE STATUS_AF = '1' ORDER BY LOCATECODE+0 ")
        If ds4.Tables(0).Rows.Count > 0 Then
            With cboLOCATION
                .Properties.DataSource = ds4.Tables(0)
                .Properties.DisplayMember = "LOCATENAME"
                .Properties.ValueMember = "LOCATECODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If

        Dim ds5 As DataSet
        ds5 = clsdataBus.Lc_Business8.SELECT_TABLE("ASSETCODE,ASSETNAME", "l_assets_type ", " WHERE STATUS_AF = '1'  ORDER BY ASSETCODE+0 ")
        If ds5.Tables(0).Rows.Count > 0 Then
            With cboAssetGroup
                .Properties.DataSource = ds5.Tables(0)
                .Properties.DisplayMember = "ASSETNAME"
                .Properties.ValueMember = "ASSETCODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With

        End If

     
    End Sub
    Private Sub SearchData()
        SplashScreenManager1.ShowWaitForm()

        Dim tmpSQL1 As String = ""
        If CheckBox1.Checked = True Then
            tmpSQL1 = " AND BTYPE = '" & cboBTYPE.EditValue & "'"
        Else
            tmpSQL1 = ""
        End If

        Dim tmpSQL2 As String = ""
        If CheckBox2.Checked = True Then
            tmpSQL2 = " AND RECIEVE_TYPE = '" & cboBUDGET.EditValue & "'"
        Else
            tmpSQL2 = ""
        End If

        Dim tmpSQL3 As String = ""
        If CheckBox3.Checked = True Then
            tmpSQL3 = " AND OFFICE_LOCATION = '" & cboLOCATE_OFFICE.EditValue & "'"
        Else
            tmpSQL3 = ""
        End If

        Dim tmpSQL4 As String = ""
        If CheckBox4.Checked = True Then
            tmpSQL4 = " AND LOCATION = '" & cboLOCATION.EditValue & "'"
        Else
            tmpSQL4 = ""
        End If

        Dim tmpSQL5 As String = ""
        If CheckBox5.Checked = True Then
            tmpSQL5 = " AND GROUPTYPE = '" & cboAssetGroup.EditValue & "'"
        Else
            tmpSQL5 = ""
        End If

        Dim tmpSQL6 As String = ""
        If CheckBox7.Checked = True Or CheckBox7.Checked = True Or CheckBox8.Checked = True Or CheckBox9.Checked = True Or CheckBox10.Checked = True Or CheckBox11.Checked = True Then
            tmpSQL6 = " AND ("
            Dim tmpSQLex As String = ""
            If CheckBox7.Checked Then
                tmpSQLex = " STATUS_AF = '1' "
                tmpSQL6 = tmpSQL6 & tmpSQLex
            End If
            If CheckBox8.Checked = True Then
                If tmpSQLex = "" Then
                    tmpSQLex = " STATUS_AF = '2' "
                Else
                    tmpSQLex = " OR STATUS_AF = '2' "
                End If
                tmpSQL6 = tmpSQL6 & tmpSQLex
            End If
            If CheckBox9.Checked = True Then
                If tmpSQLex = "" Then
                    tmpSQLex = " STATUS_AF = '3' "
                Else
                    tmpSQLex = " OR STATUS_AF = '3' "
                End If
                tmpSQL6 = tmpSQL6 & tmpSQLex
            End If
            If CheckBox10.Checked = True Then
                If tmpSQLex = "" Then
                    tmpSQLex = " STATUS_AF = '4' "
                Else
                    tmpSQLex = " OR STATUS_AF = '4' "
                End If
                tmpSQL6 = tmpSQL6 & tmpSQLex
            End If
            If CheckBox11.Checked = True Then
                If tmpSQLex = "" Then
                    tmpSQLex = " STATUS_AF = '5' "
                Else
                    tmpSQLex = " OR STATUS_AF = '5' "
                End If
                tmpSQL6 = tmpSQL6 & tmpSQLex
            End If

            tmpSQL6 = tmpSQL6 & ")"
        Else
            tmpSQL6 = ""
        End If

        Dim ds As DataSet

        ds = clsdataBus.Lc_Business8.SELECT_TABLE("*", "m_assets", " WHERE (ASSET_CODE_ID LIKE '%" & txtSearch.Text & "%' OR ASSET_NAME LIKE '%" & txtSearch.Text & "%') " & tmpSQL1 & tmpSQL2 & tmpSQL3 & tmpSQL4 & tmpSQL5 & tmpSQL6 & " ORDER BY DATE_RECIEVE DESC")
        If ds.Tables(0).Rows.Count > 0 Then
            BetterDisplayData(ds)
            lblAmount.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
        Else
            BetterListView1.Items.Clear()
            lblAmount.Text = "จำนวน 0 รายการ"
        End If

        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub SearchDataAll()
        SplashScreenManager1.ShowWaitForm()

        Dim ds As DataSet

        ds = clsdataBus.Lc_Business8.SELECT_TABLE("*", "m_assets", " ORDER BY DATE_RECIEVE DESC")
        If ds.Tables(0).Rows.Count > 0 Then
            BetterDisplayData(ds)
            lblAmount.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
        Else
            BetterListView1.Items.Clear()
            lblAmount.Text = "จำนวน 0 รายการ"
        End If

        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub BetterDisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itms As New BetterListViewItem
        Dim tmpPrename As String = ""

        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)

                If Not IsDBNull(dr("STATUS_AF")) Then
                    If dr("STATUS_AF") = "4" Then
                        BetterListView1.Items.Add(ImageList1.Images.Item(1)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                    ElseIf dr("STATUS_AF") = "2" Then
                        BetterListView1.Items.Add(ImageList1.Images.Item(2)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                    ElseIf dr("STATUS_AF") = "1" Then
                        BetterListView1.Items.Add(ImageList1.Images.Item(0)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                    ElseIf dr("STATUS_AF") = "3" Then
                        BetterListView1.Items.Add(ImageList1.Images.Item(3)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                    ElseIf dr("STATUS_AF") = "5" Then
                        BetterListView1.Items.Add(ImageList1.Images.Item(4)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                    Else
                        BetterListView1.Items.Add("")
                    End If
                Else
                    BetterListView1.Items.Add("")
                End If

                BetterListView1.Items(i).SubItems.Add(dr("ROWID").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add((i + 1).ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add((dr("ASSET_CODE_ID") & "/" & dr("ASSET_ID")).ToString).AlignHorizontal = TextAlignmentHorizontal.Center

                If Not IsDBNull(dr("ASSET_NAME")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("ASSET_NAME").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If dr("DATE_RECIEVE") = "" Or dr("DATE_RECIEVE") = "00000000" Then
                    BetterListView1.Items(i).SubItems.Add("")
                Else
                    If CheckDate(DateTime.ParseExact(dr("DATE_RECIEVE").ToString.Substring(0, 4) + 543 & dr("DATE_RECIEVE").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("dd/MM/yyyy")) = False Then
                        BetterListView1.Items(i).SubItems.Add("")
                    Else
                        BetterListView1.Items(i).SubItems.Add((DateTime.ParseExact(dr("DATE_RECIEVE").ToString.Substring(0, 4) + 543 & dr("DATE_RECIEVE").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy")).ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                    End If
                End If


                If Not IsDBNull(dr("PRICE")) Then
                    BetterListView1.Items(i).SubItems.Add((CDbl(dr("PRICE")).ToString("#,##0.00")).ToString).AlignHorizontal = TextAlignmentHorizontal.Right
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If

                If Not IsDBNull(dr("YEAR_USED")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("YEAR_USED").ToString).AlignHorizontal = TextAlignmentHorizontal.Right
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If

                If IsDBNull(dr("DATE_RECIEVE")) Then
                    BetterListView1.Items(i).SubItems.Add("ไม่มีข้อมูล").AlignHorizontal = TextAlignmentHorizontal.Center
                    BetterListView1.Items(i).SubItems.Add("")
                Else
                    If dr("DATE_RECIEVE") <> "" Then
                        Dim tmpDOB = dr("DATE_RECIEVE").ToString.Substring(0, 4) + 543 & dr("DATE_RECIEVE").ToString.Substring(4, 4)
                        If CheckDate(DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("dd/MM/yyyy")) = True Then

                            Dim DOB As DateTime = DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture)
                            Dim Years As Integer = 0
                            Dim Month As Integer = 0
                            Dim YearText As String = ""
                            Dim MonthText As String = ""
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
                                If Years = 0 Then
                                    YearText = ""
                                Else
                                    YearText = Years.ToString() & " ปี "
                                End If
                                If Month = 0 Then
                                    MonthText = ""
                                Else
                                    MonthText = Month.ToString() & " เดือน "
                                End If
                                StrAge = YearText & MonthText & Days.ToString() & " วัน "
                            Else
                                StrAge = "ข้อมูลไม่ถูกต้อง"
                            End If

                            BetterListView1.Items(i).SubItems.Add(StrAge).AlignHorizontal = TextAlignmentHorizontal.Right

                            Dim tmpDaysUsed As Integer = 0
                            Dim totaldays2 = DateTime.Now - DOB
                            tmpDaysUsed = totaldays2.Days

                            If Not IsDBNull(dr("YEAR_USED")) Then
                                If dr("YEAR_USED") <> "" Then
                                    Dim tmpDaysExpire As Integer = 0
                                    Dim totaldays = CDate(DOB).AddYears(dr("YEAR_USED")) - DOB
                                    tmpDaysExpire = totaldays.Days
                                    Dim valueDeCline As Double = 0.0
                                    valueDeCline = CDbl(dr("PRICE")) / tmpDaysExpire
                                    valueDeCline = CDbl(CDbl(valueDeCline) * tmpDaysUsed)
                                    valueDeCline = CDbl(dr("PRICE")) - valueDeCline
                                    If valueDeCline < 1.0 Then
                                        BetterListView1.Items(i).SubItems.Add("1.00").AlignHorizontal = TextAlignmentHorizontal.Right
                                    Else
                                        BetterListView1.Items(i).SubItems.Add((valueDeCline.ToString("#,##0.00")).ToString).AlignHorizontal = TextAlignmentHorizontal.Right
                                    End If
                                Else
                                    BetterListView1.Items(i).SubItems.Add("0.00").AlignHorizontal = TextAlignmentHorizontal.Right
                                End If
                            Else
                                BetterListView1.Items(i).SubItems.Add("0.00").AlignHorizontal = TextAlignmentHorizontal.Right
                            End If
                        Else
                            BetterListView1.Items(i).SubItems.Add("").AlignHorizontal = TextAlignmentHorizontal.Right
                            BetterListView1.Items(i).SubItems.Add("0.00").AlignHorizontal = TextAlignmentHorizontal.Right
                        End If
                    Else
                        BetterListView1.Items(i).SubItems.Add("ไม่มีข้อมูล").AlignHorizontal = TextAlignmentHorizontal.Right
                        BetterListView1.Items(i).SubItems.Add("")
                    End If

                End If

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                If Not IsDBNull(dr("STATUS_AF")) Then
                    If dr("STATUS_AF") = "4" Then
                        BetterListView1.Items(i).BackColor = Color.LightPink
                    End If
                End If

            Next
            BetterListView1.AutoResizeColumn(3, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(4, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.ResumeSort()
            BetterListView1.EndUpdate()

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim tmpSumPrice As Double = 0.0
        Dim tmpSumPrice2 As Double = 0.0
        For i = 0 To BetterListView1.Items.Count - 1
            tmpSumPrice = tmpSumPrice + CDbl(BetterListView1.Items(i).SubItems(6).Text)
            tmpSumPrice2 = tmpSumPrice2 + CDbl(BetterListView1.Items(i).SubItems(9).Text)
        Next
        lblTotal1.Text = tmpSumPrice.ToString("#,##0.00")
        lblTotal2.Text = tmpSumPrice2.ToString("#,##0.00")
    End Sub
    Private Sub DisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itm As ListViewItem
        Dim NAMEUSER As String = ""
        Dim tmpPrename As String = ""
        Dim tmpProvider As String = ""
        Try
            ListView1.Items.Clear()
            ListView1.BeginUpdate()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)

                itm = ListView1.Items.Add(dr("ROWID"))
                itm.SubItems.Add(i + 1)
                itm.SubItems.Add(dr("ASSET_CODE_ID") & "/" & dr("ASSET_ID"))

                If Not IsDBNull(dr("ASSET_NAME")) Then
                    itm.SubItems.Add(dr("ASSET_NAME"))
                Else
                    itm.SubItems.Add("")
                End If


                If dr("DATE_RECIEVE") = "" Or dr("DATE_RECIEVE") = "00000000" Then
                    itm.SubItems.Add("")
                Else
                    If CheckDate(DateTime.ParseExact(dr("DATE_RECIEVE").ToString.Substring(0, 4) + 543 & dr("DATE_RECIEVE").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("dd/MM/yyyy")) = False Then
                        itm.SubItems.Add("")
                    Else
                        itm.SubItems.Add(DateTime.ParseExact(dr("DATE_RECIEVE").ToString.Substring(0, 4) + 543 & dr("DATE_RECIEVE").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy"))
                    End If
                End If

                If Not IsDBNull(dr("PRICE")) Then
                    itm.SubItems.Add(CDbl(dr("PRICE")).ToString("#,##0.00"))
                Else
                    itm.SubItems.Add("")
                End If

                If Not IsDBNull(dr("YEAR_USED")) Then
                    itm.SubItems.Add(dr("YEAR_USED"))
                Else
                    itm.SubItems.Add("")
                End If


                If IsDBNull(dr("DATE_RECIEVE")) Then
                    itm.SubItems.Add("ไม่มีข้อมูล")
                    itm.SubItems.Add("0.00")
                Else
                    If dr("DATE_RECIEVE") <> "" Then
                        Dim tmpDOB = dr("DATE_RECIEVE").ToString.Substring(0, 4) + 543 & dr("DATE_RECIEVE").ToString.Substring(4, 4)
                        If CheckDate(DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("dd/MM/yyyy")) = True Then

                            Dim DOB As DateTime = DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture)
                            Dim Years As Integer = 0
                            Dim Month As Integer = 0
                            Dim YearText As String = ""
                            Dim MonthText As String = ""
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
                                If Years = 0 Then
                                    YearText = ""
                                Else
                                    YearText = Years.ToString() & " ปี "
                                End If
                                If Month = 0 Then
                                    MonthText = ""
                                Else
                                    MonthText = Month.ToString() & " เดือน "
                                End If
                                StrAge = YearText & MonthText & Days.ToString() & " วัน "
                            Else
                                StrAge = "ข้อมูลไม่ถูกต้อง"
                            End If

                            itm.SubItems.Add(StrAge)
                            Dim tmpDaysUsed As Integer = 0
                            Dim totaldays2 = DateTime.Now - DOB
                            tmpDaysUsed = totaldays2.Days

                            If Not IsDBNull(dr("YEAR_USED")) Then
                                If dr("YEAR_USED") <> "" Then
                                    Dim tmpDaysExpire As Integer = 0
                                    Dim totaldays = CDate(DOB).AddYears(dr("YEAR_USED")) - DOB
                                    tmpDaysExpire = totaldays.Days
                                    Dim valueDeCline As Double = 0.0
                                    valueDeCline = CDbl(dr("PRICE")) / tmpDaysExpire
                                    valueDeCline = CDbl(CDbl(valueDeCline) * tmpDaysUsed)
                                    valueDeCline = CDbl(dr("PRICE")) - valueDeCline
                                    If valueDeCline < 1.0 Then
                                        itm.SubItems.Add("1.00")
                                    Else
                                        itm.SubItems.Add(valueDeCline.ToString("#,##0.00"))
                                    End If
                                Else
                                    itm.SubItems.Add("0.00")
                                End If
                            Else
                                itm.SubItems.Add("0.00")
                            End If
                        Else
                            itm.SubItems.Add("")
                            itm.SubItems.Add("0.00")
                        End If
                    Else
                        itm.SubItems.Add("ไม่มีข้อมูล")
                        itm.SubItems.Add("0.00")
                    End If

                End If

                If (itm.Index Mod 2) = 0 Then
                    itm.BackColor = Color.MintCream
                End If

                If Not IsDBNull(dr("STATUS_AF")) Then
                    If dr("STATUS_AF") = "4" Then
                        itm.BackColor = Color.LightCoral
                    End If
                End If
            Next
            ListView1.EndUpdate()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim tmpSumPrice As Double = 0.0
        Dim tmpSumPrice2 As Double = 0.0
        For i = 0 To ListView1.Items.Count - 1
            tmpSumPrice = tmpSumPrice + CDbl(ListView1.Items(i).SubItems(5).Text)
            tmpSumPrice2 = tmpSumPrice2 + CDbl(ListView1.Items(i).SubItems(8).Text)
        Next
        lblTotal1.Text = tmpSumPrice.ToString("#,##0.00")
        lblTotal2.Text = tmpSumPrice2.ToString("#,##0.00")

    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        For i As Integer = 0 To ListView1.SelectedItems.Count - 1
            Dim lvi As ListViewItem
            lvi = ListView1.SelectedItems(i)
            aseetROWID = lvi.SubItems.Item(0).Text
        Next
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        For i As Integer = 0 To ListView1.SelectedItems.Count - 1
            Dim lvi As ListViewItem
            lvi = ListView1.SelectedItems(i)
            aseetROWID = lvi.SubItems.Item(0).Text
        Next
        Dim f As New frmAssetEdit
        f.ShowDialog()

    End Sub

    Private Sub cmdCode_Click(sender As Object, e As EventArgs) Handles cmdCode.Click
        Dim f As New frmSearchAssetCode
        f.ShowDialog()
        If assetCode <> "" Then
            txtSearch.Text = assetCode
            RadioButton2.Checked = True
            SearchData()
        End If
    End Sub

    Private Sub cmdSearch2_Click(sender As Object, e As EventArgs) Handles cmdSearch2.Click
        If RadioButton1.Checked = True Then
            SearchDataAll()
        Else
            SearchData()
        End If

    End Sub

    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        txtSearch.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        aseetROWID = ""
        Dim f As New frmAssetEdit
        f.ShowDialog()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles cmdDel.Click
        If aseetROWID = "" Then
            XtraMessageBox.Show("กรุณาเลื่อกรายการทีต้องการลบก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            Dim f As New frmDelAssets
            f.ShowDialog()
            aseetROWID = ""
            SearchData()
        End If
    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs) Handles RadioButton2.Click
        txtSearch.Select()
    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click
        txtSearch.Text = ""
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub BetterListView1_DoubleClick(sender As Object, e As EventArgs) Handles BetterListView1.DoubleClick

        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            aseetROWID = lvi.SubItems.Item(1).Text
        Next
        If aseetROWID <> "" Then
            Dim f As New frmAssetEdit
            f.ShowDialog()
        End If

    End Sub


    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            aseetROWID = lvi.SubItems.Item(1).Text
        Next
    End Sub

    Private Sub CheckBox6_Click(sender As Object, e As EventArgs) Handles CheckBox6.Click
        If CheckBox6.Checked = True Then
            CheckBox7.Checked = True
            CheckBox8.Checked = True
            CheckBox9.Checked = True
            CheckBox10.Checked = True
            CheckBox11.Checked = True
        Else
            CheckBox7.Checked = True
            CheckBox8.Checked = False
            CheckBox9.Checked = False
            CheckBox10.Checked = False
            CheckBox11.Checked = False
        End If
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            SearchData()
        End If
    End Sub
End Class