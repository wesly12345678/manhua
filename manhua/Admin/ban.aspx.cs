using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace manhua.Admin
{
    public partial class ban : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            int index = 0;
            if (Page.IsValid)
            {
                foreach (GridViewRow r in GridView1.Rows)
                {
                    var chk = (CheckBox)r.Cells[0].FindControl("CheckBox1");
                    if (chk != null && chk.Checked)
                    {
                        int id = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString());
                        readers c = db.readers.SingleOrDefault(a => a.R_Id == id);
                        if (c != null)
                        {
                            c.R_BanStatus = true;
                            db.SubmitChanges();
                        }
                    }
                    index++;
                }
                Response.Redirect("../Admin/ban.aspx");
            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int index = 0;
            if (Page.IsValid)
            {
                foreach (GridViewRow r in GridView1.Rows)
                {
                    var chk = (CheckBox)r.Cells[0].FindControl("CheckBox1");
                    if (chk != null && chk.Checked)
                    {
                        int id = Convert.ToInt32(GridView1.DataKeys[index].Value.ToString());
                        readers c = db.readers.SingleOrDefault(a => a.R_Id == id);
                        if (c != null)
                        {
                            c.R_BanStatus = false;
                            db.SubmitChanges();
                        }

                    }
                    index++;
                }
                Response.Redirect("../Admin/ban.aspx");
            }
           
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("/home.aspx");
        }
    }
}