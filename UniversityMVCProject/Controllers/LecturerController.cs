using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMVCProject.Models.EntityFramework;
using UniversityMVCProject.ViewModel;

namespace UniversityMVCProject.Controllers
{
    public class LecturerController : Controller
    {
        UniversityEntities db = new UniversityEntities();
        public ActionResult Index()
        {
            var model = db.Lecturers.ToList();
            return View(model);
        }

        public ActionResult Yeni()
        {
            var model = new LecturerViewModels()
            {
                Departmans = db.Departmans.ToList()
        };
            return View("Yeni", model);
        }
        public ActionResult Kaydet(Lecturers lecturers)
        {
            if (lecturers.Id == 0)
            {
                db.Lecturers.Add(lecturers);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}