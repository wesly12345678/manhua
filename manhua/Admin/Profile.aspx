<%@ Page Title="Profile" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="manhua.Admin.Profile" %>
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
        .h1{
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
        .btn-group {
            margin: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
     <asp:HiddenField ID="hfId" runat="server" />
    <div class="hahe"> <h1>Edit Profile</h1></div>
    <div class="haha">
        <div>
            <img src="/pic/profile/<%= hfId.Value %>.jpg" width="300px" height="300px"/>
        </div>
          <div>
            Name :
            <div>
                <asp:TextBox ID="txtname" runat="server" MaxLength="20" CssClass="input"></asp:TextBox>
                </div>
              <div>
                <asp:CustomValidator ID="cvName" runat="server" ControlToValidate="txtname" CssClass="error" Display="Dynamic" ErrorMessage="Please enter [name]"  ValidateEmptyText="True" ></asp:CustomValidator>
            </div>
        </div>
        <div>
            Password :
            <div>
                <asp:TextBox ID="txtPassword" runat="server" MaxLength="20" TextMode="Password" CssClass="input"></asp:TextBox></div>
            <div>
                 <asp:CustomValidator ID="cvPassword" runat="server" ControlToValidate="txtPassword" CssClass="error" Display="Dynamic" ErrorMessage="Please enter [ password ]"  ValidateEmptyText="True"></asp:CustomValidator>
            </div>
        </div>
        <div>
            Confirm Password :
            <div>
                <asp:TextBox ID="txtConfirm" runat="server" MaxLength="20" TextMode="Password" CssClass="input"></asp:TextBox></div>
            <div>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtConfirm" ControlToValidate="txtPassword" CssClass="error" Display="Dynamic" ErrorMessage="[Confirm Password] and [Password] not matched"></asp:CompareValidator>
            </div>
        </div>
        
        <div>
            Email:
            <div>
                <asp:TextBox ID="txtEmail" ReadOnly="True" runat="server" MaxLength="30" CssClass="input"></asp:TextBox></div>
            <div>
            <asp:CustomValidator ID="cvEmail" runat="server" ControlToValidate="txtEmail" CssClass="error" Display="Dynamic" ErrorMessage="Pls enter [Email]"  ValidateEmptyText="True"></asp:CustomValidator>
            </div>
        </div>
         
        <div>
            Gender
            <div>
                <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                </asp:RadioButtonList></div>
            <div>
                 <asp:CustomValidator ID="cvGender" runat="server" ControlToValidate="rblGender" CssClass="error" Display="Dynamic" ErrorMessage="Pls choice [Gender]"  ValidateEmptyText="True"></asp:CustomValidator>

                </div>
              <div>
            Picture
            <div>
                <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control-file border" accept="image/*" /></div>
                  <asp:CustomValidator ID="cvFuImage" runat="server" ErrorMessage="" CssClass="error" ControlToValidate="fuImage" OnServerValidate="cvFuImage_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>

        </div>
        </div>
        
     <div class="btn-group">
        <asp:Button ID="btnRegister" runat="server" Text="Edit" OnClick="btnRegister_Click" CssClass="button" />
         <asp:Button ID="Button1" runat="server" Text="Back" CssClass="button" OnClick="Button1_Click" />
    </div>

    </div>
</asp:Content>
