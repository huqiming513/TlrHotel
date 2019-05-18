<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Web.Master" CodeBehind="RoomPublish.aspx.cs" Inherits="HotelWebProject.Admin.Room.RoomPublish" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/AdminCss.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
<div class="col-md-10 form-horizontal" style="margin:2% 0 2% 0;">
    <div class="form-group">
        <label for="txtDishName" class="col-md-offset-3 col-md-2 control-label">房间名称</label>
        <div class="col-md-4">
            <asp:TextBox ID="txtDishName" class="form-control" PlaceHolder="请输入房间名称" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <label for="txtUnitPrice" class="col-md-offset-3 col-sm-2 control-label">价格/天</label>
        <div class="col-sm-4">
            <asp:TextBox ID="txtUnitPrice" Type="Number" class="form-control" PlaceHolder="请输入房间价格" runat="server"></asp:TextBox>
        </div>
    </div>

    
    <div class="form-group">
        <label for="txtItemdiv" class="col-md-offset-3 col-sm-2 control-label">房间图片</label>
        <div class="col-sm-4">
            <asp:Image ID="dishImage" class="form-control" ImageUrl="~/Images/room/default.jpg"
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
        <asp:Button ID="btnPublish" CssClass="btn btn-primary" runat="server" Text="新增房间" OnClick="btnPublish_Click"/>
        <asp:Button ID="btnEdit" CssClass="btn btn-primary" runat="server" Text="提交修改" OnClick="btnPublish_Click"/>
        <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
    </div>
</div>
</asp:Content>
