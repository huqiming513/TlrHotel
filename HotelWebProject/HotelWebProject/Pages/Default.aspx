<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HotelWebProject.Pages.Default" MasterPageFile="~/Web.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Default.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/about.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
        <div class="section w3ls-banner-btm-main">
		<div class="container">
			<div class="banner-btm">
				<div class="col-md-6 banner-btm-g1">
					<img src="/Images/hotel-caribe-fachada-interna.jpg" class="img-responsive" alt="" style="width:100%;height:100%;"/>
				</div>
				<div class="col-md-6 banner-btm-g2">
					<h3 class="title-main">TlrHotel 等候您的来访</h3>
					<h4 class="sub-title">给您最优质的服务</h4>
					<p class="text-left">
                        总部现有员工700余名，并成立了300余人的专业装潢队伍，拥有12000平米现代化办公场地和二十余亩的工业园区，以大型餐饮企业集团为依托，以创新的快餐财富攻略迈入餐饮市场，凭借卓越的品质、良好的服务和优雅的环境，致力于为消费者提供更精致、更健康、更快捷、更符合现代化生活形态的快餐美食，中国快速餐饮事业锐意前行！
					</p>
					<div class="find-about">
						<a href="CompanyDishes/DishesBook.aspx">立即预定</a>
					</div>
				</div>
				<div class="clearfix"></div>
			</div>
		</div>
	</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphDown" runat="server">
    <div class="news" style="display:flex;flex-direction:column;justify-content:center;">
		<h2 class="heading-agileinfo">招 牌 菜 品<span>Exclusive Holidays for Any Travelers</span></h2>
        <div class="cakes_grids">
            <asp:Repeater ID="rptRecommanded" runat="server">
                <ItemTemplate>
                    <div class="col-md-4">
		                <div class="cakes_grid1">
			                <img src="<%#Eval("DishId","../Images/dish/{0}.png") %>" alt="Recommanded Dishes">
			                <h3><%#Eval("DishName") %></h3>
			                <p>￥<%#Eval("UnitPrice")%></p>
		                </div>
	                </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
	</div>

<h2 class="heading-agileinfo">最 近 新 闻<span>Exclusive Holidays for Any Travelers</span></h2>
<div class="blog">
	<div class="container" style="width:50%;">
			<ul id="flexiselDemo1">		
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <li>
					        <div class="wthree_testimonials_grid_main text-center">
						        <div class="col-md-12 blog_grid">
							        <a href='/Pages/NewsDetail.aspx?NewsId=<%#Eval("NewsId") %>'>
							            <img src="../Images/hotel.jpg" alt="blog_post1" style="height:300px;"/>
							            <p><%#Eval("NewsTitle") %></p>
							        </a>
							        <p class="pull-right"><span class="fa fa-heart"></span> 7 likes / <span class="fa fa-comments"></span> 15 comments</p>
							        <h3><a href="single.aspx">27 <span>Dec</span></a></h3>
							        <div class="clearfix"></div>
						        </div>
						        <div class="clearfix"></div>
					        </div>
				        </li>
                    </ItemTemplate>
                 </asp:Repeater>	
			</ul>
	</div>
</div>

<script type="text/javascript">
    $(window).load(function() {
	    $("#flexiselDemo1").flexisel({
		    visibleItems:1,
		    animationSpeed: 1000,
		    autoPlay: true,
		    autoPlaySpeed: 4000,    		
		    pauseOnHover: true,
		    enableResponsiveBreakpoints: true,
		    responsiveBreakpoints: { 
			    portrait: { 
				    changePoint:480,
				    visibleItems: 1
			    }, 
			    landscape: { 
				    changePoint:640,
				    visibleItems:1
			    },
			    tablet: { 
				    changePoint:768,
				    visibleItems: 1
			    }
		    }
	    });
								
    });
</script>
<script type="text/javascript" src="/Scripts/jquery.flexisel.js"></script>
</asp:Content>