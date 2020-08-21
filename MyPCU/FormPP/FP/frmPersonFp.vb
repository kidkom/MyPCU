Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Globalization
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Public Class frmPersonFp
    Dim tmpUpdate As Boolean = False
    Dim chkData As Boolean = False
    Dim tmpErrorDesc2 As String = ""
    Dim tmpFp As String = ""
    Dim tmpDateServe As String = ""

    Private Sub frmPersonFp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblErrorCode.Text = ""
        cboProviderAction()
        cboFptypeAction()

        If vFpRowID <> "" Then
            Dim ds As New DataSet
            ds = clsdataBus.Lc_Business.SELECT_TABLE("DATE_SERV,FPTYPE,FPPLACE,PROVIDER,CODE_ID,SEQ", "m_fp", "WHERE ROWID = '" & vFpRowID & "'")
            If ds.Tables(0).Rows.Count > 0 Then
                tmpUpdate = True

                If Not IsDBNull(ds.Tables(0).Rows(0).Item("DATE_SERV")) Then
                    If ds.Tables(0).Rows(0).Item("DATE_SERV") <> "" Then
                        txtDateServ.EditValue = DateTime.ParseExact(ds.Tables(0).Rows(0).Item("DATE_SERV"), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture)
                        tmpDateServe = txtDateServ.Text
                    End If
                End If

                If Not IsDBNull(ds.Tables(0).Rows(0).Item("FPTYPE")) Then
                    txtFpType.Text = ds.Tables(0).Rows(0).Item("FPTYPE")
                    cboFpType.EditValue = txtFpType.Text
                End If



                If Not IsDBNull(ds.Tables(0).Rows(0).Item("FPPLACE")) Then
                    txtFpPlaceCode.Text = ds.Tables(0).Rows(0).Item("FPPLACE")
                    txtFpPlaceName.Text = ClsBusiness.Lc_Business.SELECT_NAME_HOSPITAL(txtFpPlaceCode.Text)
                End If

                'If Not IsDBNull(ds.Tables(0).Rows(0).Item("LOT_NO")) Then
                '    txtLotNo.Text = ds.Tables(0).Rows(0).Item("LOT_NO")
                '    'txtLotNo.Text = ClsBusiness.Lc_Business.SELECT_NAME_HOSPITAL(txtHOSP_RX.Text)
                'End If

                'If ds.Tables(0).Rows(0).Item("BOTTLE") <> "" Then
                '        If IsNumeric(ds.Tables(0).Rows(0).Item("BOTTLE")) = True Then
                '            numBottle.Value = ds.Tables(0).Rows(0).Item("BOTTLE")
                '        End If
                '    End If

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
    Private Sub cboFptypeAction()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("FP_DESC,FP_CODE", " l_fptype", "")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboFpType
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "FP_DESC"
                .Properties.ValueMember = "FP_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(1).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = "พิมพ์เพื่อค้นหา"
            End With
        End If
    End Sub
    Private Sub cboFpType_EditValueChanged(sender As Object, e As EventArgs) Handles cboFpType.EditValueChanged
        txtFpType.Text = cboFpType.EditValue
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
    Private Sub cboProvider_EditValueChanged(sender As Object, e As EventArgs) Handles cboProvider.EditValueChanged
        txtProviderCode.Text = cboProvider.EditValue
    End Sub
    Private Sub btnLookupHospital_Click(sender As Object, e As EventArgs) Handles btnLookupHospital.Click
        Dim fHospSearch As New frmHospSearch
        fHospSearch.ShowDialog()
        If vTmpHcode <> "" Then
            txtFpPlaceCode.Text = vTmpHcode
            txtFpPlaceName.Text = clsdataBus.Lc_Business.SELECT_NAME_HOSPITAL(vTmpHcode)
            chkUnkonw.Checked = False
            vTmpHcode = ""

        End If
    End Sub
    Private Sub CheckHospDX()
        If txtFpPlaceCode.Text.Replace("_", "") <> "" And CheckHOSP(txtFpPlaceCode.Text) = False Then
            XtraMessageBox.Show("บันทึกรหัสหน่วยบริการไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFpPlaceCode.BackColor = Color.LightPink
            txtFpPlaceName.Text = ""
        Else
            txtFpPlaceCode.BackColor = Color.Beige
            txtFpPlaceName.Text = clsdataBus.Lc_Business.SELECT_NAME_HOSPITAL(txtFpPlaceCode.Text)
            chkUnkonw.Checked = False
        End If
    End Sub
    Private Sub chkUnkonw_Click(sender As Object, e As EventArgs) Handles chkUnkonw.Click
        If chkUnkonw.Checked = True Then
            txtFpPlaceCode.Text = "00000"
            txtFpPlaceName.Text = clsdataBus.Lc_Business.SELECT_NAME_HOSPITAL(txtFpPlaceCode.Text)
        Else
            txtFpPlaceCode.Text = ""
            txtFpPlaceName.Text = ""
        End If
    End Sub

    Private Sub txtFpType_Leave(sender As Object, e As EventArgs)
        txtFpPlaceCode.Select()
        txtFpPlaceCode.SelectAll()
    End Sub

    Private Sub txtFpPlaceCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFpPlaceCode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                CheckHospDX()
                cboProvider.Select()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtDateServ_Leave(sender As Object, e As EventArgs) Handles txtDateServ.Leave
        TimeEdit1.Select()
    End Sub

    Private Sub txtDateServ_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDateServ.KeyDown
        If e.KeyCode = Keys.Enter Then
            TimeEdit1.Select()
            TimeEdit1.SelectAll()
        End If
    End Sub
    Private Sub TimeEdit1_Leave(sender As Object, e As EventArgs) Handles TimeEdit1.Leave
        txtFpType.Select()
    End Sub

    Private Sub TimeEdit1_KeyDown(sender As Object, e As KeyEventArgs) Handles TimeEdit1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtFpType.Select()
            txtFpType.SelectAll()
        End If
    End Sub

    Private Sub txtFpType_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFpType.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboFpType.EditValue = txtFpType.Text
            txtFpPlaceCode.Select()
            txtFpPlaceCode.SelectAll()
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

        If txtFpPlaceCode.Text <> "" Then
            CheckHospDX()
        End If

        If CheckPERSON(vFpPID) = False Then
            XtraMessageBox.Show("ไม่สามารถบันทึกได้เนื่องจาก ไม่มีบุคคลดังกล่าว!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If txtFpType.Text = "" Then
            XtraMessageBox.Show("บันทึกประเภทการรับบริการก่อน !!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFpType.Select()
            txtFpType.SelectAll()
            Exit Sub
        End If

        If txtFpPlaceCode.Text = vHcode Then
            XtraMessageBox.Show("ไม่สามารถบันทึกได้ หากให้บริการเองต้องไปบันทึกหน้าการให้บริการ!!! ", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFpPlaceCode.Select()
            txtFpPlaceCode.SelectAll()
            Exit Sub
        End If


        'Dim ds As DataSet
        'ds = clsdataBus.Lc_Business.SELECT_TABLE("A.ROWID ", "m_epi A JOIN l_vaccinetype B ON(A.VACCINETYPE = B.VACCINE_CODE)", " WHERE DUP = '1' AND PID = '" & vEpiPID & "' AND VACCINETYPE = '" & txtVaccineTypeCode.Text & "' AND A.STATUS_AF <> '8'")
        'If ds.Tables(0).Rows.Count > 0 Then
        '    XtraMessageBox.Show("ไม่สามารถบันทึกได้ เนื่องจากมีการบันทึกข้อมูลไว้แล้ว!!! ", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If

        Dim DATE_SERV As String = CDate(txtDateServ.Text).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))
        Dim FPTYPE As String = txtFpType.Text
        Dim FPPLACE As String = txtFpPlaceCode.Text
        Dim PROVIDER As String = txtProviderCode.Text
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate_En()


        If tmpUpdate = False Then
            'Add Data

            Dim ds As DataSet
            ds = clsdataBus.Lc_Business.SELECT_TABLE("ROWID ", "m_fp", " WHERE PID = '" & vFpPID & "' AND DATE_SERV = '" & txtDateServ.Text & "' AND STATUS_AF <> '8'")
            If ds.Tables(0).Rows.Count > 0 Then
                XtraMessageBox.Show("ไม่สามารถบันทึกได้ เนื่องจากมีการบันทึกข้อมูลไว้แล้ว!!! ", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


            clsbusent.Lc_BusinessEntity.Insertm_table("m_fp (HOSPCODE,PID,SEQ,DATE_SERV,FPPLACE,FPTYPE,PROVIDER,D_UPDATE,USER_REC,STATUS_AF)",
              "'" & vHcode & "','" & vFpPID & "','','" & DATE_SERV & "','" & FPPLACE & "','" & FPTYPE & "','" & PROVIDER & "','" & tmpNow & "','" & vUSERID & "','2'")
            XtraMessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
            tmpUpdate = True
        Else
            'Update Data

            If txtDateServ.Text <> tmpDateServe Then
                Dim ds As DataSet
                ds = clsdataBus.Lc_Business.SELECT_TABLE("ROWID ", "m_fp", " WHERE  PID = '" & vFpPID & "' AND DATE_SERV = '" & DATE_SERV & "' AND STATUS_AF <> '8'")
                If ds.Tables(0).Rows.Count > 0 Then
                    XtraMessageBox.Show("ไม่สามารถบันทึกได้ เนื่องจากมีการบันทึกข้อมูลไว้แล้ว!!! ", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
            clsbusent.Lc_BusinessEntity.Updatem_table("m_fp", "FPTYPE = '" & FPTYPE & "',FPPLACE = '" _
                                          & FPPLACE & "', DATE_SERV = '" & DATE_SERV & "',PROVIDER = '" & PROVIDER & "',D_UPDATE = '" & tmpNow & "',STATUS_AF = '2'" _
                                          , "ROWID = '" & vFpRowID & "'")
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

        If txtFpType.Text = "" Then
            txtFpType.BackColor = Color.LightPink
            chkData = False
        Else
            txtFpType.BackColor = Color.White
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