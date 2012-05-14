<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="checkAttendance.aspx.vb" Inherits="OSAMS.checkAttendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<script type="text/javascript">

    var student = new Array();



    function check(id) {



        var existed = false;

        

        if (window.student.length != 0) {
            for (i = 0; i < window.student.length; i++) {

                if (id === window.student[i]) {

                    student.splice(i, 1);
                    existed = true;

                    break;
                }

            }
        }





        if (existed == false) {

            window.student.push(id);
        }


    }


    function run() {
        var value = "";


        if (window.student.length != 0) {
            for (i = 0; i < this.student.length; i++) {
                value = value + window.student[i] + ",";
            }

        }

        if (value != "") {
            //var pathname = window.location.pathname + "?value=" + value;
            var pathname = window.location.href + "&value=" + value;
            window.location.href = pathname;
        } else {

            var pathname = window.location.href + "&value=0";
            window.location.href = pathname;

        }


    }
    function edit(value) {

        //        var pathname = window.location.protocol + "//" + window.location.host  + window.location.pathname + "?edit=" + value;
        var pathname = window.location.href + "&edit=" + value;
        window.location.href = pathname;

    }
    function runedit() {

        var value = "";


        if (window.student.length != 0) {
            for (i = 0; i < this.student.length; i++) {
                value = value + window.student[i] + ",";
            }

        }

        if (value != "") {
            
            var pathname = window.location.href + "&value=" + value;
            window.location.href = pathname;
        } else {

            var pathname = window.location.href + "&value=0";
            window.location.href = pathname;

        }

    }
//    function cancel(value) {

//        var pathname = window.location.protocol + "//" + window.location.host + window.location.pathname + "?field=" + value;
//    
//    }



</script>
<div id="big_content">
<div id="content">
<div id="content_header">
     <div id="content_header_logo"><img alt="logo" src="images/icons/page_accept.png" width="50" height="50" /></div>
     <div id="caption">MARK ATTENDANCE</div>
</div>
<div id="table">
<div id="error_message">
<asp:Label ID="lblMes" runat="server" Text="" ForeColor="Red"></asp:Label>
</div>
<div id="selection">


    
<table width="700" border="0" align="left" cellpadding="2" cellspacing="0" id="asd">
  <tr>
    <td align="left" valign="middle">Semester:&nbsp;
        <asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="True">
        </asp:DropDownList>
      </td>
    <td align="left" valign="middle">Course:&nbsp;
        <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="True">
        </asp:DropDownList>
      </td>
    <td align="left" valign="middle">Group:&nbsp;
        <asp:DropDownList ID="ddlGroup" runat="server">
        </asp:DropDownList>
      </td>

    
    <td align="left" valign="middle">
        <asp:Button ID="btnShow" runat="server" Text="Show Attendance" />
      </td>
  </tr>
</table>

</div>
    
    <br />
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

    <br />
     <asp:Table id="tbattendace" BorderWidth="1" GridLines="Both" runat="server" class="style21" style="text-align: left" AutoPostBack="True"/>

    
    
    
    <br />
    <br />


    <br />

    

    
</div>
</div>
</div>
</asp:Content>
