using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using CMS.Helpers;
using CMS.SiteProvider;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyLSB.Models.Pages;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MyLSB.Controllers
{
    public class CustomRoutesController : Controller
    {
        private readonly PageRepository pageRepository;
        private readonly IPageUrlRetriever pageUrlRetriever;

        public CustomRoutesController(PageRepository pageRepository, IPageUrlRetriever pageUrlRetriever)
        {
            this.pageRepository = pageRepository;
            this.pageUrlRetriever = pageUrlRetriever;
        }

        public ActionResult PageGroup()
        {
            return NotFound();
        }

        public ActionResult Redirect()
        {
            string Path = RequestContext.URL.PathAndQuery.TrimEnd('/');
            int Site = SiteContext.CurrentSiteID;

            DataSet Ds = URLRedirection.RedirectionTableInfoProvider.GetRedirectionTables(Path, Site);
            string DestUrl = ValidationHelper.GetString(Ds.Tables[0].Rows[0]["RedirectionTargetURL"], "/");

            // Not an absolute URL? Build one.
            if (!DestUrl.StartsWith("http"))
            {
                DestUrl = URLHelper.ResolveUrl("~" + DestUrl);
            }

            if (ValidationHelper.GetString(Ds.Tables[0].Rows[0]["RedirectionType"], "301") == "301")
            {
                return new RedirectResult(DestUrl, true);
            }
            else
            {
                return new RedirectResult(DestUrl, false);
            }
        }
    }

    class PageGroupConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            string Path = "/" + (values["path"] == null ? string.Empty : values["path"].ToString().TrimEnd('/'));

            TreeNode Group = CacheHelper.Cache(cs =>
            {
                if (cs.Cached) { cs.CacheDependency = CacheHelper.GetCacheDependency($"node|{SiteContext.CurrentSiteName}|{Path}"); }
                return new DocumentQuery(PageGroup.CLASS_NAME)
                .OnCurrentSite()
                .CombineWithDefaultCulture()
                .Published()
                .Column("ClassName")
                .Path(Path)
                .FirstOrDefault();

            }, new CacheSettings(10, $"RouteConstraintPageGroup|{SiteContext.CurrentSiteName}|{Path}"));

            if (Group != null)
            {
                return Group.ClassName == PageGroup.CLASS_NAME;
            }

            return false;
        }
    }

    class RedirectConstraint : IRouteConstraint
    {

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            string Path = "/" + (values["path"] == null ? string.Empty : values["path"].ToString().ToLower().TrimEnd('/'));
            int Site = SiteContext.CurrentSiteID;

            List<string> OriginalUrls = CacheHelper.Cache(cs =>
            {
                if (cs.Cached) { cs.CacheDependency = CacheHelper.GetCacheDependency("urlredirection.redirectiontable|all"); }
                return URLRedirection.RedirectionTableInfoProvider.GetRedirectionTables(Site).Select(r => r.RedirectionOriginalURL.ToLower().TrimEnd('/')).ToList();

            }, new CacheSettings(10, $"{nameof(RedirectConstraint)}|{SiteContext.CurrentSiteName}|{Path}"));


            if (OriginalUrls.Contains(Path))
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }

}