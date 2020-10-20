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
    public partial class forgetPassword : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButPwd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string email = txtEmail.Text;
                user m = db.users.SingleOrDefault(x => x.Email == email);
                readers c = db.readers.SingleOrDefault(x => x.R_email == email);
                ComicCreator cr = db.ComicCreators.SingleOrDefault(x => x.CC_email == email);
                admin ad = db.admins.SingleOrDefault(a => a.A_email == email); 

                if (m == null)
                {
                    cvNotMatched.IsValid = false;
                }
                else 
                {
                    if (c!=null)
                    {
                        string pass = Security.GetPass();

                        MailMessage mm = new MailMessage("teyyh-wm17@student.tarc.edu.my", txtEmail.Text);
                        mm.Subject = "Your password!";
                        mm.Body = string.Format("Hello :" + m.Email + "<p>This is your new password : <h3>" + pass + "</h3>");
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential nc = new NetworkCredential();
                        nc.UserName = "teyyh-wm17@student.tarc.edu.my";
                        nc.Password = "wesly123";
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = nc;
                        smtp.Port = 587;
                        smtp.Send(mm);
                        Labmsg.Text = "Your password has been sent to " + txtEmail.Text;
                        Labmsg.ForeColor = Color.Green;
                        c.R_hash = Security.GetHash(pass);
                        db.SubmitChanges();
                    }
                    else if(cr!=null)
                    {
                        string pass = Security.GetPass();

                        MailMessage mm = new MailMessage("teyyh-wm17@student.tarc.edu.my", txtEmail.Text);
                        mm.Subject = "Your password!";
                        mm.Body = string.Format("Hello :" + m.Email + "<p>This is your new password : <h3>" + pass + "</h3>");
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential nc = new NetworkCredential();
                        nc.UserName = "teyyh-wm17@student.tarc.edu.my";
                        nc.Password = "wesly123";
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = nc;
                        smtp.Port = 587;
                        smtp.Send(mm);
                        Labmsg.Text = "Your password has been sent to " + txtEmail.Text;
                        Labmsg.ForeColor = Color.Green;
                        cr.CC_hash = Security.GetHash(pass);
                        db.SubmitChanges();
                    }
                    else if (ad != null)
                    {
                        string pass = Security.GetPass();

                        MailMessage mm = new MailMessage("teyyh-wm17@student.tarc.edu.my", txtEmail.Text);
                        mm.Subject = "Your password!";
                        mm.Body = string.Format("Hello :" + m.Email + "<p>This is your new password : <h3>" + pass + "</h3>");
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential nc = new NetworkCredential();
                        nc.UserName = "teyyh-wm17@student.tarc.edu.my";
                        nc.Password = "wesly123";
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = nc;
                        smtp.Port = 587;
                        smtp.Send(mm);
                        Labmsg.Text = "Your password has been sent to " + txtEmail.Text;
                        Labmsg.ForeColor = Color.Green;
                        ad.A_hash = Security.GetHash(pass);
                        db.SubmitChanges();
                    }
                    else
                    {
                        Labmsg.Text = "The account is not register yet";
                        Labmsg.ForeColor = Color.Red;
                    }

                }

            }




        }

    }
}