<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="AddAdmin.aspx.vb" Inherits="OSAMS.AddAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style21
        {
            width: 564px;
            float: left;
        }
        .style22
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
<div id="content">
<div id="table">

    <div id="table_left">
    <div id="table_left_logo"><img alt="logo" src="images/icons/prize_winner.png" width="80" height="80" /></div>
    <div id="table_left_caption">ADMIN<br />MANAGEMENT</div>
    </div>
    <div id="table_middle">
    <div id="table_middle_caption">
    &nbsp;<img alt="logo" src="images/add.png" width="14" height="14" />&nbsp;Add New Admin
    </div>
    <div id="table_middle_note">Adding your new data by follwing the below required textbox, input your infomation correctly by following the rule of the system.</div>
    <div id="error_message"><asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></div>
    <div id="table_middle_content">
    <table class="style21" style="text-align: left; clear: left; float: left;">
        <tr>
            <td>
                Staff ID:</td>
            <td>
                <asp:TextBox ID="txtStaffID" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtStaffID" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtStaffID" 
                    ErrorMessage="Error: Staff ID must follow format vxxxxx" 
                    ValidationExpression="^[v]{1}[0-9]{5}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Family Name:</td>
            <td>
                <asp:TextBox ID="txtFamilyName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtFamilyName" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>

            <td>

                Middle Name:</td>
            <td class="style22">
                <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
            </td>
            <td class="style22">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Given Name:</td>
            <td>
                <asp:TextBox ID="txtGivenName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtGivenName" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Gender:</td>
            <td>
                <asp:DropDownList ID="ddlGender" runat="server">
                    <asp:ListItem>M</asp:ListItem>
                    <asp:ListItem>F</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <div id="button_right">
        
                    <asp:Button ID="btnSave" runat="server" Text="Save" CausesValidation ="true"/>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation = "false" />
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
