using MyLSB.Models;
using CMS.DocumentEngine.Types.Custom;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.DocumentEngine;

namespace MyLSB.Components
{
    public class AccordionViewModel : TreeNodeViewModel
    {
        public IEnumerable<Panel> Panels { get; set; }

        protected AccordionViewModel(TreeNode node) : base(node)
        {
        }

        public static AccordionViewModel GetViewModel(Accordion node, PanelRepository panelRepository)
        {
            return new AccordionViewModel(node)
            {
                Panels = panelRepository.GetPanels(node.NodeAliasPath)
            };
        }
    }
}
