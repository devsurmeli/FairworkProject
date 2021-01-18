using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.GroupSalesManager.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: GroupSalesManager/Home
        //İlgilendiği Fuara göre bir fuar seçtim onun bılgılerıne ve satıs danısmanlarını goruyor.
        //Yenı Sadece Berlin Fuarını goruyor.
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var sales = db.SalesPersons.Where(x=>x.FairId==2).ToList();
            return View(sales);
        }
        public ActionResult Detay(int id)
        {
            var sales = db.SalesPersons.Where(x => x.ID == id).ToList();
            return View(sales);

        }
    }
}