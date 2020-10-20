using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace manhua
{
    public partial class Comic1 : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string category = Request.QueryString["ca"];
                if (string.IsNullOrEmpty(category))
                {
                    lblCategory.Text = "";
                    lblCategory.Visible = false;
                }
                else
                {
                    Category c = db.Categories.SingleOrDefault(
                        a => a.Ca_Id == category);
                    if (c != null)
                    {
                        lblCategory.Visible = true;
                        lblCategory.Text = "("+c.Ca_Name + ")";
                    }
                    
                }
            }
        }
    }
}