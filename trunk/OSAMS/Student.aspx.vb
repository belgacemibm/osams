'------------------------------------------------------------ 
'File Name          :Student.vb
' Description       :Indicate the process of add semester
' Function List     : 

'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
'    ------------------------------------------------------------ 
' 17/04/2012   Nguyen Tran Dang Khoa     Student
'------------------------------------------------------------ 
Imports System.Data.SqlClient

Public Class Student
    Inherits System.Web.UI.Page
    'declare connection

    Dim ds As New DataSet()

    'declare variables
    Private currentGroupName, currentGender, currentStream, currentProgram As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("Rememberme") = "false") Then
            If PB.getAccountType(Session("ID")) = "1" Or PB.getAccountType(Session("ID")) = "2" Then
                'bind database
                If Not IsPostBack Then
                    bind()
                    load_dropdownlist()

                    lblError.ForeColor = System.Drawing.Color.Red
                    lblError.Text = ""
                Else
                    lblError.ForeColor = System.Drawing.Color.Red
                    lblError.Text = ""
                End If

                If ddlSemester.SelectedValue = "None" Then
                    ddlCourse.Enabled = False
                Else
                    ddlCourse.Enabled = True

                End If
            Else
                Response.Redirect("Home.aspx")
            End If
        Else
            If PB.getAccountType(Request.Cookies("ID").Value) = "1" Or PB.getAccountType(Request.Cookies("ID").Value) = "2" Then
                'bind database
                If Not IsPostBack Then
                    bind()
                    load_dropdownlist()

                    lblError.ForeColor = System.Drawing.Color.Red
                    lblError.Text = ""
                Else
                    lblError.ForeColor = System.Drawing.Color.Red
                    lblError.Text = ""
                End If

                If ddlSemester.SelectedValue = "None" Then
                    ddlCourse.Enabled = False
                Else
                    ddlCourse.Enabled = True

                End If
            Else
                Response.Redirect("Home.aspx")
            End If
        End If
    End Sub

    Protected Sub btnAddNewStudent_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddNewStudent.Click
        'direct to add student page
        Response.Redirect("AddStudent.aspx")

    End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShow.Click
        '------------------------------------------------------------ 
        ' Aim           : Add student
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : student_id, family_name, middle_name, given_name, gender, mail, program, stream, semester, course, group
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            : 


        'get connection
        Dim connection As New SqlConnection(PB.getConnectionString())



        Try
            'open connection
            connection.Open()
            'select query
            Dim sqlGeneralStatement As String = "select distinct [student].student_id, [student].family_name,[student].middle_name, [student].given_name, [student].gender, [student].email, [student].program, [student].stream, [student_group].active, [group].group_name, [account].password from student, [group], student_group, course, account" & _
                " WHERE [student].student_id = [student_group].student_id" & _
                " AND [student_group].group_id = [group].group_id" & _
                " AND [group].course_id = course.course_id" & _
                " AND [group].semester_name = '" + ddlSemester.Text + "'" & _
                " AND [course].course_id = '" + ddlCourse.Text + "'" & _
                " AND [student_group].active = 1" & _
                "AND [student].student_id = [account].[user_name]"


            Dim sqlNoneStatement As String = "SELECT distinct [student].student_id, [student].family_name,[student].middle_name, [student].given_name, [student].gender, [student].email, [student].program, [student].stream, [account].password FROM student inner join [account] on [student].student_id = [account].[user_name] WHERE NOT EXISTS (select student_group.active from [student_group] where student_group.student_id = student.student_id and student_group.active = '1' )"

            If ddlSemester.SelectedValue = "None" Then
                grdvwNoneStudent.Visible = True
                grdvwStudent.Visible = False

                'execute query
                Dim cmd As New SqlCommand(sqlNoneStatement, connection)
                Dim sqlDa As New SqlDataAdapter(cmd)

                'fill database
                sqlDa.Fill(ds)

                If ds.Tables(0).Rows.Count = 0 Then
                    lblError.Text = "No student found"
                    grdvwNoneStudent.DataSource = ""
                    grdvwNoneStudent.DataBind()
                Else
                    lblError.Text = ""
                    grdvwNoneStudent.DataSource = ds.Tables(0)
                    grdvwNoneStudent.DataBind()
                End If

            Else
                grdvwNoneStudent.Visible = False
                grdvwStudent.Visible = True
                'execute query
                Dim cmd As New SqlCommand(sqlGeneralStatement, connection)
                Dim sqlDa As New SqlDataAdapter(cmd)

                'fill database
                sqlDa.Fill(ds)

                If ds.Tables(0).Rows.Count = 0 Then
                    lblError.Text = "No student found"
                    grdvwStudent.DataSource = ""
                    grdvwStudent.DataBind()
                Else
                    lblError.Text = ""
                    grdvwStudent.DataSource = ds.Tables(0)
                    grdvwStudent.DataBind()
                End If

            End If

        Catch ex As System.Data.SqlClient.SqlException
            Dim msg As String = "Fetch Error:"
            msg += ex.Message
            Throw New Exception(msg)
        Finally
            'close connection
            connection.Close()
        End Try
    End Sub
    Protected Sub grdvwStudent_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdvwStudent.RowUpdating
        '------------------------------------------------------------ 
        ' Aim           : Update student
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : student_id, family_name, middle_name, given_name, gender, mail, program, stream, semester, course, group
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            : 


        'get connection
        Dim connection As New SqlConnection(PB.getConnectionString())
        'declare variables
        Dim active As Integer
        Dim gender, stream, program As String
        'declare textbox, dropdownlist control 
        Dim row As GridViewRow = DirectCast(grdvwStudent.Rows(e.RowIndex), GridViewRow)
        Dim student_id As Label = DirectCast(row.FindControl("student_id"), Label)
        Dim family_name As TextBox = DirectCast(row.FindControl("family_name"), TextBox)
        Dim middle_name As TextBox = DirectCast(row.FindControl("middle_name"), TextBox)
        Dim given_name As TextBox = DirectCast(row.FindControl("given_name"), TextBox)

        Dim genderDDL As DropDownList = TryCast(row.FindControl("ddlGender"), DropDownList)
        gender = genderDDL.SelectedValue

        Dim email As TextBox = DirectCast(row.FindControl("email"), TextBox)

        Dim programDDL As DropDownList = TryCast(row.FindControl("ddlProgram"), DropDownList)
        program = programDDL.SelectedValue

        Dim streamDDL As DropDownList = TryCast(row.FindControl("ddlStream"), DropDownList)
        stream = streamDDL.SelectedValue


        Dim group_nameDDL As DropDownList = TryCast(row.FindControl("ddlGroup_name"), DropDownList)

        active = 1

        Dim password As TextBox = DirectCast(row.FindControl("password"), TextBox)

        Dim semesterSqlStatement As String = "SELECT [end_date] FROM [semester] WHERE [semester].semester_name = '" & ddlSemester.SelectedValue & "'"
      
        Dim strDate As String = String.Empty

        Dim cmd As New SqlCommand(semesterSqlStatement, connection)

        Dim strEmail = "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"

        Dim myRegex As New Regex(strEmail)

        
        'open connection
        connection.Open()
        Using reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                For i As Integer = 0 To reader.FieldCount - 1

                    strDate = reader.GetValue(i)

                Next

            End While

        End Using

        If strDate < Today Then
            e.Cancel = True
            lblError.Text = "Error: You cannot modify last semester"
        Else
            If family_name.Text = "" Or given_name.Text = "" Or email.Text = "" Or password.Text = "" Then

                lblError.Text = "Error: Family Name, Given Name, Email and Password must not be blank"
                e.Cancel = True
            Else
                If Not myRegex.IsMatch(email.Text) Then
                    lblError.Text = "Error: Email is not correct format"
                    e.Cancel = True
                Else
                    lblError.Text = ""

                    grdvwStudent.EditIndex = -1



                    'declare select query
                    Dim selectSqlStatement As String = "select [student_group].group_id FROM  student_group inner join [group] on student_group.group_id = [group].group_id where [student_group].student_id = '" + student_id.Text & "' AND [group].course_id = '" + ddlCourse.SelectedValue & "' AND [student_group].active = 1 "

                    Dim selectGroupnameStatement As String = "select group_id from [group] where course_id = '" + ddlCourse.SelectedValue & "' and group_name ='" + group_nameDDL.SelectedValue & "' and semester_name = '" + ddlSemester.SelectedValue & "'"
                    'declare update query
                    Dim sqlStatement As String = "UPDATE student SET family_name = '" + family_name.Text & "' , middle_name = '" + middle_name.Text & "', given_name = '" + given_name.Text & "', gender = '" + gender & "', email = '" + email.Text & "', program = '" + program & "', stream = '" + stream & "', active = '1' WHERE student_id = '" + student_id.Text & "'"

                    Dim updateSqlStatement As String = "UPDATE [student_group] SET [student_group].active = '0' WHERE student_id = '" + student_id.Text & "' AND [student_group].group_id = @current_group_ID "
                    updateSqlStatement = updateSqlStatement + "update [group] set number_of_student = number_of_student - 1 where group_id = @current_group_ID and course_id ='" & ddlCourse.SelectedValue & "' and semester_name ='" & ddlSemester.SelectedValue & "'"

                    Dim updateStatusSqlStatement As String = "UPDATE [student_group] SET [student_group].active = '1' WHERE student_id = '" + student_id.Text & "' AND [student_group].group_id = @group_ID "
                    updateStatusSqlStatement = updateStatusSqlStatement + "update [group] set number_of_student = number_of_student + 1 where group_id = @group_ID and course_id ='" & ddlCourse.SelectedValue & "' and semester_name ='" & ddlSemester.SelectedValue & "'"

                    Dim insertSqlStatement As String = "INSERT INTO student_group (grade, result, comment, active, group_id, student_id) VALUES  ('','','',1, @group_ID ,'" & student_id.Text & "')"
                    insertSqlStatement = insertSqlStatement + "update [group] set number_of_student = number_of_student + 1 where group_id = @group_ID and course_id ='" & ddlCourse.SelectedValue & "' and semester_name ='" & ddlSemester.SelectedValue & "'"

                    Dim updateAccountStatement As String = "UPDATE [account] SET [account].password = '" & password.Text & "' , [account].active = 1, [account].account_type_id = 5 WHERE [account].user_name = '" & student_id.Text & "'"


                    'declare variable
                    Dim group_ID As Integer
                    Dim current_group_id As Integer


                    Try
                        'execute query
                        Dim cmd1 As New SqlCommand(selectSqlStatement, connection)
                        Dim cmd4 As New SqlCommand(selectGroupnameStatement, connection)

                        'get current group id
                        Using reader As SqlDataReader = cmd1.ExecuteReader()
                            While reader.Read()
                                For i As Integer = 0 To reader.FieldCount - 1

                                    current_group_id = reader.GetValue(i)

                                Next

                            End While
                        End Using

                        'get current group ID
                        Using reader1 As SqlDataReader = cmd4.ExecuteReader()
                            While reader1.Read()
                                For i As Integer = 0 To reader1.FieldCount - 1

                                    group_ID = reader1.GetValue(i)

                                Next

                            End While
                        End Using

                        'execute quer
                        Dim cmd2 As New SqlCommand(sqlStatement, connection)
                        Dim cmd5 As New SqlCommand(updateAccountStatement, connection)

                        Dim cmd7 As New SqlCommand(updateSqlStatement, connection)
                        cmd7.Parameters.AddWithValue("@current_group_id", current_group_id)
                        cmd7.CommandType = CommandType.Text
                        cmd7.ExecuteNonQuery()

                        Dim extra As Boolean = PB.checkEsixtedData("select student_group_id from student_group where student_id = '" & student_id.Text & "' and group_id= '" & group_ID & "'")
                        If extra = True Then

                            Dim cmd3 As New SqlCommand(updateStatusSqlStatement, connection)
                            cmd3.Parameters.AddWithValue("@group_id", group_ID)
                            cmd3.CommandType = CommandType.Text
                            cmd3.ExecuteNonQuery()

                        Else
                            Dim cmd6 As New SqlCommand(insertSqlStatement, connection)
                            cmd6.Parameters.AddWithValue("@group_id", group_ID)
                            cmd6.CommandType = CommandType.Text
                            cmd6.ExecuteNonQuery()
                        End If


                        'use command type
                        cmd2.CommandType = CommandType.Text
                        cmd5.CommandType = CommandType.Text

                        cmd2.ExecuteNonQuery()
                        cmd5.ExecuteNonQuery()
                        'addAttendance(student_id.Text, group_ID, current_group_id)



                    Catch ex As System.Data.SqlClient.SqlException
                        Dim msg As String = "Insert/Update Error:"
                        msg += ex.Message
                        Throw New Exception(msg)
                    Finally
                        'close(connection)
                        connection.Close()
                        'bind(database)
                        bind()
                    End Try
                End If
        End If
        End If
    End Sub
    Protected Sub grdvwStudent_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdvwStudent.RowEditing
        '------------------------------------------------------------ 
        ' Aim           : Edit student
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : 
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            : 

        'declare variables
        Dim groupName, gender, stream, program As String
        'get find control
        groupName = TryCast(grdvwStudent.Rows(e.NewEditIndex).FindControl("lblGroupName"), Label).Text
        gender = TryCast(grdvwStudent.Rows(e.NewEditIndex).FindControl("lblGender"), Label).Text
        stream = TryCast(grdvwStudent.Rows(e.NewEditIndex).FindControl("lblStream"), Label).Text
        program = TryCast(grdvwStudent.Rows(e.NewEditIndex).FindControl("lblProgram"), Label).Text

        'get current value
        currentGroupName = groupName
        currentGender = gender
        currentStream = stream
        currentProgram = program

        grdvwStudent.EditIndex = e.NewEditIndex

        'bind database
        bind()
    End Sub
    Protected Sub grdvwStudent_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdvwStudent.RowCancelingEdit
        '------------------------------------------------------------ 
        ' Aim           : cancel editing
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : 
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            : 


        ' bind database
        grdvwStudent.EditIndex = -1
        bind()
        lblError.Text = ""
    End Sub
    Public Sub bind()
        '------------------------------------------------------------ 
        ' Aim           : bind database
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : student_id, family_name, middle_name, given_name, gender, mail, program, stream, group_name
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            :


        'get connection
        Dim connection As New SqlConnection(PB.getConnectionString())
        'open connection
        connection.Open()
        'select query
        Dim sqlGeneralStatement As String = "select distinct [student].student_id, [student].family_name,[student].middle_name, [student].given_name, [student].gender, [student].email, [student].program, [student].stream, [student].active, [group].group_name, [account].password from student, [group], student_group, course, account" & _
            " WHERE [student].student_id = [student_group].student_id" & _
            " AND [student_group].group_id = [group].group_id" & _
            " AND [group].course_id = course.course_id" & _
            " AND [group].semester_name = '" + ddlSemester.Text + "'" & _
            " AND [course].course_id = '" + ddlCourse.Text + "'" & _
            " AND [student_group].active ='1'" & _
            "AND [student].student_id = [account].[user_name]"

        'declare onnection
        Dim da As New SqlDataAdapter(sqlGeneralStatement, connection)
        Dim ds As New DataSet()
        'fill data
        da.Fill(ds)
        grdvwStudent.DataSource = ds.Tables(0)
        grdvwStudent.DataBind()
        'close connection
        connection.Close()
    End Sub
    Public Sub bindNonGroup()

        'get connection
        Dim connection As New SqlConnection(PB.getConnectionString())
        'open connection
        connection.Open()

        Dim sqlNoneStatement As String = "SELECT distinct [student].student_id, [student].family_name,[student].middle_name, [student].given_name, [student].gender, [student].email, [student].program, [student].stream, [account].password FROM student inner join [account] on [student].student_id = [account].[user_name] WHERE NOT EXISTS (select student_group.active from [student_group] where student_group.student_id = student.student_id and student_group.active = '1' )"
        'declare onnection
        Dim da As New SqlDataAdapter(sqlNoneStatement, connection)
        Dim ds As New DataSet()
        'fill data
        da.Fill(ds)
        grdvwNoneStudent.DataSource = ds.Tables(0)
        grdvwNoneStudent.DataBind()
        'close connection
        connection.Close()

    End Sub

    Protected Sub grdvwStudent_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdvwStudent.RowDataBound
        '------------------------------------------------------------ 
        ' Aim           : Row Databound
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : 
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            : 

        If (e.Row.RowState And DataControlRowState.Edit) = DataControlRowState.Edit Then
            If e.Row.RowType = DataControlRowType.DataRow Then


                'declare dropdownlist
                Dim dd, ee, ff, zz As DropDownList

                ' Find control
                dd = e.Row.FindControl("ddlGender")
                ee = e.Row.FindControl("ddlGroup_name")
                ff = e.Row.FindControl("ddlProgram")
                zz = e.Row.FindControl("ddlStream")

                ' add gender in dropdownlist
                dd.Items.Add("M")
                dd.Items.Add("F")

                'add stream in dropdownlist
                zz.Items.Add("")
                zz.Items.Add("M")
                zz.Items.Add("F")
                zz.Items.Add("B")

                'add program in dropdownlist
                ff.Items.Add("BP138")
                ff.Items.Add("BP153")
                ff.Items.Add("BP162")
                ff.Items.Add("BP181")
                ff.Items.Add("BP222")
                ff.Items.Add("BP251")
                ff.Items.Add("BP252")
                ff.Items.Add("BP254")
                ff.Items.Add("DP001")
                ff.Items.Add("GC020")
                ff.Items.Add("MC065")
                ff.Items.Add("MC088")
                ff.Items.Add("MC162")
                ff.Items.Add("MC189")

                'declare variables
                Dim ds As DataSet
                Dim sql As String
                Dim items As New ArrayList

                'select query
                sql = "select [group].group_name FROM  [group] where  [group].course_id = '" + ddlCourse.SelectedValue & "' and semester_name = '" + ddlSemester.SelectedValue & "'"

                'get value
                ds = PB.extractData(sql)
                Dim group_name As String
                'put value in dropdownlist
                For Each dr As DataRow In ds.Tables(0).Rows
                    group_name = dr.Item("group_name")
                    items.Add(New CGroup(group_name))
                Next
                'bind database
                ee.DataSource = items
                ee.DataTextField = "group_name"

                ee.DataBind()

                'find current value of group_name
                If currentGroupName IsNot Nothing Then
                    ee.Items.FindByText(currentGroupName).Selected = True
                End If
                'find current value of gender
                If currentGender IsNot Nothing Then
                    dd.Items.FindByValue(currentGender).Selected = True
                End If
                'find current value of stream
                If currentStream IsNot Nothing Then
                    zz.Items.FindByValue(currentStream).Selected = True
                End If
                ' find current value of program
                If currentProgram IsNot Nothing Then
                    ff.Items.FindByValue(currentProgram).Selected = True
                End If

            End If
        End If

    End Sub
    Public Sub load_dropdownlist()
        Dim semesterSqlStatement As String = "SELECT [semester_name], [end_date] FROM [semester]"
        Dim courseSqlStatement As String = "SELECT [course_id], [course_name] FROM [course]"

        Dim item As String

        Dim dtSemester As DataSet
        Dim dtCourse As DataSet

        dtSemester = PB.extractData(semesterSqlStatement)
        dtCourse = PB.extractData(courseSqlStatement)

        ddlCourse.Items.Clear()
        ddlSemester.Items.Clear()
        ddlSemester.Items.Add(New ListItem("None", "None"))
        ddlAssignSemester.Items.Add(New ListItem("Select", "Select"))
        ddlAssignCourse.Items.Add(New ListItem("Select", "Select"))

        For Each dr As DataRow In dtSemester.Tables(0).Rows
            ddlSemester.Items.Add(New ListItem(dr.Item("semester_name"), dr.Item("semester_name")))
            ddlAssignSemester.Items.Add(New ListItem(dr.Item("semester_name"), dr.Item("semester_name")))

        Next

        For Each dr As DataRow In dtCourse.Tables(0).Rows
            item = dr.Item("course_id") + ": " + dr.Item("course_name")
            ddlCourse.Items.Add(New ListItem(item, dr.Item("course_id")))
            ddlAssignCourse.Items.Add(New ListItem(item, dr.Item("course_id")))
        Next

    End Sub

    Protected Sub btnRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRemove.Click
        For Each gvr As GridViewRow In grdvwStudent.Rows
            Dim chk As CheckBox = DirectCast(gvr.FindControl("cbRemove"), CheckBox)
            Dim student_id As Label = DirectCast(gvr.FindControl("student_id"), Label)
            Dim group_name As Label = DirectCast(gvr.FindControl("lblGroupName"), Label)
            'declare variable
            Dim group_ID As Integer

            'get connection
            Dim connection As New SqlConnection(PB.getConnectionString())
            Dim semesterSqlStatement As String = "SELECT [end_date] FROM [semester] WHERE [semester].semester_name = '" & ddlSemester.SelectedValue & "'"

            Dim strDate As String = String.Empty

            Dim cmd3 As New SqlCommand(semesterSqlStatement, connection)


            'open connection
            connection.Open()
            Using reader As SqlDataReader = cmd3.ExecuteReader()
                While reader.Read()
                    For i As Integer = 0 To reader.FieldCount - 1

                        strDate = reader.GetValue(i)

                    Next

                End While

            End Using

            If strDate < Today Then
                lblError.Text = "Error: You cannot modify last semester"
            Else

                If chk.Checked Then
                    Try
                        
                        Dim selectGroupnameStatement As String = "select group_id from [group] where course_id = '" + ddlCourse.SelectedValue & "' and group_name ='" + group_name.Text & "' and semester_name = '" + ddlSemester.SelectedValue & "'"


                        Dim cmd1 As New SqlCommand(selectGroupnameStatement, connection)

                        'get current group ID
                        Using reader1 As SqlDataReader = cmd1.ExecuteReader()
                            While reader1.Read()
                                For i As Integer = 0 To reader1.FieldCount - 1

                                    group_ID = reader1.GetValue(i)

                                Next

                            End While
                        End Using


                        Dim updateSqlStatement As String = "UPDATE [student_group] SET [student_group].active = '0' WHERE student_id = '" + student_id.Text & "' AND group_id = '" & group_ID & "'"
                        updateSqlStatement = updateSqlStatement + "update [group] set number_of_student = number_of_student - 1 where group_id = " & group_ID & " and course_id ='" & ddlCourse.SelectedValue & "' and semester_name ='" & ddlSemester.SelectedValue & "'"


                        'execute query
                        Dim cmd As New SqlCommand(updateSqlStatement, connection)

                        'use command type
                        cmd.CommandType = CommandType.Text

                        cmd.ExecuteNonQuery()


                    Catch ex As System.Data.SqlClient.SqlException
                        Dim msg As String = "Insert/Update Error:"
                        msg += ex.Message
                        Throw New Exception(msg)
                    Finally
                        'close(connection)
                        connection.Close()

                        bind()

                    End Try
                End If
                End If
        Next

    End Sub

    Protected Sub grdvwNoneStudent_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdvwNoneStudent.RowEditing
        'declare variables
        Dim gender, stream, program As String
        'get find control

        gender = TryCast(grdvwNoneStudent.Rows(e.NewEditIndex).FindControl("lblGender"), Label).Text
        stream = TryCast(grdvwNoneStudent.Rows(e.NewEditIndex).FindControl("lblStream"), Label).Text
        program = TryCast(grdvwNoneStudent.Rows(e.NewEditIndex).FindControl("lblProgram"), Label).Text

        'get current value

        currentGender = gender
        currentStream = stream
        currentProgram = program

        grdvwNoneStudent.EditIndex = e.NewEditIndex

        'bind database
        bindNonGroup()

    End Sub

    Protected Sub grdvwNoneStudent_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdvwNoneStudent.RowCancelingEdit
        ' bind database
        grdvwNoneStudent.EditIndex = -1
        bindNonGroup()
        lblError.Text = ""
    End Sub

    Protected Sub grdvwNoneStudent_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdvwNoneStudent.RowDataBound

        If (e.Row.RowState And DataControlRowState.Edit) = DataControlRowState.Edit Then
            If e.Row.RowType = DataControlRowType.DataRow Then


                'declare dropdownlist
                Dim dd, ff, zz As DropDownList

                ' Find control
                dd = e.Row.FindControl("ddlGender")

                ff = e.Row.FindControl("ddlProgram")
                zz = e.Row.FindControl("ddlStream")

                ' add gender in dropdownlist
                dd.Items.Add("M")
                dd.Items.Add("F")

                'add stream in dropdownlist
                zz.Items.Add("")
                zz.Items.Add("M")
                zz.Items.Add("F")
                zz.Items.Add("B")

                'add program in dropdownlist
                ff.Items.Add("BP138")
                ff.Items.Add("BP153")
                ff.Items.Add("BP162")
                ff.Items.Add("BP181")
                ff.Items.Add("BP222")
                ff.Items.Add("BP251")
                ff.Items.Add("BP252")
                ff.Items.Add("BP254")
                ff.Items.Add("DP001")
                ff.Items.Add("GC020")
                ff.Items.Add("MC065")
                ff.Items.Add("MC088")
                ff.Items.Add("MC162")
                ff.Items.Add("MC189")

                'find current value of gender
                If currentGender IsNot Nothing Then
                    dd.Items.FindByValue(currentGender).Selected = True
                End If
                'find current value of stream
                If currentStream IsNot Nothing Then
                    zz.Items.FindByValue(currentStream).Selected = True
                End If
                ' find current value of program
                If currentProgram IsNot Nothing Then
                    ff.Items.FindByValue(currentProgram).Selected = True
                End If

            End If
        End If

    End Sub
    Protected Sub grdvwNoneStudent_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdvwNoneStudent.RowUpdating
        '------------------------------------------------------------ 
        ' Aim           : Update student
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : student_id, family_name, middle_name, given_name, gender, mail, program, stream, semester, course, group
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            : 


        'get connection
        Dim connection As New SqlConnection(PB.getConnectionString())
        'declare variables
        Dim active As Integer
        Dim gender, stream, program As String
        'declare textbox, dropdownlist control 
        Dim row As GridViewRow = DirectCast(grdvwNoneStudent.Rows(e.RowIndex), GridViewRow)
        Dim student_id As Label = DirectCast(row.FindControl("student_id"), Label)
        Dim family_name As TextBox = DirectCast(row.FindControl("family_name"), TextBox)
        Dim middle_name As TextBox = DirectCast(row.FindControl("middle_name"), TextBox)
        Dim given_name As TextBox = DirectCast(row.FindControl("given_name"), TextBox)

        Dim genderDDL As DropDownList = TryCast(row.FindControl("ddlGender"), DropDownList)
        gender = genderDDL.SelectedValue

        Dim email As TextBox = DirectCast(row.FindControl("email"), TextBox)

        Dim programDDL As DropDownList = TryCast(row.FindControl("ddlProgram"), DropDownList)
        program = programDDL.SelectedValue

        Dim streamDDL As DropDownList = TryCast(row.FindControl("ddlStream"), DropDownList)
        stream = streamDDL.SelectedValue

        active = 1


        Dim password As TextBox = DirectCast(row.FindControl("password"), TextBox)

        Dim strEmail = "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"

        Dim myRegex As New Regex(strEmail)

        'validate blank fields
        If family_name.Text = "" Or given_name.Text = "" Or email.Text = "" Or password.Text = "" Then

            lblError.Text = "Error: Family Name, Given Name, Email and Password must not be blank"
            e.Cancel = True
        Else
            If Not myRegex.IsMatch(email.Text) Then
                lblError.Text = "Error: Email is not correct format"
                e.Cancel = True
            Else
                lblError.Text = ""

                grdvwNoneStudent.EditIndex = -1

                'open connection
                connection.Open()

                'declare update query
                Dim sqlStatement As String = "UPDATE student SET family_name = '" + family_name.Text & "' , middle_name = '" + middle_name.Text & "', given_name = '" + given_name.Text & "', gender = '" + gender & "', email = '" + email.Text & "', program = '" + program & "', stream = '" + stream & "', active = '1' WHERE student_id = '" + student_id.Text & "'"

                Dim updateAccountStatement As String = "UPDATE [account] SET [account].password = '" & password.Text & "' , [account].active = 1, [account].account_type_id = 5 WHERE [account].user_name = '" & student_id.Text & "'"

                Try
                    'execute query
                    Dim cmd2 As New SqlCommand(sqlStatement, connection)
                    Dim cmd5 As New SqlCommand(updateAccountStatement, connection)


                    'use command type
                    cmd2.CommandType = CommandType.Text
                    cmd5.CommandType = CommandType.Text

                    cmd2.ExecuteNonQuery()
                    cmd5.ExecuteNonQuery()


                Catch ex As System.Data.SqlClient.SqlException
                    Dim msg As String = "Insert/Update Error:"
                    msg += ex.Message
                    Throw New Exception(msg)
                Finally
                    'close(connection)
                    connection.Close()
                    'bind(database)
                    bindNonGroup()
                End Try
            End If
        End If
    End Sub

    Protected Sub ddlSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlSemester.SelectedIndexChanged
        grdvwNoneStudent.Visible = False
        grdvwStudent.Visible = False
        ddlAssignSemester.SelectedIndex = ddlSemester.SelectedIndex
        ddlAssignCourse.SelectedValue = "Select"
    End Sub

    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlCourse.SelectedIndexChanged
        ddlAssignCourse.SelectedIndex = ddlCourse.SelectedIndex + 1

        '------------------------------------------------------------ 
        ' Aim           : put value in dropdownlist
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : 
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            : 
        'declare variables
        Dim sqlgroup As String
        'clear dropdownlist
        ddlAssignGroup.Items.Clear()
        ' select query
        sqlgroup = "select [group].group_name, [group].group_id FROM  [group] where [group].course_id = '" + ddlAssignCourse.SelectedValue + "' and [group].semester_name = '" + ddlAssignSemester.SelectedValue + "'"
        ' declare dataset
        Dim dsgroup As DataSet
        ' get data
        dsgroup = PB.extractData(sqlgroup)
        ' validate default value
        If ddlAssignCourse.SelectedValue = "Select" Then
            lblError.Text = ""
        Else
            'validate data found
            If dsgroup Is Nothing Then
                lblError.Text = "No group found"
            Else

                lblError.Text = ""
                ' add value in dropdownlist
                For Each dr As DataRow In dsgroup.Tables(0).Rows
                    ddlAssignGroup.Items.Add(New ListItem(dr.Item("group_name"), dr.Item("group_id")))

                Next
            End If
        End If


    End Sub

    Protected Sub ddlAssignCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlAssignCourse.SelectedIndexChanged
        '------------------------------------------------------------ 
        ' Aim           : put value in dropdownlist
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : 
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            : 
        'declare variables
        Dim sqlgroup As String
        'clear dropdownlist
        ddlAssignGroup.Items.Clear()
        ' select query
        sqlgroup = "select [group].group_name, [group].group_id FROM  [group] where [group].course_id = '" + ddlAssignCourse.SelectedValue + "' and [group].semester_name = '" + ddlAssignSemester.SelectedValue + "'"
        ' declare dataset
        Dim dsgroup As DataSet
        ' get data
        dsgroup = PB.extractData(sqlgroup)
        ' validate default value
        If ddlAssignCourse.SelectedValue = "Select" Then
            lblError.Text = ""
        Else
            'validate data found
            If dsgroup Is Nothing Then
                lblError.Text = "No group found"
            Else

                lblError.Text = ""
                ' add value in dropdownlist
                For Each dr As DataRow In dsgroup.Tables(0).Rows
                    ddlAssignGroup.Items.Add(New ListItem(dr.Item("group_name"), dr.Item("group_id")))

                Next
            End If
        End If
    End Sub
    Protected Sub ddlAssignSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlAssignSemester.SelectedIndexChanged
        'clear group dropdownlist
        ddlAssignGroup.Items.Clear()
        'declare default value
        ddlAssignCourse.SelectedValue = "Select"
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Dim selectqueryCommand, countqueryCommand, checkqueryCommand As SqlCommand
        Dim count, countGroup, countStudent As Integer


        ' Get connection
        Dim connection As New SqlConnection(PB.getConnectionString())
        'Open connection

        Dim semesterSqlStatement As String = "SELECT [end_date] FROM [semester] WHERE [semester].semester_name = '" & ddlAssignSemester.SelectedValue & "'"

        Dim strDate As String = String.Empty

        Dim cmdEnd As New SqlCommand(semesterSqlStatement, connection)


        'open connection
        connection.Open()
        Using reader As SqlDataReader = cmdEnd.ExecuteReader()
            While reader.Read()
                For i As Integer = 0 To reader.FieldCount - 1

                    strDate = reader.GetValue(i)

                Next

            End While

        End Using

        
            'Select query
            If txtStudentID.Text = "" Then

                lblError.Text = "Error: Please fulfill student ID"
            Else
                If ddlAssignCourse.SelectedValue = "Select" Or ddlAssignSemester.SelectedValue = "Select" Or ddlAssignGroup.SelectedValue = "" Then
                    lblError.Text = "Error: Please select the course, semester and group"
                Else
                If strDate < Today Then
                    lblError.Text = "Error: You cannot modify last semester"
                Else

                    Dim strStudent As String = "select count (*) name from student where student_id = '" + txtStudentID.Text & "'"

                    Dim str As String = "select count (*) name from student_group where student_id = '" + txtStudentID.Text & "'"

                    Dim groupStr As String = "select count (*) name from student_group where student_id = '" + txtStudentID.Text + "' and group_id ='" + ddlAssignGroup.SelectedValue + "'"

                    Dim activeStr As String = "select count (*) name"

                    Dim updateStatusSqlStatement As String = "UPDATE [student_group] SET [student_group].active = '1' WHERE student_id = '" + txtStudentID.Text & "' AND [student_group].group_id = '" & ddlAssignGroup.SelectedValue & "'"
                    updateStatusSqlStatement = updateStatusSqlStatement + "update [group] set number_of_student = number_of_student + 1 where group_id = " & ddlAssignGroup.SelectedValue & " and course_id ='" & ddlAssignCourse.SelectedValue & "' and semester_name ='" & ddlAssignSemester.SelectedValue & "'"

                    Dim insertSqlStatement As String = "INSERT INTO student_group (grade, result, comment, active, group_id, student_id) VALUES  ('','','','1','" & ddlAssignGroup.SelectedValue & "','" & txtStudentID.Text & "')"
                    insertSqlStatement = insertSqlStatement + "update [group] set number_of_student = number_of_student + 1 where group_id = " & ddlAssignGroup.SelectedValue & " and course_id ='" & ddlAssignCourse.SelectedValue & "' and semester_name ='" & ddlAssignSemester.SelectedValue & "'"

                    'declare select query
                    Dim selectSqlStatement As String = "select [student_group].group_id FROM  student_group inner join [group] on student_group.group_id = [group].group_id where [student_group].student_id = '" + txtStudentID.Text & "' AND [group].course_id = '" + ddlAssignCourse.SelectedValue & "' AND [student_group].active = 1 "

                    Dim selectGroupnameStatement As String = "select group_id from [group] where course_id = '" + ddlAssignCourse.SelectedValue & "' and group_name ='" + ddlAssignGroup.SelectedItem.Text & "' and semester_name = '" + ddlAssignSemester.SelectedValue & "'"

                    Dim updateSqlStatement As String = "UPDATE [student_group] SET [student_group].active = '0' WHERE student_id = '" + txtStudentID.Text & "' AND [student_group].group_id = @current_group_ID "
                    updateSqlStatement = updateSqlStatement + "update [group] set number_of_student = number_of_student - 1 where group_id = @current_group_ID and course_id ='" & ddlAssignCourse.SelectedValue & "' and semester_name ='" & ddlAssignSemester.SelectedValue & "'"

                    'declare variable
                    Dim group_ID As Integer
                    Dim current_group_id As Integer


                    'execute query
                    Dim cmd1 As New SqlCommand(selectSqlStatement, connection)
                    Dim cmd4 As New SqlCommand(selectGroupnameStatement, connection)

                    'get current group id
                    Using reader As SqlDataReader = cmd1.ExecuteReader()
                        While reader.Read()
                            For i As Integer = 0 To reader.FieldCount - 1

                                current_group_id = reader.GetValue(i)

                            Next

                        End While
                    End Using

                    'get current group ID
                    Using reader1 As SqlDataReader = cmd4.ExecuteReader()
                        While reader1.Read()
                            For i As Integer = 0 To reader1.FieldCount - 1

                                group_ID = reader1.GetValue(i)

                            Next

                        End While
                    End Using


                    Dim cmd7 As New SqlCommand(updateSqlStatement, connection)
                    cmd7.Parameters.AddWithValue("@current_group_id", current_group_id)
                    cmd7.CommandType = CommandType.Text
                    cmd7.ExecuteNonQuery()

                    'Execute query
                    selectqueryCommand = New SqlCommand(str, connection)
                    count = Convert.ToInt32(selectqueryCommand.ExecuteScalar)

                    'Execute query
                    countqueryCommand = New SqlCommand(groupStr, connection)
                    countGroup = Convert.ToInt32(countqueryCommand.ExecuteScalar)

                    checkqueryCommand = New SqlCommand(strStudent, connection)
                    countStudent = Convert.ToInt32(checkqueryCommand.ExecuteScalar)
                    If countStudent = 0 Then

                        lblError.Text = "Error: Student is not exist"
                    Else

                        Dim a As Boolean
                        If (count > 0) Then
                            If (countGroup > 0) Then
                                'execute query
                                a = PB.runquery(updateStatusSqlStatement)
                            Else
                                'execute query
                                a = PB.runquery(insertSqlStatement)
                                ' addAttendance(txtStudentID.Text, ddlAssignGroup.SelectedValue, current_group_id)
                            End If

                        Else
                            'execute query
                            a = PB.runquery(insertSqlStatement)
                            'addAttendance(txtStudentID.Text, ddlAssignGroup.SelectedValue, current_group_id)
                        End If
                        If a = True Then
                            'display confirm message
                            lblError.ForeColor = System.Drawing.Color.Black
                            lblError.Text = "Student " + txtStudentID.Text + " has been assigned to course "

                        End If
                    End If
                    bindNonGroup()
                End If
            End If
        End If
    End Sub
    Public Sub default_dropdownlist()

        ddlAssignCourse.SelectedValue = "Select"
        ddlAssignSemester.SelectedValue = "Select"
        txtStudentID.Text = ""
    End Sub

    Private Sub addAttendance(ByVal sID As String, ByVal group As String, ByVal currentGroup As String)
        Dim sql As String
        sql = "select distinct(ss.schedule_id) from student_schedule ss, schedule s where ss.schedule_id = s.schedule_id AND s.group_id = " + group
        Dim dt As DataTable
        dt = PB.getData(sql)
        Dim insert As String = ""
        For Each dr As DataRow In dt.Rows
            insert = insert + " insert into student_schedule values('absent', 1, " + dr.Item("schedule_id") + ", '" + sID + "')"

        Next
        Dim sql1 As String = "select ss.student_schedule_id from student_schedule ss, schedule s where ss.schedule_id = s.schedule_id AND s.group_id = " + currentGroup + "AND ss.student_id = '" + sID + "'"
        Dim updt As DataTable = PB.getData(sql1)
        Dim update As String = ""
        For Each dr As DataRow In updt.Rows
            update = update + " update student_schedule set active = 0 where student_schedule_id = " + dr.Item("student_schedule_id")

        Next

        Dim a As Boolean = PB.runquery(insert)
        a = PB.runquery(update)


    End Sub

    Protected Sub grdvwStudent_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdvwStudent.SelectedIndexChanged

    End Sub
End Class