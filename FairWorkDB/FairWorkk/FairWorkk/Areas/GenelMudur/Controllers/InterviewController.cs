using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.GenelMudur.Controllers
{
    [AllowAnonymous]
    public class InterviewController : Controller
    {
        // GET: GenelMudur/Interview
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var interview = db.Interviews.ToList();
            return View(interview);
        }
        public ActionResult Detay(int id)
        {
            var interview = db.Interviews.Where(x=>x.ID==id).ToList();
            return View(interview);
        }
    }
}