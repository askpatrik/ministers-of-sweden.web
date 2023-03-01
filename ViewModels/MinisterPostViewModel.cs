using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ministers_of_sweden.web.ViewModels
{
    public class MinisterPostViewModel
    {
        [Required(ErrorMessage = "Name missing!")]
        public string Name {get; set;}
         [Required(ErrorMessage = "Type of Minister missing!")]
         [DisplayName("Type of Minister")]
        public string Type { get; set; }
         [Required(ErrorMessage = "Birth Year missing!")]
         [DisplayName("Birth Year")]
        public int Born {get; set;}
         [Required(ErrorMessage = "Gender missing")]
          [DisplayName("Gender")]
        public string Sex { get; set; }
        public string ImgUrl { get; set; }
         [Required(ErrorMessage = "HasAcademicDegree missing")]
        public bool HasAcademicDegree { get; set; }
         [Required(ErrorMessage = "Department missing!")]
        public string Department {get; set;}
      
        public List<SelectListItem> Departments { get; set; } 
        public string AcademicField {get; set;}
     
          public List<SelectListItem> AcademicFields { get; set; } 
        public string Party {get; set;}
          public List<SelectListItem> Parties { get; set; }
  
       
    }
}