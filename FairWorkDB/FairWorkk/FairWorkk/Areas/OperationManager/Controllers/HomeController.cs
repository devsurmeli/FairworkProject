using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.OperationManager.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: OperationManager/Home
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            //Sözleşmesi imzalı olanlar sadece görüyor.
            var contract = db.Contracts.Where(x=>x.ContractSigned==true).ToList();
            return View(contract);
        }
        public ActionResult Detail(int id)
        {
            var contract = db.Contracts.Where(x => x.ID == id).ToList();
            return View(contract);
        }
    }
}