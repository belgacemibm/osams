<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="AddGroup.aspx.vb" Inherits="OSAMS.AddGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style21
        {
            width: 350px;
            float: left;
            
        }
        .style22
        {
            width: 900px;
            float: left;
            
        }
        .style23
        {
            width: 350px;
            float: left;
            
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
<div id="content">
<div class="style18" id="caption">ADD NEW GROUP</div>
<div id="table">

<div id="error_message">
<asp:Label ID="lbl" runat="server" Text=""></asp:Label>
<asp:Label ID="lblError" runat="server" ForeColor="Red" align="center"></asp:Label>
</div>

<form method="get">

    <table align="left" class="style21" style="float: left; clear: left;">
        <tr>
            <td style="text-align: left; background-color: #000000; color: #FFFFFF; font-weight: bold;">
                Group Name:</td>
            <td style="text-align: left">
                <asp:TextBox ID="txtGroupName" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; background-color: #000000; color: #FFFFFF; font-weight: bold;" 
                class="style24">
                Semester:</td>
            <td style="text-align: left" class="style24">
                <asp:DropDownList ID="cbxSemester" runat="server" Height="20px" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; background-color: #000000; color: #FFFFFF; font-weight: bold;">
                Course:</td>
            <td style="text-align: left">
                <asp:DropDownList ID="cbxCourse" runat="server" Height="20px" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; background-color: #000000; color: #FFFFFF; font-weight: bold;">
                Lecturer:</td>
            <td style="text-align: left">
                <asp:DropDownList ID="cbxLecturer" runat="server" Height="20px" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
    </table>

  
    <table align="left" class="style22" 
        style="clear: left; float: left; margin-top: 15px;">
        <tr>
            <td style="text-align: left; background-color: #000000; color: #FFFFFF; font-weight: bold;">
                Day 1:</td>
            <td style="text-align: left">
                <asp:DropDownList ID="cbxDay1" runat="server">
                    <asp:ListItem Value="1">Monday</asp:ListItem>
                    <asp:ListItem Value="2">Tuesday</asp:ListItem>
                    <asp:ListItem Value="3">Wednesday</asp:ListItem>
                    <asp:ListItem Value="4">Thursday</asp:ListItem>
                    <asp:ListItem Value="5">Friday</asp:ListItem>
                    <asp:ListItem Value="6">Saturday</asp:ListItem>
                    <asp:ListItem Value="7">Sunday</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="text-align: left; background-color: #000000; color: #FFFFFF; font-weight: bold;">
                Start Time:</td>
            <td style="text-align: left">
                <asp:DropDownList ID="cbxStartHour1" runat="server">
                </asp:DropDownList>
                (h) :
                <asp:DropDownList ID="cbxStartMinute1" runat="server">
                </asp:DropDownList>
                (m)</td>
            <td style="text-align: left; background-color: #000000; color: #FFFFFF; font-weight: bold;">
                End Time:</td>
            <td style="text-align: left">
                <asp:DropDownList ID="cbxEndHour1" runat="server">
                </asp:DropDownList>
                (h) :
                <asp:DropDownList ID="cbxEndMinute1" runat="server">
                </asp:DropDownList>
                (m)</td>
            <td style="text-align: left; background-color: #000000; color: #FFFFFF; font-weight: bold;">
                Type:</td>
            <td style="text-align: left">
                <asp:DropDownList ID="cbxType1" runat="server">
                    <asp:ListItem>Lecture</asp:ListItem>
                    <asp:ListItem>Tutorial</asp:ListItem>
                    <asp:ListItem>Both</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; background-color: #000000; color: #FFFFFF; font-weight: bold;">
                Day 2:</td>
            <td style="text-align: left">
                <asp:DropDownList ID="cbxDay2" runat="server">
                    <asp:ListItem Value="0">None</asp:ListItem>
                    <asp:ListItem Value="1">Monday</asp:ListItem>
                    <asp:ListItem Value="2">Tuesday</asp:ListItem>
                    <asp:ListItem Value="3">Wednesday</asp:ListItem>
                    <asp:ListItem Value="4">Thursday</asp:ListItem>
                    <asp:ListItem Value="5">Friday</asp:ListItem>
                    <asp:ListItem Value="6">Saturday</asp:ListItem>
                    <asp:ListItem Value="7">Sunday</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="text-align: left; background-color: #000000; color: #FFFFFF; font-weight: bold;">
                Start Time:</td>
            <td style="text-align: left">
                <asp:DropDownList ID="cbxStartHour2" runat="server">
                </asp:DropDownList>
                (h) :
                <asp:DropDownList ID="cbxStartMinute2" runat="server">
                </asp:DropDownList>
                (m)</td>
            <td style="text-align: left; background-color: #000000; color: #FFFFFF; font-weight: bold;">
                End Time:</td>
            <td style="text-align: left">
                <asp:DropDownList ID="cbxEndHour2" runat="server">
                </asp:DropDownList>
                (h) :
                <asp:DropDownList ID="cbxEndMinute2" runat="server">
                </asp:DropDownList>
                (m)</td>
            <td style="text-align: left; background-color: #000000; color: #FFFFFF; font-weight: bold;">
                Type:</td>
            <td style="text-align: left" id="cbxType2">
                <asp:DropDownList ID="cbxType2" runat="server">
                    <asp:ListItem>Lecture</asp:ListItem>
                    <asp:ListItem>Tutorial</asp:ListItem>
                    <asp:ListItem>Both</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>


 
    <table class="style23" style="clear: left; float: left; margin-top: 15px;">
        <tr>
            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold;">
                Upload File:</td>
            <td>
                <asp:FileUpload ID="FileUpload" runat="server" />
                <asp:HyperLink ID="HyperLink1" runat="server" 
                    NavigateUrl="~/fileupload/sample.xlsx">sample</asp:HyperLink>
            </td>
        </tr>
        
    </table>

    <div id="button">
    <br />
  <div id="left">
  &nbsp;
  </div>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
    </div>
</form>
    <%
    'Dim groupname As String
    'groupname = Request.QueryString("txtGroupName")
    'MsgBox(groupname)
    'saveData()
    
%>
 
</div>
</div>
</div>
</asp:Content>
