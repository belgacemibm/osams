<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="EditProfile.aspx.vb" Inherits="OSAMS.EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style21
        {
            width: 544px;
            float: left;
        }
        .style22
        {
            width: 422px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
<div id="content">

<div id="table" style="text-align: left">
<div id="table_left">
    <div id="table_left_logo"><img alt="logo" src="images/icons/edit_page.png" width="80" height="80" /></div>
    <div id="table_left_caption">PROFILE<br />MANAGEMENT</div>
</div>
    
    <div id="table_middle">
    <div id="table_middle_caption">
    &nbsp;<img alt="logo" src="images/brush.png" width="14" height="14" />&nbsp;Edit Profile
    </div>
    <div id="table_middle_note">Editing your data in the fields below. For instructions, please check out <a href="Help.aspx">Help</a> page.</div>
    <div id="table_middle_content">
    <table class="style21">
        <tr>
            <td>

    

    <asp:Label ID="lblID" runat="server" Text="ID:"></asp:Label>
            </td>
            <td class="style22">
    <asp:TextBox ID="tbxID" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
    <asp:Label ID="lblFamilyName" runat="server" Text="Family Name:"></asp:Label>
            </td>
            <td class="style22">
    <asp:TextBox ID="tbxFamilyName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="tbxFamilyName" 
                    ErrorMessage="&quot;Family Name&quot; cannot be blank!">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
    <asp:Label ID="lblMiddleName" runat="server" Text="Middle Name:"></asp:Label>
            </td>
            <td class="style22">
    <asp:TextBox ID="tbxMiddleName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
    <asp:Label ID="lblGivenName" runat="server" Text="Given Name:"></asp:Label>
            </td>
            <td class="style22">
    <asp:TextBox ID="tbxGivenName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="tbxGivenName" 
                    ErrorMessage="&quot;Given Name&quot; cannot be blank!">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
    <asp:Label ID="lblGender" runat="server" Text="Gender:"></asp:Label>
            </td>
            <td class="style22">
    <asp:DropDownList ID="ddlGender" runat="server">
        <asp:ListItem>M</asp:ListItem>
        <asp:ListItem>F</asp:ListItem>
    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
    <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            </td>
            <td class="style22">
    <asp:TextBox ID="tbxEmail" runat="server" Height="22px" Width="158px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="tbxEmail" ErrorMessage="&quot;Email&quot; cannot be blank!">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="tbxEmail" ErrorMessage="Error: Email is incorrect format" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Error: Email is incorrect format</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
    <asp:Button ID="btnSave" runat="server" Text="Save" CausesValidation="True"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"/>

    

            </td>
        </tr>
    </table>

    </div>
    </div>
</div>
</div>
</div>
</asp:Content>
