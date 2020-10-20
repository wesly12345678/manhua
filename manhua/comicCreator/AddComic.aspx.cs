using Helpers;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Classes;


namespace manhua.comicCreator
{
    public partial class AddComic : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string email = HttpContext.Current.User.Identity.Name;
                ComicCreator f = db.ComicCreators.SingleOrDefault(x => x.CC_email.ToString() == email);
                if (f != null) //
                {
                    for (int i = 1; i < 22; i++)
                    {
                        ddlAgeRestrt.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    }
                }
                else
                {
                    Response.Redirect("~/error.aspx?err=You didnt have permission");
                    //redirect to the error page
                }
               
            }
        }

        protected void cvTitle_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string errorMessage = Validation.titleValidate(args.Value);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                cvTitle.ErrorMessage = errorMessage;
                args.IsValid = false;
            }
        }

        protected void cvDesc_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string errorMessage = Validation.description(args.Value);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                cvDesc.ErrorMessage = errorMessage;
                args.IsValid = false;
            }
        }

        protected void cvCategory_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(args.Value))
            {
                args.IsValid = false;
                cvCategory.ErrorMessage = "Please choose one category";
            }
            else if(!db.Categories.Any(a=>a.Ca_Id == args.Value))
            {
                args.IsValid = false;
                cvCategory.ErrorMessage = "Please choose the category only inside the dropdownlist";
            }

        }

        protected void cvPrice_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string errorMessage = Validation.priceValidate(args.Value);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                cvPrice.ErrorMessage = errorMessage;
                args.IsValid = false;
            }
        }

        protected void cvAgeRestrt_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string errorMessage = Validation.age(args.Value);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                cvAgeRestrt.ErrorMessage = errorMessage;
                args.IsValid = false;
            }
        }

        protected void cvVipView_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (rblVipView.SelectedIndex != 0 && rblVipView.SelectedIndex != 1)
            {
                cvVipView.ErrorMessage = "Please choose true or false";
                args.IsValid = false;
            }
        }
        protected void cvFuImage_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var pattern = new Regex(@".+\.(jpg|png|jpeg)$", RegexOptions.IgnoreCase);

            if (string.IsNullOrEmpty(args.Value))
            {
                args.IsValid = false;
                cvFuImage.ErrorMessage = "No picture chosen";
            }
            else if (!pattern.IsMatch(args.Value))
            {
                args.IsValid = false;
                cvFuImage.ErrorMessage = "Only JPG and PNG are allowed for [Photo]";
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int randomId;
            Random random = new Random();
            bool repeatId = false;
            string email = HttpContext.Current.User.Identity.Name;
            ComicCreator f = db.ComicCreators.SingleOrDefault(x => x.CC_email.ToString() == email);
            int id = f.CC_Id;
            if (Page.IsValid)
            {
                do
                {
                    randomId = random.Next(100000, 99999999);
                    var b = db.Comics.SingleOrDefault(
                        cc => cc.C_Id == randomId);
                    if (b == null) repeatId = true;
                } while (repeatId == false);

                string p = "~/pic/comic/" + randomId + "/";
                var folder = Server.MapPath(p);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                var img = new SimpleImage(fuImage.FileContent);
                img.SaveAs(folder + randomId + ".jpg");

                Comic c = new Comic
                {
                    C_Id = randomId,
                    C_Title = txtTitle.Text,
                    C_Description = txtDescription.Text,
                    C_Price = decimal.Parse(txtPrice.Text),
                    C_Publish_Date = DateTime.Now,
                    C_Status = 'U',
                    C_category = ddlCategory.SelectedValue,
                    C_AgeRestrict = int.Parse(ddlAgeRestrt.SelectedValue),
                    C_IsForVip = bool.Parse(rblVipView.SelectedValue),
                    CC_Id = id
                };
                db.Comics.InsertOnSubmit(c);
                db.SubmitChanges();
                Response.Redirect("~/Comic.aspx");
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/home.aspx");
        }
    }
}