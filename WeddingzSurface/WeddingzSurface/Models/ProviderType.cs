using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeddingzSurface
{

    public class ProviderType
    {
        public int id { get; set; }
        public String name { get; set; }
        public String image_url { get; set; }
        public String icon_url { get; set; }
        public bool activated { get; set; }

        public List<Provider> services { get; set; }

        public ProviderType()
        {
            // Empty
        }
    }
}