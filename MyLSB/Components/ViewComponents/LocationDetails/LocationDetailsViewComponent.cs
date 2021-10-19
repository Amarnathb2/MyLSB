using CMS.DocumentEngine.Types.Custom;
using CMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class LocationDetailsViewComponent : ViewComponent
    {
        public LocationDetailsViewComponent()
        {
        }

        public IViewComponentResult Invoke(LocationDetails node)
        {
            var model = CacheHelper.Cache(cs =>
            {
                var location = node.Fields.Location.OfType<PageLocation>().FirstOrDefault();

                if (cs.Cached)
                {
                    cs.CacheDependency = CacheHelper.GetCacheDependency(new string[] {
                        $"nodeid|{node.NodeID}",
                        $"nodeid|{location.NodeID}"
                    });
                }

                return LocationDetailsViewModel.GetViewModel(location);

            }, new CacheSettings(10, $"{nameof(LocationDetails)}|{node.NodeID}"));

            if (model is not null)
            {
                return View("/Components/ViewComponents/LocationDetails/LocationDetails.cshtml", model);
            }

            return Content(String.Empty);
        }
    }
}
