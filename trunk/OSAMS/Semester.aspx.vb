'------------------------------------------------------------ 
'File Name          :semester.vb
' Description       :Indicate the process of add semester
' Function List     : edit semester
'                   : row databound
'                   : row editing
'                   : row cancel editing
'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
'    ------------------------------------------------------------ 
' 17/04/2012   Nguyen Tran Dang Khoa     Semester
'------------------------------------------------------------ 
Imports System.Data.SqlClient

Public Class Semester
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '------------------------------------------------------------ 
        ' Aim           : validate session for each type of users
        '               : set the message back to red color    
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
                    lblError.ForeColor = System.Drawing.Color.Red
                Else
                    lblError.ForeColor = System.Drawing.Color.Red
                End If
            Else
                Response.Redirect("Home.aspx")
            End If
        Else
            If PB.getAccountType(Request.Cookies("ID").Value) = "1" Or PB.getAccountType(Request.Cookies("ID").Value) = "2" Then
                If Not Page.IsPostBack Then
                    lblError.ForeColor = System.Drawing.Color.Red
                Else
                    lblError.ForeColor = System.Drawing.Color.Red
                End If
            Else
                Response.Redirect("Home.aspx")
            End If
        End If

    End Sub

    Protected Sub btnAddSemester_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddSemester.Click
        'Edit semester will back to add semester
        Response.Redirect("AddSemester.aspx")
    End Sub

    Protected Sub grdvwSemester_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdvwSemester.RowDataBound

        '------------------------------------------------------------ 
        ' Aim           : Row Databound
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : start date, end date
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            :


        If (e.Row.RowState And DataControlRowState.Edit) =
        DataControlRowState.Edit Then
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim startDate, endDate As TextBox
                'find control start date, end date
                startDate = e.Row.FindControl("txtStartDate")
                endDate = e.Row.FindControl("txtEndDate")

                'add "read only" attribute to start date, end date
                startDate.Attributes.Add("readonly", "readonly")
                endDate.Attributes.Add("readonly", "readonly")

            End If
        End If
    End Sub

    Protected Sub grdvwSemester_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdvwSemester.RowUpdating
        '------------------------------------------------------------ 
        ' Aim           : Row Updating
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : semester name, start date, end date
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            :

        'declare start date, end date control
        Dim startDate, endDate As TextBox
        'declare semester name, start date string, end date string, start date compare with end date
        Dim semester_name, startDateString, endDateString, startDateCompare, endDateCompare As String
        'get connection
        Dim connection As New SqlConnection(PB.getConnectionString())
        Dim updateSqlStatement As String = String.Empty

        'find control
        semester_name = grdvwSemester.Rows(e.RowIndex).Cells(1).Text
        startDate = TryCast(grdvwSemester.Rows(e.RowIndex).FindControl("txtStartDate"), TextBox)
        startDateString = startDate.Text
        endDate = TryCast(grdvwSemester.Rows(e.RowIndex).FindControl("txtEndDate"), TextBox)
        endDateString = endDate.Text
        'convert date
        startDateCompare = CDate(startDateString).ToString("yyyyMMdd")
        endDateCompare = CDate(endDateString).ToString("yyyyMMdd")
        ' select semester
        Dim extra As Boolean = PB.checkEsixtedData("select * from [group] where semester_name = '" & semester_name & "'")
        If extra = True Then
            'validate semester already have a group
            lblError.Text = "Error: This semester already containt the group. You are not allowed to change"
            e.Cancel = True
        Else
            'compare start date, end date
            If startDateCompare > endDateCompare Then
                lblError.Text = "Error: End date must greater than start date"
                e.Cancel = True
            Else
                'validate end date must greater or equal today creating
                If CDate(endDateString).ToString("MM/dd/yyyy") < Today Then
                    lblError.Text = "Error: End date must equal or greater than today"
                    e.Cancel = True
                Else
                    Try
                        'open connection
                        connection.Open()
                        lblError.Text = ""
                        'update query
                        updateSqlStatement = " UPDATE [semester] SET [start_date] = @start_date, [end_date] = @end_date, [active] = '1' WHERE [semester_name] = @semester_name AND [active] = '1'"
                        'get sql connection
                        Dim cmd As New SqlCommand(updateSqlStatement, connection)

                        'add value
                        cmd.Parameters.AddWithValue("@semester_name", semester_name)
                        cmd.Parameters.AddWithValue("@start_date", startDateString)
                        cmd.Parameters.AddWithValue("@end_date", endDateString)
                        'command sql
                        cmd.CommandType = CommandType.Text
                        'execute query
                        cmd.ExecuteNonQuery()


                    Catch ex As System.Data.SqlClient.SqlException
                        Dim msg As String = "Insert/Update Error:"
                        msg += ex.Message
                        Throw New Exception(msg)
                    Finally
                        'close connection
                        connection.Close()
                    End Try

                End If


            End If

        End If
    End Sub

    Protected Sub grdvwSemester_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdvwSemester.RowCancelingEdit
        '------------------------------------------------------------ 
        ' Aim           : Cancel editing
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : clear textbox
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            :
        'clear message
        lblError.Text = ""
    End Sub
End Class