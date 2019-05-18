<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="RoomShow.aspx.cs" Inherits="HotelWebProject.Pages.Environment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   <link href="../Styles/Dishes.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/awesome-bootstrap-checkbox.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" Runat="Server">
 <div class="cakes_grids" style="margin-top:3rem;">
    <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate>
            <div class="col-md-4">
		        <div class="cakes_grid1" style="background:rgba(255,255,255,0.9);box-shadow:0 0 5px #ddd;">
			        <img src="<%#Eval("CategoryId","../Images/room/{0}.jpg") %>" alt="Recommanded Dishes" style="height:200px;">
			        <h3><%#Eval("CategoryName") %></h3>
			        <p>￥<%#Eval("UnitPrice")%>/天</p>
                    <div class="checkbox checkbox-info" style="position:absolute; right:1rem;bottom:1.7rem;">
                        <input type="checkbox" name="room-reserve" data-id='<%#Eval("CategoryId")%>'>
                        <label for="checkbox1"></label>
                    </div>
		        </div>
	        </div>
        </ItemTemplate>
    </asp:Repeater>
    <a id="btn-submit" class="btn btn-primary" style="display:none;">立即预约</a>
    <div class="clearfix"></div>
</div>
<script type="text/javascript">
    $("input:checkbox").on("change", function () {
        var objName = $(this).attr("name");
        var status = $(this).prop("checked");
        $("input[name='" + objName + "']").prop("checked", false);
        $(this).prop("checked", status);
        if ($("input[name='" + objName + "']:checked").length > 0) {
            $("#btn-submit").show();
        } else {
            $("#btn-submit").hide();
        }
    });
    $("#btn-submit").on("click", function () {
        var id = $("input[name='room-reserve']:checked").data("id");
        location.href = "./Book.aspx?ordertype=2&roomtype=" + id;
    });
</script>
</asp:Content>


