<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="AddCourse.aspx.vb" Inherits="OSAMS.AddCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style21
        {
            width: 745px;
            float: left;
        }
     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
<div id="content">
<div id="table">
    <div id="table_left">
    <div id="table_left_logo"><img alt="logo" src="images/icons/full_page.png" width="80" height="80" /></div>
    <div id="table_left_caption">COURSE<br />MANAGEMENT</div>
    </div>
    <div id="table_middle">
    <div id="table_middle_caption">
    &nbsp;<img alt="logo" src="images/add.png" width="14" height="14" />&nbsp;Add New Course</div>
    <div id="table_middle_note">Adding your data into the fields below. For instructions, please check out <a href="Help.aspx">Help</a> page.</div>
     <div id="error_message"><asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></div>
     <div id="table_middle_content">
    <table class="style21" style="text-align: left; float: left; clear: left;">
        <tr>

            <td>

                Course ID:</td>
            <td class="style24">
                <asp:TextBox ID="txtCourseID" runat="server"></asp:TextBox>
            </td>
            <td class="style22">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtCourseID" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtCourseID" 
                    ErrorMessage="Error: Course ID must follow format 4 characters and 4 numbers" 
                    ValidationExpression="^[a-zA-Z]{4}[0-9]{4}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>

            <td>

                Course Name:</td>
            <td class="style24">
                <asp:TextBox ID="txtCourseName" runat="server"></asp:TextBox>
            </td>
            <td class="style22">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtCourseName" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>

            <td>

                Level:</td>
            <td class="style24">
                <asp:DropDownList ID="ddlLevel" runat="server">
                    <asp:ListItem>Diploma</asp:ListItem>
                    <asp:ListItem>Bachelor</asp:ListItem>
                    <asp:ListItem>Master</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style22">
                &nbsp;</td>
        </tr>
        <tr>

            <td>


                Credit:</td>
            <td class="style24">
                <asp:DropDownList ID="ddlCredit" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style22">
                &nbsp;</td>
        </tr>
        <tr>

            <td>


                &nbsp;</td>
            <td class="style24">
        <div id="button_right">
        <asp:Button ID="btnSave" runat="server" Text="Save" CausesValidation = "true"/> 
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation = "false" />
        </div></td>
            <td class="style22">
                &nbsp;</td>
        </tr>
    </table>
    </div>
    
    </div>

    
    

</div>
</div>
</div>

</asp:Content>
