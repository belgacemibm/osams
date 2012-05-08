'------------------------------------------------------------ 
' File Name         :SummaryReport.aspx.vb
' Description       :Allows user to select criteria for the report
' Function List     :Page_Load
'                    btnShow_Click
'                    getInfo
'                    getCheckboxInGridview
'                    btnViewReport_Click
'                    getSelectedGroupDetails
' Date Created      : 27/04/2012
' Created By        : Vo Ngoc Diep
'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
' 06/05/2012   Vo Ngoc Diep       Getting selected group details
'------------------------------------------------------------ 

Imports System.Data.SqlClient
Public Class Report
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
            Else
                Response.Redirect("Home.aspx")
            End If
        Else
            If PB.getAccountType(Request.Cookies("ID").Value) = "1" Or PB.getAccountType(Request.Cookies("ID").Value) = "2" Or PB.getAccountType(Request.Cookies("ID").Value) = "3" Or PB.getAccountType(Request.Cookies("ID").Value) = "4" Then
                grdvwReport.Enabled = False 'Set GridView is invisible
                tbxFromDate.Attributes.Add("readonly", "readonly") 'Set "From Date" textbox is readonly
                tbxToDate.Attributes.Add("readonly", "readonly") 'Set "To Date" textbox is readonly
                btnViewReport.Visible = False 'Set "View Report" button is invisible
            Else
                Response.Redirect("Home.aspx")
            End If
        End If
    End Sub

    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShow.Click
        'Show button is clicked

        grdvwReport.Enabled = True 'Set GridView is visible
        btnViewReport.Visible = True 'Set "View Report" button is visible
        cmdstrAdmin = "Select distinct g.semester_name as 'Semester Name', g.course_id as 'Course ID', g.group_name as 'Group Name', g.group_id as 'Group ID' from schedule as s, [group] as g where s.group_id = g.group_id and (s.date between '" & tbxFromDate.Text & "' and '" & tbxToDate.Text & "')"
        If (Session("Rememberme") = "false") Then 'If username is remembered
            cmdstrLecturer = "Select distinct g.semester_name as 'Semester Name', g.course_id as 'Course ID', g.group_name as 'Group Name', g.group_id as 'Group ID' from schedule as s, [group] as g where s.group_id = g.group_id and (s.date between '" & tbxFromDate.Text & "' and '" & tbxToDate.Text & "') and g.lecturer_id = '" & Session("ID") & "'"
            If PB.getAccountType(Session("ID")) = "4" Then
                getInfo(cmdstrLecturer)
            Else
                getInfo(cmdstrAdmin)
            End If
        Else 'Username is not remembered
            cmdstrLecturer = "Select distinct g.semester_name as 'Semester Name', g.course_id as 'Course ID', g.group_name as 'Group Name', g.group_id as 'Group ID' from schedule as s, [group] as g where s.group_id = g.group_id and (s.date between '" & tbxFromDate.Text & "' and '" & tbxToDate.Text & "') and g.lecturer_id = '" & Request.Cookies("ID").Value & "'"
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
            grdvwReport.DataSource = dr
            grdvwReport.DataBind()
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

    Private Function getCountCheckboxInGridview() As Integer
        'Function to count the number of checkboxes is checked
        getCountCheckboxInGridview = 0
        Dim i As Integer
        Dim Chk As New CheckBox
        Dim D As GridViewRow
        For i = 0 To grdvwReport.Rows.Count - 1
            If Chk.Checked = True Then
                getCountCheckboxInGridview = getCountCheckboxInGridview + 1
            Else
                getCountCheckboxInGridview = getCountCheckboxInGridview - 1
            End If
        Next
                Return getCountCheckboxInGridview
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
            lblErrorMessage.Text = "Error: Please select at least one group!"
        ElseIf getCountCheckboxInGridview() > 5 Then
            grdvwReport.Enabled = True 'Set GridView is visible
            btnViewReport.Visible = True 'Set "View Report" button is visible
            lblErrorMessage.Text = "Error: Cannot select more than 5 groups!"
        Else
            Session("SelectedGroupDetails_SummaryReport") = Right(getSelectedGroupDetails(), getSelectedGroupDetails().Length - 1)
            Session("GroupID") = Right(getCheckboxInGridview(4), getCheckboxInGridview(4).Length - 1)
            Session("start_date") = tbxFromDate.Text
            Session("end_date") = tbxToDate.Text
            Response.Redirect("SummaryReportResult.aspx")
        End If
    End Sub

End Class