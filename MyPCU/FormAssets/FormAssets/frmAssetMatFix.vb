Imports clsDataAcc8 = MyPCU.ClsDataAccess8
Imports clsdataBus8 = MyPCU.ClsBusiness8
Imports clsbusent8 = MyPCU.ClsBusinessEntity8
Imports clsdataBus = MyPCU.ClsBusiness
Imports System.DateTime
Imports System.Globalization
Imports MySql.Data.MySqlClient
Imports System.IO
Imports Microsoft.Reporting.WinForms
Imports DevExpress.XtraEditors
Imports ComponentOwl.BetterListView
Public Class frmAssetMatFix

    Private Sub frmAssetMatFix_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 30
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "รายการ"
            .Columns(1).Width = 120
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "จำนวนที่มี"
            .Columns(2).Width = 80
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "ราคาต่อหน่วย"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = ""
            .Columns(4).Width = 0
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = ""
            .Columns(5).Width = 0
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        With BetterListView2
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 30
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "รายการ"
            .Columns(1).Width = 120
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "จำนวนที่ใช้"
            .Columns(2).Width = 80
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "ราคารวม"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = ""
            .Columns(4).Width = 0
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        SearchMatGroup()
        SearchFix()
    End Sub
    Private Sub SearchMatGroup()
        cboMatGroup.Properties.DataSource = Nothing
        Dim ds As DataSet
        ds = clsdataBus8.Lc_Business8.SELECT_TABLE("A.MATERIALCODE,A.MATERIALNAME", "l_material A JOIN m_material B ON(A.MATERIALCODE = B.MET_GROUP) ", " WHERE B.STATUS_AF = '1' GROUP BY A.MATERIALCODE   ORDER BY A.MATERIALCODE ")

        If ds.Tables(0).Rows.Count > 0 Then
            With cboMatGroup
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "MATERIALNAME"
                .Properties.ValueMember = "MATERIALCODE"
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        Else
            cboMatGroup.Properties.DataSource = Nothing
        End If

    End Sub
    Private Sub cboMatGroup_EditValueChanged(sender As Object, e As EventArgs) Handles cboMatGroup.EditValueChanged
        cboMatType.Properties.DataSource = Nothing
        Dim ds As DataSet
        ds = clsdataBus8.Lc_Business8.SELECT_TABLE("A.MATERIALCODE,A.MATERIALNAME", "l_material_type A JOIN m_material B ON(A.MATERIALCODE = B.MET_TYPE)  ", " WHERE MATERIALGROUP = '" & cboMatGroup.EditValue & "' AND B.STATUS_AF = '1' GROUP BY A.MATERIALCODE   ORDER BY A.MATERIALCODE ")

        If ds.Tables(0).Rows.Count > 0 Then
            With cboMatType
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "MATERIALNAME"
                .Properties.ValueMember = "MATERIALCODE"
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        Else
            cboMatType.Properties.DataSource = Nothing
        End If

    End Sub

    Private Sub cboMatType_EditValueChanged(sender As Object, e As EventArgs) Handles cboMatType.EditValueChanged
        cboMat.Properties.DataSource = Nothing
        Dim ds As DataSet
        ds = clsdataBus8.Lc_Business8.SELECT_TABLE("METERIALCODE,MET_NAME", "m_material   ", " WHERE MET_GROUP = '" & cboMatGroup.EditValue & "' AND MET_TYPE = '" & cboMatType.EditValue & "' AND STATUS_AF = '1'  ORDER BY MET_NAME ")

        If ds.Tables(0).Rows.Count > 0 Then
            With cboMat
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "MET_NAME"
                .Properties.ValueMember = "METERIALCODE"
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        Else
            cboMat.Properties.DataSource = Nothing
        End If

    End Sub

    Private Sub cboMat_EditValueChanged(sender As Object, e As EventArgs) Handles cboMat.EditValueChanged
        CheckGroup()
    End Sub
    Private Sub CheckGroup()
        BetterListView1.Items.Clear()
        Dim tmpDepartMent As String = ""
        Dim ds1 As DataSet
        ds1 = clsdataBus8.Lc_Business8.SELECT_TABLE(" DEPARTMENT ", " l_user ", " WHERE USER_ID = '" & vUSERID & "' ")
        If ds1.Tables(0).Rows.Count > 0 Then
            tmpDepartMent = ds1.Tables(0).Rows(0).Item("DEPARTMENT")
        End If


        Dim ds As DataSet
        ds = clsdataBus8.Lc_Business8.SELECT_TABLE("b.ROWID,MET_NAME,(b.AMOUNT-b.USED) AS C_AMOUNT,b.PRICE,a.METERIALCODE,a.ROWID AS A_ROWID", "m_material a JOIN m_material_out b ON(a.METERIALCODE = b.MATERIALCODE) JOIN m_material_out_no c ON(b.REGIS_NO = c.REGIS_NO)", " WHERE b.MATERIALCODE = '" & cboMat.EditValue & "' AND (b.AMOUNT-b.USED) >= " & NumericUpDown1.Value & " AND USER_WITHDRAW IN(SELECT USER_ID FROM l_user WHERE DEPARTMENT = '" & tmpDepartMent & "') ORDER BY MET_NAME ")
        If ds.Tables(0).Rows.Count > 0 Then
            BetterDisplayData(ds)
        Else
            BetterListView1.Items.Clear()
        End If
    End Sub
    Private Sub BetterDisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itms As New BetterListViewItem
        Dim tmpPrename As String = ""

        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)

                BetterListView1.Items.Add(dr("ROWID"))
                BetterListView1.Items(i).SubItems.Add(dr("MET_NAME").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(CInt(dr("C_AMOUNT")).ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right
                BetterListView1.Items(i).SubItems.Add(CDbl(dr("PRICE")).ToString("#,##0.00")).AlignHorizontal = TextAlignmentHorizontal.Right
                BetterListView1.Items(i).SubItems.Add(dr("METERIALCODE").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("A_ROWID").ToString).AlignHorizontal = TextAlignmentHorizontal.Left

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

            Next
            BetterListView1.AutoResizeColumn(1, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.ResumeSort()
            BetterListView1.EndUpdate()

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each itm As BetterListViewItem In BetterListView1.Items
            If itm.Checked = True Then

                'Dim ds As DataSet
                'ds = clsdataBus.Lc_Business.SELECT_TABLE("ROWID", " m_fix_mat ", " WHERE MAT_REGIS_NO = '" & itm.SubItems.Item(5).Text & "' AND STATUS_AF <> '8'  ")
                'If ds.Tables(0).Rows.Count > 0 Then
                'clsbusent.Lc_BusinessEntity.UpdateM_table(" m_fix_mat ", " AMOUNT = AMOUNT+" & NumericUpDown1.Value & ",TOTAL = AMOUNT*PRICE ", " ROWID = '" & ds.Tables(0).Rows(0).Item("ROWID") & "'")
                'clsbusent.Lc_BusinessEntity.UpdateM_table(" m_material_out ", " USED = USED+" & NumericUpDown1.Value & " ", " ROWID = '" & itm.SubItems.Item(0).Text & "'")

                'Else
                Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate()

                clsbusent8.Lc_BusinessEntity8.InsertM_table("m_fix_mat (ASSETS_CODE,ASSETS_ID,FIX_ID,MATERIALCODE,AMOUNT,PRICE,TOTAL,USER_REC,D_UPDATE,STATUS_AF,MAT_REGIS_NO)",
                     "'" & picAssetCODE & "','" & PicID & "','" & fixNumID & "','" & itm.SubItems.Item(4).Text & "','" & NumericUpDown1.Value & "','" & CDbl(itm.SubItems.Item(3).Text).ToString("0.00") & "','" & CDbl(CDbl(itm.SubItems.Item(3).Text) * NumericUpDown1.Value).ToString("0.00") & "','" & vUSERID & "','" & tmpNow & "','1','" & itm.SubItems.Item(0).Text & "'")
                clsbusent8.Lc_BusinessEntity8.UpdateM_table(" m_material_out ", " USED = USED+" & NumericUpDown1.Value & " ", " ROWID = '" & itm.SubItems.Item(0).Text & "'")

                ' End If

            End If
        Next
        CheckGroup()
        SearchFix()
    End Sub
    Private Sub SearchFix()

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("b.ROWID,MET_NAME,b.AMOUNT,b.PRICE,b.TOTAL,MAT_REGIS_NO", "m_material a JOIN m_fix_mat b ON(a.METERIALCODE = b.MATERIALCODE) ", " WHERE  FIX_ID = '" & fixNumID & "' AND b.STATUS_AF <> '8'  ORDER BY MET_NAME ")
        If ds.Tables(0).Rows.Count > 0 Then
            BetterDisplayData2(ds)
        Else
            BetterListView2.Items.Clear()
        End If
    End Sub
    Private Sub BetterDisplayData2(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itms As New BetterListViewItem
        Dim tmpPrename As String = ""

        Try
            BetterListView2.Items.Clear()
            BetterListView2.BeginUpdate()
            BetterListView2.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)

                BetterListView2.Items.Add(dr("ROWID"))
                BetterListView2.Items(i).SubItems.Add(dr("MET_NAME").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView2.Items(i).SubItems.Add(CInt(dr("AMOUNT")).ToString("#,##0")).AlignHorizontal = TextAlignmentHorizontal.Right
                BetterListView2.Items(i).SubItems.Add(CDbl(dr("TOTAL")).ToString("#,##0.00")).AlignHorizontal = TextAlignmentHorizontal.Right
                BetterListView2.Items(i).SubItems.Add(dr("MAT_REGIS_NO").ToString).AlignHorizontal = TextAlignmentHorizontal.Left

                If (i Mod 2) = 0 Then
                    BetterListView2.Items(i).BackColor = Color.WhiteSmoke
                End If

            Next
            BetterListView2.AutoResizeColumn(1, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView2.ResumeSort()
            BetterListView2.EndUpdate()

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        Dim tmpSumPrice As Double = 0.0
        Dim tmpSumPrice2 As Double = 0.0
        For i = 0 To BetterListView2.Items.Count - 1
            tmpSumPrice = tmpSumPrice + CDbl(BetterListView2.Items(i).SubItems(3).Text)
        Next
        lblTotal1.Text = tmpSumPrice.ToString("#,##0.00")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For Each itm As BetterListViewItem In BetterListView2.Items
            If itm.Checked = True Then
                clsbusent8.Lc_BusinessEntity8.UpdateM_table(" m_fix_mat ", " STATUS_AF = '8' ", " ROWID = '" & itm.SubItems.Item(0).Text & "'")
                clsbusent8.Lc_BusinessEntity8.UpdateM_table(" m_material_out ", " USED = USED - " & itm.SubItems.Item(2).Text & " ", " ROWID = '" & itm.SubItems.Item(4).Text & "'")
            End If
        Next
        CheckGroup()
        SearchFix()
    End Sub
End Class