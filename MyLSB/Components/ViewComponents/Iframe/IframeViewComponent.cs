using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class IframeViewComponent : ViewComponent
    {
        public IframeViewComponent()
        {
        }

        public IViewComponentResult Invoke(Iframe node)
        {
            if (node.Parent.ClassName == Partials.CLASS_NAME)
            {
                return View("~/Components/ViewComponents/Iframe/IframeContainer.cshtml", node);
            }
            return View("~/Components/ViewComponents/Iframe/Iframe.cshtml", node);
        }
    }
}
