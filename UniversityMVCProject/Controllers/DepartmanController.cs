using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMVCProject.Models.EntityFramework;

namespace UniversityMVCProject.Controllers
{
    public class DepartmanController : Controller
    {
        UniversityEntities db = new UniversityEntities();
        public ActionResult Index()
        {
            var model = db.Departmans.ToList();
            return View(model);
        }
        public ActionResult Yeni()
        {

            return View("Yeni");
        }
        public ActionResult Kaydet(Departmans departmans)
        {
            if (departmans.Id == 0)
            {
                db.Departmans.Add(departmans);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}