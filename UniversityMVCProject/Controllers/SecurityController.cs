using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UniversityMVCProject.Models.EntityFramework;

namespace UniversityMVCProject.Controllers
{
    public class SecurityController : Controller
    {
        UniversityEntities db = new UniversityEntities();
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Userss userss)
        {
            var user = db.Userss.FirstOrDefault(x => x.Name == userss.Name && x.Password == userss.Password);
            if(user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Name, false);
                return RedirectToAction("Index", "Departman");
            }
            else
            {
                ViewBag.Mesaj = "Giriş başarısız";
                return View();
            }
           
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }

    }
}