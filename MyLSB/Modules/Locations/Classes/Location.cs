using CMS.DocumentEngine;
using System.Collections.Generic;

namespace MyLSB.Modules.Locations.Classes
{
    public class Location
    {
        public string Id { get; set; }
        public string Type { get; set; }

        public string Name { get; set; }
        public string KenticoGuid { get; set; }
        public string KenticoUrl { get; set; }
        public string KenticoNodeAliasPath { get; set; }

        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Distance { get; set; }
        public string DistanceString { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string GoogleDirectionsLink { get; set; }

        public bool LocationTypeBankingFinancialServices { get; set; }
        public bool LocationTypeInsuranceTrustWealthManagement { get; set; }
        public string LocationTypes { get; set; }

        public string Phone { get; set; }
        public string PhoneLink { get; set; }
        public string Hours { get; set; }

        public Dictionary<string, string> Attributes = new Dictionary<string, string>();

        internal void setId()
        {
            if (!string.IsNullOrEmpty(KenticoGuid))
            {
                this.Id = this.Type + "-" + KenticoGuid;
            }
            else
            {
                this.Id = (this.Type + "-" + Latitude.ToString() + Longitude.ToString()).Replace("-", "N").Replace(".", "P");
            }
        }
    }

    class LocationComparer : IEqualityComparer<Location>
    {
        public bool Equals(Location loc1, Location loc2)
        {
            if (loc1.Id == loc2.Id)
                return true;
            return false;
        }

        public int GetHashCode(Location loc1)
        {
            string hCode = loc1.Id + loc1.Latitude + loc1.Longitude;
            return hCode.GetHashCode();
        }
    }
}