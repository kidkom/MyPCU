Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D
Imports System.IO
Imports DevExpress.XtraEditors
Public Class frmWebCam

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        PictureEdit1.EditValue = CameraControl1.TakeSnapshot()
        CameraControl1.ShowSettingsButton = False
        Dim bmp As Bitmap = New Bitmap(CameraControl1.Width, CameraControl1.Height)
        CameraControl1.DrawToBitmap(bmp, New Rectangle(0, 0, CameraControl1.Width, CameraControl1.Height))

        If Not Directory.Exists(Application.StartupPath & "\tmppic\") Then
            Directory.CreateDirectory(Application.StartupPath & "\tmppic\")
        End If

        Dim tmpNow As String = Now.ToString("yyyyMMddHHmmss")
        bmp.Save(Application.StartupPath & "\tmppic\" & tmpNow & ".jpg", Imaging.ImageFormat.Jpeg)
        PictureBox1.Image = Image.FromFile(Application.StartupPath & "\tmppic\" & tmpNow & ".jpg")
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If vImage = "0" Then
            PictureBox1.Image.Save(PicPer & vCidImage & ".png", System.Drawing.Imaging.ImageFormat.Png)
        ElseIf vImage = "1" Then
            SavePicture()
        Else
            SavePicture()
            PictureBox1.Image.Save(PicPer & vCidImage & ".png", System.Drawing.Imaging.ImageFormat.Png)
        End If

        XtraMessageBox.Show(msSave, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub
    Private Sub SavePicture()
        Try
            Dim connpic As MySqlConnection = New MySqlConnection
            Dim cmd As New MySqlCommand
            Dim FileSize As UInt32
            Dim SQL As String

            If PictureBox1.Image IsNot Nothing Then
                Dim resized As Image = ResizeImage(PictureBox1.Image, New Size(168, 186))
                Dim ms As New MemoryStream()

                resized.Save(ms, PictureBox1.Image.RawFormat)
                Dim Img As Byte() = ms.GetBuffer()
                FileSize = ms.Length
                ms.Close()

                Dim dsi As DataSet
                dsi = clsdataBus.Lc_Business.SELECT_TABLE("CID", " m_image_person ", " WHERE CID = '" & vCidImage & "' ")


                If dsi.Tables(0).Rows.Count = 0 Then

                    SQL = "INSERT INTO m_image_person (CID,IMG,FILESIZE) VALUES(@CID,@IMG,@FILESIZE)"
                    If connpic.State = ConnectionState.Open Then
                        connpic.Close()
                    End If
                    connpic.ConnectionString = "Data Source=" & clsDataAcc.G_DBIPServer & ";port=" & clsDataAcc.G_DBPortServer & ";Database= his43;user id=" & clsDataAcc.G_DBUserName & ";password=" & clsDataAcc.G_DBPassword & ""
                    connpic.Open()
                    cmd.Connection = connpic
                    cmd.CommandText = SQL
                    cmd.Parameters.AddWithValue("@CID", vCidImage)
                    cmd.Parameters.AddWithValue("@IMG", Img)
                    cmd.Parameters.AddWithValue("@FILESIZE", FileSize)
                    cmd.ExecuteNonQuery()
                    connpic.Close()
                Else
                    SQL = "UPDATE m_image_person SET IMG = @IMG,FILESIZE = @FILESIZE WHERE CID = '" & vCidImage & "' "
                    connpic.ConnectionString = "Data Source=" & clsDataAcc.G_DBIPServer & ";port=" & clsDataAcc.G_DBPortServer & ";Database= his43;user id=" & clsDataAcc.G_DBUserName & ";password=" & clsDataAcc.G_DBPassword & ""
                    connpic.Open()
                    cmd.Connection = connpic
                    cmd.CommandText = SQL
                    cmd.Parameters.AddWithValue("@CID", vCidImage)
                    cmd.Parameters.AddWithValue("@IMG", Img)
                    cmd.Parameters.AddWithValue("@FILESIZE", FileSize)
                    cmd.ExecuteNonQuery()
                    connpic.Close()

                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show("ไฟล์ภาพมีปัญหาไม่สามารถบันทึกได้!!!  " & ex.ToString, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


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
End Class