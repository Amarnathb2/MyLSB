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
    public class ProductsServicesTabViewModel : TreeNodeViewModel
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public IEnumerable<ProductServicePromo> Promos { get; set; }

        protected ProductsServicesTabViewModel(TreeNode node) : base(node)
        {
        }

        public static ProductsServicesTabViewModel GetViewModel(ProductsServicesTab tab)
        {
            return new ProductsServicesTabViewModel(tab)
            {
                Name = tab.ProductsServicesTabName,
                Icon = tab.ProductsServicesTabIcon,
                Promos = CacheHelper.Cache(cs =>
                {
                    var promos = tab.Fields.Promos.OfType<ProductServicePromo>().Take(2);

                    if (cs.Cached)
                    {
                        var cacheKeys = new string[] { $"nodeid|{tab.NodeID}" };
                        foreach (var promo in promos)
                        {
                            cacheKeys.Append($"nodeid|{promo.NodeID}");
                        }

                        cs.CacheDependency = CacheHelper.GetCacheDependency(cacheKeys);
                    }

                    return promos;

                }, new CacheSettings(10, $"{nameof(ProductsServicesTabViewModel)}|{tab.NodeID}"))
            };
        }
    }
}
