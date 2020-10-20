<%@ Page Title="Credit Card" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="CreditCard.aspx.cs" Inherits="manhua.Payment.CreditCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="https://s3-us-west-2.amazonaws.com/s.cdpn.io/3/jquery.inputmask.bundle.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.inputmask/3.3.4/bindings/inputmask.binding.js"></script>
    <style>
        #payment_wrapper{
             background-color: white;
            border-radius: 10px;
            box-shadow: 0 0 20px grey;
            padding-top: 100px;
            margin: 50px auto;
            max-width: 800px;
            padding: 20px 10%;
        }
        .haha{
            margin:150px;
        }

    </style>
   
    <script>
        $(":input").inputmask();
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="haha">
     <div id="payment_wrapper">
        <h3 class="text-center">Credit / Debit Card Info</h3>
        <hr />
        <div>
            <asp:Label ID="totalAmount" runat="server" CssClass="font-weight-bold"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblCardNum" runat="server" Text="Credit Card Number:"></asp:Label>
            <asp:TextBox ID="txtCardNum" runat="server" MaxLength="19" data-inputmask="'mask': '9999 9999 9999 9999'" placeholder="8888 8888 8888 8888" CssClass="form-control"></asp:TextBox>
            <small>
                <asp:CustomValidator ID="cvCardNum" runat="server" ControlToValidate="txtCardNum" ErrorMessage="number" Display="Dynamic" OnServerValidate="cvCardNum_ServerValidate" ValidateEmptyText="True" CssClass="error"></asp:CustomValidator>
            </small>
        </div>
        <div class="d-flex justify-content-between">
            <div>
                <asp:Label ID="lblExpDate" runat="server" Text="Expire date(mm/yy)"></asp:Label>
                <asp:TextBox ID="txtExpDate" runat="server" data-inputmask="'alias': '99/99'" MaxLength="5" placeholder="mm/yy" CssClass="form-control"></asp:TextBox>
                <small>
                    <asp:CustomValidator ID="cvExpDate" runat="server" ErrorMessage="exp" ControlToValidate="txtExpDate" Display="Dynamic" OnServerValidate="cvCreditCardEpx_ServerValidate" ValidateEmptyText="True" CssClass="error"></asp:CustomValidator>
                </small>
            </div>
            <div>
                <asp:Label ID="lblCvv" runat="server" Text="CVV/CVC"></asp:Label>
                <asp:TextBox ID="txtCvv" runat="server" MaxLength="3" data-inputmask="'mask': '999'" CssClass="form-control" placeholder="999"></asp:TextBox>
                <small>
                    <asp:CustomValidator ID="cvCvv" runat="server" ErrorMessage="cvv" ControlToValidate="txtCvv" Display="Dynamic" OnServerValidate="cvCreditCardCvv_ServerValidate" ValidateEmptyText="True" CssClass="error"></asp:CustomValidator>
                </small>
            </div>
        </div>
        <hr />
        <div class="text-center">
            <asp:Button ID="btnSubmit" runat="server" Text="PayNow" OnClick="btnSubmit_Click" CssClass="btn btn-outline-primary" />
             <asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="btnBack_Click" CssClass="btn btn-outline-primary" />
    
    </div>
      </div>
    </div>
</asp:Content>
