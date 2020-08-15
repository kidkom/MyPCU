Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Globalization
Imports System.IO
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors

Public Class frmDoctorRoom
    Dim tmpRoom As String = ""
    Dim tmpDoctor As String = ""
    Private Sub frmDoctorRoom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label5.Text = ""
        Label6.Text = ""

        ShowClinic()

        With BetterListView1
            .Columns.Add(0).Text = "ห้องตรวจ"
            .Columns(0).Width = 80
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "เจ้าหน้าที่"
            .Columns(1).Width = 200
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
        End With

        With BetterListView2
            .Columns.Add(0).Text = "รหัส"
            .Columns(0).Width = 0
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "เจ้าหน้าที่"
            .Columns(1).Width = 200
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
        End With

        cboClinic.EditValue = vClinic
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
    End Sub
    Private Sub ShowDoctor()
        Dim tmpSQL As String = ""
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 4)

        Dim ds As DataSet

        ds = clsdataBus.Lc_Business.SELECT_TABLE("A.PROVIDER,IFNULL(PRENAME_HOS,'') AS PRENAME,IFNULL(NAME,'') AS NAME,IFNULL(LNAME,'') AS LNAME ", "m_provider A   ", " WHERE A.STATUS_AF <> '8' AND IFNULL(SERVICE,'') = '1' AND A.PROVIDER NOT IN(SELECT IFNULL(DOCTOR,'') FROM m_doctor_room WHERE CLINIC = '" & vClinic & "' AND IFNULL(DEPARTMENT,'') = '') GROUP BY A.PROVIDER ORDER BY NAME,LNAME ")

        If ds.Tables(0).Rows.Count > 0 Then
            BetterDisplayData2(ds)
        Else
            BetterListView2.Items.Clear()
        End If
    End Sub
    Private Sub BetterDisplayData2(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim NAMEUSER As String = ""
        Dim tmpPrename As String = ""
        Dim tmpROWID As String = ""

        Try
            BetterListView2.Items.Clear()
            BetterListView2.BeginUpdate()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                tmpROWID = i + 1
                BetterListView2.Items.Add(dr("PROVIDER").ToString).AlignHorizontal = TextAlignmentHorizontal.Center

                If Not IsDBNull(dr("PRENAME")) Then
                    tmpPrename = clsdataBus.Lc_Business.SELECT_NAME_PRENAME(dr("PRENAME"))
                End If
                Try
                    BetterListView2.Items(i).SubItems.Add(tmpPrename & ((dr("NAME"))) & " " & ((dr("LNAME"))))
                Catch ex As Exception
                    BetterListView2.Items(i).SubItems.Add("มีข้อผิดพลาด!!!")
                End Try

                If (i Mod 2) = 0 Then
                    BetterListView2.Items(i).BackColor = Color.WhiteSmoke
                End If

            Next
            BetterListView2.EndUpdate()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message & " " & tmpROWID, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub ShowDoctorRoom()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("ROOM,IFNULL(PRENAME_HOS,'') AS PRENAME,IFNULL(NAME,'') AS NAME,IFNULL(LNAME,'') AS LNAME ", "m_doctor_room A LEFT JOIN m_provider B ON(A.DOCTOR = B.PROVIDER)", " WHERE A.CLINIC = '" & vClinic & "' AND IFNULL(A.DEPARTMENT,'') = '' ORDER BY ROOM+0 ")
        If ds.Tables(0).Rows.Count > 0 Then

            BetterDisplayData(ds)
        Else

            BetterListView1.Items.Clear()
        End If
    End Sub
    Private Sub BetterDisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim tmpPrename As String = ""
        Dim tmpROWID As String = ""

        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                tmpROWID = i + 1
                BetterListView1.Items.Add(dr("ROOM").ToString).AlignHorizontal = TextAlignmentHorizontal.Center

                If Not IsDBNull(dr("PRENAME")) Then
                    tmpPrename = clsdataBus.Lc_Business.SELECT_NAME_PRENAME(dr("PRENAME"))
                End If
                Try
                    BetterListView1.Items(i).SubItems.Add(tmpPrename & ((dr("NAME"))) & " " & ((dr("LNAME"))))
                Catch ex As Exception
                    BetterListView1.Items(i).SubItems.Add("มีข้อผิดพลาด!!!")
                End Try

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

            Next
            BetterListView1.EndUpdate()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message & " " & tmpROWID, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub cboClinic_EditValueChanged(sender As Object, e As EventArgs) Handles cboClinic.EditValueChanged
        ShowDoctor()
        ShowDoctorRoom()
    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        If txtRoom.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดห้องตรวจก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRoom.Select()
            Exit Sub
        End If

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("* ", "m_doctor_room ", " WHERE CLINIC = '" & vClinic & "' AND ROOM = '" & txtRoom.Text & "' ")
        If ds.Tables(0).Rows.Count > 0 Then
            XtraMessageBox.Show("ไม่สามารถเพิ่มได้เนื่องจากมีการเพิ่มห้องตรวจนี้แล้ว!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRoom.Select()
            Exit Sub
        End If

        clsbusent.Lc_BusinessEntity.Insertm_table("m_doctor_room (CLINIC,ROOM)",
       "'" & vClinic & "','" & txtRoom.Text & "'")

        txtRoom.Text = ""
        ShowDoctorRoom()
        ShowDoctor()
    End Sub

    Private Sub cmdEdit_Click(sender As Object, e As EventArgs) Handles cmdEdit.Click
        If Label6.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดห้องตรวจที่ต้องการลบก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If XtraMessageBox.Show("คุณต้องการลบข้อมูลห้องตรวจใช่หรือไม่?", vProgram, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
            clsbusent.Lc_BusinessEntity.Delete_table("m_doctor_room", " WHERE CLINIC = '" & vClinic & "' AND ROOM = '" & tmpRoom & "'")
            ShowDoctorRoom()
            Label6.Text = ""
        End If
    End Sub

    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            tmpRoom = lvi.SubItems.Item(0).Text
            Label6.Text = tmpRoom
        Next
    End Sub

    Private Sub BetterListView2_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView2.SelectedItemsChanged
        For i As Integer = 0 To BetterListView2.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView2.SelectedItems(i)
            tmpDoctor = lvi.SubItems.Item(0).Text
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Label6.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดห้องตรวจก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("* ", "m_doctor_room ", " WHERE CLINIC = '" & vClinic & "' AND DOCTOR = '" & tmpDoctor & "' AND IFNULL(DEPARTMENT,'') = '' ")
        If ds.Tables(0).Rows.Count > 0 Then
            XtraMessageBox.Show("มีการกำหนดแพทย์ท่านนี้แล้ว!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate_En()
        clsbusent.Lc_BusinessEntity.Updatem_table("m_doctor_room", "DOCTOR  = '" & tmpDoctor & "',USER_REC = '" & vUSERID & "',D_UPDATE = '" & tmpNow & "'" _
                                      , "CLINIC = '" & vClinic & "' AND ROOM = '" & tmpRoom & "'")
        Label6.Text = ""
        tmpDoctor = ""
        ShowDoctorRoom()
        ShowDoctor()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Label6.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดห้องตรวจก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate_En()
        clsbusent.Lc_BusinessEntity.Updatem_table("m_doctor_room", "DOCTOR  = '',USER_REC = '" & vUSERID & "',D_UPDATE = '" & tmpNow & "'" _
                                      , "CLINIC = '" & vClinic & "' AND ROOM = '" & tmpRoom & "'")
        Label6.Text = ""
        tmpDoctor = ""
        ShowDoctorRoom()
        ShowDoctor()
    End Sub
End Class