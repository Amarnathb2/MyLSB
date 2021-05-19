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
    public class SectionSubpageGroupViewModel : TreeNodeViewModel
    {        
        public string Heading { get; set; }
        public string Icon { get; set; }
        public IEnumerable<MenuItemViewModel> Children { get; set; }
        public PageGroupPromo Promo { get; set; }

        protected SectionSubpageGroupViewModel(TreeNode node) : base(node)
        {
        }

        public static SectionSubpageGroupViewModel GetViewModel(PageGroup pageGroup, NavigationRepository navigationRepository)
        {
            return CacheHelper.Cache(cs =>
            {
                pageGroup.MakeComplete(true);

                var promo = pageGroup.Fields.Promo.OfType<PageGroupPromo>().FirstOrDefault();

                if (cs.Cached)
                {
                    var keys = new string[] { $"nodeid|{pageGroup.NodeID}" };

                    if (promo is not null)
                    {
                        keys.Append($"nodeid|{promo.NodeID}");
                    }

                    cs.CacheDependency = CacheHelper.GetCacheDependency(keys);
                }

                return new SectionSubpageGroupViewModel(pageGroup)
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
