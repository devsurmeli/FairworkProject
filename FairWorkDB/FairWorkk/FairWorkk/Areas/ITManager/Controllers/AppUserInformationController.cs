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
    public class AppUserInformationController : Controller
    {
        // GET: ITManager/AppUserInformation
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var app = db.AppUserInformations.ToList();
            return View(app);
        }
        public ActionResult Add()
        {
            ViewBag.Role = new SelectList(db.Roles, "ID", "Role1");
            ViewBag.AppUser = new SelectList(db.AppUsers, "ID", "UserName");
            return View();
        }

        [HttpPost]
        public ActionResult Add(AppUserInformation appi)
        {
            if (ModelState.IsValid)
            {
                db.AppUserInformations.Add(appi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Role = new SelectList(db.Roles, "ID", "Role1", appi.RoleId);
            ViewBag.AppUser = new SelectList(db.AppUsers, "ID", "UserName",appi.AppUserId);
            return View(appi);

        }

        public ActionResult Update(int id)
        {
            var appi = db.AppUserInformations.Find(id);
            ViewBag.Role = new SelectList(db.Roles, "ID", "Role1", appi.RoleId);
            ViewBag.AppUser = new SelectList(db.AppUsers, "ID", "UserName", appi.AppUserId);
            return View(appi);
        }

        [HttpPost]
        public ActionResult Update(AppUserInformation appi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Role = new SelectList(db.Roles, "ID", "Role1", appi.RoleId);
            ViewBag.AppUser = new SelectList(db.AppUsers, "ID", "UserName", appi.AppUserId);
            return View(appi);
        }
        public ActionResult Delete(int id)
        {
            var appi = db.AppUserInformations.Find(id);
            db.AppUserInformations.Remove(appi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}