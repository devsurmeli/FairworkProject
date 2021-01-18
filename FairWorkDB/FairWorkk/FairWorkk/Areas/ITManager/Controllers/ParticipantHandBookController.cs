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
    public class ParticipantHandBookController : Controller
    {
        // GET: ITManager/ParticipantHandBook
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var handbook = db.ParticipantHandbooks.ToList();
            return View(handbook);
        }
        public ActionResult Detail(int id)
        {
            var handbook = db.ParticipantHandbooks.Where(x => x.ID == id).ToList();
            return View(handbook);
        }
        public ActionResult Add()
        {
            ViewBag.Employee = new SelectList(db.Employees, "ID", "FullName");
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName");
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName");
            return View();
        }
        [HttpPost]
        public ActionResult Add(ParticipantHandbook handbook)
        {
            if (ModelState.IsValid)
            {
                db.ParticipantHandbooks.Add(handbook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee = new SelectList(db.Employees, "ID", "FullName",handbook.EmployeeId);
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName",handbook.FairId);
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", handbook.CompanyId);
            return View(handbook);
        }
        public ActionResult Update(int id)
        {
            var handbook = db.ParticipantHandbooks.Find(id);
            ViewBag.Employee = new SelectList(db.Employees, "ID", "FullName", handbook.EmployeeId);
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName", handbook.FairId);
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", handbook.CompanyId);
            return View(handbook);
        }
        [HttpPost]
        public ActionResult Update(ParticipantHandbook handbook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(handbook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee = new SelectList(db.Employees, "ID", "FullName", handbook.EmployeeId);
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName", handbook.FairId);
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", handbook.CompanyId);
            return View(handbook);
        }
        public ActionResult Delete(int id)
        {
            var handbook = db.ParticipantHandbooks.Find(id);
            db.ParticipantHandbooks.Remove(handbook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
