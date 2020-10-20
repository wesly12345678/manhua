using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace manhua.comicCreator
{
    public partial class ViewEpisode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            if (!IsPostBack)
            {
                string email = HttpContext.Current.User.Identity.Name;
                string cId = Request.QueryString["cId"];
                string eId = Request.QueryString["eId"];
                ComicCreator cc = db.ComicCreators.SingleOrDefault(a => a.CC_email == email);
                readers r = db.readers.SingleOrDefault(a => a.R_email == email);
                admin ad = db.admins.SingleOrDefault(a => a.A_email == email);
                if (!string.IsNullOrEmpty(email) || int.TryParse(cId,out int o) || Int32.TryParse(eId,out int p))
                {
                    int c_id = Int32.Parse(cId);
                    int e_id = Int32.Parse(eId);
                    Episode ep = db.Episodes.SingleOrDefault(
                    a => a.E_Id == e_id && a.C_Id == c_id);
                    Comic com = db.Comics.SingleOrDefault(
                    a => a.C_Id == c_id);
                    if (ep != null)
                    {
                        string path = Server.MapPath("/pic/comic/");
                        int success = 0;
                        for (int i = 0; i <= ep.E_PageNumber; i++)
                        {
                            string pageEpisode = path + "/" + ep.C_Id + "/" + ep.E_Id + "/" + i + ".jpg";
                            if (File.Exists(pageEpisode))
                            {
                                success++;
                            }

                        }
                        if (success == ep.E_PageNumber)
                        {
                            hfEpisode.Value = ep.E_Id.ToString();
                            hfPageNum.Value = ep.E_PageNumber.ToString();
                            hfComicId.Value = ep.C_Id.ToString();
                        }
                        if (com != null)
                        {
                            if(r!=null)
                            {
                                if(r.R_isvip == true && com.C_IsForVip == true)
                                {
                                    //got purchased
                                    if(!db.Purchaseds.Any(a=>a.R_Id == r.R_Id && a.C_Id == com.C_Id))
                                    {
                                        if (ep.E_Id > 5)
                                        {
                                            Response.Redirect("~/error.aspx?err=You didnt have the permission");
                                        }
                                    }
                                }else if(r.R_isvip == false && com.C_IsForVip == true)
                                {
                                    Response.Redirect("~/error.aspx?err=You didnt have the permission");
                                }
                                else if(r.R_isvip == true && com.C_IsForVip == false)
                                {
                                    if (!db.Purchaseds.Any(a => a.R_Id == r.R_Id && a.C_Id == com.C_Id))
                                    {
                                        if (ep.E_Id > 5)
                                        {
                                            Response.Redirect("~/error.aspx?err=You didnt have the permission");
                                        }
                                    }
                                }
                                else
                                {
                                    if (!db.Purchaseds.Any(a => a.R_Id == r.R_Id && a.C_Id == com.C_Id))
                                    {
                                        if (ep.E_Id > 5)
                                        {
                                            Response.Redirect("~/error.aspx?err=You didnt have the permission");
                                        }
                                    }
                                }
                            }else if (cc != null)
                            {
                                if(com.C_IsForVip == true)
                                {
                                    Response.Redirect("~/error.aspx?err=You didnt have the permission");
                                }
                                else
                                {
                                    if (ep.E_Id > 5)
                                    {
                                        Response.Redirect("~/error.aspx?err=You didnt have the permission");
                                    }
                                }
                            }else if (ad != null)
                            {

                            }
                            else
                            {
                                if (com.C_IsForVip == true)
                                {
                                    Response.Redirect("~/error.aspx?err=You didnt have the permission");
                                }
                                else
                                {
                                    if (ep.E_Id > 5)
                                    {
                                        Response.Redirect("~/error.aspx?err=You didnt have the permission");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("~/error.aspx?err=Result cant be found");
                    }
                }
                else
                {
                    Response.Redirect("~/error.aspx?err=Result cant be found");
                }      
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cId = Request.QueryString["cId"];
            string eId = Request.QueryString["eId"];
            int newEId = int.Parse(eId);
            --newEId;
            Response.Redirect("/ViewEpisode.aspx?cId=" + cId + " &eId=" + newEId);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string cId = Request.QueryString["cId"];
            Response.Redirect("~/DisplayComic.aspx?cId=" + cId);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string cId = Request.QueryString["cId"];
            string eId = Request.QueryString["eId"];
            int newEId = int.Parse(eId);
            ++newEId;
            Response.Redirect("~/ViewEpisode.aspx?cId=" + cId + " &eId=" + newEId);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string cId = Request.QueryString["cId"];
            string eId = Request.QueryString["eId"];
            int newEId = int.Parse(eId);
            --newEId;
            Response.Redirect("~/ViewEpisode.aspx?cId=" + cId + " &eId=" + newEId);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string cId = Request.QueryString["cId"];
            Response.Redirect("~/DisplayComic.aspx?cId=" + cId);
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string cId = Request.QueryString["cId"];
            string eId = Request.QueryString["eId"];
            int newEId = int.Parse(eId);
            ++newEId;
            Response.Redirect("~/ViewEpisode.aspx?cId=" + cId + " &eId=" + newEId);
        }
    }
}