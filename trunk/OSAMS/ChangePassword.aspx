<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="ChangePassword.aspx.vb" Inherits="OSAMS.ChangePassword" %>

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

<div id="table" style="text-align: left">
<div id="table_left">
    <div id="table_left_logo"><img alt="logo" src="images/icons/lock.png" width="80" height="80" /></div>
    <div id="table_left_caption">PASSWORD<br />MANAGEMENT</div>
</div>
    
<div id="table_middle">
<div id="table_middle_caption">
    &nbsp;<img alt="logo" src="images/lock.png" width="14" height="14" />&nbsp;Change Password
</div>
<div id="table_middle_note">Changing your password by follwing the below controls, and input your infomation correctly by following the rule of the system validation.</div>
<div id="table_middle_content">   
    <table class="style21">
        <tr>
            <td>

    

    <asp:Label ID="lblID" runat="server" Text="ID:"></asp:Label>
            </td>
            <td class="style22">
                <asp:TextBox ID="tbxID" runat="server"></asp:TextBox>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
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
            <td>
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
            <td>
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
    </div>
    </div>
    

</div>
</div>
</div>
</asp:Content>
