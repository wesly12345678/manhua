<%@ Page Title="Edit Profile" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="manhua.Reader.EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .haha{
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
    <div class =" hahe "><h1>Edit Profile</h1></div>
    <asp:HiddenField ID="hfId" runat="server" />
    <div class="haha">
    
        <div>
           Profile Picture:
            
            <div>
                <div class="pic">
                    <img src='../pic/profile/<%= hfId.Value %>.jpg' width="50px" height="50px" />
                </div>
            </div>
        </div>
        <div>
            Name :
            <div>
                <asp:TextBox ID="txtname" runat="server" MaxLength="20"></asp:TextBox></div>
            <div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter [name]" ControlToValidate="txtname" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div>
            Password :
            <div>
                <asp:TextBox ID="txtPassword" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox></div>
            <div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter [Password]" ControlToValidate="txtPassword" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div>
            Confirm Password :
            <div>
                <asp:TextBox ID="txtConfirm" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox></div>
            <div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter [Confirm Password]" ControlToValidate="txtConfirm" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
               </div>
            <div> <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirm" CssClass="error" Display="Dynamic" ErrorMessage="[Confirm Password] and [Password] not matched"></asp:CompareValidator>
            </div>
        </div>
        <div>
            email:
            <div>
                <asp:TextBox ID="txtEmail" runat="server" MaxLength="30" ReadOnly="True"></asp:TextBox></div>
              <div>  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter [Email]" ControlToValidate="txtEmail" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div>
            Phone Number:
            <div>
                <asp:TextBox ID="txtPhoneNumber" runat="server" MaxLength="50"></asp:TextBox></div>
              <div><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please enter [Phone Number]" ControlToValidate="txtPhoneNumber" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div>
            Picture:
            <div>
                <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control-file border" accept="image/*"/></div>
            <div><asp:CustomValidator ID="cvFuImage" runat="server" ErrorMessage="" CssClass="error" ControlToValidate="fuImage" OnServerValidate="cvFuImage_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator></div>
        </div>
    
    <div>
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="button" />
        <asp:Button ID="Button1" runat="server" Text="Back" CssClass="button" OnClick="Button1_Click" CausesValidation="False"  />

    </div>
        </div>
</asp:Content>
