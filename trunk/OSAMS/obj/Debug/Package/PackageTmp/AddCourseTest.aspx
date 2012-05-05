<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="AddCourseTest.aspx.vb" Inherits="OSAMS.AddCourseTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style21
        {
            width: 300px;
            float: left;
        }
        .style22
        {
            width: 400px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="big_content">
<div id="content">

<div id="table_test">

    

    <table class="style21" style="text-align: left">
        <tr>
            <td>
                <img alt="logo" src="images/play-button.png" width="16" height="16" /></td>
            <td colspan="2">
                <div class="style18" id="caption_test">ADD NEW COURSE</div></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="color: #FFFFFF; font-weight: bold; background-color: #000000">
                Course ID:</td>
            <td>
                <asp:TextBox ID="txtCourseID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="color: #FFFFFF; font-weight: bold; background-color: #000000">
                Course Name:</td>
            <td>
                <asp:TextBox ID="txtCourseName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="color: #FFFFFF; font-weight: bold; background-color: #000000">
                Level:</td>
            <td>
                <asp:DropDownList ID="cbxLevel" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="color: #FFFFFF; font-weight: bold; background-color: #000000">
                Credit:</td>
            <td>
                <asp:TextBox ID="txtCredit" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="2">
        <div id="button">
        <div id="left">
        <asp:Button ID="btnSave" runat="server" Text="Save" />        
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        </div></div> </td>
        </tr>
    </table>
   
    

</div>
<div id="note_horizon">
    <table class="style22">
        <tr>
            <td>
                <img alt="logo" src="images/play-button.png" width="16" height="16" /></td>
            <td>
                <div id="note_caption">NOTE</div></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                
                    Understanding the need of BIS lecturer in student attendance management, OSAMS 
                    which stand for <strong>Online Student Attendance Management System</strong> has 
                    been created to solve the issue.<br />
                <p>
                    By using OSAMS system, the lecturer could get many benefits below:</p>
                <li><strong>Saving paper</strong></li>
                <li><strong>Saving time</strong></li>
                <li><strong>Integrating data</strong></li>
                <li><strong>Analysing report</strong><p>
                    Hope our users will have a useful and gladful time when using the system.</p>
                </li>
            </td>
        </tr>
    </table>
    </div>
</div>
</div>
</asp:Content>