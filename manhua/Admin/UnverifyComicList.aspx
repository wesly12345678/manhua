<%@ Page Title="Verify Comic" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="UnverifyComicList.aspx.cs" Inherits="manhua.Admin.VerifyComic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        
        .bold {
            font-weight: bolder;
        }


        .haha {
            margin: 10px;
            display: block;
            margin-left: 150px;
            flex-direction: row;
        }

        .cont {
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
        .btnPadding {
            margin-left: 15%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:LinqDataSource ID="ldsUnverifyComic" runat="server" ContextTypeName="manhua.DataClasses1DataContext" EntityTypeName="" TableName="Comics" Where="C_CantViewable == @C_CantViewable &amp;&amp; C_Status == @C_Status">
        <WhereParameters>
            <asp:Parameter DefaultValue="false" Name="C_CantViewable" Type="Boolean" />
            <asp:Parameter DefaultValue="U" Name="C_Status" Type="Char" />
        </WhereParameters>
    </asp:LinqDataSource>
    <h1>Unverify Comic List</h1>
    <div class="haha">
        <asp:ListView ID="lvUnverify" runat="server" DataSourceID="ldsUnverifyComic">
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
    <div>
        <asp:Button ID="Button1" runat="server" Text="Back" cssClass="btn btn-primary btnPadding" OnClick="Button1_Click"/></div>
   
</asp:Content>
