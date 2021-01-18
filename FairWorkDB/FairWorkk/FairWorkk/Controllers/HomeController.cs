using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        FairWorkDbEntities db = new FairWorkDbEntities();
       
        public ActionResult Index()
        {
            var fair = db.Fairs.ToList();
            return View(fair);
        }

    }
}