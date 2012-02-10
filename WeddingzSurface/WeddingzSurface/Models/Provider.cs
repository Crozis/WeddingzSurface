using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeddingzSurface
{

    public class Provider
    {
        public int UID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tarifs { get; set; }
        public string frontPicture { get; set; }
        public List<string> pictures { get; set; }
        public string type { get; set; }

        public Provider()
        {
            // Empty
        }
    }
}