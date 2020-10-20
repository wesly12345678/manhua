<%@ Page Title="Type Of Payment" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="ChoiceCoP.aspx.cs" Inherits="manhua.ChoiceCoP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .huhu {
            border: solid 1px black;
            margin: 20px;
            width: 400px;
            text-align: center;
        }
        .huha {
            border-bottom: solid 1px black;
        }
        .text {
            text-align: center;
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
            margin: 0;
            padding: 0;
        }

        .itemss {
            border: 1px solid black;
            padding: 10px;
        }

        .itemss:hover {
            color: white !important;
            background: black;
            border-color: Blue;
            transition: all 0.4s ease 0s;
        }

        h1 {
            text-align: center;
        }

        .tt {
            padding: 20px;
        }

        .mouse {
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="tt">
        <h1>Payment Method</h1>
    </div>
    <div class="huhu">
        <div class="huha">
            Username:
        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
        </div>
        <div class="huha">
            Type:
        <asp:Label ID="lblType" runat="server" Text=""></asp:Label>
        </div>
        <div class="huha">
            Comic Name: 
        <asp:Label ID="lblComicName" runat="server" Text=""></asp:Label>
        </div>
        <div clas="huha">
            Amount:
        <asp:Label ID="lblAmount" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="hahe ">
        <div class="itemss">
            <div class="pic">
                <a href="/reader/Payment/CreditCard.aspx">
                    <img src="/pic/background_image/credit-cards.png" class="image" style="cursor: pointer" width="400px" height="300px" />
                </a>
            </div>
            <div class="hh">
                <label>Credit Card</label></div>
        </div>
        <div class="borderL"></div>
        <div class="itemss">
            <div class="pic">
            <asp:ImageButton ID="imgBtn" CssClass="image" ImageUrl="~/pic/background_image/paypal.png" Width="400px" Height="300px" runat="server" OnClick="imgBtn_Click" />
            </div>
                <div class="hh">
                <label>PayPal</label>
            </div>
        </div>
    </div>


</asp:Content>
