using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.GenelMudur.Controllers
{
    [AllowAnonymous]
    public class ContractController : Controller
    {
        // GET: GenelMudur/Contract
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var contract = db.Contracts.ToList();
            return View(contract);
        }
        public ActionResult Detay(int id) 
        {
            var contract = db.Contracts.Where(x => x.ID == id).ToList();
            return View(contract);
        }
    }
}