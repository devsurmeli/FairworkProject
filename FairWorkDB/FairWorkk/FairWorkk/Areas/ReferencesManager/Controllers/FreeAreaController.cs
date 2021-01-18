using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.ReferencesManager.Controllers
{
    [AllowAnonymous]
    public class FreeAreaController : Controller
    {
        // GET: ReferencesManager/FreeArea
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var fa = db.FreeAreas.ToList();
            return View(fa);
        }
        public ActionResult Detay(int id)
        {
            var fa = db.FreeAreas.Where(x => x.ID == id).ToList();
            return View(fa);
        }
    }
}