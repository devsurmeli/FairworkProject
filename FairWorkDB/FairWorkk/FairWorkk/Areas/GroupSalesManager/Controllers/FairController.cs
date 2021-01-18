using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.GroupSalesManager.Controllers
{
    [AllowAnonymous]
    public class FairController : Controller
    {
        // GET: GroupSalesManager/Fair
        //Fuar olarak sadece berlın gorucek.
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var fair = db.Fairs.Where(x=>x.ID==2).ToList();
            return View(fair);
        }
        public ActionResult Detail(int id)
        {
            var fair = db.Fairs.Where(x => x.ID == id).ToList();
            return View(fair);
        }
    }
}