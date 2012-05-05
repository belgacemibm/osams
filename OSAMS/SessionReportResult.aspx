<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="SessionReportResult.aspx.vb" Inherits="OSAMS.SessionReportResult" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="big_content">
<div id="content">
<div class="style18" id="caption">SESSION REPORT RESULT</div>
<div id="table">




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
        Font-Size="8pt" Height="525px" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1024px">
        <LocalReport ReportPath="RDLC\SessionReport.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:connstr %>" 
        SelectCommand="SessionReport" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="group_id" SessionField="GroupID_SessionReport" 
                Type="String" />
            <asp:SessionParameter Name="start_date" SessionField="start_date_SessionReport" 
                Type="DateTime" />
            <asp:SessionParameter Name="end_date" SessionField="end_date_SessionReport" 
                Type="DateTime" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>




</div>
</div>
</div>
</asp:Content>
