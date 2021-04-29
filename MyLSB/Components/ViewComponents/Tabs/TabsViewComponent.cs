using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class TabsViewComponent : ViewComponent
    {
        private readonly PanelRepository panelRepository;

        public TabsViewComponent(PanelRepository panelRepository)
        {
            this.panelRepository = panelRepository;
        }

        public IViewComponentResult Invoke(Tabs node)
        {
            var tabs = TabsViewModel.GetViewModel(node, panelRepository);

            if (tabs.Panels.Any())
            {
                if (node.Parent.ClassName == Partials.CLASS_NAME)
                {
                    return View("~/Components/ViewComponents/Tabs/TabsContainer.cshtml", tabs);
                }
                return View("~/Components/ViewComponents/Tabs/Tabs.cshtml", tabs);
            }
            return Content(String.Empty);
        }
    }
}
