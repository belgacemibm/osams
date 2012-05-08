<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="AddSemester.aspx.vb" Inherits="OSAMS.AddSemester" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style21
        {
            width: 438px;
            float: left;
            
        }
        .style22
        {
            width: 114px;
        }
        .style23
        {
            width: 183px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
<div id="content">
<div id="table">
<div id="table_left">
    <div id="table_left_logo"><img alt="logo" src="images/icons/calendar.png" width="80" height="80" /></div>
    <div id="table_left_caption">SEMESTER<br />MANAGEMENT</div>
</div>
<div id="table_middle">
<asp:ToolkitScriptManager ID="toolkitScriptMaster" runat="server">
</asp:ToolkitScriptManager>
    <div id="table_middle_caption">
   &nbsp;<img alt="logo" src="images/add.png" width="14" height="14" />&nbsp;Add New Semester
    </div>
    <div id="table_middle_note">Adding your new data by follwing the below required textbox, input your infomation correctly by following the rule of the system.</div>
    <div id="error_message"><asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></div>
    <div id="table_middle_content">
    <table align="left" class="style21" 
        style="text-align: left; height: 124px; float: left; clear: left;">
        <tr>
            <td class="style22">
                Year:</td>
            <td class="style23">
                <asp:DropDownList ID="ddlYear" runat="server" Height="27px" Width="178px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style22">
                Order:</td>
            <td class="style23">
                <asp:DropDownList ID="ddlOrder" runat="server" Height="21px" Width="178px">
                    <asp:ListItem>A</asp:ListItem>
                    <asp:ListItem>B</asp:ListItem>
                    <asp:ListItem>C</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style22">
                Start Date:</td>
            <td class="style23">
                <asp:TextBox ID="txtStartDate" runat="server" 
                        Text='<%# Bind("start_date", "{0:d MMMM, yyyy}") %>'></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate" Format="d MMMM, yyyy">
                    </asp:CalendarExtender>

                     

            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtStartDate" ErrorMessage="*"></asp:RequiredFieldValidator>

                     

            </td>
        </tr>
        <tr>
            <td class="style22">
                End Date:</td>
            <td class="style23">
                <asp:TextBox ID="txtEndDate" runat="server" 
                        Text='<%# Bind("end_date", "{0:d MMMM, yyyy}") %>'></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEndDate" Format="d MMMM, yyyy">
                    </asp:CalendarExtender>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtEndDate" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style22">
                &nbsp;</td>
            <td style="text-align: right">
                <div id="button_right">
                    <asp:Button ID="btnSave" runat="server" Text="Save" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                </div></td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

    </div>
    
</div>   
</div>
</div>
</div>
</asp:Content>
