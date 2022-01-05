using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Modules.Hubspot
{
    public class BlogPost
    {
        public string Name { get; set; }
        public List<BlogTag> Tags { get; set; } = new List<BlogTag>();
        public string URL { get; set; }
    }
    public class BlogTag
    {
        public Int64 TagID { get; set; }
        public string TagName { get; set; }
    }
}
