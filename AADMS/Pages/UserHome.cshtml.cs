using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AADMS.CURD;
using AADMS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGeneration;
using QRCoder;

namespace AADMS.Pages
{
    public class UserHomeModel : PageModel
    {
        [BindProperty]
        public string AID { get; set; }

        [BindProperty]
        public User user { get; set; }

        [BindProperty]
        public User user1 { get; set; }

        [BindProperty]
        public string test { get; set; }

        public void OnGet()
        {
            AID = HttpContext.Session.GetString("aadno");
            user = CurdOpsUser.getDataByAID(AID);

        }
        

        public void OnPost()
        {
            AID = HttpContext.Session.GetString("aadno");
            user = CurdOpsUser.getDataByAID(AID);

            string name = user.UID + " " + user.FIRSTNAME + " " + user.LASTNAME + " " + user.DOB + " " + user.PHONE + " " + user.ADD_LINE1 + "," + user.ADD_LINE2 + "," + user.POSTALCODE + "," + user.STATE + " " + user.CO_FNAME + " " + user.CO_LNAME;
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
                QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(name, QRCodeGenerator.ECCLevel.Q);
                QRCode qRCode = new QRCode(qRCodeData);

                using (Bitmap bitmap = qRCode.GetGraphic(5))
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    test = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        
        public IActionResult GenerateQRCode()
        {
            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode("hello!",QRCodeGenerator.ECCLevel.Q);
            QRCode qRCode = new QRCode(qRCodeData);
            Bitmap bitmap = qRCode.GetGraphic(15);
            var bitmapBytes = ConvertBitmapToBytes(bitmap);
            return File(bitmapBytes, "/image/jpeg");
        }

        private byte[] ConvertBitmapToBytes(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}