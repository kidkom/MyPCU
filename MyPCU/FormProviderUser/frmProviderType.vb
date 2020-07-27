Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.IO
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmProviderType
    Dim tmpROWID As String = ""
    Dim tmpPROVIDER As String = ""
    Dim tmpUpdate As Boolean = False

    Private Sub frmProviderType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 0
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "รหัสประเภท"
            .Columns(1).Width = 100
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "ประเภทผู้ให้บริการ"
            .Columns(2).Width = 300
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "รหัสกลุ่มผู้ให้บริการ"
            .Columns(3).Width = 0
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "กลุ่มผู้ให้บริการ"
            .Columns(4).Width = 600
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "STATUS_AF"
            .Columns(5).Width = 0
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("PROVIDER_CODE,CONCAT(PROVIDER_DESC,' [',PROVIDER_CODE,']') AS PROVIDER", "l_providertype", " ORDER BY PROVIDER_CODE")
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

        Timer1.Enabled = True

    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 100
        SplashScreenManager1.ShowWaitForm()

        ShowData()
        SplashScreenManager1.CloseWaitForm()
        Timer1.Enabled = False
    End Sub
    Private Sub ShowData()

        Dim ds2 As DataSet
        ds2 = ClsBusiness.Lc_Business.SELECT_TABLE("a.ROWID,a.PROVIDER_CODE,a.PROVIDER_DESC,IFNULL(b.PROVIDER_DESC,'') AS PROVIDER_DESC2,IFNULL(b.PROVIDER_CODE,'') AS PROVIDER_CODE2,a.STATUS_AF ", " l_providertype_hosp a LEFT JOIN l_providertype b ON(a.PROVIDER_TYPE = b.PROVIDER_CODE) ", " WHERE a.STATUS_AF = '1' ORDER BY b.PROVIDER_CODE,a.PROVIDER_DESC ")
        If ds2.Tables(0).Rows.Count > 0 Then
            Betterdisplaydata(ds2)
            Label30.Text = "จำนวน " & ds2.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
        Else
            BetterListView1.Items.Clear()
            Label30.Text = "จำนวน 0 รายการ"
        End If

    End Sub
    Private Sub Betterdisplaydata(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow

        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                BetterListView1.Items.Add(dr("ROWID"))
                If dr("PROVIDER_CODE").ToString <> "" Then
                    BetterListView1.Items(i).SubItems.Add(dr("PROVIDER_CODE").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                End If
                If dr("PROVIDER_DESC").ToString <> "" Then
                    BetterListView1.Items(i).SubItems.Add(dr("PROVIDER_DESC").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
                Else
                    BetterListView1.Items(i).SubItems.Add("").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
                End If
                If dr("PROVIDER_CODE2").ToString <> "" Then
                    BetterListView1.Items(i).SubItems.Add(dr("PROVIDER_CODE2").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                End If
                If dr("PROVIDER_DESC2").ToString <> "" Then
                    BetterListView1.Items(i).SubItems.Add(dr("PROVIDER_DESC2").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
                Else
                    BetterListView1.Items(i).SubItems.Add("").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
                End If

                BetterListView1.Items(i).SubItems.Add(dr("STATUS_AF"))

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

            Next
            BetterListView1.AutoResizeColumn(2, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(4, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.ResumeSort(True)
            BetterListView1.EndUpdate()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub cboPROVIDERTYPE_EditValueChanged(sender As Object, e As EventArgs) Handles cboPROVIDERTYPE.EditValueChanged
        lblProviderType.Text = cboPROVIDERTYPE.EditValue
    End Sub

    Private Sub cmdEdit_Click(sender As Object, e As EventArgs) Handles cmdEdit.Click
        If tmpUpdate = False Then
            AddData()
        Else
            SaveData()
        End If
    End Sub
    Private Sub AddData()
        If txtProviderType.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดประเภทผู้ให้บริการก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If lblProviderType.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดประเภทกลุ่มผู้ให้บริการก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim ds1 As DataSet
        ds1 = clsdataBus.Lc_Business.SELECT_TABLE("PROVIDER_DESC ", " l_providertype_hosp", " WHERE PROVIDER_DESC = '" & txtProviderType.Text & "' ")
        If ds1.Tables(0).Rows.Count > 0 Then
            XtraMessageBox.Show("มีการบันทึกแล้วไม่สามารถบันทึกได้อีก!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)
        Dim ds As DataSet
        Dim INS_CODE As String = ""
        ds = clsdataBus.Lc_Business.SELECT_TABLE("PROVIDER_CODE ", " l_providertype_hosp", " ORDER BY PROVIDER_CODE DESC LIMIT 1 ")
        If ds.Tables(0).Rows.Count > 0 Then
            INS_CODE = CInt(ds.Tables(0).Rows(0).Item("PROVIDER_CODE") + 1).ToString("000")
        Else
            INS_CODE = "001"

        End If
        lblProviderCode.Text = INS_CODE

        clsbusent.Lc_BusinessEntity.Insertm_table("l_providertype_hosp (PROVIDER_CODE,PROVIDER_DESC,PROVIDER_TYPE,STATUS_AF,D_UPDATE,USER_REC)", "'" & INS_CODE & "','" & txtProviderType.Text & "','" & lblProviderType.Text & "','1','" & tmpNow & "','" & vUSERID & "'")

        txtProviderType.Text = ""
        lblProviderType.Text = ""
        lblProviderCode.Text = ""
        ShowData()
    End Sub
    Private Sub SaveData()
        If txtProviderType.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดประเภทผู้ให้บริการก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If lblProviderType.Text = "" Then
            XtraMessageBox.Show("กรุณากำหนดประเภทกลุ่มผู้ให้บริการก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If tmpPROVIDER <> txtProviderType.Text Then
            Dim ds1 As DataSet
            ds1 = clsdataBus.Lc_Business.SELECT_TABLE("PROVIDER_DESC ", " l_providertype_hosp", " WHERE  PROVIDER_DESC = '" & txtProviderType.Text & "' ")
            If ds1.Tables(0).Rows.Count > 0 Then
                XtraMessageBox.Show("มีการบันทึกแล้วไม่สามารถบันทึกได้อีก!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
        Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 4) - 543 & clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(4, 10)
        Dim tmpSTATUS As String = ""
        If chkCancle.Checked = True Then
            tmpSTATUS = "0"
        Else
            tmpSTATUS = "1"
        End If

        clsbusent.Lc_BusinessEntity.Updatem_table("l_providertype_hosp", " PROVIDER_TYPE = '" & lblProviderType.Text & "',PROVIDER_DESC = '" & txtProviderType.Text & "',STATUS_AF = '" & tmpSTATUS & "',USER_REC = '" & vUSERID & "',D_UPDATE = '" & tmpNow & "'", " ROWID = '" & tmpROWID & "'")

        txtProviderType.Text = ""
        lblProviderType.Text = ""
        lblProviderCode.Text = ""
        tmpUpdate = False
        ShowData()
    End Sub

    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            tmpROWID = lvi.SubItems.Item(0).Text
            lblProviderCode.Text = lvi.SubItems.Item(1).Text
            tmpPROVIDER = lvi.SubItems.Item(2).Text
            txtProviderType.Text = lvi.SubItems.Item(2).Text
            lblProviderType.Text = lvi.SubItems.Item(3).Text
            cboPROVIDERTYPE.EditValue = lblProviderType.Text
            If lvi.SubItems.Item(5).Text = "0" Then
                chkCancle.Checked = True
            Else
                chkCancle.Checked = False
            End If
            tmpUpdate = True
        Next
    End Sub
End Class