using MyLSB.Modules.Locations.Classes;
using Microsoft.AspNetCore.Mvc;
using MyLSB.Modules.Locations;
using System.Collections.Generic;

namespace MyLSB.Modules.Locations
{
    [ApiController]
    public class LocationsController : Controller
    {
        // /Api/Locations/GetLocations
        [HttpPost]
        [Route("api/[controller]/[action]")]
        public IActionResult GetLocations(SearchValues searchValues)
        {
            LocationsManager locationsManager = new LocationsManager();
            List<Location> locations = locationsManager.GetLocations(searchValues);
            return Json(locations);
        }
    }
}
