<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="AddStudent.aspx.vb" Inherits="OSAMS.AddStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style21
        {
            width: 600px;
            float: left;
        }
        .style22
        {
            height: 26px;
        }
        .style23
        {
            width: 137px;
        }
        .style24
        {
            height: 26px;
            width: 137px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
<div id="content">
<div class="style18" id="caption">ADD NEW STUDENT</div>
<div id="table">

    <div id="error_message"><asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></div>

    <table class="style21" style="text-align: left; float: left; clear: left;">
        <tr>
            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold;">
                Student ID:</td>
            <td class="style23">
                <asp:TextBox ID="txtStudentID" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtStudentID" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtStudentID" 
                    ErrorMessage="Error: Student ID must follow format sxxxxxxx" 
                    ValidationExpression="^[s]{1}[0-9]{7}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold;">
                Program:</td>
            <td class="style23">
                <asp:DropDownList ID="ddlProgram" runat="server">
                    <asp:ListItem>BP138</asp:ListItem>
                    <asp:ListItem>BP153</asp:ListItem>
                    <asp:ListItem>BP162</asp:ListItem>
                    <asp:ListItem>BP181</asp:ListItem>
                    <asp:ListItem>BP222</asp:ListItem>
                    <asp:ListItem>BP251</asp:ListItem>
                    <asp:ListItem>BP252</asp:ListItem>
                    <asp:ListItem>BP254</asp:ListItem>
                    <asp:ListItem>DP001</asp:ListItem>
                    <asp:ListItem>GC020</asp:ListItem>
                    <asp:ListItem>MC065</asp:ListItem>
                    <asp:ListItem>MC088</asp:ListItem>
                    <asp:ListItem>MC162</asp:ListItem>
                    <asp:ListItem>MC189</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold;">
                Stream:</td>
            <td class="style23">
                <asp:DropDownList ID="ddlStream" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>M</asp:ListItem>
                    <asp:ListItem>F</asp:ListItem>
                    <asp:ListItem>B</asp:ListItem>
                
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold;">
                Family Name:</td>
            <td class="style23">
                <asp:TextBox ID="txtFamilyName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtFamilyName" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold;">
                Middle Name:</td>
            <td class="style23">
                <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold;">
                Given Name:</td>
            <td class="style23">
                <asp:TextBox ID="txtGivenName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtGivenName" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style22" 
                style="background-color: #000000; color: #FFFFFF; font-weight: bold;">
                Gender:</td>
            <td class="style24">
                <asp:DropDownList ID="ddlGender" runat="server">
                    <asp:ListItem>M</asp:ListItem>
                    <asp:ListItem>F</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style22">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <strong>Assign Student<asp:CheckBox ID="cbAssign" runat="server" AutoPostBack="true" />
                </strong></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold;">
                Semester:</td>
            <td class="style23">
                <asp:DropDownList ID="ddlSemester" runat="server" DataTextField="semester_name" 
                    DataValueField="semester_name" AutoPostBack="True" 
                    AppendDataBoundItems="True">
                    <asp:ListItem>Select</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold;">
                Course:</td>
            <td class="style23">
                <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="True" DataTextField="course_name" 
                    DataValueField="course_name" style="margin-bottom: 0px">
                    <asp:ListItem>Select</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="background-color: #000000; color: #FFFFFF; font-weight: bold;">
                Group:</td>
            <td class="style23">
                <asp:DropDownList ID="ddlGroup" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

    <div id="button">
        <div id="left">
        <asp:Button ID="btnSave" runat="server" Text="Save" CausesValidation = "true" />
        </div> 
        <asp:Button ID="btnCancel" runat="server" Text="Cancel"  CausesValidation = "false"/>
    </div>

    

</div>
</div>
</div>
</asp:Content>
