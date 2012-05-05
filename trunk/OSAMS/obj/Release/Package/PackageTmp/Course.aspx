<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Course.aspx.vb" Inherits="OSAMS.Course" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style21
        {
            width: 700px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="big_content">
<div id="content">
<div class="style18" id="caption">COURSE MANAGEMENT</div>
<div id="table">

    

    <table class="style21" style="text-align: left; float: left;">
        <tr>
            <td style="background-color: #999999">
                Course ID</td>
            <td style="background-color: #999999">
                Course Name</td>
            <td style="background-color: #999999">
                Level</td>
            <td style="background-color: #999999">
                Credit</td>
        </tr>
        <tr>
            <td style="background-color: #F0EFEF">
                &nbsp;</td>
            <td style="background-color: #F0EFEF">
                &nbsp;</td>
            <td style="background-color: #F0EFEF">
                &nbsp;</td>
            <td style="background-color: #F0EFEF">
                &nbsp;</td>
        </tr>
    </table>
    <div id="button">
        <div id="left">
        <asp:Button ID="btnAddNewCourse" runat="server" Text="New Course" />
        </div> 
    </div>
    

</div>
</div>
</div>
</asp:Content>
