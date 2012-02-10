using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeddingzSurface.Models
{
    class Wedding
    {
        public int id                   { get; set; }
        public String name              { get; set; }
        public int budget               { get; set; }
        public String place             { get; set; }
        public int nb_person            { get; set; }
        public int nb_child             { get; set; }
        public List<Provider> services  { get; set; }      
    }
}
