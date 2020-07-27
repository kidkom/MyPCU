Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Public Class frmMedicineList

    Private Sub frmMedicineList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 30
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "รหัสยา"
            .Columns(1).Width = 80
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "ชื่อยา"
            .Columns(2).Width = 80
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "ชื่อยา [ไทย]"
            .Columns(3).Width = 120
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "TMTID"
            .Columns(4).Width = 100
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "รหัส 24 หลัก"
            .Columns(5).Width = 100
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "หน่วย"
            .Columns(6).Width = 100
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "หน่วยบรรจุ"
            .Columns(7).Width = 100
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "ราคาขาย"
            .Columns(8).Width = 100
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(9).Text = "เริ่มใช้ราคานี้เมื่อ"
            .Columns(9).Width = 100
            .Columns(9).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(10).Text = "บันทึกโดย"
            .Columns(10).Width = 100
            .Columns(10).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(11).Text = "ปรับปรุงเมื่อ"
            .Columns(11).Width = 100
            .Columns(11).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

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
        If chkStatus1.Checked = True Then
            tmpSQL = " AND A.STATUS = '1' "
        ElseIf chkStatus0.Checked = True Then
            tmpSQL = " AND A.STATUS = '0' "
        ElseIf chkStatusAll.Checked = True Then
            tmpSQL = ""
        End If
        If txtSearch.Text <> "" Then
            tmpSQL2 = " AND DNAME LIKE '" & txtSearch.Text & "%'"
        End If

        If chkShowAll.Checked = True Then
            ds2 = clsdataBus.Lc_Business.SELECT_TABLE("A.ROWID,CHARGEITEM,DIDSTD,DRUG_CODE,DNAME,AMOUNT_DEFAULT,dd.UNIT,UNIT_DESC,UNIT_PACKING,dd.AMOUNT,IFNULL(DRUGCOST,0) AS DRUGCOST,IFNULL(DRUG_PRICE,0) AS DRUG_PRICE,INDICATION,USED,WARNING,A.STATUS,PRENAME,FNAME,LNAME,A.D_UPDATE,IFNULL(AMOUNT_WARNING,0) AS AMOUNT_WARNING,IFNULL(WARNING_ALL,0) AS WARNING_ALL,ANTIBIOTIC,IFNULL(CLAIM,'') AS CLAIM,IFNULL(USED,'') AS USED,HOSPDRUGCODE,TMTCODE,PRINT_TH,IFNULL(DATE_PRICE,'') AS DATE_PRICE", " l_drugprice A LEFT JOIN l_unit B ON(A.UNIT = B.UNIT_CODE) LEFT JOIN l_user C ON(A.USER_REC = C.USER_ID) LEFT JOIN d_drug_amount dd ON(A.DIDSTD = dd.DRUG_ID) ", " WHERE CHARGEITEM IN('03','04','17') " & tmpSQL & tmpSQL2 & " ORDER BY DNAME ")
        ElseIf chkShow03.Checked = True Then
            ds2 = clsdataBus.Lc_Business.SELECT_TABLE("A.ROWID,CHARGEITEM,DIDSTD,DRUG_CODE,DNAME,AMOUNT_DEFAULT,dd.UNIT,UNIT_DESC,UNIT_PACKING,dd.AMOUNT,IFNULL(DRUGCOST,0) AS DRUGCOST,IFNULL(DRUG_PRICE,0) AS DRUG_PRICE,INDICATION,USED,WARNING,A.STATUS,PRENAME,FNAME,LNAME,A.D_UPDATE,IFNULL(AMOUNT_WARNING,0) AS AMOUNT_WARNING,IFNULL(WARNING_ALL,0) AS WARNING_ALL,ANTIBIOTIC,IFNULL(CLAIM,'') AS CLAIM,IFNULL(USED,'') AS USED,HOSPDRUGCODE,TMTCODE,PRINT_TH,IFNULL(DATE_PRICE,'') AS DATE_PRICE", " l_drugprice A LEFT JOIN l_unit B ON(A.UNIT = B.UNIT_CODE) LEFT JOIN l_user C ON(A.USER_REC = C.USER_ID) LEFT JOIN d_drug_amount dd ON(A.DIDSTD = dd.DRUG_ID) ", " WHERE CHARGEITEM = '03' " & tmpSQL & tmpSQL2 & " ORDER BY DNAME ")
        ElseIf chkShow17.Checked = True Then
            ds2 = clsdataBus.Lc_Business.SELECT_TABLE("A.ROWID,CHARGEITEM,DIDSTD,DRUG_CODE,DNAME,AMOUNT_DEFAULT,dd.UNIT,UNIT_DESC,UNIT_PACKING,dd.AMOUNT,IFNULL(DRUGCOST,0) AS DRUGCOST,IFNULL(DRUG_PRICE,0) AS DRUG_PRICE,INDICATION,USED,WARNING,A.STATUS,PRENAME,FNAME,LNAME,A.D_UPDATE,IFNULL(AMOUNT_WARNING,0) AS AMOUNT_WARNING,IFNULL(WARNING_ALL,0) AS WARNING_ALL,ANTIBIOTIC,IFNULL(CLAIM,'') AS CLAIM,IFNULL(USED,'') AS USED,HOSPDRUGCODE,TMTCODE,PRINT_TH,IFNULL(DATE_PRICE,'') AS DATE_PRICE", " l_drugprice A LEFT JOIN l_unit B ON(A.UNIT = B.UNIT_CODE) LEFT JOIN l_user C ON(A.USER_REC = C.USER_ID) LEFT JOIN d_drug_amount dd ON(A.DIDSTD = dd.DRUG_ID) ", " WHERE CHARGEITEM = '17' " & tmpSQL & tmpSQL2 & " ORDER BY DNAME ")
        End If

        If ds2.Tables(0).Rows.Count > 0 Then
            DisplayData(ds2)
            Label30.Text = "จำนวน " & ds2.Tables(0).Rows.Count.ToString("#,##0") & " รายการ"
        Else
            BetterListView1.Items.Clear()
            Label30.Text = "จำนวน 0 รายการ"
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

                If dr("CHARGEITEM") = "03" Then
                    BetterListView1.Items.Add(ImageList1.Images.Item(0)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                Else
                    BetterListView1.Items.Add("")
                End If

                BetterListView1.Items(i).SubItems.Add(dr("DRUG_CODE").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("DNAME").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("PRINT_TH").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(dr("TMTCODE").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("DIDSTD").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("UNIT_DESC").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("UNIT_PACKING").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(CDbl(dr("DRUG_PRICE")).ToString("#,##0.00")).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right
                If dr("DATE_PRICE") = "" Then
                    BetterListView1.Items(i).SubItems.Add("")
                Else
                    BetterListView1.Items(i).SubItems.Add(Thaidate(dr("DATE_PRICE")).ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                End If
                If Not IsDBNull(dr("PRENAME")) Then
                    tmpPrename = clsdataBus.Lc_Business.SELECT_NAME_PRENAME(dr("PRENAME"))
                End If
                BetterListView1.Items(i).SubItems.Add((tmpPrename & dr("FNAME") & " " & dr("LNAME")).ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(Thaidate_D_UPDATE(dr("D_UPDATE")).ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center


                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                If dr("STATUS").ToString = "0" Then
                    BetterListView1.Items(i).BackColor = Color.LightPink
                End If

            Next

            BetterListView1.AutoResizeColumn(2, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(3, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(5, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
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

    Private Sub chkShowAll_Click(sender As Object, e As EventArgs) Handles chkShowAll.Click
        chkShowAll.Checked = True
        chkShow03.Checked = False
        chkShow17.Checked = False
        Timer1.Enabled = True
    End Sub

    Private Sub chkShow03_Click(sender As Object, e As EventArgs) Handles chkShow03.Click
        chkShowAll.Checked = False
        chkShow03.Checked = True
        chkShow17.Checked = False
        Timer1.Enabled = True
    End Sub

    Private Sub chkShow17_Click(sender As Object, e As EventArgs) Handles chkShow17.Click
        chkShowAll.Checked = False
        chkShow03.Checked = False
        chkShow17.Checked = True
        Timer1.Enabled = True
    End Sub
End Class