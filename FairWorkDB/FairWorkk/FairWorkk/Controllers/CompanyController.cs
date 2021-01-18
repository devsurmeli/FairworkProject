using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Controllers
{
    [AllowAnonymous]
    public class CompanyController : Controller
    {
        // GET: Company
        FairWorkDbEntities db = new FairWorkDbEntities();
        
        public ActionResult Add()
        {
            ViewBag.Country = new SelectList(db.Countries, "ID", "CountryName");
            ViewBag.Sector = new SelectList(db.Sectors, "ID", "SectorAdı");
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName");
            return View();
        }
        
        [HttpPost]
        public ActionResult Add(Company company)
        {
            if (ModelState.IsValid)
            {
                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Add");
            }
            ViewBag.Country = new SelectList(db.Countries, "ID", "CountryName",company.CountryId);
            ViewBag.Sector = new SelectList(db.Sectors, "ID", "SectorName",company.SectorId);
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName",company.FairId);
            return View(company);
        }
    }
}