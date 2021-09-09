 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityMVCProject.Models.EntityFramework;
using UniversityMVCProject.ViewModel;

namespace UniversityMVCProject.Controllers
{
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
                 Lessons=db.Lessons.ToList(),
                 Students = db.Students.ToList()
            };
            return View("Yeni", model);
        }
        public ActionResult Kaydet(Notes notes)
        {
            if (notes.Id == 0)
            {
                db.Notes.Add(notes);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}