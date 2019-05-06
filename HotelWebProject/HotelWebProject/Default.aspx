<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HotelWebProject.Default" MasterPageFile="Web.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/Default.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
        <div class="section w3ls-banner-btm-main">
		<div class="container">
			<div class="banner-btm">
				<div class="col-md-6 banner-btm-g1">
					<img src="Images/hotel-caribe-fachada-interna.jpg" class="img-responsive" alt="" style="width:100%;height:100%;"/>
				</div>
				<div class="col-md-6 banner-btm-g2">
					<h3 class="title-main">TlrHotel 等候您的来访</h3>
					<h4 class="sub-title">给您最优质的的服务</h4>
					<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut vitae nunc auctor, malesuada est eu, pellentesque nisi.
						Nam in enim lacinia, hendrerit neque non, placerat quam.Mauris eu tortor congue purus congue iaculis sit amet tincidunt
						neque. Aliquam suscipit nisi erat, non ultricies ex aliquet a.

					</p>
					<div class="find-about">
						<a href="about.html">关于我们</a>
					</div>
				</div>
				<div class="clearfix"></div>
			</div>
		</div>
	</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphDown" runat="server">
    <div class="news">
		<div class="container">  
				<h2 class="heading-agileinfo">最 近 新 闻<span>Exclusive Holidays for Any Travelers</span></h2>
			<div class="news-agileinfo"> 
				<div class="news-w3row"> 
                  <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <div class="col-md-6 wthree-news-grids">
						    <div class="col-md-3 col-xs-3 datew3-agileits">
							    <img src="Images/t1.jpg" class="img-responsive" alt=""/>
						    </div>
						    <div class="col-md-9 col-xs-9 datew3-agileits-info ">
							    <h5>
                                    <a href='CompanyNews/NewsDetail.aspx?NewsId=<%#Eval("NewsId") %>'><%#Eval("NewsTitle") %></a>
                                    <%--<a href="#" data-toggle="modal" data-target="#myModal">Sit amet justo vitae</a>--%>
							    </h5>
							    <h6> <%#Eval("PublishTime","{0:yyyy-MM-dd}") %></h6>
							    <p><%#Eval("NewsContents") %></p>
						    </div>
						    <div class="clearfix"> </div>
					    </div>
                    </ItemTemplate>
                  </asp:Repeater>
				</div>
			</div>
		</div>
	</div>

    <div class="news">
		<div class="container">  
			<h2 class="heading-agileinfo">招 牌 菜 品<span>Exclusive Holidays for Any Travelers</span></h2>
			<div class="news-agileinfo"> 
				<div class="news-w3row"> 
                    <div class="col-md-6 wthree-news-grids">
						<div class="col-md-3 col-xs-3 datew3-agileits">
							<img src="Images/zhaopai1.jpg" class="img-responsive" alt=""/>
						</div>
						<div class="col-md-9 col-xs-9 datew3-agileits-info ">
							<h5>
                                <a href='#'>招牌菜一</a>
							</h5>
							<p>测试简介</p>
						</div>
						<div class="clearfix"> </div>
					</div>
                    <div class="col-md-6 wthree-news-grids">
						<div class="col-md-3 col-xs-3 datew3-agileits">
							<img src="Images/zhaopai2.jpg" class="img-responsive" alt=""/>
						</div>
						<div class="col-md-9 col-xs-9 datew3-agileits-info ">
							<h5>
                                <a href='#'>招牌菜二</a>
							</h5>
							<p>测试简介</p>
						</div>
						<div class="clearfix"> </div>
					</div>
                    <div class="col-md-6 wthree-news-grids">
						<div class="col-md-3 col-xs-3 datew3-agileits">
							<img src="Images/zhaopai3.jpg" class="img-responsive" alt=""/>
						</div>
						<div class="col-md-9 col-xs-9 datew3-agileits-info ">
							<h5>
                                <a href='#'>招牌菜三</a>
							</h5>
							<p>测试简介</p>
						</div>
						<div class="clearfix"> </div>
					</div>
                    <div class="col-md-6 wthree-news-grids">
						<div class="col-md-3 col-xs-3 datew3-agileits">
							<img src="Images/zhaopai4.jpg" class="img-responsive" alt=""/>
						</div>
						<div class="col-md-9 col-xs-9 datew3-agileits-info ">
							<h5>
                                <a href='#'>招牌菜四</a>
							</h5>
							<p>测试简介</p>
						</div>
						<div class="clearfix"> </div>
					</div>
				</div>
			</div>
		</div>
	</div>

</asp:Content>