<%@ Page Title="Login" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="manhua.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://www.google.com/recaptcha/api.js?render=6LemVIQUAAAAAHx3EV5zL4IPOoFQC5wpT5x0WRwJ"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <style>
        h1 {
            text-align: center;
            ;
        }

        #register_warpper {
            background-color: white;
            border-radius: 10px;
            box-shadow: 0 0 20px grey;
            padding-top: 100px;
            margin: 50px auto;
            max-width: 800px;
            padding: 20px 10%;
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
    <div class="haha">
        <div id="register_warpper">

            <h1>Login</h1>
            <table id="login">
                <tr>
                    <td>Email :</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" MaxLength="50" CssClass="input" CausesValidation="True" Width="492px"></asp:TextBox></td>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" CssClass="error" Display="Dynamic" ErrorMessage="Please enter [Email]"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                <tr>
                    <td>Password :</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="20" CssClass="input" CausesValidation="True" Width="488px"></asp:TextBox></td>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" CssClass="error" Display="Dynamic" ErrorMessage="Please enter [Password]"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvNotMatched" runat="server" CssClass="error" Display="Dynamic" ErrorMessage="" OnServerValidate="cvNotMatched_ServerValidate"></asp:CustomValidator>
                        </td>
                    </tr>
                <tr>
                    <td colspan="2">
                        <asp:CheckBox ID="chkRememberMe" runat="server" Text="Remember me" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:CustomValidator ID="cvRecaptcha" runat="server" ErrorMessage=""></asp:CustomValidator>
                        <a href="#" onclick="window.open('ForgetPassword.aspx','FP','with=500,height=50,top=300,left=500,fullscreen=no,resizable=0');">Forget Password</a>
                    </td>
                </tr>
            </table>


            <div class="hehe">
                <span>
                    <asp:HiddenField ID="hfRecaptcha" runat="server" />
                </span>
                <asp:Button ID="btnRegister" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="button" />
                <asp:Button ID="btnReset" runat="server" CausesValidation="False" Text="Reset" OnClick="btnReset_Click" CssClass="button" Width="110px" />
            </div>


            <p>
                No account yet? Please
        [ <a href="/Authentication/Register.aspx">Register</a> ].
            </p>
        </div>
    </div>
    <script>
        grecaptcha.ready(function () {
            grecaptcha.execute('6LemVIQUAAAAAHx3EV5zL4IPOoFQC5wpT5x0WRwJ', { action: 'login' }).then(function (token) {
                $('#main_hfRecaptcha').val(token);
            });
        });
    </script>
</asp:Content>
