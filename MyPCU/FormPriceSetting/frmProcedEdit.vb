Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmProcedEdit

    Private Sub frmProcedEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChargeItem()
        If vProcedROWID <> "" Then
            chkProcedCode1.Enabled = False
            chkProcedCode2.Enabled = False

            Dim ds As DataSet
            ds = clsdataBus.Lc_Business.SELECT_TABLE("CHARGEITEM,PROCEDCODE,IFNULL(PROCEDNAME,'') AS PROCEDNAME,IFNULL(ICD,'') AS ICD,IFNULL(ICD9CM,'') AS ICD9CM,IFNULL(CSMBS,'') AS CSMBS,SERVICEPRICE,SERVICECOST", " l_procedprice ", " WHERE ROWID = '" & vProcedROWID & "' ")

            If ds.Tables(0).Rows.Count > 0 Then
                chkProcedCode1.Enabled = False

                txtChargeitem.Text = ds.Tables(0).Rows(0).Item("CHARGEITEM")
                cboChargeItem.EditValue = txtChargeitem.Text

                txtPROCEDCODE.Text = ds.Tables(0).Rows(0).Item("PROCEDCODE")
                txtProcedDesc.Text = ds.Tables(0).Rows(0).Item("PROCEDNAME")

                txtICD10TM.Text = ds.Tables(0).Rows(0).Item("ICD")
                txtICD10thai.Text = ClsBusiness.Lc_Business.SELECT_NAME_ICD9_ICD10TM(txtICD10TM.Text, "1")
                txtICD10eng.Text = ClsBusiness.Lc_Business.SELECT_NAME_ICD9_ICD10TM(txtICD10TM.Text, "0")

                txtICD9CM.Text = ds.Tables(0).Rows(0).Item("ICD9CM")
                txtICD9desc.Text = ClsBusiness.Lc_Business.SELECT_NAME_ICD9CM(txtICD9CM.Text, "0")

                txtCSMBS.Text = ds.Tables(0).Rows(0).Item("CSMBS")
                txtCSMBSdesc.Text = ClsBusiness.Lc_Business.SELECT_NAME_CSMBS_NHSO(txtCSMBS.Text)

                txtSERVICEPRICE.Text = ds.Tables(0).Rows(0).Item("SERVICEPRICE")
                txtSERVICECOST.Text = ds.Tables(0).Rows(0).Item("SERVICECOST")
            End If
        End If

    End Sub
    Private Sub ChargeItem()
        cboChargeItem.Properties.DataSource = Nothing
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("CHARGEITEM_CODE,CHARGEITEM_DESC", " l_chargeitem ", " WHERE IFNULL(PROCED,'') = '1' ")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboChargeItem
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "CHARGEITEM_DESC"
                .Properties.ValueMember = "CHARGEITEM_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
    End Sub

    Private Sub txtICD10TM_KeyDown(sender As Object, e As KeyEventArgs) Handles txtICD10TM.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtICD10thai.Text = ClsBusiness.Lc_Business.SELECT_NAME_ICD9_ICD10TM(txtICD10TM.Text, "1")
            txtICD10eng.Text = ClsBusiness.Lc_Business.SELECT_NAME_ICD9_ICD10TM(txtICD10TM.Text, "0")
        End If
    End Sub

    Private Sub cboChargeItem_EditValueChanged(sender As Object, e As EventArgs) Handles cboChargeItem.EditValueChanged
        txtChargeitem.Text = cboChargeItem.EditValue
        txtPROCEDCODE.Select()
    End Sub

    Private Sub chkName1_Click(sender As Object, e As EventArgs) Handles chkName1.Click
        chkName1.Checked = True
        chkName2.Checked = False
        chkName3.Checked = False
        chkName4.Checked = False
        txtProcedDesc.Text = txtICD10thai.Text
    End Sub

    Private Sub chkName2_Click(sender As Object, e As EventArgs) Handles chkName2.Click
        chkName1.Checked = False
        chkName2.Checked = True
        chkName3.Checked = False
        chkName4.Checked = False
        txtProcedDesc.Text = txtICD10eng.Text
    End Sub

    Private Sub chkName3_Click(sender As Object, e As EventArgs) Handles chkName3.Click
        chkName1.Checked = False
        chkName2.Checked = False
        chkName3.Checked = True
        chkName4.Checked = False
        txtProcedDesc.Text = txtICD9desc.Text
    End Sub
    Private Sub chkName4_Click(sender As Object, e As EventArgs) Handles chkName4.Click
        chkName1.Checked = False
        chkName2.Checked = False
        chkName3.Checked = False
        chkName4.Checked = True
        txtProcedDesc.Text = txtCSMBSdesc.Text

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click


        If txtChargeitem.Text = "" Then
            XtraMessageBox.Show("กรุณาเลือกหมวดค่าใช้จ่ายก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If chkProcedCode2.Checked = True And txtPROCEDCODE.Text = "" Then
            XtraMessageBox.Show("กำหนดรหัส ICD 10 TM ก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If txtProcedDesc.Text = "" Then
            XtraMessageBox.Show("กำหนดชื่อรายการหัตถการก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtProcedDesc.Select()
            Exit Sub
        End If

        If CDbl(txtSERVICEPRICE.Text) <= 0 Then
            XtraMessageBox.Show("กำหนดราคาขายก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSERVICEPRICE.Select()
            txtSERVICEPRICE.Select()
            Exit Sub
        End If

        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)
        Dim tmpStatus As String = ""
        If chkCancle.Checked = False Then
            tmpStatus = "1"
        Else
            tmpStatus = "0"
        End If
        Dim tmpDental As String = ""
        If txtChargeitem.Text = "13" Then
            tmpDental = "Y"
        Else
            tmpDental = "N"
        End If

        If vProcedROWID <> "" Then
            clsbusent.Lc_BusinessEntity.Updatem_table("l_procedprice", "SERVICEPRICE = '" & CDbl(txtSERVICEPRICE.Text).ToString("0.00") & "',SERVICECOST = '" & CDbl(txtSERVICECOST.Text).ToString("0.00") & "'" _
                                                      & ",DENTAL = '" & tmpDental & "',ICD = '" & txtICD10TM.Text & "',CSMBS = '" & txtCSMBS.Text & "',ICD9CM = '" & txtICD9CM.Text & "',PROCEDNAME = '" & txtProcedDesc.Text & "',USER_REC = '" & vUSERID & "',D_UPDATE = '" & tmpNow & "',STATUS = '" & tmpStatus & "'",
                              "ROWID = '" & vProcedROWID & "'")
        Else
            Dim tmpProcedCode As String = ""
            Dim tmpChargeList As String = ""
            Dim ds As DataSet
            ds = clsdataBus.Lc_Business.SELECT_TABLE("MAX(CHARGELIST)+1 AS ID", " l_procedprice ", " WHERE CHARGEITEM = '" & txtChargeitem.Text & "' GROUP BY CHARGEITEM")
            If ds.Tables(0).Rows.Count > 0 Then
                tmpChargeList = CInt(ds.Tables(0).Rows(0).Item("ID")).ToString("0000")
                tmpProcedCode = txtChargeitem.Text & tmpChargeList
            Else
                tmpChargeList = "0001"
                tmpProcedCode = txtChargeitem.Text & tmpChargeList
            End If

            If chkProcedCode1.Checked = True Then
                tmpProcedCode = tmpProcedCode
            Else
                tmpProcedCode = txtPROCEDCODE.Text
            End If

            clsbusent.Lc_BusinessEntity.Insertm_table("l_procedprice (CHARGEITEM,CHARGELIST,PROCEDCODE,SERVICEPRICE,SERVICECOST,DENTAL,USER_REC,D_UPDATE,STATUS,CSMBS,ICD9CM,ICD,PROCEDNAME)",
             "'" & txtChargeitem.Text & "','" & tmpChargeList & "','" & tmpProcedCode & "','" & CDbl(txtSERVICEPRICE.Text).ToString("0.00") & "','" & CDbl(txtSERVICECOST.Text).ToString("0.00") & "','" & tmpDental & "','" & vUSERID & "','" & tmpNow & "','1','" & txtCSMBS.Text & "','" & txtICD9CM.Text & "','" & txtICD10TM.Text & "','" & txtProcedDesc.Text & "'")


        End If

        XtraMessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

    End Sub
    Private Sub GenID()



    End Sub
    Private Sub chkProcedCode1_Click(sender As Object, e As EventArgs) Handles chkProcedCode1.Click
        chkProcedCode1.Checked = True
        chkProcedCode2.Checked = False
        txtPROCEDCODE.Text = ""
    End Sub
    Private Sub chkProcedCode2_Click(sender As Object, e As EventArgs) Handles chkProcedCode2.Click
        chkProcedCode2.Checked = True
        chkProcedCode1.Checked = False
        txtPROCEDCODE.Text = txtICD10TM.Text
    End Sub
    Private Sub cmdICD10search_Click(sender As Object, e As EventArgs) Handles cmdICD10search.Click
        vProcedAdd = "10"
        Dim f As New frmIcd9Search
        f.ShowDialog()
        If vProcedCode <> "" Then
            txtICD10TM.Text = vProcedCode
            txtICD10thai.Text = ClsBusiness.Lc_Business.SELECT_NAME_ICD9_ICD10TM(txtICD10TM.Text, "1")
            txtICD10eng.Text = ClsBusiness.Lc_Business.SELECT_NAME_ICD9_ICD10TM(txtICD10TM.Text, "0")
        End If
        vProcedAdd = ""
        vProcedCode = ""
    End Sub

    Private Sub cmdICD9search_Click(sender As Object, e As EventArgs) Handles cmdICD9search.Click
        vProcedAdd = "9"
        Dim f As New frmIcd9Search
        f.ShowDialog()
        If vProcedCode <> "" Then
            txtICD9CM.Text = vProcedCode
            txtICD9desc.Text = ClsBusiness.Lc_Business.SELECT_NAME_ICD9CM(txtICD9CM.Text, "0")
        End If
        vProcedAdd = ""
        vProcedCode = ""
    End Sub

    Private Sub txtSERVICEPRICE_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSERVICEPRICE.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSERVICECOST.Select()
            txtSERVICECOST.SelectAll()
        End If
    End Sub


    Private Sub txtSERVICEPRICE_Leave(sender As Object, e As EventArgs) Handles txtSERVICEPRICE.Leave
        If IsNumeric(txtSERVICEPRICE.Text) = False Then
            XtraMessageBox.Show(msNumber, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSERVICEPRICE.Select()
            txtSERVICEPRICE.SelectAll()
        Else
            txtSERVICEPRICE.Text = CDbl(txtSERVICEPRICE.Text).ToString("#,##0.00")
        End If
    End Sub

    Private Sub txtSERVICECOST_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSERVICECOST.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmdSave.Focus()
        End If
    End Sub

    Private Sub txtSERVICECOST_Leave(sender As Object, e As EventArgs) Handles txtSERVICECOST.Leave
        If IsNumeric(txtSERVICECOST.Text) = False Then
            XtraMessageBox.Show(msNumber, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSERVICECOST.Select()
            txtSERVICECOST.SelectAll()
        Else
            txtSERVICECOST.Text = CDbl(txtSERVICECOST.Text).ToString("#,##0.00")
        End If
    End Sub


End Class