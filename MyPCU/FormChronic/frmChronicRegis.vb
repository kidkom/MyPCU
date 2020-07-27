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
        PictureEdit1.Image = Image.FromFile(Application.StartupPath & "\images\person.png")

        If vPSEARCH = "1" Then
            txtPID.Select()
        ElseIf vPSEARCH = "2" Then
            txtHN.Select()
        ElseIf vPSEARCH = "3" Then
            txtCID.Select()
        ElseIf vPSEARCH = "4" Then
            txtName.Select()
        Else
            txtPID.Select()
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

            txtPID.Text = ds.Tables(0).Rows(0).Item("PID").ToString

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("HN")) Then
                If ds.Tables(0).Rows(0).Item("HN") <> "" Then
                    txtHN.Text = ds.Tables(0).Rows(0).Item("HN").ToString
                Else
                    txtHN.Text = ""
                End If
            Else
                txtHN.Text = ""
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("CID")) Then
                Try
                    txtCID.Text = (ds.Tables(0).Rows(0).Item("CID")).ToString
                Catch ex As Exception

                End Try

                tmpCID = txtCID.Text
            Else
                txtCID.Text = Nothing
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("PRENAME_DESC")) Then
                tmpPrename = ds.Tables(0).Rows(0).Item("PRENAME_DESC").ToString

            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("NAME")) Then
                txtName.Text = tmpPrename & (ds.Tables(0).Rows(0).Item("NAME")).ToString
            Else
                txtName.Text = ""
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("LNAME")) Then
                txtLName.Text = (ds.Tables(0).Rows(0).Item("LNAME")).ToString
            Else
                txtLName.Text = ""
            End If

            txtSex.Text = ds.Tables(0).Rows(0).Item("SEX")
            If ds.Tables(0).Rows(0).Item("BIRTH") <> "" Then
                txtBIRTH.Text = DateTime.ParseExact(ds.Tables(0).Rows(0).Item("BIRTH"), "yyyyMMdd", CultureInfo.InvariantCulture).ToString("d MMM yyyy")
                Dim Years As String = ds.Tables(0).Rows(0).Item("AGE_YEAR")
                Dim Month As String = ds.Tables(0).Rows(0).Item("AGE_MONTH")
                Dim Days As String = ds.Tables(0).Rows(0).Item("AGE_DAY")
                txtAGE.Text = ((Years.ToString() & " ปี ") + Month.ToString() & " เดือน ") + Days.ToString() & " วัน "
            End If





            If vImage = "0" Then
                If File.Exists(PicPer & txtPID.Text & ".png") = True Then
                    PictureEdit1.Image = Image.FromFile(PicPer & txtPID.Text & ".png")
                ElseIf File.Exists(PicPer & txtPID.Text & ".jpg") = True Then
                    PictureEdit1.Image = Image.FromFile(PicPer & txtPID.Text & ".jpg")
                ElseIf File.Exists(PicPer & txtCID.Text & ".png") = True Then
                    PictureEdit1.Image = Image.FromFile(PicPer & txtCID.Text & ".png")
                ElseIf File.Exists(PicPer & txtCID.Text.Replace(" ", "") & ".jpg") = True Then
                    PictureEdit1.Image = Image.FromFile(PicPer & txtCID.Text & ".jpg")
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
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("IMG", " m_image_person ", " WHERE CID  = '" & txtCID.Text & "'")
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

        txtPID.Text = ""
        txtHN.Text = ""
        txtCID.Text = Nothing
        txtName.Text = ""
        txtLName.Text = ""
        txtBIRTH.Text = ""
        txtAGE.Text = ""
        txtSex.Text = ""
    End Sub
    Private Sub txtPID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPID.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If txtPID.Text <> "" Then
                    Dim ds As DataSet
                    ds = clsdataBus.Lc_Business.SELECT_TABLE(" CID ", " m_person ", " WHERE PID = '" & txtPID.Text & "'  AND STATUS_AF <> '8' ")
                    If ds.Tables(0).Rows.Count = 1 Then
                        tmpCID = ds.Tables(0).Rows(0).Item("CID").ToString
                        SearchData()
                    ElseIf ds.Tables(0).Rows.Count > 1 Then
                        XtraMessageBox.Show("มีข้อมูลมากกว่า 1 รายการ!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        XtraMessageBox.Show("ไม่มีข้อมูล ลองค้นหาจากเงื่อนไขอื่นๆ!!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ClearData()
                        Exit Sub
                    End If
                Else
                    txtHN.Select()
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex, "")
        End Try
    End Sub

    Private Sub FluentDesignFormControl1_Click(sender As Object, e As EventArgs) Handles FluentDesignFormControl1.Click

    End Sub
End Class
