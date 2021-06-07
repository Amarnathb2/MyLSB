using CMS.DocumentEngine;
using CMS.Helpers;
using CMS.SiteProvider;
using Microsoft.AspNetCore.Mvc;
using SimpleMvcSitemap;
using System.Linq;

namespace MyLSB.Controllers
{

    public class XmlSitemapController
    {
        public ActionResult Index()
        {
            return CacheHelper.Cache(cs =>
            {
                if (cs.Cached)
                {
                    cs.CacheDependency = CacheHelper.GetCacheDependency($"node|{SiteContext.CurrentSiteName}|/|childnodes");
                }
                var XmlSitemapDocuments = DocumentHelper.GetDocuments()
                    .Types(ContentItemIdentifiers.XML_SITEMAP_PAGETYPES)
                    .OnCurrentSite()
                    .Path("/%")
                    .Culture(SiteContext.CurrentSite.DefaultVisitorCulture)
                    .CombineWithDefaultCulture(true)
                    .OrderBy("NodeLevel, NodeOrder, DocumentName")
                    .WhereFalse("NoIndex")
                    .Published()
                    .LatestVersion()
                    .Select(x => new SitemapNode(x.NodeAliasPath)
                    {
                        LastModificationDate = x.DocumentModifiedWhen.Date.ToLocalTime()
                    }).ToList();

                return new SitemapProvider().CreateSitemap(new SitemapModel(XmlSitemapDocuments));
            }, new CacheSettings(240, $"XmlSitemap|{SiteContext.CurrentSiteName}|/"));
        }
    }
}