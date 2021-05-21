using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;
using MyLSB.Modules.Locations.Configuration.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class LocationsViewComponent : ViewComponent
    {
        public LocationsViewComponent()
        {
        }

        public IViewComponentResult Invoke(Locations node)
        {
            var locations = LocationsViewModel.GetViewModel(node);
            return View("~/Components/ViewComponents/Locations/Locations.cshtml", locations);
        }
    }
}