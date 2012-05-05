'------------------------------------------------------------ 
' File Name         :EditProfile.aspx.vb
' Description       :Edit Profile details
' Function List     :Page_Load
'                    btnCancel_Click
'                    Load_Page_NotRememberMe
'                    Load_Page_RememberMe
'                    getInfo
'                    btnSave_Click
'                    updateProfileDetails
' Date Created      : 28/03/2012
' Created By        : Vo Ngoc Diep
'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
' 16/4/2012    Vo Ngoc Diep       Adding comments
'------------------------------------------------------------ 

Imports System.Data.SqlClient
Public Class EditProfile
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
            getInfo("staff_id", "admin", Session("ID"))
        End If
        If PB.getAccountType(Session("ID")) = "3" Or PB.getAccountType(Session("ID")) = "4" Then
            getInfo("lecturer_id", "lecturer", Session("ID"))
        End If
        If PB.getAccountType(Session("ID")) = "5" Then
            getInfo("student_id", "student", Session("ID"))
        End If
    End Sub

    Private Sub Load_Page_RememberMe()
        'Load the page with remember password
        If PB.getAccountType(Request.Cookies("ID").Value) = "1" Or PB.getAccountType(Request.Cookies("ID").Value) = "2" Then
            getInfo("staff_id", "admin", Request.Cookies("ID").Value)
        End If
        If PB.getAccountType(Request.Cookies("ID").Value) = "3" Or PB.getAccountType(Request.Cookies("ID").Value) = "4" Then
            getInfo("lecturer_id", "lecturer", Request.Cookies("ID").Value)
        End If
        If PB.getAccountType(Request.Cookies("ID").Value) = "5" Then
            getInfo("student_id", "student", Request.Cookies("ID").Value)
        End If
    End Sub

    Private Sub getInfo(ByVal ID_Field As String, ByVal Table_Name As String, ByVal ID As String)
        'Get User info and fill in controls
        Dim cnn As SqlConnection
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        Dim str As String

        str = PB.getConnectionString()

        cnn = New SqlConnection(str)
        Try
            cnn.Open()
            cmd = New SqlCommand("Select " & ID_Field & ", family_name, middle_name, given_name, gender, email from " & Table_Name & " where " & ID_Field & " = '" & ID & "'", cnn)
            dr = cmd.ExecuteReader
            While dr.Read
                tbxID.Text = dr(ID_Field)
                tbxFamilyName.Text = dr("family_name")
                tbxMiddleName.Text = dr("middle_name")
                tbxGivenName.Text = dr("given_name")
                ddlGender.Text = dr("gender")
                tbxEmail.Text = dr("email")
            End While
        Catch ex As Exception
            Response.Write(ex)
            cnn.Close()
        End Try
        cnn.Close()
    End Sub

    Private Sub updateProfileDetails(ByVal ID_Field As String, ByVal Table_Name As String, ByVal ID As String)
        'Update Profile details
        Dim cnn As SqlConnection
        Dim cmd As SqlCommand

        Dim str As String

        str = PB.getConnectionString()

        cnn = New SqlConnection(str)
        Try
            cnn.Open()
            cmd = New SqlCommand("Update " & Table_Name & " SET family_name = '" & tbxFamilyName.Text & "', middle_name = '" & tbxMiddleName.Text & "', given_name = '" & tbxGivenName.Text & "', gender = '" & ddlGender.Text & "', email = '" & tbxEmail.Text & "' where " & ID_Field & " = '" & ID & "'", cnn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Response.Write(ex)
            cnn.Close()
        End Try
        cnn.Close()
    End Sub

    Private Sub updateWithCookie()
        'Update Profile details with cookie
        If PB.getAccountType(Request.Cookies("ID").Value) = "1" Or PB.getAccountType(Request.Cookies("ID").Value) = "2" Then
            updateProfileDetails("staff_id", "admin", Request.Cookies("ID").Value)
        End If
        If PB.getAccountType(Request.Cookies("ID").Value) = "3" Or PB.getAccountType(Request.Cookies("ID").Value) = "4" Then
            updateProfileDetails("lecturer_id", "lecturer", Request.Cookies("ID").Value)
        End If
        If PB.getAccountType(Request.Cookies("ID").Value) = "5" Then
            updateProfileDetails("student_id", "student", Request.Cookies("ID").Value)
        End If
        Response.Redirect("Profile.aspx")
    End Sub

    Private Sub updateWithSession()
        'Update Profile details with session
        If PB.getAccountType(Session("ID")) = "1" Or PB.getAccountType(Session("ID")) = "2" Then
            updateProfileDetails("staff_id", "admin", Session("ID"))
        End If
        If PB.getAccountType(Session("ID")) = "3" Or PB.getAccountType(Session("ID")) = "4" Then
            updateProfileDetails("lecturer_id", "lecturer", Session("ID"))
        End If
        If PB.getAccountType(Session("ID")) = "5" Then
            updateProfileDetails("student_id", "student", Session("ID"))
        End If
        Response.Redirect("Profile.aspx")
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        'Cancel button is clicked
        Response.Redirect("Profile.aspx")
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        'Save button is clicked
        If (Session("Rememberme") = "false") Then
            updateWithSession()
        Else
            updateWithCookie()
        End If
    End Sub

End Class