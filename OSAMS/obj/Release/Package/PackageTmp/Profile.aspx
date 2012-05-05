<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Profile.aspx.vb" Inherits="OSAMS.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="big_content">
<div id="content">
<div class="style18" id="caption">USER PROFILE</div>
<div id="table" style="text-align: left">
    <asp:Button ID="btnEditProfile" runat="server" Text="Edit Profile" />
    &nbsp;<asp:Button ID="btnChangePassword" runat="server" 
        Text="Change Password" />
    <br />
    <asp:GridView ID="grdvwProfile" runat="server" BackColor="White" 
        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        EnableModelValidation="True">
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <br />
</div>
</div>
</div>
</asp:Content>
