using MyLSB.Modules.Locations.Configuration.Classes;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MyLSB.Modules.Locations.Classes
{
    public class SearchValues
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int Radius { get; set; }
        public List<Connector> Connectors { get; set; }

        public string this[string propertyName]
        {
            get
            {
                Type myType = typeof(SearchValues);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null).ToString();
            }
        }
    }
}