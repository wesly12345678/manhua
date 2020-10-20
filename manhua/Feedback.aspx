<%@ Page Title="Feedback Page" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="manhua.Feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
     <h1>Feedback</h1>
    Enter you Email:
    <br />
    <asp:TextBox ID="txtb1" runat="server"></asp:TextBox>
    <br />
    Enter you password:<br />
    <asp:TextBox ID="txtb3" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <br />
    Enter what you want to say:
    
    <br />
    
    <asp:TextBox ID="txtb2" runat="server" Height="186px" Width="286px"></asp:TextBox>
    <asp:Button ID="btn1" runat="server" Text="Send" OnClick="btn1_Click" />
</asp:Content>
