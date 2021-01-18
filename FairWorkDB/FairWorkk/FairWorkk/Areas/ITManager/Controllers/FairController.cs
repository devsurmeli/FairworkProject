using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.ITManager.Controllers
{
    [AllowAnonymous]
    public class FairController : Controller
    {
        // GET: ITManager/Fair
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var fair = db.Fairs.ToList();
            return View(fair);
        }
        public ActionResult Detail(int id)
        {
            var fair = db.Fairs.Where(x=>x.ID==id).ToList();
            return View(fair);
        }
        public ActionResult Add()
        {
            ViewBag.Saloon = new SelectList(db.Saloons, "ID", "SalonName");
            return View();
        }
        [HttpPost]
        public ActionResult Add(Fair fair)
        {
            if (Request.Files.Count>0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "/Content/image/" + filename + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                fair.ImagePat = "/Content/image/" + filename + uzanti;
            }
            if (ModelState.IsValid)
            {
                db.Fairs.Add(fair);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Saloon = new SelectList(db.Saloons, "ID", "SalonName",fair.SaloonId);
            return View(fair);
        }
        public ActionResult Update(int id)
        {
            var fair = db.Fairs.Find(id);
            ViewBag.Saloon = new SelectList(db.Saloons, "ID", "SalonName", fair.SaloonId);
            return View(fair);
        }
        [HttpPost]
        public ActionResult Update(Fair fair)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "/Content/image/" + filename + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                fair.ImagePat = "/Content/image/" + filename + uzanti;
            }
            if (ModelState.IsValid)
            {
                db.Entry(fair).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Saloon = new SelectList(db.Saloons, "ID", "SalonName", fair.SaloonId);
            return View(fair);
        }
        public ActionResult Delete(int id)
        {
            var fair = db.Fairs.Find(id);
            db.Fairs.Remove(fair);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
