<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="AddLecturer.aspx.vb" Inherits="OSAMS.AddLecturer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style21
        {
            width: 751px;
            float: left;
        }
        .style22
        {
            width: 141px;
        }
        .style23
        {
            width: 104px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
<div id="content">
<div class="style18" id="caption">ADD NEW LECTURER</div>
<div id="table">

    
    <div id="error_message"><asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></div>
    <table class="style21" style="text-align: left; float: left; clear: left;">
        <tr>

            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold;">

                Lecturer ID:</td>
            <td class="style22">
                <asp:TextBox ID="txtLecturerID" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtLecturerID" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtLecturerID" 
                    ErrorMessage="Error: Lecturer ID must follow format vxxxxx" 
                    ValidationExpression="^[v]{1}[0-9]{5}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>

            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold;">

                Family Name:</td>
            <td class="style22">
                <asp:TextBox ID="txtFamilyName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtFamilyName" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>

            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold;">

                Middle Name:</td>
            <td class="style22">
                <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>

            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold;">

                Given Name:</td>
            <td class="style22">
                <asp:TextBox ID="txtGivenName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtGivenName" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>

            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold;">

                Gender:</td>
            <td class="style22">
                <asp:DropDownList ID="ddlGender" runat="server">
                    <asp:ListItem>M</asp:ListItem>
                    <asp:ListItem>F</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>

            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold;">

                Role:</td>
            <td class="style22">
                <asp:DropDownList ID="ddlRole" runat="server">
                    <asp:ListItem Value="4">Lecturer</asp:ListItem>
                    <asp:ListItem Value="3">Senior Lecturer</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

    
    <div id="button">
        <div id="left">
        <asp:Button ID="btnSave" runat="server" Text="Save" />
        </div> 
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation ="false"  />
    </div>
    
</div>
</div>
</div>
</asp:Content>
