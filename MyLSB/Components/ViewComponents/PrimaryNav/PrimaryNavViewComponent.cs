using CMS.DocumentEngine;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using MyLSB.Models;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class PrimaryNavViewComponent : ViewComponent
    {
        private readonly NavigationRepository navigationRepository;
        private readonly IPageDataContextRetriever pageDataContextRetriever;

        public PrimaryNavViewComponent(NavigationRepository navigationRepository, IPageDataContextRetriever pageDataContextRetriever)
        {
            this.navigationRepository = navigationRepository;
            this.pageDataContextRetriever = pageDataContextRetriever;
        }

        public IViewComponentResult Invoke()
        {
            var currentPath = pageDataContextRetriever.Retrieve<TreeNode>().Page.NodeAliasPath;
            var menuItems = navigationRepository.GetMenuItems("/")
                                                .Select(page => MenuItemViewModel.GetViewModel(page, currentPath, navigationRepository));

            return View("~/Components/ViewComponents/PrimaryNav/PrimaryNav.cshtml", menuItems);
        }
    }
}
