Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.IO
Imports System.Drawing.Printing
Imports DevExpress.XtraEditors
Imports MadMilkman.Ini
Imports MySql.Data.MySqlClient
Public Class frmConfigPicture

    Private Sub frmConfigPicture_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim filePath = Application.StartupPath & "\config.ini"
            Dim file As New IniFile()
            file.Load(filePath)

            If file.Sections("Pictures").Keys("Type").Value = "1" Then
                optPic1.Checked = True
            ElseIf file.Sections("Pictures").Keys("Type").Value = "0" Then
                optPic2.Checked = True
            ElseIf file.Sections("Pictures").Keys("Type").Value = "2" Then
                optPic3.Checked = True
            End If

            txtPic.Text = file.Sections("Pictures").Keys("Folder").Value

        Catch ex As Exception
            optPic1.Checked = True
        End Try
    End Sub

    Private Sub optPic1_Click(sender As Object, e As EventArgs) Handles optPic1.Click
        optPic1.Checked = True
        optPic2.Checked = False
        optPic3.Checked = False
    End Sub
    Private Sub optPic2_Click(sender As Object, e As EventArgs) Handles optPic2.Click
        optPic1.Checked = False
        optPic2.Checked = True
        optPic3.Checked = False
    End Sub
    Private Sub optPic3_Click(sender As Object, e As EventArgs) Handles optPic3.Click
        optPic1.Checked = False
        optPic2.Checked = False
        optPic3.Checked = True
    End Sub

    Private Sub cmdCancle_Click(sender As Object, e As EventArgs) Handles cmdCancle.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If XtraFolderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtPic.Text = XtraFolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub cmdApply_Click(sender As Object, e As EventArgs) Handles cmdApply.Click
        SaveData()
        XtraMessageBox.Show(msSave, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub SaveData()

        If optPic1.Checked = True Or optPic3.Checked = True Then
            If txtPic.Text = "" Then
                XtraMessageBox.Show("กำหนดโฟลเดอร์ที่เก็บไฟล์ภาพก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        Dim tmpType As String = ""
        If optPic1.Checked = True Then
            tmpType = "1"
        ElseIf optPic2.Checked = True Then
            tmpType = "0"
        ElseIf optPic3.Checked = True Then
            tmpType = "2"
        End If

        vImage = tmpType
        PicPer = txtPic.Text

        Dim filePath = Application.StartupPath & "\config.ini"
        Dim file2 As New IniFile()
        If File.Exists(filePath) = True Then
            file2.Load(filePath)
        End If

        file2.Sections.Remove("Pictures")
        file2.Sections.Add("Pictures")

        file2.Sections("Pictures").Keys.Add("Type", tmpType)
        file2.Sections("Pictures").Keys.Add("Folder", txtPic.Text & "\")


        file2.Save(filePath)
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        SaveData()
        XtraMessageBox.Show(msSave, vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub


    Private Sub cmdImportData_Click(sender As Object, e As EventArgs) Handles cmdImportData.Click
        If txtPic.Text = "" Then
            XtraMessageBox.Show("กำหนดโฟลเดอร์ที่เก็บไฟล์ภาพก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        SaveData()
        SplashScreenManager1.ShowWaitForm()

        ClsBusinessEntity.Lc_BusinessEntity.SetGlobal()

        ImportPicture()

        SplashScreenManager1.CloseWaitForm()
        XtraMessageBox.Show("นำเข้าเรียบร้อยแล้ว!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Private Sub ImportPicture()

        Dim SQL As String = ""
        Dim connpic As MySqlConnection = New MySqlConnection
        Dim cmd As New MySqlCommand
        Dim FileSize As UInt32
        Dim bytes As Byte()
        Dim ds As DataSet
        Dim tmpFD As String = ""
        Dim tmpCID As String = ""
        clsbusent.Lc_BusinessEntity.Turncate_table("m_image_person")
        ds = clsdataBus.Lc_Business.SELECT_TABLE("CID", " m_person ", " WHERE IFNULL(CID,'') <> ''  ")

        If ds.Tables(0).Rows.Count > 0 Then
            ProgressBarControl1.EditValue = 0
            ProgressBarControl1.Properties.Maximum = 100
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                tmpCID = Decode(ds.Tables(0).Rows(i).Item("CID"))

                If File.Exists(PicPer & tmpCID & ".jpg") Then
                    Dim fs As New FileStream(PicPer & tmpCID & ".jpg", FileMode.Open, FileAccess.Read)
                    Dim br As New BinaryReader(fs)

                    bytes = System.IO.File.ReadAllBytes(PicPer & tmpCID & ".jpg")
                    FileSize = bytes.Length

                    SQL = "INSERT INTO m_image_person (CID,IMG,FILESIZE) VALUES(@CID" & i & ",@IMG" & i & ",@FILESIZE" & i & ")"
                    If connpic.State = ConnectionState.Open Then
                        connpic.Close()
                    End If
                    connpic.ConnectionString = "Data Source=" & clsDataAcc.G_DBIPServer & ";port=" & clsDataAcc.G_DBPortServer & ";Database= his43;user id=" & clsDataAcc.G_DBUserName & ";password=" & clsDataAcc.G_DBPassword & ""
                    connpic.Open()
                    cmd.Connection = connpic
                    cmd.CommandText = SQL
                    cmd.Parameters.AddWithValue("@CID" & i & "", tmpCID)
                    cmd.Parameters.AddWithValue("@IMG" & i & "", bytes)
                    cmd.Parameters.AddWithValue("@FILESIZE" & i & "", FileSize)
                    cmd.ExecuteNonQuery()
                    connpic.Close()


                Else
                    If File.Exists(PicPer & tmpCID & ".png") Then
                        Dim fs As New FileStream(PicPer & tmpCID & ".png", FileMode.Open, FileAccess.Read)
                        Dim br As New BinaryReader(fs)

                        bytes = System.IO.File.ReadAllBytes(PicPer & tmpCID & ".png")
                        FileSize = bytes.Length

                        SQL = "INSERT INTO m_image_person (CID,IMG,FILESIZE) VALUES(@CID,@IMG,@FILESIZE)"
                        If connpic.State = ConnectionState.Open Then
                            connpic.Close()
                        End If
                        connpic.ConnectionString = "Data Source=" & clsDataAcc.G_DBIPServer & ";port=" & clsDataAcc.G_DBPortServer & ";Database= " & clsDataAcc.G_DBName & ";user id=" & clsDataAcc.G_DBUserName & ";password=" & clsDataAcc.G_DBPassword & ""
                        connpic.Open()
                        cmd.Connection = connpic
                        cmd.CommandText = SQL
                        cmd.Parameters.AddWithValue("@CID", tmpCID)
                        cmd.Parameters.AddWithValue("@IMG", bytes)
                        cmd.Parameters.AddWithValue("@FILESIZE", FileSize)
                        cmd.ExecuteNonQuery()
                        connpic.Close()
                    End If
                End If

                ProgressBarControl1.EditValue = (i + 1) * 100 / ds.Tables(0).Rows.Count
                ProgressBarControl1.Refresh()
            Next
            ProgressBarControl1.EditValue = 100
            connpic.Close()
        End If


    End Sub
End Class