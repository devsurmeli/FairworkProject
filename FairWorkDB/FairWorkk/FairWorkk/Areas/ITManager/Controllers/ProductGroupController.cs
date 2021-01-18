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
    public class ProductGroupController : Controller
    {
        // GET: ITManager/ProductGroup
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var product = db.ProductGroups.ToList();
            return View(product);
        }
        public ActionResult Detail(int id)
        {
            var product = db.ProductGroups.Where(x => x.ID == id).ToList();
            return View(product);
        }
        public ActionResult Add()
        {
            ViewBag.Product = new SelectList(db.Products,"ID","ProductName");
            return View();
        }

        [HttpPost]
        public ActionResult Add(ProductGroup product)
        {
            if (ModelState.IsValid)
            {
                db.ProductGroups.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Product = new SelectList(db.Products, "ID", "ProductName",product.ProductId);
            return View(product);
        }

        public ActionResult Update(int id)
        {
            var product = db.ProductGroups.Find(id);
            ViewBag.Product = new SelectList(db.Products, "ID", "ProductName", product.ProductId);
            return View(product);
        }
        [HttpPost]
        public ActionResult Update(ProductGroup product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Product = new SelectList(db.Products, "ID", "ProductName", product.ProductId);
            return View(product);
        }
        public ActionResult Delete(int id)
        {
            var product = db.ProductGroups.Find(id);
            db.ProductGroups.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
