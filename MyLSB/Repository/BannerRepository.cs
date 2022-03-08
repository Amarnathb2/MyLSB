using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Repository
{
    public class BannerRepository
    {
        private readonly IPageRetriever pageRetriever;


        /// <summary>
        /// Initializes a new instance of the <see cref="BannerRepository"/> class that returns banners.
        /// </summary>
        /// <param name="pageRetriever">Retriever for pages based on given parameters.</param>
        public BannerRepository(IPageRetriever pageRetriever)
        {
            this.pageRetriever = pageRetriever;
        }

        /// <summary>
        /// Returns an enumerable collection of banners ordered by a position in the content tree.
        /// </summary>
        public IEnumerable<Banner> GetBanners(string path)
        {
            return pageRetriever.Retrieve<Banner>(
                query => query
                    .Path(path, PathTypeEnum.Children)
                    .OrderByAscending("NodeOrder"),
                cache => cache
                    .Key($"{nameof(BannerRepository)}|{nameof(GetBanners)}|{path}")
                    .Dependencies((_, builder) => builder.Pages(Banner.CLASS_NAME)
                        .PagePath(path, PathTypeEnum.Children)
                        .PageOrder()));
        }
    }
}
