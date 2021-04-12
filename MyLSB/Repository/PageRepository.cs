using CMS.DocumentEngine;
using CMS.Helpers;
using CMS.Membership;
using CMS.Search;
using CMS.SiteProvider;
using Kentico.Content.Web.Mvc;
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

        public PageRepository(IPageRetriever pageRetriever)
        {
            this.pageRetriever = pageRetriever;
        }

        public static List<TreeNode> GetPages(string path)
        {
            return CacheHelper.Cache(cs =>
            {
                if (cs.Cached) { cs.CacheDependency = CacheHelper.GetCacheDependency($"node|{SiteContext.CurrentSiteName}|{path}|childnodes"); }
                return DocumentHelper.GetDocuments()
                    .Types("Custom.PageDefault", "Custom.PageGroup", "Custom.PageRedirect", "Custom.PageBlog", "Custom.PageBio", "Custom.PageLanding")
                    .Path(path, PathTypeEnum.Children)
                    .NestingLevel(1)
                    .MenuItems()
                    //.Columns("ClassName", "NodeGUID", "NodeAliasPath", "DocumentName")
                    .OrderBy("NodeOrder")
                    .PublishedVersion()
                    .Published()
                    .ToList();

            }, new CacheSettings(10, $"Pages|{SiteContext.CurrentSiteName}|{path}"));
        }

        public static List<TreeNode> GetPagesSitemap(string path)
        {
            return CacheHelper.Cache(cs =>
            {
                if (cs.Cached) { cs.CacheDependency = CacheHelper.GetCacheDependency($"node|{SiteContext.CurrentSiteName}|{path}|childnodes"); }
                return DocumentHelper.GetDocuments()
                    .Types("Custom.PageDefault", "Custom.PageGroup", "Custom.PageRedirect", "Custom.PageBlog", "Custom.PageBio", "Custom.PageLanding")
                    .Path(path, PathTypeEnum.Children)
                    .NestingLevel(1)
                    .WhereNotEquals("DocumentSitemapExcluded", 1)
                    //.Columns("ClassName", "NodeGUID", "NodeAliasPath", "DocumentName")
                    .OrderBy("NodeOrder")
                    .PublishedVersion()
                    .Published()
                    .ToList();

            }, new CacheSettings(10, $"PagesSitemap|{SiteContext.CurrentSiteName}|{path}"));
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

        public static SearchResult GetPagesSearchResults(string term, string index, int page = 1, int PAGE_SIZE = 10)
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