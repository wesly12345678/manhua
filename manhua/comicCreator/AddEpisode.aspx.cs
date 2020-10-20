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
    public partial class AddEpisode : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = Request.QueryString["comicId"];
                string email = HttpContext.Current.User.Identity.Name;
                ComicCreator f = db.ComicCreators.SingleOrDefault(x => x.CC_email == email);
                if (f != null)
                {
                    if (Int32.TryParse(query,out int rem))
                    {
                        int comicId = int.Parse(query);
                        //int comicId = 98988572;
                        Comic c = db.Comics.SingleOrDefault(x => x.CC_Id == f.CC_Id && x.C_Id == comicId);
                        if (c == null)
                        {
                            Response.Redirect("~/error.aspx?err=You didnt have permission");
                            //Error page (U didnt have permission to add episode on this comic)
                        }
                    }
                    else
                    {
                        Response.Redirect("~/error.aspx?err=Result cant be found");
                        //if didnt have query
                    }
                }
                else
                {
                    Response.Redirect("~/error.aspx?err=You didnt have permission");
                    //Redirect to error page
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
        protected void cvEpisode_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string errorMessage = Validation.intValidated(args.Value, "Episode number");
            string query = Request.QueryString["comicId"];
            int comicId = Int32.Parse(query);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                cvEpisode.ErrorMessage = errorMessage;
                args.IsValid = false;
            }else if (db.Episodes.Any(a => a.C_Id == comicId && a.E_Id == Int32.Parse(args.Value)))
            {
                cvEpisode.ErrorMessage = "Cant add same episode number";
                args.IsValid = false;
            }
        }
        protected void cvPageNum_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string errorMessage = Validation.intValidated(args.Value, "Page number");
            if (!string.IsNullOrEmpty(errorMessage))
            {
                cvPageNum.ErrorMessage = errorMessage;
                args.IsValid = false;
            }
        }
        protected void cvImage_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var pattern = new Regex(@".+\.(jpg|png|jpeg)$", RegexOptions.IgnoreCase);

            if (string.IsNullOrEmpty(args.Value))
            {
                cvFuImage.ErrorMessage = "Please choose image";
                args.IsValid = false;
            }
            else if (!pattern.IsMatch(args.Value))
            {
                args.IsValid = false;
                cvFuImage.ErrorMessage = "Only JPG and PNG are allowed for [Photo]";
            }
            else
            {
                if (cvPageNum.IsValid == true)
                {
                    int number = int.Parse(txtPageNum.Text);
                    if (number != fuImage.PostedFiles.Count)
                    {
                        cvFuImage.ErrorMessage = "The page numbers not equal with number of images uploaded";
                        args.IsValid = false;
                    }
                }
                else
                {
                    cvFuImage.ErrorMessage = "Page number is needed before upload image";
                    args.IsValid = false;
                }

            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int ccId = 0;
            string query = Request.QueryString["comicId"];
            string name = HttpContext.Current.User.Identity.Name;
            ComicCreator f = db.ComicCreators.SingleOrDefault(x => x.CC_NickName.ToString() == name);
            if (f != null)
            {
                ccId = f.CC_Id;
            }
            if (Page.IsValid)
            {
                int pageNum = int.Parse(txtPageNum.Text);
                int comicId = int.Parse(query);
                //int comicId = 98988572;
                int episode = int.Parse(txtEpisode.Text);
                //Create new folder
                string p = "~/pic/comic/" + query + "/" + episode + "/";
                var folder = Server.MapPath(p);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                int i = 0;
                foreach (HttpPostedFile File in fuImage.PostedFiles)
                {
                    ++i;
                    File.SaveAs(folder + i + ".jpg");
                }

                Episode c = new Episode
                {
                    E_Id = episode,
                    E_Title = txtTitle.Text,
                    E_PageNumber = pageNum,
                    E_DateUpload = DateTime.Now,
                    E_Status = 'U',
                    C_Id = comicId
                };
                db.Episodes.InsertOnSubmit(c);
                db.SubmitChanges();
                Response.Redirect("~/DisplayComic.aspx?cId="+query);
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/home.aspx");
        }
    }
}