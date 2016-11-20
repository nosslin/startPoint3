using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace startPoint3.Models.Bookmarks
{
    public class Bookmarks
    {
        public Bookmarks()
        {
        }

        public Bookmarks(string bucketName, List<Section> sections)
        {
            Bucket = bucketName;
            Sections = sections;
        }
        public ObjectId _id { get; set; }
        public string Bucket { get; set; }
        public List<Section> Sections { get; set; }
    }
}
