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
Public Class frmUserEdit
    Dim tmpProvider As String = ""
    Dim chkData As Boolean = True

    Private Sub frmUserEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Prename()
        lblCIDError.Text = ""
        If vUserSelectID <> "" Then
            Dim ds As DataSet
            ds = clsdataBus.Lc_Business.SELECT_TABLE(" * ", "l_user", " WHERE USER_ID = '" & vUserSelectID & "'")
            If ds.Tables(0).Rows.Count > 0 Then
                lblUSERID.Text = ds.Tables(0).Rows(0).Item("USER_ID").ToString
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("CID")) Then
                    txtCID.Text = Decode(ds.Tables(0).Rows(0).Item("CID").ToString)
                    CheckCID(txtCID.Text)
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("PRENAME")) Then
                    txtPrename.Text = ds.Tables(0).Rows(0).Item("PRENAME").ToString
                    cboPrename.EditValue = txtPrename.Text
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("FNAME")) Then
                    txtName.Text = ds.Tables(0).Rows(0).Item("FNAME").ToString
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("LNAME")) Then
                    txtLName.Text = ds.Tables(0).Rows(0).Item("LNAME").ToString
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("USERNAME")) Then
                    txtUsername.Text = Decode(ds.Tables(0).Rows(0).Item("USERNAME").ToString)
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("PASSWORD")) Then
                    txtPassword.Text = Decode(ds.Tables(0).Rows(0).Item("PASSWORD").ToString)
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("ADMIN")) Then
                    If ds.Tables(0).Rows(0).Item("ADMIN").ToString = "1" Then
                        optAdmin.Checked = True
                    Else
                        optUser.Checked = True
                    End If
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("STATUS")) Then
                    If ds.Tables(0).Rows(0).Item("STATUS").ToString = "1" Then
                        chkStatus1.Checked = True
                    Else
                        chkStatus0.Checked = True
                    End If
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("PROVIDER")) Then
                    If ds.Tables(0).Rows(0).Item("PROVIDER").ToString <> "" Then
                        chkPorvider1.Checked = True
                    Else
                        chkPorvider0.Checked = True
                    End If
                Else
                    chkPorvider0.Checked = True
                End If

                If Not IsDBNull(ds.Tables(0).Rows(0).Item("POP")) Then
                    If ds.Tables(0).Rows(0).Item("POP").ToString = "1" Then
                        chkPop.Checked = True
                    End If
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("CHRONIC")) Then
                    If ds.Tables(0).Rows(0).Item("CHRONIC").ToString = "1" Then
                        chkChronic.Checked = True
                    End If
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("SERVICE")) Then
                    If ds.Tables(0).Rows(0).Item("SERVICE").ToString = "1" Then
                        chkService.Checked = True
                    End If
                End If

                If Not IsDBNull(ds.Tables(0).Rows(0).Item("ASSET")) Then
                    If ds.Tables(0).Rows(0).Item("ASSET").ToString = "1" Then
                        chkAsset.Checked = True
                    End If
                End If


                If Not IsDBNull(ds.Tables(0).Rows(0).Item("MET_ADMIN")) Then
                    If ds.Tables(0).Rows(0).Item("MET_ADMIN").ToString = "1" Then
                        chkMetAdmin.Checked = True
                    End If
                End If

                If Not IsDBNull(ds.Tables(0).Rows(0).Item("MET_USER")) Then
                    If ds.Tables(0).Rows(0).Item("MET_USER").ToString = "1" Then
                        chkMetUser.Checked = True
                    End If
                End If

                If Not IsDBNull(ds.Tables(0).Rows(0).Item("DRUG_STORE")) Then
                    If ds.Tables(0).Rows(0).Item("DRUG_STORE").ToString = "1" Then
                        chkDrug.Checked = True
                    End If
                End If

                If Not IsDBNull(ds.Tables(0).Rows(0).Item("ACC")) Then
                    If ds.Tables(0).Rows(0).Item("ACC").ToString = "1" Then
                        chkAccout.Checked = True
                    End If
                End If

                If Not IsDBNull(ds.Tables(0).Rows(0).Item("DATA")) Then
                    If ds.Tables(0).Rows(0).Item("DATA").ToString = "1" Then
                        chkDataAdmin.Checked = True
                    End If
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

                checkData()
            End If
        Else
            Dim ds2 As DataSet
            ds2 = clsdataBus.Lc_Business.SELECT_DATA("m_provider", " WHERE CID = '" & vUserSelectCID & "'")
            If ds2.Tables(0).Rows.Count > 0 Then
                If ds2.Tables(0).Rows(0).Item("CID").ToString <> "" Then
                    txtCID.Text = (ds2.Tables(0).Rows(0).Item("CID").ToString)
                End If
                If ds2.Tables(0).Rows(0).Item("PRENAME").ToString <> "" Then
                    txtPrename.Text = ds2.Tables(0).Rows(0).Item("PRENAME").ToString
                    cboPrename.EditValue = txtPrename.Text
                End If
                If ds2.Tables(0).Rows(0).Item("NAME").ToString <> "" Then
                    txtName.Text = (ds2.Tables(0).Rows(0).Item("NAME")).ToString
                End If
                If Not IsDBNull(ds2.Tables(0).Rows(0).Item("LNAME")) Then
                    txtLName.Text = (ds2.Tables(0).Rows(0).Item("LNAME")).ToString
                End If

                tmpProvider = ds2.Tables(0).Rows(0).Item("PROVIDER")

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


                optUser.Checked = True
                chkPorvider0.Checked = True
                chkStatus1.Checked = True

                txtUsername.Select()
            End If
        End If

    End Sub

    Private Sub Prename()
        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_PRENAME("")
        If ds2.Tables(0).Rows.Count > 0 Then
            With cboPrename
                .Properties.DataSource = ds2.Tables(0)
                .Properties.DisplayMember = "PRENAME"
                .Properties.ValueMember = "PRENAME_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
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
                PictureBox1.Image = img
                ms.Close()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub optAdmin_Click(sender As Object, e As EventArgs) Handles optAdmin.Click
        optAdmin.Checked = True
        optUser.Checked = False
    End Sub

    Private Sub optUser_Click(sender As Object, e As EventArgs) Handles optUser.Click
        optUser.Checked = True
        optAdmin.Checked = False
    End Sub

    Private Sub chkPorvider0_Click(sender As Object, e As EventArgs) Handles chkPorvider0.Click
        chkPorvider0.Checked = True
        chkPorvider1.Checked = False
    End Sub
    Private Sub chkPorvider1_Click(sender As Object, e As EventArgs) Handles chkPorvider1.Click
        chkPorvider1.Checked = True
        chkPorvider0.Checked = False
    End Sub

    Private Sub chkStatus0_Click(sender As Object, e As EventArgs) Handles chkStatus0.Click
        chkStatus0.Checked = True
        chkStatus1.Checked = False
    End Sub

    Private Sub chkStatus1_Click(sender As Object, e As EventArgs) Handles chkStatus1.Click
        chkStatus1.Checked = True
        chkStatus0.Checked = False
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If txtUsername.Text.Trim = "" Then
            XtraMessageBox.Show("กรุณากำหนด Username ก่อน", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
            txtUsername.SelectAll()
            txtUsername.Focus()
        End If

        If txtPassword.Text.Trim = "" Then
            XtraMessageBox.Show("กรุณากำหนด Password ก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
            txtPassword.SelectAll()
            txtPassword.Focus()
        End If

        Dim tmpUserID As String = lblUSERID.Text
        Dim tmpCID As String = Trim(txtCID.Text.Replace("_", ""))
        tmpCID = Encode(Trim(tmpCID.Replace(" ", "")))
        Dim tmpPrename As String = txtPrename.Text
        Dim tmpName As String = txtName.Text
        Dim tmpUsername As String = Encode(txtUsername.Text.ToLower)
        Dim tmpPassword As String = Encode(txtPassword.Text.ToLower)
        Dim tmpLname As String = txtLName.Text
        Dim tmpAdmin As String = ""
        If optAdmin.Checked = True Then
            tmpAdmin = "1"
        ElseIf optUser.Checked = True Then
            tmpAdmin = "0"
        End If
        Dim tmpStatus As String = ""
        If chkStatus1.Checked = True Then
            tmpStatus = "1"
        Else
            tmpStatus = "0"
        End If
        Dim STATUS_AF As String = "1"

        Dim tmpDrugStroe As String = ""
        If chkDrug.Checked = True Then
            tmpDrugStroe = "1"
        Else
            tmpDrugStroe = "0"
        End If
        Dim tmpAcc As String = ""
        If chkAccout.Checked = True Then
            tmpAcc = "1"
        Else
            tmpAcc = "0"
        End If
        Dim tmpPop As String = ""
        If chkPop.Checked = True Then
            tmpPop = "1"
        Else
            tmpPop = "0"
        End If
        Dim tmpService As String = ""
        If chkService.Checked = True Then
            tmpService = "1"
        Else
            tmpService = "0"
        End If
        Dim tmpChronic As String = ""
        If chkChronic.Checked = True Then
            tmpChronic = "1"
        Else
            tmpChronic = "0"
        End If
        Dim tmpMetAdmin As String = ""
        If chkMetAdmin.Checked = True Then
            tmpMetAdmin = "1"
        Else
            tmpMetAdmin = "0"
        End If
        Dim tmpMetUser As String = ""
        If chkMetUser.Checked = True Then
            tmpMetUser = "1"
        Else
            tmpMetUser = "0"
        End If
        Dim tmpAsset As String = ""
        If chkAsset.Checked = True Then
            tmpAsset = "1"
        Else
            tmpAsset = "0"
        End If
        Dim tmpData As String = ""
        If chkDataAdmin.Checked = True Then
            tmpData = "1"
        Else
            tmpData = "0"
        End If
        Dim tmpProviderID As String = ""
        If chkPorvider1.Checked = True Then
            Dim ds2 As DataSet
            ds2 = clsdataBus.Lc_Business.SELECT_TABLE("PROVIDER", " m_provider ", " WHERE CID = '" & txtCID.Text & "'")
            If ds2.Tables(0).Rows.Count > 0 Then
                tmpProviderID = ds2.Tables(0).Rows(0).Item("PROVIDER")
            Else
                tmpProviderID = ""
            End If
        Else
            tmpProviderID = ""
        End If
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)


        If vUserSelectID <> "" Then

            clsbusent.Lc_BusinessEntity.Updatem_table("l_user", "CID = '" & tmpCID & "', PRENAME = '" & tmpPrename & "',FNAME = '" _
                                                      & tmpName & "',LNAME = '" & tmpLname & "',USERNAME = '" & tmpUsername & "',PASSWORD = '" & tmpPassword & "',ADMIN = '" _
                                                      & tmpAdmin & "',STATUS = '" & tmpStatus & "',PROVIDER = '" & tmpProviderID & "',USER_REC = '" & vUSERID & "',D_UPDATE = '" _
                                                      & tmpNow & "',STATUS_AF = '" & STATUS_AF & "',DRUG_STORE = '" & tmpDrugStroe & "',ACC = '" & tmpAcc & "',POP = '" & tmpPop & "',SERVICE = '" & tmpService & "',ASSET = '" & tmpAsset & "' ,DATA = '" & tmpData & "',MET_ADMIN = '" & tmpMetAdmin & "',MET_USER = '" & tmpMetUser & "' ,CHRONIC = '" & tmpChronic & "'", "USER_ID = '" & vUserSelectID & "'")
        Else
            Dim ds As DataSet
            ds = clsdataBus.Lc_Business.SELECT_MAX_USERID()
            tmpUserID = CInt(ds.Tables(0).Rows(0).Item("MAX(USER_ID)") + 1).ToString("00000")

            If txtCID.Text.Replace("_", "") <> "" Then
                ds = clsdataBus.Lc_Business.SELECT_USER("WHERE CID = '" & Encode(txtCID.Text) & "' ")
                If ds.Tables(0).Rows.Count > 0 Then
                    XtraMessageBox.Show("ไม่สามารถบันทึกได้เนื่องจากมี User นี้แล้ว!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            clsbusent.Lc_BusinessEntity.Insertm_table("l_user (USER_ID,CID,PRENAME,FNAME,LNAME,USERNAME,PASSWORD,ADMIN,STATUS,STATUS_AF,PROVIDER,USER_REC,D_UPDATE,DRUG_STORE,ACC,POP,SERVICE,ASSET,DATA,MET_ADMIN,MET_USER,CHRONIC)",
                    "'" & tmpUserID & "','" & tmpCID & "','" & tmpPrename & "','" & tmpName & "','" & tmpLname & "','" & tmpUsername & "','" & tmpPassword & "','" & tmpAdmin & "','" & tmpStatus & "','" & STATUS_AF & "','" & tmpProviderID & "','" & vUSERID & "','" & tmpNow & "','" & tmpDrugStroe & "','" & tmpAcc & "','" & tmpPop & "','" & tmpService & "','" & tmpAsset & "','" & tmpData & "','" & tmpMetAdmin & "','" & tmpMetUser & "','" & tmpChronic & "'")

        End If

        If vPROVIDER_ID <> "" Then
            clsbusent.Lc_BusinessEntity.Updatem_table("m_provider", "USER_REC = '" & tmpUserID & "'", "PROVIDER = '" & vPROVIDER_ID & "'")
        End If

        XtraMessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

    End Sub
    Private Sub checkData()
        chkData = True
        If Trim(txtCID.Text.Replace("_", "")).Replace(" ", "") = "" Then
            txtCID.BackColor = Color.LightPink
            chkData = False
        Else
            If CheckCID(txtCID.Text) = False Then
                txtCID.BackColor = Color.Orange
                lblCIDError.Visible = True
            Else
                lblCIDError.Visible = False
                txtCID.BackColor = SystemColors.Window
            End If
        End If
        If txtPrename.Text = Nothing Then
            txtPrename.BackColor = Color.Beige
            chkData = False
        Else
            If CheckPRENAME(txtPrename.Text) = False Then
                txtPrename.BackColor = Color.LightPink
                chkData = False
            Else
                txtPrename.BackColor = Color.Beige
                cboPrename.EditValue = txtPrename.Text
            End If
        End If
        If txtName.Text = "" Then
            txtName.BackColor = Color.LightPink
            chkData = False
        Else
            txtName.BackColor = Color.Beige
        End If
        If txtLName.Text = "" Then
            txtLName.BackColor = Color.LightPink
            chkData = False
        Else
            txtLName.BackColor = Color.Beige
        End If
        If txtUsername.Text = "" Then
            txtUsername.BackColor = Color.LightPink
            chkData = False
        Else
            txtUsername.BackColor = SystemColors.Window
        End If
        If txtPassword.Text = "" Then
            txtPassword.BackColor = Color.LightPink
            chkData = False
        Else
            txtPassword.BackColor = SystemColors.Window
        End If

    End Sub

    Private Sub txtCID_Leave(sender As Object, e As EventArgs) Handles txtCID.Leave
        checkData()
    End Sub
    Private Sub txtCID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCID.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                checkData()
                txtPrename.Select()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtPrename_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrename.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                CheckDATA()
                txtName.Select()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtPrename_Leave(sender As Object, e As EventArgs) Handles txtPrename.Leave
        checkData()
    End Sub
    Private Sub cboPrename_EditValueChanged(sender As Object, e As EventArgs) Handles cboPrename.EditValueChanged
        txtPrename.Text = cboPrename.EditValue
        checkData()
        txtName.Select()
    End Sub
    Private Sub txtName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtName.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                checkData()
                txtLName.Select()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtName_Leave(sender As Object, e As EventArgs) Handles txtName.Leave
        CheckDATA()
    End Sub
    Private Sub txtLName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLName.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                CheckDATA()
                txtUsername.Select()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                checkData()
                txtPassword.Select()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtUsername_Leave(sender As Object, e As EventArgs) Handles txtUsername.Leave
        checkData()
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                checkData()
                cmdSave.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPassword_Leave(sender As Object, e As EventArgs) Handles txtPassword.Leave

        checkData()

    End Sub


End Class