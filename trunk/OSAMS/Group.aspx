<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Group.aspx.vb" Inherits="OSAMS.Group" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style21
        {
            width: 100%;
        }
        .style22
        {
            width: 67px;
        }
        .style23
        {
            width: 116px;
        }
        .style24
        {
            width: 56px;
        }
        .style25
        {
            width: 141px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
<div id="content">
<div class="style18" id="caption">GROUP MANAGEMENT</div>
<div id="table">

    <div id="selection">
    
        <table class="style21">
            <tr>
                <td class="style22">
                    <asp:Label ID="lblSemester" runat="server" Text="Semester"></asp:Label>
                </td>
                <td class="style23">
                    <asp:DropDownList ID="ddlSemester" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="style24">
                    <asp:Label ID="lblCourse" runat="server" Text="Course"></asp:Label>
                </td>
                <td class="style25">
                    <asp:DropDownList ID="ddlCourse" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnShow" runat="server" Text="Show" />
                </td>
            </tr>
        </table>
    
    </div>


 <asp:gridview autogeneratecolumns="false" runat="server" id="grdvwGroup" 
            AutoGenerateEditButton="True" CellPadding="3"  
            ForeColor="Black" GridLines="Vertical" BackColor="White" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">    
            <AlternatingRowStyle BackColor="#CCCCCC" />
          <columns>       
            <asp:templatefield headertext="Group ID"> 
                <EditItemTemplate>
                    <asp:Label ID="lblGroupID" runat="server" Text='<%# Bind("GroupID") %>'></asp:Label>
                </EditItemTemplate>
              <itemtemplate> <%# Eval("GroupID")%>       
              </itemtemplate> 
            </asp:templatefield> 

            <asp:templatefield headertext="Group Name"> 
                <EditItemTemplate>
                    <asp:Label ID="lblGroupName" runat="server" Text='<%# Bind("GroupName") %>'></asp:Label>
                </EditItemTemplate>
              <itemtemplate> <%# Eval("GroupName")%>
              </itemtemplate> </asp:templatefield> 

            <asp:templatefield headertext="Number Of Student"> 
                <EditItemTemplate>
                    <asp:Label  ID="lblNumberOfStudent" runat="server" Text='<%# Bind("NumberOfStudent") %>'></asp:Label>
                </EditItemTemplate>
              <itemtemplate><%# Eval("NumberOfStudent")%>
              </itemtemplate>
           </asp:templatefield>
             
           <asp:templatefield headertext="Course ID"> 
               <EditItemTemplate>
                   <asp:Label  ID="lblCourseID" runat="server" Text='<%# Bind("CourseID") %>'></asp:Label>
               </EditItemTemplate>
              <itemtemplate><%# Eval("CourseID")%>
              </itemtemplate>
           </asp:templatefield>

           <asp:templatefield headertext="Semester Name"> 
               <EditItemTemplate>
                   <asp:Label  ID="lblSemesterName" runat="server" Text='<%# Bind("SemesterName") %>'></asp:Label>
               </EditItemTemplate>
              <itemtemplate><%# Eval("SemesterName")%>
              </itemtemplate>
           </asp:templatefield>

           <asp:templatefield headertext="Lecturer Name"> 
               <EditItemTemplate>
                   <asp:DropDownList ID="ddlLecturerName" runat="server">
                   </asp:DropDownList>
               </EditItemTemplate>
              <itemtemplate><asp:Label ID="lblLecturerName" runat="server" Text='<%# Bind("LecturerName")%>'></asp:Label>
              </itemtemplate>
           </asp:templatefield>


            <asp:templatefield headertext="Day 1"> 
               <EditItemTemplate>
                   <asp:Label  ID="lblDayOne" runat="server" Text='<%# Bind("Day_1") %>'></asp:Label>
               </EditItemTemplate>
              <itemtemplate><%# Eval("Day_1")%>
              </itemtemplate>
           </asp:templatefield>
           
          <asp:templatefield headertext="Start Time"> 
               <EditItemTemplate>
                   <asp:Label  ID="lblDayOneStartTime" runat="server" Text='<%# Bind("StartTime_1") %>'></asp:Label>
               </EditItemTemplate>
              <itemtemplate><%# Eval("StartTime_1")%>
              </itemtemplate>
           </asp:templatefield>

           <asp:templatefield headertext="End Time"> 
               <EditItemTemplate>
                   <asp:Label  ID="lblDayOneEndTime" runat="server" Text='<%# Bind("EndTime_1") %>'></asp:Label>
               </EditItemTemplate>
              <itemtemplate><%# Eval("EndTime_1")%>
              </itemtemplate>
           </asp:templatefield>

           <asp:templatefield headertext="Type"> 
               <EditItemTemplate>
                   <asp:Label  ID="lblDayOneType" runat="server" Text='<%# Bind("Type_1") %>' ></asp:Label>
               </EditItemTemplate>
              <itemtemplate><%# Eval("Type_1")%>
              </itemtemplate>
           </asp:templatefield>
           
            <asp:templatefield headertext="Day 2"> 
               <EditItemTemplate>
                   <asp:Label  ID="lblDayTwo" runat="server" Text='<%# Bind("Day_2") %>'></asp:Label>
               </EditItemTemplate>
              <itemtemplate><%# Eval("Day_2")%>
              </itemtemplate>
           </asp:templatefield>
           
          <asp:templatefield headertext="Start Time"> 
               <EditItemTemplate>
                   <asp:Label  ID="lblDayTwoStartTime" runat="server" Text='<%# Bind("StartTime_2") %>' ></asp:Label>
               </EditItemTemplate>
              <itemtemplate><%# Eval("StartTime_2")%>
              </itemtemplate>
           </asp:templatefield>


           <asp:templatefield headertext="End Time"> 
               <EditItemTemplate>
                   <asp:Label  ID="lblDayTwoEndTime" runat="server" Text='<%# Bind("EndTime_2") %>' ></asp:Label>
               </EditItemTemplate>
              <itemtemplate><%# Eval("EndTime_2")%>
              </itemtemplate>
           </asp:templatefield>

                      <asp:templatefield headertext="Type"> 
               <EditItemTemplate>
                   <asp:Label  ID="lblDayTwoType" runat="server" Text='<%# Bind("Type_2") %>'  ></asp:Label>
               </EditItemTemplate>
              <itemtemplate><%# Eval("Type_2")%>
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
 <asp:Button ID="btnNewGroup" runat="server" Text="New Group" />
  </div>
        
</div>
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
</div>

</div>
</div>
</asp:Content>
