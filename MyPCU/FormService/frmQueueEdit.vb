Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Globalization
Imports System.IO
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmQueueEdit
    Dim tmpCID As String = ""
    Private Sub frmQueueEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPID.Select()
        Label16.Visible = False
        txtHospInRefer.Visible = False
        GroupControl3.Enabled = False
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
        PateinReson()
        cboProviderAction()
        PatienStatus()
        ShowClinic()
        cboClinic.EditValue = vClinic
        ShowRoom()
    End Sub
    Private Sub PateinReson()
        Dim ds3 As DataSet
        ds3 = ClsBusiness.Lc_Business.SELECT_TABLE("PT_REASON,PT_REASON_CODE", "l_pt_reason", "")
        If ds3.Tables(0).Rows.Count > 0 Then
            With cboPtReason
                .Properties.DataSource = ds3.Tables(0)
                .Properties.DisplayMember = "PT_REASON"
                .Properties.ValueMember = "PT_REASON_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        Else
            cboPtReason.Properties.NullText = "ยังไม่มีการกำหนดรายการ"
        End If
    End Sub
    Private Sub cboProviderAction()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("PROVIDER,CONCAT(b.PRENAME_DESC,' ',a.NAME,' ',a.LNAME) AS PROVIDER_NAME", " m_provider a JOIN l_mypcu_prename b ON(a.PRENAME_HOS = b.PRENAME_CODE)  ", " WHERE a.STATUS_AF <> '8' AND IFNULL(SERVICE,'') = '1'  ORDER BY PROVIDER ")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboProvider
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "PROVIDER_NAME"
                .Properties.ValueMember = "PROVIDER"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = "พิมพ์เพื่อค้นหา"
            End With
        End If
    End Sub
    Private Sub PatienStatus()
        Dim ds4 As DataSet
        ds4 = ClsBusiness.Lc_Business.SELECT_TABLE("PT_STATUS,PT_STATUS_CODE", "l_pt_status", "")
        If ds4.Tables(0).Rows.Count > 0 Then
            With cboPtStatus
                .Properties.DataSource = ds4.Tables(0)
                .Properties.DisplayMember = "PT_STATUS"
                .Properties.ValueMember = "PT_STATUS_CODE"
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
                '.EditValue = "001"
            End With
        Else
            cboPtStatus.Properties.NullText = "ยังไม่มีการกำหนดรายการ"
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
        txtClinic.Text = vClinic
        cboClinic.EditValue = vClinic

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
            Else
                If txtPID.Text.Length = 13 Then
                    chkName.Checked = False
                    chkPID.Checked = True
                    chkCID.Checked = False
                End If
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
    Private Sub SearchData()
        ClearData()
        Dim tmpPrename As String = ""
        Dim tmpDOB As String = ""
        Dim tmpAge As String = ""
        Dim tmpD As String = ""
        Dim tmpM As String = ""
        Dim tmpY As String = ""
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("PID,HID,HN,CID,IFNULL(PRENAME_DESC,'') AS  PRENAME_DESC,NAME,LNAME,s.SEX,IFNULL(BIRTH,'') AS BIRTH,DISCHARGE," _
            & "TIMESTAMPDIFF(YEAR, BIRTH, Now()) As AGE_YEAR,TIMESTAMPDIFF( MONTH, BIRTH, now() ) % 12 As AGE_MONTH," _
            & "FLOOR( TIMESTAMPDIFF( DAY, BIRTH, now() ) % 30.4375 ) AS AGE_DAY", " m_person a LEFT JOIN l_mypcu_prename b ON(a.PRENAME_HOS = b.PRENAME_CODE) LEFT JOIN l_sex s ON(a.SEX = s.SEX_CODE) ", " WHERE CID = '" & tmpCID & "' AND a.STATUS_AF <> '8' ")
        If ds.Tables(0).Rows.Count > 0 Then
            lblPID.Text = ds.Tables(0).Rows(0).Item("PID").ToString
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
            GroupControl3.Enabled = True
            CardSearch()
            If ds.Tables(0).Rows(0).Item("DISCHARGE") <> "9" Then
                XtraMessageBox.Show("จำหน่ายหรือเสียชีวิตแล้วไม่สามารถให้บริการได้!!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                AccordionControlElement14.Enabled = False
                txtPID.Select()
            Else
                chkRefer0.Checked = True
                txtCauseIn.Select()
            End If
        Else
            ClearData()
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
        lblCID.Text = Nothing
        lblName.Text = ""
        lblLNAME.Text = ""
        lblBirth.Text = ""
        lblAge.Text = ""
        lblSex.Text = ""
        PictureEdit1.Image = Image.FromFile(Application.StartupPath & "\images\person.png")
        AccordionControlElement14.Enabled = True
        GroupControl3.Enabled = False
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
    Private Sub CardSearch()
        Dim ds As DataSet
        Try
            ds = clsdataBus.Lc_Business.SELECT_DATA("m_card", "WHERE PID = '" & lblPID.Text & "' AND STATUS_AF <> '8'")
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("INSTYPE_OLD")) Then
                    lblINTYPE_OLD.Text = ClsBusiness.Lc_Business.SELECT_NAME_INSTYPE_OLD(ds.Tables(0).Rows(0).Item("INSTYPE_OLD"))
                    txtINTYPE_OLD.Text = ds.Tables(0).Rows(0).Item("INSTYPE_OLD")
                Else
                    lblINTYPE_OLD.Text = ""
                    txtINTYPE_OLD.Text = ""
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("INSTYPE_NEW")) Then
                    lblINTYPE_NEW.Text = ClsBusiness.Lc_Business.SELECT_NAME_INSTYPE_NEW(ds.Tables(0).Rows(0).Item("INSTYPE_NEW"))
                    txtINTYPE_NEW.Text = ds.Tables(0).Rows(0).Item("INSTYPE_NEW")
                Else
                    lblINTYPE_NEW.Text = ""
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("INSID")) Then
                    lblINSID.Text = ds.Tables(0).Rows(0).Item("INSID")
                Else
                    lblINSID.Text = ""
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("MAIN")) Then
                    lblMAIN.Text = ClsBusiness.Lc_Business.SELECT_NAME_HOSPITAL(ds.Tables(0).Rows(0).Item("MAIN"))
                    txtMAIN.Text = ds.Tables(0).Rows(0).Item("MAIN")
                Else
                    lblMAIN.Text = ""
                    txtMAIN.Text = ""
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("SUB")) Then
                    lblSUB.Text = ClsBusiness.Lc_Business.SELECT_NAME_HOSPITAL(ds.Tables(0).Rows(0).Item("SUB"))
                    txtSUB.Text = ds.Tables(0).Rows(0).Item("SUB")
                Else
                    lblSUB.Text = ""
                    txtSUB.Text = ""
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("EXPIREDATE")) And ds.Tables(0).Rows(0).Item("EXPIREDATE") <> "" Then
                    lblEXPIREDATE.Text = DateTime.ParseExact(ds.Tables(0).Rows(0).Item("EXPIREDATE").ToString.Substring(0, 4) + 543 & ds.Tables(0).Rows(0).Item("EXPIREDATE").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy")
                Else
                    lblEXPIREDATE.Text = ""
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("STATUS_NHSO")) Then
                    If ds.Tables(0).Rows(0).Item("STATUS_NHSO") = "003" Then
                        txtStatusNhso.Text = "จำหน่ายหรือเสียชีวิตแล้ว"
                        txtStatusNhso.BackColor = Color.LightPink
                    Else
                        txtStatusNhso.Text = "ปกติ"
                        txtStatusNhso.BackColor = Color.White
                    End If
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("MODEL")) Then
                    lblType.Text = ds.Tables(0).Rows(0).Item("MODEL")
                Else
                    lblType.Text = ""
                End If
            Else
                ClearCard()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ClearCard()
        lblINTYPE_NEW.Text = ""
        txtINTYPE_NEW.Text = ""
        lblINTYPE_OLD.Text = ""
        txtINTYPE_OLD.Text = ""
        lblMAIN.Text = ""
        txtMAIN.Text = ""
        lblSUB.Text = ""
        txtSUB.Text = ""
        lblINSID.Text = ""
        lblEXPIREDATE.Text = ""
        txtINSTYPE_NEW.Text = "9100"
        cboINSTYPE_NEW.EditValue = txtINSTYPE_NEW.Text
        txtStatusNhso.Text = ""
        lblType.Text = ""
    End Sub
    Private Sub chkRefer0_Click(sender As Object, e As EventArgs) Handles chkRefer0.Click
        chkRefer0.Checked = True
        chkRefer1.Checked = False
        chkRefer2.Checked = False
        Label16.Visible = False
        txtHospInRefer.Visible = False
    End Sub
    Private Sub chkRefer1_Click(sender As Object, e As EventArgs) Handles chkRefer1.Click
        chkRefer0.Checked = False
        chkRefer1.Checked = True
        chkRefer2.Checked = False
        Label16.Visible = False
        txtHospInRefer.Visible = False
    End Sub
    Private Sub chkRefer2_Click(sender As Object, e As EventArgs) Handles chkRefer2.Click
        chkRefer0.Checked = False
        chkRefer2.Checked = True
        Dim f As New frmReferInEdit
        f.ShowDialog()
        If vReferinHosp <> "" Then
            Label16.Visible = True
            txtHospInRefer.Visible = True
            txtHospInRefer.Text = ClsBusiness.Lc_Business.SELECT_NAME_HOSPITAL(vReferinHosp)
        Else
            Label16.Visible = False
            txtHospInRefer.Visible = False
            chkRefer0.Checked = True
            chkRefer1.Checked = False
            chkRefer2.Checked = False
        End If
    End Sub
    Private Sub AccordionControlElement14_Click(sender As Object, e As EventArgs) Handles AccordionControlElement14.Click
        '****** Clear Referin
        vReferinType = ""
        vReferinHosp = ""
        vReferinCause = ""
        vReferinNo = ""
        vReferinDateExpire = ""
    End Sub
    Private Sub btnPtResonEdit_Click(sender As Object, e As EventArgs) Handles btnPtResonEdit.Click
        Dim f As New frmReasonToService
        f.ShowDialog()
        PateinReson()
    End Sub
    Private Sub txtCauseIn_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCauseIn.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboPtReason.EditValue = txtCauseIn.Text
            If cboPtReason.Text = "" Then
                XtraMessageBox.Show(mDataMiss, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtCauseIn.Select()
                txtCauseIn.SelectAll()
            Else
                txtPtStatus.Select()
            End If
        End If
    End Sub
    Private Sub txtCauseIn_Leave(sender As Object, e As EventArgs) Handles txtCauseIn.Leave
        If txtCauseIn.Text <> "" Then
            If cboPtReason.Text = "" Then
                XtraMessageBox.Show(mDataMiss, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtCauseIn.Select()
                txtCauseIn.SelectAll()
            End If
        End If
    End Sub
    Private Sub btnPtStatus_Click(sender As Object, e As EventArgs) Handles btnPtStatus.Click
        Dim f As New frmPtStatus
        f.ShowDialog()
        PatienStatus()
    End Sub
    Private Sub txtPtStatus_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPtStatus.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboPtStatus.EditValue = txtPtStatus.Text
            If cboPtStatus.Text = "" Then
                XtraMessageBox.Show(mDataMiss, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtPtStatus.Select()
                txtPtStatus.SelectAll()
            Else
                ImageComboBoxEdit1.Select()
            End If
        End If
    End Sub
    Private Sub cboPtReason_EditValueChanged(sender As Object, e As EventArgs) Handles cboPtReason.EditValueChanged
        txtCauseIn.Text = cboPtReason.EditValue
    End Sub
    Private Sub cboPtStatus_EditValueChanged(sender As Object, e As EventArgs) Handles cboPtStatus.EditValueChanged
        txtPtStatus.Text = cboPtReason.EditValue
    End Sub

    Private Sub cboProvider_EditValueChanged(sender As Object, e As EventArgs) Handles cboProvider.EditValueChanged
        txtProvider.Text = cboProvider.EditValue
    End Sub

    Private Sub txtProvider_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProvider.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboProvider.EditValue = txtProvider
            If cboProvider.Text = "" Then
                XtraMessageBox.Show(mDataMiss, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtProvider.Select()
                txtProvider.SelectAll()
            End If
        End If
    End Sub
    Private Sub ShowRoom()
        Dim ds As DataSet
        ds = ClsBusiness.Lc_Business.SELECT_TABLE("ROOM,DOCTOR", "m_doctor_room", " WHERE CLINIC = '" & cboClinic.EditValue & "' AND IFNULL(DOCTOR,'') <> '' AND IFNULL(DEPARTMENT,'') = '' ")

        If ds.Tables(0).Rows.Count > 0 Then
            cboRoom.Enabled = True
            With cboRoom
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "ROOM"
                .Properties.ValueMember = "DOCTOR"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        Else
            cboRoom.Enabled = False
        End If
    End Sub
    Private Sub cboClinic_EditValueChanged(sender As Object, e As EventArgs) Handles cboClinic.EditValueChanged
        cboRoom.Properties.DataSource = Nothing
        ShowRoom()
    End Sub

    Private Sub cboRoom_EditValueChanged(sender As Object, e As EventArgs) Handles cboRoom.EditValueChanged
        txtProvider.Text = cboRoom.EditValue
        cboProvider.EditValue = txtProvider.Text
    End Sub
End Class
