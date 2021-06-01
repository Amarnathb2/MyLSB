using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using MyLSB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class BannerViewModel : TreeNodeViewModel
    {
        public string Heading { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public LinkViewModel Button { get; set; }

        protected BannerViewModel(TreeNode node) : base(node)
        {
        }

        public static BannerViewModel GetViewModel(Banner banner)
        {
            return new BannerViewModel(banner)
            {
                Heading = banner.BannerHeading,
                Text = banner.BannerText,
                Image = banner.BannerImage,
                Button = LinkViewModel.GetViewModel(banner.BannerButtonText, banner.BannerButtonUrl, banner.BannerButtonNewTab, banner.BannerButtonAriaLabel)
            };
        }
    }
}