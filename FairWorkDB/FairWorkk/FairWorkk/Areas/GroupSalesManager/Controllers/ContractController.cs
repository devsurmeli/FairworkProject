using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FairWorkk.Models;

namespace FairWorkk.Areas.GroupSalesManager.Controllers
{
    [AllowAnonymous]
    public class ContractController : Controller
    {
        // GET: GroupSalesManager/Contract
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var contract = db.Contracts.Where(x=>x.SalesPerson.FairId==2).ToList();
            return View(contract);
        }
        public ActionResult Detail(int id)
        {
            var contract = db.Contracts.Where(x => x.ID == id).ToList();
            return View(contract);
        }
    }
}