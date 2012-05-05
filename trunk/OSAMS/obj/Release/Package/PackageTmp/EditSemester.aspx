<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="EditSemester.aspx.vb" Inherits="OSAMS.EditSemester" %>
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
<div class="style18" id="caption">EDIT SEMESTER</div>
<div id="table">

    

    <table class="style21" style="text-align: left">
        <tr>
            <td>
                Semester:</td>
            <td>
                2012A</td>
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
