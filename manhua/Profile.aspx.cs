using System;
using System.Linq;
using System.Web;

namespace manhua.comicCreator
{
    public partial class Profile : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            //temporary
            //creator_id=7757276
            string cc_Id = Request.QueryString["creator_id"];
            string ccEmail = HttpContext.Current.User.Identity.Name;
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(cc_Id)) //get the creator id from query string
                {
                    int ccId = Int32.Parse(cc_Id);
                    ComicCreator c = db.ComicCreators.SingleOrDefault(a => a.CC_Id == ccId);
                    if (c != null) //great querystring
                    {
                        imgProfile.ImageUrl = "~/pic/profile/" + ccId + ".jpg";
                        lbName.Text = c.CC_NickName;
                        lbEmail.Text = c.CC_email;
                        lbphone.Text = c.CC_phone;
                        int counts = (from row in db.Comics
                                      where row.CC_Id == c.CC_Id && row.C_Status == 'V'
                                      select row).Count();
                        lbQuantity.Text = counts.ToString();

                        //button add comic
                        if (!string.IsNullOrEmpty(ccEmail))
                        {
                            ComicCreator current = db.ComicCreators.SingleOrDefault(a=> a.CC_email == ccEmail);
                            admin ad = db.admins.SingleOrDefault(a => a.A_email == ccEmail);
                            if (current!=null && current.CC_Id == ccId)
                            {
                                lvUnverify.Visible = true;
                                lblUnverify.Visible = true;
                                bntEdit.Visible = true;
                            }else if (ad != null)
                            {
                                lvUnverify.Visible = true;
                                lblUnverify.Visible = true;
                            }
                        }
                       
                    }
                    else
                    {
                        Response.Redirect("~/error.aspx?err=The result cant be found");
                        //Error page as the creator id is fake get from query string
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(ccEmail))
                    {
                        ComicCreator cc = db.ComicCreators.SingleOrDefault(a => a.CC_email == ccEmail);
                        if (cc != null)
                        {
                            Response.Redirect("~/Profile.aspx?creator_id=" + cc.CC_Id);
                        }
                        else
                        {
                            Response.Redirect("~/error.aspx?err=You didnt have the permission");
                        }

                    }
                    else
                    {
                        Response.Redirect("~/error.aspx?err=The result cant be found");
                    }

                }
                //Will do the looping for the comic to count the quantity
            }

        }

        protected void bntEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/comicCreator/editProfile.aspx");
        }
    }
}