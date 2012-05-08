'------------------------------------------------------------ 
'File Name          :group.vb
' Description       :Indicate the process of edit group
' Function List     : edit group
'                   : round databound
'                   : round editing
'                   : round canceling
'                   : round updating
'                   : load dropdownlist
'                   : show
'                   : bind 

'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
'    ------------------------------------------------------------ 
' 17/04/2012   Nguyen Tran Dang Khoa     Group
'------------------------------------------------------------ 
Imports System.Data.SqlClient

Public Class Group
    Inherits System.Web.UI.Page
    'declare dataset and current position
    Dim ds As New DataSet()
    Private currentLecturerName As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '------------------------------------------------------------ 
        ' Aim           : validate session for each type of users
        '               : set the message back to red color    
        '               : bind data into gridview
        '               : add data in dropdownlist
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
                If Not IsPostBack Then
                    bind()
                    load_dropdownlist()

                End If
            Else
                Response.Redirect("Home.aspx")
            End If
        Else
            If PB.getAccountType(Request.Cookies("ID").Value) = "1" Or PB.getAccountType(Request.Cookies("ID").Value) = "2" Then
                If Not IsPostBack Then
                    bind()
                    load_dropdownlist()

                End If
            Else
                Response.Redirect("Home.aspx")
            End If
        End If
    End Sub

    Protected Sub grdvwGroup_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdvwGroup.RowDataBound
        '------------------------------------------------------------ 
        ' Aim           : Row Data Bound (bound data into gridview)
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : lecturer given name, middle name, family name
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            :

        If (e.Row.RowState And DataControlRowState.Edit) = DataControlRowState.Edit Then
            If e.Row.RowType = DataControlRowType.DataRow Then

                'declare dropdownlist control, dataset, sql
                Dim dd As DropDownList
                Dim ds As DataSet
                Dim sql As String

                'find control
                dd = e.Row.FindControl("ddlLecturerName")
                ' Declare array list
                Dim items As New ArrayList

                'Select lecturer query
                sql = "select distinct [lecturer].[lecturer_id], [lecturer].[family_name], [lecturer].[middle_name], [lecturer].[given_name] " & _
          "from [course], [group], [lecturer] "
                'get database
                ds = PB.extractData(sql)
                Dim fullName, id As String

                'Add given name, middle name, family name in dropdownlist
                For Each dr As DataRow In ds.Tables(0).Rows
                    fullName = dr.Item("given_name") + " " + dr.Item("middle_name") + " " + dr.Item("family_name")
                    id = dr.Item("lecturer_id")
                    items.Add(New CLecturer(id, fullName))


                Next
                'Bind datasource
                dd.DataSource = items
                ' Bind data text and value
                dd.DataTextField = "full_Name"
                dd.DataValueField = "lecturer_id"
                dd.DataBind()
                'Get current value
                If currentLecturerName IsNot Nothing Then
                    dd.Items.FindByText(currentLecturerName).Selected = True
                End If

            End If
        End If
    End Sub

    Protected Sub grdvwGroup_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdvwGroup.RowUpdating
        '------------------------------------------------------------ 
        ' Aim           : Row Updating (update data gridview)
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


        'Declare group ID, group name, semester name, course id , lecturer ID, number of student
        Dim group_id, group_name, semester_name, course_id, lecturerID, number_of_student As String
        Dim active As Integer
        'Find control of group ID, group name, semester name, course id , lecturer ID, number of student
        Dim group_idLB As Label = TryCast(grdvwGroup.Rows(e.RowIndex).FindControl("lblGroupID"), Label)
        group_id = group_idLB.Text

        Dim groupNameLB As Label = TryCast(grdvwGroup.Rows(e.RowIndex).FindControl("lblGroupName"), Label)
        group_name = groupNameLB.Text

        Dim groupNumberLB As Label = TryCast(grdvwGroup.Rows(e.RowIndex).FindControl("lblNumberOfStudent"), Label)
        number_of_student = groupNumberLB.Text

        active = 1

        Dim courseIdLB As Label = TryCast(grdvwGroup.Rows(e.RowIndex).FindControl("lblCourseID"), Label)
        course_id = courseIdLB.Text

        Dim semesterNameLB As Label = TryCast(grdvwGroup.Rows(e.RowIndex).FindControl("lblSemesterName"), Label)
        semester_name = semesterNameLB.Text

        Dim lecturerNameDDL As DropDownList = TryCast(grdvwGroup.Rows(e.RowIndex).FindControl("ddlLecturerName"), DropDownList)
        lecturerID = lecturerNameDDL.SelectedValue

        'get connection
        Dim connection As New SqlConnection(PB.getConnectionString())
        'declare select, update sql
        Dim sqlStatement As String = String.Empty
        Dim updateSqlStatement As String = String.Empty
        Dim selectSqlStatement As String

        Dim semesterSqlStatement As String = "SELECT [end_date] FROM [semester] WHERE [semester].semester_name = '" & ddlSemester.SelectedValue & "'"


        'Select statement
        selectSqlStatement = "Select lecturer_id from lecturer where [lecturer].[given_name] + ' ' + [lecturer].[middle_name]+ ' '+ [lecturer].[family_name] = @lecturer_name"
        'Update statement
        sqlStatement = "UPDATE [group] SET [group_name] = @group_name, [number_of_student] = @number_of_student, [active] = '1',[course_id] =@course_id, [semester_name] = @semester_name, [lecturer_id] = @lecturer_id WHERE [group_id] = @group_id AND [active]= '1'"

        updateSqlStatement = "UPDATE [group] SET [lecturer_id] = @lecturer_id where [group_id] = @group_id"

        Dim strDate As String = String.Empty

        Dim cmd As New SqlCommand(semesterSqlStatement, connection)

        connection.Open()
        'Loop through and get end date
        Using reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                For i As Integer = 0 To reader.FieldCount - 1

                    strDate = reader.GetValue(i)

                Next

            End While

        End Using

        'Validate last semester
        If strDate < Today Then
            e.Cancel = True
            lblError.Text = "Error: You cannot modify last semester"
        Else
            Try
                grdvwGroup.EditIndex = -1


                ' get query connection
                Dim cmd2 As New SqlCommand(sqlStatement, connection)
                Dim cmd3 As New SqlCommand(updateSqlStatement, connection)


                'add @value  
                cmd2.Parameters.AddWithValue("@group_id", group_id)
                cmd2.Parameters.AddWithValue("@group_name", group_name)
                cmd2.Parameters.AddWithValue("@number_of_student", number_of_student)
                cmd2.Parameters.AddWithValue("@active", active)
                cmd2.Parameters.AddWithValue("@course_id", course_id)
                cmd2.Parameters.AddWithValue("@semester_name", semester_name)
                cmd2.Parameters.AddWithValue("@lecturer_id", lecturerID)

                cmd3.Parameters.AddWithValue("@group_id", group_id)
                cmd3.Parameters.AddWithValue("@lecturer_id", lecturerID)

                'command type query
                cmd2.CommandType = CommandType.Text
                cmd3.CommandType = CommandType.Text

                'execute query
                cmd2.ExecuteNonQuery()
                cmd3.ExecuteNonQuery()

            Catch ex As System.Data.SqlClient.SqlException
                Dim msg As String = "Insert/Update Error:"
                msg += ex.Message
                Throw New Exception(msg)
            Finally
                'close connection
                connection.Close()
                'bind database
                bind()

            End Try
        End If

    End Sub


    Protected Sub grdvwGroup_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdvwGroup.RowCancelingEdit
        'allow canceling
        grdvwGroup.EditIndex = -1
        'bind database
        bind()
        'clear message
        lblError.Text = ""
    End Sub

    Protected Sub grdvwGroup_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdvwGroup.RowEditing
        '------------------------------------------------------------ 
        ' Aim           : Row Editing
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


        'declare lecturer name
        Dim lecturerName As String
        'find control lecturer name
        lecturerName = TryCast(grdvwGroup.Rows(e.NewEditIndex).FindControl("lblLecturerName"), Label).Text
        'get current position
        currentLecturerName = lecturerName
        'allow editing
        grdvwGroup.EditIndex = e.NewEditIndex
        'bind database
        bind()

    End Sub

    Protected Sub grdvwGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdvwGroup.SelectedIndexChanged

    End Sub

    Protected Sub btnNewGroup_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNewGroup.Click
        'Cancel will back to add group page
        Response.Redirect("AddGroup.aspx")
    End Sub
    Public Sub load_dropdownlist()
        'declare semester and course sql
        Dim semesterSqlStatement As String = "SELECT [semester_name] FROM [semester]"
        Dim courseSqlStatement As String = "SELECT [course_id], [course_name] FROM [course]"

        Dim item As String
        'declare dataset
        Dim dtSemester As DataSet
        Dim dtCourse As DataSet
        'extract semester and course data
        dtSemester = PB.extractData(semesterSqlStatement)
        dtCourse = PB.extractData(courseSqlStatement)
        'clear dropdownlist
        ddlCourse.Items.Clear()
        ddlSemester.Items.Clear()
        'add data semester to dropdownlist
        For Each dr As DataRow In dtSemester.Tables(0).Rows
            ddlSemester.Items.Add(New ListItem(dr.Item("semester_name"), dr.Item("semester_name")))
        Next
        'add data course to dropdownlist
        For Each dr As DataRow In dtCourse.Tables(0).Rows
            item = dr.Item("course_id") + ": " + dr.Item("course_name")
            ddlCourse.Items.Add(New ListItem(item, dr.Item("course_id")))
        Next

    End Sub

    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShow.Click
        '------------------------------------------------------------ 
        ' Aim           : show group in gridview
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : group id, group name, number of student, course id, semester name, lecturer full name
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            : 

        'declare datatable
        Dim checkqueryCommand As SqlCommand

        Dim dr1, dr2 As SqlDataReader

        Dim i As Integer
        i = 0

        'get connection
        Dim connection As New SqlConnection(PB.getConnectionString())
        'sql
        Dim strSelect As String = "Select distinct [group].[group_id] from group_day inner join day_of_week on  [group_day].day_id = [day_of_week].day_id inner join [group] on [group_day].group_id =[group].group_id inner join [lecturer] on [group].[lecturer_id] = [lecturer].[lecturer_id] where [group].[active] = 1 AND [group].semester_name = '" & ddlSemester.SelectedValue & "' AND [group].course_id = '" & ddlCourse.SelectedValue & "'"
        Dim dt As DataTable
        'open connection
        connection.Open()
        Try
            dt = PB.getData(strSelect)
            Dim list As New List(Of CDay)

            If dt.Rows.Count > 0 Then

                lblError.Text = ""
                For Each dr As DataRow In dt.Rows


                    'Select group, lecturer, group_day query
                    Dim sqlGeneralStatement As String = "select TOP 1 [group].[group_id], [group].[group_name], [group].[number_of_student], [group].[course_id], [group].[semester_name], ([lecturer].[given_name] + ' ' + [lecturer].[middle_name] + ' ' + [lecturer].[family_name])  AS lecturer_name," & _
        " day_of_week.[day] AS day1, CONVERT (varchar(15), group_day.start_time, 108) AS start_time_day1, CONVERT (varchar(15), group_day.end_time, 108) AS end_time_day1, group_day.type AS type_day1 " & _
        " from group_day inner join day_of_week on  [group_day].day_id = [day_of_week].day_id inner join [group] on [group_day].group_id =[group].group_id" & _
        " inner join [lecturer] on [group].[lecturer_id] = [lecturer].[lecturer_id]" & _
        " where [group].[active] = 1 AND [group].semester_name = '" & ddlSemester.SelectedValue & "' AND [group].course_id = '" & ddlCourse.SelectedValue & "' AND [group].[group_id] = '" & dr.Item("group_id") & "'" & _
        " ORDER BY [group_day].[group_day_id] ASC"




                    Dim selectTutorialStatement As String = "select TOP 1 day_of_week.[day] AS day2, CONVERT (varchar(15), group_day.start_time, 108) AS start_time_day2, CONVERT (varchar(15), group_day.end_time, 108) AS end_time_day2, group_day.type AS type_day2" & _
        " from group_day inner join day_of_week on  [group_day].day_id = [day_of_week].day_id inner join [group] on [group_day].group_id =[group].group_id" & _
        " inner join [lecturer] on [group].[lecturer_id] = [lecturer].[lecturer_id]" & _
        " where [group].[active] = 1 AND [group].semester_name = '" & ddlSemester.SelectedValue & "' AND [group].course_id = '" & ddlCourse.SelectedValue & "' AND [group].[group_id] = '" & dr.Item("group_id") & "'" & _
        " ORDER BY [group_day].[group_day_id] DESC"

                    Dim checkqueryStatement As String = "Select count ([group].[group_id]) from group_day inner join day_of_week on  [group_day].day_id = [day_of_week].day_id inner join [group] on [group_day].group_id =[group].group_id inner join [lecturer] on [group].[lecturer_id] = [lecturer].[lecturer_id] where [group].[active] = 1 AND [group].semester_name = '" & ddlSemester.SelectedValue & "' AND [group].course_id = '" & ddlCourse.SelectedValue & "' AND [group].[group_id] = '" & dr.Item("group_id") & "'"
                    Dim count As Integer
                    checkqueryCommand = New SqlCommand(checkqueryStatement, connection)
                    count = Convert.ToInt32(checkqueryCommand.ExecuteScalar)
                    'execute query
                    Dim cmd As New SqlCommand(sqlGeneralStatement, connection)

                    Dim cmd1 As New SqlCommand(selectTutorialStatement, connection)
                    If count > 1 Then

                        dr1 = cmd.ExecuteReader


                        While dr1.Read()
                            'reading from the datareader
                            Dim day As New CDay
                            day.GroupID = dr1(0).ToString()
                            day.GroupName = dr1(1).ToString()
                            day.NumberOfStudent = dr1(2).ToString
                            day.CourseID = dr1(3).ToString
                            day.SemesterName = dr1(4).ToString()
                            day.LecturerName = dr1(5).ToString()
                            day.Day_1 = dr1(6).ToString()
                            day.StartTime_1 = dr1(7).ToString()
                            day.EndTime_1 = dr1(8).ToString()
                            day.Type_1 = dr1(9).ToString()

                            list.Add(day)
                            'displaying the data from the table

                        End While


                        'Close Sql Data Reader
                        dr1.Close()


                        'Add value to list
                        If (list.Count > 0) Then

                            dr2 = cmd1.ExecuteReader
                            While dr2.Read()
                                list(i).Day_2 = dr2(0).ToString()
                                list(i).StartTime_2 = dr2(1).ToString()
                                list(i).EndTime_2 = dr2(2).ToString()
                                list(i).Type_2 = dr2(3).ToString()
                                i += 1
                            End While
                            'Close Sql Data Reader
                            dr2.Close()

                        End If
                    Else
                        dr1 = cmd.ExecuteReader


                        While dr1.Read()
                            'reading from the datareader
                            Dim day As New CDay
                            day.GroupID = dr1(0).ToString()
                            day.GroupName = dr1(1).ToString()
                            day.NumberOfStudent = dr1(2).ToString
                            day.CourseID = dr1(3).ToString
                            day.SemesterName = dr1(4).ToString()
                            day.LecturerName = dr1(5).ToString()
                            day.Day_1 = dr1(6).ToString()
                            day.StartTime_1 = dr1(7).ToString()
                            day.EndTime_1 = dr1(8).ToString()
                            day.Type_1 = dr1(9).ToString()

                            list.Add(day)
                            'displaying the data from the table

                        End While


                        'Close Sql Data Reader
                        dr1.Close()

                    End If

                Next
                'Bind database to gridview
                grdvwGroup.DataSource = list
                grdvwGroup.DataBind()

            Else
                lblError.Text = "No group found"
                'Bind database to gridview
                grdvwGroup.DataSource = ""
                grdvwGroup.DataBind()

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

    Public Sub bind()
        '------------------------------------------------------------ 
        ' Aim           : Bind group database
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : group id, group name, number of student, course id, semester name, lecturer full name
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            : 

        '------------------------------------------------------------ 
        ' Aim           : show group in gridview
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : group id, group name, number of student, course id, semester name, lecturer full name
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            : 

        'declare datatable


        Dim dr1, dr2 As SqlDataReader

        Dim i As Integer
        i = 0

        'get connection
        Dim connection As New SqlConnection(PB.getConnectionString())
        'sql
        Dim strSelect As String = "Select distinct [group].[group_id] from group_day inner join day_of_week on  [group_day].day_id = [day_of_week].day_id inner join [group] on [group_day].group_id =[group].group_id inner join [lecturer] on [group].[lecturer_id] = [lecturer].[lecturer_id] where [group].[active] = 1 AND [group].semester_name = '" & ddlSemester.SelectedValue & "' AND [group].course_id = '" & ddlCourse.SelectedValue & "'"
        Dim dt As DataTable
        'open connection
        connection.Open()
        Try
            dt = PB.getData(strSelect)
            Dim list As New List(Of CDay)


            For Each dr As DataRow In dt.Rows


                'Select group, lecturer, group_day query
                Dim sqlGeneralStatement As String = "select TOP 1 [group].[group_id], [group].[group_name], [group].[number_of_student], [group].[course_id], [group].[semester_name], ([lecturer].[given_name] + ' ' + [lecturer].[middle_name] + ' ' + [lecturer].[family_name])  AS lecturer_name," & _
    " day_of_week.[day] AS day1, CONVERT (varchar(15), group_day.start_time, 108) AS start_time_day1, CONVERT (varchar(15), group_day.end_time, 108) AS end_time_day1, group_day.type AS type_day1 " & _
    " from group_day inner join day_of_week on  [group_day].day_id = [day_of_week].day_id inner join [group] on [group_day].group_id =[group].group_id" & _
    " inner join [lecturer] on [group].[lecturer_id] = [lecturer].[lecturer_id]" & _
    " where [group].[active] = 1 AND [group].semester_name = '" & ddlSemester.SelectedValue & "' AND [group].course_id = '" & ddlCourse.SelectedValue & "' AND [group].[group_id] = '" & dr.Item("group_id") & "'" & _
    " ORDER BY [group_day].[group_day_id] ASC"



                Dim selectTutorialStatement As String = "select TOP 1 day_of_week.[day] AS day2, CONVERT (varchar(15), group_day.start_time, 108) AS start_time_day2, CONVERT (varchar(15), group_day.end_time, 108) AS end_time_day2, group_day.type AS type_day2" & _
    " from group_day inner join day_of_week on  [group_day].day_id = [day_of_week].day_id inner join [group] on [group_day].group_id =[group].group_id" & _
    " inner join [lecturer] on [group].[lecturer_id] = [lecturer].[lecturer_id]" & _
    " where [group].[active] = 1 AND [group].semester_name = '" & ddlSemester.SelectedValue & "' AND [group].course_id = '" & ddlCourse.SelectedValue & "' AND [group].[group_id] = '" & dr.Item("group_id") & "'" & _
    " ORDER BY [group_day].[group_day_id] DESC"


                'execute query
                Dim cmd As New SqlCommand(sqlGeneralStatement, connection)

                Dim cmd1 As New SqlCommand(selectTutorialStatement, connection)

                dr1 = cmd.ExecuteReader


                While dr1.Read()
                    'reading from the datareader
                    Dim day As New CDay
                    day.GroupID = dr1(0).ToString()
                    day.GroupName = dr1(1).ToString()
                    day.NumberOfStudent = dr1(2).ToString
                    day.CourseID = dr1(3).ToString
                    day.SemesterName = dr1(4).ToString()
                    day.LecturerName = dr1(5).ToString()
                    day.Day_1 = dr1(6).ToString()
                    day.StartTime_1 = dr1(7).ToString()
                    day.EndTime_1 = dr1(8).ToString()
                    day.Type_1 = dr1(9).ToString()

                    list.Add(day)
                    'displaying the data from the table

                End While


                'Close Sql Data Reader
                dr1.Close()


                'Add value to list
                If (list.Count > 0) Then
                    lblError.Text = ""
                    dr2 = cmd1.ExecuteReader
                    While dr2.Read()
                        list(i).Day_2 = dr2(0).ToString()
                        list(i).StartTime_2 = dr2(1).ToString()
                        list(i).EndTime_2 = dr2(2).ToString()
                        list(i).Type_2 = dr2(3).ToString()
                        i += 1
                    End While
                    'Close Sql Data Reader
                    dr2.Close()
                Else
                    'Display error message
                    lblError.Text = "No group found"
                End If

                'Bind database to gridview


            Next
            grdvwGroup.DataSource = list
            grdvwGroup.DataBind()


        Catch ex As System.Data.SqlClient.SqlException
            Dim msg As String = "Fetch Error:"
            msg += ex.Message
            Throw New Exception(msg)
        Finally
            'close connection

            connection.Close()
        End Try

    End Sub

End Class