using MyLSB.Models;
using MyLSB.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class SitemapViewComponent : ViewComponent
    {
        private readonly NavigationRepository navigationRepository;

        public SitemapViewComponent(NavigationRepository navigationRepository)
        {
            this.navigationRepository = navigationRepository;
        }

        public IViewComponentResult Invoke()
        {
            var sitemap = navigationRepository.GetSiteMapItems("/")
                            .Select(node => SitemapItemViewModel.GetViewModel(node, navigationRepository));

            return View("~/Components/ViewComponents/Sitemap/Sitemap.cshtml", sitemap);
        }
    }
}
