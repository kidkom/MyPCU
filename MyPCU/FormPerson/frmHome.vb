Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Columns
Imports DevExpress.XtraTreeList.Nodes
Public Class frmHome

    Private Sub frmHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With BetterListView1
            .Columns.Add(0).Text = "HID"
            .Columns(0).Width = 0
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "บ้านเลขที่"
            .Columns(1).Width = 200
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "หมู่ที่"
            .Columns(2).Width = 80
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "ซอย/ชุมชน"
            .Columns(3).Width = 120
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "ตำบล/แขวง"
            .Columns(4).Width = 150
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "อำเภอ/เขต"
            .Columns(5).Width = 150
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "จำนวนคน"
            .Columns(6).Width = 100
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "อสม."
            .Columns(7).Width = 100
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With
        TreeList1.SelectImageList = ImageList1

        TreeList1.Columns.AddField("ที่ตั้ง").Visible = True
        TreeList1.Columns.AddField("P").Visible = False
        TreeList1.Columns.AddField("A").Visible = False
        TreeList1.Columns.AddField("T").Visible = False
        TreeList1.Columns.AddField("V").Visible = False
        TreeList1.Columns.AddField("Search").Visible = False
        'AddHandler TreeList1.Load, AddressOf TreeList1_Load
        Timer1.Enabled = True
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 100
        Timer1.Enabled = False
        SplashScreenManager1.ShowWaitForm()
        CreateNodes()
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub CreateNodes()


        Dim parentForRootNodes As TreeListNode = Nothing
        Dim rootNode As TreeListNode = Nothing
        Dim parentForRootNodes2 As TreeListNode = Nothing
        Dim rootNode2 As TreeListNode = Nothing
        Dim parentForRootNodes3 As TreeListNode = Nothing
        Dim rootNode3 As TreeListNode = Nothing

        Dim ds As DataSet
        Dim tmpProvince As String = ""
        Dim tmpProvinceName As String = ""
        Dim tmpCount As String = ""
        ds = clsdataBus.Lc_Business.SELECT_TABLE("CHANGWAT, COUNT(*) AS m_COUNT", " m_home", " WHERE STATUS_AF <> '8' GROUP BY CHANGWAT")
        If ds.Tables(0).Rows.Count > 0 Then
            TreeList1.BeginUnboundLoad()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                tmpProvince = ds.Tables(0).Rows(i).Item("CHANGWAT").ToString
                tmpProvinceName = clsdataBus.Lc_Business.SELECT_NAME_PROVINCE(tmpProvince)
                tmpCount = " [" & CInt(ds.Tables(0).Rows(i).Item("M_COUNT")).ToString("#,##0") & "]"
                rootNode = TreeList1.AppendNode(New Object() {tmpProvinceName & tmpCount, tmpProvince, "0", "0", "0", "0"}, parentForRootNodes)
                rootNode.SelectImageIndex = 1
                Dim ds2 As DataSet
                ds2 = clsdataBus.Lc_Business.SELECT_TABLE("CHANGWAT,AMPUR, COUNT(*) AS m_COUNT", " m_home", "WHERE CHANGWAT = '" & tmpProvince & "' AND STATUS_AF <> '8'  GROUP BY CHANGWAT,AMPUR ORDER BY CHANGWAT,AMPUR")
                If ds2.Tables(0).Rows.Count > 0 Then
                    For k As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                        Dim tmpAmphur = ds2.Tables(0).Rows(k).Item("AMPUR").ToString
                        Dim tmpAmphurName = clsdataBus.Lc_Business.SELECT_NAME_AMPHUR(tmpProvince, tmpAmphur)
                        Dim tmpCount2 = " [" & CInt(ds2.Tables(0).Rows(k).Item("M_COUNT")).ToString("#,##0") & "]"
                        rootNode2 = TreeList1.AppendNode(New Object() {tmpAmphurName & tmpCount2, tmpProvince, tmpAmphur, "0", "0", "0"}, rootNode, parentForRootNodes2)
                        rootNode2.SelectImageIndex = 1

                        Dim tmpTambon As String = ""
                        Dim tmpTambonName As String = ""
                        Dim tmpCount3 As String = ""
                        Dim ds3 As DataSet
                        ds3 = clsdataBus.Lc_Business.SELECT_TABLE("CHANGWAT,AMPUR,TAMBON,COUNT(*) AS m_COUNT", " m_home", " WHERE CHANGWAT = '" & tmpProvince & "' AND AMPUR  = '" & tmpAmphur & "' AND STATUS_AF <> '8' GROUP BY CHANGWAT,AMPUR,TAMBON ORDER BY CHANGWAT,AMPUR,TAMBON")
                        If ds3.Tables(0).Rows.Count > 0 Then
                            For h As Integer = 0 To ds3.Tables(0).Rows.Count - 1
                                tmpTambon = ds3.Tables(0).Rows(h).Item("TAMBON").ToString
                                tmpTambonName = clsdataBus.Lc_Business.SELECT_NAME_TAMBOL(tmpProvince, tmpAmphur, tmpTambon)
                                tmpCount3 = " [" & CInt(ds3.Tables(0).Rows(h).Item("M_COUNT")).ToString("#,##0") & "]"
                                rootNode3 = TreeList1.AppendNode(New Object() {tmpTambonName & tmpCount3, tmpProvince, tmpAmphur, tmpTambon, "0", "0"}, rootNode2, parentForRootNodes3)
                                rootNode3.SelectImageIndex = 1

                                Dim ds4 As DataSet
                                Dim tmpVILLAGE As String = ""
                                Dim tmpCount4 As String = ""
                                ds4 = clsdataBus.Lc_Business.SELECT_TABLE("CHANGWAT,AMPUR,TAMBON,VILLAGE,COUNT(*) AS m_COUNT", " m_home", " WHERE CHANGWAT = '" & tmpProvince & "' AND AMPUR  = '" & tmpAmphur & "' AND TAMBON  = '" & tmpTambon & "' AND STATUS_AF <> '8' AND  VILLAGE <> '00' GROUP BY CHANGWAT,AMPUR,TAMBON,VILLAGE ORDER BY CHANGWAT,AMPUR,TAMBON,VILLAGE+1")
                                If ds4.Tables(0).Rows.Count > 0 Then

                                    For s As Integer = 0 To ds4.Tables(0).Rows.Count - 1
                                        tmpVILLAGE = ds4.Tables(0).Rows(s).Item("VILLAGE").ToString
                                        tmpCount4 = " [" & CInt(ds4.Tables(0).Rows(s).Item("M_COUNT")).ToString("#,##0") & "]"
                                        TreeList1.AppendNode(New Object() {tmpVILLAGE & tmpCount4, tmpProvince, tmpAmphur, tmpTambon, tmpVILLAGE, "1"}, rootNode3)
                                    Next
                                Else
                                    Dim ds5 As DataSet
                                    ds5 = clsdataBus.Lc_Business.SELECT_TABLE("CHANGWAT,AMPUR,TAMBON,VILLANAME,COUNT(*) AS m_COUNT", " m_home", " WHERE CHANGWAT = '" & tmpProvince & "' AND AMPUR  = '" & tmpAmphur & "' AND TAMBON  = '" & tmpTambon & "' AND STATUS_AF <> '8' AND  VILLAGE = '00' GROUP BY CHANGWAT,AMPUR,TAMBON,VILLANAME ORDER BY CHANGWAT,AMPUR,TAMBON,VILLANAME")
                                    If ds5.Tables(0).Rows.Count > 0 Then
                                        For s As Integer = 0 To ds5.Tables(0).Rows.Count - 1
                                            tmpVILLAGE = ds5.Tables(0).Rows(s).Item("VILLANAME").ToString
                                            tmpCount4 = " [" & CInt(ds5.Tables(0).Rows(s).Item("M_COUNT")).ToString("#,##0") & "]"
                                            TreeList1.AppendNode(New Object() {tmpVILLAGE & tmpCount4, tmpProvince, tmpAmphur, tmpTambon, tmpVILLAGE, "1"}, rootNode3)
                                        Next
                                    End If

                                End If
                            Next
                        End If
                    Next
                End If

            Next
            TreeList1.EndUnboundLoad()
        End If

    End Sub
    Private Sub TreeList1_Load(ByVal sender As Object, ByVal e As EventArgs)
        For Each node As TreeListNode In treeList1.Nodes
            node.ImageIndex = 0
            node.SelectImageIndex = 1
            node.StateImageIndex = 2
        Next node
    End Sub
    
    Private Sub chkExpand_Click(sender As Object, e As EventArgs) Handles chkExpand.Click
        If chkExpand.Checked = True Then
            TreeList1.ExpandAll()
        Else
            TreeList1.CollapseAll()
        End If
    End Sub

    Private Sub TreeList1_FocusedNodeChanged(sender As Object, e As FocusedNodeChangedEventArgs) Handles TreeList1.FocusedNodeChanged
        Dim tmpPcode As String = e.Node.GetValue(1).ToString()
        Dim tmpAcode As String = e.Node.GetValue(2).ToString()
        Dim tmpTcode As String = e.Node.GetValue(3).ToString()
        Dim tmpVcode As String = e.Node.GetValue(4).ToString()
        Dim tmpSearch As String = e.Node.GetValue(5).ToString()


        If tmpSearch = "1" Then
            SearchHome1(tmpPcode & tmpAcode & tmpTcode & tmpVcode)
        End If
    End Sub
    Private Sub SearchHome1(ByVal Str As String)
        SplashScreenManager1.ShowWaitForm()
        Dim ds As DataSet

        If chkError.Checked = False Then
            If CheckBox1.Checked = True Then
                If Str.ToString.Length > 8 Then
                    ds = clsdataBus.Lc_Business.SELECT_TABLE("A.HID,A.HOUSE,A.CHANGWAT,A.AMPUR,A.TAMBON,A.VILLAGE,A.VILLANAME,IFNULL(A.STATUS_AF,'') AS STATUS_AF,IFNULL(A.STATUS,'') AS STATUS,TAMBOL_NAME,AMPHUR_NAME,PROVINCE_NAME,COUNT(C.PID) AS PCOUNT,IFNULL(A.VHVID,'') AS VHVID", " m_home A JOIN l_cat B On(A.TAMBON = B.TAMBOL_ID AND A.AMPUR = B.AMPHUR_ID AND A.CHANGWAT = B.PROVINCE_ID) LEFT JOIN m_person C ON(A.HID = C.HID)", " WHERE CONCAT(A.CHANGWAT,A.AMPUR,A.TAMBON,A.VILLANAME) = '" & Str & "' AND A.STATUS_AF <> '8' GROUP BY A.HID HAVING COUNT(C.PID) = 0 ORDER BY A.HOUSE+1")
                Else
                    ds = clsdataBus.Lc_Business.SELECT_TABLE("A.HID,A.HOUSE,A.CHANGWAT,A.AMPUR,A.TAMBON,A.VILLAGE,A.VILLANAME,IFNULL(A.STATUS_AF,'') AS STATUS_AF,IFNULL(A.STATUS,'') AS STATUS,TAMBOL_NAME,AMPHUR_NAME,PROVINCE_NAME,COUNT(C.PID) AS PCOUNT,IFNULL(A.VHVID,'') AS VHVID", " m_home A JOIN l_cat B On(A.TAMBON = B.TAMBOL_ID AND A.AMPUR = B.AMPHUR_ID AND A.CHANGWAT = B.PROVINCE_ID) LEFT JOIN m_person C ON(A.HID = C.HID)", " WHERE CONCAT(A.CHANGWAT,A.AMPUR,A.TAMBON,A.VILLANAME) = '" & Str & "' AND A.STATUS_AF <> '8' GROUP BY A.HID HAVING COUNT(C.PID) = 0 ORDER BY A.HOUSE+1")
                End If
            Else
                If Str.ToString.Length > 8 Then
                    ds = clsdataBus.Lc_Business.SELECT_TABLE("A.HID,A.HOUSE,A.CHANGWAT,A.AMPUR,A.TAMBON,A.VILLAGE,A.VILLANAME,IFNULL(A.STATUS_AF,'') AS STATUS_AF,IFNULL(A.STATUS,'') AS STATUS,TAMBOL_NAME,AMPHUR_NAME,PROVINCE_NAME,COUNT(C.PID) AS PCOUNT,IFNULL(A.VHVID,'') AS VHVID", " m_home A JOIN l_cat B On(A.TAMBON = B.TAMBOL_ID AND A.AMPUR = B.AMPHUR_ID AND A.CHANGWAT = B.PROVINCE_ID) LEFT JOIN m_person C ON(A.HID = C.HID)", " WHERE CONCAT(A.CHANGWAT,A.AMPUR,A.TAMBON,A.VILLANAME) = '" & Str & "' AND A.STATUS_AF <> '8' GROUP BY A.HID ORDER BY A.HOUSE+1")
                Else
                    ds = clsdataBus.Lc_Business.SELECT_TABLE("A.HID,A.HOUSE,A.CHANGWAT,A.AMPUR,A.TAMBON,A.VILLAGE,A.VILLANAME,IFNULL(A.STATUS_AF,'') AS STATUS_AF,IFNULL(A.STATUS,'') AS STATUS,TAMBOL_NAME,AMPHUR_NAME,PROVINCE_NAME,COUNT(C.PID) AS PCOUNT,IFNULL(A.VHVID,'') AS VHVID", " m_home A JOIN l_cat B On(A.TAMBON = B.TAMBOL_ID AND A.AMPUR = B.AMPHUR_ID AND A.CHANGWAT = B.PROVINCE_ID) LEFT JOIN m_person C ON(A.HID = C.HID)", " WHERE CONCAT(A.CHANGWAT,A.AMPUR,A.TAMBON,A.VILLAGE) = '" & Str & "' AND A.STATUS_AF <> '8' GROUP BY A.HID ORDER BY A.HOUSE+1")
                End If
            End If
        Else
            If CheckBox1.Checked = True Then
                If Str.ToString.Length > 8 Then
                    ds = clsdataBus.Lc_Business.SELECT_TABLE("A.HID,A.HOUSE,A.CHANGWAT,A.AMPUR,A.TAMBON,A.VILLAGE,A.VILLANAME,IFNULL(A.STATUS_AF,'') AS STATUS_AF,IFNULL(A.STATUS,'') AS STATUS,TAMBOL_NAME,AMPHUR_NAME,PROVINCE_NAME,COUNT(C.PID) AS PCOUNT,IFNULL(A.VHVID,'') AS VHVID", " m_home A JOIN l_cat B On(A.TAMBON = B.TAMBOL_ID AND A.AMPUR = B.AMPHUR_ID AND A.CHANGWAT = B.PROVINCE_ID) LEFT JOIN m_person C ON(A.HID = C.HID)", " WHERE CONCAT(A.CHANGWAT,A.AMPUR,A.TAMBON,A.VILLANAME) = '" & Str & "' AND IFNULL(A.STATUS_AF,'') = '0' GROUP BY A.HID HAVING COUNT(C.PID) = 0 ORDER BY A.HOUSE+1")
                Else
                    ds = clsdataBus.Lc_Business.SELECT_TABLE("A.HID,A.HOUSE,A.CHANGWAT,A.AMPUR,A.TAMBON,A.VILLAGE,A.VILLANAME,IFNULL(A.STATUS_AF,'') AS STATUS_AF,IFNULL(A.STATUS,'') AS STATUS,TAMBOL_NAME,AMPHUR_NAME,PROVINCE_NAME,COUNT(C.PID) AS PCOUNT,IFNULL(A.VHVID,'') AS VHVID", " m_home A JOIN l_cat B On(A.TAMBON = B.TAMBOL_ID AND A.AMPUR = B.AMPHUR_ID AND A.CHANGWAT = B.PROVINCE_ID) LEFT JOIN m_person C ON(A.HID = C.HID)", " WHERE CONCAT(A.CHANGWAT,A.AMPUR,A.TAMBON,A.VILLAGE) = '" & Str & "' AND IFNULL(A.STATUS_AF,'') = '0' GROUP BY A.HID HAVING COUNT(C.PID) = 0 ORDER BY A.HOUSE+1")
                End If
            Else
                If Str.ToString.Length > 8 Then
                    ds = clsdataBus.Lc_Business.SELECT_TABLE("A.HID,A.HOUSE,A.CHANGWAT,A.AMPUR,A.TAMBON,A.VILLAGE,A.VILLANAME,IFNULL(A.STATUS_AF,'') AS STATUS_AF,IFNULL(A.STATUS,'') AS STATUS,TAMBOL_NAME,AMPHUR_NAME,PROVINCE_NAME,COUNT(C.PID) AS PCOUNT,IFNULL(A.VHVID,'') AS VHVID", " m_home A JOIN l_cat B On(A.TAMBON = B.TAMBOL_ID AND A.AMPUR = B.AMPHUR_ID AND A.CHANGWAT = B.PROVINCE_ID) LEFT JOIN m_person C ON(A.HID = C.HID)", " WHERE CONCAT(A.CHANGWAT,A.AMPUR,A.TAMBON,A.VILLANAME) = '" & Str & "' AND IFNULL(A.STATUS_AF,'') = '0' GROUP BY A.HID ORDER BY A.HOUSE+1")
                Else
                    ds = clsdataBus.Lc_Business.SELECT_TABLE("A.HID,A.HOUSE,A.CHANGWAT,A.AMPUR,A.TAMBON,A.VILLAGE,A.VILLANAME,IFNULL(A.STATUS_AF,'') AS STATUS_AF,IFNULL(A.STATUS,'') AS STATUS,TAMBOL_NAME,AMPHUR_NAME,PROVINCE_NAME,COUNT(C.PID) AS PCOUNT,IFNULL(A.VHVID,'') AS VHVID", " m_home A JOIN l_cat B On(A.TAMBON = B.TAMBOL_ID AND A.AMPUR = B.AMPHUR_ID AND A.CHANGWAT = B.PROVINCE_ID) LEFT JOIN m_person C ON(A.HID = C.HID)", " WHERE CONCAT(A.CHANGWAT,A.AMPUR,A.TAMBON,A.VILLAGE) = '" & Str & "' AND IFNULL(A.STATUS_AF,'') = '0' GROUP BY A.HID ORDER BY A.HOUSE+1")
                End If
            End If
        End If

        If ds.Tables(0).Rows.Count > 0 Then
            DisplayData(ds)
            Label1.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0") & " หลัง"
        Else
            BetterListView1.Items.Clear()
            Label1.Text = "จำนวน 0 หลัง"
        End If

        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub DisplayData(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim itm As ListViewItem
        Dim tmpProvinceName As String = ""
        Dim tmpAmphurName As String = ""
        Dim tmpTambonName As String = ""
        Dim tmpData As String = ""

        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)

                tmpProvinceName = dr("PROVINCE_NAME")
                tmpAmphurName = dr("AMPHUR_NAME")
                tmpTambonName = dr("TAMBOL_NAME")

                BetterListView1.Items.Add(dr("HID"))
                BetterListView1.Items(i).SubItems.Add(dr("HOUSE").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(CInt(dr("VILLAGE")).ToString("#0")).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(dr("VILLANAME").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
                BetterListView1.Items(i).SubItems.Add(tmpTambonName).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(tmpAmphurName).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                BetterListView1.Items(i).SubItems.Add(CInt(dr("PCOUNT")).ToString("#,##0")).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right
                If dr("VHVID") = "" Then
                    BetterListView1.Items(i).SubItems.Add(ImageList1.Images.Item(3), "ยังไม่กำหนด").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add(ImageList1.Images.Item(4), clsdataBus.Lc_Business.SELECT_NAME_PERSON(dr("VHVID")).ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
                End If



                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If


                If dr("STATUS_AF").ToString = "0" Then
                    BetterListView1.Items(i).BackColor = Color.LightSalmon
                End If
                If dr("STATUS").ToString = "0" Then
                    BetterListView1.Items(i).BackColor = Color.LightPink
                End If

            Next

            BetterListView1.AutoResizeColumn(3, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            'BetterListView1.AutoResizeColumn(4, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            'BetterListView1.AutoResizeColumn(5, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(7, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)

            BetterListView1.ResumeSort(True)
            BetterListView1.EndUpdate()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub cmdSearch1_Click(sender As Object, e As EventArgs) Handles cmdSearch1.Click
        SearchData2()
    End Sub
    Private Sub SearchData2()
        SplashScreenManager1.ShowWaitForm()
        Dim Ds As DataSet

        If chkError.Checked = False Then
            If CheckBox1.Checked = True Then
                Ds = clsdataBus.Lc_Business.SELECT_TABLE("A.HID,A.HOUSE,A.CHANGWAT,A.AMPUR,A.TAMBON,A.VILLAGE,A.VILLANAME,IFNULL(A.STATUS_AF,'') AS STATUS_AF,IFNULL(A.STATUS,'') AS STATUS,TAMBOL_NAME,AMPHUR_NAME,PROVINCE_NAME,COUNT(C.PID) AS PCOUNT,IFNULL(A.VHVID,'') AS VHVID", " m_home A JOIN l_cat B On(A.TAMBON = B.TAMBOL_ID AND A.AMPUR = B.AMPHUR_ID AND A.CHANGWAT = B.PROVINCE_ID) LEFT JOIN m_person C ON(A.HID = C.HID)", " WHERE A.HOUSE = '" & txtHouseSearch.Text & "'  AND A.STATUS_AF <> '8' GROUP BY A.HID HAVING COUNT(C.PID) = 0 ORDER BY A.HOUSE+1")
            Else
                Ds = clsdataBus.Lc_Business.SELECT_TABLE("A.HID,A.HOUSE,A.CHANGWAT,A.AMPUR,A.TAMBON,A.VILLAGE,A.VILLANAME,IFNULL(A.STATUS_AF,'') AS STATUS_AF,IFNULL(A.STATUS,'') AS STATUS,TAMBOL_NAME,AMPHUR_NAME,PROVINCE_NAME,COUNT(C.PID) AS PCOUNT,IFNULL(A.VHVID,'') AS VHVID", " m_home A JOIN l_cat B On(A.TAMBON = B.TAMBOL_ID AND A.AMPUR = B.AMPHUR_ID AND A.CHANGWAT = B.PROVINCE_ID) LEFT JOIN m_person C ON(A.HID = C.HID)", " WHERE A.HOUSE = '" & txtHouseSearch.Text & "'  AND A.STATUS_AF <> '8' GROUP BY A.HID ORDER BY A.HOUSE+1")
            End If
        Else
            If CheckBox1.Checked = True Then
                Ds = clsdataBus.Lc_Business.SELECT_TABLE("A.HID,A.HOUSE,A.CHANGWAT,A.AMPUR,A.TAMBON,A.VILLAGE,A.VILLANAME,IFNULL(A.STATUS_AF,'') AS STATUS_AF,IFNULL(A.STATUS,'') AS STATUS,TAMBOL_NAME,AMPHUR_NAME,PROVINCE_NAME,COUNT(C.PID) AS PCOUNT,IFNULL(A.VHVID,'') AS VHVID", " m_home A JOIN l_cat B On(A.TAMBON = B.TAMBOL_ID AND A.AMPUR = B.AMPHUR_ID AND A.CHANGWAT = B.PROVINCE_ID) LEFT JOIN m_person C ON(A.HID = C.HID)", " WHERE A.HOUSE ='" & txtHouseSearch.Text & "'  AND IFNULL(A.STATUS_AF,'') = '0' GROUP BY A.HID HAVING COUNT(C.PID) = 0 ORDER BY A.HOUSE+1")
            Else
                Ds = clsdataBus.Lc_Business.SELECT_TABLE("A.HID,A.HOUSE,A.CHANGWAT,A.AMPUR,A.TAMBON,A.VILLAGE,A.VILLANAME,IFNULL(A.STATUS_AF,'') AS STATUS_AF,IFNULL(A.STATUS,'') AS STATUS,TAMBOL_NAME,AMPHUR_NAME,PROVINCE_NAME,COUNT(C.PID) AS PCOUNT,IFNULL(A.VHVID,'') AS VHVID", " m_home A JOIN l_cat B On(A.TAMBON = B.TAMBOL_ID AND A.AMPUR = B.AMPHUR_ID AND A.CHANGWAT = B.PROVINCE_ID) LEFT JOIN m_person C ON(A.HID = C.HID)", " WHERE A.HOUSE = '" & txtHouseSearch.Text & "'  AND IFNULL(A.STATUS_AF,'') = '0' GROUP BY A.HID ORDER BY A.HOUSE+1")
            End If
        End If

        If Ds.Tables(0).Rows.Count > 0 Then
            DisplayData(Ds)
            Label1.Text = "จำนวน " & Ds.Tables(0).Rows.Count.ToString("#,##0") & " หลัง"
        Else
            BetterListView1.Items.Clear()
            Label1.Text = "จำนวน 0 หลัง"
        End If

        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub txtHouseSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHouseSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            SearchData2()
        End If
    End Sub

    Private Sub BetterListView1_DoubleClick(sender As Object, e As EventArgs) Handles BetterListView1.DoubleClick
        Dim f As New frmHomeEdit
        f.ShowDialog()
    End Sub

    Private Sub BetterListView1_SelectedItemsChanged(sender As Object, eventArgs As BetterListViewSelectedItemsChangedEventArgs) Handles BetterListView1.SelectedItemsChanged
        For i As Integer = 0 To BetterListView1.SelectedItems.Count - 1
            Dim lvi As BetterListViewItem
            lvi = BetterListView1.SelectedItems(i)
            vHomeHID = lvi.SubItems.Item(0).Text
        Next
    End Sub
End Class