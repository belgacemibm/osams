<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Lecturer.aspx.vb" Inherits="OSAMS.Lecturer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style21
        {
            width: 700px;
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
<div id="content">
<div class="style18" id="caption">LECTURER MANAGEMENT</div>
<div id="table">

    <div id="button">
        <div id="left">
        <asp:Button ID="btnAddNewLecturer" runat="server" Text="New Lecturer" />
        </div> 
    </div>

    <table class="style21" style="text-align: left">
        <tr>
            <td style="background-color: #0066FF; color: #FFFFFF; font-weight: bold;">
                Lecturer ID</td>
            <td style="background-color: #0066FF; color: #FFFFFF; font-weight: bold;">
                Family Name</td>
            <td style="background-color: #0066FF; color: #FFFFFF; font-weight: bold;">
                Middle Name</td>
            <td style="background-color: #0066FF; color: #FFFFFF; font-weight: bold;">
                Given Name</td>
            <td style="background-color: #0066FF; color: #FFFFFF; font-weight: bold;">
                Gender</td>
            <td style="background-color: #0066FF; color: #FFFFFF; font-weight: bold;">
                Email</td>
            <td style="background-color: #0066FF; color: #FFFFFF; font-weight: bold;">
                Role</td>
        </tr>
        <tr>
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
