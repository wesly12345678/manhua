using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace manhua.Payment
{
    public partial class PaymentSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = "";
            if (Session["purchase_cId"] != null)
            {
                id = Session["purchase_cId"].ToString();
                hfId.Value = id;
            }
            Session["purchase_cId"] = null;
            Session["price"] = null;
            Session["type"] = null;

        }
    }
}