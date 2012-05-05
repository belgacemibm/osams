'------------------------------------------------------------ 
' File Name         :SummaryReportResult.aspx.vb
' Description       :Allows user to view the report result
' Function List     :Page_Load
'
' Date Created      : 27/04/2012
' Created By        : Vo Ngoc Diep
'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
' 
'------------------------------------------------------------

Public Class ReportResult
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Load the page
        If (Session("Rememberme") = "false") Then
            If PB.getAccountType(Session("ID")) = "5" Then
                Response.Redirect("Home.aspx")
            Else
                lblStartDateResult.Text = Session("start_date")
                lblEndDateResult.Text = Session("end_date")
                lblSelectedGroupResult.Text = Session("GroupName_SummaryReport")
            End If
        Else
            If PB.getAccountType(Request.Cookies("ID").Value) = "5" Then
                Response.Redirect("Home.aspx")
            Else
                lblStartDateResult.Text = Session("start_date")
                lblEndDateResult.Text = Session("end_date")
                lblSelectedGroupResult.Text = Session("GroupName_SummaryReport")
            End If
        End If
    End Sub

End Class