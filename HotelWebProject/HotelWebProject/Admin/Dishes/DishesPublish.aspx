<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Web.Master" AutoEventWireup="true"
    CodeBehind="DishesPublish.aspx.cs" Inherits="HotelWebProject.Admin.DishesPublish" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/AdminCss.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
<div class="col-md-10 form-horizontal" style="margin:2% 0 2% 0;">
    <div class="form-group">
        <label for="txtDishName" class="col-md-offset-3 col-md-2 control-label">菜品名称</label>
        <div class="col-md-4">
            <asp:TextBox ID="txtDishName" class="form-control" PlaceHolder="请输入菜品名称" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <label for="txtUnitPrice" class="col-md-offset-3 col-sm-2 control-label">价格</label>
        <div class="col-sm-4">
            <asp:TextBox ID="txtUnitPrice" Type="Number" Step="0.01" class="form-control" PlaceHolder="请输入菜品价格" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <label for="ddlCategory" class="col-md-offset-3 col-sm-2 control-label">菜品分类</label>
        <div class="col-sm-4">
            <asp:DropDownList ID="ddlCategory" class="form-control" runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class="form-group">
        <label for="txtItemdiv" class="col-md-offset-3 col-sm-2 control-label">菜品图片</label>
        <div class="col-sm-4">
            <asp:Image ID="dishImage" class="form-control" ImageUrl="~/Images/dish/default.png"
                       CssClass="imgDish"
                       runat="server"/>
        </div>
    </div>
    <div class="form-group">
        <label for="txtItemdiv" class="col-md-offset-3 col-sm-2 control-label">上传图片</label>
        <div class="col-sm-4">
            <asp:FileUpload ID="fulImage" class="form-control" runat="server"/>
        </div>
    </div>

    <div class="form-group" style="margin-top:40px;">
        <asp:Button ID="btnPublish" CssClass="btn btn-primary" runat="server" Text="新增菜品" OnClick="btnPublish_Click"/>
        <asp:Button ID="btnEdit" CssClass="btn btn-primary" runat="server" Text="提交修改" OnClick="btnPublish_Click"/>
        <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
    </div>
</div>
</asp:Content>
