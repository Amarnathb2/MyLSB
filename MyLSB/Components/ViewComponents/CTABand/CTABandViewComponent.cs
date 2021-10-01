using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class CTABandViewComponent : ViewComponent
    {
        public CTABandViewComponent()
        {
        }

        public IViewComponentResult Invoke(CTABand node)
        {
            return View("~/Components/ViewComponents/CTABand/CTABand.cshtml", node);
        }
    }
}