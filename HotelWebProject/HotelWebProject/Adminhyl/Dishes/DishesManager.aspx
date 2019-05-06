<%@ Page Title="" Language="C#" MasterPageFile="~/Adminhyl/Adminhyl.Master" AutoEventWireup="true"
    CodeBehind="DishesManager.aspx.cs" Inherits="HotelWebProject.Adminhyl.DishesManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/Dishes.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div id="dishcategory" class="col-md-12">
        <div class="form-inline">
            <div class="form-group">
                <label for="ddlCategory" class="control-label">菜品分类</label>
                <asp:DropDownList ID="ddlCategory" class="form-control" runat="server"></asp:DropDownList>
            </div>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnQuery" CssClass="btn btn-primary" runat="server" Text="提交查询" OnClick="btnQuery_Click" />
        </div>
    </div>

    <div id="dishlistdiv">
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <div class="dishlist-item">
                    <div class="dishlist-img">
                        <img src='<%#Eval("DishId","/Images/dish/{0}.png") %>' alt="" />
                    </div>
                    <div class="dishlist-right">
                        <div class="dishlist-txt">
                            菜品名称：<%#Eval("DishName") %></div>
                        <div class="dishlist-txt">
                            菜品分类：<%#Eval("CategoryName") %></div>
                        <div class="dishlist-txt">
                            菜品价格：￥<%#Eval("UnitPrice") %></div>
                        <div class="dishlist-txt">
                            <a class="text-primary" href='/Adminhyl/Dishes/DishesPublish.aspx?Operation=1&dishId=<%#Eval("DishId") %>'>修改</a>&nbsp;&nbsp;
                            <asp:LinkButton CssClass="text-warning" ID="lbtnDel" OnClientClick='return confirm("是否确认删除?")' OnClick="lbtnDel_Click" runat="server" CommandArgument='<%#Eval("DishID") %>'>删除</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        </div> 
    <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
</asp:Content>
