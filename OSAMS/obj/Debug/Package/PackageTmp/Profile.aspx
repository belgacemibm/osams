<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Profile.aspx.vb" Inherits="OSAMS.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
<div id="content">
<div class="style18" id="caption">USER PROFILE</div>
<div id="table" style="text-align: left">
    &nbsp;<br />
    <asp:DetailsView ID="DtpfvwUserProfile" runat="server" CellPadding="4"
        EnableModelValidation="True" Height="50px" Width="292px" 
        ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />

        <CommandRowStyle BackColor="#507CD1" Font-Bold="True" />
        <EditRowStyle BackColor="#507CD1" />
        <FieldHeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#2461BF" />
        <RowStyle BackColor="#CCCCCC" />

    </asp:DetailsView>

    <br />
    <asp:Button ID="btnEditProfile" runat="server" Text="Edit Profile" 
        Width="150px" />
    <asp:Button ID="btnChangePassword" runat="server" 
        Text="Change Password" Width="150px" />

    <br />
</div>
</div>
</div>
</asp:Content>
