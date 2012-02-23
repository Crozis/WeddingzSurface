using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeddingzSurface
{

    public class Provider
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone_number { get; set; }
        public string address { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string price { get; set; }
        public string front_picture { get; set; }
        public bool activated { get; set; }
        public List<string> pictures_url { get; set; }

        public Provider()
        {
            // Empty
        }
    }
}