using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using manhua;

namespace Test.Classes
{
    public class Validation
    {
        public static string usernameValidate(string username)
        {
            var fullname = Security.ParseOutHTML(username);
            var match = Regex.Match(fullname, @"^[A-Za-z \d]*$");
            if (string.IsNullOrEmpty(fullname))
                return "Full name cannot be empty";
            else if (!match.Success)
                return "Invalid full name";
            else
                return null;
        }

        public static string emailValidate(string mail)
        {
            var email = Security.ParseOutHTML(mail);
            if (string.IsNullOrEmpty(email))
                return "Email is empty";
            else if (!EmailTryValidate(email))
                return "Invalid format of email";
            else
                return null;
        }

        public static bool EmailTryValidate(string emailadd)
        {
            try
            {
                var m = new MailAddress(emailadd);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static bool tryDate(string date)
        {
            try
            {
                DateTime oDate = DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static string passwordValidate(string pwd)
        {
            var password = Security.ParseOutHTML(pwd);
            var match = Regex.Match(password, @"((?=.*\d)(?=.*[a-z]).{6,20})");

            if (string.IsNullOrEmpty(pwd))
                return "Password is empty";
            else if (password.Length < 6)
                return "Password must not less than 6";
            else if (password.Length > 50)
                return "Password must less than 50";
            else if (!match.Success)
                return "The password must have at least one lower case and one number";
            else
                return null;
        }

        public static string phoneNumber(string num)
        {
            string phoneNumber = Security.ParseOutHTML(num);
            Match match1 = Regex.Match(phoneNumber, @"01\d+");
            if (string.IsNullOrEmpty(phoneNumber))
                return "Phone Number cannot be empty";
            else if (!match1.Success)  
                return "Invalid Phone Number";
            else if (phoneNumber.Length < 11 || phoneNumber.Length > 12)
                return "Invalid length Phone Number";
            else
                return null;
                
        }
        public static string titleValidate(string tempName)
        {
            var name = Security.ParseOutHTML(tempName);
            if (string.IsNullOrEmpty(name))
            {
                return "Title cannot be empty";
            }
            else
            {
                return null;
            }

        }
        public static string description(string des)
        {
            var description = Security.ParseOutHTML(des);
            if (string.IsNullOrEmpty(description) || description.Length == 0)
            {
                return "Description cannot be empty";
            }
            else
            {
                return null;
            }
        }
        public static string priceValidate(string p)
        {
            var match = Regex.Match(p, @"^\d{0,8}(\.\d{1,4})?$");
            if (string.IsNullOrEmpty(p))
            {
                return "The price cannot be empty";
            }
            else
            {
                if (decimal.TryParse(p, out decimal price))
                {
                    if (price <= 0)
                    {
                        return "The price is invalid";
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return "The price must in decimal";
                }
            }
        }
        public static string dateValid(string date)
        {
            if(string.IsNullOrEmpty(date))
            {
                return "The date cannot be empty";
            }
            else if (!tryDate(date))
            {
                return "The date format is wrong ";
            }
            else
            {
                return null;
            }
        }
        public static string age(string q)
        {
            if (string.IsNullOrEmpty(q))
            {
                return "Age cannot be empty";
            }
            else
            {
                int p = int.Parse(q);
                if (p <= 0)
                {
                    return "The age is invalid";
                }
                else
                {
                    return null;
                }
            }
        }
        public static string intValidated(string q,string name)
        {
            if (string.IsNullOrEmpty(q))
            {
                return name + " cannot be empty";
            }
            else
            {
                int p = int.Parse(q);
                if (p <= 0)
                {
                    return name + " is invalid";
                }
                else
                {
                    return null;
                }
            }
        }
    }
}