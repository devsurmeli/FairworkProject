using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace FairWorkk.Areas.GenelMudur.Controllers
{
    [Authorize(Roles = "GM")]
    public class HomeController : Controller
    {
        // GET: GenelMudur/Home
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
             var company = db.Companies.ToList();
            return View(company) ;
        }
        public ActionResult Detail(int id) 
        {
            var company = db.Companies.Where(x => x.ID == id).ToList();
            return View(company);
        }
    }
}