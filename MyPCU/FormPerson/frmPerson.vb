Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.DateTime
Imports System.Globalization
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Imports System.IO
Imports DevExpress.XtraEditors.Controls

Public Class frmPerson
    Dim SearchPID As Boolean = False
    Dim SearchHN As Boolean = False
    Dim SearchCID As Boolean = False
    Dim tmpCID As String = ""
    Dim tmpSEX As String = ""
    Dim tmpAge As String = ""
    Dim ChkData As Boolean = False
    Dim tmpEnter As Boolean = False
    Dim tmpAdd As Boolean = False
    Dim tmpUpdate As Boolean = False
    Dim chkDataDrug As Boolean = False
    Dim chkDataCard As Boolean = False
    Dim chkDataDeath As Boolean = False
    Dim tmpRowID As String = ""
    Dim tmpRowCardID As String = ""
    Dim tmpCardUpdate As Boolean = False
    Dim tmpAddPerson As Boolean = False
    Dim CurrentReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
    Dim dsRpt As New DataSet
    Dim tmpFName As String = ""
    Dim tmpLNmae As String = ""
    Dim tmpTitle As String = ""
    Dim tmpBDATE As String = ""
    Dim tmpDOB As String = ""
    Dim tmpAMOUNT As String = ""
    Dim tmpPassport As String = ""

    Private Sub frmPerson_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDeath.Visible = False
        chkNoCID.Visible = False

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

        Timer1.Enabled = True
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'SplashScreenManager1.ShowWaitForm()
        Timer1.Interval = 100
        PrenameAction()
        SexAction()
        OccupationAction()
        MstatusAction()
        RaceAction()
        NationAction()
        ReligionAction()
        EducationAction()
        VStatusAction()
        LaborAction()
        TypeareaAction()

        Timer1.Enabled = False

    End Sub
    Private Sub PrenameAction()
        Dim ds As DataSet
        ds = ClsBusiness.Lc_Business.SELECT_TABLE("PRENAME_DESC,PRENAME_CODE", " l_mypcu_prename", "WHERE STATUS_AF = '1' ORDER BY PRENAME_CODE + 0")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboPrename
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "PRENAME_DESC"
                .Properties.ValueMember = "PRENAME_CODE"
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
    End Sub
    Private Sub OccupationAction()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("OCCUPATION_DESC,OCCUPATION_CODE", " l_mypcu_occupation ", " WHERE STATUS_AF = '1' ORDER BY OCCUPATION_DESC")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboOccupation
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "OCCUPATION_DESC"
                .Properties.ValueMember = "OCCUPATION_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = "พิมพ์เพื่อค้นหา"
            End With
        End If
    End Sub
    Private Sub SexAction()
        Dim ds As DataSet
        ds = ClsBusiness.Lc_Business.SELECT_TABLE("SEX, SEX_CODE", " l_sex", " WHERE STATUS_AF = '1' ")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboSex
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "SEX"
                .Properties.ValueMember = "SEX_CODE"
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
    End Sub
    Private Sub MstatusAction()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("MSTATUS_DESC,MSTATUS_CODE", " l_mypcu_mstatus ", " WHERE STATUS_AF = '1' ORDER BY MSTATUS_DESC")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboMstatus
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "MSTATUS_DESC"
                .Properties.ValueMember = "MSTATUS_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = "พิมพ์เพื่อค้นหา"
            End With
        End If
    End Sub
    Private Sub RaceAction()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("NATION_DESC,NATION_CODE", " l_mypcu_nation ", " WHERE STATUS_AF = '1' ORDER BY NATION_DESC")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboRace
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "NATION_DESC"
                .Properties.ValueMember = "NATION_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = "พิมพ์เพื่อค้นหา"
            End With
        End If
    End Sub
    Private Sub NationAction()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("NATION_DESC,NATION_CODE", " l_mypcu_nation ", " WHERE STATUS_AF = '1' ORDER BY NATION_DESC")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboNation
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "NATION_DESC"
                .Properties.ValueMember = "NATION_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = "พิมพ์เพื่อค้นหา"
            End With
        End If
    End Sub
    Private Sub ReligionAction()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("RELIGION_DESC,RELIGION_CODE", " l_mypcu_religion ", " WHERE STATUS_AF = '1' ORDER BY RELIGION_DESC")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboReligion
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "RELIGION_DESC"
                .Properties.ValueMember = "RELIGION_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = "พิมพ์เพื่อค้นหา"
            End With
        End If
    End Sub
    Private Sub EducationAction()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("EDUCATION_DESC,EDUCATION_CODE", " l_mypcu_education ", " WHERE STATUS_AF = '1' ORDER BY EDUCATION_DESC")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboEducation
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "EDUCATION_DESC"
                .Properties.ValueMember = "EDUCATION_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = "พิมพ์เพื่อค้นหา"
            End With
        End If
    End Sub
    Private Sub VStatusAction()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("VSTATUS_DESC,VSTATUS_CODE", " l_vstatus ", " ORDER BY VSTATUS_DESC")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboVstatus
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "VSTATUS_DESC"
                .Properties.ValueMember = "VSTATUS_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = "พิมพ์เพื่อค้นหา"
            End With
        End If
    End Sub
    Private Sub LaborAction()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("LABOR_DESC,LABOR_CODE", " l_mypcu_labor ", " WHERE STATUS_AF = '1' ORDER BY LABOR_DESC")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboLabor
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "LABOR_DESC"
                .Properties.ValueMember = "LABOR_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = "พิมพ์เพื่อค้นหา"
            End With
        End If
    End Sub
    Private Sub TypeareaAction()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("TYPEAREA_DESC,TYPEAREA_CODE", " l_typearea ", " ORDER BY TYPEAREA_CODE")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboTypearea
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "TYPEAREA_DESC"
                .Properties.ValueMember = "TYPEAREA_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = "พิมพ์เพื่อค้นหา"
            End With
        End If
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
    Private Sub SearchData()
        ClearData()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA(" m_person ", " WHERE CID = '" & tmpCID & "' AND STATUS_AF <> '8' ")

        If ds.Tables(0).Rows.Count > 0 Then
            tmpUpdate = True
            txtPID.Text = ds.Tables(0).Rows(0).Item("PID").ToString
            pPID = txtPID.Text
            hHID = ds.Tables(0).Rows(0).Item("HID").ToString
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
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("PASSPORT")) Then
                Try
                    txtPassport.Text = (ds.Tables(0).Rows(0).Item("PASSPORT")).ToString
                    tmpPassport = (ds.Tables(0).Rows(0).Item("PASSPORT")).ToString
                Catch ex As Exception
                    txtPassport.Text = ds.Tables(0).Rows(0).Item("PASSPORT")
                End Try

            Else
                txtPassport.Text = ""
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("PRENAME_HOS")) Then
                txtPrename.Text = ds.Tables(0).Rows(0).Item("PRENAME_HOS").ToString
                cboPrename.EditValue = txtPrename.Text
            Else
                txtPrename.Text = Nothing
                tmpFName = ""
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("NAME")) Then
                Try
                    txtName.Text = (ds.Tables(0).Rows(0).Item("NAME")).ToString
                    tmpFName = (ds.Tables(0).Rows(0).Item("NAME")).ToString
                Catch ex As Exception
                    txtName.Text = ds.Tables(0).Rows(0).Item("NAME")
                End Try

            Else
                txtName.Text = ""
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("LNAME")) Then
                Try
                    txtLName.Text = (ds.Tables(0).Rows(0).Item("LNAME")).ToString
                    tmpLNmae = (ds.Tables(0).Rows(0).Item("LNAME")).ToString
                Catch ex As Exception
                    txtLName.Text = ds.Tables(0).Rows(0).Item("LNAME")
                    tmpLNmae = ""
                End Try

            Else
                txtLName.Text = ""
            End If

            txtSEX.Text = ds.Tables(0).Rows(0).Item("SEX")
            cboSex.EditValue = txtSEX.Text

            Try
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("BIRTH")) And ds.Tables(0).Rows(0).Item("BIRTH") <> "" Then
                    tmpDOB = ds.Tables(0).Rows(0).Item("BIRTH").ToString.Substring(0, 4) + 543 & ds.Tables(0).Rows(0).Item("BIRTH").ToString.Substring(4, 4)
                    txtBirth.EditValue = DateTime.ParseExact(ds.Tables(0).Rows(0).Item("BIRTH"), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture)
                    If CheckDate(DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("dd/MM/yyyy")) = True Then
                        'txtBirth.Text = DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy")
                        Dim DOB As DateTime = DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture)
                        Dim Years As Integer = 0
                        Dim Month As Integer = 0
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
                            tmpAge = age.Year - 1
                            txtAgeY.Text = Years.ToString
                            txtAgeM.Text = Month.ToString
                            txtAgeD.Text = Days.ToString

                        Else
                            txtAgeY.Text = "x"
                            txtAgeM.Text = "x"
                            txtAgeD.Text = "x"
                        End If
                    Else
                        txtAgeY.Text = "x"
                        txtAgeM.Text = "x"
                        txtAgeD.Text = "x"
                        txtBirth.Text = Nothing
                    End If
                Else
                    txtBirth.Text = Nothing
                End If
            Catch ex As Exception

            End Try

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("OCCUPATION_HOS")) Then
                txtOccupation.Text = ds.Tables(0).Rows(0).Item("OCCUPATION_HOS")
                cboOccupation.EditValue = txtOccupation.Text
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("MSTATUS_HOS")) Then
                txtMstatus.Text = ds.Tables(0).Rows(0).Item("MSTATUS_HOS")
                cboMstatus.EditValue = txtMstatus.Text
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("RACE_HOS")) Then
                txtRace.Text = ds.Tables(0).Rows(0).Item("RACE_HOS")
                cboRace.EditValue = txtRace.Text
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("NATION_HOS")) Then
                txtNation.Text = ds.Tables(0).Rows(0).Item("NATION_HOS")
                cboNation.EditValue = txtNation.Text
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("RELIGION_HOS")) Then
                txtReligion.Text = ds.Tables(0).Rows(0).Item("RELIGION_HOS")
                cboReligion.EditValue = txtReligion.Text
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("EDUCATION_HOS")) Then
                txtEducation.Text = ds.Tables(0).Rows(0).Item("EDUCATION_HOS")
                cboEducation.EditValue = txtEducation.Text
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("ABOGROUP")) Then
                If ds.Tables(0).Rows(0).Item("ABOGROUP") = "1" Then
                    cboBloodGroup.Text = "A"
                ElseIf ds.Tables(0).Rows(0).Item("ABOGROUP") = "2" Then
                    cboBloodGroup.Text = "B"
                ElseIf ds.Tables(0).Rows(0).Item("ABOGROUP") = "3" Then
                    cboBloodGroup.Text = "AB"
                ElseIf ds.Tables(0).Rows(0).Item("ABOGROUP") = "4" Then
                    cboBloodGroup.Text = "O"
                End If
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("RHGROUP")) Then
                If ds.Tables(0).Rows(0).Item("RHGROUP") = "1" Then
                    cboRh.Text = "+"
                ElseIf ds.Tables(0).Rows(0).Item("ABOGROUP") = "2" Then
                    cboRh.Text = "-"
                End If
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FSTATUS")) Then
                If ds.Tables(0).Rows(0).Item("FSTATUS") = "1" Then
                    cboFstatus.Text = "เจ้าบ้าน"
                ElseIf ds.Tables(0).Rows(0).Item("FSTATUS") = "2" Then
                    cboFstatus.Text = "ผู้อาศัย"
                End If
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FSTATUS")) Then
                txtFstatus.Text = ds.Tables(0).Rows(0).Item("FSTATUS").ToString
                If txtFstatus.Text = "1" Then
                    chkFstatus1.Checked = True
                    chkFstatus2.Checked = False
                ElseIf txtFstatus.Text = "2" Then
                    chkFstatus2.Checked = True
                    chkFstatus1.Checked = False
                End If
            Else
                txtFstatus.Text = Nothing
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("FML_STATUS")) Then
                txtFmlstatus.Text = ds.Tables(0).Rows(0).Item("FML_STATUS").ToString
                If txtFmlstatus.Text = "1" Then
                    chkFmlStatus1.Checked = True
                    chkFmlStatus2.Checked = False
                ElseIf txtFmlstatus.Text = "2" Then
                    chkFmlStatus2.Checked = True
                    chkFmlStatus1.Checked = False
                End If
            Else
                txtFmlstatus.Text = Nothing
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("VSTATUS")) Then
                txtVstatus.Text = ds.Tables(0).Rows(0).Item("VSTATUS")
                cboVstatus.EditValue = txtVstatus.Text
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("LABOR_HOS")) Then
                txtLabor.Text = ds.Tables(0).Rows(0).Item("LABOR_HOS")
                cboLabor.EditValue = txtLabor.Text
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("TYPEAREA")) Then
                txtTypearea.Text = ds.Tables(0).Rows(0).Item("TYPEAREA")
                cboTypearea.EditValue = txtTypearea.Text
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
        Else
            tmpUpdate = False
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
        txtPrename.Text = Nothing
        txtName.Text = ""
        txtLName.Text = ""
        txtPassport.Text = ""
    End Sub

    Private Sub cmdPrenameEdit_Click(sender As Object, e As EventArgs) Handles cmdPrenameEdit.Click, Button1.Click
        Dim f As New frmLookupPrename
        f.ShowDialog()
        PrenameAction()
    End Sub

    Private Sub cboPrename_EditValueChanged(sender As Object, e As EventArgs) Handles cboPrename.EditValueChanged
        txtPrename.Text = cboPrename.EditValue
    End Sub

    Private Sub cboSex_EditValueChanged(sender As Object, e As EventArgs) Handles cboSex.EditValueChanged
        txtSEX.Text = cboSex.EditValue
    End Sub

    Private Sub txtPrename_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrename.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboPrename.EditValue = txtPrename.Text
        End If
    End Sub

    Private Sub txtSEX_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSEX.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboSex.EditValue = txtSEX.Text
            txtBirth.Focus()
        End If
    End Sub

    Private Sub AccordionControlElement5_Click(sender As Object, e As EventArgs) Handles AccordionControlElement5.Click
        Dim f As New frmLookupPrename
        f.ShowDialog()
        PrenameAction()
    End Sub

    Private Sub cboOccupation_EditValueChanged(sender As Object, e As EventArgs) Handles cboOccupation.EditValueChanged
        txtOccupation.Text = cboOccupation.EditValue
    End Sub

    Private Sub txtOccupation_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOccupation.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboOccupation.EditValue = txtOccupation.Text
            txtRace.Select()
            txtRace.SelectAll()
        End If
    End Sub

    Private Sub txtOccupation_Leave(sender As Object, e As EventArgs) Handles txtOccupation.Leave
        cboOccupation.EditValue = txtOccupation.Text
    End Sub

    Private Sub cboMstatus_EditValueChanged(sender As Object, e As EventArgs) Handles cboMstatus.EditValueChanged
        txtMstatus.Text = cboMstatus.EditValue
    End Sub
    Private Sub txtMstatus_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMstatus.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboMstatus.EditValue = txtMstatus.Text
            txtOccupation.Select()
            txtOccupation.SelectAll()
        End If
    End Sub
    Private Sub txtMstatus_Leave(sender As Object, e As EventArgs)
        cboMstatus.EditValue = txtMstatus.Text
    End Sub


    Private Sub cboRace_EditValueChanged(sender As Object, e As EventArgs) Handles cboRace.EditValueChanged
        txtRace.Text = cboRace.EditValue
    End Sub
    Private Sub txtRace_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRace.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboRace.EditValue = txtRace.Text
            txtNation.Select()
            txtNation.SelectAll()
        End If
    End Sub
    Private Sub txtRace_Leave(sender As Object, e As EventArgs)
        cboRace.EditValue = txtRace.Text
    End Sub

    Private Sub cboNation_EditValueChanged(sender As Object, e As EventArgs) Handles cboNation.EditValueChanged
        txtNation.Text = cboNation.EditValue
    End Sub
    Private Sub txtNation_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNation.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboNation.EditValue = txtNation.Text
            txtReligion.Select()
            txtReligion.SelectAll()
        End If
    End Sub
    Private Sub txtNation_Leave(sender As Object, e As EventArgs)
        cboNation.EditValue = txtNation.Text
    End Sub

    Private Sub cboReligion_EditValueChanged(sender As Object, e As EventArgs) Handles cboReligion.EditValueChanged
        txtReligion.Text = cboReligion.EditValue
    End Sub
    Private Sub txtReligion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReligion.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboReligion.EditValue = txtReligion.Text
            txtEducation.Select()
            txtEducation.SelectAll()
        End If
    End Sub
    Private Sub txtReligion_Leave(sender As Object, e As EventArgs)
        cboReligion.EditValue = txtReligion.Text
    End Sub

    Private Sub cboEducation_EditValueChanged(sender As Object, e As EventArgs) Handles cboEducation.EditValueChanged
        txtEducation.Text = cboEducation.EditValue
    End Sub
    Private Sub txtEducation_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEducation.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboEducation.EditValue = txtEducation.Text
            txtBloodGroup.Select()
            txtBloodGroup.SelectAll()
        End If
    End Sub
    Private Sub txtEducation_Leave(sender As Object, e As EventArgs)
        cboEducation.EditValue = txtEducation.Text
    End Sub
    Private Sub cboVstatus_EditValueChanged(sender As Object, e As EventArgs) Handles cboVstatus.EditValueChanged
        txtVstatus.Text = cboVstatus.EditValue
    End Sub
    Private Sub txtVstatus_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVstatus.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboVstatus.EditValue = txtVstatus.Text
            txtLabor.Select()
            txtLabor.SelectAll()
        End If
    End Sub
    Private Sub txtVstatus_Leave(sender As Object, e As EventArgs)
        cboVstatus.EditValue = txtVstatus.Text
    End Sub

    Private Sub cboLabor_EditValueChanged(sender As Object, e As EventArgs) Handles cboLabor.EditValueChanged
        txtLabor.Text = cboLabor.EditValue
    End Sub
    Private Sub txtLabor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLabor.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboLabor.EditValue = txtLabor.Text
            txtTelephone.Select()
            txtTelephone.SelectAll()
        End If
    End Sub
    Private Sub txtLabor_Leave(sender As Object, e As EventArgs)
        cboLabor.EditValue = txtLabor.Text
    End Sub

    Private Sub cboTypearea_EditValueChanged(sender As Object, e As EventArgs) Handles cboTypearea.EditValueChanged
        txtTypearea.Text = cboTypearea.EditValue
    End Sub
    Private Sub txtTypearea_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTypearea.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboTypearea.EditValue = txtTypearea.Text
            txtVstatus.Select()
            txtVstatus.SelectAll()
        End If
    End Sub
    Private Sub txtTypearea_Leave(sender As Object, e As EventArgs)
        cboTypearea.EditValue = txtTypearea.Text
    End Sub

    Private Sub btnLookupMstatus_Click(sender As Object, e As EventArgs) Handles btnLookupMstatus.Click
        Dim f As New frmLookupMstatus
        f.ShowDialog()
        MstatusAction()
    End Sub

    Private Sub btnLookupOccupation_Click(sender As Object, e As EventArgs) Handles btnLookupOccupation.Click
        Dim f As New frmLookupOccupation
        f.ShowDialog()
        OccupationAction()
    End Sub

    Private Sub btnLookupRace_Click(sender As Object, e As EventArgs) Handles btnLookupRace.Click
        Dim f As New frmLookupNation
        f.ShowDialog()
        RaceAction()
    End Sub

    Private Sub btbLookupNation_Click(sender As Object, e As EventArgs) Handles btbLookupNation.Click
        Dim f As New frmLookupNation
        f.ShowDialog()
        NationAction()
    End Sub

    Private Sub btnLookupReligion_Click(sender As Object, e As EventArgs) Handles btnLookupReligion.Click
        Dim f As New frmLookupReligion
        f.ShowDialog()
        ReligionAction()
    End Sub

    Private Sub btnLookupEducation_Click(sender As Object, e As EventArgs) Handles btnLookupEducation.Click
        Dim f As New frmLookupEducation
        f.ShowDialog()
        EducationAction()
    End Sub
    Private Sub btnLookupLabor_Click(sender As Object, e As EventArgs) Handles btnLookupLabor.Click
        Dim f As New frmLookupLabor
        f.ShowDialog()
        LaborAction()
    End Sub

    Private Sub txtBloodGroup_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBloodGroup.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtBloodGroup.Text = "1" Then
                cboBloodGroup.Text = "A"
            ElseIf txtBloodGroup.Text = "2" Then
                cboBloodGroup.Text = "B"
            ElseIf txtBloodGroup.Text = "3" Then
                cboBloodGroup.Text = "AB"
            ElseIf txtBloodGroup.Text = "4" Then
                cboBloodGroup.Text = "O"
            Else
                XtraMessageBox.Show("กรุณากำหนด Blood Group ให้ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtBloodGroup.SelectAll()
                Exit Sub
            End If

            txtRH.Select()
            txtRH.SelectAll()
        End If
    End Sub

    Private Sub cboBloodGroup_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboBloodGroup.SelectedValueChanged
        If cboBloodGroup.Text = "A" Then
            txtBloodGroup.Text = "1"
        ElseIf cboBloodGroup.Text = "B" Then
            txtBloodGroup.Text = "2"
        ElseIf cboBloodGroup.Text = "AB" Then
            txtBloodGroup.Text = "3"
        ElseIf cboBloodGroup.Text = "O" Then
            txtBloodGroup.Text = "4"
        End If
    End Sub

    Private Sub txtRH_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRH.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtRH.Text = "1" Then
                cboRh.Text = "+"
            ElseIf txtRH.Text = "2" Then
                cboRh.Text = "-"
            Else
                XtraMessageBox.Show("กรุณากำหนด RH Group ให้ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtRH.SelectAll()
                Exit Sub
            End If

            txtFstatus.Select()
            txtFstatus.SelectAll()
        End If
    End Sub

    Private Sub cboRh_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboRh.SelectedValueChanged
        If cboRh.Text = "+" Then
            txtRH.Text = "1"
        ElseIf cboRh.Text = "-" Then
            txtRH.Text = "2"
        End If
    End Sub


    Private Sub txtFstatus_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFstatus.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtFstatus.Text = "1" Then
                cboFstatus.Text = "เจ้าบ้าน"
                chkFstatus1.Checked = True
                chkFstatus2.Checked = False
            ElseIf txtFstatus.Text = "2" Then
                cboFstatus.Text = "ผู้อาศัย"
                chkFstatus2.Checked = True
                chkFstatus1.Checked = False
            Else
                XtraMessageBox.Show("กรุณากำหนด สถานะตามทะเบียนบ้าน ให้ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtFstatus.SelectAll()
                Exit Sub
            End If

            txtFmlstatus.Select()
            txtFmlstatus.SelectAll()
        End If
    End Sub



    Private Sub cboFstatus_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboFstatus.SelectedValueChanged
        If cboFstatus.Text = "เจ้าบ้าน" Then
            txtFstatus.Text = "1"
        ElseIf cboFstatus.Text = "ผู้อาศัย" Then
            txtFstatus.Text = "2"
        End If
    End Sub

    Private Sub chkFstatus1_Click(sender As Object, e As EventArgs) Handles chkFstatus1.Click
        chkFstatus1.Checked = True
        chkFstatus2.Checked = False
        txtFstatus.Text = "1"
        'chkFmlStatus1.Checked = False
        'chkFmlStatus2.Checked = False

    End Sub

    Private Sub chkFstatus2_Click(sender As Object, e As EventArgs) Handles chkFstatus2.Click
        chkFstatus1.Checked = False
        chkFstatus2.Checked = True
        txtFstatus.Text = "2"

    End Sub

    Private Sub chkFmlStatus1_Click(sender As Object, e As EventArgs) Handles chkFmlStatus1.Click
        chkFmlStatus1.Checked = True
        chkFmlStatus2.Checked = False
        txtFmlstatus.Text = "1"

    End Sub

    Private Sub chkFmlStatus2_Click(sender As Object, e As EventArgs) Handles chkFmlStatus2.Click
        chkFmlStatus1.Checked = False
        chkFmlStatus2.Checked = True
        txtFmlstatus.Text = "2"

    End Sub

    Private Sub txtFmlstatus_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFmlstatus.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtFmlstatus.Text = "1" Then
                chkFmlStatus1.Checked = True
                chkFmlStatus2.Checked = False
            ElseIf txtFmlstatus.Text = "2" Then
                chkFmlStatus2.Checked = True
                chkFmlStatus1.Checked = False
            Else
                XtraMessageBox.Show("กรุณากำหนด สถานะบุคคลในครอบครัว ให้ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtFstatus.SelectAll()
                Exit Sub
            End If

            txtTypearea.Select()
            txtTypearea.SelectAll()
        End If
    End Sub

    Private Sub AccordionControlElement8_Click(sender As Object, e As EventArgs) Handles AccordionControlElement8.Click

        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate_En()

        If chkDelete.Checked = True Then
            If XtraMessageBox.Show("ต้องการยกเลิกข้อมูลบุคคลรายนี้?" & vbCrLf & "ยืนยันการยกเลิกกด OK หากไม่ต้องการยกเลิก กด Cancel", vProgram, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = System.Windows.Forms.DialogResult.Cancel Then
                chkDelete.Checked = False
                Exit Sub
            End If
            SplashScreenManager1.ShowWaitForm()
            Dim ds As DataSet
            ds = clsdataBus.Lc_Business.SELECT_TABLE("M_TABLE", "l_table43", " WHERE M_TABLE NOT IN('PERSON','CARD','ADDRESS') ORDER BY m_TABLE")
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim ds3 As DataSet
                    ds3 = clsdataBus.Lc_Business.SHOW_TABLE_COLUMN("m_" & ds.Tables(0).Rows(i).Item("M_TABLE").ToString.ToLower & " WHERE FIELD = 'PID' ")
                    If ds3.Tables(0).Rows.Count = 1 Then
                        For h As Integer = 0 To ds3.Tables(0).Rows.Count - 1
                            Dim ds4 As DataSet
                            ds4 = clsdataBus.Lc_Business.SELECT_TABLE("PID", "m_" & ds.Tables(0).Rows(i).Item("M_TABLE").ToString.ToLower & "", " WHERE PID = '" & pPID & "'")
                            If ds4.Tables(0).Rows.Count > 0 Then
                                MessageBox.Show("ไม่สามารถยกเลิกได้เนื่องจากมีข้อมูลการรับบริการของประชากรรายนี้ในแฟ้ม " & ds.Tables(0).Rows(i).Item("M_TABLE").ToString, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                chkDelete.Checked = False
                                Exit Sub
                            End If
                        Next
                    End If
                Next
            End If

            clsbusent.Lc_BusinessEntity.Updatem_table("m_person", " STATUS_AF = '8', D_UPDATE = '" & tmpNow & "',USER_REC = '" & vUSERID & "' ", "PID = '" & txtPID.Text & "'")
            clsbusent.Lc_BusinessEntity.Updatem_table("m_address", " STATUS_AF = '8', D_UPDATE = '" & tmpNow & "',USER_REC = '" & vUSERID & "' ", "PID = '" & txtPID.Text & "'")
            clsbusent.Lc_BusinessEntity.Updatem_table("m_card", " STATUS_AF = '8', D_UPDATE = '" & tmpNow & "',USER_REC = '" & vUSERID & "' ", "PID = '" & txtPID.Text & "'")

            SplashScreenManager1.CloseWaitForm()
            Exit Sub
        End If


        If tmpUpdate = True Then


        Else


        End If
    End Sub

    Private Sub FluentDesignFormControl1_Click(sender As Object, e As EventArgs) Handles FluentDesignFormControl1.Click

    End Sub
End Class