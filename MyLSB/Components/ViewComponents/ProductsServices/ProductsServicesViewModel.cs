using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using MyLSB.Models;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class ProductsServicesViewModel : TreeNodeViewModel
    {
        public string Heading { get; set; }
        public IEnumerable<ProductsServicesTabViewModel> Tabs { get; set; }

        protected ProductsServicesViewModel(TreeNode node) : base(node)
        {
        }

        public static ProductsServicesViewModel GetViewModel(ProductsServices node, ProductsServicesRepository productsServicesRepository)
        {
            return new ProductsServicesViewModel(node)
            {
                Heading = node.ProductsServicesHeading,
                Tabs = productsServicesRepository.GetTabs(node.NodeAliasPath).Select(tab => ProductsServicesTabViewModel.GetViewModel(tab))
            };
        }
    }
}
