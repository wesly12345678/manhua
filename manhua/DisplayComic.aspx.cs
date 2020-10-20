using System;
using System.Linq;
using System.Web;

namespace manhua
{
    public partial class DisplayComic : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            string cid = Request.QueryString["cId"];
            int readerId = 0;
            bool isVip = false, cantSee = false;
            char vStatus = '\0';
            string email = HttpContext.Current.User.Identity.Name;
            Comic f = db.Comics.SingleOrDefault(o => o.C_Id.ToString() == cid);         //f comic 
            readers r = db.readers.SingleOrDefault(a => a.R_email == email);
            ComicCreator cc = db.ComicCreators.SingleOrDefault(a => a.CC_email == email); // cc comiccreator
            admin ad = db.admins.SingleOrDefault(a => a.A_email == email);
            if (r != null)
            {
                readerId = r.R_Id;
            }
            if (f != null)
            {
                hfId.Value = f.C_Id.ToString(); // Id is int
                lblName.Text = f.C_Title;
                lblD.Text = f.C_Description;
                vStatus = f.C_Status;
                isVip = f.C_IsForVip;
                cantSee = f.C_CantViewable;
                ComicCreator c = db.ComicCreators.SingleOrDefault(
                    a => a.CC_Id == f.CC_Id);
                if (isVip == true)
                {
                    lblVip.Visible = true;
                }
                lblAuthor.Text = c.CC_NickName;

                //get the discount
                lblPrice.Text = "RM" + f.C_Price;
                lblDiscount.Text = "RM" + Math.Round(f.C_Price * Convert.ToDecimal(0.9),2);
                if (cantSee == true)
                {
                    //cant see
                    Response.Redirect("~/error.aspx?err=You didnt have the permission");
                }
                if (cc != null)  //Is comic creator
                {
                    if (cc.CC_Id == f.CC_Id)    // If the comic creator itself see it own comic
                    {
                        btnEdit.Visible = true;
                        btnAddEpisode.Visible = true;
                        btnRead.Visible = false;
                        btnCantRead.Visible = false;
                        btnFavourite.Visible = false;
                        btnFavourited.Visible = false;
                        btnPurchase.Visible = false;
                        btnPurchased.Visible = false;
                        lvEpisode.Visible = false;
                        lvUpdate.Visible = true;
                        btnStatus.Visible = true;
                        string status = verifyStatus(f.C_Status);
                        btnStatus.Text = status;
                        lvCantView.Visible = false;

                    }
                    else //Other comic creator see ur comic
                    {
                       
                        if (vStatus != 'V')
                        {
                            // Error page
                            Response.Redirect("~/error.aspx?err=The result cant be found");
                        }
                        //Default button
                        btnFavourite.Visible = false;
                        btnFavourited.Visible = false;
                        btnPurchase.Visible = false;
                        btnPurchased.Visible = false;
                        btnCantRead.Visible = true;
                        btnRead.Visible = false;
                        lvCantView.Visible = true;
                        lvCan.Visible = false;
                        lvEpisode.Visible = false;
                        lvOnlyVip.Visible = true;

                    }
                }
                else if (r != null) // Is reader
                {

                    if (r.R_isvip == true && isVip == true) // vip with comic vip
                    {
                        Purchased p = db.Purchaseds.SingleOrDefault(a => a.R_Id == readerId && a.C_Id == f.C_Id);
                        if (p != null) //Is purchased
                        {
                            btnPurchase.Visible = false;
                            btnPurchased.Visible = true;
                            btnPurchased.Enabled = false;
                            lvOnlyVip.Visible = false;
                            lvEpisode.Visible = true;
                            lvCantView.Visible = false;
                            lvCan.Visible = true;
                        }
                        else
                        {
                            btnPurchase.Visible = true;
                            btnPurchased.Visible = false;
                        }
                        Favourite fa = db.Favourites.SingleOrDefault(a => a.R_Id == readerId && a.C_Id == f.C_Id);
                        if (fa != null) // Is Faourite
                        {
                            btnFavourite.Visible = false;
                            btnFavourited.Visible = true;
                            btnFavourited.Enabled = false;
                        }
                        else
                        {
                            btnFavourite.Visible = true;
                            btnFavourited.Visible = false;
                        }
                        Episode ep = db.Episodes.SingleOrDefault(a => a.C_Id == f.C_Id && a.E_Id == 1);
                        if (ep == null)  //Didnt have episode
                        {
                            btnRead.Visible = false;
                            btnCantRead.Visible = true;
                            btnCantRead.Enabled = false;
                        }
                        else
                        {
                            btnRead.Visible = true;
                            btnCantRead.Visible = false;
                        }
                    }
                    else if (r.R_isvip == true && isVip == false) // if the reader is vip and comic not vip
                    {
                        Purchased p = db.Purchaseds.SingleOrDefault(a => a.R_Id == readerId && a.C_Id == f.C_Id);
                        if (p != null) //Is purchased
                        {
                            btnPurchase.Visible = false;
                            btnPurchased.Visible = true;
                            btnPurchased.Enabled = false;
                            lblPrice.CssClass += " discount";
                            lblDiscount.Visible = true;
                            lvCantView.Visible = false;
                            lvCan.Visible = true;
                            lvEpisode.Visible = true;
                            lvOnlyVip.Visible = false;
                        }
                        else
                        {
                            lblPrice.CssClass += " discount";
                            lblDiscount.Visible = true;
                            lvEpisode.Visible = true;
                            lvOnlyVip.Visible = false;
                            lvCantView.Visible = true;
                            btnPurchase.Visible = true;
                            btnPurchased.Visible = false;
                        }
                        Favourite fa = db.Favourites.SingleOrDefault(a => a.R_Id == readerId && a.C_Id == f.C_Id);
                        if (fa != null) // Is Faourite
                        {
                            btnFavourite.Visible = false;
                            btnFavourited.Visible = true;
                            btnFavourited.Enabled = false;
                        }
                        else
                        {
                            btnFavourite.Visible = true;
                            btnFavourited.Visible = false;
                        }
                        Episode ep = db.Episodes.SingleOrDefault(a => a.C_Id == f.C_Id && a.E_Id == 1);
                        if (ep == null)  //Didnt have episode
                        {
                            btnRead.Visible = false;
                            btnCantRead.Visible = true;
                            btnCantRead.Enabled = false;
                        }
                        else
                        {
                            btnRead.Visible = true;
                            btnCantRead.Visible = false;
                        }
                    }
                    else if(r.R_isvip == false && isVip == true)
                    {
                        btnPurchase.Visible = false;
                        btnPurchased.Visible = false;
                        btnRead.Visible = false;
                        btnCantRead.Visible = true;
                        btnCantRead.Enabled = false;
                        btnFavourite.Visible = false;
                        btnFavourited.Visible = false;
                        lvOnlyVip.Visible = true;
                        lvEpisode.Visible = false;
                        lvCantView.Visible = true;
                        lvCan.Visible = false;

                    }
                    else
                    {
                        Purchased p = db.Purchaseds.SingleOrDefault(a => a.R_Id == readerId && a.C_Id == f.C_Id);
                        if (p != null) //Is purchased
                        {
                            btnPurchase.Visible = false;
                            btnPurchased.Visible = true;
                            btnPurchased.Enabled = false;
                            lvOnlyVip.Visible = false;
                            lvEpisode.Visible = true;
                            lvCantView.Visible = false;
                            lvCan.Visible = true;
                        }
                        else
                        {
                            btnPurchase.Visible = true;
                            btnPurchased.Visible = false;
                        }
                        Favourite fa = db.Favourites.SingleOrDefault(a => a.R_Id == readerId && a.C_Id == f.C_Id);
                        if (fa != null) // Is Faourite
                        {
                            btnFavourite.Visible = false;
                            btnFavourited.Visible = true;
                            btnFavourited.Enabled = false;
                        }
                        else
                        {
                            btnFavourite.Visible = true;
                            btnFavourited.Visible = false;
                        }
                        Episode ep = db.Episodes.SingleOrDefault(a => a.C_Id == f.C_Id && a.E_Id == 1);
                        if (ep == null)  //Didnt have episode
                        {
                            btnRead.Visible = false;
                            btnCantRead.Visible = true;
                            btnCantRead.Enabled = false;
                        }
                        else
                        {
                            btnRead.Visible = true;
                            btnCantRead.Visible = false;
                        }
                    }
                    if (vStatus != 'V')
                    {
                        // Error page
                        Response.Redirect("~/error.aspx?err=The result cant be found");
                    }
                }
                else if (ad != null) //Admin
                {
                    btnStatus.Visible = true;
                    string status = verifyStatus(f.C_Status);
                    btnStatus.Text = status;
                    btnFail.Visible = true;
                    btnVerify.Visible = true;
                    btnUnverify.Visible = true;
                    btnRead.Visible = false;
                    btnCantRead.Visible = false;
                    btnFavourite.Visible = false;
                    btnFavourited.Visible = false;
                    btnPurchase.Visible = false;
                    btnPurchased.Visible = false;
                    lvCantView.Visible = false;
                    lvCan.Visible = true;
                    lvEpisode.Visible = true;
                    lvOnlyVip.Visible = false;
                }
                else
                {
                    if (isVip == true)
                    {
                        btnPurchase.Visible = true;
                        btnPurchased.Visible = false;
                        btnRead.Visible = false;
                        btnCantRead.Visible = true;
                        btnCantRead.Enabled = false;
                        btnFavourite.Visible = false;
                        btnFavourited.Visible = false;
                        lvEpisode.Visible = false;
                        lvOnlyVip.Visible = true;

                    }
                    else
                    {
                        Episode ep = db.Episodes.SingleOrDefault(a => a.C_Id == f.C_Id && a.E_Id == 1);
                        if (ep == null) //Havent  Favourite 
                        {
                            btnRead.Visible = false;
                            btnCantRead.Visible = true;
                            btnCantRead.Enabled = false;
                        }
                        else
                        {
                            btnRead.Visible = true;
                            btnCantRead.Visible = false;
                        }
                    }

                    //Default button
                    btnFavourite.Visible = true;
                    btnFavourited.Visible = false;
                    btnPurchase.Visible = true;
                    btnPurchased.Visible = false;
                    if (vStatus != 'V')
                    {
                        // Error page
                        Response.Redirect("~/error.aspx?err=The result cant be found");
                    }


                }
                //Verified the available to see all or not
            }
            else
            {
                Response.Redirect("~/error.aspx?err=The result cant be found");
            }
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["cId"];
            string sourcceURL = "/ViewEpisode.aspx?cId=" + id + " &eId=1";
            Server.Transfer(sourcceURL);

        }
        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            string email = HttpContext.Current.User.Identity.Name;
            string comic = Request.QueryString["cId"];
            int comicId = Int32.Parse(comic);
            readers r = db.readers.SingleOrDefault(a => a.R_email == email);
            if (r != null)
            {
                if (!db.Purchaseds.Any(a => a.C_Id == comicId && a.R_Id == r.R_Id))
                {
                    Session["type"] = "Comic";
                    Session["purchase_cId"] = Request.QueryString["cId"];
                    Response.Redirect("~/Reader/Payment/ChoiceCoP.aspx");
                }
                else
                {
                    Response.Redirect("~/DisplayComic.aspx?cId=" + comic);
                }
            }
            else
            {
                Session["url"] = "~/DisplayComic.aspx?cId=" + comic;
                Response.Redirect("~/Authentication/login.aspx");
                //Jump to login page
            }

        }

        protected void btnFavourite_Click(object sender, EventArgs e)
        {
            string email = HttpContext.Current.User.Identity.Name;
            string comic = Request.QueryString["cId"];
            int comicId = Int32.Parse(comic);
            readers r = db.readers.SingleOrDefault(a => a.R_email == email);
            if (r != null)
            {
                if (!db.Favourites.Any(a => a.C_Id == comicId && a.R_Id == r.R_Id))
                {
                    Favourite l = new Favourite
                    {
                        R_Id = r.R_Id,
                        C_Id = comicId
                    };
                    db.Favourites.InsertOnSubmit(l);
                    db.SubmitChanges();
                    // When the Error is the favourite got this item
                }
                Response.Redirect("~/DisplayComic.aspx?cId=" + comic);
            }
            else
            {
                Session["url"] = "~/DisplayComic.aspx?cId=" + comic;
                Response.Redirect("~/Authentication/login.aspx");
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string comic = Request.QueryString["cId"];
            int comicId = Int32.Parse(comic);
            Response.Redirect("~/comicCreator/UpdateComicInfo.aspx?cId=" + comic);
            //Edit comic
        }

        protected void btnAddEpisode_Click(object sender, EventArgs e)
        {
            string comic = Request.QueryString["cId"];
            int comicId = Int32.Parse(comic);
            int counts = (from row in db.Episodes
                          where row.C_Id == comicId
                          select row).Count();
            counts++;
            Response.Redirect("~/comicCreator/AddEpisode.aspx?comicId=" + comic);
        }
        protected void btnVerify_Click(object sender, EventArgs e)
        {
            addStatus('V');
        }
        protected void btnUnverify_Click(object sender, EventArgs e)
        {
            addStatus('U');
        }

        protected void btnFail_Click(object sender, EventArgs e)
        {
            addStatus('F');
        }

        public void addStatus(char status)
        {
            string cid = Request.QueryString["cId"];
            string email = HttpContext.Current.User.Identity.Name;
            admin am = db.admins.SingleOrDefault(a => a.A_email == email);
            if (am != null)
            {
                if (!string.IsNullOrEmpty(cid))
                {
                    int c_Id = Int32.Parse(cid);
                    Comic com = db.Comics.SingleOrDefault(a => a.C_Id == c_Id);
                    if (com != null)
                    {
                        com.C_Status = status;
                        db.SubmitChanges();
                        Response.Redirect("~/DisplayComic.aspx?cId=" + cid);
                    }
                    else
                    {
                        Response.Redirect("~/error.aspx?err=The result cant be found");

                    }
                }
                else
                {
                    Response.Redirect("~/error.aspx?err=The result cant be found");
                }
            }
            else
            {
                Response.Redirect("~/error.aspx?err=You didnt have the permission");
            }
        }
        public static string verifyStatus(char p)
        {
            if (p == 'V')
            {
                return "Verified";
            }
            else if (p == 'U')
            {
                return "Unverified";
            }
            else if (p == 'F')
            {
                return "Failed";
            }
            else
            {
                return "Undefined";
            }
        }

        protected void ldsEpisode_Selecting(object sender, System.Web.UI.WebControls.LinqDataSourceSelectEventArgs e)
        {
            e.Arguments.MaximumRows = 5;
        }
    }
}