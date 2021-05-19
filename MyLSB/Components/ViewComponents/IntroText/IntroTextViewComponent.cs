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
    public class IntroTextViewComponent : ViewComponent
    {
        public IntroTextViewComponent()
        {
        }

        public IViewComponentResult Invoke(IntroText node)
        {
            return View("/Components/ViewComponents/IntroText/IntroText.cshtml", node);
        }
    }
}
