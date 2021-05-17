using CMS.DocumentEngine.Types.Custom;
using CMS.Helpers;
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
            var tagline = CacheHelper.Cache(cs =>
            {
                var tagline = node.Fields.Tagline.OfType<Tagline>().FirstOrDefault();

                if (cs.Cached)
                {
                    cs.CacheDependency = CacheHelper.GetCacheDependency(new string[] {
                        $"nodeid|{node.NodeID}",
                        $"nodeid|{tagline.NodeID}"
                    });
                }

                return tagline;

            }, new CacheSettings(10, $"{nameof(TaglineSelector)}|{node.NodeID}"));

            if (tagline != null)
            {
                if (node.Parent.ClassName == Partials.CLASS_NAME)
                {
                    return View("~/Components/ViewComponents/RichText/RichTextContainer.cshtml", tagline.TaglineText);
                }
                return View("~/Components/ViewComponents/RichText/RichText.cshtml", tagline.TaglineText);
            }

            return Content(String.Empty);
        }
    }
}