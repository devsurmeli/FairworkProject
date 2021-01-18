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
    public class CompanyInformationController : Controller
    {
        // GET: ITManager/CompanyInformation
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var ci = db.CompanyInformations.ToList();
            return View(ci);
        }
        public ActionResult Detail(int id)
        {
            var ci = db.CompanyInformations.Where(x => x.ID == id).ToList();
            return View(ci);
        }
        public ActionResult Add()
        {
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName");
            return View();
        }
        [HttpPost]
        public ActionResult Add(CompanyInformation ci)
        {
            if (ModelState.IsValid)
            {
                db.CompanyInformations.Add(ci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName",ci.CompanyId);
            return View(ci);
        }
        public ActionResult Update(int id)
        {
            var ci = db.CompanyInformations.Find(id);
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", ci.CompanyId);
            return View(ci);
        }
        [HttpPost]
        public ActionResult Update(CompanyInformation ci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", ci.CompanyId);
            return View(ci);
        }

        public ActionResult Delete(int id)
        {
            var ci = db.CompanyInformations.Find(id);
            db.CompanyInformations.Remove(ci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
