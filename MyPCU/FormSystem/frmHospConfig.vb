Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports DevExpress.XtraEditors
Public Class frmHospConfig
    Dim tmpProvince As String = ""
    Dim tmpAmphur As String = ""
    Dim tmpTambol As String = ""
    Dim tmpVillage As String = ""
    Dim tmpRowid As String = ""
    Dim tmp506ONLINE As String = ""
    Dim tmpWEB506 As String = ""
    Dim tmpUSERNAME As String = ""
    Dim tmpPASSWORD As String = ""
    Dim tmpWEB506_2 As String = ""
    Dim tmpHSERV As String = ""
    Private Sub frmHospConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As DataSet

        ds = clsdataBus.Lc_Business.SELECT_DATA("l_confighcode", "")
        If ds.Tables(0).Rows.Count > 0 Then
            txtHospCode.Text = ds.Tables(0).Rows(0).Item("HOSPCODE").ToString
            lblHospName.Text = ds.Tables(0).Rows(0).Item("HOSPNAME").ToString
            lblProvinceID.Text = ds.Tables(0).Rows(0).Item("PROVINCE_ID").ToString
            lblProvinceName.Text = ds.Tables(0).Rows(0).Item("PROVINCE_NAME").ToString
            lblAmphurID.Text = ds.Tables(0).Rows(0).Item("AMPHUR_ID").ToString
            lblAmphurName.Text = ds.Tables(0).Rows(0).Item("AMPHUR_NAME").ToString
            txtHmain.Text = ds.Tables(0).Rows(0).Item("HMAIN").ToString

            bntHospName.Text = ds.Tables(0).Rows(0).Item("HMAIN_NAME").ToString
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("LATITUDE")) Then
                txtLATITUDE.Text = ds.Tables(0).Rows(0).Item("LATITUDE").ToString
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("LONGITUDE")) Then
                txtLONGITUDE.Text = ds.Tables(0).Rows(0).Item("LONGITUDE").ToString
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("TEL")) Then
                txtTEL.Text = ds.Tables(0).Rows(0).Item("TEL").ToString
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("HSERV")) Then
                txt506.Text = ds.Tables(0).Rows(0).Item("HSERV").ToString
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("506ONLINE")) Then
                tmp506ONLINE = ds.Tables(0).Rows(0).Item("506ONLINE").ToString
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("WEB506")) Then
                tmpWEB506 = ds.Tables(0).Rows(0).Item("WEB506").ToString
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("USERNAME")) Then
                tmpUSERNAME = ds.Tables(0).Rows(0).Item("USERNAME").ToString
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("PASSWORD")) Then
                tmpPASSWORD = ds.Tables(0).Rows(0).Item("PASSWORD").ToString
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("WEB506_2")) Then
                tmpWEB506_2 = ds.Tables(0).Rows(0).Item("WEB506_2").ToString
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("ADDRESS")) Then
                TextBox1.Text = ds.Tables(0).Rows(0).Item("ADDRESS").ToString
            End If
        End If
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        Dim fHospSearch As New frmHospSearch
        fHospSearch.ShowDialog()
        If vTmpHcode <> "" Then
            SearchData(vTmpHcode)
            txtHospCode.Text = vTmpHcode
            vTmpHcode = ""
        End If

    End Sub
    Private Sub SearchData(ByVal strString As String)
        Dim ds As DataSet
        Dim ds2 As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_hospitals", "WHERE HOSPCODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            lblHospName.Text = ds.Tables(0).Rows(0).Item("HOSPNAME").ToString
            lblProvinceID.Text = ds.Tables(0).Rows(0).Item("PROVINCE_ID").ToString
            lblProvinceName.Text = clsdataBus.Lc_Business.SELECT_NAME_PROVINCE(lblProvinceID.Text)
            lblAmphurID.Text = ds.Tables(0).Rows(0).Item("AMP").ToString
            lblAmphurName.Text = clsdataBus.Lc_Business.SELECT_NAME_AMPHUR(lblProvinceID.Text, lblAmphurID.Text)
        End If
    End Sub
    Private Sub txtHospCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHospCode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SearchData(txtHospCode.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtHmain_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHmain.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                SearchHamin(txtHmain.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SearchHamin(ByVal strString As String)
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_hospitals", "WHERE HOSPCODE = '" & strString & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            bntHospName.Text = ds.Tables(0).Rows(0).Item("HOSPNAME").ToString
        End If
    End Sub

    Private Sub cmdSearch2_Click(sender As Object, e As EventArgs)
        Dim fHospSearch As New frmHospSearch
        fHospSearch.ShowDialog()
        If vTmpHcode <> "" Then
            SearchHamin(vTmpHcode)
            txtHmain.Text = vTmpHcode
            vTmpHcode = ""
        End If

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click


        If vHcode <> "" Then
            If vHcode <> txtHospCode.Text Then
                If XtraMessageBox.Show("การเปลี่ยนแปลงรหัสหน่วยบริการจะทำให้ข้อมูลเดิมที่เคยบันทึกหรือนำเข้าไว้สูญหายได้!!! ยืนยันการเปลี่ยนกด Yes ไม่ต้องการเปลี่ยนกด No", vProgram, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = System.Windows.Forms.DialogResult.No Then
                    txtHospCode.Text = vHcode
                    SearchData(txtHospCode.Text)
                    Exit Sub
                Else
                    Dim ds2 As DataSet
                    ds2 = clsdataBus.Lc_Business.SELECT_TABLE("M_TABLE", "l_table43", "ORDER BY m_TABLE")
                    If ds2.Tables(0).Rows.Count > 0 Then
                        For i As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                            Dim tmpMtable As String = "m_" & ds2.Tables(0).Rows(i).Item("M_TABLE").ToString
                            clsbusent.Lc_BusinessEntity.Delete_table(tmpMtable, " WHERE HOSPCODE <> '" & txtHospCode.Text & "'")
                        Next
                    End If
                End If
            End If
        End If

        If txtHospCode.Text.Replace("_", "") = "" Or txtHmain.Text.Replace("_", "") = "" Then
            XtraMessageBox.Show("ไม่สามารถบันทึกข้อมูลได้ เนื่องจากยังไม่มีการกำหนดหน่วยบริการหรือหน่วยบริการประจำ!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim LATITUDE As String = ""
        If Trim(txtLATITUDE.Text.Replace(".", "")) <> "" Then
            LATITUDE = CDbl(Trim(txtLATITUDE.Text.Replace("_", ""))).ToString("000.000000")
        Else
            LATITUDE = ""
        End If
        Dim LONGITUDE As String = ""
        If Trim(txtLONGITUDE.Text.Replace(".", "")) <> "" Then
            LONGITUDE = CDbl(Trim(txtLONGITUDE.Text.Replace("_", ""))).ToString("000.000000")
        Else
            LONGITUDE = ""
        End If
        Dim tmpDrugStore As String = ""
        Dim tmpDrugLabel As String = ""
        Dim tmpvHNPID As String = ""
        If dDrugStore = "1" Then
            tmpDrugStore = "1"
        Else
            tmpDrugStore = "0"
        End If

        If dDrugLabel = "1" Then
            tmpDrugLabel = "1"
        Else
            tmpDrugLabel = "0"
        End If

        If vHNPID = "1" Then
            tmpvHNPID = "1"
        Else
            tmpvHNPID = "0"
        End If
        Try
            Dim Mode As String = ""
            Dim str_Result As Boolean

            '----Delete data in Table Config----
            clsbusent.Lc_BusinessEntity.Turncate_table("l_confighcode")
            str_Result = clsbusent.Lc_BusinessEntity.Insertm_table("l_confighcode (HOSPCODE,HOSPNAME,PROVINCE_ID,PROVINCE_NAME,AMPHUR_ID,AMPHUR_NAME,HMAIN,HMAIN_NAME,LATITUDE,LONGITUDE,TEL,DRUG_STORE,DRUG_LABEL,HNPID,HSERV,506ONLINE,WEB506,USERNAME,PASSWORD,WEB506_2,ADDRESS)",
                    "'" & txtHospCode.Text & "','" & lblHospName.Text & "','" & lblProvinceID.Text & "','" & lblProvinceName.Text & "','" & lblAmphurID.Text & "','" & lblAmphurName.Text & "','" & txtHmain.Text & "','" & bntHospName.Text & "','" & LATITUDE & "','" & LONGITUDE & "','" & txtTEL.Text & "','" & tmpDrugStore & "','" & tmpDrugLabel & "','" & tmpvHNPID & "','" & txt506.Text & "','" & tmp506ONLINE & "','" & tmpWEB506 & "','" & tmpUSERNAME & "','" & tmpPASSWORD & "','" & tmpWEB506_2 & "','" & TextBox1.Text & "'")


            If str_Result = True Then
                XtraMessageBox.Show("บันทึกเสร็จเรียบร้อยแล้ว โปรแกรมจะปิดเพื่อเข้าระบบใหม่ !!!", "PCUbyKIDKOM", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()

                End
            Else
                XtraMessageBox.Show("ไม่สามารถบันทึกข้อมูล กรุณาลองใหม่ !!!", "PCUbyKIDKOM", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show("มีข้อผิดพลาด ดังนี้ : " & ex.ToString, "PCUbyKIDKOM", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub bntHospName_Click(sender As Object, e As EventArgs) Handles bntHospName.Click
        Dim f As New frmHospSearch
        f.ShowDialog()
        If vTmpHcode <> "" Then
            txtHmain.Text = vTmpHcode
            bntHospName.Text = ClsBusiness.Lc_Business.SELECT_NAME_HOSPITAL(txtHmain.Text)
        End If
        vTmpHcode = ""

    End Sub
End Class