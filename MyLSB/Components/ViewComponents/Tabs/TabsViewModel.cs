using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using MyLSB.Models;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components{
    public class TabsViewModel : TreeNodeViewModel
    {
        public IEnumerable<Panel> Panels { get; set; }

        protected TabsViewModel(TreeNode node) : base(node)
        {
        }

        public static TabsViewModel GetViewModel(Tabs node, PanelRepository panelRepository)
        {
            return new TabsViewModel(node)
            {
                Panels = panelRepository.GetPanels(node.NodeAliasPath)
            };
        }
    }
}
