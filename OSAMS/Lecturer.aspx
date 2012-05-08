<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Lecturer.aspx.vb" Inherits="OSAMS.Lecturer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
<div id="content">
<div id="content_header">
    <div id="content_header_logo"><img alt="logo" src="images/icons/user.png" width="50" height="50" /></div>
    <div id="caption">LECTURER MANAGEMENT</div>
</div>
<div id="table">
    <div id="error_message"><asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></div>
    
        <div id="grid_view">
         <asp:gridview autogeneratecolumns="False" runat="server" id="grdvwLecturer" 
            AutoGenerateEditButton="True"  CellPadding="3" EnableModelValidation="True" 
            ForeColor="Black" GridLines="Vertical" BackColor="White" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CssClass="grid_view">    
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:templatefield headertext="Lecturer ID"> 
                <EditItemTemplate>
                    <asp:Label ID="lecturer_id" runat="server" Text='<%# Bind("lecturer_id") %>'></asp:Label>
                </EditItemTemplate>
              <itemtemplate> 
                  <asp:Label ID="lecturer_id" runat="server" Text='<%#Eval("lecturer_id")%>'></asp:Label>       
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
                <asp:TemplateField HeaderText="Gender" SortExpression="gender">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlGender" runat="server">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblGender" runat="server" Text='<%# Bind("gender") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:templatefield headertext="Email"> 
               <EditItemTemplate>
                   <asp:TextBox ID="email" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
               </EditItemTemplate>
              <itemtemplate><%# Eval("email")%>
              </itemtemplate>
           </asp:templatefield>
                <asp:TemplateField HeaderText="Account Type" SortExpression="account_type">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlAccountType" runat="server">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblAccountType" runat="server" 
                            Text='<%# Bind("account_type") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:templatefield headertext="Password"> 
               <EditItemTemplate>
                   <asp:TextBox ID="password" runat="server" Text='<%# Bind("password") %>'></asp:TextBox>
               </EditItemTemplate>
              <itemtemplate><%# Eval("password")%>
              </itemtemplate>
           </asp:templatefield>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        </asp:gridview>
        </div>
    <div id="button">       
    
        <asp:Button ID="btnAddNewLecturer" runat="server" Text="Add New Lecturer" />
   
    </div>

    
    
    <div id="find" style="float: left; clear: left;">
    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
    <asp:Button ID="btnFind" runat="server" Text="Find" />
    <asp:Button ID="btnClear" runat="server" Text="Clear" />
    </div>

</div>
</div>
</div>
</asp:Content>
