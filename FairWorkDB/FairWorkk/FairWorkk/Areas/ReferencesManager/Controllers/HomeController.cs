using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.ReferencesManager.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: ReferencesManager/Home
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            ViewModel vm = new ViewModel();
            vm.ContractModel = db.Contracts.ToList();
            vm.ASMModel = db.AdditionalStandMaterials.ToList();
            vm.FreeAreaModel = db.FreeAreas.ToList();
            vm.SalesPersonModel = db.SalesPersons.ToList();
            return View(vm);
        }
    }
}