using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FairWorkk.Models;

namespace FairWorkk.Areas.GenelMudur.Controllers
{
    [AllowAnonymous]
    public class FairController : Controller
    {
        // GET: GenelMudur/Fair
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var fair = db.Fairs.ToList();
            return View(fair);
        }
        public ActionResult Detail(int id)
        {
            var fair = db.Fairs.Where(x => x.ID == id).ToList();
            return View(fair);
        }
    }
}