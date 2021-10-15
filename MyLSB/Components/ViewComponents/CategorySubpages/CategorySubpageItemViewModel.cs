using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using CMS.Helpers;
using MyLSB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class CategorySubpageItemViewModel : MenuItemViewModel
    {
        public string Summary { get; set; }

        private CategorySubpageItemViewModel(TreeNode node) : base(node)
        {
        }

        public static new CategorySubpageItemViewModel GetViewModel(TreeNode node)
        {
            return CacheHelper.Cache(cs =>
            {                
                node.MakeComplete(true);

                if (cs.Cached)
                {
                    cs.CacheDependency = CacheHelper.GetCacheDependency($"nodeid|{node.NodeID}");
                }

                return new CategorySubpageItemViewModel(node)
                {
                    Text = node.DocumentName,
                    Url = GetMenuItemUrl(node),
                    NewTab = node.ClassName == PageRedirect.CLASS_NAME && ((PageRedirect)node).PageRedirectNewTab,
                    Summary = node.GetStringValue("Summary", "")
                };

            }, new CacheSettings(10, $"{nameof(CategorySubpageItemViewModel)}|{node.NodeID}"));
        }
    }
}