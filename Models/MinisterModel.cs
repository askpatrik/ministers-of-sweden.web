using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ministers_of_sweden.web.Models
{
    public class MinisterModel
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Type { get; set; }
        public int Born {get; set;}
        public string Sex { get; set; }
        public string ImgUrl { get; set; }
        public bool HasAcademicDegree { get; set; }


        public int DepartmentId {get; set;}
        [ForeignKey("DepartmentId")]
        public DepartmentModel department {get; set;}

        public int AcademicFieldId {get; set;}
        [ForeignKey("AcademicFieldId")]
        public AcademicFieldModel academicField {get; set;}

        public int PartyId {get; set;}
        [ForeignKey("PartyId")]
        public PartyModel party {get; set;}
    }
}