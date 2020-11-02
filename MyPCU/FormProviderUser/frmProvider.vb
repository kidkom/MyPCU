Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmProvider

    Private Sub frmProvider_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 30
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = ""
            .Columns(1).Width = 30
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "เลขที่ผู้ให้บริการ"
            .Columns(2).Width = 100
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "เลขทะเบียนวิชาชีพ"
            .Columns(3).Width = 120
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "เลขประชาชน"
            .Columns(4).Width = 120
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "ชื่อ-นามสกุล"
            .Columns(5).Width = 200
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "ประเภทเจ้าหน้าที่"
            .Columns(6).Width = 120
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "ตำแหน่ง"
            .Columns(7).Width = 120
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "เริ่มปฏิบัติงาน"
            .Columns(8).Width = 100
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(9).Text = "สิ้นสุดปฏิบัติงาน"
            .Columns(9).Width = 100
            .Columns(9).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(10).Text = "ผู้บันทึก"
            .Columns(10).Width = 100
            .Columns(10).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(11).Text = "ปรับปรุงเมื่อ"
            .Columns(11).Width = 100
            .Columns(11).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(12).Text = "ROWID"
            .Columns(12).Width = 0
            .Columns(12).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        CboProvider()
        Timer1.Enabled = True

    End Sub
    Private Sub CboProvider()
        cboPROVIDERTYPE.Properties.DataSource = Nothing
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("PROVIDER_CODE,PROVIDER_DESC AS PROVIDER", "l_providertype_hosp", " ORDER BY PROVIDER_DESC")
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
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 100
        Timer1.Enabled = False
        SplashScreenManager1.ShowWaitForm()

        ShowData()

        SplashScreenManager1.CloseWaitForm()

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim f As New frmProviderType
        f.ShowDialog()
        CboProvider()
    End Sub
    Private Sub ShowData()
        Dim ds As DataSet
        If chkAll.Checked = True Then
            ds = clsdataBus.Lc_Business.SELECT_TABLE("A.ROWID,A.PROVIDER,A.REGISTERNO,A.CID,B.PRENAME_DESC,A.NAME,A.LNAME,C.PROVIDER_DESC,A.POSITION,IFNULL(A.STARTDATE,'') AS STARTDATE,IFNULL(A.OUTDATE,'') AS OUTDATE,A.STATUS_AF,A.USER_REC,A.D_UPDATE,A.STATUS,IFNULL(SERVICE,'0') AS SERVICE", "m_provider A LEFT JOIN l_mypcu_prename B ON(A.PRENAME_HOS = B.PRENAME_CODE) LEFT JOIN l_providertype_hosp C ON(PROVIDER_TYPE_HOSP = C.PROVIDER_CODE)", " WHERE A.STATUS_AF <> '8' ORDER BY PROVIDER+0 DESC")
        ElseIf chk1.Checked = True Then
            ds = clsdataBus.Lc_Business.SELECT_TABLE("A.ROWID,A.PROVIDER,A.REGISTERNO,A.CID,B.PRENAME_DESC,A.NAME,A.LNAME,C.PROVIDER_DESC,A.POSITION,IFNULL(A.STARTDATE,'') AS STARTDATE,IFNULL(A.OUTDATE,'') AS OUTDATE,A.STATUS_AF,A.USER_REC,A.D_UPDATE,A.STATUS,IFNULL(SERVICE,'0') AS SERVICE", "m_provider A LEFT JOIN l_mypcu_prename B ON(A.PRENAME_HOS = B.PRENAME_CODE) LEFT JOIN l_providertype_hosp C ON(PROVIDER_TYPE_HOSP = C.PROVIDER_CODE)", " WHERE A.STATUS_AF <> '8'  AND IFNULL(A.STATUS,'1') = '1' ORDER BY PROVIDER+0 DESC")
        ElseIf chk0.Checked = True Then
            ds = clsdataBus.Lc_Business.SELECT_TABLE("A.ROWID,A.PROVIDER,A.REGISTERNO,A.CID,B.PRENAME_DESC,A.NAME,A.LNAME,C.PROVIDER_DESC,A.POSITION,IFNULL(A.STARTDATE,'') AS STARTDATE,IFNULL(A.OUTDATE,'') AS OUTDATE,A.STATUS_AF,A.USER_REC,A.D_UPDATE,A.STATUS,IFNULL(SERVICE,'0') AS SERVICE", "m_provider A LEFT JOIN l_mypcu_prename B ON(A.PRENAME_HOS = B.PRENAME_CODE) LEFT JOIN l_providertype_hosp C ON(PROVIDER_TYPE_HOSP = C.PROVIDER_CODE)", " WHERE A.STATUS_AF <> '8' AND A.STATUS = '0' ORDER BY PROVIDER+0 DESC")
        End If
        If ds.Tables(0).Rows.Count > 0 Then
            DisplayData(ds)
            Label1.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
        Else
            BetterListView1.Items.Clear()
            Label1.Text = "จำนวน 0 รายการ"
        End If


    End Sub
    Private Sub DisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim NAMEUSER As String = ""
        Dim tmpPrename As String = ""
        Dim tmpProvider As String = ""

        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                NAMEUSER = clsdataBus.Lc_Business.SELECT_NAME_USERID(dr("USER_REC").ToString)

                If dr("STATUS") = "1" Then
                    BetterListView1.Items.Add(ImageList1.Images.Item(0)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                Else
                    BetterListView1.Items.Add(ImageList1.Images.Item(1)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                End If

                If dr("SERVICE") = "1" Then
                    BetterListView1.Items(i).SubItems.Add(ImageList1.Images.Item(2)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If

                BetterListView1.Items(i).SubItems.Add(dr("PROVIDER").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("REGISTERNO").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("CID").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                If Not IsDBNull(dr("PRENAME_DESC")) Then
                    tmpPrename = dr("PRENAME_DESC").ToString
                End If
                BetterListView1.Items(i).SubItems.Add((tmpPrename.ToString & (dr("NAME").ToString) & " " & (dr("LNAME").ToString)).ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("PROVIDER_DESC").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("POSITION").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left

                If dr("STARTDATE").ToString = "" Or dr("STARTDATE").ToString = "00000000" Then
                    BetterListView1.Items(i).SubItems.Add("")
                Else
                    BetterListView1.Items(i).SubItems.Add(Thaidate(dr("STARTDATE")).ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                End If


                If dr("OUTDATE").ToString = "" Or dr("OUTDATE").ToString = "00000000" Then
                    BetterListView1.Items(i).SubItems.Add("")
                Else
                    BetterListView1.Items(i).SubItems.Add(Thaidate(dr("OUTDATE").ToString).ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                End If

                BetterListView1.Items(i).SubItems.Add(NAMEUSER.ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left

                If Not IsDBNull(dr("D_UPDATE")) Then
                    BetterListView1.Items(i).SubItems.Add(Thaidate_D_UPDATE(dr("D_UPDATE").ToString).ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If

                BetterListView1.Items(i).SubItems.Add(dr("ROWID").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center


                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                If Not IsDBNull(dr("STATUS_AF")) Then
                    If dr("STATUS_AF").ToString = "0" Then
                        BetterListView1.Items(i).BackColor = Color.LightSalmon
                    End If
                End If

            Next
            BetterListView1.AutoResizeColumn(4, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(5, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(6, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(7, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(8, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(9, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(10, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(11, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.ResumeSort(True)
            BetterListView1.EndUpdate()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        chkAll.Checked = False
        ShoData2()
    End Sub
    Private Sub ShoData2()

        SplashScreenManager1.ShowWaitForm()
        Dim tmpSQL As String = ""
        If chkAll.Checked = True Then
            tmpSQL = ""
        ElseIf chk1.Checked = True Then
            tmpSQL = " AND IFNULL(A.STATUS,'1') = '1' "
        ElseIf chk0.Checked = True Then
            tmpSQL = " AND IFNULL(A.STATUS,'1') = '0' "
        End If
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("A.ROWID,A.PROVIDER,A.REGISTERNO,A.CID,B.PRENAME_DESC,A.NAME,A.LNAME,C.PROVIDER_DESC,A.POSITION,IFNULL(A.STARTDATE,'') AS STARTDATE,IFNULL(A.OUTDATE,'') AS OUTDATE,A.STATUS_AF,A.USER_REC,A.D_UPDATE,A.STATUS,IFNULL(SERVICE,'') AS SERVICE", "m_provider A LEFT JOIN l_mypcu_prename B ON(A.PRENAME_HOS = B.PRENAME_CODE) LEFT JOIN l_providertype_hosp C ON(PROVIDER_TYPE_HOSP = C.PROVIDER_CODE)", " WHERE A.STATUS_AF <> '8' AND (A.NAME LIKE '%" & txtSearch.Text & "%' OR A.LNAME LIKE '%" & txtSearch.Text & "%') " & tmpSQL & " ORDER BY PROVIDER+0 DESC")
        If ds.Tables(0).Rows.Count > 0 Then
            DisplayData(ds)
            Label1.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
        Else
            BetterListView1.Items.Clear()
            Label1.Text = "จำนวน 0 รายการ"
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub chkAll_Click(sender As Object, e As EventArgs) Handles chkAll.Click
        chkAll.Checked = True
        chk1.Checked = False
        chk0.Checked = False
        txtSearch.Text = ""
        Timer1.Enabled = True

    End Sub
    Private Sub chk1_Click(sender As Object, e As EventArgs) Handles chk1.Click
        chkAll.Checked = False
        chk1.Checked = True
        chk0.Checked = False
        txtSearch.Text = ""
        Timer1.Enabled = True

    End Sub
    Private Sub chk0_Click(sender As Object, e As EventArgs) Handles chk0.Click
        chkAll.Checked = False
        chk1.Checked = False
        chk0.Checked = True
        txtSearch.Text = ""
        Timer1.Enabled = True
    End Sub
    Private Sub cboPROVIDERTYPE_EditValueChanged(sender As Object, e As EventArgs) Handles cboPROVIDERTYPE.EditValueChanged
        chkAll.Checked = False
        SplashScreenManager1.ShowWaitForm()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("A.ROWID,A.PROVIDER,A.REGISTERNO,A.CID,B.PRENAME_HOS,A.NAME,A.LNAME,C.PROVIDER_DESC,A.POSITION,IFNULL(A.STARTDATE,'') AS STARTDATE,IFNULL(A.OUTDATE,'') AS OUTDATE,A.STATUS_AF,A.USER_REC,A.D_UPDATE,A.STATUS", "m_provider A LEFT JOIN l_mypcu_prename B ON(A.PRENAME_HOS = B.PRENAME_CODE) LEFT JOIN l_providertype_hosp C ON(PROVIDER_TYPE_HOSP = C.PROVIDER_CODE)", " WHERE A.STATUS_AF <> '8' AND (A.NAME LIKE '%" & txtSearch.Text & "%' OR A.LNAME LIKE '%" & txtSearch.Text & "%') AND C.PROVIDER_CODE = '" & cboPROVIDERTYPE.EditValue & "' ORDER BY PROVIDER+0 DESC")
        If ds.Tables(0).Rows.Count > 0 Then
            DisplayData(ds)
            Label1.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
        Else
            BetterListView1.Items.Clear()
            Label1.Text = "จำนวน 0 รายการ"
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub cmdSearch2_Click(sender As Object, e As EventArgs) Handles cmdSearch2.Click
        vPvdROWID = ""
        Dim f As New frmProviderEdit
        f.ShowDialog()
    End Sub

    Private Sub BetterListView1_DoubleClick(sender As Object, e As EventArgs) Handles BetterListView1.DoubleClick
        Dim f As New frmProviderEdit
        f.ShowDialog()
        If txtSearch.Text <> "" Then
            Timer1.Enabled = True
        Else
            ShoData2()
        End If
    End Sub

    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            vPvdROWID = lvi.SubItems.Item(12).Text
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If vPvdROWID <> "" Then
            Dim f As New frmProviderEdit
            f.ShowDialog()
            If txtSearch.Text <> "" Then
                Timer1.Enabled = True
            Else
                ShoData2()
            End If
        End If
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            ShoData2()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim f As New frmProviderData
        f.ShowDialog()
    End Sub
End Class