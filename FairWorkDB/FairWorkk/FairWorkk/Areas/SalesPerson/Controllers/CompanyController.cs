using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FairWorkk.Models;
using System.Data.Entity;
using System.Net;

namespace FairWorkk.Areas.SalesPerson.Controllers
{
    [AllowAnonymous]
    public class CompanyController : Controller
    {
        // GET: SalesPerson/Company
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var company = db.Companies.Where(x => x.FairId == 2).ToList();
            return View(company);
        }
        public ActionResult Detail(int id)
        {
            var company = db.Companies.Where(x => x.ID == id).ToList();
            return View(company);
        }
    }
}