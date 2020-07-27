Imports clsDataAcc8 = MyPCU.ClsDataAccess8
Imports clsdataBus8 = MyPCU.ClsBusiness8
Imports clsbusent8 = MyPCU.ClsBusinessEntity8
Imports clsdataBus = MyPCU.ClsBusiness
Imports System.DateTime
Imports System.Globalization
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Imports DevExpress.Skins

Public Class frmAssetEdit
    Dim tmpAssetID As String = ""
    Dim tmpID As String = ""
    Dim tmpPicture1 As Boolean = False
    Dim tmpPicture2 As Boolean = False
    Dim tmpPicture3 As Boolean = False
    Dim tmpPicture4 As Boolean = False
    Dim tmpDateIn As String = ""
    Dim tmpDaysUsed As Integer = 0
    Dim tmpDaysExpire As Integer = 0
    Dim tmpUpdate As Boolean = False
    Dim rs As New Resizer
    'Dim _cultureTHInfo As New Globalization.CultureInfo("en-EN")

    Private Sub frmAssetEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F12
                ClearDataAll()
        End Select
    End Sub
    Protected Overrides Sub OnShown(ByVal e As EventArgs)
        MyBase.OnShown(e)
        Dim currentSkin As Skin = FormSkins.GetSkin(Me.LookAndFeel)
        Dim element As SkinElement = currentSkin(FormSkins.SkinFormCaption)
        element.Image.Image = Nothing
        element.Color.BackColor = Color.FromArgb(194, 191, 184)
        Me.LookAndFeel.UpdateStyleSettings()
    End Sub
    Private Sub frmAssetEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' rs.FindAllControls(Me)
        cmdSearchFix.Enabled = False
        Label23.Text = ""
        CalendarControl1.Visible = False

        With ListView1
            .Columns.Add("ROWID", 0, HorizontalAlignment.Center)
            .Columns.Add("ลำดับ", 80, HorizontalAlignment.Center)
            .Columns.Add("ประเภท", 120, HorizontalAlignment.Center)
            .Columns.Add("วันที่", 150, HorizontalAlignment.Center)
            .Columns.Add("รายละเอียด", 400, HorizontalAlignment.Left)
            .Columns.Add("จำนวนเงิน", 150, HorizontalAlignment.Right)
        End With
        ListView1.View = View.Details
        ListView1.GridLines = True

        Dim ds As DataSet
        ds = clsdataBus8.Lc_Business8.SELECT_TABLE("BTYPECODE,BTYPENAME", "l_btype ", "  ORDER BY BTYPECODE+0 ")
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
        ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("RECIEVECODE,RECIEVENAME", "l_recieve ", " WHERE STATUS_AF = '1' ORDER BY RECIEVECODE+0 ")
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
        ds3 = clsdataBus8.Lc_Business8.SELECT_TABLE("LOCATECODE,LOCATENAME", "l_location_office ", " WHERE STATUS_AF = '1' ORDER BY LOCATECODE+0 ")
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
        ds4 = clsdataBus8.Lc_Business8.SELECT_TABLE("LOCATECODE,LOCATENAME", "l_location ", " WHERE STATUS_AF = '1' ORDER BY LOCATECODE+0 ")
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
        ds5 = clsdataBus8.Lc_Business8.SELECT_TABLE("ASSETCODE,ASSETNAME", "l_assets_type ", " WHERE STATUS_AF = '1' ORDER BY ASSETCODE+0 ")
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

        Dim ds6 As DataSet
        ds6 = clsdataBus8.Lc_Business8.SELECT_TABLE("STATUSCODE,STATUSNAME", "l_status ", " WHERE STATUS_AF = '1' ORDER BY STATUSCODE+0 ")
        If ds6.Tables(0).Rows.Count > 0 Then
            With cboSTATUS
                .Properties.DataSource = ds6.Tables(0)
                .Properties.DisplayMember = "STATUSNAME"
                .Properties.ValueMember = "STATUSCODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If

        cboFromAction()

        If aseetROWID <> "" Then
            ShowData()
            txtASSET_NAME.SelectionStart = txtASSET_NAME.TextLength
        Else
            ButtonDisable()
        End If
    End Sub
    Private Sub ClearDataAll()
        lblASSET_CODE_ID1.Text = ""
        lblASSET_CODE_ID2.Text = ""
        lblASSET_CODE_ID3.Text = ""
        lblASSET_CODE_ID4.Text = ""

        txtASSET_NAME.Text = ""
        txtPRODUCT_NO.Text = ""

        txtDateIn.Text = ""
        txtGYEAR.Text = ""
        txtPRICE.Text = "0.00"
        NumericUpDown1.Value = 1
        txtREMARK.Text = ""
        PictureBox1.Image = Nothing
        PictureBox2.Image = Nothing
        PictureBox3.Image = Nothing
        PictureBox4.Image = Nothing
        ButtonDisable()
        lblAge.Text = ""
        lblExpired.Text = ""
        lblDeclineValue.Text = ""
        tmpUpdate = False
        Label22.Text = ""
        ListView1.Items.Clear()
        Label23.Text = ""

        txtASSET_NAME.Select()


    End Sub
    Private Sub ButtonDisable()
        cmdDelPic1.Enabled = False
        cmdPic1.Enabled = False
        cmdDelPic2.Enabled = False
        cmdPic2.Enabled = False
        cmdDelPic3.Enabled = False
        cmdPic3.Enabled = False
        cmdDelPic4.Enabled = False
        cmdPic4.Enabled = False
        cmdPictureDetail.Enabled = False
        cmdDocument.Enabled = False
        cmdFix.Enabled = False
        cmdDeleteAsset.Enabled = False
        cmdWebCam1.Enabled = False
        cmdWebCam2.Enabled = False
        cmdWebCam3.Enabled = False
        cmdWebCam4.Enabled = False
    End Sub
    Private Sub ButtonEnable()
        cmdDelPic1.Enabled = True
        cmdPic1.Enabled = True
        cmdDelPic2.Enabled = True
        cmdPic2.Enabled = True
        cmdDelPic3.Enabled = True
        cmdPic3.Enabled = True
        cmdDelPic4.Enabled = True
        cmdPic4.Enabled = True
        cmdPictureDetail.Enabled = True
        cmdDocument.Enabled = True
        cmdFix.Enabled = True
        cmdDeleteAsset.Enabled = True
        cmdWebCam1.Enabled = True
        cmdWebCam2.Enabled = True
        cmdWebCam3.Enabled = True
        cmdWebCam4.Enabled = True
    End Sub
    Private Sub ShowData()
        Dim ds As DataSet
        ds = clsdataBus8.Lc_Business8.SELECT_TABLE("ROWID,OFF_ID,GROUP_CODE,GROUP_TYPE_CODE,ASSET_CODE,ASSET_CODE_ID,ASSET_ID,DATE_RECIEVE,STR_TO_DATE(DATE_RECIEVE,'%Y%m%d') AS DATE_S,ASSET_NAME,UNIT,PRODUCT_NO,PRICE,GYEAR,YEAR_USED,RECIEVE_TYPE,CCO_SUBOFF,OFFICE_LOCATION,LOCATION,GROUPTYPE,CHANGWAT,BTYPE,REMARK,STATUS_AF,USER_REC,D_UPDATE,STATUS_SEND,IFNULL(COMPANY,'') AS COMPANY", "m_assets ", "  WHERE ROWID = '" & aseetROWID & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            tmpUpdate = True

            lblASSET_CODE_ID1.Text = ds.Tables(0).Rows(0).Item("GROUP_CODE")
            lblASSET_CODE_ID2.Text = ds.Tables(0).Rows(0).Item("GROUP_TYPE_CODE")
            lblASSET_CODE_ID3.Text = ds.Tables(0).Rows(0).Item("ASSET_CODE")
            lblASSET_CODE_ID4.Text = ds.Tables(0).Rows(0).Item("ASSET_ID")
            tmpAssetID = ds.Tables(0).Rows(0).Item("ASSET_CODE_ID")
            tmpID = ds.Tables(0).Rows(0).Item("ASSET_ID")
            vAssetID = ds.Tables(0).Rows(0).Item("ASSET_CODE_ID")
            vID = ds.Tables(0).Rows(0).Item("ASSET_ID")
            txtASSET_NAME.Text = ds.Tables(0).Rows(0).Item("ASSET_NAME")
            txtPRODUCT_NO.Text = ds.Tables(0).Rows(0).Item("PRODUCT_NO")
            txtUNIT.Text = ds.Tables(0).Rows(0).Item("UNIT")
            tmpDateIn = ds.Tables(0).Rows(0).Item("DATE_RECIEVE")
            'DateEdit1.Text = tmpDateIn.ToString.Substring(4, 2) & "/" & tmpDateIn.ToString.Substring(6, 2) & "/" & tmpDateIn.ToString.Substring(0, 4)
            'DateEdit1.EditValue = DateTime.ParseExact(ds.Tables(0).Rows(0).Item("DATE_RECIEVE").ToString.Substring(0, 4) + 543 & ds.Tables(0).Rows(0).Item("DATE_RECIEVE").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("dd/MM/yyyy")

            txtDateIn.Text = DateTime.ParseExact(ds.Tables(0).Rows(0).Item("DATE_RECIEVE").ToString.Substring(0, 4) + 543 & ds.Tables(0).Rows(0).Item("DATE_RECIEVE").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("dd/MM/yyyy")
            'DateEdit1.EditValue = DateTime.ParseExact(ds.Tables(0).Rows(0).Item("DATE_RECIEVE"), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("#dd/MM/yyyy#")
            'DateEdit1.Text = "06/01/2019"


            txtPRICE.Text = CDbl(ds.Tables(0).Rows(0).Item("PRICE")).ToString("#,##0.00")
            cboBTYPE.EditValue = ds.Tables(0).Rows(0).Item("BTYPE")
            cboBUDGET.EditValue = ds.Tables(0).Rows(0).Item("RECIEVE_TYPE")
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("OFFICE_LOCATION")) Then
                cboLOCATE_OFFICE.EditValue = ds.Tables(0).Rows(0).Item("OFFICE_LOCATION")
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("LOCATION")) Then
                cboLOCATION.EditValue = ds.Tables(0).Rows(0).Item("LOCATION")
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("GROUPTYPE")) Then
                cboAssetGroup.EditValue = ds.Tables(0).Rows(0).Item("GROUPTYPE")
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("GYEAR")) Then
                If ds.Tables(0).Rows(0).Item("GYEAR") = "" Then
                    If CInt(tmpDateIn.Substring(4, 2)) >= 10 Then
                        txtGYEAR.Text = CInt(tmpDateIn.Substring(0, 4)) + 544
                    Else
                        txtGYEAR.Text = CInt(tmpDateIn.Substring(0, 4)) + 543
                    End If
                Else
                    txtGYEAR.Text = ds.Tables(0).Rows(0).Item("GYEAR")
                End If
            Else
                If CInt(tmpDateIn.Substring(4, 2)) >= 10 Then
                    txtGYEAR.Text = CInt(tmpDateIn.Substring(0, 4)) + 544
                Else
                    txtGYEAR.Text = CInt(tmpDateIn.Substring(0, 4)) + 543
                End If
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("YEAR_USED")) Then
                If ds.Tables(0).Rows(0).Item("YEAR_USED") = "" Then
                    NumericUpDown1.Value = ClsBusiness8.Lc_Business8.SELECT_AGEUSED(ds.Tables(0).Rows(0).Item("GROUPTYPE"))
                Else
                    NumericUpDown1.Value = ds.Tables(0).Rows(0).Item("YEAR_USED")
                End If

            Else
                NumericUpDown1.Value = ClsBusiness8.Lc_Business8.SELECT_AGEUSED(ds.Tables(0).Rows(0).Item("GROUPTYPE"))
            End If
            txtCCO_SUBOFF.Text = ds.Tables(0).Rows(0).Item("CCO_SUBOFF")
            txtREMARK.Text = ds.Tables(0).Rows(0).Item("REMARK")

            cboSTATUS.EditValue = ds.Tables(0).Rows(0).Item("STATUS_AF")
            If ds.Tables(0).Rows(0).Item("STATUS_AF") = "4" Then
                cboSTATUS.Enabled = False
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("COMPANY")) Then
                If ds.Tables(0).Rows(0).Item("COMPANY") <> "" Then
                    Dim tmpCompany = ds.Tables(0).Rows(0).Item("COMPANY")
                    cboFROM.EditValue = CInt(ds.Tables(0).Rows(0).Item("COMPANY"))
                End If

            End If
            CalAge(tmpDateIn)
            CalExpired(tmpDateIn)
            ShowImages1()
            ShowImages2()
            ShowImages3()
            ShowImages4()
            SearchDocument()
            ShowDataFix()

            ButtonEnable()
            txtASSET_NAME.Select()
        End If
    End Sub
    Private Sub ShowDataFix()
        Dim ds2 As DataSet
        ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("*", " m_assets_fix ", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "' AND STATUS_AF = '1' ORDER BY DATE_IN DESC")
        If ds2.Tables(0).Rows.Count > 0 Then
            DisplayData(ds2)
            Label23.Text = "จำนวน " & ds2.Tables(0).Rows.Count & " รายการ"
            cmdSearchFix.Enabled = True
        Else
            cmdSearchFix.Enabled = False
            ListView1.Items.Clear()
            Label23.Text = "จำนวน 0 รายการ"
        End If

    End Sub
    Private Sub DisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itm As ListViewItem
        Dim tmpSum As Double = 0.0
        Try
            ListView1.Items.Clear()
            ListView1.BeginUpdate()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                itm = ListView1.Items.Add(dr("ROWID"))
                itm.SubItems.Add(i + 1)
                If dr("ASSET_STATUS") = "1" Then
                    itm.SubItems.Add("ปรับปรุง/ซ่อม")
                Else
                    itm.SubItems.Add("จำหน่าย")
                End If
                itm.SubItems.Add(DateTime.ParseExact(dr("DATE_IN").ToString.Substring(0, 4) + 543 & dr("DATE_IN").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy"))
                itm.SubItems.Add(dr("DETAIL"))
                itm.SubItems.Add(CDbl(dr("PRICE")).ToString("#,##0.00"))
                If (itm.Index Mod 2) = 0 Then
                    itm.BackColor = Color.WhiteSmoke
                End If

                tmpSum = tmpSum + CDbl(dr("PRICE"))
                If dr("ASSET_STATUS") = "0" Then
                    itm.BackColor = Color.LightCoral
                End If
            Next

            ListView1.EndUpdate()
            Label22.Text = tmpSum.ToString("#,##0.00")
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub SearchDocument()
        Dim ds As DataSet
        ds = clsdataBus8.Lc_Business8.SELECT_TABLE("*", "t_document ", "  WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            cmdDocument.Text = "เอกสารที่เกี่ยวข้อง (" & ds.Tables(0).Rows.Count & ")"
        Else
            cmdDocument.Text = "เอกสารที่เกี่ยวข้อง"
        End If

    End Sub
    Private Sub CalAge(ByVal StrDate As String)
        Dim tmpDOB As String = ""
        tmpDOB = StrDate.ToString.Substring(0, 4) + 543 & StrDate.ToString.Substring(4, 4)
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 8)


        If CheckDate(DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("dd/MM/yyyy")) = True Then
            'txtBIRTH.Text = DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy")
            Dim DOB As DateTime = DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture)
            Dim tmpDOS As String = tmpNow
            Dim tmpDOS2 As DateTime = DateTime.ParseExact(tmpDOS, "yyyyMMdd", CultureInfo.CurrentCulture)
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

                lblAge.Text = Years.ToString & " ปี " & Month.ToString & " เดือน " & Days.ToString & " วัน"

                Dim totaldays = tmpDOS2 - DOB
                tmpDaysUsed = totaldays.Days

            Else
                lblAge.Text = ""
            End If
        Else
            lblAge.Text = ""
        End If
    End Sub

    Private Sub CalExpired(ByVal StrDate As String)
        If txtDateIn.Text <> "" Then
            lblExpired.Text = CDate(txtDateIn.Text).AddYears(NumericUpDown1.Value).ToString("d MMM yyyy")

            Dim tmpDOB As String = ""
            tmpDOB = StrDate.ToString.Substring(0, 4) + 543 & StrDate.ToString.Substring(4, 4)

            Dim DOB As DateTime = DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture)

            Dim totaldays = CDate(txtDateIn.Text).AddYears(NumericUpDown1.Value) - DOB
            tmpDaysExpire = totaldays.Days

            Dim valueDeCline As Double = 0.0
            valueDeCline = CDbl(txtPRICE.Text) / tmpDaysExpire
            valueDeCline = CDbl(CDbl(valueDeCline) * tmpDaysUsed)
            valueDeCline = CDbl(txtPRICE.Text) - valueDeCline
            If valueDeCline < 1.0 Then
                lblDeclineValue.Text = "1.00"
            Else
                lblDeclineValue.Text = valueDeCline.ToString("#,##0.00")
            End If
        End If

    End Sub
    Private Sub ShowImages1()
        Dim ds2 As DataSet
        ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("IMG", " t_picture1 ", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            Dim lb() As Byte = ds2.Tables(0).Rows(0).Item("IMG")
            Dim ms As MemoryStream = New MemoryStream(lb)
            Dim img As Image = Image.FromStream(ms)
            PictureBox1.Image = img
            ms.Close()
        End If
    End Sub
    Private Sub ShowImages2()
        Dim ds2 As DataSet
        ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("IMG", " t_picture2 ", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            Dim lb() As Byte = ds2.Tables(0).Rows(0).Item("IMG")
            Dim ms As MemoryStream = New MemoryStream(lb)
            Dim img As Image = Image.FromStream(ms)
            PictureBox2.Image = img
            ms.Close()
        End If
    End Sub
    Private Sub ShowImages3()
        Dim ds2 As DataSet
        ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("IMG", " t_picture3 ", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            Dim lb() As Byte = ds2.Tables(0).Rows(0).Item("IMG")
            Dim ms As MemoryStream = New MemoryStream(lb)
            Dim img As Image = Image.FromStream(ms)
            PictureBox3.Image = img
            ms.Close()
        End If
    End Sub
    Private Sub ShowImages4()
        Dim ds2 As DataSet
        ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("IMG", " t_picture4 ", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            Dim lb() As Byte = ds2.Tables(0).Rows(0).Item("IMG")
            Dim ms As MemoryStream = New MemoryStream(lb)
            Dim img As Image = Image.FromStream(ms)
            PictureBox4.Image = img
            ms.Close()
        End If
    End Sub
    Private Sub cmdPic1_Click(sender As Object, e As EventArgs) Handles cmdPic1.Click
        If lblASSET_CODE_ID1.Text = "" Then
            Exit Sub
        End If
        Me.XtraOpenFileDialog1.Filter = "PNG files (*.png)|*.png|JPEG files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif|All files (*.*)|*.*"
        If XtraOpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(XtraOpenFileDialog1.FileName)
            tmpPicture1 = True
        End If
        M_Picture1()
    End Sub


    Private Sub cmdPic2_Click(sender As Object, e As EventArgs) Handles cmdPic2.Click
        If lblASSET_CODE_ID1.Text = "" Then
            Exit Sub
        End If
        Me.XtraOpenFileDialog1.Filter = "PNG files (*.png)|*.png|JPEG files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif|All files (*.*)|*.*"
        If XtraOpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox2.Image = Image.FromFile(XtraOpenFileDialog1.FileName)
            tmpPicture2 = True
        End If
        M_Picture2()
    End Sub
    Private Sub cmdPic3_Click(sender As Object, e As EventArgs) Handles cmdPic3.Click
        If lblASSET_CODE_ID1.Text = "" Then
            Exit Sub
        End If
        Me.XtraOpenFileDialog1.Filter = "PNG files (*.png)|*.png|JPEG files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif|All files (*.*)|*.*"
        If XtraOpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox3.Image = Image.FromFile(XtraOpenFileDialog1.FileName)
            tmpPicture3 = True
        End If
        M_Picture3()
    End Sub


    Private Sub cmdPic4_Click(sender As Object, e As EventArgs) Handles cmdPic4.Click
        If lblASSET_CODE_ID1.Text = "" Then
            Exit Sub
        End If
        Me.XtraOpenFileDialog1.Filter = "PNG files (*.png)|*.png|JPEG files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif|All files (*.*)|*.*"
        If XtraOpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox4.Image = Image.FromFile(XtraOpenFileDialog1.FileName)
            tmpPicture4 = True
        End If
        M_Picture4()
    End Sub
    Public Shared Function ResizeImage(ByVal image As Image, ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        Dim newWidth As Integer
        Dim newHeight As Integer
        If preserveAspectRatio Then
            Dim originalWidth As Integer = image.Width
            Dim originalHeight As Integer = image.Height
            Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
            Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
            Dim percent As Single = If(percentHeight < percentWidth,
                    percentHeight, percentWidth)
            newWidth = CInt(originalWidth * percent)
            newHeight = CInt(originalHeight * percent)
        Else
            newWidth = size.Width
            newHeight = size.Height
        End If
        Dim newImage As Image = New Bitmap(newWidth, newHeight)
        Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using
        Return newImage
    End Function
    Private Sub M_Picture1()
        Try
            Dim conn As MySqlConnection = New MySqlConnection
            Dim cmd As New MySqlCommand
            Dim FileSize As UInt32
            Dim SQL As String

            If PictureBox1.Image IsNot Nothing Then
                Dim resized As Image = ResizeImage(PictureBox1.Image, New Size(485, 485))
                Dim ms As New MemoryStream()

                resized.Save(ms, PictureBox1.Image.RawFormat)
                Dim Img As Byte() = ms.GetBuffer()
                FileSize = ms.Length
                ms.Close()

                Dim dsi As DataSet
                dsi = clsdataBus8.Lc_Business8.SELECT_TABLE("ASSET_ID", " t_picture1", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")


                If dsi.Tables(0).Rows.Count = 0 Then

                    SQL = "INSERT INTO t_picture1 (ASSET_ID,ID,IMG,FILESIZE) VALUES(@ASSET_ID,@ID,@IMG,@FILESIZE)"
                    conn.ConnectionString = "Data Source=" & clsDataAcc8.G_DBIPServer8 & ";port=" & clsDataAcc8.G_DBPortServer8 & ";Database= " & clsDataAcc8.G_DBName8 & ";user id=" & clsDataAcc8.G_DBUserName8 & ";password=" & clsDataAcc8.G_DBPassword8 & ""
                    conn.Open()
                    cmd.Connection = conn
                    cmd.CommandText = SQL
                    cmd.Parameters.AddWithValue("@ASSET_ID", tmpAssetID)
                    cmd.Parameters.AddWithValue("@ID", tmpID)
                    cmd.Parameters.AddWithValue("@IMG", Img)
                    cmd.Parameters.AddWithValue("@FILESIZE", FileSize)
                    cmd.ExecuteNonQuery()
                    conn.Close()
                Else
                    SQL = "UPDATE t_picture1 SET IMG = @IMG,FILESIZE = @FILESIZE WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'"
                    conn.ConnectionString = "Data Source=" & clsDataAcc8.G_DBIPServer8 & ";port=" & clsDataAcc8.G_DBPortServer8 & ";Database= " & clsDataAcc8.G_DBName8 & ";user id=" & clsDataAcc8.G_DBUserName8 & ";password=" & clsDataAcc8.G_DBPassword8 & ""
                    conn.Open()
                    cmd.Connection = conn
                    cmd.CommandText = SQL
                    cmd.Parameters.AddWithValue("@ASSET_ID", tmpAssetID)
                    cmd.Parameters.AddWithValue("@ID", tmpID)
                    cmd.Parameters.AddWithValue("@IMG", Img)
                    cmd.Parameters.AddWithValue("@FILESIZE", FileSize)
                    cmd.ExecuteNonQuery()
                    conn.Close()

                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show("ไฟล์ภาพมีปัญหาไม่สามารถบันทึกได้!!!  " & ex.ToString, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub M_Picture2()
        Try
            Dim conn As MySqlConnection = New MySqlConnection
            Dim cmd As New MySqlCommand
            Dim FileSize As UInt32
            Dim SQL As String

            If PictureBox2.Image IsNot Nothing Then
                Dim resized As Image = ResizeImage(PictureBox2.Image, New Size(485, 485))
                Dim ms As New MemoryStream()

                resized.Save(ms, PictureBox2.Image.RawFormat)
                Dim Img As Byte() = ms.GetBuffer()
                FileSize = ms.Length
                ms.Close()

                Dim dsi As DataSet
                dsi = clsdataBus8.Lc_Business8.SELECT_TABLE("ASSET_ID", " t_picture2", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")


                If dsi.Tables(0).Rows.Count = 0 Then

                    SQL = "INSERT INTO t_picture2 (ASSET_ID,ID,IMG,FILESIZE) VALUES(@ASSET_ID,@ID,@IMG,@FILESIZE)"
                    conn.ConnectionString = "Data Source=" & clsDataAcc8.G_DBIPServer8 & ";port=" & clsDataAcc8.G_DBPortServer8 & ";Database= " & clsDataAcc8.G_DBName8 & ";user id=" & clsDataAcc8.G_DBUserName8 & ";password=" & clsDataAcc8.G_DBPassword8 & ""
                    conn.Open()
                    cmd.Connection = conn
                    cmd.CommandText = SQL
                    cmd.Parameters.AddWithValue("@ASSET_ID", tmpAssetID)
                    cmd.Parameters.AddWithValue("@ID", tmpID)
                    cmd.Parameters.AddWithValue("@IMG", Img)
                    cmd.Parameters.AddWithValue("@FILESIZE", FileSize)
                    cmd.ExecuteNonQuery()
                    conn.Close()
                Else
                    SQL = "UPDATE t_picture2 SET IMG = @IMG,FILESIZE = @FILESIZE WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'"
                    conn.ConnectionString = "Data Source=" & clsDataAcc8.G_DBIPServer8 & ";port=" & clsDataAcc8.G_DBPortServer8 & ";Database= " & clsDataAcc8.G_DBName8 & ";user id=" & clsDataAcc8.G_DBUserName8 & ";password=" & clsDataAcc8.G_DBPassword8 & ""
                    conn.Open()
                    cmd.Connection = conn
                    cmd.CommandText = SQL
                    cmd.Parameters.AddWithValue("@ASSET_ID", tmpAssetID)
                    cmd.Parameters.AddWithValue("@ID", tmpID)
                    cmd.Parameters.AddWithValue("@IMG", Img)
                    cmd.Parameters.AddWithValue("@FILESIZE", FileSize)
                    cmd.ExecuteNonQuery()
                    conn.Close()

                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show("ไฟล์ภาพมีปัญหาไม่สามารถบันทึกได้!!!  " & ex.ToString, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub M_Picture3()
        Try
            Dim conn As MySqlConnection = New MySqlConnection
            Dim cmd As New MySqlCommand
            Dim FileSize As UInt32
            Dim SQL As String

            If PictureBox3.Image IsNot Nothing Then
                Dim resized As Image = ResizeImage(PictureBox3.Image, New Size(485, 485))
                Dim ms As New MemoryStream()

                resized.Save(ms, PictureBox3.Image.RawFormat)
                Dim Img As Byte() = ms.GetBuffer()
                FileSize = ms.Length
                ms.Close()

                Dim dsi As DataSet
                dsi = clsdataBus8.Lc_Business8.SELECT_TABLE("ASSET_ID", " t_picture3", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")


                If dsi.Tables(0).Rows.Count = 0 Then

                    SQL = "INSERT INTO t_picture3 (ASSET_ID,ID,IMG,FILESIZE) VALUES(@ASSET_ID,@ID,@IMG,@FILESIZE)"
                    conn.ConnectionString = "Data Source=" & clsDataAcc8.G_DBIPServer8 & ";port=" & clsDataAcc8.G_DBPortServer8 & ";Database= " & clsDataAcc8.G_DBName8 & ";user id=" & clsDataAcc8.G_DBUserName8 & ";password=" & clsDataAcc8.G_DBPassword8 & ""
                    conn.Open()
                    cmd.Connection = conn
                    cmd.CommandText = SQL
                    cmd.Parameters.AddWithValue("@ASSET_ID", tmpAssetID)
                    cmd.Parameters.AddWithValue("@ID", tmpID)
                    cmd.Parameters.AddWithValue("@IMG", Img)
                    cmd.Parameters.AddWithValue("@FILESIZE", FileSize)
                    cmd.ExecuteNonQuery()
                    conn.Close()
                Else
                    SQL = "UPDATE t_picture3 SET IMG = @IMG,FILESIZE = @FILESIZE WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'"
                    conn.ConnectionString = "Data Source=" & clsDataAcc8.G_DBIPServer8 & ";port=" & clsDataAcc8.G_DBPortServer8 & ";Database= " & clsDataAcc8.G_DBName8 & ";user id=" & clsDataAcc8.G_DBUserName8 & ";password=" & clsDataAcc8.G_DBPassword8 & ""
                    conn.Open()
                    cmd.Connection = conn
                    cmd.CommandText = SQL
                    cmd.Parameters.AddWithValue("@ASSET_ID", tmpAssetID)
                    cmd.Parameters.AddWithValue("@ID", tmpID)
                    cmd.Parameters.AddWithValue("@IMG", Img)
                    cmd.Parameters.AddWithValue("@FILESIZE", FileSize)
                    cmd.ExecuteNonQuery()
                    conn.Close()

                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show("ไฟล์ภาพมีปัญหาไม่สามารถบันทึกได้!!!  " & ex.ToString, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub M_Picture4()
        Try
            Dim conn As MySqlConnection = New MySqlConnection
            Dim cmd As New MySqlCommand
            Dim FileSize As UInt32
            Dim SQL As String

            If PictureBox4.Image IsNot Nothing Then
                Dim resized As Image = ResizeImage(PictureBox4.Image, New Size(485, 485))
                Dim ms As New MemoryStream()

                resized.Save(ms, PictureBox4.Image.RawFormat)
                Dim Img As Byte() = ms.GetBuffer()
                FileSize = ms.Length
                ms.Close()

                Dim dsi As DataSet
                dsi = clsdataBus8.Lc_Business8.SELECT_TABLE("ASSET_ID", " t_picture4", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")


                If dsi.Tables(0).Rows.Count = 0 Then

                    SQL = "INSERT INTO t_picture4 (ASSET_ID,ID,IMG,FILESIZE) VALUES(@ASSET_ID,@ID,@IMG,@FILESIZE)"
                    conn.ConnectionString = "Data Source=" & clsDataAcc8.G_DBIPServer8 & ";port=" & clsDataAcc8.G_DBPortServer8 & ";Database= " & clsDataAcc8.G_DBName8 & ";user id=" & clsDataAcc8.G_DBUserName8 & ";password=" & clsDataAcc8.G_DBPassword8 & ""
                    conn.Open()
                    cmd.Connection = conn
                    cmd.CommandText = SQL
                    cmd.Parameters.AddWithValue("@ASSET_ID", tmpAssetID)
                    cmd.Parameters.AddWithValue("@ID", tmpID)
                    cmd.Parameters.AddWithValue("@IMG", Img)
                    cmd.Parameters.AddWithValue("@FILESIZE", FileSize)
                    cmd.ExecuteNonQuery()
                    conn.Close()
                Else
                    SQL = "UPDATE t_picture4 SET IMG = @IMG,FILESIZE = @FILESIZE WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'"
                    conn.ConnectionString = "Data Source=" & clsDataAcc8.G_DBIPServer8 & ";port=" & clsDataAcc8.G_DBPortServer8 & ";Database= " & clsDataAcc8.G_DBName8 & ";user id=" & clsDataAcc8.G_DBUserName8 & ";password=" & clsDataAcc8.G_DBPassword8 & ""
                    conn.Open()
                    cmd.Connection = conn
                    cmd.CommandText = SQL
                    cmd.Parameters.AddWithValue("@ASSET_ID", tmpAssetID)
                    cmd.Parameters.AddWithValue("@ID", tmpID)
                    cmd.Parameters.AddWithValue("@IMG", Img)
                    cmd.Parameters.AddWithValue("@FILESIZE", FileSize)
                    cmd.ExecuteNonQuery()
                    conn.Close()

                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show("ไฟล์ภาพมีปัญหาไม่สามารถบันทึกได้!!!  " & ex.ToString, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        If txtDateIn.Text = "" Then
            XtraMessageBox.Show("กรุณาวันที่ได้รับทรัพย์สินก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDateIn.Select()
            Exit Sub
        End If
        Dim DATE_IN As String = CDate(txtDateIn.Text).ToString("yyyyMMdd")
        DATE_IN = DATE_IN.ToString.Substring(0, 4) - 543 & DATE_IN.ToString.Substring(4, 4)
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)

        If txtGYEAR.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดปีงบประมาณก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtGYEAR.Select()
            Exit Sub
        End If

        If NumericUpDown1.Value = 0 Then
            XtraMessageBox.Show("กรุณากำหนดอายุการใช้งานก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            NumericUpDown1.Select()
            Exit Sub
        End If

        Dim tmpAddress As String = ""
        Dim tmpHCODE As String = ""
        Dim tmpIDPROVINCE As String = ""
        Dim tmpAMPHUR_ID As String = ""
        Dim tmpHospname As String = ""
        Dim tmpCODE = Encode("wilasinee@3100200131951")

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("*", "l_confighcode", "")
        If ds.Tables(0).Rows.Count > 0 Then
            tmpHCODE = Encode(ds.Tables(0).Rows(0).Item("HOSPCODE").ToString)
            tmpIDPROVINCE = Encode(ds.Tables(0).Rows(0).Item("PROVINCE_ID").ToString)
            tmpAMPHUR_ID = Encode(ds.Tables(0).Rows(0).Item("AMPHUR_ID").ToString)
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("ADDRESS")) Then
                tmpAddress = ds.Tables(0).Rows(0).Item("ADDRESS")
            End If
            tmpHospname = Encode(ds.Tables(0).Rows(0).Item("HOSPNAME").ToString)
        End If
        If tmpAddress = "" Or tmpHCODE & tmpIDPROVINCE & tmpAMPHUR_ID & tmpCODE & tmpHospname <> tmpAddress Then
            Dim ds2 As DataSet
            ds2 = clsdataBus.Lc_Business.SELECT_TABLE("*", "m_assets", "")
            If ds2.Tables(0).Rows.Count > 9 Then
                XtraMessageBox.Show("ไม่สามารถบันทึกได้เนื่องจากบันทึกเกิน 10 รายการ!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

        End If

        If tmpUpdate = True Then
            clsbusent8.Lc_BusinessEntity8.UpdateM_table("m_assets", " ASSET_NAME = '" & txtASSET_NAME.Text.Replace("'", "\'") & "'" _
                                                      & ",UNIT = '" & txtUNIT.Text & "'" _
                                                      & ",PRODUCT_NO = '" & txtPRODUCT_NO.Text & "'" _
                                                      & ",DATE_RECIEVE = '" & DATE_IN & "'" _
                                                      & ",PRICE = '" & CDbl(txtPRICE.Text).ToString("0.00") & "'" _
                                                      & ",GYEAR = '" & txtGYEAR.Text & "'" _
                                                      & ",YEAR_USED = '" & NumericUpDown1.Value & "'" _
                                                      & ",BTYPE = '" & cboBTYPE.EditValue & "'" _
                                                      & ",RECIEVE_TYPE = '" & cboBUDGET.EditValue & "'" _
                                                      & ",OFFICE_LOCATION = '" & cboLOCATE_OFFICE.EditValue & "'" _
                                                      & ",LOCATION = '" & cboLOCATION.EditValue & "'" _
                                                      & ",COMPANY = '" & cboFROM.EditValue & "'" _
                                                      & ",GROUPTYPE = '" & cboAssetGroup.EditValue & "'" _
                                                      & ",CCO_SUBOFF = '" & txtCCO_SUBOFF.Text & "'" _
                                                      & ",REMARK = '" & txtREMARK.Text & "'" _
                                                      & ",USER_REC = '" & vUSERID & "'" _
                                                      & ",D_UPDATE = '" & tmpNow & "'" _
                                                      & ",STATUS_AF = '" & cboSTATUS.EditValue & "',STATUS_SEND = '0'" _
                                                      , " ROWID = '" & aseetROWID & "'")
            XtraMessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If lblASSET_CODE_ID1.Text = "" Then
                Dim f As New frmProvideCode
                f.ShowDialog()
                If genCode <> "" Then
                    lblASSET_CODE_ID1.Text = genCode
                    lblASSET_CODE_ID2.Text = genCode2
                    lblASSET_CODE_ID3.Text = genCode3
                    lblASSET_CODE_ID4.Text = genCode4
                    txtUNIT.Text = genUnit
                    genCode = ""
                    genUnit = ""
                    tmpAssetID = genCode & "-" & genCode2 & "-" & genCode3
                    tmpID = genCode4
                Else
                    Exit Sub
                End If
            End If
            If tAmount = 1 Then
                clsbusent8.Lc_BusinessEntity8.InsertM_table("m_assets (OFF_ID,GROUP_CODE,GROUP_TYPE_CODE,ASSET_CODE,ASSET_CODE_ID," _
                                                                      & "ASSET_ID,DATE_RECIEVE,ASSET_NAME,UNIT,PRODUCT_NO,PRICE,GYEAR," _
                                                                      & "YEAR_USED,RECIEVE_TYPE,OFFICE_LOCATION,LOCATION,GROUPTYPE," _
                                                                      & "BTYPE,CCO_SUBOFF,COMPANY,REMARK,STATUS_AF,USER_REC,D_UPDATE,STATUS_SEND)",
                            "'" & vHcode & "','" & lblASSET_CODE_ID1.Text & "'" _
                            & ",'" & lblASSET_CODE_ID2.Text & "'" _
                            & ",'" & lblASSET_CODE_ID3.Text & "'" _
                            & ",'" & lblASSET_CODE_ID1.Text & "-" & lblASSET_CODE_ID2.Text & "-" & lblASSET_CODE_ID3.Text & "'" _
                            & ",'" & lblASSET_CODE_ID4.Text & "'" _
                            & ",'" & DATE_IN & "'" _
                            & ",'" & txtASSET_NAME.Text.Replace("'", "\'") & "'" _
                            & ",'" & txtUNIT.Text & "'" _
                            & ",'" & txtPRODUCT_NO.Text & "'" _
                            & ",'" & CDbl(txtPRICE.Text).ToString("0.00") & "'" _
                            & ",'" & txtGYEAR.Text & "'" _
                            & ",'" & NumericUpDown1.Value.ToString & "'" _
                            & ",'" & cboBUDGET.EditValue & "'" _
                            & ",'" & cboLOCATE_OFFICE.EditValue & "'" _
                            & ",'" & cboLOCATION.EditValue & "'" _
                            & ",'" & cboAssetGroup.EditValue & "'" _
                            & ",'" & cboBTYPE.EditValue & "'" _
                            & ",'" & txtCCO_SUBOFF.Text & "'" _
                            & ",'" & cboFROM.EditValue & "'" _
                            & ",'" & txtREMARK.Text & "'" _
                            & ",'1','" & vUSERID & "'" _
                            & ",'" & tmpNow & "','0'")
            Else
                For i As Integer = 0 To tAmount - 1

                    clsbusent8.Lc_BusinessEntity8.InsertM_table("m_assets (OFF_ID,GROUP_CODE,GROUP_TYPE_CODE,ASSET_CODE,ASSET_CODE_ID," _
                                                                      & "ASSET_ID,DATE_RECIEVE,ASSET_NAME,UNIT,PRODUCT_NO,PRICE,GYEAR," _
                                                                      & "YEAR_USED,RECIEVE_TYPE,OFFICE_LOCATION,LOCATION,GROUPTYPE," _
                                                                      & "BTYPE,CCO_SUBOFF,COMPANY,REMARK,STATUS_AF,USER_REC,D_UPDATE,STATUS_SEND)",
                            "'" & vHcode & "','" & lblASSET_CODE_ID1.Text & "'" _
                            & ",'" & lblASSET_CODE_ID2.Text & "'" _
                            & ",'" & lblASSET_CODE_ID3.Text & "'" _
                            & ",'" & lblASSET_CODE_ID1.Text & "-" & lblASSET_CODE_ID2.Text & "-" & lblASSET_CODE_ID3.Text & "'" _
                            & ",'" & genCode4 & "'" _
                            & ",'" & DATE_IN & "'" _
                            & ",'" & txtASSET_NAME.Text.Replace("'", "\'") & "'" _
                            & ",'" & txtUNIT.Text & "'" _
                            & ",'" & txtPRODUCT_NO.Text & "'" _
                            & ",'" & CDbl(txtPRICE.Text).ToString("0.00") & "'" _
                            & ",'" & txtGYEAR.Text & "'" _
                            & ",'" & NumericUpDown1.Value.ToString & "'" _
                            & ",'" & cboBUDGET.EditValue & "'" _
                            & ",'" & cboLOCATE_OFFICE.EditValue & "'" _
                            & ",'" & cboLOCATION.EditValue & "'" _
                            & ",'" & cboAssetGroup.EditValue & "'" _
                            & ",'" & cboBTYPE.EditValue & "'" _
                            & ",'" & txtCCO_SUBOFF.Text & "'" _
                            & ",'" & cboFROM.EditValue & "'" _
                            & ",'" & txtREMARK.Text & "'" _
                            & ",'1','" & vUSERID & "'" _
                            & ",'" & tmpNow & "','0'")
                    genCode4 = genCode4 + 1
                Next
            End If




            tmpUpdate = True
            ButtonEnable()

            XtraMessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        If tmpPicture1 = True Then
            M_Picture1()
        End If
        If tmpPicture2 = True Then
            M_Picture2()
        End If
        If tmpPicture3 = True Then
            M_Picture3()
        End If
        If tmpPicture4 = True Then
            M_Picture4()
        End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If txtDateIn.Text <> "" Then
            Dim DATE_IN As String = CDate(txtDateIn.Text).ToString("yyyyMMdd")
            DATE_IN = DATE_IN.ToString.Substring(0, 4) - 543 & DATE_IN.ToString.Substring(4, 4)
            CalExpired(DATE_IN)
        End If

    End Sub
    Private Sub txtPRICE_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPRICE.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Try

                    txtPRICE.Text = CDbl(txtPRICE.Text).ToString("#,##0.00")
                Catch ex As Exception
                    XtraMessageBox.Show("บันทึกตัวเลขไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtPRICE.SelectAll()

                    Exit Sub
                End Try

                NumericUpDown1.Select()

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPRICE_Leave(sender As Object, e As EventArgs) Handles txtPRICE.Leave
        Try

            txtPRICE.Text = CDbl(txtPRICE.Text).ToString("#,##0.00")
            If txtDateIn.Text = "" Then
                Dim DATE_IN As String = CDate(txtDateIn.Text).ToString("yyyyMMdd")
                DATE_IN = DATE_IN.ToString.Substring(0, 4) - 543 & DATE_IN.ToString.Substring(4, 4)
                CalExpired(DATE_IN)
            End If
        Catch ex As Exception
            XtraMessageBox.Show("บันทึกตัวเลขไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPRICE.SelectAll()

            Exit Sub
        End Try
    End Sub

    Private Sub cmdDelPic1_Click(sender As Object, e As EventArgs) Handles cmdDelPic1.Click
        If XtraMessageBox.Show("ต้องการลบภาพใช่หรือไม่?", vProgram, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            clsbusent8.Lc_BusinessEntity8.Delete_table("t_picture1", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")
            PictureBox1.Image = Nothing
        End If
    End Sub

    Private Sub cmdDelPic2_Click(sender As Object, e As EventArgs) Handles cmdDelPic2.Click
        If XtraMessageBox.Show("ต้องการลบภาพใช่หรือไม่?", vProgram, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            clsbusent8.Lc_BusinessEntity8.Delete_table("t_picture2", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")
            PictureBox2.Image = Nothing
        End If
    End Sub

    Private Sub cmdDelPic3_Click(sender As Object, e As EventArgs) Handles cmdDelPic3.Click
        If XtraMessageBox.Show("ต้องการลบภาพใช่หรือไม่?", vProgram, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            clsbusent8.Lc_BusinessEntity8.Delete_table("t_picture3", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")
            PictureBox3.Image = Nothing
        End If
    End Sub

    Private Sub cmdDelPic4_Click(sender As Object, e As EventArgs) Handles cmdDelPic4.Click
        If XtraMessageBox.Show("ต้องการลบภาพใช่หรือไม่?", vProgram, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            clsbusent8.Lc_BusinessEntity8.Delete_table("t_picture4", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")
            PictureBox4.Image = Nothing
        End If
    End Sub

    Private Sub cmdBTYPE_Click(sender As Object, e As EventArgs) Handles cmdBTYPE.Click
        Dim tmpValue = cboBTYPE.EditValue
        Dim f As New frmTableBtype
        f.ShowDialog()
        cboBTYPE.Properties.DataSource = Nothing

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("BTYPECODE,BTYPENAME", "l_btype ", "  ORDER BY BTYPECODE+0 ")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboBTYPE
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "BTYPENAME"
                .Properties.ValueMember = "BTYPECODE"
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
    End Sub

    Private Sub cmdBugdet_Click(sender As Object, e As EventArgs) Handles cmdBugdet.Click
        Dim tmpValue = cboBUDGET.EditValue
        Dim f As New frmTableBudget
        f.ShowDialog()

        cboBUDGET.Properties.DataSource = Nothing

        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("RECIEVECODE,RECIEVENAME", "l_recieve ", " WHERE STATUS_AF = '1' ORDER BY RECIEVECODE+0 ")
        If ds2.Tables(0).Rows.Count > 0 Then
            With cboBUDGET
                .Properties.DataSource = ds2.Tables(0)
                .Properties.DisplayMember = "RECIEVENAME"
                .Properties.ValueMember = "RECIEVECODE"
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If


    End Sub

    Private Sub cmdOFF_LOCATE_Click(sender As Object, e As EventArgs) Handles cmdOFF_LOCATE.Click
        Dim tmpValue = cboLOCATE_OFFICE.EditValue
        Dim f As New frmTableLocationOffice
        f.ShowDialog()

        cboLOCATE_OFFICE.Properties.DataSource = Nothing
        Dim ds3 As DataSet
        ds3 = clsdataBus.Lc_Business.SELECT_TABLE("LOCATECODE,LOCATENAME", "l_location_office ", " WHERE STATUS_AF = '1' ORDER BY LOCATECODE+0 ")
        If ds3.Tables(0).Rows.Count > 0 Then
            With cboLOCATE_OFFICE
                .Properties.DataSource = ds3.Tables(0)
                .Properties.DisplayMember = "LOCATENAME"
                .Properties.ValueMember = "LOCATECODE"
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If

    End Sub

    Private Sub cmdLOCATION_Click(sender As Object, e As EventArgs) Handles cmdLOCATION.Click
        Dim tmpValue = cboLOCATION.EditValue
        Dim f As New frmTableLocate
        f.ShowDialog()
        cboLOCATION.Properties.DataSource = Nothing

        Dim ds4 As DataSet
        ds4 = clsdataBus.Lc_Business.SELECT_TABLE("LOCATECODE,LOCATENAME", "l_location ", " WHERE STATUS_AF = '1' ORDER BY LOCATECODE+0 ")
        If ds4.Tables(0).Rows.Count > 0 Then
            With cboLOCATION
                .Properties.DataSource = ds4.Tables(0)
                .Properties.DisplayMember = "LOCATENAME"
                .Properties.ValueMember = "LOCATECODE"
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
    End Sub

    Private Sub cmdGroup_Click(sender As Object, e As EventArgs) Handles cmdGroup.Click
        Dim tmpValue = cboAssetGroup.EditValue
        Dim f As New frmTableAssetType
        f.ShowDialog()
        cboAssetGroup.Properties.DataSource = Nothing

        Dim ds5 As DataSet
        ds5 = clsdataBus.Lc_Business.SELECT_TABLE("ASSETCODE,ASSETNAME", "l_assets_type ", " WHERE STATUS_AF = '1' ORDER BY ASSETCODE+0 ")
        If ds5.Tables(0).Rows.Count > 0 Then
            With cboAssetGroup
                .Properties.DataSource = ds5.Tables(0)
                .Properties.DisplayMember = "ASSETNAME"
                .Properties.ValueMember = "ASSETCODE"
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
        NumericUpDown1.Value = ClsBusiness8.Lc_Business8.SELECT_AGEUSED(tmpValue)

    End Sub


    Private Sub cmdPictureDetail_Click(sender As Object, e As EventArgs) Handles cmdPictureDetail.Click
        picCODE = tmpAssetID & "/" & tmpID
        PicNAME = txtASSET_NAME.Text
        picAssetCODE = tmpAssetID
        PicID = tmpID
        Dim f As New frmAssetPicture
        f.ShowDialog()
    End Sub

    Private Sub cmdDocument_Click(sender As Object, e As EventArgs) Handles cmdDocument.Click
        picCODE = tmpAssetID & "/" & tmpID
        PicNAME = txtASSET_NAME.Text
        picAssetCODE = tmpAssetID
        PicID = tmpID
        Dim f As New frmAssetDocument
        f.ShowDialog()
        SearchDocument()
    End Sub

    Private Sub cmdFix_Click(sender As Object, e As EventArgs) Handles cmdFix.Click
        picCODE = tmpAssetID & "/" & tmpID
        PicNAME = txtASSET_NAME.Text
        picAssetCODE = tmpAssetID
        PicID = tmpID
        Dim f As New frmAssetFix
        f.ShowDialog()
        ShowDataFix()
    End Sub

    Private Sub cmdDeleteAsset_Click(sender As Object, e As EventArgs) Handles cmdDeleteAsset.Click
        picCODE = tmpAssetID & "/" & tmpID
        PicNAME = txtASSET_NAME.Text
        picAssetCODE = tmpAssetID
        PicID = tmpID
        Dim f As New frmAssetDecline
        f.ShowDialog()
        ShowDataFix()
        ShowData()
    End Sub

    Private Sub txtASSET_NAME_KeyDown(sender As Object, e As KeyEventArgs) Handles txtASSET_NAME.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                txtUNIT.Select()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtUNIT_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUNIT.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                txtPRODUCT_NO.Select()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPRODUCT_NO_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPRODUCT_NO.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                cboAssetGroup.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboAssetGroup_SelectionChangeCommitted(sender As Object, e As EventArgs)
        NumericUpDown1.Value = ClsBusiness8.Lc_Business8.SELECT_AGEUSED(cboAssetGroup.EditValue)
        txtDateIn.Select()
    End Sub

    Private Sub cboLOCATION_SelectionChangeCommitted(sender As Object, e As EventArgs)
        txtCCO_SUBOFF.Select()
    End Sub

    Private Sub cmdWebCam1_Click(sender As Object, e As EventArgs) Handles cmdWebCam1.Click
        picAssetCODE = tmpAssetID
        PicID = tmpID
        vWebCam = "1"
        Dim f As New frmWebCam
        f.ShowDialog()
        ShowImages1()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles cmdWebCam2.Click
        picAssetCODE = tmpAssetID
        PicID = tmpID
        vWebCam = "2"
        Dim f As New frmWebCam
        f.ShowDialog()
        ShowImages2()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles cmdWebCam3.Click
        picAssetCODE = tmpAssetID
        PicID = tmpID
        vWebCam = "3"
        Dim f As New frmWebCam
        f.ShowDialog()
        ShowImages3()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles cmdWebCam4.Click
        picAssetCODE = tmpAssetID
        PicID = tmpID
        vWebCam = "4"
        Dim f As New frmWebCam
        f.ShowDialog()
        ShowImages4()
    End Sub



    Private Sub txtCCO_SUBOFF_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCCO_SUBOFF.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                txtREMARK.Select()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DateEdit1_EditValueChanged(sender As Object, e As EventArgs)
        If txtDateIn.Text <> "" Then

            Dim DATE_IN As String = CDate(txtDateIn.Text).ToString("yyyyMMdd")

            If CInt(DATE_IN.Substring(4, 2)) >= 10 Then
                txtGYEAR.Text = CInt(DATE_IN.Substring(0, 4)) + 1
            Else
                txtGYEAR.Text = CInt(DATE_IN.Substring(0, 4))
            End If
            DATE_IN = DATE_IN.ToString.Substring(0, 4) - 543 & DATE_IN.ToString.Substring(4, 4)
            CalAge(DATE_IN)
            CalExpired(DATE_IN)
        End If

    End Sub

    Private Sub cmdSearchFix_Click(sender As Object, e As EventArgs) Handles cmdSearchFix.Click
        Dim f As New frmAssetFixDetail
        f.ShowDialog()
    End Sub

    Private Sub cboSTATUS_EditValueChanged(sender As Object, e As EventArgs) Handles cboSTATUS.EditValueChanged
        If tmpUpdate = False Then
            If cboSTATUS.EditValue = "4" Then
                XtraMessageBox.Show("ไม่สามารถเลือกรายการนี้ได้ ให้ไปในบันทึกการจำหน่าย!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cboSTATUS.EditValue = "1"
                Exit Sub
            End If
        End If

    End Sub

    Private Sub cboAssetGroup_EditValueChanged(sender As Object, e As EventArgs) Handles cboAssetGroup.EditValueChanged
        NumericUpDown1.Value = ClsBusiness8.Lc_Business8.SELECT_AGEUSED(cboAssetGroup.EditValue)
        txtDateIn.Select()
    End Sub

    Private Sub cboLOCATION_EditValueChanged(sender As Object, e As EventArgs) Handles cboLOCATION.EditValueChanged
        txtCCO_SUBOFF.Select()
    End Sub

    Private Sub cmdCalenda_Click(sender As Object, e As EventArgs) Handles cmdCalenda.Click
        If CalendarControl1.Visible = False Then
            CalendarControl1.Visible = True
            CalendarControl1.EditValue = txtDateIn.Text
        Else
            CalendarControl1.Visible = False
        End If

    End Sub

    Private Sub CalendarControl1_DoubleClick(sender As Object, e As EventArgs) Handles CalendarControl1.DoubleClick
        txtDateIn.Text = CalendarControl1.EditValue
        If txtDateIn.Text <> "" Then
            Dim DATE_IN As String = CDate(txtDateIn.Text).ToString("yyyyMMdd")

            If CInt(DATE_IN.Substring(4, 2)) >= 10 Then
                txtGYEAR.Text = CInt(DATE_IN.Substring(0, 4)) + 1
            Else
                txtGYEAR.Text = CInt(DATE_IN.Substring(0, 4))
            End If
            DATE_IN = DATE_IN.ToString.Substring(0, 4) - 543 & DATE_IN.ToString.Substring(4, 4)
            CalAge(DATE_IN)
            CalExpired(DATE_IN)
        End If
        CalendarControl1.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As New frmCompanySearch
        f.ShowDialog()
        cboFromAction()
    End Sub
    Private Sub cboFromAction()
        cboFROM.Properties.DataSource = Nothing
        Dim ds As DataSet
        ds = clsdataBus8.Lc_Business8.SELECT_TABLE("COMPANY_NAME,ROWID", "l_company ", " WHERE STATUS_AF = '1' ")

        If ds.Tables(0).Rows.Count > 0 Then
            With cboFROM
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "COMPANY_NAME"
                .Properties.ValueMember = "ROWID"
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        Else
            cboFROM.Properties.DataSource = Nothing
        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f As New frmSearchTemp
        f.ShowDialog()
        If vTmpID <> "" Then
            Dim ds2 As DataSet
            ds2 = clsdataBus.Lc_Business.SELECT_TABLE("ROWID,ID,ASSETS_NAME,IFNULL(MODEL,'') AS MODEL,IFNULL(SERIAL,'') AS SERIAL,IFNULL(COMPANY,'') AS COMPANY,PRICE,DATEIN", " m_tmp_assets ", " WHERE ROWID = '" & vTmpID & "' ")
            If ds2.Tables(0).Rows.Count > 0 Then
                txtASSET_NAME.Text = ds2.Tables(0).Rows(0).Item("ASSETS_NAME") & " " & ds2.Tables(0).Rows(0).Item("MODEL")
                txtPRODUCT_NO.Text = ds2.Tables(0).Rows(0).Item("SERIAL")
                txtPRICE.Text = CDbl(ds2.Tables(0).Rows(0).Item("PRICE")).ToString("#,##0.00")
                txtDateIn.Text = DateTime.ParseExact(ds2.Tables(0).Rows(0).Item("DATEIN").ToString.Substring(0, 4) & ds2.Tables(0).Rows(0).Item("DATEIN").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("dd/MM/yyyy")
                CalendarControl1.EditValue = txtDateIn
                If txtDateIn.Text <> "" Then
                    Dim DATE_IN As String = CDate(txtDateIn.Text).ToString("yyyyMMdd")

                    If CInt(DATE_IN.Substring(4, 2)) >= 10 Then
                        txtGYEAR.Text = CInt(DATE_IN.Substring(0, 4)) + 1
                    Else
                        txtGYEAR.Text = CInt(DATE_IN.Substring(0, 4))
                    End If
                    DATE_IN = DATE_IN.ToString.Substring(0, 4) - 543 & DATE_IN.ToString.Substring(4, 4)
                    CalAge(DATE_IN)
                    CalExpired(DATE_IN)
                End If
            End If

        End If

        vTmpID = ""
    End Sub

    Private Sub CalendarControl1_Click(sender As Object, e As EventArgs) Handles CalendarControl1.Click

    End Sub
End Class