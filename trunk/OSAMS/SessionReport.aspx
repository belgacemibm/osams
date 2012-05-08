<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="SessionReport.aspx.vb" Inherits="OSAMS.SessionReport" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
<div id="content">
<div id="content_header">
     <div id="content_header_logo"><img alt="logo" src="images/icons/chart_up.png" width="50" height="50" /></div>
     <div id="caption">SESSION REPORT</div>
</div>
<div id="table">

<asp:Label ID="lblFromDate" runat="server" Text="From Date:"></asp:Label>
&nbsp;<asp:TextBox ID="tbxFromDate" runat="server"></asp:TextBox>
    <asp:CalendarExtender ID="tbxFromDate_CalendarExtender" runat="server" 
        TargetControlID="tbxFromDate" Format="d MMMM, yyyy">
    </asp:CalendarExtender>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="tbxFromDate" ErrorMessage="From Date must be entered">*</asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblToDate" runat="server" Text="To Date:"></asp:Label>
&nbsp;<asp:TextBox ID="tbxToDate" runat="server"></asp:TextBox>
    <asp:CalendarExtender ID="tbxToDate_CalendarExtender" runat="server" 
        TargetControlID="tbxToDate" Format="d MMMM, yyyy">
    </asp:CalendarExtender>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="tbxToDate" ErrorMessage="To Date must be entered">*</asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnShow" runat="server" Text="Show"  CausesValidation="true"/>
    <br />
    <br />
    <asp:Button ID="btnSelectAll" runat="server" Text="Select All" CausesValidation="false" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnUnselectAll" runat="server" Text="Unselect All" CausesValidation="false"/>
    <br />
    <asp:GridView ID="grdvwReport" runat="server" CellPadding="3" 
        EnableModelValidation="True" ForeColor="Black" GridLines="Vertical" 
        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <asp:Button ID="btnViewReport" runat="server" Text="View Report" />
    <br />

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>


</div>
</div>
</div>
</asp:Content>
