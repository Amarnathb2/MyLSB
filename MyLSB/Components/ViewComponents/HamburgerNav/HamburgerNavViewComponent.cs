using CMS.DocumentEngine;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using MyLSB.Models;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class HamburgerNavViewComponent : ViewComponent
    {
        private readonly NavigationRepository navigationRepository;
        private readonly LinkRepository linkRepository;

        public HamburgerNavViewComponent(NavigationRepository navigationRepository, LinkRepository linkRepository)
        {
            this.navigationRepository = navigationRepository;
            this.linkRepository = linkRepository;
        }

        public IViewComponentResult Invoke()
        {
            var hamburgerNav = HamburgerNavViewModel.GetViewModel(navigationRepository, linkRepository);

            return View("~/Components/ViewComponents/HamburgerNav/HamburgerNav.cshtml", hamburgerNav);
        }
    }
}
