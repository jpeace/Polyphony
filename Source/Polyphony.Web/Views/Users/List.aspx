<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Polyphony.Web.Views.Users.List" %>
<%@ Import Namespace="Polyphony.Web.Models.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Users | Polphony
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <ol>
        <% foreach (var user in Model.Users) {%>
            <li><%= this.DisplayFor(user, u => u.FirstName) %></li>
        <% }%>
    </ol>
</asp:Content>