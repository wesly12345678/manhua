using System;
using System.Linq;
using System.Web;

namespace manhua
{
    public partial class ChoiceCoP : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = HttpContext.Current.User.Identity.Name;
            readers r = db.readers.SingleOrDefault(a => a.R_email == email);
            string type = "", cId = "";
            decimal price = 0;
            if (Session["type"] != null)
            {
                 type = Session["type"].ToString();
            }

            if (Session["purchase_cId"] != null)
            {
                cId = Session["purchase_cId"].ToString();
            }
            if (r != null)
            {
                if (!string.IsNullOrEmpty(type))
                {
                    if (type == "Vip")
                    {
                        if (r.R_isvip != true)
                        {
                            price = Convert.ToDecimal(199.99);
                            Session["price"] = price.ToString();
                            lblAmount.Text = price.ToString();
                            lblComicName.Text = "None";
                            lblName.Text = r.R_NickName;
                            lblType.Text = type;
                        }
                        else
                        {
                            //Error page because got vip le
                            Session["purchase_cId"] = null;
                            Session["price"] = null;
                            Session["type"] = null;
                            Response.Redirect("~/home.aspx");
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(cId))
                        {
                            int comicId = Int32.Parse(cId);
                            Comic c = db.Comics.SingleOrDefault(a => a.C_Id == comicId);
                            if (c != null)
                            {
                                if (r.R_isvip == true)
                                {
                                    price = c.C_Price * Convert.ToDecimal(0.9);
                                }
                                else
                                {
                                    price = c.C_Price;
                                }
                                Session["price"] = price.ToString();
                                lblAmount.Text = price.ToString();
                                lblComicName.Text = c.C_Title;
                                lblName.Text = r.R_NickName;
                                lblType.Text = type;
                            }
                            else
                            {
                                //Didnt have the comic in the database
                                Session["purchase_cId"] = null;
                                Session["price"] = null;
                                Session["type"] = null;
                                Response.Redirect("~/home.aspx");
                            }
                        }
                        else
                        {
                            //Didnt have the comic from session
                            Session["purchase_cId"] = null;
                            Session["price"] = null;
                            Session["type"] = null;
                            Response.Redirect("~/home.aspx");
                        }
                    }
                }
                else
                {
                    //Error page becasue didnt have the type
                    Session["purchase_cId"] = null;
                    Session["price"] = null;
                    Session["type"] = null;
                    Response.Redirect("~/home.aspx");

                }
            }
            else
            {
                Session["purchase_cId"] = null;
                Session["price"] = null;
                Session["type"] = null;
                Response.Redirect("~/home.aspx");
                //If the user is not the reader
            }
        }

        protected void imgBtn_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (Session["type"] == null || Session["purchase_cId"] == null || Session["price"] == null)
            {
                //
                Response.Redirect("~/home.aspx");
            }

            string email = HttpContext.Current.User.Identity.Name;
            string type = Session["type"].ToString();
            string comicId = Session["purchase_cId"].ToString();
            string price = Session["price"].ToString();
            readers r = db.readers.SingleOrDefault(a => a.R_email == email);
            Comic c = db.Comics.SingleOrDefault(a => a.C_Id.ToString() == comicId);
            decimal amount = decimal.Parse(price);
            string name = "", itemName = "";
            if (r != null)
            {
                if (c != null && type == "Comic")
                {
                    itemName = c.C_Title;
                }
                else if (c == null && type == "Vip")
                {
                    itemName = "Vip";
                }
                else
                {
                    //error page
                    Response.Redirect("~/home.aspx");
                }
                //Pay pal process Refer for what are the variable are need to send http://www.paypalobjects.com/IntegrationCenter/ic_std-variable-ref-buy-now.html
                var redirectUrl = "";
                //Mention URL to redirect content to paypal site
                redirectUrl += "https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&business=comic6@gmail.com";
                redirectUrl += "&first_name=" + name;
                //Product Name
                redirectUrl += "&item_name=" + itemName;
                //Product Amount
                redirectUrl += "&amount=" + amount;
                redirectUrl += "&currency_code=MYR";
                //Business contact paypal EmailID
                redirectUrl += "&business=comic6@gmail.com";
                //Shipping charges if any, or available or using shopping cart system
                //redirectUrl += "&shipping=0";
                //Handling charges if any, or available or using shopping cart system
                //redirectUrl += "&handling=0";
                //Tax charges if any, or available or using shopping cart system
                //redirectUrl += "&tax=0";
                //Quantiy of product, Here statically added quantity 1
                redirectUrl += "&quantity=" + 1;
                //If transactioin has been successfully performed, redirect SuccessURL page- this page will be designed by developer
                redirectUrl += "&return=http://localhost:57613//reader/Payment/ProcessPayment.aspx";
                //If transactioin has been failed, redirect FailedURL page- this page will be designed by developer
                redirectUrl += "&cancel_return=http://localhost:57613//reader/Payment/PaymentFailed.aspx";
                Response.Redirect(redirectUrl);
            }
            else
            {
                //when the payment is not made by the reader
                Response.Redirect("~/home.aspx");
            }

        }
    }
}