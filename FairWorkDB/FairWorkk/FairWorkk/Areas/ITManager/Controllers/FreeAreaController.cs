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
    public class FreeAreaController : Controller
    {
        // GET: ITManager/FreeArea
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var free = db.FreeAreas.ToList();
            return View(free);
        }
        public ActionResult Detail(int id)
        {
            var free = db.FreeAreas.Where(x=>x.ID==id).ToList();
            return View(free);
        }
        public ActionResult Add()
        {
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName");
            ViewBag.Contract = new SelectList(db.Contracts, "ID", "ID");
            return View();
        }
        [HttpPost]
        public ActionResult Add(FreeArea free)
        {
            if (ModelState.IsValid)
            {
                db.FreeAreas.Add(free);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName",free.CompanyId);
            ViewBag.Contract = new SelectList(db.Contracts, "ID", "ID",free.ContractId);
            return View(free);
        }

        public ActionResult Update(int id)
        {
            var free = db.FreeAreas.Find(id);
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", free.CompanyId);
            ViewBag.Contract = new SelectList(db.Contracts, "ID", "ID", free.ContractId);
            return View(free);
        }
        [HttpPost]
        public ActionResult Update(FreeArea free)
        {
            if (ModelState.IsValid)
            {
                db.Entry(free).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", free.CompanyId);
            ViewBag.Contract = new SelectList(db.Contracts, "ID", "ID", free.ContractId);
            return View(free);
        }
        public ActionResult Delete(int id)
        {
            var free = db.FreeAreas.Find(id);
            db.FreeAreas.Remove(free);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
