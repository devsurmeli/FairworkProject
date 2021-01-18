using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.GenelMudur.Controllers
{
    [AllowAnonymous]
    public class BudgetController : Controller
    {
        // GET: GenelMudur/Budget
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var budget = db.BudgetAndCurrentSales.ToList();
            return View(budget);
        }
    }
}