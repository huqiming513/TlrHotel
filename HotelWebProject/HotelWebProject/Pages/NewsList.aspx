<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true"
    CodeBehind="NewsList.aspx.cs" Inherits="HotelWebProject.Pages.NewsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/News.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/comm.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="spage-left">
        <div class="news-type-list">
            <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                    <div class='newsitem <%#Convert.ToInt32(Eval("CategoryId"))==1?"inform":"event"%>'>
                        <span class="item-type"> <%#Eval("CategoryName")%> </span>
                        <a class="item-href" href='NewsDetail.aspx?newsId=<%#Eval("NewsId") %>'><%#Eval("NewsTitle") %></a>
                        <span class="item-time pull-right"> <%#Eval("PublishTime","{0:yyyy-MM-dd}") %> </span>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

