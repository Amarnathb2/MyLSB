using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
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
    public class InternalNavViewComponent : ViewComponent
    {
        private readonly IPageDataContextRetriever pageDataContextRetriever;
        private readonly NavigationRepository navigationRepository;

        public InternalNavViewComponent(IPageDataContextRetriever pageDataContextRetriever, NavigationRepository navigationRepository)
        {
            this.pageDataContextRetriever = pageDataContextRetriever;
            this.navigationRepository = navigationRepository;
        }

        public IViewComponentResult Invoke()
        {
            var currentPage = pageDataContextRetriever.Retrieve<TreeNode>().Page;

            if (currentPage.NodeLevel <= 1)
            {
                return Content(string.Empty);
            }

            var startingNode = GetStartingNode(currentPage);
            if (startingNode == null)
            {
                return Content(string.Empty);
            }

            var menuItem = MenuItemViewModel.GetViewModel(startingNode, startingNode.NodeAliasPath, navigationRepository);

            return View("~/Components/ViewComponents/InternalNav/InternalNav.cshtml", menuItem);
        }

        private TreeNode GetStartingNode(TreeNode node)
        {
            if (node.Parent.ClassName == PageGroup.CLASS_NAME)
            {
                return node;
            }

            return node.Parent;
        }
    }
}
