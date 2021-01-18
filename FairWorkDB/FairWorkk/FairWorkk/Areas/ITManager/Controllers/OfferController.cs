using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.ITManager.Controllers
{
    [AllowAnonymous]
    public class OfferController : Controller
    {
        // GET: ITManager/Offer
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
        public ActionResult Add()
        {
            ViewBag.Currency = new SelectList(db.Currencies, "ID", "CurrencyName");
            ViewBag.Saloon = new SelectList(db.Saloons, "ID", "SalonName");
            ViewBag.Stand = new SelectList(db.Stands, "ID", "Code");
            return View();
        }
        [HttpPost]
        public ActionResult Add(Offer offer)
        {
            if (ModelState.IsValid)
            {
                db.Offers.Add(offer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Stand = new SelectList(db.Stands, "ID", "Code", offer.StandId);
            ViewBag.Currency = new SelectList(db.Currencies, "ID", "CurrencyName", offer.CurrencyId);
            ViewBag.Saloon = new SelectList(db.Saloons, "ID", "SalonName", offer.SaloonId);
            return View(offer);
        }
        public ActionResult Update(int id)
        {
            var offer = db.Offers.Find(id);
            ViewBag.SaloonId = new SelectList(db.Saloons, "ID", "SalonName", offer.SaloonId);
            ViewBag.StandId = new SelectList(db.Stands, "ID", "Code", offer.StandId);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "ID", "CurrencyName", offer.CurrencyId);
            return View(offer);
        }
        [HttpPost]
        public ActionResult Update(Offer offer)
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
        public ActionResult Delete(int id)
        {
            var offer = db.Offers.Find(id);
            db.Offers.Remove(offer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
