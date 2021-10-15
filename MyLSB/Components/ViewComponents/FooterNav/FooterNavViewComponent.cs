using Microsoft.AspNetCore.Mvc;
using MyLSB.Models;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components.ViewComponents.FooterNav
{
    public class FooterNavViewComponent : ViewComponent
    {
        private readonly LinkRepository linkRepository;

        public FooterNavViewComponent(LinkRepository linkRepository)
        {
            this.linkRepository = linkRepository;
        }

        public IViewComponentResult Invoke()
        {
            var model = FooterNavViewModel.GetViewModel(linkRepository);

            return View("~/Components/ViewComponents/FooterNav/FooterNav.cshtml", model);
        }
    }
}
