using FairWorkk.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Controllers
{
    [AllowAnonymous]
    public class GuestController : Controller
    {
        // GET: Guest
        FairWorkDbEntities db = new FairWorkDbEntities();
        
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
            ViewBag.Profession = new SelectList(db.Professions, "ID", "ProfessionName",guest.ProfessionId);
            ViewBag.TicketType = new SelectList(db.TicketTypes, "ID", "TypeName",guest.TicketTypeId);
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName",guest.FairId);
            return View(guest);
        }
    }
}