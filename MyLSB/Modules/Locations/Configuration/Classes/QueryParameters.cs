using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MyLSB.Modules.Locations.Configuration.Classes
{
    [ConfigurationCollection(typeof(Parameter), AddItemName = "Parameter")]
    public class QueryParameters : ConfigurationElementCollection, IEnumerable<Parameter>
    {

        protected override ConfigurationElement CreateNewElement()
        {
            return new Parameter();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var l_configElement = element as Parameter;
            if (l_configElement != null)
                return l_configElement.Name;
            else
                return null;
        }

        public Parameter this[int index]
        {
            get
            {
                return BaseGet(index) as Parameter;
            }
        }

        public new IEnumerator<Parameter> GetEnumerator()
        {
            return (from i in Enumerable.Range(0, this.Count)
                    select this[i])
                .GetEnumerator();
        }

    }
}