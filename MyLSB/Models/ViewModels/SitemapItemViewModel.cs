using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using MyLSB.Repository;
using System.Linq;

namespace MyLSB.Models
{
    public class SitemapItemViewModel : MenuItemViewModel
    {
        protected SitemapItemViewModel(TreeNode node) : base(node)
        {
        }

        new public static SitemapItemViewModel GetViewModel(TreeNode node, NavigationRepository navigationRepository)
        {
            return new SitemapItemViewModel(node)
            {
                NodeLevel = node.NodeLevel,
                Text = node.DocumentName,
                Url = GetMenuItemUrl(node),
                NewTab = node.ClassName == PageRedirect.CLASS_NAME && ((PageRedirect)node).PageRedirectNewTab,
                Children = navigationRepository.GetSiteMapItems(node.NodeAliasPath)
                                               .Select(node => GetViewModel(node, navigationRepository)) ?? Enumerable.Empty<SitemapItemViewModel>()
            };
        }
    }
}
