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
    public class InterviewController : Controller
    {
        // GET: ITManager/Interview
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var ınter = db.Interviews.ToList();
            return View(ınter);
        }
        public ActionResult Detail(int id)
        {
            var inter = db.Interviews.Where(x => x.ID == id).ToList();
            return View(inter);
        }
        public ActionResult Add()
        {
            ViewBag.SalesPersonId = new SelectList(db.SalesPersons, "ID", "FullName");
            ViewBag.IntervieweeId = new SelectList(db.Interviewees, "ID", "FullName");
            ViewBag.SectorId = new SelectList(db.Sectors, "ID", "SectorAdı");
            ViewBag.CompanyProfileId = new SelectList(db.CompanyProfiles, "ID", "ProfileName");
            ViewBag.FairId = new SelectList(db.Fairs, "ID", "FairName");
            ViewBag.SaloonId = new SelectList(db.Saloons, "ID", "SalonName");
            return View();
        }
        [HttpPost]
        public ActionResult Add(Interview inter)
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
        public ActionResult Update(int id)
        {
            var inter = db.Interviews.Find(id);
            ViewBag.SalesPersonId = new SelectList(db.SalesPersons, "ID", "FullName", inter.SalesPersonId);
            ViewBag.IntervieweeId = new SelectList(db.Interviewees, "ID", "FullName", inter.IntervieweeId);
            ViewBag.SectorId = new SelectList(db.Sectors, "ID", "SectorAdı", inter.FairId);
            ViewBag.CompanyProfileId = new SelectList(db.CompanyProfiles, "ID", "ProfileName", inter.CompanyProfileId);
            ViewBag.FairId = new SelectList(db.Fairs, "ID", "FairName", inter.FairId);
            ViewBag.SaloonId = new SelectList(db.Saloons, "ID", "SalonName", inter.SaloonId);
            return View(inter);
        }
        [HttpPost]
        public ActionResult Update(Interview inter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inter).State = EntityState.Modified;
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

        public ActionResult Delete(int id)
        {
            var inter = db.Interviews.Find(id);
            db.Interviews.Remove(inter);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
