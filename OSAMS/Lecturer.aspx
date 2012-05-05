<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Lecturer.aspx.vb" Inherits="OSAMS.Lecturer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
<div id="content">
<div class="style18" id="caption">LECTURER MANAGEMENT</div>
<div id="table">

    <div id="button">
        
        <asp:GridView ID="grdvwLecturer" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" CellPadding="3" 
            DataKeyNames="lecturer_id" DataSourceID="SqlDataLecturer" 
            EnableModelValidation="True" ForeColor="Black" GridLines="Vertical" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="lecturer_id" HeaderText="Lecturer ID" 
                    ReadOnly="True" SortExpression="lecturer_id" />
                <asp:BoundField DataField="family_name" HeaderText="Family Name" 
                    SortExpression="family_name" />
                <asp:BoundField DataField="middle_name" HeaderText="Middle Name" 
                    SortExpression="middle_name" />
                <asp:BoundField DataField="given_name" HeaderText="Given Name" 
                    SortExpression="given_name" />
                <asp:TemplateField HeaderText="Gender" SortExpression="gender">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlGender" runat="server">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblGender" runat="server" Text='<%# Bind("gender") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
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
                <asp:BoundField DataField="password" HeaderText="Password" 
                    SortExpression="password" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
           
        <asp:SqlDataSource ID="SqlDataLecturer" runat="server" 
            ConflictDetection="CompareAllValues" 
            ConnectionString="<%$ ConnectionStrings:connstr %>" 
            DeleteCommand="DELETE FROM [lecturer] WHERE [lecturer_id] = @original_lecturer_id AND (([family_name] = @original_family_name) OR ([family_name] IS NULL AND @original_family_name IS NULL)) AND (([middle_name] = @original_middle_name) OR ([middle_name] IS NULL AND @original_middle_name IS NULL)) AND (([given_name] = @original_given_name) OR ([given_name] IS NULL AND @original_given_name IS NULL)) AND [gender] = @original_gender AND (([email] = @original_email) OR ([email] IS NULL AND @original_email IS NULL)) AND (([active] = @original_active) OR ([active] IS NULL AND @original_active IS NULL))" 
            InsertCommand="INSERT INTO [lecturer] ([lecturer_id], [family_name], [middle_name], [given_name], [gender], [email], [active]) VALUES (@lecturer_id, @family_name, @middle_name, @given_name, @gender, @email, @active)" 
            OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT lecturer.lecturer_id, lecturer.family_name, lecturer.middle_name, lecturer.given_name, lecturer.gender, lecturer.email, lecturer.active, account_type.account_type, account.password FROM lecturer INNER JOIN account ON lecturer.lecturer_id = account.user_name INNER JOIN account_type ON account.account_type_id = account_type.account_type_id" 
            
            UpdateCommand="UPDATE [lecturer] SET [family_name] = @family_name, [middle_name] = @middle_name, [given_name] = @given_name, [gender] = @gender, [email] = @email, [active] = '1' WHERE [lecturer_id] = @original_lecturer_id AND (([family_name] = @original_family_name) OR ([family_name] IS NULL AND @original_family_name IS NULL)) AND (([middle_name] = @original_middle_name) OR ([middle_name] IS NULL AND @original_middle_name IS NULL)) AND (([given_name] = @original_given_name) OR ([given_name] IS NULL AND @original_given_name IS NULL)) AND [gender] = @original_gender AND (([email] = @original_email) OR ([email] IS NULL AND @original_email IS NULL)) AND [active] = '1'"




             >
            
            <DeleteParameters>
                <asp:Parameter Name="original_lecturer_id" Type="String" />
                <asp:Parameter Name="original_family_name" Type="String" />
                <asp:Parameter Name="original_middle_name" Type="String" />
                <asp:Parameter Name="original_given_name" Type="String" />
                <asp:Parameter Name="original_gender" Type="String" />
                <asp:Parameter Name="original_email" Type="String" />
                <asp:Parameter Name="original_active" Type="Boolean" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="lecturer_id" Type="String" />
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
                <asp:Parameter Name="original_lecturer_id" Type="String" />
                <asp:Parameter Name="original_family_name" Type="String" />
                <asp:Parameter Name="original_middle_name" Type="String" />
                <asp:Parameter Name="original_given_name" Type="String" />
                <asp:Parameter Name="original_gender" Type="String" />
                <asp:Parameter Name="original_email" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        
    </div>
    <div id="left">
        <asp:Button ID="btnAddNewLecturer" runat="server" Text="Add New Lecturer" />
        </div> 
    

    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    

</div>
</div>
</div>
</asp:Content>
