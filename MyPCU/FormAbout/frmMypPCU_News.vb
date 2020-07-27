Imports System.Text
Public Class frmMypPCU_News

    Private Sub frmMypPCU_News_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim AddrToSearch As New StringBuilder()
            AddrToSearch.Append("http://mypcu.in.th/mypcu/mypcu_news.php")
            ' if there is latitude
            WebBrowser1.Navigate(AddrToSearch.ToString())
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), _
                            "Problem encountered please check internet connection!")
        End Try
    End Sub
End Class