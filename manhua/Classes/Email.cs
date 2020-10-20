using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace Test.Classes
{
    public class Email
    {
        public static void Send(string username,string email, string id, string pin, string condition)
        {
            if (condition == "cEmail") // 
            {
                string body = PopulateBody(username,
              "Please click here to verify",
              "https://localhost:44377/Authentication/Verification.aspx?em=" + email + "&userId=" + id,
              "<br/>Here is the url to confirm ur email<br/>Please ignore this email if this email is not your");
                SendHtmlFormattedEmail(email,"Confirmation Email" , body);
            }
            else if (condition == "rPassword") // Renew the password
            {
                string body = PopulateBody(username,
              "Please click here to verify",
              "https://localhost:44377/Authentication/Verification.aspx?em=" + email + "&pin=" + pin,
              "<br/>Here is the url to confirm ur email<br/>Please ignore this email if this email is not your");
                SendHtmlFormattedEmail(email, "Renew the password", body);
            }

        }
        private static string PopulateBody(string userName, string title, string url, string description)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/Authentication/SendEmail.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{UserName}", userName);
            body = body.Replace("{Title}", title);
            body = body.Replace("{Url}", url);
            body = body.Replace("{Description}", description);
            return body;
        }
        private static void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            try
            {
                //benlyr1212 @gmail.com
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(recepientEmail);
                mailMessage.From = new MailAddress("connetcompany@gmail.com");
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient();

                smtpClient.Host = "smtp.gmail.com";

                smtpClient.Port = 587;
                smtpClient.Credentials = new System.Net.NetworkCredential
                ("connetcompany@gmail.com", "connet123");
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);

            }
            catch (System.Exception)
            {
                //Response.Redirect("~/Error.aspx?errmsg=Email cant sent");

            }

        }
        private static void randomCharacter()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < 6; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            string randomText = builder.ToString().ToUpper();
        }
    }
}