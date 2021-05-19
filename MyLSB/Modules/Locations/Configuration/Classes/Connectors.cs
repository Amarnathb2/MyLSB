using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MyLSB.Modules.Locations.Configuration.Classes
{
    [ConfigurationCollection(typeof(Connector), AddItemName = "Connector")]
    public class Connectors : ConfigurationElementCollection, IEnumerable<Connector>
    {
        public Connector this[int index]
        {
            get { return (Connector)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(Connector serviceConfig)
        {
            BaseAdd(serviceConfig);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new Connector();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Connector)element).Key;
        }

        public void Remove(Connector serviceConfig)
        {
            BaseRemove(serviceConfig.Key);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(String name)
        {
            BaseRemove(name);
        }

        public new IEnumerator<Connector> GetEnumerator()
        {

            int count = base.Count;

            for (int i = 0; i < count; i++)
            {

                yield return base.BaseGet(i) as Connector;

            }

        }


    }
}