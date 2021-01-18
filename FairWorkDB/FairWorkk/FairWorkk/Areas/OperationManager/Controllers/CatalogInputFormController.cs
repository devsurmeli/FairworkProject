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
    public class CatalogInputFormController : Controller
    {
        // GET: OperationManager/CatalogInputForm
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var inputform = db.CatalogInputForms.ToList();
            return View(inputform);
        }
        public ActionResult Detay(int id) 
        {
            var input = db.CatalogInputForms.Where(x => x.ID == id).ToList();
            return View(input);
        }
        public ActionResult Add()
        {
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName");
            ViewBag.ProductGroup = new SelectList(db.ProductGroups, "ID", "ProductCode");
            ViewBag.CompanyProfile = new SelectList(db.CompanyProfiles, "ID", "ProfileName");
            return View();
        }
        [HttpPost]
        public ActionResult Add(CatalogInputForm cat)
        {
            if (ModelState.IsValid)
            {
                db.CatalogInputForms.Add(cat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", cat.CompanyId);
            ViewBag.ProductGroup = new SelectList(db.ProductGroups, "ID", "ProductCode", cat.ProductGroupId);
            ViewBag.CompanyProfile = new SelectList(db.CompanyProfiles, "ID", "ProfileName", cat.CompanyProfile);
            return View(cat);

        }
        public ActionResult Update(int id)
        {
            var cat = db.CatalogInputForms.Find(id);
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", cat.CompanyId);
            ViewBag.ProductGroup = new SelectList(db.ProductGroups, "ID", "ProductCode", cat.ProductGroupId);
            ViewBag.CompanyProfile = new SelectList(db.CompanyProfiles, "ID", "ProfileName", cat.CompanyProfile);
            return View(cat);
        }
        [HttpPost]
        public ActionResult Update(CatalogInputForm cat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", cat.CompanyId);
            ViewBag.ProductGroup = new SelectList(db.ProductGroups, "ID", "ProductCode", cat.ProductGroupId);
            ViewBag.CompanyProfile = new SelectList(db.CompanyProfiles, "ID", "ProfileName", cat.CompanyProfile);
            return View(cat);

        }
    }
}