using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB
{
    public static class ContentItemIdentifiers
    {
        public const string SETTINGS = "/settings";
        public const string HOME = "/home";
        public const string AUXILIARY_NAVIGATION = "/settings/auxiliary-navigation";
        public const string SOCIAL_MEDIA = "/settings/social-media";
        public const string POPULAR_REQUESTS = "/settings/popular-requests";
        public const string LEARN_ABOUT_US = "/settings/learn-about-us";

        public const string SITEMAP_PAGETYPES = "custom.PageGroup;custom.PageDefault;custom.PageRedirect;custom.PageLocation;custom.PageEmployee";
        public const string XML_SITEMAP_PAGETYPES = "custom.PageDefault;custom.PageLocation;custom.pageEmployee";
    }
}
