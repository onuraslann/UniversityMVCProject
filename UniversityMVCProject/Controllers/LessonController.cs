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
                  Students = db.Students.ToList(),
                  Lessons = new Lessons()
            };
            return View("Yeni", model);
        }
   
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Lessons lessons)
        {
            if (!ModelState.IsValid)
            {
                var model = new LessonViewModels()
                {
                    Lecturers = db.Lecturers.ToList(),
                    Students = db.Students.ToList(),
                    Lessons=lessons
                    
                };
                return View("Yeni", model);
            }
            if (lessons.Id == 0)
            {
                db.Lessons.Add(lessons);
            }
            else
            {
                var updatedEntity = db.Entry(lessons);
                updatedEntity.State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var model = new LessonViewModels()
            {
                Lecturers = db.Lecturers.ToList(),
                Students = db.Students.ToList(),
                Lessons = db.Lessons.Find(id)
            };
            return View("Yeni", model);
        }
        public ActionResult Delete(int id)
        {
            var deletedEntity = db.Lessons.Find(id);
            if (deletedEntity == null)
            {
                return HttpNotFound();
            }
            db.Lessons.Remove(deletedEntity);
            db.SaveChanges();
            return View("Index");
        }
    }
}