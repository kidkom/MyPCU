Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Globalization
Imports System.IO
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmChronicRegis
    Dim tmpCID As String = ""
    Private Sub frmChronicRegis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClearData()


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
            .Columns.Add(0).Text = "ROWID"
            .Columns(0).Width = 0
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "วันที่วินิจฉัย/พบ"
            .Columns(1).Width = 150
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "โรงเรื้อรัง"
            .Columns(2).Width = 120
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "หน่วยบริการที่วินิฉัย"
            .Columns(3).Width = 120
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "หน่วยบริการที่รักษาประจำ"
            .Columns(4).Width = 120
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "สถานะ"
            .Columns(5).Width = 120
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "วันที่จำหน่าย"
            .Columns(6).Width = 200
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "วันที่บันทึก/ปรับปรุง"
            .Columns(7).Width = 120
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
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
    End Sub
    Private Sub txtPID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPID.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SearchPerson()

            End If
        Catch ex As Exception
            MessageBox.Show(ex, "")
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

    Private Sub FluentDesignFormControl1_Click(sender As Object, e As EventArgs) Handles FluentDesignFormControl1.Click

    End Sub
End Class
