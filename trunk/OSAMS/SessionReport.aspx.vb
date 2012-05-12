'------------------------------------------------------------ 
' File Name         :SessionReport.aspx.vb
' Description       :Allows user to select criteria for the report
' Function List     :Page_Load
'                    btnShow_Click
'                    getInfo
'                    getCheckboxInGridview
'                    btnViewReport_Click
'                    ToggleCheckState
'                    btnSelectAll_Click
'                    btnUnselectAll_Click
'                    getSelectedGroupDetails
' Date Created      : 27/04/2012
' Created By        : Vo Ngoc Diep
'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
' 04/05/2012   Vo Ngoc Diep       Adding Select All, Unselect All buttons
'                                 Validation for all fields
' 06/05/2012   Vo Ngoc Diep       Getting selected group details
' 12/05/2012   Vo Ngoc Diep       Validate the gridview, if there is no group found between the selected time period
'------------------------------------------------------------ 

Imports System.Data.SqlClient
Public Class SessionReport
    Inherits System.Web.UI.Page

    Dim cnn As SqlConnection
    Dim cmdstrAdmin As String 'Command String for Admin and Senior Lecturer
    Dim cmdstrLecturer As String 'Command String for Lecturer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Load the page
        If (Session("Rememberme") = "false") Then
            If PB.getAccountType(Session("ID")) = "1" Or PB.getAccountType(Session("ID")) = "2" Or PB.getAccountType(Session("ID")) = "3" Or PB.getAccountType(Session("ID")) = "4" Then
                grdvwReport.Enabled = False 'Set GridView is invisible
                tbxFromDate.Attributes.Add("readonly", "readonly") 'Set "From Date" textbox is readonly
                tbxToDate.Attributes.Add("readonly", "readonly") 'Set "To Date" textbox is readonly
                btnViewReport.Visible = False 'Set "View Report" button is invisible
                btnSelectAll.Visible = False 'Set "Select All" button is invisible
                btnUnselectAll.Visible = False 'Set "Unselect All" button is invisible
            Else
                Response.Redirect("Home.aspx")
            End If
        Else
            If PB.getAccountType(Request.Cookies("ID").Value) = "1" Or PB.getAccountType(Request.Cookies("ID").Value) = "2" Or PB.getAccountType(Request.Cookies("ID").Value) = "3" Or PB.getAccountType(Request.Cookies("ID").Value) = "4" Then
                grdvwReport.Enabled = False 'Set GridView is invisible
                tbxFromDate.Attributes.Add("readonly", "readonly") 'Set "From Date" textbox is readonly
                tbxToDate.Attributes.Add("readonly", "readonly") 'Set "To Date" textbox is readonly
                btnViewReport.Visible = False 'Set "View Report" button is invisible
                btnSelectAll.Visible = False 'Set "Select All" button is invisible
                btnUnselectAll.Visible = False 'Set "Unselect All" button is invisible
            Else
                Response.Redirect("Home.aspx")
            End If
        End If
    End Sub

    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShow.Click
        'Show button is clicked

        lblErrorMessage.Text = ""
        cmdstrAdmin = "SELECT DISTINCT g.semester_name AS 'Semester Name', g.course_id AS 'Course ID', g.group_name AS 'Group Name', g.group_id AS 'Group ID' FROM dbo.schedule AS s INNER JOIN dbo.[group] AS g ON s.group_id = g.group_id INNER JOIN dbo.student_schedule ON s.schedule_id = dbo.student_schedule.schedule_id and (s.date between '" & tbxFromDate.Text & "' and '" & tbxToDate.Text & "')"
        If (Session("Rememberme") = "false") Then 'If username is remembered
            cmdstrLecturer = "SELECT DISTINCT g.semester_name AS 'Semester Name', g.course_id AS 'Course ID', g.group_name AS 'Group Name', g.group_id AS 'Group ID' FROM dbo.schedule AS s INNER JOIN dbo.[group] AS g ON s.group_id = g.group_id INNER JOIN dbo.student_schedule ON s.schedule_id = dbo.student_schedule.schedule_id and (s.date between '" & tbxFromDate.Text & "' and '" & tbxToDate.Text & "') and g.lecturer_id = '" & Session("ID") & "'"
            If PB.getAccountType(Session("ID")) = "4" Then
                getInfo(cmdstrLecturer)
            Else
                getInfo(cmdstrAdmin)
            End If
        Else 'Username is not remembered
            cmdstrLecturer = "SELECT DISTINCT g.semester_name AS 'Semester Name', g.course_id AS 'Course ID', g.group_name AS 'Group Name', g.group_id AS 'Group ID' FROM dbo.schedule AS s INNER JOIN dbo.[group] AS g ON s.group_id = g.group_id INNER JOIN dbo.student_schedule ON s.schedule_id = dbo.student_schedule.schedule_id and (s.date between '" & tbxFromDate.Text & "' and '" & tbxToDate.Text & "') and g.lecturer_id = '" & Request.Cookies("ID").Value & "'"
            If PB.getAccountType(Request.Cookies("ID").Value) = "4" Then
                getInfo(cmdstrLecturer)
            Else
                getInfo(cmdstrAdmin)
            End If
        End If
    End Sub

    Private Sub getInfo(ByVal cmdstr As String)
        'Function to ger info and filled in gridview

        Dim dr As SqlDataReader
        Dim str As String
        Dim cmd As SqlCommand

        str = PB.getConnectionString()

        cnn = New SqlConnection(str)
        Try
            cnn.Open()
            cmd = New SqlCommand(" " & cmdstr & " ", cnn)
            dr = cmd.ExecuteReader
            If dr.Read() Then
                grdvwReport.Enabled = True 'Set GridView is visible
                btnViewReport.Visible = True 'Set "View Report" button is visible
                btnSelectAll.Visible = True 'Set "Select All" button is visible
                btnUnselectAll.Visible = True 'Set "Unselect All" button is visible
                grdvwReport.DataSource = dr
                grdvwReport.DataBind()
            Else
                lblErrorMessage.Text = "Error: There is no group found between selected time period!"
            End If
        Catch ex As Exception
            Response.Write(ex)
            cnn.Close()
        End Try
        cnn.Close()
    End Sub

    Private Function getCheckboxInGridview(ByVal nCell As Integer) As String
        'Function to get info is selected from checkbox
        getCheckboxInGridview = ""
        Dim Chk As New CheckBox
        Dim D As GridViewRow
        For Each D In grdvwReport.Rows
            Chk = D.FindControl("CheckBox1")
            If Chk.Checked = True Then
                getCheckboxInGridview = getCheckboxInGridview + "," + D.Cells(nCell).Text.Trim()
            End If
        Next
        Return getCheckboxInGridview
    End Function

    Private Function getSelectedGroupDetails() As String
        'Function to get selected group details
        getSelectedGroupDetails = ""
        Dim Chk As New CheckBox
        Dim D As GridViewRow
        For Each D In grdvwReport.Rows
            Chk = D.FindControl("CheckBox1")
            If Chk.Checked = True Then
                getSelectedGroupDetails = getSelectedGroupDetails + ", " + D.Cells(1).Text.Trim() + " - " + D.Cells(2).Text.Trim() + " - " + D.Cells(3).Text.Trim()
            End If
        Next
        Return getSelectedGroupDetails
    End Function

    Protected Sub btnViewReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnViewReport.Click
        'View Report button is clicked

        If getCheckboxInGridview(4) = "" Then 'If no checkboxes is checked
            grdvwReport.Enabled = True 'Set GridView is visible
            btnViewReport.Visible = True 'Set "View Report" button is visible
            btnSelectAll.Visible = True 'Set "Select All" button is visible
            btnUnselectAll.Visible = True 'Set "Unselect All" button is visible
            lblErrorMessage.Text = "Error: Please select at least one group!"
        Else
            Session("SelectedGroupDetails_SessionReport") = Right(getSelectedGroupDetails(), getSelectedGroupDetails().Length - 1)
            Session("GroupID_SessionReport") = Right(getCheckboxInGridview(4), getCheckboxInGridview(4).Length - 1)
            Session("start_date_SessionReport") = tbxFromDate.Text
            Session("end_date_SessionReport") = tbxToDate.Text
            Response.Redirect("SessionReportResult.aspx")
        End If
    End Sub

    Private Sub ToggleCheckState(ByVal checkState As Boolean)
        ' Iterate through the grdvwReport.Rows property
        For Each row As GridViewRow In grdvwReport.Rows
            ' Access the CheckBox
            Dim cb As CheckBox = row.FindControl("CheckBox1")
            If cb IsNot Nothing Then
                cb.Checked = checkState
            End If
        Next
    End Sub

    Protected Sub btnSelectAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelectAll.Click
        'Select All button is clicked
        ToggleCheckState(True)
        grdvwReport.Enabled = True 'Set GridView is visible
        btnViewReport.Visible = True 'Set "View Report" button is visible
        btnSelectAll.Visible = True 'Set "Select All" button is visible
        btnUnselectAll.Visible = True 'Set "Unselect All" button is visible
    End Sub

    Protected Sub btnUnselectAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUnselectAll.Click
        'Unselect All button is clicked
        ToggleCheckState(False)
        grdvwReport.Enabled = True 'Set GridView is visible
        btnViewReport.Visible = True 'Set "View Report" button is visible
        btnSelectAll.Visible = True 'Set "Select All" button is visible
        btnUnselectAll.Visible = True 'Set "Unselect All" button is visible
    End Sub

End Class