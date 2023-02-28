using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ministers_of_sweden.web.ViewModels
{
    public class MinisterPostViewModel
    {
        public string Name {get; set;}
        public string Type { get; set; }
        public int Born {get; set;}
        public string Sex { get; set; }
        public string ImgUrl { get; set; }
        public bool HasAcademicDegree { get; set; }
        public int DepartmentId {get; set;}
        public int AcademicFieldId {get; set;}
        public int PartyId {get; set;}
  
       
    }
}