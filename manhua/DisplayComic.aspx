<%@ Page Title="Display Comic" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="DisplayComic.aspx.cs" Inherits="manhua.DisplayComic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/DisplayComic.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div id="background">
        <h1>Comic Info</h1>
    </div>
    <div class="bodyy">
        <div class="topcontect">
            <img src='/pic/comic/<%= hfId.Value %>/<%= hfId.Value %>.jpg' />
            <asp:Label ID="lblVip" Visible="False" CssClass="vip" runat="server" Text="Vip"></asp:Label>
            <div class="right">

                <asp:HiddenField ID="hfId" runat="server" />
                <asp:Label ID="lblName" runat="server" Font-Bold="True"></asp:Label>
                <div class="pos">
                    <asp:Button ID="btnStatus" runat="server" Visible="False" CssClass="btn btn-outline-danger disable" Enabled="False" Text=""/>
                    <asp:Label ID="lblPrice" runat="server" CssClass="ggleft" Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblDiscount" Visible="false" runat="server" CssClass="ggleft" Font-Bold="True"></asp:Label>
                    <asp:Button ID="btnPurchase" CssClass="btn-primary btn" runat="server" Text="Purchase" OnClick="btnPurchase_Click" />
                    <asp:Button ID="btnPurchased" Enabled="False" CssClass="btn btn-secondary disable" runat="server" Text="Purchased" />
                    <asp:Button ID="btnEdit" runat="server" Visible="False" CssClass="btn btn-outline-danger" Text="Edit" OnClick="btnEdit_Click" />
                </div>
                <%-- Category --%>
                <p />
                <asp:Label ID="lblAuthor" runat="server" Font-Bold="True"></asp:Label>
                <p />
                <asp:Label ID="lblD" runat="server" Font-Bold="True"></asp:Label>
                <p/>    
                <div class="btnPosition">
                    <asp:Button ID="btnVerify" Visible="false" CssClass="btn btn-outline-secondary" runat="server" Text="Verify" OnClick="btnVerify_Click" />
                    <asp:Button ID="btnUnverify" Visible="false" CssClass="btn btn-outline-secondary" runat="server" Text="Unverify" OnClick="btnUnverify_Click" />
                    <asp:Button ID="btnFail" Visible="false" CssClass="btn btn-outline-secondary" runat="server" Text="Failed" OnClick="btnFail_Click" />
                    <asp:Button ID="btnFavourite" CssClass="btn btn-outline-primary" runat="server" Text="Add Favourite" OnClick="btnFavourite_Click" />
                    <asp:Button ID="btnFavourited" Enabled="False" CssClass="btn btn-outline-secondary" runat="server" Text="Favourite Added" />
                    <asp:Button ID="btnCantRead" Enabled="False" CssClass="btn btn-outline-secondary" runat="server" Text="Cant Read" />
                    <asp:Button ID="btnRead" CssClass="btn btn-outline-primary" runat="server" Text="Read Me" OnClick="btnRead_Click" />
                    <div>
                        <asp:Button ID="btnAddEpisode" Visible="false" CssClass="btn btn-outline-danger dd" runat="server" Text="Add Episode" OnClick="btnAddEpisode_Click" />
                    </div>
                </div>
            </div>
           
        </div>
        <div class="center">
            <asp:LinqDataSource ID="ldsEpisode" runat="server" ContextTypeName="manhua.DataClasses1DataContext" EntityTypeName="" TableName="Episodes" Where="C_Id == @C_Id" OnSelecting="ldsEpisode_Selecting">
                <WhereParameters>
                    <asp:QueryStringParameter Name="C_Id" QueryStringField="cId" Type="Int32" />
                </WhereParameters>
            </asp:LinqDataSource>
            <asp:ListView ID="lvEpisode" runat="server" DataKeyNames="E_Id" DataSourceID="ldsEpisode">
                <EmptyDataTemplate>
                    <span>No Episode.</span>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <div class="episode">
                        <a href='/ViewEpisode.aspx?cId=<%# Eval("C_Id")%>&eId=<%# Eval("E_Id") %>'>
                            <div id="font">
                                <asp:Label ID="E_TitleLabel" runat="server" Text='<%# Eval("E_Title") %>' />
                                <p />
                                <asp:Label ID="E_DateUploadLabel" runat="server" Text='<%# Eval("E_DateUpload") %>' />
                                <br />
                            </div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:ListView>
            <asp:LinqDataSource ID="ldsOnlyVip" runat="server" ContextTypeName="manhua.DataClasses1DataContext" EntityTypeName="" TableName="Episodes" Where="C_Id == @C_Id" OnSelecting="ldsEpisode_Selecting">
                <WhereParameters>
                    <asp:QueryStringParameter Name="C_Id" QueryStringField="cId" Type="Int32" />
                </WhereParameters>
            </asp:LinqDataSource>
            <asp:ListView ID="lvOnlyVip" Visible="False" runat="server" DataKeyNames="E_Id" DataSourceID="ldsOnlyVip">
                <EmptyDataTemplate>
                    <span>No Episode.</span>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <div class="cant">
                        <div id="font">
                            <asp:Label ID="E_TitleLabel" runat="server" Text='<%# Eval("E_Title") %>' />
                            <p />
                            <asp:Label ID="E_DateUploadLabel" runat="server" Text='<%# Eval("E_DateUpload") %>' />
                            <br />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
            <asp:LinqDataSource ID="ldsCantView" runat="server" ContextTypeName="manhua.DataClasses1DataContext" EntityTypeName="" TableName="Episodes" Where="C_Id == @C_Id &amp;&amp; E_Id &gt; @E_Id">
                <WhereParameters>
                    <asp:QueryStringParameter Name="C_Id" QueryStringField="cId" Type="Int32" />
                    <asp:Parameter DefaultValue="5" Name="E_Id" Type="Int32" />
                </WhereParameters>
            </asp:LinqDataSource>
            <asp:ListView ID="lvCantView" runat="server" DataKeyNames="E_Id" DataSourceID="ldsCantView">
                <ItemTemplate>
                    <div class="cant">
                            <div id="font">
                                <asp:Label ID="E_TitleLabel" runat="server" Text='<%# Eval("E_Title") %>' />
                                <p />
                                <asp:Label ID="E_DateUploadLabel" runat="server" Text='<%# Eval("E_DateUpload") %>' />
                                <br />
                            </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
            <asp:LinqDataSource ID="ldsCanView" runat="server" ContextTypeName="manhua.DataClasses1DataContext" EntityTypeName="" TableName="Episodes" Where="C_Id == @C_Id &amp;&amp; E_Id &gt; @E_Id">
                <WhereParameters>
                    <asp:QueryStringParameter Name="C_Id" QueryStringField="cId" Type="Int32" />
                    <asp:Parameter DefaultValue="5" Name="E_Id" Type="Int32" />
                </WhereParameters>
            </asp:LinqDataSource>
            <asp:ListView ID="lvCan" Visible="false" runat="server" DataKeyNames="E_Id" DataSourceID="ldsCanView">
                <ItemTemplate>
                    <div class="episode">
                        <a href='/ViewEpisode.aspx?cId=<%# Eval("C_Id")%>&eId=<%# Eval("E_Id") %>'>
                            <div id="font">
                                <asp:Label ID="E_TitleLabel" runat="server" Text='<%# Eval("E_Title") %>' />
                                <p />
                                <asp:Label ID="E_DateUploadLabel" runat="server" Text='<%# Eval("E_DateUpload") %>' />
                                <br />
                            </div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="center">
            <asp:LinqDataSource ID="ldsUpdate" runat="server" ContextTypeName="manhua.DataClasses1DataContext" EntityTypeName="" TableName="Episodes" Where="C_Id == @C_Id">
                <WhereParameters>
                    <asp:QueryStringParameter Name="C_Id" QueryStringField="cId" Type="Int32" />
                </WhereParameters>
            </asp:LinqDataSource>
            <asp:ListView ID="lvUpdate" runat="server" Visible="False" DataKeyNames="E_Id" DataSourceID="ldsUpdate">
                <EmptyDataTemplate>
                    <span>No Episode.</span>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <div class="episode">
                        <a href='/comicCreator/UpdateEpisode.aspx?cId=<%# Eval("C_Id")%>&eId=<%# Eval("E_Id") %>'>
                            <div id="font">
                                <asp:Label ID="E_TitleLabel" runat="server" Text='<%# Eval("E_Title") %>' />
                                <p />
                                <asp:Label ID="E_DateUploadLabel" runat="server" Text='<%# Eval("E_DateUpload") %>' />
                                <br />
                            </div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
