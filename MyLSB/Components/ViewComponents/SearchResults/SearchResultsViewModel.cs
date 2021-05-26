using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using CMS.Helpers;
using Microsoft.AspNetCore.Http;
using MyLSB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace MyLSB.Components
{
    public class SearchResultsViewModel : TreeNodeViewModel
    {
        public string SearchIndex { get; set; }
        public string SearchTerm { get; set; }
        public int SearchPage { get; set; }
        public int SearchPageSize { get; set; }
        public StaticPagedList<TreeNode> Pages { get; set; }

        protected SearchResultsViewModel(TreeNode node) : base(node)
        {
        }

        public static SearchResultsViewModel GetViewModel(SearchResults node, HttpRequest request)
        {
            int.TryParse(request.Query["page"], out int page);

            return new SearchResultsViewModel(node)
            {
                SearchIndex = node.SearchResultsSearchIndex,
                SearchTerm = request.Query["searchtext"],
                SearchPage = page,
                SearchPageSize = 10
            };
        }
    }
}
