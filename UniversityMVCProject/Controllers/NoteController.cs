 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMVCProject.Models.EntityFramework;
using UniversityMVCProject.ViewModel;

namespace UniversityMVCProject.Controllers
{
    [Authorize(Roles = "atolla")]
    public class NoteController : Controller
    {
        UniversityEntities db = new UniversityEntities();
        public ActionResult Index()
        {
            var model = db.Notes.ToList();
            return View(model);
        }
        public ActionResult Yeni()
        {
            var model = new NoteViewModels()
            {
                Lessons = db.Lessons.ToList(),
                Students = db.Students.ToList(),
                Notes = new Notes()
            };
            return View("Yeni", model);
        }
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Notes notes)
        {
            if (!ModelState.IsValid)
            {
                var model = new NoteViewModels()
                {
                    Lessons = db.Lessons.ToList(),
                    Students = db.Students.ToList(),
                    Notes=notes
                };
                return View("Yeni", model);
            }

            if (notes.Id == 0)
            {
                db.Notes.Add(notes);
            }
            else
            {
                var updatedEntity = db.Entry(notes);
                updatedEntity.State = System.Data.Entity.EntityState.Modified;

            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult  Update(int id)
        {
            var model = new NoteViewModels()
            {
                Lessons = db.Lessons.ToList(),
                Students = db.Students.ToList(),
                Notes = db.Notes.Find(id)
            };
            return View("Yeni", model);

        }
        public ActionResult Delete(int id)
        {
            var deletedEntity = db.Notes.Find(id);

            if (deletedEntity==null)
            {
                return HttpNotFound();
            }
            db.Notes.Remove(deletedEntity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}