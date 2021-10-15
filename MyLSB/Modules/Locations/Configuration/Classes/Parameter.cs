using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MyLSB.Modules.Locations.Configuration.Classes
{
    public class Parameter : ConfigurationElement
    {

        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get
            {
                return base["name"] as string;
            }
            set
            {
                base["name"] = value;
            }
        }

        [ConfigurationProperty("value")]
        public string Value
        {
            get
            {
                return base["value"] as string;
            }
            set
            {
                base["value"] = value;
            }
        }

    }
}