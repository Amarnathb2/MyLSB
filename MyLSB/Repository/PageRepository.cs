using CMS.DocumentEngine;
using CMS.Helpers;
using CMS.Membership;
using CMS.Search;
using CMS.SiteProvider;
using Kentico.Content.Web.Mvc;
using MyLSB.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace MyLSB.Repository
{
    /// <summary>
    /// Represents a collection of navigation items.
    /// </summary>
    public class PageRepository
    {
        private readonly IPageRetriever pageRetriever;
        private readonly RepositoryCacheHelper repositoryCacheHelper;

        public PageRepository(IPageRetriever pageRetriever, RepositoryCacheHelper repositoryCacheHelper)
        {
            this.pageRetriever = pageRetriever;
            this.repositoryCacheHelper = repositoryCacheHelper;
        }

        public IEnumerable<TreeNode> GetPages(string path)
        {
            return pageRetriever.Retrieve<TreeNode>(
                query => query
                    .Path(path, PathTypeEnum.Children)
                    .NestingLevel(1)
                    .OrderByAscending("NodeOrder"),
                cache => cache
                    .Key($"{nameof(PageRepository)}|{nameof(GetPages)}|{path}")
                    .Dependencies((_, builder) => builder.PagePath(path, PathTypeEnum.Children)
                                                         .PageOrder()));

            //return CacheHelper.Cache(cs =>
            //{
            //    if (cs.Cached) { cs.CacheDependency = CacheHelper.GetCacheDependency($"node|{SiteContext.CurrentSiteName}|{path}|childnodes"); }
            //    return DocumentHelper.GetDocuments()
            //        .Types("custom.pagedefault", "custom.pagegroup", "custom.pageredirect")
            //        .Path(path, PathTypeEnum.Children)
            //        .NestingLevel(1)
            //        .MenuItems()
            //        .OrderBy("NodeOrder")
            //        .PublishedVersion()
            //        .Published()
            //        .ToList();

            //}, new CacheSettings(10, $"Pages|{SiteContext.CurrentSiteName}|{path}"));
        }

        public IEnumerable<TreeNode> GetPagesSitemap(string path)
        {
            //return CacheHelper.Cache(cs =>
            //{
            //    if (cs.Cached) { cs.CacheDependency = CacheHelper.GetCacheDependency($"node|{SiteContext.CurrentSiteName}|{path}|childnodes"); }
            //    return DocumentHelper.GetDocuments()
            //        .Types("Custom.PageDefault", "Custom.PageGroup", "Custom.PageRedirect", "Custom.PageBlog", "Custom.PageBio", "Custom.PageLanding")
            //        .Path(path, PathTypeEnum.Children)
            //        .NestingLevel(1)
            //        .WhereNotEquals("DocumentSitemapExcluded", 1)
            //        //.Columns("ClassName", "NodeGUID", "NodeAliasPath", "DocumentName")
            //        .OrderBy("NodeOrder")
            //        .PublishedVersion()
            //        .Published()
            //        .ToList();

            //}, new CacheSettings(10, $"PagesSitemap|{SiteContext.CurrentSiteName}|{path}"));


            return repositoryCacheHelper.CachePages(() =>
            {
                return DocumentHelper.GetDocuments()
                    .Types("Custom.PageDefault", "Custom.PageGroup", "Custom.PageRedirect", "Custom.PageLanding")
                    .OnCurrentSite()
                    .NestingLevel(1)
                    // Get Type-specific columns for the subclasses returned.
                    .WithCoupledColumns()
                    .OrderByAscending("NodeOrder");

            }, $"{nameof(PageRepository)}|{nameof(GetPagesSitemap)}|{path}", new[]
            {
                $"node|{SiteContext.CurrentSiteName}|{path}|childnodes"
            }) ?? Enumerable.Empty<TreeNode>();
        }

        public static List<TreeNode> GetBreadcrumbs(string path)
        {
            return CacheHelper.Cache(cs =>
            {
                if (cs.Cached) { cs.CacheDependency = CacheHelper.GetCacheDependency($"node|{SiteContext.CurrentSiteName}|{path}|childnodes"); }

                TreeNode page = DocumentHelper.GetDocuments().Path(path).FirstOrDefault();
                return page.DocumentsOnPath.Skip(1).ToList();

            }, new CacheSettings(10, $"Breadcrumbs|{SiteContext.CurrentSiteName}|{path}"));
        }

        public static SearchResult GetSearchResults(string term, string index, int page = 1, int PAGE_SIZE = 10)
        {
            int DEFAULT_PAGE_NUMBER = 1;

            // Validate page number (starting from 1)
            page = Math.Max(page, DEFAULT_PAGE_NUMBER);

            SearchParameters searchParameters = SearchParameters.PrepareForPages(term, new[] { index }, page, PAGE_SIZE, MembershipContext.AuthenticatedUser);
            SearchResult searchResults = SearchHelper.Search(searchParameters);

            return searchResults;
        }

        public string GetNodeAliasPath(int nodeId)
        {
            return pageRetriever.Retrieve<TreeNode>(
                  query => query
                       .Column("NodeAliasPath")
                       .WhereEquals("NodeID", nodeId)
                       .TopN(1),
                  cache => cache
                      .Key($"{nameof(PageRepository)}|{nameof(GetNodeAliasPath)}|{nodeId}")
                      .Dependencies((_, builder) => builder.Custom($"nodeid|{nodeId}")))
                .FirstOrDefault()
                .NodeAliasPath;
        }
    }
}