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
    public partial class UpdateComicInfo : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string email = HttpContext.Current.User.Identity.Name;
                string cid = Request.QueryString["cId"];

                if (string.IsNullOrEmpty(cid))
                {
                    //Redirect the page to error page
                }
                else
                {
                    int cId = Int32.Parse(cid);
                    ComicCreator f = db.ComicCreators.SingleOrDefault(x => x.CC_email.ToString() == email);
                    if (f != null)
                    {
                        Comic c = db.Comics.SingleOrDefault(a => a.C_Id == cId && a.CC_Id == f.CC_Id);
                        if (c != null)
                        {
                            for (int i = 1; i < 22; i++)
                            {
                                ddlAgeRestrt.Items.Add(new ListItem(i.ToString(), i.ToString()));
                            }

                            txtTitle.Text = c.C_Title;
                            txtDescription.Text = c.C_Description;
                            txtPrice.Text = c.C_Price.ToString();
                            rblVipView.SelectedValue = c.C_IsForVip.ToString();
                            ddlCategory.SelectedValue = c.C_category;
                            ddlAgeRestrt.SelectedValue = c.C_AgeRestrict.ToString();
                        }
                        else
                        {
                            Response.Redirect("~/error.aspx?err=The result cant be found");
                            //Redirect 
                        }
                    }
                    else
                    {
                        Response.Redirect("~/error.aspx?err=You didnt have permission");
                        //redirect to the error page
                    }
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
            else if (!db.Categories.Any(a => a.Ca_Id == args.Value))
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

            if (!string.IsNullOrEmpty(args.Value))
            {
                if(!pattern.IsMatch(args.Value))
                {
                    args.IsValid = false;
                    cvFuImage.ErrorMessage = "Only JPG and PNG are allowed for [Photo]";
                }
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string email = HttpContext.Current.User.Identity.Name;
            ComicCreator f = db.ComicCreators.SingleOrDefault(x => x.CC_email.ToString() == email);
            string cid = Request.QueryString["cId"];
            if (Page.IsValid)
            {
                if (!string.IsNullOrEmpty(cid))
                {
                    int cId = Int32.Parse(cid);
                    string p = "~/pic/comic/" + cid + "/";
                    var folder = Server.MapPath(p);
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    if (fuImage.HasFile)
                    {
                        File.Delete(folder + cid + ".jpg");
                        var img = new SimpleImage(fuImage.FileContent);
                        img.SaveAs(folder + cid + ".jpg");
                    }
                    Comic c = db.Comics.SingleOrDefault(a => a.C_Id == cId);
                    c.C_Title = txtTitle.Text;
                    c.C_Description = txtDescription.Text;
                    c.C_Price = decimal.Parse(txtPrice.Text);
                    c.C_category = ddlCategory.SelectedValue;
                    c.C_AgeRestrict = Int32.Parse(ddlAgeRestrt.SelectedValue);
                    c.C_IsForVip = bool.Parse(rblVipView.SelectedValue);

                    db.SubmitChanges();
                    Response.Redirect("~/DisplayComic.aspx?cId=" + cid);
                }
                else
                {
                    Response.Redirect("~/error.aspx?err=The result cant be found");

                    //redirect to the error page
                }

            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string email = HttpContext.Current.User.Identity.Name;
            ComicCreator f = db.ComicCreators.SingleOrDefault(x => x.CC_email.ToString() == email);
            string cid = Request.QueryString["cId"];
            if (f != null)
            {
                if (Int32.TryParse(cid, out int o))
                {
                    Comic c = db.Comics.SingleOrDefault(a => a.C_Id == o && a.CC_Id == f.CC_Id);
                    if (c != null)
                    {
                        c.C_CantViewable = true;
                        db.SubmitChanges();
                        Response.Redirect("~/Profile.aspx?creator_id=" + f.CC_Id);
                    }
                    else //other comic creator delete the files
                    {
                        Response.Redirect("~/error.aspx?err=You didnt have permission");
                    }
                }
                else
                {
                    Response.Redirect("~/error.aspx?err=The result cant be found");
                    //Error due to didnt have comic id in query string
                }

            }
            else //Not the comic creator
            {
                Response.Redirect("~/error.aspx?err=You didnt have permission");
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/home.aspx");
        }
    }
}