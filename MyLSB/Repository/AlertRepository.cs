using System.Collections.Generic;

using CMS.DocumentEngine.Types.Custom;

using Kentico.Content.Web.Mvc;

namespace MyLSB.Repository
{
    /// <summary>
    /// Represents a collection of site alerts.
    /// </summary>
    public class AlertRepository
    {
        private readonly IPageRetriever pageRetriever;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlertRepository"/> class that returns alerts.
        /// </summary>
        /// <param name="pageRetriever">Retriever for pages based on given parameters.</param>
        public AlertRepository(IPageRetriever pageRetriever)
        {
            this.pageRetriever = pageRetriever;
        }


        /// <summary>
        /// Returns an enumerable collection of alerts ordered by a position in the content tree.
        /// </summary>
        public IEnumerable<Alert> GetAlerts()
        {
            return pageRetriever.Retrieve<Alert>(
                query => query
                    .Columns("AlertID, AlertStyle, AlertTitle, AlertText")
                    .OrderByAscending("NodeOrder"),
                cache => cache
                    .Key($"{nameof(AlertRepository)}|{nameof(GetAlerts)}")
                    .Dependencies((_, builder) => builder.Pages(Alert.CLASS_NAME).PageOrder()));
        }
    }
}