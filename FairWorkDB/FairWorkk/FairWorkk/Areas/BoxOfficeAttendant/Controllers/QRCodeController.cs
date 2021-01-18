using FairWorkk.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.BoxOfficeAttendant.Controllers
{
    [Authorize(Roles = "BOA")]
    public class QRCodeController : Controller
    {
        // GET: BoxOfficeAttendant/QRCode
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string dkod)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator koduret = new QRCodeGenerator();
                QRCodeGenerator.QRCode karekod = koduret.CreateQrCode(dkod, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap resim = karekod.GetGraphic(5))
                {
                    resim.Save(ms, ImageFormat.Png);
                    ViewBag.KarekodResim = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }
    }
}