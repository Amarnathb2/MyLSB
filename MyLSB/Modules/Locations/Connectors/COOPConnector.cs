using MyLSB.Modules.Locations.Classes;
using MyLSB.Modules.Locations.Configuration.Classes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace MyLSB.Modules.Locations.Connectors
{
    public class COOPConnector : ConnectorBase
    {

        internal override List<dynamic> getLocationsFromService(SearchValues searchValues, string connectorName)
        {
            string[] parms = { searchValues.Latitude.ToString(), searchValues.Longitude.ToString(), Math.Min(100, searchValues.Radius).ToString() };
            var url = LocationsConfig.Connectors.Where(c => c.Key == connectorName).FirstOrDefault().Url;
            var key = LocationsConfig.Connectors.Where(c => c.Key == connectorName).FirstOrDefault().ApiKey;

            var requestUri = string.Format(url, parms);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);

            request.Accept = "application/json";
            request.Headers.Add("Version", "1");
            request.Headers.Add("Authorization", key);

            var response = request.GetResponse();
            Stream stream = response.GetResponseStream();

            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            String responseString = reader.ReadToEnd();

            dynamic jsonObject = JObject.Parse(responseString);

            return jsonObject.response.locations.ToObject<List<dynamic>>();
        }

        internal override Location getLocation(dynamic dynLocation, int id, string connectorName)
        {
            Location location = new Location();
            location.Type = connectorName;
            location.Name = dynLocation.institutionName.Value;

            if (dynLocation.address != null)
            {
                location.Address1 = checkNull(dynLocation.address.Value);
                location.City = checkNull(dynLocation.city.Value);
                location.State = checkNull(dynLocation.stateAbbreviation.Value);
                location.ZipCode = checkNull(dynLocation.zip.Value);
                location.Phone = checkNull(dynLocation.phone.Value);

                location.GoogleDirectionsLink = String.Format(LocationsConfig.GoogleLocationDirectionsUrl, location.Address1.Replace(" ", "+"), location.City.Replace(" ", "+"), location.State.Replace(" ", "+"));
            }

            location.Longitude = float.Parse(dynLocation.longitude.Value.ToString());
            location.Latitude = float.Parse(dynLocation.latitude.Value.ToString());

            location.Distance = float.Parse(dynLocation.distance.Value.ToString());
            location.DistanceString = Math.Round(location.Distance, 2).ToString();

            location.setId();
            return location;
        }


        private string buildSearchParameters(SearchValues searchValues)
        {
            string val = "Latitude=" + searchValues.Latitude + "&";
            val += "Longitude=" + searchValues.Longitude + "&";
            val += "Offset=" + searchValues.Radius + "&";

            return val;
        }

    }
}