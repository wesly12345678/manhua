<%@ Page Title="Ban Comic Creator" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="banCC.aspx.cs" Inherits="manhua.Admin.banCC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/Ban.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
      <div class="setposition">
        <h1>Comic Creator List</h1>
           <p> <a href="/Admin/ban.aspx">Reader List</a> |
           <a href="/Admin/banCC.aspx">Comic Creator List</a>
       </p> 
          <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="manhua.DataClasses1DataContext" EntityTypeName="" TableName="ComicCreators"></asp:LinqDataSource>
           <asp:GridView ID="GridView1" CssClass="grid text-center table table-hover table-light" GridLines="None" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource1" DataKeyNames="CC_Id">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" CssClass="" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CC_Id" HeaderText="Id" ReadOnly="True" SortExpression="CC_Id" />
                <asp:BoundField DataField="CC_NickName" HeaderText="Nick Name" ReadOnly="True" SortExpression="CC_NickName" />
                <asp:TemplateField HeaderText="BAN Status" SortExpression="CC_BanStatus">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CC_BanStatus") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CC_register_date" HeaderText="Account Register Date" ReadOnly="True" SortExpression="CC_register_date" />
            </Columns>
            <HeaderStyle CssClass="thead-dark" />
        </asp:GridView>
        
        <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Ban" OnClick="Button1_Click" />
        <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Unbanned" OnClick="Button2_Click" />
        
          <asp:Button ID="Button3" CssClass="btn btn-primary" runat="server" Text="Back" OnClick="Button3_Click" />
        
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
