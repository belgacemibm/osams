'------------------------------------------------------------ 
'File Name          :lecturer.vb
' Description       :Indicate the process of add semester
' Function List     : 

'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
'    ------------------------------------------------------------ 
' 17/04/2012   Nguyen Tran Dang Khoa     Lecturer
'------------------------------------------------------------ 
Imports System.Data.SqlClient

Public Class Lecturer
    Inherits System.Web.UI.Page
    'declare variables
    Private currentGender As String
    Private currentAccountType As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("Rememberme") = "false") Then
            If PB.getAccountType(Session("ID")) = "1" Or PB.getAccountType(Session("ID")) = "2" Then
                
            Else
                Response.Redirect("Home.aspx")
            End If
        Else
            If PB.getAccountType(Request.Cookies("ID").Value) = "1" Or PB.getAccountType(Request.Cookies("ID").Value) = "2" Then
                
            Else
                Response.Redirect("Home.aspx")
            End If
        End If
    End Sub

    Protected Sub btnAddNewLecturer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddNewLecturer.Click
        'Direct to add lecturer page
        Response.Redirect("AddLecturer.aspx")
    End Sub


    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdvwLecturer.RowUpdating
        '------------------------------------------------------------ 
        ' Aim           : Update lecturer
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : lecturer_id, family_name, middle_name, given_name, gender, mail, program, stream,  group_name
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            : 


        'Declare variables
        Dim lecturer_id As String
        Dim family_name, middle_name, given_name, gender, email, accountType, password As String
        Dim active As Integer
        'get textbox, dropdownlist control value
        lecturer_id = grdvwLecturer.Rows(e.RowIndex).Cells(1).Text
        
        family_name = DirectCast(grdvwLecturer.Rows(e.RowIndex).Cells(2).Controls(0), TextBox).Text
        middle_name = DirectCast(grdvwLecturer.Rows(e.RowIndex).Cells(3).Controls(0), TextBox).Text
        given_name = DirectCast(grdvwLecturer.Rows(e.RowIndex).Cells(4).Controls(0), TextBox).Text
        email = DirectCast(grdvwLecturer.Rows(e.RowIndex).Cells(6).Controls(0), TextBox).Text
        active = 1


        Dim accountTypeDDL As DropDownList = TryCast(grdvwLecturer.Rows(e.RowIndex).FindControl("ddlAccountType"), DropDownList)
        accountType = accountTypeDDL.SelectedValue


        'get connection 
        Dim connection As New SqlConnection(PB.getConnectionString())
        Dim sqlStatement As String = String.Empty
        Dim updateSqlStatement As String = String.Empty
        Dim selectSqlStatement As String


        Dim genderDDL As DropDownList = TryCast(grdvwLecturer.Rows(e.RowIndex).FindControl("ddlGender"), DropDownList)
        gender = genderDDL.SelectedValue

        password = DirectCast(grdvwLecturer.Rows(e.RowIndex).Cells(8).Controls(0), TextBox).Text

        Dim accountTypeID As Integer

        Dim strEmail = "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"

        Dim myRegex As New Regex(strEmail)


        'select query
        selectSqlStatement = " Select account_type_id from account_type where account_type.[account_type] = @account_type"
        'update query
        sqlStatement = "UPDATE [lecturer] SET [family_name] = @family_name, [middle_name] = @middle_name, [given_name] = @given_name, [gender] = @gender, [email] = @email, [active] = '1' WHERE [lecturer_id] = @lecturer_id AND [active]= '1'"

        updateSqlStatement = "UPDATE [account] SET [account_type_id] = @accountTypeID, [password] = @password where [user_name] = @lecturer_id"

        'validate blank fields
        If family_name = "" Or given_name = "" Or email = "" Or password = "" Then

            lblError.Text = "Error: Family Name, Given Name, Email and Password must not be blank"
            e.Cancel = True
        Else
            If Not myRegex.IsMatch(email) Then
                lblError.Text = "Error: Email is not correct format"
                e.Cancel = True
            Else
                Try
                    'execute query
                    Dim cmd1 As New SqlCommand(selectSqlStatement, connection)
                    'add value in account type
                    cmd1.Parameters.AddWithValue("@account_type", accountType)
                    lblError.Text = ""
                    'open connection
                    connection.Open()
                    'get value of account tyoe
                    Using reader As SqlDataReader = cmd1.ExecuteReader()
                        While reader.Read()
                            For i As Integer = 0 To reader.FieldCount - 1
                                accountTypeID = reader.GetValue(i)

                            Next

                        End While
                    End Using
                    'get query connection
                    Dim cmd2 As New SqlCommand(sqlStatement, connection)
                    Dim cmd3 As New SqlCommand(updateSqlStatement, connection)

                    'get value 
                    cmd2.Parameters.AddWithValue("@lecturer_id", lecturer_id)
                    cmd2.Parameters.AddWithValue("@family_name", family_name)
                    cmd2.Parameters.AddWithValue("@middle_name", middle_name)
                    cmd2.Parameters.AddWithValue("@given_name", given_name)
                    cmd2.Parameters.AddWithValue("@gender", gender)
                    cmd2.Parameters.AddWithValue("@email", email)
                    cmd2.Parameters.AddWithValue("@active", active)
                    cmd2.Parameters.AddWithValue("@account_type", accountType)


                    cmd3.Parameters.AddWithValue("@lecturer_id", lecturer_id)
                    cmd3.Parameters.AddWithValue("@accountTypeID", accountTypeID)
                    cmd3.Parameters.AddWithValue("@password", password)

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

                End Try
            End If
        End If
    End Sub
    
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        grdvwLecturer.EditIndex = e.NewEditIndex
        ' turn to edit mode
        BindGridView()
        ' Rebind GridView to show the data in edit mode
    End Sub

    Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)
        grdvwLecturer.EditIndex = -1
        'swicth back to default mode
        BindGridView()
        ' Rebind GridView to show the data in default mode
    End Sub
    Private Sub BindGridView()
        '------------------------------------------------------------ 
        ' Aim           : Bind lecturer
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

        'declare data table
        Dim dt As New DataTable()
        'get connection
        Dim connection As New SqlConnection(PB.getConnectionString())
        Try
            'open connection
            connection.Open()
            'select query
            Dim sqlStatement As String = "SELECT * FROM lecturer"
            Dim cmd As New SqlCommand(sqlStatement, connection)
            Dim sqlDa As New SqlDataAdapter(cmd)
            'fill database
            sqlDa.Fill(dt)
            'bind database
            If dt.Rows.Count > 0 Then
                grdvwLecturer.DataSource = dt
                grdvwLecturer.DataBind()
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

    Function getLecturerType(ByVal ID As String) As String
        '------------------------------------------------------------ 
        ' Aim           : get lecturer type
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : 
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            : getLecturerType

        'declare connection
        Dim cnn As SqlConnection
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        getLecturerType = ""
        'declare variables
        Dim str As String
        'get connection
        str = PB.getConnectionString()

        cnn = New SqlConnection(str)
        Try
            'open connection
            cnn.Open()
            'select query
            cmd = New SqlCommand("Select * from Account where user_name = '" & ID & "'", cnn)
            dr = cmd.ExecuteReader
            'select account type id
            While dr.Read
                getLecturerType = dr("account_type_id")
            End While

        Catch ex As Exception
            Response.Write(ex)
            cnn.Close()
        End Try
        'close connection
        cnn.Close()
        Return getLecturerType
    End Function

   

   
    Protected Sub ddlAccountType_DataBound(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Protected Sub grdvwLecturer_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdvwLecturer.RowDataBound
        '------------------------------------------------------------ 
        ' Aim           : row data bound
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
                'declare dropdown list
                Dim ee As DropDownList
                Dim dd As DropDownList
                'find control
                ee = e.Row.FindControl("ddlAccountType")
                dd = e.Row.FindControl("ddlGender")
                'add value to account type control
                ee.Items.Add("Senior Lecturer")
                ee.Items.Add("Lecturer")
                'add value to gender control
                dd.Items.Add("M")
                dd.Items.Add("F")
                'select current value of gender
                If currentGender IsNot Nothing Then
                    dd.Items.FindByValue(currentGender).Selected = True
                End If
                'select current value of account type
                If currentAccountType IsNot Nothing Then
                    ee.Items.FindByValue(currentAccountType).Selected = True
                End If


            End If

        End If

    End Sub

    Protected Sub grdvwLecturer_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdvwLecturer.RowEditing
        '------------------------------------------------------------ 
        ' Aim           : edit lecturer
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
        Dim gender As String
        Dim accountType As String
        'find control 
        gender = TryCast(grdvwLecturer.Rows(e.NewEditIndex).FindControl("lblGender"), Label).Text
        accountType = TryCast(grdvwLecturer.Rows(e.NewEditIndex).FindControl("lblAccountType"), Label).Text
        'select current value
        currentGender = gender
        currentAccountType = accountType
    End Sub

    Protected Sub grdvwLecturer_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdvwLecturer.RowCancelingEdit
        lblError.Text = ""
    End Sub
End Class