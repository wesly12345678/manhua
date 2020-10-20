<%@ Page Title="VIP Page" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Vip.aspx.cs" Inherits="manhua.Vip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .text-intro {
            width: 90%;
            margin: auto;
            text-align: center;
            padding-top: 30px;
        }

        .auto-style1 {
            margin-left: 0px;
        }

        .background {
            width: 100%;
            height: 400px;
            position: relative;
            z-index: 1;
        }

        .vipcontainer {
            position: absolute;
            bottom: 0;
            padding: 10px;
            right: 50px;
            background-color: rgba(128, 128, 128,0.7);
            z-index: 2;
        }

            .vipcontainer li {
                list-style-type: circle;
            }

        #title {
            position: absolute;
            z-index: 2;
        }

        .homebody {
            margin: 100px;
            border: 1px solid black;
            padding-left: 20px;
        }

        .items {
            position: relative;
            margin: 10px;
            padding: 5px;
            text-align: center;
            width: 270px;
            border: 1px solid black;
            float: left;
            height: 300px;
            overflow: hidden;
            background-color: white;
            transition: transform 0.2s;
            -moz-transition: transform 0.2s;
            z-index: 2;
        }

        .imageCss img {
            z-index: 1;
        }

        .items:hover {
            transform: scale(1.25);
            -moz-transform: scale(1.25);
            background-color: white;
            z-index: 1000;
            overflow: hidden;
        }

        .items a:hover {
            text-decoration: none;
        }

        .textDD {
            margin-left: 15px;
            text-align: left;
            z-index: 1000;
        }
        .vipp {
            border: 1px solid black;
            position: absolute;
            right: 9px;
            top: -10px;
            margin: 0;
            padding: 10px;
            font-weight: bold;
            background-color: rgba(10000,0,0,1);
            color: white;
        }
        .disable {
            cursor: default;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="manhua.DataClasses1DataContext" EntityTypeName="" TableName="Comics"></asp:LinqDataSource>
    <h1 id="title">Vip </h1>
    <div class="background">
        <img src="pic/background_image/VipBack3.jpg" width="100%" height="500px" />
        <div class="vipcontainer">
            <ul>
                <li>Get discount when purchase</li>
                <li>View Exclusive comic for Vip</li>
                <asp:Button ID="btnDone" CssClass="btn btn-danger disable" Visible="false" runat="server" Text="Purchased" />
                <asp:Button ID="btnVip" CssClass="btn btn-outline-danger" runat="server" Text="Purchase Vip" OnClick="btnVip_Click" />
            </ul>
        </div>
    </div>
    <div class="text-intro">
    </div>
    <div>
        <asp:LinqDataSource ID="ldsVip" runat="server" ContextTypeName="manhua.DataClasses1DataContext" EntityTypeName="" TableName="Comics" Where="C_IsForVip == @C_IsForVip &amp;&amp; C_CantViewable == @C_CantViewable &amp;&amp; C_Status == @C_Status">
            <WhereParameters>
                <asp:Parameter DefaultValue="true" Name="C_IsForVip" Type="Boolean" />
                <asp:Parameter DefaultValue="false" Name="C_CantViewable" Type="Boolean" />
                <asp:Parameter DefaultValue="V" Name="C_Status" Type="Char" />
            </WhereParameters>
        </asp:LinqDataSource>
        <div class="homebody">
            <h3>Vip</h3>
            <asp:ListView ID="lvVip" runat="server" DataSourceID="ldsVip">
                <EmptyDataTemplate>
                    <span>No data was returned.</span>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <div class="items">
                        <a href='DisplayComic.aspx?cId=<%# Eval("C_Id")%>'>
                            <div class="row">
                                <div class="imageCss col-sm">
                                    <asp:Label ID="lblVip" CssClass="vipp" runat="server" Text="Vip"></asp:Label>
                                    <img src='/pic/comic/<%# Eval("C_Id") %>/<%# Eval("C_Id") %>.jpg' width="150px" height="150px" />
                                </div>
                                <div class="textDD">
                                    <asp:Label ID="lbTitle" runat="server" Text='<%# Eval("C_Title") %>'></asp:Label>
                                    <p />
                                    <asp:Label ID="lblAuthor" runat="server" Text='<%# Eval("ComicCreator.CC_NickName") %>'></asp:Label>
                                    <br />
                                    <asp:Label ID="lblDesc" runat="server" Text='<%# Eval("C_Description") %>'></asp:Label>
                                </div>
                            </div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
