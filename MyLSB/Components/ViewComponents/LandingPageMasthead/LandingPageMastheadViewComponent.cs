using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;
namespace MyLSB.Components
{
    public class LandingPageMastheadViewComponent : ViewComponent
    {
        public LandingPageMastheadViewComponent()
        {
        }

        public IViewComponentResult Invoke(LandingPageMasthead node)
        {
            var model = LandingPageMastheadViewModel.GetViewModel(node);
            return View("~/Components/ViewComponents/LandingPageMasthead/LandingPageMasthead.cshtml", model);
        }
    }
}