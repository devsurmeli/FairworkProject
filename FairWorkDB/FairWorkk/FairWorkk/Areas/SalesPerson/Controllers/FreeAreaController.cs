using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.SalesPerson.Controllers
{
    [AllowAnonymous]
    public class FreeAreaController : Controller
    {
        // GET: SalesPerson/FreeArea
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var free = db.FreeAreas.ToList();
            return View(free);
        }
        public ActionResult FreeAdd()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "ID", "CompanyName");
            ViewBag.Contract = new SelectList(db.Contracts, "ID", "ID");
            return View();
        }
        [HttpPost]
        public ActionResult FreeAdd(FreeArea freeArea)
        {
            if (ModelState.IsValid)
            {
                db.FreeAreas.Add(freeArea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "ID", "CompanyName", freeArea.CompanyId);
            ViewBag.Contract = new SelectList(db.Contracts, "ID", "ID", freeArea.ContractId);
            return View(freeArea);
        }
    }
}