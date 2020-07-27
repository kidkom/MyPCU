Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmAreaSetting
    Dim tmpProvinceID As String = ""
    Dim tmpRowid As String = ""
    Private Sub frmAreaSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        lblAmount.Text = ""
        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 28
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "จังหวัด"
            .Columns(1).Width = 0
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "อำเภอ"
            .Columns(2).Width = 0
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "ตำบล"
            .Columns(3).Width = 0
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "จังหวัด"
            .Columns(4).Width = 150
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "อำเภอ"
            .Columns(5).Width = 150
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "ตำบล"
            .Columns(6).Width = 150
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "หมู่ที่/ซอย/ชุมชน"
            .Columns(7).Width = 160
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 100
        Timer1.Enabled = False
        SplashScreenManager1.ShowWaitForm()

        Dim ds As DataSet
        Dim ds2 As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_confighcode", "")
        If ds.Tables(0).Rows.Count > 0 Then
            tmpProvinceID = ds.Tables(0).Rows(0).Item("PROVINCE_ID").ToString
            ds2 = clsdataBus.Lc_Business.SELECT_TABLE("AMPHUR_ID,AMPHUR_NAME", "l_cat", "WHERE PROVINCE_ID = '" & tmpProvinceID & "' GROUP BY AMPHUR_ID ORDER BY AMPHUR_ID")
            If ds2.Tables(0).Rows.Count > 0 Then
                With cboAmphur
                    .Properties.DataSource = ds2.Tables(0)
                    .Properties.DisplayMember = "AMPHUR_NAME"
                    .Properties.ValueMember = "AMPHUR_ID"
                    .Properties.ForceInitialize()
                    .Properties.PopulateColumns()
                    .Properties.Columns(0).Visible = False
                    .Properties.ShowHeader = False
                    .Properties.NullText = ""
                End With
            End If
        End If

        ShowData()

        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ShowData()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_area", "ORDER BY PROVINCE_ID,AMPHUR_ID,TAMBOL_ID")
        If ds.Tables(0).Rows.Count > 0 Then
            DisplayData(ds)
            lblAmount.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
        Else
            BetterListView1.Items.Clear()
            lblAmount.Text = "จำนวน 0 รายการ"
        End If

    End Sub
    Private Sub DisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itm As ListViewItem
        Dim tmpProvinceName As String = ""
        Dim tmpAmphurName As String = ""
        Dim tmpTambolName As String = ""

        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                tmpProvinceName = clsdataBus.Lc_Business.SELECT_NAME_PROVINCE(dr("PROVINCE_ID").ToString)
                tmpAmphurName = clsdataBus.Lc_Business.SELECT_NAME_AMPHUR(dr("PROVINCE_ID").ToString, dr("AMPHUR_ID").ToString)
                tmpTambolName = clsdataBus.Lc_Business.SELECT_NAME_TAMBOL(dr("PROVINCE_ID").ToString, dr("AMPHUR_ID").ToString, dr("TAMBOL_ID").ToString)
                BetterListView1.Items.Add(dr("ROWID").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("PROVINCE_ID").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("AMPHUR_ID").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("TAMBOL_ID").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(tmpProvinceName).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(tmpAmphurName).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(tmpTambolName).AlignHorizontal = TextAlignmentHorizontal.Center
                If dr("VILLAGE") = "00" Then
                    If Not IsDBNull(dr("VILLANAME")) Then
                        BetterListView1.Items(i).SubItems.Add(dr("VILLANAME").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                    Else
                        BetterListView1.Items(i).SubItems.Add("").AlignHorizontal = TextAlignmentHorizontal.Center
                    End If

                Else
                    BetterListView1.Items(i).SubItems.Add(dr("VILLAGE").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                End If

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If
            Next
            BetterListView1.EndUpdate()
            BetterListView1.AutoResizeColumn(4, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(5, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(6, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(7, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub cboAmphur_EditValueChanged(sender As Object, e As EventArgs) Handles cboAmphur.EditValueChanged
        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("TAMBOL_ID,TAMBOL_NAME", "l_cat", "WHERE PROVINCE_ID = '" & tmpProvinceID & "' AND AMPHUR_ID = '" & cboAmphur.EditValue & "' GROUP BY TAMBOL_ID ORDER BY TAMBOL_ID")
        If ds2.Tables(0).Rows.Count > 0 Then
            cboTambol.Properties.DataSource = Nothing
            With cboTambol
                .Properties.DataSource = ds2.Tables(0)
                .Properties.DisplayMember = "TAMBOL_NAME"
                .Properties.ValueMember = "TAMBOL_ID"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
    End Sub

    Private Sub cboTambol_EditValueChanged(sender As Object, e As EventArgs) Handles cboTambol.EditValueChanged
        txtVILLAGE.Select()
    End Sub
    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            tmpROWID = lvi.SubItems.Item(0).Text
        Next
    End Sub
    Private Sub cmdDel_Click(sender As Object, e As EventArgs) Handles cmdDel.Click
        For Each itm As BetterListViewItem In BetterListView1.Items
            If itm.Checked Then
                Try
                    clsbusent.Lc_BusinessEntity.Delete_table("l_area", " WHERE ROWID = '" & itm.SubItems.Item(0).Text & "'")
                Catch ex As Exception

                End Try
            End If
        Next
        ShowData()
    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        If cboTambol.EditValue = Nothing Then
            XtraMessageBox.Show("ไม่สามารถบันทึกข้อมูลได้กำหนดตำบลก่อน !!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If txtVILLAGE.Text.Replace("_", "") = "" Then
            XtraMessageBox.Show("ไม่สามารถบันทึกข้อมูลได้กำหนดหมู่ที่ก่อน !!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("l_area", " WHERE PROVINCE_ID = '" & tmpProvinceID & "' AND AMPHUR_ID = '" & cboAmphur.EditValue & "' AND TAMBOL_ID = '" & cboTambol.EditValue & "' AND  VILLAGE = '" & txtVILLAGE.Text & "' AND  VILLANAME = '" & TextBox2.Text & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            XtraMessageBox.Show("ไม่สามารถบันทึกข้อมูลได้เนื่องจากมีการกำหนดไว้แล้ว !!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            clsbusent.Lc_BusinessEntity.Insertm_table("l_area (PROVINCE_ID,AMPHUR_ID,TAMBOL_ID,VILLAGE,VILLANAME)",
                        "'" & tmpProvinceID & "','" & cboAmphur.EditValue & "','" & cboTambol.EditValue & "','" & txtVILLAGE.Text & "','" & TextBox2.Text & "'")
        Catch ex As Exception
            XtraMessageBox.Show("ไม่สามารถบันทึกข้อมูลได้เนื่องจากมีการกำหนดไว้แล้ว !!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ShowData()
    End Sub

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        SplashScreenManager1.ShowWaitForm()
        Dim ds As DataSet
        clsbusent.Lc_BusinessEntity.Turncate_table("l_area")
        ds = clsdataBus.Lc_Business.SELECT_TABLE("VILLAGE,TAMBON,AMPUR,CHANGWAT", "m_home", " WHERE STATUS_AF <> '8' AND VILLAGE <> '00'  GROUP BY VILLAGE,TAMBON,AMPUR,CHANGWAT ")
        If ds.Tables(0).Rows.Count > 0 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                clsbusent.Lc_BusinessEntity.Insertm_table("l_area (VILLAGE,TAMBOL_ID,AMPHUR_ID,PROVINCE_ID)", "'" & CInt(ds.Tables(0).Rows(i).Item("VILLAGE")).ToString("00") & "','" & ds.Tables(0).Rows(i).Item("TAMBON") & "','" & ds.Tables(0).Rows(i).Item("AMPUR") & "','" & ds.Tables(0).Rows(i).Item("CHANGWAT") & "'")
            Next
        Else
            ds = clsdataBus.Lc_Business.SELECT_TABLE("VILLAGE,TAMBON,AMPUR,CHANGWAT,VILLANAME", "m_home", " WHERE STATUS_AF <> '8' AND VILLAGE = '00'  GROUP BY VILLANAME,TAMBON,AMPUR,CHANGWAT ")

            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    clsbusent.Lc_BusinessEntity.Insertm_table("l_area (VILLAGE,TAMBOL_ID,AMPHUR_ID,PROVINCE_ID,VILLANAME)", "'" & CInt(ds.Tables(0).Rows(i).Item("VILLAGE")).ToString("00") & "','" & ds.Tables(0).Rows(i).Item("TAMBON") & "','" & ds.Tables(0).Rows(i).Item("AMPUR") & "','" & ds.Tables(0).Rows(i).Item("CHANGWAT") & "','" & ds.Tables(0).Rows(i).Item("VILLANAME") & "'")
                Next
            End If
        End If

        ShowData()

        SplashScreenManager1.CloseWaitForm()

    End Sub
End Class