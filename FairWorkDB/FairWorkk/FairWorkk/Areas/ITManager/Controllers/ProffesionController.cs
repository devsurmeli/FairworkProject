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
    public class ProffesionController : Controller
    {
        // GET: ITManager/Proffesion
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var meslek = db.Professions.ToList();
            return View(meslek);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Profession  profession)
        {
            if (ModelState.IsValid)
            {
                db.Professions.Add(profession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profession);
        }
        public ActionResult Update(int id)
        {
            var meslek = db.Professions.Find(id);
            return View(meslek);
        }
        [HttpPost]
        public ActionResult Update(Profession profession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profession);
        }
        public ActionResult Delete(int id)
        {
            var ci = db.Professions.Find(id);
            db.Professions.Remove(ci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
