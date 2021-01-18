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
    public class HiddenDiscountController : Controller
    {
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var hidden = db.HiddenDiscounts.ToList();
            return View(hidden);
        }

        public ActionResult Detay(int id)
        {
            var hidden = db.HiddenDiscounts.Where(x => x.ID == id).ToList();
            return View(hidden);
        }

        public ActionResult Ekle()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "ID", "CompanyName");
            ViewBag.SaloonId = new SelectList(db.Saloons, "ID", "SalonName");
            ViewBag.StandId = new SelectList(db.Stands, "ID", "Code");
            ViewBag.CurrencyId = new SelectList(db.Currencies, "ID", "CurrencyName");
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(HiddenDiscount hidden)
        {
            if (ModelState.IsValid)
            {
                db.HiddenDiscounts.Add(hidden);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "ID", "CompanyName",hidden.CompanyId);
            ViewBag.SaloonId = new SelectList(db.Saloons, "ID", "SalonName",hidden.SaloonId);
            ViewBag.StandId = new SelectList(db.Stands, "ID", "Code",hidden.StandId);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "ID", "CurrencyName",hidden.CurrencyId);
            return View(hidden);

        }

        public ActionResult Güncelle(int id)
        {
            var hiddens = db.HiddenDiscounts.Find(id);
            ViewBag.CompanyId = new SelectList(db.Companies, "ID", "CompanyName", hiddens.CompanyId);
            ViewBag.SaloonId = new SelectList(db.Saloons, "ID", "SalonName", hiddens.SaloonId);
            ViewBag.StandId = new SelectList(db.Stands, "ID", "Code", hiddens.StandId);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "ID", "CurrencyName", hiddens.CurrencyId);
            return View(hiddens);
        }

        [HttpPost]
        public ActionResult Güncelle(HiddenDiscount hidden)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hidden).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "ID", "CompanyName", hidden.CompanyId);
            ViewBag.SaloonId = new SelectList(db.Saloons, "ID", "SalonName", hidden.SaloonId);
            ViewBag.StandId = new SelectList(db.Stands, "ID", "Code", hidden.StandId);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "ID", "CurrencyName", hidden.CurrencyId);
            return View(hidden);
        }

    }
}
