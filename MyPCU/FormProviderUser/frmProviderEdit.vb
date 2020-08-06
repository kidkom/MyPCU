Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.IO
Imports System.DateTime
Imports System.Globalization
Imports System.Text
Imports DevExpress.XtraEditors
Imports GemCard
Imports com.idcard.card
Imports com.idcard.data
Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D
Public Class frmProviderEdit
    Dim ChkData As Boolean = True
    Dim tmpAdd As Boolean = False
    Dim tmpUpdate As Boolean = False
    Dim tmpCID As String = ""
    Dim tmpSave As Boolean = False
    Dim tmpPROVIDER_ID As String = ""
    Dim tmpROWID As String = ""
    Dim tmpErrorDesc2 As String = ""
    Private Sub frmProviderEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblErrorCode.Text = ""
        Prename()
        CboProvider()
        Council()
        Sex()

        If vPvdROWID <> "" Then
            Dim ds As DataSet
            ds = clsdataBus.Lc_Business.SELECT_DATA("m_provider", " WHERE ROWID = '" & vPvdROWID & "'")
            If ds.Tables(0).Rows.Count > 0 Then
                tmpUpdate = True
                lblPROVIDER_ID.Text = ds.Tables(0).Rows(0).Item("PROVIDER").ToString

                If ds.Tables(0).Rows(0).Item("REGISTERNO").ToString <> "" Then
                    txtRegisterno.Text = ds.Tables(0).Rows(0).Item("REGISTERNO").ToString
                End If

                If ds.Tables(0).Rows(0).Item("COUNCIL").ToString <> "" Then
                    txtCouncil.Text = ds.Tables(0).Rows(0).Item("COUNCIL").ToString
                    cboCouncil.EditValue = txtCouncil.Text
                End If
                If ds.Tables(0).Rows(0).Item("CID").ToString <> "" Then
                    txtCID.Text = (ds.Tables(0).Rows(0).Item("CID").ToString)
                    CheckCID(txtCID.Text)
                    tmpCID = (ds.Tables(0).Rows(0).Item("CID")).ToString
                End If
                If ds.Tables(0).Rows(0).Item("PRENAME_HOS").ToString <> "" Then
                    txtPrename.Text = ds.Tables(0).Rows(0).Item("PRENAME_HOS").ToString
                    cboPrename.EditValue = txtPrename.Text
                    CheckPRENAME(txtPrename.Text)
                End If
                If ds.Tables(0).Rows(0).Item("NAME").ToString <> "" Then
                    txtName.Text = (ds.Tables(0).Rows(0).Item("NAME")).ToString
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("LNAME")) Then
                    txtLName.Text = (ds.Tables(0).Rows(0).Item("LNAME")).ToString
                End If

                If ds.Tables(0).Rows(0).Item("SEX").ToString <> "" Then
                    txtSex.Text = ds.Tables(0).Rows(0).Item("SEX").ToString
                    cboSEX.EditValue = txtSex.Text
                End If

                txtBirth.EditValue = DateTime.ParseExact(ds.Tables(0).Rows(0).Item("BIRTH"), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture)

                txtStartDate.EditValue = DateTime.ParseExact(ds.Tables(0).Rows(0).Item("STARTDATE"), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture)
                If ds.Tables(0).Rows(0).Item("OUTDATE") <> "" Then
                    txtOutDate.EditValue = DateTime.ParseExact(ds.Tables(0).Rows(0).Item("OUTDATE"), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture)
                End If

                If ds.Tables(0).Rows(0).Item("PROVIDERTYPE") <> "" Then
                    txtProviderType.Text = ds.Tables(0).Rows(0).Item("PROVIDERTYPE").ToString
                End If

                If Not IsDBNull(ds.Tables(0).Rows(0).Item("PROVIDER_TYPE_HOSP")) Then
                    If ds.Tables(0).Rows(0).Item("PROVIDER_TYPE_HOSP") <> "" Then
                        txtProviderTypeHosp.Text = ds.Tables(0).Rows(0).Item("PROVIDER_TYPE_HOSP").ToString
                        cboPROVIDERTYPE.EditValue = txtProviderTypeHosp.Text
                    End If
                End If

                If ds.Tables(0).Rows(0).Item("MOVEFROM") <> "" Then
                    txtMoveForm.Text = ds.Tables(0).Rows(0).Item("MOVEFROM").ToString
                    lblHospName.Text = clsdataBus.Lc_Business.SELECT_NAME_HOSPITAL(txtMoveForm.Text)
                End If
                If ds.Tables(0).Rows(0).Item("MOVETO") <> "" Then
                    txtMoveTo.Text = ds.Tables(0).Rows(0).Item("MOVETO").ToString
                    lblHospName2.Text = clsdataBus.Lc_Business.SELECT_NAME_HOSPITAL(txtMoveTo.Text)
                End If

                If Not IsDBNull(ds.Tables(0).Rows(0).Item("CODE_ID")) Then
                    lblErrorCode.Text = ds.Tables(0).Rows(0).Item("CODE_ID")
                    LoadValidateResult(lblErrorCode.Text)
                End If


                If Not IsDBNull(ds.Tables(0).Rows(0).Item("POSITION")) Then
                    txtPOSITION.Text = ds.Tables(0).Rows(0).Item("POSITION")
                End If

                If Not IsDBNull(ds.Tables(0).Rows(0).Item("SERVICE")) Then
                    If ds.Tables(0).Rows(0).Item("SERVICE") = "1" Then
                        chkPorvider1.Checked = True
                        chkPorvider2.Checked = False
                    Else
                        chkPorvider2.Checked = True
                        chkPorvider1.Checked = False
                    End If
                Else
                    chkPorvider2.Checked = True
                End If

                If Not IsDBNull(ds.Tables(0).Rows(0).Item("TELEPHONE")) Then
                    txtTelephone.Text = ds.Tables(0).Rows(0).Item("TELEPHONE")
                End If

                If Not IsDBNull(ds.Tables(0).Rows(0).Item("EMAIL")) Then
                    txtEmail.Text = ds.Tables(0).Rows(0).Item("EMAIL")
                End If

                If Not IsDBNull(ds.Tables(0).Rows(0).Item("LINE")) Then
                    txtLine.Text = ds.Tables(0).Rows(0).Item("LINE")
                End If

                If vImage = "0" Then
                    If File.Exists(PicPer & txtCID.Text & ".png") = True Then
                        PictureBox1.Image = Image.FromFile(PicPer & txtCID.Text & ".png")
                    ElseIf File.Exists(PicPer & txtCID.Text & ".jpg") = True Then
                        PictureBox1.Image = Image.FromFile(PicPer & txtCID.Text & ".jpg")
                    Else
                        PictureBox1.Image = Image.FromFile(PicPer & "man.png")
                    End If
                Else
                    ShowImage()
                End If

                CheckData()
            End If
        End If

        txtRegisterno.Select()

    End Sub
    Private Sub ShowImage()
        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("IMG", " m_image_person ", " WHERE CID  = '" & txtCID.Text & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            Try
                Dim lb() As Byte = ds2.Tables(0).Rows(0).Item("IMG")
                Dim ms As MemoryStream = New MemoryStream(lb)
                Dim img As Image = Image.FromStream(ms)
                PictureBox1.Image = img
                ms.Close()
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub Council()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("COUNCIL_CODE, CONCAT('[',COUNCIL_CODE,'] ',COUNCIL_DESC) AS COUNCIL ", "l_council", "")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboCouncil
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "COUNCIL"
                .Properties.ValueMember = "COUNCIL_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
    End Sub
    Private Sub CboProvider()
        cboPROVIDERTYPE.Properties.DataSource = Nothing
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("PROVIDER_CODE,PROVIDER_DESC AS PROVIDER", "l_providertype_hosp", " ORDER BY PROVIDER_DESC")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboPROVIDERTYPE
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "PROVIDER"
                .Properties.ValueMember = "PROVIDER_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
    End Sub
    Private Sub Prename()
        Dim ds As DataSet
        ds = ClsBusiness.Lc_Business.SELECT_TABLE("PRENAME_DESC,PRENAME_CODE", " l_mypcu_prename", "WHERE STATUS_AF = '1' ORDER BY PRENAME_CODE + 0")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboPrename
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "PRENAME_DESC"
                .Properties.ValueMember = "PRENAME_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
    End Sub
    Private Sub Sex()
        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("*", " l_sex ", "")
        If ds2.Tables(0).Rows.Count > 0 Then
            With cboSEX
                .Properties.DataSource = ds2.Tables(0)
                .Properties.DisplayMember = "SEX"
                .Properties.ValueMember = "SEX_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
    End Sub
    Private Sub CheckData()
        ChkData = True
        If Trim(txtCouncil.Text.Replace("_", "")).Replace(" ", "") <> "" Then
            If CheckCOUNCIL(txtCouncil.Text) = False Then
                txtCouncil.BackColor = Color.LightPink
            Else
                txtCouncil.BackColor = Color.Beige
                cboCouncil.EditValue = txtCouncil.Text
            End If
        Else
            txtCouncil.BackColor = Color.Beige
        End If


        If Trim(txtCID.Text.Replace("_", "")).Replace(" ", "") = "" Then
            txtCID.BackColor = Color.LightPink
            ChkData = False
        Else
            If CheckCID(txtCID.Text) = False Then
                txtCID.BackColor = Color.Orange
                lblCIDError.Visible = True
            Else
                lblCIDError.Visible = False
                txtCID.BackColor = Color.Beige
            End If
        End If

        If txtPrename.Text = Nothing Then
            txtPrename.BackColor = Color.LightPink
            ChkData = False
        Else
            If CheckPRENAME(txtPrename.Text) = False Then
                txtPrename.BackColor = Color.LightPink
                ChkData = False
            Else
                txtPrename.BackColor = Color.Beige
                cboPrename.EditValue = txtPrename.Text
                txtSex.Text = clsdataBus.Lc_Business.SELECT_SEX(txtPrename.Text)
            End If
        End If
        If txtName.Text = "" Then
            txtName.BackColor = Color.LightPink
            ChkData = False
        Else
            txtName.BackColor = Color.Beige
        End If
        If txtLName.Text = "" Then
            txtLName.BackColor = Color.LightPink
            ChkData = False
        Else
            txtLName.BackColor = Color.Beige
        End If

        If txtSex.Text = Nothing Then
            txtSex.BackColor = Color.LightPink
            ChkData = False
        Else
            If txtSex.Text <> "1" And txtSex.Text <> "2" Then
                txtSex.BackColor = Color.LightPink
                ChkData = False
            Else
                txtSex.BackColor = Color.Beige
                cboSEX.EditValue = txtSex.Text
            End If
        End If

        If Trim(txtBirth.Text.Replace("_", "")).Replace("/", "") = "" Then
            txtBirth.BackColor = Color.LightPink
            ChkData = False
        Else
            If CheckDate(txtBirth.Text) = False Then
                txtBirth.BackColor = Color.LightPink
                ChkData = False
            Else
                txtBirth.BackColor = Color.Beige
            End If
            If CheckDateToday(CDate(txtBirth.Text).AddYears(-543).ToString("yyyyMMdd")) = False Then
                txtBirth.BackColor = Color.LightPink
                ChkData = False
            Else
                txtBirth.BackColor = Color.Beige
            End If
        End If
        If txtProviderTypeHosp.Text = Nothing Then
            txtProviderTypeHosp.BackColor = Color.LightPink
            ChkData = False
        Else
            If CheckPROVIDERTYPE(txtProviderTypeHosp.Text) = False Then
                txtProviderTypeHosp.BackColor = Color.LightPink
                ChkData = False
            Else
                txtProviderTypeHosp.BackColor = Color.Beige
                cboPROVIDERTYPE.EditValue = txtProviderTypeHosp.Text
            End If
        End If


        If Trim(txtStartDate.Text.Replace("_", "")).Replace("/", "") = "" Then
            txtStartDate.BackColor = Color.LightPink
            ChkData = False
        Else
            If CheckDate(txtStartDate.Text) = False Then
                txtStartDate.BackColor = Color.LightPink
                ChkData = False
            Else
                txtStartDate.BackColor = Color.Beige
            End If
            If CheckDateToday(CDate(txtStartDate.Text).AddYears(-543).ToString("yyyyMMdd")) = False Then
                txtStartDate.BackColor = Color.LightPink
                ChkData = False
            Else
                txtStartDate.BackColor = Color.Beige
            End If
        End If

        If Trim(txtProviderTypeHosp.Text.Replace("_", "")).Replace(" ", "") = "" Then
            txtProviderTypeHosp.BackColor = Color.LightPink
            ChkData = False
        Else
            CheckPROVIDERTYPE(txtProviderTypeHosp.Text)
        End If


    End Sub


    Private Sub cboProviderEdit_Click(sender As Object, e As EventArgs) Handles cboProviderEdit.Click
        Dim f As New frmProviderType
        f.ShowDialog()
        CboProvider()
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim ds As DataSet
        If chkCancle.Checked = False Then

            If Trim(txtCID.Text.Replace("_", "")).Replace(" ", "") = "" Then
                XtraMessageBox.Show("กรุณาใส่เลขประจำตัวประชาชนก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
                txtCID.Select()
            End If
            If txtName.Text.Trim = "" Then
                XtraMessageBox.Show("กรุณาใส่ชื่อก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
                txtName.Select()
            End If

            If txtLName.Text.Trim = "" Then
                XtraMessageBox.Show("กรุณาใส่นามสกุลก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
                txtLName.Select()
            End If
            If tmpAdd = True Then
                ds = clsdataBus.Lc_Business.SELECT_TABLE("CID", "m_provider", "WHERE CID = '" & (txtCID.Text.Replace("_", "").Replace(" ", "")) & "'")
                If ds.Tables(0).Rows.Count > 0 Then
                    XtraMessageBox.Show("ไม่สามารถบันทึกได้เนื่องจากมีข้อมูลผู้ให้บริการรายนี้แล้ว!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Else
                If txtCID.Text.Replace("_", "").Replace(" ", "") <> tmpCID Then
                    ds = clsdataBus.Lc_Business.SELECT_TABLE("CID", "m_provider", "WHERE CID = '" & (txtCID.Text.Replace("_", "").Replace(" ", "")) & "'")
                    If ds.Tables(0).Rows.Count > 0 Then
                        XtraMessageBox.Show("ไม่สามารถบันทึกได้เนื่องจากมีข้อมูลผู้ให้บริการรายนี้แล้ว!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End If
            End If
            If ChkData = False Then
                If XtraMessageBox.Show("การบันทึกข้อมูลยังไม่สมบูรณ์ คุณต้องการบันทึกหรือไม่" & vbCrLf & "กด OK หากต้องการบันทึก กด Cancel หากไม่ต้องการบันทึก", vProgram, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = System.Windows.Forms.DialogResult.Cancel Then
                    Exit Sub
                End If
            End If
        End If

        AddData()
    End Sub
    Private Sub AddData()
        SplashScreenManager1.ShowWaitForm()
        Dim ds As DataSet
        Dim tmpProviderId As String = ""

        CheckData()

        Dim tmpCID As String = Trim(txtCID.Text.Replace("_", ""))
        tmpCID = (Trim(tmpCID.Replace(" ", "")))
        Dim tmpCouncil As String = Trim(txtCouncil.Text.Replace("_", ""))
        Dim tmpPrename As String = clsdataBus.Lc_Business.SELECT_PRENAME_HOS(txtPrename.Text)
        Dim tmpPrenameHos As String = txtPrename.Text
        Dim tmpName As String = txtName.Text
        Dim tmpLname As String = txtLName.Text
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)
        Dim tmpSex As String = Trim(txtSex.Text.Replace("_", ""))
        Dim tmpBirth As String = ""
        If txtBirth.EditValue = Nothing Then
            tmpBirth = ""
        Else
            tmpBirth = CDate(txtBirth.EditValue).ToString("yyyyMMdd", System.Globalization.CultureInfo.GetCultureInfo("en-US"))
        End If
        Dim tmpStartDate As String = ""
        If txtStartDate.EditValue = Nothing Then
            tmpStartDate = ""
        Else
            tmpStartDate = CDate(txtStartDate.EditValue).ToString("yyyyMMdd", System.Globalization.CultureInfo.GetCultureInfo("en-US"))
        End If
        Dim tmpOutDate As String = ""
        Dim tmpStatus As String = ""
        If txtOutDate.EditValue = Nothing Then
            tmpOutDate = ""
            tmpStatus = "1"
        Else
            tmpOutDate = CDate(txtOutDate.EditValue).ToString("yyyyMMdd", System.Globalization.CultureInfo.GetCultureInfo("en-US"))
            tmpStatus = "0"
        End If
        Dim tmpProType As String = Trim(txtProviderTypeHosp.Text.Replace("_", ""))
        Dim tmpMoveFrom As String = Trim(txtMoveForm.Text.Replace("_", ""))
        Dim tmpMoveTo As String = Trim(txtMoveTo.Text.Replace("_", ""))

        Dim tmpStatusAF As String = ""
        If chkCancle.Checked = False Then
            tmpStatus = "1"
        Else
            tmpStatus = "0"
        End If

        Dim POSITION As String = ""
        If txtPOSITION.Text <> "" Then
            POSITION = txtPOSITION.Text
        Else
            POSITION = ""
        End If

        Dim tmpService As String = ""
        If chkPorvider1.Checked = True Then
            tmpService = "1"
        Else
            tmpService = "0"
        End If

        If tmpUpdate = True Then
            If tmpPROVIDER_ID <> lblPROVIDER_ID.Text Then
                clsbusent.Lc_BusinessEntity.Updatem_table("m_provider", " PROVIDER_OLD =  '" & tmpPROVIDER_ID & "'", " (PROVIDER_OLD = '' OR PROVIDER_OLD = PROVIDER) AND ROWID = '" & tmpROWID & "'")
                ds = clsdataBus.Lc_Business.SELECT_TABLE("M_TABLE", "l_table43", " WHERE M_TABLE <> 'PROVIDER' ORDER BY m_TABLE")
                If ds.Tables(0).Rows.Count > 0 Then
                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        Dim ds3 As DataSet
                        ds3 = clsdataBus.Lc_Business.SHOW_TABLE_COLUMN("m_" & ds.Tables(0).Rows(i).Item("M_TABLE").ToString.ToLower & " WHERE FIELD = 'PROVIDER' ")
                        Dim tmpMTable = "m_" & ds.Tables(0).Rows(i).Item("M_TABLE").ToString.ToLower
                        If ds3.Tables(0).Rows.Count = 1 Then
                            clsbusent.Lc_BusinessEntity.Updatem_table(tmpMTable, " PROVIDER =  '" & lblPROVIDER_ID.Text & "'", " PROVIDER = '" & tmpPROVIDER_ID & "'")
                        End If
                    Next

                End If
            End If

            clsbusent.Lc_BusinessEntity.Updatem_table("m_provider", "PROVIDER = '" & lblPROVIDER_ID.Text & "', REGISTERNO = '" & txtRegisterno.Text & "',COUNCIL = '" & tmpCouncil & "', CID = '" _
                                                      & tmpCID & "', PRENAME = '" & tmpPrename & "', PRENAME_HOS = '" & tmpPrenameHos & "',NAME = '" & tmpName & "',LNAME = '" & tmpLname & "',SEX = '" & tmpSex & "',BIRTH = '" _
                                                      & tmpBirth & "',PROVIDERTYPE = '" & txtProviderType.Text & "',PROVIDER_TYPE_HOSP = '" & tmpProType & "',STARTDATE = '" & tmpStartDate & "',POSITION = '" & POSITION & "',OUTDATE = '" _
                                                      & tmpOutDate & "',MOVEFROM = '" & tmpMoveFrom & "',MOVETO = '" & tmpMoveTo & "',USER_REC = '" & vUSERID & "',D_UPDATE = '" & tmpNow & "',STATUS = '" & tmpStatus & "',STATUS_AF = '2'," _
                                                      & "SERVICE = '" & tmpService & "',TELEPHONE  = '" & txtTelephone.Text & "',EMAIL = '" & txtEmail.Text & "',LINE = '" & txtLine.Text & "' ",
                                      "ROWID = '" & vPvdROWID & "'")



        Else
            Dim ds2 As DataSet
            If lblPROVIDER_ID.Text = "" Then
                ds = clsdataBus.Lc_Business.SELECT_TABLE("MAX(PROVIDER+0) AS PROVIDER_ID", " m_provider", "")
                If IsDBNull(ds.Tables(0).Rows(0).Item("PROVIDER_ID")) Then
                    tmpProviderId = 1.ToString("00000")
                Else
                    tmpProviderId = CInt(ds.Tables(0).Rows(0).Item("PROVIDER_ID") + 1).ToString("00000")
                End If
            Else
                tmpProviderId = lblPROVIDER_ID.Text
            End If

            clsbusent.Lc_BusinessEntity.Insertm_table("m_provider (HOSPCODE,PROVIDER,REGISTERNO,COUNCIL,CID,PRENAME,PRENAME_HOS,NAME," _
                                                      & "LNAME,SEX,BIRTH,PROVIDER_TYPE_HOSP,PROVIDERTYPE,STARTDATE,OUTDATE,MOVEFROM,MOVETO," _
                                                      & "D_UPDATE,USER_REC,STATUS,STATUS_AF,USER_STATUS,POSITION,MYDATA,SERVICE,TELEPHONE,EMAIL,LINE)",
                                            "'" & vHcode & "','" & tmpProviderId & "','" & txtRegisterno.Text & "','" & tmpCouncil & "'," _
                                            & "'" & tmpCID & "','" & tmpPrename & "','" & tmpPrenameHos & "','" & tmpName & "','" & tmpLname & "'," _
                                            & "'" & tmpSex & "','" & tmpBirth & "','" & tmpProType & "','" & txtProviderType.Text & "','" & tmpStartDate & "'," _
                                            & "'" & tmpOutDate & "','" & tmpMoveFrom & "','" & tmpMoveTo & "','" & tmpNow & "','" & vUSERID & "','1'," _
                                            & "'" & tmpStatusAF & "','1','" & POSITION & "','0','" & tmpService & "','" & txtTelephone.Text & "','" & txtEmail.Text & "','" & txtLine.Text & "'")

        End If
        SplashScreenManager1.CloseWaitForm()

        XtraMessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub txtRegisterno_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRegisterno.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                CheckData()
                If txtCouncil.Enabled = True Then
                    txtCouncil.Select()
                Else
                    txtCID.Select()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtRegisterno_Leave(sender As Object, e As EventArgs) Handles txtRegisterno.Leave
        CheckData()
    End Sub
    Private Sub txtCouncil_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCouncil.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                CheckData()
                txtCID.Select()
            End If
        Catch ex As Exception
            CheckData()
        End Try
    End Sub
    Private Sub txtCouncil_Leave(sender As Object, e As EventArgs) Handles txtCouncil.Leave
        CheckData()
    End Sub

    Private Sub cboCouncil_EditValueChanged(sender As Object, e As EventArgs) Handles cboCouncil.EditValueChanged
        txtCouncil.Text = cboCouncil.EditValue
        txtCID.Select()
        CheckData()
    End Sub
    Private Sub txtCID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCID.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If tmpUpdate = False And tmpCID <> txtCID.Text.Replace("_", "").Replace(" ", "") Then
                    Dim ds As DataSet
                    ds = clsdataBus.Lc_Business.SELECT_TABLE("CID", "m_provider", "WHERE CID = '" & (txtCID.Text.Replace("_", "").Replace(" ", "")) & "'")
                    If ds.Tables(0).Rows.Count > 0 Then
                        XtraMessageBox.Show("ไม่สามารถบันทึกได้เนื่องจากมีข้อมูลผู้ให้บริการรายนี้แล้ว!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End If

                CheckData()
                txtPrename.Select()
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub txtPrename_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrename.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                CheckData()
                txtName.Select()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtPrename_Leave(sender As Object, e As EventArgs) Handles txtPrename.Leave
        CheckData()
    End Sub
    Private Sub cboPrename_EditValueChanged(sender As Object, e As EventArgs) Handles cboPrename.EditValueChanged
        txtPrename.Text = cboPrename.EditValue
        CheckData()
        txtName.Select()
    End Sub
    Private Sub txtName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtName.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                CheckData()
                txtLName.Select()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtName_Leave(sender As Object, e As EventArgs) Handles txtName.Leave
        CheckData()
    End Sub
    Private Sub txtLName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLName.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                CheckData()
                If txtSex.Text = Nothing Then
                    txtSex.Select()
                Else
                    txtBirth.Select()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtLName_Leave(sender As Object, e As EventArgs) Handles txtLName.Leave
        CheckData()
    End Sub
    Private Sub txtSEX_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSex.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                CheckData()
                txtBirth.Select()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtSEX_Leave(sender As Object, e As EventArgs) Handles txtSex.Leave
        CheckData()
    End Sub
    Private Sub cboSEX_EditValueChanged(sender As Object, e As EventArgs) Handles cboSEX.EditValueChanged
        txtSex.Text = cboSEX.EditValue
        CheckData()
        txtBirth.Select()
    End Sub
    Private Sub txtProviderTypeHosp_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProviderTypeHosp.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                CheckData()
                txtStartDate.Select()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtProviderTypeHosp_Leave(sender As Object, e As EventArgs) Handles txtProviderTypeHosp.Leave
        CheckData()
    End Sub
    Private Sub cboPROVIDERTYPE_EditValueChanged(sender As Object, e As EventArgs) Handles cboPROVIDERTYPE.EditValueChanged
        txtProviderTypeHosp.Text = cboPROVIDERTYPE.EditValue
        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE(" PROVIDER_TYPE ", " l_providertype_hosp", " WHERE PROVIDER_CODE = '" & txtProviderType.Text & "' ")
        If ds2.Tables(0).Rows.Count > 0 Then
            txtProviderType.Text = ds2.Tables(0).Rows(0).Item("PROVIDER_TYPE")
        End If
        CheckData()
    End Sub


    Private Sub txtMoveForm_DragEnter(sender As Object, e As DragEventArgs) Handles txtMoveForm.DragEnter
        txtMoveTo.Text = vTmpHcode
    End Sub
    Private Sub txtMoveForm_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMoveForm.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                lblHospName.Text = clsdataBus.Lc_Business.SELECT_NAME_HOSPITAL(txtMoveForm.Text)
                txtMoveTo.Select()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtMoveForm_Leave(sender As Object, e As EventArgs) Handles txtMoveForm.Leave
        lblHospName.Text = clsdataBus.Lc_Business.SELECT_NAME_HOSPITAL(txtMoveForm.Text)
    End Sub
    Private Sub txtMoveTo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMoveTo.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                lblHospName2.Text = clsdataBus.Lc_Business.SELECT_NAME_HOSPITAL(txtMoveTo.Text)
                cmdSave.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtMoveTo_Leave(sender As Object, e As EventArgs) Handles txtMoveTo.Leave
        lblHospName2.Text = clsdataBus.Lc_Business.SELECT_NAME_HOSPITAL(txtMoveTo.Text)
    End Sub
    Private Sub cmdSearch1_Click(sender As Object, e As EventArgs) Handles cmdSearch1.Click
        Dim fHospSearch As New frmHospSearch
        fHospSearch.ShowDialog()
        txtMoveForm.Text = vTmpHcode
        lblHospName.Text = clsdataBus.Lc_Business.SELECT_NAME_HOSPITAL(txtMoveForm.Text)
        vTmpHcode = ""
    End Sub
    Private Sub cmdSearch2_Click(sender As Object, e As EventArgs) Handles cmdSearch2.Click
        Dim fHospSearch As New frmHospSearch
        fHospSearch.ShowDialog()
        txtMoveTo.Text = vTmpHcode
        lblHospName2.Text = clsdataBus.Lc_Business.SELECT_NAME_HOSPITAL(txtMoveTo.Text)
        vTmpHcode = ""
    End Sub
    Private Sub LoadValidateResult(ByVal strVal As String)
        Dim validateCode() As String
        Dim tmpErrorDesc As String = ""
        tmpErrorDesc2 = ""
        Try
            If strVal = "" Then
                Exit Sub
            Else
                validateCode = strVal.Split(CChar(","))
                For Each code As String In validateCode
                    Dim ds As DataSet
                    ds = clsdataBus.Lc_Business.SELECT_TABLE("ERROR_DESC", "l_configcheck", " WHERE ERROR_CODE = '" & code & "'")
                    If ds.Tables(0).Rows.Count > 0 Then
                        tmpErrorDesc = ds.Tables(0).Rows(0).Item("ERROR_DESC").ToString
                    End If
                    If tmpErrorDesc2 = "" Then
                        tmpErrorDesc2 = tmpErrorDesc
                    Else
                        tmpErrorDesc2 = tmpErrorDesc2 & "," & tmpErrorDesc
                    End If
                Next
            End If
        Catch ex As Exception

        End Try

        ToolTipController1.SetToolTip(lblErrorCode, tmpErrorDesc2.ToString)

    End Sub

    Private Sub cmdSmartCard_Click(sender As Object, e As EventArgs) Handles cmdSmartCard.Click
        Try
            smFname = ""
            smLname = ""
            smTitle = ""
            smDOB = ""
            smSex = ""

            Dim datePattern As String = "dd/MM/yyyy"
            Dim data As ThaiCitizenData = SmartCard.getThaiIDCardInfo(ThaiCardFactory.getCardDataReader())
            txtCID.Text = data.CitizenIdNumber

            smFname = data.CitizenNameThai.FirstName
            smLname = data.CitizenNameThai.LastName
            smTitle = data.CitizenNameThai.Title

            txtName.Text = data.CitizenNameThai.FirstName
            txtLName.Text = data.CitizenNameThai.LastName


            Try
                smDOB = data.DateOfBirth.getThaiDate().ToString(datePattern)
            Catch ex As Exception
                smDOB = ""
            End Try

            If data.Sex.getSexString = "ชาย" Then
                smSex = "1"
            Else
                smSex = "2"
            End If

            txtBirth.Text = smDOB
            txtSex.Text = smSex

            Dim picByte() As Byte = SmartCard.getThaiIDCardPictureOnly(ThaiCardFactory.getCardDataReader())
            Dim ms As MemoryStream = New MemoryStream(picByte)
            Dim img As Image = Image.FromStream(ms)
            PictureBox1.Image = img

            If vImage = "0" Then
                If File.Exists(PicPer & txtCID.Text & ".jpg") Then
                    FileSystem.Kill(PicPer & txtCID.Text & ".jpg")
                End If
                Dim fs = New BinaryWriter(New FileStream(PicPer & txtCID.Text & ".jpg", FileMode.Append, FileAccess.Write))
                fs.Write(picByte)
                fs.Close()
                fs.Dispose()
            ElseIf vImage = "1" Then
                SavePicture()
            Else
                SavePicture()
                If File.Exists(PicPer & txtCID.Text & ".jpg") Then
                    FileSystem.Kill(PicPer & txtCID.Text & ".jpg")
                End If
                Dim fs = New BinaryWriter(New FileStream(PicPer & txtCID.Text & ".jpg", FileMode.Append, FileAccess.Write))
                fs.Write(picByte)
                fs.Close()
                fs.Dispose()
            End If

        Catch ex As Exception

        End Try

        smFname = ""
        smLname = ""
        smTitle = ""
        smDOB = ""
        smSex = ""

        CheckData()
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
                dsi = clsdataBus.Lc_Business.SELECT_TABLE("CID", " m_image_person ", " WHERE CID = '" & txtCID.Text & "' ")


                If dsi.Tables(0).Rows.Count = 0 Then

                    SQL = "INSERT INTO m_image_person (CID,IMG,FILESIZE) VALUES(@CID,@IMG,@FILESIZE)"
                    If connpic.State = ConnectionState.Open Then
                        connpic.Close()
                    End If
                    connpic.ConnectionString = "Data Source=" & clsDataAcc.G_DBIPServer & ";port=" & clsDataAcc.G_DBPortServer & ";Database= his43;user id=" & clsDataAcc.G_DBUserName & ";password=" & clsDataAcc.G_DBPassword & ""
                    connpic.Open()
                    cmd.Connection = connpic
                    cmd.CommandText = SQL
                    cmd.Parameters.AddWithValue("@CID", txtCID.Text)
                    cmd.Parameters.AddWithValue("@IMG", Img)
                    cmd.Parameters.AddWithValue("@FILESIZE", FileSize)
                    cmd.ExecuteNonQuery()
                    connpic.Close()
                Else
                    SQL = "UPDATE m_image_person SET IMG = @IMG,FILESIZE = @FILESIZE WHERE CID = '" & txtCID.Text & "' "
                    connpic.ConnectionString = "Data Source=" & clsDataAcc.G_DBIPServer & ";port=" & clsDataAcc.G_DBPortServer & ";Database= his43;user id=" & clsDataAcc.G_DBUserName & ";password=" & clsDataAcc.G_DBPassword & ""
                    connpic.Open()
                    cmd.Connection = connpic
                    cmd.CommandText = SQL
                    cmd.Parameters.AddWithValue("@CID", txtCID.Text)
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

    Private Sub cmdPicture_Click(sender As Object, e As EventArgs) Handles cmdPicture.Click
        If txtCID.Text = "" Then
            XtraMessageBox.Show("เลือกผู้ให้บริการก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Me.XtraOpenFileDialog1.Filter = "PNG files (*.png)|*.png|JPEG files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif|All files (*.*)|*.*"
        If XtraOpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(XtraOpenFileDialog1.FileName)
            If vImage = "0" Then
                PictureBox1.Image.Save(PicPer & txtCID.Text & ".png", System.Drawing.Imaging.ImageFormat.Png)
            ElseIf vImage = "1" Then
                SavePicture()
            Else
                SavePicture()
                PictureBox1.Image.Save(PicPer & txtCID.Text & ".png", System.Drawing.Imaging.ImageFormat.Png)
            End If

        End If
    End Sub

    Private Sub cmdWebCam_Click(sender As Object, e As EventArgs) Handles cmdWebCam.Click
        If txtCID.Text.Replace("_", "") = "" Then
            XtraMessageBox.Show("เลือกผู้ให้บริการก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        vCidImage = txtCID.Text
        Dim fWebCam As New frmWebCam
        fWebCam.ShowDialog()
        vCidImage = ""
        ShowImage()
    End Sub

    Private Sub cmdFingerPrint_Click(sender As Object, e As EventArgs) Handles cmdFingerPrint.Click
        If txtCID.Text.Replace("_", "") = "" Then
            XtraMessageBox.Show("เลือกผู้ให้บริการก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        vfgCID = txtCID.Text
        Dim f As New frmFingerPrint
        f.ShowDialog()
        vfgCID = ""
    End Sub


    Private Sub cmdUser_Click(sender As Object, e As EventArgs) Handles cmdUser.Click
        Dim tmpCID As String = Encode(txtCID.Text)
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("USER_ID", " l_user ", " WHERE CID = '" & tmpCID & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            vUserSelectID = ds.Tables(0).Rows(0).Item("USER_ID")
        Else
            vUserSelectID = ""
            vUserSelectCID = txtCID.Text
        End If

        Dim f As New frmUserEdit
        f.ShowDialog()
        vUserSelectID = ""

    End Sub

    Private Sub cmdPrename_Click(sender As Object, e As EventArgs) Handles cmdPrename.Click
        Dim f As New frmLookupPrename
        f.ShowDialog()
        Prename()
    End Sub

    Private Sub chkPorvider1_Click(sender As Object, e As EventArgs) Handles chkPorvider1.Click
        chkPorvider1.Checked = True
        chkPorvider2.Checked = False
    End Sub

    Private Sub chkPorvider2_Click(sender As Object, e As EventArgs) Handles chkPorvider2.Click
        chkPorvider1.Checked = False
        chkPorvider2.Checked = True
    End Sub
End Class