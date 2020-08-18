Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Globalization
Imports System.IO
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors

Public Class frmNutritionMain
    Dim tmpCID As String = ""

    Private Sub frmNutritionMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClearData()
        cmdAdd.Enabled = False
        cmdEdit.Enabled = False

        If vPSEARCH = "1" Then
            chkPID.Checked = True
        ElseIf vPSEARCH = "2" Then
            'txtHN.Select()
        ElseIf vPSEARCH = "3" Then
            chkCID.Checked = True
        ElseIf vPSEARCH = "4" Then
            chkName.Checked = True
        Else
            chkPID.Checked = True
        End If

        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 30
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ROWID"
            .Columns(1).Width = 0
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "วันที่ตรวจ"
            .Columns(2).Width = 120
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "อายุ(เดือน)"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "น้ำหนัก"
            .Columns(4).Width = 100
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "ส่วนสูง"
            .Columns(5).Width = 100
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "เส้นรอบศีรษะ"
            .Columns(6).Width = 100
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "อาหารและนม"
            .Columns(7).Width = 150
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "การใช้ขวดนม"
            .Columns(8).Width = 100
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(9).Text = "ผู้ให้บริการ"
            .Columns(9).Width = 200
            .Columns(9).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(10).Text = "สถานบริการ"
            .Columns(10).Width = 150
            .Columns(10).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(11).Text = "วันที่ปรับปรุงข้อมูล"
            .Columns(11).Width = 150
            .Columns(11).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        txtPID.Select()
    End Sub
    Private Sub SearchData()
        ClearData()
        Dim tmpPrename As String = ""
        Dim tmpDOB As String = ""
        Dim tmpAge As String = ""
        Dim tmpD As String = ""
        Dim tmpM As String = ""
        Dim tmpY As String = ""

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("PID,HID,HN,CID,IFNULL(PRENAME_DESC,'') AS  PRENAME_DESC,NAME,LNAME,s.SEX,IFNULL(BIRTH,'') AS BIRTH," _
            & "TIMESTAMPDIFF(YEAR, BIRTH, Now()) As AGE_YEAR,TIMESTAMPDIFF( MONTH, BIRTH, now() ) % 12 As AGE_MONTH," _
            & "FLOOR( TIMESTAMPDIFF( DAY, BIRTH, now() ) % 30.4375 ) AS AGE_DAY", " m_person a LEFT JOIN l_mypcu_prename b ON(a.PRENAME_HOS = b.PRENAME_CODE) LEFT JOIN l_sex s ON(a.SEX = s.SEX_CODE) ", " WHERE CID = '" & tmpCID & "' AND a.STATUS_AF <> '8' ")

        If ds.Tables(0).Rows.Count > 0 Then

            lblPID.Text = ds.Tables(0).Rows(0).Item("PID").ToString

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("HN")) Then
                If ds.Tables(0).Rows(0).Item("HN") <> "" Then
                    lblHN.Text = ds.Tables(0).Rows(0).Item("HN").ToString
                Else
                    lblHN.Text = ""
                End If
            Else
                lblHN.Text = ""
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("CID")) Then
                Try
                    lblCID.Text = (ds.Tables(0).Rows(0).Item("CID")).ToString
                Catch ex As Exception

                End Try

                tmpCID = lblCID.Text
            Else
                lblCID.Text = ""
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("PRENAME_DESC")) Then
                tmpPrename = ds.Tables(0).Rows(0).Item("PRENAME_DESC").ToString

            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("NAME")) Then
                lblName.Text = tmpPrename & (ds.Tables(0).Rows(0).Item("NAME")).ToString
            Else
                lblName.Text = ""
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("LNAME")) Then
                lblLNAME.Text = (ds.Tables(0).Rows(0).Item("LNAME")).ToString
            Else
                lblLNAME.Text = ""
            End If

            lblSex.Text = ds.Tables(0).Rows(0).Item("SEX")

            If ds.Tables(0).Rows(0).Item("BIRTH") <> "" Then
                lblBirth.Text = DateTime.ParseExact(ds.Tables(0).Rows(0).Item("BIRTH"), "yyyyMMdd", CultureInfo.InvariantCulture).ToString("d MMM yyyy")
                Dim Years As String = ds.Tables(0).Rows(0).Item("AGE_YEAR")
                Dim Month As String = ds.Tables(0).Rows(0).Item("AGE_MONTH")
                Dim Days As String = ds.Tables(0).Rows(0).Item("AGE_DAY")
                lblAge.Text = ((Years.ToString() & " ปี ") + Month.ToString() & " เดือน ") + Days.ToString() & " วัน "
            End If





            If vImage = "0" Then
                If File.Exists(PicPer & txtPID.Text & ".png") = True Then
                    PictureEdit1.Image = Image.FromFile(PicPer & txtPID.Text & ".png")
                ElseIf File.Exists(PicPer & txtPID.Text & ".jpg") = True Then
                    PictureEdit1.Image = Image.FromFile(PicPer & txtPID.Text & ".jpg")
                ElseIf File.Exists(PicPer & lblCID.Text & ".png") = True Then
                    PictureEdit1.Image = Image.FromFile(PicPer & lblCID.Text & ".png")
                ElseIf File.Exists(PicPer & lblCID.Text.Replace(" ", "") & ".jpg") = True Then
                    PictureEdit1.Image = Image.FromFile(PicPer & lblCID.Text & ".jpg")
                Else
                    PictureEdit1.Image = Image.FromFile(Application.StartupPath & "\images\person.png")
                End If
            Else
                ShowImage()
            End If
            ShowDataNutrition()
        End If
    End Sub
    Private Sub ShowImage()
        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("IMG", " m_image_person ", " WHERE CID  = '" & lblCID.Text & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            Try
                Dim lb() As Byte = ds2.Tables(0).Rows(0).Item("IMG")
                Dim ms As MemoryStream = New MemoryStream(lb)
                Dim img As Image = Image.FromStream(ms)
                PictureEdit1.Image = img
                ms.Close()
            Catch ex As Exception

            End Try
        Else
            PictureEdit1.Image = Image.FromFile(Application.StartupPath & "\images\person.png")
        End If
    End Sub
    Private Sub ClearData()

        lblPID.Text = ""
        lblHN.Text = ""
        lblCID.Text = Nothing
        lblName.Text = ""
        lblLNAME.Text = ""
        lblBirth.Text = ""
        lblAge.Text = ""
        lblSex.Text = ""
        PictureEdit1.Image = Image.FromFile(Application.StartupPath & "\images\person.png")
        cmdAdd.Enabled = False
        BetterListView1.Items.Clear()
    End Sub
    Private Sub txtPID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPID.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SearchPerson()

            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex, "")
        End Try
    End Sub
    Private Sub SearchPerson()
        If txtPID.Text <> "" Then

            If IsNumeric(txtPID.Text) = False Then
                chkName.Checked = True
                chkPID.Checked = False
                chkCID.Checked = False
            End If

            Dim ds As DataSet
            If chkPID.Checked = True Then
                ds = clsdataBus.Lc_Business.SELECT_TABLE(" CID ", " m_person ", " WHERE PID = '" & txtPID.Text & "'  AND STATUS_AF <> '8' ")
            ElseIf chkCID.Checked = True Then
                ds = clsdataBus.Lc_Business.SELECT_TABLE(" CID ", " m_person ", " WHERE CID LIKE '%" & txtPID.Text & "%'  AND STATUS_AF <> '8' ")
            ElseIf chkName.Checked = True Then
                ds = clsdataBus.Lc_Business.SELECT_TABLE(" CID ", " m_person ", " WHERE (NAME LIKE '%" & txtPID.Text & "%' OR LNAME LIKE '%" & txtPID.Text & "%')  AND STATUS_AF <> '8' ")
            End If

            If ds.Tables(0).Rows.Count = 1 Then
                tmpCID = ds.Tables(0).Rows(0).Item("CID").ToString
                SearchData()
                cmdAdd.Enabled = True
            ElseIf ds.Tables(0).Rows.Count > 1 Then
                If chkPID.Checked = True Then
                    vSearchPID = txtPID.Text
                    vSearchCID = ""
                    vSearchName = ""
                ElseIf chkCID.Checked = True Then
                    vSearchCID = txtPID.Text
                    vSearchPID = ""
                    vSearchName = ""
                ElseIf chkName.Checked = True Then
                    vSearchName = txtPID.Text
                    vSearchPID = ""
                    vSearchCID = ""
                End If

                Dim f As New frmNameSearch
                f.ShowDialog()
            Else
                XtraMessageBox.Show("ไม่มีข้อมูล ลองค้นหาจากเงื่อนไขอื่นๆ!!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ClearData()
                Exit Sub
            End If
        Else
        End If
    End Sub
    Private Sub chkPID_Click(sender As Object, e As EventArgs) Handles chkPID.Click
        chkPID.Checked = True
        chkCID.Checked = False
        chkName.Checked = False
        txtPID.Text = ""
        txtPID.Select()
    End Sub
    Private Sub chkCID_Click(sender As Object, e As EventArgs) Handles chkCID.Click
        chkPID.Checked = False
        chkCID.Checked = True
        chkName.Checked = False
        txtPID.Text = ""
        txtPID.Select()
    End Sub
    Private Sub chkName_Click(sender As Object, e As EventArgs) Handles chkName.Click
        chkPID.Checked = False
        chkCID.Checked = False
        chkName.Checked = True
        txtPID.Text = ""
        txtPID.Select()
    End Sub
    Private Sub ShowDataNutrition()
        SplashScreenManager1.ShowWaitForm()
        Dim ds As DataSet
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 4)
        ds = clsdataBus.Lc_Business.SELECT_TABLE("a.PID,a.ROWID,a.HOSPCODE,a.SEQ,a.DATE_SERV,a.AGEMONTH,a.NUTRITIONPLACE,a.WEIGHT,a.HEIGHT,a.HEADCIRCUM,a.CHILDDEVELOP,a.FOOD,a.BOTTLE," _
                                                 & "a.PROVIDER,a.D_UPDATE,a.STATUS_AF,b.FOOD_DESC,c.BOTTLE_DESC" _
                                                 , "m_nutrition a LEFT JOIN l_food b on(a.FOOD = b.FOOD_CODE) LEFT JOIN l_bottle c on(a.BOTTLE = c.BOTTLE_CODE)" _
                                                 , "WHERE PID = '" & lblPID.Text & "' AND STATUS_AF <> '8'  ORDER BY DATE_SERV DESC")

        If ds.Tables(0).Rows.Count > 0 Then
            DisplayData(ds)
            Label2.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0").ToString & " รายการ"
        Else
            BetterListView1.Items.Clear()
            Label2.Text = "จำนวน 0 รายการ"
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    'Private Sub ShowDataNutrition()
    '    SplashScreenManager1.ShowWaitForm()
    '    Dim ds As DataSet
    '    Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 4)
    '    ds = clsdataBus.Lc_Business.SELECT_TABLE("*", "m_nutrition", "WHERE PID = '" & lblPID.Text & "' AND STATUS_AF <> '8'  ORDER BY DATE_SERV DESC")

    '    If ds.Tables(0).Rows.Count > 0 Then
    '        DisplayData(ds)
    '        Label2.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0").ToString & " รายการ"
    '    Else
    '        BetterListView1.Items.Clear()
    '        Label2.Text = "จำนวน 0 รายการ"
    '    End If
    '    SplashScreenManager1.CloseWaitForm()
    'End Sub
    Private Sub DisplayData(ByVal ds As DataSet)

        Dim dr As DataRow
        Dim tmpPrename As String = ""
        Dim tmpAge2 As String = ""
        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)

                If dr("SEQ") <> "" Then
                    BetterListView1.Items.Add(ImageList1.Images.Item(0)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                Else
                    BetterListView1.Items.Add("")
                End If
                BetterListView1.Items(i).SubItems.Add((dr("ROWID")).ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(Thaidate(dr("DATE_SERV")).ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add((dr("AGEMONTH")).ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add((dr("WEIGHT")).ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add((dr("HEIGHT")).ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add((dr("HEADCIRCUM")).ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add((dr("FOOD_DESC")).ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add((dr("BOTTLE_DESC")).ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                'BetterListView1.Items(i).SubItems.Add("")
                'BetterListView1.Items(i).SubItems.Add("")

                BetterListView1.Items(i).SubItems.Add(clsdataBus.Lc_Business.SELECT_NAME_PROVIDER(dr("PROVIDER")).ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(clsdataBus.Lc_Business.SELECT_NAME_HOSPITAL(dr("NUTRITIONPLACE")).ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(Thaidate_D_UPDATE(dr("D_UPDATE")).ToString).AlignHorizontal = TextAlignmentHorizontal.Center



                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                If dr("STATUS_AF").ToString = "0" Then
                    BetterListView1.Items(i).BackColor = Color.LightPink
                End If

            Next



            'BetterListView1.AutoResizeColumn(2, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            'BetterListView1.AutoResizeColumn(4, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            'BetterListView1.AutoResizeColumn(5, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            'BetterListView1.AutoResizeColumn(6, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            'BetterListView1.AutoResizeColumn(8, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            'BetterListView1.AutoResizeColumn(9, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.ResumeSort(True)
            BetterListView1.EndUpdate()


        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        vNutritionPID = lblPID.Text

        Dim f As New frmPersonNutrition
        f.ShowDialog()

        vNutritionPID = ""
        ShowDataNutrition()

    End Sub
    Private Sub BetterListView1_DoubleClick(sender As Object, e As EventArgs) Handles BetterListView1.DoubleClick
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            vNutritionRowID = lvi.SubItems.Item(1).Text
        Next

        vNutritionPID = lblPID.Text

        Dim f As New frmPersonNutrition
        f.ShowDialog()
        cmdEdit.Enabled = False
        vNutritionRowID = ""
        ShowDataNutrition()

    End Sub

    Private Sub BetterListView1_ItemSelectionChanged(sender As Object, eventArgs As BetterListViewItemSelectionChangedEventArgs) Handles BetterListView1.ItemSelectionChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            vNutritionRowID = lvi.SubItems.Item(1).Text
        Next
    End Sub

End Class