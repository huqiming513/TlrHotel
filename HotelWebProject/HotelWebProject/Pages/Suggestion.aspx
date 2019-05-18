<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true"
    CodeBehind="Suggestion.aspx.cs" Inherits="HotelWebProject.Pages.Suggestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Dishes.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server"> 
<div style="margin:3rem 3rem 0 3rem;padding:3rem; background:rgba(255,255,255,0.5);border-radius:0.5rem; box-shadow:0 0 5px #eee;">
    <div class="form-horizontal">
    <div class="form-group">
        <label for="txtConsumeTime" class="col-md-offset-3 col-md-2 control-label">客户姓名：</label>
        <div class="col-md-4">
            <asp:TextBox ID="txtCustomerName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label for="txtPersons" class="col-md-offset-3 col-md-2 control-label">您的消费情况：</label>
        <div class="col-md-4">
            <asp:TextBox ID="txtConsumeDesc" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label for="txtPersons" class="col-md-offset-3 col-md-2 control-label">联系电话：</label>
        <div class="col-md-4">
            <asp:TextBox ID="txtPhoneNumber" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label for="txtPersons" class="col-md-offset-3 col-md-2 control-label">电子邮件：</label>
        <div class="col-md-4">
            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label for="txtPersons" class="col-md-offset-3 col-md-2 control-label">投诉建议：</label>
        <div class="col-md-4">
            <asp:TextBox ID="txtSuggestion" CssClass="form-control" runat="server" Height="100px" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>
        <div class="form-group">
        <label for="txtComment" class="col-md-offset-3 col-md-2 control-label">验证码：</label>
        <div class="col-md-4">
                <asp:TextBox class="form-control col-md-6" ID="txtValidateCode"  runat="server" Style="width:40%;"  PlaceHolder="输入验证码" ></asp:TextBox>
                <asp:Image class="col-md-6" ID="Image1" ImageUrl="~/Handlers/ValidateCode.ashx" runat="server" Style="height:34px;"/>
        </div>
    </div>
    <div class="form-group" style="margin-top:40px;">
        <asp:Button ID="btnSubmit" CssClass="btn btn-default" runat="server" Text="提交投诉"/>
        <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
    </div>
</div>
</div>

</asp:Content>
