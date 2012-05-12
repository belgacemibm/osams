'------------------------------------------------------------ 
'File Name          :AddCourse.vb
' Description       :Indicate the process of add course to semester
' Function List     : add course

'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
'    ------------------------------------------------------------ 
' 17/04/2012   Nguyen Tran Dang Khoa     Add Course
'------------------------------------------------------------ 

Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.SqlClient
Public Class AddCourse
    Inherits System.Web.UI.Page
    ' Connect Database  
    Dim connection As New SqlConnection(PB.getConnectionString())
    ' define the sql command
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

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        '------------------------------------------------------------ 
        ' Aim           : Save new course into OSAMS system
        '                          
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : course_id, course_name, credit, level  
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            :   

        ' Open Connection
        connection.Open()
        'Declare course ID, course Name, Credit and Level
        Dim courseID As String = txtCourseID.Text
        Dim courseName As String = txtCourseName.Text
        Dim courseCredit As Integer = ddlCredit.SelectedValue
        Dim courseLevel As String = ddlLevel.Text

        Dim count As Integer

        ' create a new SqlConnection object with the appropriate connection string 
        Dim str As String = "select count (*) name from course where course_id = '" + courseID & "'"
        ' Connect sql
        selectqueryCommand = New SqlCommand(str, connection)



        'validate duplicate course
        count = Convert.ToInt32(selectqueryCommand.ExecuteScalar)

        If (count > 0) Then
            lblError.Text = "Error: The course has been existed"
        Else
            ' Create INSERT statement with named  and execute query
            nonqueryCommand = New SqlCommand("INSERT  INTO course (course_id, course_name, credit, level, active) VALUES ('" & courseID.ToUpper & "','" & courseName & "','" & courseCredit & "','" & courseLevel & "','" & "1" & "')", connection)
            nonqueryCommand.ExecuteNonQuery()
            'display confirm message 
            lblError.ForeColor = System.Drawing.Color.Green
            lblError.Text = " The course " + courseName + " has been added"

            'clear textbox
            txtCourseID.Text = ""
            txtCourseName.Text = ""
            ' Close Connection
            connection.Close()
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        ' Cancel will back to course page
        Response.Redirect("Course.aspx")
    End Sub
    

End Class