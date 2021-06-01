using System.Collections.Generic;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;

using Kentico.Content.Web.Mvc;

namespace MyLSB.Repository
{
    /// <summary>
    /// Represents a collection of Links.
    /// </summary>
    public class BlogPostLinkRepository
    {
        private readonly IPageRetriever pageRetriever;


        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPostLinkRepository"/> class that returns Links.
        /// </summary>
        /// <param name="pageRetriever">Retriever for pages based on given parameters.</param>
        public BlogPostLinkRepository(IPageRetriever pageRetriever)
        {
            this.pageRetriever = pageRetriever;
        }


        /// <summary>
        /// Returns an enumerable collection of Links ordered by a position in the content tree.
        /// </summary>
        public IEnumerable<BlogPostLink> GetLinks(string path)
        {
            return pageRetriever.Retrieve<BlogPostLink>(
                query => query
                    .Path(path, PathTypeEnum.Children)
                    .Columns(
                        nameof(BlogPostLink.BlogPostLinkText),
                        nameof(BlogPostLink.BlogPostLinkUrl),
                        nameof(BlogPostLink.BlogPostLinkNewTab),
                        nameof(BlogPostLink.BlogPostLinkAriaLabel),
                        nameof(BlogPostLink.BlogPostLinkPostCategory)
                    )
                    .NestingLevel(1)
                    .OrderByAscending("NodeOrder"),
                cache => cache
                    .Key($"{nameof(BlogPostLinkRepository)}|{nameof(GetLinks)}|{path}")
                    .Dependencies((_, builder) => builder.PageOrder()
                                                         .PagePath(path)));
        }
    }
}