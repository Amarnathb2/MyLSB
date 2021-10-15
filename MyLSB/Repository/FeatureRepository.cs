using System.Collections.Generic;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;

using Kentico.Content.Web.Mvc;

namespace MyLSB.Repository
{
    /// <summary>
    /// Represents a collection of Features.
    /// </summary>
    public class FeatureRepository
    {
        private readonly IPageRetriever pageRetriever;


        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureRepository"/> class that returns Features.
        /// </summary>
        /// <param name="pageRetriever">Retriever for pages based on given parameters.</param>
        public FeatureRepository(IPageRetriever pageRetriever)
        {
            this.pageRetriever = pageRetriever;
        }


        /// <summary>
        /// Returns an enumerable collection of Features ordered by a position in the content tree.
        /// </summary>
        public IEnumerable<Feature> GetFeatures(string path)
        {
            return pageRetriever.Retrieve<Feature>(
                query => query                
                    .Path(path, PathTypeEnum.Children)
                    .Columns("DocumentName, FeatureIsRate, FeatureRate, FeatureRateLabel")
                    .NestingLevel(1)
                    .OrderByAscending("NodeOrder"),
                cache => cache
                    .Key($"{nameof(FeatureRepository)}|{nameof(GetFeatures)}|{path}")
                    .Dependencies((_, builder) => builder.Pages(Feature.CLASS_NAME)
                                                         .PageOrder()
                                                         .PagePath(path)));
        }
    }
}