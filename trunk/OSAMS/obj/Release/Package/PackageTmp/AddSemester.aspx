<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="AddSemester.aspx.vb" Inherits="OSAMS.AddSemester" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style21
        {
            width: 250px;
            float: left;
            
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
<div id="content">
<div class="style18" id="caption">ADD NEW SEMESTER</div>
<div id="table">

    

    <table align="left" class="style21" 
        style="text-align: left">
        <tr>
            <td>
                Year:</td>
            <td>
                <asp:DropDownList ID="cbxYear" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Order:</td>
            <td>
                <asp:DropDownList ID="cbxOrder" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Start Date:</td>
            <td>
                <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                End Date:</td>
            <td>
                <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
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
