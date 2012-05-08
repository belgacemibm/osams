<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="AddLecturer.aspx.vb" Inherits="OSAMS.AddLecturer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style21
        {
            width: 650px;
            float: left;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
<div id="content">
<div id="table">

    <div id="table_left">
    <div id="table_left_logo"><img alt="logo" src="images/icons/user.png" width="80" height="80" /></div>
    <div id="table_left_caption">LECTURER<br />MANAGEMENT</div>
    </div>
    <div id="table_middle">
    <div id="table_middle_caption">
    &nbsp;<img alt="logo" src="images/add.png" width="14" height="14" />&nbsp;Add New Lecturer
    </div>
    <div id="table_middle_note">Adding your new data by follwing the below required textbox, input your infomation correctly by following the rule of the system.</div>
    <div id="error_message"><asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></div>
    <div id="table_middle_content">
    <table class="style21" style="text-align: left; float: left; clear: left;">
        <tr>

            <td>

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

            <td>

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

            <td>

                Middle Name:</td>
            <td class="style22">
                <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>

            <td>

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

            <td>

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

            <td>

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
        <tr>

            <td>

                &nbsp;</td>
            <td class="style22">
                <div id="button_right">        
                    <asp:Button ID="btnSave" runat="server" Text="Save" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation ="false"  />
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
