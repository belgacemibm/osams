<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Group.aspx.vb" Inherits="OSAMS.Group" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
<div id="content">
<div class="style18" id="caption">GROUP MANAGEMENT</div>
<div id="table">

    
    <div id="button">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:connstr %>" SelectCommand="select [group].[group_id],('group ' + [group].[group_name]) as group_name, [group].[semester_name], [course].[course_name], [group].[number_of_student], ([lecturer].[family_name] + ' '+ [lecturer].[middle_name] + ' '+ [lecturer].[given_name])  AS lecturer_name 
from [group], lecturer, course, semester
where [group].[course_id] = [course].[course_id] 
AND [group].[lecturer_id] = [lecturer].[lecturer_id] 
AND [group].[semester_name] = [semester].[semester_name]
AND [group].[active] = 1
AND datediff(day, getdate(), [semester].[end_date]) &gt;= 0
ORDER BY [group].[group_id] desc"></asp:SqlDataSource>
        <asp:GridView ID="GridView1"  allowpaging="True"  runat="server" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
            BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="group_id" 
            DataSourceID="SqlDataSource1" EnableModelValidation="True" ForeColor="Black" 
            GridLines="Horizontal">
            <Columns>
                <asp:BoundField DataField="group_id" HeaderText="group_id" 
                    InsertVisible="False" ReadOnly="True" SortExpression="group_id" />
                <asp:BoundField DataField="group_name" HeaderText="group_name" ReadOnly="True" 
                    SortExpression="group_name" />
                <asp:BoundField DataField="semester_name" HeaderText="semester_name" 
                    SortExpression="semester_name" />
                <asp:BoundField DataField="course_name" HeaderText="course_name" 
                    SortExpression="course_name" />
                <asp:BoundField DataField="number_of_student" HeaderText="number_of_student" 
                    SortExpression="number_of_student" />
                <asp:BoundField DataField="lecturer_name" HeaderText="lecturer_name" 
                    ReadOnly="True" SortExpression="lecturer_name" />
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Edit" 
                    ShowHeader="True" Text="Edit" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
        <br />
        <br />
  <div id="left">
 <asp:Button ID="btnNewGroup" runat="server" Text="New Group" />
  </div>
        
</div>
</div>

</div>
</div>
</asp:Content>
