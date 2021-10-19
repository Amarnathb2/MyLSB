using CMS.DocumentEngine.Types.Custom;
using Microsoft.AspNetCore.Mvc;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class AccordionViewComponent : ViewComponent
    {
        private readonly PanelRepository panelRepository;

        public AccordionViewComponent(PanelRepository panelRepository)
        {
            this.panelRepository = panelRepository;
        }

        public IViewComponentResult Invoke(Accordion node)
        {
            var accordion = AccordionViewModel.GetViewModel(node, panelRepository);

            if (accordion.Panels.Any())
            {
                if (node.Parent.ClassName == Partials.CLASS_NAME)
                {
                    return View("~/Components/ViewComponents/Accordion/AccordionContainer.cshtml", accordion);
                }
                return View("~/Components/ViewComponents/Accordion/Accordion.cshtml", accordion);
            }
            return Content(String.Empty);
        }
    }
}
