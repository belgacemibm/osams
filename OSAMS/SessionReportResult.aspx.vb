'------------------------------------------------------------ 
' File Name         :SessionReportResult.aspx.vb
' Description       :Allows user to view the report result
' Function List     :Page_Load
'
' Date Created      : 27/04/2012
' Created By        : Vo Ngoc Diep
'------------------------------------------------------------ 
' Date Mod     Modified by        Brief Description  
' 
'------------------------------------------------------------

Public Class SessionReportResult
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Load the page
        If (Session("Rememberme") = "false") Then
            If PB.getAccountType(Session("ID")) = "1" Or PB.getAccountType(Session("ID")) = "2" Or PB.getAccountType(Session("ID")) = "3" Or PB.getAccountType(Session("ID")) = "4" Then
                lblStartDateResult.Text = Session("start_date_SessionReport")
                lblEndDateResult.Text = Session("end_date_SessionReport")
                lblSelectedGroupResult.Text = Session("SelectedGroupDetails_SessionReport")
            Else
                Response.Redirect("Home.aspx")
            End If
        Else
            If PB.getAccountType(Request.Cookies("ID").Value) = "1" Or PB.getAccountType(Request.Cookies("ID").Value) = "2" Or PB.getAccountType(Request.Cookies("ID").Value) = "3" Or PB.getAccountType(Request.Cookies("ID").Value) = "4" Then
                lblStartDateResult.Text = Session("start_date_SessionReport")
                lblEndDateResult.Text = Session("end_date_SessionReport")
                lblSelectedGroupResult.Text = Session("SelectedGroupDetails_SessionReport")
            Else
                Response.Redirect("Home.aspx")
            End If
        End If
    End Sub

End Class