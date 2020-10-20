<%@ Page Title="View Episode" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="ViewEpisode.aspx.cs" Inherits="manhua.comicCreator.ViewEpisode" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .picCenter{
            margin-left: 0px auto;
            padding-left:120px;
        }
        .haha{
            text-align:center
        }
         .button {
            color: #494949 !important;
            text-transform: uppercase;
            background: #ffffff;
            padding: 10px;
            border: 4px solid #494949 !important;
            border-radius: 6px;
            display: inline-block;
        }

        .button:hover {
            cursor: pointer;
            color: white !important;
            background: #4cff00;
            border-color: #4cff00 !important;
            transition: all 0.4s ease 0s;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
<asp:HiddenField ID="hfEpisode" runat="server" />
<asp:HiddenField ID="hfPageNum" runat="server" />
    <asp:HiddenField ID="hfComicId" runat="server" />

    <h1>Episode:<%= hfEpisode.Value %></h1>
     <div class="haha">
        <asp:Button ID="Button1" runat="server" Text="Back" CssClass="button" OnClick="Button1_Click"/><asp:Button ID="Button2" runat="server" Text="Episode List" CssClass="button" OnClick="Button2_Click" /><asp:Button ID="Button3" runat="server" Text="Next" CssClass="button" OnClick="Button3_Click"/>

     </div>
    <div class="picCenter">
    <% string temp = hfPageNum.Value;
        int pageNum = int.Parse(temp);
        for (int i = 1; i <= pageNum; i++)
        {%>
    <img src='/pic/comic/<%= hfComicId.Value %>/<%= hfEpisode.Value %>/<%= i %>.jpg' width="90%"/>

    <%
        }%>
        </div>
     <div class="haha">
        <asp:Button ID="Button4" runat="server" Text="Back" CssClass="button" OnClick="Button4_Click"/><asp:Button ID="Button5" runat="server" Text="Episode List" CssClass="button" OnClick="Button5_Click"/><asp:Button ID="Button6" runat="server" Text="Next" CssClass="button" OnClick="Button6_Click"/>

     </div>
    </asp:Content>
