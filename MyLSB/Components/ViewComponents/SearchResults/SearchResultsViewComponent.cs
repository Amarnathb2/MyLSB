using MyLSB.Models;
using MyLSB.Repository;
using CMS.Activities.Loggers;
using CMS.Core;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using CMS.Search;
using CMS.WebAnalytics;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace MyLSB.Components
{
    public class SearchResultsViewComponent : ViewComponent
    {

        private readonly IPageUrlRetriever pageUrlRetriever;
        private readonly IPagesActivityLogger pageActivityLogger;

        public SearchResultsViewComponent(IPageUrlRetriever pageUrlRetriever)
        {
            this.pageUrlRetriever = pageUrlRetriever;
            this.pageActivityLogger = Service.Resolve<IPagesActivityLogger>();
        }

        public IViewComponentResult Invoke(CMS.DocumentEngine.Types.Custom.SearchResults node)
        {
            //var results = SearchResultsViewModel.GetViewModel(node, Request);

            //if (string.IsNullOrWhiteSpace(results.SearchTerm))
            //{
            //    results.Pages = new StaticPagedList<TreeNode>(Enumerable.Empty<TreeNode>(), 1, results.SearchPageSize, 0);
            //}
            //else
            //{
            //    SearchResult searchResults = PageRepository.GetSearchResults(results.SearchTerm, results.SearchIndex, results.SearchPage);

            //    // Validate page number (starting from 1)
            //    results.SearchPage = Math.Max(results.SearchPage, 1);

            //    IEnumerable<TreeNode> searchResultItems = searchResults.Items.Select(result => result.Data as TreeNode);
            //    foreach (var result in searchResultItems)
            //    {
            //        result.LoadInheritedValues(new[] { "DocumentPageDescription" });
            //    }

            //    results.Pages = new StaticPagedList<TreeNode>(searchResultItems, results.SearchPage, results.SearchPageSize, searchResults.TotalNumberOfResults);
            //}

            //pageActivityLogger.LogInternalSearch(Request.Query["searchtext"]);

            //return View("~/Components/ViewComponents/SearchResults/SearchResults.cshtml", results);

            return View("~/Components/ViewComponents/SearchResults/SearchResults.cshtml");
        }
    }
}