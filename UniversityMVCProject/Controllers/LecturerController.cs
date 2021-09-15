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
                Departmans = db.Departmans.ToList(),
                 Lecturers=new Lecturers()
        };
            return View("Yeni", model);
        }
        public ActionResult Kaydet(Lecturers lecturers)
        {
            if (!ModelState.IsValid)
            {
                var model = new LecturerViewModels()
                {
                    Departmans = db.Departmans.ToList(),
                    Lecturers = lecturers
                };
                return View("Yeni", model);
            }
            if (lecturers.Id == 0)
            {
                db.Lecturers.Add(lecturers);
            }
            else
            {
                var updatedEntity = db.Entry(lecturers);
                updatedEntity.State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var model = new LecturerViewModels
            {
                Departmans = db.Departmans.ToList(),
                Lecturers = db.Lecturers.Find(id)
            };
            return View("Yeni", model);
        }
        public ActionResult Delete(int id)
        {
            var deletedEntity = db.Lecturers.Find(id);
            if(deletedEntity == null)
            {
                return HttpNotFound();

            }
            db.Lecturers.Remove(deletedEntity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}