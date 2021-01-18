using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.ReferencesManager.Controllers
{
    [AllowAnonymous]
    public class ContractController : Controller
    {
        // GET: ReferencesManager/Contract
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var contract = db.Contracts.ToList();
            return View(contract);
        }
    }
}