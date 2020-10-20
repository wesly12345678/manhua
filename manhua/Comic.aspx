<%@ Page Title="Category" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Comic.aspx.cs" Inherits="manhua.Comic1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @import url('https://fonts.googleapis.com/css?family=Gothic+A1|Kaushan+Script|Libre+Baskerville|Lobster');
        .haha{
            
            margin : 10px;
            margin-left:150px;
            flex-direction:row;
        }
        .cont{
            background-color:black;
            margin:20px;
            width:300px;
            float:left;
            height:350px;
            transition: transform .2s;
        }
        .cont:hover{
            transform: scale(1.2);
        }
        .textT{
            text-align:center;
            color:white;
        }
        h1{
            padding-top: 10px;
            text-align:center;
        }
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <h1>Category<asp:Label ID="lblCategory" runat="server" Text=""></asp:Label></h1>
    
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="manhua.DataClasses1DataContext" EntityTypeName="" TableName="Comics" Where="C_Status == @C_Status &amp;&amp; C_CantViewable == @C_CantViewable &amp;&amp; (C_category == @C_category || @C_category == null)">
        <WhereParameters>
            <asp:Parameter DefaultValue="V" Name="C_Status" Type="Char" />
            <asp:Parameter DefaultValue="false" Name="C_CantViewable" Type="Boolean" />
            <asp:QueryStringParameter Name="C_category" QueryStringField="ca" Type="String" />
        </WhereParameters>
    </asp:LinqDataSource>
     <div class="haha">
         <ul class="nav nav-tabs">
             <li class="nav-item"><a href="Comic.aspx?ca=Ad" class="nav-link">Adventure</a></li>
             <li class="nav-item"><a href="Comic.aspx?ca=Ch" class="nav-link">Children</a></li>
             <li class="nav-item"><a href="Comic.aspx?ca=Co" class="nav-link">Comedy</a></li>
             <li class="nav-item"><a href="Comic.aspx?ca=Hi" class="nav-link">History</a></li>
             <li class="nav-item"><a href="Comic.aspx?ca=Lo" class="nav-link">Love</a></li>
             <li class="nav-item"><a href="Comic.aspx?ca=Ma" class="nav-link">Magic</a></li>
             <li class="nav-item"><a href="Comic.aspx?ca=Sc" class="nav-link">School</a></li>
             <li class="nav-item"><a href="Comic.aspx?ca=Sp" class="nav-link">Sport</a></li>
             <li class="nav-item"><a href="Comic.aspx?ca=Wa" class="nav-link">War</a></li>
             <li class="nav-item"><a href="Comic.aspx?ca=Su" class="nav-link">Suspense</a></li>      
         </ul>
         <asp:ListView ID="lvComic" runat="server" DataSourceID="LinqDataSource1">
             <EmptyDataTemplate>
                 <h1>Coming Soon....</h1>
             </EmptyDataTemplate>
            <ItemTemplate>
                <div class="cont">
                    <a class="aa"href="DisplayComic.aspx?cId=<%# Eval("C_Id") %>">
                    <img src='/pic/comic/<%# Eval("C_Id") %>/<%# Eval("C_Id") %>.jpg' width="300px" height="300px" style="border: solid"/>
                        <div class="textT">
                            <%# Eval("C_Title") %>
                        </div>
                    </a>
               </div>
            </ItemTemplate>
        </asp:ListView> 
    </div>
</asp:Content>
