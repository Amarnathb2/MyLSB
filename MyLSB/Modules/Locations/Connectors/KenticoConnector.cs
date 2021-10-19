using CMS.DocumentEngine;
using GeoCoordinatePortable;
using MyLSB.Modules.Locations.Classes;
using MyLSB.Modules.Locations.Configuration.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLSB.Modules.Locations.Connectors
{
    public class KenticoConnector : ConnectorBase
    {

        public override List<Location> GetLocations(SearchValues searchValues, string connectorName)
        {
            List<Location> locations = new List<Location>();
            GeoCoordinate startPoint = new GeoCoordinate(searchValues.Latitude, searchValues.Longitude);

            List<TreeNode> pages = getPages(searchValues, connectorName, startPoint);

            int i = 1;
            foreach (var treeNode in pages)
            {
                locations.Add(getLocation(treeNode, i, connectorName, startPoint));
                i++;
            }

            return locations.Distinct(new LocationComparer()).ToList();
        }

        private List<TreeNode> getPages(SearchValues searchValues, string connectorName, GeoCoordinate startPoint)
        {
            TreeProvider tree = new TreeProvider();

            IQueryable<TreeNode> pages = null;

            string typeMapping = getTypeMapping(connectorName);

            if (typeMapping != null)
                pages = tree.SelectNodes("Custom.PageLocation").Published().Where(o => (checkProxDistance(o, searchValues.Radius, startPoint)) && o.GetStringValue("LocationType", "") == typeMapping);
            else
                pages = tree.SelectNodes("Custom.PageLocation").Published().Where(o => (checkProxDistance(o, searchValues.Radius, startPoint)));

            Classes.Connector conn = searchValues.Connectors.Where(c => c.name == connectorName).FirstOrDefault();
            if ((conn != null) && (conn.filters != null) && (conn.filters.Count > 0))
                pages = addMappers(pages, conn.filters);

            if (pages == null)
                return new List<TreeNode>();

            return pages.ToList();
        }

        private IQueryable<TreeNode> addMappers(IQueryable<TreeNode> pages, List<Filter> mappers)
        {
            foreach (var mapper in mappers)
                if (mapper.selected)
                    pages = pages.Where(o=> o.GetBooleanValue(mapper.name, false));

            return pages;
        }

        private string getTypeMapping(string connectorName)
        {
            var conn = LocationsConfig.Connectors.Where(c => c.Key == connectorName).FirstOrDefault();
            if (string.IsNullOrEmpty(conn.TypeMapping))
                return null;
            return conn.TypeMapping;
        }

        private bool checkProxDistance(TreeNode o, int radius, GeoCoordinate startPoint)
        {
            Double latitude = o.GetValue<Double>("LocationLatitude", 0);
            Double longitude = o.GetValue<Double>("LocationLongitude", 0);
            var LocationPoint = new GeoCoordinate(latitude, longitude);
            return (startPoint.GetDistanceTo(LocationPoint) / 1609.344) < radius;
        }

        private Location getLocation(TreeNode treeNode, int id, string connectorName, GeoCoordinate startPoint)
        {
            Location location = new Location();
            location.Type = connectorName;
            location.Name = treeNode.GetValue<string>("NodeName", "");
            location.KenticoGuid = treeNode.GetValue<string>("NodeGUID", "");
            location.KenticoUrl = DocumentURLProvider.GetUrl(treeNode).TrimStart('~');
            location.KenticoNodeAliasPath = treeNode.GetValue<string>("NodeAliasPath", "");

            location.Latitude = treeNode.GetValue<float>("LocationLatitude", 0);
            location.Longitude = treeNode.GetValue<float>("LocationLongitude", 0);
            location.Distance = Convert.ToSingle(startPoint.GetDistanceTo(new GeoCoordinate(location.Latitude, location.Longitude)) / 1609.344);
            location.DistanceString = Math.Round(location.Distance, 2).ToString();

            location.Address1 = treeNode.GetValue<string>("LocationAddress1", "");
            location.Address2 = treeNode.GetValue<string>("LocationAddress2", "");
            location.City = treeNode.GetValue<string>("LocationCity", "");
            location.State = treeNode.GetValue<string>("LocationState", "");
            location.ZipCode = treeNode.GetValue<string>("LocationZipCode", "");
            location.GoogleDirectionsLink = String.Format(LocationsConfig.GoogleLocationDirectionsUrl, location.Address1.Replace(" ", "+"), location.City.Replace(" ", "+"), location.State.Replace(" ", "+"));

            location.LocationTypeBankingFinancialServices = treeNode.GetValue<bool>("LocationTypeBankingFinancialServices", false);
            location.LocationTypeInsuranceTrustWealthManagement = treeNode.GetValue<bool>("LocationTypeInsuranceTrustWealthManagement", false);

            location.Phone = treeNode.GetValue<string>("LocationPhone", "");
            location.PhoneLink = CustomHelpers.TelLink(location.Phone);

            location.Hours = treeNode.GetValue<string>("LocationHours", "");

            location.setId();
            return location;
        }

        private Week getWeek(TreeNode treeNode, string prefix)
        {
            string[] dayNames = { "Sunday","Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            Week week = new Week();
            foreach (var name in dayNames)
            {          
                string open = treeNode.GetStringValue(prefix + name + "Open", "12 AM");
                string close = treeNode.GetStringValue(prefix + name + "Close", "12 AM");

                week.SetTimeFor((DayOfWeek)Enum.Parse(typeof(DayOfWeek), name), DateTime.Parse(open), DateTime.Parse(close));
            }
            return week;
        }

        private Dictionary<string, string> getAttributes(TreeNode treeNode)
        {
            Dictionary<string, string> atts = new Dictionary<string, string>();
            Configuration.Classes.Connector conn = LocationsConfig.Connectors.Where(c => c.Key == "Website").FirstOrDefault();

            foreach (Mapping mapping in conn.Mappings)
                atts.Add(mapping.To, treeNode.GetStringValue(mapping.Key, ""));

            return atts;
        }

        internal override List<dynamic> getLocationsFromService(SearchValues searchValues, string connectorName)
        {
            return null;
        }

        internal override Location getLocation(dynamic dynLocation, int id, string connectorName)
        {
            return null;
        }
    }
}
