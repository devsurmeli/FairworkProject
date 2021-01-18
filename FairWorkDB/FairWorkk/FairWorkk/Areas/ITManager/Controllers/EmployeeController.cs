using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.ITManager.Controllers
{
    [AllowAnonymous]
    public class EmployeeController : Controller
    {
        // GET: ITManager/Employee
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var employee = db.Employees.ToList();
            return View(employee);
        }
        public ActionResult Detail(int id)
        {
            var employee = db.Employees.Where(x=>x.ID==id).ToList();
            return View(employee);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public ActionResult Delete(int id)
        {
            var employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
