using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Classes;

namespace manhua.Admin
{
    public partial class AdminRegister : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void cvName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string NickName = args.Value;
            string errorMessage = Validation.usernameValidate(args.Value);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                cvName.ErrorMessage = errorMessage;
                args.IsValid = false;
            }
            
        }

        protected void cvPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string errorMessage = Validation.passwordValidate(args.Value);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                cvPassword.ErrorMessage = errorMessage;
                args.IsValid = false;
            }
        }

       

        protected void cvEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string errorMessage = Validation.emailValidate(args.Value);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                cvEmail.ErrorMessage = errorMessage;
                args.IsValid = false;
            }
            else if (db.users.Any(u => u.Email == args.Value))
            {
                cvEmail.ErrorMessage = "The email is been used";
                args.IsValid = false;
            }
        }

       

        protected void cvGender_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(args.Value))
            {
                cvGender.ErrorMessage = "Please choose the gender";
                args.IsValid = false;
            }
            else if (args.Value != "M" && args.Value != "F")
            {
                cvGender.ErrorMessage = "The gender is invalid";
                args.IsValid = false;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int randomId = 0;
                Random random = new Random();
                bool repeatId = false;
                String NickName = txtname.Text;
                string password = txtPassword.Text;
                string email = txtEmail.Text;
                string gender = rblGender.Text;

                do
                {
                    randomId = random.Next(10000, 9999999);
                    var p = db.readers.SingleOrDefault(
                        b => b.R_Id == randomId);
                    if (p == null) repeatId = true;
                } while (repeatId == false);


                var sourcePath = MapPath("~/pic/system/");
                var destPath = MapPath("~/pic/profile/");

                if (gender == "M")
                {
                    string fileName = "male.jpg";

                    string oldFileName = sourcePath + fileName;
                    string newFileName = destPath + randomId + ".jpg";
                    File.Copy(oldFileName, newFileName);

                }
                else
                {
                    string fileName = "female.jpg";

                    string oldFileName = sourcePath + fileName;
                    string newFileName = destPath + randomId + ".jpg";
                    File.Copy(oldFileName, newFileName);
                }



                admin r = new admin
                {
                    A_Id = randomId,
                    A_Nickname = NickName,
                    A_hash = Security.GetHash(password),
                    A_email = email,
                    A_gender = char.Parse(gender),
                    A_register_date = DateTime.Now
                };
                db.admins.InsertOnSubmit(r);
                db.SubmitChanges();

                Response.Redirect("~/RegisterSucess.aspx");
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Authentication/Register.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/home.aspx");
        }
    }
}