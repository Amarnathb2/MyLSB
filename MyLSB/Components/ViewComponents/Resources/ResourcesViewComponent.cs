using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class ResourcesViewComponent : ViewComponent
    {
        public ResourcesViewComponent()
        {
        }

        public IViewComponentResult Invoke(Resources node)
        {
            return View("~/Components/ViewComponents/Resources/Resources.cshtml", node);
        }
    }
}