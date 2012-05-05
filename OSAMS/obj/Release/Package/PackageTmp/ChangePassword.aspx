<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="ChangePassword.aspx.vb" Inherits="OSAMS.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style21
        {
            width: 300px;
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="big_content">
<div id="content">
<div class="style18" id="caption">CHANGE PASSWORD</div>
<div id="table" style="text-align: left">

    

    <table class="style21">
        <tr>
            <td>

    

    <asp:Label ID="lblID" runat="server" Text="ID:"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="tbxID" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
    <asp:Label ID="lblOldPassword" runat="server" Text="Old Password:"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="tbxOldPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
    <asp:Label ID="lblNewPassword" runat="server" Text="New Password:"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="tbxNewPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
    <asp:Label ID="lblNewPasswordConfirm" runat="server" 
        Text="New Password (Confirm):"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="tbxNewPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />

    

            </td>
        </tr>
    </table>
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    &nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
    <br />

    

</div>
</div>
</div>
</asp:Content>
