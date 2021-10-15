using System.Collections.Generic;
using System.Linq;
using MyLSB.Modules.Locations.Classes;
using MyLSB.Modules.Locations.Configuration.Classes;

namespace MyLSB.Modules.Locations.Connectors
{
    public abstract class ConnectorBase
    {
        public LocationsConfig LocationsConfig = LocationsConfig.GetConfig();

        public virtual List<Location> GetLocations(SearchValues searchValues, string connectorName)
        {
            List<Location> locations = new List<Location>();
            List<dynamic> dynLocations = getLocationsFromService(searchValues, connectorName);

            if (dynLocations != null){
                int i = 1;

                foreach (dynamic dynLocation in dynLocations)
                {
                    locations.Add(getLocation(dynLocation, i, connectorName));
                    i++;
                }
            }
            return locations.Distinct(new LocationComparer()).ToList();
        }

        internal abstract List<dynamic> getLocationsFromService(SearchValues searchValues, string connectorName);
        internal abstract Location getLocation(dynamic dynLocation, int id, string connectorName);

        internal string checkNull(string val)
        {
            if (string.IsNullOrEmpty(val)) return "";
            return val;
        }

        internal string buildQueryString(SearchValues searchValues, string connectorName)
        {
            string toReturn = "?";
            foreach (Parameter p in LocationsConfig.Connectors.Where(c => c.Key == connectorName).FirstOrDefault().QueryParameters)
                toReturn += addParameter(searchValues, p) +"&";
            return toReturn;
        }

        private string addParameter(SearchValues searchValues, Parameter p)
        {
            return p.Name + "=" + p.Value;
        }
    }
}
