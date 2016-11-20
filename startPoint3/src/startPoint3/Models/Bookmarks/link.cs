using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace startPoint3.Models.Bookmarks
{
    public class Link
    {
        public Link()
        {}

        public Link(string name, string linkUrl, string imgUrl)
        {
            this.name = name;
            this.linkUrl = linkUrl;
            this.imgUrl = imgUrl;
        }

        public string name { get; set; }
        public string linkUrl { get; set; }
        public string imgUrl { get; set; }
    }
}
