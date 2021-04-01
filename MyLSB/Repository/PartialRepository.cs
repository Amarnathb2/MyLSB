using CMS.DocumentEngine;
using CMS.Helpers;
using CMS.SiteProvider;
using System.Collections.Generic;
using System.Linq;
using CMS.DocumentEngine.Types.Custom;

namespace BancFirst.Repository
{
    public static class PartialRepository
    {

        public static PartialsContainer GetPartialsContainer(string path)
        {
            return CacheHelper.Cache(cs =>
            {
                if (cs.Cached) { cs.CacheDependency = CacheHelper.GetCacheDependency($"node|{SiteContext.CurrentSiteName}|{path}|childnodes"); }

                return PartialsContainerProvider.GetPartialsContainers()
                    .OnSite("BancFirst")
                    .Culture("en-us")
                    .Path(path, PathTypeEnum.Children)
                    .NestingLevel(1)
                    .OrderBy("NodeOrder")
                    .PublishedVersion()
                    .Published()
                    .FirstOrDefault();

            }, new CacheSettings(10, $"PartialsContainer|{SiteContext.CurrentSiteName}|{path}"));
        }

        public static List<TreeNode> GetPartials(string path)
        {
            var Partials = CacheHelper.Cache(cs =>
            {
                if (cs.Cached) { cs.CacheDependency = CacheHelper.GetCacheDependency($"node|{SiteContext.CurrentSiteName}|{path}|childnodes"); }
                return DocumentHelper.GetDocuments()
                    .Path(path, PathTypeEnum.Children)
                    .NestingLevel(1)
                    // Get Type-specific columns for the subclasses returned.
                    .WithCoupledColumns()
                    .OrderBy("NodeOrder")
                    .ToList();

            }, new CacheSettings(10, $"PartialsContainers|{SiteContext.CurrentSiteName}|{path}"));

            return Partials;
        }

        public static IEnumerable<PartialCarouselSlide> GetPartialCarouselSlides(string path)
        {
            return CacheHelper.Cache(cs =>
            {
                if (cs.Cached) { cs.CacheDependency = CacheHelper.GetCacheDependency($"node|{SiteContext.CurrentSiteName}|{path}|childnodes"); }
                return PartialCarouselSlideProvider.GetPartialCarouselSlides()
                    .OnSite("BancFirst")
                    .Culture("en-us")
                    .Path(path, PathTypeEnum.Children)
                    .OrderBy("NodeOrder")
                    .PublishedVersion()
                    .Published()
                    .ToList();

            }, new CacheSettings(10, $"PartialCarouselSlides|{SiteContext.CurrentSiteName}|{path}"));
        }

        public static IEnumerable<PartialIcon> GetPartialIcons(string path)
        {
            return CacheHelper.Cache(cs =>
            {
                if (cs.Cached) { cs.CacheDependency = CacheHelper.GetCacheDependency($"node|{SiteContext.CurrentSiteName}|{path}|childnodes"); }
                return PartialIconProvider.GetPartialIcons()
                    .OnSite("BancFirst")
                    .Culture("en-us")
                    .Path(path, PathTypeEnum.Children)
                    .OrderBy("NodeOrder")
                    .PublishedVersion()
                    .Published()
                    .ToList();

            }, new CacheSettings(10, $"PartialIcons|{SiteContext.CurrentSiteName}|{path}"));
        }

        public static IEnumerable<PageBio> GetPageBios(string path)
        {
            return CacheHelper.Cache(cs =>
            {
                if (cs.Cached) { cs.CacheDependency = CacheHelper.GetCacheDependency($"node|{SiteContext.CurrentSiteName}|{path}|childnodes"); }
                return PageBioProvider.GetPageBios()
                    .OnSite("BancFirst")
                    .Culture("en-us")
                    .Path(path, PathTypeEnum.Children)
                    .OrderBy("NodeOrder")
                    .PublishedVersion()
                    .Published()
                    .ToList();

            }, new CacheSettings(10, $"PageBios|{SiteContext.CurrentSiteName}|{path}"));
        }

        public static IEnumerable<PartialPromo> GetPartialPromos(string path)
        {
            return CacheHelper.Cache(cs =>
            {
                if (cs.Cached) { cs.CacheDependency = CacheHelper.GetCacheDependency($"node|{SiteContext.CurrentSiteName}|{path}|childnodes"); }
                return PartialPromoProvider.GetPartialPromoes()
                    .OnSite("BancFirst")
                    .Culture("en-us")
                    .Path(path, PathTypeEnum.Children)
                    .OrderBy("NodeOrder")
                    .PublishedVersion()
                    .Published()
                    .ToList();

            }, new CacheSettings(10, $"PartialPromos|{SiteContext.CurrentSiteName}|{path}"));
        }

        public static IEnumerable<PartialAccordionPanel> GetPartialAccordionPanels(string path)
        {
            return CacheHelper.Cache(cs =>
            {
                if (cs.Cached) { cs.CacheDependency = CacheHelper.GetCacheDependency($"node|{SiteContext.CurrentSiteName}|{path}|childnodes"); }
                return PartialAccordionPanelProvider.GetPartialAccordionPanels()
                    .OnSite("BancFirst")
                    .Culture("en-us")
                    .Path(path, PathTypeEnum.Children)
                    .OrderBy("NodeOrder")
                    .PublishedVersion()
                    .Published()
                    .ToList();

            }, new CacheSettings(10, $"PartialAccordionPanels|{SiteContext.CurrentSiteName}|{path}"));
        }

        public static IEnumerable<PartialTabPane> GetPartialTabPanes(string path)
        {
            return CacheHelper.Cache(cs =>
            {
                if (cs.Cached) { cs.CacheDependency = CacheHelper.GetCacheDependency($"node|{SiteContext.CurrentSiteName}|{path}|childnodes"); }
                return PartialTabPaneProvider.GetPartialTabPanes()
                    .OnSite("BancFirst")
                    .Culture("en-us")
                    .Path(path, PathTypeEnum.Children)
                    .OrderBy("NodeOrder")
                    .PublishedVersion()
                    .Published()
                    .ToList();

            }, new CacheSettings(10, $"PartialTabPanes|{SiteContext.CurrentSiteName}|{path}"));
        }

        public static IEnumerable<PartialColumn> GetPartialColumns(string path)
        {
            return CacheHelper.Cache(cs =>
            {
                if (cs.Cached) { cs.CacheDependency = CacheHelper.GetCacheDependency($"node|{SiteContext.CurrentSiteName}|{path}|childnodes"); }
                return PartialColumnProvider.GetPartialColumns()
                    .OnSite("BancFirst")
                    .Culture("en-us")
                    .Path(path, PathTypeEnum.Children)
                    .OrderBy("NodeOrder")
                    .PublishedVersion()
                    .Published()
                    .ToList();

            }, new CacheSettings(10, $"PartialColumns|{SiteContext.CurrentSiteName}|{path}"));
        }

        public static IEnumerable<PartialGalleryItem> GetLandingCarouselItems(string path)
        {
            return CacheHelper.Cache(cs =>
            {
                if (cs.Cached) { cs.CacheDependency = CacheHelper.GetCacheDependency($"node|{SiteContext.CurrentSiteName}|{path}|childnodes"); }
                return PartialGalleryItemProvider.GetPartialGalleryItems()
                    .OnSite("BancFirst")
                    .Culture("en-us")
                    .Path(path, PathTypeEnum.Children)
                    .OrderBy("NodeOrder")
                    .PublishedVersion()
                    .Published()
                    .ToList();

            }, new CacheSettings(10, $"PartialGalleryItems|{SiteContext.CurrentSiteName}|{path}"));
        }
    }
}