Imports clsDataAcc8 = MyPCU.ClsDataAccess8
Imports clsdataBus8 = MyPCU.ClsBusiness8
Imports clsbusent8 = MyPCU.ClsBusinessEntity8
Imports System.DateTime
Imports System.Globalization
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmAssetFixDetail

    Private Sub frmAssetFixDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 30
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ROWID"
            .Columns(1).Width = 0
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "ลำดับ"
            .Columns(2).Width = 80
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "ประเภท"
            .Columns(3).Width = 150
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "วันที่"
            .Columns(4).Width = 150
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "รายละเอียด"
            .Columns(5).Width = 400
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "จำนวนเงิน"
            .Columns(6).Width = 150
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With
        ShowDataFix()
    End Sub
    Private Sub ShowDataFix()
        Dim ds2 As DataSet
        ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("*", " m_assets_fix ", " WHERE ASSET_ID = '" & vAssetID & "' AND ID  = '" & vID & "' AND STATUS_AF = '1' ORDER BY DATE_IN DESC")
        If ds2.Tables(0).Rows.Count > 0 Then
            BetterDisplayData(ds2)
            Label23.Text = "จำนวน " & ds2.Tables(0).Rows.Count & " รายการ"
            'cmdSearchFix.Enabled = True
        Else
            BetterListView1.Items.Clear()
            Label23.Text = "จำนวน 0 รายการ"
        End If

    End Sub

    Private Sub BetterDisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itms As New BetterListViewItem
        Dim tmpPrename As String = ""
        Dim tmpSum As Double = 0.0
        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                BetterListView1.Items.Add("").AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("ROWID").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add((i + 1).ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                If dr("ASSET_STATUS") = "1" Then
                    BetterListView1.Items(i).SubItems.Add("ปรับปรุง/ซ่อม").AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("จำหน่าย").AlignHorizontal = TextAlignmentHorizontal.Center
                End If
                BetterListView1.Items(i).SubItems.Add((DateTime.ParseExact(dr("DATE_IN").ToString.Substring(0, 4) + 543 & dr("DATE_IN").ToString.Substring(4, 4), "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy")).ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("DETAIL").ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add((CDbl(dr("PRICE")).ToString("#,##0.00")).ToString).AlignHorizontal = TextAlignmentHorizontal.Right
                BetterListView1.Items(i).SubItems.Add(dr("STATUS_AF").ToString).AlignHorizontal = TextAlignmentHorizontal.Right

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                If dr("ASSET_STATUS") = "0" Then
                    BetterListView1.Items(i).BackColor = Color.LightPink
                End If
                tmpSum = tmpSum + CDbl(dr("PRICE"))
            Next
            BetterListView1.AutoResizeColumn(3, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(4, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(5, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.ResumeSort()
            BetterListView1.EndUpdate()
            Label22.Text = tmpSum.ToString("#,##0.00")
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
   
End Class