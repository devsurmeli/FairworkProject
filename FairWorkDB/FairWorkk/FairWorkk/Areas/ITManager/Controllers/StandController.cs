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
    public class StandController : Controller
    {
        // GET: ITManager/Stand
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var stand = db.Stands.ToList();
            return View(stand);
        }
        public ActionResult Add()
        {
            ViewBag.Saloon = new SelectList(db.Saloons, "ID", "SalonName");
            return View();
        }
        [HttpPost]
        public ActionResult Add(Stand stand)
        {
            if (ModelState.IsValid)
            {
                db.Stands.Add(stand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Saloon = new SelectList(db.Saloons, "ID", "SalonName",stand.SaloonId);
            return View(stand);
        }
        public ActionResult Update(int id)
        {
            var stand = db.Stands.Find(id);
            ViewBag.Saloon = new SelectList(db.Saloons, "ID", "SalonName", stand.SaloonId);
            return View(stand);
        }
        [HttpPost]
        public ActionResult Update(Stand stand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Saloon = new SelectList(db.Saloons, "ID", "SalonName", stand.SaloonId);
            return View(stand);
        }
        public ActionResult Delete(int id)
        {
            var stand = db.Stands.Find(id);
            db.Stands.Remove(stand);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
