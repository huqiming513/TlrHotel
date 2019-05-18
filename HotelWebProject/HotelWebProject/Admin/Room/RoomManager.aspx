<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Web.Master" CodeBehind="RoomManager.aspx.cs" Inherits="HotelWebProject.Admin.Room.RoomManager" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/Dishes.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">

    <div id="dishlistdiv">
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <div class="dishlist-item">
                    <div class="dishlist-img">
                        <img src='<%#Eval("CategoryId","/Images/room/{0}.jpg") %>' alt="" />
                    </div>
                    <div class="dishlist-right">
                        <div class="dishlist-txt">
                            房间名称：<%#Eval("CategoryName") %></div>
                        <div class="dishlist-txt">
                            住宿价格/天：￥<%#Eval("UnitPrice") %></div>
                        <div class="dishlist-txt">
                            <a class="text-primary" href='/Admin/Room/RoomPublish.aspx?Operation=1&CategoryId=<%#Eval("CategoryId") %>'>修改</a>&nbsp;&nbsp;
                            <asp:LinkButton CssClass="text-warning" ID="lbtnDel" OnClientClick='return confirm("是否确认删除?")' OnClick="lbtnDel_Click" runat="server" CommandArgument='<%#Eval("CategoryId") %>'>删除</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        </div> 
    <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
</asp:Content>
