using manhua.Classes;
using System;
using System.Linq;
using System.Web;

namespace manhua.reader.Payment
{
    public partial class ProcessPayment : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            GoPay d = new GoPay();
            decimal price = 0;
            string purchaseType = Session["type"].ToString();
            int purchase = 0;
            string email = HttpContext.Current.User.Identity.Name;
            readers r = db.readers.SingleOrDefault(
                b => b.R_email == email);
            Comic c = null;

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
            if (r != null)
            {
                if (c != null && purchaseType == "Comic")
                {

                }
                else if (c == null && purchaseType == "Vip")
                {
                    if (r.R_isvip == true)
                    {
                        Session["purchase_cId"] = null;
                        Session["price"] = null;
                        Session["type"] = null;
                        Response.Redirect("~/error.aspx?err=You already purchased VIP");
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
                Response.Redirect("~/home.aspx");
            }

            string message = d.pay(price, purchaseType, "Paypal", purchase, r.R_Id);
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
}