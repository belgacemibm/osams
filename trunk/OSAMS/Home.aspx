<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Home.aspx.vb" Inherits="OSAMS.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/slideshow.css" />
    <script type="text/javascript" src="Scripts/slideshow.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="big_content">
<div id="content">
<div id="table">
<div id="homeleft">
<div id="tabletitle">Introduction</div>
<div id="homecontent">    
                Welcome to OSAMS !<br />
                <p>
                    Understanding the need of BIS lecturer in student attendance management, OSAMS 
                    which stand for <strong>Online Student Attendance Management System</strong> has 
                    been created to solve the issue.</p>
                <p>
                    By using OSAMS, the lecturer could get many benefits from:</p>
                <ul>
                    <li><strong>
                    Saving paper</strong></li><br />               
                    <li><strong>
                    Saving time</strong></li><br />             
                    <li><strong>
                    Integrating data</strong></li><br />
                    <li><strong>
                    Analysing report</strong></li><br />
                </ul>
                <p>
                    Hope you 
                    will have a useful and gladful time when using OSAMS.</p>

    </div>          
    </div>
<div id="headerslide">
 
   <!-- jQuery handles to place the header background images -->
   <div id="headerimgs">
      <div id="headerimg1" class="headerimg"></div>
      <div id="headerimg2" class="headerimg"></div>
   </div>
 
   <!-- Slideshow controls -->
   <div id="headernav-outer">
      <div id="headernav">
         <div id="back" class="btn"></div>
         <div id="control" class="btn"></div>
         <div id="next" class="btn"></div>
      </div>
   </div>
 
   <!-- jQuery handles for the text displayed on top of the images -->
   <div id="headertxt">
      <p class="caption">
         <span id="firstline"></span>
         <a href="#" id="secondline"></a>
      </p>
      <p class="pictured">
         Pictured:
         <a href="#" id="pictureduri"></a>
      </p>
   </div>
</div>  
</div>
</div>
</div>
</asp:Content>
