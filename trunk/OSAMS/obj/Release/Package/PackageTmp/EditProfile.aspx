<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="EditProfile.aspx.vb" Inherits="OSAMS.EditProfile" %>
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
<div class="style18" id="caption">EDIT PROFILE</div>
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
    <asp:Label ID="lblFamilyName" runat="server" Text="Family Name:"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="tbxFamilyName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
    <asp:Label ID="lblMiddleName" runat="server" Text="Middle Name:"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="tbxMiddleName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
    <asp:Label ID="lblGivenName" runat="server" Text="Given Name:"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="tbxGivenName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
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
            <td>
    <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            </td>
            <td>
    <asp:TextBox ID="tbxEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
    <asp:Button ID="btnSave" runat="server" Text="Save" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />

    

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
