<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Admin.aspx.vb" Inherits="OSAMS.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
<div id="content">
<div class="style18" id="caption">ADMIN MANAGEMENT</div>
<div id="table">
    <div id="error_message"><asp:Label ID="lblError" runat="server"></asp:Label></div>
    
            <asp:GridView ID="grdvwAdmin" runat="server" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="staff_id" 
                DataSourceID="SqlDataAdmin" EnableModelValidation="True" BackColor="White" 
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                ForeColor="Black" GridLines="Vertical" CssClass="grid_view">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:BoundField DataField="staff_id" HeaderText="Staff ID" ReadOnly="True" 
                        SortExpression="staff_id" />
                    <asp:TemplateField HeaderText="Family Name" SortExpression="family_name">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFamilyName" runat="server" 
                                Text='<%# Bind("family_name") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("family_name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Middle Name" SortExpression="middle_name">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtMiddleName" runat="server" 
                                Text='<%# Bind("middle_name") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("middle_name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Given Name" SortExpression="given_name">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtGivenName" runat="server" Text='<%# Bind("given_name") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("given_name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Gender" SortExpression="gender">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlGender" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblGender" runat="server" Text='<%# Bind("gender") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email" SortExpression="email">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("email") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Active" SortExpression="active">
                        <EditItemTemplate>
                            <asp:CheckBox ID="cbActive" runat="server" Checked='<%# Bind("active") %>' />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("active") %>' 
                                Enabled="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataAdmin" runat="server" 
                ConflictDetection="CompareAllValues" 
                ConnectionString="<%$ ConnectionStrings:connstr %>" 
                DeleteCommand="DELETE FROM [admin] WHERE [staff_id] = @original_staff_id AND (([family_name] = @original_family_name) OR ([family_name] IS NULL AND @original_family_name IS NULL)) AND (([middle_name] = @original_middle_name) OR ([middle_name] IS NULL AND @original_middle_name IS NULL)) AND (([given_name] = @original_given_name) OR ([given_name] IS NULL AND @original_given_name IS NULL)) AND [gender] = @original_gender AND (([email] = @original_email) OR ([email] IS NULL AND @original_email IS NULL)) AND (([active] = @original_active) OR ([active] IS NULL AND @original_active IS NULL))" 
                InsertCommand="INSERT INTO [admin] ([staff_id], [family_name], [middle_name], [given_name], [gender], [email], [active]) VALUES (@staff_id, @family_name, @middle_name, @given_name, @gender, @email, @active)" 
                OldValuesParameterFormatString="original_{0}" 
                SelectCommand="
SELECT  [admin].staff_id, [admin].family_name, [admin].middle_name, [admin].given_name, [admin].gender, [admin].email, [account].active 
from [admin] inner join [account] on [admin].staff_id = [account].[user_name] inner join [account_type] on [account].[account_type_id] = [account_type].[account_type_id]
where [account_type].[account_type_id] = 2" 
                
                UpdateCommand="UPDATE [admin] SET [family_name] = @family_name, [middle_name] = @middle_name, [given_name] = @given_name, [gender] = @gender, [email] = @email, [active] = @active WHERE [staff_id] = @original_staff_id AND (([family_name] = @original_family_name) OR ([family_name] IS NULL AND @original_family_name IS NULL)) AND (([middle_name] = @original_middle_name) OR ([middle_name] IS NULL AND @original_middle_name IS NULL)) AND (([given_name] = @original_given_name) OR ([given_name] IS NULL AND @original_given_name IS NULL)) AND [gender] = @original_gender AND (([email] = @original_email) OR ([email] IS NULL AND @original_email IS NULL)) AND (([active] = @original_active) OR ([active] IS NULL AND @original_active IS NULL))">
                <DeleteParameters>
                    <asp:Parameter Name="original_staff_id" Type="String" />
                    <asp:Parameter Name="original_family_name" Type="String" />
                    <asp:Parameter Name="original_middle_name" Type="String" />
                    <asp:Parameter Name="original_given_name" Type="String" />
                    <asp:Parameter Name="original_gender" Type="String" />
                    <asp:Parameter Name="original_email" Type="String" />
                    <asp:Parameter Name="original_active" Type="Boolean" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="staff_id" Type="String" />
                    <asp:Parameter Name="family_name" Type="String" />
                    <asp:Parameter Name="middle_name" Type="String" />
                    <asp:Parameter Name="given_name" Type="String" />
                    <asp:Parameter Name="gender" Type="String" />
                    <asp:Parameter Name="email" Type="String" />
                    <asp:Parameter Name="active" Type="Boolean" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="family_name" Type="String" />
                    <asp:Parameter Name="middle_name" Type="String" />
                    <asp:Parameter Name="given_name" Type="String" />
                    <asp:Parameter Name="gender" Type="String" />
                    <asp:Parameter Name="email" Type="String" />
                    <asp:Parameter Name="active" Type="Boolean" />
                    <asp:Parameter Name="original_staff_id" Type="String" />
                    <asp:Parameter Name="original_family_name" Type="String" />
                    <asp:Parameter Name="original_middle_name" Type="String" />
                    <asp:Parameter Name="original_given_name" Type="String" />
                    <asp:Parameter Name="original_gender" Type="String" />
                    <asp:Parameter Name="original_email" Type="String" />
                    <asp:Parameter Name="original_active" Type="Boolean" />
                </UpdateParameters>
            </asp:SqlDataSource>
        <div id="button">
            <div id="left">
                <asp:Button ID="btnNewAdmin" runat="server" Text="Add New Admin" />
            </div> 
        </div>
</div>
</div>
</div>
</asp:Content>
