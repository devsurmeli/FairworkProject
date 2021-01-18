using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FairWorkk.Areas.ITManager.Controllers
{
    [AllowAnonymous]
    public class CompanyPaymentController : Controller
    {
        // GET: ITManager/CompanyPayment
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var ccp = db.CompanyContractPayments.ToList();
            return View(ccp);
        }
        public ActionResult Detail(int id)
        {
            var ccp = db.CompanyContractPayments.Where(x => x.ID == id).ToList();
            return View(ccp);
        }
        public ActionResult Add()
        {
            ViewBag.Contract = new SelectList(db.CompanyContractPayments,"ID","ID");
            ViewBag.Company = new SelectList(db.Companies,"ID","CompanyName");
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName");
            return View();
        }
        [HttpPost]
        public ActionResult Add(CompanyContractPayment payment)
        {
            if (ModelState.IsValid)
            {
                db.CompanyContractPayments.Add(payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Contract = new SelectList(db.Contracts, "ID", "ID", payment.ContractId);
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", payment.CompanyId);
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName", payment.FairId);
            return View(payment);
        }
        public ActionResult Update(int id)
        {
            var payment = db.CompanyContractPayments.Find(id);
            ViewBag.Contract = new SelectList(db.Contracts, "ID", "ID", payment.ContractId);
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", payment.CompanyId);
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName", payment.FairId);
            return View(payment);
        }
        [HttpPost]
        public ActionResult Update(CompanyContractPayment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Contract = new SelectList(db.Contracts, "ID", "ID", payment.ContractId);
            ViewBag.Company = new SelectList(db.Companies, "ID", "CompanyName", payment.CompanyId);
            ViewBag.Fair = new SelectList(db.Fairs, "ID", "FairName", payment.FairId);
            return View(payment);
        }
        public ActionResult Delete(int id)
        {
            var ccp = db.CompanyContractPayments.Find(id);
            db.CompanyContractPayments.Remove(ccp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
