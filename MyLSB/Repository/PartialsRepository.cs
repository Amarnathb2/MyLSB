using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using CMS.SiteProvider;
using Kentico.Content.Web.Mvc;
using MyLSB.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLSB.Repository
{
    /// <summary>
    /// Represents a collection of page content partials.
    /// </summary>
    public class PartialsRepository
    {
        private readonly IPageRetriever pageRetriever;
        private readonly RepositoryCacheHelper repositoryCacheHelper;
        private readonly PageRepository pageRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="panelRepository"/> class that returns page content partials.
        /// </summary>
        /// <param name="pageRetriever">Retriever for pages based on given parameters.</param>
        public PartialsRepository(IPageRetriever pageRetriever, RepositoryCacheHelper repositoryCacheHelper, PageRepository pageRepository)
        {
            this.pageRetriever = pageRetriever;
            this.repositoryCacheHelper = repositoryCacheHelper;
            this.pageRepository = pageRepository;
        }

        public IEnumerable<TreeNode> GetPartials(string nodeAliasPath)
        {
            return repositoryCacheHelper.CachePages(() =>
            {
                return DocumentHelper.GetDocuments()
                    .Path(nodeAliasPath, PathTypeEnum.Children)
                    .OnCurrentSite()
                    .NestingLevel(1)
                    // Get Type-specific columns for the subclasses returned.
                    .WithCoupledColumns()
                    .OrderByAscending("NodeOrder");

            }, $"{nameof(PartialsRepository)}|{nameof(GetPartials)}|{nodeAliasPath}", new[]
            {
                $"node|{SiteContext.CurrentSiteName}|{nodeAliasPath}",
                $"node|{SiteContext.CurrentSiteName}|{nodeAliasPath}|childnodes"
            }) ?? Enumerable.Empty<TreeNode>();
        }

        public Partials GetPartialsContainer(string nodeAliasPath)
        {
            return pageRetriever.Retrieve<Partials>(
                    query => query
                        .Path(nodeAliasPath, PathTypeEnum.Children)
                        .OnCurrentSite()
                        .NestingLevel(1)
                        .OrderByAscending("NodeOrder"),
                    cache => cache
                        .Key($"{nameof(PartialsRepository)}|{nameof(GetPartialsContainer)}|{nodeAliasPath}")
                        .Dependencies((_, builder) => builder.Pages(Partials.CLASS_NAME).PageOrder()))
                        .FirstOrDefault();
        }

        public string GetPartialsContainerPath(TreeNode node)
        {
            var path = node.IsLink ? pageRepository.GetNodeAliasPath(node.NodeLinkedNodeID) : node.NodeAliasPath;
            var container = GetPartialsContainer(path);

            if (container is null)
            {
                return String.Empty;
            }
            return container.NodeAliasPath;
        }
    }
}