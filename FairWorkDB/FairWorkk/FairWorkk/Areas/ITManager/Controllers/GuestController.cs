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
    public class GuestController : Controller
    {
        // GET: ITManager/Guest
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var guest = db.Guests.ToList();
            return View(guest);
        }
        public ActionResult Detail(int id)
        {
            var guest = db.Guests.Where(x=>x.ID==id).ToList();
            return View(guest);
        }
        public ActionResult Add()
        {
            ViewBag.Profession = new SelectList(db.Professions, "ID", "ProfessionName");
            ViewBag.TicketType = new SelectList(db.TicketTypes, "ID", "TypeName");
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName");
            return View();
        }

        [HttpPost]
        public ActionResult Add(Guest guest)
        {
            if (ModelState.IsValid)
            {
                db.Guests.Add(guest);
                db.SaveChanges();
                return RedirectToAction("Add");
            }
            ViewBag.Profession = new SelectList(db.Professions, "ID", "ProfessionName", guest.ProfessionId);
            ViewBag.TicketType = new SelectList(db.TicketTypes, "ID", "TypeName", guest.TicketTypeId);
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName", guest.FairId);
            return View(guest);
        }

        public ActionResult Update(int id)
        {
            var guest = db.Guests.Find(id);
            ViewBag.Profession = new SelectList(db.Professions, "ID", "ProfessionName", guest.ProfessionId);
            ViewBag.TicketType = new SelectList(db.TicketTypes, "ID", "TypeName", guest.TicketTypeId);
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName", guest.FairId);
            return View(guest);

        }

        [HttpPost]
        public ActionResult Update(Guest guest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Profession = new SelectList(db.Professions, "ID", "ProfessionName", guest.ProfessionId);
            ViewBag.TicketType = new SelectList(db.TicketTypes, "ID", "TypeName", guest.TicketTypeId);
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName", guest.FairId);
            return View(guest);

        }
        public ActionResult Delete(int id)
        {
            var guest = db.Guests.Find(id);
            db.Guests.Remove(guest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
