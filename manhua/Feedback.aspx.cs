using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Net;
using System.Net.Mail;
namespace manhua
{
    public partial class Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string email = txtb1.Text;
                string text = txtb2.Text;
                string pass = txtb3.Text;
                MailMessage mm = new MailMessage(email, "ericafen68.tyh@gmail.com");
                mm.Subject = "Feedback";
                mm.Body = string.Format("Hello :" + text + "</h3>");
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential nc = new NetworkCredential();
                nc.UserName = email;
                nc.Password = pass;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = nc;
                smtp.Port = 587;
                smtp.Send(mm);
                Response.Redirect("home.aspx");
            }

        }
    }
}