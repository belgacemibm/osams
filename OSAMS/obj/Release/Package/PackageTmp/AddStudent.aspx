<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="AddStudent.aspx.vb" Inherits="OSAMS.AddStudent" %>
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
<div class="style18" id="caption">ADD NEW STUDENT</div>
<div id="table">

    

    <table class="style21" style="text-align: left">
        <tr>
            <td>
                Student ID:</td>
            <td>
                <asp:TextBox ID="txtStudentID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Program:</td>
            <td>
                <asp:DropDownList ID="cbxProgram" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Stream:</td>
            <td>
                <asp:DropDownList ID="cbxStream" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Family Name:</td>
            <td>
                <asp:TextBox ID="txtFamilyName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Middle Name:</td>
            <td>
                <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Given Name:</td>
            <td>
                <asp:TextBox ID="txtGivenName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Gender:</td>
            <td>
                <asp:DropDownList ID="cbxGender" runat="server">
                </asp:DropDownList>
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
