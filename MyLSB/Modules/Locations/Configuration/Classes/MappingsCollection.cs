using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace MyLSB.Modules.Locations.Configuration.Classes
{
    [ConfigurationCollection(typeof(Mapping), AddItemName = "Mapping")]
    public class MappingsCollection : ConfigurationElementCollection, IEnumerable<Mapping>
    {

        protected override ConfigurationElement CreateNewElement()
        {
            return new Mapping();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var l_configElement = element as Mapping;
            if (l_configElement != null)
                return l_configElement.Key;
            else
                return null;
        }

        public Mapping this[int index]
        {
            get
            {
                return BaseGet(index) as Mapping;
            }
        }

        public new IEnumerator<Mapping> GetEnumerator()
        {
            return (from i in Enumerable.Range(0, this.Count)
                    select this[i])
                .GetEnumerator();
        }

    }
}