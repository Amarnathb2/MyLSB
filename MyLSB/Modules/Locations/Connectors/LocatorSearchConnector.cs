using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using MyLSB.Modules.Locations.Classes;
using MyLSB.Modules.Locations.Configuration.Classes;
using System.Xml;

namespace MyLSB.Modules.Locations.Connectors
{
    class LocatorSearchConnector : ConnectorBase
    {

        internal override List<dynamic> getLocationsFromService(SearchValues searchValues, string connectorName)
        {
            var queryString = buildQueryString(searchValues, connectorName)
                                + buildSearchParameters(searchValues)
                                + "AddressLine=&City=&State=&PostalCode=&Country=";

            var url = LocationsConfig.Connectors.Where(c => c.Key == connectorName).FirstOrDefault().Url;
            var requestUri = url + queryString;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);

            var response = request.GetResponse();
            Stream stream = response.GetResponseStream();

            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            String responseString = reader.ReadToEnd();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(responseString);

            if (doc.GetElementsByTagName("locations").Item(0).InnerText == "No Results Found.")
                return null;

            string json = JsonConvert.SerializeXmlNode(doc);
            dynamic dyn = JsonConvert.DeserializeObject(json);

            List<dynamic> dynList = new List<dynamic>();

            if (doc.GetElementsByTagName("locations")[0].Attributes["locationCount"].Value == "1")
            {
                dynList.Add(dyn.locations.location);
            }
            else
            {
                foreach (var d in dyn.locations.location)
                    dynList.Add(d);
            }

            return dynList;
        }

        private string buildSearchParameters(SearchValues searchValues)
        {
            string val = "Latitude=" + searchValues.Latitude + "&";
            val += "Longitude=" + searchValues.Longitude + "&";
            val += "Offset=" + searchValues.Radius + "&";

            return val;
        }


        internal override Location getLocation(dynamic dynLocation, int id, string connectorName)
        {
            Location location = new Location();
            location.Type = connectorName;
            location.Name = getName(dynLocation);

            if (dynLocation.address != null)
            {
                location.Address1 = checkNull(dynLocation.address.street.Value);
                location.City = checkNull(dynLocation.address.city.Value);
                location.State = checkNull(dynLocation.address.state.Value);
                location.ZipCode = checkNull(dynLocation.address.zip.Value);
                location.GoogleDirectionsLink = String.Format(LocationsConfig.GoogleLocationDirectionsUrl, location.Address1.Replace(" ", "+"), location.City.Replace(" ", "+"), location.State.Replace(" ", "+"));
            }

            location.Latitude = ((JObject)dynLocation.address)["lat"].Value<float>();
            location.Longitude = ((JObject)dynLocation.address)["long"].Value<float>();
            location.Distance = float.Parse(((JObject)dynLocation)["@distance"].Value<string>());
            location.DistanceString = Math.Round(location.Distance, 2).ToString();

            location.setId();

            return location;
        }

        private Week getWeek(dynamic dynLocation)
        {
            Week week = new Week();
            return week;
        }

        private string getName(dynamic dynLocation)
        {
            JArray attributes = ((JArray)dynLocation.attributes.attribute);
            string name = String.Empty;
            foreach (JObject attribute in attributes)
                if (attribute["@key"].Value<string>() == "LocationName")
                    name = attribute["#text"].Value<string>();

            if (String.IsNullOrEmpty(name))
                name = dynLocation.address.street.Value + " " + dynLocation.address.city.Value;

            return name;
        }
    }
}
