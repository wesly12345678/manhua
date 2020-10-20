using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace manhua
{
    public partial class masterPage : System.Web.UI.MasterPage
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = HttpContext.Current.User.Identity.Name;
            user u = db.users.SingleOrDefault(a => a.Email == email);
            if (u != null)
            {
                if (u.Role == "Customer")
                {
                    readers r = db.readers.SingleOrDefault(a => a.R_email == u.Email);
                    imgProfile.Visible = true;
                    imgProfile.ImageUrl = "~/pic/profile/" + r.R_Id + ".jpg";
                }
                else if (u.Role == "admin")
                {
                    admin r = db.admins.SingleOrDefault(a => a.A_email == u.Email);
                    imgProfile.Visible = true;
                    imgProfile.ImageUrl = "~/pic/profile/" + r.A_Id + ".jpg";
                }
                else if (u.Role == "comic")
                {
                    ComicCreator r = db.ComicCreators.SingleOrDefault(a => a.CC_email == u.Email);
                    imgProfile.Visible = true;
                    imgProfile.ImageUrl = "~/pic/profile/" + r.CC_Id + ".jpg";
                }
                else
                {
                    imgProfile.Visible = false;
                }
            }
            else
            {
                imgProfile.Visible = false;
            }

        }
    }
}