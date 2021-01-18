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
    public class CompanyController : Controller
    {
        // GET: ITManager/Company
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var company = db.Companies.ToList();
            return View(company);
        }
        public ActionResult Detail(int id)
        {
            var company = db.Companies.Where(x => x.ID == id).ToList();
            return View(company);
        }
        public ActionResult Add()
        {
            ViewBag.Country = new SelectList(db.Countries, "ID", "CountryName");
            ViewBag.Sector = new SelectList(db.Sectors, "ID", "SectorAdı");
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName");
            return View();
        }
        [HttpPost]
        public ActionResult Add(Company  company)
        {
            if (ModelState.IsValid)
            {
                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Country = new SelectList(db.Countries, "ID", "CountryName", company.CountryId);
            ViewBag.Sector = new SelectList(db.Sectors, "ID", "SectorAdı", company.SectorId);
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName", company.FairId);
            return View(company);
        }
        public ActionResult Update(int id)
        {
            var company = db.Companies.Find(id);
            ViewBag.Country = new SelectList(db.Countries, "ID", "CountryName", company.CountryId);
            ViewBag.Sector = new SelectList(db.Sectors, "ID", "SectorAdı", company.SectorId);
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName", company.FairId);
            return View(company);
        }
        [HttpPost]
        public ActionResult Update(Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Country = new SelectList(db.Countries, "ID", "CountryName", company.CountryId);
            ViewBag.Sector = new SelectList(db.Sectors, "ID", "SectorName", company.SectorId);
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName", company.FairId);
            return View(company);
        }
        public ActionResult Delete(int id)
        {
            var company = db.Companies.Find(id);
            db.Companies.Remove(company);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
