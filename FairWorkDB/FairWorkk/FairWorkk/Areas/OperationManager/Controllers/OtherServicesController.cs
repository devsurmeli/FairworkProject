using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.OperationManager.Controllers
{
    [AllowAnonymous]
    public class OtherServicesController : Controller
    {
        // GET: OperationManager/OtherServices
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var standmaterial = db.AdditionalStandMaterials.ToList();
            return View(standmaterial);
        }
        public ActionResult Detay(int id)
        {
            var standmaterial = db.AdditionalStandMaterials.Where(x => x.ID == id).ToList();
            return View(standmaterial);
        }
        public ActionResult Add()
        {
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName");
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName");
            ViewBag.Supplier = new SelectList(db.Suppliers, "ID", "CompanyName");
            return View();
        }
        [HttpPost]
        public ActionResult Add(AdditionalStandMaterial asm)
        {
            if (ModelState.IsValid)
            {
                db.AdditionalStandMaterials.Add(asm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", asm.CompanyId);
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName", asm.FairId);
            ViewBag.Supplier = new SelectList(db.Suppliers, "ID", "CompanyName", asm.SupplierId);
            return View(asm);
        }
        public ActionResult Update(int id)
        {
            var asm = db.AdditionalStandMaterials.Find(id);
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", asm.CompanyId);
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName", asm.FairId);
            ViewBag.Supplier = new SelectList(db.Suppliers, "ID", "CompanyName", asm.SupplierId);
            return View(asm);
        }
        [HttpPost]
        public ActionResult Update(AdditionalStandMaterial asm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", asm.CompanyId);
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName", asm.FairId);
            ViewBag.Supplier = new SelectList(db.Suppliers, "ID", "CompanyName", asm.SupplierId);
            return View(asm);
        }
    }
}