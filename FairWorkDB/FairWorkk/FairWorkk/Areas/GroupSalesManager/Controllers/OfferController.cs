﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FairWorkk.Models;

namespace FairWorkk.Areas.GroupSalesManager.Controllers
{
    [AllowAnonymous]
    public class OfferController : Controller
    {
        // GET: GroupSalesManager/Offer
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Index()
        {
            var offer = db.Offers.ToList();
            return View(offer);
        }
        public ActionResult Detail(int id)
        {
            var offer = db.Offers.Where(x => x.ID == id).ToList();
            return View(offer);
        }
    }
}