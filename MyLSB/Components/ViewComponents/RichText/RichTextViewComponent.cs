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
    public class RichTextViewComponent : ViewComponent
    {
        public RichTextViewComponent()
        {
        }

        public IViewComponentResult Invoke(RichText node)
        {
            if (node.Parent.ClassName == Partials.CLASS_NAME)
            {
                return View("~/Components/ViewComponents/RichText/RichTextContainer.cshtml", node.RichTextText);
            }
            return View("~/Components/ViewComponents/RichText/RichText.cshtml", node.RichTextText);
        }
    }
}
