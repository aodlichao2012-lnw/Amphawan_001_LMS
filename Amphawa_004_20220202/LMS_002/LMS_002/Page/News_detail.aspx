<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="News_detail.aspx.cs" Inherits="LMS_002.Page.News_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="card">
            <div class=" card-header"></div>
            <div class="card-body">
                <asp:Label runat="server" ID="detail"  Font-Size="Medium" CssClass=" w-75"></asp:Label>
              
            </div>
            <div class=" card-footer">
                        <a class="btn btn-success btn-lg " runat="server" onserverclick="sendto_lend_ServerClick" id="sendto_lend" data-id="1" href="#"><i class="fa fa-filter "></i>ย้อนกลับ </a>
            </div>
          </div>
</asp:Content>
