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
    public class SupplierController : Controller
    {
        // GET: ITManager/Supplier
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var supp = db.Suppliers.ToList();
            return View(supp);
        }
        public ActionResult Detail(int id)
        {
            var supp = db.Suppliers.Where(x=>x.ID==id).ToList();
            return View(supp);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }
        public ActionResult Update(int id)
        {
            var supp = db.Suppliers.Find(id);
            return View(supp);
        }
        [HttpPost]
        public ActionResult Update(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }
        public ActionResult Delete(int id)
        {
            var supp = db.Suppliers.Find(id);
            db.Suppliers.Remove(supp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
