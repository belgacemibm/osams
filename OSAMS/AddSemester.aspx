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
<div class="style18" id="caption">ADD NEW SEMESTER</div>
<div id="table">
<asp:ToolkitScriptManager ID="toolkitScriptMaster" runat="server">
</asp:ToolkitScriptManager>

    <div id="error_message"><asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></div>

    <table align="left" class="style21" 
        style="text-align: left; height: 124px; float: left; clear: left;">
        <tr>
            <td class="style22" 
                style="background-color: #000000; color: #FFFFFF; font-weight: bold;">
                Year:</td>
            <td class="style23">
                <asp:DropDownList ID="ddlYear" runat="server" Height="27px" Width="178px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style22" 
                style="background-color: #000000; color: #FFFFFF; font-weight: bold;">
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
            <td class="style22" 
                style="background-color: #000000; color: #FFFFFF; font-weight: bold;">
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
            <td class="style22" 
                style="background-color: #000000; color: #FFFFFF; font-weight: bold;">
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
    </table>

    <div id="button">
        <div id="left">
        <asp:Button ID="btnSave" runat="server" Text="Save" />
        </div> 
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        
    </div>
    
</div>
</div>
</div>
</asp:Content>
