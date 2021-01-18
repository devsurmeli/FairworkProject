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
    public class AppUserController : Controller
    {
        // GET: ITManager/AppUser
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var app = db.AppUsers.ToList();
            return View(app);
        }
        public ActionResult Add()
        {
            ViewBag.Role = new SelectList(db.Roles,"ID","Role1");
            return View();
        }

        [HttpPost]
        public ActionResult Add(AppUser app)
        {
            if (ModelState.IsValid)
            {
                db.AppUsers.Add(app);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Role = new SelectList(db.Roles, "ID", "Role1",app.RoleId);
            return View(app);
            
        }

        public ActionResult Update(int id)
        {
            var app = db.AppUsers.Find(id);
            ViewBag.Role = new SelectList(db.Roles, "ID", "Role1", app.RoleId);
            return View(app);
        }

        [HttpPost]
        public ActionResult Update(AppUser app)
        {
            if (ModelState.IsValid)
            {
                db.Entry(app).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Role = new SelectList(db.Roles, "ID", "Role1", app.RoleId);
            return View(app);
        }
        public ActionResult Delete(int id)
        {
            var app = db.AppUsers.Find(id);
            db.AppUsers.Remove(app);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
