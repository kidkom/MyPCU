Imports System.IO
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports Saraff.Twain.Twain32
Imports iTextSharp.text.pdf
Imports DevExpress.XtraEditors
Public Class frmDocumentScan
    ' Dim _twain32 = New Saraff.Twain.Twain32
    Friend WithEvents _twain32 As Saraff.Twain.Twain32
    Dim tmpFile As Integer = 0

    Dim imgThumb As Image = Nothing

    Dim PicWidth As Integer
    Dim PicHeight As Integer
    Dim XLocation As Integer
    Dim YLocation As Integer

    Dim x As Integer = 2

    Dim chkFileList(17) As String
    Dim fileListUC() As String
    Dim fileList() As String
    Dim tmpDelete As String = ""

    Private Sub frmDocumentScan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me._twain32 = New Saraff.Twain.Twain32
        If Directory.Exists(Application.StartupPath & "/Scan") Then
            Directory.Delete(Application.StartupPath & "/Scan", True)
            Directory.CreateDirectory(Application.StartupPath & "/Scan")
        Else
            Directory.CreateDirectory(Application.StartupPath & "/Scan")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Me._twain32.CloseDataSource()
            Me._twain32.SelectSource()
            Me._twain32.OpenDataSource()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tmpFile = tmpFile + 1

        Dim FileToSaveAs As String = Application.StartupPath & "/Scan/" & tmpFile & ".jpg"
        PictureBox2.Image.Save(FileToSaveAs, System.Drawing.Imaging.ImageFormat.Jpeg)
        ShowImages()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub _twain32_AcquireCompleted(sender As System.Object, e As System.EventArgs) Handles _twain32.AcquireCompleted

        Try
            If Not Me.PictureBox2.Image Is Nothing Then
                Me.PictureBox2.Image.Dispose()
            End If
            Me.PictureBox2.Image = Me._twain32.GetImage(0)
            Me._twain32.CloseDSM()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DrawPictureBox(ByVal _filename As String, ByVal _displayname As String, ByVal person_name As String)
        Dim Pic1 As New PictureBox
        Dim La1 As New Label

        'CreateGallery()

        Pic1.Location = New System.Drawing.Point(XLocation, YLocation)
        La1.Location = New System.Drawing.Point(XLocation, YLocation + 120)
        XLocation = XLocation + PicWidth + 30
        If XLocation + PicWidth >= Panel1.Width Then
            XLocation = 25
            YLocation = YLocation + PicHeight + 30
        End If
        Pic1.Name = _displayname
        La1.Name = "Label" & x + 100
        x += 1
        Pic1.Size = New System.Drawing.Size(PicWidth, PicHeight)
        La1.Size = New System.Drawing.Size(130, 30)
        Pic1.TabIndex = 0
        Pic1.TabStop = False
        Pic1.BorderStyle = BorderStyle.Fixed3D
        Panel1.Controls.Add(Pic1)
        Panel1.Controls.Add(La1)

        Dim xx As Image
        Using str As Stream = File.OpenRead(_filename)
            xx = Image.FromStream(str)
        End Using
        Pic1.Image = xx
        'Pic1.Image = Image.FromFile(_filename)
        'Pic1.Load(_filename)
        La1.Text = person_name
        Pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        AddHandler Pic1.MouseEnter, AddressOf Pic1_MouseEnter
        AddHandler Pic1.MouseLeave, AddressOf Pic1_MouseLeave
        AddHandler La1.MouseClick, AddressOf La1_MouseClick
        AddHandler Pic1.MouseClick, AddressOf Pic1_MouseClick


    End Sub
    Private Sub Pic1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Pic As PictureBox
        Pic = sender
        Pic.BorderStyle = BorderStyle.FixedSingle
        'TextBox1.Text = Pic.Name
    End Sub
    Private Sub Pic1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Pic As PictureBox
        Pic = sender
        Pic.BorderStyle = BorderStyle.Fixed3D
        'TextBox1.Text = Pic.Name

    End Sub
    Private Sub Pic1_MouseClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Pic As PictureBox
        Pic = sender
        Pic.BorderStyle = BorderStyle.Fixed3D
        tmpDelete = Pic.Name
    End Sub
    Private Sub La1_MouseClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim La As Label
        La = sender
        tmpDelete = La.Name
    End Sub
    Private Sub ShowImages()
        Panel1.Controls.Clear()
        XLocation = 10
        YLocation = 10
        PicWidth = 100
        PicHeight = 120

        chkFileList = System.IO.Directory.GetFiles(Application.StartupPath & "\Scan", "*.jpg")
        fileListUC = chkFileList.Clone
        For i As Integer = 0 To fileListUC.Length - 1
            fileListUC(i) = System.IO.Path.GetFileNameWithoutExtension(chkFileList(i))
            DrawPictureBox(Application.StartupPath & "\Scan\" & fileListUC(i) & ".jpg", fileListUC(i), fileListUC(i))
        Next
    End Sub
    Private Sub RemoveControls()
Again:  For Each ctrl As Control In Panel1.Controls
            If TypeOf (ctrl) Is PictureBox Then
                Me.Controls.Remove(ctrl)
            End If
        Next
        If Me.Controls.Count > 0 Then
            GoTo Again
        End If
    End Sub
    Private Function PadExt(ByVal s As String) As String
        s = UCase(s)
        If s.Length > 3 Then
            s = s.Substring(1, 3)
        End If
        Return s
    End Function
    Function GetPageCount(ByVal sFolderPath As String) As Integer
        Dim iRet As Integer = 0
        Dim oFiles As String() = Directory.GetFiles(sFolderPath)

        For i As Integer = 0 To oFiles.Length - 1
            Dim sFromFilePath As String = oFiles(i)
            Dim oFileInfo As New FileInfo(sFromFilePath)
            Dim sFileType As String = "JPG"
            Dim sExt As String = PadExt(oFileInfo.Extension)

            Select Case sFileType
                Case "All"
                    If sExt = "PDF" Then
                        iRet += 1
                    ElseIf sExt = "JPG" Or sExt = "TIF" Then
                        iRet += 1
                    End If

                Case "PDF"
                    If sExt = "PDF" Then
                        iRet += 1
                    End If

                Case "JPG", "TIF"
                    If sExt = "JPG" Or sExt = "TIF" Then
                        iRet += 1
                    End If
            End Select
        Next

        Return iRet
    End Function
    Private Sub ProccessFolder(ByVal sFolderPath As String)

        Dim bOutputfileAlreadyExists As Boolean = False
        Dim oFolderInfo As New System.IO.DirectoryInfo(sFolderPath)
        Dim sOutFilePath As String = sFolderPath & "\tmpDoc.pdf"

        Dim iPageCount As Integer = GetPageCount(sFolderPath)
        If iPageCount > 0 And bOutputfileAlreadyExists = False Then
            'txtOutput.Text += "Processing folder: " & sFolderPath & " - " & iPageCount & " files." & vbCrLf

            Dim oFiles As String() = Directory.GetFiles(sFolderPath)
            'ProgressBar1.Maximum = oFiles.Length

            Dim oPdfDoc As New iTextSharp.text.Document()
            Dim oPdfWriter As PdfWriter = PdfWriter.GetInstance(oPdfDoc, New FileStream(sOutFilePath, FileMode.Create))

            oPdfDoc.Open()

            System.Array.Sort(Of String)(oFiles)

            For i As Integer = 0 To oFiles.Length - 1
                Dim sFromFilePath As String = oFiles(i)
                Dim oFileInfo As New FileInfo(sFromFilePath)
                Dim sFileType As String = "JPG"
                Dim sExt As String = PadExt(oFileInfo.Extension)

                Try
                    If sExt = "JPG" Or sExt = "TIF" Then
                        AddImage(sFromFilePath, oPdfDoc, oPdfWriter, sExt)
                    End If

                Catch ex As Exception
                    'txtOutput.Text += sFromFilePath & vbTab & ex.Message & vbCrLf
                End Try
            Next

            Try
                oPdfDoc.Close()
                oPdfWriter.Close()
            Catch ex As Exception
                'txtOutput.Text += ex.Message & vbCrLf
                Try
                    IO.File.Delete(sOutFilePath)
                Catch ex2 As Exception
                End Try
            End Try

            'ProgressBar1.Value = 0
        End If

        Dim oFolders As String() = Directory.GetDirectories(sFolderPath)
        For i As Integer = 0 To oFolders.Length - 1
            Dim sChildFolder As String = oFolders(i)
            Dim iPos As Integer = sChildFolder.LastIndexOf("\")
            Dim sFolderName As String = sChildFolder.Substring(iPos + 1)
            ProccessFolder(sChildFolder)
        Next



    End Sub

    Sub AddImage(ByVal sInFilePath As String, ByRef oPdfDoc As iTextSharp.text.Document, ByRef oPdfWriter As PdfWriter, ByVal sExt As String)

        'AddBookmark(oPdfDoc, sInFilePath)
        Dim oDirectContent As iTextSharp.text.pdf.PdfContentByte = oPdfWriter.DirectContent
            Dim oPdfImage As iTextSharp.text.Image
            oPdfImage = iTextSharp.text.Image.GetInstance(sInFilePath)
            oPdfImage.SetAbsolutePosition(1, 1)
            oPdfDoc.SetPageSize(New iTextSharp.text.Rectangle(oPdfImage.Width, oPdfImage.Height))
            oPdfDoc.NewPage()
            oDirectContent.AddImage(oPdfImage)
            Exit Sub

        Dim oImage As System.Drawing.Image = System.Drawing.Image.FromFile(sInFilePath)


        AddImage2(oImage, oPdfDoc, oPdfWriter)
        oImage.Dispose()

    End Sub
    Sub AddImage2(ByRef oImage As System.Drawing.Image, ByRef oPdfDoc As iTextSharp.text.Document, ByRef oPdfWriter As PdfWriter)

        Dim oDirectContent As iTextSharp.text.pdf.PdfContentByte = oPdfWriter.DirectContent
        Dim oPdfImage As iTextSharp.text.Image
        Dim iWidth As Single = oImage.Width
        Dim iHeight As Single = oImage.Height
        Dim iAspectRatio As Double = iWidth / iHeight

        Dim iWidthPage As Single = 0
        Dim iHeightPage As Single = 0

        If iAspectRatio < 1 Then
            'Landscape image
            iWidthPage = iTextSharp.text.PageSize.LETTER.Width
            iHeightPage = iTextSharp.text.PageSize.LETTER.Height
        Else
            iHeightPage = iTextSharp.text.PageSize.LETTER.Width
            iWidthPage = iTextSharp.text.PageSize.LETTER.Height
        End If

        Dim iPageAspectRatio As Double = iWidthPage / iHeightPage

        Dim iWidthGoal As Single = 0
        Dim iHeightGoal As Single = 0
        Dim bFitsWithin As Boolean = False

        If iWidth < iWidthPage And iHeight < iHeightPage Then
            'Image fits within the page
            bFitsWithin = True
            iWidthGoal = iWidth
            iHeightGoal = iHeight

        ElseIf iAspectRatio > iPageAspectRatio Then
            'Width is too big
            iWidthGoal = iWidthPage
            iHeightGoal = iWidthPage * (iHeight / iWidth)

        Else
            'Height is too big
            iWidthGoal = iHeightPage * (iWidth / iHeight)
            iHeightGoal = iHeightPage
        End If

        If bFitsWithin = False Then
            oImage = FixedSize(oImage, iWidthGoal, iHeightGoal)
            'oImage.Save("C:\temp\folder1\Lilly_copy.jpg")
        End If

        oPdfImage = iTextSharp.text.Image.GetInstance(oImage, System.Drawing.Imaging.ImageFormat.Png)
        oPdfImage.SetAbsolutePosition(1, 1)

        If iAspectRatio < 1 Then
            'Landscape image
            oPdfDoc.SetPageSize(iTextSharp.text.PageSize.LETTER)
        Else
            oPdfDoc.SetPageSize(iTextSharp.text.PageSize.LETTER.Rotate())
        End If

        oPdfDoc.NewPage()
        oPdfImage.ScaleAbsolute(iWidthGoal, iHeightGoal)
        oDirectContent.AddImage(oPdfImage)

    End Sub
    Private Function FixedSize(ByVal imgPhoto As System.Drawing.Image, ByVal Width As Integer, ByVal Height As Integer) As System.Drawing.Image


        Dim iResizeResolution As Double = CDbl(100) / 100
        Width = Width * iResizeResolution
        Height = Height * iResizeResolution

        Dim sourceWidth As Integer = imgPhoto.Width
        Dim sourceHeight As Integer = imgPhoto.Height
        Dim sourceX As Integer = 0
        Dim sourceY As Integer = 0
        Dim destX As Integer = 0
        Dim destY As Integer = 0

        Dim nPercent As Single = 0
        Dim nPercentW As Single = 0
        Dim nPercentH As Single = 0

        nPercentW = (CSng(Width) / CSng(sourceWidth))
        nPercentH = (CSng(Height) / CSng(sourceHeight))

        If nPercentH < nPercentW Then
            nPercent = nPercentH
            destX = CInt(((Width - (sourceWidth * nPercent)) / 2))
        Else
            nPercent = nPercentW
            destY = CInt(((Height - (sourceHeight * nPercent)) / 2))
        End If

        Dim destWidth As Integer = CInt((sourceWidth * nPercent))
        Dim destHeight As Integer = CInt((sourceHeight * nPercent))

        Dim bmPhoto As New Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution)

        Dim grPhoto As Graphics = Graphics.FromImage(bmPhoto)
        grPhoto.Clear(Color.White)
        grPhoto.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic

        grPhoto.DrawImage(imgPhoto, New Rectangle(destX, destY, destWidth, destHeight), _
          New Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel)

        grPhoto.Dispose()
        imgPhoto.Dispose()

        Return bmPhoto
    End Function

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        ProccessFolder(Application.StartupPath & "\Scan")
        XtraMessageBox.Show("สร้างไฟล์ pdf เรียบร้อยแล้ว", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If tmpDelete <> "" Then
            If XtraMessageBox.Show("คุณต้องการลบไฟล์ภาพนี้ใช่หรือไม่?", vProgram, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = System.Windows.Forms.DialogResult.Yes Then
                If File.Exists(Application.StartupPath & "\Scan\" & tmpDelete & ".jpg") Then

                    Panel1.Controls.Clear()

                    File.Delete(Application.StartupPath & "\Scan\" & tmpDelete & ".jpg")
                End If
                ShowImages()
            End If
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Me._twain32.Acquire()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        Try
            Me._twain32.CloseDataSource()
            Me._twain32.SourceIndex = ComboBox1.SelectedIndex
            Me._twain32.OpenDataSource()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
