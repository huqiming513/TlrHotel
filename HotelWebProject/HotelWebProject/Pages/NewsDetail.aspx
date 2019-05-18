<%@ Page Title="" Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true"
    CodeBehind="NewsDetail.aspx.cs" Inherits="HotelWebProject.Pages.NewsDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/News.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/comm2.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
  <div class="g-commu_article">
      <div class="part">
          <div class="in-part">
              <h1 class="art-tit" ID="newsTitle" runat="server"></h1>
              <div class="art-palette">
                    <span class="art-time" id="publishTime" runat="server"></span>
                   <%-- <span class="fs-title">字体：</span>
                    <div class="fs-wrap">
                        <a href="javascript:fontZoom(16)" class="btn-font-size"><span class="radio"></span>大</a>
                        <a href="javascript:fontZoom(14)" class="btn-font-size"><span class="radio"></span>中</a>
                        <a href="javascript:fontZoom(12)" class="btn-font-size"><span class="radio"></span>小</a>
                    </div>--%>
              </div>
              <div class="article" ID="newsContents" runat="server">

              </div>
          </div>
      </div>
  </div>
</asp:Content>
