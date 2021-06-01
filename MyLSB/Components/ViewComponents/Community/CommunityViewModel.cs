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
    public class CommunityViewModel : TreeNodeViewModel
    {
        public string Heading { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public LinkViewModel Button { get; set; }
        public IEnumerable<Statistic> Statistics { get; set; }

        protected CommunityViewModel(TreeNode node) : base(node)
        {
        }

        public static CommunityViewModel GetViewModel(Community community, StatisticRepository statisticRepository)
        {
            return new CommunityViewModel(community)
            {
                Heading = community.CommunityHeading,
                Text = community.CommunityText,
                Image = community.CommunityImage,
                Button = LinkViewModel.GetViewModel(community.CommunityButtonText, community.CommunityButtonUrl, community.CommunityButtonNewTab, community.CommunityButtonAriaLabel),
                Statistics = statisticRepository.GetStatistics(community.NodeAliasPath) ?? Enumerable.Empty<Statistic>()
            };
        }
    }
}