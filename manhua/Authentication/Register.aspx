<%@ Page Title="Register Reader" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="manhua.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table {
            padding-right: 9px;
        }

        .textbox {
            font-family: 'Montserrat', sans-serif;
            color: black;
        }

        .haha {
        }

        h1 {
            text-align: center;
            ;
        }

        #register_warpper {
            background-color: white;
            border-radius: 10px;
            box-shadow: 0 0 20px grey;
            margin: 50px auto;
            max-width: 800px;
            padding: 20px 10%;
        }

        .auto-style1 {
            height: 26px;
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

    <link href="../css/register.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="haha">
        <div id="register_warpper">
            <h1>Register</h1>
            <%--  <a href="registerComic.aspx">comicCreator </a>--%>
            <table>
                <tr>
                    <td>Name :</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtname" class="textbox" runat="server" MaxLength="20" CssClass="input textbox" Width="420px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:CustomValidator ID="cvName" runat="server" ControlToValidate="txtname" CssClass="error" Display="Dynamic" ErrorMessage="" OnServerValidate="cvName_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
                    </td>
                </tr>

                <tr>
                    <td>Password :</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtPassword" class="textbox" runat="server" MaxLength="20" TextMode="Password" CssClass="input textbox" Width="422px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:CustomValidator ID="cvPassword" runat="server" ControlToValidate="txtPassword" CssClass="error" Display="Dynamic" ErrorMessage="" OnServerValidate="cvPassword_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td>Confirm Password :</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtConfirm" runat="server" MaxLength="20" TextMode="Password" CssClass="input textbox" Width="425px"></asp:TextBox></td>
                    <tr>
                        <td>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtConfirm" ControlToValidate="txtPassword" CssClass="error" Display="Dynamic" ErrorMessage="[Confirm Password] and [Password] not matched"></asp:CompareValidator>
                        </td>
                    </tr>
                <tr>
                    <td class="auto-style2">Birth Date:</td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:TextBox ID="TxtDob" class="textbox" runat="server" Text='' TextMode="Date" Width="429px"></asp:TextBox></td>
                    <tr>
                        <td>
                            <asp:CustomValidator ID="cvDob" runat="server" ControlToValidate="txtDob" CssClass="error" Display="Dynamic" ErrorMessage="" OnServerValidate="cvDob_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
                        </td>
                    </tr>
                <tr>
                    <td>Email:</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="30" CssClass="input textbox" Width="430px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:CustomValidator ID="cvEmail" runat="server" ControlToValidate="txtEmail" CssClass="error" Display="Dynamic" ErrorMessage="" OnServerValidate="cvEmail_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td>Phone Number:</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtPhoneNumber" runat="server" MaxLength="50" CssClass="input textbox" Width="435px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:CustomValidator ID="cvPhoneNum" runat="server" ControlToValidate="txtPhoneNumber" CssClass="error" Display="Dynamic" ErrorMessage="" OnServerValidate="cvPhoneNum_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>


                    </td>
                </tr>
                <tr>
                    <td>Gender</td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="M">Male</asp:ListItem>
                            <asp:ListItem Value="F">Female</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td>
                        <asp:CustomValidator ID="cvGender" runat="server" ControlToValidate="rblGender" CssClass="error" Display="Dynamic" ErrorMessage="" OnServerValidate="cvGender_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>

                    </td>
                </tr>
            </table>
            <div class="hehe">
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="button" />
                <asp:Button ID="btnReset" runat="server" CausesValidation="False" Text="Reset" OnClick="btnReset_Click" CssClass="button" Width="139px" />
            </div>
        </div>

    </div>
</asp:Content>
