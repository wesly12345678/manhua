using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using manhua.Classes;

namespace manhua.Payment
{
    public partial class CreditCard : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = HttpContext.Current.User.Identity.Name;
            readers r = db.readers.SingleOrDefault(a => a.R_email == email);
            if (r != null)
            {
                if (Session["type"] == null || Session["purchase_cId"] == null || Session["price"] == null)
                {
                    //Redirect the page
                    Response.Redirect("~/error.aspx?err=The result cant be found");
                }
                else
                {
                    if (Session["type"].ToString() != "Vip" && Session["type"].ToString() != "Comic")
                    {
                        //redirect page
                        Response.Redirect("~/error.aspx?err=The result cant be found");
                    }
                }
            }
           
            
        }
        protected void cvCardNum_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string temp = Security.ParseOutHTML(txtCardNum.Text);
            string tm = temp.Replace(" ", string.Empty);
            bool verified = ValidateCardNumber(tm);
            if (string.IsNullOrEmpty(args.Value))
            {
                cvCardNum.ErrorMessage = "The credit card number is empty";
                args.IsValid = false;
            }
            else
            {
                if (!verified)
                {
                    cvCardNum.ErrorMessage = "The credit card number is invalid";
                    args.IsValid = false;
                }
            }
        }
        protected void cvCreditCardEpx_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string exp = Security.ParseOutHTML(txtExpDate.Text);
            if (string.IsNullOrEmpty(exp))
            {
                cvExpDate.ErrorMessage = "The expire data cannot be empty";
                args.IsValid = false;
            }

        }

        protected void cvCreditCardCvv_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string cvv = Security.ParseOutHTML(txtCvv.Text);
            if (string.IsNullOrEmpty(cvv))
            {
                cvCvv.ErrorMessage = "CVV/CVC cannot be empty";
                args.IsValid = false;
            }
            else if (Convert.ToInt32(cvv) < 0)
            {
                cvCvv.ErrorMessage = "Invalid CVV/CVC";
                args.IsValid = false;
            }
        }


        private static bool ValidateCardNumber(string cardNumber)
        {
            try
            {
                // Array to contain individual numbers
                var CheckNumbers = new ArrayList();
                // So, get length of card
                var CardLength = cardNumber.Length;

                // Double the value of alternate digits, starting with the second digit
                // from the right, i.e. back to front.
                // Loop through starting at the end
                for (var i = CardLength - 2; i >= 0; i = i - 2)
                    // Now read the contents at each index, this
                    // can then be stored as an array of integers

                    // Double the number returned
                    CheckNumbers.Add(int.Parse(cardNumber[i].ToString()) * 2);

                var CheckSum = 0; // Will hold the total sum of all checksum digits

                // Second stage, add separate digits of all products
                for (var iCount = 0; iCount <= CheckNumbers.Count - 1; iCount++)
                {
                    var _count = 0; // will hold the sum of the digits

                    // determine if current number has more than one digit
                    if ((int)CheckNumbers[iCount] > 9)
                    {
                        var _numLength = ((int)CheckNumbers[iCount]).ToString().Length;
                        // add count to each digit
                        for (var x = 0; x < _numLength; x++)
                            _count = _count + int.Parse(
                                         ((int)CheckNumbers[iCount]).ToString()[x].ToString());
                    }
                    else
                    {
                        // single digit, just add it by itself
                        _count = (int)CheckNumbers[iCount];
                    }

                    CheckSum = CheckSum + _count; // add sum to the total sum
                }

                // Stage 3, add the unaffected digits
                // Add all the digits that we didn't double still starting from the
                // right but this time we'll start from the rightmost number with 
                // alternating digits
                var OriginalSum = 0;
                for (var y = CardLength - 1; y >= 0; y = y - 2)
                    OriginalSum = OriginalSum + int.Parse(cardNumber[y].ToString());

                // Perform the final calculation, if the sum Mod 10 results in 0 then
                // it's valid, otherwise its false.
                return (OriginalSum + CheckSum) % 10 == 0;
            }
            catch
            {
                return false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GoPay d = new GoPay();
            decimal price = 0;
            string purchaseType = Session["type"].ToString();
            int purchase = 0;
            string email = HttpContext.Current.User.Identity.Name;
            readers r = db.readers.SingleOrDefault(
                b => b.R_email == email);
            Comic c = null;
            if (Page.IsValid)
            {
                if (Session["purchase_cId"] != null)
                {
                    purchase = Int32.Parse(Session["purchase_cId"].ToString());
                    if (purchase != 0)
                    {
                        c = db.Comics.SingleOrDefault(
                            a => a.C_Id == purchase);
                    }
                }
                else
                {
                    Response.Redirect("~/error.aspx?err=The result cant be found");
                }
                if (r!=null)
                {
                    if (c != null && purchaseType == "Comic")
                    {

                    }
                    else if(c == null && purchaseType == "Vip")
                    {
                        if (r.R_isvip == true)
                        {
                            Session["purchase_cId"] = null;
                            Session["price"] = null;
                            Session["type"] = null;
                            Response.Redirect("~/error.aspx?err=You aldready purchased VIP");
                        }
                    }
                    else
                    {
                        Session["purchase_cId"] = null;
                        Session["price"] = null;
                        Session["type"] = null;
                        Response.Redirect("~/error.aspx?err=The result cant be found");
                    }
                    
                }
                else
                {
                    //redirect to the error page 
                    Response.Redirect("~/error.aspx?err=You didnt have the permission");
                }

                if (Session["price"] != null)
                {
                    price = decimal.Parse(Session["price"].ToString());
                }
                else
                {
                    //error page 
                    Response.Redirect("~/error.aspx?err=The result cant be found");
                }

                string message = d.pay(price,purchaseType,"Credit Card",purchase,r.R_Id);
                if (message.Equals("Success"))
                {
                    Response.Redirect("~/Reader/Payment/PaymentSuccess.aspx");

                }
                else
                {
                    //Error Page
                    Response.Redirect("~/error.aspx?err=Payment Error");
                }

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            string s = "";
            if (Session["purchase_cId"] != null)
            {
                s = Session["purchase_cId"].ToString();
            }
            else
            {
                s = "0";
            }
            if (s != "0")
            {
                Response.Redirect("/DisplayComic.aspx?cId=" + s);
            }
            else
            {
                Response.Redirect("/Vip.aspx");
            }
        }
    }
}