using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.SalesPerson.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: SalesPerson/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}