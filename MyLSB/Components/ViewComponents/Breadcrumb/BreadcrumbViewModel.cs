using CMS.DocumentEngine;
using Kentico.Content.Web.Mvc;
using MyLSB.Models;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class BreadcrumbViewModel
    {
        public string CurrentPageUrl { get; set; }
        public IEnumerable<MenuItemViewModel> BreadcrumbItems { get; set; }

        public static BreadcrumbViewModel GetViewModel(IPageDataContextRetriever pageDataContextRetriever, NavigationRepository navigationRepository)
        {
            var currentPage = pageDataContextRetriever.Retrieve<TreeNode>().Page;

            return new BreadcrumbViewModel
            {
                CurrentPageUrl = DocumentURLProvider.GetUrl(currentPage),
                BreadcrumbItems = navigationRepository.GetBreadcrumbItems(currentPage)
            };
        }
    }
}
