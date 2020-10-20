<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="AddComic.aspx.cs" Inherits="manhua.comicCreator.AddComic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form{
              background-color: white;
            border-radius: 10px;
            box-shadow: 0 0 20px grey;
            padding-top: 100px;
            margin: 50px auto;
            max-width: 800px;
            padding: 20px 10%;
        }
        h1{
            text-align:center;
        }
        .button{
              color: #494949 !important;
            text-transform: uppercase;
            background: #ffffff;
            padding: 10px;
            border: 4px solid #494949 !important;
            border-radius: 6px;
            display: inline-block;
        }
        .button:hover{
               cursor: pointer;
            color: white !important;
            background: #4cff00;
            border-color: #4cff00 !important;
            transition: all 0.4s ease 0s;
        }
         

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:LinqDataSource ID="ldsCategory" runat="server" ContextTypeName="manhua.DataClasses1DataContext" EntityTypeName="" TableName="Categories"></asp:LinqDataSource>
    <div class="haha">
        <h1>Add Comic</h1>
    <div class="form">
        <p>
            Title:
            <div>
                <asp:TextBox ID="txtTitle" runat="server" Height="32px" Width="272px"></asp:TextBox>
                </div>
            <div>
                <asp:CustomValidator ID="cvTitle" runat="server" ErrorMessage="CustomValidator" OnServerValidate="cvTitle_ServerValidate" ControlToValidate="txtTitle" ValidateEmptyText="True" Display="Dynamic" CssClass="error"></asp:CustomValidator>
            </div>
        </p>
        <p>
            Description:
            <div>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="49px" Width="275px"></asp:TextBox>
                </div>
            <div>
                <asp:CustomValidator ID="cvDesc" runat="server" ErrorMessage="CustomValidator" OnServerValidate="cvDesc_ServerValidate" ControlToValidate="txtDescription" ValidateEmptyText="True" Display="Dynamic" CssClass="error"></asp:CustomValidator>
            </div>
        </p>
        <p>
            Category:
            <div>
                <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="ldsCategory" DataTextField="Ca_Name" DataValueField="Ca_Id"></asp:DropDownList>
                </div>
            <div>
                <asp:CustomValidator ID="cvCategory" runat="server" ErrorMessage="CustomValidator" OnServerValidate="cvCategory_ServerValidate" ControlToValidate="ddlCategory" ValidateEmptyText="True" Display="Dynamic" CssClass="error"></asp:CustomValidator>
            </div>
        </p>
        <p>
            Price:
            <div>
                <asp:TextBox ID="txtPrice" runat="server" Height="32px" Width="275px"></asp:TextBox>
                </div>
            <div>
                <asp:CustomValidator ID="cvPrice" runat="server" ErrorMessage="CustomValidator" OnServerValidate="cvPrice_ServerValidate" ControlToValidate="txtPrice" ValidateEmptyText="True" Display="Dynamic" CssClass="error"></asp:CustomValidator>
            </div>
        </p>
        <p>
            Age Restriction:
            <div>
                <asp:DropDownList ID="ddlAgeRestrt" runat="server"></asp:DropDownList>
                </div>
            <div>
                <asp:CustomValidator ID="cvAgeRestrt" runat="server" ErrorMessage="CustomValidator" OnServerValidate="cvAgeRestrt_ServerValidate" ControlToValidate="ddlAgeRestrt" ValidateEmptyText="True" Display="Dynamic" CssClass="error"></asp:CustomValidator>
            </div>
        </p>
        <p>
            Vip can view?:
            <div>
                <asp:RadioButtonList ID="rblVipView" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>True</asp:ListItem>
                    <asp:ListItem>False</asp:ListItem>
            </asp:RadioButtonList>
                </div>
            <div>
                <asp:CustomValidator ID="cvVipView" runat="server" ErrorMessage="CustomValidator" OnServerValidate="cvVipView_ServerValidate" ControlToValidate="rblVipView" ValidateEmptyText="True" Display="Dynamic" CssClass="error"></asp:CustomValidator>
            </div>
        </p>
        <p>
            Picture:
            <div >
                <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control-file border"  accept="image/*" />
                </div>
            <div>
                <asp:CustomValidator ID="cvFuImage" runat="server" ErrorMessage="CustomValidator" ControlToValidate="fuImage" ValidateEmptyText="True" OnServerValidate="cvFuImage_ServerValidate" Display="Dynamic" CssClass="error"></asp:CustomValidator>
            </div>
        </p>

        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="button" OnClick="btnAdd_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" OnClick="btnCancel_Click" />
    </div>

    </div>
</asp:Content>
