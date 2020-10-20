<%@ Page Title="Favourite" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="FavouriteList.aspx.cs" Inherits="manhua.FavouriteList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:LinqDataSource ID="ldsFavourite" runat="server" ContextTypeName="manhua.DataClasses1DataContext" EntityTypeName="" TableName="Favourites"></asp:LinqDataSource>
    <h1>Favourite List</h1>
    <div class="ff">
        <asp:ListView ID="lvFavourite" runat="server" DataKeyNames="R_Id,C_Id" DataSourceID="ldsFavourite">
            <EmptyDataTemplate>
                Your Favourite Comic is empty
            </EmptyDataTemplate>
            <ItemTemplate>
                <div class="cont">
                    <a class="aa" href="/DisplayComic.aspx?cId=<%# Eval("C_Id") %>">
                        <img src='/pic/comic/<%# Eval("C_Id") %>/<%# Eval("C_Id") %>.jpg' width="300px" height="300px" style="border: solid" />
                        <div class="textT">
                            <%# Eval("Comic.C_Title") %>
                        </div>
                    </a>
                </div>
            </ItemTemplate>

        </asp:ListView>
    </div>
    <style>
        .cont {
            background-color: black;
            margin: 20px;
            width: 300px;
            float: left;
            height: 350px;
            transition: transform .2s;
        }

            .cont:hover {
                transform: scale(1.2);
            }

        .textT {
            text-align: center;
            color: white;
        }

        h1 {
            padding-top: 10px;
            text-align: center;
        }
        .ff {

        }
    </style>
</asp:Content>
