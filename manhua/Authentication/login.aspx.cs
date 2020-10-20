using manhua.Classes;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace manhua
{
    public partial class login : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/home.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string recaptcha = hfRecaptcha.Value;
            var IsCaptchaValid = RecaptchaClass3.Validate(recaptcha) == "true" ? true : false;
            if (IsCaptchaValid)
            {
                if (Page.IsValid)
                {

                    string email = txtName.Text;
                    string password = txtPassword.Text;
                    bool rememberMe = chkRememberMe.Checked;

                    // Login the user
                    user u = db.users.SingleOrDefault(
                        x => x.Email == email && x.Hash == Security.GetHash(password));

                    if (u != null)
                    {
                        if (u.Status == false)
                        {
                            if (Session["url"] != null)
                            {
                                string url = Session["url"].ToString();
                                Session["url"] = null;
                                Security.LoginUser(u.Nickname, u.Role, rememberMe, u.Email, url);
                            }
                            else
                            {
                                Security.LoginUser(u.Nickname, u.Role, rememberMe, u.Email, "");
                            }
                        }
                        else
                        {
                            cvNotMatched.ErrorMessage = "Your account is banned";
                            cvNotMatched.IsValid = false;

                        }

                    }
                    else
                    {
                        cvNotMatched.ErrorMessage = "[Password] and [Username] not matched";
                        cvNotMatched.IsValid = false;
                    }
                }
            }
            else
            {
                cvRecaptcha.ErrorMessage = "Recaptcha Failed..";
                cvRecaptcha.IsValid = false;
                Console.Write("Recaptcha maybe wrong");
            }


        }

        protected void cvNotMatched_ServerValidate(object source, ServerValidateEventArgs args)
        {

        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Authentication/login.aspx");
        }
    }
}