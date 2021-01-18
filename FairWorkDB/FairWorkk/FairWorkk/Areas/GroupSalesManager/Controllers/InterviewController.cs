using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.GroupSalesManager.Controllers
{
    [AllowAnonymous]
    public class InterviewController : Controller
    {
        // GET: GroupSalesManager/Interview
        //Fuar olarak berlının goruyor.
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var interview = db.Interviews.Where(x=>x.FairId==2).ToList();
            return View(interview);
        }

        public ActionResult Detay(int id)
        {
            var ınterviews = db.Interviews.Where(x => x.ID == id).ToList();
            return View(ınterviews);
        }
    }
}