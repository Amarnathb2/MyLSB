using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using MyLSB.Models;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLSB.Modules.Hubspot;
using CMS.Helpers;

namespace MyLSB.Components
{
    public class LatestBlogPostsViewModel: TreeNodeViewModel
    {
        public string Heading { get; set; }
        public string Image { get; set; }
        public LinkViewModel Button { get; set; }
        public IEnumerable<BlogPost> Links { get; set; }

        protected LatestBlogPostsViewModel(TreeNode node) : base(node)
        {
        }

        public static LatestBlogPostsViewModel GetViewModel(LatestBlogPosts latestBlogPosts, BlogPostLinkRepository blogPostLinkRepository, SettingsRepository settingsRepository)
        {

            var lstBlogPosts = CacheHelper.Cache(cs =>
            {
                if (cs.Cached) { cs.CacheDependency = CacheHelper.GetCacheDependency($"nodeid|{latestBlogPosts.NodeID}"); }

                var settings = settingsRepository.GetSettings();
                HubspotAPI hubspotAPI = new HubspotAPI(settings.BlogPostsAPIUrl, settings.BlogTagsAPIUrl, settings.BlogsAPIKey, latestBlogPosts.LatestBlogPostsCount);

                return hubspotAPI.GetBlogPosts();
            }, new CacheSettings(10, $"hubspotapidatasource|{latestBlogPosts.NodeID}|blogposts"));

            return new LatestBlogPostsViewModel(latestBlogPosts)
            {
                Heading = latestBlogPosts.LatestBlogPostsHeading,
                Image = latestBlogPosts.LatestBlogPostsImage,
                Button = LinkViewModel.GetViewModel(latestBlogPosts.LatestBlogPostsButtonText, latestBlogPosts.LatestBlogPostsButtonUrl, latestBlogPosts.LatestBlogPostsButtonNewTab, latestBlogPosts.LatestBlogPostsButtonAriaLabel),
                Links = lstBlogPosts?.Any() ?? false ? lstBlogPosts : new List<BlogPost>()
            };
        }       
    }
}
