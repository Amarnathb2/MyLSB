using CMS.Helpers;
using CMS.SiteProvider;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;

namespace MyLSB.Controllers
{

    public class CustomRoutesController : Controller
    {

        public ActionResult Admin()
        {
            // get presentation url from CMS to gather http vs https
            Uri LiveSite = new Uri(SiteContext.CurrentSite.SitePresentationURL);
            string LiveSiteProtocol = LiveSite.Scheme + Uri.SchemeDelimiter;

            // get scheme plus administration domain name from CMS to = full admin URL
            string AdminUrl = LiveSiteProtocol + SiteContext.CurrentSite.DomainName;

            if (!string.IsNullOrEmpty(AdminUrl))
            {
                // Redirects to the specified administration interface URL
                return new RedirectResult(AdminUrl, true);
            }

            // If the administration interface URL not set, returns the homepage
            return new RedirectResult("/", false);
        }

        public ActionResult Redirect()
        {
            string url = RequestContext.URL.PathAndQuery;
            int site = SiteContext.CurrentSiteID;

            DataSet ds = URLRedirection.RedirectionTableInfoProvider.GetRedirectionTables(url, site);

            if (!DataHelper.DataSourceIsEmpty(ds))
            {

                string destUrl = ValidationHelper.GetString(ds.Tables[0].Rows[0]["RedirectionTargetURL"], "/");
                // Not an absolute URL? Build one.
                if (!destUrl.StartsWith("http"))
                {
                    destUrl = URLHelper.ResolveUrl("~" + destUrl);
                }

                if (ValidationHelper.GetString(ds.Tables[0].Rows[0]["RedirectionType"], "301") == "301")
                {
                    return new RedirectResult(destUrl, true);
                }
                else
                {
                    return new RedirectResult(destUrl, false);
                }
            }

            else
            {
                return new RedirectResult("/Page-Not-Found?Page=" + url, false);
            }
        }

        public ActionResult Error(string code)
        {
            return new RedirectResult("/Page-Not-Found", false);
        }
    }
}