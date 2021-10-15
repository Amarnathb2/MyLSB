using MyLSB.Models;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using CMS.SiteProvider;
using Kentico.Content.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using MyLSB.Infrastructure;

namespace MyLSB.Repository
{
    public class NavigationRepository
    {
        private readonly IPageRetriever pageRetriever;
        private readonly IPageDataContextRetriever pageDataContextRetriever;
        private readonly RepositoryCacheHelper repositoryCacheHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationRepository"/> class.
        /// </summary>
        /// <param name="pageRetriever">The page retriever.</param>
        public NavigationRepository(IPageRetriever pageRetriever, IPageDataContextRetriever pageDataContextRetriever, RepositoryCacheHelper repositoryCacheHelper)
        {
            this.pageRetriever = pageRetriever;
            this.pageDataContextRetriever = pageDataContextRetriever;
            this.repositoryCacheHelper = repositoryCacheHelper;
        }

        /// <summary>
        /// Returns an enumerable collection of menu items ordered by the content tree order and level.
        /// </summary>
        public IEnumerable<TreeNode> GetMenuItems(string path)
        {
            return pageRetriever.Retrieve<TreeNode>(
                query => query
                    .Path(path, PathTypeEnum.Children)
                    .MenuItems()
                    .NestingLevel(1)                    
                    .OrderByAscending("NodeOrder"),
                cache => cache
                    .Key($"{nameof(NavigationRepository)}|{nameof(GetMenuItems)}|{path}")
                    .Dependencies((_, builder) => builder.PagePath(path, PathTypeEnum.Children)
                                                         .PageOrder()));
        }

        /// <summary>
        /// Returns an enumerable collection of auxiliary navigation links ordered by the content tree order.
        /// </summary>
        public IEnumerable<Link> GetAuxiliaryNavItems()
        {
            return pageRetriever.Retrieve<Link>(
                query => query
                    .Path(ContentItemIdentifiers.AUXILIARY_NAVIGATION, PathTypeEnum.Children)
                    .OrderByAscending("NodeOrder"),
                cache => cache
                    .Key($"{nameof(NavigationRepository)}|{nameof(GetAuxiliaryNavItems)}")
                    .Dependencies((_, builder) => builder.Pages(Link.CLASS_NAME)
                                                         .PageOrder()
                                                         .PagePath(ContentItemIdentifiers.AUXILIARY_NAVIGATION)));
        }

        /// <summary>
        /// Returns an enumerable collection of pages on the same path as the current page.
        /// </summary>
        public IEnumerable<TreeNode> GetBreadcrumbItems(TreeNode node)
        {
            return repositoryCacheHelper.CachePages(() =>
            {
                return node.DocumentsOnPath.Skip(1);
            }, $"{nameof(NavigationRepository)}|{nameof(GetBreadcrumbItems)}|{node.NodeID}", new[]
            {
                $"node|{SiteContext.CurrentSiteName}|{node.NodeID}"
            });
        }

        public IEnumerable<TreeNode> GetSiteMapItems(string path)
        {
            return pageRetriever.RetrieveMultiple(
                query => query
                    .Types(ContentItemIdentifiers.SITEMAP_PAGETYPES)
                    .Path(path, PathTypeEnum.Children)
                    .OnCurrentSite()
                    .WhereTrue("ShowInSitemap")
                    .NestingLevel(1)
                    .OrderByAscending("NodeOrder"),
                cache => cache
                    .Key($"{nameof(NavigationRepository)}|{nameof(GetSiteMapItems)}|{path}")
                    .Dependencies((_, builder) => builder.PagePath(path, PathTypeEnum.Children)
                                                         .PageOrder()));

        }
    }
}
