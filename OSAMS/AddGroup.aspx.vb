Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data.OleDb

'------------------------------------------------------------ 
' File Name         :AddGroup.aspx.vb
' Description       :add new group
' Function List     :Page_load()
'                    load_commbobox()
'    '               saveData(ByVal lecID As String)
'                   btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs)
'                   valid()
'                   checkEsixtedData(ByVal sql As String)
'                   btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)

' date created:      17/04/2012                
' created by:   '    pham sy nhat nam                
'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
'    '------------------------------------------------------------ 
' 17/04/2012   Pham Sy Nhat Nam     add comment
'------------------------------------------------------------ 


Public Class AddGroup
    Inherits System.Web.UI.Page

    Public strConn As String = PB.getConnectionString()

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
            If PB.getAccountType(Session("ID")) = "1" Or PB.getAccountType(Session("ID")) = "2" Then
                If Not Page.IsPostBack Then

                    load_combobox()
                    lblError.ForeColor = Drawing.Color.Red
                    lbl.Text = ""
                Else
                    lblError.ForeColor = Drawing.Color.Red
                    lbl.Text = ""

                End If
            Else
                Response.Redirect("Home.aspx")
            End If
        Else
            If PB.getAccountType(Request.Cookies("ID").Value) = "1" Or PB.getAccountType(Request.Cookies("ID").Value) = "2" Then
                If Not Page.IsPostBack Then

                    load_combobox()
                    lblError.ForeColor = Drawing.Color.Red
                    lbl.Text = ""
                Else
                    lblError.ForeColor = Drawing.Color.Red
                    lbl.Text = ""

                End If
            Else
                Response.Redirect("Home.aspx")
            End If
        End If
    End Sub

    Private Sub load_combobox()
        '------------------------------------------------------------
        ' subroutine  : load_combobox
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to load the data into the dropdownlist
        '------------------------------------------------------------
        ' Incoming Parameters
        '
        '------------------------------------------------------------
        For i = 6 To 21

            If i < 10 Then
                cbxStartHour1.Items.Add(New ListItem("0" + CStr(i), "0" + CStr(i)))
                cbxStartHour2.Items.Add(New ListItem("0" + CStr(i), "0" + CStr(i)))
                cbxEndHour1.Items.Add(New ListItem("0" + CStr(i), "0" + CStr(i)))
                cbxEndHour2.Items.Add(New ListItem("0" + CStr(i), "0" + CStr(i)))

            Else
                cbxStartHour1.Items.Add(New ListItem(CStr(i), CStr(i)))
                cbxStartHour2.Items.Add(New ListItem(CStr(i), CStr(i)))
                cbxEndHour1.Items.Add(New ListItem(CStr(i), CStr(i)))
                cbxEndHour2.Items.Add(New ListItem(CStr(i), CStr(i)))

            End If



        Next
        For i = 0 To 59
            If i < 10 Then
                cbxStartMinute1.Items.Add(New ListItem("0" + CStr(i), "0" + CStr(i)))
                cbxStartMinute2.Items.Add(New ListItem("0" + CStr(i), "0" + CStr(i)))
                cbxEndMinute1.Items.Add(New ListItem("0" + CStr(i), "0" + CStr(i)))
                cbxEndMinute2.Items.Add(New ListItem("0" + CStr(i), "0" + CStr(i)))
            Else
                cbxStartMinute1.Items.Add(New ListItem(CStr(i), CStr(i)))
                cbxStartMinute2.Items.Add(New ListItem(CStr(i), CStr(i)))
                cbxEndMinute1.Items.Add(New ListItem(CStr(i), CStr(i)))
                cbxEndMinute2.Items.Add(New ListItem(CStr(i), CStr(i)))
            End If
        Next
        Dim dt As DataTable
        dt = New DataTable
        dt = PB.getData(" select semester_name from [dbo].[semester] where datediff(day, getdate(), [dbo].[semester].[end_date]) >= 0")
        For Each dr As DataRow In dt.Rows
            cbxSemester.Items.Insert(0, New ListItem(dr.Item("semester_name"), dr.Item("semester_name")))
        Next
        Dim dt1 As DataTable
        dt1 = New DataTable()
        dt1 = PB.getData(" select course_id, course_name from [dbo].[course]")
        For Each dr1 As DataRow In dt1.Rows
            cbxCourse.Items.Insert(0, New ListItem(dr1.Item("course_id") + ": " + dr1.Item("course_name"), dr1.Item("course_id")))
        Next
        Dim dt2 As DataTable
        dt2 = New DataTable()
        Dim sql As String
        sql = " " & _
        "select distinct [lecturer].[lecturer_id], [lecturer].[family_name], [lecturer].[middle_name], [lecturer].[given_name] " & _
        "from [lecturer]  where [lecturer].active = 1"
        dt2 = PB.getData(sql)
        cbxLecturer.Items.Clear()
        Dim item As String

        For Each dr As DataRow In dt2.Rows
            item = dr.Item("lecturer_id") + ": " + dr.Item("family_name") + " " + dr.Item("middle_name") + " " + dr.Item("given_name")
            cbxLecturer.Items.Add(New ListItem(item, dr.Item("lecturer_id")))
        Next


    End Sub



    Public Function saveData(ByVal lecID As String) As Boolean
        '------------------------------------------------------------
        ' function  : saveData
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to save the new group data into the database
        '------------------------------------------------------------
        ' Incoming Parameters
        ' lecid: the lecturer ID
        '
        '
        '------------------------------------------------------------
        '
        Dim s As Boolean
        s = False
        If (FileUpload.HasFile) Then
            Try


                'upload file
                Dim filename As String = Path.GetFileName(FileUpload.FileName)
                FileUpload.SaveAs(Server.MapPath("~/fileupload/") + filename)


                Dim myDataset As New DataSet()
                Dim filepath As String
                filepath = Server.MapPath("~/fileupload/") + filename
                Dim strConnExcel As String
                strConnExcel = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                "Data Source=" + filepath & _
                "; Extended Properties=""Excel 12.0 Xml;HDR=YES;"""

                'read excel file

                Dim connection As OleDbConnection = New OleDbConnection(strConnExcel)

                connection.Open()

                Dim SheetList As New ArrayList

                Dim df As DataTable
                ' read the excel sheet name
                df = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
                Dim i As Integer
                i = 0
                'add the sheet name to the list
                For i = 0 To df.Rows.Count - 1

                    SheetList.Add(df.Rows(i)!TABLE_NAME.ToString)

                Next
                'take the data from the first sheet of excel file
                Dim myData As New OleDbDataAdapter("SELECT * FROM [" & SheetList(0) & "]", strConnExcel)
                myData.TableMappings.Add("Table", "ExcelTest")
                myData.Fill(myDataset)

                connection.Close()
                'check and add the student data of excel file into the database
                Dim StudentID As String
                Dim Program As String
                Dim Stream As String
                Dim family_name As String
                Dim middle_name As String
                Dim given_name As String
                Dim gender As String
                Dim sql As String
                Dim a As Boolean
                Dim addedStudent = New ArrayList



                'get the student ID

                Dim sID = New ArrayList


                sql = " "

                Dim exist As Boolean

                Dim numStudent As Integer
                numStudent = 0
                For Each dr As DataRow In myDataset.Tables(0).Rows
                    numStudent = numStudent + 1
                    addedStudent.Add(dr.Item("StudentID"))
                    StudentID = dr.Item("StudentID")

                    Program = dr.Item("Program")
                    If dr.Item("Stream") = "-" Then
                        Stream = ""
                    Else
                        Stream = dr.Item("Stream")
                    End If

                    family_name = dr.Item("Family Name").ToString
                    middle_name = dr.Item("Middle Name").ToString
                    given_name = dr.Item("Given Name").ToString
                    gender = dr.Item("Gender")
                    'check the student existed or not
                    exist = PB.checkEsixtedData(" select student_id from student where student_id = 's" + StudentID + "'")

                    If exist = False Then
                        sql = sql + " insert into account values ( 's" + StudentID + "', '1234', 1, 5) " & _
                            " insert into student values ('s" & _
                        StudentID + "', '" + family_name + "', '" + middle_name + "', '" + given_name + "', '" + gender + "', 's" & _
                        StudentID + "@rmit.edu.vn', '" + Program + "', '" + Stream + "', 1)"

                    End If

                Next

                ' create sql insert group

                sql = sql + " insert into [dbo].[group] values ('" + txtGroupName.Text + "', " + CStr(numStudent) + ", 1, '" + cbxCourse.SelectedValue + "', '" + cbxSemester.SelectedValue + "', '" + lecID + "') "



                'insert the group and student data into database
                a = PB.runquery(sql)


                'get the new added group id
                Dim gID As String
                Dim sqlGID As String
                sqlGID = " select group_id from [group], [course] where [group].[course_id] = [course].[course_id] AND " & _
                    "[group].[group_name] = '" + txtGroupName.Text & _
                    "' AND [course].[course_name] = '" + cbxCourse.SelectedItem.ToString + "' AND [group].[semester_name] = '" + cbxSemester.SelectedValue + "' AND [group].[lecturer_id] = '" + lecID + "'"
                Dim gdt As DataTable
                gdt = New DataTable


                gdt = PB.getData(sqlGID)

                gID = gdt.Rows(0).Item("group_id").ToString


                Dim enrolsql As String
                enrolsql = " "
                'insert the group day data
                If cbxDay2.SelectedValue > 0 Then
                    enrolsql = enrolsql + " insert into group_day values ('" + cbxStartHour1.SelectedValue + ":" + cbxStartMinute1.SelectedValue + ":00', '" + cbxEndHour1.SelectedValue + ":" + cbxEndMinute1.SelectedValue + ":00', '" + cbxType1.SelectedValue + "', 1, " + gID + ", " + cbxDay1.SelectedValue + ") "

                    enrolsql = enrolsql + " insert into group_day values ('" + cbxStartHour2.SelectedValue + ":" + cbxStartMinute2.SelectedValue + ":00', '" + cbxEndHour2.SelectedValue + ":" + cbxEndMinute2.SelectedValue + ":00', '" + cbxType2.SelectedValue + "', 1, " + gID + ", " + cbxDay2.SelectedValue + ") "

                Else
                    enrolsql = enrolsql + " insert into group_day values ('" + cbxStartHour1.SelectedValue + ":" + cbxStartMinute1.SelectedValue + ":00', '" + cbxEndHour1.SelectedValue + ":" + cbxEndMinute1.SelectedValue + ":00', '" + cbxType1.SelectedValue + "', 1, " + gID + ", " + cbxDay1.SelectedValue + ") "

                End If

                'enrol the student into created group
                For i = 0 To addedStudent.Count - 1
                    enrolsql = enrolsql + " insert into student_group values (NULL, NULL, NULL, 1, " + gID + ", 's" + addedStudent(i).ToString + "') "
                Next

                a = PB.runquery(enrolsql)

                'get the start date of the comming semester
                Dim semesterds As DataTable
                semesterds = New DataTable
                Dim semesterStartDate As Date
                Dim d As String

                semesterds = PB.getData(" select CONVERT(VARCHAR(15),start_date,107) AS begin_date from [dbo].[semester] where semester_name = '" + cbxSemester.SelectedValue + "'")

                d = semesterds.Rows(0).Item("begin_date").ToString
                semesterStartDate = CDate(d)

                Dim schdulesql As String
                Dim lecDate As Date
                Dim tutDate As Date
                schdulesql = " "
                For i = 0 To 11
                    lecDate = DateAdd("d", cbxDay1.SelectedValue - 1 + i * 7, semesterStartDate)

                    schdulesql = schdulesql + "insert into schedule values ('" + lecDate.ToString("yyyyMMdd") + "', 1, " + gID + ") "

                    If cbxDay2.SelectedValue > 0 Then

                        tutDate = DateAdd("d", cbxDay2.SelectedValue - 1 + i * 7, semesterStartDate)
                        schdulesql = schdulesql + "insert into schedule values ('" + tutDate.ToString("yyyyMMdd") + "', 1, " + gID + ") "
                    End If
                Next


                a = PB.runquery(schdulesql)

                s = True
                Dim id = getUser()

                sendingLectureMail(gID, cbxSemester.SelectedValue, cbxCourse.SelectedValue, cbxLecturer.SelectedValue + "@rmit.edu.vn")

                sendingMail(gID, cbxSemester.SelectedValue, cbxCourse.SelectedValue, id + "@rmit.edu.vn")

            Catch

            End Try
        Else
            lblError.Text = "Error: Please choose an excel file to upload."
        End If

        Return s
    End Function

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        '------------------------------------------------------------
        ' subroutine  : btnSubmit_Click
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to insert the new data
        '------------------------------------------------------------
        ' Incoming Parameters
        '
        '------------------------------------------------------------

        Dim s As Boolean
        s = valid()
        If s = True Then

            Dim sqlGroup As String
            Dim exist As Boolean

            sqlGroup = " Select [group].[group_name] from [course], [group], [semester] " & _
                "where [group].[course_id] = [course].[course_id] AND [group].[semester_name] = [semester].[semester_name] " & _
                "AND [semester].[semester_name] = '" + cbxSemester.SelectedValue + "' " & _
                "AND [course].[course_name] = '" + cbxCourse.SelectedItem.ToString + "' " & _
                "AND [group].[group_name] = '" + txtGroupName.Text + "'"

            Dim groupdt As DataTable
            groupdt = New DataTable()
            groupdt = PB.getData(sqlGroup)
            exist = False
            exist = PB.checkEsixtedData(sqlGroup)

            Dim success As Boolean
            success = False

            If exist = False Then

                success = saveData(cbxLecturer.SelectedValue)
                If success = True Then
                    lblError.ForeColor = System.Drawing.Color.Green

                    lblError.Text = "The group has been added successfully."

                End If
            Else
                lblError.ForeColor = System.Drawing.Color.Red
                lblError.Text = "Error: The group has already existed."
            End If

        End If

    End Sub
    Private Function valid() As Boolean

        '------------------------------------------------------------
        ' function  : valid
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to validate the data
        '------------------------------------------------------------
        ' Incoming Parameters
        ' 
        '
        '
        '------------------------------------------------------------
        Dim val As Boolean
        val = True
        Dim mes As String = String.Empty

        If txtGroupName.Text = "" Then
            val = False
            mes = "Error: Enter the group name. <br />"
        End If
        If (cbxStartHour1.SelectedValue * 60 + cbxStartMinute1.SelectedValue >= cbxEndHour1.SelectedValue * 60 + cbxEndMinute1.SelectedValue) Or ((cbxStartHour2.SelectedValue * 60 + cbxStartMinute2.SelectedValue >= cbxEndHour2.SelectedValue * 60 + cbxEndMinute2.SelectedValue) And cbxDay2.SelectedValue <> 0) Then
            val = False
            mes = "Error: The start time must be before the end time. <br />"

        End If

        If cbxDay2.SelectedValue - cbxDay1.SelectedValue <= 0 And cbxDay2.SelectedValue <> 0 Then
            val = False
            mes = "Error: The day 2 must be after day 1 <br />"
        End If

        If val = False Then
            lblError.Text = mes

        End If
        Return val

    End Function


    'Private Function checkEsixtedData(ByVal sql As String) As Boolean
    '    '------------------------------------------------------------
    '    ' function  : checkEsixtedData
    '    ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
    '    ' Aim         : to check the data does it existed or not
    '    '------------------------------------------------------------
    '    ' Incoming Parameters
    '    ' 
    '    '
    '    '
    '    '------------------------------------------------------------

    '    Dim exist As Boolean
    '    exist = False
    '    Dim myds As New DataTable
    '    Dim da As New SqlDataAdapter

    '    Dim connection As New SqlConnection(strConn)
    '    connection.Open()


    '    da.SelectCommand = New SqlCommand(sql, connection)
    '    da.Fill(myds)

    '    If Not myds.Rows.Count = 0 Then
    '        exist = True
    '    End If

    '    connection.Close()
    '    Return exist

    'End Function

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        '------------------------------------------------------------
        ' subroutine  : btnCancel_Click
        ' Author      : Pham Sy Nhat Nam                Date   : 17/4/12
        ' Aim         : to cacel the function and come back to group page
        '------------------------------------------------------------
        ' Incoming Parameters
        '
        '------------------------------------------------------------
        Response.Redirect("~/group.aspx")
    End Sub
    Private Sub sendingLectureMail(ByVal group As String, ByVal semester As String, ByVal course As String, ByVal toMail As String)
        Dim sb As New StringBuilder
        Dim array As Array = Split(cbxLecturer.SelectedItem.ToString, ":")

        sb.Append("Dear " + array(1).ToString + ",")
        sb.AppendLine()
        sb.Append("this email is sent to inform that the group ")
        sb.Append(group)
        sb.Append(" in the course ")
        sb.Append(course)
        sb.Append(" of the semester ")
        sb.Append(semester)
        sb.Append(" has been created")
        sb.AppendLine()
        sb.Append("You has been assigned to this group")
        sb.AppendLine()
        sb.Append("Best Regard")
        sb.AppendLine()
        sb.Append("OSAMS Support Team")
        sb.AppendLine()
        sb.Append("707 Nguyen Van Linh, District 7, Ho Chi Minh City")
        sb.AppendLine()
        sb.Append("Phone: (84-8) 1234-5678")
        sb.AppendLine()
        sb.Append("Email: support@osams.tk")

        PB.sendMail("support@osams.tk", toMail, "group creating", sb, "supportosams")

    End Sub
    Private Sub sendingMail(ByVal group As String, ByVal semester As String, ByVal course As String, ByVal toMail As String)
        Dim sb As New StringBuilder

        sb.Append("Dear, ")
        sb.AppendLine()
        sb.Append("this email is sent to inform that the group ")
        sb.Append(group)
        sb.Append(" in the course ")
        sb.Append(course)
        sb.Append(" of the semester ")
        sb.Append(semester)
        sb.Append(" has been created")
        sb.AppendLine()
        sb.Append("Best Regard")
        sb.AppendLine()
        sb.Append("OSAMS Support Team")
        sb.AppendLine()
        sb.Append("707 Nguyen Van Linh, District 7, Ho Chi Minh City")
        sb.AppendLine()
        sb.Append("Phone: (84-8) 1234-5678")
        sb.AppendLine()
        sb.Append("Email: support@osams.tk")

        PB.sendMail("support@osams.tk", toMail, "group creating", sb, "supportosams")

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
End Class