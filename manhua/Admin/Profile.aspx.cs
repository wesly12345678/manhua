using Helpers;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace manhua.Admin
{
    public partial class Profile : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        private char gender;
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // Initial page load
            {
                string name = HttpContext.Current.User.Identity.Name;
                admin f = db.admins.SingleOrDefault(x => x.A_email.ToString() == name);

                if (f != null)
                {



                    hfId.Value = f.A_Id.ToString();
                    txtname.Text = f.A_Nickname;
                    txtPassword.Text = f.A_hash;
                    txtEmail.Text = f.A_email;
                    gender = (char)f.A_gender;
                    rblGender.SelectedValue = gender.ToString();
                    id = f.A_Id;

                }
                else
                {
                    Response.Redirect("../home.aspx");
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string email = txtEmail.Text;
                admin f = db.admins.SingleOrDefault(x => x.A_email == email);
                if (f != null)
                {
                    int id = f.A_Id;
                    var path = MapPath("~/pic/profile/");
                    string password = txtPassword.Text;


                    if (fuImage.HasFile)
                    {
                        File.Delete(path + id + ".jpg");
                        var img = new SimpleImage(fuImage.FileContent);
                        img.SaveAs(path + id + ".jpg");
                    }

                    f.A_Nickname = txtname.Text;
                    f.A_hash = Security.GetHash(password);
                    //f.A_email = email;
                    f.A_gender = Char.Parse(rblGender.SelectedValue);

                    db.SubmitChanges();
                };



                Response.Redirect("../home.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/home.aspx");
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