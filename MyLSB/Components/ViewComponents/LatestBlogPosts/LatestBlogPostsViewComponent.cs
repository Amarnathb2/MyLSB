using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class LatestBlogPostsViewComponent : ViewComponent
    {
        private readonly BlogPostLinkRepository blogPostLinkRepository;
        private readonly SettingsRepository settingsRepository;

        public LatestBlogPostsViewComponent(BlogPostLinkRepository blogPostLinkRepository,SettingsRepository settingsRepository)
        {
            this.blogPostLinkRepository = blogPostLinkRepository;
            this.settingsRepository = settingsRepository;
        }

        public IViewComponentResult Invoke(LatestBlogPosts node)
        {
            var model = LatestBlogPostsViewModel.GetViewModel(node, blogPostLinkRepository, settingsRepository);
            return View("~/Components/ViewComponents/LatestBlogPosts/LatestBlogPosts.cshtml", model);
        }
    }
}