using System;

namespace WeddingzSurface
{

    public class Thumbnail
    {
        public string label { get; set; }
        public string fileName { get; set; }
        public string groupName { get; set; }

        public Thumbnail(string fileName, string label, string groupName)
        {
            this.fileName = fileName;
            this.label = label;
            this.groupName = groupName;
        }

    }
}