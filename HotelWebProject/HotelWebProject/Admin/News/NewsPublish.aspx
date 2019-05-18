<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Web.Master" AutoEventWireup="true"
    CodeBehind="NewsPublish.aspx.cs" Inherits="HotelWebProject.Admin.NewsPublish"
    ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Admin/TxtEditor/themes/default/default.css" />
    <link rel="stylesheet" href="/Admin/TxtEditor/plugins/code/prettify.css" />
    <script type="text/javascript" charset="utf-8" src="/Admin/TxtEditor/kindeditor.js"></script>
    <script type="text/javascript" charset="utf-8" src="/Admin/TxtEditor/lang/zh_CN.js"></script>
    <script type="text/javascript" charset="utf-8" src="/Admin/TxtEditor/plugins/code/prettify.js"></script>
    <script type="text/javascript">
        KindEditor.ready(function (K) {
            var editor1 = K.create('#<%=txtContent.ClientID %>', {
                cssPath: '../TxtEditor/plugins/code/prettify.css',
                uploadJson: '../TxtEditor/upload_json.ashx',
                fileManagerJson: '../TxtEditor/file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=form1]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=form1]')[0].submit();
                    });
                }
            });
            prettyPrint();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="txtContentdiv">
          <div class="form-horizontal">
            <div class="form-group">
                <label for="txtNewsTitle" class="col-sm-2 control-label">新闻标题</label>
                <div class="col-sm-10">
                    <asp:TextBox ID="txtNewsTitle" class="form-control" PlaceHolder="请输入新闻标题" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="ddlCategory" class="col-sm-2 control-label">新闻分类</label>
                <div class="col-sm-4">
                    <asp:DropDownList ID="ddlCategory" class="form-control" runat="server">
                        <asp:ListItem Value="1">公司新闻</asp:ListItem>
                        <asp:ListItem Value="2">社会新闻</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <label for="txtContent" class="col-sm-2 control-label">新闻内容</label>
                <div class="col-sm-10">
                    <textarea id="txtContent" cols="100" rows="8" style="width: 958px; height: 300px;" runat="server"></textarea>
                </div>
            </div>

        </div>
        <div class="txtItemdiv">
            <asp:Button ID="btnPublish" CssClass="btn btn-primary" runat="server" Text="立即发布" OnClick="btnPublish_Click"/>
            <asp:Button ID="btnModify" CssClass="btn btn-primary" runat="server" Text="提交修改"  OnClick="btnPublish_Click"/>
            <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
