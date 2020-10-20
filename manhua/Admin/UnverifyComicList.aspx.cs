using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace manhua.Admin
{
    public partial class VerifyComic : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = HttpContext.Current.User.Identity.Name;
            admin am = db.admins.SingleOrDefault(a => a.A_email == email);
            if (am == null)
            {
                //Redirect to the error page
                //didnt have permission
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/home.aspx");
        }
    }
}