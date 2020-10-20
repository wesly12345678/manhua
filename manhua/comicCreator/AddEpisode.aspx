<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="AddEpisode.aspx.cs" Inherits="manhua.comicCreator.AddEpisode" %>
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
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">\
    <div class=" haha">
        <h1>Add Episode</h1>
    <div class="form">
        <p>
            Episode Number
            <div>
                <asp:TextBox ID="txtEpisode" runat="server"></asp:TextBox>
                </div>
            <div>
                <asp:CustomValidator ID="cvEpisode" runat="server" ErrorMessage="CustomValidator" ControlToValidate="txtEpisode" Display="Dynamic" ValidateEmptyText="True" OnServerValidate="cvEpisode_ServerValidate" CssClass="error"></asp:CustomValidator>
            </div>
        </p>
        <p>
            Title
            <div>
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                </div><div>
                <asp:CustomValidator ID="cvTitle" runat="server" ErrorMessage="CustomValidator" OnServerValidate="cvTitle_ServerValidate" ControlToValidate="txtTitle" Display="Dynamic" ValidateEmptyText="True" CssClass="error"></asp:CustomValidator>
            </div>
        </p>
        <p>
            Page Number
            <div>
                <asp:TextBox ID="txtPageNum" runat="server" TextMode="Number"></asp:TextBox>
                </div>
            <div>
                <asp:CustomValidator ID="cvPageNum" runat="server" ErrorMessage="CustomValidator" ControlToValidate="txtPageNum" Display="Dynamic" ValidateEmptyText="True" OnServerValidate="cvPageNum_ServerValidate" CssClass="error"></asp:CustomValidator>
            </div>
        </p>
        <p>
            Upload
            <div>
                <asp:FileUpload ID="fuImage" runat="server" AllowMultiple="True" CssClass="form-control-file border"  runat="server" accept="image/*" />
                </div>
            <div>
                <asp:CustomValidator ID="cvFuImage" runat="server" ErrorMessage="CustomValidator" ControlToValidate="fuImage" Display="Dynamic" ValidateEmptyText="True" CssClass="error" OnServerValidate="cvImage_ServerValidate"></asp:CustomValidator>
            </div>
        </p>
        

        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="button" OnClick="btnAdd_Click" />
        <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" />
       
        <asp:Button ID="Button1" runat="server" Text="Back" CssClass="button" OnClick="Button1_Click" />
       
    </div>

    </div>
</asp:Content>
