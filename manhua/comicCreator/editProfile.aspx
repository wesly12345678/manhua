<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="editProfile.aspx.cs" Inherits="manhua.comicCreator.editProfile" %>

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

        .tablewhole {
            margin: 50px auto;
        }
        .btnGroup {
            margin: 10px;
            margin-left: 100px;

        }
        .wholeBody {
            border: 1px solid lightgrey;
            box-shadow:0 0 20px gray;
            width: 50%;
            margin: 10px auto;

        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="hfId" runat="server" />
    <h1>Edit Profile</h1>
    <div class="wholeBody">
    <table class="tablewhole">
        <tr>
            <td>Profile Picture</td>
            <td>
                <div class="pic">
                    <img src='../pic/profile/<%= hfId.Value %>.jpg' width="50px" height="50px" />
                </div>
            </td>
        </tr>
        <tr>
            <td>Name :</td>
            <td>
                <asp:TextBox ID="txtname" runat="server" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter [name]" ControlToValidate="txtname" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Password :</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter [Password]" ControlToValidate="txtPassword" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Confirm Password :</td>
            <td>
                <asp:TextBox ID="txtConfirm" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter [Confirm Password]" ControlToValidate="txtConfirm" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirm" CssClass="error" Display="Dynamic" ErrorMessage="[Confirm Password] and [Password] not matched"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>email</td>
            <td>
                <asp:TextBox ID="txtEmail" ReadOnly="True" runat="server" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter [Email]" ControlToValidate="txtEmail" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>Phone Number</td>
            <td>
                <asp:TextBox ID="txtPhoneNumber" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please enter [Phone Number]" ControlToValidate="txtPhoneNumber" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Update Profile Picture</td>
            <td>
                <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control-file border" accept="image/*" />
                <asp:CustomValidator ID="cvFuImage" runat="server" ErrorMessage="CustomValidator" ControlToValidate="fuImage" ValidateEmptyText="True" OnServerValidate="cvFuImage_ServerValidate" Display="Dynamic" CssClass="error"></asp:CustomValidator>
            </td>
        </tr>
    </table>
    <p>
        <div class="btnGroup">
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="button" />
            <asp:Button ID="Button1" runat="server" Text="Back" CssClass="button" OnClick="Button1_Click" CausesValidation="False" />
        </div>
    </div>
</asp:Content>
