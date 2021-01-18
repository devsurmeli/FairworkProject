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
    public class BudgetController : Controller
    {
        // GET: ITManager/Budget
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var budget = db.BudgetAndCurrentSales.ToList();
            return View(budget);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(BudgetAndCurrentSale budget)
        {
            if (ModelState.IsValid)
            {
                db.BudgetAndCurrentSales.Add(budget);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(budget);
        }
        public ActionResult Update(int id)
        {
            var budget = db.BudgetAndCurrentSales.Find(id);
            return View(budget);
        }
        [HttpPost]
        public ActionResult Update(BudgetAndCurrentSale budget)
        {
            if (ModelState.IsValid)
            {
                db.Entry(budget).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(budget);
        }
        public ActionResult Delete(int id)
        {
            var budget = db.BudgetAndCurrentSales.Find(id);
            db.BudgetAndCurrentSales.Remove(budget);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
