using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class LandingPageContentViewComponent : ViewComponent
    {
        public LandingPageContentViewComponent()
        {            
        }

        public IViewComponentResult Invoke(LandingPageContent node)
        {
            if(node.LandingPageContentHasForm)
            {
                return View("~/Components/ViewComponents/LandingPageContent/LandingPageContentForm.cshtml", node);
            }

            return View("~/Components/ViewComponents/LandingPageContent/LandingPageContent.cshtml", node);
        }
    }
}
