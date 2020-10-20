using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace manhua
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Logout the user
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                Session["url"] = null;
                Session["purchase_id"] = null;
                Session["type"] = null;
                Session["price"] = null;
                // Response.Redirect("Logout.aspx");
                Response.Redirect("~/home.aspx");
            }

        }
    }
}