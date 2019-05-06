<%@ Page Title="" Language="C#" MasterPageFile="~/Adminhyl/Adminhyl.Master" AutoEventWireup="true"
    CodeBehind="SuggestionList.aspx.cs" Inherits="HotelWebProject.Adminhyl.SuggestionList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="itemdiv">
        <div class="book-title">
            投诉时间</div>
        <div class="book-title">
            客户姓名</div>
        <div class="book-title">
            联系电话</div>
        <div class="book-title">
            电子邮件</div>
        <div class="book-title" style="width: 324px;">
            消费情况</div>
        <div class="book-title" style="width: 100px;">
            操作</div>
        <div class="book-title">
            2014-08-04 07:56
        </div>
        <div class="book-title">
            柳钢</div>
        <div class="book-title">
            15686623456人</div>
        <div class="book-title">
            liugang@qq.com</div>
        <div class="book-title" style="width: 324px;">
            在本店聚会一次</div>
        <div class="book-title" style="width: 100px;">
            <a href="#">受理投诉</a>
        </div>
        <div class="bookdetail">
            <div class="book-comment">
                具体投诉说明：感觉上菜有点慢,希望后续改进。
            </div>
        </div>
        <div class="book-title">
            2014-08-04 07:56
        </div>
        <div class="book-title">
            杜小杰</div>
        <div class="book-title">
            15687423456人</div>
        <div class="book-title">
            duxiaojie@qq.com</div>
        <div class="book-title" style="width: 324px;">
            在该店举行一次婚礼</div>
        <div class="book-title" style="width: 100px;">
             <a href="#">受理投诉</a>
        </div>
        <div class="bookdetail">
            <div class="book-comment">
                具体投诉说明：感觉总体服务不到位，菜品味道没有以前的好。
            </div>
        </div>
        <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
    </div>
</asp:Content>
