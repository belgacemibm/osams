<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="EditGroup.aspx.vb" Inherits="OSAMS.EditGroup" %>
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
<div class="style18" id="caption">EDIT GROUP</div>
<div id="table">

    

    <table align="left" class="style21">
        <tr>
            <td style="text-align: left; ">
                Group Name:</td>
            <td style="text-align: left">
                <asp:Label ID="lblGroupName" runat="server" BorderStyle="None" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; ">
                Lecturer:</td>
            <td style="text-align: left">
                <asp:DropDownList ID="ddlLecturer" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
    </table>

    <div id="button">
    <br />
  <div id="left">
<asp:Button ID="btnSave" runat="server" Text="Save" />
  </div> 
  
<asp:Button ID="btnCancel" runat="server" Text="Cancel" />
  
</div>

</div>
</div>
</div>
</asp:Content>
