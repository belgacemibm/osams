'------------------------------------------------------------ 
' File Name         :Profile.aspx.vb
' Description       :Profile page
' Function List     :Page_Load
'                    Load_Page_RememberMe
'                    Load_Page_NotRememberMe
'                    getInfo
'                    btnEditProfile_Click
' Date Created      : 28/03/2012
' Created By        : Vo Ngoc Diep
'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
' 16/4/2012    Vo Ngoc Diep       Adding comments, change gridview to detailsview
'------------------------------------------------------------ 

Imports System.Data.SqlClient
Public Class Profile
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Load the page
        If (IsPostBack = False) Then
            If Session("ID") Is Nothing And Request.Cookies("ID") Is Nothing Then
                Response.Redirect("LoginForm.aspx")
            Else
                If (Session("Rememberme") = "false") Then
                    Load_Page_NotRememberMe()
                Else
                    Load_Page_RememberMe()
                End If
            End If
        End If
    End Sub

    Private Sub Load_Page_NotRememberMe()
        'Load the page without remember password
        If PB.getAccountType(Session("ID")) = "1" Or PB.getAccountType(Session("ID")) = "2" Then
            getInfo("staff_id", "Staff ID", "admin", Session("ID"))
        End If
        If PB.getAccountType(Session("ID")) = "3" Or PB.getAccountType(Session("ID")) = "4" Then
            getInfo("lecturer_id", "Lecturer ID", "lecturer", Session("ID"))
        End If
        If PB.getAccountType(Session("ID")) = "5" Then
            getInfo("student_id", "Student ID", "student", Session("ID"))
        End If
    End Sub

    Private Sub Load_Page_RememberMe()
        'Load the page with remember password
        If PB.getAccountType(Request.Cookies("ID").Value) = "1" Or PB.getAccountType(Request.Cookies("ID").Value) = "2" Then
            getInfo("staff_id", "Staff ID", "admin", Request.Cookies("ID").Value)
        End If
        If PB.getAccountType(Request.Cookies("ID").Value) = "3" Or PB.getAccountType(Request.Cookies("ID").Value) = "4" Then
            getInfo("lecturer_id", "Lecturer ID", "lecturer", Request.Cookies("ID").Value)
        End If
        If PB.getAccountType(Request.Cookies("ID").Value) = "5" Then
            getInfo("student_id", "Student ID", "student", Request.Cookies("ID").Value)
        End If
    End Sub

    Private Sub getInfo(ByVal ID_Field As String, ByVal ID_Name As String, ByVal Table_Name As String, ByVal ID As String)
        'Sub to get user info and fill in the Detail View
        Dim cnn As SqlConnection
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim str As String

        str = PB.getConnectionString()

        cnn = New SqlConnection(str)
        Try
            cnn.Open()
            cmd = New SqlCommand("Select " & ID_Field & " as '" & ID_Name & "', family_name as 'Family Name', middle_name as 'Middle Name', given_name as 'Given Name', gender as 'Gender', email as 'Email', account_type as 'Account Type' from " & Table_Name & ", account, account_type where account.account_type_id = account_type.account_type_id and account.user_name = " & Table_Name & "." & ID_Field & " and " & ID_Field & " = '" & ID & "'", cnn)
            dr = cmd.ExecuteReader
            DtpfvwUserProfile.DataSource = dr
            DtpfvwUserProfile.DataBind()
        Catch ex As Exception
            Response.Write(ex)
            cnn.Close()
        End Try
        cnn.Close()
    End Sub

    Protected Sub btnEditProfile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEditProfile.Click
        'Edit Profile button is clicked
        Response.Redirect("EditProfile.aspx")
    End Sub

    Protected Sub btnChangePassword_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnChangePassword.Click
        'Change Password button is clicked
        Response.Redirect("ChangePassword.aspx")
    End Sub

End Class