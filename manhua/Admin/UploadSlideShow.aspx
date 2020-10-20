<%@ Page Title="Upload Slide Show" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="UploadSlideShow.aspx.cs" Inherits="manhua.Admin.UploadSlideShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/UploadSlideShow.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="setposition">

        <h1 id>Upload the slideshow</h1>
        <div class="container-form">
            <div class="input-group">
                <div class="input-group-prepend ">
                    <span class="input-group-text " id="inputGroup-sizing-default">Title</span>
                </div>
                <asp:TextBox ID="txtTitle" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <%-- <div>
                asd
            </div>--%>
            <p />
            <div class="input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text" id="inputGroup-sizing-default">Alternative</span>
                </div>
                <asp:TextBox ID="txtAlt" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <p />
            <div class="input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text" id="inputGroup-sizing-default">Link</span>
                </div>
                <asp:TextBox ID="txtLink" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <p />
            <div class="input-group">

                <asp:FileUpload ID="fuPicture" aria-describedby="inputGroupFileAddon01" CssClass="form-control-file border"  runat="server" accept="image/*" />
            </div>
            <asp:CustomValidator ID="cvPicture" runat="server" ErrorMessage="" ControlToValidate="fuPicture" CssClass="error" OnServerValidate="cvPicture_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
            <p />
            <div class="input-group">

                <asp:Button ID="btnUpload" CssClass="btn btn-outline-secondary" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                <asp:Button ID="Button1" runat="server" Text="Back" CssClass="btn btn-outline-secondary" OnClick="Button1_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
