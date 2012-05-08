<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="SemesterAttendance.aspx.vb" Inherits="OSAMS.SemesterAttendance" EnableSessionState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .style21
        {
            width: 1000px;
            float: center;
            text-align:center;
        }

    </style>
    <div id="big_content">
<div id="content">
<div class="style18" id="caption">VIEW ATTENDANCE</div>
<div id="table">
<div id="selection">
    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>

<table width="700" border="0" align="left" cellpadding="2" cellspacing="0">
  <tr>
    <td align="left" valign="middle">Semester:&nbsp;
        <asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="True">
            <asp:ListItem Value="-1" Text="select"></asp:ListItem>
        </asp:DropDownList>
      </td>
    <td align="center" valign="middle">Course:&nbsp;
        <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="True">
        </asp:DropDownList>
      </td>
    <td align="left" valign="middle">Group:&nbsp;
        <asp:DropDownList ID="ddlGroup" runat="server">
        </asp:DropDownList>
      </td>
    
    <td align="left" valign="middle">
        <asp:Button ID="btnShow" runat="server" Text="Show Attendance" />
      </td>
  </tr>
</table>

    

</div>
    
    <br />
    <br />
     <asp:Table id="tbattendace" BorderWidth="1" GridLines="Both" runat="server" class="style21" style="text-align: left" AutoPostBack="True"/>

    <table class="style21" style="text-align: center;" align="center">

   


            <td>
            <div id="button" align="center" style="text-align: center">
               
                
                    <asp:Button ID="btnExport" runat="server" Text="Export to excel" 
                        Visible="False" align="center" />

            </div>
                </td>
        </tr>
    </table>
    
    
</div>
</div>
</div>
</asp:Content>

