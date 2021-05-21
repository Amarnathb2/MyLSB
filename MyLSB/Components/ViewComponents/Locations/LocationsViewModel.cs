using CMS.Taxonomy;
using System.Collections.Generic;
using CMS.DocumentEngine.Types.Custom;
using MyLSB.Models;
using CMS.DocumentEngine;
using MyLSB.Modules.Locations.Configuration.Classes;

namespace MyLSB.Components
{
    public class LocationsViewModel : TreeNodeViewModel
    {
        public string GoogleApiString { get; set; }
        public Locations Locations { get; set; }

        protected LocationsViewModel(TreeNode node) : base(node)
        {
        }

        public static LocationsViewModel GetViewModel(Locations locations)
        {
            var locationsConfig = LocationsConfig.GetConfig();

            return new LocationsViewModel(locations)
            {
                GoogleApiString = string.Format(locationsConfig.GoogleClientGeoCodeUrl, locationsConfig.GoogleClientGeoCodeApiKey),
                Locations = locations
            };
        }
    }
}