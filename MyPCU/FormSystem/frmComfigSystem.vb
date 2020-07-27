Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.IO
Imports System.Drawing.Printing
Imports DevExpress.XtraEditors
Imports MadMilkman.Ini
Public Class frmComfigSystem
    Dim tmpSave As Boolean = False
    Private Sub frmComfigSystem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ShowClinic()
        Dim printers As New Printing.PrintDocument()
        Dim printername = printers.PrinterSettings.PrinterName
        For Each printername In Printing.PrinterSettings.InstalledPrinters
            cboPrinter1.Properties.Items.Add(printername)
        Next
        Dim printers2 As New Printing.PrintDocument()
        Dim printername2 = printers2.PrinterSettings.PrinterName
        For Each printername2 In Printing.PrinterSettings.InstalledPrinters
            cboPrinter2.Properties.Items.Add(printername2)
        Next

        Try
            Dim filePath = Application.StartupPath & "\config.ini"
            Dim file As New IniFile()
            file.Load(filePath)

            lblClinic.Text = file.Sections("Clinic").Keys("Department").Value
            cboClinic.EditValue = lblClinic.Text
            If file.Sections("Clinic").Keys("Show").Value = "1" Then
                chkClinicShow.Checked = True
            Else
                chkClinicShow.Checked = False
            End If

            If file.Sections("DSPM").Keys("Show").Value = "1" Then
                chkDspm.Checked = True
            Else
                chkDspm.Checked = False
            End If

        Catch ex As Exception

        End Try

        Try
            Dim filePath = Application.StartupPath & "\config.ini"
            Dim file As New IniFile()
            file.Load(filePath)

            Print1 = file.Sections("Print1").Keys("Printername").Value
            Width1 = file.Sections("Print1").Keys("Width").Value
            Height1 = file.Sections("Print1").Keys("Height").Value
            MarginTop1 = file.Sections("Print1").Keys("MarginTop").Value
            MarginBottom1 = file.Sections("Print1").Keys("MarginBottom").Value
            MarginLeft1 = file.Sections("Print1").Keys("MarginLeft").Value
            MarginRight1 = file.Sections("Print1").Keys("MarginRight").Value
            PrintView1 = file.Sections("Print1").Keys("PrintView").Value
        Catch ex As Exception
        End Try


        Try
            Dim filePath = Application.StartupPath & "\config.ini"
            Dim file As New IniFile()
            file.Load(filePath)

            Print2 = file.Sections("Print2").Keys("Printername").Value
            Width2 = file.Sections("Print2").Keys("Width").Value
            Height2 = file.Sections("Print2").Keys("Height").Value
            MarginTop2 = file.Sections("Print2").Keys("MarginTop").Value
            MarginBottom2 = file.Sections("Print2").Keys("MarginBottom").Value
            MarginLeft2 = file.Sections("Print2").Keys("MarginLeft").Value
            MarginRight2 = file.Sections("Print2").Keys("MarginRight").Value
            PrintView2 = file.Sections("Print2").Keys("PrintView").Value
        Catch ex As Exception
        End Try
        Try
            Dim filePath = Application.StartupPath & "\config.ini"
            Dim file As New IniFile()
            file.Load(filePath)
            txtNHSO.Text = File.Sections("NHSO").Keys("Path").Value
        Catch ex As Exception

        End Try

        Try
            Dim filePath = Application.StartupPath & "\config.ini"
            Dim file As New IniFile()
            file.Load(filePath)
            vICD10TH = file.Sections("ICD").Keys("vICD10TH").Value
            vICD10 = file.Sections("ICD").Keys("vICD10").Value
            vICD10TM = file.Sections("ICD").Keys("vICD10TM").Value
            vICD10TMD = file.Sections("ICD").Keys("vICD10TMD").Value
            vICD9 = file.Sections("ICD").Keys("vICD9").Value
            vICD9TM = file.Sections("ICD").Keys("vICD9TM").Value
            vICD9TMD = file.Sections("ICD").Keys("vICD9TMD").Value
            vICD9DENT = file.Sections("ICD").Keys("vICD9DENT").Value
            vICD9CHINA = file.Sections("ICD").Keys("vICD9CHINA").Value

            ICD10_1 = file.Sections("ICD").Keys("ICD10_1").Value
            ICD10_2 = file.Sections("ICD").Keys("ICD10_2").Value
            ICD10_3 = file.Sections("ICD").Keys("ICD10_3").Value
            ICD10_4 = file.Sections("ICD").Keys("ICD10_4").Value
            ICD10_5 = file.Sections("ICD").Keys("ICD10_5").Value
        Catch ex As Exception

        End Try

        Try
            Dim filePath = Application.StartupPath & "\config.ini"
            Dim file As New IniFile()
            file.Load(filePath)
            vPSEARCH = file.Sections("Search").Keys("Element").Value
        Catch ex As Exception

        End Try

        cboPrinter1.Text = Print1
        txtWidth1.Value = Width1
        txtHeight1.Value = Height1
        txtMarginBottom1.Value = MarginBottom1
        txtMarginTop1.Value = MarginTop1
        txtMarginLeft1.Value = MarginLeft1
        txtMarginRight1.Value = MarginRight1

        If PrintView1 = "1" Then
            chkPreview1.Checked = True
            chkAuto1.Checked = False
        Else
            chkAuto1.Checked = True
            chkPreview1.Checked = False
        End If

        cboPrinter2.Text = Print2
        txtWidth2.Value = Width2
        txtHeight2.Value = Height2
        txtMarginBottom2.Value = MarginBottom2
        txtMarginTop2.Value = MarginTop2
        txtMarginLeft2.Value = MarginLeft2
        txtMarginRight2.Value = MarginRight2

        If PrintView2 = "1" Then
            chkPreview2.Checked = True
            chkAuto2.Checked = False
        Else
            chkAuto2.Checked = True
            chkPreview2.Checked = False
        End If

        If vICD10TH = "1" Then
            optICD10_THAI.Checked = True
        ElseIf vICD10TH = "0" Then
            optICD10_ENG.Checked = True
        End If

        If vICD10 = "1" Then
            chkICD10.Checked = True
        ElseIf vICD10 = "0" Then
            chkICD10.Checked = False
        End If

        If vICD10TM = "1" Then
            chkICD10TM.Checked = True
        ElseIf vICD10TM = "0" Then
            chkICD10TM.Checked = False
        End If

        If vICD10TMD = "1" Then
            chkICD10TMD.Checked = True
        ElseIf vICD10TMD = "0" Then
            chkICD10TMD.Checked = False
        End If

        If vICD9 = "1" Then
            chkICD9.Checked = True
        ElseIf vICD9 = "0" Then
            chkICD9.Checked = False
        End If

        If vICD9TM = "1" Then
            chkICD9TM.Checked = True
        ElseIf vICD9TM = "0" Then
            chkICD9TM.Checked = False
        End If

        If vICD9TMD = "1" Then
            chkICD9TMD.Checked = True
        ElseIf vICD9TMD = "0" Then
            chkICD9TMD.Checked = False
        End If
        If vICD9DENT = "1" Then
            chkICD9DENT.Checked = True
        ElseIf vICD9DENT = "0" Then
            chkICD9DENT.Checked = False
        End If

        If vICD9CHINA = "1" Then
            chkICD9CHINA.Checked = True
        ElseIf vICD9CHINA = "0" Then
            chkICD9CHINA.Checked = False
        End If

        If ICD10_1 = "1" Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If
        If ICD10_2 = "1" Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False
        End If
        If ICD10_3 = "1" Then
            CheckBox3.Checked = True
        Else
            CheckBox3.Checked = False
        End If
        If ICD10_4 = "1" Then
            CheckBox4.Checked = True
        Else
            CheckBox4.Checked = False
        End If
        If ICD10_5 = "1" Then
            CheckBox5.Checked = True
        Else
            CheckBox5.Checked = False
        End If

        If vPSEARCH = "1" Then
            chkPID.Checked = True
        ElseIf vPSEARCH = "2" Then
            chkHN.Checked = True
        ElseIf vPSEARCH = "3" Then
            chkCID.Checked = True
        ElseIf vPSEARCH = "4" Then
            chkName.Checked = True
        Else
            chkPID.Checked = True
        End If

        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("HNPID,IFNULL(DTX1,'') AS DTX1,IFNULL(DTX2,'') AS DTX2,IFNULL(CSMBS,'0') AS CSMBS,IFNULL(MEDSERVICE,'') AS MEDSERVICE,IFNULL(IMAGE_TYPE,'0') AS IMAGE_TYPE,IFNULL(DENTAL_WARNING,'0') AS DENTAL_WARNING,IFNULL(DIAG_WORD,'0') AS DIAG_WORD,IFNULL(LABEl_nation,'0') AS LABEl_nation,IFNULL(SDX,'0') AS SDX,IFNULL(EGFR,'0') AS EGFR,IFNULL(CARD,'1') AS CARD,IFNULL(506ONLINE,'1') AS 506ONLINE,IFNULL(WEB506,'') AS WEB506,IFNULL(WEB506_2,'') AS WEB506_2,IFNULL(USERNAME,'') AS USERNAME,IFNULL(PASSWORD,'') AS PASSWORD,IFNULL(BILL,'0') AS BILL,IFNULL(DIAGNOSIS,'0') AS DIAGNOSIS,IFNULL(EXAM,'0') AS EXAM,IFNULL(INTIME,'080000') AS INTIME,IFNULL(OUTTIME,'160000') AS OUTTIME", "l_confighcode", "")
        If ds2.Tables(0).Rows.Count > 0 Then
            txtINTIME.Text = ds2.Tables(0).Rows(0).Item("INTIME").ToString
            txtOUTTIME.Text = ds2.Tables(0).Rows(0).Item("OUTTIME").ToString
        End If

    End Sub
    Private Sub ShowClinic()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE(" CLINIC_CODE,CONCAT('[',CLINIC_CODE,'] ',CLINIC_SUB_DESC) AS CLINIC_SUB_DESC ", "  l_clinic_hosp ", "WHERE STATUS = '1' ")

        If ds.Tables(0).Rows.Count > 0 Then
            With cboClinic
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "CLINIC_SUB_DESC"
                .Properties.ValueMember = "CLINIC_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
    End Sub
    Private Sub SaveData()

        If lblClinic.Text = "" Then
            XtraMessageBox.Show("กำหนดแผนกก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim tmpClinicShow As String = ""

        If chkClinicShow.Checked = True Then
            tmpClinicShow = "1"
        Else
            tmpClinicShow = "0"
        End If


        Dim View1 As String = ""
        Dim View2 As String = ""

        If chkPreview1.Checked = True Then
            View1 = "1"
        Else
            View1 = "0"
        End If
        If chkPreview2.Checked = True Then
            View2 = "1"
        Else
            View2 = "0"
        End If


        If optICD10_THAI.Checked = True Then
            vICD10TH = "1"
        ElseIf optICD10_ENG.Checked = True Then
            vICD10TH = "0"
        End If

        If chkICD10.Checked = True Then
            vICD10 = "1"
        Else
            vICD10 = "0"
        End If

        If chkICD10TM.Checked = True Then
            vICD10TM = "1"
        Else
            vICD10TM = "0"
        End If

        If chkICD10TMD.Checked = True Then
            vICD10TMD = "1"
        Else
            vICD10TMD = "0"
        End If
        If chkICD9.Checked = True Then
            vICD9 = "1"
        Else
            vICD9 = "0"
        End If

        If chkICD9TM.Checked = True Then
            vICD9TM = "1"
        Else
            vICD9TM = "0"
        End If

        If chkICD9TMD.Checked = True Then
            vICD9TMD = "1"
        Else
            vICD9TMD = "0"
        End If
        If chkICD9DENT.Checked = True Then
            vICD9DENT = "1"
        Else
            vICD9DENT = "0"
        End If

        If chkICD9CHINA.Checked = True Then
            vICD9CHINA = "1"
        Else
            vICD9CHINA = "0"
        End If

        If CheckBox1.Checked = True Then
            vICD10_1 = "1"
        Else
            vICD10_1 = "0"
        End If

        If CheckBox2.Checked = True Then
            vICD10_2 = "1"
        Else
            vICD10_2 = "0"
        End If

        If CheckBox3.Checked = True Then
            vICD10_3 = "1"
        Else
            vICD10_3 = "0"
        End If

        If CheckBox4.Checked = True Then
            vICD10_4 = "1"
        Else
            vICD10_4 = "0"
        End If

        If CheckBox5.Checked = True Then
            vICD10_5 = "1"
        Else
            vICD10_5 = "0"
        End If

        If chkPID.Checked = True Then
            vPSEARCH = "1"
        ElseIf chkHN.Checked = True Then
            vPSEARCH = "2"
        ElseIf chkCID.Checked = True Then
            vPSEARCH = "3"
        ElseIf chkName.Checked = True Then
            vPSEARCH = "4"
        Else
            vPSEARCH = "1"
        End If

        Dim filePath = Application.StartupPath & "\config.ini"
        Dim file2 As New IniFile()
        If File.Exists(filePath) = True Then
            file2.Load(filePath)
        End If

        file2.Sections.Remove("Clinic")
        file2.Sections.Remove("DSPM")
        file2.Sections.Remove("Print1")
        file2.Sections.Remove("Print2")
        file2.Sections.Remove("NHSO")
        file2.Sections.Remove("ICD")
        file2.Sections.Remove("Search")

        file2.Sections.Add("Clinic")

        file2.Sections("Clinic").Keys.Add("Department", lblClinic.Text)
        file2.Sections("Clinic").Keys.Add("Show", tmpClinicShow)

        file2.Sections.Add("NHSO")
        file2.Sections("NHSO").Keys.Add("Path", txtNHSO.Text)

        file2.Sections.Add("DSPM")
        Dim tmpDSPM As String = ""

        If chkDspm.Checked = True Then
            tmpDSPM = "1"
        Else
            tmpDSPM = "0"
        End If


        file2.Sections("DSPM").Keys.Add("Show", tmpDSPM)

        file2.Sections.Add("Print1")
        file2.Sections("Print1").Keys.Add("Printername", (cboPrinter1.Text))
        file2.Sections("Print1").Keys.Add("Width", (txtWidth1.Value))
        file2.Sections("Print1").Keys.Add("Height", (txtHeight1.Value))
        file2.Sections("Print1").Keys.Add("MarginTop", (txtMarginTop1.Value))
        file2.Sections("Print1").Keys.Add("MarginBottom", (txtMarginBottom1.Value))
        file2.Sections("Print1").Keys.Add("MarginLeft", (txtMarginLeft1.Value))
        file2.Sections("Print1").Keys.Add("MarginRight", (txtMarginRight1.Value))
        file2.Sections("Print1").Keys.Add("PrintView", (View1))

        file2.Sections.Add("Print2")
        file2.Sections("Print2").Keys.Add("Printername", (cboPrinter2.Text))
        file2.Sections("Print2").Keys.Add("Width", (txtWidth2.Value))
        file2.Sections("Print2").Keys.Add("Height", (txtHeight2.Value))
        file2.Sections("Print2").Keys.Add("MarginTop", (txtMarginTop2.Value))
        file2.Sections("Print2").Keys.Add("MarginBottom", (txtMarginBottom2.Value))
        file2.Sections("Print2").Keys.Add("MarginLeft", (txtMarginLeft2.Value))
        file2.Sections("Print2").Keys.Add("MarginRight", (txtMarginRight2.Value))
        file2.Sections("Print2").Keys.Add("PrintView", (View2))


        file2.Sections.Add("ICD")
        file2.Sections("ICD").Keys.Add("vICD10TH", vICD10TH)
        file2.Sections("ICD").Keys.Add("vICD10", vICD10)
        file2.Sections("ICD").Keys.Add("vICD10TM", vICD10TM)
        file2.Sections("ICD").Keys.Add("vICD10TMD", vICD10TMD)
        file2.Sections("ICD").Keys.Add("vICD9", vICD9)
        file2.Sections("ICD").Keys.Add("vICD9TM", vICD9TM)
        file2.Sections("ICD").Keys.Add("vICD9TMD", vICD9TMD)
        file2.Sections("ICD").Keys.Add("vICD9DENT", vICD9DENT)
        file2.Sections("ICD").Keys.Add("vICD9CHINA", vICD9CHINA)
        file2.Sections("ICD").Keys.Add("ICD10_1", ICD10_1)
        file2.Sections("ICD").Keys.Add("ICD10_2", ICD10_2)
        file2.Sections("ICD").Keys.Add("ICD10_3", ICD10_3)
        file2.Sections("ICD").Keys.Add("ICD10_4", ICD10_4)
        file2.Sections("ICD").Keys.Add("ICD10_5", ICD10_5)

        file2.Sections.Add("Search")
        file2.Sections("Search").Keys.Add("Element", vPSEARCH)

        file2.Save(filePath)


        '************ Save ลง Datatabase

        vINTIME = CInt(txtINTIME.Text.Replace(":", "").Replace("_", "")).ToString("000000")
        vOUTTIME = CInt(txtOUTTIME.Text.Replace(":", "").Replace("_", "")).ToString("000000")


        clsbusent.Lc_BusinessEntity.Updatem_table("l_confighcode", "INTIME = '" & vINTIME & "',OUTTIME = '" & vOUTTIME & "'", " HOSPCODE = '" & vHcode & "'")


        tmpSave = True
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click

        SaveData()
        XtraMessageBox.Show(msSave, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
        If tmpSave = True Then
            Me.Close()
        End If

    End Sub

    Private Sub cmdApply_Click(sender As Object, e As EventArgs) Handles cmdApply.Click
        SaveData()
        XtraMessageBox.Show(msSave, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub cmdCancle_Click(sender As Object, e As EventArgs) Handles cmdCancle.Click
        Me.Close()
    End Sub

    Private Sub cboClinic_EditValueChanged(sender As Object, e As EventArgs) Handles cboClinic.EditValueChanged
        lblClinic.Text = cboClinic.EditValue
    End Sub

    Private Sub chkPreview1_Click(sender As Object, e As EventArgs) Handles chkPreview1.Click
        chkPreview1.Checked = True
        chkAuto1.Checked = False
    End Sub

    Private Sub chkAuto1_Click(sender As Object, e As EventArgs) Handles chkAuto1.Click
        chkPreview1.Checked = False
        chkAuto1.Checked = True
    End Sub
    Private Sub chkPreview2_Click(sender As Object, e As EventArgs) Handles chkPreview2.Click
        chkPreview2.Checked = True
        chkAuto2.Checked = False
    End Sub

    Private Sub chkAuto2_Click(sender As Object, e As EventArgs) Handles chkAuto2.Click
        chkPreview2.Checked = False
        chkAuto2.Checked = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If XtraFolderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtNHSO.Text = XtraFolderBrowserDialog1.SelectedPath
        End If
    End Sub


    Private Sub cmdDepartmentEdit_Click(sender As Object, e As EventArgs) Handles cmdDepartmentEdit.Click
        Dim f As New frmDepartmentEdit
        f.ShowDialog()
        ShowClinic()
    End Sub

    Private Sub optICD10_ENG_Click(sender As Object, e As EventArgs) Handles optICD10_ENG.Click
        optICD10_ENG.Checked = True
        optICD10_THAI.Checked = False
    End Sub

    Private Sub optICD10_THAI_Click(sender As Object, e As EventArgs) Handles optICD10_THAI.Click
        optICD10_ENG.Checked = False
        optICD10_THAI.Checked = True
    End Sub

    Private Sub chkPID_Click(sender As Object, e As EventArgs) Handles chkPID.Click
        chkPID.Checked = True
        chkHN.Checked = False
        chkCID.Checked = False
        chkName.Checked = False
    End Sub

    Private Sub chkHN_Click(sender As Object, e As EventArgs) Handles chkHN.Click
        chkPID.Checked = False
        chkHN.Checked = True
        chkCID.Checked = False
        chkName.Checked = False
    End Sub

    Private Sub chkCID_Click(sender As Object, e As EventArgs) Handles chkCID.Click
        chkPID.Checked = False
        chkHN.Checked = False
        chkCID.Checked = True
        chkName.Checked = False
    End Sub

    Private Sub chkName_Click(sender As Object, e As EventArgs) Handles chkName.Click
        chkPID.Checked = False
        chkHN.Checked = False
        chkCID.Checked = False
        chkName.Checked = True
    End Sub
End Class