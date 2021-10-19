using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class HubSpotFormViewComponent : ViewComponent
    {
        public HubSpotFormViewComponent()
        {
        }

        public IViewComponentResult Invoke(HubSpotForm node)
        {
            if (node.Parent.ClassName == Partials.CLASS_NAME)
            {
                return View("~/Components/ViewComponents/HubSpotForm/HubSpotFormContainer.cshtml", node);
            }
            return View("~/Components/ViewComponents/HubSpotForm/HubSpotForm.cshtml", node);
        }
    }
}
