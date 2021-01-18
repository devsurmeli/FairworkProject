using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.ReferencesManager.Controllers
{
    [AllowAnonymous]
    public class StandController : Controller
    {
        // GET: ReferencesManager/Stand
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var stand = db.AdditionalStandMaterials.ToList();
            return View(stand);
        }
        public ActionResult Detay(int id)
        {
            var asm = db.AdditionalStandMaterials.Where(x => x.ID == id).ToList();
            return View(asm);
        }
    }
}