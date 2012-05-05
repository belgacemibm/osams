'------------------------------------------------------------ 
' File Name         :LoginForm.aspx.vb
' Description       :Allows user to log in the system
' Function List     :ValidateUser
'                    LoginControl_Authenticate
'                    Page_Load
'                    ValidateUser
'                    getActiveField
' Date Created      : 28/03/2012
' Created By        : Vo Ngoc Diep
'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
' 16/4/2012    Vo Ngoc Diep       Adding comments
' 02/05/2012   Vo Ngoc Diep       Validating whether is active or not
'------------------------------------------------------------ 

Imports System.Data.SqlClient
Public Class LoginForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Lod the page
        If (IsPostBack = False) Then
            If Not (Session("ID") Is Nothing And Request.Cookies("ID") Is Nothing) Then 'Check if Session and Cookie are not null
                Response.Redirect("Home.aspx")
            End If
        End If
    End Sub

    Protected Sub LoginControl_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles LoginControl.Authenticate
        'Authenticate username and password
        If getActiveField(LoginControl.UserName) = "False" Then
            LoginControl.FailureText = "Your account has been deactivated. Please contact Super Admin for details."
        Else
            ValidateUser(LoginControl.UserName, LoginControl.Password)
        End If
    End Sub

    Function ValidateUser(ByVal ID As String, ByVal Password As String) As Boolean
        'Validate username and password
        Dim cnn As SqlConnection
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim retVal As Boolean = False

        If LoginControl.RememberMeSet = True Then 'Check if "Remember Me" is checked or not
            Session("Rememberme") = "true"
        Else
            Session("Rememberme") = "false"
        End If
        Dim str As String
        str = PB.getConnectionString()

        cnn = New SqlConnection(str)
        Try
            cnn.Open()
            cmd = New SqlCommand("Select * from account where user_name = '" & ID & "' and password = '" & Password & "'", cnn)
            dr = cmd.ExecuteReader

            While dr.Read
                If LoginControl.RememberMeSet = True Then 'If "Remember Me" is checked
                    retVal = True
                    Response.Cookies("ID").Value = ID 'Set Cookie
                    Response.Cookies("ID").Expires = "1/1/2013"
                    Response.Redirect("Home.aspx")
                Else 'If "Remember Me" is not checked
                    retVal = True
                    Session("ID") = ID 'Set Session
                    Response.Redirect("Home.aspx")
                End If
            End While
        Catch ex As Exception
            Response.Write(ex)
            cnn.Close()
        End Try
        ValidateUser = retVal
    End Function

    Private Function getActiveField(ByVal ID As String) As String
        'Function to get 'active' field
        Dim cnn As SqlConnection
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        getActiveField = ""

        Dim str As String

        str = PB.getConnectionString()

        cnn = New SqlConnection(str)
        Try
            cnn.Open()
            cmd = New SqlCommand("Select * from account where user_name = '" & ID & "'", cnn)
            dr = cmd.ExecuteReader

            While dr.Read
                getActiveField = dr("active")
            End While

        Catch ex As Exception
            cnn.Close()
        End Try
        cnn.Close()
        Return getActiveField
    End Function

End Class