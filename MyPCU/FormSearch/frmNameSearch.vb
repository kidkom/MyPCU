Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Globalization
Imports System.IO
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors

Public Class frmNameSearch
    Private Sub frmNameSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 30
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "ประเภท"
            .Columns(1).Width = 100
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "PID"
            .Columns(2).Width = 100
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "CID"
            .Columns(3).Width = 120
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "ชื่อ-นามสกุล"
            .Columns(4).Width = 120
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "วันเดือนปีเกิด"
            .Columns(5).Width = 120
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "อายุ"
            .Columns(6).Width = 200
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "ที่อยู่"
            .Columns(7).Width = 200
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        Timer1.Enabled = True

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 100
        Timer1.Enabled = False
        SplashScreenManager1.ShowWaitForm()
        SearchData()

        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub SearchData()
        Dim tmpSQL As String = ""
        If vSearchPID <> "" Then
            tmpSQL = " WHERE a.PID = '" & vSearchPID & "' AND a.STATUS_AF <> '8' "
        ElseIf vSearchCID <> "" Then
            tmpSQL = " WHERE a.CID LIKE '%" & vSearchCID & "%' AND a.STATUS_AF <> '8' "
        ElseIf vSearchName <> "" Then
            tmpSQL = " WHERE (NAME Like '%" & vSearchName & "%' OR LNAME LIKE '%" & vSearchName & "%') "
        End If

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("a.PID,a.HID,HN,CID,IFNULL(PRENAME_DESC,'') AS  PRENAME_DESC,NAME,LNAME,a.SEX,IFNULL(BIRTH,'') AS BIRTH," _
                        & "TIMESTAMPDIFF(YEAR, BIRTH, Now()) As AGE_YEAR,TIMESTAMPDIFF( MONTH, BIRTH, now() ) % 12 As AGE_MONTH," _
                        & "FLOOR( TIMESTAMPDIFF( DAY, BIRTH, now() ) % 30.4375 ) AS AGE_DAY,TYPEAREA,DISCHARGE," _
                        & "IF(TYPEAREA = '4','นอกเขต','ในเขต') AS AREA,h.HOUSE,h.VILLAGE,h.VILLANAME,ca1.TAMBOL_NAME,ca1.AMPHUR_NAME,ca1.PROVINCE_NAME," _
                        & "ad.HOUSENO,ad.VILLAGE,ad.ROAD,ad.TAMBON,ad.AMPUR,ad.CHANGWAT,ca2.TAMBOL_NAME AS adTAMBOL,ca2.AMPHUR_NAME AS adAMPHUR,ca2.PROVINCE_NAME AS adPROVINCE" _
                        , "m_person a LEFT JOIN l_mypcu_prename b ON(a.PRENAME_HOS = b.PRENAME_CODE) LEFT JOIN l_sex s ON(a.SEX = s.SEX_CODE) " _
                        & "LEFT JOIN m_home h ON(a.HID = h.HID AND h.STATUS_AF <> '8') LEFT JOIN l_cat ca1 ON(h.TAMBON = ca1.TAMBOL_ID AND h.AMPUR = ca1.AMPHUR_ID AND h.CHANGWAT = ca1.PROVINCE_ID)" _
                        & "LEFT JOIN m_address ad ON(ad.PID = a.PID AND ad.STATUS_AF <> '8') LEFT JOIN l_cat ca2 ON(ad.TAMBON = ca2.TAMBOL_ID AND ad.AMPUR = ca2.AMPHUR_ID AND ad.CHANGWAT = ca2.PROVINCE_ID)" _
                        , tmpSQL)
        If ds.Tables(0).Rows.Count > 0 Then
            DisplayData(ds)
            Label2.Text = "จำนวน " & ds.Tables(0).Rows.Count.ToString("#,##0") & " คน"
        Else
            BetterListView1.Items.Clear()
            Label2.Text = "จำนวน 0 คน"
        End If

    End Sub
    Private Sub DisplayData(ByVal ds As DataSet)
        Dim dr As DataRow
        Dim tmpPrename As String = ""
        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)

                If dr("SEX") = "1" Then
                    BetterListView1.Items.Add(ImageList1.Images.Item(0)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                Else
                    BetterListView1.Items.Add(ImageList1.Images.Item(1)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                End If
                BetterListView1.Items(i).SubItems.Add(dr("AREA").ToString).AlignHorizontal = TextAlignmentHorizontal.Center

                If Not IsDBNull(dr("PID")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("PID").ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If

                If Not IsDBNull(dr("CID")) Then
                    Try
                        BetterListView1.Items(i).SubItems.Add((dr("CID")).ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                    Catch ex As Exception
                        BetterListView1.Items(i).SubItems.Add("ข้อมูลผิดพลาด").AlignHorizontal = TextAlignmentHorizontal.Center
                    End Try
                Else
                    BetterListView1.Items(i).SubItems.Add("")
                End If
                If Not IsDBNull(dr("PRENAME_DESC")) Then
                    tmpPrename = dr("PRENAME_DESC")
                End If
                Try
                    BetterListView1.Items(i).SubItems.Add((tmpPrename & ((dr("NAME"))) & " " & ((dr("LNAME")))).ToString).AlignHorizontal = TextAlignmentHorizontal.Left
                Catch ex As Exception
                    BetterListView1.Items(i).SubItems.Add("ข้อมูลผิดพลาด")
                End Try

                If dr("BIRTH") = "" Then
                    BetterListView1.Items(i).SubItems.Add("")
                Else
                    Dim tmpDOB = DateTime.ParseExact(dr("BIRTH"), "yyyyMMdd", CultureInfo.InvariantCulture).ToString("d MMM yyyy")
                    BetterListView1.Items(i).SubItems.Add(tmpDOB).AlignHorizontal = TextAlignmentHorizontal.Center
                    Dim tmpAGE = dr("AGE_YEAR") & " ปี " & dr("AGE_MONTH") & " เดือน " & dr("AGE_DAY") & " วัน "
                    BetterListView1.Items(i).SubItems.Add(tmpAGE.ToString).AlignHorizontal = TextAlignmentHorizontal.Center
                End If



                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                If dr("DISCHARGE").ToString <> "9" Then
                    BetterListView1.Items(i).BackColor = Color.LightPink
                End If

            Next



            BetterListView1.AutoResizeColumn(2, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(3, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(4, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(5, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(6, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(7, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.ResumeSort(True)
            BetterListView1.EndUpdate()


        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
End Class