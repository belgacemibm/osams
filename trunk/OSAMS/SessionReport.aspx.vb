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
' Date Created      : 27/04/2012
' Created By        : Vo Ngoc Diep
'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
' 04/05/2012   Vo Ngoc Diep       Adding Select All, Unselect All buttons
'                                 Validation for all fields
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
            If PB.getAccountType(Session("ID")) = "5" Then
                Response.Redirect("Home.aspx")
            Else
                grdvwReport.Enabled = False 'Set GridView is invisible
                btnViewReport.Visible = False 'Set "View Report" button is invisible
                btnSelectAll.Visible = False 'Set "Select All" button is invisible
                btnUnselectAll.Visible = False 'Set "Unselect All" button is invisible
            End If
        Else
            If PB.getAccountType(Request.Cookies("ID").Value) = "5" Then
                Response.Redirect("Home.aspx")
            Else
                grdvwReport.Enabled = False 'Set GridView is invisible
                btnViewReport.Visible = False 'Set "View Report" button is invisible
                btnSelectAll.Visible = False 'Set "Select All" button is invisible
                btnUnselectAll.Visible = False 'Set "Unselect All" button is invisible
            End If
        End If
    End Sub

    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShow.Click
        'Show button is clicked

        grdvwReport.Enabled = True 'Set GridView is visible
        btnViewReport.Visible = True 'Set "View Report" button is visible
        btnSelectAll.Visible = True 'Set "Select All" button is visible
        btnUnselectAll.Visible = True 'Set "Unselect All" button is visible
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

    Protected Sub btnViewReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnViewReport.Click
        'View Report button is clicked

        If getCheckboxInGridview(4) = "" Then 'If no checkboxes is checked
            grdvwReport.Enabled = True 'Set GridView is visible
            btnViewReport.Visible = True 'Set "View Report" button is visible
            btnSelectAll.Visible = True 'Set "Select All" button is visible
            btnUnselectAll.Visible = True 'Set "Unselect All" button is visible
            lblErrorMessage.Text = "Error: Please select at least one group!"
        Else
            Session("GroupName_SessionReport") = Right(getCheckboxInGridview(3), getCheckboxInGridview(3).Length - 1)
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