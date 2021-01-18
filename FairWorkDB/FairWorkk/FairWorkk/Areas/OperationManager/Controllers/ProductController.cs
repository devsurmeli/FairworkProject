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
    public class ProductController : Controller
    {
        // GET: OperationManager/Product
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var product = db.Products.ToList();
            return View(product);
        }
        public ActionResult Detail(int id)
        {
            var product = db.Products.Where(x => x.ID == id).ToList();
            return View(product);
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Update(int id)
        {
            var update = db.Products.Find(id);
            return View(update);
        }
        [HttpPost]
        public ActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}