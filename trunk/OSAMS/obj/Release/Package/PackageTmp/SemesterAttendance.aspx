<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="SemesterAttendance.aspx.vb" Inherits="OSAMS.SemesterAttendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style21
        {
            width: 1000px;
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="big_content">
<div id="content">
<div class="style18" id="caption">SEMESTER ATTENDANCE</div>
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
            <td colspan="2" style="background-color: #CCCCFF; color: #000000;">
                W1</td>
            <td colspan="2" style="background-color: #CCCCFF; color: #000000;">
                W2</td>
            <td colspan="2" style="background-color: #CCCCFF; color: #000000;">
                W3</td>
            <td colspan="2" style="background-color: #CCCCFF; color: #000000;">
                W4</td>
            <td colspan="2" style="background-color: #CCCCFF; color: #000000;">
                W5</td>
            <td colspan="2" style="background-color: #CCCCFF; color: #000000;">
                W6</td>
            <td colspan="2" style="background-color: #CCCCFF; color: #000000;">
                W7</td>
            <td colspan="2" style="background-color: #CCCCFF; color: #000000;">
                W8</td>
            <td colspan="2" style="background-color: #CCCCFF; color: #000000;">
                W9</td>
            <td colspan="2" style="background-color: #CCCCFF; color: #000000;">
                W10</td>
            <td colspan="2" style="background-color: #CCCCFF; color: #000000;">
                W11</td>
            <td colspan="2" style="background-color: #CCCCFF; color: #000000;">
                W12</td>
        </tr>
        <tr>
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
                M</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                F</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                M</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                F</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                M</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                F</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                M</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                F</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                M</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                F</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                M</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                F</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                M</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                F</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                M</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                F</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                M</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                F</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                M</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                F</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                M</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                F</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                M</td>
            <td style="color: #FFFFFF; background-color: #6699FF">
                F</td>
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
            <td colspan="31">
            <div id="button">
                <div id="left"></div>
                <div id="right">
                <asp:Button ID="btnAddNewStudent" runat="server" Text="Export to Excel" />
                </div> 
            </div>
                </td>
        </tr>
    </table>
    
    
</div>
</div>
</div>
</asp:Content>
