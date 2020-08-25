Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Globalization
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Public Class frmWomenMain
    Dim tmpCID As String = ""

    Private Sub frmWomenMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ClearData()
        cmdAdd.Enabled = False
        cmdEdit.Enabled = False

        If vPSEARCH = "1" Then
            chkPID.Checked = True
        ElseIf vPSEARCH = "2" Then
            'txtHN.Select()
        ElseIf vPSEARCH = "3" Then
            chkCID.Checked = True
        ElseIf vPSEARCH = "4" Then
            chkName.Checked = True
        Else
            chkPID.Checked = True
        End If

        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 30
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ROWID"
            .Columns(1).Width = 0
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "PID"
            .Columns(2).Width = 120
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "HN"
            .Columns(3).Width = 50
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "CID"
            .Columns(4).Width = 100
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "วัน เดือน ปี เกิด"
            .Columns(5).Width = 100
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "อายุ"
            .Columns(6).Width = 100
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "การคุมกำเนิด"
            .Columns(7).Width = 100
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "เหตุผลที่ไม่คุมกำเนิด"
            .Columns(8).Width = 100
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(9).Text = "จำนวนบุตรทั้งหมด"
            .Columns(9).Width = 100
            .Columns(9).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(10).Text = "มีชีวิต"
            .Columns(10).Width = 100
            .Columns(10).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(11).Text = "แท้ง"
            .Columns(11).Width = 100
            .Columns(11).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(12).Text = "ตายคลอด"
            .Columns(12).Width = 100
            .Columns(12).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(13).Text = "ผู้บันทึก"
            .Columns(13).Width = 150
            .Columns(13).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(14).Text = "วันที่ปรับปรุงข้อมูล"
            .Columns(14).Width = 150
            .Columns(14).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        txtPID.Select()
    End Sub
End Class