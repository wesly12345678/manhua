<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="manhua.search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:SqlDataSource ID="sdsSearch" runat="server" ConnectionString="<%$ ConnectionStrings:Database1ConnectionString %>" SelectCommand="SELECT * FROM [ComicInfo] WHERE (([C_CantViewable] = @C_CantViewable) AND ([CC_NickName] LIKE '%' + @CC_NickName + '%') OR ([Ca_Name] LIKE '%' + @Ca_Name + '%') OR ([C_Title] LIKE '%' + @C_Title + '%') AND ([C_Status] = @C_Status))">
        <SelectParameters>
            <asp:Parameter DefaultValue="false" Name="C_CantViewable" Type="Boolean" />
            <asp:QueryStringParameter Name="CC_NickName" QueryStringField="search" Type="String" />
            <asp:QueryStringParameter Name="Ca_Name" QueryStringField="search" Type="String" />
            <asp:QueryStringParameter Name="C_Title" QueryStringField="search" Type="String" />
            <asp:Parameter DefaultValue="V" Name="C_Status" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <h2 id="h22">Search result</h2>
    <div class="inContent">
        <asp:ListView ID="lvSearch" runat="server" DataKeyNames="C_Id" DataSourceID="sdsSearch">
            <EmptyDataTemplate>
                No data was returned.
            </EmptyDataTemplate>
            <ItemTemplate>
                <div class="items">
                    <a href="/DisplayComic.aspx?cId=<%# Eval("C_Id") %>">
                        <img src='/pic/comic/<%# Eval("C_Id") %>/<%# Eval("C_Id") %>.jpg' width="200px" height="300px" class="images" />
                        <div class="text">
                            <asp:Label ID="C_TitleLabel" CssClass="bold" runat="server" Text='<%# Eval("C_Title") %>' />
                            <br />
                        <a href='/Profile.aspx?creator_id=<%# Eval("CC_Id") %>'>
                            <asp:Label ID="CC_NickNameLabel" runat="server" Text='<%# Eval("CC_NickName") %>' />
                            </a>
                            <br />
                            <asp:Label ID="Ca_NameLabel" runat="server" Text='<%# Eval("Ca_Name") %>' />
                            <br />
                            <asp:Label ID="C_DescriptionLabel" runat="server" Text='<%# Eval("C_Description") %>' />
                    </a>
                    </div>
                </div>
            </ItemTemplate>

        </asp:ListView>
    </div>
    <style>
        #h22 {
            padding: 10px;
        }
        .items {
            border: 1px solid black;
            display: flex;
            flex-direction: row;
            height: 300px;
            overflow: hidden;
        }.items:hover {
             background-color: lightgray;
             text-decoration: none;
         }
        .inContent {
            margin: 30px;
        }

        .text {
            padding: 10px;
            font-size: 20pt;
        }

        .bold {
            font-weight: bold
        }
    </style>
</asp:Content>
