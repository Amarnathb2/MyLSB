using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using MyLSB.Models;
using MyLSB.Modules.Locations.Configuration.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class LocationDetailsViewModel : TreeNodeViewModel
    {
        public PageLocation Location { get; set; }

        public string ApiKey { get; set; }

        protected LocationDetailsViewModel(TreeNode node) : base(node)
        {
        }

        public static LocationDetailsViewModel GetViewModel(PageLocation location)
        {
            var locationsConfig = LocationsConfig.GetConfig();
            return new LocationDetailsViewModel(location)
            {
                Location = location,
                ApiKey = locationsConfig.GoogleClientGeoCodeApiKey
            };
        }
    }
}
