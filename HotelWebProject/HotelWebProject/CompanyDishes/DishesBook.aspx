<%@ Page Title="" Language="C#" MasterPageFile="~/MP_Dishes.Master" AutoEventWireup="true"
    CodeBehind="DishesBook.aspx.cs" Inherits="HotelWebProject.CompanyDishes.DishesBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/Dishes.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
    <div class="cdiv">
        <div class="item">
            <div class="itemtitle">
                酒店名称：
            </div>
            <div class="itemcontent">
                <asp:DropDownList ID="ddlHotelName" runat="server" Width="100px">
                    <asp:ListItem>天津南开店</asp:ListItem>
                    <asp:ListItem>天津和平店</asp:ListItem>
                    <asp:ListItem>北京朝阳店</asp:ListItem>
                </asp:DropDownList>
                <span>&nbsp;*</span>
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
                您的消费时间：
            </div>
            <div class="itemcontent">
                <asp:TextBox ID="txtConsumeTime" CssClass="txt" runat="server" onClick="WdatePicker()"></asp:TextBox><span>&nbsp;*</span>
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
                您的消费人数：
            </div>
            <div class="itemcontent">
                <asp:TextBox ID="txtPersons" CssClass="txt" runat="server"></asp:TextBox><span>&nbsp;*</span>
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
                选择包间类型：
            </div>
            <div class="itemcontent">
                <asp:DropDownList ID="ddlRoomType" runat="server" Width="100px">
                    <asp:ListItem>包间</asp:ListItem>
                    <asp:ListItem>散座</asp:ListItem>
                </asp:DropDownList>
                <span>&nbsp;*</span>
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
                预订人姓名：
            </div>
            <div class="itemcontent">
                <asp:TextBox ID="txtCustomerName" CssClass="txt" runat="server"></asp:TextBox><span>&nbsp;*</span>
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
                联系电话：
            </div>
            <div class="itemcontent">
                <asp:TextBox ID="txtPhoneNumber" CssClass="txt" runat="server"></asp:TextBox><span>&nbsp;*</span>
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
                电子邮件：
            </div>
            <div class="itemcontent">
                <asp:TextBox ID="txtEmail" CssClass="txt" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
                备注事项：
            </div>
            <div class="itemcontent">
                <asp:TextBox ID="txtComment" CssClass="txt" runat="server" Height="100px" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
                验证码：
            </div>
            <div class="itemcontent">
                <asp:TextBox ID="txtValidateCode" CssClass="txt" runat="server" Width="50px"></asp:TextBox><span>&nbsp;*<asp:Image
                    ID="Image1" ImageUrl="~/Handlers/ValidateCode.ashx" runat="server" /></span>
            </div>
        </div>
        <div class="item">
            <div class="itemtitle">
            </div>
            <div class="itemcontent">
                <asp:Button ID="btnBook" runat="server" CssClass="btncss" Text="马上预定" OnClick="btnBook_Click" />
                <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
</asp:Content>
