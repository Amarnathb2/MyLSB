using Microsoft.AspNetCore.Mvc;
using MyLSB.Models;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class AuxiliaryNavViewComponent : ViewComponent
    {
        private readonly LinkRepository linkRepository;

        public AuxiliaryNavViewComponent(LinkRepository linkRepository)
        {
            this.linkRepository = linkRepository;
        }

        public IViewComponentResult Invoke()
        {
            var links = linkRepository.GetLinks(ContentItemIdentifiers.AUXILIARY_NAVIGATION)
                                      .Select(link => LinkViewModel.GetViewModel(link));

            return View("~/Components/ViewComponents/AuxiliaryNav/AuxiliaryNav.cshtml", links);
        }
    }
}
