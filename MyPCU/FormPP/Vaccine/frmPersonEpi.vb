Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Globalization
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class frmPersonEpi
    Dim tmpUpdate As Boolean = False
    Dim chkData As Boolean = False
    Dim tmpErrorDesc2 As String = ""
    Dim tmpVaccine As String = ""

    Private Sub frmPersonEpi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblErrorCode.Text = ""
        cboVaccineTypeAction()
        cboProviderAction()

        If vVaccineRowID <> "" Then
            Dim ds As New DataSet
            ds = clsdataBus.Lc_Business.SELECT_TABLE("DATE_SERV,VACCINETYPE,VACCINEPLACE,PROVIDER,LOT_NO,IFNULL(BOTTLE,'') AS BOTTLE,CODE_ID", "m_epi", "WHERE ROWID = '" & vVaccineRowID & "'")
            If ds.Tables(0).Rows.Count > 0 Then
                tmpUpdate = True

                If Not IsDBNull(ds.Tables(0).Rows(0).Item("DATE_SERV")) Then
                    If ds.Tables(0).Rows(0).Item("DATE_SERV") <> "" Then
                        txtDateServ.EditValue = DateTime.ParseExact(ds.Tables(0).Rows(0).Item("DATE_SERV"), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture)
                    End If
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("VACCINETYPE")) Then
                    txtVaccineTypeCode.Text = ds.Tables(0).Rows(0).Item("VACCINETYPE")
                    cboVaccineType.EditValue = txtVaccineTypeCode.Text
                    tmpVaccine = txtVaccineTypeCode.Text

                End If

                If Not IsDBNull(ds.Tables(0).Rows(0).Item("VACCINEPLACE")) Then
                    txtVaccinePlaceCode.Text = ds.Tables(0).Rows(0).Item("VACCINEPLACE")
                    txtVaccinePlaceName.Text = ClsBusiness.Lc_Business.SELECT_NAME_HOSPITAL(txtVaccinePlaceCode.Text)
                End If

                If Not IsDBNull(ds.Tables(0).Rows(0).Item("LOT_NO")) Then
                    txtLotNo.Text = ds.Tables(0).Rows(0).Item("LOT_NO")
                    'txtLotNo.Text = ClsBusiness.Lc_Business.SELECT_NAME_HOSPITAL(txtHOSP_RX.Text)
                End If

                If ds.Tables(0).Rows(0).Item("BOTTLE") <> "" Then
                    If IsNumeric(ds.Tables(0).Rows(0).Item("BOTTLE")) = True Then
                        numBottle.Value = ds.Tables(0).Rows(0).Item("BOTTLE")
                    End If
                End If

                If Not IsDBNull(ds.Tables(0).Rows(0).Item("PROVIDER")) Then
                    txtProviderCode.Text = ds.Tables(0).Rows(0).Item("PROVIDER")
                    cboProvider.EditValue = txtProviderCode.Text
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("CODE_ID")) Then
                    lblErrorCode.Text = ds.Tables(0).Rows(0).Item("CODE_ID")
                    LoadValidateResult(lblErrorCode.Text)
                End If
            End If
        End If



    End Sub
    Private Sub cboVaccineTypeAction()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("VACCINE_CODE,CONCAT('[',VACCINE_CODE,'] ',VACCINE_DESC_E) AS VACCINE_DESC", "l_vaccinetype ", " WHERE STATUS = '1' ORDER BY VACCINE_CODE")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboVaccineType
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "VACCINE_DESC"
                .Properties.ValueMember = "VACCINE_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = "พิมพ์เพื่อค้นหา"
            End With
        End If
    End Sub
    Private Sub cboProviderAction()
        Dim ds As DataSet

        ds = clsdataBus.Lc_Business.SELECT_TABLE("PROVIDER,CONCAT(b.PRENAME_DESC,' ',a.NAME,' ',a.LNAME) AS PROVIDER_NAME,SERVICE", " m_provider a JOIN l_mypcu_prename b ON(a.PRENAME_HOS = b.PRENAME_CODE)  ", " WHERE a.STATUS_AF <> '8' AND IFNULL(SERVICE,'') = '1'  ORDER BY PROVIDER ")
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

    Private Sub cboVaccineType_EditValueChanged(sender As Object, e As EventArgs) Handles cboVaccineType.EditValueChanged
        txtVaccineTypeCode.Text = cboVaccineType.EditValue
    End Sub

    Private Sub cboProvider_EditValueChanged(sender As Object, e As EventArgs) Handles cboProvider.EditValueChanged
        txtProviderCode.Text = cboProvider.EditValue
    End Sub

    Private Sub btnLookupHospital_Click(sender As Object, e As EventArgs) Handles btnLookupHospital.Click
        Dim fHospSearch As New frmHospSearch
        fHospSearch.ShowDialog()
        If vTmpHcode <> "" Then
            txtVaccinePlaceCode.Text = vTmpHcode
            txtVaccinePlaceName.Text = clsdataBus.Lc_Business.SELECT_NAME_HOSPITAL(vTmpHcode)
            chkUnkonw.Checked = False
            vTmpHcode = ""
        End If
    End Sub

    Private Sub txtVaccineTypeCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVaccineTypeCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboVaccineType.EditValue = txtVaccineTypeCode.Text
            txtVaccinePlaceCode.Select()
        End If
    End Sub
    Private Sub CheckHospDX()
        If txtVaccinePlaceCode.Text.Replace("_", "") <> "" And CheckHOSP(txtVaccinePlaceCode.Text) = False Then
            XtraMessageBox.Show("บันทึกรหัสหน่วยบริการไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtVaccinePlaceCode.BackColor = Color.LightPink
            txtVaccinePlaceName.Text = ""
        Else
            txtVaccinePlaceCode.BackColor = Color.Beige
            txtVaccinePlaceName.Text = clsdataBus.Lc_Business.SELECT_NAME_HOSPITAL(txtVaccinePlaceCode.Text)
        End If
    End Sub
    Private Sub txtVaccinePlaceCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVaccinePlaceCode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                CheckHospDX()
                txtLotNo.Select()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtVaccineTypeCode_Leave(sender As Object, e As EventArgs) Handles txtVaccineTypeCode.Leave
        cboVaccineType.EditValue = txtVaccineTypeCode.Text
    End Sub

    Private Sub txtVaccinePlaceCode_Leave(sender As Object, e As EventArgs) Handles txtVaccinePlaceCode.Leave
        CheckHospDX()
    End Sub

    Private Sub chkUnkonw_Click(sender As Object, e As EventArgs) Handles chkUnkonw.Click
        If chkUnkonw.Checked = True Then
            txtVaccinePlaceCode.Text = "00000"
            txtVaccinePlaceName.Text = clsdataBus.Lc_Business.SELECT_NAME_HOSPITAL(txtVaccinePlaceCode.Text)
        Else
            txtVaccinePlaceCode.Text = ""
            txtVaccinePlaceName.Text = ""
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        CheckData()
        If chkData = False Then
            XtraMessageBox.Show("บันทึกข้อมูลให้ครบถ้วนก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If CheckDateToday(CDate(txtDateServ.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))) = False Then
            XtraMessageBox.Show("บันทึกวันที่มากกว่าวันปัจจุบัน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If txtVaccinePlaceCode.Text <> "" Then
            CheckHospDX()
        End If

        If CheckPERSON(vEpiPID) = False Then
            XtraMessageBox.Show("ไม่สามารถบันทึกได้เนื่องจาก ไม่มีบุคคลดังกล่าว!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If txtVaccineTypeCode.Text = "" Then
            XtraMessageBox.Show("กำหนดรหัสวัคซีนก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtVaccineTypeCode.Select()
            txtVaccineTypeCode.SelectAll()
            Exit Sub
        End If
        If txtVaccinePlaceCode.Text = "" Then
            XtraMessageBox.Show("บันทึกสถานที่ให้วัคซีนก่อน! กรณีไม่ทราบให้ใส่ 00000 ", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtVaccinePlaceCode.Select()
            txtVaccinePlaceCode.SelectAll()
            Exit Sub
        End If
        If txtVaccinePlaceCode.Text = vHcode Then
            XtraMessageBox.Show("ไม่สามารถบันทึกได้ หากให้บริการเองต้องไปบันทึกหน้าการให้บริการ!!! ", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtVaccinePlaceCode.Select()
            txtVaccinePlaceCode.SelectAll()
            Exit Sub
        End If


        'Dim ds As DataSet
        'ds = clsdataBus.Lc_Business.SELECT_TABLE("A.ROWID ", "m_epi A JOIN l_vaccinetype B ON(A.VACCINETYPE = B.VACCINE_CODE)", " WHERE DUP = '1' AND PID = '" & vEpiPID & "' AND VACCINETYPE = '" & txtVaccineTypeCode.Text & "' AND A.STATUS_AF <> '8'")
        'If ds.Tables(0).Rows.Count > 0 Then
        '    XtraMessageBox.Show("ไม่สามารถบันทึกได้ เนื่องจากมีการบันทึกข้อมูลไว้แล้ว!!! ", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If

        Dim DATE_SERV As String = CDate(txtDateServ.Text).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))
        Dim VACCINETYPE As String = txtVaccineTypeCode.Text
        Dim VACCINEPLACE As String = txtVaccinePlaceCode.Text
        Dim LOT_NO As String = txtLotNo.Text
        Dim BOTTLE As String = numBottle.Value
        Dim PROVIDER As String = txtProviderCode.Text
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate_En()


        If tmpUpdate = False Then
            'Add Data

            Dim ds As DataSet
            ds = clsdataBus.Lc_Business.SELECT_TABLE("A.ROWID ", "m_epi A JOIN l_vaccinetype B ON(A.VACCINETYPE = B.VACCINE_CODE)", " WHERE DUP = '1' AND PID = '" & vEpiPID & "' AND VACCINETYPE = '" & txtVaccineTypeCode.Text & "' AND A.STATUS_AF <> '8'")
            If ds.Tables(0).Rows.Count > 0 Then
                XtraMessageBox.Show("ไม่สามารถบันทึกได้ เนื่องจากมีการบันทึกข้อมูลไว้แล้ว!!! ", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


            clsbusent.Lc_BusinessEntity.Insertm_table("m_epi (HOSPCODE,PID,SEQ,DATE_SERV,VACCINETYPE,VACCINEPLACE,LOT_NO,BOTTLE,PROVIDER,D_UPDATE,USER_REC,STATUS_AF)",
              "'" & vHcode & "','" & vEpiPID & "','','" & DATE_SERV & "','" & VACCINETYPE & "','" & VACCINEPLACE & "','" & LOT_NO & "','" & BOTTLE & "','" & PROVIDER & "','" & tmpNow & "','" & vUSERID & "','2'")
            XtraMessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
            tmpUpdate = True
        Else
            'Update Data

            If txtVaccineTypeCode.Text <> tmpVaccine Then
                Dim ds As DataSet
                ds = clsdataBus.Lc_Business.SELECT_TABLE("A.ROWID ", "m_epi A JOIN l_vaccinetype B ON(A.VACCINETYPE = B.VACCINE_CODE)", " WHERE DUP = '1' AND PID = '" & vEpiPID & "' AND VACCINETYPE = '" & txtVaccineTypeCode.Text & "' AND A.STATUS_AF <> '8'")
                If ds.Tables(0).Rows.Count > 0 Then
                    XtraMessageBox.Show("ไม่สามารถบันทึกได้ เนื่องจากมีการบันทึกข้อมูลไว้แล้ว!!! ", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
            clsbusent.Lc_BusinessEntity.Updatem_table("m_epi", "VACCINETYPE = '" & VACCINETYPE & "',VACCINEPLACE = '" _
                                          & VACCINEPLACE & "', DATE_SERV = '" & DATE_SERV & "',PROVIDER = '" & PROVIDER & "',D_UPDATE = '" & tmpNow & "',STATUS_AF = '2',LOT_NO = '" & txtLotNo.Text & "' ,BOTTLE = '" & BOTTLE & "'",
                          "ROWID = '" & vVaccineRowID & "'")
            XtraMessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

            End If
    End Sub
    Private Sub CheckData()
        chkData = True
        If txtDateServ.Text = Nothing Then
            txtDateServ.BackColor = Color.LightPink
            chkData = False
        Else
            txtDateServ.BackColor = Color.Beige
        End If

        If txtVaccineTypeCode.Text = "" Then
            txtVaccineTypeCode.BackColor = Color.LightPink
            chkData = False
        Else
            txtVaccineTypeCode.BackColor = Color.Beige
        End If

        If txtVaccinePlaceCode.Text = "" Then
            txtVaccinePlaceCode.BackColor = Color.LightPink
            chkData = False
        Else
            txtVaccinePlaceCode.BackColor = Color.Beige
        End If

        'If txtTYPEDISCH.Text.Replace("_", "") = "" Then
        '    txtTYPEDISCH.BackColor = Color.LightPink
        '    chkData = False
        'Else
        '    txtTYPEDISCH.BackColor = Color.Beige
        '    cboTYPEDISCH.EditValue = txtTYPEDISCH.Text
        'End If
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
End Class