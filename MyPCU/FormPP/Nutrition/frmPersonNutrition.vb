Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Globalization
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class frmPersonNutrition
    Dim tmpUpdate As Boolean = False
    Dim chkData As Boolean = False
    Dim tmpErrorDesc2 As String = ""
    Dim tmpNutrition As String = ""
    Dim tmpDateServe As String = ""
    Private Sub frmPersonNutrition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblErrorCode.Text = ""
        cboProviderAction()

        If vNutritionRowID <> "" Then
            Dim ds As New DataSet
            ds = clsdataBus.Lc_Business.SELECT_TABLE("DATE_SERV,WEIGHT,HEIGHT,HEADCIRCUM,CHILDDEVELOP,FOOD,BOTTLE,NUTRITIONPLACE,PROVIDER,CODE_ID,SEQ", "m_nutrition", "WHERE ROWID = '" & vNutritionRowID & "'")
            If ds.Tables(0).Rows.Count > 0 Then
                tmpUpdate = True

                If Not IsDBNull(ds.Tables(0).Rows(0).Item("DATE_SERV")) Then
                    If ds.Tables(0).Rows(0).Item("DATE_SERV") <> "" Then
                        txtDateServ.EditValue = DateTime.ParseExact(ds.Tables(0).Rows(0).Item("DATE_SERV"), "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture)
                        tmpDateServe = txtDateServ.Text
                    End If
                End If

                If Not IsDBNull(ds.Tables(0).Rows(0).Item("WEIGHT")) Then
                    txtWeight.Text = ds.Tables(0).Rows(0).Item("WEIGHT")
                End If

                If Not IsDBNull(ds.Tables(0).Rows(0).Item("HEIGHT")) Then
                    txtHeight.Text = ds.Tables(0).Rows(0).Item("HEIGHT")
                End If

                If Not IsDBNull(ds.Tables(0).Rows(0).Item("HEADCIRCUM")) Then
                    txtHeadCircum.Text = ds.Tables(0).Rows(0).Item("HEADCIRCUM")
                End If

                txtChildDevelope.Text = ds.Tables(0).Rows(0).Item("CHILDDEVELOP")

                If ds.Tables(0).Rows(0).Item("CHILDDEVELOP") = "1" Then
                    chkChildDevelop1.Checked = True
                ElseIf ds.Tables(0).Rows(0).Item("CHILDDEVELOP") = "2" Then
                    chkChildDevelop2.Checked = True
                ElseIf ds.Tables(0).Rows(0).Item("CHILDDEVELOP") = "3" Then
                    chkChildDevelop3.Checked = True
                End If

                txtFood.Text = ds.Tables(0).Rows(0).Item("FOOD")

                If ds.Tables(0).Rows(0).Item("FOOD") = "0" Then
                    chkFood0.Checked = True
                ElseIf ds.Tables(0).Rows(0).Item("FOOD") = "1" Then
                    chkFood1.Checked = True
                ElseIf ds.Tables(0).Rows(0).Item("FOOD") = "2" Then
                    chkFood2.Checked = True
                ElseIf ds.Tables(0).Rows(0).Item("FOOD") = "3" Then
                    chkFood3.Checked = True
                ElseIf ds.Tables(0).Rows(0).Item("FOOD") = "4" Then
                    chkFood4.Checked = True
                ElseIf ds.Tables(0).Rows(0).Item("FOOD") = "5" Then
                    chkFood5.Checked = True
                End If

                If ds.Tables(0).Rows(0).Item("SEQ") <> "" Then
                    btnSave.Enabled = False
                End If

            End If

            txtBottle.Text = ds.Tables(0).Rows(0).Item("BOTTLE")

            If ds.Tables(0).Rows(0).Item("BOTTLE") = "1" Then
                chkBottle1.Checked = True
            ElseIf ds.Tables(0).Rows(0).Item("BOTTLE") = "2" Then
                chkBottle2.Checked = True

            End If

        If Not IsDBNull(ds.Tables(0).Rows(0).Item("NUTRITIONPLACE")) Then
                txtNutritionPlaceCode.Text = ds.Tables(0).Rows(0).Item("NUTRITIONPLACE")
                txtNutritionPlaceName.Text = ClsBusiness.Lc_Business.SELECT_NAME_HOSPITAL(txtNutritionPlaceCode.Text)
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
            txtNutritionPlaceCode.Text = vTmpHcode
            txtNutritionPlaceName.Text = clsdataBus.Lc_Business.SELECT_NAME_HOSPITAL(vTmpHcode)
            chkUnkonw.Checked = False
            vTmpHcode = ""

        End If
    End Sub
    Private Sub CheckHospDX()
        If txtNutritionPlaceCode.Text.Replace("_", "") <> "" And CheckHOSP(txtNutritionPlaceCode.Text) = False Then
            XtraMessageBox.Show("บันทึกรหัสหน่วยบริการไม่ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtNutritionPlaceCode.BackColor = Color.LightPink
            txtNutritionPlaceName.Text = ""
        Else
            txtNutritionPlaceCode.BackColor = Color.Beige
            txtNutritionPlaceName.Text = clsdataBus.Lc_Business.SELECT_NAME_HOSPITAL(txtNutritionPlaceCode.Text)
            chkUnkonw.Checked = False
        End If
    End Sub
    Private Sub chkUnkonw_Click(sender As Object, e As EventArgs) Handles chkUnkonw.Click
        If chkUnkonw.Checked = True Then
            txtNutritionPlaceCode.Text = "00000"
            txtNutritionPlaceName.Text = clsdataBus.Lc_Business.SELECT_NAME_HOSPITAL(txtNutritionPlaceCode.Text)
        Else
            txtNutritionPlaceCode.Text = ""
            txtNutritionPlaceName.Text = ""
        End If
    End Sub


    Private Sub chkChildDevelop1_Click(sender As Object, e As EventArgs) Handles chkChildDevelop1.Click
        chkChildDevelop1.Checked = True
        chkChildDevelop2.Checked = False
        chkChildDevelop3.Checked = False
        txtChildDevelope.Text = "1"
        txtFood.Select()
    End Sub
    Private Sub chkChildDevelop2_Click(sender As Object, e As EventArgs) Handles chkChildDevelop2.Click
        chkChildDevelop1.Checked = False
        chkChildDevelop2.Checked = True
        chkChildDevelop3.Checked = False
        txtChildDevelope.Text = "2"
        txtFood.Select()
    End Sub
    Private Sub chkChildDevelop3_Click(sender As Object, e As EventArgs) Handles chkChildDevelop3.Click
        chkChildDevelop1.Checked = False
        chkChildDevelop2.Checked = False
        chkChildDevelop3.Checked = True
        txtChildDevelope.Text = "3"
        txtFood.Select()
    End Sub

    Private Sub txtChildDevelope_KeyDown(sender As Object, e As KeyEventArgs) Handles txtChildDevelope.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtChildDevelope.Text = "1" Then
                chkChildDevelop1.Checked = True
                chkChildDevelop2.Checked = False
                chkChildDevelop3.Checked = False
            ElseIf txtChildDevelope.Text = "2" Then
                chkChildDevelop1.Checked = False
                chkChildDevelop2.Checked = True
                chkChildDevelop3.Checked = False
            ElseIf txtChildDevelope.Text = "3" Then
                chkChildDevelop1.Checked = False
                chkChildDevelop2.Checked = False
                chkChildDevelop3.Checked = True
            Else
                XtraMessageBox.Show("กรุณากำหนด พัฒนาการเด็ก ให้ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtChildDevelope.SelectAll()
                Exit Sub
            End If

            txtFood.Select()
            txtFood.SelectAll()
        End If
    End Sub

    Private Sub txtWeight_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWeight.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtHeight.Select()
            txtHeight.SelectAll()
        End If
    End Sub


    Private Sub txtHeight_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHeight.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtHeadCircum.Select()
            txtHeadCircum.SelectAll()
        End If
    End Sub

    Private Sub txtHeadCircum_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHeadCircum.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtChildDevelope.Select()
            txtChildDevelope.SelectAll()
        End If
    End Sub

    Private Sub txtFood_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFood.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtFood.Text = "0" Then
                chkFood0.Checked = True
                chkFood1.Checked = False
                chkFood2.Checked = False
                chkFood3.Checked = False
                chkFood4.Checked = False
                chkFood5.Checked = False
            ElseIf txtFood.Text = "1" Then
                chkFood0.Checked = False
                chkFood1.Checked = True
                chkFood2.Checked = False
                chkFood3.Checked = False
                chkFood4.Checked = False
                chkFood5.Checked = False
            ElseIf txtFood.Text = "2" Then
                chkFood0.Checked = False
                chkFood1.Checked = False
                chkFood2.Checked = True
                chkFood3.Checked = False
                chkFood4.Checked = False
                chkFood5.Checked = False
            ElseIf txtFood.Text = "3" Then
                chkFood0.Checked = False
                chkFood1.Checked = False
                chkFood2.Checked = False
                chkFood3.Checked = True
                chkFood4.Checked = False
                chkFood5.Checked = False
            ElseIf txtFood.Text = "4" Then
                chkFood0.Checked = False
                chkFood1.Checked = False
                chkFood2.Checked = False
                chkFood3.Checked = False
                chkFood4.Checked = True
                chkFood5.Checked = False
            ElseIf txtFood.Text = "5" Then
                chkFood0.Checked = False
                chkFood1.Checked = False
                chkFood2.Checked = False
                chkFood3.Checked = False
                chkFood4.Checked = False
                chkFood5.Checked = True
            Else
                XtraMessageBox.Show("กรุณากำหนด การรับประทานอาหารในปัจจุบัน ให้ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtFood.SelectAll()
                Exit Sub
            End If

            txtBottle.Select()
            txtBottle.SelectAll()
        End If
    End Sub

    Private Sub txtWeight_Leave(sender As Object, e As EventArgs) Handles txtWeight.Leave
        txtHeight.Select()
        txtHeight.SelectAll()
    End Sub

    Private Sub txtHeight_Leave(sender As Object, e As EventArgs) Handles txtHeight.Leave
        txtHeadCircum.Select()
        txtHeadCircum.SelectAll()
    End Sub

    Private Sub txtHeadCircum_Leave(sender As Object, e As EventArgs) Handles txtHeadCircum.Leave
        txtChildDevelope.Select()
        txtChildDevelope.SelectAll()
    End Sub

    Private Sub chkFood0_Click(sender As Object, e As EventArgs) Handles chkFood0.Click
        chkFood0.Checked = True
        chkFood1.Checked = False
        chkFood2.Checked = False
        chkFood3.Checked = False
        chkFood4.Checked = False
        chkFood5.Checked = False
        txtFood.Text = "0"
        txtBottle.Select()
    End Sub

    Private Sub chkFood1_Click(sender As Object, e As EventArgs) Handles chkFood1.Click
        chkFood0.Checked = False
        chkFood1.Checked = True
        chkFood2.Checked = False
        chkFood3.Checked = False
        chkFood4.Checked = False
        chkFood5.Checked = False
        txtFood.Text = "1"
        txtBottle.Select()
    End Sub

    Private Sub chkFood2_Click(sender As Object, e As EventArgs) Handles chkFood2.Click
        chkFood0.Checked = False
        chkFood1.Checked = False
        chkFood2.Checked = True
        chkFood3.Checked = False
        chkFood4.Checked = False
        chkFood5.Checked = False
        txtFood.Text = "2"
        txtBottle.Select()
    End Sub

    Private Sub chkFood3_Click(sender As Object, e As EventArgs) Handles chkFood3.Click
        chkFood0.Checked = False
        chkFood1.Checked = False
        chkFood2.Checked = False
        chkFood3.Checked = True
        chkFood4.Checked = False
        chkFood5.Checked = False
        txtFood.Text = "3"
        txtBottle.Select()
    End Sub

    Private Sub chkFood4_Click(sender As Object, e As EventArgs) Handles chkFood4.Click
        chkFood0.Checked = False
        chkFood1.Checked = False
        chkFood2.Checked = False
        chkFood3.Checked = False
        chkFood4.Checked = True
        chkFood5.Checked = False
        txtFood.Text = "4"
        txtBottle.Select()
    End Sub

    Private Sub chkFood5_Click(sender As Object, e As EventArgs) Handles chkFood5.Click
        chkFood0.Checked = False
        chkFood1.Checked = False
        chkFood2.Checked = False
        chkFood3.Checked = False
        chkFood4.Checked = False
        chkFood5.Checked = True
        txtFood.Text = "5"
        txtBottle.Select()
    End Sub

    Private Sub chkBottle1_Click(sender As Object, e As EventArgs) Handles chkBottle1.Click
        chkBottle1.Checked = True
        chkBottle2.Checked = False
        txtBottle.Text = "1"
        txtNutritionPlaceCode.Select()
    End Sub

    Private Sub chkBottle2_Click(sender As Object, e As EventArgs) Handles chkBottle2.Click
        chkBottle1.Checked = False
        chkBottle2.Checked = True
        txtBottle.Text = "2"
        txtNutritionPlaceCode.Select()
    End Sub

    Private Sub txtBottle_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBottle.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtBottle.Text = "1" Then
                chkBottle1.Checked = True
                chkBottle2.Checked = False
            ElseIf txtBottle.Text = "2" Then
                chkBottle1.Checked = False
                chkBottle2.Checked = True
            Else
                XtraMessageBox.Show("กรุณากำหนด การใช้ขวดนม ให้ถูกต้อง!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtBottle.SelectAll()
                Exit Sub
            End If

            txtNutritionPlaceCode.Select()
            txtNutritionPlaceCode.SelectAll()
        End If
    End Sub

    Private Sub txtNutritionPlaceCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNutritionPlaceCode.KeyDown
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
        txtWeight.Select()
    End Sub

    Private Sub TimeEdit1_KeyDown(sender As Object, e As KeyEventArgs) Handles TimeEdit1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtWeight.Select()
            txtWeight.SelectAll()
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

        If txtNutritionPlaceCode.Text <> "" Then
            CheckHospDX()
        End If

        If CheckPERSON(vNutritionPID) = False Then
            XtraMessageBox.Show("ไม่สามารถบันทึกได้เนื่องจาก ไม่มีบุคคลดังกล่าว!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If txtWeight.Text = "" Then
            XtraMessageBox.Show("บันทึกน้ำหนักก่อน !!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtWeight.Select()
            txtWeight.SelectAll()
            Exit Sub
        End If
        If txtHeight.Text = "" Then
            XtraMessageBox.Show("บันทึกส่วนสูงก่อน !!! ", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtHeight.Select()
            txtHeight.SelectAll()
            Exit Sub
        End If
        If txtHeadCircum.Text = "" Then
            XtraMessageBox.Show("บันทึกเส้นรอบศีรษะก่อน !!! ", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtHeadCircum.Select()
            txtHeadCircum.SelectAll()
            Exit Sub
        End If
        If txtChildDevelope.Text = "" Then
            XtraMessageBox.Show("บันทึกระดับพัฒนาการก่อน !!! ", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtChildDevelope.Select()
            txtChildDevelope.SelectAll()
            Exit Sub
        End If
        If txtFood.Text = "" Then
            XtraMessageBox.Show("บันทึการกินอาหารและนมก่อน !!! ", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFood.Select()
            txtFood.SelectAll()
            Exit Sub
        End If
        If txtBottle.Text = "" Then
            XtraMessageBox.Show("บันทึการใช้ขวดนมก่อน !!! ", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBottle.Select()
            txtBottle.SelectAll()
            Exit Sub
        End If
        If txtNutritionPlaceCode.Text = vHcode Then
            XtraMessageBox.Show("ไม่สามารถบันทึกได้ หากให้บริการเองต้องไปบันทึกหน้าการให้บริการ!!! ", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtNutritionPlaceCode.Select()
            txtNutritionPlaceCode.SelectAll()
            Exit Sub
        End If


        'Dim ds As DataSet
        'ds = clsdataBus.Lc_Business.SELECT_TABLE("A.ROWID ", "m_epi A JOIN l_vaccinetype B ON(A.VACCINETYPE = B.VACCINE_CODE)", " WHERE DUP = '1' AND PID = '" & vEpiPID & "' AND VACCINETYPE = '" & txtVaccineTypeCode.Text & "' AND A.STATUS_AF <> '8'")
        'If ds.Tables(0).Rows.Count > 0 Then
        '    XtraMessageBox.Show("ไม่สามารถบันทึกได้ เนื่องจากมีการบันทึกข้อมูลไว้แล้ว!!! ", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If

        Dim DATE_SERV As String = CDate(txtDateServ.Text).ToString("yyyyMMdd", CultureInfo.CreateSpecificCulture("en-EN"))
        Dim WEIGHT As String = txtWeight.Text
        Dim HEIGHT As String = txtHeight.Text
        Dim HEADCIRCUM As String = txtHeadCircum.Text
        Dim CHILDDEVELOP As String = txtChildDevelope.Text
        Dim FOOD As String = txtFood.Text
        Dim BOTTLE As String = txtBottle.Text
        Dim NUTRITIONPLACE As String = txtNutritionPlaceCode.Text
        Dim PROVIDER As String = txtProviderCode.Text
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate_En()


        If tmpUpdate = False Then
            'Add Data

            Dim ds As DataSet
            ds = clsdataBus.Lc_Business.SELECT_TABLE("ROWID ", "m_nutrition", " WHERE PID = '" & vNutritionPID & "' AND DATE_SERV = '" & txtDateServ.Text & "' AND STATUS_AF <> '8'")
            If ds.Tables(0).Rows.Count > 0 Then
                XtraMessageBox.Show("ไม่สามารถบันทึกได้ เนื่องจากมีการบันทึกข้อมูลไว้แล้ว!!! ", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


            clsbusent.Lc_BusinessEntity.Insertm_table("m_nutrition (HOSPCODE,PID,SEQ,DATE_SERV,NUTRITIONPLACE,WEIGHT,HEIGHT,HEADCIRCUM,CHILDDEVELOP,FOOD,BOTTLE,PROVIDER,D_UPDATE,USER_REC,STATUS_AF)",
              "'" & vHcode & "','" & vNutritionPID & "','','" & DATE_SERV & "','" & NUTRITIONPLACE & "','" & WEIGHT & "','" & HEIGHT & "','" & HEADCIRCUM & "','" & CHILDDEVELOP & "','" & FOOD & "','" & BOTTLE & "','" & PROVIDER & "','" & tmpNow & "','" & vUSERID & "','2'")
            XtraMessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
            tmpUpdate = True
        Else
            'Update Data

            If txtDateServ.Text <> tmpDateServe Then
                Dim ds As DataSet
                ds = clsdataBus.Lc_Business.SELECT_TABLE("ROWID ", "m_nutrition", " WHERE  PID = '" & vNutritionPID & "' AND DATE_SERV = '" & DATE_SERV & "' AND STATUS_AF <> '8'")
                If ds.Tables(0).Rows.Count > 0 Then
                    XtraMessageBox.Show("ไม่สามารถบันทึกได้ เนื่องจากมีการบันทึกข้อมูลไว้แล้ว!!! ", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
            clsbusent.Lc_BusinessEntity.Updatem_table("m_nutrition", "WEIGHT = '" & WEIGHT & "',NUTRITIONPLACE = '" _
                                          & NUTRITIONPLACE & "', DATE_SERV = '" & DATE_SERV & "',PROVIDER = '" & PROVIDER & "',D_UPDATE = '" & tmpNow & "',STATUS_AF = '2',HEIGHT = '" & HEIGHT & "',HEADCIRCUM = '" & HEADCIRCUM & "',CHILDDEVELOP = '" & CHILDDEVELOP & "',FOOD = '" & FOOD & "',BOTTLE = '" & BOTTLE & "'" _
                                          , "ROWID = '" & vNutritionRowID & "'")
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

        If txtWeight.Text = "" Then
            txtWeight.BackColor = Color.LightPink
            chkData = False
        Else
            txtWeight.BackColor = Color.White
        End If

        If txtHeight.Text = "" Then
            txtHeight.BackColor = Color.LightPink
            chkData = False
        Else
            txtHeight.BackColor = Color.White
        End If

        If txtHeadCircum.Text = "" Then
            txtHeadCircum.BackColor = Color.LightPink
            chkData = False
        Else
            txtHeadCircum.BackColor = Color.White
        End If


        If txtChildDevelope.Text = "" Then
            txtChildDevelope.BackColor = Color.LightPink
            chkData = False
        Else
            txtChildDevelope.BackColor = Color.Beige
        End If

        If txtFood.Text = "" Then
            txtFood.BackColor = Color.LightPink
            chkData = False
        Else
            txtFood.BackColor = Color.Beige
        End If

        If txtBottle.Text = "" Then
            txtBottle.BackColor = Color.LightPink
            chkData = False
        Else
            txtBottle.BackColor = Color.Beige
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