<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Semester.aspx.vb" Inherits="OSAMS.Semester" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style21
        {
            width: 350px;
            float: left;
            border: 1px solid #CCCCCC;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
<div id="content">
<div class="style18" id="caption">SEMESTER MANAGEMENT</div>
<div id="table">

    

    <table class="style21" style="text-align: left">
        <tr>
            <td style="text-align: left; background-color: #999999;">
                Semester Name</td>
            <td style="text-align: left; background-color: #999999;">
                Start Date</td>
            <td style="text-align: left; background-color: #999999;">
                End Date</td>
        </tr>
        <tr>
            <td style="text-align: left; background-color: #F0EFEF;">
                2011A</td>
            <td style="text-align: left; background-color: #F0EFEF;">
                &nbsp;</td>
            <td style="text-align: left; background-color: #F0EFEF;">
                &nbsp;</td>
        </tr>
    </table>

    <div id="button">
        <div id="left">
        <asp:Button ID="btnAddSemester" runat="server" Text="New Semester" />
        </div> 
    </div>

</div>
</div>
</div>
</asp:Content>
