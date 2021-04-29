using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class TaglineSelectorViewComponent : ViewComponent
    {
        public TaglineSelectorViewComponent()
        {
        }

        public IViewComponentResult Invoke(TaglineSelector node)
        {
            var tagline = node.Fields.Tagline.OfType<Tagline>().FirstOrDefault();

            if (tagline != null)
            {
                if (node.Parent.ClassName == Partials.CLASS_NAME)
                {
                    return View("~/Components/ViewComponents/RichText/RichTextContainer.cshtml", tagline.Fields.Text);
                }
                return View("~/Components/ViewComponents/RichText/RichText.cshtml", tagline.Fields.Text);
            }

            return Content(String.Empty);
        }
    }
}