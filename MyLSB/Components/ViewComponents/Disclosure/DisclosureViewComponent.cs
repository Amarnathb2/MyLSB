using MyLSB.Models;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class DisclosureViewComponent : ViewComponent
    {
        public DisclosureViewComponent()
        {
        }

        public IViewComponentResult Invoke(Disclosure node)
        {
            if (node.Parent.ClassName == Partials.CLASS_NAME)
            {
                return View("~/Components/ViewComponents/Disclosure/ContainerDisclosure.cshtml", node);
            }
            return View("~/Components/ViewComponents/Disclosure/Disclosure.cshtml", node);
        }
    }
}
