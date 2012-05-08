Imports System.IO
'------------------------------------------------------------ 
' File Name         :SemesterAttendance.aspx.vb
' Description       :this is used to display the attendance data of student and export these data into the excel file
' Function List     :Page_load()
'                    
'    '               y(ByVal value As String)
'                   btnShow_Click(ByVal sender As Object, ByVal e As EventArgs)
'                   buildtable(ByVal group As String)
'                   ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
'                   ddlSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
'                   btnExport_Click1(ByVal sender As Object, ByVal e As EventArgs)

' date created:      17/04/2012                
' created by:       pham sy nhat nam                
'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
'    '------------------------------------------------------------ 
' 17/04/2012   Pham Sy Nhat Nam     build the page
'------------------------------------------------------------ 
Public Class SemesterAttendance
    Inherits System.Web.UI.Page

    'Private id As String = getUser()
    'Private ReadOnly user_type As String = getUserType()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '------------------------------------------------------------
        ' subroutine  : Page_Load
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to Create page when loaded
        '------------------------------------------------------------
        ' Incoming Parameters
        '
        '------------------------------------------------------------

        If Not Page.IsPostBack Then

            'load the data into the semester dropdownlist
            'Dim aaa As String = checkDisplay() 'to check the permission and disable the ddlgroup if the user is student
            Dim id As String = getUser()
            Dim user_type As String = PB.getAccountType(id)

            Dim dtSem As DataTable
            Dim sqlSem As String
            If user_type = "4" Then
                sqlSem = "select distinct(semester_name) from [group] where active = 1 AND lecturer_id ='" + id + "'"
            ElseIf user_type = "5" Then
                sqlSem = "select distinct(g.semester_name) from [group] g, student_group sg where g.group_id = sg.group_id AND sg.student_id = '" + id + "'"
                ddlGroup.Enabled = False
            Else
                sqlSem = "select semester_name from semester where active = 1"

            End If

            dtSem = PB.getData(sqlSem)
            For Each dr As DataRow In dtSem.Rows
                ddlSemester.Items.Add(New ListItem(dr.Item("semester_name"), dr.Item("semester_name")))
            Next

            ddlSemester.SelectedIndex = 0
            loadcourse()

            'this export the excel file
            Dim group As String
            group = Request.QueryString("field")


            If group <> "" Then
                Dim data As Array
                Dim groupinfo As New ArrayList
                data = Split(group, ",")
                For Each item In data
                    groupinfo.Add(item)
                Next
                ddlSemester.SelectedValue = groupinfo(1)
                ddlCourse.SelectedValue = groupinfo(2)
                ddlGroup.SelectedValue = groupinfo(0)

                Dim sqlgroup As String
                Dim dtgroup As DataTable
                sqlgroup = "select group_name, course_id, semester_name from [group] where active = 1 AND group_id = " + groupinfo(0)
                dtgroup = PB.getData(sqlgroup)
                buildtable(groupinfo(0))

                Dim context As HttpContext = HttpContext.Current


                context.Response.Clear()
                context.Response.Buffer = True
                context.Response.AddHeader("content-disposition",
                                   "attachment;filename=Attendance-" + dtgroup.Rows(0).Item("semester_name") + "-" + dtgroup.Rows(0).Item("course_id") + "-group" + dtgroup.Rows(0).Item("group_name") + ".xls")
                context.Response.Charset = ""

                context.Response.ContentType = "application/vnd.ms-excel"
                Dim sw As StringWriter
                sw = New StringWriter
                Dim hw As New HtmlTextWriter(sw)


                For i = 0 To tbattendace.Rows.Count - 1
                    tbattendace.Rows(i).Attributes.Add("class", "textmode")
                Next
                tbattendace.RenderControl(hw)


                Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
                context.Response.Write(style)
                context.Response.Output.Write(sw.ToString())
                context.Response.Flush()
                context.Response.End()
                'buildtable(groupinfo(0))
            End If
        End If
        'If Page.IsPostBack Then


        'End If


    End Sub

    Private Function y(ByVal value As String) As TableCell
        '------------------------------------------------------------
        ' function  : y
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to create and return the table cell 
        '------------------------------------------------------------
        ' Incoming Parameters
        ' value: the status of student attendance like present or absent
        '
        '
        '------------------------------------------------------------
        '
        Dim c As New TableCell
        If value = "present" Then
            c.Controls.Add(New LiteralControl("Y"))
        ElseIf value = "absent" Then
            c.BackColor = System.Drawing.Color.Red
            c.Controls.Add(New LiteralControl("N"))

        End If

        Return c

    End Function



    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShow.Click

        '------------------------------------------------------------
        ' subroutine  : btnShow_Click
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to call the build table function for particular group id
        '------------------------------------------------------------
        ' Incoming Parameters
        '
        '
        '
        '------------------------------------------------------------
        '
        'call the build table function

        If ddlSemester.SelectedItem.ToString <> "select" Then
            buildtable(ddlGroup.SelectedValue.ToString)
            'If ddlGroup.Enabled = True Then
            '    buildtable(ddlGroup.SelectedValue.ToString)
            'Else
            '    Dim group As String = getGroupId()
            '    buildtable(group)


            'End If
        End If



    End Sub

    Private Sub buildtable(ByVal group As String)
        '------------------------------------------------------------
        ' subroutine  : buildtable
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to build the html table for attendance
        '------------------------------------------------------------
        ' Incoming Parameters
        'group: the group id
        '
        '
        '------------------------------------------------------------
        '
        Dim sqlAttendance As String
        Dim dtAttendance As DataTable

        'sqlAttendance = "select * from student, student_schedule, [group], schedule, student_group " & _
        '"where student_group.active = 1 AND student.student_id = student_schedule.student_id " & _
        '"AND student_schedule.schedule_id = schedule.schedule_id " & _
        '"AND schedule.group_id = [group].group_id " & _
        '"AND student.student_id = student_group.student_id " & _
        '"AND [group].group_id = student_group.group_id " & _
        '"AND student_group.active = 1 AND [group].group_id = " + group & _
        '"ORDER BY student.student_id, student_schedule.schedule_id"

        'sqlAttendance = "select * from student_group INNER JOIN student on student.student_id = student_group.student_id " & _
        '    "LEFT JOIN student_schedule on student.student_id = student_schedule.student_id " & _
        '    "LEFT JOIN schedule on schedule.schedule_id = student_schedule.schedule_id " & _
        '    "INNER JOIN [group] on [group].group_id = schedule.group_id " & _
        '    "WHERE(student_group.active = 1) AND student_group.group_id = " + group

        sqlAttendance = checkPer(group)


        dtAttendance = New DataTable()

        dtAttendance = PB.getData(sqlAttendance)


        'build the table if the attendance data is existed

        If dtAttendance.Rows.Count > 0 Then
            btnExport.Enabled = True

            Dim r1 As New TableRow
            Dim c As New TableCell

            c = New TableCell
            c.ColumnSpan = 7
            c.Controls.Add(New LiteralControl(" &nbsp;"))
            r1.Cells.Add(c)

            Dim u As Integer


            u = 1

            'get how many class per week for the group like 1 day per week or 2 day per week
            Dim sql As String
            sql = "select * from [group], group_day where [group].[group_id] = group_day.group_id AND [group].group_id = " + group
            Dim dt As DataTable
            dt = New DataTable

            dt = PB.getData(sql)



            If dt.Rows.Count > 1 Then
                For u = 1 To 12
                    'for 2 class day per week
                    c = New TableCell
                    c.ColumnSpan = 2

                    c.Controls.Add(New LiteralControl("W" + CStr(u)))
                    r1.Cells.Add(c)
                Next
            Else
                For u = 1 To 12
                    'for 1 class per week
                    c = New TableCell
                    c.Controls.Add(New LiteralControl("W" + CStr(u)))
                    r1.Cells.Add(c)
                Next

            End If


            tbattendace.Rows.Add(r1)

            Dim r2 As TableRow

            r2 = New TableRow
            c = New TableCell
            r2.BackColor = System.Drawing.Color.CornflowerBlue
            c.Controls.Add(New LiteralControl("Student ID"))
            r2.Cells.Add(c)
            c = New TableCell
            c.Controls.Add(New LiteralControl("Program"))
            r2.Cells.Add(c)
            c = New TableCell
            c.Controls.Add(New LiteralControl("Stream"))
            r2.Cells.Add(c)
            c = New TableCell
            c.Controls.Add(New LiteralControl("Family Name"))
            r2.Cells.Add(c)
            c = New TableCell
            c.Controls.Add(New LiteralControl("Middle Name"))
            r2.Cells.Add(c)
            c = New TableCell
            c.Controls.Add(New LiteralControl("Given Name"))
            r2.Cells.Add(c)
            c = New TableCell
            c.Controls.Add(New LiteralControl("Gender"))
            r2.Cells.Add(c)
            Dim h As Integer
            Dim dsday As DataTable
            'add the sudy day of group into the table
            Dim sqlday As String
            sqlday = "select LEFT(day,3) as day_group from group_day, day_of_week where group_day.day_id = day_of_week.day_id AND group_day.group_id = " + group
            dsday = PB.getData(sqlday)

            If dsday.Rows.Count > 1 Then
                'add day for 2 class per week
                For h = 1 To 12

                    For Each dr As DataRow In dsday.Rows
                        c = New TableCell
                        c.Controls.Add(New LiteralControl(dr.Item("day_group").ToString))
                        r2.Cells.Add(c)

                    Next


                Next
            Else
                'for only one class per week
                Dim day As String
                day = dsday.Rows(0).Item("day_group").ToString()


                For h = 1 To 12

                    c = New TableCell
                    c.Controls.Add(New LiteralControl(day))
                    r2.Cells.Add(c)
                Next


            End If


            tbattendace.Rows.Add(r2)
            'add the student data and attendance data into the table
            Dim i As Integer = 0

            Dim r As TableRow
            r = New TableRow

            For Each dr As DataRow In dtAttendance.Rows
                If i > 0 Then
                    'add the new row for new student
                    If dr.Item("student_id").ToString <> dtAttendance.Rows(i - 1).Item("student_id").ToString Then


                        tbattendace.Rows.Add(r)
                        r = New TableRow

                        c = New TableCell
                        c.Controls.Add(New LiteralControl(dr.Item("student_id").ToString))
                        r.Cells.Add(c)
                        c = New TableCell
                        c.Controls.Add(New LiteralControl(dr.Item("program").ToString))
                        r.Cells.Add(c)
                        c = New TableCell
                        c.Controls.Add(New LiteralControl(dr.Item("stream").ToString))
                        r.Cells.Add(c)
                        c = New TableCell
                        c.Controls.Add(New LiteralControl(dr.Item("family_name").ToString))
                        r.Cells.Add(c)
                        c = New TableCell
                        c.Controls.Add(New LiteralControl(dr.Item("middle_name").ToString))
                        r.Cells.Add(c)
                        c = New TableCell
                        c.Controls.Add(New LiteralControl(dr.Item("given_name").ToString))
                        r.Cells.Add(c)
                        c = New TableCell
                        c.Controls.Add(New LiteralControl(dr.Item("gender").ToString))
                        r.Cells.Add(c)
                        c = New TableCell
                        c = y(dr.Item("status").ToString)
                        r.Cells.Add(c)
                    Else
                        'add attendance data for student
                        c = New TableCell

                        c = y(dr.Item("status").ToString)
                        r.Cells.Add(c)

                    End If
                Else

                    'add teh student data and attendance for the first student in the table
                    r = New TableRow

                    c = New TableCell
                    c.Controls.Add(New LiteralControl(dr.Item("student_id").ToString))
                    r.Cells.Add(c)
                    c = New TableCell
                    c.Controls.Add(New LiteralControl(dr.Item("program").ToString))
                    r.Cells.Add(c)
                    c = New TableCell
                    c.Controls.Add(New LiteralControl(dr.Item("stream").ToString))
                    r.Cells.Add(c)
                    c = New TableCell
                    c.Controls.Add(New LiteralControl(dr.Item("family_name").ToString))
                    r.Cells.Add(c)
                    c = New TableCell
                    c.Controls.Add(New LiteralControl(dr.Item("middle_name").ToString))
                    r.Cells.Add(c)
                    c = New TableCell
                    c.Controls.Add(New LiteralControl(dr.Item("given_name").ToString))
                    r.Cells.Add(c)
                    c = New TableCell
                    c.Controls.Add(New LiteralControl(dr.Item("gender").ToString))
                    r.Cells.Add(c)
                    c = New TableCell
                    c = y(dr.Item("status").ToString)
                    r.Cells.Add(c)

                End If
                i = i + 1

            Next
            tbattendace.Rows.Add(r)
        End If
    End Sub


    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlCourse.SelectedIndexChanged
        '------------------------------------------------------------
        ' subroutine  : ddlCourse_SelectedIndexChanged
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to load the ddlgroup when ddlcourse changed
        '------------------------------------------------------------
        ' Incoming Parameters
        '
        '
        '
        '------------------------------------------------------------
        '
        'If ddlGroup.Enabled = True Then

        
        loadgroup()

        ' End If


    End Sub
    Private Sub loadgroup()
        btnExport.Enabled = False
        ddlGroup.Items.Clear()
        Dim dtGroup As DataTable
        Dim sqlGroup As String
        dtGroup = New DataTable()
        'sqlGroup = "select group_name, group_id from [group] where active = 1 AND semester_name = '" + ddlSemester.SelectedValue + "' AND course_id = '" + ddlCourse.SelectedValue + "'"
        'MsgBox(sqlGroup)
        sqlGroup = getgroup()

        dtGroup = PB.getData(sqlGroup)
        For Each dr As DataRow In dtGroup.Rows
            ddlGroup.Items.Add(New ListItem(dr.Item("group_name"), dr.Item("group_id")))
        Next
    End Sub

    Protected Sub ddlSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlSemester.SelectedIndexChanged
        '------------------------------------------------------------
        ' subroutine  : ddlSemester_SelectedIndexChanged
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to to load the ddlcourse when ddlsemester changed
        '------------------------------------------------------------
        ' Incoming Parameters
        '
        '
        '
        '------------------------------------------------------------
        '

        loadcourse()

    End Sub
    Private Sub loadcourse()
        If ddlSemester.SelectedItem.ToString <> "" Then
            btnExport.Enabled = False
            ddlCourse.Items.Clear()

            Dim dtCourse As DataTable

            Dim sqlCourse As String
            dtCourse = New DataTable()
            'sqlCourse = "select distinct(course.course_id) from course, [group] where [group].course_id = course.course_id AND course.active = 1 AND [group].semester_name= '" + ddlSemester.SelectedValue + "'"
            sqlCourse = checkDisplay()


            dtCourse = PB.getData(sqlCourse)

            For Each dr1 As DataRow In dtCourse.Rows
                ddlCourse.Items.Add(New ListItem(dr1.Item("course_id") + ": " + dr1.Item("course_name"), dr1.Item("course_id")))
            Next

            ddlCourse.SelectedIndex = 0

            If ddlCourse.SelectedItem.ToString <> "" Then 'And ddlGroup.Enabled = True Then
                ddlGroup.Items.Clear()
                Dim dtGroup As DataTable
                Dim sqlGroup As String
                dtGroup = New DataTable()
                'sqlGroup = "select group_name, group_id from [group] where active = 1 AND semester_name = '" + ddlSemester.SelectedValue + "' AND course_id = '" + ddlCourse.SelectedValue + "'"
                sqlGroup = getgroup()

                dtGroup = PB.getData(sqlGroup)
                For Each dr As DataRow In dtGroup.Rows
                    ddlGroup.Items.Add(New ListItem(dr.Item("group_name"), dr.Item("group_id")))
                Next
                ddlGroup.SelectedIndex = 0
            End If

        End If
    End Sub
    Private Function getgroup() As String
        Dim id As String = getUser()
        Dim type As String = PB.getAccountType(id)

        Dim sql As String
        If type = "4" Then
            sql = "select group_name, group_id from [group] where active = 1 AND semester_name = '" + ddlSemester.SelectedValue + "' AND course_id = '" + ddlCourse.SelectedValue + "' AND lecturer_id = '" + id + "'"
        ElseIf type = "5" Then
            sql = "select g.group_name, g.group_id from [group] g, student_group sg where g.group_id = sg.group_id AND sg.active = 1 AND semester_name = '" + ddlSemester.SelectedValue + "' AND course_id = '" + ddlCourse.SelectedValue + "' AND sg.student_id = '" + id + "'"
        Else
            sql = "select group_name, group_id from [group] where active = 1 AND semester_name = '" + ddlSemester.SelectedValue + "' AND course_id = '" + ddlCourse.SelectedValue + "'"


        End If
        Return sql


    End Function

    Protected Sub btnExport_Click1(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport.Click
        '------------------------------------------------------------
        ' subroutine  : btnExport_Click1
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to exprot the attendance to the excel file
        '------------------------------------------------------------
        ' Incoming Parameters
        '
        '
        '
        '------------------------------------------------------------
        '

        If ddlGroup.Enabled = True Then
            'export if not student
            If ddlGroup.SelectedValue <> Nothing Then
                Response.Redirect("~/SemesterAttendance.aspx?field=" + ddlGroup.SelectedValue + "," + ddlSemester.SelectedValue + "," + ddlCourse.SelectedValue)

            End If
        Else
            Dim group As String = getGroupId() 'get the group id of the student
            Response.Redirect("~/SemesterAttendance.aspx?field=" + group + "," + ddlSemester.SelectedValue + "," + ddlCourse.SelectedValue)

        End If

    End Sub


    Private Function getUser() As String

        '------------------------------------------------------------
        ' function  : getUser
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to get the logined user ID
        '------------------------------------------------------------
        ' Incoming Parameters
        ' 
        '
        '
        '------------------------------------------------------------
        '

        Dim id1 As String = ""


        If (Session("Rememberme") = "false") Then
            id1 = HttpContext.Current.Session("ID")
        Else
            id1 = System.Web.HttpContext.Current.Request.Cookies("ID").Value
        End If


        Return id1


    End Function


    Private Function checkPer(ByVal group As String) As String
        '------------------------------------------------------------
        ' function  : checkPer
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to get the type of user like lecturer or student to reurn the properly sql query
        '------------------------------------------------------------
        ' Incoming Parameters
        ' 
        '
        '
        '------------------------------------------------------------
        '
        Dim id As String = getUser()

        Dim user_type As String = PB.getAccountType(id)

        Dim sql As String
        sql = "select * from student, student_schedule, [group], schedule, student_group " & _
       " where student.student_id = student_schedule.student_id " & _
       " AND student_schedule.schedule_id = schedule.schedule_id " & _
       " AND schedule.group_id = [group].group_id " & _
       " AND student.student_id = student_group.student_id " & _
       " AND [group].group_id = student_group.group_id " & _
       " AND [group].group_id = " + group & _
       " AND student_group.active = 1"


        'sql = "select * from student_group INNER JOIN student on student.student_id = student_group.student_id " & _
        '    "INNER JOIN student_schedule on student.student_id = student_schedule.student_id " & _
        '    "INNER JOIN schedule on schedule.schedule_id = student_schedule.schedule_id " & _
        '    "INNER JOIN [group] on [group].group_id = schedule.group_id " & _
        '    "WHERE student_group.active = 1 "

        'If accountType = "1" Or accountType = "2" Or accountType = "3" Then
        '    sql = sql + "AND [student_group].group_id = " + group + " AND [group].group_id = " + group + " ORDER BY student.student_id"
        'ElseIf accountType = "4" Then

        '    sql = sql + "AND [student_group].group_id = " + group + " AND [group].group_id = " + group + " ORDER BY student.student_id"

        'Else
        If user_type = "5" Then
            'If ddlGroup.Enabled = True Then
            '    ddlGroup.Enabled = False


            'End If
            'Dim array As ArrayList = getSemCou(group)

            sql = sql + " AND student.student_id = '" + id + "'"

        End If




        sql = sql + " ORDER BY student.student_id, student_schedule.schedule_id"
        'If accountType = "1" Or accountType = "2" Or accountType = "3" Then
        '    sql = sql + "AND [student_group].group_id = " + group + " AND [group].group_id = " + group + " ORDER BY student.student_id"
        'ElseIf accountType = "4" Then

        '    sql = sql + "AND [student_group].group_id = " + group + " AND [group].group_id = " + group + " ORDER BY student.student_id"

        'Else
        '    If ddlGroup.Enabled = True Then
        '        ddlGroup.Enabled = False


        '    End If
        '    Dim array As ArrayList = getSemCou(group)

        '    sql = sql + " AND student.student_id = '" + id + "' AND [group].course_id = '" + array(1).ToString + "' AND [group].semester_name = '" + array(0).ToString + "'"

        'End If



        Return sql

    End Function

    'Private Function getSemCou(ByVal group As String) As ArrayList
    '    '------------------------------------------------------------
    '    ' function  : getSemCou
    '    ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
    '    ' Aim         : to get the semester name and course id from group id
    '    '------------------------------------------------------------
    '    ' Incoming Parameters
    '    ' group: the group id of the group
    '    '
    '    '
    '    '------------------------------------------------------------
    '    Dim array As New ArrayList
    '    Dim sql As String = "select semester_name, course_id from [group] where group_id = " + group
    '    Dim dt As DataTable = PB.getData(sql)
    '    array.Add(dt.Rows(0).Item("semester_name"))
    '    array.Add(dt.Rows(0).Item("course_id"))

    '    Return array

    'End Function

    Private Function checkDisplay() As String
        '------------------------------------------------------------
        ' function  : checkPer
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to display the properly values of dropdownlists
        '------------------------------------------------------------
        ' Incoming Parameters
        ' 
        '
        '
        '------------------------------------------------------------

        Dim id As String = getUser()

        Dim user_type As String = PB.getAccountType(id)
        Dim sql As String
        If user_type = "1" Or user_type = "2" Or user_type = "3" Then
            sql = "select distinct([group].course_id), course.course_name from [group], course where [group].course_id = course.course_id AND [group].active = 1 AND [group].semester_name= '" + ddlSemester.SelectedValue + "'"
        ElseIf user_type = "4" Then

            sql = "select distinct([group].course_id), course.course_name from [group], course where [group].course_id = course.course_id AND [group].active = 1 AND [group].semester_name= '" + ddlSemester.SelectedValue + "' AND [group].lecturer_id = '" + id + "'"
        ElseIf user_type = "5" Then

            'If ddlGroup.Enabled = True Then
            '    ddlGroup.Enabled = False


            'End If
            'sql = sql + " AND student.student_id = '" + id + "'"
            sql = "select distinct([group].course_id), course.course_name from [group], student_group, course where [group].course_id = course.course_id AND [group].group_id = student_group.group_id AND [group].active = 1 AND [group].semester_name= '" + ddlSemester.SelectedValue + "' AND student_group.student_id = '" + id + "'"
        Else
            sql = "select distinct([group].course_id), course.course_name from [group], course where [group].course_id = course.course_id AND [group].active = 1 AND [group].semester_name= '" + ddlSemester.SelectedValue + "'"


        End If

        Return sql

    End Function
        Private Function getGroupId() As String
            Dim groupid As String
            Dim sql As String
            Dim dt As DataTable
            sql = "SELECT group_id FROM [group] WHERE [group].semester_name = '" + ddlSemester.SelectedValue + "' AND [group].course_id = '" + ddlCourse.SelectedValue + "'"
            dt = PB.getData(sql)
            groupid = dt.Rows(0).Item("group_id")

            Return groupid

        End Function



End Class
