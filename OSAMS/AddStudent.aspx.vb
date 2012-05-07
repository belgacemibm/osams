'------------------------------------------------------------ 
'File Name          :AddStudent.vb
' Description       :Indicate the process of add semester
' Function List     : 

'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
'    ------------------------------------------------------------ 
' 17/04/2012   Nguyen Tran Dang Khoa     Add Student
'------------------------------------------------------------ 

Imports System.Data.SqlClient

Public Class AddStudent
    Inherits System.Web.UI.Page

    'Declare connection
    Private nonqueryCommand As SqlCommand
    Private selectqueryCommand As SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("Rememberme") = "false") Then
            If PB.getAccountType(Session("ID")) = "1" Or PB.getAccountType(Session("ID")) = "2" Then
                If Not Page.IsPostBack Then
                    lblError.ForeColor = System.Drawing.Color.Red
                    load_combobox()
                Else
                    lblError.ForeColor = System.Drawing.Color.Red
                End If
                If cbAssign.Checked Then
                    enable_dropdownlist(True)
                Else
                    enable_dropdownlist(False)
                End If
            Else
                Response.Redirect("Home.aspx")
            End If
        Else
            If PB.getAccountType(Request.Cookies("ID").Value) = "1" Or PB.getAccountType(Request.Cookies("ID").Value) = "2" Then
                If Not Page.IsPostBack Then
                    lblError.ForeColor = System.Drawing.Color.Red
                    load_combobox()
                Else
                    lblError.ForeColor = System.Drawing.Color.Red
                End If
                If cbAssign.Checked Then
                    enable_dropdownlist(True)
                Else
                    enable_dropdownlist(False)
                End If
            Else
                Response.Redirect("Home.aspx")
            End If
        End If



    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
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

        ' Get connection
        Dim connection As New SqlConnection(PB.getConnectionString())
        'Open connection
        connection.Open()
        'Declare variables
        Dim studentID As String = txtStudentID.Text
        Dim studentFamilyName As String = txtFamilyName.Text
        Dim studentMiddleName As String = txtMiddleName.Text
        Dim studentGivenName As String = txtGivenName.Text
        Dim studentGender As String = ddlGender.Text
        Dim studentMail As String = studentID + "@rmit.edu.vn"
        Dim studentProgram As String = ddlProgram.SelectedValue
        Dim studentStream As String = ddlStream.SelectedValue
        Dim studentSemester As String = ddlSemester.SelectedValue
        Dim studentCourse As String = ddlCourse.SelectedValue
        Dim studentGroup As String = ddlGroup.SelectedValue
        Dim count As Integer


        ' Create INSERT statement with named parameters

        Dim sql As String
        sql = "INSERT INTO account (user_name, password, active, account_type_id) VALUES ('" & studentID & "','1234','1','5')"
        sql = sql + "INSERT  INTO student (student_id, family_name, middle_name, given_name, gender, email, program, stream, active) VALUES ('" & studentID & "','" & studentFamilyName & "','" & studentMiddleName & "','" & studentGivenName & "','" & studentGender & "','" & studentMail & "','" & studentProgram & "','" & studentStream & "','" & "1" & "')"
        sql = sql + "INSERT INTO student_group (grade, result, comment, active, group_id, student_id) VALUES  ('','','','1','" & studentGroup & "','" & studentID & "')"
        sql = sql + "update [group] set number_of_student = number_of_student + 1 where group_id = " & studentGroup & " and course_id ='" & studentCourse & "' and semester_name ='" & studentSemester & "'"

        Dim insertSql As String

        insertSql = "INSERT INTO account (user_name, password, active, account_type_id) VALUES ('" & studentID & "','1234','1','5')"
        insertSql = insertSql + "INSERT  INTO student (student_id, family_name, middle_name, given_name, gender, email, program, stream, active) VALUES ('" & studentID & "','" & studentFamilyName & "','" & studentMiddleName & "','" & studentGivenName & "','" & studentGender & "','" & studentMail & "','" & studentProgram & "','" & studentStream & "','" & "1" & "')"

        'Select query
        Dim str As String = "select count (*) name from student where student_id = '" + studentID & "'"
        'Execute query
        selectqueryCommand = New SqlCommand(str, connection)


        Dim semesterSqlStatement As String = "SELECT [end_date] FROM [semester] WHERE [semester].semester_name = '" & ddlSemester.SelectedValue & "'"

        Dim strDate As String = String.Empty

        Dim cmdEnd As New SqlCommand(semesterSqlStatement, connection)


        Using reader As SqlDataReader = cmdEnd.ExecuteReader()
            While reader.Read()
                For i As Integer = 0 To reader.FieldCount - 1

                    strDate = reader.GetValue(i)

                Next

            End While

        End Using

       

            'validate duplicate student ID
            count = Convert.ToInt32(selectqueryCommand.ExecuteScalar)

            If (count > 0) Then

                lblError.Text = "Error: The student ID has been existed"

        Else
            lblError.Text = ""
            If cbAssign.Checked Then
                If ddlSemester.SelectedValue = "Select" Or ddlProgram.SelectedValue = "Select" Or ddlGroup.SelectedValue = "" Then
                    lblMessage.Text = "Error: Please select semester, course and group"
                Else
                    lblMessage.Text = ""
                    If strDate < Today Then
                        lblError.Text = "Error: You cannot modify last semester"
                    Else
                        lblError.Text = ""
                        'execute query
                        Dim a As Boolean
                        a = PB.runquery(sql)

                        If a = True Then
                            confirm(studentID)
                        End If
                    End If
                End If
            Else

                'execute query
                Dim b As Boolean
                b = PB.runquery(insertSql)

                If b = True Then
                    addAttendance(txtStudentID.Text, ddlGroup.SelectedValue)
                    confirm(studentID)

                End If
            End If
            End If

        ' Close Connection
        connection.Close()
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        'Direct to student page
        Response.Redirect("Student.aspx")

    End Sub

    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlCourse.SelectedIndexChanged
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
        ddlGroup.Items.Clear()
        ' select query
        sqlgroup = "select [group].group_name, [group].group_id FROM  [group] where [group].course_id = '" + ddlCourse.SelectedValue + "' and [group].semester_name = '" + ddlSemester.SelectedValue + "'"
        ' declare dataset
        Dim dsgroup As DataSet
        ' get data
        dsgroup = PB.extractData(sqlgroup)
        ' validate default value
        If ddlCourse.SelectedValue = "Select" Then
            lblError.Text = ""
        Else
            'validate data found
            If dsgroup Is Nothing Then
                lblError.Text = "No group found"
            Else

                lblError.Text = ""
                ' add value in dropdownlist
                For Each dr As DataRow In dsgroup.Tables(0).Rows
                    ddlGroup.Items.Add(New ListItem(dr.Item("group_name"), dr.Item("group_id")))

                Next
            End If
        End If
    End Sub

    Protected Sub ddlCourse_DataBound(ByVal sender As Object, ByVal e As EventArgs) Handles ddlCourse.DataBound


    End Sub

    Protected Sub ddlCourse_DataBinding(ByVal sender As Object, ByVal e As EventArgs) Handles ddlCourse.DataBinding


    End Sub

    Protected Sub ddlSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlSemester.SelectedIndexChanged

        'clear group dropdownlist
        ddlGroup.Items.Clear()
        'declare default value
        ddlCourse.SelectedValue = "Select"
        lblMessage.Text = ""
        lblError.Text = ""
    End Sub

    Public Sub confirm(ByVal str As String)
        'display confirm message
        lblError.ForeColor = System.Drawing.Color.Black
        lblError.Text = "Student " + str + " has been created"
        'clear text box
        txtFamilyName.Text = ""
        txtGivenName.Text = ""
        txtMiddleName.Text = ""
        txtStudentID.Text = ""
    End Sub
    Public Sub load_combobox()
        'Declare variables
        Dim sqlsemester As String
        Dim sqlcourse As String
        'Select query
        sqlsemester = "SELECT [semester_name] FROM [semester]"
        sqlcourse = "select course_name, course_id from course"

        'Declare datase
        Dim dtsemester As DataSet
        Dim dscourse As DataSet

        'Get data
        dtsemester = PB.extractData(sqlsemester)
        dscourse = PB.extractData(sqlcourse)


        'Add value semester_name
        For Each dr As DataRow In dtsemester.Tables(0).Rows
            ddlSemester.Items.Add(New ListItem(dr.Item("semester_name"), dr.Item("semester_name")))

        Next


        'Add value course_name
        For Each dr As DataRow In dscourse.Tables(0).Rows
            ddlCourse.Items.Add(New ListItem(dr.Item("course_name"), dr.Item("course_id")))

        Next
    End Sub

    Protected Sub cbAssign_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbAssign.CheckedChanged

    End Sub
    Public Sub enable_dropdownlist(ByVal b As Boolean)
        ddlSemester.Enabled = b
        ddlCourse.Enabled = b
        ddlGroup.Enabled = b

    End Sub
    Private Sub addAttendance(ByVal sID As String, ByVal group As String)
        Dim sql As String
        sql = "select distinct(ss.schedule_id) from student_schedule ss, schedule s where ss.schedule_id = s.schedule_id AND s.group_id = " + group
        Dim dt As DataTable
        dt = PB.getData(sql)
        Dim insert As String = ""
        For Each dr As DataRow In dt.Rows
            insert = insert + " insert into student_schedule values('absent', 1, " + dr.Item("schedule_id") + ", '" + sID + "')"

        Next


        Dim a As Boolean = PB.runquery(insert)
        'a = PB.runquery(update)


    End Sub
End Class