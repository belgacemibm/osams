<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Semester.aspx.vb" Inherits="OSAMS.Semester" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
<div id="content">
<div class="style18" id="caption">SEMESTER MANAGEMENT</div>
<div id="table">
<asp:ToolkitScriptManager ID="toolkitScriptMaster" runat="server">
</asp:ToolkitScriptManager>
    
    <div id="error_message"><asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></div>


    <asp:GridView ID="grdvwSemester" runat="server" AutoGenerateColumns="False" 
        CellPadding="3" DataKeyNames="semester_name" DataSourceID="SqlDataSource1" 
        EnableModelValidation="True" ForeColor="Black" GridLines="Vertical" 
        AllowPaging="True" AllowSorting="True" BackColor="White" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
        CssClass="grid_view">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="semester_name" HeaderText="Semester Name" 
                ReadOnly="True" SortExpression="semester_name" />
            <asp:TemplateField HeaderText="Start Date" SortExpression="start_date">
                <EditItemTemplate>
              
              
                    <asp:TextBox ID="txtStartDate" runat="server" 
                        Text='<%# Bind("start_date", "{0:d MMMM, yyyy}") %>'></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate" Format="d MMMM, yyyy">
                    </asp:CalendarExtender>
              
                  
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("start_date", "{0:d MMMM, yyyy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="End Date" SortExpression="end_date">
                <EditItemTemplate>
                    <asp:TextBox ID="txtEndDate" runat="server" 
                        Text='<%# Bind("end_date", "{0:d MMMM, yyyy}") %>'></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEndDate" Format="d MMMM, yyyy">
                    </asp:CalendarExtender>

                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("end_date", "{0:d MMMM, yyyy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConflictDetection="CompareAllValues" 
        ConnectionString="<%$ ConnectionStrings:connstr %>" 
        DeleteCommand="DELETE FROM [semester] WHERE [semester_name] = @original_semester_name AND [start_date] = @original_start_date AND [end_date] = @original_end_date AND (([active] = @original_active) OR ([active] IS NULL AND @original_active IS NULL))" 
        InsertCommand="INSERT INTO [semester] ([semester_name], [start_date], [end_date], [active]) VALUES (@semester_name, @start_date, @end_date, @active)" 
        OldValuesParameterFormatString="original_{0}" 
        SelectCommand="SELECT* FROM [semester]" 
        UpdateCommand="UPDATE [semester] SET [start_date] = @start_date, [end_date] = @end_date, [active] = '1' WHERE [semester_name] = @original_semester_name AND [start_date] = @original_start_date AND [end_date] = @original_end_date AND [active] = '1'">
        <DeleteParameters>
            <asp:Parameter Name="original_semester_name" Type="String" />
            <asp:Parameter Name="original_start_date" Type="DateTime" />
            <asp:Parameter Name="original_end_date" Type="DateTime" />
            <asp:Parameter Name="original_active" Type="Boolean" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="semester_name" Type="String" />
            <asp:Parameter Name="start_date" Type="DateTime" />
            <asp:Parameter Name="end_date" Type="DateTime" />
            <asp:Parameter Name="active" Type="Boolean" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="start_date" Type="DateTime" />
            <asp:Parameter Name="end_date" Type="DateTime" />
            <asp:Parameter Name="active" Type="Boolean" />
            <asp:Parameter Name="original_semester_name" Type="String" />
            <asp:Parameter Name="original_start_date" Type="DateTime" />
            <asp:Parameter Name="original_end_date" Type="DateTime" />
            <asp:Parameter Name="original_active" Type="Boolean" />
        </UpdateParameters>
    </asp:SqlDataSource>


    <div id="button">
        <div id="left">
        <asp:Button ID="btnAddSemester" runat="server" Text="Add New Semester" />
        </div> 
    </div>
</div>
</div>
</div>
</asp:Content>
