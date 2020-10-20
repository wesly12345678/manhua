using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace manhua
{
    public partial class PaymentHistory : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = HttpContext.Current.User.Identity.Name;
            readers r = db.readers.SingleOrDefault(a => a.R_email == email);
            if (r != null)
            {
                ldsPayment.Where = "R_Id = " + r.R_Id;
            }
            else
            {
                //error page
                Response.Redirect("~/error.aspx?err=You didnt have the permission");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/home.aspx");
        }

    }
}