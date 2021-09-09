using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMVCProject.Models.EntityFramework;
using UniversityMVCProject.ViewModel;

namespace UniversityMVCProject.Controllers
{
    public class LessonController : Controller
    {
        UniversityEntities db = new UniversityEntities();
        public ActionResult Index()
        {
            var model = db.Lessons.ToList();
            return View(model);
        }
        public ActionResult Yeni()
        {
            var model = new LessonViewModels()
            {
                  Lecturers=db.Lecturers.ToList(),
                  Students = db.Students.ToList()
            };
            return View("Yeni", model);
        }
        public ActionResult Kaydet(Lessons lessons)
        {
            if (lessons.Id == 0)
            {
                db.Lessons.Add(lessons);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}