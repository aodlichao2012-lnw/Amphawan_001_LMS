<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Label1" Text="<%$Resources:Resource, Greetings %>" runat="server" Font-Bold="true" />
    <br />
    <br />
    <span><%=Resources.Resource.Introduction %></span>
</asp:Content>
