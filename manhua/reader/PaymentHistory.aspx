<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="PaymentHistory.aspx.cs" Inherits="manhua.PaymentHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>  
        .button {
            color: #494949 !important;
            text-transform: uppercase;
            background: #ffffff;
            padding: 10px;
            border: 4px solid #494949 !important;
            border-radius: 6px;
            display: inline-block;
        }

        .button:hover {
            cursor: pointer;
            color: white !important;
            background: #4cff00;
            border-color: #4cff00 !important;
            transition: all 0.4s ease 0s;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:LinqDataSource ID="ldsPayment" runat="server" ContextTypeName="manhua.DataClasses1DataContext" EntityTypeName="" TableName="payments"></asp:LinqDataSource>
   
    <h1>Payment History</h1>
    <asp:GridView ID="gvPaymnent" runat="server" AutoGenerateColumns="False" DataKeyNames="P_Id" DataSourceID="ldsPayment" CellPadding="4" ForeColor="#333333" GridLines="None" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="P_Id" HeaderText="Payment Id" ReadOnly="True" SortExpression="P_Id"></asp:BoundField>
            <asp:BoundField DataField="P_Amount" HeaderText="Amount" SortExpression="P_Amount"></asp:BoundField>
            <asp:BoundField DataField="P_Method" HeaderText="Method" SortExpression="P_Method"></asp:BoundField>
            <asp:BoundField DataField="P_Currency" HeaderText="Currency" SortExpression="P_Currency"></asp:BoundField>
            <asp:BoundField DataField="P_Transaction_Date" HeaderText="Transaction Date" SortExpression="P_Transaction_Date"></asp:BoundField>
            <asp:BoundField DataField="P_Type" HeaderText="Type" SortExpression="P_Type"></asp:BoundField>
            <asp:BoundField DataField="Comic.C_Title" HeaderText="Comic Name" SortExpression="C_Id"></asp:BoundField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <div>
        <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" CssClass="button"/></div>
</asp:Content>
