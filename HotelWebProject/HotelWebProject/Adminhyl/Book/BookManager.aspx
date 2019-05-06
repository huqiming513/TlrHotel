<%@ Page Title="" Language="C#" MasterPageFile="~/Adminhyl/Adminhyl.Master" AutoEventWireup="true"
    CodeBehind="BookManager.aspx.cs" Inherits="HotelWebProject.Adminhyl.BookManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Styles/dataTables.bootstrap.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery.dataTables.js"></script>
    <script type="text/javascript" src="../../Scripts/dataTables.bootstrap.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#orderdataTables').dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
       <div class="panel panel-default">
            <div class="panel-heading">
                预约列表
            </div>
            <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-striped table-bordered table-hover" id="orderdataTables">
                            <thead>
                            <tr>
                                <th>酒店名称</th>
                                <th>下单时间</th>
                                <th>预约时间</th>
                                <th>预约人数</th>
                                <th>包间类型</th>   
                                <th>客户姓名</th>
                                <th>联系电话</th>
                                <th>预定状态</th>
                                <th>备注</th>
                                <th>操作</th>
                            </tr>
                            </thead>
                            <tbody id="user-table">
                            <asp:Repeater ID="rptList" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td> <%#Eval("HotelName") %></td>
                                        <td> <%#Eval("BookTime","{0:yyyy-MM-dd hh:mm}") %></td>
                                        <td> <%#Eval("ConsumeTime","{0:yyyy-MM-dd hh:mm}") %> </td>
                                        <td> <%#Eval("ConsumePersons") %></td>
                                        <td> <%#Eval("RoomType") %></td>
                                        <td> <%#Eval("CustomerName") %></td>
                                        <td> <%#Eval("CustomerPhone") %></td>
                                        <td> <%#Convert.ToInt32(Eval("OrderStatus"))==0?"未处理":"不通过"%></td>
                                        <td> <%#Eval("Comments") %></td>
                                        <td> 
                                            <asp:LinkButton CssClass="text-success" ID="lbtnPass" CommandArgument='<%#Eval("BookId")%>' CommandName="1" runat="server" OnClick="lbtnOperation">通过</asp:LinkButton>
                                            <asp:LinkButton CssClass="text-warning" ID="lbtnCancel" CommandArgument='<%#Eval("BookId")%>' CommandName="-1" runat="server" OnClick="lbtnOperation">撤销</asp:LinkButton>
                                            <asp:LinkButton CssClass="text-danger" ID="lbtnClose" CommandArgument='<%#Eval("BookId")%>' CommandName="2" runat="server" OnClick="lbtnOperation">关闭</asp:LinkButton>
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
</asp:Content>
