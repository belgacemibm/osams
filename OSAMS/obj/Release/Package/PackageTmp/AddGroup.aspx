<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="AddGroup.aspx.vb" Inherits="OSAMS.AddGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style21
        {
            width: 300px;
            float: left;
            
        }
        .style22
        {
            width: 850px;
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
<form method="get">

    <table align="left" class="style21" style="border: 1px solid #CCCCCC; float: left;">
        <tr>
            <td bgcolor="#999999" style="border: 1px solid #CCCCCC; text-align: left">
                Group Name</td>
            <td style="border: 1px solid #CCCCCC; text-align: left">
                <asp:TextBox ID="txtGroupName" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td bgcolor="#999999" style="border: 1px solid #CCCCCC; text-align: left" 
                class="style24">
                Semester</td>
            <td style="border: 1px solid #CCCCCC; text-align: left" class="style24">
                <asp:DropDownList ID="cbxSemester" runat="server" Height="20px" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td bgcolor="#999999" style="border: 1px solid #CCCCCC; text-align: left">
                Course</td>
            <td style="border: 1px solid #CCCCCC; text-align: left">
                <asp:DropDownList ID="cbxCourse" runat="server" Height="20px" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td bgcolor="#999999" style="border: 1px solid #CCCCCC; text-align: left">
                Lecturer</td>
            <td style="border: 1px solid #CCCCCC; text-align: left">
                <asp:DropDownList ID="cbxLecturer" runat="server" Height="20px" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
    </table>

  
    <table align="left" class="style22" 
        style="border: 1px solid #CCCCCC; clear: left; float: left; margin-top: 15px;">
        <tr>
            <td bgcolor="#999999" style="border: 1px solid #CCCCCC; text-align: left">
                Day 1</td>
            <td style="border: 1px solid #CCCCCC; text-align: left">
                <asp:DropDownList ID="cbxDay1" runat="server">
                    <asp:ListItem Value="1">monday</asp:ListItem>
                    <asp:ListItem Value="2">tuesday</asp:ListItem>
                    <asp:ListItem Value="3">wednesday</asp:ListItem>
                    <asp:ListItem Value="4">thursday</asp:ListItem>
                    <asp:ListItem Value="5">friday</asp:ListItem>
                    <asp:ListItem Value="6">saturday</asp:ListItem>
                    <asp:ListItem Value="7">sunday</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td bgcolor="#999999" style="border: 1px solid #CCCCCC; text-align: left">
                Start Time</td>
            <td style="border: 1px solid #CCCCCC; text-align: left">
                <asp:DropDownList ID="cbxStartHour1" runat="server">
                </asp:DropDownList>
                (h) :
                <asp:DropDownList ID="cbxStartMinute1" runat="server">
                </asp:DropDownList>
                (m)</td>
            <td bgcolor="#999999" style="border: 1px solid #CCCCCC; text-align: left">
                End Time</td>
            <td style="border: 1px solid #CCCCCC; text-align: left">
                <asp:DropDownList ID="cbxEndHour1" runat="server">
                </asp:DropDownList>
                (h) :
                <asp:DropDownList ID="cbxEndMinute1" runat="server">
                </asp:DropDownList>
                (m)</td>
            <td bgcolor="#999999" style="border: 1px solid #CCCCCC; text-align: left">
                Type</td>
            <td style="border: 1px solid #CCCCCC; text-align: left">
                <asp:DropDownList ID="cbxType1" runat="server">
                    <asp:ListItem>Lecture</asp:ListItem>
                    <asp:ListItem>Tutorial</asp:ListItem>
                    <asp:ListItem>Both</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td bgcolor="#999999" style="border: 1px solid #CCCCCC; text-align: left">
                Day 2</td>
            <td style="border: 1px solid #CCCCCC; text-align: left">
                <asp:DropDownList ID="cbxDay2" runat="server">
                    <asp:ListItem Value="0">none</asp:ListItem>
                    <asp:ListItem Value="1">monday</asp:ListItem>
                    <asp:ListItem Value="2">tuesday</asp:ListItem>
                    <asp:ListItem Value="3">wednesday</asp:ListItem>
                    <asp:ListItem Value="4">thursday</asp:ListItem>
                    <asp:ListItem Value="5">friday</asp:ListItem>
                    <asp:ListItem Value="6">saturday</asp:ListItem>
                    <asp:ListItem Value="7">sunday</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td bgcolor="#999999" style="border: 1px solid #CCCCCC; text-align: left">
                Start Time</td>
            <td style="border: 1px solid #CCCCCC; text-align: left">
                <asp:DropDownList ID="cbxStartHour2" runat="server">
                </asp:DropDownList>
                (h) :
                <asp:DropDownList ID="cbxStartMinute2" runat="server">
                </asp:DropDownList>
                (m)</td>
            <td bgcolor="#999999" style="border: 1px solid #CCCCCC; text-align: left">
                End Time</td>
            <td style="border: 1px solid #CCCCCC; text-align: left">
                <asp:DropDownList ID="cbxEndHour2" runat="server">
                </asp:DropDownList>
                (h) :
                <asp:DropDownList ID="cbxEndMinute2" runat="server">
                </asp:DropDownList>
                (m)</td>
            <td bgcolor="#999999" style="border: 1px solid #CCCCCC; text-align: left">
                Type</td>
            <td style="border: 1px solid #CCCCCC; text-align: left" id="cbxType2">
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
            <td bgcolor="#999999">
                Upload File</td>
            <td>
                <asp:FileUpload ID="FileUpload" runat="server" />
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
