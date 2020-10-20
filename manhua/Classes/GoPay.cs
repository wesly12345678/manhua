using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace manhua.Classes
{
    public class GoPay
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public string pay(decimal amount, string type, string method, int comicId, int readerId) // type is Vip, method is payment
        {
            int randomId = 0;
            Random random = new Random();
            bool repeatId = false;
            string message;
            do
            {
                randomId = random.Next(10000, 9999999);
                var p = db.ComicCreators.SingleOrDefault(
                    b => b.CC_Id == randomId);
                if (p == null) repeatId = true;
            } while (repeatId == false);

            if (type.Equals("Vip"))
            {
                message =  Vip(randomId,amount,method,readerId);
            }
            else
            {
                message = comic(randomId,comicId ,amount, method, readerId);
            }

            return message;
        }

        private string Vip(int paymentId, decimal amount, string method, int readerId)
        {
            try
            {
                payment n = new payment
                {
                    P_Id = paymentId,
                    P_Amount = amount,
                    P_Currency = "MYR",
                    P_Method = method,
                    P_Transaction_Date = DateTime.Now,
                    P_Type = "Vip",
                    R_Id = readerId
                };
                db.payments.InsertOnSubmit(n);
                db.SubmitChanges();
                readers r = db.readers.SingleOrDefault(a => a.R_Id == readerId);
                if (r != null)
                {
                    r.R_isvip = true;
                    db.SubmitChanges();
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return "Failed";
            }
        }

        private string comic(int paymentId, int comicId, decimal amount, string method, int readerId)
        {
            try
            {
                payment n = new payment
                {
                    P_Id = paymentId,
                    P_Amount = amount,
                    P_Currency = "MYR",
                    P_Method = method,
                    P_Transaction_Date = DateTime.Now,
                    C_Id = comicId,
                    P_Type = "Comic",
                    R_Id = readerId
                };
                db.payments.InsertOnSubmit(n);
                db.SubmitChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                return "Failed";
            }
        }
    }
}