using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace MyLSB.Modules.Locations.Configuration.Classes
{
    public class Connector : ConfigurationElement
    {

        public string Key { get; set; }
        public string ClassName { get; set; }
        public string TypeMapping { get; set; }
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ApiKey { get; set; }
        public string ApiPassword { get; set; }
        public MappingsCollection Mappings { get; set; }
        public QueryParameters QueryParameters { get; set; }

    }
}