<%@ Page Title="Payment Sucess" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="PaymentSuccess.aspx.cs" Inherits="manhua.Payment.PaymentSuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <h1>
        Payment Success
    </h1>
    <p/>
    Page will redirect to display comic in 5 seconds...
    <asp:HiddenField ID="hfId" runat="server" />
    <script>
        var cId = $("#main_hfId").val();
        if (cId == null || cId == 0) {
            var timer = setTimeout(function() {
                window.location = '/Vip.aspx';
            }, 5000);
        } else {
            var timer = setTimeout(function() {
                window.location = '/DisplayComic.aspx?cId=' + cId;
            }, 5000);
        }
        
    </script>
</asp:Content>
