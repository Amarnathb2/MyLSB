using CMS.DocumentEngine.Types.Custom;
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
            var promo = node.Fields.Promo.OfType<CrossPromo>().FirstOrDefault();
            
            if (promo != null)
            {
                return View("~/Components/ViewComponents/CrossPromo/CrossPromo.cshtml", promo);
            }
            
            return Content(String.Empty);
        }
    }
}