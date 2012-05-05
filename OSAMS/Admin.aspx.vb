Imports System.Data.SqlClient

Public Class Admin
    Inherits System.Web.UI.Page
    Private currentGender As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
                If (Session("Rememberme") = "false") Then
                    If PB.getAccountType(Session("ID")) = "1" Then
                        If Not Page.IsPostBack Then
                            lblError.ForeColor = System.Drawing.Color.Red
                        Else
                            lblError.ForeColor = System.Drawing.Color.Red
                        End If
                    Else
                Response.Redirect("Home.aspx")
            End If
        Else
            If PB.getAccountType(Request.Cookies("ID").Value) = "1" Then
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

    Protected Sub grdvwAdmin_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdvwAdmin.RowDataBound
        If (e.Row.RowState And DataControlRowState.Edit) = DataControlRowState.Edit Then
            If e.Row.RowType = DataControlRowType.DataRow Then

                Dim dd As DropDownList
                dd = e.Row.FindControl("ddlGender")

                dd.Items.Add("M")
                dd.Items.Add("F")

                'find current value of gender
                If currentGender IsNot Nothing Then
                    dd.Items.FindByValue(currentGender).Selected = True
                End If

            End If
        End If


    End Sub

    Protected Sub grdvwAdmin_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdvwAdmin.RowEditing
        Dim gender As String
        gender = TryCast(grdvwAdmin.Rows(e.NewEditIndex).FindControl("lblGender"), Label).Text
        currentGender = gender
    End Sub

    Protected Sub grdvwAdmin_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdvwAdmin.RowUpdating
        Dim staffId, family_name, middle_name, given_name, gender, email As String
        Dim active As Integer

        staffId = grdvwAdmin.Rows(e.RowIndex).Cells(1).Text

        Dim family_nameTXT As TextBox = TryCast(grdvwAdmin.Rows(e.RowIndex).FindControl("txtFamilyName"), TextBox)
        family_name = family_nameTXT.Text
        Dim middle_nameTXT As TextBox = TryCast(grdvwAdmin.Rows(e.RowIndex).FindControl("txtMiddleName"), TextBox)
        middle_name = middle_nameTXT.Text
        Dim given_nameTXT As TextBox = TryCast(grdvwAdmin.Rows(e.RowIndex).FindControl("txtGivenName"), TextBox)
        given_name = given_nameTXT.Text
        Dim genderDDL As DropDownList = TryCast(grdvwAdmin.Rows(e.RowIndex).FindControl("ddlGender"), DropDownList)
        gender = genderDDL.SelectedValue

        Dim emailTXT As TextBox = TryCast(grdvwAdmin.Rows(e.RowIndex).FindControl("txtEmail"), TextBox)
        email = emailTXT.Text
        Dim activeCB As CheckBox = TryCast(grdvwAdmin.Rows(e.RowIndex).FindControl("cbActive"), CheckBox)
        If activeCB.Checked = True Then
            active = 1
        Else
            active = 0
        End If
        'validate blank fields
        If family_nameTXT.Text = "" Or given_nameTXT.Text = "" Or emailTXT.Text = "" Then

            lblError.Text = "Error: Family Name, Given Name, Email must not be blank"
            e.Cancel = True
        Else
            lblError.Text = ""

            'get connection 
            Dim connection As New SqlConnection(PB.getConnectionString())
            Dim updateAdminStatement, updateAccountStatement As String

            updateAdminStatement = "UPDATE [admin] SET [family_name] = @family_name, [middle_name] = @middle_name, [given_name] = @given_name, [gender] = @gender, [email] = @email, [active] = '1' WHERE [staff_id]= @staff_id"
            updateAccountStatement = "UPDATE [account] SET [active] = @active WHERE [account].[user_name] = '" & staffId & "'"

            Try

                connection.Open()

                Dim cmd2 As New SqlCommand(updateAdminStatement, connection)
                Dim cmd3 As New SqlCommand(updateAccountStatement, connection)


                cmd2.Parameters.AddWithValue("@staff_id", staffId)
                cmd2.Parameters.AddWithValue("@family_name", family_name)
                cmd2.Parameters.AddWithValue("@middle_name", middle_name)
                cmd2.Parameters.AddWithValue("@given_name", given_name)
                cmd2.Parameters.AddWithValue("@gender", gender)
                cmd2.Parameters.AddWithValue("@email", email)

                cmd3.Parameters.AddWithValue("@active", active)


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
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNewAdmin.Click
        Response.Redirect("AddAdmin.aspx")
    End Sub

    Protected Sub grdvwAdmin_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdvwAdmin.RowCancelingEdit
        lblError.Text = ""
    End Sub
End Class