using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeddingzSurface.Models
{
    class Wedding
    {
        public int id                   { get; set; }
        public int budget { get; set; }
        public String place { get; set; }
        public int nb_person { get; set; }
        public bool has_child { get; set; }
        public String bride_first_name { get; set; }
        public String bride_last_name { get; set; }
        public String bride_phone_number { get; set; }
        public String bride_email { get; set; }
        public String groom_first_name { get; set; }
        public String groom_last_name { get; set; }
        public String groom_phone_number { get; set; }
        public String groom_email { get; set; }
        public String religion { get; set; }
        public String place_type { get; set; }
        public String desired_atmosphere { get; set; }
        public String note { get; set; }
        public String bride_photo { get; set; }
        public String groom_photo { get; set; }
        public String wedding_photo { get; set; }
        public List<ProviderType> service_types { get; set; }      
    }
}
