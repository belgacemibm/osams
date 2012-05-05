'------------------------------------------------------------ 
' File Name         :Template.Master.vb
' Description       :Control system menu
' Function List     :Page_Load
'                    Load_Page_RememberMe
'                    Load_Page_NotRememberMe
'                    getFullName
'                    lkbtnLoginStatus_Click
'                    lnkbtnProfile_Click
' Date Created      : 28/03/2012
' Created By        : Vo Ngoc Diep
'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
' 16/4/2012    Vo Ngoc Diep       Adding comments
'------------------------------------------------------------ 

Imports System.Data.SqlClient
Public Class Template
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Load the page
        If (IsPostBack = False) Then
            If (Session("Rememberme") = "false") Then
                Load_Page_NotRememberMe()
            Else
                Load_Page_RememberMe()
            End If
        End If
    End Sub

    Private Sub Load_Page_RememberMe()
        'Load the page with remember password
        If (Request.Cookies("ID") Is Nothing) Then 'If Cookie is null
            Response.Redirect("LoginForm.aspx") 'Return to Login page
        Else
            lblWelcome.Text += " " + getFullName(Request.Cookies("ID").Value, "admin", "staff_id") + getFullName(Request.Cookies("ID").Value, "lecturer", "lecturer_id") + getFullName(Request.Cookies("ID").Value, "student", "student_id")
            lnkbtnLoginStatus.Text = "Logout"
            Response.Cookies("AccountType").Value = PB.getAccountType(Request.Cookies("ID").Value)
            If PB.getAccountType(Request.Cookies("ID").Value) = "1" Then 'Load menu
                NavigationMenu.DataSourceID = "SuperAdmin"
            ElseIf PB.getAccountType(Request.Cookies("ID").Value) = "2" Then
                NavigationMenu.DataSourceID = "Admin"
            ElseIf PB.getAccountType(Request.Cookies("ID").Value) = "3" Or PB.getAccountType(Request.Cookies("ID").Value) = "4" Then
                NavigationMenu.DataSourceID = "Lecturer"
            ElseIf PB.getAccountType(Request.Cookies("ID").Value) = "5" Then
                NavigationMenu.DataSourceID = "Student"
            End If
        End If
    End Sub

    Private Sub Load_Page_NotRememberMe()
        'Load the page without remember password
        If (Session("ID") Is Nothing) Then 'If session is null
            Response.Redirect("LoginForm.aspx") 'Return to Login page
        Else
            lblWelcome.Text += " " + getFullName(Session("ID"), "admin", "staff_id") + getFullName(Session("ID"), "lecturer", "lecturer_id") + getFullName(Session("ID"), "student", "student_id")
            lnkbtnLoginStatus.Text = "Logout"
            Session("AccountType") = PB.getAccountType(Session("ID"))
            If PB.getAccountType(Session("ID")) = "1" Then 'Load menu
                NavigationMenu.DataSourceID = "SuperAdmin"
            ElseIf PB.getAccountType(Session("ID")) = "2" Then
                NavigationMenu.DataSourceID = "Admin"
            ElseIf PB.getAccountType(Session("ID")) = "3" Or PB.getAccountType(Session("ID")) = "4" Then
                NavigationMenu.DataSourceID = "Lecturer"
            ElseIf PB.getAccountType(Session("ID")) = "5" Then
                NavigationMenu.DataSourceID = "Student"
            End If
        End If
    End Sub

    Function getFullName(ByVal ID As String, ByVal table As String, ByVal ID_Name As String) As String
        'Function to get Full Name
        Dim cnn As SqlConnection
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        getFullName = ""
        Dim str As String
        str = PB.getConnectionString()

        cnn = New SqlConnection(str)
        Try
            cnn.Open()
            cmd = New SqlCommand("Select * from " & table & " where " & ID_Name & " = '" & ID & "'", cnn)
            dr = cmd.ExecuteReader

            While dr.Read
                getFullName = dr("given_name") + " " + dr("family_name") + " " + dr("middle_name")
            End While

        Catch ex As Exception
            Response.Write(ex)
            cnn.Close()
        End Try
        cnn.Close()
        Return getFullName
    End Function

    Protected Sub lkbtnLoginStatus_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkbtnLoginStatus.Click
        'Login Status link is clicked
        Response.Cookies("ID").Expires = DateTime.Now.AddDays(-1)
        Session.Abandon()
        Response.Redirect("LoginForm.aspx")
    End Sub

    Protected Sub lnkbtnProfile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkbtnProfile.Click
        'Profile link is clicked
        Response.Redirect("Profile.aspx")
    End Sub

End Class