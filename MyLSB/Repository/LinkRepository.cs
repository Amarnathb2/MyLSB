using System.Collections.Generic;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;

using Kentico.Content.Web.Mvc;

namespace MyLSB.Repository
{
    /// <summary>
    /// Represents a collection of Links.
    /// </summary>
    public class LinkRepository
    {
        private readonly IPageRetriever pageRetriever;


        /// <summary>
        /// Initializes a new instance of the <see cref="LinkRepository"/> class that returns Links.
        /// </summary>
        /// <param name="pageRetriever">Retriever for pages based on given parameters.</param>
        public LinkRepository(IPageRetriever pageRetriever)
        {
            this.pageRetriever = pageRetriever;
        }


        /// <summary>
        /// Returns an enumerable collection of Links ordered by a position in the content tree.
        /// </summary>
        public IEnumerable<Link> GetLinks(string path)
        {
            return pageRetriever.Retrieve<Link>(
                query => query                
                    .Path(path, PathTypeEnum.Children)
                    .Columns("LinkText, LinkUrl, LinkNewTab, LinkAriaLabel, LinkIconClass, LinkIconImage")
                    .NestingLevel(1)
                    .OrderByAscending("NodeOrder"),
                cache => cache
                    .Key($"{nameof(LinkRepository)}|{nameof(GetLinks)}|{path}")
                    .Dependencies((_, builder) => builder.PageOrder()
                                                         .PagePath(path)));
        }
    }
}