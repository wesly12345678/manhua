using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Security.Principal;
using System.Web.Security;
using System.Threading;
using System.Text.RegularExpressions;

namespace manhua
{
    public class Security
    {
        public static string GetHash(string strPass)
        {
        byte[] binPass = Encoding.Default.GetBytes(strPass);

        SHA256 sha = SHA256.Create();
        byte[] binHash = sha.ComputeHash(binPass);
        string strHash = Convert.ToBase64String(binHash);

        return strHash;
         }
        public static void LoginUser(string Nickname, string role, bool rememberMe,string email, string redirection)
        {
            HttpContext ctx = HttpContext.Current;

            HttpCookie authCookie = FormsAuthentication.GetAuthCookie(email, rememberMe);
            FormsAuthenticationTicket oldTicket = FormsAuthentication.Decrypt(authCookie.Value);
            FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(
                oldTicket.Version,
                oldTicket.Name,
                oldTicket.IssueDate,
                oldTicket.Expiration,
                oldTicket.IsPersistent,
                role,
                email
                
            );
            authCookie.Value = FormsAuthentication.Encrypt(newTicket);
            ctx.Response.Cookies.Add(authCookie);

            string redirectUrl = FormsAuthentication.GetRedirectUrl(Nickname, rememberMe);

            if (!string.IsNullOrEmpty(redirection))
            {
                ctx.Response.Redirect(redirection);
            }
            else
            {
                ctx.Response.Redirect(redirectUrl);
            }
        }
            public static string GetPass()
            {
                int size = 10;//generate 10 character new password for forget password
                char[] chars =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
                byte[] data = new byte[size];
                using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
                {
                    crypto.GetBytes(data);
                }
                StringBuilder result = new StringBuilder(size);
                foreach (byte b in data)
                {
                    result.Append(chars[b % (chars.Length)]);
                }
                return result.ToString();
            }


            public static void ProcessRoles()
        {
            HttpContext ctx = HttpContext.Current;

            if (ctx.User != null &&
                ctx.User.Identity.IsAuthenticated &&
                ctx.User.Identity is FormsIdentity)
            {
                FormsIdentity identity = (FormsIdentity)ctx.User.Identity;
                string[] roles = identity.Ticket.UserData.Split(',');

                GenericPrincipal principal = new GenericPrincipal(identity, roles);
                ctx.User = principal;
                Thread.CurrentPrincipal = principal;
            }
        }
        public static string ParseOutHTML(string htmlContent)
        {
            var parsedContent = string.Empty;
            var tagPattern = new Regex(@"(?<=^|>)[^><]+?(?=<|$)", RegexOptions.IgnoreCase);
            var tagsRemoved = tagPattern.Matches(htmlContent);
            foreach (Match match in tagsRemoved)
                parsedContent += match.Value.Trim() + " ";
            return parsedContent;
        }

        public static string autoId(char type)
        {
            return type + Guid.NewGuid().ToString("N");
        }
    }
}
