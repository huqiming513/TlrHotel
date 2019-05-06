<%@ Page Title="" Language="C#" MasterPageFile="~/Adminhyl/Adminhyl.Master" AutoEventWireup="true"
    CodeBehind="RecruitmentManager.aspx.cs" Inherits="HotelWebProject.Adminhyl.RecruitmentManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/AdminCss.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="itemdiv">
        <div class="bitem-title">
            职位名称</div>
        <div class="bitem-title">
            职位类型</div>
        <div class="bitem-title">
            工作经验</div>
        <div class="bitem-title">
            学历要求</div>
        <div class="bitem-title">
            招聘人数</div>
        <div class="bitem-title">
            工作地点</div>
        <div class="bitem-title" style="width: 120px;">
            操作</div>
        <div class="bitem">
            大堂经理</div>
        <div class="bitem">
            全职</div>
        <div class="bitem">
            3年</div>
        <div class="bitem">
            本科</div>
        <div class="bitem">
            2</div>
        <div class="bitem">
            天津</div>
        <div class="bitem" style="width: 120px;">
            <a href='RecruitmentModify.aspx?PostId=100000' target="_blank">修改</a> <a href="#">删除</a>
        </div>
        <div class="bitem">
            接待员</div>
        <div class="bitem">
            全职</div>
        <div class="bitem">
            1年</div>
        <div class="bitem">
            高中</div>
        <div class="bitem">
            5</div>
        <div class="bitem">
            北京</div>
        <div class="bitem" style="width: 120px;">
            <a href='RecruitmentModify.aspx?PostId=100001' target="_blank">修改</a> <a href="#">删除</a>
        </div>
        <div class="bitem">
            总经理助理</div>
        <div class="bitem">
            全职</div>
        <div class="bitem">
            3年</div>
        <div class="bitem">
            本科</div>
        <div class="bitem">
            1</div>
        <div class="bitem">
            天津</div>
        <div class="bitem" style="width: 120px;">
            <a href='RecruitmentModify.aspx?PostId=100002' target="_blank">修改</a> <a href="#">删除</a>
        </div>
    </div>
    <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
</asp:Content>
