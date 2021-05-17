using MyLSB.Models.Pages;
using MyLSB.Repository;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Html;
using System.Collections.Generic;
using System.Linq;
using MyLSB.Models;
using CMS.Helpers;

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
                NewTab = node.ClassName == PageRedirect.CLASS_NAME && ((PageRedirect)node).PageRedirectNewTab
            };
        }

        public static MenuItemViewModel GetViewModel(TreeNode node, string currentPath)
        {
            return new MenuItemViewModel(node)
            {
                NodeLevel = node.NodeLevel,
                Text = node.DocumentName,
                Url = GetMenuItemUrl(node),
                NewTab = node.ClassName == PageRedirect.CLASS_NAME && ((PageRedirect)node).PageRedirectNewTab,
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
                NewTab = node.ClassName == PageRedirect.CLASS_NAME && ((PageRedirect)node).PageRedirectNewTab,
                Children = navigationRepository.GetMenuItems(node.NodeAliasPath).Select(node => GetViewModel(node, navigationRepository)) ?? Enumerable.Empty<MenuItemViewModel>()
            };
        }

        public static MenuItemViewModel GetViewModel(TreeNode node, string currentPath, NavigationRepository navigationRepository)
        {
            var resources = CacheHelper.Cache(cs =>
            {
                var links = node.NodeLevel == 1 && node.ClassName == PageDefault.CLASS_NAME ? (node as PageDefault).Fields.Resources.OfType<Link>() : Enumerable.Empty<Link>();

                if (cs.Cached)
                {
                    var cacheKeys = new string[] { $"nodeid|{node.NodeID}" };

                    foreach (var link in links)
                    {
                        cacheKeys.Append($"nodeid|{link.NodeID}");
                    }

                    cs.CacheDependency = CacheHelper.GetCacheDependency(cacheKeys);
                }

                return links.Select(link => LinkViewModel.GetViewModel(link));

            }, new CacheSettings(10, $"{nameof(MenuItemViewModel)}|{node.NodeID}"));

            return new MenuItemViewModel(node)
            {
                NodeLevel = node.NodeLevel,
                Text = node.DocumentName,
                Url = GetMenuItemUrl(node),
                NewTab = node.ClassName == PageRedirect.CLASS_NAME && ((PageRedirect)node).PageRedirectNewTab,
                Children = navigationRepository.GetMenuItems(node.NodeAliasPath).Select(node => GetViewModel(node, currentPath, navigationRepository)) ?? Enumerable.Empty<MenuItemViewModel>(),
                IsActive = currentPath.StartsWith(node.NodeAliasPath),
                Resources = resources
            };
        }

        protected static string GetMenuItemUrl(TreeNode node)
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
