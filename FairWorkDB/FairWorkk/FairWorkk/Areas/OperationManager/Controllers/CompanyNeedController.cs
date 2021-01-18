using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.OperationManager.Controllers
{
    [AllowAnonymous]
    public class CompanyNeedController : Controller
    {
        // GET: OperationManager/CompanyNeed
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var cn = db.CompanyNeeds.ToList();
            return View(cn);
        }
        public ActionResult Detail(int id)
        {
            var cn = db.CompanyNeeds.Where(x => x.ID == id).ToList();
            return View(cn);
        }
    }
}