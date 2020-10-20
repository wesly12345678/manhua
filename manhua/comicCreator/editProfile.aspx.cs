using Helpers;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace manhua.comicCreator
{
    public partial class editProfile : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private char gender;
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // Initial page load
            {
                string email = HttpContext.Current.User.Identity.Name;
                ComicCreator f = db.ComicCreators.SingleOrDefault(x => x.CC_email == email);

                if (f != null)
                {

                    txtPhoneNumber.Text = f.CC_phone;
                    hfId.Value = f.CC_Id.ToString();
                    txtname.Text = f.CC_NickName;
                    txtPassword.Text = f.CC_hash;
                    txtEmail.Text = f.CC_email;
                    gender = (char)f.CC_gender;
                    id = f.CC_Id;
                }
                else
                {
                    Response.Redirect("~/error.aspx?err=You didnt have permission");
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string email = txtEmail.Text;
                ComicCreator f = db.ComicCreators.SingleOrDefault(x => x.CC_email == email);
                if (f != null)
                {
                    int id = f.CC_Id;
                    string name = txtname.Text;
                    string password = txtPassword.Text;
                    var path = MapPath("~/pic/profile/");
                    string phone = txtPhoneNumber.Text;
                    int n = Convert.ToInt32(phone);
                    if (fuImage.HasFile)
                    {
                        File.Delete(path + id + ".jpg");
                        var img = new SimpleImage(fuImage.FileContent);
                        img.SaveAs(path + id + ".jpg");
                    }


                    f.CC_NickName = txtname.Text;
                    f.CC_hash = Security.GetHash(password);
                    //f.CC_email = email;
                    f.CC_phone = phone;
                    db.SubmitChanges();
                };



                Response.Redirect("~/home.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/home.aspx");
        }

        protected void cvFuImage_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var pattern = new Regex(@".+\.(jpg|png|jpeg)$", RegexOptions.IgnoreCase);

            if (!string.IsNullOrEmpty(args.Value))
            {
                if (!pattern.IsMatch(args.Value))
                {
                    args.IsValid = false;
                    cvFuImage.ErrorMessage = "Only JPG and PNG are allowed for [Photo]";
                }
            }
        }
    }
}