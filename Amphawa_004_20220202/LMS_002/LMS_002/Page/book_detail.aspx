<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="book_detail.aspx.cs" Inherits="LMS_002.Page.book_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" oncontextmenu="return false;">
        <div class="card">
            <div class=" card-header"><%= LMS_002.Resource.Resource.detail_book %></div>
            <div class="card-body">
                <asp:Label runat="server" ID="detail"></asp:Label>

            </div>
            <div class=" card-footer">
                <a class="btn btn-success btn-lg " runat="server" onserverclick="sendto_lend_ServerClick" id="sendto_lend" data-id="1" href="#"><i class="fa fa-filter "></i>ย้อนกลับ </a>
            </div>
        </div>
    </div>

</asp:Content>
