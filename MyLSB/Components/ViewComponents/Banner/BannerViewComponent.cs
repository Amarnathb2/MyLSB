using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class BannerViewComponent : ViewComponent
    {
        public BannerViewComponent()
        {
        }

        public IViewComponentResult Invoke(Banner node)
        {
            var banner = BannerViewModel.GetViewModel(node);
            return View("~/Components/ViewComponents/Banner/Banner.cshtml", banner);
        }
    }
}