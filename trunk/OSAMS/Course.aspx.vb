'------------------------------------------------------------ 
'File Name          :course.vb
' Description       :Indicate the process of add semester
' Function List     : edit group
'                   : find group
'                   : row databound
'                   : row editing
'                   : row updating
'                   : row cancel editing
'                   : find ()
'                   : bind_data()
'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
'    ------------------------------------------------------------ 
' 17/04/2012   Nguyen Tran Dang Khoa     Course
'------------------------------------------------------------ 
Imports System.Data.SqlClient

Public Class Course

    Inherits System.Web.UI.Page
    'declare position credit, level
    Private currentCredit, currentLevel As String
    ' define sql command
    Private nonqueryCommand As SqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '------------------------------------------------------------ 
        ' Aim           : validate session for each type of users
        '               : set the message back to red color    
        '               : bind data into gridview
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
                    bind_data()
                    lblMessage.ForeColor = System.Drawing.Color.Red
                    lblMessage.Text = ""
                Else
                    lblMessage.ForeColor = System.Drawing.Color.Red
                    lblMessage.Text = ""
                End If
            Else
                Response.Redirect("Home.aspx")
            End If
        Else
            If PB.getAccountType(Request.Cookies("ID").Value) = "1" Or PB.getAccountType(Request.Cookies("ID").Value) = "2" Then
                If Not Page.IsPostBack Then
                    bind_data()
                    lblMessage.ForeColor = System.Drawing.Color.Red
                    lblMessage.Text = ""
                Else
                    lblMessage.ForeColor = System.Drawing.Color.Red
                    lblMessage.Text = ""
                End If
            Else
                Response.Redirect("Home.aspx")
            End If
        End If
    End Sub

    Protected Sub btnAddNewCourse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddNewCourse.Click
        'direct to add couse page
        Response.Redirect("AddCourse.aspx")

    End Sub
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdvwCourse.RowDataBound
        '------------------------------------------------------------ 
        ' Aim           : Row Databound
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : dropdownlist Credit, Level
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            : value of Credit, Level

        If (e.Row.RowState And DataControlRowState.Edit) =
        DataControlRowState.Edit Then
            If e.Row.RowType = DataControlRowType.DataRow Then

                Dim i As Integer
                'Define list item and dropdownlist
                Dim z As ListItem
                Dim dd As DropDownList
                Dim ee As DropDownList

                'Find control
                dd = e.Row.FindControl("ddlCredit")
                ee = e.Row.FindControl("ddlLevel")

                ' Add number into dropdownlist
                For i = 1 To 12
                    z = New ListItem(i)

                    dd.Items.Add(z.ToString)

                Next

                'Add item Level in dropdownlist
                ee.Items.Add("Bachelor")
                ee.Items.Add("Diploma")
                ee.Items.Add("Master")

                'Get current position of credit, level
                If currentCredit IsNot Nothing Then
                    dd.Items.FindByValue(currentCredit).Selected = True
                End If
                If currentLevel IsNot Nothing Then
                    ee.Items.FindByValue(currentLevel).Selected = True
                End If
            End If
        End If
    End Sub

    Protected Sub grdvwCourse_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdvwCourse.RowUpdating
        '------------------------------------------------------------ 
        ' Aim           : Update student
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : course_id, course_name, credit
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            : 


        'get connection
        Dim connection As New SqlConnection(PB.getConnectionString())
        'declare variables
        Dim active As Integer
        Dim credit, level As String
        'declare textbox, dropdownlist control 
        Dim row As GridViewRow = DirectCast(grdvwCourse.Rows(e.RowIndex), GridViewRow)
        Dim course_id As Label = DirectCast(row.FindControl("course_id"), Label)
        Dim course_name As TextBox = DirectCast(row.FindControl("course_name"), TextBox)


        Dim creditDDL As DropDownList = TryCast(row.FindControl("ddlCredit"), DropDownList)
        credit = creditDDL.SelectedValue



        Dim levelDDL As DropDownList = TryCast(row.FindControl("ddlLevel"), DropDownList)
        level = levelDDL.SelectedValue


        active = 1



        'validate blank fields
        If course_name.Text = "" Then

            lblMessage.Text = "Error: Course Name must not be blank"
            e.Cancel = True
        Else
            lblMessage.Text = ""

            grdvwCourse.EditIndex = -1

            'open connection
            connection.Open()

            'declare update query
            Dim sqlStatement As String = "UPDATE [course] SET [course_name] = '" & course_name.Text & "', [credit] = '" & credit & "', [level] = '" & level & "', [active] = '1' WHERE [course_id] = '" & course_id.Text & "' AND [active]= '1'"


            Try
                'connect query
                Dim cmd2 As New SqlCommand(sqlStatement, connection)



                'use command type
                cmd2.CommandType = CommandType.Text

                'execute query
                cmd2.ExecuteNonQuery()


            Catch ex As System.Data.SqlClient.SqlException
                Dim msg As String = "Insert/Update Error:"
                msg += ex.Message
                Throw New Exception(msg)
            Finally
                'close(connection)
                connection.Close()
                'bind(database)
                bind_data()
                'bind find database
                find()

            End Try
        End If

    End Sub

    Protected Sub grdvwCourse_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdvwCourse.RowEditing
        '------------------------------------------------------------ 
        ' Aim           : Row Editing
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : credit, level
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            :

        'declare variable
        Dim credit As String
        Dim level As String
        'find control credit, level
        credit = TryCast(grdvwCourse.Rows(e.NewEditIndex).FindControl("lblCredit"), Label).Text
        level = TryCast(grdvwCourse.Rows(e.NewEditIndex).FindControl("lblLevel"), Label).Text

        'current value
        currentCredit = credit
        currentLevel = level

        grdvwCourse.EditIndex = e.NewEditIndex

        'bind database
        bind_data()
        'bind find database
        find()


    End Sub

    Protected Sub grdvwCourse_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdvwCourse.RowCancelingEdit
        '------------------------------------------------------------ 
        ' Aim           : Row Cancel editing
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : credit, level
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            :

        'Set index of gridview
        grdvwCourse.EditIndex = -1
        'bind database
        bind_data()
        'bind find database
        find()
        ' Set blank error message
        lblMessage.Text = ""
    End Sub

    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFind.Click
        '------------------------------------------------------------ 
        ' Aim           : Find course
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : course_id, course_name, level, credit
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            :

        ' Sql find course
        Dim findStr As String = "select * from course where course_id like '%" & txtSearch.Text & "%' or course_name like '%" & txtSearch.Text & "%' or credit like '%" & txtSearch.Text & "%' or [level] like '%" & txtSearch.Text & "%'"
        'Declare connection string, sql command
        Dim strConn As String
        strConn = PB.getConnectionString()
        Dim connection As New SqlConnection(strConn)
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        Try
            'Open connection
            connection.Open()

            ' Initialize the SqlCommand with the new SQL string.
            cmd = New SqlCommand(findStr, connection)
            dr = cmd.ExecuteReader()
            If (dr.HasRows) Then
                'Disallow paging and bind data into datasource
                grdvwCourse.AllowPaging = False
                grdvwCourse.DataSource = dr
                grdvwCourse.DataBind()

            Else
                'Allow paging and bind data into datasource
                grdvwCourse.AllowPaging = True
                lblMessage.ForeColor = System.Drawing.Color.Black
                lblMessage.Text = "No course found"
            End If
            'close connection
            connection.Close()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
    Public Sub bind_data()
        '------------------------------------------------------------ 
        ' Aim           : Bind database
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : credit, level
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            :

        Dim loadStr As String = "select course_id, course_name, credit, [level] from course "
        Dim ds As New DataSet()
        'get connection
        Dim connection As New SqlConnection(PB.getConnectionString())
        Try
            'open connection
            connection.Open()
            'execute query
            Dim cmd As New SqlCommand(loadStr, connection)
            Dim sqlDa As New SqlDataAdapter(cmd)

            'fill database
            sqlDa.Fill(ds)

            grdvwCourse.DataSource = ds.Tables(0)
            grdvwCourse.DataBind()

        Catch ex As System.Data.SqlClient.SqlException
            Dim msg As String = "Fetch Error:"
            msg += ex.Message
            Throw New Exception(msg)
        Finally
            'close connection
            connection.Close()
        End Try
    End Sub
    Public Sub find()
        '------------------------------------------------------------ 
        ' Aim           : bind find data
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

        ' find course query
        Dim findStr As String = "select * from course where course_id like '%" & txtSearch.Text & "%' or course_name like '%" & txtSearch.Text & "%' or credit like '%" & txtSearch.Text & "%' or [level] like '%" & txtSearch.Text & "%'"
        ' declare connectionstring, sql command and sql datareader
        Dim strConn As String
        strConn = PB.getConnectionString()
        Dim connection As New SqlConnection(strConn)
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        Try
            ' open connection
            connection.Open()

            ' Initialize the SqlCommand with the new SQL string.
            cmd = New SqlCommand(findStr, connection)
            dr = cmd.ExecuteReader()
            If (dr.HasRows) Then
                ' disallow page
                grdvwCourse.AllowPaging = False
                'bind database into datasource
                grdvwCourse.DataSource = dr
                grdvwCourse.DataBind()

            Else
                'allow page and display message
                grdvwCourse.AllowPaging = True
                lblMessage.Text = "No data found"
            End If
            'close connection
            connection.Close()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClear.Click
        '------------------------------------------------------------ 
        ' Aim           : clear database
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : search textbox
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            : reload data

        'clear search textbox
        txtSearch.Text = ""
        'bind find data
        find()
    End Sub
End Class