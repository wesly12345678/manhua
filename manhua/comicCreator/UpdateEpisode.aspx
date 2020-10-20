<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="UpdateEpisode.aspx.cs" Inherits="manhua.comicCreator.UpdateEpisode" %>
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
    <asp:HiddenField ID="hfEpisode" runat="server" />
    <asp:HiddenField ID="hfPageNum" runat="server" />
    <asp:HiddenField ID="hfComicId" runat="server" />
    <div class="form">
        <p>
            Episode Number
            <small>
                <asp:TextBox ID="txtEpisode" ReadOnly="True" Enabled="False" Text="<%= hfEpisode.Value %>" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="cvEpisode" runat="server" ErrorMessage="CustomValidator" ControlToValidate="txtEpisode" Display="Dynamic" ValidateEmptyText="True" OnServerValidate="cvEpisode_ServerValidate"></asp:CustomValidator>
            </small>
        </p>
        <p>
            Title
            <small>
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                <asp:CustomValidator ID="cvTitle" runat="server" ErrorMessage="CustomValidator" OnServerValidate="cvTitle_ServerValidate" ControlToValidate="txtTitle" Display="Dynamic" ValidateEmptyText="True"></asp:CustomValidator>
            </small>
        </p>
        <p>
            Page Number
            <small>
                <asp:TextBox ID="txtPageNum" runat="server" TextMode="Number"></asp:TextBox>
                <asp:CustomValidator ID="cvPageNum" runat="server" ErrorMessage="CustomValidator" ControlToValidate="txtPageNum" Display="Dynamic" ValidateEmptyText="True" OnServerValidate="cvPageNum_ServerValidate"></asp:CustomValidator>
            </small>
        </p>
        <div class="pic">
            <% string temp = hfPageNum.Value;
               int pageNum = int.Parse(temp);
               for (int i = 1; i <= pageNum; i++)
               {%>
                <img src='/pic/comic/<%= hfComicId.Value %>/<%= hfEpisode.Value %>/<%= i %>.jpg' class="border" width="300px" height="300px"/>
            <%
        }%>
        </div>
        <p>
            Reupload
            <small>
                <asp:FileUpload ID="fuImage" runat="server" AllowMultiple="True" CssClass="form-control-file border"  accept="image/*"  />
                <asp:CustomValidator ID="cvFuImage" runat="server" ErrorMessage="CustomValidator" ControlToValidate="fuImage" Display="Dynamic" ValidateEmptyText="True" OnServerValidate="cvImage_ServerValidate"></asp:CustomValidator>
            </small>
        </p>

        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="button" />
         <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="button" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="button"/>
       
    </div>
    <style>
        .pic {
            border: 1px solid black;
        }
        .border {
            border: 1px solid black;
        }
    </style>
</asp:Content>
