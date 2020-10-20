using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace manhua
{
    public partial class FavouriteList : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string email = HttpContext.Current.User.Identity.Name;
                readers r = db.readers.SingleOrDefault(a => a.R_email == email);
                if (r != null)
                {
                    ldsFavourite.Where = @"R_Id ==" + r.R_Id;
                }
                else
                {
                    Response.Redirect("~/error.aspx?err=You didnt have the permission");
                }
            }
            
        }
    }
}