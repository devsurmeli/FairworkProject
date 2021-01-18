using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.GenelMudur.Controllers
{
    [AllowAnonymous]
    public class HiddenDiscountController : Controller
    {
        // GET: GenelMudur/HiddenDiscount
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var discount = db.HiddenDiscounts.ToList();
            return View(discount);
        }
        public ActionResult Detay(int id) 
        {
            var discount = db.HiddenDiscounts.Where(x => x.ID == id).ToList();
            return View(discount);
        }
    }
}