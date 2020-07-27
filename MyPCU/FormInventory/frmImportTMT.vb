Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports System.IO
Imports ExcelDataReader
Imports DevExpress.XtraEditors
Public Class frmImportTMT

    Dim sbr1 As String = ""
    Dim strFolder As String = ""

    Private Sub frmImportTMT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdBrowse_Click(sender As Object, e As EventArgs) Handles cmdBrowse.Click
        Dim opf As XtraOpenFileDialog = New XtraOpenFileDialog

        opf.Filter = "zip files (*.zip)|*.*|zip files (*.zip)|*.zip"
        opf.FilterIndex = 0
        opf.RestoreDirectory = True


        If opf.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim stFilePathAndName As String = opf.FileName
            Dim MyFile As IO.FileInfo = New IO.FileInfo(stFilePathAndName)

            txtFilename.Text = MyFile.Name
            sbr1 = opf.FileName
            strFolder = System.IO.Path.GetFileNameWithoutExtension(MyFile.Name)
        End If


    End Sub

    Private Sub cmdImport_Click(sender As Object, e As EventArgs) Handles cmdImport.Click
        If txtFilename.Text <> "" Then
            SplashScreenManager1.ShowWaitForm()
            If Directory.Exists(Application.StartupPath & "\Import\TMT") = False Then
                Directory.CreateDirectory(Application.StartupPath & "\Import\TMT")
                ClsUnzip.unzip.ExtractArchive(sbr1, Application.StartupPath & "\Import\TMT")
            Else
                Directory.Delete(Application.StartupPath & "\Import\TMT", True)
                Directory.CreateDirectory(Application.StartupPath & "\Import\TMT")
                ClsUnzip.unzip.ExtractArchive(sbr1, Application.StartupPath & "\Import\TMT")
            End If
            If CheckBox1.Checked = True Then
                ImportTMTFull()
            End If
            If CheckBox2.Checked = True Then
                ImportTMTgp()
            End If
            If CheckBox3.Checked = True Then
                ImportTMTsubs()
            End If
            If CheckBox4.Checked = True Then
                ImportTMTvtm()
            End If
            If CheckBox5.Checked = True Then
                ImportTMTgpu()
            End If
            If CheckBox6.Checked = True Then
                ImportTMTtp()
            End If
            ImportTMTtpToTpu()
            ImportTMTgpuToTpu()
            ImportTMTgpToTp()
            ImportTMTgpToGpu()
            ImportTMTvtmtoGP()
            ImportTMTsubsToVtm()
            SplashScreenManager1.CloseWaitForm()
        Else
            XtraMessageBox.Show("โปรดระบุไฟล์ที่ต้องการนำเข้าก่อน!!!", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmdBrowse.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub ImportTMTFull()

        Try
            Using stream As FileStream = File.Open(Application.StartupPath & "\Import\TMT\" & strFolder & "\" & strFolder & "_FULL.xls", FileMode.Open, FileAccess.Read)
                Dim excelReader As IExcelDataReader = ExcelReaderFactory.CreateBinaryReader(stream)
                Dim tmpFileCount As Integer = excelReader.FieldCount
                If excelReader.FieldCount <> 8 Then
                    XtraMessageBox.Show("โครงสร้างไฟล์นำเข้าไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                ProgressBarControl1.Visible = True
                ProgressBarControl1.Properties.Maximum = 100
                ProgressBarControl1.EditValue = 0

                Dim tmpROW As Integer = excelReader.RowCount
                Dim i As Integer = 0
                While excelReader.Read()
                    If i > 0 Then
                        Try
                            Dim tmpA As String = excelReader.GetValue(0)
                            Dim tmpB As String = excelReader.GetValue(1).ToString.Replace("'", "''").Replace(" (TPU)", "")
                            Dim tmpC As String = excelReader.GetValue(2).ToString.Replace("'", "''")
                            Dim tmpD As String = excelReader.GetValue(3)
                            Dim tmpE As String = excelReader.GetValue(4)
                            Dim tmpF As String = excelReader.GetValue(5)
                            Dim tmpG As String = excelReader.GetValue(6)
                            Dim tmpH As String = excelReader.GetValue(7)

                            Dim ds As DataSet
                            ds = clsdataBus.Lc_Business.SELECT_TABLE("TMTID", " l_tmt_full ", " WHERE TMTID = '" & tmpA & "' ")
                            If ds.Tables(0).Rows.Count = 0 Then

                                clsbusent.Lc_BusinessEntity.Insertm_table(" l_tmt_full (TMTID,FSN,MANUFACTURER,CHANGEDATE,ISSUEDATE,EFFECTIVEDATE,INVALIDDATE,INVALID) ",
                                   "'" & tmpA & "','" & tmpB & "','" & tmpC & "','" & tmpD & "','" & tmpE & "','" & tmpF & "','" & tmpG & "','" & tmpH & "'")
                            Else
                                clsbusent.Lc_BusinessEntity.Updatem_table("l_tmt_full", "FSN = '" & tmpB & "',MANUFACTURER = '" & tmpC & "'" _
                                          & ",CHANGEDATE = '" & tmpD & "',ISSUEDATE = '" & tmpE & "',EFFECTIVEDATE = '" & tmpF & "',INVALIDDATE = '" & tmpG & "',INVALID = '" & tmpH & "'",
                                    "TMTID = '" & tmpA & "'")
                            End If


                        Catch ex As Exception

                        End Try
                    End If
                    i += 1
                    ProgressBarControl1.EditValue = (i + 1) * 100 / tmpROW
                    ProgressBarControl1.Refresh()
                    ProgressBarControl1.EditValue = 100

                End While
            End Using
        Catch ex As Exception
            XtraMessageBox.Show("ไม่สามารถดำเนินการได้ ไฟล์อาจมีการเปิดอยู่!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub ImportTMTgp()

        Try
            Using stream As FileStream = File.Open(Application.StartupPath & "\Import\TMT\" & strFolder & "_BONUS\Concept\" & strFolder.ToString.Replace("TMTRF", "GP") & ".xls", FileMode.Open, FileAccess.Read)
                Dim excelReader As IExcelDataReader = ExcelReaderFactory.CreateBinaryReader(stream)
                Dim tmpFileCount As Integer = excelReader.FieldCount
                If excelReader.FieldCount <> 3 Then
                    XtraMessageBox.Show("โครงสร้างไฟล์นำเข้าไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                ProgressBarControl2.Visible = True
                ProgressBarControl2.Properties.Maximum = 100
                ProgressBarControl2.EditValue = 0

                Dim tmpROW As Integer = excelReader.RowCount
                Dim i As Integer = 0
                While excelReader.Read()
                    If i > 0 Then
                        Try
                            Dim tmpA As String = excelReader.GetValue(0)
                            Dim tmpB As String = excelReader.GetValue(1).ToString.Replace("'", "''").Replace(" (GP)", "")
                            Dim tmpC As String = excelReader.GetValue(2).ToString.Replace("'", "''")
                            

                            Dim ds As DataSet
                            ds = clsdataBus.Lc_Business.SELECT_TABLE("TMTID", " l_tmt_gp ", " WHERE TMTID = '" & tmpA & "' ")
                            If ds.Tables(0).Rows.Count = 0 Then

                                clsbusent.Lc_BusinessEntity.Insertm_table(" l_tmt_gp (TMTID,FSN,CHANGEDATE) ",
                                   "'" & tmpA & "','" & tmpB & "','" & tmpC & "'")
                            Else
                                clsbusent.Lc_BusinessEntity.Updatem_table("l_tmt_gp", "FSN = '" & tmpB & "',CHANGEDATE = '" & tmpC & "'",
                                    "TMTID = '" & tmpA & "'")
                            End If


                        Catch ex As Exception

                        End Try
                    End If
                    i += 1
                    ProgressBarControl2.EditValue = (i + 1) * 100 / tmpROW
                    ProgressBarControl2.Refresh()
                    ProgressBarControl2.EditValue = 100

                End While
            End Using
        Catch ex As Exception
            XtraMessageBox.Show("ไม่สามารถดำเนินการได้ ไฟล์อาจมีการเปิดอยู่!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub ImportTMTsubs()

        Try
            Using stream As FileStream = File.Open(Application.StartupPath & "\Import\TMT\" & strFolder & "_BONUS\Concept\" & strFolder.ToString.Replace("TMTRF", "SUBS") & ".xls", FileMode.Open, FileAccess.Read)
                Dim excelReader As IExcelDataReader = ExcelReaderFactory.CreateBinaryReader(stream)
                Dim tmpFileCount As Integer = excelReader.FieldCount
                If excelReader.FieldCount <> 3 Then
                    XtraMessageBox.Show("โครงสร้างไฟล์นำเข้าไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                ProgressBarControl3.Visible = True
                ProgressBarControl3.Properties.Maximum = 100
                ProgressBarControl3.EditValue = 0

                Dim tmpROW As Integer = excelReader.RowCount
                Dim i As Integer = 0
                While excelReader.Read()
                    If i > 0 Then
                        Try
                            Dim tmpA As String = excelReader.GetValue(0)
                            Dim tmpB As String = excelReader.GetValue(1).ToString.Replace("'", "''").Replace(" (SUBS)", "")
                            Dim tmpC As String = excelReader.GetValue(2).ToString.Replace("'", "''")


                            Dim ds As DataSet
                            ds = clsdataBus.Lc_Business.SELECT_TABLE("TMTID", " l_tmt_subs ", " WHERE TMTID = '" & tmpA & "' ")
                            If ds.Tables(0).Rows.Count = 0 Then

                                clsbusent.Lc_BusinessEntity.Insertm_table(" l_tmt_subs (TMTID,FSN,CHANGEDATE) ",
                                   "'" & tmpA & "','" & tmpB & "','" & tmpC & "'")
                            Else
                                clsbusent.Lc_BusinessEntity.Updatem_table("l_tmt_subs", "FSN = '" & tmpB & "',CHANGEDATE = '" & tmpC & "'",
                                    "TMTID = '" & tmpA & "'")
                            End If


                        Catch ex As Exception

                        End Try
                    End If
                    i += 1
                    ProgressBarControl3.EditValue = (i + 1) * 100 / tmpROW
                    ProgressBarControl3.Refresh()
                    ProgressBarControl3.EditValue = 100

                End While
            End Using
        Catch ex As Exception
            XtraMessageBox.Show("ไม่สามารถดำเนินการได้ ไฟล์อาจมีการเปิดอยู่!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub ImportTMTvtm()

        Try
            Using stream As FileStream = File.Open(Application.StartupPath & "\Import\TMT\" & strFolder & "_BONUS\Concept\" & strFolder.ToString.Replace("TMTRF", "VTM") & ".xls", FileMode.Open, FileAccess.Read)
                Dim excelReader As IExcelDataReader = ExcelReaderFactory.CreateBinaryReader(stream)
                Dim tmpFileCount As Integer = excelReader.FieldCount
                If excelReader.FieldCount <> 3 Then
                    XtraMessageBox.Show("โครงสร้างไฟล์นำเข้าไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                ProgressBarControl4.Visible = True
                ProgressBarControl4.Properties.Maximum = 100
                ProgressBarControl4.EditValue = 0

                Dim tmpROW As Integer = excelReader.RowCount
                Dim i As Integer = 0
                While excelReader.Read()
                    If i > 0 Then
                        Try
                            Dim tmpA As String = excelReader.GetValue(0)
                            Dim tmpB As String = excelReader.GetValue(1).ToString.Replace("'", "''").Replace(" (VTM)", "")
                            Dim tmpC As String = excelReader.GetValue(2).ToString.Replace("'", "''")


                            Dim ds As DataSet
                            ds = clsdataBus.Lc_Business.SELECT_TABLE("TMTID", " l_tmt_vtm ", " WHERE TMTID = '" & tmpA & "' ")
                            If ds.Tables(0).Rows.Count = 0 Then

                                clsbusent.Lc_BusinessEntity.Insertm_table(" l_tmt_vtm (TMTID,FSN,CHANGEDATE) ",
                                   "'" & tmpA & "','" & tmpB & "','" & tmpC & "'")
                            Else
                                clsbusent.Lc_BusinessEntity.Updatem_table("l_tmt_vtm", "FSN = '" & tmpB & "',CHANGEDATE = '" & tmpC & "'",
                                    "TMTID = '" & tmpA & "'")
                            End If


                        Catch ex As Exception

                        End Try
                    End If
                    i += 1
                    ProgressBarControl4.EditValue = (i + 1) * 100 / tmpROW
                    ProgressBarControl4.Refresh()
                    ProgressBarControl4.EditValue = 100

                End While
            End Using
        Catch ex As Exception
            XtraMessageBox.Show("ไม่สามารถดำเนินการได้ ไฟล์อาจมีการเปิดอยู่!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub ImportTMTgpu()

        Try
            Using stream As FileStream = File.Open(Application.StartupPath & "\Import\TMT\" & strFolder & "_BONUS\Concept\" & strFolder.ToString.Replace("TMTRF", "GPU") & ".xls", FileMode.Open, FileAccess.Read)
                Dim excelReader As IExcelDataReader = ExcelReaderFactory.CreateBinaryReader(stream)
                Dim tmpFileCount As Integer = excelReader.FieldCount
                If excelReader.FieldCount <> 3 Then
                    XtraMessageBox.Show("โครงสร้างไฟล์นำเข้าไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                ProgressBarControl5.Visible = True
                ProgressBarControl5.Properties.Maximum = 100
                ProgressBarControl5.EditValue = 0

                Dim tmpROW As Integer = excelReader.RowCount
                Dim i As Integer = 0
                While excelReader.Read()
                    If i > 0 Then
                        Try
                            Dim tmpA As String = excelReader.GetValue(0)
                            Dim tmpB As String = excelReader.GetValue(1).ToString.Replace("'", "''").Replace(" (GPU)", "")
                            Dim tmpC As String = excelReader.GetValue(2).ToString.Replace("'", "''")


                            Dim ds As DataSet
                            ds = clsdataBus.Lc_Business.SELECT_TABLE("TMTID", " l_tmt_gpu ", " WHERE TMTID = '" & tmpA & "' ")
                            If ds.Tables(0).Rows.Count = 0 Then

                                clsbusent.Lc_BusinessEntity.Insertm_table(" l_tmt_gpu (TMTID,FSN,CHANGEDATE) ",
                                   "'" & tmpA & "','" & tmpB & "','" & tmpC & "'")
                            Else
                                clsbusent.Lc_BusinessEntity.Updatem_table("l_tmt_vtm", "FSN = '" & tmpB & "',CHANGEDATE = '" & tmpC & "'",
                                    "TMTID = '" & tmpA & "'")
                            End If


                        Catch ex As Exception

                        End Try
                    End If
                    i += 1
                    ProgressBarControl5.EditValue = (i + 1) * 100 / tmpROW
                    ProgressBarControl5.Refresh()
                    ProgressBarControl5.EditValue = 100

                End While
            End Using
        Catch ex As Exception
            XtraMessageBox.Show("ไม่สามารถดำเนินการได้ ไฟล์อาจมีการเปิดอยู่!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub ImportTMTtp()

        Try
            Using stream As FileStream = File.Open(Application.StartupPath & "\Import\TMT\" & strFolder & "_BONUS\Concept\" & strFolder.ToString.Replace("TMTRF", "TP") & ".xls", FileMode.Open, FileAccess.Read)
                Dim excelReader As IExcelDataReader = ExcelReaderFactory.CreateBinaryReader(stream)
                Dim tmpFileCount As Integer = excelReader.FieldCount
                If excelReader.FieldCount <> 4 Then
                    XtraMessageBox.Show("โครงสร้างไฟล์นำเข้าไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                ProgressBarControl6.Visible = True
                ProgressBarControl6.Properties.Maximum = 100
                ProgressBarControl6.EditValue = 0

                Dim tmpROW As Integer = excelReader.RowCount
                Dim i As Integer = 0
                While excelReader.Read()
                    If i > 0 Then
                        Try
                            Dim tmpA As String = excelReader.GetValue(0)
                            Dim tmpB As String = excelReader.GetValue(1).ToString.Replace("'", "''").Replace(" (TP)", "")
                            Dim tmpC As String = excelReader.GetValue(2).ToString.Replace("'", "''")
                            Dim tmpD As String = excelReader.GetValue(3)

                            Dim ds As DataSet
                            ds = clsdataBus.Lc_Business.SELECT_TABLE("TMTID", " l_tmt_tp ", " WHERE TMTID = '" & tmpA & "' ")
                            If ds.Tables(0).Rows.Count = 0 Then

                                clsbusent.Lc_BusinessEntity.Insertm_table(" l_tmt_tp (TMTID,FSN,MANUFACTURER,CHANGEDATE) ",
                                   "'" & tmpA & "','" & tmpB & "','" & tmpC & "','" & tmpD & "'")
                            Else
                                clsbusent.Lc_BusinessEntity.Updatem_table("l_tmt_tp", "FSN = '" & tmpB & "',MANUFACTURER = '" & tmpC & "'" _
                                          & ",CHANGEDATE = '" & tmpD & "'",
                                    "TMTID = '" & tmpA & "'")
                            End If


                        Catch ex As Exception

                        End Try
                    End If
                    i += 1
                    ProgressBarControl6.EditValue = (i + 1) * 100 / tmpROW
                    ProgressBarControl6.Refresh()
                    ProgressBarControl6.EditValue = 100

                End While
            End Using
        Catch ex As Exception
            XtraMessageBox.Show("ไม่สามารถดำเนินการได้ ไฟล์อาจมีการเปิดอยู่!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub ImportTMTtpToTpu()

        Try
            Using stream As FileStream = File.Open(Application.StartupPath & "\Import\TMT\" & strFolder & "_BONUS\Relationship\" & strFolder.ToString.Replace("TMTRF", "TPtoTPU") & ".xls", FileMode.Open, FileAccess.Read)
                Dim excelReader As IExcelDataReader = ExcelReaderFactory.CreateBinaryReader(stream)
                Dim tmpFileCount As Integer = excelReader.FieldCount
                If excelReader.FieldCount <> 2 Then
                    XtraMessageBox.Show("โครงสร้างไฟล์นำเข้าไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                ProgressBarControl1.Visible = True
                ProgressBarControl1.Properties.Maximum = 100
                ProgressBarControl1.EditValue = 0

                Dim tmpROW As Integer = excelReader.RowCount
                Dim i As Integer = 0
                While excelReader.Read()
                    If i > 0 Then
                        Try
                            Dim tmpA As String = excelReader.GetValue(0)
                            Dim tmpB As String = excelReader.GetValue(1)

                            Dim ds As DataSet
                            ds = clsdataBus.Lc_Business.SELECT_TABLE("TMTID", " l_tmt_full ", " WHERE TMTID = '" & tmpB & "' ")
                            If ds.Tables(0).Rows.Count > 0 Then

                                clsbusent.Lc_BusinessEntity.Updatem_table("l_tmt_full", "TPID = '" & tmpA & "'", "TMTID = '" & tmpB & "'")
                            End If


                        Catch ex As Exception

                        End Try
                    End If
                    i += 1
                    ProgressBarControl1.EditValue = (i + 1) * 100 / tmpROW
                    ProgressBarControl1.Refresh()
                    ProgressBarControl1.EditValue = 100

                End While
            End Using
        Catch ex As Exception
            XtraMessageBox.Show("ไม่สามารถดำเนินการได้ ไฟล์อาจมีการเปิดอยู่!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub ImportTMTgpuToTpu()

        Try
            Using stream As FileStream = File.Open(Application.StartupPath & "\Import\TMT\" & strFolder & "_BONUS\Relationship\" & strFolder.ToString.Replace("TMTRF", "GPUtoTPU") & ".xls", FileMode.Open, FileAccess.Read)
                Dim excelReader As IExcelDataReader = ExcelReaderFactory.CreateBinaryReader(stream)
                Dim tmpFileCount As Integer = excelReader.FieldCount
                If excelReader.FieldCount <> 2 Then
                    XtraMessageBox.Show("โครงสร้างไฟล์นำเข้าไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                ProgressBarControl2.Visible = True
                ProgressBarControl2.Properties.Maximum = 100
                ProgressBarControl2.EditValue = 0

                Dim tmpROW As Integer = excelReader.RowCount
                Dim i As Integer = 0
                While excelReader.Read()
                    If i > 0 Then
                        Try
                            Dim tmpA As String = excelReader.GetValue(0)
                            Dim tmpB As String = excelReader.GetValue(1)

                            Dim ds As DataSet
                            ds = clsdataBus.Lc_Business.SELECT_TABLE("TMTID", " l_tmt_full ", " WHERE TMTID = '" & tmpB & "' ")
                            If ds.Tables(0).Rows.Count > 0 Then

                                clsbusent.Lc_BusinessEntity.Updatem_table("l_tmt_full", "GPUID = '" & tmpA & "'", "TMTID = '" & tmpB & "'")
                            End If


                        Catch ex As Exception

                        End Try
                    End If
                    i += 1
                    ProgressBarControl2.EditValue = (i + 1) * 100 / tmpROW
                    ProgressBarControl2.Refresh()
                    ProgressBarControl2.EditValue = 100

                End While
            End Using
        Catch ex As Exception
            XtraMessageBox.Show("ไม่สามารถดำเนินการได้ ไฟล์อาจมีการเปิดอยู่!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub ImportTMTgpToTp()

        Try
            Using stream As FileStream = File.Open(Application.StartupPath & "\Import\TMT\" & strFolder & "_BONUS\Relationship\" & strFolder.ToString.Replace("TMTRF", "GPtoTP") & ".xls", FileMode.Open, FileAccess.Read)
                Dim excelReader As IExcelDataReader = ExcelReaderFactory.CreateBinaryReader(stream)
                Dim tmpFileCount As Integer = excelReader.FieldCount
                If excelReader.FieldCount <> 2 Then
                    XtraMessageBox.Show("โครงสร้างไฟล์นำเข้าไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                ProgressBarControl3.Visible = True
                ProgressBarControl3.Properties.Maximum = 100
                ProgressBarControl3.EditValue = 0

                Dim tmpROW As Integer = excelReader.RowCount
                Dim i As Integer = 0
                While excelReader.Read()
                    If i > 0 Then
                        Try
                            Dim tmpA As String = excelReader.GetValue(0)
                            Dim tmpB As String = excelReader.GetValue(1)

                            Dim ds As DataSet
                            ds = clsdataBus.Lc_Business.SELECT_TABLE("TMTID", " l_tmt_tp ", " WHERE TMTID = '" & tmpB & "' ")
                            If ds.Tables(0).Rows.Count > 0 Then

                                clsbusent.Lc_BusinessEntity.Updatem_table("l_tmt_tp", "GPID = '" & tmpA & "'", "TMTID = '" & tmpB & "'")
                            End If


                        Catch ex As Exception

                        End Try
                    End If
                    i += 1
                    ProgressBarControl3.EditValue = (i + 1) * 100 / tmpROW
                    ProgressBarControl3.Refresh()
                    ProgressBarControl3.EditValue = 100

                End While
            End Using
        Catch ex As Exception
            XtraMessageBox.Show("ไม่สามารถดำเนินการได้ ไฟล์อาจมีการเปิดอยู่!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    
    Private Sub ImportTMTgpToGpu()

        Try
            Using stream As FileStream = File.Open(Application.StartupPath & "\Import\TMT\" & strFolder & "_BONUS\Relationship\" & strFolder.ToString.Replace("TMTRF", "GPtoGPU") & ".xls", FileMode.Open, FileAccess.Read)
                Dim excelReader As IExcelDataReader = ExcelReaderFactory.CreateBinaryReader(stream)
                Dim tmpFileCount As Integer = excelReader.FieldCount
                If excelReader.FieldCount <> 2 Then
                    XtraMessageBox.Show("โครงสร้างไฟล์นำเข้าไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                ProgressBarControl4.Visible = True
                ProgressBarControl4.Properties.Maximum = 100
                ProgressBarControl4.EditValue = 0

                Dim tmpROW As Integer = excelReader.RowCount
                Dim i As Integer = 0
                While excelReader.Read()
                    If i > 0 Then
                        Try
                            Dim tmpA As String = excelReader.GetValue(0)
                            Dim tmpB As String = excelReader.GetValue(1)

                            Dim ds As DataSet
                            ds = clsdataBus.Lc_Business.SELECT_TABLE("TMTID", " l_tmt_gpu ", " WHERE TMTID = '" & tmpB & "' ")
                            If ds.Tables(0).Rows.Count > 0 Then

                                clsbusent.Lc_BusinessEntity.Updatem_table("l_tmt_gpu", "GPID = '" & tmpA & "'", "TMTID = '" & tmpB & "'")
                            End If


                        Catch ex As Exception

                        End Try
                    End If
                    i += 1
                    ProgressBarControl4.EditValue = (i + 1) * 100 / tmpROW
                    ProgressBarControl4.Refresh()
                    ProgressBarControl4.EditValue = 100

                End While
            End Using
        Catch ex As Exception
            XtraMessageBox.Show("ไม่สามารถดำเนินการได้ ไฟล์อาจมีการเปิดอยู่!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub ImportTMTvtmtoGP()

        Try
            Using stream As FileStream = File.Open(Application.StartupPath & "\Import\TMT\" & strFolder & "_BONUS\Relationship\" & strFolder.ToString.Replace("TMTRF", "VTMtoGP") & ".xls", FileMode.Open, FileAccess.Read)
                Dim excelReader As IExcelDataReader = ExcelReaderFactory.CreateBinaryReader(stream)
                Dim tmpFileCount As Integer = excelReader.FieldCount
                If excelReader.FieldCount <> 2 Then
                    XtraMessageBox.Show("โครงสร้างไฟล์นำเข้าไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                ProgressBarControl5.Visible = True
                ProgressBarControl5.Properties.Maximum = 100
                ProgressBarControl5.EditValue = 0

                Dim tmpROW As Integer = excelReader.RowCount
                Dim i As Integer = 0
                While excelReader.Read()
                    If i > 0 Then
                        Try
                            Dim tmpA As String = excelReader.GetValue(0)
                            Dim tmpB As String = excelReader.GetValue(1)

                            Dim ds As DataSet
                            ds = clsdataBus.Lc_Business.SELECT_TABLE("TMTID", " l_tmt_gp ", " WHERE TMTID = '" & tmpB & "' ")
                            If ds.Tables(0).Rows.Count > 0 Then

                                clsbusent.Lc_BusinessEntity.Updatem_table("l_tmt_gp", "VTMID = '" & tmpA & "'", "TMTID = '" & tmpB & "'")
                            End If


                        Catch ex As Exception

                        End Try
                    End If
                    i += 1
                    ProgressBarControl5.EditValue = (i + 1) * 100 / tmpROW
                    ProgressBarControl5.Refresh()
                    ProgressBarControl5.EditValue = 100

                End While
            End Using
        Catch ex As Exception
            XtraMessageBox.Show("ไม่สามารถดำเนินการได้ ไฟล์อาจมีการเปิดอยู่!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub ImportTMTsubsToVtm()

        Try
            Using stream As FileStream = File.Open(Application.StartupPath & "\Import\TMT\" & strFolder & "_BONUS\Relationship\" & strFolder.ToString.Replace("TMTRF", "SUBStoVTM") & ".xls", FileMode.Open, FileAccess.Read)
                Dim excelReader As IExcelDataReader = ExcelReaderFactory.CreateBinaryReader(stream)
                Dim tmpFileCount As Integer = excelReader.FieldCount
                If excelReader.FieldCount <> 2 Then
                    XtraMessageBox.Show("โครงสร้างไฟล์นำเข้าไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                clsbusent.Lc_BusinessEntity.Turncate_table("l_tmt_subsvtm")
                ProgressBarControl6.Visible = True
                ProgressBarControl6.Properties.Maximum = 100
                ProgressBarControl6.EditValue = 0

                Dim tmpROW As Integer = excelReader.RowCount
                Dim i As Integer = 0
                While excelReader.Read()
                    If i > 0 Then
                        Try
                            Dim tmpA As String = excelReader.GetValue(0)
                            Dim tmpB As String = excelReader.GetValue(1)

                            clsbusent.Lc_BusinessEntity.Insertm_table(" l_tmt_subsvtm (SUBSID,VTMID) ",
                                                             "'" & tmpA & "','" & tmpB & "'")


                        Catch ex As Exception

                        End Try
                    End If
                    i += 1
                    ProgressBarControl6.EditValue = (i + 1) * 100 / tmpROW
                    ProgressBarControl6.Refresh()
                    ProgressBarControl6.EditValue = 100

                End While
            End Using
        Catch ex As Exception
            XtraMessageBox.Show("ไม่สามารถดำเนินการได้ ไฟล์อาจมีการเปิดอยู่!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub chkAll_Click(sender As Object, e As EventArgs) Handles chkAll.Click
        If chkAll.Checked = True Then
            CheckBox1.Checked = True
            CheckBox2.Checked = True
            CheckBox3.Checked = True
            CheckBox4.Checked = True
            CheckBox5.Checked = True
            CheckBox6.Checked = True
        Else
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = False
        End If
    End Sub
End Class