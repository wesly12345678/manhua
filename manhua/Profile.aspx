<%@ Page Title="Profile" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="manhua.comicCreator.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="header">
        <asp:Image ID="imgProfile" CssClass="imga" runat="server" />
        <div id="text">
            Nickname:
        <asp:Label ID="lbName" runat="server" CssClass="bold" Text=""></asp:Label>
            <br />
            Email:
        <asp:Label ID="lbEmail" runat="server" CssClass="bold" Text=""></asp:Label>
            <br />
            Number of Uploaded Comic:
        <asp:Label ID="lbQuantity" runat="server" CssClass="bold" Text=""></asp:Label>
            <br />
            Phone Number:
        <asp:Label ID="lbphone" runat="server" CssClass="bold" Text=""></asp:Label>
        </div>
        <asp:Button ID="bntEdit" Visible="false" CssClass="flexnone btn btn-warning" runat="server" Text="Edit" OnClick="bntEdit_Click" />
    </div>
    <div class="middlSection">

        <asp:LinqDataSource ID="ldsComic" runat="server" ContextTypeName="manhua.DataClasses1DataContext" EntityTypeName="" TableName="Comics" Where="CC_Id == @CC_Id &amp;&amp; C_Status == @C_Status &amp;&amp; C_CantViewable == @C_CantViewable">
            <WhereParameters>
                <asp:QueryStringParameter Name="CC_Id" QueryStringField="creator_id" Type="Int32" />
                <asp:Parameter DefaultValue="V" Name="C_Status" Type="Char" />
                <asp:Parameter DefaultValue="false" Name="C_CantViewable" Type="Boolean" />
            </WhereParameters>
        </asp:LinqDataSource>
        <asp:LinqDataSource ID="ldsUnverify" runat="server" ContextTypeName="manhua.DataClasses1DataContext" EntityTypeName="" TableName="Comics" Where="CC_Id == @CC_Id &amp;&amp; C_Status == @C_Status &amp;&amp; C_CantViewable == @C_CantViewable">
            <WhereParameters>
                <asp:QueryStringParameter Name="CC_Id" QueryStringField="creator_id" Type="Int32" />
                <asp:Parameter DefaultValue="U" Name="C_Status" Type="Char" />
                <asp:Parameter DefaultValue="false" Name="C_CantViewable" Type="Boolean" />
            </WhereParameters>
        </asp:LinqDataSource>

        <div class="haha">
            <h1 class="nav-tabs">
                <asp:Label ID="lblUnverify" Visible="false" CssClass="" runat="server" Text="Unverify"></asp:Label></h1>
            <asp:ListView ID="lvUnverify" Visible="False" runat="server" DataSourceID="ldsUnverify">
                <EmptyDataTemplate>
                    <h1>Coming Soon....</h1>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <div class="conts">
                        <a class="aa" href="/DisplayComic.aspx?cId=<%# Eval("C_Id") %>">
                            <img src='/pic/comic/<%# Eval("C_Id") %>/<%# Eval("C_Id") %>.jpg' width="300px" height="300px" style="border: solid" />
                            <div class="textT">
                                <%# Eval("C_Title") %>
                            </div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
    <div class="bottomSection">
        <div class="haha">
            <h1 class="nav-tabs">Comic</h1>
            <asp:ListView ID="lvComic" runat="server" DataSourceID="ldsComic">
                <EmptyDataTemplate>
                    <h1>Coming Soon....</h1>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <div class="cont">
                        <a class="aa" href="/DisplayComic.aspx?cId=<%# Eval("C_Id") %>">
                            <img src='/pic/comic/<%# Eval("C_Id") %>/<%# Eval("C_Id") %>.jpg' width="300px" height="300px" style="border: solid" />
                            <div class="textT">
                                <%# Eval("C_Title") %>
                            </div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>

    <style>
        .bold {
            font-weight: bolder;
        }
        .header {
            display: flex;
            flex-direction: row;
            padding: 10px;
            padding-left: 100px;
            margin-left: 100px;
            margin-right: 100px;
            border: 1px solid darkmagenta;
            border-bottom-left-radius: 100px;
            border-bottom-right-radius: 100px;
            height: 130px;
            color: white;
            background-color: darkmagenta
        }

        .haha {
            margin: 10px;
            display: block;
            margin-left: 150px;
            flex-direction: row;
        }

        .cont, .conts {
            background-color: rgba(0,0,0,0.9);
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

        .hh {
            margin: 5px;
            border: 2px solid grey;
            color: white;
            padding: 10px;
            background-color: rgba(0, 0, 0, 0.6);
            border-radius: 70%;
        }
        .imga {
            width: 100px;
            height: 100px;
            margin-right: 50px;
        }
        .flexnone {
            margin-left: 50px;
            flex: 0 0 auto;
            height: 50px;
            width: 100px;
        }
    </style>
</asp:Content>
