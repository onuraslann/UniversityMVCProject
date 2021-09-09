using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityMVCProject.Models.EntityFramework;

namespace UniversityMVCProject.ViewModel
{
    public class LessonViewModels
    {
        public List<Students> Students { get; set; }
        public List<Lecturers> Lecturers { get; set; }

        public Lessons Lessons { get; set; }
    }
}