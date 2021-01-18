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
    public class InterviewController : Controller
    {
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var interview = db.Interviews.ToList();
            return View(interview);
        }

        public ActionResult Detail(int id)
        {
            var ınterviews = db.Interviews.Where(x => x.ID == id).ToList();
            return View(ınterviews);
        }

        public ActionResult AddInterview() 
        {
            ViewBag.SalesPersonId = new SelectList(db.SalesPersons, "ID", "FullName");
            ViewBag.IntervieweeId = new SelectList(db.Interviewees, "ID", "FullName");
            ViewBag.SectorId = new SelectList(db.Sectors, "ID", "SectorAdı");
            ViewBag.CompanyProfileId = new SelectList(db.CompanyProfiles, "ID", "ProfileName");
            ViewBag.FairId = new SelectList(db.Fairs, "ID", "FairName");
            ViewBag.SaloonId = new SelectList(db.Saloons,"ID","SalonName");
            return View();
        }
        [HttpPost]
        public ActionResult AddInterview(Interview inter) 
        {
            if (ModelState.IsValid)
            {
                db.Interviews.Add(inter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SalesPersonId = new SelectList(db.SalesPersons, "ID", "FullName", inter.SalesPersonId);
            ViewBag.IntervieweeId = new SelectList(db.Interviewees, "ID", "FullName", inter.IntervieweeId);
            ViewBag.SectorId = new SelectList(db.Sectors, "ID", "SectorAdı", inter.FairId);
            ViewBag.CompanyProfileId = new SelectList(db.CompanyProfiles, "ID", "ProfileName", inter.CompanyProfileId);
            ViewBag.FairId = new SelectList(db.Fairs, "ID", "FairName", inter.FairId);
            ViewBag.SaloonId = new SelectList(db.Saloons, "ID", "SalonName", inter.SaloonId);
            return View(inter);
        }
        public ActionResult UpdateInterview(int id) 
        {
            var interview = db.Interviews.Find(id);
            ViewBag.SalesPersonId = new SelectList(db.SalesPersons,"ID","FullName",interview.SalesPersonId);
            ViewBag.IntervieweeId = new SelectList(db.Interviewees, "ID", "FullName", interview.IntervieweeId);
            ViewBag.SectorId = new SelectList(db.Sectors, "ID", "SectorAdı", interview.SectorId);
            ViewBag.CompanyProfileId = new SelectList(db.CompanyProfiles, "ID", "ProfileName", interview.CompanyProfileId);
            ViewBag.FairId = new SelectList(db.Fairs, "ID", "FairName", interview.FairId);
            ViewBag.SaloonId = new SelectList(db.Saloons, "ID", "SalonName", interview.SaloonId);
            return View(interview);
        }
        [HttpPost]
        public ActionResult UpdateInterview(Interview interview) 
        {
            if (ModelState.IsValid)
            {
                db.Entry(interview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SalesPersonId = new SelectList(db.SalesPersons, "ID", "FullName", interview.SalesPersonId);
            ViewBag.IntervieweeId = new SelectList(db.Interviewees, "ID", "FullName", interview.IntervieweeId);
            ViewBag.SectorId = new SelectList(db.Sectors, "ID", "SectorAdı", interview.SectorId);
            ViewBag.CompanyProfileId = new SelectList(db.CompanyProfiles, "ID", "ProfileName", interview.CompanyProfileId);
            ViewBag.FairId = new SelectList(db.Fairs, "ID", "FairName", interview.FairId);
            ViewBag.SaloonId = new SelectList(db.Saloons, "ID", "SalonName", interview.SaloonId);
            return View(interview);
        }
    }
}
