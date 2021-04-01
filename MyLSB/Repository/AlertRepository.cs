using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using CMS.Helpers;
using CMS.SiteProvider;
using System.Collections.Generic;
using System.Linq;

namespace BancFirst.Repository
{
    public static class AlertRepository
    {
        public static List<Alert> GetAlerts(string path)
        {
            return CacheHelper.Cache(cs =>
            {
                if (cs.Cached) { cs.CacheDependency = CacheHelper.GetCacheDependency($"node|{SiteContext.CurrentSiteName}|{path}|childnodes"); }
                return AlertProvider.GetAlerts()
                    .OnSite("BancFirst")
                    .Culture("en-us")
                    .Path(path, PathTypeEnum.Children)
                    .OrderBy("NodeOrder")
                    .PublishedVersion()
                    .Published()
                    .ToList();

            }, new CacheSettings(10, $"Alerts|{SiteContext.CurrentSiteName}|{path}"));
        }
    }
}