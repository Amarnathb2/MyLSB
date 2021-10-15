using CMS.SiteProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB
{
    public class CacheKeys
    {
        //reminder: page type class names must be lower case

        public static readonly string[] Settings = {
            $"node|{SiteContext.CurrentSiteName}|custom.settings|all"
        };

        public static readonly string[] Navigation = {
            $"nodes|{SiteContext.CurrentSiteName}|custom.pagedefault|all",
            $"nodes|{SiteContext.CurrentSiteName}|custom.pagegroup|all",
            $"nodes|{SiteContext.CurrentSiteName}|custom.pageredirect|all"
        };

        public static readonly string[] AuxiliaryNavigation = {
            $"node|{SiteContext.CurrentSiteName}|{ContentItemIdentifiers.AUXILIARY_NAVIGATION}|childnodes"
        };

        public static readonly string[] SocialMedia = {
            $"node|{SiteContext.CurrentSiteName}|{ContentItemIdentifiers.SOCIAL_MEDIA}|childnodes"
        };

        public static readonly string[] PopularRequests = {
            $"node|{SiteContext.CurrentSiteName}|{ContentItemIdentifiers.POPULAR_REQUESTS}|childnodes"
        };

        public static readonly string[] LearnAboutUs = {
            $"node|{SiteContext.CurrentSiteName}|{ContentItemIdentifiers.LEARN_ABOUT_US}|childnodes"
        };
    }
}
