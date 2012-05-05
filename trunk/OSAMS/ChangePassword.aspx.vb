'------------------------------------------------------------ 
' File Name         :ChangePassword.aspx.vb
' Description       :Allows user to change their password
' Function List     :Page_Load
'                    changePassword
'                    btnCancel_Click
'                    getCurrentPassword
'                    CustomValidator1_ServerValidate
' Date Created      : 28/03/2012
' Created By        : Vo Ngoc Diep
'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
' 16/04/2012   Vo Ngoc Diep       Adding comments, validations
'------------------------------------------------------------ 

Imports System.Data.SqlClient
Public Class ChangePassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Load the page
        If (IsPostBack = False) Then
            If Session("ID") Is Nothing And Request.Cookies("ID") Is Nothing Then 'Check Session and Cookie are null
                Response.Redirect("LoginForm.aspx")
            Else
                If (Session("Rememberme") = "false") Then
                    tbxID.Text = Session("ID")
                Else
                    tbxID.Text = Request.Cookies("ID").Value
                End If
            End If
        End If
    End Sub

    Private Sub changePassword(ByVal Table_Name As String, ByVal ID As String)
        ' Function to change password
        Dim cnn As SqlConnection
        Dim cmd As SqlCommand
        Dim str As String
        str = PB.getConnectionString()

        cnn = New SqlConnection(str)
        Try
            cnn.Open()
            cmd = New SqlCommand("Update " & Table_Name & " SET password = '" & tbxNewPassword.Text & "' where user_name = '" & ID & "'", cnn)
            cmd.ExecuteNonQuery()
            Response.Redirect("Home.aspx")
        Catch ex As Exception
            Response.Write(ex)
            cnn.Close()
        End Try
        cnn.Close()
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        'Cancel button is clicked
        Response.Redirect("Profile.aspx")
    End Sub

    Function getCurrentPassword(ByVal ID As String) As String
        'Function to get current password
        Dim cnn As SqlConnection
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        getCurrentPassword = ""
        Dim str As String
        str = PB.getConnectionString()

        cnn = New SqlConnection(str)
        Try
            cnn.Open()
            cmd = New SqlCommand("Select * from account where user_name = '" & ID & "'", cnn)
            dr = cmd.ExecuteReader

            While dr.Read
                getCurrentPassword = dr("password")
            End While

        Catch ex As Exception
            Response.Write(ex)
            cnn.Close()
        End Try
        cnn.Close()
        Return getCurrentPassword
    End Function

    Protected Sub CtvldtOldPassword_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CtvldtOldPassword.ServerValidate
        'Validate Old Password
        If (tbxOldPassword.Text = getCurrentPassword(tbxID.Text)) Then
            args.IsValid = True
            changePassword("account", tbxID.Text)
        Else
            args.IsValid = False
        End If
    End Sub
End Class