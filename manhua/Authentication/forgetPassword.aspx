<%@ Page Title="Forget Password" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="forgetPassword.aspx.cs" Inherits="manhua.forgetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
      <p>Enter your register email:<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
 </p>
 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Email is required" ControlToValidate="txtEmail" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid email format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="error" Display="Dynamic"></asp:RegularExpressionValidator>
            
 <p>
        <asp:Button ID="ButPwd" runat="server" Text="Send" OnClick="ButPwd_Click" CssClass="color-change"/>
        <asp:Label ID="Labmsg" runat="server" ></asp:Label>
 </p>
<p>
        <asp:CustomValidator ID="cvNotMatched" runat="server" CssClass="error" Display="Dynamic" ErrorMessage="This email address has not registered yet."></asp:CustomValidator>
 </p>
</asp:Content>
