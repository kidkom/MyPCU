Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.IO
Imports DevExpress.XtraEditors
Imports ComponentOwl.BetterListView

Public Class frmDepartmentEdit

    Private Sub frmDepartmentEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With BetterListView1
            .Columns.Add(0).Text = "แผนก"
            .Columns(0).Width = 120
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "รหัสแผนกย่อย"
            .Columns(1).Width = 100
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "แผนกย่อย"
            .Columns(2).Width = 300
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        ShowClinic()

    End Sub
    Private Sub ShowClinic()

        Dim ds As DataSet
        If chkStatus1.Checked = True Then
            ds = clsdataBus.Lc_Business.SELECT_TABLE(" a.CLINIC_CODE,a.CLINIC_SUB_DESC,IFNULL(b.CLINIC_DESC,'') AS MAIN_DESC", "  l_clinic_hosp a LEFT JOIN l_clinic b ON(a.MAIN_CODE = b.CLINIC_CODE) ", " WHERE a.STATUS = '1' ")
        ElseIf chkStatus0.Checked = True Then
            ds = clsdataBus.Lc_Business.SELECT_TABLE(" a.CLINIC_CODE,a.CLINIC_SUB_DESC,IFNULL(b.CLINIC_DESC,'') AS MAIN_DESC ", "  l_clinic_hosp a LEFT JOIN l_clinic b ON(a.MAIN_CODE = b.CLINIC_CODE) ", " WHERE a.STATUS = '0' ")
        ElseIf chkStatusAll.Checked = True Then
            ds = clsdataBus.Lc_Business.SELECT_TABLE(" a.CLINIC_CODE,a.CLINIC_SUB_DESC,IFNULL(b.CLINIC_DESC,'') AS MAIN_DESC", "  l_clinic_hosp a LEFT JOIN l_clinic b ON(a.MAIN_CODE = b.CLINIC_CODE) ", " ")
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
        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)

                BetterListView1.Items.Add(dr("MAIN_DESC").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("CLINIC_CODE").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("CLINIC_SUB_DESC").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left


                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If


            Next

            BetterListView1.ResumeSort(True)
            BetterListView1.EndUpdate()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub chkStatus1_Click(sender As Object, e As EventArgs) Handles chkStatus1.Click
        chkStatus1.Checked = True
        chkStatus0.Checked = False
        chkStatusAll.Checked = False
        ShowClinic()
    End Sub
    Private Sub chkStatus0_Click(sender As Object, e As EventArgs) Handles chkStatus0.Click
        chkStatus1.Checked = False
        chkStatus0.Checked = True
        chkStatusAll.Checked = False
        ShowClinic()
    End Sub
    Private Sub chkStatusAll_Click(sender As Object, e As EventArgs) Handles chkStatusAll.Click
        chkStatus1.Checked = False
        chkStatus0.Checked = False
        chkStatusAll.Checked = True
        ShowClinic()
    End Sub

    Private Sub cmdSearch2_Click(sender As Object, e As EventArgs) Handles cmdSearch2.Click
        Dim f As New frmAddDepartment
        f.ShowDialog()
        ShowClinic()
    End Sub

    Private Sub BetterListView1_DoubleClick(sender As Object, e As EventArgs) Handles BetterListView1.DoubleClick
        If vClinicSelect <> "" Then
            Dim f As New frmAddDepartment
            f.ShowDialog()
            vClinicSelect = ""
            ShowClinic()
        End If

    End Sub
    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            vClinicSelect = lvi.SubItems.Item(1).Text
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If vClinicSelect <> "" Then
            Dim f As New frmAddDepartment
            f.ShowDialog()
            vClinicSelect = ""
            ShowClinic()
        End If
    End Sub
End Class