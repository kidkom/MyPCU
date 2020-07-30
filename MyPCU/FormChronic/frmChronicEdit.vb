Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Globalization
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class frmChronicEdit
    Dim tmpUpdate As Boolean = False
    Dim chkData As Boolean = False
    Dim tmpErrorDesc2 As String = ""
    Dim tmpCHORNIC As String = ""
    Private Sub frmChronicEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblErrorCode.Text = ""
        cboTypedischAction()

        If vChronicRowID <> "" Then
            Dim ds As New DataSet
            ds = clsdataBus.Lc_Business.SELECT_TABLE("DATE_DIAG,CHRONIC,HOSP_DX,HOSP_RX,DATE_DISCH,TYPEDISCH,CODE_ID", "m_chronic", "WHERE ROWID = '" & vChronicRowID & "'")
            If ds.Tables(0).Rows.Count > 0 Then
                tmpUpdate = True

                If Not IsDBNull(ds.Tables(0).Rows(0).Item("DATE_DIAG")) Then
                    If ds.Tables(0).Rows(0).Item("DATE_DIAG") <> "" Then
                        txtDATE_DIAG.EditValue = DateTime.ParseExact(ds.Tables(0).Rows(0).Item("DATE_DIAG"), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture)
                    End If
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("CHRONIC")) Then
                    txtCHRONIC.Text = ds.Tables(0).Rows(0).Item("CHRONIC")
                    tmpCHORNIC = txtCHRONIC.Text
                    txtCHRONICDESC.Text = ClsBusiness.Lc_Business.SELECT_NAME_CHRONIC(txtCHRONIC.Text, "1")
                    ToolTipController1.SetToolTip(txtCHRONICDESC, clsdataBus.Lc_Business.SELECT_NAME_CHRONIC(txtCHRONIC.Text, "0"))
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("HOSP_DX")) Then
                    txtHOSP_DX.Text = ds.Tables(0).Rows(0).Item("HOSP_DX")
                    lblHOSP_DX.Text = ClsBusiness.Lc_Business.SELECT_NAME_HOSPITAL(txtHOSP_DX.Text)
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("HOSP_RX")) Then
                    txtHOSP_RX.Text = ds.Tables(0).Rows(0).Item("HOSP_RX")
                    lblHOSP_RX.Text = ClsBusiness.Lc_Business.SELECT_NAME_HOSPITAL(txtHOSP_RX.Text)
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("DATE_DISCH")) Then
                    If ds.Tables(0).Rows(0).Item("DATE_DISCH") <> "" Then
                        txtDATE_DISCH.Text = DateTime.ParseExact(ds.Tables(0).Rows(0).Item("DATE_DISCH"), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture)
                    End If
                End If
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("TYPEDISCH")) Then
                    txtTYPEDISCH.Text = ds.Tables(0).Rows(0).Item("TYPEDISCH")
                    cboTYPEDISCH.EditValue = txtTYPEDISCH.Text
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("CODE_ID")) Then
                    lblErrorCode.Text = ds.Tables(0).Rows(0).Item("CODE_ID")
                    LoadValidateResult(lblErrorCode.Text)
                End If

            End If

    End Sub
    Private Sub cboTypedischAction()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("TYPEDISCH_CODE,CONCAT('[',TYPEDISCH_CODE,'] ',TYPEDISCH_DESC) AS TYPEDISCH_DESC", "l_typedisch ", " WHERE STATUS = '1' ORDER BY TYPEDISCH_CODE")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboTYPEDISCH
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "TYPEDISCH_DESC"
                .Properties.ValueMember = "TYPEDISCH_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = "พิมพ์เพื่อค้นหา"
            End With
        End If
    End Sub
    Private Sub cmdHospDx_Click(sender As Object, e As EventArgs) Handles cmdHospDx.Click
        Dim fHospSearch As New frmHospSearch
        fHospSearch.ShowDialog()
        If vTmpHcode <> "" Then
            txtHOSP_DX.Text = vTmpHcode
            lblHOSP_DX.Text = clsdataBus.Lc_Business.SELECT_NAME_HOSPITAL(vTmpHcode)
            vTmpHcode = ""
        End If
    End Sub
    Private Sub cmdHospRx_Click(sender As Object, e As EventArgs) Handles cmdHospRx.Click
        Dim fHospSearch As New frmHospSearch
        fHospSearch.ShowDialog()
        If vTmpHcode <> "" Then
            txtHOSP_RX.Text = vTmpHcode
            lblHOSP_RX.Text = clsdataBus.Lc_Business.SELECT_NAME_HOSPITAL(vTmpHcode)
            vTmpHcode = ""
        End If
    End Sub
    Private Sub cmdChronicSearch_Click(sender As Object, e As EventArgs) Handles cmdChronicSearch.Click
        Dim f As New frmSearchChronic
        f.ShowDialog()
        If vChronicCode <> "" Then
            txtCHRONIC.Text = vChronicCode
            txtCHRONICDESC.Text = clsdataBus.Lc_Business.SELECT_NAME_CHRONIC(txtCHRONIC.Text, "1")
        End If
    End Sub

    Private Sub txtCHRONIC_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCHRONIC.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtCHRONIC.Text = "" Then
                txtCHRONICDESC.Select()
            Else
                CheckChronic()
                txtHOSP_DX.Select()
            End If

        End If
    End Sub

    Private Sub txtCHRONIC_Leave(sender As Object, e As EventArgs) Handles txtCHRONIC.Leave
        If txtCHRONIC.Text <> "" Then
            CheckChronic()
        End If

    End Sub
    Private Sub CheckChronic()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("CODE", "l_chronic", " WHERE CODE = '" & txtCHRONIC.Text & "' ")
        If ds.Tables(0).Rows.Count > 0 Then
            txtCHRONICDESC.Text = clsdataBus.Lc_Business.SELECT_NAME_CHRONIC(txtCHRONIC.Text, "1")
            ToolTipController1.SetToolTip(txtCHRONICDESC, clsdataBus.Lc_Business.SELECT_NAME_CHRONIC(txtCHRONIC.Text, "0"))
            txtCHRONIC.Text = txtCHRONIC.Text.ToUpper()
            txtCHRONIC.BackColor = Color.Beige
        Else
            XtraMessageBox.Show("รหัสโรคเรื้อรังไม่ถูกต้อง!!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCHRONIC.Select()
            txtCHRONIC.SelectAll()
            txtCHRONIC.BackColor = Color.LightPink
        End If

    End Sub
    Private Sub txtHOSP_DX_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHOSP_DX.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                CheckHospDX()
                txtHOSP_RX.Select()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtHOSP_DX_Leave(sender As Object, e As EventArgs) Handles txtHOSP_DX.Leave
        If txtHOSP_DX.Text <> "" Then
            CheckHospDX()
        End If

    End Sub
    Private Sub CheckHospDX()
        If txtHOSP_DX.Text.Replace("_", "") <> "" And CheckHOSP(txtHOSP_DX.Text) = False Then
            XtraMessageBox.Show("บันทึกรหัสหน่วยบริการไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtHOSP_DX.BackColor = Color.LightPink
            lblHOSP_RX.Text = ""
        Else
            txtHOSP_DX.BackColor = Color.Beige
            lblHOSP_DX.Text = clsdataBus.Lc_Business.SELECT_NAME_HOSPITAL(txtHOSP_DX.Text)
        End If
    End Sub
    Private Sub txtHOSP_RX_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHOSP_RX.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                CheckHospRX()
                txtDATE_DISCH.Select()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtHOSP_RX_Leave(sender As Object, e As EventArgs) Handles txtHOSP_RX.Leave
        If txtHOSP_RX.Text <> "" Then
            CheckHospRX()
        End If

    End Sub
    Private Sub CheckHospRX()
        If txtHOSP_RX.Text.Replace("_", "") <> "" And CheckHOSP(txtHOSP_RX.Text) = False Then
            XtraMessageBox.Show("บันทึกรหัสหน่วยบริการไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblHOSP_RX.Text = ""
            txtHOSP_RX.BackColor = Color.LightPink
        Else
            txtHOSP_RX.BackColor = Color.Beige
            lblHOSP_RX.Text = clsdataBus.Lc_Business.SELECT_NAME_HOSPITAL(txtHOSP_RX.Text)
        End If
    End Sub
    Private Sub txtTYPEDISCH_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTYPEDISCH.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If txtTYPEDISCH.Text.Replace("_", "") <> "" Then
                    Try
                        If CheckTYPEDISCH(txtTYPEDISCH.Text) = False Then
                            XtraMessageBox.Show("บันทึกประเภทสาเหตุการจำหน่ายหรือสถานะปัจจุบันไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Catch ex As Exception
                        txtTYPEDISCH.SelectAll()
                        Exit Sub
                    End Try
                End If
                DateDisch()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTYPEDISCH_Leave(sender As Object, e As EventArgs) Handles txtTYPEDISCH.Leave
        Try
            If CheckTYPEDISCH(txtTYPEDISCH.Text) = False Then
                XtraMessageBox.Show("บันทึกประเภทสาเหตุการจำหน่ายหรือสถานะปัจจุบันไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            cboTYPEDISCH.EditValue = txtTYPEDISCH.Text
            DateDisch()
        Catch ex As Exception
            txtTYPEDISCH.SelectAll()
            Exit Sub
        End Try

    End Sub

    Private Sub cboTYPEDISCH_EditValueChanged(sender As Object, e As EventArgs) Handles cboTYPEDISCH.EditValueChanged
        txtTYPEDISCH.Text = cboTYPEDISCH.EditValue
    End Sub
    Private Sub DateDisch()
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 4)
        If txtTYPEDISCH.Text <> "03" Then
            txtDATE_DISCH.EditValue = Now.ToString("dd/MM/yyyy")
        Else
            txtDATE_DISCH.EditValue = Nothing
        End If
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        CheckData()
        If chkData = False Then
            XtraMessageBox.Show("บันทึกข้อมูลให้ครบถ้วนก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If CheckDateToday(CDate(txtDATE_DIAG.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))) = False Then
            XtraMessageBox.Show("บันทึกวันที่มากกว่าวันปัจจุบัน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        CheckChronic()
        If txtHOSP_DX.Text <> "" Then
            CheckHospDX()
        End If
        If txtHOSP_RX.Text <> "" Then
            CheckHospRX()
        End If
        Dim DATE_DIAG As String = CDate(txtDATE_DIAG.EditValue).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))
        Dim CHRONIC As String = txtCHRONIC.Text
        Dim HOSP_DX As String = txtHOSP_DX.Text
        Dim HOSP_RX As String = txtHOSP_RX.Text
        Dim DATE_DISCH As String = ""
        If txtDATE_DISCH.EditValue <> Nothing Then
            DATE_DISCH = CDate(txtDATE_DISCH.Text).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))
        End If
        Dim TYPEDISCH As String = txtTYPEDISCH.Text
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate_En

        If tmpUpdate = False Then


            Dim ds As DataSet
            ds = clsdataBus.Lc_Business.SELECT_TABLE("ROWID ", "m_chronic", " WHERE PID = '" & vChonicPID & "' AND CHRONIC = '" & CHRONIC & "' AND STATUS_AF <> '8' AND TYPEDISCH = '03'")
            If ds.Tables(0).Rows.Count > 0 Then
                XtraMessageBox.Show("ไม่สามารถบันทึกได้เนื่องจากมีการบันทึกแล้ว!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            clsbusent.Lc_BusinessEntity.Insertm_table("m_chronic (HOSPCODE,PID,DATE_DIAG,CHRONIC,HOSP_DX,HOSP_RX,DATE_DISCH,TYPEDISCH,D_UPDATE,USER_REC,STATUS_AF,MYDATA)",
              "'" & vHcode & "','" & vChonicPID & "','" & DATE_DIAG & "','" & CHRONIC & "','" & HOSP_DX & "','" & HOSP_RX & "','" & DATE_DISCH & "','" & TYPEDISCH & "','" & tmpNow & "','" & vUSERID & "','2','0'")
            XtraMessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)

            tmpUpdate = True
        Else
            If txtCHRONIC.Text <> tmpCHORNIC Then
                Dim ds As DataSet
                ds = clsdataBus.Lc_Business.SELECT_TABLE("ROWID ", "m_chronic", " WHERE PID = '" & vChonicPID & "' AND CHRONIC = '" & CHRONIC & "' AND STATUS_AF <> '8' AND TYPEDISCH = '03'")
                If ds.Tables(0).Rows.Count > 0 Then
                    XtraMessageBox.Show("ไม่สามารถบันทึกได้เนื่องจากมีการบันทึกแล้ว!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
            clsbusent.Lc_BusinessEntity.Updatem_table("m_chronic", "DATE_DIAG = '" & DATE_DIAG & "',CHRONIC = '" & CHRONIC & "'" _
                                                      & ", HOSP_DX = '" & HOSP_DX & "',HOSP_RX = '" & HOSP_RX & "', DATE_DISCH = '" & DATE_DISCH & "',TYPEDISCH = '" & TYPEDISCH & "',D_UPDATE = '" & tmpNow & "', STATUS_AF = '2',USER_REC = '" & vUSERID & "', MYDATA = '2' " _
                                                      , "ROWID = '" & vChronicRowID & "'")
            XtraMessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub
    Private Sub CheckData()
        chkData = True
        If txtDATE_DIAG.Text = Nothing Then
            txtDATE_DIAG.BackColor = Color.LightPink
            chkData = False
        Else
            txtDATE_DIAG.BackColor = Color.Beige
        End If

        If txtCHRONIC.Text = "" Then
            txtCHRONIC.BackColor = Color.LightPink
            chkData = False
        Else
            txtCHRONIC.BackColor = Color.Beige
        End If



        If txtTYPEDISCH.Text.Replace("_", "") = "" Then
            txtTYPEDISCH.BackColor = Color.LightPink
            chkData = False
        Else
            txtTYPEDISCH.BackColor = Color.Beige
            cboTYPEDISCH.EditValue = txtTYPEDISCH.Text
        End If
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