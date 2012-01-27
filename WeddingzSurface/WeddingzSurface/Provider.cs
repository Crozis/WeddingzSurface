using System;
using System.Collections.Generic;

namespace WeddingzSurface
{
    class Provider
    {
        public int UID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tarifs { get; set; }
        public string frontPicture { get; set; }
        public List<string> pictures { get; set; }

        public Provider()
        {
            // Empty
        }
    }
}