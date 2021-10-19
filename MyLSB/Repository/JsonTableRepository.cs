using CMS.DocumentEngine.Types.Custom;
using Kentico.Content.Web.Mvc;
using System.Linq;

namespace MyLSB.Repository
{
    public class JsonTableRepository
    {
        private readonly IPageRetriever pageRetriever;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonTableRepository"/> class that returns Json Tables.
        /// </summary>
        /// <param name="pageRetriever">Retriever for pages based on given parameters.</param>
        public JsonTableRepository(IPageRetriever pageRetriever)
        {
            this.pageRetriever = pageRetriever;
        }

        /// <summary>
        /// Returns a single Json Table.
        /// </summary>
        public JsonTable GetJsonTable(string jsonTableId)
        {
            return pageRetriever.Retrieve<JsonTable>(
                query => query
                    .OnCurrentSite()
                    .WhereEquals("JsonTableID", jsonTableId)
                    .TopN(1),
                cache => cache
                    .Key($"{nameof(JsonTableRepository)}|{nameof(GetJsonTable)}|{jsonTableId}")
                    .Dependencies((_, builder) => builder.Custom($"node|{jsonTableId}")))
                .FirstOrDefault();
        }
    }
}