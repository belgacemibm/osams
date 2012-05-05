<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Student.aspx.vb" Inherits="OSAMS.Student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style21
        {
            width: 900px;
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
<div id="content">
<div class="style18" id="caption">STUDENT MANAGEMENT</div>
<div id="table">
<div id="selection">
<table width="370" border="0" align="left" cellpadding="2" cellspacing="0">
  <tr>
    <td align="left" valign="middle">Semester:&nbsp;
        <asp:DropDownList ID="cbxSemester" runat="server">
        </asp:DropDownList>
      </td>
    <td align="left" valign="middle">Course:&nbsp;
        <asp:DropDownList ID="cbxCourse" runat="server">
        </asp:DropDownList>
      </td>
    <td align="left" valign="middle">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
      </td>
  </tr>
</table>
</div>
    <br />

    <table class="style21" style="text-align: left">
        <tr>
            <td style="background-color: #0066FF; color: #FFFFFF; font-weight: bold;">
                Student ID</td>
            <td style="background-color: #0066FF; color: #FFFFFF; font-weight: bold;">
                Program</td>
            <td style="background-color: #0066FF; color: #FFFFFF; font-weight: bold;">
                Steam</td>
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
                Group</td>
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
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    
    <div id="button">
        <div id="left">
        <asp:Button ID="btnAddNewStudent" runat="server" Text="New Student" />
        </div> 
    </div>
</div>
</div>
</div>
</asp:Content>
