using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.SalesPerson.Controllers
{
    [AllowAnonymous]
    public class IntervieweeController : Controller
    {
        // GET: SalesPerson/Interviewee
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var interviewee = db.Interviewees.ToList();
            return View(interviewee);
        }
        public ActionResult Detay(int id)
        {
            var interviewee = db.Interviewees.Where(x => x.ID == id).ToList();
            return View(interviewee);
        }
        public ActionResult Ekle()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "ID", "CompanyName");
            ViewBag.IntervieweeId = new SelectList(db.Interviewees, "ID", "IsInterviewee");
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Interviewee interviewee)
        {
            if (ModelState.IsValid)
            {
                db.Interviewees.Add(interviewee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "ID", "CompanyName",interviewee.CompanyId);
            ViewBag.IntervieweeId = new SelectList(db.Interviewees, "ID", "IsInterviewee",interviewee.IsInterviewee);
            return View(interviewee);
        }
        public ActionResult Güncelle(int id) 
        {
            var interviewee = db.Interviewees.Find(id);
            ViewBag.CompanyId = new SelectList(db.Companies, "ID", "CompanyName", interviewee.CompanyId);
            ViewBag.IntervieweeId = new SelectList(db.Interviewees, "ID", "IsInterviewee", interviewee.IsInterviewee);
            return View(interviewee);
        }
        [HttpPost]
        public ActionResult Güncelle(Interviewee interviewee) 
        {
            if (ModelState.IsValid)
            {
                db.Entry(interviewee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "ID", "CompanyName", interviewee.CompanyId);
            ViewBag.IntervieweeId = new SelectList(db.Interviewees, "ID", "IsInterviewee", interviewee.IsInterviewee);
            return View(interviewee);
        }
    }
}