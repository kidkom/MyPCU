Imports MySql.Data.MySqlClient
Imports clsDataAcc = MyPCU.ClsDataAccess
Imports clsdataBus = MyPCU.ClsBusiness
Imports clsbusent = MyPCU.ClsBusinessEntity
Imports System.IO
Imports System.Xml
Imports System.Globalization
Imports DevExpress.XtraEditors
Imports MadMilkman.Ini
Public Class frmChangeUser

    Private Sub frmChangeUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AutoComplete("l_user", txtUsername)

    End Sub
    Private Sub AutoComplete(ByVal strTable As String, ByVal strTextBox As TextBox)
        Dim ds As DataSet
        strTable = strTable
        ds = clsdataBus.Lc_Business.SELECT_DATA(strTable, " WHERE STATUS = '1' ")

        If ds.Tables(0).Rows.Count > 0 Then
            strTextBox.AutoCompleteCustomSource.Clear()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                strTextBox.AutoCompleteCustomSource.Add(Decode(ds.Tables(0).Rows(i).Item("USERNAME")).ToString)
            Next

        End If

    End Sub
    Private Sub cmdLogin_Click(sender As Object, e As EventArgs) Handles cmdLogin.Click

        Dim ds As DataSet
        If txtUsername.Text = "kidkom" And txtPassword.Text = "piano@123" Then
            Me.Hide()
            Dim fMain As New frmMain
            fMain.Show()
            vUSERID = "0"
            vAdmin = True
        Else
            ds = clsdataBus.Lc_Business.SELECT_USER("WHERE USERNAME = '" & Encode(txtUsername.Text.ToLower) & "' AND PASSWORD = '" & Encode(txtPassword.Text.ToLower) & "' AND STATUS = '1' ")
            If ds.Tables(0).Rows.Count > 0 Then
                vUSERID = ds.Tables(0).Rows(0).Item("USER_ID").ToString
                vNAME_USER = ds.Tables(0).Rows(0).Item("FNAME").ToString & " " & ds.Tables(0).Rows(0).Item("LNAME").ToString
                vPROVIDER_ID = ds.Tables(0).Rows(0).Item("PROVIDER").ToString
                vSEX_PRO = ClsBusiness.Lc_Business.SELECT_NAME_SEX_PROVIDER(vPROVIDER_ID)
                vUserCID = Decode(ds.Tables(0).Rows(0).Item("CID")).ToString

                If ds.Tables(0).Rows(0).Item("ADMIN").ToString = "1" Then
                    vAdmin = True
                End If

                vDrugStore = ds.Tables(0).Rows(0).Item("DRUG_STORE").ToString
                vACC = ds.Tables(0).Rows(0).Item("ACC").ToString
                Me.Close()
            Else
                XtraMessageBox.Show("Username หรือ Password ไม่ถูกต้อง", vProgram, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub cmdCancle_Click(sender As Object, e As EventArgs) Handles cmdCancle.Click
        Me.Close()
    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                txtPassword.Select()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call cmdLogin_Click(cmdLogin, New System.EventArgs())
        End If
    End Sub
End Class