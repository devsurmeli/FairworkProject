using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Controllers
{
    [AllowAnonymous]
    public class FairController : Controller
    {
        // GET: Fair
        FairWorkDbEntities db = new FairWorkDbEntities();
        
        public ActionResult Index()
        {
            var fair = db.Fairs.ToList();
            return View(fair);
        }
        
        public ActionResult Detay(int id)
        {
            var fair = db.Fairs.Where(x => x.ID == id).ToList();
            return View(fair);
        }
    }
}