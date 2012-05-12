'------------------------------------------------------------ 
'File Name          :lecturer.vb
' Description       :Indicate the process of add semester
' Function List     : edit lecturer
'                   : get lecturer type()
'                   : row databound
'                   : row editing
'                   : row updating

'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
'    ------------------------------------------------------------ 
' 17/04/2012   Nguyen Tran Dang Khoa     Lecturer
'------------------------------------------------------------ 
Imports System.Data.SqlClient

Public Class Lecturer
    Inherits System.Web.UI.Page
    'declare current position
    Private currentGender As String
    Private currentAccountType As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '------------------------------------------------------------ 
        ' Aim           : validate session for each type of users
        '               : set the message back to red color    
        '               : bind data into gridview
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
                    bind_data()
                    lblError.ForeColor = System.Drawing.Color.Red
                    lblError.Text = ""
                Else
                    lblError.ForeColor = System.Drawing.Color.Red
                    lblError.Text = ""
                End If
            Else
                Response.Redirect("Home.aspx")
            End If
        Else
            If PB.getAccountType(Request.Cookies("ID").Value) = "1" Or PB.getAccountType(Request.Cookies("ID").Value) = "2" Then
                If Not Page.IsPostBack Then
                    bind_data()
                    lblError.ForeColor = System.Drawing.Color.Red
                    lblError.Text = ""
                Else
                    lblError.ForeColor = System.Drawing.Color.Red
                    lblError.Text = ""
                End If
            Else
                Response.Redirect("Home.aspx")
            End If
        End If
    End Sub

    Protected Sub btnAddNewLecturer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddNewLecturer.Click
        'Edit lecturer will back to add lecturer page
        Response.Redirect("AddLecturer.aspx")
    End Sub

    Function getLecturerType(ByVal ID As String) As String
        '------------------------------------------------------------ 
        ' Aim           : get lecturer type
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : account_id, user_name, password, account_type_id 
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
            cmd = New SqlCommand("Select * from [account] where user_name = '" & ID & "'", cnn)
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

    Protected Sub grdvwLecturer_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdvwLecturer.RowDataBound
        '------------------------------------------------------------ 
        ' Aim           : row data bound
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : dropdownlist account_type, gender
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
        ' Incoming Parameters    : label gender, account type
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            : 

        'declare variables
        Dim gender As String
        Dim accountType As String
        'find control gender, account type
        gender = TryCast(grdvwLecturer.Rows(e.NewEditIndex).FindControl("lblGender"), Label).Text
        accountType = TryCast(grdvwLecturer.Rows(e.NewEditIndex).FindControl("lblAccountType"), Label).Text
        'select current value
        currentGender = gender
        currentAccountType = accountType

        grdvwLecturer.EditIndex = e.NewEditIndex
        ' bind database
        bind_data()
        ' bind find database
        find()

        ' Rebind GridView to show the data in edit mode
    End Sub

    Protected Sub grdvwLecturer_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdvwLecturer.RowCancelingEdit
        '------------------------------------------------------------ 
        ' Aim           : cancel editing
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
        'clear message
        lblError.Text = ""

        grdvwLecturer.EditIndex = -1
        'swicth back to default mode
        bind_data()
        'bind find database
        find()

        ' Rebind GridView to show the data in default mode
    End Sub
    Public Sub bind_data()
        '------------------------------------------------------------ 
        ' Aim           : edit lecturer
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : lecturer id, family name, middle name, given name, gender, email, active, account type, password
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            : 

        Dim loadStr As String = "SELECT lecturer.lecturer_id, lecturer.family_name, lecturer.middle_name, lecturer.given_name, lecturer.gender, lecturer.email, lecturer.active, account_type.account_type, account.password FROM lecturer INNER JOIN account ON lecturer.lecturer_id = account.[user_name] INNER JOIN account_type ON account.account_type_id = account_type.account_type_id"

        Dim ds As New DataSet()
        'get connection
        Dim connection As New SqlConnection(PB.getConnectionString())
        Try
            'open connection
            connection.Open()
            'execute query
            Dim cmd As New SqlCommand(loadStr, connection)
            Dim sqlDa As New SqlDataAdapter(cmd)

            'fill database
            sqlDa.Fill(ds)

            grdvwLecturer.DataSource = ds.Tables(0)
            grdvwLecturer.DataBind()

        Catch ex As System.Data.SqlClient.SqlException
            Dim msg As String = "Fetch Error:"
            msg += ex.Message
            Throw New Exception(msg)
        Finally
            'close connection
            connection.Close()
        End Try
    End Sub

    Protected Sub grdvwLecturer_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdvwLecturer.RowUpdating
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

        Dim lecturer_id, family_name, middle_name, given_name, gender, email, password, accountType As String
        Dim active As Integer
        'get textbox, dropdownlist control value
        'find control lecturer id, family name, middle name, given name, email, account type dropdownlist, gender dropdownlist, password 
        Dim row As GridViewRow = DirectCast(grdvwLecturer.Rows(e.RowIndex), GridViewRow)
        Dim lecturer_idLB As Label = DirectCast(row.FindControl("lecturer_id"), Label)
        lecturer_id = lecturer_idLB.Text
        Dim family_nameTXT As TextBox = DirectCast(row.FindControl("family_name"), TextBox)
        family_name = family_nameTXT.Text
        Dim middle_nameTXT As TextBox = DirectCast(row.FindControl("middle_name"), TextBox)
        middle_name = middle_nameTXT.Text
        Dim given_nameTXT As TextBox = DirectCast(row.FindControl("given_name"), TextBox)
        given_name = given_nameTXT.Text
        Dim emailTXT As TextBox = DirectCast(row.FindControl("email"), TextBox)
        email = emailTXT.Text
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

        Dim passwordTXT As TextBox = DirectCast(row.FindControl("password"), TextBox)
        password = passwordTXT.Text


        Dim accountTypeID As Integer

        ' validate email
        Dim strEmail = "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"

        Dim myRegex As New Regex(strEmail)


        'select query
        selectSqlStatement = "Select account_type_id from account_type where account_type.[account_type] = @account_type"
        'update query
        sqlStatement = "UPDATE [lecturer] SET [family_name] = @family_name, [middle_name] = @middle_name, [given_name] = @given_name, [gender] = @gender, [email] = @email, [active] = '1' WHERE [lecturer_id] = @lecturer_id AND [active]= '1'"

        updateSqlStatement = "UPDATE [account] SET [account_type_id] = @accountTypeID, [password] = @password where [user_name] = @lecturer_id"

        'validate blank fields
        If family_name = "" Or given_name = "" Or email = "" Or password = "" Then

            lblError.Text = "Error: Family Name, Given Name, Email and Password must not be blank"
            e.Cancel = True
        Else
            'validate email
            If Not myRegex.IsMatch(email) Then
                lblError.Text = "Error: Email is not correct format"
                e.Cancel = True
            Else
                Try
                    lblError.Text = ""

                    grdvwLecturer.EditIndex = -1
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

                    'add value lecturer id, family name, middle name, given name, gender, email, active, account type
                    cmd2.Parameters.AddWithValue("@lecturer_id", lecturer_id)
                    cmd2.Parameters.AddWithValue("@family_name", family_name)
                    cmd2.Parameters.AddWithValue("@middle_name", middle_name)
                    cmd2.Parameters.AddWithValue("@given_name", given_name)
                    cmd2.Parameters.AddWithValue("@gender", gender)
                    cmd2.Parameters.AddWithValue("@email", email)
                    cmd2.Parameters.AddWithValue("@active", active)
                    cmd2.Parameters.AddWithValue("@account_type", accountType)

                    'add value lecturer id, account type id, password
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
                    bind_data()
                    find()
                End Try
            End If
        End If
    End Sub

    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFind.Click
        '------------------------------------------------------------ 
        ' Aim           : find
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : lecturer id, family name, middle name, given name, gender, email, active, account type, password
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            : 

        'Defint find query
        Dim findStr As String = "SELECT lecturer.lecturer_id, lecturer.family_name, lecturer.middle_name, lecturer.given_name, lecturer.gender, lecturer.email, lecturer.active, account_type.account_type, account.password FROM lecturer INNER JOIN account ON lecturer.lecturer_id = account.[user_name] INNER JOIN account_type ON account.account_type_id = account_type.account_type_id Where lecturer.lecturer_id like '%" & txtSearch.Text & "%' or lecturer.family_name like '%" & txtSearch.Text & "%' or lecturer.middle_name like '%" & txtSearch.Text & "%' or lecturer.given_name like '%" & txtSearch.Text & "%' or lecturer.email like '%" & txtSearch.Text & "%' or account_type.account_type like '%" & txtSearch.Text & "%'"
        'Define connection string, sql command and sql data reader
        Dim strConn As String
        strConn = PB.getConnectionString()
        Dim connection As New SqlConnection(strConn)
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        Try
            connection.Open()

            ' Initialize the SqlCommand with the new SQL string.
            cmd = New SqlCommand(findStr, connection)
            dr = cmd.ExecuteReader()
            If (dr.HasRows) Then
                grdvwLecturer.AllowPaging = False
                grdvwLecturer.DataSource = dr
                grdvwLecturer.DataBind()

            Else
                grdvwLecturer.AllowPaging = True
                lblError.ForeColor = System.Drawing.Color.Black
                lblError.Text = "No lecturer found"
            End If

            connection.Close()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub find()
        '------------------------------------------------------------ 
        ' Aim           : edit lecturer
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : label gender, account type
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            : 
        Dim findStr As String = "SELECT lecturer.lecturer_id, lecturer.family_name, lecturer.middle_name, lecturer.given_name, lecturer.gender, lecturer.email, lecturer.active, account_type.account_type, account.password FROM lecturer INNER JOIN account ON lecturer.lecturer_id = account.[user_name] INNER JOIN account_type ON account.account_type_id = account_type.account_type_id Where lecturer.lecturer_id like '%" & txtSearch.Text & "%' or lecturer.family_name like '%" & txtSearch.Text & "%' or lecturer.middle_name like '%" & txtSearch.Text & "%' or lecturer.given_name like '%" & txtSearch.Text & "%' or lecturer.email like '%" & txtSearch.Text & "%' or account_type.account_type like '%" & txtSearch.Text & "%'"

        Dim strConn As String
        strConn = PB.getConnectionString()
        Dim connection As New SqlConnection(strConn)
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        Try
            connection.Open()

            ' Initialize the SqlCommand with the new SQL string.
            cmd = New SqlCommand(findStr, connection)
            dr = cmd.ExecuteReader()
            If (dr.HasRows) Then
                grdvwLecturer.AllowPaging = False
                grdvwLecturer.DataSource = dr
                grdvwLecturer.DataBind()

            Else
                grdvwLecturer.AllowPaging = True
                grdvwLecturer.DataSource = ""
                grdvwLecturer.DataBind()
                lblError.ForeColor = System.Drawing.Color.Black
                lblError.Text = "No lecturer found"
            End If

            connection.Close()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClear.Click
        '------------------------------------------------------------ 
        ' Aim           : Clear
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : search text box
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            : 

        'clear search
        txtSearch.Text = ""
        ' bind find database
        find()
    End Sub
End Class