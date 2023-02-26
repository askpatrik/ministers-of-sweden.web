using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ministers_of_sweden.web.ViewModels
{
    public class MinisterDetailModel: IndexViewModel
    {
        public int Born {get; set;}
        public string Sex { get; set; }
        public string AcademicField {get;set;}
        public bool HasAcademicDegree { get; set; }
        public string Department {get; set;}
        public string Party {get; set;}

    }
}