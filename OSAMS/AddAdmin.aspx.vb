'------------------------------------------------------------ 
'File Name          :AddAdmin.vb
' Description       :Indicate the process of add admin to system
' Function List     : add admin

'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
'    ------------------------------------------------------------ 
' 17/04/2012   Nguyen Tran Dang Khoa     Add Course
'------------------------------------------------------------ 
Imports System.Data.SqlClient

Public Class AddAdmin
    Inherits System.Web.UI.Page
    ' define sql command 
    Private nonqueryCommand As SqlCommand
    Private selectqueryCommand As SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '------------------------------------------------------------ 
        ' Aim           : validate session for each type of users
        '               : set the message back to red color            
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : ID, error text
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            :   type of ID
        If (Session("Rememberme") = "false") Then
            If PB.getAccountType(Session("ID")) = "1" Then
                If Not Page.IsPostBack Then
                    lblError.ForeColor = System.Drawing.Color.Red
                Else
                    lblError.ForeColor = System.Drawing.Color.Red
                End If
            Else
                Response.Redirect("Home.aspx")
            End If
        Else
            If PB.getAccountType(Request.Cookies("ID").Value) = "1" Then
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

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        '------------------------------------------------------------ 
        ' Aim           : add new admin to OSAMS system
        '               
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : admin ID, family name, middle name, given name, gender, email, password, account type
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            :  


        ' Connect Database
        Dim connection As New SqlConnection(PB.getConnectionString())
        ' Open connection
        connection.Open()
        ' Declare staff ID, family name, middle name, given, gender, email
        Dim staffID As String = txtStaffID.Text
        Dim staffFamilyName As String = txtFamilyName.Text
        Dim staffMiddleName As String = txtMiddleName.Text
        Dim staffGivenName As String = txtGivenName.Text
        Dim staffGender As String = ddlGender.Text
        Dim staffMail As String = staffID + "@rmit.edu.vn"

        Dim count As Integer

        ' Create INSERT statement with named parameters

        Dim sql As String
        sql = " INSERT  INTO account (user_name, password, active, account_type_id) VALUES('" + staffID + "', '1234', 1, '2')"

        sql = sql + "INSERT  INTO admin (staff_id, family_name, middle_name, given_name, gender, email, active) VALUES ('" & staffID & "','" & staffFamilyName & "','" & staffMiddleName & "','" & staffGivenName & "','" & staffGender & "','" & staffMail & "','" & "1" & "')"
        
        ' Create INSERT statement with named parameters
        Dim str As String = "select count (*) name from admin where staff_id = '" + staffID & "'"
        selectqueryCommand = New SqlCommand(str, connection)

        
                        'validate duplidate lecturer ID
                        count = Convert.ToInt32(selectqueryCommand.ExecuteScalar)

                        If (count > 0) Then
                            lblError.Text = "Error: The admin ID has been existed"
                        Else
                            Dim a As Boolean
                            'Execute query
                            a = PB.runquery(sql)
                            If a = True Then
                                'Display confirm message
                lblError.ForeColor = System.Drawing.Color.Green
                lblError.Text = "Admin " + staffID + " has been added"

                                'clear textbox
                                txtStaffID.Text = ""
                                txtFamilyName.Text = ""
                                txtMiddleName.Text = ""
                                txtGivenName.Text = ""
                            End If
                        End If
              
        ' Close Connection
        connection.Close()
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        'Cancel will back to Admin page 
        Response.Redirect("Admin.aspx")
    End Sub
End Class