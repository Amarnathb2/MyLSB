using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLSB.Modules.Locations.Classes
{
    public class Connector
    {
        public string name { get; set; }
        public bool selected { get; set; }
        public string icon { get; set; }
        public int zindex { get; set; }
        public List<Filter> filters { get; set; }
    }
}