Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsdataBus = MyPCU.ClsBusiness
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports clsDataAcc6 = MyPCU.ClsDataAccess6
Imports clsdataBus6 = MyPCU.ClsBusiness6
Imports clsbusent6 = MyPCU.ClsBusinessEntity6
Imports System.Threading
Imports DPUruNet
Imports DPUruNet.Constants
Imports System.Drawing  'for bitmap
Imports System.Drawing.Imaging  'for bitmap display
Delegate Sub MyDelegate()
Public Class frmFingerPrint
    Public adapter As MySql.Data.MySqlClient.MySqlDataAdapter
    Public dataSet As System.Data.DataSet
    Dim fpReader As DPUruNet.Reader
    Dim enrollThread As System.Threading.Thread
    Dim bContinueEnroll As Boolean
    Dim fmdLeftIndex As Fmd 'temporarily store enrollment data to be saved to db
    Dim fmdRightIndex As Fmd 'temporarily store enrollment data to be saved to db
    Private Sub frmFingerPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim strDataSource6 As String = ""
        Dim strUserID6 As String = ""
        Dim strPassword6 As String = ""
        Dim strPort6 As String = ""
        Dim strDatabasename6 As String = ""

        SplashScreenManager1.ShowWaitForm()
        Dim strDataSource5 As String = ""
        Dim strUserID5 As String = ""
        Dim strPassword5 As String = ""
        Dim strPort5 As String = ""
        Dim strDatabasename5 As String = ""
        Dim dsc As DataSet
        dsc = clsdataBus.Lc_Business.SELECT_TABLE("*", "l_config_mypcu_pro", " WHERE ROWID = '09' ")
        If dsc.Tables(0).Rows.Count > 0 Then
            strDataSource6 = dsc.Tables(0).Rows(0).Item("HOST")
            strUserID6 = dsc.Tables(0).Rows(0).Item("USERNAME")
            strPassword6 = dsc.Tables(0).Rows(0).Item("PASSWORD")
            strPort6 = dsc.Tables(0).Rows(0).Item("PORT")
            strDatabasename6 = dsc.Tables(0).Rows(0).Item("DATABASENAME")
            clsDataAcc6.G_DBIPServer6 = strDataSource6
            clsDataAcc6.G_DBPortServer6 = strPort6
            clsDataAcc6.G_DBUserName6 = strUserID6
            clsDataAcc6.G_DBPassword6 = strPassword6
            clsDataAcc6.G_DBName6 = strDatabasename6

        End If

        SplashScreenManager1.CloseWaitForm()


    End Sub

    Private Sub EnrollmentThread()
        'Get reference to which checkbox user clicked
        Dim ckbReference As System.Windows.Forms.CheckBox = Nothing
        If (ckbLeftIndex.Enabled <> True And ckbLeftIndex.Checked <> True) Then
            ckbReference = ckbLeftIndex
        Else : ckbReference = ckbRightIndex
        End If

        fpReader = DPUruNet.ReaderCollection.GetReaders().Item(0)

        If (fpReader Is Nothing) Then
            MessageBox.Show("ไม่พบเครื่องสแกนลายนิ้วมือ โปรดตรวจสอบการเชื่อมต่อเครื่องอีกครั้ง")
            BeginInvoke(Function()
                            If (ckbLeftIndex.Checked = False) Then
                                ckbLeftIndex.Enabled = True
                            End If
                            If (ckbRightIndex.Checked = False) Then
                                ckbRightIndex.Enabled = True
                            End If
                            Return True
                        End Function)
            Return
        End If

        'Begin image capture

        Dim result As Constants.ResultCode = Constants.ResultCode.DP_DEVICE_FAILURE

        result = fpReader.Open(Constants.CapturePriority.DP_PRIORITY_COOPERATIVE)
        If result <> Constants.ResultCode.DP_SUCCESS Then
            BeginInvoke(Function()
                            MessageBox.Show("ไม่สามารถเปิดอุปกรณ์ได้ โปรดตรวจสอบการเชื่อมต่อเครื่องอีกครั้งหรือเครื่องอ่านอาจถูกใช้งานกับโปรแกรมอื่นอยู่")
                            If (ckbLeftIndex.Checked = False) Then
                                ckbLeftIndex.Enabled = True
                            End If
                            If (ckbRightIndex.Checked = False) Then
                                ckbRightIndex.Enabled = True
                            End If
                            Return True
                        End Function)
            Return
        End If

        Dim fmds As New List(Of Fmd)

        'Inform user to press finger 4 times
        BeginInvoke(Function()
                        lblInfo.Text = "วางนิ้ว (แนะนำนิ้วโป้ง) บนเครื่องสแกนอย่างน้อย 4 ครั้ง"
                        Return True
                    End Function)

        Dim count As Integer = 4 'Track remaining press before trying to create enrollment FMD
        Dim pressCount As Integer = 0 'Used to limit amount of presses before determining user should register a different finger

        'Capture image
        While (bContinueEnroll)

            result = fpReader.GetStatus()

            If (result <> ResultCode.DP_SUCCESS) Then
                BeginInvoke(Function()
                                lblInfo.Text = "การจับภาพล้มเหลว :" & result.ToString()
                                If (ckbLeftIndex.Checked = False) Then
                                    ckbLeftIndex.Enabled = True
                                End If
                                If (ckbRightIndex.Checked = False) Then
                                    ckbRightIndex.Enabled = True
                                End If
                                Return True
                            End Function)
                Exit While
            End If

            'Notify app device is busy if state is 'busy'
            If (fpReader.Status.Status = ReaderStatuses.DP_STATUS_BUSY) Then
                Thread.Sleep(100)
                BeginInvoke(Function()
                                lblInfo.Text = "อุปกรณ์กำลังทำงาน"
                                Return True
                            End Function)
                Continue While

                'Device needs to be calibrate.  Calibrate it.
            ElseIf (fpReader.Status.Status = ReaderStatuses.DP_STATUS_NEED_CALIBRATION) Then
                fpReader.Calibrate()
                Continue While

                'Device was not ready but isn't busy.  Continue polling device until ready.
            ElseIf (fpReader.Status.Status <> ReaderStatuses.DP_STATUS_READY) Then
                BeginInvoke(Function()
                                lblInfo.Text = "อุปกรณ์ไม่พร้อมใช้งาน"
                                Return True
                            End Function)
                Thread.Sleep(100)
                Continue While
            End If

            'Capture image.  Wait indefinitely for image.
            Dim captureResult = fpReader.Capture(Formats.Fid.ISO, _
                                               CaptureProcessing.DP_IMG_PROC_DEFAULT, _
                                               -1, _
                                               fpReader.Capabilities.Resolutions(0))

            If (captureResult.ResultCode <> ResultCode.DP_SUCCESS) Then
                BeginInvoke(Function()
                                lblInfo.Text = "การจับภาพล้มเหลว : " & captureResult.ResultCode.ToString()
                                If (ckbLeftIndex.Checked = False) Then
                                    ckbLeftIndex.Enabled = True
                                End If
                                If (ckbRightIndex.Checked = False) Then
                                    ckbRightIndex.Enabled = True
                                End If
                                Return True
                            End Function)
                Exit While
            End If

            If (captureResult.Quality = CaptureQuality.DP_QUALITY_CANCELED) Then
                BeginInvoke(Function()
                                lblInfo.Text = "การจับภาพล้มเหลว : " & captureResult.ResultCode.ToString()
                                If (ckbLeftIndex.Checked = False) Then
                                    ckbLeftIndex.Enabled = True
                                End If
                                If (ckbRightIndex.Checked = False) Then
                                    ckbRightIndex.Enabled = True
                                End If
                                Return True
                            End Function)

                Exit While
            End If

            If (captureResult.Quality = CaptureQuality.DP_QUALITY_NO_FINGER _
                Or captureResult.Quality = CaptureQuality.DP_QUALITY_TIMED_OUT) Then
                BeginInvoke(Function()
                                lblInfo.Text = "หมดเวลาการจับภาพ : " & captureResult.ResultCode.ToString()
                                If (ckbLeftIndex.Checked = False) Then
                                    ckbLeftIndex.Enabled = True
                                End If
                                If (ckbRightIndex.Checked = False) Then
                                    ckbRightIndex.Enabled = True
                                End If
                                Return True
                            End Function)

                Exit While
            End If

            If (captureResult.Quality = CaptureQuality.DP_QUALITY_FAKE_FINGER) Then
                BeginInvoke(Function()
                                lblInfo.Text = "การจับภาพล้มเหลว กรุณาลองอีกครั้ง : " & captureResult.ResultCode.ToString()
                                Return True
                            End Function)
                Continue While
            End If


            'We assume image was captured at this point.  Now display the image.
            pressCount = pressCount + 1
            Dim FPBitmap As Bitmap = CreateBitmap(captureResult.Data.Views(0).RawImage, captureResult.Data.Views(0).Width, captureResult.Data.Views(0).Height)

            Dim pbIndex As Integer = 4 - count

            If (pbIndex = 0) Then
                pbPrint1.Image = New Bitmap(FPBitmap, pbPrint1.Width, pbPrint1.Height)
            ElseIf (pbIndex = 1) Then
                pbPrint2.Image = New Bitmap(FPBitmap, pbPrint2.Width, pbPrint2.Height)
            ElseIf (pbIndex = 2) Then
                pbPrint3.Image = New Bitmap(FPBitmap, pbPrint3.Width, pbPrint3.Height)
            ElseIf (pbIndex = 3) Then
                pbPrint4.Image = New Bitmap(FPBitmap, pbPrint4.Width, pbPrint4.Height)
            End If



            'Extract pre-registration fmd from image
            Dim resultConversion As DataResult(Of Fmd) = FeatureExtraction.CreateFmdFromFid(captureResult.Data, Formats.Fmd.ISO)




            If resultConversion.ResultCode <> ResultCode.DP_SUCCESS Then
                BeginInvoke(Function()
                                lblInfo.Text = "ไม่สามารถสร้างไฟล์ได้ : " & captureResult.ResultCode.ToString()
                                Return True
                            End Function)
                Continue While
            End If

            fmds.Add(resultConversion.Data)

            count = count - 1

            If count = 0 Then 'Ready to try and create enrollment FMD

                Dim resultEnrollment As DataResult(Of Fmd) = DPUruNet.Enrollment.CreateEnrollmentFmd(Formats.Fmd.ISO, fmds)

                'Check for successfull enrollment
                If resultEnrollment.ResultCode = ResultCode.DP_SUCCESS Then


                    BeginInvoke(Function()
                                    lblInfo.Text = "การสแกนลายนิ้วมือเสร็จสิ้น "
                                    ckbReference.Checked = True
                                    If (ckbReference.Name = "ckbLeftIndex") Then
                                        fmdLeftIndex = resultEnrollment.Data
                                        If (ckbRightIndex.Checked <> True) Then
                                            ckbRightIndex.Enabled = True
                                        End If
                                    Else
                                        fmdRightIndex = resultEnrollment.Data
                                        If (ckbLeftIndex.Checked <> True) Then
                                            ckbLeftIndex.Enabled = True
                                        End If
                                    End If

                                    Return (True)
                                End Function)
                    Exit While


                ElseIf resultEnrollment.ResultCode = ResultCode.DP_FAILURE Then
                    BeginInvoke(Function()
                                    lblInfo.Text = "ไม่สามารถดำเนินการได้  ลองนิ้วอื่นๆ"
                                    Return True
                                End Function)
                    fmds.Clear()
                    count = 4
                    Continue While
                End If
            End If

            If count = 0 Then 'This means we need to press again
                count = count + 1
            End If

            If pressCount = 8 Then 'Limit enrollment to 8 presses
                BeginInvoke(Function()
                                MessageBox.Show("ไม่สามารถดำเนินการได้  ลองนิ้วอื่นๆ")
                                If (ckbLeftIndex.Checked = False) Then
                                    ckbLeftIndex.Enabled = True
                                End If
                                If (ckbRightIndex.Checked = False) Then
                                    ckbRightIndex.Enabled = True
                                End If
                                ClearPrintImages()
                                Return True
                            End Function)
                Exit While
            End If

            BeginInvoke(Function()
                            lblInfo.Text = "การสแกนสำเร็จ กรุณาวางนิ้วเดิมอีก " & count & " ครั้ง"
                            Return True
                        End Function)
        End While

        fpReader.Dispose()
        fpReader = Nothing

    End Sub

    Private Sub ckbLeftIndex_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ckbLeftIndex.CheckedChanged
        If Not ckbLeftIndex.Checked Or ckbLeftIndex.Enabled = False Then
            Return
        End If

        'Reset images
        pbPrint1.Image = Nothing
        pbPrint2.Image = Nothing
        pbPrint3.Image = Nothing
        pbPrint4.Image = Nothing

        ckbLeftIndex.Checked = False 'Set to false.  Only check if enrollment succeeded at end of operation
        ckbLeftIndex.Enabled = False
        ckbRightIndex.Enabled = False 'Prevent user from launching a seperate enrollment thread until current enrollment is complete
        bContinueEnroll = True
        enrollThread = New System.Threading.Thread(AddressOf Me.EnrollmentThread)
        enrollThread.IsBackground = True 'If not set, process stays in background if main thread exits.
        enrollThread.Start()



    End Sub
    Private Sub ckbRightIndex_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ckbRightIndex.CheckedChanged
        If Not ckbRightIndex.Checked Or ckbRightIndex.Enabled = False Then
            Return
        End If

        'Reset images
        pbPrint1.Image = Nothing
        pbPrint2.Image = Nothing
        pbPrint3.Image = Nothing
        pbPrint4.Image = Nothing

        ckbRightIndex.Checked = False 'Set to false.  Only check if enrollment succeeded
        ckbRightIndex.Enabled = False
        ckbLeftIndex.Enabled = False
        bContinueEnroll = True
        enrollThread = New System.Threading.Thread(AddressOf Me.EnrollmentThread)
        enrollThread.IsBackground = True 'If not set, process stays in background if main thread exits.
        enrollThread.Start()

    End Sub

    Private Sub btnSubmit_Click(sender As System.Object, e As System.EventArgs) Handles btnSubmit.Click
        If (ValidateSubmit() = False) Then
            MessageBox.Show("ไม่สามารถบันทึกได้!!!")
            Return
        End If
        Dim ds As DataSet
        ds = clsdataBus6.Lc_Business6.SELECT_TABLE("CID", " m_fingerprint ", " WHERE CID = '" & vfgCID & "' ")
        If ds.Tables(0).Rows.Count > 0 Then
            Try
                clsbusent6.Lc_BusinessEntity6.UpdateM_table("m_fingerprint ", " print1 = '" & Fmd.SerializeXml(fmdLeftIndex) & "',print2 = '" & Fmd.SerializeXml(fmdRightIndex) & "'", " CID = '" & vfgCID & "'")
            Catch ex As Exception
                MessageBox.Show("Error registering user: " & ex.Message)
            End Try
        Else
            Try
                clsbusent6.Lc_BusinessEntity6.InsertM_table("m_fingerprint (CID,print1,print2)",
            "'" & vfgCID & "','" & Fmd.SerializeXml(fmdLeftIndex) & "','" & Fmd.SerializeXml(fmdRightIndex) & "'")
            Catch ex As Exception
                MessageBox.Show("Error registering user: " & ex.Message)
            End Try
        End If



        Me.Close()

    End Sub

    Private Function ValidateSubmit() As Boolean
        If (fmdLeftIndex Is Nothing Or fmdRightIndex Is Nothing) Then
            Return False
        End If


        Return True
    End Function

    Private Function CreateBitmap(ByVal bytes As [Byte](), ByVal width As Integer, ByVal height As Integer) As Bitmap
        Dim rgbBytes As Byte() = New Byte(bytes.Length * 3 - 1) {}

        For i As Integer = 0 To bytes.Length - 1
            rgbBytes((i * 3)) = bytes(i)
            rgbBytes((i * 3) + 1) = bytes(i)
            rgbBytes((i * 3) + 2) = bytes(i)
        Next
        Dim bmp As New Bitmap(width, height, PixelFormat.Format24bppRgb)

        Dim data As BitmapData = bmp.LockBits(New Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.[WriteOnly], PixelFormat.Format24bppRgb)

        If IntPtr.Size = 8 Then
            For i As Integer = 0 To bmp.Height - 1
                Dim p As New IntPtr(data.Scan0.ToInt64() + data.Stride * i)
                System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3)
            Next

        Else
            For i As Integer = 0 To bmp.Height - 1
                Dim p As New IntPtr(data.Scan0.ToInt32() + data.Stride * i)
                System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3)
            Next

        End If

        bmp.UnlockBits(data)

        Return bmp
    End Function

    Private Sub ClearPrintImages()
        pbPrint1.Image = Nothing
        pbPrint2.Image = Nothing
        pbPrint3.Image = Nothing
        pbPrint4.Image = Nothing
    End Sub

    Private Sub frmFingerPrint_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        bContinueEnroll = False

        If fpReader IsNot Nothing Then
            fpReader.CancelCapture()
            fpReader.Dispose()
        End If

        If enrollThread IsNot Nothing Then
            enrollThread.Join(3000)
        End If
    End Sub
End Class