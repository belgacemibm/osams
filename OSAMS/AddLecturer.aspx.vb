'------------------------------------------------------------ 
'File Name          :AddLecturer.vb
' Description       :Indicate the process of add new lecturer to OSAMS system
' Function List     : add lecturer

'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
'    ------------------------------------------------------------ 
' 17/04/2012   Nguyen Tran Dang Khoa     Add Lecturer
'------------------------------------------------------------ 

Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.SqlClient
Public Class AddLecturer
    Inherits System.Web.UI.Page

    ' define sql command
    Private nonqueryCommand As SqlCommand
    Private selectqueryCommand, selectAdminCommand As SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '------------------------------------------------------------ 
        ' Aim           : validate session for each type of users
        '               : set the message back to red color  
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : 
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            :     

        If (Session("Rememberme") = "false") Then
            If PB.getAccountType(Session("ID")) = "1" Or PB.getAccountType(Session("ID")) = "2" Then
                If Not Page.IsPostBack Then
                    lblError.ForeColor = System.Drawing.Color.Red
                Else
                    lblError.ForeColor = System.Drawing.Color.Red
                End If
            Else
                Response.Redirect("Home.aspx")
            End If
        Else
            If PB.getAccountType(Request.Cookies("ID").Value) = "1" Or PB.getAccountType(Request.Cookies("ID").Value) = "2" Then
                If Not Page.IsPostBack Then
                    lblError.ForeColor = System.Drawing.Color.Red
                Else
                    lblError.ForeColor = System.Drawing.Color.Red
                End If
            Else
                Response.Redirect("Home.aspx")
            End If
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        'Cancel will back to Lecturer page
        Response.Redirect("Lecturer.aspx")
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        '------------------------------------------------------------ 
        ' Aim           : Add new lecturer into OSAMS system       
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : lecturer_id, family_name, middle_name, given_name, gender, email, active
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            :  


        ' Connect Database
        Dim connection As New SqlConnection(PB.getConnectionString())
        ' Open connection
        connection.Open()
        ' Declare lecturer ID, family name, middle name, given name, gender, mail, role
        Dim lecturerID As String = txtLecturerID.Text
        Dim lecturerFamilyName As String = txtFamilyName.Text
        Dim lecturerMiddleName As String = txtMiddleName.Text
        Dim lecturerGivenName As String = txtGivenName.Text
        Dim lecturerGender As String = ddlGender.Text
        Dim lecturerMail As String = lecturerID + "@rmit.edu.vn"
        Dim lecturerRole As String = ddlRole.SelectedValue

        Dim count As Integer
        Dim countAdmin As Integer

        ' Create INSERT statement with named parameters
        Dim sql As String

        sql = " INSERT  INTO account (user_name, password, active, account_type_id) VALUES('" + lecturerID + "', '1234', 1, " + lecturerRole + ")"
        sql = sql + "INSERT  INTO lecturer (lecturer_id, family_name, middle_name, given_name, gender, email, active) VALUES ('" & lecturerID & "','" & lecturerFamilyName & "','" & lecturerMiddleName & "','" & lecturerGivenName & "','" & lecturerGender & "','" & lecturerMail & "','" & "1" & "')"

        ' Create INSERT statement with named parameters
        Dim str As String = "select count (*) name from lecturer where lecturer_id = '" + lecturerID & "'"
        Dim strAdmin As String = "select count (*) name from [admin] where staff_id = '" + lecturerID & "'"

        selectqueryCommand = New SqlCommand(str, connection)
        selectAdminCommand = New SqlCommand(strAdmin, connection)
        
        'validate duplidate lecturer ID
        count = Convert.ToInt32(selectqueryCommand.ExecuteScalar)
        countAdmin = Convert.ToInt32(selectAdminCommand.ExecuteScalar)

        If (count > 0) Then
            lblError.Text = "Error: The lecturer ID has been existed"
        Else
            'validate conflict admin ID
            If (countAdmin > 0) Then
                lblError.Text = "Error: The lecturer ID is conflicted with admin ID"
            Else
                Dim a As Boolean
                'Execute query
                a = PB.runquery(sql)
                If a = True Then
                    'Display confirm message
                    lblError.ForeColor = System.Drawing.Color.Black
                    lblError.Text = "Lecturer " + lecturerID + " has been created"

                    'Clear textbox
                    txtLecturerID.Text = ""
                    txtFamilyName.Text = ""
                    txtMiddleName.Text = ""
                    txtGivenName.Text = ""
                End If
            End If
        End If
        ' Close Connection
        connection.Close()
    End Sub
End Class