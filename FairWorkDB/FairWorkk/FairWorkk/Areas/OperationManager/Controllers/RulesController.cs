using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.OperationManager.Controllers
{
    [AllowAnonymous]
    public class RulesController : Controller
    {
        // GET: OperationManager/Rules
        public ActionResult Index()
        {
            return View();
        }
    }
}