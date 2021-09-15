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

            return View("Yeni", new Departmans());
        }
        public ActionResult Kaydet(Departmans departmans)
        {
            if (!ModelState.IsValid)
            {
                return View("Yeni");
            }
            if (departmans.Id == 0)
            {
                db.Departmans.Add(departmans);
            }
            else
            {
                var updatedEntity = db.Entry(departmans);
                updatedEntity.State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var deletedEntity = db.Departmans.Find(id);
            if (deletedEntity == null)
            {
                return HttpNotFound();
            }
            db.Departmans.Remove(deletedEntity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Update( int id)
        {
            var updatedDepartman = db.Departmans.Find(id);
            if (updatedDepartman == null)
            {
                return HttpNotFound();
            }
            db.SaveChanges();
            return View("Yeni",updatedDepartman);
        }
    }
}