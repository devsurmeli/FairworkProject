using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.OperationManager.Controllers
{
    [AllowAnonymous]
    public class SupplierController : Controller
    {
        // GET: OperationManager/Supplier
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var supp = db.Suppliers.ToList();
            return View(supp);
        }
        public ActionResult Detail(int id)
        {
            var supp = db.Suppliers.Where(x => x.ID == id).ToList();
            return View(supp);
        }
    }
}