using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.ReferencesManager.Controllers
{
    [AllowAnonymous]
    public class SalesPersonController : Controller
    {
        // GET: ReferencesManager/SalesPerson
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var sales = db.SalesPersons.Where(x => x.CommisionPrice != null).ToList();
            return View(sales);
        }
        public ActionResult Detay(int id)
        {
            var sales = db.SalesPersons.Where(x => x.ID == id).ToList();
            return View(sales);
        }
    }
}