<%@ Page Title="Register Sucess" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="RegisterSucess.aspx.cs" Inherits="manhua.RegisterSucess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
     <h1>Congratulations!</h1>
    <p>Thx for register You will go to login page after 5 second</p>
   
    <script>
        var timer = setTimeout(function() {
            window.location='/authentication/login.aspx'
        }, 5000);
    </script>
</asp:Content>
