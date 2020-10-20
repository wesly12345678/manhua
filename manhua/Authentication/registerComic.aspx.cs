using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Classes;

namespace manhua
{
    public partial class registerComic : System.Web.UI.Page
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

        protected void cvDob_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string errorMessage = Validation.dateValid(args.Value);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                cvDob.ErrorMessage = errorMessage;
                args.IsValid = false;
            };
        }

        protected void cvEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string errorMessage = Validation.emailValidate(args.Value);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                cvEmail.ErrorMessage = errorMessage;
                args.IsValid = false;
            }
            else if (db.users.Any(a => a.Email == args.Value))
            {
                cvEmail.ErrorMessage = "The email has been used";
                args.IsValid = false;
            }
        }

        protected void cvPhoneNum_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string errorMessage = Validation.phoneNumber(args.Value);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                cvPhoneNum.ErrorMessage = errorMessage;
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
                string phone = txtPhoneNumber.Text;
                string gender = rblGender.Text;
                string newFormat = DateTime.ParseExact(TxtDob.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                .ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dat = DateTime.Parse(newFormat);
                do
                {
                    randomId = random.Next(10000, 9999999);
                    var p = db.ComicCreators.SingleOrDefault(
                        b => b.CC_Id == randomId);
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
                ComicCreator r = new ComicCreator
                {
                    CC_Id = randomId,
                    CC_NickName = NickName,
                    CC_hash = Security.GetHash(password),
                    CC_email = email,
                    CC_phone = phone,
                    CC_gender = char.Parse(gender),
                    CC_birth_date = dat,
                    CC_register_date = DateTime.Now
                };
                db.ComicCreators.InsertOnSubmit(r);
                db.SubmitChanges();

                Response.Redirect("~/Authentication/login.aspx");
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Authentication/registerComic.aspx");
        }
    }
}