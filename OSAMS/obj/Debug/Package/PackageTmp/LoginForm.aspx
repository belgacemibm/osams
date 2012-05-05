<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LoginForm.aspx.vb" Inherits="OSAMS.LoginForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var screen_height = $(document).height();
            var footer_height = $("#bigfooter").height();
            $("#logincontent").css("min-height", (screen_height - footer_height - 210) + "px");
        });
    </script>
<link href="css/style_body.css" rel="stylesheet" type="text/css" />
    <link id="Link1" runat="server" rel="shortcut icon" href="~/images/logo1_s.ico" type="image/x-icon" /> 
    <link id="Link2" runat="server" rel="icon" href="~/images/logo1_s.ico" type="image/ico" />
</head>
<body class="body">
    <form id="form1" runat="server">
    <div id="big_header">
<div id="header">
<div id="logo"><img alt="logo" src="images/logo_red.png" width="80" height="80" /></div>
<div id="menu">
<div id="title">
  <span class="style20">OSAMS</span></div>

</div>
</div>
</div>
<div id="logincontent">
<div id="mainlogin">
<div id="loginleft" style="font-size: 11px; color: #444444;"><img alt="logo" src="images/login.jpg" width="120" height="120" /><br />
<span style="font-size: 13px; color: #444444;">Welcome to OSAMS!</span><br /><br />
    Please enter your user ID and passowrd to log in (click &quot;Remember me next time&quot; 
    to remember your ID and password for the next login)</div>
<div id="loginright"><asp:Login ID="LoginControl" runat="server" 
        BackColor="White" Font-Names="Arial" 
        Font-Size="0.8em" ForeColor="#333333" Height="207px" Width="282px" 
        
        FailureText="The combination of User Name and Password is not correctl. Please try again." 
        LoginButtonText="Login">
        <InstructionTextStyle Font-Italic="True" ForeColor="#444444" />
        <LoginButtonStyle BackColor="Black" BorderColor="#444444" BorderStyle="Solid" 
            BorderWidth="1px" Font-Names="Arial" Font-Size="1 em" 
            ForeColor="White" />
        <TextBoxStyle Font-Size="1em" />
        <TitleTextStyle BackColor="White" Font-Bold="True" Font-Size="1.6 em" 
            ForeColor="#444444" HorizontalAlign="left" />
    </asp:Login></div>
    </div>
    </div>
<div id="bigfooter">
<div class="style11" id="footer">
<div id="footerleft">
Copyright © 2012, OSAMS v1.2.0</div>
</div>
</div>
    </form>
</body>
</html>
