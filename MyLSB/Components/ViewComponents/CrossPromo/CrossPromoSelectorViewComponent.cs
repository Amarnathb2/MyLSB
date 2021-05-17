using CMS.DocumentEngine.Types.Custom;
using CMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class CrossPromoSelectorViewComponent : ViewComponent
    {
        public CrossPromoSelectorViewComponent()
        {
        }

        public IViewComponentResult Invoke(CrossPromoSelector node)
        {
            var promo = CacheHelper.Cache(cs =>
            {
                var promo = node.Fields.Promo.OfType<CrossPromo>().FirstOrDefault();
                
                if (cs.Cached)
                {
                    cs.CacheDependency = CacheHelper.GetCacheDependency(new string[] {
                        $"nodeid|{node.NodeID}",
                        $"nodeid|{promo.NodeID}"
                    });
                }
                
                return promo;

            }, new CacheSettings(10, $"{nameof(CrossPromoSelector)}|{node.NodeID}"));            
            
            if (promo != null)
            {
                return View("~/Components/ViewComponents/CrossPromo/CrossPromo.cshtml", promo);
            }
            
            return Content(String.Empty);
        }
    }
}