﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="ChangePassword.aspx.vb" Inherits="OSAMS.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style21
        {
            width: 800px;
            float: left;
        }
        .style22
        {
            width: 600px;
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
            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold">

    

    <asp:Label ID="lblID" runat="server" Text="ID:"></asp:Label>
            </td>
            <td class="style22">
                <asp:TextBox ID="tbxID" runat="server"></asp:TextBox>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold">
    <asp:Label ID="lblOldPassword" runat="server" Text="Old Password:"></asp:Label>
            </td>
            <td class="style22">
                <asp:TextBox ID="tbxOldPassword" runat="server" TextMode="Password"></asp:TextBox>
            &nbsp;
                <asp:RequiredFieldValidator ID="RqfvOldPassword" runat="server" 
                    ControlToValidate="tbxOldPassword" 
                    ErrorMessage="Please enter your old password!" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CtvldtOldPassword" runat="server" 
                    ErrorMessage="Old Password is incorrect!" BorderStyle="None"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold">
    <asp:Label ID="lblNewPassword" runat="server" Text="New Password:"></asp:Label>
            </td>
            <td class="style22">
    <asp:TextBox ID="tbxNewPassword" runat="server" TextMode="Password"></asp:TextBox>
            &nbsp;
                <asp:RequiredFieldValidator ID="RqfvNewPassword" runat="server" 
                    ControlToValidate="tbxNewPassword" 
                    ErrorMessage="Please enter your new password!" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold">
    <asp:Label ID="lblNewPasswordConfirm" runat="server" 
        Text="New Password (Confirm):"></asp:Label>
            </td>
            <td class="style22">
    <asp:TextBox ID="tbxNewPasswordConfirm" runat="server" TextMode="Password"></asp:TextBox>
            &nbsp;
                <asp:RequiredFieldValidator ID="RqfvConfirmNewPassword" runat="server" 
                    ControlToValidate="tbxNewPasswordConfirm" 
                    ErrorMessage="Please confirm your new password!" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CmpvlrNewPassword" runat="server" 
                    ControlToCompare="tbxNewPassword" ControlToValidate="tbxNewPasswordConfirm" 
                    ErrorMessage="New Password does not match!"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" CausesValidation = "true"/>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation = "false"/>

    

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
