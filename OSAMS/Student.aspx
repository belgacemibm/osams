﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Student.aspx.vb" Inherits="OSAMS.Student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style21
        {
            width: 700px;
        }
        .style22
        {
            width: 88px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
<div id="content">
<div id="content_header">
     <div id="content_header_logo"><img alt="logo" src="images/icons/id_card.png" width="50" height="50" /></div>
     <div id="caption">STUDENT MANAGEMENT</div>
</div>
<div id="table" style="float: left; clear: left">
<div id="selection">
<table border="0" align="left" cellpadding="2" cellspacing="0" style="width: 488px">
  <tr>
    <td align="left" valign="middle">Semester:&nbsp;
        <asp:DropDownList ID="ddlSemester" runat="server" 
            DataTextField="semester_name" DataValueField="semester_name" 
            AppendDataBoundItems="True" AutoPostBack="True" 
            >
            <asp:ListItem Selected="True">None</asp:ListItem>
        </asp:DropDownList>
      </td>
    <td align="left" valign="middle">Course:&nbsp;
        <asp:DropDownList ID="ddlCourse" runat="server" 
            DataTextField="course_id" DataValueField="course_id" 
            AppendDataBoundItems="True" AutoPostBack="True">
        </asp:DropDownList>
      </td>
    <td align="left" valign="middle">
        <asp:Button ID="btnShow" runat="server" Text="Show" />
      </td>
  </tr>
</table>
</div>

    <div id="error_message"><asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></div>
    <div id="grid_view">
        <asp:gridview autogeneratecolumns="False" runat="server" id="grdvwStudent" 
            AutoGenerateEditButton="True"  CellPadding="3" EnableModelValidation="True" 
            ForeColor="Black" GridLines="Vertical" BackColor="White" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
        CssClass="grid_view">    
            <AlternatingRowStyle BackColor="#CCCCCC" />
          <columns>       
            <asp:templatefield headertext="Student ID"> 
                <EditItemTemplate>
                    <asp:Label ID="student_id" runat="server" Text='<%# Bind("student_id") %>'></asp:Label>
                </EditItemTemplate>
              <itemtemplate> 
                  <asp:Label ID="student_id" runat="server" Text='<%#Eval("student_id")%>'></asp:Label>       
              </itemtemplate> 
            </asp:templatefield> 

            <asp:templatefield headertext="Family Name"> 
                <EditItemTemplate>
                    <asp:TextBox ID="family_name" runat="server" Text='<%# Bind("family_name") %>'></asp:TextBox>
                </EditItemTemplate>
              <itemtemplate> <%# Eval("family_name")%>
              </itemtemplate> </asp:templatefield> 
            <asp:templatefield headertext="Middle Name"> 
                <EditItemTemplate>
                    <asp:TextBox ID="middle_name" runat="server" Text='<%# Bind("middle_name") %>'></asp:TextBox>
                </EditItemTemplate>
              <itemtemplate><%# Eval("middle_name")%>
              </itemtemplate>
           </asp:templatefield>  
           <asp:templatefield headertext="Given Name"> 
               <EditItemTemplate>
                   <asp:TextBox ID="given_name" runat="server" Text='<%# Bind("given_name") %>'></asp:TextBox>
               </EditItemTemplate>
              <itemtemplate><%# Eval("given_name")%>
              </itemtemplate>
           </asp:templatefield>
           <asp:templatefield headertext="Gender"> 
               <EditItemTemplate>
                   <asp:DropDownList ID="ddlGender" runat="server">
                   </asp:DropDownList>
               </EditItemTemplate>
              <itemtemplate><asp:Label ID="lblGender" runat="server" Text='<%# Bind("gender")%>'></asp:Label>
              </itemtemplate>
           </asp:templatefield>
           <asp:templatefield headertext="Email"> 
               <EditItemTemplate>
                   <asp:TextBox ID="email" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
               </EditItemTemplate>
              <itemtemplate><%# Eval("email")%>
              </itemtemplate>
           </asp:templatefield>
           <asp:templatefield headertext="Program"> 
               <EditItemTemplate>
                   <asp:DropDownList ID="ddlProgram" runat="server">
                   </asp:DropDownList>
               </EditItemTemplate>
              <itemtemplate><asp:Label ID="lblProgram" runat="server" Text='<%# Bind("program")%>'></asp:Label>
              </itemtemplate>
           </asp:templatefield>
           <asp:templatefield headertext="Stream"> 
               <EditItemTemplate>
                   <asp:DropDownList ID="ddlStream" runat="server">
                   </asp:DropDownList>
               </EditItemTemplate>
              <itemtemplate><asp:Label ID="lblStream" runat="server" Text='<%# Bind("stream")%>'></asp:Label>
              </itemtemplate>
           </asp:templatefield>
           <asp:templatefield headertext="Group Name"> 
               <EditItemTemplate>
                   <asp:DropDownList ID="ddlGroup_name" runat="server">
                   </asp:DropDownList>
               </EditItemTemplate>
              <itemtemplate><asp:Label ID="lblGroupName" runat="server" Text='<%# Bind("group_name")%>'></asp:Label>
              </itemtemplate>
           </asp:templatefield>  
           <asp:templatefield headertext="Password"> 
               <EditItemTemplate>
                   <asp:TextBox ID="password" runat="server" Text='<%# Bind("password") %>'></asp:TextBox>
               </EditItemTemplate>
              <itemtemplate><%# Eval("password")%>
              </itemtemplate>
           </asp:templatefield>
              <asp:TemplateField HeaderText="Remove">
                  <EditItemTemplate>
                      <asp:CheckBox ID="cbRemove" runat="server" />
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:CheckBox ID="cbRemove" runat="server" />
                  </ItemTemplate>
              </asp:TemplateField>
          </columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        </asp:gridview>
        </div>
        <div id="grid_view2">
        <asp:gridview autogeneratecolumns="False" runat="server" id="grdvwNoneStudent" 
            AutoGenerateEditButton="True"  CellPadding="3" EnableModelValidation="True" 
            ForeColor="Black" GridLines="Vertical" BackColor="White" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">    
            <AlternatingRowStyle BackColor="#CCCCCC" />
          <columns>       
            <asp:templatefield headertext="Student ID"> 
                <EditItemTemplate>
                    <asp:Label ID="student_id" runat="server" Text='<%# Bind("student_id") %>'></asp:Label>
                </EditItemTemplate>
              <itemtemplate> 
                  <asp:Label ID="student_id" runat="server" Text='<%#Eval("student_id")%>'></asp:Label>       
              </itemtemplate> 
            </asp:templatefield> 

            <asp:templatefield headertext="Family Name"> 
                <EditItemTemplate>
                    <asp:TextBox ID="family_name" runat="server" Text='<%# Bind("family_name") %>'></asp:TextBox>
                </EditItemTemplate>
              <itemtemplate> <%# Eval("family_name")%>
              </itemtemplate> </asp:templatefield> 
            <asp:templatefield headertext="Middle Name"> 
                <EditItemTemplate>
                    <asp:TextBox ID="middle_name" runat="server" Text='<%# Bind("middle_name") %>'></asp:TextBox>
                </EditItemTemplate>
              <itemtemplate><%# Eval("middle_name")%>
              </itemtemplate>
           </asp:templatefield>  
           <asp:templatefield headertext="Given Name"> 
               <EditItemTemplate>
                   <asp:TextBox ID="given_name" runat="server" Text='<%# Bind("given_name") %>'></asp:TextBox>
               </EditItemTemplate>
              <itemtemplate><%# Eval("given_name")%>
              </itemtemplate>
           </asp:templatefield>
           <asp:templatefield headertext="Gender"> 
               <EditItemTemplate>
                   <asp:DropDownList ID="ddlGender" runat="server">
                   </asp:DropDownList>
               </EditItemTemplate>
              <itemtemplate><asp:Label ID="lblGender" runat="server" Text='<%# Bind("gender")%>'></asp:Label>
              </itemtemplate>
           </asp:templatefield>
           <asp:templatefield headertext="Email"> 
               <EditItemTemplate>
                   <asp:TextBox ID="email" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
               </EditItemTemplate>
              <itemtemplate><%# Eval("email")%>
              </itemtemplate>
           </asp:templatefield>
           <asp:templatefield headertext="Program"> 
               <EditItemTemplate>
                   <asp:DropDownList ID="ddlProgram" runat="server">
                   </asp:DropDownList>
               </EditItemTemplate>
              <itemtemplate><asp:Label ID="lblProgram" runat="server" Text='<%# Bind("program")%>'></asp:Label>
              </itemtemplate>
           </asp:templatefield>
           <asp:templatefield headertext="Stream"> 
               <EditItemTemplate>
                   <asp:DropDownList ID="ddlStream" runat="server">
                   </asp:DropDownList>
               </EditItemTemplate>
              <itemtemplate><asp:Label ID="lblStream" runat="server" Text='<%# Bind("stream")%>'></asp:Label>
              </itemtemplate>
           </asp:templatefield>
            
           <asp:templatefield headertext="Password"> 
               <EditItemTemplate>
                   <asp:TextBox ID="password" runat="server" Text='<%# Bind("password") %>'></asp:TextBox>
               </EditItemTemplate>
              <itemtemplate><%# Eval("password")%>
              </itemtemplate>
           </asp:templatefield>
              
          </columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        </asp:gridview>
        </div>
    <div id="button">
        <div id="left">
        <asp:Button ID="btnAddNewStudent" runat="server" Text="Add New Student" />
            <asp:Button ID="btnRemove" runat="server" Text="Remove Student" Width="114px" />
        </div> 
    </div>

    <div id="student_div_search">
    <div id="student_search">
    <div id="table_middle_caption">
    &nbsp;<img alt="logo" src="images/add.png" width="14" height="14" />Add Student to Group
    </div>    
        <table class="style21" style="padding: 2px">
            <tr>
                <td class="style22">
                    <asp:Label ID="lblAssignStudentID" runat="server" Text="Student ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtStudentID" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblAssignSemester" runat="server" Text="Semester"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlAssignSemester" runat="server" AutoPostBack="True" 
                        style="height: 22px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblAssignCourse" runat="server" Text="Course"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlAssignCourse" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblAssignGroup" runat="server" Text="Group"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlAssignGroup" runat="server">
                        <asp:ListItem>Select</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="8">
            <asp:Button ID="btnAdd" runat="server" Text="Add Student to Group" />
                </td>
            </tr>
        </table>
        
    </div>
    
    </div>
    </div>
</div>
</div>

</asp:Content>
