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
    public class IntervieweeController : Controller
    {
        // GET: ITManager/Interviewee
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var inter = db.Interviewees.ToList();
            return View(inter);
        }
        public ActionResult Detail(int id)
        {
            var inter = db.Interviewees.Where(x => x.ID == id).ToList();
            return View(inter);
        }
        public ActionResult Add()
        {
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName");
            return View();
        }
        [HttpPost]
        public ActionResult Add(Interviewee inter)
        {
            if (ModelState.IsValid)
            {
                db.Interviewees.Add(inter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName",inter.CompanyId);
            return View(inter);
        }
        public ActionResult Update(int id)
        {
            var inter = db.Interviewees.Find(id);
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", inter.CompanyId);
            return View(inter);
        }
        [HttpPost]
        public ActionResult Update(Interviewee inter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", inter.CompanyId);
            return View();
            
        }
        public ActionResult Delete(int id)
        {
            var inter = db.Interviewees.Find(id);
            db.Interviewees.Remove(inter);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
