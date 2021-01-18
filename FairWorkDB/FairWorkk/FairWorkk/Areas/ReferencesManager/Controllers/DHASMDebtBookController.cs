using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.ReferencesManager.Controllers
{
    [AllowAnonymous]
    public class DHASMDebtBookController : Controller
    {
        // GET: ReferencesManager/DHASMDebtBook
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var asm = db.ADMFAPayments.ToList();
            return View(asm);
        }
        public ActionResult Detay(int id)
        {
            var asm = db.ADMFAPayments.Where(x => x.ID == id).ToList();
            return View(asm);
        }
        public ActionResult Add()
        {
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName");
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName");
            ViewBag.FreeArea = new SelectList(db.FreeAreas, "ID", "ID");
            ViewBag.Stand = new SelectList(db.AdditionalStandMaterials, "ID", "ID");
            return View();
        }
        [HttpPost]
        public ActionResult Add(ADMFAPayment admfa)
        {
            if (ModelState.IsValid)
            {
                db.ADMFAPayments.Add(admfa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", admfa.CompanyId);
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName", admfa.FairId);
            ViewBag.FreeArea = new SelectList(db.FreeAreas, "ID", "ID", admfa.FreeAreaId);
            ViewBag.Stand = new SelectList(db.AdditionalStandMaterials, "ID", "ID", admfa.AdditionalStandId);
            return View(admfa);
        }
        public ActionResult Update(int id)
        {
            var admfa = db.ADMFAPayments.Find(id);
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", admfa.CompanyId);
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName", admfa.FairId);
            ViewBag.FreeArea = new SelectList(db.FreeAreas, "ID", "ID", admfa.FreeAreaId);
            ViewBag.Stand = new SelectList(db.AdditionalStandMaterials, "ID", "ID", admfa.AdditionalStandId);
            return View(admfa);
        }
        [HttpPost]
        public ActionResult Update(ADMFAPayment admfa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admfa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", admfa.CompanyId);
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName", admfa.FairId);
            ViewBag.FreeArea = new SelectList(db.FreeAreas, "ID", "ID", admfa.FreeAreaId);
            ViewBag.Stand = new SelectList(db.AdditionalStandMaterials, "ID", "ID", admfa.AdditionalStandId);
            return View(admfa);
        }
    }
}