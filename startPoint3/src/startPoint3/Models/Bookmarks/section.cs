using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace startPoint3.Models.Bookmarks
{
    public class Section
    {

        public Section()
        {
        }

        public Section(string name, List<Link> links)
        {
            this.name = name;
            this.links = links;
        }

        public string name { get; set; }
        public List<Link> links { get; set; }

    }
}
