using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FairWorkk.Models;

namespace FairWorkk.Areas.GroupSalesManager.Controllers
{
    [AllowAnonymous]
    public class HiddenDiscountController : Controller
    {
        // GET: GroupSalesManager/HiddenDiscount
        //Burada da sadece fuar bazından gızlı ındırımını goruyor.
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var hidden = db.HiddenDiscounts.Where(x=>x.Company.FairId==2).ToList();
            return View(hidden);
        }

        public ActionResult Detay(int id)
        {
            var hidden = db.HiddenDiscounts.Where(x => x.ID == id).ToList();
            return View(hidden);
        }
    }
}