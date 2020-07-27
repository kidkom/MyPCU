Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports ComponentOwl.BetterListView
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Drawing
Imports MyPCU.GraphicsEditor
'Imports DevExpress.XtraTreeList
'Imports DevExpress.XtraTreeList.Columns
'Imports DevExpress.XtraTreeList.Nodes
Imports System.DateTime
Imports System.Globalization

Public Class frmHomeEdit
    Dim tmpHouse As String = ""
    Dim tmpHTYPE_Update As Boolean = False
    Dim tmpAssress As String = ""
    Dim ChkData As Boolean = True
    Dim ChkSanitation As Boolean = True

    Private Sub frmHomeEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        With BetterListView1
            .Columns.Add(0).Text = ""
            .Columns(0).Width = 30
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "สถานะในครอบครัว"
            .Columns(1).Width = 120
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "PID"
            .Columns(2).Width = 100
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "HN"
            .Columns(3).Width = 100
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "CID"
            .Columns(4).Width = 120
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "ชื่อ-นามสกุล"
            .Columns(5).Width = 150
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(6).Text = "เพศ"
            .Columns(6).Width = 60
            .Columns(6).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(7).Text = "วันเดือนปีเกิด"
            .Columns(7).Width = 120
            .Columns(7).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(8).Text = "อายุ"
            .Columns(8).Width = 150
            .Columns(8).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(9).Text = "สถานะสมรส"
            .Columns(9).Width = 120
            .Columns(9).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(10).Text = "การจำหน่าย"
            .Columns(10).Width = 120
            .Columns(10).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With

        With BetterListView2
            .Columns.Add(0).Text = "ROWID"
            .Columns(0).Width = 0
            .Columns(0).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(1).Text = "DATE_SERV"
            .Columns(1).Width = 0
            .Columns(1).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(2).Text = "วันที่รับบริการ"
            .Columns(2).Width = 100
            .Columns(2).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(3).Text = "จำนวนภาชนะ"
            .Columns(3).Width = 150
            .Columns(3).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(4).Text = "จำนวนภาชนะที่พบ"
            .Columns(4).Width = 150
            .Columns(4).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
            .Columns.Add(5).Text = "วันที่ปรับปรุงข้อมูล"
            .Columns(5).Width = 200
            .Columns(5).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
        End With


        housetype()
        provincelist()
        housetype_new()
        ShowHome()
    End Sub
    Private Sub housetype()
        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("HTYPE_CODE,CONCAT('[',HTYPE_CODE,'] ',HTYPE_DESC) AS HTYPE_DESC", " l_housetype ", " WHERE STATUS = '1' ")
        If ds2.Tables(0).Rows.Count > 0 Then
            With cboHOUSETYPE
                .Properties.DataSource = ds2.Tables(0)
                .Properties.DisplayMember = "HTYPE_DESC"
                .Properties.ValueMember = "HTYPE_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
    End Sub
    Private Sub housetype_new()
        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("HTYPE_CODE,CONCAT('[',HTYPE_CODE,'] ',HTYPE_DESC) AS HTYPE_DESC", " l_housetype_new ", " WHERE STATUS = '1' ")
        If ds2.Tables(0).Rows.Count > 0 Then
            With cboHTYPE
                .Properties.DataSource = ds2.Tables(0)
                .Properties.DisplayMember = "HTYPE_DESC"
                .Properties.ValueMember = "HTYPE_CODE"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
    End Sub
    Private Sub provincelist()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("A.PROVINCE_ID,PROVINCE_NAME ", "l_area A INNER JOIN l_catm B ON(A.PROVINCE_ID = B.PROVINCE_ID)", "GROUP BY A.PROVINCE_ID,PROVINCE_NAME ")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboCHANGWAT
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "PROVINCE_NAME"
                .Properties.ValueMember = "PROVINCE_ID"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
    End Sub
    Private Sub ampurlist()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("A.AMPHUR_ID,AMPHUR_NAME ", "l_area A INNER JOIN l_catm B ON(A.PROVINCE_ID = B.PROVINCE_ID AND A.AMPHUR_ID = B.AMPHUR_ID)", "WHERE A.PROVINCE_ID = '" & txtCHANGWAT.Text & "'  GROUP BY A.AMPHUR_ID,AMPHUR_NAME ")
        If Ds.Tables(0).Rows.Count > 0 Then
            With cboAMPHUR
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "AMPHUR_NAME"
                .Properties.ValueMember = "AMPHUR_ID"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
    End Sub
    Private Sub tambonlist()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("A.TAMBOL_ID,TAMBOL_NAME ", "l_area A INNER JOIN l_cat B ON(A.PROVINCE_ID = B.PROVINCE_ID AND A.AMPHUR_ID = B.AMPHUR_ID AND A.TAMBOL_ID = B.TAMBOL_ID)", "WHERE A.PROVINCE_ID = '" & txtCHANGWAT.Text & "' AND B.AMPHUR_ID = '" & txtAMPUR.Text & "' GROUP BY A.TAMBOL_ID,TAMBOL_NAME ")
        If ds.Tables(0).Rows.Count > 0 Then
            With cboTAMBON
                .Properties.DataSource = ds.Tables(0)
                .Properties.DisplayMember = "TAMBOL_NAME"
                .Properties.ValueMember = "TAMBOL_ID"
                .Properties.ForceInitialize()
                .Properties.PopulateColumns()
                .Properties.Columns(0).Visible = False
                .Properties.ShowHeader = False
                .Properties.NullText = ""
            End With
        End If
    End Sub
    Private Sub ShowHome()
        Dim ds As DataSet

        ds = clsdataBus.Lc_Business.SELECT_DATA("m_home", "WHERE HID = '" & vHomeHID & "' AND IFNULL(STATUS_AF,'') <> '8' ")
        If ds.Tables(0).Rows.Count > 0 Then

            lblHID.Text = ds.Tables(0).Rows(0).Item("HID").ToString
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("HOUSE_ID")) Then
                txtHOUSE_ID.Text = ds.Tables(0).Rows(0).Item("HOUSE_ID").ToString
            Else
                txtHOUSE_ID.Text = Nothing
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("HEADID")) Then
                Dim tmpHEADID As String = ds.Tables(0).Rows(0).Item("HEADID").ToString
                lblHEADID.Text = clsdataBus.Lc_Business.SELECT_NAME_PERSON(tmpHEADID)
            Else
                lblHEADID.Text = ""
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("LOCATYPE")) Then
                txtLOCATYPE.Text = ds.Tables(0).Rows(0).Item("LOCATYPE").ToString
                If txtLOCATYPE.Text = "1" Then
                    optLOCALTYPE1.Checked = True
                Else
                    optLOCALTYPE2.Checked = True
                End If
            Else
                txtLOCATYPE.Text = Nothing
                optLOCALTYPE1.Checked = False
                optLOCALTYPE2.Checked = False
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("HOUSE")) Then
                txtHOUSE.Text = ds.Tables(0).Rows(0).Item("HOUSE").ToString
                tmpHouse = txtHOUSE.Text
                hHOUSE = txtHOUSE.Text
            Else
                txtHOUSE.Text = ""
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("ROOMNO")) Then
                txtROOMNO.Text = ds.Tables(0).Rows(0).Item("ROOMNO").ToString
            Else
                txtROOMNO.Text = ""
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("CONDO")) Then
                txtCONDO.Text = ds.Tables(0).Rows(0).Item("CONDO").ToString
            Else
                txtCONDO.Text = ""
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("HOUSETYPE")) Then
                txtHOUSETYPE.Text = ds.Tables(0).Rows(0).Item("HOUSETYPE").ToString
                cboHOUSETYPE.EditValue = txtHOUSETYPE.Text
            Else
                txtHOUSETYPE.Text = Nothing
            End If


            If Not IsDBNull(ds.Tables(0).Rows(0).Item("SOISUB")) Then
                txtSOISUB.Text = ds.Tables(0).Rows(0).Item("SOISUB").ToString
            Else
                txtSOISUB.Text = ""
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("SOIMAIN")) Then
                txtSOIMAIN.Text = ds.Tables(0).Rows(0).Item("SOIMAIN").ToString
            Else
                txtSOIMAIN.Text = ""
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("ROAD")) Then
                txtROAD.Text = ds.Tables(0).Rows(0).Item("ROAD").ToString
            Else
                txtROAD.Text = ""
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("VILLANAME")) Then
                txtVILLANAME.Text = ds.Tables(0).Rows(0).Item("VILLANAME").ToString
                hVILLAGE_NAME = txtVILLANAME.Text
            Else
                txtVILLANAME.Text = ""
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("VILLAGE")) Then
                txtVILLAGE.Text = ds.Tables(0).Rows(0).Item("VILLAGE").ToString
                hVILLAGE = CInt(txtVILLAGE.Text).ToString("#0")
            Else
                txtVILLAGE.Text = Nothing
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("CHANGWAT")) Then
                txtCHANGWAT.Text = ds.Tables(0).Rows(0).Item("CHANGWAT").ToString
                cboCHANGWAT.EditValue = ds.Tables(0).Rows(0).Item("CHANGWAT").ToString
                hCHANGWAT = txtCHANGWAT.Text
            Else
                txtCHANGWAT.Text = Nothing
            End If
            ampurlist()

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("AMPUR")) Then
                txtAMPUR.Text = ds.Tables(0).Rows(0).Item("AMPUR").ToString
                cboAMPHUR.EditValue = ds.Tables(0).Rows(0).Item("AMPUR").ToString
                hAMPUR = txtAMPUR.Text
            Else
                txtAMPUR.Text = Nothing
            End If
            tambonlist()

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("TAMBON")) Then
                txtTAMBON.Text = ds.Tables(0).Rows(0).Item("TAMBON").ToString
                cboTAMBON.EditValue = ds.Tables(0).Rows(0).Item("TAMBON").ToString
                hTAMBON = txtTAMBON.Text
            Else
                txtTAMBON.Text = Nothing
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("TELEPHONE")) Then
                txtTELEPHONE.Text = ds.Tables(0).Rows(0).Item("TELEPHONE").ToString
            Else
                txtTELEPHONE.Text = Nothing
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("LATITUDE")) Then
                txtLATITUDE.Text = ds.Tables(0).Rows(0).Item("LATITUDE").ToString
            Else
                txtLATITUDE.Text = Nothing
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("LONGITUDE")) Then
                txtLONGITUDE.Text = ds.Tables(0).Rows(0).Item("LONGITUDE").ToString
            Else
                txtLONGITUDE.Text = Nothing
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("NFAMILY")) Then
                txtNFAMILY.Text = ds.Tables(0).Rows(0).Item("NFAMILY").ToString
            Else
                txtNFAMILY.Text = Nothing
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("VHVID")) Then
                lblVHVID.Text = clsdataBus.Lc_Business.SELECT_NAME_PERSON(ds.Tables(0).Rows(0).Item("VHVID").ToString)
            Else
                lblVHVID.Text = ""
            End If

            If hVILLAGE = "00" Then
                tmpAssress = hHOUSE & " " & hVILLAGE_NAME & " " & clsdataBus.Lc_Business.SELECT_NAME_ADDRESS(hCHANGWAT & hAMPUR & hTAMBON)
            Else
                tmpAssress = hHOUSE & " หมู่ " & hVILLAGE & " " & clsdataBus.Lc_Business.SELECT_NAME_ADDRESS(hCHANGWAT & hAMPUR & hTAMBON)
            End If


            If Not IsDBNull(ds.Tables(0).Rows(0).Item("TOILET")) Then
                hTOILET = ds.Tables(0).Rows(0).Item("TOILET").ToString
            Else
                hTOILET = ""
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("WATER")) Then
                hWATER = ds.Tables(0).Rows(0).Item("WATER").ToString
            Else
                hWATER = ""
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("WATERTYPE")) Then
                hWATERTYPE = ds.Tables(0).Rows(0).Item("WATERTYPE").ToString
            Else
                hWATERTYPE = ""
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("GARBAGE")) Then
                hGARBAGE = ds.Tables(0).Rows(0).Item("GARBAGE").ToString
            Else
                hGARBAGE = ""
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("HOUSING")) Then
                hHOUSING = ds.Tables(0).Rows(0).Item("HOUSING").ToString
            Else
                hHOUSING = ""
            End If
            If Not IsDBNull(ds.Tables(0).Rows(0).Item("DURABILITY")) Then
                hDURABILITY = ds.Tables(0).Rows(0).Item("DURABILITY").ToString
            Else
                hDURABILITY = ""
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("CLEANLINESS")) Then
                hCLEANLINESS = ds.Tables(0).Rows(0).Item("CLEANLINESS").ToString
            Else
                hCLEANLINESS = ""
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("VENTILATION")) Then
                hVENTILATION = ds.Tables(0).Rows(0).Item("VENTILATION").ToString
            Else
                hVENTILATION = ""
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("WATERTM")) Then
                hWATERTM = ds.Tables(0).Rows(0).Item("WATERTM").ToString
            Else
                hWATERTM = ""
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("MFOOD")) Then
                hMFOOD = ds.Tables(0).Rows(0).Item("MFOOD").ToString
            Else
                hMFOOD = ""
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("BCONTROL")) Then
                hBCONTROL = ds.Tables(0).Rows(0).Item("BCONTROL").ToString
            Else
                hBCONTROL = ""
            End If

            If Not IsDBNull(ds.Tables(0).Rows(0).Item("ACONTROL")) Then
                hACONTROL = ds.Tables(0).Rows(0).Item("ACONTROL").ToString
            Else
                hACONTROL = ""
            End If


            If Not IsDBNull(ds.Tables(0).Rows(0).Item("CHEMICAL")) Then
                hCHEMICAL = ds.Tables(0).Rows(0).Item("CHEMICAL").ToString
            Else
                hCHEMICAL = ""
            End If

            txtTOILET.Text = hTOILET
            txtWATER.Text = hWATER
            txtWATERTYPE.Text = hWATERTYPE
            txtGARBAGE.Text = hGARBAGE
            txtHOUSING.Text = hHOUSING
            txtDURABILITY.Text = hDURABILITY
            txtCLEANLINESS.Text = hCLEANLINESS
            txtVENTILATION.Text = hVENTILATION
            txtLIGHT.Text = hLIGHT
            txtWATERTM.Text = hWATERTM
            txtMFOOD.Text = hMFOOD
            txtBCONTROL.Text = hBCONTROL
            txtACONTROL.Text = hACONTROL
            txtCHEMICAL.Text = hCHEMICAL

            CheckDataSani()
            ShowHouseType()

            ShowPerson()

            ShowImageInhouse()
        End If


    End Sub
    Private Sub ShowHouseType()
        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_DATA("n_house_type", "WHERE HID = '" & vHomeHID & "'")
        If ds.Tables(0).Rows.Count > 0 Then
            txtHOME_TYPE.Text = ds.Tables(0).Rows(0).Item("HTYPE")
            cboHTYPE.EditValue = txtHOME_TYPE.Text
            tmpHTYPE_Update = True
        Else
            txtHOME_TYPE.Text = "0"
            cboHTYPE.EditValue = txtHOME_TYPE.Text
            tmpHTYPE_Update = False
        End If


    End Sub
    Private Sub ShowPerson()
        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_DATA("m_person", "WHERE HID = '" & vHomeHID & "' AND STATUS_AF <> '8' ORDER BY BIRTH DESC ")
        If ds2.Tables(0).Rows.Count > 0 Then
            DisplayData2(ds2)
            XtraTabPage2.Text = "คนในบ้าน [" & ds2.Tables(0).Rows.Count.ToString & "]"
        Else
            XtraTabPage2.Text = "คนในบ้าน [0]"
            BetterListView1.Items.Clear()
        End If
    End Sub
    Private Sub DisplayData2(ByVal ds As DataSet)
        Dim anyData() As String = Nothing
        Dim dr As DataRow
        Dim NAMEUSER As String = ""
        Dim tmpPrename As String = ""
        Dim tmpProvider As String = ""
        Dim tmpCID As String = ""
        Dim tmpPID As String = ""
        Dim tmpName As String = ""

        Try
            BetterListView1.Items.Clear()
            BetterListView1.BeginUpdate()
            BetterListView1.SuspendSort()

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                If Not IsDBNull(dr("USER_REC")) Then
                    NAMEUSER = clsdataBus.Lc_Business.SELECT_NAME_USERID(dr("USER_REC"))
                End If

                If dr("SEX") = "1" Then
                    BetterListView1.Items.Add(ImageList1.Images.Item(6)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                Else
                    BetterListView1.Items.Add(ImageList1.Images.Item(7)).AlignHorizontalImage = BetterListViewImageAlignmentHorizontal.OverlayCenter
                End If
                If dr("FSTATUS") = "1" Then
                    BetterListView1.Items(i).SubItems.Add("เจ้าบ้าน").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("ผู้อาศัย").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                End If
                If Not IsDBNull(dr("PID")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("PID").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                    tmpPID = dr("PID")
                Else
                    BetterListView1.Items(i).SubItems.Add("").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                    tmpPID = ""
                End If
                If Not IsDBNull(dr("HN")) Then
                    BetterListView1.Items(i).SubItems.Add(dr("HN").ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                End If
                If Not IsDBNull(dr("CID")) Then
                    Try
                        BetterListView1.Items(i).SubItems.Add((dr("CID")).ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                        tmpCID = (dr("CID"))
                    Catch ex As Exception
                        BetterListView1.Items(i).SubItems.Add("มีข้อผิดพลาด!!!")
                        tmpCID = "x"
                    End Try
                Else
                    BetterListView1.Items(i).SubItems.Add("").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                End If
                If Not IsDBNull(dr("PRENAME")) Then
                    tmpPrename = clsdataBus.Lc_Business.SELECT_NAME_PRENAME(dr("PRENAME"))
                End If
                Try
                    BetterListView1.Items(i).SubItems.Add(tmpPrename & (dr("NAME") & " " & dr("LNAME")).ToString).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Left
                    tmpName = tmpPrename & ((dr("NAME"))) & " " & ((dr("LNAME")))
                Catch ex As Exception
                    BetterListView1.Items(i).SubItems.Add("มีข้อผิดพลาด!!!").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                    tmpName = ""
                End Try
                If dr("SEX") = "1" Then
                    BetterListView1.Items(i).SubItems.Add("ชาย").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                Else
                    BetterListView1.Items(i).SubItems.Add("หญิง").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                End If
                If IsDBNull(dr("BIRTH")) Then
                    BetterListView1.Items(i).SubItems.Add("ไม่มีข้อมูล").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                    BetterListView1.Items(i).SubItems.Add("").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                Else
                    If dr("BIRTH") <> "" Then
                        Dim tmpDOB = dr("BIRTH").ToString.Substring(0, 4) + 543 & dr("BIRTH").ToString.Substring(4, 4)
                        If CheckDate(DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("dd/MM/yyyy")) = True Then

                            Dim DOB As DateTime = DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture)
                            Dim Years As Integer = 0
                            Dim Month As Integer = 0
                            Dim Days As Integer = 0
                            Dim StrAge As String = Nothing
                            ' Check if the DOB is less than current date
                            If DOB < DateTime.Now Then
                                ' Calculate Difference between current date and DOB
                                Dim dateDiff As TimeSpan = DateTime.Now - DOB
                                Dim age As New DateTime(dateDiff.Ticks)
                                Years = age.Year - 1
                                Month = age.Month - 1
                                Days = age.Day - 1
                                StrAge = ((Years.ToString() & " ปี ") + Month.ToString() & " เดือน ") + Days.ToString() & " วัน "
                            Else
                                StrAge = "วันเดือนปีเกิดไม่ถูกต้อง"
                            End If
                            BetterListView1.Items(i).SubItems.Add(DateTime.ParseExact(tmpDOB, "yyyyMMdd", CultureInfo.CurrentCulture).ToString("d MMM yyyy")).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                            BetterListView1.Items(i).SubItems.Add(StrAge).AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                        Else
                            BetterListView1.Items(i).SubItems.Add("").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                            BetterListView1.Items(i).SubItems.Add("").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                        End If
                    Else
                        BetterListView1.Items(i).SubItems.Add("ไม่มีข้อมูล").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                        BetterListView1.Items(i).SubItems.Add("").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                    End If

                End If
                If Not IsDBNull(dr("MSTATUS")) Then
                    Select Case dr("MSTATUS")
                        Case "1"
                            BetterListView1.Items(i).SubItems.Add("โสด").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                        Case "2"
                            BetterListView1.Items(i).SubItems.Add("คู่").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                        Case "3"
                            BetterListView1.Items(i).SubItems.Add("ม่าย").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                        Case "4"
                            BetterListView1.Items(i).SubItems.Add("หย่า").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                        Case "5"
                            BetterListView1.Items(i).SubItems.Add("แยก").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                        Case "6"
                            BetterListView1.Items(i).SubItems.Add("สมณะ").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                        Case "9"
                            BetterListView1.Items(i).SubItems.Add("ไม่ทราบ").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                        Case ""
                            BetterListView1.Items(i).SubItems.Add("ไม่บันทึก").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                    End Select
                Else
                    BetterListView1.Items(i).SubItems.Add("").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                End If

                If Not IsDBNull(dr("DISCHARGE")) Then
                    Select Case dr("DISCHARGE")
                        Case "1"
                            BetterListView1.Items(i).SubItems.Add("ตาย").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                        Case "2"
                            BetterListView1.Items(i).SubItems.Add("ย้าย").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                        Case "3"
                            BetterListView1.Items(i).SubItems.Add("สาบสูญ").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                        Case "9"
                            BetterListView1.Items(i).SubItems.Add("ไม่จำหน่าย").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                        Case ""
                            BetterListView1.Items(i).SubItems.Add("ไม่บันทึก").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                    End Select
                Else
                    BetterListView1.Items(i).SubItems.Add("").AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Center
                End If

                If (i Mod 2) = 0 Then
                    BetterListView1.Items(i).BackColor = Color.WhiteSmoke
                End If

                If dr("DISCHARGE").ToString <> "9" Then
                    BetterListView1.Items(i).BackColor = Color.LightPink
                End If

                If dr("STATUS_AF").ToString = "0" Then
                    BetterListView1.Items(i).BackColor = Color.Orange
                End If


            Next
            BetterListView1.AutoResizeColumn(5, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(7, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)
            BetterListView1.AutoResizeColumn(8, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent)

            BetterListView1.ResumeSort(True)
            BetterListView1.EndUpdate()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Error002", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub optLOCALTYPE1_Click(sender As Object, e As EventArgs) Handles optLOCALTYPE1.Click
        optLOCALTYPE1.Checked = True
        optLOCALTYPE2.Checked = False
        txtLOCATYPE.Text = "1"
    End Sub

    Private Sub optLOCALTYPE2_Click(sender As Object, e As EventArgs) Handles optLOCALTYPE2.Click
        optLOCALTYPE1.Checked = False
        optLOCALTYPE2.Checked = True
        txtLOCATYPE.Text = "2"
    End Sub

    Private Sub cmdMap_Click(sender As Object, e As EventArgs) Handles cmdMap.Click
        hLatitude = ""
        hLongitude = ""
        hHouseName = ""

        If txtLATITUDE.Text.Replace("_", "").Replace(".", "") <> "" And txtLONGITUDE.Text.Replace("_", "").Replace(".", "") <> "" Then
            hLatitude = txtLATITUDE.Text
            hLongitude = txtLONGITUDE.Text
            hHouseName = tmpAssress
        End If

        Dim fmaps As New frmGoogleMaps
        fmaps.ShowDialog()

        If vLatitude.ToString <> "" Then
            txtLATITUDE.Text = vLatitude.ToString
            txtLONGITUDE.Text = vLongitude.ToString
        Else
            txtLATITUDE.Text = hLatitude.ToString
            txtLONGITUDE.Text = hLongitude.ToString
        End If

        vLatitude = ""
        vLongitude = ""
        CheckData()
    End Sub
    Private Sub CheckData()
        ChkData = True
        If txtLOCATYPE.Text = Nothing Then
            txtLOCATYPE.BackColor = Color.LightPink
            ChkData = False
        Else
            If txtLOCATYPE.Text <> "1" And txtLOCATYPE.Text <> "2" Then
                txtLOCATYPE.BackColor = Color.LightPink
                ChkData = False
            Else
                txtLOCATYPE.BackColor = Color.Beige
                If txtLOCATYPE.Text = "1" Then
                    optLOCALTYPE1.Checked = True
                Else
                    optLOCALTYPE2.Checked = True
                End If
            End If
        End If
        If txtHOUSETYPE.Text = Nothing Then
            txtHOUSETYPE.BackColor = Color.LightPink
            ChkData = False
        Else
            If txtHOUSETYPE.Text = "0" Or txtHOUSETYPE.Text = "7" Then
                txtHOUSETYPE.BackColor = Color.LightPink
                ChkData = False
            Else
                txtHOUSETYPE.BackColor = Color.Beige
            End If
        End If

        If txtHOUSE.Text = "" Then
            txtHOUSE.BackColor = Color.LightPink
            ChkData = False
        Else
            txtHOUSE.BackColor = Color.Beige
        End If

        If txtVILLAGE.Text = Nothing Then
            txtVILLAGE.BackColor = Color.LightPink
            ChkData = False
        Else
            txtVILLAGE.BackColor = Color.Beige
            txtVILLAGE.Text = CInt(txtVILLAGE.Text).ToString("00")
        End If

        If txtTAMBON.Text = Nothing Then
            txtTAMBON.BackColor = Color.LightPink
            ChkData = False
        Else
            txtTAMBON.BackColor = Color.Beige
        End If
        If txtAMPUR.Text = Nothing Then
            txtAMPUR.BackColor = Color.LightPink
            ChkData = False
        Else
            txtAMPUR.BackColor = Color.Beige
        End If
        If txtCHANGWAT.Text = Nothing Then
            txtCHANGWAT.BackColor = Color.LightPink
            ChkData = False
        Else
            If CheckCHANGWAT(txtCHANGWAT.Text) = False Then
                txtCHANGWAT.BackColor = Color.LightPink
                ChkData = False
            Else
                txtCHANGWAT.BackColor = Color.Beige
                cboCHANGWAT.EditValue = txtCHANGWAT.Text
            End If
        End If
        If txtAMPUR.Text = Nothing Then
            txtAMPUR.BackColor = Color.LightPink
            ChkData = False
        Else
            If CheckAMPUR(txtCHANGWAT.Text, txtAMPUR.Text) = False Then
                txtAMPUR.BackColor = Color.LightPink
                ChkData = False
            Else
                txtAMPUR.BackColor = Color.Beige
                cboAMPHUR.EditValue = txtAMPUR.Text
            End If
        End If
        If txtTAMBON.Text = Nothing Then
            txtTAMBON.BackColor = Color.LightPink
            ChkData = False
        Else
            If CheckTAMBON(txtCHANGWAT.Text, txtAMPUR.Text, txtTAMBON.Text) = False Then
                txtAMPUR.BackColor = Color.LightPink
                ChkData = False
            Else
                txtAMPUR.BackColor = Color.Beige
                cboTAMBON.EditValue = txtTAMBON.Text
            End If
        End If

        If Trim(txtLATITUDE.Text.Replace(".", "")) = "" Then
            txtLATITUDE.BackColor = Color.Orange
            ChkData = False
        Else
            txtLATITUDE.BackColor = Color.Beige
            txtLATITUDE.Text = CDbl(txtLATITUDE.Text).ToString("000.000000")
        End If
        If Trim(txtLONGITUDE.Text.Replace(".", "")) = "" Then
            txtLONGITUDE.BackColor = Color.Orange
            ChkData = False
        Else
            txtLONGITUDE.BackColor = Color.Beige
            txtLONGITUDE.Text = CDbl(txtLONGITUDE.Text).ToString("000.000000")
        End If

        If txtNFAMILY.Text = Nothing Then
            txtNFAMILY.BackColor = Color.LightPink
            ChkData = False
        Else
            txtNFAMILY.BackColor = SystemColors.Window
            txtNFAMILY.Text = CInt(txtNFAMILY.Text).ToString("00")
        End If


    End Sub
    Private Sub CheckDataSani()

        optTOILET0.ForeColor = Color.FromArgb(64, 64, 64)
        optTOILET1.ForeColor = Color.FromArgb(64, 64, 64)
        optTOILET9.ForeColor = Color.FromArgb(64, 64, 64)

        optWATER0.ForeColor = Color.FromArgb(64, 64, 64)
        optWATER1.ForeColor = Color.FromArgb(64, 64, 64)
        optWATER9.ForeColor = Color.FromArgb(64, 64, 64)

        optWATERTYPE1.ForeColor = Color.FromArgb(64, 64, 64)
        optWATERTYPE2.ForeColor = Color.FromArgb(64, 64, 64)
        optWATERTYPE3.ForeColor = Color.FromArgb(64, 64, 64)
        optWATERTYPE4.ForeColor = Color.FromArgb(64, 64, 64)
        optWATERTYPE5.ForeColor = Color.FromArgb(64, 64, 64)
        optWATERTYPE6.ForeColor = Color.FromArgb(64, 64, 64)
        optWATERTYPE9.ForeColor = Color.FromArgb(64, 64, 64)

        optGARBAGE1.ForeColor = Color.FromArgb(64, 64, 64)
        optGARBAGE2.ForeColor = Color.FromArgb(64, 64, 64)
        optGARBAGE3.ForeColor = Color.FromArgb(64, 64, 64)
        optGARBAGE4.ForeColor = Color.FromArgb(64, 64, 64)
        optGARBAGE9.ForeColor = Color.FromArgb(64, 64, 64)
        optGARBAGE9.ForeColor = Color.FromArgb(64, 64, 64)

        optHOUSING0.ForeColor = Color.FromArgb(64, 64, 64)
        optHOUSING1.ForeColor = Color.FromArgb(64, 64, 64)
        optHOUSING9.ForeColor = Color.FromArgb(64, 64, 64)

        optDURABILITY1.ForeColor = Color.FromArgb(64, 64, 64)
        optDURABILITY2.ForeColor = Color.FromArgb(64, 64, 64)
        optDURABILITY3.ForeColor = Color.FromArgb(64, 64, 64)
        optDURABILITY0.ForeColor = Color.FromArgb(64, 64, 64)
        optDURABILITY9.ForeColor = Color.FromArgb(64, 64, 64)

        optCLEANLINESS0.ForeColor = Color.FromArgb(64, 64, 64)
        optCLEANLINESS1.ForeColor = Color.FromArgb(64, 64, 64)
        optCLEANLINESS9.ForeColor = Color.FromArgb(64, 64, 64)

        optVENTILATION0.ForeColor = Color.FromArgb(64, 64, 64)
        optVENTILATION1.ForeColor = Color.FromArgb(64, 64, 64)
        optVENTILATION9.ForeColor = Color.FromArgb(64, 64, 64)

        optLIGHT0.ForeColor = Color.FromArgb(64, 64, 64)
        optLIGHT1.ForeColor = Color.FromArgb(64, 64, 64)
        optLIGHT9.ForeColor = Color.FromArgb(64, 64, 64)

        optWATERTM0.ForeColor = Color.FromArgb(64, 64, 64)
        optWATERTM1.ForeColor = Color.FromArgb(64, 64, 64)
        optWATERTM9.ForeColor = Color.FromArgb(64, 64, 64)

        optMFOOD0.ForeColor = Color.FromArgb(64, 64, 64)
        optMFOOD1.ForeColor = Color.FromArgb(64, 64, 64)
        optMFOOD9.ForeColor = Color.FromArgb(64, 64, 64)


        optBCONTROL0.ForeColor = Color.FromArgb(64, 64, 64)
        optBCONTROL1.ForeColor = Color.FromArgb(64, 64, 64)
        optBCONTROL9.ForeColor = Color.FromArgb(64, 64, 64)

        optACONTROL0.ForeColor = Color.FromArgb(64, 64, 64)
        optACONTROL1.ForeColor = Color.FromArgb(64, 64, 64)
        optACONTROL9.ForeColor = Color.FromArgb(64, 64, 64)


        optCHEMICAL0.ForeColor = Color.FromArgb(64, 64, 64)
        optCHEMICAL1.ForeColor = Color.FromArgb(64, 64, 64)
        optCHEMICAL9.ForeColor = Color.FromArgb(64, 64, 64)


        If txtTOILET.Text = "0" Then
            optTOILET0.Checked = True
            optTOILET0.ForeColor = Color.Blue
        ElseIf txtTOILET.Text = "1" Then
            optTOILET1.Checked = True
            optTOILET1.ForeColor = Color.Blue
        ElseIf txtTOILET.Text = "9" Then
            optTOILET9.Checked = True
            optTOILET9.ForeColor = Color.Blue
        End If

        If txtWATER.Text = "0" Then
            optWATER0.Checked = True
            optWATER0.ForeColor = Color.Blue
        ElseIf txtWATER.Text = "1" Then
            optWATER1.Checked = True
            optWATER1.ForeColor = Color.Blue
        ElseIf txtWATER.Text = "9" Then
            optWATER9.Checked = True
            optWATER9.ForeColor = Color.Blue
        End If

        If txtWATERTYPE.Text = "1" Then
            optWATERTYPE1.Checked = True
            optWATERTYPE1.ForeColor = Color.Blue
        ElseIf txtWATERTYPE.Text = "2" Then
            optWATERTYPE2.Checked = True
            optWATERTYPE2.ForeColor = Color.Blue
        ElseIf txtWATERTYPE.Text = "3" Then
            optWATERTYPE3.Checked = True
            optWATERTYPE3.ForeColor = Color.Blue
        ElseIf txtWATERTYPE.Text = "4" Then
            optWATERTYPE4.Checked = True
            optWATERTYPE4.ForeColor = Color.Blue
        ElseIf txtWATERTYPE.Text = "5" Then
            optWATERTYPE5.Checked = True
            optWATERTYPE5.ForeColor = Color.Blue
        ElseIf txtWATERTYPE.Text = "6" Then
            optWATERTYPE6.Checked = True
            optWATERTYPE6.ForeColor = Color.Blue
        ElseIf txtWATERTYPE.Text = "9" Then
            optWATERTYPE9.Checked = True
            optWATERTYPE9.ForeColor = Color.Blue
        End If

        If txtGARBAGE.Text = "1" Then
            optGARBAGE1.Checked = True
            optGARBAGE1.ForeColor = Color.Blue
        ElseIf txtGARBAGE.Text = "2" Then
            optGARBAGE2.Checked = True
            optGARBAGE2.ForeColor = Color.Blue
        ElseIf txtGARBAGE.Text = "3" Then
            optGARBAGE3.Checked = True
            optGARBAGE3.ForeColor = Color.Blue
        ElseIf txtGARBAGE.Text = "4" Then
            optGARBAGE4.Checked = True
            optGARBAGE4.ForeColor = Color.Blue
        ElseIf txtGARBAGE.Text = "9" Then
            optGARBAGE9.Checked = True
            optGARBAGE9.ForeColor = Color.Blue
        End If

        If txtHOUSING.Text = "0" Then
            optHOUSING0.Checked = True
            optHOUSING0.ForeColor = Color.Blue
        ElseIf txtHOUSING.Text = "1" Then
            optHOUSING1.Checked = True
            optHOUSING1.ForeColor = Color.Blue
        ElseIf txtHOUSING.Text = "9" Then
            optHOUSING9.Checked = True
            optHOUSING9.ForeColor = Color.Blue
        End If

        If txtDURABILITY.Text = "1" Then
            optDURABILITY1.Checked = True
            optDURABILITY1.ForeColor = Color.Blue
        ElseIf txtDURABILITY.Text = "2" Then
            optDURABILITY2.Checked = True
            optDURABILITY2.ForeColor = Color.Blue
        ElseIf txtDURABILITY.Text = "3" Then
            optDURABILITY3.Checked = True
            optDURABILITY3.ForeColor = Color.Blue
        ElseIf txtDURABILITY.Text = "0" Then
            optDURABILITY0.Checked = True
            optDURABILITY0.ForeColor = Color.Blue
        ElseIf txtDURABILITY.Text = "9" Then
            optDURABILITY9.Checked = True
            optDURABILITY9.ForeColor = Color.Blue
        End If

        If txtCLEANLINESS.Text = "0" Then
            optCLEANLINESS0.Checked = True
            optCLEANLINESS0.ForeColor = Color.Blue
        ElseIf txtCLEANLINESS.Text = "1" Then
            optCLEANLINESS1.Checked = True
            optCLEANLINESS1.ForeColor = Color.Blue
        ElseIf txtCLEANLINESS.Text = "9" Then
            optCLEANLINESS9.Checked = True
            optCLEANLINESS9.ForeColor = Color.Blue
        End If

        If txtVENTILATION.Text = "0" Then
            optVENTILATION0.Checked = False
            optVENTILATION0.ForeColor = Color.Blue
        ElseIf txtVENTILATION.Text = "1" Then
            optVENTILATION1.Checked = True
            optVENTILATION1.ForeColor = Color.Blue
        ElseIf txtVENTILATION.Text = "9" Then
            optVENTILATION9.Checked = True
            optVENTILATION9.ForeColor = Color.Blue
        End If

        If txtLIGHT.Text = "0" Then
            optLIGHT0.Checked = True
            optLIGHT0.ForeColor = Color.Blue
        ElseIf txtLIGHT.Text = "1" Then
            optLIGHT1.Checked = True
            optLIGHT1.ForeColor = Color.Blue
        ElseIf txtLIGHT.Text = "9" Then
            optLIGHT9.Checked = True
            optLIGHT9.ForeColor = Color.Blue
        End If


        If txtWATERTM.Text = "0" Then
            optWATERTM0.Checked = True
            optWATERTM0.ForeColor = Color.Blue
        ElseIf txtWATERTM.Text = "1" Then
            optWATERTM1.Checked = True
            optWATERTM1.ForeColor = Color.Blue
        ElseIf txtWATERTM.Text = "9" Then
            optWATERTM9.Checked = True
            optWATERTM9.ForeColor = Color.Blue
        End If

        If txtMFOOD.Text = "0" Then
            optMFOOD0.Checked = True
            optMFOOD0.ForeColor = Color.Blue
        ElseIf txtMFOOD.Text = "1" Then
            optMFOOD1.Checked = True
            optMFOOD1.ForeColor = Color.Blue
        ElseIf txtMFOOD.Text = "9" Then
            optMFOOD9.Checked = True
            optMFOOD9.ForeColor = Color.Blue
        End If

        If txtBCONTROL.Text = "0" Then
            optBCONTROL0.Checked = True
            optBCONTROL0.ForeColor = Color.Blue
        ElseIf txtBCONTROL.Text = "1" Then
            optBCONTROL1.Checked = True
            optBCONTROL1.ForeColor = Color.Blue
        ElseIf txtBCONTROL.Text = "9" Then
            optBCONTROL9.Checked = True
            optBCONTROL9.ForeColor = Color.Blue
        End If

        If txtACONTROL.Text = "0" Then
            optACONTROL0.Checked = True
            optACONTROL0.ForeColor = Color.Blue
        ElseIf txtACONTROL.Text = "1" Then
            optACONTROL1.Checked = True
            optACONTROL1.ForeColor = Color.Blue
        ElseIf txtACONTROL.Text = "9" Then
            optACONTROL9.Checked = True
            optACONTROL9.ForeColor = Color.Blue
        End If

        If txtCHEMICAL.Text = "0" Then
            optCHEMICAL0.Checked = True
            optCHEMICAL0.ForeColor = Color.Blue
        ElseIf txtCHEMICAL.Text = "1" Then
            optCHEMICAL1.Checked = True
            optCHEMICAL1.ForeColor = Color.Blue
        ElseIf txtCHEMICAL.Text = "9" Then
            optCHEMICAL9.Checked = True
            optCHEMICAL9.ForeColor = Color.Blue
        End If

        Dim i As Integer = 0
        If txtTOILET.Text = Nothing Then
            txtTOILET.BackColor = Color.LightPink
            ChkSanitation = False
        Else
            If txtTOILET.Text <> "0" And txtTOILET.Text <> "1" And txtTOILET.Text <> "9" Then
                txtTOILET.BackColor = Color.LightPink
                ChkSanitation = False
            Else
                txtTOILET.BackColor = Color.Beige
            End If
        End If

        If txtWATER.Text = Nothing Then
            txtWATER.BackColor = Color.LightPink
            ChkSanitation = False
        Else
            If txtWATER.Text <> "0" And txtWATER.Text <> "1" And txtWATER.Text <> "9" Then
                txtWATER.BackColor = Color.LightPink
                ChkSanitation = False
            Else
                txtWATER.BackColor = Color.Beige

            End If
        End If

        If txtWATERTYPE.Text = Nothing Then
            txtWATERTYPE.BackColor = Color.LightPink
            ChkSanitation = False
        Else
            If txtWATERTYPE.Text = "0" And txtWATERTYPE.Text = "7" And txtWATERTYPE.Text = "8" Then
                txtWATERTYPE.BackColor = Color.LightPink
                ChkSanitation = False
            Else
                txtWATERTYPE.BackColor = Color.Beige

            End If
        End If

        If txtGARBAGE.Text = Nothing Then
            txtGARBAGE.BackColor = Color.LightPink
            ChkSanitation = False
        Else
            If txtGARBAGE.Text <> "1" And txtGARBAGE.Text <> "2" And txtGARBAGE.Text <> "3" And txtGARBAGE.Text <> "4" And txtGARBAGE.Text <> "9" Then
                txtGARBAGE.BackColor = Color.LightPink
                ChkSanitation = False
            Else
                txtGARBAGE.BackColor = Color.Beige

            End If
        End If

        If txtHOUSING.Text = Nothing Then
            txtHOUSING.BackColor = Color.LightPink
            ChkSanitation = False
        Else
            If txtHOUSING.Text <> "0" And txtHOUSING.Text <> "1" And txtHOUSING.Text <> "9" Then
                txtHOUSING.BackColor = Color.LightPink
                ChkSanitation = False
            Else
                txtHOUSING.BackColor = Color.Beige

            End If
        End If

        If txtDURABILITY.Text = Nothing Then
            txtDURABILITY.BackColor = Color.LightPink
            ChkSanitation = False
        Else
            If txtDURABILITY.Text <> "1" And txtDURABILITY.Text <> "2" And txtDURABILITY.Text <> "3" And txtDURABILITY.Text <> "9" And txtDURABILITY.Text <> "0" Then
                txtDURABILITY.BackColor = Color.LightPink
                ChkSanitation = False
            Else
                txtDURABILITY.BackColor = Color.Beige

            End If
        End If

        If txtCLEANLINESS.Text = Nothing Then
            txtCLEANLINESS.BackColor = Color.LightPink
            ChkSanitation = False
        Else
            If txtCLEANLINESS.Text <> "0" And txtCLEANLINESS.Text <> "1" And txtCLEANLINESS.Text <> "9" Then
                txtCLEANLINESS.BackColor = Color.LightPink
                ChkSanitation = False
            Else
                txtCLEANLINESS.BackColor = Color.Beige

            End If
        End If

        If txtVENTILATION.Text = Nothing Then
            txtVENTILATION.BackColor = Color.LightPink
            ChkSanitation = False
        Else
            If txtVENTILATION.Text <> "0" And txtVENTILATION.Text <> "1" And txtVENTILATION.Text <> "9" Then
                txtVENTILATION.BackColor = Color.LightPink
                ChkSanitation = False
            Else
                txtVENTILATION.BackColor = Color.Beige

            End If
        End If

        If txtLIGHT.Text = Nothing Then
            txtLIGHT.BackColor = Color.LightPink
            ChkSanitation = False
        Else
            If txtLIGHT.Text <> "0" And txtLIGHT.Text <> "1" And txtLIGHT.Text <> "9" Then
                txtLIGHT.BackColor = Color.LightPink
                ChkSanitation = False
            Else
                txtLIGHT.BackColor = Color.Beige

            End If
        End If

        If txtWATERTM.Text = Nothing Then
            txtWATERTM.BackColor = Color.LightPink
            ChkSanitation = False
        Else
            If txtWATERTM.Text <> "0" And txtWATERTM.Text <> "1" And txtWATERTM.Text <> "9" Then
                txtWATERTM.BackColor = Color.LightPink
                ChkSanitation = False
            Else
                txtWATERTM.BackColor = Color.Beige

            End If
        End If

        If txtMFOOD.Text = Nothing Then
            txtMFOOD.BackColor = Color.LightPink
            ChkSanitation = False
        Else
            If txtMFOOD.Text <> "0" And txtMFOOD.Text <> "1" And txtMFOOD.Text <> "9" Then
                txtMFOOD.BackColor = Color.LightPink
                ChkSanitation = False
            Else
                txtMFOOD.BackColor = Color.Beige

            End If
        End If

        If txtBCONTROL.Text = Nothing Then
            txtBCONTROL.BackColor = Color.LightPink
            ChkSanitation = False
        Else
            If txtBCONTROL.Text <> "0" And txtBCONTROL.Text <> "1" And txtBCONTROL.Text <> "9" Then
                txtBCONTROL.BackColor = Color.LightPink
                ChkSanitation = False
            Else
                txtBCONTROL.BackColor = Color.Beige

            End If
        End If


        If txtACONTROL.Text = Nothing Then
            txtACONTROL.BackColor = Color.LightPink
            ChkSanitation = False
        Else
            If txtACONTROL.Text <> "0" And txtACONTROL.Text <> "1" And txtACONTROL.Text <> "9" Then
                txtACONTROL.BackColor = Color.LightPink
                ChkSanitation = False
            Else
                txtACONTROL.BackColor = Color.Beige

            End If
        End If

        If txtCHEMICAL.Text = Nothing Then
            txtCHEMICAL.BackColor = Color.LightPink
            ChkSanitation = False
        Else
            If txtCHEMICAL.Text <> "0" And txtCHEMICAL.Text <> "1" And txtCHEMICAL.Text <> "9" Then
                txtCHEMICAL.BackColor = Color.LightPink
                ChkSanitation = False
            Else
                txtCHEMICAL.BackColor = Color.Beige

            End If
        End If


    End Sub
    Private Sub optTOILET0_Click(sender As Object, e As EventArgs) Handles optTOILET0.Click
        optTOILET0.Checked = True
        optTOILET1.Checked = False
        optTOILET9.Checked = False
        txtTOILET.Text = "0"
        CheckDataSani()
    End Sub
    Private Sub optTOILET1_Click(sender As Object, e As EventArgs) Handles optTOILET1.Click
        optTOILET0.Checked = False
        optTOILET1.Checked = True
        optTOILET9.Checked = False
        txtTOILET.Text = "1"
        CheckDataSani()
    End Sub
    Private Sub optTOILET9_Click(sender As Object, e As EventArgs) Handles optTOILET9.Click
        optTOILET0.Checked = False
        optTOILET1.Checked = False
        optTOILET9.Checked = True
        txtTOILET.Text = "9"
        CheckDataSani()
    End Sub

    Private Sub txtTOILET_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTOILET.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckDataSani()
        End If
    End Sub
    Private Sub optWATER0_Click(sender As Object, e As EventArgs) Handles optWATER0.Click
        optWATER0.Checked = True
        optWATER1.Checked = False
        optWATER9.Checked = False
        txtWATER.Text = "0"
        CheckDataSani()
    End Sub
    Private Sub optWATER1_Click(sender As Object, e As EventArgs) Handles optWATER1.Click
        optWATER0.Checked = False
        optWATER1.Checked = True
        optWATER9.Checked = False
        txtWATER.Text = "1"
        CheckDataSani()
    End Sub
    Private Sub optWATER9_Click(sender As Object, e As EventArgs) Handles optWATER9.Click
        optWATER0.Checked = False
        optWATER1.Checked = False
        optWATER9.Checked = True
        txtWATER.Text = "9"
        CheckDataSani()
    End Sub

    Private Sub txtWATER_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWATER.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckDataSani()
        End If
    End Sub
    Private Sub optWATERTYPE1_Click(sender As Object, e As EventArgs) Handles optWATERTYPE1.Click
        optWATERTYPE1.Checked = True
        optWATERTYPE2.Checked = False
        optWATERTYPE3.Checked = False
        optWATERTYPE4.Checked = False
        optWATERTYPE5.Checked = False
        optWATERTYPE6.Checked = False
        optWATERTYPE9.Checked = False
        txtWATERTYPE.Text = "1"
        CheckDataSani()
    End Sub
    Private Sub optWATERTYPE2_Click(sender As Object, e As EventArgs) Handles optWATERTYPE2.Click
        optWATERTYPE1.Checked = False
        optWATERTYPE2.Checked = True
        optWATERTYPE3.Checked = False
        optWATERTYPE4.Checked = False
        optWATERTYPE5.Checked = False
        optWATERTYPE6.Checked = False
        optWATERTYPE9.Checked = False
        txtWATERTYPE.Text = "2"
        CheckDataSani()
    End Sub
    Private Sub optWATERTYPE3_Click(sender As Object, e As EventArgs) Handles optWATERTYPE3.Click
        optWATERTYPE1.Checked = False
        optWATERTYPE2.Checked = False
        optWATERTYPE3.Checked = True
        optWATERTYPE4.Checked = False
        optWATERTYPE5.Checked = False
        optWATERTYPE6.Checked = False
        optWATERTYPE9.Checked = False
        txtWATERTYPE.Text = "3"
        CheckDataSani()
    End Sub
    Private Sub optWATERTYPE4_Click(sender As Object, e As EventArgs) Handles optWATERTYPE4.Click
        optWATERTYPE1.Checked = False
        optWATERTYPE2.Checked = False
        optWATERTYPE3.Checked = False
        optWATERTYPE4.Checked = True
        optWATERTYPE5.Checked = False
        optWATERTYPE6.Checked = False
        optWATERTYPE9.Checked = False
        txtWATERTYPE.Text = "4"
        CheckDataSani()
    End Sub
    Private Sub optWATERTYPE5_Click(sender As Object, e As EventArgs) Handles optWATERTYPE5.Click
        optWATERTYPE1.Checked = False
        optWATERTYPE2.Checked = False
        optWATERTYPE3.Checked = False
        optWATERTYPE4.Checked = False
        optWATERTYPE5.Checked = True
        optWATERTYPE6.Checked = False
        optWATERTYPE9.Checked = False
        txtWATERTYPE.Text = "5"
        CheckDataSani()
    End Sub
    Private Sub optWATERTYPE6_Click(sender As Object, e As EventArgs) Handles optWATERTYPE6.Click
        optWATERTYPE1.Checked = False
        optWATERTYPE2.Checked = False
        optWATERTYPE3.Checked = False
        optWATERTYPE4.Checked = False
        optWATERTYPE5.Checked = False
        optWATERTYPE6.Checked = True
        optWATERTYPE9.Checked = False
        txtWATERTYPE.Text = "6"
        CheckDataSani()
    End Sub
    Private Sub optWATERTYPE9_Click(sender As Object, e As EventArgs) Handles optWATERTYPE9.Click
        optWATERTYPE1.Checked = False
        optWATERTYPE2.Checked = False
        optWATERTYPE3.Checked = False
        optWATERTYPE4.Checked = False
        optWATERTYPE5.Checked = False
        optWATERTYPE6.Checked = False
        optWATERTYPE9.Checked = False
        optWATERTYPE9.Checked = True
        txtWATERTYPE.Text = "9"
        CheckDataSani()
    End Sub

    Private Sub txtWATERTYPE_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWATERTYPE.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckDataSani()
        End If
    End Sub
    Private Sub optGARBAGE1_Click(sender As Object, e As EventArgs) Handles optGARBAGE1.Click
        optGARBAGE1.Checked = True
        optGARBAGE2.Checked = False
        optGARBAGE3.Checked = False
        optGARBAGE4.Checked = False
        optGARBAGE9.Checked = False
        txtGARBAGE.Text = "1"
        CheckDataSani()
    End Sub
    Private Sub optGARBAGE2_Click(sender As Object, e As EventArgs) Handles optGARBAGE2.Click
        optGARBAGE1.Checked = False
        optGARBAGE2.Checked = True
        optGARBAGE3.Checked = False
        optGARBAGE4.Checked = False
        optGARBAGE9.Checked = False
        txtGARBAGE.Text = "2"
        CheckDataSani()
    End Sub
    Private Sub optGARBAGE3_Click(sender As Object, e As EventArgs) Handles optGARBAGE3.Click
        optGARBAGE1.Checked = False
        optGARBAGE2.Checked = False
        optGARBAGE3.Checked = True
        optGARBAGE4.Checked = False
        optGARBAGE9.Checked = False
        txtGARBAGE.Text = "3"
        CheckDataSani()
    End Sub
    Private Sub optGARBAGE4_Click(sender As Object, e As EventArgs) Handles optGARBAGE4.Click
        optGARBAGE1.Checked = False
        optGARBAGE2.Checked = False
        optGARBAGE3.Checked = False
        optGARBAGE4.Checked = True
        optGARBAGE9.Checked = False
        txtGARBAGE.Text = "4"
        CheckDataSani()
    End Sub
    Private Sub optGARBAGE9_Click(sender As Object, e As EventArgs) Handles optGARBAGE9.Click
        optGARBAGE1.Checked = False
        optGARBAGE2.Checked = False
        optGARBAGE3.Checked = False
        optGARBAGE4.Checked = False
        optGARBAGE9.Checked = False
        optGARBAGE9.Checked = True
        txtGARBAGE.Text = "9"
        CheckDataSani()
    End Sub

    Private Sub txtGARBAGE_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGARBAGE.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckDataSani()
        End If
    End Sub
    Private Sub optHOUSING0_Click(sender As Object, e As EventArgs) Handles optHOUSING0.Click
        optHOUSING0.Checked = True
        optHOUSING1.Checked = False
        optHOUSING9.Checked = False
        txtHOUSING.Text = "0"
        CheckDataSani()
    End Sub
    Private Sub optHOUSING1_Click(sender As Object, e As EventArgs) Handles optHOUSING1.Click
        optHOUSING0.Checked = False
        optHOUSING1.Checked = True
        optHOUSING9.Checked = False
        txtHOUSING.Text = "1"
        CheckDataSani()
    End Sub
    Private Sub optHOUSING9_Click(sender As Object, e As EventArgs) Handles optHOUSING9.Click
        optHOUSING0.Checked = False
        optHOUSING1.Checked = False
        optHOUSING9.Checked = True
        txtHOUSING.Text = "9"
        CheckDataSani()
    End Sub

    Private Sub txtHOUSING_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHOUSING.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckDataSani()
        End If
    End Sub
    Private Sub optDURABILITY1_Click(sender As Object, e As EventArgs) Handles optDURABILITY1.Click
        optDURABILITY1.Checked = True
        optDURABILITY2.Checked = False
        optDURABILITY3.Checked = False
        optDURABILITY0.Checked = False
        optDURABILITY9.Checked = False
        txtDURABILITY.Text = "1"
        CheckDataSani()
    End Sub
    Private Sub optDURABILITY2_Click(sender As Object, e As EventArgs) Handles optDURABILITY2.Click
        optDURABILITY1.Checked = False
        optDURABILITY2.Checked = True
        optDURABILITY3.Checked = False
        optDURABILITY0.Checked = False
        optDURABILITY9.Checked = False
        txtDURABILITY.Text = "2"
        CheckDataSani()
    End Sub
    Private Sub optDURABILITY3_Click(sender As Object, e As EventArgs) Handles optDURABILITY3.Click
        optDURABILITY1.Checked = False
        optDURABILITY2.Checked = False
        optDURABILITY3.Checked = True
        optDURABILITY0.Checked = False
        optDURABILITY9.Checked = False
        txtDURABILITY.Text = "3"
        CheckDataSani()
    End Sub
    Private Sub optDURABILITY0_Click(sender As Object, e As EventArgs) Handles optDURABILITY0.Click
        optDURABILITY1.Checked = False
        optDURABILITY2.Checked = False
        optDURABILITY3.Checked = False
        optDURABILITY0.Checked = True
        optDURABILITY9.Checked = False
        txtDURABILITY.Text = "4"
        CheckDataSani()
    End Sub
    Private Sub optDURABILITY9_Click(sender As Object, e As EventArgs) Handles optDURABILITY9.Click
        optDURABILITY1.Checked = False
        optDURABILITY2.Checked = False
        optDURABILITY3.Checked = False
        optDURABILITY0.Checked = False
        optDURABILITY9.Checked = False
        optDURABILITY9.Checked = True
        txtDURABILITY.Text = "9"
        CheckDataSani()
    End Sub

    Private Sub txtDURABILITY_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDURABILITY.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckDataSani()
        End If
    End Sub
    Private Sub optCLEANLINESS0_Click(sender As Object, e As EventArgs) Handles optCLEANLINESS0.Click
        optCLEANLINESS0.Checked = True
        optCLEANLINESS1.Checked = False
        optCLEANLINESS9.Checked = False
        txtCLEANLINESS.Text = "0"
        CheckDataSani()
    End Sub
    Private Sub optCLEANLINESS1_Click(sender As Object, e As EventArgs) Handles optCLEANLINESS1.Click
        optCLEANLINESS0.Checked = False
        optCLEANLINESS1.Checked = True
        optCLEANLINESS9.Checked = False
        txtCLEANLINESS.Text = "1"
        CheckDataSani()
    End Sub
    Private Sub optCLEANLINESS9_Click(sender As Object, e As EventArgs) Handles optCLEANLINESS9.Click
        optCLEANLINESS0.Checked = False
        optCLEANLINESS1.Checked = False
        optCLEANLINESS9.Checked = True
        txtCLEANLINESS.Text = "9"
        CheckDataSani()
    End Sub

    Private Sub txtCLEANLINESS_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCLEANLINESS.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckDataSani()
        End If
    End Sub
    Private Sub optVENTILATION0_Click(sender As Object, e As EventArgs) Handles optVENTILATION0.Click
        optVENTILATION0.Checked = True
        optVENTILATION1.Checked = False
        optVENTILATION9.Checked = False
        txtVENTILATION.Text = "0"
        CheckDataSani()
    End Sub
    Private Sub optVENTILATION1_Click(sender As Object, e As EventArgs) Handles optVENTILATION1.Click
        optVENTILATION0.Checked = False
        optVENTILATION1.Checked = True
        optVENTILATION9.Checked = False
        txtVENTILATION.Text = "1"
        CheckDataSani()
    End Sub
    Private Sub optVENTILATION9_Click(sender As Object, e As EventArgs) Handles optVENTILATION9.Click
        optVENTILATION0.Checked = False
        optVENTILATION1.Checked = False
        optVENTILATION9.Checked = True
        txtVENTILATION.Text = "9"
        CheckDataSani()
    End Sub

    Private Sub txtVENTILATION_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVENTILATION.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckDataSani()
        End If
    End Sub
    Private Sub optLIGHT0_Click(sender As Object, e As EventArgs) Handles optLIGHT0.Click
        optLIGHT0.Checked = True
        optLIGHT1.Checked = False
        optLIGHT9.Checked = False
        txtLIGHT.Text = "0"
        CheckDataSani()
    End Sub
    Private Sub optLIGHT1_Click(sender As Object, e As EventArgs) Handles optLIGHT1.Click
        optLIGHT0.Checked = False
        optLIGHT1.Checked = True
        optLIGHT9.Checked = False
        txtLIGHT.Text = "1"
        CheckDataSani()
    End Sub
    Private Sub optLIGHT9_Click(sender As Object, e As EventArgs) Handles optLIGHT9.Click
        optLIGHT0.Checked = False
        optLIGHT1.Checked = False
        optLIGHT9.Checked = True
        txtLIGHT.Text = "9"
        CheckDataSani()
    End Sub

    Private Sub txtLIGHT_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLIGHT.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckDataSani()
        End If
    End Sub
    Private Sub optWATERTM0_Click(sender As Object, e As EventArgs) Handles optWATERTM0.Click
        optWATERTM0.Checked = True
        optWATERTM1.Checked = False
        optWATERTM9.Checked = False
        txtWATERTM.Text = "0"
        CheckDataSani()
    End Sub
    Private Sub optWATERTM1_Click(sender As Object, e As EventArgs) Handles optWATERTM1.Click
        optWATERTM0.Checked = False
        optWATERTM1.Checked = True
        optWATERTM9.Checked = False
        txtWATERTM.Text = "1"
        CheckDataSani()
    End Sub
    Private Sub optWATERTM9_Click(sender As Object, e As EventArgs) Handles optWATERTM9.Click
        optWATERTM0.Checked = False
        optWATERTM1.Checked = False
        optWATERTM9.Checked = True
        txtWATERTM.Text = "9"
        CheckDataSani()
    End Sub

    Private Sub txtWATERTM_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWATERTM.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckDataSani()
        End If
    End Sub
    Private Sub optMFOOD0_Click(sender As Object, e As EventArgs) Handles optMFOOD0.Click
        optMFOOD0.Checked = True
        optMFOOD1.Checked = False
        optMFOOD9.Checked = False
        txtMFOOD.Text = "0"
        CheckDataSani()
    End Sub
    Private Sub optMFOOD1_Click(sender As Object, e As EventArgs) Handles optMFOOD1.Click
        optMFOOD0.Checked = False
        optMFOOD1.Checked = True
        optMFOOD9.Checked = False
        txtMFOOD.Text = "1"
        CheckDataSani()
    End Sub
    Private Sub optMFOOD9_Click(sender As Object, e As EventArgs) Handles optMFOOD9.Click
        optMFOOD0.Checked = False
        optMFOOD1.Checked = False
        optMFOOD9.Checked = True
        txtMFOOD.Text = "9"
        CheckDataSani()
    End Sub

    Private Sub txtMFOOD_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMFOOD.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckDataSani()
        End If
    End Sub
    Private Sub optBCONTROL0_Click(sender As Object, e As EventArgs) Handles optBCONTROL0.Click
        optBCONTROL0.Checked = True
        optBCONTROL1.Checked = False
        optBCONTROL9.Checked = False
        txtBCONTROL.Text = "0"
        CheckDataSani()
    End Sub
    Private Sub optBCONTROL1_Click(sender As Object, e As EventArgs) Handles optBCONTROL1.Click
        optBCONTROL0.Checked = False
        optBCONTROL1.Checked = True
        optBCONTROL9.Checked = False
        txtBCONTROL.Text = "1"
        CheckDataSani()
    End Sub
    Private Sub optBCONTROL9_Click(sender As Object, e As EventArgs) Handles optBCONTROL9.Click
        optBCONTROL0.Checked = False
        optBCONTROL1.Checked = False
        optBCONTROL9.Checked = True
        txtBCONTROL.Text = "9"
        CheckDataSani()
    End Sub

    Private Sub txtBCONTROL_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBCONTROL.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckDataSani()
        End If
    End Sub
    Private Sub optACONTROL0_Click(sender As Object, e As EventArgs) Handles optACONTROL0.Click
        optACONTROL0.Checked = True
        optACONTROL1.Checked = False
        optACONTROL9.Checked = False
        txtACONTROL.Text = "0"
        CheckDataSani()
    End Sub
    Private Sub optACONTROL1_Click(sender As Object, e As EventArgs) Handles optACONTROL1.Click
        optACONTROL0.Checked = False
        optACONTROL1.Checked = True
        optACONTROL9.Checked = False
        txtACONTROL.Text = "1"
        CheckDataSani()
    End Sub
    Private Sub optACONTROL9_Click(sender As Object, e As EventArgs) Handles optACONTROL9.Click
        optACONTROL0.Checked = False
        optACONTROL1.Checked = False
        optACONTROL9.Checked = True
        txtACONTROL.Text = "9"
        CheckDataSani()
    End Sub

    Private Sub txtACONTROL_KeyDown(sender As Object, e As KeyEventArgs) Handles txtACONTROL.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckDataSani()
        End If
    End Sub
    Private Sub optCHEMICAL0_Click(sender As Object, e As EventArgs) Handles optCHEMICAL0.Click
        optCHEMICAL0.Checked = True
        optCHEMICAL1.Checked = False
        optCHEMICAL9.Checked = False
        txtCHEMICAL.Text = "0"
        CheckDataSani()
    End Sub
    Private Sub optCHEMICAL1_Click(sender As Object, e As EventArgs) Handles optCHEMICAL1.Click
        optCHEMICAL0.Checked = False
        optCHEMICAL1.Checked = True
        optCHEMICAL9.Checked = False
        txtCHEMICAL.Text = "1"
        CheckDataSani()
    End Sub
    Private Sub optCHEMICAL9_Click(sender As Object, e As EventArgs) Handles optCHEMICAL9.Click
        optCHEMICAL0.Checked = False
        optCHEMICAL1.Checked = False
        optCHEMICAL9.Checked = True
        txtCHEMICAL.Text = "9"
        CheckDataSani()
    End Sub

    Private Sub txtCHEMICAL_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCHEMICAL.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckDataSani()
        End If
    End Sub
    Private Sub ShowImageInhouse()
        Dim ds2 As DataSet
        ds2 = clsdataBus.Lc_Business.SELECT_TABLE("IMG,a.CID,CONCAT(NAME,'  ',LNAME) AS NAME", " m_person a JOIN m_image_person b ON(a.CID = b.CID) ", "WHERE HID = '" & vHomeHID & "' AND a.STATUS_AF <> '8' ORDER BY BIRTH DESC ")
        If ds2.Tables(0).Rows.Count > 0 Then
            GridControl1.DataSource = ds2.Tables(0)
            Dim repItemGraphicsEdit As New RepositoryItemGraphicsEdit
            repItemGraphicsEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
            repItemGraphicsEdit.BestFitWidth = 100
            LayoutView1.Columns("IMG").ColumnEdit = repItemGraphicsEdit
        End If
    End Sub
End Class