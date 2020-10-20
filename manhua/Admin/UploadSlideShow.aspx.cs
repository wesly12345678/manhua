using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace manhua.Admin
{
    public partial class UploadSlideShow : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int randomId = 0;
                Random random = new Random();
                bool repeatId = false;
                var path = MapPath("~/pic/slideshow/");
                do
                {
                    randomId = random.Next(10000, 9999999);
                    var pro = db.slideshows.SingleOrDefault(
                        b => b.S_Id == randomId);
                    if (pro == null) repeatId = true;
                } while (repeatId == false);
                var img = new SimpleImage(fuPicture.FileContent);
                img.SaveAs(path + randomId + ".jpg");
                slideshow s = new slideshow
                {
                    S_Id = randomId,
                    S_Title = txtTitle.Text,
                    S_link = txtLink.Text
                };
                db.slideshows.InsertOnSubmit(s);
                db.SubmitChanges();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/home.aspx");
        }

        protected void cvPicture_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var pattern = new Regex(@".+\.(jpg|png|jpeg)$", RegexOptions.IgnoreCase);

            if (string.IsNullOrEmpty(args.Value))
            {
                args.IsValid = false;
                cvPicture.ErrorMessage = "No picture chosen";
            }
            else if (!pattern.IsMatch(args.Value))
            {
                args.IsValid = false;
                cvPicture.ErrorMessage = "Only JPG and PNG are allowed for [Photo]";
            }
        }
    }
}