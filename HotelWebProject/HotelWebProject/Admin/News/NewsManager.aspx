<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Web.Master" AutoEventWireup="true"
    CodeBehind="NewsManager.aspx.cs" Inherits="HotelWebProject.Admin.NewsManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/AdminCss.css" rel="stylesheet" type="text/css" />
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
    <div class="panel panel-default" style="width:80%;">
        <div class="panel-heading">
            新闻列表
        </div>
        <div class="panel-body">
                <div class="table-responsive">
                    <table class="table table-striped table-bordered table-hover" id="orderdataTables">
                        <thead>
                        <tr>
                            <th>序号</th>
                            <th>新闻标题</th>
                            <th>新闻分类</th>
                            <th>发布时间</th>
                            <th>操作</th>
                        </tr>
                        </thead>
                        <tbody id="user-table">
                        <asp:Repeater ID="rptList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td> <%#Container.ItemIndex + 1 %></td>
                                    <td> <a class="text-primary" href='/Pages/NewsDetail.aspx?newsId= <%#Eval("NewsId")%>'target="_blank"> <%#Eval("NewsTitle")%></a></td>
                                    <td> <%#Eval("CategoryName")%> </td>
                                    <td> <%#Eval("PublishTime","{0:yyyy-MM-dd}") %></td>
                                    <td> 
                                        <a class="text-primary" href='NewsPublish.aspx?Operation=1&newsId=<%#Eval("NewsId")%>'>修改</a>
                                        <asp:LinkButton CssClass="text-danger" ID="lbtnDel" OnClientClick="return confirm('确认删除吗?')" OnClick="btn_Click" CommandArgument='<%#Eval("NewsId")%>' runat="server">删除</asp:LinkButton>
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

