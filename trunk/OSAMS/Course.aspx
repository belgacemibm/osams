<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master"
    CodeBehind="Course.aspx.vb" Inherits="OSAMS.Course" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
        <div id="content">
            <div class="style18" id="caption">
                COURSE MANAGEMENT</div>
            <div id="table">
                
                <asp:gridview autogeneratecolumns="False" runat="server" id="grdvwCourse" 
            AutoGenerateEditButton="True"  CellPadding="3" EnableModelValidation="True" 
            ForeColor="Black" GridLines="Vertical" BackColor="White" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">    
            <AlternatingRowStyle BackColor="#CCCCCC" />
          <columns>       
            <asp:templatefield headertext="Course ID"> 
                <EditItemTemplate>
                    <asp:Label ID="course_id" runat="server" Text='<%# Bind("course_id") %>'></asp:Label>
                </EditItemTemplate>
              <itemtemplate> 
                  <asp:Label ID="course_id" runat="server" Text='<%#Eval("course_id")%>'></asp:Label>       
              </itemtemplate> 
            </asp:templatefield> 
            <asp:templatefield headertext="Course Name"> 
                <EditItemTemplate>
                    <asp:TextBox ID="course_name" runat="server" Text='<%# Bind("course_name") %>'></asp:TextBox>
                </EditItemTemplate>
              <itemtemplate> <%# Eval("course_name")%>
              </itemtemplate> </asp:templatefield> 
           
           <asp:templatefield headertext="Credit"> 
               <EditItemTemplate>
                   <asp:DropDownList ID="ddlCredit" runat="server">
                   </asp:DropDownList>
               </EditItemTemplate>
              <itemtemplate><asp:Label ID="lblCredit" runat="server" Text='<%# Bind("credit")%>'></asp:Label>
              </itemtemplate>
           </asp:templatefield>
          
           <asp:templatefield headertext="Level"> 
               <EditItemTemplate>
                   <asp:DropDownList ID="ddlLevel" runat="server">
                   </asp:DropDownList>
               </EditItemTemplate>
              <itemtemplate><asp:Label ID="lblLevel" runat="server" Text='<%# Bind("level")%>'></asp:Label>
              </itemtemplate>
           </asp:templatefield>
          
           
           
              
          </columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        </asp:gridview>


                <div id="button">
                    <div id="left">
                        <asp:Button ID="btnAddNewCourse" runat="server" Text="Add New Course" />
                    </div>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                    <asp:Button ID="btnFind" runat="server" Text="Find" />
                    <asp:Button ID="btnClear" runat="server" style="height: 26px" Text="Clear" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
