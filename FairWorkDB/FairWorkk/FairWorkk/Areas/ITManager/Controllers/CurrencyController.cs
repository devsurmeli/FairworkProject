using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.ITManager.Controllers
{
    [AllowAnonymous]
    public class CurrencyController : Controller
    {
        // GET: ITManager/Currency
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var currency = db.Currencies.ToList();
            return View(currency);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Currency currency)
        {
            if (ModelState.IsValid)
            {
                db.Currencies.Add(currency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(currency);
        }
        public ActionResult Delete(int id)
        {
            var currency = db.Currencies.Find(id);
            db.Currencies.Remove(currency);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
