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
    public class CompanyNeedController : Controller
    {
        // GET: ITManager/CompanyNeed
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var cn = db.CompanyNeeds.ToList();
            return View(cn);
        }
        public ActionResult Detail(int id)
        {
            var cn = db.CompanyNeeds.Where(x=>x.ID==id).ToList();
            return View(cn);
        }
        public ActionResult Add()
        {
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName");
            return View();
        }
        [HttpPost]
        public ActionResult Add(CompanyNeed cn)
        {
            if (ModelState.IsValid)
            {
                db.CompanyNeeds.Add(cn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", cn.CompanyId);
            return View(cn);
        }
        public ActionResult Update(int id)
        {
            var cn = db.CompanyNeeds.Find(id);
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", cn.CompanyId);
            return View(cn);
        }
        [HttpPost]
        public ActionResult Update(CompanyNeed cn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", cn.CompanyId);
            return View(cn);
        }
        public ActionResult Delete(int id)
        {
            var cn = db.CompanyNeeds.Find(id);
            db.CompanyNeeds.Remove(cn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
