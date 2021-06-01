using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Repository
{
    /// <summary>
    /// Represents a collection of site Statistics.
    /// </summary>
    public class StatisticRepository
    {
        private readonly IPageRetriever pageRetriever;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticRepository"/> class that returns Statistics.
        /// </summary>
        /// <param name="pageRetriever">Retriever for pages based on given parameters.</param>
        public StatisticRepository(IPageRetriever pageRetriever)
        {
            this.pageRetriever = pageRetriever;
        }

        /// <summary>
        /// Returns an enumerable collection of Statistics ordered by a position in the content tree.
        /// </summary>
        public IEnumerable<Statistic> GetStatistics(string path)
        {
            return pageRetriever.Retrieve<Statistic>(
                query => query
                    .Path(path, PathTypeEnum.Children)
                    .Columns("NodeID, StatisticName, StatisticStartValue, StatisticEndValue, StatisticIsCurrency")
                    .OrderByAscending("NodeOrder"),
                cache => cache
                    .Key($"{nameof(StatisticRepository)}|{nameof(GetStatistics)}")
                    .Dependencies((_, builder) => builder.Pages(Statistic.CLASS_NAME).PagePath(path, PathTypeEnum.Children)));
        }
    }
}