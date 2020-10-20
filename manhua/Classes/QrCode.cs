using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using QRCoder;
using Image = System.Web.UI.WebControls.Image;

namespace Test.Classes
{
    public class QrCode
    {
        public static Image QrcodeGenerator(string url, string pic)
        {
            var qrGenerator = new QRCodeGenerator();
            var imgBarCode = new Image();
            imgBarCode.Height = 150;
            imgBarCode.Width = 150;
            var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            using (var qrCodeImage = qrCode.GetGraphic(20))
            {
                // Set the image inside the QR code
                var path = pic;
                var logo = System.Drawing.Image.FromFile(path);
                logo = resizeImage(logo, new Size(200, 200)); // Use the method created
                var left = qrCodeImage.Width / 2 - logo.Width / 2;
                var top = qrCodeImage.Height / 2 - logo.Height / 2;
                var g = Graphics.FromImage(qrCodeImage);
                g.DrawImage(logo, new Point(left, top));
                //
                using (var ms = new MemoryStream())
                {
                    qrCodeImage.Save(ms, ImageFormat.Png);
                    var byteImage = ms.ToArray();
                    imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                }
            }

            return imgBarCode;
        }

        public static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
        {
            return new Bitmap(imgToResize, size);
        }
    }
}