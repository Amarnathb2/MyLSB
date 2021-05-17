using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using CMS.Helpers;
using MyLSB.Models;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class SectionSubpageGroupViewModel
    {
        public string Heading { get; set; }
        public string Icon { get; set; }
        public IEnumerable<MenuItemViewModel> Children { get; set; }
        public TreeNode Promo { get; set; }

        public static SectionSubpageGroupViewModel GetViewModel(PageGroup pageGroup, NavigationRepository navigationRepository)
        {
            return CacheHelper.Cache(cs =>
            {
                var promo = pageGroup.Fields.Promo.FirstOrDefault();

                if (cs.Cached)
                {
                    var keys = new string[] { $"nodeid|{pageGroup.NodeID}" };

                    if (promo is not null)
                    {
                        keys.Append($"nodeid|{promo.NodeID}");
                    }

                    cs.CacheDependency = CacheHelper.GetCacheDependency(keys);
                }

                return new SectionSubpageGroupViewModel
                {
                    Heading = pageGroup.DocumentName,
                    Icon = pageGroup.PageGroupIcon,
                    Children = navigationRepository.GetMenuItems(pageGroup.NodeAliasPath).Select(page => MenuItemViewModel.GetViewModel(page)),
                    Promo = promo
                };

            }, new CacheSettings(10, $"{nameof(SectionSubpageGroupViewModel)}|{nameof(GetViewModel)}|{pageGroup.NodeID}"));
        }
    }
}
