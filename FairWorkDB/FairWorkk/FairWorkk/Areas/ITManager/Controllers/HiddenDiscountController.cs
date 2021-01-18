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
    public class HiddenDiscountController : Controller
    {
        // GET: ITManager/HiddenDiscount
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var hidden = db.HiddenDiscounts.ToList();
            return View(hidden);
        }
        public ActionResult Detail(int id)
        {
            var hidden = db.HiddenDiscounts.Where(x=>x.ID==id).ToList();
            return View(hidden);
        }
        public ActionResult Add()
        {
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName");
            ViewBag.Saloon = new SelectList(db.Saloons, "ID", "SalonName");
            ViewBag.Stand = new SelectList(db.Stands, "ID", "Code");
            ViewBag.Currency = new SelectList(db.Currencies, "ID", "CurrencyName");
            return View();
        }
        [HttpPost]
        public ActionResult Add(HiddenDiscount hidden)
        {
            if (ModelState.IsValid)
            {
                db.HiddenDiscounts.Add(hidden);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName",hidden.CompanyId);
            ViewBag.Saloon = new SelectList(db.Saloons, "ID", "SalonName",hidden.SaloonId);
            ViewBag.Stand = new SelectList(db.Stands, "ID", "Code",hidden.StandId);
            ViewBag.Currency = new SelectList(db.Currencies, "ID", "CurrencyName",hidden.CurrencyId);
            return View(hidden);
        }
        public ActionResult Update(int id)
        {
            var hidden = db.HiddenDiscounts.Find(id);
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", hidden.CompanyId);
            ViewBag.Saloon = new SelectList(db.Saloons, "ID", "SalonName", hidden.SaloonId);
            ViewBag.Stand = new SelectList(db.Stands, "ID", "Code", hidden.StandId);
            ViewBag.Currency = new SelectList(db.Currencies, "ID", "CurrencyName", hidden.CurrencyId);
            return View(hidden);
        }
        [HttpPost]
        public ActionResult Update(HiddenDiscount hidden)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hidden).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", hidden.CompanyId);
            ViewBag.Saloon = new SelectList(db.Saloons, "ID", "SalonName", hidden.SaloonId);
            ViewBag.Stand = new SelectList(db.Stands, "ID", "Code", hidden.StandId);
            ViewBag.Currency = new SelectList(db.Currencies, "ID", "CurrencyName", hidden.CurrencyId);
            return View(hidden);
        }
        public ActionResult Delete(int id)
        {
            var hidden = db.HiddenDiscounts.Find(id);
            db.HiddenDiscounts.Remove(hidden);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
