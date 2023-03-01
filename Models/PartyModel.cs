using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ministers_of_sweden.web.Models
{
    public class PartyModel
    {
        public int Id {get; set;}
        public string Name {get; set;}

         public ICollection<MinisterModel> Ministers {get; set;}
    }
}