using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Repository
{
    public class ColumnRepository
    {
        private readonly IPageRetriever pageRetriever;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnRepository"/> class that returns columns.
        /// </summary>
        /// <param name="pageRetriever">Retriever for pages based on given parameters.</param>
        public ColumnRepository(IPageRetriever pageRetriever)
        {
            this.pageRetriever = pageRetriever;
        }

        /// <summary>
        /// Returns an enumerable collection of Columns ordered by a position in the content tree.
        /// </summary>
        public IEnumerable<Column> GetColumns(string nodeAliasPath)
        {
            return pageRetriever.Retrieve<Column>(
                query => query
                    .Path(nodeAliasPath, PathTypeEnum.Children)
                    .OnCurrentSite()
                    .NestingLevel(1)
                    .OrderByAscending("NodeOrder"),
                cache => cache
                    .Key($"{nameof(ColumnRepository)}|{nameof(GetColumns)}|{nodeAliasPath}")
                    .Dependencies((_, builder) => builder.Pages(Column.CLASS_NAME).PageOrder()));
        }
    }
}