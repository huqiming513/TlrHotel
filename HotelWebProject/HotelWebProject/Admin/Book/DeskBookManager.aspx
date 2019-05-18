<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Web.Master" AutoEventWireup="true"
    CodeBehind="DeskBookManager.aspx.cs" Inherits="HotelWebProject.Admin.DeskBookManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../../Scripts/dataTables/dataTables.bootstrap.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-3.2.1.min.js"></script>
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
                订桌列表
            </div>
            <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-striped table-bordered table-hover" id="orderdataTables">
                            <thead>
                            <tr>
                                <th>序号</th>
                                <th>预约时间</th>
                                <th>预约人数</th>
                                <th>包间类型</th>   
                                <th>客户姓名</th>
                                <th>联系电话</th>
                                <th>下单时间</th>
                                <th>预定状态</th>
                                <th>备注</th>
                                <th>操作</th>
                            </tr>
                            </thead>
                            <tbody id="user-table">
                            <asp:Repeater ID="rptList" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td> <%#Container.ItemIndex + 1 %> </td>
                                        <td> <%#Eval("ConsumeTime","{0:yyyy-MM-dd hh:mm}") %> </td>
                                        <td> <%#Eval("ConsumePersons") %></td>
                                        <td> <%#Eval("DeskType") %></td>
                                        <td> <%#Eval("CustomerName") %></td>
                                        <td> <%#Eval("CustomerPhone") %></td>
                                        <td> <%#Eval("OrderTime","{0:yyyy-MM-dd hh:mm}") %></td>
                                        <td class="text-warning" v-if="<%#Convert.ToInt32(Eval("OrderStatus"))%> == 0"> 未处理</td>
                                        <td class="text-success" v-else-if="<%#Convert.ToInt32(Eval("OrderStatus"))%> == 1"> 通过</td>
                                        <td class="text-danger" v-else-if="<%#Convert.ToInt32(Eval("OrderStatus"))%> == -1"> 未通过</td>
                                        <td> <%#Eval("Comments") %></td>
                                        <td> 
                                            <asp:LinkButton CssClass="text-success" ID="lbtnPass" CommandArgument='<%#Eval("OrderId")%>' CommandName="1" runat="server" OnClick="lbtnOperation">通过</asp:LinkButton>
                                            <asp:LinkButton CssClass="text-warning" ID="lbtnCancel" CommandArgument='<%#Eval("OrderId")%>' CommandName="-1" runat="server" OnClick="lbtnOperation">撤销</asp:LinkButton>
                                            <asp:LinkButton CssClass="text-danger" ID="lbtnClose" CommandArgument='<%#Eval("OrderId")%>' CommandName="2" runat="server" OnClick="lbtnOperation">关闭</asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
            </div>
        </div>

    <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
    <script type="text/javascript">
        var app = new Vue({
            el: '#app',
            data: {
                
            }
        });
    </script>
</asp:Content>
