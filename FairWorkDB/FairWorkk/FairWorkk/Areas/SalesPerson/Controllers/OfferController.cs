using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FairWorkk.Models;

namespace FairWorkk.Areas.SalesPerson.Controllers
{
    [AllowAnonymous]
    public class OfferController : Controller
    {
        // GET: SalesPerson/Offer
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var offer = db.Offers.ToList();
            return View(offer);
        }
        public ActionResult Detail(int id)
        {
            var offer = db.Offers.Where(x => x.ID == id).ToList();
            return View(offer);
        }
        public ActionResult AddOffer()
        {
            ViewBag.CurrencyId = new SelectList(db.Currencies, "ID", "CurrencyName");
            ViewBag.SaloonId = new SelectList(db.Saloons, "ID", "SalonName");
            ViewBag.StandId = new SelectList(db.Stands, "ID", "Code");
            return View();
        }
        [HttpPost]
        public ActionResult AddOffer(Offer offer)
        {
           
            if (ModelState.IsValid)
            {
                db.Offers.Add(offer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StandId = new SelectList(db.Stands, "ID", "Code",offer.StandId);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "ID", "CurrencyName", offer.CurrencyId);
            ViewBag.SaloonId = new SelectList(db.Saloons, "ID", "SalonName", offer.SaloonId);
            return View(offer);
        }
        public ActionResult UpdateOffer(int id)
        {
            var offer = db.Offers.Find(id);
            ViewBag.SaloonId = new SelectList(db.Saloons, "ID", "SalonName", offer.SaloonId);
            ViewBag.StandId = new SelectList(db.Stands, "ID", "Code", offer.StandId);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "ID", "CurrencyName", offer.CurrencyId);
            return View(offer);
        }
        [HttpPost]
        public ActionResult UpdateOffer(Offer offer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SaloonId = new SelectList(db.Saloons, "ID", "SalonName", offer.SaloonId);
            ViewBag.StandId = new SelectList(db.Stands, "ID", "Code", offer.StandId);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "ID", "CurrencyName", offer.CurrencyId);
            return View(offer);
        }

    }
}