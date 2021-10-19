using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class PromoBandViewComponent : ViewComponent
    {
        public PromoBandViewComponent()
        {
        }

        public IViewComponentResult Invoke(PromoBand node)
        {
            return View("~/Components/ViewComponents/PromoBand/PromoBand.cshtml", node);
        }
    }
}