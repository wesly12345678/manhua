<%@ Page Title="Ban Reader" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="ban.aspx.cs" Inherits="manhua.Admin.ban" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/Ban.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="setposition">
        <h1>Reader List</h1>
       <p> <a href="/Admin/ban.aspx">Reader List</a> |
           <a href="/Admin/banCC.aspx">Comic Creator List</a>
       </p> 
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="manhua.DataClasses1DataContext" EntityTypeName="" Select="new (R_Id, R_NickName, R_BanStatus, R_register_date)" TableName="readers"></asp:LinqDataSource>
        <asp:GridView ID="GridView1" CssClass="grid text-center table table-hover table-light" GridLines="None" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource1" DataKeyNames="R_Id">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" CssClass="" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="R_Id" HeaderText="Id" ReadOnly="True" SortExpression="R_Id" />
                <asp:BoundField DataField="R_NickName" HeaderText="Nick Name" ReadOnly="True" SortExpression="R_NickName" />
                <asp:TemplateField HeaderText="BAN Status" SortExpression="R_BanStatus">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("R_BanStatus") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="R_register_date" HeaderText="Account Register Date" ReadOnly="True" SortExpression="R_register_date" />
            </Columns>
            <HeaderStyle CssClass="thead-dark" />
        </asp:GridView>
        <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Ban" OnClick="Button1_Click" />
        <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Unbanned" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="Back" CssClass="btn btn-primary" OnClick="Button3_Click"/>
        
    </div>
    <script>
        $(document).ready(function () {
            $('tr').click(function (event) {
                if (event.target.type !== 'checkbox') {
                    $(':checkbox', this).trigger('click');
                }
            });
        });
        $('tbody').on('click', 'input[type="checkbox"]', function (e) {
            var $row = $(this).closest('tr');
            if (this.checked) {
                $row.addClass('selected');
            } else {
                $row.removeClass('selected');
            }
        });

    </script>
</asp:Content>
