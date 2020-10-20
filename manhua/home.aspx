<%@ Page Title="Home" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="manhua.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="engine1/style.css" />
    <link rel="stylesheet" type="text/css" href="css/home.css" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:LinqDataSource ID="ldsSlideshow" runat="server" ContextTypeName="manhua.DataClasses1DataContext" EntityTypeName="" TableName="slideshows">
    </asp:LinqDataSource>

    <asp:LinqDataSource ID="ldsPopularComic" runat="server" ContextTypeName="manhua.DataClasses1DataContext" EntityTypeName="" TableName="Comics" OrderBy="C_Price" Where="C_CantViewable == @C_CantViewable &amp;&amp; C_Status == @C_Status &amp;&amp; C_Price &gt;= @C_Price" OnSelecting="ldsPopularComic_Selecting">
        <WhereParameters>
            <asp:Parameter DefaultValue="false" Name="C_CantViewable" Type="Boolean" />
            <asp:Parameter DefaultValue="V" Name="C_Status" Type="Char" />
            <asp:Parameter DefaultValue="0.00" Name="C_Price" Type="Decimal" />
        </WhereParameters>
    </asp:LinqDataSource>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="manhua.DataClasses1DataContext" EntityTypeName="" TableName="Comics" OrderBy="C_Id" Where="C_Price == @C_Price &amp;&amp; C_CantViewable == @C_CantViewable &amp;&amp; C_Status == @C_Status" OnSelecting="LinqDataSource1_Selecting">
        <WhereParameters>
            <asp:Parameter DefaultValue="14.00" Name="C_Price" Type="Decimal" />
            <asp:Parameter DefaultValue="false" Name="C_CantViewable" Type="Boolean" />
            <asp:Parameter DefaultValue="V" Name="C_Status" Type="Char" />
        </WhereParameters>
    </asp:LinqDataSource>
    <asp:LinqDataSource ID="ldsComic" runat="server" ContextTypeName="manhua.DataClasses1DataContext" EntityTypeName="" TableName="Comics" OrderBy="C_Id desc" Where="C_CantViewable == @C_CantViewable &amp;&amp; C_IsForVip == @C_IsForVip &amp;&amp; C_Status == @C_Status">
        <WhereParameters>
            <asp:Parameter DefaultValue="false" Name="C_CantViewable" Type="Boolean" />
            <asp:Parameter DefaultValue="false" Name="C_IsForVip" Type="Boolean" />
            <asp:Parameter DefaultValue="V" Name="C_Status" Type="Char" />
        </WhereParameters>
    </asp:LinqDataSource>
    <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="manhua.DataClasses1DataContext" EntityTypeName="" OnSelecting="LinqDataSource2_Selecting" OrderBy="C_Publish_Date desc" TableName="Comics" Where="C_CantViewable == @C_CantViewable &amp;&amp; C_Status == @C_Status">
        <WhereParameters>
            <asp:Parameter DefaultValue="false" Name="C_CantViewable" Type="Boolean" />
            <asp:Parameter DefaultValue="V" Name="C_Status" Type="Char" />
        </WhereParameters>
    </asp:LinqDataSource>

    <div id="wowslider-container1">
        <div class="ws_images">
            <ul>
                <asp:ListView ID="lvSlideshow" runat="server" DataSourceID="ldsSlideshow">
                    <ItemTemplate>
                        <li>
                            <a href="<%# Eval("S_Link") %>" title='<%#Eval("S_Title") %>'>
                                <img src='pic/slideshow/<%# Eval("S_Id") %>.jpg' alt='<%#Eval("S_Title") %>' title='<%#Eval("S_Title") %>' id='<%#Eval("S_Id") %>' />
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:ListView>
            </ul>
        </div>
        <div class="ws_bullets">
            <div>
                <asp:ListView ID="ListView1" runat="server" DataSourceID="ldsSlideshow">
                    <ItemTemplate>
                        <asp:HiddenField ID="hfNumber" runat="server" />
                        <a href="<%# Eval("S_Link") %>" title='<%#Eval("S_Title") %>'><span>
                            <img id="imgUL" src="pic/slideshow/<%# Eval("S_Id") %>.jpg" alt="<%# Eval("S_Title") %>" /></span></a>
                    </ItemTemplate>
                </asp:ListView>

            </div>

            <div class="ws_script" style="position: absolute; left: -99%"><a href="http://wowslider.net">javascript carousel</a> by WOWSlider.com v8.8</div>
            <div class="ws_shadow"></div>
        </div>
    </div>
    <div class="all row">
        <div class="bar col-sm">
            <h3>Overall Rank</h3>
            <asp:ListView ID="lvPopular" runat="server" DataSourceID="ldsPopularComic">
                <EmptyDataTemplate>
                    <span>No data was returned.</span>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <asp:HiddenField ID="hfNumber" runat="server" />
                    <div class="leftbaritem">
                        <a href='DisplayComic.aspx?cId=<%# Eval("C_Id")%>'>
                            <div class="row">
                                <div class="col-sm">
                                    <img src='/pic/comic/<%# Eval("C_Id") %>/<%# Eval("C_Id") %>.jpg' width="150px" height="150px" />
                                </div>
                                <div class="textTD col-sm">
                                    <asp:Label ID="lbTitle" runat="server" Text='<%# Eval("C_Title") %>'></asp:Label>
                                    <p />
                                    <asp:Label ID="lblAuthor" runat="server" Text='<%# Eval("ComicCreator.CC_NickName") %>'></asp:Label>
                                </div>
                            </div>
                        </a>

                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="bar col-sm">
            <h3>Most Favourite</h3>
            <asp:ListView ID="ListView2" runat="server" DataSourceID="LinqDataSource1">
                <EmptyDataTemplate>
                    <span>No data was returned.</span>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <div class="leftbaritem">
                        <a href='DisplayComic.aspx?cId=<%# Eval("C_Id")%>'>
                            <div class="row">
                                <div class="col-sm">
                                    <img src='/pic/comic/<%# Eval("C_Id") %>/<%# Eval("C_Id") %>.jpg' width="150px" height="150px" />
                                </div>
                                <div class="textTD col-sm">
                                    <asp:Label ID="lbTitle" runat="server" Text='<%# Eval("C_Title") %>'></asp:Label>
                                    <p />
                                    <asp:Label ID="lblAuthor" runat="server" Text='<%# Eval("ComicCreator.CC_NickName") %>'></asp:Label>
                                </div>
                            </div>
                        </a>

                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="bar col-sm">
            <h3>Comic</h3>
            <asp:ListView ID="ListView3" runat="server" DataSourceID="LinqDataSource2">
                <EmptyDataTemplate>
                    <span>No data was returned.</span>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <div class="leftbaritem">
                        <%--<div class="num">
                        <asp:Label ID="lblNumber" runat="server" Text=""></asp:Label>
                    </div>--%>
                        <a href='DisplayComic.aspx?cId=<%# Eval("C_Id")%>'>
                            <div class="row">
                                <div class="col-sm">
                                    <img src='/pic/comic/<%# Eval("C_Id") %>/<%# Eval("C_Id") %>.jpg' width="150px" height="150px" />
                                </div>
                                <div class="textTD col-sm">
                                    <asp:Label ID="lbTitle" runat="server" Text='<%# Eval("C_Title") %>'></asp:Label>
                                    <p />
                                    <asp:Label ID="lblAuthor" runat="server" Text='<%# Eval("ComicCreator.CC_NickName") %>'></asp:Label>
                                </div>
                            </div>
                        </a>

                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
    <div class="homebody">
        <h3>Comic</h3>
        <asp:ListView ID="ListView4" runat="server" DataSourceID="ldsComic">
            <EmptyDataTemplate>
                <span>No data was returned.</span>
            </EmptyDataTemplate>
            <ItemTemplate>
                <div class="items">
                    <a href='DisplayComic.aspx?cId=<%# Eval("C_Id")%>'>
                        <div class="row">
                            <div class="imageCss imgg col-sm">
                                <img src='/pic/comic/<%# Eval("C_Id") %>/<%# Eval("C_Id") %>.jpg' width="150px" height="150px" />
                            </div>
                            <div class="textDD">
                                <asp:Label ID="lbTitle" runat="server" Text='<%# Eval("C_Title") %>'></asp:Label>
                                <p />
                                <a href='/Profile.aspx?creator_id=<%# Eval("CC_Id") %>'>
                                <asp:Label ID="lblAuthor" runat="server" Text='<%# Eval("ComicCreator.CC_NickName") %>'></asp:Label>
                                </a>
                                <br />
                                <asp:Label ID="lblDesc" runat="server" Text='<%# Eval("C_Description") %>'></asp:Label>
                            </div>
                        </div>
                    </a>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
    
    <script type="text/javascript" src="engine1/wowslider.js"></script>
    <script type="text/javascript" src="engine1/script.js"></script>
    <style>
        
    </style>
</asp:Content>

