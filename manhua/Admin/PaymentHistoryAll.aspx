<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="PaymentHistoryAll.aspx.cs" Inherits="manhua.Admin.PaymentHistoryAll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <h1>All Transaction History</h1>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="manhua.DataClasses1DataContext" EntityTypeName="" TableName="payments"></asp:LinqDataSource>
    <asp:GridView ID="gvPaymnent" runat="server" AutoGenerateColumns="False" DataKeyNames="P_Id" DataSourceID="LinqDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvPaymnent_SelectedIndexChanged">
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
    <div><asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" cssClass="btn btn-primary"/></div>
</asp:Content>
