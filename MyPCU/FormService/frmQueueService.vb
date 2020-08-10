Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Globalization
Imports System.IO
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmQueueService
    Private Sub frmQueueService_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowClinic()
        cboProviderAction()
        dtpDate1.EditValue = Now.ToString("dd/MM/yyyy")

        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 30
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "SEQ"
            .Columns(1).Width = 0
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "ลำดับแผนก"
            .Columns(2).Width = 100
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "ลำดับรวม"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "แผนก"
            .Columns(4).Width = 100
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "ชื่่อ-นามสกุล"
            .Columns(5).Width = 150
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "เพศ"
            .Columns(6).Width = 180
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "อายุ"
            .Columns(7).Width = 200
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "อาการสำคัญ"
            .Columns(8).Width = 120
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(9).Text = "อุณหภูมิ"
            .Columns(9).Width = 80
            .Columns(9).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(10).Text = "ความดันฯ"
            .Columns(10).Width = 120
            .Columns(10).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(11).Text = "ชีพจร"
            .Columns(11).Width = 120
            .Columns(11).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(12).Text = "หายใจ"
            .Columns(12).Width = 120
            .Columns(12).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With
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
    Private Sub cboProviderAction()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("PROVIDER,CONCAT(b.PRENAME_DESC,' ',a.NAME,' ',a.LNAME) AS PROVIDER_NAME,SERVICE", " m_provider a JOIN l_mypcu_prename b ON(a.PRENAME_HOS = b.PRENAME_CODE)  ", " WHERE a.STATUS_AF <> '8' AND IFNULL(SERVICE,'') = '1'  ORDER BY PROVIDER ")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboProvider
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "PROVIDER_NAME"
                .Properties.ValueMember = "PROVIDER"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = "พิมพ์เพื่อค้นหา"
            End With
        End If
    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        Dim f As New frmQueueEdit
        f.ShowDialog()
    End Sub
End Class