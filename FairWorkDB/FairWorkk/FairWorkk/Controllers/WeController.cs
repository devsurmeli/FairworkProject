using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Controllers
{
    [AllowAnonymous]
    public class WeController : Controller
    {
        // GET: We
        
        public ActionResult Index()
        {
            return View();
        }
    }
}