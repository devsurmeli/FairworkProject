using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.SalesPerson.Controllers
{
    [AllowAnonymous]
    public class FairController : Controller
    {
        // GET: SalesPerson/Fari
        //İlgilendiği fuar berlin oldugu ıcın grup satıs muduru ıle bırlıkte bunu goruyor satıs danısmanı.
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var fair = db.Fairs.Where(x => x.ID == 2).ToList();
            return View(fair);
        }
        public ActionResult Detail(int id)
        {
            var fair = db.Fairs.Where(x => x.ID == id).ToList();
            return View(fair);
        }
    }
}