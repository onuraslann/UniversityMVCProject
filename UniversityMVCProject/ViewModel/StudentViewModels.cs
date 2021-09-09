using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityMVCProject.Models.EntityFramework;

namespace UniversityMVCProject.ViewModel
{
    public class StudentViewModels
    {
        public List<Departmans> Departmans { get; set; }

        public Students Students { get; set; }
    }
}