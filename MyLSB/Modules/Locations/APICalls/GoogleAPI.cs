using MyLSB.Modules.Locations.Configuration.Classes;
using GeoCoordinatePortable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Linq;

namespace MyLSB.Modules.Locations.APICalls
{
    public class GoogleAPI
    {

        public static GeoCoordinate GetPoint(string address)
        {
            LocationsConfig config = LocationsConfig.GetConfig();
            var requestUri = string.Format(
                config.GoogleLocationGeoCodeUrl,
                Uri.EscapeDataString(address),
                config.GoogleClientGeoCodeApiKey);

            var request = WebRequest.Create(requestUri);
            var response = request.GetResponse();
            GeoCoordinate geoCoordinate = new GeoCoordinate();

            var xdoc = XDocument.Load(response.GetResponseStream());

            var result = xdoc.Element("GeocodeResponse").Element("result");
            if (result != null)
            {
                var locationElement = result.Element("geometry").Element("location");
                geoCoordinate.Latitude = double.Parse(locationElement.Element("lat").Value);
                geoCoordinate.Longitude = double.Parse(locationElement.Element("lng").Value);
            }

            return geoCoordinate;
        }
    }
}