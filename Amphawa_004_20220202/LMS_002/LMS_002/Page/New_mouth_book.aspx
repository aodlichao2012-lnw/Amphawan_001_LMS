<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="New_mouth_book.aspx.cs" Inherits="LMS_002.Page.New_mouth_book" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row" oncontextmenu="return false;">
        <div class="card">
            <div class=" card-header"><%= LMS_002.Resource.Resource.news_mouth %></div>
            <div class="card-body">
                <asp:Label runat="server" ID="detail"></asp:Label>

            </div>
            <div class=" card-footer">
            </div>
        </div>
    </div>
</asp:Content>
