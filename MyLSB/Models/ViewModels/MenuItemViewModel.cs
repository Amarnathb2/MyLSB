using MyLSB.Models.Pages;
using MyLSB.Repository;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Html;
using System.Collections.Generic;
using System.Linq;
using BHFCU.Models;

namespace MyLSB.Models
{
    public class MenuItemViewModel : TreeNodeViewModel
    {
        public int NodeLevel { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public bool NewTab { get; set; }
        public IEnumerable<MenuItemViewModel> Children { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<LinkViewModel> Resources { get; set; }

        protected MenuItemViewModel(TreeNode node) : base(node)
        {
        }

        public static MenuItemViewModel GetViewModel(TreeNode node)
        {
            return new MenuItemViewModel(node)
            {
                NodeLevel = node.NodeLevel,
                Text = node.DocumentName,
                Url = GetMenuItemUrl(node),
                NewTab = node.ClassName == PageRedirect.CLASS_NAME && ((PageRedirect)node).Fields.NewTab
            };
        }

        public static MenuItemViewModel GetViewModel(TreeNode node, string currentPath)
        {
            return new MenuItemViewModel(node)
            {
                NodeLevel = node.NodeLevel,
                Text = node.DocumentName,
                Url = GetMenuItemUrl(node),
                NewTab = node.ClassName == PageRedirect.CLASS_NAME && ((PageRedirect)node).Fields.NewTab,
                IsActive = node.NodeAliasPath.StartsWith(currentPath),
            };
        }

        public static MenuItemViewModel GetViewModel(TreeNode node, NavigationRepository navigationRepository)
        {
            return new MenuItemViewModel(node)
            {
                NodeLevel = node.NodeLevel,
                Text = node.DocumentName,
                Url = GetMenuItemUrl(node),
                NewTab = node.ClassName == PageRedirect.CLASS_NAME && ((PageRedirect)node).Fields.NewTab,
                Children = navigationRepository.GetMenuItems(node.NodeAliasPath).Select(node => GetViewModel(node, navigationRepository)) ?? Enumerable.Empty<MenuItemViewModel>()
            };
        }

        public static MenuItemViewModel GetViewModel(TreeNode node, string currentPath, NavigationRepository navigationRepository)
        {
            var resources = node.NodeLevel == 1 && node.ClassName == PageGroup.CLASS_NAME ? (node as PageGroup).Fields.Resources.OfType<Link>().Select(link => LinkViewModel.GetViewModel(link)) : Enumerable.Empty<LinkViewModel>();

            return new MenuItemViewModel(node)
            {
                NodeLevel = node.NodeLevel,
                Text = node.DocumentName,
                Url = GetMenuItemUrl(node),
                NewTab = node.ClassName == PageRedirect.CLASS_NAME && ((PageRedirect)node).Fields.NewTab,
                Children = navigationRepository.GetMenuItems(node.NodeAliasPath).Select(node => GetViewModel(node, currentPath, navigationRepository)) ?? Enumerable.Empty<MenuItemViewModel>(),
                IsActive = currentPath.StartsWith(node.NodeAliasPath),
                Resources = resources
            };
        }

        private static string GetMenuItemUrl(TreeNode node)
        {
            switch (node.ClassName)
            {
                case PageGroup.CLASS_NAME:
                    return "#";

                case PageRedirect.CLASS_NAME:
                    node.MakeComplete(true);
                    return node.GetStringValue("PageRedirectUrl", DocumentURLProvider.GetUrl(node));

                default:
                    return DocumentURLProvider.GetUrl(node);
            }
        }
    }
}
