using CMS.DocumentEngine.Types.Custom;
using CMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using MyLSB.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class CrossPromoSelectorViewComponent : ViewComponent
    {
        private readonly RepositoryCacheHelper repositoryCacheHelper;

        public CrossPromoSelectorViewComponent(RepositoryCacheHelper repositoryCacheHelper)
        {
            this.repositoryCacheHelper = repositoryCacheHelper;
        }

        public IViewComponentResult Invoke(CrossPromoSelector node)
        {
            var promo = CacheHelper.Cache(cs =>
            {
                var relatedPromo = node.Fields.Promo.OfType<CrossPromo>().FirstOrDefault();

                if (cs.Cached)
                {
                    cs.CacheDependency = CacheHelper.GetCacheDependency(new string[] {
                        $"nodeid|{node.NodeID}",
                        $"nodeid|{relatedPromo.NodeID}"
                    });
                }

                return relatedPromo;

            }, new CacheSettings(10, $"{nameof(CrossPromoSelector)}|{node.NodeID}"));

            if (promo is not null)
            {
                return View("~/Components/ViewComponents/CrossPromo/CrossPromo.cshtml", promo);
            }
            
            return Content(String.Empty);
        }
    }
}