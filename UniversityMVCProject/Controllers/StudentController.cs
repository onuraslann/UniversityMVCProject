using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMVCProject.Models.EntityFramework;
using UniversityMVCProject.ViewModel;

namespace UniversityMVCProject.Controllers
{
    public class StudentController : Controller
    {
        UniversityEntities db = new UniversityEntities();
        public ActionResult Index()
        {
            var model = db.Students.ToList();
            return View(model);
        }
        public ActionResult Yeni()
        {
            var model = new StudentViewModels
            { 
                Departmans=db.Departmans.ToList()


            };
            return View("Yeni", model);
            ;
        }
        public ActionResult Kaydet(Students students)
        {
            if (students.Id == 0)
            {
                db.Students.Add(students);
            }
            else
            {
                var updatedEntity = db.Entry(students);
                updatedEntity.State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var model = new StudentViewModels()
            {
                Departmans = db.Departmans.ToList(),
            Students = db.Students.Find(id)
            };
            return View("Yeni", model);
        }
        public ActionResult Delete(int id)
        {
            var deletedEntity = db.Students.Find(id);
            if (deletedEntity == null)
            {
                return HttpNotFound();
            }
            db.Students.Remove(deletedEntity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}