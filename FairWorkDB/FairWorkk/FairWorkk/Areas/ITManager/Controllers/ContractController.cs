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
    public class ContractController : Controller
    {
        // GET: ITManager/Contract
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var contract = db.Contracts.ToList();
            return View(contract);
        }
        public ActionResult Detail(int id)
        {
            var contract = db.Contracts.Where(x => x.ID == id).ToList();
            return View(contract);
        }
        public ActionResult Add()
        {
            ViewBag.SalesPersonId = new SelectList(db.SalesPersons, "ID", "FullName");
            ViewBag.CompanyInformationId = new SelectList(db.CompanyInformations, "ID", "CompanyId");
            ViewBag.ContractTypeId = new SelectList(db.ContractTypes, "ID", "TypeName");
            ViewBag.StandTypeId = new SelectList(db.StandTypes, "ID", "TypeName");
            ViewBag.StandId = new SelectList(db.Stands, "ID", "Code");
            ViewBag.CurrencyId = new SelectList(db.Currencies, "ID", "CurrencyName");
            return View();
        }
        [HttpPost]
        public ActionResult Add(Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Contracts.Add(contract);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SalesPersonId = new SelectList(db.SalesPersons, "ID", "FullName", contract.SalesPersonId);
            ViewBag.CompanyInformationId = new SelectList(db.CompanyInformations, "ID", "CompanyId", contract.CompanyInformationId);
            ViewBag.ContractTypeId = new SelectList(db.ContractTypes, "ID", "TypeName", contract.ContractTypeId);
            ViewBag.StandTypeId = new SelectList(db.StandTypes, "ID", "TypeName", contract.StandId);
            ViewBag.StandId = new SelectList(db.Stands, "ID", "Code", contract.StandId);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "ID", "CurrencyName", contract.CurrencyId);
            return View(contract);
        }

        public ActionResult Update(int id)
        {
            var contract = db.Contracts.Find(id);
            ViewBag.SalesPersonId = new SelectList(db.SalesPersons, "ID", "FullName", contract.SalesPersonId);
            ViewBag.CompanyInformationId = new SelectList(db.CompanyInformations, "ID", "CompanyId", contract.CompanyInformationId);
            ViewBag.ContractTypeId = new SelectList(db.ContractTypes, "ID", "TypeName", contract.ContractTypeId);
            ViewBag.StandTypeId = new SelectList(db.StandTypes, "ID", "TypeName", contract.StandId);
            ViewBag.StandId = new SelectList(db.Stands, "ID", "Code", contract.StandId);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "ID", "CurrencyName", contract.CurrencyId);
            return View(contract);
        }
        [HttpPost]
        public ActionResult Update(Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SalesPersonId = new SelectList(db.SalesPersons, "ID", "FullName", contract.SalesPersonId);
            ViewBag.CompanyInformationId = new SelectList(db.CompanyInformations, "ID", "CompanyId", contract.CompanyInformationId);
            ViewBag.ContractTypeId = new SelectList(db.ContractTypes, "ID", "TypeName", contract.ContractTypeId);
            ViewBag.StandTypeId = new SelectList(db.StandTypes, "ID", "TypeName", contract.StandId);
            ViewBag.StandId = new SelectList(db.Stands, "ID", "Code", contract.StandId);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "ID", "CurrencyName", contract.CurrencyId);
            return View(contract);
        }
        public ActionResult Delete(int id)
        {
            var contract = db.Contracts.Find(id);
            db.Contracts.Remove(contract);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
