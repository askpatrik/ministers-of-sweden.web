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
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Please enter a valid name.")]
        public string Name {get; set;}
      
        [DisplayName("Type of Minister")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Please enter a valid minister type.")]
        public string Type { get; set; }

        [DisplayName("Birth Year")]
        [Range(1900, 2008, ErrorMessage = "Please enter a birth year between 1900 and 2008.")]
        public int Born {get; set;} = 1975;

        [Required(ErrorMessage = "Please enter a gender.")]
        [DisplayName("Gender")]
        public string Sex { get; set; }
       
        [DisplayName("Has Academic Degree (True/False)")]
        [RegularExpression("^(True|False)$", ErrorMessage = "Please enter 'True' or 'False'.")]
        public bool HasAcademicDegree { get; set; }
        [Required(ErrorMessage = "Department missing!")]
        public string Department {get; set;}
      
        public List<SelectListItem> Departments { get; set; } 
        [Required(ErrorMessage = "Department missing!")]

        [DisplayName("Academic Field")]
        public string AcademicField {get; set;}

        public List<SelectListItem> AcademicFields { get; set; } 
        public string Party {get; set;}
        public List<SelectListItem> Parties { get; set; }
        public string ImgUrl { get; set; 
  
       
    }
}
}