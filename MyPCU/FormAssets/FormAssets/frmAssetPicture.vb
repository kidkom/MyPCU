Imports clsDataAcc8 = MyPCU.ClsDataAccess8
Imports clsdataBus8 = MyPCU.ClsBusiness8
Imports clsbusent8 = MyPCU.ClsBusinessEntity8
Imports System.DateTime
Imports System.Globalization
Imports MySql.Data.MySqlClient
Imports System.IO
Public Class frmAssetPicture
    Dim tmpAssetID As String = ""
    Dim tmpID As String = ""

    Private Sub frmAssetPicture_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblASSET_CODE_ID.Text = "รหัสทรัพย์สิน : " & picCODE
        txtASSET_NAME.Text = PicNAME

        tmpAssetID = picAssetCODE
        tmpID = PicID

        ShowImages1()
        ShowImages2()
        ShowImages3()
        ShowImages4()

        PictureBox1.Focus()

    End Sub
    Private Sub ShowImages1()
        Dim ds2 As DataSet
        ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("IMG", " t_picture1 ", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            Dim lb() As Byte = ds2.Tables(0).Rows(0).Item("IMG")
            Dim ms As MemoryStream = New MemoryStream(lb)
            Dim img As Image = Image.FromStream(ms)
            PictureBox1.Image = img
            ms.Close()
        Else
            PictureBox1.Enabled = False
        End If
    End Sub
    Private Sub ShowImages2()
        Dim ds2 As DataSet
        ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("IMG", " t_picture2 ", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            Dim lb() As Byte = ds2.Tables(0).Rows(0).Item("IMG")
            Dim ms As MemoryStream = New MemoryStream(lb)
            Dim img As Image = Image.FromStream(ms)
            PictureBox2.Image = img
            ms.Close()
        Else
            PictureBox2.Enabled = False
        End If
    End Sub
    Private Sub ShowImages3()
        Dim ds2 As DataSet
        ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("IMG", " t_picture3 ", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            Dim lb() As Byte = ds2.Tables(0).Rows(0).Item("IMG")
            Dim ms As MemoryStream = New MemoryStream(lb)
            Dim img As Image = Image.FromStream(ms)
            PictureBox3.Image = img
            ms.Close()
        Else
            PictureBox3.Enabled = False
        End If
    End Sub
    Private Sub ShowImages4()
        Dim ds2 As DataSet
        ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("IMG", " t_picture4 ", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            Dim lb() As Byte = ds2.Tables(0).Rows(0).Item("IMG")
            Dim ms As MemoryStream = New MemoryStream(lb)
            Dim img As Image = Image.FromStream(ms)
            PictureBox4.Image = img
            ms.Close()
        Else
            PictureBox4.Enabled = False
        End If
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim ds2 As DataSet
        ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("IMG", " t_picture1 ", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            Dim lb() As Byte = ds2.Tables(0).Rows(0).Item("IMG")
            Dim ms As MemoryStream = New MemoryStream(lb)
            Dim img As Image = Image.FromStream(ms)
            PictureBox5.Image = img
            ms.Close()
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim ds2 As DataSet
        ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("IMG", " t_picture2 ", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            Dim lb() As Byte = ds2.Tables(0).Rows(0).Item("IMG")
            Dim ms As MemoryStream = New MemoryStream(lb)
            Dim img As Image = Image.FromStream(ms)
            PictureBox5.Image = img
            ms.Close()
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim ds2 As DataSet
        ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("IMG", " t_picture3 ", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            Dim lb() As Byte = ds2.Tables(0).Rows(0).Item("IMG")
            Dim ms As MemoryStream = New MemoryStream(lb)
            Dim img As Image = Image.FromStream(ms)
            PictureBox5.Image = img
            ms.Close()
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dim ds2 As DataSet
        ds2 = clsdataBus8.Lc_Business8.SELECT_TABLE("IMG", " t_picture4 ", " WHERE ASSET_ID = '" & tmpAssetID & "' AND ID  = '" & tmpID & "'")
        If ds2.Tables(0).Rows.Count > 0 Then
            Dim lb() As Byte = ds2.Tables(0).Rows(0).Item("IMG")
            Dim ms As MemoryStream = New MemoryStream(lb)
            Dim img As Image = Image.FromStream(ms)
            PictureBox5.Image = img
            ms.Close()
        End If
    End Sub
End Class