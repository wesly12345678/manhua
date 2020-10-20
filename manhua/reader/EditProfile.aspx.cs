using Helpers;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace manhua.Reader
{
    public partial class EditProfile : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private char gender;
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // Initial page load
            {
                string name = HttpContext.Current.User.Identity.Name;
                readers f = db.readers.SingleOrDefault(x => x.R_email == name);

                if (f != null)
                {

                    string n = Convert.ToString(f.R_phone);
                    txtPhoneNumber.Text = n;
                    hfId.Value = f.R_Id.ToString();
                    txtname.Text = f.R_NickName;
                    txtPassword.Text = f.R_hash;
                    txtEmail.Text = f.R_email;
                    gender = (char)f.R_gender;
                    id = f.R_Id;
                }
                else
                {
                    Response.Redirect("~/error.aspx?err=You didnt have the permission");
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string email = txtEmail.Text;

                readers f = db.readers.SingleOrDefault(x => x.R_email == email);
                if (f != null)
                {
                    int id = f.R_Id;
                    var path = MapPath("~/pic/profile/");
                    string password = txtPassword.Text;


                    string phone = txtPhoneNumber.Text;

                    if (fuImage.HasFile)
                    {
                        File.Delete(path + id + ".jpg");
                        var img = new SimpleImage(fuImage.FileContent);
                        img.SaveAs(path + id + ".jpg");
                    }


                    f.R_NickName = txtname.Text;
                    f.R_hash = Security.GetHash(password);
                    //f.R_email = email;
                    f.R_phone = phone;
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