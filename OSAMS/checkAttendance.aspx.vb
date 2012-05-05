'------------------------------------------------------------ 
' File Name         :checkAttendance.aspx.vb
' Description       :check the and save the attendance data of student into the database
' Function List     :Page_load()
'                    checkAttendance(ByVal group As String, ByVal value As String) As Boolean
'    '               getschedule(ByVal group As String) As String
'                   y(ByVal value As String) As TableCell
'                   btnShow_Click(ByVal sender As Object, ByVal e As EventArgs)
'                   buildtable(ByVal group As String)
'                   ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
'                   ddlSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)

' date created:      17/04/2012                
' created by:       pham sy nhat nam                
'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
'    '------------------------------------------------------------ 
' 17/04/2012   Pham Sy Nhat Nam     build the page
'------------------------------------------------------------ 


Public Class checkAttendance
    Inherits System.Web.UI.Page
    Private studentarray As ArrayList

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '------------------------------------------------------------
        ' subroutine  : Page_Load
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to Create page when loaded
        '------------------------------------------------------------
        ' Incoming Parameters
        '
        '------------------------------------------------------------

        If (Session("Rememberme") = "false") Then
            If PB.getAccountType(Session("ID")) = "5" Or PB.getAccountType(Session("ID")) = "2" Then
                Response.Redirect("Home.aspx")
            Else
                If Not Page.IsPostBack Then
                    Dim dtSem As DataTable
                    Dim sqlSem As String
                    'load the data into the dropdownlist
                    sqlSem = "select semester_name from semester where active = 1 AND datediff(day, getdate(), [dbo].[semester].[end_date]) >= 0"
                    dtSem = PB.getData(sqlSem)
                    For Each dr As DataRow In dtSem.Rows
                        ddlSemester.Items.Add(New ListItem(dr.Item("semester_name"), dr.Item("semester_name")))
                    Next

                    ddlSemester.SelectedIndex = 0


                    'display group
                    Dim group As String
                    group = Request.QueryString("field")
                    Dim value As String
                    value = Request.QueryString("value")
                    Dim edit As String
                    edit = Request.QueryString("edit")
                    If group <> "" Then
                        Dim groupinfo As New ArrayList
                        Dim data As Array

                        data = Split(group, ",")
                        For Each item In data
                            groupinfo.Add(item)
                        Next

                        ddlSemester.SelectedValue = groupinfo(1)
                        loadcourse()
                        ddlCourse.SelectedValue = groupinfo(2)
                        loadgroup()
                        ddlGroup.SelectedValue = groupinfo(0)

                        If value = "" And edit = "" Then

                            buildtable(groupinfo(0))

                        End If
                        'save the attendance data
                        If value <> "" And edit = "" Then

                            checkAttendance(groupinfo(0), value)

                            Response.Redirect("~/checkAttendance.aspx?field=" + group)
                            lblMes.ForeColor = Drawing.Color.Black
                            lblMes.Text = "Attendance updated"
                        End If
                        'edit attendance


                        Dim va As Array
                        Dim list As New ArrayList
                        If edit <> "" And value = "" Then
                            va = Split(edit, ",")

                            list = editTable(va(0).ToString, va(1).ToString)


                        End If

                        If edit <> "" And value <> "" Then
                            va = Split(edit, ",")
                            list = getabstu(va(1).ToString, va(0).ToString)
                            editAttendance(va(1).ToString, va(0).ToString, value, list)
                            Response.Redirect("~/checkAttendance.aspx?field=" + group)
                            lblMes.ForeColor = Drawing.Color.Black
                            lblMes.Text = "Attendance updated"
                        End If

                    End If
                End If
                End If
        Else
                If PB.getAccountType(Request.Cookies("ID").Value) = "5" Or PB.getAccountType(Request.Cookies("ID").Value) = "2" Then
                    Response.Redirect("Home.aspx")
                Else
                If Not Page.IsPostBack Then
                    Dim dtSem As DataTable
                    Dim sqlSem As String
                    'load the data into the dropdownlist
                    sqlSem = "select semester_name from semester where active = 1 AND datediff(day, getdate(), [dbo].[semester].[end_date]) >= 0"
                    dtSem = PB.getData(sqlSem)
                    For Each dr As DataRow In dtSem.Rows
                        ddlSemester.Items.Add(New ListItem(dr.Item("semester_name"), dr.Item("semester_name")))
                    Next

                    ddlSemester.SelectedIndex = 0


                    'display group
                    Dim group As String
                    group = Request.QueryString("field")
                    Dim value As String
                    value = Request.QueryString("value")
                    Dim edit As String
                    edit = Request.QueryString("edit")
                    If group <> "" Then
                        Dim groupinfo As New ArrayList
                        Dim data As Array

                        data = Split(group, ",")
                        For Each item In data
                            groupinfo.Add(item)
                        Next

                        ddlSemester.SelectedValue = groupinfo(1)
                        loadcourse()
                        ddlCourse.SelectedValue = groupinfo(2)
                        loadgroup()
                        ddlGroup.SelectedValue = groupinfo(0)

                        If value = "" And edit = "" Then

                            buildtable(groupinfo(0))

                        End If
                        'save the attendance data
                        If value <> "" And edit = "" Then

                            checkAttendance(groupinfo(0), value)

                            Response.Redirect("~/checkAttendance.aspx?field=" + group)
                            lblMes.ForeColor = Drawing.Color.Black
                            lblMes.Text = "Attendance updated"
                        End If
                        'edit attendance


                        Dim va As Array
                        Dim list As New ArrayList
                        If edit <> "" And value = "" Then
                            va = Split(edit, ",")

                            list = editTable(va(0).ToString, va(1).ToString)


                        End If

                        If edit <> "" And value <> "" Then
                            va = Split(edit, ",")
                            list = getabstu(va(1).ToString, va(0).ToString)
                            editAttendance(va(1).ToString, va(0).ToString, value, list)
                            Response.Redirect("~/checkAttendance.aspx?field=" + group)
                            lblMes.ForeColor = Drawing.Color.Black
                            lblMes.Text = "Attendance updated"
                        End If

                    End If
                End If
                End If
        End If



            '    'build the table
            '    Dim groupinfo As New ArrayList
            '    If group <> "" Then
            '        Dim data As Array

            '        data = Split(group, ",")
            '        For Each item In data
            '            groupinfo.Add(item)
            '        Next
            '        ddlSemester.SelectedValue = groupinfo(1)
            '        ddlCourse.SelectedValue = groupinfo(2)
            '        ddlGroup.SelectedValue = groupinfo(0)
            '    End If
            '    If group <> "" And value = "" And edit = "" Then

            '        buildtable(groupinfo(0))

            '    End If
            '    'save the attendance data
            '    If value <> "" And group <> "" And edit = "" Then

            '        checkAttendance(groupinfo(0), value)

            '        Response.Redirect("~/checkAttendance.aspx?field=" + group)
            '        lblMes.ForeColor = Drawing.Color.Black
            '        lblMes.Text = "Attendance updated"
            '    End If
            '    'edit attendance


            '    Dim va As Array
            '    Dim list As New ArrayList
            '    If edit <> "" And group <> "" And value = "" Then
            '        va = Split(edit, ",")

            '        list = editTable(va(0).ToString, va(1).ToString)


            '    End If

            '    If edit <> "" And value <> "" And group <> "" Then
            '        va = Split(edit, ",")
            '        list = getabstu(va(1).ToString, va(0).ToString)
            '        editAttendance(va(1).ToString, va(0).ToString, value, list)
            '        Response.Redirect("~/checkAttendance.aspx?field=" + group)
            '        lblMes.ForeColor = Drawing.Color.Black
            '        lblMes.Text = "Attendance updated"
            '    End If


    End Sub
    Private Function getabstu(ByVal group As String, ByVal day As String) As ArrayList
        Dim id As String = getEditSchedule(group, day)
        Dim array As New ArrayList
        Dim sql As String = "select student_id from student_schedule where schedule_id = " + id + " and status = 'absent'"
        Dim dt As DataTable = PB.getData(sql)
        For Each dr As DataRow In dt.Rows

            array.Add(dr.Item("student_id"))

        Next

        Return array

    End Function
    Private Function editAttendance(ByVal group As String, ByVal dayedit As String, ByVal value As String, ByVal list As ArrayList) As Boolean
        '------------------------------------------------------------
        ' function  : editAttendance
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to edit the attendance of students
        '------------------------------------------------------------
        ' Incoming Parameters
        ' group: the group id of group want to check the attendance
        'value: the student id of student who is absent from class
        'dayedit: the day that want to edit the attendance record
        '------------------------------------------------------------
        '
        Dim s As Boolean = False

        Dim sql As String
        Dim scheduleid As String
        scheduleid = getEditSchedule(group, dayedit) 'get the schedule id of the group
        sql = ""


        If value <> "0" Then

            Dim stu As Array


            stu = Split(value, ",")

            Dim t As Boolean = False
            Dim abstu As New ArrayList
            For Each item In stu

                If item <> "" Then
                    abstu.Add(item)
                    For i = 0 To list.Count - 1
                        If list(i) = item Then
                            t = True

                            Exit For
                        End If

                    Next
                    'build query for absent students
                    'sql = sql + " insert into student_schedule values ('absent', 1, " + scheduleid + ", '" + item + "')"
                    If t = False Then
                        sql = sql + " update student_schedule set status = 'absent' where schedule_id = " + scheduleid + " AND student_id = '" + item + "'"
                    Else
                        sql = sql + " update student_schedule set status = 'present' where schedule_id = " + scheduleid + " AND student_id = '" + item + "'"
                    End If

                End If
                t = False
            Next



            s = PB.runquery(sql)



        End If

        Return s

    End Function
    Private Function checkAttendance(ByVal group As String, ByVal value As String) As Boolean
        '------------------------------------------------------------
        ' function  : checkAttendance
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to record the attendance of students
        '------------------------------------------------------------
        ' Incoming Parameters
        ' group: the group id of group want to check the attendance
        'value: the student id of student who is absent from class
        '
        '------------------------------------------------------------
        '
        Dim success As Boolean
        success = False
        Dim sql As String
        Dim scheduleid As String
        scheduleid = getschedule(group) 'get the schedule id of the group
        sql = ""

        If scheduleid <> 0 Then


            If value <> "0" Then
                Dim stu As Array
                stu = Split(value, ",")
                For Each item In stu

                    If item <> "" Then
                        'build query for absent students
                        sql = sql + " insert into student_schedule values ('absent', 1, " + scheduleid + ", '" + item + "')"

                    End If


                Next

                'get all the student in group
                Dim groupsql As String
                groupsql = "select student_id from student_group where group_id = " + group

                Dim groupdt As DataTable
                groupdt = PB.getData(groupsql)
                For Each dr As DataRow In groupdt.Rows
                    Dim e As Boolean = False

                    For Each item In stu
                        If item = dr.Item("student_id") Then
                            e = True
                            Exit For
                        End If
                    Next

                    If e = False Then
                        'build query for presented student
                        sql = sql + " insert into student_schedule values ('present', 1, " + scheduleid + ", '" + dr.Item("student_id") + "')"

                    End If

                Next

            Else


                Dim groupsql As String
                groupsql = "select student_id from student_group where group_id = " + group

                Dim groupdt As DataTable
                groupdt = PB.getData(groupsql)
                For Each dr As DataRow In groupdt.Rows


                    'build query for presented student
                    sql = sql + " insert into student_schedule values ('present', 1, " + scheduleid + ", '" + dr.Item("student_id") + "')"

                Next


            End If




            success = PB.runquery(sql)



        End If




        Return success

    End Function
    Private Function getschedule(ByVal group As String) As String
        '------------------------------------------------------------
        ' function  : getschedule
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to get the schdule id of the group to know the schedule of the class
        '------------------------------------------------------------
        ' Incoming Parameters
        ' group: the group id of group want to check the attendance
        '
        '
        '------------------------------------------------------------
        '


        Dim scheduleid As String
        Dim schedulesql, classsql As String
        Dim scheduledt, classdt As DataTable

        schedulesql = "select schedule_id from schedule where group_id = " + group + " order by date"

        classsql = "select distinct(S.date) from student_schedule SS, [group] G, schedule S where SS.schedule_id = S.schedule_id AND G.group_id = S.group_id " & _
            " AND G.group_id = " + group
        classdt = PB.getData(classsql)

        Dim numofclassday As Integer
        numofclassday = classdt.Rows.Count
        scheduledt = PB.getData(schedulesql)


        If numofclassday < scheduledt.Rows.Count Then
            scheduleid = scheduledt.Rows(numofclassday).Item("schedule_id")

        Else
            scheduleid = 0

        End If

        Return scheduleid

    End Function
    Private Function getEditSchedule(ByVal group As String, ByVal day As String) As String
        '------------------------------------------------------------
        ' function  : editschedule
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to get the schdule id of the group to know the schedule of the class
        '------------------------------------------------------------
        ' Incoming Parameters
        ' group: the group id of group want to check the attendance
        'day: the edit day
        '
        '------------------------------------------------------------
        '
        Dim id As String
        Dim sql As String
        Dim dt As DataTable
        sql = "select schedule_id from schedule where group_id = " + group + " order by date"
        dt = PB.getData(sql)
        Dim i As Integer = CInt(day) - 1
        id = dt.Rows(i).Item("schedule_id")


        Return id


    End Function

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
      
        If ddlSemester.SelectedItem.ToString <> "" Then
            If ddlGroup.SelectedValue <> Nothing Then
                Response.Redirect("~/checkAttendance.aspx?field=" + ddlGroup.SelectedValue + "," + ddlSemester.SelectedValue + "," + ddlCourse.SelectedValue)

            End If
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

        sqlAttendance = "select * from student, student_schedule, [group], schedule, student_group " & _
        " where student.student_id = student_schedule.student_id " & _
        " AND student_schedule.schedule_id = schedule.schedule_id " & _
        " AND schedule.group_id = [group].group_id " & _
        " AND student.student_id = student_group.student_id " & _
        " AND [group].group_id = student_group.group_id " & _
        " AND [group].group_id = " + group & _
        " AND student_group.active = 1" & _
        " ORDER BY student.student_id, student_schedule.schedule_id"


        'sqlAttendance = "select * from student_group INNER JOIN student on student.student_id = student_group.student_id " & _
        '  "LEFT JOIN student_schedule on student.student_id = student_schedule.student_id " & _
        '  "LEFT JOIN schedule on schedule.schedule_id = student_schedule.schedule_id " & _
        '  "INNER JOIN [group] on [group].group_id = schedule.group_id " & _
        '  "WHERE(student_group.active = 1) AND student_group.group_id = " + group & _
        '  " AND [group].group_id = " + group & _
        '  "ORDER BY student.student_id"
        'sqlAttendance = checkPer(group)
        dtAttendance = New DataTable()

        dtAttendance = PB.getData(sqlAttendance)


        'build the table if the attendance data is existed

        Dim r1 As New TableRow
        Dim c As New TableCell

        c = New TableCell
        c.ColumnSpan = 7
        c.Controls.Add(New LiteralControl(" &nbsp;"))
        r1.Cells.Add(c)


        Dim u As Integer
        u = 1
        'get how many class per week for the group like 1 day per week or 2 day per week
        'Dim sql As String
        'sql = "select * from [group], group_day where [group].[group_id] = group_day.group_id AND [group].group_id = " + group
        'Dim dt As DataTable
        'dt = New DataTable

        'dt = PB.getData(sql)

        Dim dsday As DataTable
        'add the sudy day of group into the table
        Dim sqlday As String


        sqlday = "select LEFT(day,3) as day_group from group_day, day_of_week where group_day.day_id = day_of_week.day_id AND group_day.group_id = " + group
        dsday = PB.getData(sqlday)


        If dsday.Rows.Count > 1 Then
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

        If dtAttendance.Rows.Count > 0 Then

           
            'add the student data and attendance data into the table
            Dim i As Integer = 0

            Dim r As TableRow
            r = New TableRow



            studentarray = New ArrayList

            Dim cbx As New CheckBox
            Dim numday As Integer

            For Each dr As DataRow In dtAttendance.Rows
                If i > 0 Then
                    If dr.Item("student_id").ToString <> dtAttendance.Rows(i - 1).Item("student_id").ToString Then
                        If dsday.Rows.Count > 1 And numday < 24 Then
                            c = New TableCell
                            'add the checkbox into the table
                            cbx = New CheckBox

                            cbx.ID = "cbx" + dtAttendance.Rows(i - 1).Item("student_id").ToString
                            cbx.Checked = True


                            cbx.Attributes("onclick") = "javascript:check('" + dtAttendance.Rows(i - 1).Item("student_id").ToString + "')"
                            c.Controls.Add(cbx)

                            r.Cells.Add(c)
                        ElseIf dsday.Rows.Count = 1 And numday < 12 Then
                            c = New TableCell
                            'add the checkbox into the table
                            cbx = New CheckBox

                            cbx.ID = "cbx" + dtAttendance.Rows(i - 1).Item("student_id").ToString
                            cbx.Checked = True


                            cbx.Attributes("onclick") = "javascript:check('" + dtAttendance.Rows(i - 1).Item("student_id").ToString + "')"
                            c.Controls.Add(cbx)

                            r.Cells.Add(c)

                        End If


                        numday = 0

                        'add the new row for new student
                        studentarray.Add(dtAttendance.Rows(i - 1).Item("student_id").ToString)
                       

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
                        numday = numday + 1
                    Else
                        'add attendance data for student
                        c = New TableCell

                        c = y(dr.Item("status").ToString)
                        r.Cells.Add(c)
                        numday = numday + 1

                    End If
                Else
                    numday = 0

                    'add the student data and attendance for the first student in the table
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
                    numday = numday + 1
                End If
                i = i + 1

            Next
            studentarray.Add(dtAttendance.Rows(i - 1).Item("student_id").ToString)



            If dsday.Rows.Count > 1 And numday < 24 Then
                c = New TableCell
                'add the checkbox into the table
                cbx = New CheckBox

                cbx.ID = "cbx" + dtAttendance.Rows(i - 1).Item("student_id").ToString
                cbx.Checked = True


                cbx.Attributes("onclick") = "javascript:check('" + dtAttendance.Rows(i - 1).Item("student_id").ToString + "')"
                c.Controls.Add(cbx)

                r.Cells.Add(c)
            ElseIf dsday.Rows.Count = 1 And numday < 12 Then
                c = New TableCell
                'add the checkbox into the table
                cbx = New CheckBox

                cbx.ID = "cbx" + dtAttendance.Rows(i - 1).Item("student_id").ToString
                cbx.Checked = True


                cbx.Attributes("onclick") = "javascript:check('" + dtAttendance.Rows(i - 1).Item("student_id").ToString + "')"
                c.Controls.Add(cbx)

                r.Cells.Add(c)

            End If



            tbattendace.Rows.Add(r)


            r = New TableRow
            r.BorderStyle = BorderStyle.None
            c = New TableCell
            c.ColumnSpan = 7
            c.Controls.Add(New LiteralControl("&nbsp;"))
            r.Cells.Add(c)

            If numday > 2 Then
                c = New TableCell

                If numday > 3 Then
                    c.ColumnSpan = numday - 2
                End If

                c.Controls.Add(New LiteralControl("&nbsp;"))

                r.Cells.Add(c)

            End If
            
           

            

            If numday > 1 And dsday.Rows.Count > 1 Then
                c = New TableCell
                

                c.Controls.Add(New LiteralControl("<input id='Edit1' type='button' value='Edit' onclick='javascript:edit(" + Chr(34) + (numday - 1).ToString + "," + group + Chr(34) + ");'/>"))

                r.Cells.Add(c)
                c = New TableCell

                c.Controls.Add(New LiteralControl("<input id='Edit2' type='button' value='Edit' onclick='javascript:edit(" + Chr(34) + (numday).ToString + "," + group + Chr(34) + ");'/>"))
                r.Cells.Add(c)
            ElseIf numday > 1 And dsday.Rows.Count < 2 Then
                c = New TableCell
                c.Controls.Add(New LiteralControl("&nbsp;"))

                r.Cells.Add(c)
                c = New TableCell
                c.Controls.Add(New LiteralControl("<input id='Edit1' type='button' value='Edit' onclick='javascript:edit(" + Chr(34) + (numday).ToString + "," + group + Chr(34) + ");'/>"))
                r.Cells.Add(c)
            ElseIf numday = 1 Then
                c = New TableCell
                c.Controls.Add(New LiteralControl("&nbsp;"))

                r.Cells.Add(c)
                c = New TableCell
                c.Controls.Add(New LiteralControl("<input id='Edit1' type='button' value='Edit' onclick='javascript:edit(" + Chr(34) + (numday).ToString + "," + group + Chr(34) + ");'/>"))
                r.Cells.Add(c)
            End If

            tbattendace.Rows.Add(r)

            r = New TableRow
            c = New TableCell
            c.Controls.Add(New LiteralControl("<input id='Button1' type='button' value='Submit' onclick='javascript:run();'  align='right' />"))
            r.Cells.Add(c)
            tbattendace.Rows.Add(r)



        ElseIf dtAttendance.Rows.Count = 0 Then



            Dim r As TableRow

            Dim dtstudent As DataTable
            dtstudent = New DataTable()
            Dim sqlstudent As String
            sqlstudent = "select distinct(S.student_id), S.family_name, S.middle_name, S.given_name, S.program, S.stream, S.gender from student S, [group], schedule, student_group " & _
        "where S.student_id = student_group.student_id  " & _
        "AND schedule.group_id = [group].group_id " & _
        "AND [group].group_id = student_group.group_id " & _
        "AND [group].group_id = " + group + " ORDER BY S.student_id"


            dtstudent = PB.getData(sqlstudent)




            Dim cbx As New CheckBox

            For Each dr1 As DataRow In dtstudent.Rows

                r = New TableRow

                c = New TableCell
                c.Controls.Add(New LiteralControl(dr1.Item("student_id").ToString))
                r.Cells.Add(c)
                c = New TableCell
                c.Controls.Add(New LiteralControl(dr1.Item("program").ToString))
                r.Cells.Add(c)
                c = New TableCell
                c.Controls.Add(New LiteralControl(dr1.Item("stream").ToString))
                r.Cells.Add(c)
                c = New TableCell
                c.Controls.Add(New LiteralControl(dr1.Item("family_name").ToString))
                r.Cells.Add(c)
                c = New TableCell
                c.Controls.Add(New LiteralControl(dr1.Item("middle_name").ToString))
                r.Cells.Add(c)
                c = New TableCell
                c.Controls.Add(New LiteralControl(dr1.Item("given_name").ToString))
                r.Cells.Add(c)
                c = New TableCell
                c.Controls.Add(New LiteralControl(dr1.Item("gender").ToString))
                r.Cells.Add(c)

                c = New TableCell

                cbx = New CheckBox

                cbx.ID = "cbx" + dr1.Item("student_id").ToString
                cbx.Checked = True

                cbx.Attributes("onclick") = "javascript:check('" + dr1.Item("student_id").ToString + "')"
                c.Controls.Add(cbx)

                r.Cells.Add(c)

                tbattendace.Rows.Add(r)





            Next


            r = New TableRow
            c = New TableCell
            c.ColumnSpan = 7
            r.Cells.Add(c)
            c = New TableCell
            c.Controls.Add(New LiteralControl("<input id='Button1' type='button' value='Submit Attendance' onclick='javascript:run();'  align='right' />"))
            r.Cells.Add(c)
            tbattendace.Rows.Add(r)

        End If
    End Sub


    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlCourse.SelectedIndexChanged
        '------------------------------------------------------------
        ' subroutine  : ddlCourse_SelectedIndexChanged
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to to load the ddlgroup when ddlcourse changed
        '------------------------------------------------------------
        ' Incoming Parameters
        '
        '
        '
        '------------------------------------------------------------
        '

        loadgroup()


    End Sub
    Private Sub loadgroup()
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
        If ddlSemester.SelectedItem.ToString <> "" Then

            
            loadcourse()
        End If
    End Sub
    Private Sub loadcourse()
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
        If ddlCourse.SelectedItem.ToString <> "" Then
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

        End If
    End Sub
    Private Function getgroup() As String
        Dim id As String = getUser()
        Dim type As String = getUserType()

        Dim sql As String
        If type = "4" Then
            sql = "select group_name, group_id from [group] where active = 1 AND semester_name = '" + ddlSemester.SelectedValue + "' AND course_id = '" + ddlCourse.SelectedValue + "' AND lecturer_id = '" + id + "'"
        Else
            sql = "select group_name, group_id from [group] where active = 1 AND semester_name = '" + ddlSemester.SelectedValue + "' AND course_id = '" + ddlCourse.SelectedValue + "'"


        End If
        Return sql


    End Function

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

        Dim id As String = ""

        If Request.Cookies("ID") Is Nothing Then


            If Session("ID") Is Nothing Then

            Else
                id = Session("ID")

            End If


        Else

            id = Request.Cookies("ID").Value


        End If


        Return id


    End Function

    Private Function getUserType() As String
        '------------------------------------------------------------
        ' function  : getUserType
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to get the type of user like lecturer or student
        '------------------------------------------------------------
        ' Incoming Parameters
        ' 
        '
        '
        '------------------------------------------------------------
        '
        Dim id As String
        id = getUser()

        Dim sql As String
        Dim dt As DataTable
        sql = "select account_type.account_type_id from account, account_type where account.account_type_id = account_type.account_type_id and account.user_name = '" + id + "'"
        dt = PB.getData(sql)
        Dim accountType As String = dt.Rows(0).Item("account_type_id")

        Return accountType

    End Function



    Private Function getSemCou(ByVal group As String) As ArrayList
        '------------------------------------------------------------
        ' function  : getSemCou
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to get the semester name and course id from group id
        '------------------------------------------------------------
        ' Incoming Parameters
        ' group: the group id of the group
        '
        '
        '------------------------------------------------------------
        Dim array As New ArrayList
        Dim sql As String = "select semester_name, course_id from [group] where group_id = " + group
        Dim dt As DataTable = PB.getData(sql)
        array.Add(dt.Rows(0).Item("semester_name"))
        array.Add(dt.Rows(0).Item("course_id"))

        Return array

    End Function

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

        Dim accountType As String = getUserType()
        Dim sql As String
        If accountType = "1" Or accountType = "2" Or accountType = "3" Then
            sql = "select distinct([group].course_id), course.course_name from [group], course where [group].course_id = course.course_id AND [group].active = 1 AND [group].semester_name= '" + ddlSemester.SelectedValue + "'"
        ElseIf accountType = "4" Then

            sql = "select distinct([group].course_id), course.course_name from [group], course where [group].course_id = course.course_id AND [group].active = 1 AND [group].semester_name= '" + ddlSemester.SelectedValue + "' AND [group].lecturer_id = '" + id + "'"
        ElseIf accountType = "5" Then

            If ddlGroup.Visible = True Then
                ddlGroup.Visible = False


            End If
            'sql = sql + " AND student.student_id = '" + id + "'"
            sql = "select distinct([group].course_id), course.course_name from [group], student_group, course where [group].course_id = course.course_id AND [group].group_id = student_group.group_id AND [group].active = 1 AND [group].semester_name= '" + ddlSemester.SelectedValue + "' AND student_group.student_id = '" + id + "'"
        Else
            sql = "select distinct([group].course_id), course.course_name from [group], course where [group].course_id = course.course_id AND [group].active = 1 AND [group].semester_name= '" + ddlSemester.SelectedValue + "'"


        End If

        Return sql

    End Function
    'Private Function getGroupId() As String
    '    Dim groupid As String
    '    Dim sql As String
    '    Dim dt As DataTable
    '    sql = "SELECT group_id FROM [group] WHERE [group].semester_name = '" + ddlSemester.SelectedValue + "' AND [group].course_id = '" + ddlCourse.SelectedValue + "'"
    '    dt = PB.getData(sql)
    '    groupid = dt.Rows(0).Item("group_id")

    '    Return groupid

    'End Function
    Private Function editTable(ByVal dayedit As String, ByVal group As String) As ArrayList

        '------------------------------------------------------------
        ' subroutine  : edit
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to build the html table for editing attendance
        '------------------------------------------------------------
        ' Incoming Parameters
        'group: the group id
        'dayedit the day want to edit
        'dayweek the number of 
        '------------------------------------------------------------
        '


        Dim sqlAttendance As String
        Dim dtAttendance As DataTable
        Dim list As New ArrayList

        sqlAttendance = "select * from student, student_schedule, [group], schedule, student_group " & _
        "where student.student_id = student_schedule.student_id " & _
        "AND student_schedule.schedule_id = schedule.schedule_id " & _
        "AND schedule.group_id = [group].group_id " & _
        "AND student.student_id = student_group.student_id " & _
        "AND [group].group_id = student_group.group_id " & _
        "AND [group].group_id = " + group & _
        "ORDER BY student.student_id, student_schedule.schedule_id"


        

        dtAttendance = New DataTable()

        dtAttendance = PB.getData(sqlAttendance)


        'build the table if the attendance data is existed

        Dim r1 As New TableRow
        Dim c As New TableCell

        c = New TableCell
        c.ColumnSpan = 7
        c.Controls.Add(New LiteralControl(" &nbsp;"))
        r1.Cells.Add(c)


        Dim u As Integer
        u = 1
        'get how many class per week for the group like 1 day per week or 2 day per week


        Dim dsday As DataTable
        'add the sudy day of group into the table
        Dim sqlday As String


        sqlday = "select LEFT(day,3) as day_group from group_day, day_of_week where group_day.day_id = day_of_week.day_id AND group_day.group_id = " + group
        dsday = PB.getData(sqlday)


        If dsday.Rows.Count > 1 Then
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

        If dtAttendance.Rows.Count > 0 Then


            'add the student data and attendance data into the table
            Dim i As Integer = 0

            Dim r As TableRow
            r = New TableRow





            Dim cbx As New CheckBox
            Dim numday As Integer

            For Each dr As DataRow In dtAttendance.Rows
                If i > 0 Then
                    If dr.Item("student_id").ToString <> dtAttendance.Rows(i - 1).Item("student_id").ToString Then

                        c = New TableCell


                        numday = 1

                        'add the new row for new student



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
                        If numday = dayedit Then
                            'add the checkbox into the table
                            cbx = New CheckBox

                            cbx.ID = "cbx" + dtAttendance.Rows(i).Item("student_id").ToString
                            If dr.Item("status").ToString = "present" Then
                                cbx.Checked = True
                            Else
                                cbx.Checked = False
                                list.Add(dtAttendance.Rows(i).Item("student_id").ToString)

                            End If


                            cbx.Attributes("onclick") = "javascript:check('" + dtAttendance.Rows(i).Item("student_id").ToString + "')"
                            c.Controls.Add(cbx)

                            r.Cells.Add(c)
                        Else
                            c = y(dr.Item("status").ToString)
                            r.Cells.Add(c)
                        End If
                        numday = numday + 1
                    Else
                        'add attendance data for student
                        c = New TableCell

                        If numday = dayedit Then
                            'add the checkbox into the table
                            cbx = New CheckBox

                            cbx.ID = "cbx" + dtAttendance.Rows(i).Item("student_id").ToString
                            If dr.Item("status").ToString = "present" Then
                                cbx.Checked = True
                            Else
                                cbx.Checked = False
                                list.Add(dtAttendance.Rows(i).Item("student_id").ToString)
                            End If


                            cbx.Attributes("onclick") = "javascript:check('" + dtAttendance.Rows(i).Item("student_id").ToString + "')"
                            c.Controls.Add(cbx)

                            r.Cells.Add(c)
                        Else
                            c = y(dr.Item("status").ToString)
                            r.Cells.Add(c)
                        End If

                        numday = numday + 1

                    End If
                Else
                    numday = 1

                    'add the student data and attendance for the first student in the table
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
                    If numday = dayedit Then
                        'add the checkbox into the table
                        cbx = New CheckBox


                        cbx.Attributes("onclick") = "javascript:check('" + dtAttendance.Rows(i).Item("student_id").ToString + "')"
                        cbx.ID = "cbx" + dtAttendance.Rows(i).Item("student_id").ToString
                        If dr.Item("status").ToString = "present" Then
                            cbx.Checked = True
                        Else
                            cbx.Checked = False
                            list.Add(dtAttendance.Rows(i).Item("student_id").ToString)
                        End If


                        c.Controls.Add(cbx)

                        r.Cells.Add(c)
                    Else
                        c = y(dr.Item("status").ToString)
                        r.Cells.Add(c)
                    End If
                    numday = numday + 1
                End If
                i = i + 1

            Next




            tbattendace.Rows.Add(r)


            r = New TableRow
            c = New TableCell
            c.ColumnSpan = 7
            r.Cells.Add(c)

            c = New TableCell

            c.Controls.Add(New LiteralControl("<input id='Button1' type='button' value='Submit Attendance' onclick='javascript:run();'  align='right' />"))
            r.Cells.Add(c)
            tbattendace.Rows.Add(r)

        End If

        Return list


    End Function



End Class