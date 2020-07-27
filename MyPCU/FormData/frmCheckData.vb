Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Columns
Imports DevExpress.XtraTreeList.Nodes
Public Class frmCheckData
    Dim tmpFileCheck As String = ""
    Dim tmpTamount As String = ""
    Dim tmpWamount As String = ""
    Dim tmpPamount As String = ""
    Dim tmpNamount As String = ""


    Private Sub frmCheckData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 30
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "แฟ้ม"
            .Columns(1).Width = 200
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        With BetterListView2
            .Columns.Add(0).Text = "แฟ้ม"
            .Columns(0).Width = 200
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "จำนวนทั้งหมด"
            .Columns(1).Width = 150
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "รอตรวจ"
            .Columns(2).Width = 150
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "ผ่าน"
            .Columns(3).Width = 150
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "ไม่ผ่าน"
            .Columns(4).Width = 150
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With
        Timer1.Enabled = True
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 100
        Timer1.Enabled = False
        SplashScreenManager1.ShowWaitForm()
        ShowData()
        ShowDataCheck()
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub ShowData()
        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("M_TABLE", "l_configcheck", " GROUP BY m_TABLE ORDER BY m_TABLE  ")
        If ds2.Tables(0).Rows.Count > 0 Then
            DisplayData(ds2)
        Else
            BetterListView1.Items.Clear()
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

                BetterListView1.Items.Add("")
                BetterListView1.Items(i).SubItems.Add(dr("M_TABLE").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left


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
    Private Sub ShowDataCheck()
        BetterListView2.Items.Clear()
        BetterListView2.BeginUpdate()
        BetterListView2.SuspendSort()

        For i = 0 To BetterListView1.Items.Count - 1
            tmpFileCheck = BetterListView1.Items(i).SubItems(1).Text
            CheckAmount(tmpFileCheck)

            BetterListView2.Items.Add(tmpFileCheck).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
            BetterListView2.Items(i).SubItems.Add(tmpTamount).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right
            BetterListView2.Items(i).SubItems.Add(tmpWamount).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right
            BetterListView2.Items(i).SubItems.Add(tmpPamount).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right
            BetterListView2.Items(i).SubItems.Add(tmpNamount).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right

            If (i Mod 2) = 0 Then
                BetterListView2.Items(i).BackColor = Color.WhiteSmoke
            End If

            If CInt(tmpWamount) > 0 Then
                BetterListView2.Items(i).BackColor = Color.Beige
            End If

            If CInt(tmpNamount) > 0 Then
                BetterListView2.Items(i).BackColor = Color.LightPink
            End If

        Next

        BetterListView2.ResumeSort(True)
        BetterListView2.EndUpdate()
    End Sub
    Private Sub CheckAmount(ByVal strTable As String)
        strTable = "m_" & strTable.ToLower
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE(" SUM(CASE WHEN STATUS_AF <> '8' THEN 1 ELSE 0 END) AS T_COUNT,SUM(CASE WHEN STATUS_AF = '2' THEN 1 ELSE 0 END) AS W_COUNT,SUM(CASE WHEN STATUS_AF = '1' THEN 1 ELSE 0 END) AS P_COUNT,SUM(CASE WHEN STATUS_AF = '0' THEN 1 ELSE 0 END) AS N_COUNT ", strTable, "  ")
        Try
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("T_COUNT")) Then
                    tmpTamount = CInt(ds.Tables(0).Rows(0).Item("T_COUNT")).ToString("#,##0")
                Else
                    tmpTamount = 0
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("W_COUNT")) Then
                    tmpWamount = CInt(ds.Tables(0).Rows(0).Item("W_COUNT")).ToString("#,##0")
                Else
                    tmpWamount = 0
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("P_COUNT")) Then
                    tmpPamount = CInt(ds.Tables(0).Rows(0).Item("P_COUNT")).ToString("#,##0")
                Else
                    tmpPamount = 0
                End If
                If Not IsDBNull(ds.Tables(0).Rows(0).Item("N_COUNT")) Then
                    tmpNamount = CInt(ds.Tables(0).Rows(0).Item("N_COUNT")).ToString("#,##0")
                Else
                    tmpNamount = 0
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(strTable)
        End Try


    End Sub
End Class