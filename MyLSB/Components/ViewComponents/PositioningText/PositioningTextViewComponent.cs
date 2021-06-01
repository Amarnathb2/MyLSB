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
    public class PositioningTextViewComponent : ViewComponent
    {
        public PositioningTextViewComponent()
        {
        }

        public IViewComponentResult Invoke(PositioningText node)
        {
            return View("~/Components/ViewComponents/PositioningText/PositioningText.cshtml", node);
        }
    }
}
