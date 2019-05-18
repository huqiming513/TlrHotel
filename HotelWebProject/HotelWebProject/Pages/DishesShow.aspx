<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true"
    CodeBehind="DishesShow.aspx.cs" Inherits="HotelWebProject.Pages.DishesShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/Dishes.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/comm.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/awesome-bootstrap-checkbox.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="Server">
<div class="form-inline" id="desk-box" style="margin-top:2rem;display:none;">
    <div class="form-group" style="padding-top:1.3rem;margin-right:2rem;">
        <div class="input-group">
            <div class="input-group-addon">桌号</div>
            <input type="number" class="form-control" id="desk-number"/>
        </div>
    </div>
    <a id="btn-submit" class="btn btn-info">点餐</a>
</div>

<div class="cakes_grids" style="margin-top:2rem;">
    <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate>
            <div class="col-md-3">
		        <div class="cakes_grid1" style="background:rgba(255,255,255,0.9);box-shadow:0 0 5px #ddd;">
			        <img src="<%#Eval("DishId","../Images/dish/{0}.png") %>" alt="Recommanded Dishes" style="height:150px;">
			        <h3><%#Eval("DishName") %></h3>
			        <p>￥<%#Eval("UnitPrice")%></p>
                    <input type="number" class="form-control input-number" placeholder="份数" style="display:none;position:absolute; left:1.4rem;bottom:2.3rem;width:30%;height:25px;"/>
                    <div class="checkbox checkbox-info" style="position:absolute; right:1rem;bottom:1.7rem;">
                        <input type="checkbox" name="dish-reserve" data-id='<%#Eval("DishId")%>'>
                        <label for="checkbox1"></label>
                    </div>
		        </div>
	        </div>
        </ItemTemplate>
    </asp:Repeater>
    <div class="clearfix"></div>
</div>
<div class="modal fade" id="myModal" tabindex="-1"
        role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title" id="myModalLabel2">点餐小计</h4>
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
                <p class="text-left">点餐时间： {{dishOrder.OrderTime}}</p>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">取消</button>
                <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" Text="确认" OnClick="btnSubmit_Click"/>
            </div>
        </div>
    </div>
</div>

<script type="text/javascript">
    // Vue对象
    var app = new Vue({
        el: '#modelBody',
        data: {
            dishOrder: {}
        }
    });
    $("input:checkbox").on("change", function () {
        // 控制菜品份数的输入框的显示，只有当复选框勾选之后才显示
        $numberInput = $(this).parent().siblings('input');
        if ($(this).prop('checked')) {
            $numberInput.val(1);
            $numberInput.show();
        } else {
            $numberInput.hide();
        }

        // 控制上方桌号和提交按钮的显示，应至少有一个复选框勾选之后才会显示
        if ($("input[name='dish-reserve']:checked").length > 0) {
            $("#desk-box").show();
        } else {
            $("#desk-box").hide();
        }
    });


    // 控制菜品份数不得小于1
    $(".input-number").on('change', function () {
        if ($(this).val() < 1) {
            $(this).val(1);
        }
    });

    $("#btn-submit").on("click", function () {
        var deskId = $("#desk-number").val();
        var orderDetails = [];

        // 遍历复选框勾选的菜品，获取菜品id和份数
        $("input[name='dish-reserve']:checked").each(function (index, element) {
            orderDetails.push(
                {
                    DishId:$(element).data("id"),
                    DishCount: parseInt($(element).parent().siblings('input').val())
                });
        });

        var param = { deskId, orderDetails };

        $.ajax({
            type: "post",
            contentType: "application/json",
            url: "DishesShow.aspx/GetDishOrder",
            data: JSON.stringify(param),
            success: function (res) {
                var result = JSON.parse(res.d);
                console.log(result);
                app.dishOrder = result;
                app.dishOrder.OrderTime = new Date(result.OrderTime).format('yyyy-MM-dd hh:mm:ss');
                $('#myModal').modal('show');
            }
        })
    });
</script>
</asp:Content>
