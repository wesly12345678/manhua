<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="manhua.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <style>
        #error{

           text-align:center;
           margin:100px auto;
        }
    </style>
    <h1 id="error">
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label></h1>
    <script>
        var timer = setTimeout(function() {
            window.location='/home.aspx'
        }, 5000);
    </script>
</asp:Content>
