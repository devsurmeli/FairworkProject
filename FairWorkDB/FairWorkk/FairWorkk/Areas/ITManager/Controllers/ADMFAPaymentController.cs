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
    public class ADMFAPaymentController : Controller
    {
        // GET: ITManager/ADMFAPayment
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var adm = db.ADMFAPayments.ToList();
            return View(adm);
        }
        public ActionResult Detail(int id)
        {
            var adm = db.ADMFAPayments.Where(x => x.ID == id).ToList() ;
            return View(adm);

        }
        public ActionResult Add()
        {
            
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName");
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName");
            ViewBag.FreeArea = new SelectList(db.FreeAreas, "ID", "ID");
            ViewBag.AdditionalStand = new SelectList(db.AdditionalStandMaterials, "ID", "ID");
            return View();
        }
        [HttpPost]
        public ActionResult Add(ADMFAPayment adm)
        {
            if (ModelState.IsValid)
            {
                db.ADMFAPayments.Add(adm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName",adm.CompanyId);
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName",adm.FairId);
            ViewBag.FreeArea = new SelectList(db.FreeAreas, "ID", "ID",adm.FreeAreaId);
            ViewBag.AdditionalStand = new SelectList(db.AdditionalStandMaterials, "ID", "ID", adm.AdditionalStandId);
            return View(adm);
        }
        public ActionResult Update(int id)
        {
            var adm = db.ADMFAPayments.Find(id);
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", adm.CompanyId);
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName", adm.FairId);
            ViewBag.FreeArea = new SelectList(db.FreeAreas, "ID", "ID", adm.FreeAreaId);
            ViewBag.AdditionalStand = new SelectList(db.AdditionalStandMaterials, "ID", "ID", adm.AdditionalStandId);
            return View(adm);
        }
        [HttpPost]
        public ActionResult Update(ADMFAPayment adm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", adm.CompanyId);
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName", adm.FairId);
            ViewBag.FreeArea = new SelectList(db.FreeAreas, "ID", "ID", adm.FreeAreaId);
            ViewBag.AdditionalStand = new SelectList(db.AdditionalStandMaterials, "ID", "ID", adm.AdditionalStandId);
            return View(adm);
        }
        public ActionResult Delete(int id)
        {
            var adm = db.ADMFAPayments.Find(id);
            db.ADMFAPayments.Remove(adm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}