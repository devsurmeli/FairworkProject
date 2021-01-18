using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.ParticipatingCompany.Controllers
{
    [AllowAnonymous]
    public class NeedController : Controller
    {
        // GET: ParticipatingCompany/Need
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var need = db.CompanyNeeds.ToList();
            return View(need);
        }
        public ActionResult Add()
        {
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName");
            return View();
        }
        [HttpPost]
        public ActionResult Add(CompanyNeed need)
        {
            if (ModelState.IsValid)
            {
                db.CompanyNeeds.Add(need);
                db.SaveChanges();
                return View(need);
            }
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", need.CompanyId);
            return View(need);
        }
        public ActionResult Update(int id)
        {
            var need = db.CompanyNeeds.Find(id);
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", need.CompanyId);
            return View(need);
        }
        [HttpPost]
        public ActionResult Update(CompanyNeed need)
        {
            if (ModelState.IsValid)
            {
                db.Entry(need).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", need.CompanyId);
            return View(need);
        }

    }
}