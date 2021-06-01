using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Repository
{
    public class ProductsServicesRepository
    {
        private readonly IPageRetriever pageRetriever;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsServicesRepository"/> class that returns ProductsServices.
        /// </summary>
        /// <param name="pageRetriever">Retriever for pages based on given parameters.</param>
        public ProductsServicesRepository(IPageRetriever pageRetriever)
        {
            this.pageRetriever = pageRetriever;
        }

        /// <summary>
        /// Returns an enumerable collection of ProductsServicesTabs ordered by a position in the content tree.
        /// </summary>
        public IEnumerable<ProductsServicesTab> GetTabs(string nodeAliasPath)
        {
            return pageRetriever.Retrieve<ProductsServicesTab>(
                query => query
                        .Path(nodeAliasPath, PathTypeEnum.Children)
                        .OnCurrentSite()
                        .NestingLevel(1)
                        .OrderByAscending("NodeOrder"),
                cache => cache
                    .Key($"{nameof(ProductsServicesRepository)}|{nameof(GetTabs)}|{nodeAliasPath}")
                    .Dependencies((_, builder) => builder.PagePath(nodeAliasPath).PageOrder()));
        }
    }
}