using System.Collections.Generic;
using System.Linq;
using CMS.DocumentEngine.Types.Custom;

using Kentico.Content.Web.Mvc;

namespace MyLSB.Repository
{
    public class SettingsRepository
    {
        private readonly IPageRetriever pageRetriever;

        public SettingsRepository(IPageRetriever pageRetriever)
        {
            this.pageRetriever = pageRetriever;
        }

        /// <summary>
        /// Returns the first settings node found in the content tree.
        /// </summary>
        public Settings GetSettings()
        {
            return pageRetriever.Retrieve<Settings>(
                query => query
                    .TopN(1),
                cache => cache
                    .Key($"{nameof(SettingsRepository)}|{nameof(GetSettings)}")
                    .Dependencies((_, builder) => builder.Pages(Settings.CLASS_NAME)))
                .FirstOrDefault();
        }
    }
}