<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="HotelWebProject.Admin.AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hotel Admin</title>
    <link href="Styles/AdminCss.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Styles/chocolat.css" type="text/css"/>
    <link rel="stylesheet" href="../Styles/style.css" type="text/css" media="all" />
    <link rel="stylesheet" href="../Styles/flexslider.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="../Styles/font-awesome.css"/> 
    <script type="text/javascript" src="../../Scripts/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" src="../../Scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="../../Scripts/vue.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="banner">
        <div class="agile_dot_info">
             <div class="w3-header-bottom">
                <div class="container">
                    <div class="w3layouts-logo">
                    <h1>
	                    <a href="Default.aspx">TlrHotel </a>
                    </h1>
                    </div>
                    <div class="top-nav">
		                <nav class="navbar navbar-default">
				            <ul class="nav navbar-nav">
				            </ul>	
		                </nav>		
                    </div>
                    <div class="clearfix"> </div>
                 </div>
            </div>
           <div id="content" style="padding-top:3rem;">
                <div id="content">
                    <div id="logindiv">
                        <div id="ltitle">
                            管理员登录</div>
                        <div class="litem">
                            登录账号：<asp:TextBox ID="txtLoginId" runat="server" CssClass="txt"></asp:TextBox></div>
                        <div class="litem">
                            登录密码：<asp:TextBox ID="txtLoginPwd" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox></div>
                    <div class="litem"><asp:Button ID="btnlogin" runat="server" Text="马上登录" 
                            CssClass="btn btn-primary" OnClick="btnlogin_Click" />
                        <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
                        </div>
                
                    </div>
                </div>
           </div>  
           <div id="footer">
                <div id="bq">
                    <a target="_blank" href="/Admin/Default.aspx">[网站首页]</a>&nbsp;&nbsp;版权所有 Copyright(C)2019-2022
                    TlrHotel&nbsp;&nbsp;&nbsp;<asp:Literal ID="ltaAdmin" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </div>
    <div id="container" style="display:none;">
    </div>
    </form>
</body>
</html>