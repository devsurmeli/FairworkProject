using FairWorkk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FairWorkk.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        // GET: Security
        FairWorkDbEntities db = new FairWorkDbEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AppUser user)
        {
            if (ModelState.IsValid)
            {
                var app = db.AppUsers.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
                if (app != null)
                {
                    FormsAuthentication.SetAuthCookie(app.UserName,false);
                    return Redirect("/BoxOfficeAttendant/Guest/Index");
                }
                else
                {
                    ViewBag.Hata = "Yanlış Kullanıcı veya şifre girdiniz.";
                    return View();
                }
            }
            return View(user);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
       
    }
}