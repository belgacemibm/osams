<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="EditProfile.aspx.vb" Inherits="OSAMS.EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style21
        {
            width: 441px;
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="big_content">
<div id="content">
<div class="style18" id="caption">EDIT PROFILE</div>
<div id="table" style="text-align: left">

    

    <table class="style21">
        <tr>
            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold;">

    

    <asp:Label ID="lblID" runat="server" Text="ID:"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="tbxID" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold;">
    <asp:Label ID="lblFamilyName" runat="server" Text="Family Name:"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="tbxFamilyName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="tbxFamilyName" 
                    ErrorMessage="&quot;Family Name&quot; cannot be blank!">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold;">
    <asp:Label ID="lblMiddleName" runat="server" Text="Middle Name:"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="tbxMiddleName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold;">
    <asp:Label ID="lblGivenName" runat="server" Text="Given Name:"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="tbxGivenName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="tbxGivenName" 
                    ErrorMessage="&quot;Given Name&quot; cannot be blank!">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold;">
    <asp:Label ID="lblGender" runat="server" Text="Gender:"></asp:Label>
            </td>
            <td>
    <asp:DropDownList ID="ddlGender" runat="server">
        <asp:ListItem>M</asp:ListItem>
        <asp:ListItem>F</asp:ListItem>
    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold;">
    <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="tbxEmail" runat="server" Height="22px" Width="158px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="tbxEmail" ErrorMessage="&quot;Email&quot; cannot be blank!">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="tbxEmail" ErrorMessage="Email is incorrect format" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Email is incorrect format</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
    <asp:Button ID="btnSave" runat="server" Text="Save" CausesValidation="True"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"/>

    

            </td>
        </tr>
    </table>
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />

    

</div>
</div>
</div>
</asp:Content>
