using System.Collections.Generic;
using MyLSB.Modules.Locations.Classes;
using MyLSB.Modules.Locations.Connectors;
using MyLSB.Modules.Locations.Configuration.Classes;
using System.Linq;
using System;

namespace MyLSB.Modules.Locations
{
    public class LocationsManager
    {
        public List<Location> GetLocations(SearchValues searchValues)
        {
            List<Location> locations = new List<Location>();

            LocationsConfig LocationsConfig = LocationsConfig.GetConfig();

            foreach (var searchValueConnector in searchValues.Connectors)
            {
                if (searchValueConnector.selected)
                {
                    string fullyQualifiedClassName = LocationsConfig.Connectors.Where(c => c.Key == searchValueConnector.name).FirstOrDefault().ClassName;
                    var connector = (ConnectorBase)Activator.CreateInstance(Type.GetType(fullyQualifiedClassName));
                    locations.AddRange(connector.GetLocations(searchValues, searchValueConnector.name));
                }
            }
            return locations;
        }
    }
}