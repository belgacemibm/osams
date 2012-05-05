<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="WeeklyAttendance.aspx.vb" Inherits="OSAMS.WeeklyAttendance" %>
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
<div class="style18" id="caption">WEEKLY ATTENDANCE</div>
<div id="table">

<div id="selection">
<table width="700" border="0" align="left" cellpadding="2" cellspacing="0">
  <tr>
    <td align="left" valign="middle">Semester:&nbsp;
        <asp:DropDownList ID="cbxSemester" runat="server">
        </asp:DropDownList>
      </td>
    <td align="left" valign="middle">Course:&nbsp;
        <asp:DropDownList ID="cbxCourse" runat="server">
        </asp:DropDownList>
      </td>
    <td align="left" valign="middle">Group:&nbsp;
        <asp:DropDownList ID="cbxGroup" runat="server">
        </asp:DropDownList>
      </td>
    <td align="left" valign="middle">Week:&nbsp;
        <asp:DropDownList ID="cbxWeek" runat="server">
        </asp:DropDownList>
      </td>
    <td align="left" valign="middle">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
      </td>
  </tr>
</table>

</div>

<br />
<br />
    <table class="style21" style="text-align: left">
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
            <td colspan="2" style="background-color: #CCCCFF">
                Week 1</td>
        </tr>
        <tr>
            <td style="color: #FFFFFF; background-color: #6699FF">
                <asp:CheckBox ID="chkbxCheckAll" runat="server" />
            </td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                Student ID</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                Program</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                Stream</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                Family Name</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                Middle Name</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                Given Name</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                Gender</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                Mon</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                Thu</td>
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
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="10">
            <div id="button">
                <div id="left">
                <asp:Button ID="btnAddStudent" runat="server" Text="Add Student" />
                <asp:Button ID="btnRemoveStudent" runat="server" Text="Remove Student" />
                </div>
                <div id="right">
                <asp:Button ID="btnReset" runat="server" Text="Reset" />
                <asp:Button ID="btnStudentSubmit" runat="server" Text="Submit" />
                </div> 
                
            </div>    
            </td>
        </tr>
    </table>


</div>
</div>
</div>
</asp:Content>
