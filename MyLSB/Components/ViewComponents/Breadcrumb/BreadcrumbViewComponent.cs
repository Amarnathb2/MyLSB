using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components.ViewComponents
{
    public class BreadcrumbViewComponent : ViewComponent
    {
        private readonly IPageDataContextRetriever pageDataContextRetriever;
        private readonly NavigationRepository navigationRepository;

        public BreadcrumbViewComponent(IPageDataContextRetriever pageDataContextRetriever, NavigationRepository navigationRepository)
        {
            this.pageDataContextRetriever = pageDataContextRetriever;
            this.navigationRepository = navigationRepository;
        }

        public IViewComponentResult Invoke()
        {
            var breadcrumb = BreadcrumbViewModel.GetViewModel(pageDataContextRetriever, navigationRepository);

            return View("~/Components/ViewComponents/Breadcrumb/Breadcrumb.cshtml", breadcrumb);
        }
    }
}