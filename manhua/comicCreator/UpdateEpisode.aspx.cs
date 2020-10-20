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
    public partial class UpdateEpisode : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string eId = Request.QueryString["eId"];
                string query = Request.QueryString["cId"];
                string email = HttpContext.Current.User.Identity.Name;
                ComicCreator f = db.ComicCreators.SingleOrDefault(x => x.CC_email == email);
                if (f != null)
                {
                    if (Int32.TryParse(query, out int rem) && Int32.TryParse(eId,out int r))
                    {
                        int comicId = rem;
                        int episode = r;
                        Comic c = db.Comics.SingleOrDefault(x => x.CC_Id == f.CC_Id && x.C_Id == comicId);
                        Episode ep = db.Episodes.SingleOrDefault(a => a.C_Id == comicId && a.E_Id == episode);
                        if (c == null)
                        {
                            Response.Redirect("~/error.aspx?err=You didnt have permission");
                            //Error page (U didnt have permission to add episode on this comic)
                        }
                        else
                        {
                            if (ep != null)
                            {
                                hfEpisode.Value = ep.E_Id.ToString();
                                hfComicId.Value = ep.C_Id.ToString();
                                hfPageNum.Value = ep.E_PageNumber.ToString();
                                txtEpisode.Text = ep.E_Id.ToString();
                                txtPageNum.Text = ep.E_PageNumber.ToString();
                                txtTitle.Text = ep.E_Title;
                            }
                            else
                            {
                                Response.Redirect("~/error.aspx?err=The result cant be found");
                                //Didnt have this episode
                            }

                        }
                    }
                    else
                    {
                        Response.Redirect("~/error.aspx?err=The result cant be found");
                        //if didnt have query
                    }
                }
                else
                {
                    Response.Redirect("~/error.aspx?err=You didnt have the permission");
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
            if (!string.IsNullOrEmpty(errorMessage))
            {
                cvEpisode.ErrorMessage = errorMessage;
                args.IsValid = false;
            }
            //Need to validate the episode is havent key in ?
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
            string eId = Request.QueryString["eId"];
            string query = Request.QueryString["cId"];
            var pattern = new Regex(@".+\.(jpg|png|jpeg)$", RegexOptions.IgnoreCase);
            if (string.IsNullOrEmpty(args.Value)) // if the image is empty
            {
                int episodeId = Int32.Parse(eId);
                int comicId = Int32.Parse(query);
                Episode ep = db.Episodes.SingleOrDefault(a => a.E_Id == episodeId && a.C_Id == comicId);
                if (ep.E_PageNumber.ToString() != txtPageNum.Text)  // the episode number not same with the page number
                {
                    cvFuImage.ErrorMessage = "Please choose image";
                    args.IsValid = false;
                }
                //else if(!string.IsNullOrEmpty(txtPageNum.Text) && number > 0 && fuImage.FileName.Length == 0)
            }
            else if (!pattern.IsMatch(args.Value))
            {
                args.IsValid = false;
                cvFuImage.ErrorMessage = "Only JPG and PNG are allowed for [Photo]";
            }
            else // if the image got
            {
                if (cvPageNum.IsValid == true)  //page number is valid
                {
                    int number = int.Parse(txtPageNum.Text);
                    if (number != fuImage.PostedFiles.Count)  // got change the number
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
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = Request.QueryString["cId"];
            string eId = Request.QueryString["eId"];
            string email = HttpContext.Current.User.Identity.Name;
            ComicCreator f = db.ComicCreators.SingleOrDefault(x => x.CC_email == email);
            if (Page.IsValid)
            {
                int episodeId = int.Parse(eId);
                int pageNum = int.Parse(txtPageNum.Text);
                int comicId = int.Parse(query);
                int episode = int.Parse(txtEpisode.Text);
                //Create new folder
                string p = "~/pic/comic/" + query + "/" + episode + "/";
                var folder = Server.MapPath(p);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                int i = 0;
                //Delete file first
                Episode ep = db.Episodes.SingleOrDefault(a => a.C_Id == comicId && a.E_Id == episodeId);
                int count = ep.E_PageNumber;
                //If no pic
                if (fuImage.HasFiles)  // if the got the pic
                {
                    for(int j =1;j<=count+1; j++)
                    {
                        File.Delete(folder + j + ".jpg");
                    }
                    foreach (HttpPostedFile File in fuImage.PostedFiles)
                    {
                        ++i;
                        File.SaveAs(folder + i + ".jpg");
                    }
                }
                ep.E_Title = txtTitle.Text;
                ep.E_PageNumber = pageNum;
                db.SubmitChanges();
                Response.Redirect("~/DisplayComic.aspx?cId=" + query);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string query = Request.QueryString["cId"];
            string eId = Request.QueryString["eId"];
            string email = HttpContext.Current.User.Identity.Name;
            ComicCreator f = db.ComicCreators.SingleOrDefault(x => x.CC_email == email);
            int episodeId = int.Parse(eId);
            int comicId = int.Parse(query);
            Episode ep = db.Episodes.SingleOrDefault(a => a.E_Id == episodeId && a.C_Id == comicId);
            if (ep != null)
            {
                string p = "~/pic/comic/" + query + "/" + eId + "/";
                var folder = Server.MapPath(p);
                int count = ep.E_PageNumber;
                for (int j = 1; j <= count + 1; j++)
                {
                    File.Delete(folder + j + ".jpg");
                }
                if (Directory.Exists(folder))
                {
                    Directory.Delete(folder);
                }
                db.Episodes.DeleteOnSubmit(ep);
                db.SubmitChanges();
                Response.Redirect("~/DisplayComic.aspx?cId=" + query);

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/home.aspx");
        }
    }
}