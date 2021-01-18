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
    public class SectorController : Controller
    {
        // GET: ITManager/Sector
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var sec = db.Sectors.ToList();
            return View(sec);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Sector sector)
        {
            if (ModelState.IsValid)
            {
                db.Sectors.Add(sector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sector);
        }
        public ActionResult Update(int id)
        {
            var sec = db.Sectors.Find(id);
            return View(sec);
        }
        [HttpPost]
        public ActionResult Update(Sector sector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sector);
        }
        public ActionResult Delete(int id)
        {
            var sector = db.Sectors.Find(id);
            db.Sectors.Remove(sector);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
