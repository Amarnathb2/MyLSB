using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using MyLSB.Models;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class LatestBlogPostsViewModel: TreeNodeViewModel
    {
        public string Heading { get; set; }
        public string Image { get; set; }
        public LinkViewModel Button { get; set; }
        public IEnumerable<BlogPostLink> Links { get; set; }

        protected LatestBlogPostsViewModel(TreeNode node) : base(node)
        {
        }

        public static LatestBlogPostsViewModel GetViewModel(LatestBlogPosts latestBlogPosts, BlogPostLinkRepository blogPostLinkRepository)
        {
            return new LatestBlogPostsViewModel(latestBlogPosts)
            {
                Heading = latestBlogPosts.LatestBlogPostsHeading,
                Image = latestBlogPosts.LatestBlogPostsImage,
                Button = LinkViewModel.GetViewModel(latestBlogPosts.LatestBlogPostsButtonText, latestBlogPosts.LatestBlogPostsButtonUrl, latestBlogPosts.LatestBlogPostsButtonNewTab, latestBlogPosts.LatestBlogPostsButtonAriaLabel),
                Links = blogPostLinkRepository.GetLinks(latestBlogPosts.NodeAliasPath)
            };
        }
    }
}
