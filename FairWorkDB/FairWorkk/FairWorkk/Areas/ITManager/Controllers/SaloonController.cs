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
    public class SaloonController : Controller
    {
        // GET: ITManager/Saloon
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var salon = db.Saloons.ToList();
            return View(salon);
        }
        public ActionResult Add()
        {
            ViewBag.Sector = new SelectList(db.Sectors, "ID", "SectorAdı");
            return View();
        }
        [HttpPost]
        public ActionResult Add(Saloon salon)
        {
            if (ModelState.IsValid)
            {
                db.Saloons.Add(salon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sector = new SelectList(db.Sectors, "ID", "SectorAdı",salon.SectorId);
            return View(salon);
        }
        public ActionResult Update(int id)
        {
            var salon = db.Saloons.Find(id);
            ViewBag.Sector = new SelectList(db.Sectors, "ID", "SectorAdı", salon.SectorId);
            return View(salon);
        }
        [HttpPost]
        public ActionResult Update(Saloon salon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sector = new SelectList(db.Sectors, "ID", "SectorAdı", salon.SectorId);
            return View(salon);
        }
        public ActionResult Delete(int id)
        {
            var salon = db.Saloons.Find(id);
            db.Saloons.Remove(salon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
