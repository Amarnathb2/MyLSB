using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;

namespace MyLSB.Components
{
    public class MastheadViewComponent : ViewComponent
    {
        public MastheadViewComponent()
        {
        }

        public IViewComponentResult Invoke(Masthead node)
        {
            var model = MastheadViewModel.GetViewModel(node);
            return View("~/Components/ViewComponents/Masthead/Masthead.cshtml", model);
        }
    }
}