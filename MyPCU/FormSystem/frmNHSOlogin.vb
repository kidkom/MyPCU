Imports clsdataBus = MyPCU.ClsBusiness
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.Globalization
Imports System.IO
Imports DevExpress.XtraEditors
Imports MadMilkman.Ini
Public Class frmNHSOlogin
    Dim tmpPath As String = ""
    Private Sub frmNHSOlogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim filePath = Application.StartupPath & "\config.ini"
            Dim file As New IniFile()
            file.Load(filePath)
            tmpPath = file.Sections("NHSO").Keys("Path").Value
        Catch ex As Exception

        End Try


        txtUsername.Text = vUserCID
        txtPassword.Select()
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        If txtUsername.Text = "" Or txtPassword.Text = "" Then
            XtraMessageBox.Show("กรุณาใส่ชื่อผู้ใช้และ Token ID ก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim ds As DataSet
        ds = clsdataBus.Lc_Business.SELECT_TABLE("*", " n_user_nhso", " WHERE USERNAME = '" & txtUsername.Text & "'")
        If ds.Tables(0).Rows.Count = 0 Then
            Dim tmpUsername As String = txtUsername.Text
            Dim tmpPassword As String = txtPassword.Text
            Dim tmpStatus As String = ""
            Dim tmpNow As String = clsdataBus.Lc_Business.MySQL_Sysdate().ToString.Substring(0, 6)
            clsbusent.Lc_BusinessEntity.Insertm_table("n_user_nhso (USERNAME,PASSWORD,STATUS_AF,AMOUNT,MONTH_SERV)",
            "'" & tmpUsername & "','" & tmpPassword & "','1','0','" & tmpNow & "' ")
        Else
            clsbusent.Lc_BusinessEntity.Updatem_table("n_user_nhso", " PASSWORD  = '" & txtPassword.Text & "',STATUS_AF = '1'", " USERNAME = '" & txtUsername.Text & "'")
        End If

        Me.Close()
    End Sub

    Private Sub cmdCancle_Click(sender As Object, e As EventArgs) Handles cmdCancle.Click
        Me.Close()
    End Sub


    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If txtUsername.Text = "" Then
                    XtraMessageBox.Show("กรุณาใส่ Username ก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    txtPassword.Select()
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If txtPassword.Text = "" Then
                    XtraMessageBox.Show("กรุณาใส่ Password ก่อน!!!", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    cmdOK.Focus()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If PicProvider <> "" Then
            If File.Exists(PicProvider & "nhso_token.txt") = True Then
                Dim fileReader As System.IO.StreamReader
                fileReader =
                My.Computer.FileSystem.OpenTextFileReader(tmpPath & "\nhso_token.txt")
                Dim stringReader As String
                stringReader = fileReader.ReadLine()

                If stringReader.Substring(0, 13) = txtUsername.Text Then
                    txtPassword.Text = stringReader.Substring(14)
                End If
            End If
        End If
    End Sub
End Class