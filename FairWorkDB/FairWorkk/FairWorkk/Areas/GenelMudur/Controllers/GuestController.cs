using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.GenelMudur.Controllers
{
    [AllowAnonymous]
    public class GuestController : Controller
    {
        // GET: GenelMudur/Guest
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var guest = db.Guests.ToList();
            return View(guest);
        }
        public ActionResult Detail(int id)
        {
            var guest = db.Guests.Where(x => x.ID == id).ToList();
            return View(guest);
        }
    }
}