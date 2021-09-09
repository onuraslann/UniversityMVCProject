using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityMVCProject.Models.EntityFramework;

namespace UniversityMVCProject.ViewModel
{
    public class NoteViewModels
    {
        public List<Lessons> Lessons  { get; set; }
        public List<Students> Students { get; set; }

        public Notes Notes { get; set; }
    }
}