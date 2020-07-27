Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmProcedPrice

    Private Sub frmProcedPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 30
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ROWID"
            .Columns(1).Width = 0
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "หมวดค่าบริการ"
            .Columns(2).Width = 100
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "รหัส"
            .Columns(3).Width = 120
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "รายการ"
            .Columns(4).Width = 120
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "ICD-10-TM"
            .Columns(5).Width = 120
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "ICD-9-CM"
            .Columns(6).Width = 120
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "รหัสกรมบัญชีกลาง"
            .Columns(7).Width = 100
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "ราคาค่าบริการ"
            .Columns(8).Width = 100
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(9).Text = "ราคาทุน"
            .Columns(9).Width = 100
            .Columns(9).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(10).Text = "บันทึกโดย"
            .Columns(10).Width = 100
            .Columns(10).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(11).Text = "ปรับปรุงเมื่อ"
            .Columns(11).Width = 100
            .Columns(11).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(12).Text = "STATUS"
            .Columns(12).Width = 0
            .Columns(12).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center

        End With

        ChargeItem()
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 100
        Timer1.Enabled = False
        SplashScreenManager1.ShowWaitForm()
        ShowData()

        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ShowData()
        Dim ds2 As DataSet
        Dim tmpSQL As String = ""
        Dim tmpSQL2 As String = ""
        Dim tmpSQL3 As String = ""

        If chkAll.Checked = True Then
            tmpSQL = ""
        ElseIf chkItem.Checked = True Then
            tmpSQL = " WHERE CHARGEITEM = '" & cboChargeItem.EditValue & "' "
        End If

        If txtSearch.Text <> "" Then
            tmpSQL2 = " AND (PROCEDCODE LIKE '" & txtSearch.Text & "%' OR DESC_ENG LIKE '%" & txtSearch.Text & "%' OR DESC_THA LIKE '%" & txtSearch.Text & "%' OR PROCEDNAME LIKE '%" & txtSearch.Text & "%') "
        End If

        If chkStatus1.Checked = True Then
            tmpSQL3 = " AND A.STATUS = '1' "
        ElseIf chkStatus0.Checked = True Then
            tmpSQL3 = " AND A.STATUS = '0' "
        ElseIf chkStatus0.Checked = True Then
            tmpSQL3 = "  "
        End If

        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("A.ROWID,IFNULL(PROCEDNAME,'') AS PROCEDNAME,IFNULL(ICD9CM,'') AS ICD9CM,IFNULL(ICD,'') AS ICD,CHARGEITEM,PROCEDCODE,IFNULL(SERVICEPRICE,0) AS SERVICEPRICE,IFNULL(SERVICECOST,0) AS SERVICECOST,DESC_ENG,DESC_THA,A.STATUS,PRENAME,FNAME,LNAME,A.D_UPDATE,IFNULL(CLAIM,'') AS CLAIM,IFNULL(CSMBS,'') AS CSMBS", " l_procedprice A LEFT JOIN l_icd9 B ON(A.PROCEDCODE = B.CODE) JOIN l_user C ON(A.USER_REC = C.USER_ID) ", " " & tmpSQL & tmpSQL2 & tmpSQL3 & " ORDER BY PROCEDCODE ")
        If ds2.Tables(0).Rows.Count > 0 Then
            DisplayData(ds2)
            Label1.Text = "จำนวน " & ds2.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
        Else
            BetterListView1.Items.Clear()
            Label1.Text = "จำนวน 0 รายการ"
        End If


    End Sub
    Private Sub DisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim tmpPrename As String = ""

        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                If dr("CHARGEITEM") = "02" Then
                    BetterListView1.Items.Add(ImageList1.Images.Item(0)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                ElseIf dr("CHARGEITEM") = "06" Then
                    BetterListView1.Items.Add(ImageList1.Images.Item(1)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                ElseIf dr("CHARGEITEM") = "08" Then
                    BetterListView1.Items.Add(ImageList1.Images.Item(2)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                ElseIf dr("CHARGEITEM") = "11" Then
                    BetterListView1.Items.Add(ImageList1.Images.Item(3)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                ElseIf dr("CHARGEITEM") = "13" Then
                    BetterListView1.Items.Add(ImageList1.Images.Item(4)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                ElseIf dr("CHARGEITEM") = "14" Then
                    BetterListView1.Items.Add(ImageList1.Images.Item(5)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                ElseIf dr("CHARGEITEM") = "15" Then
                    BetterListView1.Items.Add(ImageList1.Images.Item(6)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                End If

                BetterListView1.Items(i).SubItems.Add(dr("ROWID").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
     

                If dr("CHARGEITEM") <> "" Then
                    BetterListView1.Items(i).SubItems.Add(dr("CHARGEITEM").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If dr("PROCEDCODE") <> "" Then
                    BetterListView1.Items(i).SubItems.Add(dr("PROCEDCODE").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If dr("PROCEDNAME") <> "" Then
                    BetterListView1.Items(i).SubItems.Add(dr("PROCEDNAME").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If dr("ICD") <> "" Then
                    BetterListView1.Items(i).SubItems.Add(dr("ICD").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If dr("ICD9CM") <> "" Then
                    BetterListView1.Items(i).SubItems.Add(dr("ICD9CM").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If dr("CSMBS") <> "" Then
                    BetterListView1.Items(i).SubItems.Add(dr("CSMBS").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If


                If dr("SERVICEPRICE") <> "" Then
                    BetterListView1.Items(i).SubItems.Add(CDbl(dr("SERVICEPRICE")).ToString("#,##0.00")).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right
                Else
                    BetterListView1.Items(i).SubItems.Add("0.00").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right

                End If
                If dr("SERVICECOST") <> "" Then
                    BetterListView1.Items(i).SubItems.Add(CDbl(dr("SERVICECOST")).ToString("#,##0.00")).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right
                Else
                    BetterListView1.Items(i).SubItems.Add("0.00").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right
                End If



                If Not IsDBNull(dr("PRENAME")) Then
                    tmpPrename = clsdataBus.Lc_Business.SELECT_NAME_PRENAME(dr("PRENAME"))
                End If
                BetterListView1.Items(i).SubItems.Add(tmpPrename & dr("FNAME") & " " & dr("LNAME"))
                BetterListView1.Items(i).SubItems.Add(Thaidate_D_UPDATE(dr("D_UPDATE").ToString).ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("STATUS"))



                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If
                If Not IsDBNull(dr("STATUS")) Then
                    If dr("STATUS").ToString = "0" Then
                        BetterListView1.Items(i).BackColor = Color.LightPink
                    End If
                End If
            Next
            BetterListView1.AutoResizeColumn(4, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(10, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(11, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)

            BetterListView1.ResumeSort(True)
            BetterListView1.EndUpdate()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub chkAll_Click(sender As Object, e As EventArgs) Handles chkAll.Click
        chkAll.Checked = True
        chkItem.Checked = False
        Timer1.Enabled = True
    End Sub

    Private Sub chkItem_Click(sender As Object, e As EventArgs) Handles chkItem.Click
        chkAll.Checked = False
        chkItem.Checked = True
        Timer1.Enabled = True
    End Sub

    Private Sub chkStatus1_Click(sender As Object, e As EventArgs) Handles chkStatus1.Click
        chkStatus1.Checked = True
        chkStatus0.Checked = False
        chkStatusAll.Checked = False
        If chkAll.Checked = True Or chkItem.Checked = True Then
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub chkStatus0_Click(sender As Object, e As EventArgs) Handles chkStatus0.Click
        chkStatus1.Checked = False
        chkStatus0.Checked = True
        chkStatusAll.Checked = False
        If chkAll.Checked = True Or chkItem.Checked = True Then
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub chkStatusAll_Click(sender As Object, e As EventArgs) Handles chkStatusAll.Click
        chkStatus1.Checked = False
        chkStatus0.Checked = False
        chkStatusAll.Checked = True
        If chkAll.Checked = True Or chkItem.Checked = True Then
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub cboChargeItem_EditValueChanged(sender As Object, e As EventArgs) Handles cboChargeItem.EditValueChanged
        chkItem.Checked = True
        chkAll.Checked = False
        Timer1.Enabled = True
    End Sub

    Private Sub BetterListView1_DoubleClick(sender As Object, e As EventArgs) Handles BetterListView1.DoubleClick
        Dim f As New frmProcedEdit
        f.ShowDialog()
        vProcedROWID = ""
        Timer1.Enabled = True
    End Sub

    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            vProcedROWID = lvi.SubItems.Item(1).Text
        Next
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        Timer1.Enabled = True

    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub cmdSearch2_Click(sender As Object, e As EventArgs) Handles cmdSearch2.Click
        vProcedROWID = ""
        Dim f As New frmProcedEdit
        f.ShowDialog()
    End Sub
End Class