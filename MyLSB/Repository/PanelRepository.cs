using MyLSB.Infrastructure;
using MyLSB.Models;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using CMS.SiteProvider;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Repository
{
    /// <summary>
    /// Represents a collection of panels.
    /// </summary>
    public class PanelRepository
    {
        private readonly IPageRetriever pageRetriever;

        /// <summary>
        /// Initializes a new instance of the <see cref="PanelRepository"/> class that returns panels.
        /// </summary>
        /// <param name="pageRetriever">Retriever for pages based on given parameters.</param>
        public PanelRepository(IPageRetriever pageRetriever)
        {
            this.pageRetriever = pageRetriever;
        }

        /// <summary>
        /// Returns an enumerable collection of Panels ordered by a position in the content tree.
        /// </summary>
        public IEnumerable<Panel> GetPanels(string nodeAliasPath)
        {
            return pageRetriever.Retrieve<Panel>(
                query => query
                        .Path(nodeAliasPath, PathTypeEnum.Children)
                        .OnCurrentSite()
                        .NestingLevel(1)
                        .OrderByAscending("NodeOrder"),
                cache => cache
                    .Key($"{nameof(PanelRepository)}|{nameof(GetPanels)}|{nodeAliasPath}")
                    .Dependencies((_, builder) => builder.Pages(Panel.CLASS_NAME).PageOrder()));
        }
    }
}