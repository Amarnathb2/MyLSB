using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class SectionSubpagesViewComponent : ViewComponent
    {
        private readonly NavigationRepository navigationRepository;

        public SectionSubpagesViewComponent(NavigationRepository navigationRepository)
        {
            this.navigationRepository = navigationRepository;
        }

        public IViewComponentResult Invoke(SectionSubpages node)
        {
            IEnumerable<SectionSubpageGroupViewModel> subpages = navigationRepository.GetMenuItems(node.SectionSubpagesPath)
                                                                                     .OfType<PageGroup>()
                                                                                     .Select(pageGroup => SectionSubpageGroupViewModel.GetViewModel(pageGroup, navigationRepository));

            if (subpages.Any())
            {
                return View("~/Components/ViewComponents/SectionSubpages/SectionSubpages.cshtml", subpages);
            }

            return Content(String.Empty);
        }
    }
}
