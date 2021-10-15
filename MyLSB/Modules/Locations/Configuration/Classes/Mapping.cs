using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace MyLSB.Modules.Locations.Configuration.Classes
{
    public class Mapping : ConfigurationElement
    {

        [ConfigurationProperty("key", IsKey = true, IsRequired = true)]
        public string Key
        {
            get
            {
                return base["key"] as string;
            }
            set
            {
                base["key"] = value;
            }
        }

        [ConfigurationProperty("to")]
        public string To
        {
            get
            {
                return base["to"] as string;
            }
            set
            {
                base["to"] = value;
            }
        }

    }
}