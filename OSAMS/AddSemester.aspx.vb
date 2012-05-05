﻿'------------------------------------------------------------ 
'File Name          :AddSemester.vb
' Description       :Indicate the process of add semester
' Function List     :fillYearList()


'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
'    ------------------------------------------------------------ 
' 17/04/2012   Nguyen Tran Dang Khoa     Add Semester
'------------------------------------------------------------ 


Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Data.SqlClient
Public Class AddSemester
    Inherits System.Web.UI.Page


    ' Declare parameters
    Private nonqueryCommand As SqlCommand
    Private selectqueryCommand As SqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '------------------------------------------------------------ 
        ' Aim           : Set Attribute "read only" for Textbox
        '               : Add year list in the list box            
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : 
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            :     

        'textbox read only
        txtStartDate.Attributes.Add("readonly", "readonly")
        txtEndDate.Attributes.Add("readonly", "readonly")

        If (Session("Rememberme") = "false") Then
            If PB.getAccountType(Session("ID")) = "1" Or PB.getAccountType(Session("ID")) = "2" Then
                ' fill year list
                If Not Page.IsPostBack Then
                    fillYearList()
                End If
            Else
                Response.Redirect("Home.aspx")
            End If
        Else
            If PB.getAccountType(Request.Cookies("ID").Value) = "1" Or PB.getAccountType(Request.Cookies("ID").Value) = "2" Then
                ' fill year list
                If Not Page.IsPostBack Then
                    fillYearList()
                End If
            Else
                Response.Redirect("Home.aspx")
            End If
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        '------------------------------------------------------------ 
        ' Aim           : Add semester
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        '     This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : 
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            : semester_name, start_date, end_date


        ' create a new SqlConnection object with the appropriate connection string 
        Dim connection As New SqlConnection(PB.getConnectionString())
        ' Open Connection
        connection.Open()

        'Declare variables and get value from fields
        Dim startDate As String = txtStartDate.Text
        Dim endDate As String = txtEndDate.Text
        Dim startDateString As String
        Dim endDateString As String
        Dim count As Integer
        Dim strYearOrder As String = ddlYear.SelectedItem.ToString + ddlOrder.SelectedItem.ToString


        ' Convert start date and end date to string yyyy-MM-dd
        startDateString = CDate(startDate).ToString("yyyyMMdd")
        endDateString = CDate(endDate).ToString("yyyyMMdd")


        'Create select query to count semester
        Dim str As String = "select count (*) name from semester where semester_name = '" + strYearOrder + "'"

        selectqueryCommand = New SqlCommand(str, connection)


        ' Check start date and end date
        If startDateString > endDateString Then

            lblError.Text = "Error: End date must greater than start date"
        Else
            If txtEndDate.Text < Today Then

                lblError.Text = "Error: End Date must greater than today  "
            Else
                count = Convert.ToInt32(selectqueryCommand.ExecuteScalar)



                ' Check duplicate semester
                If (count > 0) Then

                    lblError.Text = "Error: The semester has been existed"


                Else
                    ' Create INSERT statement with named parameters and execute insert query
                    nonqueryCommand = New SqlCommand("INSERT  INTO semester (semester_name, start_date, end_date, active) VALUES ('" & strYearOrder & "','" & startDateString & "','" & endDateString & "','" & "1" & "')", connection)
                    nonqueryCommand.ExecuteNonQuery()

                    ' Display message to confirm
                    lblError.ForeColor = System.Drawing.Color.Black
                    lblError.Text = "The semester " + strYearOrder + " has been created successfully"

                    'Call ClearTextBoxes()
                    txtStartDate.Text = ""
                    txtEndDate.Text = ""
                End If

            End If

        End If

        ' Close Connection
        connection.Close()

    End Sub
    Public Sub fillYearList()
        '------------------------------------------------------------ 
        ' Aim           : Fill two years continuous in dropdownlist
        '              
        ' Edit/Create by: Nguyen Tran Dang Khoa
        ' Date          : 17/04/2012
        ' This function is created in reference of materials in RMIT VN BlackBoard

        '------------------------------------------------------------ 
        ' Incoming Parameters    : 
        '                                 
        ' Outgoing Parameters    :  
        '                          
        ' Return data            : year list     

        ' Declare variables
        Dim list As New List(Of String)()
        Dim year1 As Integer = Year(Now())
        ' Add continuous year
        Dim year2 As Integer = Year(DateAdd("yyyy", 1, Now))


        'Add year in dropdownlist
        ddlYear.Items.Add(New ListItem(year1.ToString, year1.ToString))
        ddlYear.Items.Add(New ListItem(year2.ToString, year2.ToString))



    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("Semester.aspx")

    End Sub


End Class