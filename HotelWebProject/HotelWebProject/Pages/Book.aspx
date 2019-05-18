<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true"
    CodeBehind="Book.aspx.cs" Inherits="HotelWebProject.Pages.DishesBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/Dishes.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
<div id="order-form" style="margin:3rem 3rem 0 3rem;padding:3rem; background:rgba(255,255,255,0.5);border-radius:0.5rem; box-shadow:0 0 5px #eee;">
    <div class="form-horizontal">
        <div class="form-group">
            <label for="selectOrderType" class="col-md-offset-3 col-md-2 control-label">选择预订类型：</label>
            <div class="col-md-4">
                <asp:DropDownList class="form-control" ID="ddlOrderType" runat="server" v-model="orderType">
                    <asp:ListItem Text="订桌" Value="1"></asp:ListItem>
                    <asp:ListItem Text="订房" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>

    <div class="form-horizontal" v-if="orderType == 1">
        <div class="form-group">
            <label for="txtConsumeTime" class="col-md-offset-3 col-md-2 control-label">预计就餐时间：</label>
            <div class="col-md-4">
                <asp:TextBox ID="txtConsumeTime" class="form-control" PlaceHolder="请选择预计就餐时间" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:00'})"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="txtPersons" class="col-md-offset-3 col-md-2 control-label">预计就餐人数：</label>
            <div class="col-md-4">
                <asp:TextBox ID="txtPersons" type="number" class="form-control" PlaceHolder="请输入预计就餐人数" runat="server" ></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="ddlRoomType" class="col-md-offset-3 col-md-2 control-label">选择包间类型：</label>
            <div class="col-md-4">
                 <asp:DropDownList ID="ddlDeskType" class="form-control" runat="server">
                        <asp:ListItem>包间</asp:ListItem>
                        <asp:ListItem>散座</asp:ListItem>
                 </asp:DropDownList>
            </div>
        </div>
    </div>

    <div class="form-horizontal" v-else-if="orderType == 2">
        <div class="form-group">
            <label for="txtConsumeTime" class="col-md-offset-3 col-md-2 control-label">预计入住时间：</label>
            <div class="col-md-4">
                <asp:TextBox ID="tbCheckInTime" class="form-control" PlaceHolder="请选择预计入住时间" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:00'})"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="txtConsumeTime" class="col-md-offset-3 col-md-2 control-label">预计退房时间：</label>
            <div class="col-md-4">
                <asp:TextBox ID="tbCheckOutTime" class="form-control" PlaceHolder="请选择预计退房时间" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:00'})"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="ddlRoomType" class="col-md-offset-3 col-md-2 control-label">选择房间类型：</label>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlRoomType" class="form-control" runat="server" v-model="roomType"></asp:DropDownList>
            </div>
        </div>
    </div>

    <div class="form-horizontal">
          <div class="form-group">
            <label for="txtCustomerName" class="col-md-offset-3 col-md-2 control-label">预订人姓名：</label>
            <div class="col-md-4">
                <asp:TextBox ID="txtCustomerName" class="form-control" PlaceHolder="请输入预订人姓名" runat="server" ></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="txtPhoneNumber" class="col-md-offset-3 col-md-2 control-label">联系电话：</label>
            <div class="col-md-4">
                <asp:TextBox ID="txtPhoneNumber" class="form-control" PlaceHolder="请输入订餐人的联系电话" runat="server" ></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="txtComment" class="col-md-offset-3 col-md-2 control-label">备注事项：</label>
            <div class="col-md-4">
                <asp:TextBox ID="txtComment" class="form-control" PlaceHolder="补充其他信息" runat="server" Height="100px" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="txtComment" class="col-md-offset-3 col-md-2 control-label">验证码：</label>
            <div class="col-md-4">
                 <asp:TextBox class="form-control col-md-6" ID="txtValidateCode"  runat="server" Style="width:40%;"  PlaceHolder="输入验证码" ></asp:TextBox>
                 <asp:Image class="col-md-6" ID="Image1" ImageUrl="~/Handlers/ValidateCode.ashx" runat="server" Style="height:34px;"/>
            </div>
        </div>
        <div class="form-group" style="margin-top:40px;">
            <asp:Button ID="btnPublish" CssClass="btn btn-default" runat="server" Text="提交预订" OnClick="btnBook_Click"/>
            <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
        </div>
    </div>


    <div class="clearfix"></div>
</div>
<script type="text/javascript">
// Vue对象
var app = new Vue({
    el: '#order-form',
    data: {
        orderType: 1,
        roomType: 1
    }
});
$(function () {
    var params = getSearchParams();
    if (params.ordertype) {
        app.orderType = params.ordertype;
    }
    if (params.roomtype) {
        app.roomType = parseInt(params.roomtype);
    }
});

</script>
</asp:Content>
