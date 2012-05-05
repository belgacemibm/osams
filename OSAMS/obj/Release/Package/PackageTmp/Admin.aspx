<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Admin.aspx.vb" Inherits="OSAMS.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style21
        {
            width: 600px;
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="big_content">
<div id="content">
<div class="style18" id="caption">ADMIN MANAGEMENT</div>
<div id="table">

    <div id="button">
        <div id="left">
        <asp:Button ID="btnAddNewAdmin" runat="server" Text="New Admin" />
        </div> 
        <asp:Button ID="btnDisable" runat="server" Text="Disable Admin" />
    </div>

    <table class="style21" style="text-align: left">
        <tr>
            <td style="color: #FFFFFF; font-weight: bold; background-color: #0066FF">
                <asp:CheckBox ID="chkbxAllCheck" runat="server" />
            </td>
            <td style="color: #FFFFFF; font-weight: bold; background-color: #0066FF">
                Staff ID</td>
            <td style="color: #FFFFFF; font-weight: bold; background-color: #0066FF">
                Family Name</td>
            <td style="color: #FFFFFF; font-weight: bold; background-color: #0066FF">
                Middle Name</td>
            <td style="color: #FFFFFF; font-weight: bold; background-color: #0066FF">
                Given Name</td>
            <td style="color: #FFFFFF; font-weight: bold; background-color: #0066FF">
                Gender</td>
            <td style="color: #FFFFFF; font-weight: bold; background-color: #0066FF">
                Email</td>
            <td style="color: #FFFFFF; font-weight: bold; background-color: #0066FF">
                Status</td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="chkbxCheck" runat="server" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

    

</div>
</div>
</div>
</asp:Content>
