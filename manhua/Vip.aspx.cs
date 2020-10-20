using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace manhua
{
    public partial class Vip : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = HttpContext.Current.User.Identity.Name;
            if (!string.IsNullOrEmpty(email))
            {
                readers r = db.readers.SingleOrDefault(a => a.R_email == email);
                if (r != null)
                {
                    if (r.R_isvip)
                    {
                        btnDone.Visible = true;
                        btnDone.Enabled = false;
                        btnVip.Visible = false;
                    }
                }
                else
                {     //other role
                    btnVip.Visible = false;
                    btnDone.Visible = false;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/home.aspx");
        }

        protected void btnVip_Click(object sender, EventArgs e)
        {
            Session["type"] = "Vip";
            Session["purchase_cId"] = 0;
            Response.Redirect("~/reader/Payment/ChoiceCoP.aspx");
        }
    }
}