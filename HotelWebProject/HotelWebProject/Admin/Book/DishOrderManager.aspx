<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Web.Master" CodeBehind="DishOrderManager.aspx.cs" Inherits="HotelWebProject.Admin.Book.DishOrderManager" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Scripts/dataTables/dataTables.bootstrap.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/dataTables/jquery.dataTables.js"></script>
    <script type="text/javascript" src="../../Scripts/dataTables/dataTables.bootstrap.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#orderdataTables').dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
       <div class="panel panel-default" style="width:90%;" id="app">
            <div class="panel-heading">
                点餐列表
            </div>
            <div class="panel-body">
                <div class="table-responsive">
                    <table class="table table-striped table-bordered table-hover" id="orderdataTables">
                        <thead>
                        <tr>
                            <th>序号</th>
                            <th>桌号</th>
                            <th>点餐时间</th>
                            <th>点餐总价</th>   
                            <th>订单详情</th>
                        </tr>
                        </thead>
                        <tbody id="user-table">
                        <asp:Repeater ID="rptList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td> <%#Container.ItemIndex + 1 %> </td>
                                    <td> <%#Eval("DeskId") %> </td>
                                    <td> <%#Eval("OrderTime") %></td>
                                    <td> ￥<%#Eval("SumPrice") %></td>
                                    <td> 
                                        <asp:LinkButton CssClass="text-primary" ID="lbtnPass" CommandArgument='<%#Eval("OrderId")%>' CommandName="OrderId" runat="server" OnClick="lbtnOperation">查看</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="modal fade" id="myModal" tabindex="-1"
            role="dialog" aria-labelledby="myModalLabel"
            aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel2">订单详情</h4>
                </div>
                <div class="modal-body" id="modelBody">
                    <p class="text-left">桌号： {{dishOrder.DeskId}}</p>
                    <p class="text-left">菜品总价： ￥{{dishOrder.SumPrice}}</p>
                    <p class="text-left">菜品清单：</p>
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>菜品名称</th>
                                <th>单价</th>
                                <th>份数</th>
                            </tr>
                        </thead>
                      <tr v-for="detail in dishOrder.DishDetails">
                          <td>{{detail.Dish.DishName}}</td>  
                          <td>￥{{detail.Dish.UnitPrice}}</td>  
                          <td>{{detail.DishCount}}</td>  
                      </tr>
                    </table>
                    <p class="text-left">点餐时间： {{dishOrder.FormattedOrderTime}}</p>
                </div>

                <div class="modal-footer">
                    <asp:Button ID="btnSubmit" class="btn btn-primary" data-dismiss="modal" runat="server" Text="确认" />
                </div>
            </div>
        </div>
    </div>
        </div>
    <script type="text/javascript">
        var app = new Vue({
            el: '#app',
            data: {
                dishOrder: {}
            }
        });
    </script>
    <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
</asp:Content>
