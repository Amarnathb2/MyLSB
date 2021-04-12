using Microsoft.AspNetCore.Mvc;
using MyLSB.Models;
using MyLSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLSB.Components
{
    public class SocialMediaLinksViewComponent : ViewComponent
    {
        private readonly LinkRepository linkRepository;

        public SocialMediaLinksViewComponent(LinkRepository linkRepository)
        {
            this.linkRepository = linkRepository;
        }

        public IViewComponentResult Invoke()
        {
            var links = linkRepository.GetLinks(ContentItemIdentifiers.SOCIAL_MEDIA)
                                      .Select(link => LinkViewModel.GetViewModel(link));

            return View("~/Components/ViewComponents/SocialMediaLinks/SocialMediaLinks.cshtml", links);
        }
    }
}
