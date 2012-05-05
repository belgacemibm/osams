<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="AddCourse.aspx.vb" Inherits="OSAMS.AddCourse" %>
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
<div class="style18" id="caption">ADD NEW COURSE</div>
<div id="table">

    

    <table class="style21" style="text-align: left">
        <tr>
            <td>
                Course ID:</td>
            <td>
                <asp:TextBox ID="txtCourseID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Course Name:</td>
            <td>
                <asp:TextBox ID="txtCourseName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Level:</td>
            <td>
                <asp:DropDownList ID="cbxLevel" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Credit:</td>
            <td>
                <asp:TextBox ID="txtCredit" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div id="button">
        <div id="left">
        <asp:Button ID="btnSave" runat="server" Text="Save" />
        </div> 
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
    </div>
    

</div>
</div>
</div>
</asp:Content>
