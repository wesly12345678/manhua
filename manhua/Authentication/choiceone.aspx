<%@ Page Title="Type Of Accout" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="choiceone.aspx.cs" Inherits="manhua.Authentication.choiceone" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
       .text{
           text-align:center;
       }
        .haha {
            border-right: solid 5px black;
        }
        .hahe {
            display: flex;
            flex-direction: row;
            justify-content: center;
            align-items: center;    
            flex: 1 1 auto;
            /*border:1px solid black;*/
            margin: 0;
            padding: 0;
          
        }
      .itemss{
          border:1px solid black;
          padding:10px;
      }
      .itemss:hover{
           color: white !important;
            background: black;
            border-color: Blue ;
            transition: all 0.4s ease 0s;
      }
      h1{
          text-align:center;
          
      }
      .tt{
          padding:20px;
      }
    
        
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="tt"><h1>Type of Account </h1> </div>
    <div class="hahe">
        <div class="itemss">
            <a href="/Authentication/registerComic.aspx">
        <img src="/pic/background_image/20170523123304.jpeg" class="image" style="cursor: pointer" onclick="window.location='/Authentication/registerComic.aspx'" width="300px" height="300px"/>
            </a>
            <div class=" text"><label>Comic Creator</label></div>
        </div>
    <div class="ii"></div>
    <div class="itemss">
        <img src="/pic/background_image/male.jpg" class="image" style="cursor: pointer" onclick="window.location='/Authentication/Register.aspx'" width="300px" height="300px"/>
        <div class="text">
        <label>Reader</label></div>
        </div>
   </div>
</asp:Content>
