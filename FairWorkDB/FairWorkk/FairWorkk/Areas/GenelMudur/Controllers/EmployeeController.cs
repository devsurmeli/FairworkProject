using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FairWorkk.Models;

namespace FairWorkk.Areas.GenelMudur.Controllers
{
    [AllowAnonymous]
    public class EmployeeController : Controller
    {
        // GET: GenelMudur/Employee
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var employee = db.Employees.ToList();
            return View(employee);
        }
        public ActionResult Detail(int id) 
        {
            var employee = db.Employees.Where(x => x.ID == id).ToList();
            return View(employee);
        }
    }
}