<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="SummaryReportResult.aspx.vb" Inherits="OSAMS.ReportResult" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
<div id="content">
<div class="style18" id="caption">SUMMARY REPORT RESULT</div>
<div id="table" style="text-align: left">
<asp:ScriptManager ID="smScriptManager" runat="server">
    </asp:ScriptManager>


    <asp:Label ID="lblStartDate" runat="server" Font-Bold="True" Text="Start Date:"></asp:Label>
    <asp:Label ID="lblStartDateResult" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblEndDate" runat="server" Font-Bold="True" Text="End Date:"></asp:Label>
    <asp:Label ID="lblEndDateResult" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblSelectedGroup" runat="server" Font-Bold="True" 
        Text="Selected Group:"></asp:Label>
    <asp:Label ID="lblSelectedGroupResult" runat="server"></asp:Label>


    <br />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="10.4in" 
        Height="6.4in" style="margin-right: 0px">
        <LocalReport ReportPath="RDLC\SummaryReport.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="SqlDataSource" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>

    <asp:SqlDataSource ID="SqlDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:connstr %>" 
        SelectCommand="summaryreport2" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="group_id" SessionField="GroupID" Type="String" />
            <asp:SessionParameter Name="start_date" SessionField="start_date" 
                Type="DateTime" />
            <asp:SessionParameter Name="end_date" SessionField="end_date" Type="DateTime" />
        </SelectParameters>
    </asp:SqlDataSource>

</div>
</div>
</div>
</asp:Content>
